using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teacher_Record
{
    internal class Program
    {
        static List<Teacher> teachers;
        static void Main()
        {
            teachers = FileHelper.LoadTeachers();
            while (true)
            {
                Console.WriteLine("Teacher Records System");
                Console.WriteLine("1. Add Teacher");
                Console.WriteLine("2. Update Teacher");
                Console.WriteLine("3. Display All Teachers");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");
                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            AddTeacher();
                            break;
                        case 2:
                            UpdateTeacher();
                            break;
                        case 3:
                            DisplayAllTeachers();
                            break;
                        case 4:
                            FileHelper.SaveTeachers(teachers);
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        static void AddTeacher()
        {
            Console.WriteLine("Adding a New Teacher");
            Console.Write("Enter Teacher ID: ");
            int id = int.Parse(Console.ReadLine());

            // Add input validation for unique ID

            Console.Write("Enter Teacher Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Class and Section: ");
            string classAndSection = Console.ReadLine();

            teachers.Add(new Teacher { ID = id, Name = name, ClassAndSection = classAndSection });
            Console.WriteLine("Teacher added successfully.");
        }

        static void UpdateTeacher()
        {
            Console.WriteLine("Updating Teacher");
            Console.Write("Enter Teacher ID to update: ");
            int id = int.Parse(Console.ReadLine());

            Teacher teacherToUpdate = teachers.Find(t => t.ID == id);

            if (teacherToUpdate != null)
            {
                Console.Write("Enter new Teacher Name: ");
                teacherToUpdate.Name = Console.ReadLine();

                Console.Write("Enter new Class and Section: ");
                teacherToUpdate.ClassAndSection = Console.ReadLine();

                Console.WriteLine("Teacher updated successfully.");
            }
            else
            {
                Console.WriteLine($"Teacher with ID {id} not found.");
            }
        }

        static void DisplayAllTeachers()
        {
            Console.WriteLine("All Teachers:");

            foreach (var teacher in teachers)
            {
                Console.WriteLine($"ID: {teacher.ID}, Name: {teacher.Name}, Class and Section: {teacher.ClassAndSection}");
            }
        }
    }
}
