using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FileDivideAndAssemble
{
    class Program
    {
        static void Main(string[] args)
        {
            string flag = Console.ReadLine();
            if (flag == "Read")      
                Read();
            else
                Display();      
        }

        public static void Read()
        {
            {
                string path = @"D:\test\Untitled.png";
                string path1 = @"D:\test\file1.txt";
                string path2 = @"D:\test\file2.txt";
                byte[] imagebyte = File.ReadAllBytes(path);
                byte[] fileOne = null;
                byte[] fileTwo = null;
                Stack<byte> byt = new Stack<byte>();
                for (int i = 0; i < imagebyte.Length; i++)
                {
                    if (i % 2 == 0)
                        byt.Push(imagebyte[i]);
                    else
                        byt.Push(imagebyte[i]);
                }
                fileOne = byt.ToArray();
                fileTwo = byt.ToArray();
                if (fileOne != null)
                    File.WriteAllBytes(path1, fileOne);
                if (fileOne != null)
                    File.WriteAllBytes(path2, fileTwo);
                Console.WriteLine("file read");
                Console.ReadLine();
            }

        }

        public static void Display()
        {
         string path = @"D:\test\created.png";
            string path1 = @"D:\test\file1.txt";
            string path2 = @"D:\test\file2.txt";

            if (File.Exists(path1) && File.Exists(path2))
            {
                byte[] imagebyte1 = File.ReadAllBytes(path1);
                byte[] imagebyte2 = File.ReadAllBytes(path2);
                byte[] imagebyte = null;
                Stack<byte> byt = new Stack<byte>();


                for (int i = 0; i < imagebyte1.Length; i++)
                {
                    if (i % 2 == 0)
                        byt.Push(imagebyte1[i]);
                    else
                        byt.Push(imagebyte2[i]);
                }
                imagebyte = byt.ToArray();
                File.WriteAllBytes(path, imagebyte);
                System.Diagnostics.Process.Start(path);
                //File.Delete(path);
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Please perform read oparation(enter \"dev\")");
                Console.ReadLine();
            }
        }
    }
}
