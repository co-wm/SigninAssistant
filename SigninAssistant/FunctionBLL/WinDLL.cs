using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SigninAssistant.FunctionBLL
{
    public static class WinDLL
    {
        //激活并显示窗口 如果窗口Max或Min则恢复原来的尺寸和位置
        public const int SW_RESTORE = 9;
        //窗口句柄
        public static IntPtr formhwnd;
        /// <summary>
        /// 找到与给出类别名和窗口名相同的窗口
        /// </summary>
        /// <param name="lpClassName">类别名</param>
        /// <param name="lpWindowName">窗口名</param>
        /// <returns>找到则返回该窗口的句柄/否则返回为NULL</returns>
        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        /// <summary>
        /// 切换到窗口并把窗口设入前台/类似SetForegroundWindow
        /// </summary>
        /// <param name="hWnd">窗口句柄</param>
        /// <param name="fAltTab">窗口通过Alt+Tab切换</param>
        [DllImport("user32.dll ", SetLastError = true)]
        static extern void SwitchToThisWindow(IntPtr hWnd, bool fAltTab);
        /// <summary>
        /// 设置窗口的显示状态
        /// </summary>
        /// <param name="hwnd">窗口句柄</param>
        /// <param name="nCmdShow">指示窗口如何被显示</param>
        /// <returns>窗口可见返回非零 窗口隐藏返回为零</returns>
        [DllImport("user32.dll", EntryPoint = "ShowWindow", CharSet = CharSet.Auto)]
        public static extern int ShowWindow(IntPtr hwnd, int nCmdShow);

        /// <summary>
        /// 将与当前进程同名的不同进程显示出来
        /// </summary>
        /// <param name="curPro"></param>
        /// <param name="proCollection"></param>
        public static void setPreProFaceFront(Process curPro, Process[] proCollection)
        {
            foreach(Process pro in proCollection)
            {
                if(pro.Id != curPro.Id)
                {
                    //如果为找到该窗体【窗体被隐藏】
                    if(pro.MainWindowHandle.ToInt32() == 0)
                    {
                        //找到该窗体句柄
                        formhwnd = FindWindow(null, "SigninAssistant");
                        ShowWindow(formhwnd,SW_RESTORE);
                        SwitchToThisWindow(formhwnd,true);
                    }
                    //窗体未被隐藏的情况下直接显示在前台
                    else
                    {
                        SwitchToThisWindow(pro.MainWindowHandle,true);
                    }
                }
            }
        }

    }
}
