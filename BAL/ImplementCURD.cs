using StudentManagementSystem.DAL;
using StudentManagementSystem.BAL.Polymorphism;

public class ImplementCURD : ICURD
{
    public List<Student> students;
    // private List<Student> student;
    public FileManager fileManager;
    //public List<Semester> SemestersAttended; 
    public ImplementCURD()
    {
        // Initialize fileManager
        fileManager = new FileManager();
        // Load students
        students = fileManager.LoadStudents();
    }
    public void Delete()
    {

        Console.Write("Enter Student ID: ");
        string studentID = Console.ReadLine();

        var student = students.FirstOrDefault(s => s.StudentID == studentID);
        if (student != null)
        {
            students.Remove(student);
            Console.WriteLine("Student deleted successfully.");
            fileManager.SaveStudents(students);
        }
        else
        {
            Console.WriteLine("Student not found.");
        }

    }

   
    public void Details()
    {
        Console.WriteLine("Viewing Student Details");
        Console.Write("Enter Student ID: ");
        string studentID = Console.ReadLine();
        fileManager = new FileManager();
        // Load students
        students = fileManager.LoadStudents();
        var student = students.FirstOrDefault(s => s.StudentID == studentID);
        if (student != null)
        {  // Add debugging statements
           // Console.WriteLine($"Number of students loaded: {students.Count}");
           // Console.WriteLine($"Student ID entered by user: {studentID}");
           //Console.WriteLine("Pavle");
            Console.WriteLine($"Student ID: {student.StudentID}");
            Console.WriteLine($"Name: {student.FirstName} {student.MiddleName} {student.LastName}");
            Console.WriteLine($"Joining Batch: {student.JoiningBatch}");
            Console.WriteLine($"Department: {student.Department}");
            Console.WriteLine($"Degree: {student.Degree}");

            if (student.SemestersAttended?.Any() == true)
            {
                Console.WriteLine("Semesters Attended:");
                foreach (var semester in student.SemestersAttended)
                {
                    Console.WriteLine($"Semester Code:- {semester.SemesterCode} Semester Year: {semester.Year}");
                }
            }
            else
            {
                Console.WriteLine("No Semesters are assigned.");
            }

            if (student.Courses?.Any() == true)
            {
                Console.WriteLine("Courses:");
                foreach (var course in student.Courses)
                {
                    Console.WriteLine($"- CourseID: {course.CourseID} And CourseName:{course.CourseName}" ); // Modify as needed to display other course details
                }
            }
            else
            {
                Console.WriteLine("No Courses are assigned.");
            }
        }
        else
        {
            Console.WriteLine("Student not found.");
        }
    }


    //return new List<Student>();
}
