namespace MeteoSationProject
{
    partial class MeteoStationController
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

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cbPorts = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnToggleReading = new System.Windows.Forms.Button();
            this.gridData = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnUpdateAlarme = new System.Windows.Forms.Button();
            this.btnUpdateIntervals = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.cbIds = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.numMaxAlarme = new System.Windows.Forms.NumericUpDown();
            this.numMinAlarme = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numMaxInterval = new System.Windows.Forms.NumericUpDown();
            this.numMinInterval = new System.Windows.Forms.NumericUpDown();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.fichierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripConfiguration = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripImportConfiguration = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripExportConfiguration = new System.Windows.Forms.ToolStripMenuItem();
            this.profileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tpData = new System.Windows.Forms.TabPage();
            this.tpGraphic = new System.Windows.Forms.TabPage();
            this.tpAddUser = new System.Windows.Forms.TabPage();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.cbAccess = new System.Windows.Forms.ComboBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.tpUsersList = new System.Windows.Forms.TabPage();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnLoadUsers = new System.Windows.Forms.Button();
            this.gridUsers = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gridData)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxAlarme)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinAlarme)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinInterval)).BeginInit();
            this.menu.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tpData.SuspendLayout();
            this.tpAddUser.SuspendLayout();
            this.tpUsersList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridUsers)).BeginInit();
            this.SuspendLayout();
            // 
            // cbPorts
            // 
            this.cbPorts.FormattingEnabled = true;
            this.cbPorts.Location = new System.Drawing.Point(970, 99);
            this.cbPorts.Name = "cbPorts";
            this.cbPorts.Size = new System.Drawing.Size(121, 21);
            this.cbPorts.TabIndex = 0;
            this.cbPorts.SelectedIndexChanged += new System.EventHandler(this.cbPorts_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(906, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "COM port :";
            // 
            // btnToggleReading
            // 
            this.btnToggleReading.Location = new System.Drawing.Point(1096, 98);
            this.btnToggleReading.Name = "btnToggleReading";
            this.btnToggleReading.Size = new System.Drawing.Size(75, 23);
            this.btnToggleReading.TabIndex = 2;
            this.btnToggleReading.Text = "Start reading";
            this.btnToggleReading.UseVisualStyleBackColor = true;
            this.btnToggleReading.Click += new System.EventHandler(this.btnToggleReading_Click);
            // 
            // gridData
            // 
            this.gridData.AllowUserToAddRows = false;
            this.gridData.AllowUserToDeleteRows = false;
            this.gridData.AllowUserToResizeColumns = false;
            this.gridData.AllowUserToResizeRows = false;
            this.gridData.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.gridData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridData.Location = new System.Drawing.Point(87, 49);
            this.gridData.MultiSelect = false;
            this.gridData.Name = "gridData";
            this.gridData.ReadOnly = true;
            this.gridData.RowHeadersVisible = false;
            this.gridData.Size = new System.Drawing.Size(603, 386);
            this.gridData.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnUpdateAlarme);
            this.groupBox1.Controls.Add(this.btnUpdateIntervals);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cbIds);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.numMaxAlarme);
            this.groupBox1.Controls.Add(this.numMinAlarme);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.numMaxInterval);
            this.groupBox1.Controls.Add(this.numMinInterval);
            this.groupBox1.Location = new System.Drawing.Point(817, 149);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(455, 221);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // btnUpdateAlarme
            // 
            this.btnUpdateAlarme.Enabled = false;
            this.btnUpdateAlarme.Location = new System.Drawing.Point(302, 179);
            this.btnUpdateAlarme.Name = "btnUpdateAlarme";
            this.btnUpdateAlarme.Size = new System.Drawing.Size(121, 23);
            this.btnUpdateAlarme.TabIndex = 11;
            this.btnUpdateAlarme.Text = "Update alarme";
            this.btnUpdateAlarme.UseVisualStyleBackColor = true;
            this.btnUpdateAlarme.Click += new System.EventHandler(this.btnUpdateAlarme_Click);
            // 
            // btnUpdateIntervals
            // 
            this.btnUpdateIntervals.Enabled = false;
            this.btnUpdateIntervals.Location = new System.Drawing.Point(97, 179);
            this.btnUpdateIntervals.Name = "btnUpdateIntervals";
            this.btnUpdateIntervals.Size = new System.Drawing.Size(121, 23);
            this.btnUpdateIntervals.TabIndex = 10;
            this.btnUpdateIntervals.Text = "Update intervals";
            this.btnUpdateIntervals.UseVisualStyleBackColor = true;
            this.btnUpdateIntervals.Click += new System.EventHandler(this.btnUpdateIntervals_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(150, 141);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(22, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Id :";
            // 
            // cbIds
            // 
            this.cbIds.Enabled = false;
            this.cbIds.FormattingEnabled = true;
            this.cbIds.Location = new System.Drawing.Point(178, 138);
            this.cbIds.Name = "cbIds";
            this.cbIds.Size = new System.Drawing.Size(121, 21);
            this.cbIds.Sorted = true;
            this.cbIds.TabIndex = 8;
            this.cbIds.SelectedIndexChanged += new System.EventHandler(this.cbIds_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(232, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Max alarme :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(235, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Min alarme :";
            // 
            // numMaxAlarme
            // 
            this.numMaxAlarme.Location = new System.Drawing.Point(303, 92);
            this.numMaxAlarme.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numMaxAlarme.Minimum = new decimal(new int[] {
            999,
            0,
            0,
            -2147483648});
            this.numMaxAlarme.Name = "numMaxAlarme";
            this.numMaxAlarme.Size = new System.Drawing.Size(120, 20);
            this.numMaxAlarme.TabIndex = 5;
            // 
            // numMinAlarme
            // 
            this.numMinAlarme.Location = new System.Drawing.Point(303, 52);
            this.numMinAlarme.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numMinAlarme.Minimum = new decimal(new int[] {
            999,
            0,
            0,
            -2147483648});
            this.numMinAlarme.Name = "numMinAlarme";
            this.numMinAlarme.Size = new System.Drawing.Size(120, 20);
            this.numMinAlarme.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Max interval :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Min interval :";
            // 
            // numMaxInterval
            // 
            this.numMaxInterval.Location = new System.Drawing.Point(98, 91);
            this.numMaxInterval.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numMaxInterval.Minimum = new decimal(new int[] {
            999,
            0,
            0,
            -2147483648});
            this.numMaxInterval.Name = "numMaxInterval";
            this.numMaxInterval.Size = new System.Drawing.Size(120, 20);
            this.numMaxInterval.TabIndex = 1;
            // 
            // numMinInterval
            // 
            this.numMinInterval.Location = new System.Drawing.Point(98, 51);
            this.numMinInterval.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numMinInterval.Minimum = new decimal(new int[] {
            999,
            0,
            0,
            -2147483648});
            this.numMinInterval.Name = "numMinInterval";
            this.numMinInterval.Size = new System.Drawing.Size(120, 20);
            this.numMinInterval.TabIndex = 0;
            // 
            // menu
            // 
            this.menu.BackColor = System.Drawing.Color.White;
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fichierToolStripMenuItem,
            this.profileToolStripMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(1297, 24);
            this.menu.TabIndex = 5;
            this.menu.Text = "menuStrip1";
            // 
            // fichierToolStripMenuItem
            // 
            this.fichierToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripConfiguration});
            this.fichierToolStripMenuItem.Name = "fichierToolStripMenuItem";
            this.fichierToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fichierToolStripMenuItem.Text = "File";
            // 
            // toolStripConfiguration
            // 
            this.toolStripConfiguration.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripImportConfiguration,
            this.toolStripExportConfiguration});
            this.toolStripConfiguration.Enabled = false;
            this.toolStripConfiguration.Name = "toolStripConfiguration";
            this.toolStripConfiguration.Size = new System.Drawing.Size(148, 22);
            this.toolStripConfiguration.Text = "Configuration";
            // 
            // toolStripImportConfiguration
            // 
            this.toolStripImportConfiguration.Name = "toolStripImportConfiguration";
            this.toolStripImportConfiguration.Size = new System.Drawing.Size(110, 22);
            this.toolStripImportConfiguration.Text = "Import";
            this.toolStripImportConfiguration.Click += new System.EventHandler(this.toolStripImportConfiguration_Click);
            // 
            // toolStripExportConfiguration
            // 
            this.toolStripExportConfiguration.Name = "toolStripExportConfiguration";
            this.toolStripExportConfiguration.Size = new System.Drawing.Size(110, 22);
            this.toolStripExportConfiguration.Text = "Export";
            this.toolStripExportConfiguration.Click += new System.EventHandler(this.toolStripExportConfiguration_Click);
            // 
            // profileToolStripMenuItem
            // 
            this.profileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.accessToolStripMenuItem});
            this.profileToolStripMenuItem.Name = "profileToolStripMenuItem";
            this.profileToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.profileToolStripMenuItem.Text = "Profile";
            // 
            // accessToolStripMenuItem
            // 
            this.accessToolStripMenuItem.Name = "accessToolStripMenuItem";
            this.accessToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.accessToolStripMenuItem.Text = "Details";
            this.accessToolStripMenuItem.Click += new System.EventHandler(this.accessToolStripMenuItem_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tpData);
            this.tabControl.Controls.Add(this.tpGraphic);
            this.tabControl.Controls.Add(this.tpAddUser);
            this.tabControl.Controls.Add(this.tpUsersList);
            this.tabControl.Location = new System.Drawing.Point(0, 27);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(787, 497);
            this.tabControl.TabIndex = 6;
            // 
            // tpData
            // 
            this.tpData.Controls.Add(this.gridData);
            this.tpData.Location = new System.Drawing.Point(4, 22);
            this.tpData.Name = "tpData";
            this.tpData.Padding = new System.Windows.Forms.Padding(3);
            this.tpData.Size = new System.Drawing.Size(779, 471);
            this.tpData.TabIndex = 0;
            this.tpData.Text = "Data";
            this.tpData.UseVisualStyleBackColor = true;
            // 
            // tpGraphic
            // 
            this.tpGraphic.Location = new System.Drawing.Point(4, 22);
            this.tpGraphic.Name = "tpGraphic";
            this.tpGraphic.Padding = new System.Windows.Forms.Padding(3);
            this.tpGraphic.Size = new System.Drawing.Size(779, 471);
            this.tpGraphic.TabIndex = 1;
            this.tpGraphic.Text = "Graphic";
            this.tpGraphic.UseVisualStyleBackColor = true;
            // 
            // tpAddUser
            // 
            this.tpAddUser.Controls.Add(this.label9);
            this.tpAddUser.Controls.Add(this.label8);
            this.tpAddUser.Controls.Add(this.label7);
            this.tpAddUser.Controls.Add(this.btnAddUser);
            this.tpAddUser.Controls.Add(this.cbAccess);
            this.tpAddUser.Controls.Add(this.txtPassword);
            this.tpAddUser.Controls.Add(this.txtUsername);
            this.tpAddUser.Location = new System.Drawing.Point(4, 22);
            this.tpAddUser.Name = "tpAddUser";
            this.tpAddUser.Size = new System.Drawing.Size(779, 471);
            this.tpAddUser.TabIndex = 2;
            this.tpAddUser.Text = "Add user";
            this.tpAddUser.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(247, 159);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 13);
            this.label9.TabIndex = 6;
            this.label9.Text = "Access:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(240, 121);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "Password:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(239, 80);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Username:";
            // 
            // btnAddUser
            // 
            this.btnAddUser.Location = new System.Drawing.Point(299, 192);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(148, 23);
            this.btnAddUser.TabIndex = 3;
            this.btnAddUser.Text = "Add user";
            this.btnAddUser.UseVisualStyleBackColor = true;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // cbAccess
            // 
            this.cbAccess.FormattingEnabled = true;
            this.cbAccess.Location = new System.Drawing.Point(299, 155);
            this.cbAccess.Name = "cbAccess";
            this.cbAccess.Size = new System.Drawing.Size(148, 21);
            this.cbAccess.TabIndex = 2;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(299, 118);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(148, 20);
            this.txtPassword.TabIndex = 1;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(299, 77);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(148, 20);
            this.txtUsername.TabIndex = 0;
            // 
            // tpUsersList
            // 
            this.tpUsersList.Controls.Add(this.btnDelete);
            this.tpUsersList.Controls.Add(this.btnLoadUsers);
            this.tpUsersList.Controls.Add(this.gridUsers);
            this.tpUsersList.Location = new System.Drawing.Point(4, 22);
            this.tpUsersList.Name = "tpUsersList";
            this.tpUsersList.Size = new System.Drawing.Size(779, 471);
            this.tpUsersList.TabIndex = 3;
            this.tpUsersList.Text = "Users list";
            this.tpUsersList.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(379, 347);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnLoadUsers
            // 
            this.btnLoadUsers.Location = new System.Drawing.Point(197, 347);
            this.btnLoadUsers.Name = "btnLoadUsers";
            this.btnLoadUsers.Size = new System.Drawing.Size(75, 23);
            this.btnLoadUsers.TabIndex = 2;
            this.btnLoadUsers.Text = "Load";
            this.btnLoadUsers.UseVisualStyleBackColor = true;
            this.btnLoadUsers.Click += new System.EventHandler(this.btnLoadUsers_Click);
            // 
            // gridUsers
            // 
            this.gridUsers.AllowUserToAddRows = false;
            this.gridUsers.AllowUserToDeleteRows = false;
            this.gridUsers.AllowUserToResizeColumns = false;
            this.gridUsers.AllowUserToResizeRows = false;
            this.gridUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridUsers.Location = new System.Drawing.Point(117, 31);
            this.gridUsers.MultiSelect = false;
            this.gridUsers.Name = "gridUsers";
            this.gridUsers.ReadOnly = true;
            this.gridUsers.RowHeadersVisible = false;
            this.gridUsers.Size = new System.Drawing.Size(403, 290);
            this.gridUsers.TabIndex = 1;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // MeteoStationController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1297, 610);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnToggleReading);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbPorts);
            this.Controls.Add(this.menu);
            this.MainMenuStrip = this.menu;
            this.Name = "MeteoStationController";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Meteo Station";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MeteoStationController_FormClosing);
            this.Load += new System.EventHandler(this.MeteoStationController_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridData)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxAlarme)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinAlarme)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinInterval)).EndInit();
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tpData.ResumeLayout(false);
            this.tpAddUser.ResumeLayout(false);
            this.tpAddUser.PerformLayout();
            this.tpUsersList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridUsers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbPorts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnToggleReading;
        private System.Windows.Forms.DataGridView gridData;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numMaxInterval;
        private System.Windows.Forms.NumericUpDown numMinInterval;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numMaxAlarme;
        private System.Windows.Forms.NumericUpDown numMinAlarme;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbIds;
        private System.Windows.Forms.Button btnUpdateIntervals;
        private System.Windows.Forms.Button btnUpdateAlarme;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem fichierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripConfiguration;
        private System.Windows.Forms.ToolStripMenuItem toolStripImportConfiguration;
        private System.Windows.Forms.ToolStripMenuItem toolStripExportConfiguration;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tpData;
        private System.Windows.Forms.TabPage tpGraphic;
        private System.Windows.Forms.TabPage tpAddUser;
        private System.Windows.Forms.TabPage tpUsersList;
        private System.Windows.Forms.DataGridView gridUsers;
        private System.Windows.Forms.Button btnLoadUsers;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.ComboBox cbAccess;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ToolStripMenuItem profileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accessToolStripMenuItem;
    }
}

