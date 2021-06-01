using MeteoSationProject.Services.SerialHandler;
using System;
using System.IO.Ports;
using System.Windows.Forms;

namespace MeteoSationProject
{
    public partial class MeteoStationController : Form
    {

        private SerialPortHandler _serialPortHandler;

        public MeteoStationController()
        {
            InitializeComponent();
            _serialPortHandler = new SerialPortHandler();
        }

    }
}
