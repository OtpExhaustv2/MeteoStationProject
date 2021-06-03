using MeteoSationProject.Forms;
using MeteoSationProject.Forms.Controls;
using MeteoSationProject.Interfaces.Observer;
using MeteoSationProject.Models;
using MeteoSationProject.Models.Ids;
using MeteoSationProject.Services;
using MeteoSationProject.Services.DBAccess_Provider;
using MeteoSationProject.Services.SerialHandler;
using MeteoSationProject.Services.UserProvider;
using System;
using System.ComponentModel;
using System.Data;
using System.IO.Ports;
using System.Windows.Forms;

namespace MeteoSationProject
{
    public partial class MeteoStationController : Form, Observer<Base>
    {

        internal static SerialPortHandler _serialPortHandler;
        private Configuration _configuration;
        private User user;
        private DataTable _dt = new DataTable();

        public MeteoStationController()
        {
            InitializeComponent();
            _configuration = new Configuration();
            _serialPortHandler = new SerialPortHandler();
            _serialPortHandler.RegisterObserver(this);
            gridData.DataSource = _dt;

            user = UserProvider.User;

            Tools.Config();
            DataReader.Read(gridUsers, "UserTable");
        }

        private void btnToggleReading_Click(object sender, EventArgs e)
        {
            _serialPortHandler.ToggleReading();
            UpdateBtnToggle();
            toolStripConfiguration.Enabled = _serialPortHandler.IsReading;
        }

        private void MeteoStationController_Load(object sender, EventArgs e)
        {
            // Fill the ports combobox
            foreach (String port in SerialPort.GetPortNames())
            {
                cbPorts.Items.Add(port);
            }

            cbPorts.SelectedIndex = 0;

            _dt.Columns.Add("ID", typeof(int));
            _dt.Columns.Add("Is configured");
            _dt.Columns.Add("Type");
            _dt.Columns.Add("Data");
            _dt.Columns.Add("State");
            _dt.Columns.Add("CheckSum");

            // Sort the data by id
            gridData.Sort(gridData.Columns[0], ListSortDirection.Ascending);


            if (user.Access._userCreation)
            {
                txtPassword.PasswordChar = '*';
                foreach (var entry in Adapter.GetAllAccess())
                {
                    cbAccess.Items.Add(entry.Key + " - " + entry.Value);
                }
                cbAccess.SelectedIndex = 0;
            }
            else
            {
                tpAddUser.Enabled = false;
            }

            if (!user.Access._allowConfigAlarm)
            {
                numMinAlarme.Enabled = false;
                numMaxAlarme.Enabled = false;
                btnUpdateAlarme.Enabled = false;
            }

            if (!user.Access._allowDestroyId)
            {
                btnDelete.Enabled = false;
            }

            // Center the data
            gridData.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridUsers.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void cbPorts_SelectedIndexChanged(object sender, EventArgs e)
        {
            _serialPortHandler.PortName(cbPorts.SelectedItem.ToString());
            _serialPortHandler.IsReading = false;
            UpdateBtnToggle();
        }

        private void UpdateBtnToggle()
        {
            btnToggleReading.Text = _serialPortHandler.IsReading ? "Stop reading" : "Start reading";
        }

        public void Update(Base b)
        {
            bool isAlreadyInGrid = false;
            foreach (DataRow row in _dt.Rows)
            {
                if (row["ID"].Equals(b._id))
                {
                    row["Is configured"] = b.IsConfigured();
                    row["Data"] = b.GetConvertedData();
                    row["CheckSum"] = b.GetCalculatedCheckSum();
                    row["State"] = b.GetState();
                    isAlreadyInGrid = true;
                }
            }

            if (!isAlreadyInGrid)
            {
                _dt.Rows.Add(b._id, b.IsConfigured(), b.GetType(), b.GetConvertedData(), b.GetState(), b.GetCalculatedCheckSum());
            }

            // Avoid thread error => only the thread that creates GUI elements can update them
            gridData.Invoke(new MethodInvoker(delegate
            {
                gridData.DataSource = null;
                gridData.DataSource = _dt;
                InsertIntoCombobox(b);
            }));
        }

        private void InsertIntoCombobox(Base b)
        {
            if (!cbIds.Enabled)
            {
                cbIds.Enabled = true;
                btnUpdateIntervals.Enabled = true;
                btnUpdateAlarme.Enabled = user.Access._allowConfigAlarm ? true : false;
            }
            // Checks if the id is already in the combobox
            if (!cbIds.Items.Contains(b._id) && (b._id > 0 && b._id <= 10))
            {
                cbIds.Items.Add(b._id);
                cbIds.SelectedIndex = 0;
            }
        }

        private void btnUpdateIntervals_Click(object sender, EventArgs e)
        {
            int selectedId = (int)cbIds.SelectedItem;
            int minValue = (int)numMinInterval.Value;
            int maxValue = (int)numMaxInterval.Value;

            if (MinMaxEqualsOrZero(minValue, maxValue))
            {
                _serialPortHandler.UpdateIntervalsMesure(selectedId, minValue, maxValue);
            }
            UpdateUpdateBtn();
        }

        private void btnUpdateAlarme_Click(object sender, EventArgs e)
        {
            if (user.Access._allowConfigAlarm)
            {
                int selectedId = (int)cbIds.SelectedItem;
                int minValue = (int)numMinAlarme.Value;
                int maxValue = (int)numMaxAlarme.Value;

                if (MinMaxEqualsOrZero(minValue, maxValue))
                {
                    _serialPortHandler.UpdateAlarmeMesure(selectedId, minValue, maxValue);
                }
            }
        }

        private bool MinMaxEqualsOrZero(int min, int max)
        {
            if (min == max || (min == 0 && max == 0))
            {
                MessageBox.Show("The values cannot have the same value or both equals to 0!");
                return false;
            }

            return true;
        }

        private void toolStripImportConfiguration_Click(object sender, EventArgs e)
        {
            string[] configurations = _configuration.ImportConfiguration();
            if (configurations != null)
            {
                foreach (string line in configurations)
                {
                    int[] splittedLine = Array.ConvertAll(line.Split(';'), data => int.Parse(data));
                    _serialPortHandler.UpdateIntervalsMesure(splittedLine[0], splittedLine[1], splittedLine[2]);
                    _serialPortHandler.UpdateAlarmeMesure(splittedLine[0], splittedLine[3], splittedLine[4]);
                    UpdateNumerics((int)cbIds.SelectedItem);
                    UpdateUpdateBtn();
                }
            }
        }

        // Export the configuration for every mesure id
        private void toolStripExportConfiguration_Click(object sender, EventArgs e)
        {
            _configuration.ExportConfiguration(_serialPortHandler.GetAllMesures());
        }

        private void cbIds_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateNumerics((int)cbIds.SelectedItem);
            UpdateUpdateBtn();
        }

        private void UpdateUpdateBtn()
        {
            Base b = _serialPortHandler.GetBaseById((int)cbIds.SelectedItem);
            btnUpdateAlarme.Enabled = b._isConfigured;
        }

        private void UpdateNumerics(int id)
        {
            Mesure mesure = (Mesure)_serialPortHandler.GetBaseById(id);
            if (mesure._isConfigured)
            {
                numMinInterval.Value = mesure.Intervals[0];
                numMaxInterval.Value = mesure.Intervals[1];
            }
            else if (numMinInterval.Value == 0 && numMaxInterval.Value == 0)
            {
                numMinInterval.Value = 0;
                numMaxInterval.Value = 0;
            }
        }

        private void MeteoStationController_FormClosing(object sender, FormClosingEventArgs e)
        {
            LoginController obj = (LoginController)Application.OpenForms["LoginController"];
            obj.Close();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text.Length == 0 || txtPassword.Text.Length == 0)
            {
                MessageBox.Show("Please, enter a valid username and password!");
                return;
            }
            string selectedItem = cbAccess.SelectedItem.ToString();
            int id = int.Parse(selectedItem.Split(new[] { " - " }, StringSplitOptions.None)[0]);
            if (Adapter.Insert(txtUsername.Text, txtPassword.Text, id))
            {
                txtPassword.Text = "";
                txtUsername.Text = "";
                cbAccess.SelectedIndex = 0;
            }
        }

        private void btnLoadUsers_Click(object sender, EventArgs e)
        {
            DataReader.Read(gridUsers, "UserTable");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure you want to delete this user?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                int index = gridUsers.CurrentCell.RowIndex;
                int id = int.Parse(gridUsers.Rows[index].Cells[0].Value.ToString());
                if (Adapter.Delete(id))
                {
                    MessageBox.Show("User deleted");
                    gridUsers.Rows.RemoveAt(index);
                }
                else
                {
                    MessageBox.Show("An error occured..");
                }
            }
        }

        private void accessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProfileDetails profileDetails = new ProfileDetails();
            profileDetails.ShowDialog();
        }

    }
}
