using AttendanceSystem.Model;
using AttendanceSystem.Model.DBEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceSystem
{
    public class Login
    {
        public User UserLogin(ProjectDbContext projectDbContext)
        {
            string username;
            string password;

            Console.WriteLine("Login");
            Console.WriteLine();

            Console.Write("Enter your username: ");
            username = Console.ReadLine();

            Console.Write("Enter your password: ");
            password = Console.ReadLine();

            User user = projectDbContext.Users.Where(u => u.Username == username && u.Password == password).FirstOrDefault();

            if (user == null)
            {
                Console.WriteLine("Invalid username or password");
                return UserLogin(projectDbContext);
            }
            else
            {
                Console.WriteLine("Welcome back," + " " + user.Name);
                return user;
            }
        }
    }
}
