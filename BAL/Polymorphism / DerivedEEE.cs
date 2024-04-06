
using StudentManagementSystem.DAL.Interface;
using StudentManagementSystem.DAL;
using StudentManagementSystem;
using System;
using System.Collections.Generic;
using System.Linq;

public class DerivedEEE : OfferCourse
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
    public override void InCompliteCourse(string studentID)
    {
        Console.WriteLine("Incomplete Courses:");
        var student = students.FirstOrDefault(s => s.StudentID == studentID);
        if (student != null)
        {
            // Get the course names of the student
            string[] studentCourses = student.Courses?.Select(c => c.CourseName.ToLower()).ToArray();

            // BBA courses
           string[] eeeCourses = {


            "EmbeddedSystems",
            "DigitalSignal",
             "PowerSystem",

            "IOT",
            "Robotics",

        };

            Console.WriteLine("Filter the incomplete courses") ;
            var incompleteCourses = eeeCourses.Where(course => !studentCourses.Contains(course.ToLower())).ToArray();
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
        string[] eeeCourses = {


            "EmbeddedSystems",
            "DigitalSignal",
             "PowerSystem",

            "IOT",
            "Robotics",

        };
        foreach (var course in eeeCourses)
        {
            Console.WriteLine($"- CourseID: {course}"); // Modify as needed to display other course details
        }

    }
}