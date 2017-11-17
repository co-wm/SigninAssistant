using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigninAssistant.ModelData
{
    public class Lesson
    {
        public string CourseName { get; set; }
        public string TeacherName { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string ClassHour { get; set; }        
        public int IsExam { get; set; }
        public List<Student> StudentInfo { get; set; }
    }
}
