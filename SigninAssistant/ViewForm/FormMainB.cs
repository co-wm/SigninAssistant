using Newtonsoft.Json;
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

namespace SigninAssistant.ViewForm
{
    public partial class FormMainB : Form
    {
        private int numA;
        private int numB;
        private stuIconB[] iconListA; //未到学生列表
        private stuIconB[] iconListB; //已到学生列表

        public FormMainB()
        {
            InitializeComponent();
            fLPStuInfo.Name = "ContainerA";
            dealStuIconInfo("A");
        }
        private void FormMainB_Load(object sender, EventArgs e)
        {
            showDataInfo();
        }
        /// <summary>
        /// 初始化界面显示信息
        /// </summary>
        private void showDataInfo()
        {
            label1.Text = "教学楼" + CommonData.ClassName;
            label2.Text = DateTime.Now.ToString("yyyy/MM/dd") + " " +
                CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(DateTime.Now.DayOfWeek) + " " +
                DateTime.Now.ToString("HH:mm");
            label3.Text = CommonData.TheLesson.CourseName;
            label5.Text = CommonData.TheLesson.StudentInfo.Count().ToString();
            label6.Text = numB.ToString();
            label7.Text = numA.ToString();
        }
        /// <summary>
        /// 生成学生头像图标
        /// </summary>
        /// <param name="flag"></param>
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

            numA = (from stu in CommonData.TheLesson.StudentInfo
                    where stu.IsLate == ""
                    select stu.IsLate).Count();
            numB = CommonData.TheLesson.StudentInfo.Count - numA;
            iconListA = new stuIconB[numA];
            iconListB = new stuIconB[numB];

            if (flag == "A")
            {
                for(int i =0,k =0; i< numA+ numB;i++)
                {
                    if (CommonData.TheLesson.StudentInfo[i].IsLate == "")
                    {
                        iconListA[k] = new stuIconB(CommonData.TheLesson.StudentInfo[i]);
                        fLPStuInfo.Controls.Add(iconListA[k]);
                        k++;
                    }
                }
            }
            else
            {
                for (int i = 0, k = 0; i < numB + numA; i++)
                {
                    if (CommonData.TheLesson.StudentInfo[i].IsLate != "")
                    {
                        iconListB[k] = new stuIconB(CommonData.TheLesson.StudentInfo[i]);
                        fLPStuInfo.Controls.Add(iconListB[k]);
                        k++;
                    }
                }
            }
        }

        private void btnTrans_MouseDown(object sender, MouseEventArgs e)
        {
            if (fLPStuInfo.Name == "ContainerA")
                btnTrans.BackgroundImage = Properties.Resources.A_downImage;
            else
                btnTrans.BackgroundImage = Properties.Resources.B_downImage;
        }

        private void btnTrans_MouseLeave(object sender, EventArgs e)
        {
            if (fLPStuInfo.Name == "ContainerA")
                btnTrans.BackgroundImage = Properties.Resources.A_normalImage;
            else
                btnTrans.BackgroundImage = Properties.Resources.B_normalImage;
        }

        private void btnTrans_MouseEnter(object sender, EventArgs e)
        {
            if (fLPStuInfo.Name == "ContainerA")
                btnTrans.BackgroundImage = Properties.Resources.A_moveImage;
            else
                btnTrans.BackgroundImage = Properties.Resources.B_moveImage;
        }

        private void btnTrans_MouseUp(object sender, MouseEventArgs e)
        {
            if (fLPStuInfo.Name == "ContainerA")
                btnTrans.BackgroundImage = Properties.Resources.A_normalImage;
            else
                btnTrans.BackgroundImage = Properties.Resources.B_normalImage;
        }

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
                    if (signInOrsignOut(0, iconListA))
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
                    if (signInOrsignOut(-1, iconListB))
                    {
                        btnAbsent_Click(sender, e);
                        label6.Text = numB.ToString();
                        label7.Text = numA.ToString();
                    }

                }
            }
        }

        private bool signInOrsignOut(int intFlag, stuIconB[] iconList)
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
                        ExamId = iconList[i].StuInfo.ExamID,
                        CourseName = CommonData.TheLesson.CourseName,
                        ScreenID = iconList[i].StuInfo.ScreenID,
                        ExamSessionID = iconList[i].StuInfo.ExamSessionID,
                        ExamRoomID = iconList[i].StuInfo.ExamRoomID
                    };
                    list.Add(stuJosn);
                }
            }
            stuIdList = JsonConvert.SerializeObject(list);
            if (stuIdList != "[]")
            {
                //发送给服务端 学生考试签到   
                if (CommonBLL.studentExamSginIn(stuIdList) == 1)
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
    }
}
