using AttendanceSystem.Model;
using AttendanceSystem.Model.DBEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem.Services
{
    public class AdminService
    {
        private readonly ProjectDbContext _projectDbContext;
        public AdminService(ProjectDbContext projectDbContext)
        {
            _projectDbContext = projectDbContext;
        }

        public void CreateTeacher(string name, string username, string password)
        {
            var teacher = new User
            {
                Name = name,
                Username = username,
                Password = password,
                UserRole = "Teacher"
            };

            _projectDbContext.Users.Add(teacher);
            _projectDbContext.SaveChanges();
        }

        public void CreateStudent(string name, string username, string password)
        {
            var student = new User
            {
                Name = name,
                Username = username,
                Password = password,
                UserRole = "Student"
            };

            _projectDbContext.Users.Add(student);
            _projectDbContext.SaveChanges();
        }

        public void CreateCourse(string courseName, decimal fees)
        {
            var course = new Course
            {
                CourseName = courseName,
                Fees = fees
            };

            _projectDbContext.Courses.Add(course);
            _projectDbContext.SaveChanges();
        }

        public void AssignTeacherInCourse()
        {
            Console.WriteLine("Teacher's List with their Id: ");

            var teachers = _projectDbContext.Users.Where(u => u.UserRole == "Teacher").ToList();

            foreach (var teacher in teachers)
            {
                Console.Write(teacher.Id);
                Console.Write(" ");
                Console.WriteLine(teacher.Name);
            }

            Console.WriteLine();

            Console.WriteLine("Courses List with their Id: ");

            var courses = _projectDbContext.Courses.ToList();

            foreach (var course in courses)
            {
                Console.Write(course.Id);
                Console.Write(" ");
                Console.WriteLine(course.CourseName);
            }

            Console.Write("Enter Teacher Id: ");
            int teacherId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Course Id: ");
            int courseId = Convert.ToInt32(Console.ReadLine());

            var teacherInCourse = new TeacherCourse
            {
                TeacherId = teacherId,
                CourseId = courseId
            };

            _projectDbContext.TeacherCourses.Add(teacherInCourse);
            _projectDbContext.SaveChanges();

        }

        public void AssignStudentInCourse()
        {
            Console.WriteLine("Students List with their Id: ");

            var students = _projectDbContext.Users.Where(u => u.UserRole == "Student").ToList();

            foreach (var student in students)
            {
                Console.Write(student.Id);
                Console.Write(" ");
                Console.WriteLine(student.Name);
            }

            Console.WriteLine();

            Console.WriteLine("Courses List with their Id: ");

            var courses = _projectDbContext.Courses.ToList();

            foreach (var course in courses)
            {
                Console.Write(course.Id);
                Console.Write(" ");
                Console.WriteLine(course.CourseName);
            }

            Console.Write("Enter Student Id: ");
            int studentId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Course Id: ");
            int courseId = Convert.ToInt32(Console.ReadLine());

            var studentInCourse = new StudentCourse
            {
                StudentId = studentId,
                CourseId = courseId
            };

            _projectDbContext.StudentCourses.Add(studentInCourse);
            _projectDbContext.SaveChanges();

        }
        public void SetClassSchedule()
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

            Console.Write("Enter Day: ");
            string day = Console.ReadLine();

            Console.Write("Enter Start Time (hh:mm in 24-hour format): ");
            DateTime startTime = DateTime.Parse(Console.ReadLine());

            Console.Write("Enter End Time (hh:mm in 24-hour format): ");
            DateTime endTime = DateTime.Parse(Console.ReadLine());

            Console.Write("Enter Total Classes: ");
            int totalClasses = Convert.ToInt32(Console.ReadLine());

            var schedule = new Schedule
            {
                Day = day,
                StartTime = startTime,
                EndTime = endTime,
                TotalClasses = totalClasses,
                CourseId = courseId
            };

            _projectDbContext.Schedules.Add(schedule);
            _projectDbContext.SaveChanges();

        }
    }
}
