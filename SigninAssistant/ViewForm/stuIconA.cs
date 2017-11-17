using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SigninAssistant.ModelData;

namespace SigninAssistant
{
    public partial class stuIconA : UserControl
    {
        private Student _stuInfo = new Student();
        public bool isCheck = false;
        public stuIconA(Student stu)
        {
            _stuInfo = stu;
            InitializeComponent();
            label1.Text = stu.StudentName;
            label2.Text = stu.StudentId.ToString();
            pictureBox1.LoadAsync(stu.ImageUrl);
        }
        public Student StuInfo {
            get
            {
                return _stuInfo;
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if(this.Parent.Name == "ContainerA")
            {
                if (!this.isCheck)
                {
                    this.BackColor = Color.Orange;
                    label1.ForeColor = Color.White;
                    label2.ForeColor = Color.White;
                    this.isCheck = true;
                }
                else
                    returnOriginalBg();                    
            }
            else
            {
                if (!this.isCheck)
                {
                    this.BackColor = Color.LightGreen;
                    label1.ForeColor = Color.White;
                    label2.ForeColor = Color.White;
                    this.isCheck = true;
                }
                else
                    returnOriginalBg();
            }
            
        }

        private void returnOriginalBg()
        {
            this.BackColor = Control.DefaultBackColor;
            label1.ForeColor = Color.Black;
            label2.ForeColor = Color.Gray;
            this.isCheck = false;
        }
    }
}
