using MeteoSationProject.Globals;
using MeteoSationProject.Models.Ids;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MeteoSationProject.Services
{
    class Configuration
    {

        private readonly string CONFIG_PATH = Globals.Path.ROOT_PATH + "/Files/config.csv";

        public Configuration()
        {
            if (!File.Exists(CONFIG_PATH))
            {
                File.Create(CONFIG_PATH);
            }
        }

        public string[] ImportConfiguration()
        {
            try
            {
                MessageBox.Show("Import succeded", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return File.ReadAllLines(CONFIG_PATH);
            }
            catch (IOException)
            {
                MessageBox.Show("The current file: " + CONFIG_PATH + " is already in use by another processus!");
            }

            return null;
        }

        public void ExportConfiguration(List<Mesure> mesures)
        {
            StringBuilder sbOutput = new StringBuilder();
            foreach (Mesure mesure in mesures)
            {
                sbOutput.AppendLine(string.Join(";", mesure.GetConfiguration()));
            }
            try
            {
                DialogResult dr = MessageBox.Show("Are you sure you want to override " +
                    "the current configuration with this one : \n" + sbOutput.ToString(), "Confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    File.WriteAllText(CONFIG_PATH, sbOutput.ToString());
                    MessageBox.Show("Export succeded", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (dr == DialogResult.No || dr == DialogResult.Cancel)
                {
                    MessageBox.Show("Export cancelled", "Cancel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (IOException)
            {
                MessageBox.Show("The current file: " + CONFIG_PATH + " is already in use by another processus!");
            }
        }

    }
}
