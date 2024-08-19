using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Model.DBEntity
{
    public class TeacherCourse
    {
        public int Id { get; set; }
        public int TeacherId { get; set; }
        public int CourseId { get; set; }
        public User Teacher {  get; set; }
        public Course Course { get; set; }
    }
}
