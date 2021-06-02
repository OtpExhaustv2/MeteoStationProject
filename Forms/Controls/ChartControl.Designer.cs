namespace MeteoSationProject.Forms.Controls
{
    partial class ChartControl
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.cbChartIds = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnLaunchChart = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.SuspendLayout();
            // 
            // cbChartIds
            // 
            this.cbChartIds.FormattingEnabled = true;
            this.cbChartIds.Location = new System.Drawing.Point(478, 149);
            this.cbChartIds.Name = "cbChartIds";
            this.cbChartIds.Size = new System.Drawing.Size(131, 21);
            this.cbChartIds.Sorted = true;
            this.cbChartIds.TabIndex = 1;
            this.cbChartIds.SelectedIndexChanged += new System.EventHandler(this.cbChartIds_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(453, 152);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Id:";
            // 
            // chart
            // 
            chartArea3.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chart.Legends.Add(legend3);
            this.chart.Location = new System.Drawing.Point(19, 27);
            this.chart.Name = "chart";
            this.chart.Size = new System.Drawing.Size(404, 300);
            this.chart.TabIndex = 3;
            this.chart.Text = "chart";
            // 
            // btnLaunchChart
            // 
            this.btnLaunchChart.Location = new System.Drawing.Point(478, 177);
            this.btnLaunchChart.Name = "btnLaunchChart";
            this.btnLaunchChart.Size = new System.Drawing.Size(131, 23);
            this.btnLaunchChart.TabIndex = 4;
            this.btnLaunchChart.Text = "Launch";
            this.btnLaunchChart.UseVisualStyleBackColor = true;
            this.btnLaunchChart.Click += new System.EventHandler(this.btnLaunchChart_Click);
            // 
            // ChartControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnLaunchChart);
            this.Controls.Add(this.chart);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbChartIds);
            this.Name = "ChartControl";
            this.Size = new System.Drawing.Size(659, 376);
            this.Load += new System.EventHandler(this.ChartControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cbChartIds;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.Button btnLaunchChart;
    }
}
