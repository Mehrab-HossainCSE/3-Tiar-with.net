using StudentManagementSystem.DAL.Interface;
using StudentManagementSystem.DAL;
using StudentManagementSystem;
namespace StudentManagementSystem.BAL.Polymorphism
{

    public  class FilterCourse
    {

        public static List<Student> students;
        public static List<Student> student;

        public FilterCourse()
        {
            FileManager fileManager = new FileManager();
            students = fileManager.LoadStudents();

        }
        public  void Course()
        {
           Console.WriteLine("Enter your Id As Same AS Immidate Previous One : ");
           var studentID=Console.ReadLine();
            
            if (students == null)
            {
                Console.WriteLine("Students list has not been initialized.");
                return;
            }

            
            var student = students.FirstOrDefault(s => s.StudentID == studentID);
            Department stuDeprt = student.Department;
            if (student == null)
            {
                Console.WriteLine("Student not found.");
                return;
            }

            var BBA = new DerivedBBA();
            var CSE = new DerivedCSE();
            var EEE = new DerivedEEE();
            if (student.Courses?.Any() == true)
            {
                if (stuDeprt == Department.ComputerScience)
                {
                    CSE.CompliteCourse(studentID);
                    CSE.InCompliteCourse(studentID);
                    // Code block for Computer Science department
                }
                else if (stuDeprt == Department.EEE)
                {
                    // Code block for EEE department
                    EEE.CompliteCourse(studentID);
                    EEE.InCompliteCourse(studentID);
                }
                else if (stuDeprt == Department.BBA)
                {
                    // Code block for BBA department
                    BBA.CompliteCourse(studentID);
                    BBA.InCompliteCourse(studentID);
                }

            }
            else
            {
                Console.WriteLine("NO Course list in Empty Now: ");

                if (stuDeprt == Department.ComputerScience)
                {
                    CSE.EmptyCompliteCourse();
                    // Code block for Computer Science department
                }
                else if (stuDeprt == Department.EEE)
                {
                    // Code block for EEE department
                    EEE.EmptyCompliteCourse();
                }
                else if (stuDeprt == Department.BBA)
                {
                    // Code block for BBA department
                    BBA.EmptyCompliteCourse();
                }

            }
        }

    }
}