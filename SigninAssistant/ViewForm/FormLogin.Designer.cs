namespace SigninAssistant
{
    partial class FormLogin
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.timerPolling = new System.Windows.Forms.Timer(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.BtnLogin = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txbClassId = new TxbTransprantDemo.TransprantTextBox();
            this.SuspendLayout();
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "签到助手";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // BtnLogin
            // 
            this.BtnLogin.BackColor = System.Drawing.Color.Transparent;
            this.BtnLogin.BackgroundImage = global::SigninAssistant.Properties.Resources.login_normal;
            this.BtnLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnLogin.FlatAppearance.BorderSize = 0;
            this.BtnLogin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.BtnLogin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.BtnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnLogin.Font = new System.Drawing.Font("Microsoft YaHei", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnLogin.ForeColor = System.Drawing.Color.White;
            this.BtnLogin.Location = new System.Drawing.Point(456, 352);
            this.BtnLogin.Name = "BtnLogin";
            this.BtnLogin.Size = new System.Drawing.Size(75, 34);
            this.BtnLogin.TabIndex = 0;
            this.BtnLogin.UseVisualStyleBackColor = false;
            this.BtnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
            this.BtnLogin.MouseEnter += new System.EventHandler(this.BtnLogin_MouseEnter);
            this.BtnLogin.MouseLeave += new System.EventHandler(this.BtnLogin_MouseLeave);
            this.BtnLogin.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BtnLogin_MouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 18F);
            this.label1.Location = new System.Drawing.Point(408, 280);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 31);
            this.label1.TabIndex = 3;
            this.label1.Text = "点击输入教室号";
            this.label1.Click += new System.EventHandler(this.txbClassId_Click);
            // 
            // txbClassId
            // 
            this.txbClassId.BackColor = System.Drawing.Color.White;
            this.txbClassId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbClassId.Font = new System.Drawing.Font("Microsoft YaHei", 18F);
            this.txbClassId.ForeColor = System.Drawing.Color.White;
            this.txbClassId.Location = new System.Drawing.Point(320, 277);
            this.txbClassId.Name = "txbClassId";
            this.txbClassId.Size = new System.Drawing.Size(350, 39);
            this.txbClassId.TabIndex = 2;
            this.txbClassId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txbClassId.Click += new System.EventHandler(this.txbClassId_Click);
            this.txbClassId.Enter += new System.EventHandler(this.txbClassName_Enter);
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txbClassId);
            this.Controls.Add(this.BtnLogin);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormLogin";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "签到助手";
            this.Load += new System.EventHandler(this.FormLogin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.Timer timerPolling;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button BtnLogin;
        private TxbTransprantDemo.TransprantTextBox txbClassId;
        private System.Windows.Forms.Label label1;
    }
}

