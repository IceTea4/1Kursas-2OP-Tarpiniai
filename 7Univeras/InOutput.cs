using System.Text;
using System.IO;
using System;

namespace Univeras
{
    internal class InOutput
    {
        public static FacultyRegister ReadStudents(string fileName)
        {
            string[] lines = File.ReadAllLines(fileName, Encoding.UTF8);

            string faculty = lines[0];

            FacultyRegister facultyRegister = new FacultyRegister(faculty);

            for (int i = 1; i < lines.Count(); i++)
            {
                string[] values = lines[i].Split(';');
                string surname = values[0];
                string name = values[1];
                string group = values[2];
                int notesCount = int.Parse(values[3]);
                int[] notes = new int[notesCount];

                for (int j = 0; j < notesCount; j++)
                {
                    notes[j] = int.Parse(values[j + 4]);
                }

                Studentas student = new Studentas(surname, name, group, notes);

                facultyRegister.students.Add(student);
            }

            return facultyRegister;
        }

        public static void PrintSutents(string label, FacultyRegister register)
        {
            Console.WriteLine(label);
            Console.WriteLine($"Fakultetas: {register.faculty}");
            Console.WriteLine(new string('-', 73));
            Console.WriteLine($"| {"Pavardė",-10} | {"Vardas",-8} | {"Grupė",-5} | {"Pažymių kiekis",14} | {"Pažymiai",20} |");
            Console.WriteLine(new string('-', 73));
            
            for (int i = 0; i < register.students.Count; i++)
            {
                Studentas student = register.students.Get(i);
                Console.WriteLine($"| {student.surname,-10} | {student.name,-8} | {student.group,-5} | {student.notes.Length,14} | {student.NotesToString(),20} |");
            }

            Console.WriteLine(new string('-', 73));
        }
    }
}
