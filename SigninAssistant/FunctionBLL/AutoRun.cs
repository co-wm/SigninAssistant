using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SigninAssistant.FunctionBLL
{
    public class AutoRun
    {
        public static void SetAutoRun(string filePath,bool isAutoRun)
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);

            if (principal.IsInRole(WindowsBuiltInRole.Administrator))
            {
                RegistryKey regk = null;
                try
                {
                    if (!File.Exists(filePath))
                        throw new Exception("该文件不存在！");
                    string fileName = filePath.Substring(filePath.LastIndexOf(@"\") + 1);
                    regk = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
                    if (regk == null)
                        regk = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");
                    if (isAutoRun)
                        regk.SetValue(fileName, filePath);
                    else
                        regk.SetValue(fileName, false);

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
                finally
                {
                    if (regk != null)
                        regk.Close();
                }
            }
            else
            {
                MessageBox.Show("修改注册表，请使用管理员身份运行");
            }
        }

        public static void SetAbsoluteRun()
        {
            RegistryKey ms_Run = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
            ms_Run.SetValue("SigninAssistant",Application.ExecutablePath);
        }
    }
}
