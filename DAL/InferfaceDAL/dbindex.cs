namespace StudentManagementSystem.DAL.Interface{ 
public interface Idbindex{
    public  void SaveStudents(List<Student> students);
    public  List<Student> LoadStudents();
}
}
