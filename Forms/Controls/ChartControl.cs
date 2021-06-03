using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MeteoSationProject.Interfaces.Observer;
using MeteoSationProject.Models.Ids;
using System.Windows.Forms.DataVisualization.Charting;
using MeteoSationProject.Services.SerialHandler;
using System.Threading;

namespace MeteoSationProject.Forms.Controls
{
    public partial class ChartControl : UserControl, Observer<Base>
    {

        private Dictionary<int, List<int>> _dataById = new Dictionary<int, List<int>>();
        private Series _series = new Series("Data");
        private bool _launched = false;
        private readonly int MAX_DATA_TO_SHOW = 10;

        public ChartControl()
        {
            InitializeComponent();
        }

        private void ChartControl_Load(object sender, EventArgs e)
        {
            MeteoStationController._serialPortHandler.RegisterObserver(this);
            _series.ChartType = SeriesChartType.Spline;
            chart.Series.Add(_series);
        }

        public void Update(Base b)
        {
            if (b._isConfigured)
            {
                if (!cbChartIds.Items.Contains(b._id))
                {
                    cbChartIds.Invoke(new MethodInvoker(delegate
                    {
                        cbChartIds.Items.Add(b._id);
                    }));
                }
                if (!_dataById.ContainsKey(b._id))
                {
                    List<int> data = new List<int>();
                    data.Add((int)b.GetConvertedData());
                    _dataById.Add(b._id, data);
                }
                else
                {
                    List<int> data = _dataById[b._id];
                    data.Add((int)b.GetConvertedData());
                    if (data.Count > MAX_DATA_TO_SHOW)
                    {
                        data.RemoveAt(0);
                    }
                }
                if (_launched)
                {
                    cbChartIds.Invoke(new MethodInvoker(delegate
                    {
                        int index = int.Parse(cbChartIds.SelectedItem.ToString());
                        if (_dataById.ContainsKey(index))
                        {
                            List<int> d = _dataById[index];
                            UpdateChart(d[d.Count - 1]);
                        }
                    }));

                    chart.Invoke(new MethodInvoker(delegate
                    {
                        if (_series.Points.Count > MAX_DATA_TO_SHOW)
                        {
                            _series.Points.RemoveAt(0);
                            chart.ResetAutoValues();
                        }
                    }));
                }
            }

        }

        private void UpdateChart(int data)
        {
            chart.Invoke(new MethodInvoker(delegate
            {
                _series.Points.AddY(data);
            }));
        }

        private void cbChartIds_SelectedIndexChanged(object sender, EventArgs e)
        {
            _series.Points.Clear();
            _launched = false;
            UpdateBtnLaunch();
        }

        private void btnLaunchChart_Click(object sender, EventArgs e)
        {
            _launched = !_launched;
            UpdateBtnLaunch();
        }

        private void UpdateBtnLaunch()
        {
            btnLaunchChart.Text = _launched ? "Stop" : "Launch";
        }
    }
}
