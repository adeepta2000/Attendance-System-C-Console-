using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Model.DBEntity
{
    public class Schedule
    {
        public int Id { get; set; }
        public string Day { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int TotalClasses { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
