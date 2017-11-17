using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigninAssistant.ModelData
{
    public class Student
    {
        public int StudentId { get; set; }
        public string cardno { get; set; }
        public string StudentName { get; set; }
        public string IsLate { get; set; }
        public string ImageUrl { get; set; }
        public string AttendImageUrl { get; set; }

        public string isWalk { get; set; }
        public string GradeId { get; set; }
        public string ClassId { get; set; }

        //考试字段
        public string TicketNum { get; set; }
        public string ExaroomName { get; set; }
        public string ExamID { get; set; }
        public string ScreenID { get; set; }
        public string ExamSessionID { get; set; }
        public string ExamRoomID { get; set; }
        public string ExamNo { get; set; }

    }
}
