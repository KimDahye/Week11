using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;

namespace SerializedStudent
{
    [Serializable]
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
            Stream ws = new FileStream("a.dat", FileMode.Create);
            BinaryFormatter serializer = new BinaryFormatter();

            ArrayList students = new ArrayList();
            students.Add(new Student("김다혜", "수학", 86));
            students.Add(new Student("아이유", "수학", 86));
            students.Add(new Student("바보", "수학", 86));
            students.Add(new Student("홍길동", "수학", 86));
            
            serializer.Serialize(ws, students);

            ws.Close();
            
            Stream rs = new FileStream("a.dat", FileMode.Open);
            BinaryFormatter deserializer = new BinaryFormatter();

            students = (ArrayList)deserializer.Deserialize(rs);

            foreach (Student student in students)
            {
                Console.WriteLine("{0}\t{1}\t{2}\t", student.GetName(), student.GetSubject(),
                    student.GetScore());
            }
            rs.Close();
            Console.ReadLine();
        }
    }
}
