namespace AutomationPageRecorder.UI
{
    partial class BrowserSettingsTabView
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BrowserSettingsTabView));
            this.label3 = new System.Windows.Forms.Label();
            this.grpRemoteConnection = new System.Windows.Forms.GroupBox();
            this.chkAutomaticallyStartServer = new System.Windows.Forms.CheckBox();
            this.lblRemoteHubStatus = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnTestRemoteHub = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRemoteHubUrl = new System.Windows.Forms.TextBox();
            this.lblWebDriverStatus = new System.Windows.Forms.Label();
            this.btnStartWebDriver = new System.Windows.Forms.Button();
            this.ddlBrowserToStart = new System.Windows.Forms.ComboBox();
            this.grdDesiredCapabilities = new System.Windows.Forms.PropertyGrid();
            this.btnLoadCapabilities = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lnkSeleniumDownloadPage = new System.Windows.Forms.LinkLabel();
            this.chkMaximizeBrowserWindow = new System.Windows.Forms.CheckBox();
            this.chkUseRemoteHub = new System.Windows.Forms.CheckBox();
            this.chkMFA = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Navegador:";
            // 
            // grpRemoteConnection
            // 
            this.grpRemoteConnection.Location = new System.Drawing.Point(0, 0);
            this.grpRemoteConnection.Name = "grpRemoteConnection";
            this.grpRemoteConnection.Size = new System.Drawing.Size(200, 100);
            this.grpRemoteConnection.TabIndex = 18;
            this.grpRemoteConnection.TabStop = false;
            // 
            // chkAutomaticallyStartServer
            // 
            this.chkAutomaticallyStartServer.AutoSize = true;
            this.chkAutomaticallyStartServer.Location = new System.Drawing.Point(73, 72);
            this.chkAutomaticallyStartServer.Name = "chkAutomaticallyStartServer";
            this.chkAutomaticallyStartServer.Size = new System.Drawing.Size(325, 17);
            this.chkAutomaticallyStartServer.TabIndex = 5;
            this.chkAutomaticallyStartServer.Text = "Run \"start_selenium_server.bat\" if Remote Driver is unavailable";
            this.chkAutomaticallyStartServer.UseVisualStyleBackColor = true;
            // 
            // lblRemoteHubStatus
            // 
            this.lblRemoteHubStatus.AutoSize = true;
            this.lblRemoteHubStatus.Location = new System.Drawing.Point(179, 53);
            this.lblRemoteHubStatus.Name = "lblRemoteHubStatus";
            this.lblRemoteHubStatus.Size = new System.Drawing.Size(62, 13);
            this.lblRemoteHubStatus.TabIndex = 4;
            this.lblRemoteHubStatus.Text = "(Not tested)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(70, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Remote Hub Status:";
            // 
            // btnTestRemoteHub
            // 
            this.btnTestRemoteHub.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTestRemoteHub.Location = new System.Drawing.Point(607, 26);
            this.btnTestRemoteHub.Name = "btnTestRemoteHub";
            this.btnTestRemoteHub.Size = new System.Drawing.Size(75, 23);
            this.btnTestRemoteHub.TabIndex = 2;
            this.btnTestRemoteHub.Text = "Test";
            this.btnTestRemoteHub.UseVisualStyleBackColor = true;
            this.btnTestRemoteHub.Click += new System.EventHandler(this.btnTestRemoteHub_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Hub URL:";
            // 
            // txtRemoteHubUrl
            // 
            this.txtRemoteHubUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRemoteHubUrl.Location = new System.Drawing.Point(69, 28);
            this.txtRemoteHubUrl.Name = "txtRemoteHubUrl";
            this.txtRemoteHubUrl.Size = new System.Drawing.Size(532, 22);
            this.txtRemoteHubUrl.TabIndex = 0;
            this.txtRemoteHubUrl.Text = "http://127.0.0.1:4444/wd/hub";
            // 
            // lblWebDriverStatus
            // 
            this.lblWebDriverStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblWebDriverStatus.AutoSize = true;
            this.lblWebDriverStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWebDriverStatus.Location = new System.Drawing.Point(590, 98);
            this.lblWebDriverStatus.Name = "lblWebDriverStatus";
            this.lblWebDriverStatus.Size = new System.Drawing.Size(54, 17);
            this.lblWebDriverStatus.TabIndex = 2;
            this.lblWebDriverStatus.Text = "Status";
            // 
            // btnStartWebDriver
            // 
            this.btnStartWebDriver.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartWebDriver.Location = new System.Drawing.Point(220, 93);
            this.btnStartWebDriver.Name = "btnStartWebDriver";
            this.btnStartWebDriver.Size = new System.Drawing.Size(75, 23);
            this.btnStartWebDriver.TabIndex = 6;
            this.btnStartWebDriver.Text = "Iniciar";
            this.btnStartWebDriver.UseVisualStyleBackColor = true;
            this.btnStartWebDriver.Click += new System.EventHandler(this.btnStartWebDriver_Click);
            // 
            // ddlBrowserToStart
            // 
            this.ddlBrowserToStart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlBrowserToStart.FormattingEnabled = true;
            this.ddlBrowserToStart.Items.AddRange(new object[] {
            "FireFox",
            "Edge"});
            this.ddlBrowserToStart.Location = new System.Drawing.Point(81, 95);
            this.ddlBrowserToStart.Name = "ddlBrowserToStart";
            this.ddlBrowserToStart.Size = new System.Drawing.Size(121, 24);
            this.ddlBrowserToStart.TabIndex = 5;
            // 
            // grdDesiredCapabilities
            // 
            this.grdDesiredCapabilities.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdDesiredCapabilities.Location = new System.Drawing.Point(0, 49);
            this.grdDesiredCapabilities.Name = "grdDesiredCapabilities";
            this.grdDesiredCapabilities.Size = new System.Drawing.Size(673, 269);
            this.grdDesiredCapabilities.TabIndex = 10;
            // 
            // btnLoadCapabilities
            // 
            this.btnLoadCapabilities.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadCapabilities.Location = new System.Drawing.Point(7, 20);
            this.btnLoadCapabilities.Name = "btnLoadCapabilities";
            this.btnLoadCapabilities.Size = new System.Drawing.Size(124, 23);
            this.btnLoadCapabilities.TabIndex = 11;
            this.btnLoadCapabilities.Text = "Carregar Capabilities";
            this.btnLoadCapabilities.UseVisualStyleBackColor = true;
            this.btnLoadCapabilities.Click += new System.EventHandler(this.btnLoadCapabilities_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(54, 207);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(900, 17);
            this.label4.TabIndex = 12;
            this.label4.Text = "Nota: A opção MFA ativada só será válido quando realizar primeiro login com MFA, " +
    "e então não precisará mais realizar e ficará salvo em cache.";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(13, 207);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(35, 40);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 13;
            this.pictureBox2.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(97, 233);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(239, 17);
            this.label5.TabIndex = 14;
            this.label5.Text = "Só funciona no Chrome browser.";
            // 
            // lnkSeleniumDownloadPage
            // 
            this.lnkSeleniumDownloadPage.AutoSize = true;
            this.lnkSeleniumDownloadPage.Location = new System.Drawing.Point(241, 191);
            this.lnkSeleniumDownloadPage.Name = "lnkSeleniumDownloadPage";
            this.lnkSeleniumDownloadPage.Size = new System.Drawing.Size(0, 16);
            this.lnkSeleniumDownloadPage.TabIndex = 15;
            this.lnkSeleniumDownloadPage.TabStop = true;
            this.lnkSeleniumDownloadPage.Visible = false;
            this.lnkSeleniumDownloadPage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkSeleniumDownloadPage_LinkClicked);
            // 
            // chkMaximizeBrowserWindow
            // 
            this.chkMaximizeBrowserWindow.AutoSize = true;
            this.chkMaximizeBrowserWindow.Checked = true;
            this.chkMaximizeBrowserWindow.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMaximizeBrowserWindow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkMaximizeBrowserWindow.Location = new System.Drawing.Point(347, 97);
            this.chkMaximizeBrowserWindow.Name = "chkMaximizeBrowserWindow";
            this.chkMaximizeBrowserWindow.Size = new System.Drawing.Size(252, 21);
            this.chkMaximizeBrowserWindow.TabIndex = 16;
            this.chkMaximizeBrowserWindow.Text = "Maximizar a tela do navegador";
            this.chkMaximizeBrowserWindow.UseVisualStyleBackColor = true;
            // 
            // chkUseRemoteHub
            // 
            this.chkUseRemoteHub.Location = new System.Drawing.Point(0, 0);
            this.chkUseRemoteHub.Name = "chkUseRemoteHub";
            this.chkUseRemoteHub.Size = new System.Drawing.Size(104, 24);
            this.chkUseRemoteHub.TabIndex = 17;
            // 
            // chkMFA
            // 
            this.chkMFA.AutoSize = true;
            this.chkMFA.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkMFA.Location = new System.Drawing.Point(347, 150);
            this.chkMFA.Name = "chkMFA";
            this.chkMFA.Size = new System.Drawing.Size(175, 20);
            this.chkMFA.TabIndex = 17;
            this.chkMFA.Text = "Ativar Microsoft MFA ";
            this.chkMFA.UseVisualStyleBackColor = true;
            // 
            // BrowserSettingsTabView
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.chkMFA);
            this.Controls.Add(this.chkMaximizeBrowserWindow);
            this.Controls.Add(this.lnkSeleniumDownloadPage);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblWebDriverStatus);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnStartWebDriver);
            this.Controls.Add(this.ddlBrowserToStart);
            this.Name = "BrowserSettingsTabView";
            this.Size = new System.Drawing.Size(694, 426);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.GroupBox grpRemoteConnection;
        public System.Windows.Forms.Label lblWebDriverStatus;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtRemoteHubUrl;
        public System.Windows.Forms.Button btnStartWebDriver;
        public System.Windows.Forms.ComboBox ddlBrowserToStart;
        private System.Windows.Forms.Label lblRemoteHubStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnTestRemoteHub;
        public System.Windows.Forms.PropertyGrid grdDesiredCapabilities;
        private System.Windows.Forms.Button btnLoadCapabilities;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkAutomaticallyStartServer;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.LinkLabel lnkSeleniumDownloadPage;
        private System.Windows.Forms.CheckBox chkMaximizeBrowserWindow;
        public System.Windows.Forms.CheckBox chkUseRemoteHub;
        private System.Windows.Forms.CheckBox chkMFA;
    }
}
