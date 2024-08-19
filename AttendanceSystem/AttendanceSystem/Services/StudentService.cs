using AttendanceSystem.Model;
using AttendanceSystem.Model.DBEntity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Services
{
    public class StudentService
    {
        private readonly ProjectDbContext _projectDbContext;
        public StudentService(ProjectDbContext projectDbContext)
        {
            _projectDbContext = projectDbContext;
        }

        public void GiveAttendance(int studentId)
        {
            var courses = _projectDbContext.StudentCourses.Where(x => x.StudentId == studentId).Include(x => x.Course).ToList();

            foreach (var course in courses)
            {
                Console.Write(course.CourseId);
                Console.Write(" ");
                Console.WriteLine(course.Course.CourseName);
            }

            Console.Write("Enter Course Id: ");
            int courseId = Convert.ToInt32(Console.ReadLine());

            var currentDay = DateTime.Now.DayOfWeek.ToString();
            var currentTime = DateTime.Now.TimeOfDay;

            var classSchedule = _projectDbContext.Schedules.Where(c => c.CourseId == courseId && c.Day == currentDay && c.StartTime.TimeOfDay <= currentTime && c.EndTime.TimeOfDay >= currentTime).FirstOrDefault();

            if (classSchedule == null)
            {
                Console.WriteLine("No class scheduled for this time.");
                return;
            }

            var studentCourse = _projectDbContext.StudentCourses.Where(x => x.StudentId == studentId && x.CourseId == courseId).FirstOrDefault();

            var attendance = new Attendance
            {
                StudentCourseId = studentCourse.Id,
                ClassDate = DateTime.Now,
                Status = true
            };

            _projectDbContext.Attendances.Add(attendance);
            _projectDbContext.SaveChanges();

            Console.WriteLine("Attendance is successfully done.");
        }
    }
}
