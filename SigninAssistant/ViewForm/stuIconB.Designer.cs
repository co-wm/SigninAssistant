namespace SigninAssistant.ViewForm
{
    partial class stuIconB
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.picExam = new System.Windows.Forms.PictureBox();
            this.picSys = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picExam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSys)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(1, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(214, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "71174500007";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(0, 134);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(215, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "陈文明";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picExam
            // 
            this.picExam.BackgroundImage = global::SigninAssistant.Properties.Resources.上课默认头像;
            this.picExam.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picExam.Location = new System.Drawing.Point(111, 7);
            this.picExam.Name = "picExam";
            this.picExam.Size = new System.Drawing.Size(94, 124);
            this.picExam.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picExam.TabIndex = 2;
            this.picExam.TabStop = false;
            this.picExam.Click += new System.EventHandler(this.picture_Click);
            // 
            // picSys
            // 
            this.picSys.BackgroundImage = global::SigninAssistant.Properties.Resources.上课默认头像;
            this.picSys.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picSys.Location = new System.Drawing.Point(11, 7);
            this.picSys.Name = "picSys";
            this.picSys.Size = new System.Drawing.Size(94, 124);
            this.picSys.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picSys.TabIndex = 2;
            this.picSys.TabStop = false;
            this.picSys.Click += new System.EventHandler(this.picture_Click);
            // 
            // stuIconB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picExam);
            this.Controls.Add(this.picSys);
            this.Name = "stuIconB";
            this.Size = new System.Drawing.Size(215, 168);
            ((System.ComponentModel.ISupportInitialize)(this.picExam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSys)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picSys;
        private System.Windows.Forms.PictureBox picExam;
        public System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}
