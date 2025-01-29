using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Initialize a List to store student names
        List<string> studentNames = new List<string>
        {
            "Rajvi", "Prachi", "Khushi", "Deep", "Shubh"
        };

        // Print all student names
        Console.WriteLine("List of students:");
        foreach (string student in studentNames)
        {
            Console.WriteLine(student);
        }
    }
}