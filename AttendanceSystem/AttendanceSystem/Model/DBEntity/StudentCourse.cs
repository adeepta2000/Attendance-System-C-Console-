using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Model.DBEntity
{
    public class StudentCourse
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public User Student { get; set; }
        public Course Course { get; set; }
        public List<Attendance> Attendances { get; set; }
    }
}
