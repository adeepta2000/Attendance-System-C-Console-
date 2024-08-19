using AttendanceSystem;
using AttendanceSystem.Model;
using AttendanceSystem.Model.DBEntity;
using AttendanceSystem.Services;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;

ProjectDbContext projectDbContext = new ProjectDbContext();

Login login = new Login();

User loggedInUser = login.UserLogin(projectDbContext);

while (true)
{
    string role = loggedInUser.UserRole;

    if (role == "Admin")
    {
        AdminService adminService = new AdminService(projectDbContext);
        AdminTask(adminService);
    }
    else if (role == "Teacher")
    {
        TeacherService teacherService = new TeacherService(projectDbContext);
        TeacherTask(teacherService);
    }
    else if (role == "Student")
    {
        StudentService studentService = new StudentService(projectDbContext);
        StudentTask(studentService, loggedInUser.Id);
    }
    else
    {
        Console.WriteLine("Login Failed.");
        break;
    }

    loggedInUser = login.UserLogin(projectDbContext);

}

static void AdminTask(AdminService adminService)
{
    while (true)
    {
        Console.WriteLine("Choose an option to continue: ");
        Console.WriteLine("1. Create Teacher");
        Console.WriteLine("2. Create Student");
        Console.WriteLine("3. Create Course");
        Console.WriteLine("4. Assign Teacher in Course");
        Console.WriteLine("5. Assign Student in Course");
        Console.WriteLine("6. Set Class Schedule");
        Console.WriteLine("7. Logout");

        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                Console.Write("Enter Teacher Name: ");
                string teacherName = Console.ReadLine();
                Console.Write("Enter Teacher Username: ");
                string teacherUsername = Console.ReadLine();
                Console.Write("Enter Teacher Password: ");
                string teacherPassword = Console.ReadLine();
                adminService.CreateTeacher(teacherName, teacherUsername, teacherPassword);
                break;

            case "2":
                Console.Write("Enter Student Name: ");
                string studentName = Console.ReadLine();
                Console.Write("Enter Student Username: ");
                string studentUsername = Console.ReadLine();
                Console.Write("Enter Student Password: ");
                string studentPassword = Console.ReadLine();
                adminService.CreateStudent(studentName, studentUsername, studentPassword);
                break;

            case "3":
                Console.Write("Enter Course Name: ");
                string courseName = Console.ReadLine();
                Console.Write("Enter Course Fees: ");
                decimal courseFees = Convert.ToDecimal(Console.ReadLine());
                adminService.CreateCourse(courseName, courseFees);
                break;

            case "4":
                adminService.AssignTeacherInCourse();
                break;

            case "5":
                adminService.AssignStudentInCourse();
                break;

            case "6":
                adminService.SetClassSchedule();
                break;

            case "7":
                return;
        }
    }
}

static void StudentTask(StudentService studentService, int studentId)
{
    while (true)
    {
        Console.WriteLine("Choose an option to continue: ");
        Console.WriteLine("1. Give Attendance");
        Console.WriteLine("2. Logout");

        string choice = Console.ReadLine();
        switch (choice)
        {
            case "1":
                studentService.GiveAttendance(studentId);
                break;

            case "2":
                return;
        }
    }
}

static void TeacherTask(TeacherService teacherService)
{
    while (true)
    {
        Console.WriteLine("Choose an option to continue: ");
        Console.WriteLine("1. Check Attendance Report");
        Console.WriteLine("2. Logout");

        string choice = Console.ReadLine();
        switch (choice)
        {
            case "1":
                teacherService.CheckAttendanceReport();
                break;

            case "2":
                return;
        }
    }
}



