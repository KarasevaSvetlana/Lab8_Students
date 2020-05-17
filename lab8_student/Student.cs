using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab8_student
{
    [Serializable]
   public class Student
    {
        public string FIO { get; set; }
        public ulong NumBook { get; set; }
        public ushort Curs { get; set; }
        public string CodeG { get; set; }
        public string Discipline { get; set; }
        public ushort Rating { get; set; }
        public Student()
        { }

        public Student(string FIO, ulong NumBook, ushort Curs, string CodeG, string Discipline, ushort Rating)
        {
            this.FIO = FIO;
            this.NumBook = NumBook;
            this.Curs = Curs;
            this.CodeG = CodeG;
            this.Discipline = Discipline;
            this.Rating = Rating;
        }
        public Student(Student student)
        {
            this.FIO = student.FIO;
            this.NumBook = student.NumBook;
            this.Curs = student.Curs;
            this.CodeG = student.CodeG;
            this.Discipline = student.Discipline;
            this.Rating = student.Rating;
        }
    }
}
