using MeteoSationProject.Interfaces.Observer;
using MeteoSationProject.Models.Ids;
using MeteoSationProject.Services;
using MeteoSationProject.Services.SerialHandler;
using System;
using System.ComponentModel;
using System.Data;
using System.IO.Ports;
using System.Windows.Forms;

namespace MeteoSationProject
{
    public partial class MeteoStationController : Form, Observer<Base>
    {

        private SerialPortHandler _serialPortHandler;
        private Configuration _configuration;
        private DataTable _dt = new DataTable();

        public MeteoStationController()
        {
            InitializeComponent();
            _configuration = new Configuration();
            _serialPortHandler = new SerialPortHandler();
            _serialPortHandler.RegisterObserver(this);
            gridData.DataSource = _dt;
        }

        private void btnToggleReading_Click(object sender, EventArgs e)
        {
            _serialPortHandler.ToggleReading();
            UpdateBtnToggle();
            toolStripConfiguration.Enabled = _serialPortHandler.IsReading;
        }

        private void MeteoStationController_Load(object sender, EventArgs e)
        {
            foreach (String port in SerialPort.GetPortNames())
            {
                cbPorts.Items.Add(port);
            }

            cbPorts.SelectedIndex = 0;

            _dt.Columns.Add("ID", typeof(int));
            _dt.Columns.Add("Is configured");
            _dt.Columns.Add("Type");
            _dt.Columns.Add("Data");
            _dt.Columns.Add("Alarme");
            _dt.Columns.Add("CheckSum");
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
                    isAlreadyInGrid = true;
                }
            }


            if (!isAlreadyInGrid)
            {
                _dt.Rows.Add(b._id, b.IsConfigured(), b.GetType(), b.GetConvertedData(), "", b.GetCalculatedCheckSum());
            }

            // Avoid thread error => only the thread that creates GUI elements can update them
            gridData.Invoke(new MethodInvoker(delegate
            {
                gridData.DataSource = null;
                gridData.DataSource = _dt;
                // Update the sorting of the grid by id
                gridData.Sort(gridData.Columns[0], ListSortDirection.Ascending);
                InsertIntoCombobox(b);
            }));
        }

        private void InsertIntoCombobox(Base b)
        {
            if (!cbIds.Enabled)
            {
                cbIds.Enabled = true;
                btnUpdateIntervals.Enabled = true;
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
        }

        private void btnUpdateAlarme_Click(object sender, EventArgs e)
        {
            int selectedId = (int)cbIds.SelectedItem;
            int minValue = (int)numMinAlarme.Value;
            int maxValue = (int)numMaxAlarme.Value;

            if (MinMaxEqualsOrZero(minValue, maxValue))
            {
                _serialPortHandler.UpdateAlarmeMesure(selectedId, minValue, maxValue);
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
                }
            }
        }

        private void toolStripExportConfiguration_Click(object sender, EventArgs e)
        {
            _configuration.ExportConfiguration(_serialPortHandler.GetAllMesures());
        }

        private void cbIds_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateNumerics((int)cbIds.SelectedItem);
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
    }
}
