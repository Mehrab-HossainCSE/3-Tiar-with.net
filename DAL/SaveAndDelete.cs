

using StudentManagementSystem.DAL.Interface;

using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace StudentManagementSystem.DAL
{
    public class FileManager : Idbindex
    {
        private static string StudentsFilePath = "students.json";

        public void SaveStudents(List<Student> students)
        {
            // Serialize the list of students to JSON
            string json = JsonConvert.SerializeObject(students, Formatting.Indented);

            // Write the JSON to a file
            File.WriteAllText("students.json", json);
        }

        public List<Student> LoadStudents()
        {
            if (File.Exists(StudentsFilePath))
            {
                var json = File.ReadAllText(StudentsFilePath);
                return JsonConvert.DeserializeObject<List<Student>>(json);
            }
            return new List<Student>();
        }
        

    }


}
