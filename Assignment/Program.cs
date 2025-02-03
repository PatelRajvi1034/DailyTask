using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static List<Student> students = new List<Student>();
    static List<Teacher> teachers = new List<Teacher>();
    static List<Class> classes = new List<Class>();

    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("School Management System");
            Console.WriteLine("1. Student Management");
            Console.WriteLine("2. Teacher Management");
            Console.WriteLine("3. Class Management");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an option: ");
            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    StudentManagement();
                    break;
                case "2":
                    TeacherManagement();
                    break;
                case "3":
                    ClassManagement();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }

    // Student Management
    static void StudentManagement()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Student Management");
            Console.WriteLine("1. Add New Student");
            Console.WriteLine("2. View All Students");
            Console.WriteLine("3. Search Student by Name or Roll Number");
            Console.WriteLine("4. Update Student Details");
            Console.WriteLine("5. Delete Student");
            Console.WriteLine("6. Back");
            Console.Write("Choose an option: ");
            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    AddStudent();
                    break;
                case "2":
                    ViewAllStudents();
                    break;
                case "3":
                    SearchStudent();
                    break;
                case "4":
                    UpdateStudent();
                    break;
                case "5":
                    DeleteStudent();
                    break;
                case "6":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }

    static void AddStudent()
    {
        Console.Write("Enter Name: ");
        string name = Console.ReadLine();
        Console.Write("Enter Age: ");
        int age = int.Parse(Console.ReadLine());
        Console.Write("Enter Class: ");
        string studentClass = Console.ReadLine();
        Console.Write("Enter Roll Number: ");
        string rollNumber = Console.ReadLine();
        Console.Write("Enter Address: ");
        string address = Console.ReadLine();

        students.Add(new Student { Name = name, Age = age, Class = studentClass, RollNumber = rollNumber, Address = address });
        Console.WriteLine("Student Added Successfully!");
        Console.ReadKey();
    }

    static void ViewAllStudents()
    {
        foreach (var student in students)
        {
            Console.WriteLine(student);
        }
        Console.ReadKey();
    }

    static void SearchStudent()
    {
        Console.Write("Enter Name or Roll Number: ");
        string searchTerm = Console.ReadLine();
        var student = students.FirstOrDefault(s => s.Name.Equals(searchTerm, StringComparison.OrdinalIgnoreCase) || s.RollNumber.Equals(searchTerm));
        if (student != null)
        {
            Console.WriteLine(student);
        }
        else
        {
            Console.WriteLine("Student not found.");
        }
        Console.ReadKey();
    }

    static void UpdateStudent()
    {
        Console.Write("Enter Roll Number of Student to Update: ");
        string rollNumber = Console.ReadLine();
        var student = students.FirstOrDefault(s => s.RollNumber.Equals(rollNumber));
        if (student != null)
        {
            Console.Write("Enter New Name: ");
            student.Name = Console.ReadLine();
            Console.Write("Enter New Age: ");
            student.Age = int.Parse(Console.ReadLine());
            Console.Write("Enter New Class: ");
            student.Class = Console.ReadLine();
            Console.Write("Enter New Address: ");
            student.Address = Console.ReadLine();
            Console.WriteLine("Student Details Updated Successfully!");
        }
        else
        {
            Console.WriteLine("Student not found.");
        }
        Console.ReadKey();
    }

    static void DeleteStudent()
    {
        Console.Write("Enter Roll Number of Student to Delete: ");
        string rollNumber = Console.ReadLine();
        var student = students.FirstOrDefault(s => s.RollNumber.Equals(rollNumber));
        if (student != null)
        {
            students.Remove(student);
            Console.WriteLine("Student Deleted Successfully!");
        }
        else
        {
            Console.WriteLine("Student not found.");
        }
        Console.ReadKey();
    }

    // Teacher Management
    static void TeacherManagement()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Teacher Management");
            Console.WriteLine("1. Add New Teacher");
            Console.WriteLine("2. View All Teachers");
            Console.WriteLine("3. Search Teacher by Name or Employee ID");
            Console.WriteLine("4. Update Teacher Details");
            Console.WriteLine("5. Delete Teacher");
            Console.WriteLine("6. Back");
            Console.Write("Choose an option: ");
            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    AddTeacher();
                    break;
                case "2":
                    ViewAllTeachers();
                    break;
                case "3":
                    SearchTeacher();
                    break;
                case "4":
                    UpdateTeacher();
                    break;
                case "5":
                    DeleteTeacher();
                    break;
                case "6":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }

    static void AddTeacher()
    {
        Console.Write("Enter Name: ");
        string name = Console.ReadLine();
        Console.Write("Enter Subject: ");
        string subject = Console.ReadLine();
        Console.Write("Enter Experience (Years): ");
        int experience = int.Parse(Console.ReadLine());
        Console.Write("Enter Employee ID: ");
        string employeeID = Console.ReadLine();

        teachers.Add(new Teacher { Name = name, Subject = subject, Experience = experience, EmployeeID = employeeID });
        Console.WriteLine("Teacher Added Successfully!");
        Console.ReadKey();
    }

    static void ViewAllTeachers()
    {
        foreach (var teacher in teachers)
        {
            Console.WriteLine(teacher);
        }
        Console.ReadKey();
    }

    static void SearchTeacher()
    {
        Console.Write("Enter Name or Employee ID: ");
        string searchTerm = Console.ReadLine();
        var teacher = teachers.FirstOrDefault(t => t.Name.Equals(searchTerm, StringComparison.OrdinalIgnoreCase) || t.EmployeeID.Equals(searchTerm));
        if (teacher != null)
        {
            Console.WriteLine(teacher);
        }
        else
        {
            Console.WriteLine("Teacher not found.");
        }
        Console.ReadKey();
    }

    static void UpdateTeacher()
    {
        Console.Write("Enter Employee ID of Teacher to Update: ");
        string employeeID = Console.ReadLine();
        var teacher = teachers.FirstOrDefault(t => t.EmployeeID.Equals(employeeID));
        if (teacher != null)
        {
            Console.Write("Enter New Name: ");
            teacher.Name = Console.ReadLine();
            Console.Write("Enter New Subject: ");
            teacher.Subject = Console.ReadLine();
            Console.Write("Enter New Experience: ");
            teacher.Experience = int.Parse(Console.ReadLine());
            Console.WriteLine("Teacher Details Updated Successfully!");
        }
        else
        {
            Console.WriteLine("Teacher not found.");
        }
        Console.ReadKey();
    }

    static void DeleteTeacher()
    {
        Console.Write("Enter Employee ID of Teacher to Delete: ");
        string employeeID = Console.ReadLine();
        var teacher = teachers.FirstOrDefault(t => t.EmployeeID.Equals(employeeID));
        if (teacher != null)
        {
            teachers.Remove(teacher);
            Console.WriteLine("Teacher Deleted Successfully!");
        }
        else
        {
            Console.WriteLine("Teacher not found.");
        }
        Console.ReadKey();
    }

    // Class Management
    static void ClassManagement()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Class Management");
            Console.WriteLine("1. Create New Class");
            Console.WriteLine("2. View All Classes");
            Console.WriteLine("3. Assign Students to Class");
            Console.WriteLine("4. Assign Teacher to Class");
            Console.WriteLine("5. Back");
            Console.Write("Choose an option: ");
            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    CreateClass();
                    break;
                case "2":
                    ViewAllClasses();
                    break;
                case "3":
                    AssignStudentsToClass();
                    break;
                case "4":
                    AssignTeacherToClass();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }

    static void CreateClass()
    {
        Console.Write("Enter Class Name: ");
        string className = Console.ReadLine();
        Console.Write("Enter Section: ");
        string section = Console.ReadLine();
        Console.Write("Enter Teacher ID to Assign to Class: ");
        string teacherID = Console.ReadLine();

        var teacher = teachers.FirstOrDefault(t => t.EmployeeID.Equals(teacherID));
        if (teacher != null)
        {
            classes.Add(new Class { ClassName = className, Section = section, AssignedTeacher = teacher });
            Console.WriteLine("Class Created Successfully!");
        }
        else
        {
            Console.WriteLine("Teacher not found.");
        }
        Console.ReadKey();
    }

    static void ViewAllClasses()
    {
        foreach (var c in classes)
        {
            Console.WriteLine(c);
        }
        Console.ReadKey();
    }

    static void AssignStudentsToClass()
    {
        Console.Write("Enter Class Name to Assign Students: ");
        string className = Console.ReadLine();
        var classObj = classes.FirstOrDefault(c => c.ClassName.Equals(className, StringComparison.OrdinalIgnoreCase));

        if (classObj != null)
        {
            Console.WriteLine("Enter Roll Numbers of Students to Assign (comma separated): ");
            string[] rollNumbers = Console.ReadLine().Split(',');

            foreach (var rollNumber in rollNumbers)
            {
                var student = students.FirstOrDefault(s => s.RollNumber.Equals(rollNumber.Trim()));
                if (student != null)
                {
                    classObj.Students.Add(student);
                    Console.WriteLine($"Assigned {student.Name} to {classObj.ClassName}.");
                }
                else
                {
                    Console.WriteLine($"Student with Roll Number {rollNumber.Trim()} not found.");
                }
            }
        }
        else
        {
            Console.WriteLine("Class not found.");
        }
        Console.ReadKey();
    }

    static void AssignTeacherToClass()
    {
        Console.Write("Enter Class Name to Assign Teacher: ");
        string className = Console.ReadLine();
        var classObj = classes.FirstOrDefault(c => c.ClassName.Equals(className, StringComparison.OrdinalIgnoreCase));

        if (classObj != null)
        {
            Console.Write("Enter Teacher ID to Assign: ");
            string teacherID = Console.ReadLine();
            var teacher = teachers.FirstOrDefault(t => t.EmployeeID.Equals(teacherID));
            if (teacher != null)
            {
                classObj.AssignedTeacher = teacher;
                Console.WriteLine($"Assigned {teacher.Name} to {classObj.ClassName}.");
            }
            else
            {
                Console.WriteLine("Teacher not found.");
            }
        }
        else
        {
            Console.WriteLine("Class not found.");
        }
        Console.ReadKey();
    }
}

class Student
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Class { get; set; }
    public string RollNumber { get; set; }
    public string Address { get; set; }

    public override string ToString()
    {
        return $"Roll Number: {RollNumber}, Name: {Name}, Age: {Age}, Class: {Class}, Address: {Address}";
    }
}

class Teacher
{
    public string Name { get; set; }
    public string Subject { get; set; }
    public int Experience { get; set; }
    public string EmployeeID { get; set; }

    public override string ToString()
    {
        return $"Employee ID: {EmployeeID}, Name: {Name}, Subject: {Subject}, Experience: {Experience} years";
    }
}

class Class
{
    public string ClassName { get; set; }
    public string Section { get; set; }
    public Teacher AssignedTeacher { get; set; }
    public List<Student> Students { get; set; } = new List<Student>();

    public override string ToString()
    {
        string teacherName = AssignedTeacher != null ? AssignedTeacher.Name : "No Teacher Assigned";
        return $"Class: {ClassName} {Section}, Teacher: {teacherName}, Students: {Students.Count}";
    }
}