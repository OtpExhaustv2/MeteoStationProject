using MeteoSationProject.Models;
using MeteoSationProject.Services.UserProvider;
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
    public partial class ProfileDetails : Form
    {
        public ProfileDetails()
        {
            InitializeComponent();
            MaximizeBox = false;
        }

        private void ProfileDetails_Load(object sender, EventArgs e)
        {
            User user = UserProvider.User;
            lbUsername.Text = user._username;
            lbPassword.Text = user._password;
            lbAccessId.Text = user._accessId.ToString();

            checkCreateId.Checked = user.Access._allowCreateId;
            checkDestroyId.Checked = user.Access._allowDestroyId;
            checkConfigAlarm.Checked = user.Access._allowConfigAlarm;
            checkAddUser.Checked = user.Access._userCreation;
        }
    }
}
