using Newtonsoft.Json;
using SigninAssistant;
using SigninAssistant.FunctionBLL;
using SigninAssistant.ModelData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SigninAssistant
{
    public partial class FormMainA : Form
    {
        private int numA;
        private int numB;
        private stuIconA[] iconListA;
        private stuIconA[] iconListB;
        public FormMainA()
        {
            InitializeComponent();
            fLPStuInfo.Name = "ContainerA";
            dealStuIconInfo("A");
        }
        private void FormMain_Load(object sender, EventArgs e)
        {
            showDateInfo();
            FormLogin.NotifyDoubleClick += new FormLogin.DoubleClickEventHandle(frmMainShowControl);
        }

        /// <summary>
        /// 初始化界面显示信息
        /// </summary>
        private void showDateInfo()
        {
            label1.Text = "教学楼" + CommonData.ClassName;
            label2.Text = DateTime.Now.ToString("yyyy/MM/dd") + " " +
                CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(DateTime.Now.DayOfWeek) + " " +
                DateTime.Now.ToString("HH:mm");
            label3.Text = CommonData.TheLesson.CourseName;
            label4.Text = CommonData.TheLesson.TeacherName;
            label5.Text = CommonData.TheLesson.StudentInfo.Count().ToString();
            label6.Text = numB.ToString();
            label7.Text = numA.ToString();
        }
        /// <summary>
        /// 生成学生头像图标
        /// </summary>
        /// <param name="flag"> A：未到学生容器 B：已到学生容器 </param>
        private void dealStuIconInfo(string flag)
        {
            if (flag == "A")
            {
                fLPStuInfo.Name = "ContainerA";
            }
            else
            {
                fLPStuInfo.Name = "ContainerB";
            }
            if (CommonBLL.getLessonInfoByClassRoomID(CommonData.ClassId) == 0)
            {
                MessageBox.Show("网络请求出错");
                return;
            }
            //已到学生人数
            numA = (from stu in CommonData.TheLesson.StudentInfo
                    where stu.IsLate == ""
                    select stu.IsLate).Count();
            //未到学生人数
            numB = CommonData.TheLesson.StudentInfo.Count - numA;
            iconListA = new stuIconA[numA];
            iconListB = new stuIconA[numB];
            if (flag == "A")
            {
                for (int i = 0,k = 0; i < numA + numB; i++)
                {
                    if (CommonData.TheLesson.StudentInfo[i].IsLate == "")
                    {
                        iconListA[k] = new stuIconA(CommonData.TheLesson.StudentInfo[i]);
                        fLPStuInfo.Controls.Add(iconListA[k]);
                        k++;
                    }
                }
            }
            else
            {
                for (int i = 0,k =0; i < numB + numA; i++)
                {
                    if (CommonData.TheLesson.StudentInfo[i].IsLate != "")
                    {
                        iconListB[k] = new stuIconA(CommonData.TheLesson.StudentInfo[i]);
                        fLPStuInfo.Controls.Add(iconListB[k]);
                        k++;
                    }
                }
            }
        }

        private void frmMainShowControl()
        {
            if (this.Visible)
            {
                this.Hide();
            }
            else
            {
                this.Show();
            }
        }
        /// <summary>
        /// 时钟定时器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_Tick(object sender, EventArgs e)
        {
            label2.Text = DateTime.Now.ToString("yyyy/MM/dd") + " " +
                CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(DateTime.Now.DayOfWeek) + " " +
                DateTime.Now.ToString("HH:mm");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        /// <summary>
        /// 未到学生按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAbsent_Click(object sender, EventArgs e)
        {
            fLPStuInfo.Controls.Clear();
            dealStuIconInfo("A");
            btnAbsent.BackColor = Color.Orange;
            btnAbsent.ForeColor = Color.White;
            btnAttend.BackColor = Color.Transparent;
            btnAttend.ForeColor = Color.Gray;
            btnTrans.BackgroundImage = Properties.Resources.A_normalImage;
        }
        /// <summary>
        /// 已到学生按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAttend_Click(object sender, EventArgs e)
        {
            fLPStuInfo.Controls.Clear();
            dealStuIconInfo("B");
            btnAttend.BackColor = Color.LightGreen;
            btnAttend.ForeColor = Color.White;
            btnAbsent.BackColor = Color.Transparent;
            btnAbsent.ForeColor = Color.Gray;
            btnTrans.BackgroundImage = Properties.Resources.B_normalImage;

        }

        /// <summary>
        /// 点击补签或撤销补签
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTrans_Click(object sender, EventArgs e)
        {
            //学生补签
            if (fLPStuInfo.Name == "ContainerA")
            {
                if (iconListA.Count() == 0)
                {
                    MessageBox.Show("没有未到学生，无法补签");
                    return;
                }
                else
                {
                    if(signInOrsignOut(0, iconListA))
                    {
                        btnAttend_Click(sender, e);
                        label6.Text = numB.ToString();
                        label7.Text = numA.ToString();
                    }
                        
                }
            }
            //签到撤回
            else
            {
                if (iconListB.Count() == 0)
                {
                    MessageBox.Show("没有已到学生，无法补签");
                    return;
                }
                else
                {
                    if(signInOrsignOut(-1, iconListB))
                    {
                        btnAbsent_Click(sender, e);
                        label6.Text = numB.ToString();
                        label7.Text = numA.ToString();
                    }
                        
                }
            }
        }

        private bool signInOrsignOut(int intFlag, stuIconA[] iconList)
        {          
            string stuIdList = "";
            List<object> list = new List<object>();
            for (int i = 0; i < iconList.Count(); i++)
            {
                if (iconList[i].isCheck)
                {
                    var stuJosn = new
                    {
                        IsLate = intFlag,
                        CardNo = iconList[i].StuInfo.cardno,
                        StudentId = iconList[i].StuInfo.StudentId,
                        StudentName = iconList[i].StuInfo.StudentName,
                        GradeId = iconList[i].StuInfo.GradeId,
                        ClassId = iconList[i].StuInfo.ClassId,
                        WeekDay = DateTime.Now.DayOfWeek,
                        ClassHour = CommonData.TheLesson.ClassHour,
                        StartTime = CommonData.TheLesson.StartTime,
                        isWalk = iconList[i].StuInfo.isWalk,
                        ClassroomID = CommonData.ClassId,
                        CourseName = CommonData.TheLesson.CourseName
                    };
                    list.Add(stuJosn);
                }
            }
            stuIdList = JsonConvert.SerializeObject(list);
            if (stuIdList != "[]")
            {
                //发送给服务端 学生签到   
                if (CommonBLL.studentSginIn(stuIdList) == 1)
                {
                    MessageBox.Show("补签成功");
                    return true;
                }
                else
                {
                    MessageBox.Show("未补签成功");
                    return false;
                }

            }
            else
            {
                MessageBox.Show("请选择签到学生");
                return false;
            }
        }

        /// <summary>
        /// 签到按钮Down
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTrans_MouseDown(object sender, MouseEventArgs e)
        {
            if (fLPStuInfo.Name == "ContainerA")
                btnTrans.BackgroundImage = Properties.Resources.A_downImage;
            else
                btnTrans.BackgroundImage = Properties.Resources.B_downImage;
        }
        /// <summary>
        /// 签到按钮Leave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTrans_MouseLeave(object sender, EventArgs e)
        {
            if (fLPStuInfo.Name == "ContainerA")
                btnTrans.BackgroundImage = Properties.Resources.A_normalImage;
            else
                btnTrans.BackgroundImage = Properties.Resources.B_normalImage;
        }
        /// <summary>
        /// 签到按钮Enter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTrans_MouseEnter(object sender, EventArgs e)
        {
            if (fLPStuInfo.Name == "ContainerA")
                btnTrans.BackgroundImage = Properties.Resources.A_moveImage;
            else
                btnTrans.BackgroundImage = Properties.Resources.B_moveImage;
        }
        /// <summary>
        /// 签到按钮Up
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTrans_MouseUp(object sender, MouseEventArgs e)
        {
            if (fLPStuInfo.Name == "ContainerA")
                btnTrans.BackgroundImage = Properties.Resources.A_normalImage;
            else
                btnTrans.BackgroundImage = Properties.Resources.B_normalImage;
        }
    }
}
