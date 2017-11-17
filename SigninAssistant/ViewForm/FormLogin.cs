using SigninAssistant.FunctionBLL;
using SigninAssistant.ModelData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SigninAssistant
{
    public partial class FormLogin : Form
    {
        //双击notifyIcon事件委托给主界面【如果主界面需要教室ID后面修改】
        public delegate void DoubleClickEventHandle();
        public static event  DoubleClickEventHandle NotifyDoubleClick;

        //多线程访问控件委托
        private delegate void AccessControl();

        public FormLogin()
        {
            InitializeComponent();               
            try
            {
                CommonData.WebServiceUrl = ConfigurationManager.AppSettings["WebServiceUrl"];
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + "读取配置信息出错！");
            }            
            //开机自启动
            AutoRun.SetAutoRun(Application.ExecutablePath, true);
            //轮询获取课时信息
            new Thread(getLessonTimeInfo) { IsBackground = true }.Start();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            this.AcceptButton = BtnLogin;
            if(CommonBLL.getAllClassRoom()==0)
            {
                MessageBox.Show("网络不通,请检查网络");
            }
        }
        /// <summary>
        /// 轮询获取课时时间 并判断是否要提示签到
        /// </summary>
        private void getLessonTimeInfo()
        {
            //################循环条件可做优化
            while(true)
            {                
                if (CommonBLL.getLessonInfo() == 0)
                {
                    MessageBox.Show("网络不通,请检查网络");
                }
                
                if ((DateTime.Now.AddMinutes(-2) - Convert.ToDateTime(CommonData.Lesson.StartTime)).TotalSeconds > 5
                    && (DateTime.Now.AddMinutes(-2) - Convert.ToDateTime(CommonData.Lesson.StartTime)).TotalSeconds < 10)
                {
                    MessageBox.Show("状态栏气泡提示");
                }
                Thread.Sleep(5000);
            }
            
        }

        //状态栏图标双击
        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
           if(NotifyDoubleClick != null)
            {
                NotifyDoubleClick();
            }
        }

        /// <summary>
        /// 登录按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if(txbClassId.Text == "")
            {
                MessageBox.Show("请输入当前教室编号");
            }
            else
            {
                var theclass = from classroom in CommonData.ClassRoomList
                               where classroom.ID == txbClassId.Text.Trim()
                               select classroom.ClassroomName;
                if(theclass.Count() == 0)
                {
                    MessageBox.Show("输入教室有误，请重新输入！");
                    txbClassId.Focus();
                    return;
                }
                CommonData.ClassId = txbClassId.Text;
                CommonData.ClassName = theclass.First();
                //多线程优化
                getLessonInfo();
            }            
        }

        private void getLessonInfo()
        {
            if(txbClassId.InvokeRequired)
            {
                AccessControl ac = new AccessControl(getLessonInfo);
                this.Invoke(ac);
            }
            else
            {
                int result = CommonBLL.getLessonInfoByClassRoomID(txbClassId.Text);
                if (result == 0)
                {
                    MessageBox.Show("网络不通,请检查网络");
                    Environment.Exit(0);
                }
                this.DialogResult = DialogResult.OK;
            }            
        }

        private void txbClassName_Enter(object sender, EventArgs e)
        {
            txbClassId.Text = "";
        }

        private void BtnLogin_MouseLeave(object sender, EventArgs e)
        {
            BtnLogin.BackgroundImage = Properties.Resources.login_normal;
        }

        private void BtnLogin_MouseUp(object sender, MouseEventArgs e)
        {
            BtnLogin.BackgroundImage = Properties.Resources.login_normal;
        }

        private void BtnLogin_MouseEnter(object sender, EventArgs e)
        {
            BtnLogin.BackgroundImage = Properties.Resources.login_move;
        }

        private void txbClassId_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            txbClassId.Focus();
        }
    }
}
