
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace TextPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamWriter sw = new StreamWriter(new FileStream("수업.txt", FileMode.Create));

            sw.WriteLine("Programming Practice");
            sw.WriteLine("We are styding now!");
            sw.WriteLine("Yeah~~!!");

            sw.Close();

            StreamReader sr = new StreamReader(new FileStream("수업.txt", FileMode.Open));

            while (sr.EndOfStream == false)
            {
                Console.WriteLine(sr.ReadLine());
            }
            
            sr.Close();

            Console.ReadLine();
        }
    }
}
