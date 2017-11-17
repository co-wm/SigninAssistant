using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SigninAssistant.FunctionBLL
{
    public class NetWork
    {
        [DllImport("winInet.dll")]
        private static extern bool InternetGetConnectedState(ref int dwFlag, int dwReserved);

        public static async void checkServeStatus(string str)
        {
            Int32 dwFlag = new Int32();
            if (!InternetGetConnectedState(ref dwFlag, 0))
            {
                MessageBox.Show("本地网络无连接");
            }
            else
            {
                System.Net.NetworkInformation.Ping ping = new System.Net.NetworkInformation.Ping();
                System.Net.NetworkInformation.PingReply reply = await ping.SendPingAsync(str);
                if (reply == null || reply != null && reply.Status != System.Net.NetworkInformation.IPStatus.Success)
                {
                    MessageBox.Show("无法连接该网站");
                }

            }
        }
        //默认Get方法
        public static string GetDataByGet(string url)
        {
            try
            {
                WebRequest wReq = WebRequest.Create(url);
                WebResponse wRsp = wReq.GetResponse();

                Stream wRspStream = wRsp.GetResponseStream();
                using (StreamReader reader = new StreamReader(wRspStream))
                {
                    return reader.ReadToEnd();
                }
            }
            catch(WebException)
            {
                return "No";
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //Post方法
        public static string GetDataByPost(string url,string postData)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                byte[] buffer = Encoding.GetEncoding("UTF-8").GetBytes(postData);
                request.Method = "post";
                request.Accept = "text/html,application/xhtml+xml,*/*";
                request.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";
                request.ContentLength = buffer.Length;

                request.GetRequestStream().Write(buffer, 0, buffer.Length);

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                {
                    return sr.ReadToEnd();
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
           
        }
    }
}
