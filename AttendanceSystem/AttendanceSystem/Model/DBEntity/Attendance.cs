using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Model.DBEntity
{
    public class Attendance
    {
        public int Id { get; set; }
        public int StudentCourseId { get; set; }
        public DateTime ClassDate { get; set; }
        public bool Status { get; set; }
        public StudentCourse StudentCourse { get; set; }
    }
}
