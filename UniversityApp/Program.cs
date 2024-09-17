using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        University university = new University();
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Load students and teachers from files");
            Console.WriteLine("2. Show all students");
            Console.WriteLine("3. Show all teachers");
            Console.WriteLine("4. Find person by last name");
            Console.WriteLine("5. Find teachers by department and sort");
            Console.WriteLine("0. Exit");

            Console.Write("\nChoose an option: ");
            string choice = Console.ReadLine() ?? string.Empty;

            switch (choice)
            {
                case "1":
                    // Load students and teachers
                    LoadData(university);
                    break;
                case "2":
                    // Show all students
                    ShowStudents(university);
                    break;
                case "3":
                    // Show all teachers
                    ShowTeachers(university);
                    break;
                case "4":
                    // Find by last name
                    FindByLastName(university);
                    break;
                case "5":
                    // Find teachers by department
                    FindTeachersByDepartment(university);
                    break;
                case "0":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }
        }
    }

    static void LoadData(University university)
    {
        string studentFilePath = "data/students.txt";
        string teacherFilePath = "data/teachers.txt";

        if (File.Exists(studentFilePath))
        {
            // Load students
            foreach (var line in File.ReadLines(studentFilePath))
            {
                try
                {
                    var student = Student.CreateFromString(line);
                    university.Add(student);
                }
                catch (FormatException e)
                {
                    Console.WriteLine($"Error parsing student line: {e.Message}");
                }
            }
        }
        else
        {
            Console.WriteLine($"Student file '{studentFilePath}' not found.");
        }

        if (File.Exists(teacherFilePath))
        {
            // Load teachers
            foreach (var line in File.ReadLines(teacherFilePath))
            {
                try
                {
                    var teacher = Teacher.CreateFromString(line);
                    university.Add(teacher);
                }
                catch (FormatException e)
                {
                    Console.WriteLine($"Error parsing teacher line: {e.Message}");
                }
            }
        }
        else
        {
            Console.WriteLine($"Teacher file '{teacherFilePath}' not found.");
        }

        Console.WriteLine("Data loaded.");
    }

    static void ShowStudents(University university)
    {
        var students = university.Students.ToList();
        if (students.Any())
        {
            foreach (var student in students)
            {
                Console.WriteLine(student);
            }
        }
        else
        {
            Console.WriteLine("No students found.");
        }
    }

    static void ShowTeachers(University university)
    {
        var teachers = university.Teachers.ToList();
        if (teachers.Any())
        {
            foreach (var teacher in teachers)
            {
                Console.WriteLine(teacher);
            }
        }
        else
        {
            Console.WriteLine("No teachers found.");
        }
    }

    static void FindByLastName(University university)
    {
        Console.Write("Enter last name: ");
        string lastName = Console.ReadLine() ?? string.Empty;
        var persons = university.FindByLastName(lastName).ToList();

        if (persons.Any())
        {
            foreach (var person in persons)
            {
                Console.WriteLine(person);
            }
        }
        else
        {
            Console.WriteLine("No person found with the given last name.");
        }
    }

    static void FindTeachersByDepartment(University university)
    {
        Console.Write("Enter text to search by department: ");
        string departmentText = Console.ReadLine() ?? string.Empty;

        var teachers = university.FindByDepartment(departmentText)
                                 .OrderBy(t => t.JobPosition)
                                 .ToList();

        if (teachers.Any())
        {
            foreach (var teacher in teachers)
            {
                Console.WriteLine(teacher);
            }
        }
        else
        {
            Console.WriteLine("No teachers found in the given department.");
        }
    }

}
