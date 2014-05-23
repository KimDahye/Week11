using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;



namespace Lab3ListBoxGUI
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void 불러오기OToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ArrayList studentList = new ArrayList();
            studentList.Add(new Student("김다혜", "자구알", 100));
            studentList.Add(new Student("나개론", "소개론", 90));
            studentList.Add(new Student("홍길동", "프연", 80));

            Stream ws = new FileStream("studnets.dat", FileMode.Create);
            BinaryFormatter serializer = new BinaryFormatter();
            serializer.Serialize(ws, studentList);
            ws.Close();

            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Stream rs = new FileStream(openFileDialog.FileName, FileMode.Open);
                BinaryFormatter deserializer = new BinaryFormatter();
       
                studentList = (ArrayList)deserializer.Deserialize(rs);

                foreach (Student student in studentList)
                {
                    listBox1.Items.Add(student.GetName()+"\t"+student.GetSubject()+"\t"+
                        student.GetScore());
                    
                }
                rs.Close();
            }
        }
    }


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
}
