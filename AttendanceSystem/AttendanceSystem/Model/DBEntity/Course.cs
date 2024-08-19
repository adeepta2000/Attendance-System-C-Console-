using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Model.DBEntity
{
    public class Course
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public decimal Fees { get; set; }
        public List<TeacherCourse> TeacherCourses { get; set; }
        public List<StudentCourse> StudentCourses { get; set; }
        public List<Schedule> Schedules { get; set; }
    }
}
