using StudentManagementSystem.BAL.Delegate;
using StudentManagementSystem.DAL.Interface;
using StudentManagementSystem.ExtensionMethod;
using StudentManagementSystem.DAL;
public class ChoiceMenu
{    public static List<Student> students;
    public delegate void Print();
    public static void PrintChoices()
    {
        Print addStudent = new Print(MainMenu.AddStudent);
        Print addSemester = new Print(MainMenu.AddSemesterCourse);
        Print viewDetails = new Print(MainMenu.ViewStudentDetails);
        Print deleteStudent = new Print(MainMenu.DeleteStudentDetails);
        Print exitDelegate = new Print(InputStudent.Exit);
        
          FileManager fileManager = new FileManager();
        students = fileManager.LoadStudents();
        int choice;
        ImplementCURD obj = new ImplementCURD();
        do
        {  
            addStudent();
            addSemester();
            viewDetails();
            deleteStudent();
            exitDelegate();
            choice = int.Parse(Console.ReadLine());
            // if (!int.TryParse(Console.ReadLine(), out choice))
            // {
            //     Console.WriteLine("Invalid choice. Please try again.");
            //     continue;
            // }

            switch (choice)
            {
                case 1:
                    var newStudent = new Student();
                    AddNewStudentExtension.AddNewStudent(newStudent);
                    // students.Add(newStudent);
                    // FileManager.SaveStudents(students);
                    break;
                case 2:
                    obj.Details();
                    break;
                case 3:
                    obj.Delete();
                    break;
                case 4:
                   var newStudent1 = new Student();
                    AddNewStudentExtension.AddSemesterCourse(newStudent1);
                    break;
                case 5:
                    fileManager.SaveStudents(students);
                    Console.WriteLine("Exiting...");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        } while (choice != 5);
    }
}
