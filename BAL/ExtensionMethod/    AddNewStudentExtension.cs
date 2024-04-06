using System;
using StudentManagementSystem.DAL;
using StudentManagementSystem.BAL.Polymorphism;
namespace StudentManagementSystem.ExtensionMethod
{
    public static class AddNewStudentExtension
    {
      public static List<Student> students;
       public static List<Student> student;
        public static void AddNewStudent(this Student student)
        {  
            FileManager fileManager=new FileManager();
            students = fileManager.LoadStudents();
            // if (student == null)
            // {
               
            // }
            // students = new List<Student>();
            Console.WriteLine("Adding New Student");

            Console.Write("Enter First Name: ");
            student.FirstName = Console.ReadLine();

            Console.Write("Enter Middle Name: ");
            student.MiddleName = Console.ReadLine();

            Console.Write("Enter Last Name: ");
            student.LastName = Console.ReadLine();

            Console.Write("Enter Student ID (XXX-XXX-XXX): ");
            student.StudentID = Console.ReadLine();

            Console.Write("Enter Joining Batch: ");
            student.JoiningBatch = Console.ReadLine();

            Console.Write("Enter Department (ComputerScience/BBA/English): ");
            student.Department = (Department)Enum.Parse(typeof(Department), Console.ReadLine());

            Console.Write("Enter Degree (BSC/BBA/BA/MSC/MBA/MA): ");
            student.Degree = (Degree)Enum.Parse(typeof(Degree), Console.ReadLine());
            students.Add(student);
            fileManager.SaveStudents(students);
            Console.WriteLine("Student added successfully.");
        }
       public static void AddSemesterCourse(this Student student1)
    {
        //SemestersAttended =new List<Semester>();
          FileManager fileManager=new FileManager();
            students = fileManager.LoadStudents();

        Console.WriteLine("Enter student ID:");
        var studentID = Console.ReadLine();
        // FilterCourse .Course(studentID);
        //obj1;
        var student = students.FirstOrDefault(s => s.StudentID == studentID);

        if (student != null)
        {
            Console.WriteLine($"Adding New Semester for Student: {studentID}");

            Console.Write("Enter SemesterCode: ");
            string semesterCode = Console.ReadLine();

            Console.Write("Enter Year: ");
            string year = Console.ReadLine();

            // Create a new Semester object
            var newSemester = new Semester
            {
                SemesterCode = semesterCode,
                Year = year
            };

            // Initialize SemestersAttended list if it's null
            if (student.SemestersAttended == null)
            {
                student.SemestersAttended = new List<Semester>();
            }

            // Add the new semester to SemestersAttended list
            student.SemestersAttended.Add(newSemester);

            Console.WriteLine("Semester added successfully.");
            FilterCourse obj=new FilterCourse();
            obj.Course();
            AddCoursesForExistingStudent(student, fileManager);
        }
        else
        {
            Console.WriteLine("Student not found.");
        }
    }

    private static void AddCoursesForExistingStudent(Student student, FileManager fileManager)
    {
        // Your existing code here


        Console.WriteLine("Enter courseID :");
        var courseID = Console.ReadLine();
        Console.WriteLine("Enter course Name Using , for multiple course names:");
        var courseName = Console.ReadLine();

        Console.WriteLine("Enter course Instructor Name :");
        var instructorName = Console.ReadLine();

        Console.WriteLine("Enter numberOfCredits:");
        var numberOfCredits = int.Parse(Console.ReadLine());

        Console.Write("Enter Course ID to add: ");
        var courseId = Console.ReadLine();

        var newCourse = new Course
        {
            CourseID = courseID,
            CourseName = courseName,
            InstructorName = instructorName,
            NumberOfCredits = numberOfCredits,
        };
        // public List<Course> Courses



        student.Courses ??= new List<Course>();
        student.Courses.Add(newCourse);
        //fileManager.SaveStudents(students);
          fileManager.SaveStudents(students);

        Console.WriteLine("Course added successfully.");



    }
    }
}