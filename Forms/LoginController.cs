using MeteoSationProject.Models;
using MeteoSationProject.Services.DBAccess_Provider;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MeteoSationProject.Forms
{
    public partial class LoginController : Form
    {
        public LoginController()
        {
            InitializeComponent();
            MaximizeBox = false;
            txtPassword.PasswordChar = '*';
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            User user = Adapter.Connection(txtUsername.Text, txtPassword.Text);
            if (user != null)
            {
                Hide();
                new MeteoStationController().Show();
            }
            else
            {
                MessageBox.Show("Wrong credentials");
            }
        }

    }
}
