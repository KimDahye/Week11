//Lab1

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.IO;

namespace Lab1BinaryFile
{
    class Student
    {
        private string Name;
        private string Subject;
        private int Score;

        public Student(string Name, string Subject, int Score)
        {
            this.Name = Name;
            this.Subject = Subject;
            this.Score = Score;
        }

        public string GetName()
        {
            return Name;
        }
        public string GetSubject()
        {
            return Subject;
        }

        public int GetScore()
        {
            return Score;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            
            string answer = "";
            ArrayList studentList = new ArrayList();
            while (answer != "n")
            {
                               
                Console.Write("이름: ");
                string Name = Console.ReadLine();
                Console.Write("과목: ");
                string Subject = Console.ReadLine();
                Console.Write("점수: ");
                int Score = int.Parse(Console.ReadLine());
                
                Student student = new Student(Name, Subject, Score);
                studentList.Add(student);

                Console.Write("더 입력하시겠습니까?(y/n)");
                answer = Console.ReadLine();
                Console.WriteLine();
            }

            BinaryWriter bw = new BinaryWriter(new FileStream("a.dat", FileMode.Create));
            
            foreach (Student student in studentList)
            {
                bw.Write(student.GetName());
                bw.Write(student.GetSubject());
                bw.Write(student.GetScore());
            }

            bw.Close();

            BinaryReader br = new BinaryReader(new FileStream("a.dat", FileMode.Open));
            ArrayList newStudentList = new ArrayList();

            while (br.PeekChar() != -1)
            {
                Student student = new Student(br.ReadString(), br.ReadString(), br.ReadInt32());
                newStudentList.Add(student);

            }

            br.Close();

            foreach (Student student in newStudentList)
            {
                Console.WriteLine("{0}\t{1}\t{2}", 
                    student.GetName(), student.GetSubject(), student.GetScore());
            }
            
            
        }
    }
}
