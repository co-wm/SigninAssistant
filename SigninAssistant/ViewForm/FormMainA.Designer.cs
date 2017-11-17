namespace SigninAssistant
{
    partial class FormMainA
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.btnOk = new System.Windows.Forms.Button();
            this.fLPStuInfo = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAbsent = new System.Windows.Forms.Button();
            this.btnAttend = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnTrans = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("SimSun", 18F);
            this.label1.Location = new System.Drawing.Point(20, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("SimSun", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(1030, 17);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(390, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "label1";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.Transparent;
            this.btnOk.FlatAppearance.BorderSize = 0;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Font = new System.Drawing.Font("Microsoft YaHei", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOk.Location = new System.Drawing.Point(1211, 725);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(80, 40);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = false;
            // 
            // fLPStuInfo
            // 
            this.fLPStuInfo.AutoScroll = true;
            this.fLPStuInfo.Location = new System.Drawing.Point(24, 208);
            this.fLPStuInfo.Margin = new System.Windows.Forms.Padding(1);
            this.fLPStuInfo.Name = "fLPStuInfo";
            this.fLPStuInfo.Size = new System.Drawing.Size(1396, 500);
            this.fLPStuInfo.TabIndex = 2;
            // 
            // btnAbsent
            // 
            this.btnAbsent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(64)))));
            this.btnAbsent.FlatAppearance.BorderSize = 0;
            this.btnAbsent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbsent.Font = new System.Drawing.Font("SimHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAbsent.ForeColor = System.Drawing.Color.White;
            this.btnAbsent.Location = new System.Drawing.Point(24, 172);
            this.btnAbsent.Name = "btnAbsent";
            this.btnAbsent.Size = new System.Drawing.Size(100, 35);
            this.btnAbsent.TabIndex = 3;
            this.btnAbsent.Text = "未到学生";
            this.btnAbsent.UseVisualStyleBackColor = false;
            this.btnAbsent.Click += new System.EventHandler(this.btnAbsent_Click);
            // 
            // btnAttend
            // 
            this.btnAttend.BackColor = System.Drawing.Color.Transparent;
            this.btnAttend.FlatAppearance.BorderSize = 0;
            this.btnAttend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAttend.Font = new System.Drawing.Font("SimHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAttend.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.btnAttend.Location = new System.Drawing.Point(131, 172);
            this.btnAttend.Name = "btnAttend";
            this.btnAttend.Size = new System.Drawing.Size(100, 35);
            this.btnAttend.TabIndex = 3;
            this.btnAttend.Text = "已到学生";
            this.btnAttend.UseVisualStyleBackColor = false;
            this.btnAttend.Click += new System.EventHandler(this.btnAttend_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft YaHei", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClose.Location = new System.Drawing.Point(1306, 725);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 40);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("SimSun", 18F);
            this.label3.Location = new System.Drawing.Point(115, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(233, 24);
            this.label3.TabIndex = 4;
            this.label3.Text = "label3";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("SimSun", 18F);
            this.label4.Location = new System.Drawing.Point(405, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(233, 24);
            this.label4.TabIndex = 4;
            this.label4.Text = "label3";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("SimSun", 18F);
            this.label5.Location = new System.Drawing.Point(794, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(150, 24);
            this.label5.TabIndex = 5;
            this.label5.Text = "label3";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("SimSun", 18F);
            this.label6.Location = new System.Drawing.Point(996, 124);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(150, 24);
            this.label6.TabIndex = 6;
            this.label6.Text = "label3";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("SimSun", 18F);
            this.label7.Location = new System.Drawing.Point(1207, 124);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(150, 24);
            this.label7.TabIndex = 7;
            this.label7.Text = "label3";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnTrans
            // 
            this.btnTrans.BackColor = System.Drawing.Color.Transparent;
            this.btnTrans.BackgroundImage = global::SigninAssistant.Properties.Resources.A_normalImage;
            this.btnTrans.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTrans.FlatAppearance.BorderSize = 0;
            this.btnTrans.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnTrans.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnTrans.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTrans.Location = new System.Drawing.Point(24, 720);
            this.btnTrans.Name = "btnTrans";
            this.btnTrans.Size = new System.Drawing.Size(180, 50);
            this.btnTrans.TabIndex = 8;
            this.btnTrans.UseVisualStyleBackColor = false;
            this.btnTrans.Click += new System.EventHandler(this.btnTrans_Click);
            this.btnTrans.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnTrans_MouseDown);
            this.btnTrans.MouseEnter += new System.EventHandler(this.btnTrans_MouseEnter);
            this.btnTrans.MouseLeave += new System.EventHandler(this.btnTrans_MouseLeave);
            this.btnTrans.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnTrans_MouseUp);
            // 
            // FormMainA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SigninAssistant.Properties.Resources.上课考勤背景;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1445, 804);
            this.Controls.Add(this.btnTrans);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnAttend);
            this.Controls.Add(this.btnAbsent);
            this.Controls.Add(this.fLPStuInfo);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormMainA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SigninAssistant";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.FlowLayoutPanel fLPStuInfo;
        private System.Windows.Forms.Button btnAbsent;
        private System.Windows.Forms.Button btnAttend;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnTrans;
    }
}