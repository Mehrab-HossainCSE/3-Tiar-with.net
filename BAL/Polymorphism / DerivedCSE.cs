using StudentManagementSystem.DAL.Interface;
using StudentManagementSystem.DAL;
using StudentManagementSystem;
using System;
using System.Collections.Generic;
using System.Linq;

public class DerivedCSE : OfferCourse
{
    public static List<Student> students;
    public override void CompliteCourse(string studentID)
    {

        FileManager fileManager = new FileManager();
        students = fileManager.LoadStudents();
        var student = students.FirstOrDefault(s => s.StudentID == studentID);
        if (student != null)
        {
            Console.WriteLine("Completed Courses:");
            foreach (var course in student.Courses)
            {
                Console.WriteLine($"- CourseName: {course.CourseName}");
            }
        }
        else
        {
            Console.WriteLine("Student not found!");
        }
    }
    // public override void InCompliteCourse(string studentID)
    // {
    //       Console.WriteLine("Incomplete Courses:");
    //     var student = students.FirstOrDefault(s => s.StudentID == studentID);
    //     if (student != null)
    //     {
    //         // Get the course names of the student
    //         string[] studentCourses = student.Courses?.Select(c => c.CourseName.ToLower()).ToArray();

    //         // BBA courses
    //        string[] cseCourses = {
    //         "Programming ",
    //         "Algorithms",
    //         "OOP",
    //         "NetworKing",


    //     };

    //         Console.WriteLine("Filter the incomplete courses") ;
    //         var incompleteCourses = cseCourses.Where(course => !studentCourses.Contains(course.ToLower())).ToArray();
    //         foreach (var course in incompleteCourses)
    //         {
    //             Console.WriteLine($"- CourseName: {course}");
    //         }
    //     }
    //     else
    //     {
    //         Console.WriteLine("Student not found!");
    //     }
    // } 
    public override void InCompliteCourse(string studentID)
    {
        Console.WriteLine("Incomplete Courses:");
        var student = students.FirstOrDefault(s => s.StudentID == studentID);
        if (student != null)
        {
            // Get the course names of the student
            string[] studentCourses = student.Courses?.SelectMany(c => c.CourseName.Split(',')) // Split the course names if they contain comma-separated values
                                                       .Select(c => c.Trim()) // Remove any leading or trailing whitespace
                                                       .ToArray();

            // Define the list of predefined courses
            string[] predefinedCourses = {
            "Programming ",
           "Algorithms",
           "OOP",
           "NetworKing",
        };

            Console.WriteLine("Filtering the incomplete courses:");
            // Find the incomplete courses
            var incompleteCourses = predefinedCourses.Where(course => !studentCourses.Contains(course)).ToArray();
            foreach (var course in incompleteCourses)
            {
                Console.WriteLine($"- CourseName: {course}");
            }
        }
        else
        {
            Console.WriteLine("Student not found!");
        }
    }


    public void EmptyCompliteCourse()
    {
        Console.WriteLine("Your Abailable Courese are: ");
        string[] cseCourses = {
            "Programming ",
            "Algorithms",
            "OOP",
            "NetworKing",


        };
        foreach (var course in cseCourses)
        {
            Console.WriteLine($"- CourseName: {course}"); // Modify as needed to display other course details
        }
    }
}