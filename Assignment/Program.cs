using System;
using System.Collections.Generic;
using System.Linq;

namespace SchoolManagementSystem
{
    class program
    {
        static void Main(string[] args)
        {
            SchoolManagement sm = new SchoolManagement();
            sm.Run();

        }
    }

    public class SchoolManagement
    {
        private List<Student> students = new List<Student>();
        private List<Teacher> teachers = new List<Teacher>();
        private List<Class> classes = new List<Class>();

        public void Run()
        {
            while (true)
            {
                Console.WriteLine("School Management System");
                Console.WriteLine("1.Student Management");
                Console.WriteLine("2.Teacher Management");
                Console.WriteLine("3.Class Management");
                Console.WriteLine("4.Exit");
                Console.Write("Select an option:");

                var option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                }
            }
        }

    }
}