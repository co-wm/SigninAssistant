using SigninAssistant.FunctionBLL;
using SigninAssistant.ModelData;
using SigninAssistant.ViewForm;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SigninAssistant
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Process curPro = Process.GetCurrentProcess(); //当前进程
            Process[] proCollection = Process.GetProcessesByName(curPro.ProcessName.Replace(".vshost",string.Empty));//所有当前同名进程
            if(proCollection.Length > 1)
            {
                WinDLL.setPreProFaceFront(curPro, proCollection);
            }
            else
            {
                CommonData.StartPath = Application.StartupPath;
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                FormLogin frmLogin = new FormLogin();

                frmLogin.ShowDialog();
                if (frmLogin.DialogResult == DialogResult.OK)
                {
                    if (CommonData.TheLesson == null)
                    {
                        MessageBox.Show("获取课堂信息失败");
                    }
                    //上课考勤
                    else if (CommonData.TheLesson.IsExam == 0)
                    {
                        Application.Run(new FormMainA());
                    }
                    //考试考勤
                    else
                    {
                        Application.Run(new FormMainB());
                    }

                }
                else
                {
                    frmLogin.Dispose();
                }
                    
            }  
        }
    }
}
