using AttendanceSystem.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Services
{
    public class TeacherService
    {
        private readonly ProjectDbContext _projectDbContext;

        public TeacherService(ProjectDbContext projectDbContext)
        {
            _projectDbContext = projectDbContext;
        }

        public void CheckAttendanceReport()
        {
            Console.WriteLine("Courses List with their Id: ");

            var courses = _projectDbContext.Courses.ToList();

            foreach (var course in courses)
            {
                Console.Write(course.Id);
                Console.Write(" ");
                Console.WriteLine(course.CourseName);
            }

            Console.Write("Enter Course Id: ");
            int courseId = Convert.ToInt32(Console.ReadLine());

            var studentInCourses = _projectDbContext.StudentCourses.Where(x => x.CourseId == courseId).Include(s => s.Student).Include(a => a.Attendances).ToList();

            foreach(var student in studentInCourses)
            {
                Console.Write(student.Student.Name);
                Console.Write(" -- ");
                foreach(var attendance  in student.Attendances)
                {
                    if (attendance.Status == true)
                        Console.WriteLine("✓");
                    else
                        Console.WriteLine("X");
                }
            }
        }
    }
}
