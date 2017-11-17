using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TxbTransprantDemo
{
    class TransprantTextBox : TextBox
    {

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr LoadLibrary(string lpFileName);

        private const int WM_PAINT = 0x000F;
        [Description("BackGround Text")]
        private string EmptyTextTip { get; set; }
        private Color EmptyTextTipColor { get; set; }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams prams = base.CreateParams;
                if (LoadLibrary("msftedit.dll") != IntPtr.Zero)
                {
                    prams.ExStyle |= 0x020;
                    prams.ClassName = "RICHEDIT50W";
                }
                return prams;
            }
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_PAINT)
            {
                WmPaint(ref m);
            }
        }

        private void WmPaint(ref Message m)
        {
            Rectangle rectangle = new Rectangle(0, 0, Width, Height);
            using (Graphics graphics = Graphics.FromHwnd(base.Handle))
            {
                if (Text.Length == 0 && !string.IsNullOrEmpty(EmptyTextTip) && !Focused)
                {
                    TextFormatFlags format = TextFormatFlags.EndEllipsis | TextFormatFlags.VerticalCenter;
                    if (RightToLeft == RightToLeft.Yes)
                    {
                        format |= TextFormatFlags.RightToLeft | TextFormatFlags.Right;
                        TextRenderer.DrawText(graphics, EmptyTextTip, Font,base.ClientRectangle, EmptyTextTipColor, format);
                    }
                }
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);
            this.ForeColor = Color.White;
        }
    }
}
