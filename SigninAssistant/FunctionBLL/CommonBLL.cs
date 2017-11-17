using Newtonsoft.Json;
using SigninAssistant.ModelData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace SigninAssistant.FunctionBLL
{
    public static class CommonBLL
    {

        /// <summary>
        /// 读取配置文件
        /// </summary>
        /// <returns></returns>
        public static bool readConfig()
        {
            bool flag = false;
            XmlDocument doc = new XmlDocument();
            try
            {
                string filePath = CommonData.StartPath + @"\" + CommonData.ConfigFile;
                doc.Load(filePath);
                XmlElement ele = (XmlElement)doc.SelectSingleNode("config");
                CommonData.WebServiceUrl = ele.GetAttribute("WebServiceUrl");
                flag = true;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                doc = null;
            }
            return flag;
        }
        /// <summary>
        /// 获取所有教室信息
        /// </summary>
        /// <returns></returns>
        public static int getAllClassRoom()
        {
            string url = CommonData.WebServiceUrl + ".foyo?actionCode=GetClassroomForWin&actionParam=1&multiParam=1";
            string res = NetWork.GetDataByGet(url);
            if(res == "No")
                return 0;
            else
            {
                CommonData.ClassRoomList = JsonConvert.DeserializeObject<List<ClassRoom>>(res);
                return 1;
            }

        }
        /// <summary>
        /// 通过教室Id请求课程信息【包含学生信息】
        /// </summary>
        /// <param name="classRooId"></param>
        /// <returns></returns>
        public static int getLessonInfoByClassRoomID(string classRooId)
        {
            string url = CommonData.WebServiceUrl + ".foyo?actionCode=GetNowAttendForWin&actionParam=1&multiParam=1&ClassroomId=" + classRooId;
            string res = NetWork.GetDataByGet(url);
            if (res.Contains("error"))
                return 0;
            else
            {
                CommonData.TheLesson = JsonConvert.DeserializeObject<Lesson>(res);
                return 1;
            }
        }
        /// <summary>
        /// 获取课时信息【开始上课时间 该节课结束上课时间】
        /// </summary>
        /// <returns></returns>
        public static int getLessonInfo()
        {
            string url = CommonData.WebServiceUrl + ".foyo?actionCode=GetNowAttendForWin&actionParam=1&multiParam=1";
            string res = NetWork.GetDataByGet(url);
            if (res == "No")
                return 0;
            else
            {
                CommonData.Lesson = JsonConvert.DeserializeObject<LessonInfo>(res);
                return 1;
            }
        }
        /// <summary>
        /// 学生上课签到
        /// </summary>
        /// <returns></returns>
        public static int studentSginIn(string data)
        {
            string url = CommonData.WebServiceUrl + ".foyo?actionCode=SetStuAttendForWin&actionParam=1&multiParam=1";
            data = "StudentInfoJson=" + data;
            string res = NetWork.GetDataByPost(url,data);
            if (res == "补签成功")
                return 1;
            return 0;
        }
        /// <summary>
        /// 学生考试签到
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static int studentExamSginIn(string data)
        {
            string url = CommonData.WebServiceUrl + ".foyo?actionCode=SetStuExamAttendForWin&actionParam=1&multiParam=1";
            data = "StudentInfoJson=" + data;
            string res = NetWork.GetDataByPost(url, data);
            if (res == "补签成功")
                return 1;
            return 0;
        }
    }
}
