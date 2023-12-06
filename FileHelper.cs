using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teacher_Record
{
    public class FileHelper
    {
        private const string FilePath = "C:\\Users\\soums\\OneDrive\\Desktop\\Simplilear\\Teachers.txt";

        public static void SaveTeachers(List<Teacher> teachers)
        {
            var lines = teachers.Select(t => $"{t.ID},{t.Name},{t.ClassAndSection}");
            File.WriteAllLines(FilePath, lines);
        }
        public static List<Teacher> LoadTeachers()
        {
            var teachers = new List<Teacher>();
            if (File.Exists(FilePath))
            {
                var lines = File.ReadAllLines(FilePath);
                foreach (var line in lines)
                {
                    var parts = line.Split(',');
                    if (parts.Length == 3 && int.TryParse(parts[0], out int id))
                    {
                        teachers.Add(new Teacher
                        {
                            ID = id,
                            Name = parts[1],
                            ClassAndSection = parts[2]
                        });
                    }
                }
            }
            return teachers;
        }
    }
}