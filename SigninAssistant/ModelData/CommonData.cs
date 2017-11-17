using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigninAssistant.ModelData
{
    public static class CommonData
    {
        public static string WebServiceUrl = "";
        public static string StartPath = "";
        public static string ClassId = "";
        public static string ClassName = "";

        public static List<ClassRoom> ClassRoomList = new List<ClassRoom>();
        public static LessonInfo Lesson = new LessonInfo();
        public static Lesson TheLesson = new Lesson();
        public static readonly string ConfigFile = "SigninAssistantConfig.xml";
    }
}
