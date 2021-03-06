﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Lab2TextFileGUI1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void 파일FToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 저장하기SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(new FileStream(saveFileDialog.FileName, FileMode.Create));
                sw.WriteLine(textBox1.Text);
                sw.Close();
            }

        }

        private void 불러오기OToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = "";
                StreamReader sr = new StreamReader(new FileStream(openFileDialog.FileName, FileMode.Open));
                textBox1.Text = sr.ReadToEnd();

                /*while (sr.EndOfStream == false)
                {
                    textBox1.Text = textBox1.Text + sr.ReadLine() + "\r\n";

                }*/
            }
        }

        private void 종료하기QToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
