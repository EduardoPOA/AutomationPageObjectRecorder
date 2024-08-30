namespace AutomationPageRecorder.UI
{
    partial class PageObjectSourceCodeView
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
            this.components = new System.ComponentModel.Container();
            this.btnGenerateSourceCode = new System.Windows.Forms.Button();
            this.txtSourceCode = new FastColoredTextBoxNS.FastColoredTextBox();
            this.cbCodeTemplates = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnConstructorProject = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.txtSourceCode)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGenerateSourceCode
            // 
            this.btnGenerateSourceCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerateSourceCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerateSourceCode.Location = new System.Drawing.Point(215, 4);
            this.btnGenerateSourceCode.Name = "btnGenerateSourceCode";
            this.btnGenerateSourceCode.Size = new System.Drawing.Size(83, 23);
            this.btnGenerateSourceCode.TabIndex = 3;
            this.btnGenerateSourceCode.Text = "Gerar Script";
            this.btnGenerateSourceCode.UseVisualStyleBackColor = true;
            this.btnGenerateSourceCode.Click += new System.EventHandler(this.btnGenerateSourceCode_Click);
            // 
            // txtSourceCode
            // 
            this.txtSourceCode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSourceCode.AutoScrollMinSize = new System.Drawing.Size(35, 18);
            this.txtSourceCode.BackBrush = null;
            this.txtSourceCode.BackColor = System.Drawing.Color.Azure;
            this.txtSourceCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSourceCode.CharHeight = 18;
            this.txtSourceCode.CharWidth = 12;
            this.txtSourceCode.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSourceCode.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.txtSourceCode.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtSourceCode.IsReplaceMode = false;
            this.txtSourceCode.Location = new System.Drawing.Point(3, 32);
            this.txtSourceCode.Name = "txtSourceCode";
            this.txtSourceCode.Paddings = new System.Windows.Forms.Padding(0);
            this.txtSourceCode.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.txtSourceCode.Size = new System.Drawing.Size(558, 355);
            this.txtSourceCode.TabIndex = 2;
            this.txtSourceCode.Zoom = 100;
            this.txtSourceCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSourceCode_KeyDown);
            // 
            // cbCodeTemplates
            // 
            this.cbCodeTemplates.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbCodeTemplates.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCodeTemplates.FormattingEnabled = true;
            this.cbCodeTemplates.Location = new System.Drawing.Point(77, 5);
            this.cbCodeTemplates.Name = "cbCodeTemplates";
            this.cbCodeTemplates.Size = new System.Drawing.Size(126, 24);
            this.cbCodeTemplates.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(2, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Linguagem:";
            // 
            // btnConstructorProject
            // 
            this.btnConstructorProject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConstructorProject.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConstructorProject.Location = new System.Drawing.Point(298, 4);
            this.btnConstructorProject.Name = "btnConstructorProject";
            this.btnConstructorProject.Size = new System.Drawing.Size(136, 23);
            this.btnConstructorProject.TabIndex = 6;
            this.btnConstructorProject.Text = "Construtor de Projeto";
            this.btnConstructorProject.UseVisualStyleBackColor = true;
            this.btnConstructorProject.Click += new System.EventHandler(this.btnConstructorProject_Click);
            // 
            // PageObjectSourceCodeView
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbCodeTemplates);
            this.Controls.Add(this.btnGenerateSourceCode);
            this.Controls.Add(this.btnConstructorProject);
            this.Controls.Add(this.txtSourceCode);
            this.Name = "PageObjectSourceCodeView";
            this.Size = new System.Drawing.Size(567, 392);
            ((System.ComponentModel.ISupportInitialize)(this.txtSourceCode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button btnGenerateSourceCode;
        public System.Windows.Forms.Button btnConstructorProject;
        public FastColoredTextBoxNS.FastColoredTextBox txtSourceCode;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox cbCodeTemplates;
    }
}
