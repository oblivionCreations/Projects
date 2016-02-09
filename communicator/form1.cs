using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace communicator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            watch();
        }
        string[] lines = new string[10];

        string rtf1;
        private void btnSend_Click(object sender, EventArgs e)
        {
             rtf1 = rtbMessage.Rtf;
            deleteIfExists();
            writeToTxt(rtf1);
          
        }




       public void watch()
        {
            FileSystemWatcher watcher = new FileSystemWatcher()
            {
                Path = @"D:\communicator\",
                Filter = "*.txt"
            };
            watcher.Created += new FileSystemEventHandler(OnChanged);

            watcher.EnableRaisingEvents = true;
        }

       public void OnChanged(object sender, System.EventArgs e)
       {

           string[] lines = System.IO.File.ReadAllLines(@"D:\communicator\Chat.txt");
           if (rtbMessage.InvokeRequired)
           {
               rtbMessage.Invoke((Action)(() => OnChanged(sender, e)));
               
           }
           else
           {
               rtbMessage.Clear();
              // for (int j = 0; j < lines.Length; j++)
              // {
                   //if (lines[j] != null)
                   //{

                      // rtbMessage.AppendText(lines[j] + System.Environment.NewLine);
             
               rtbMessage.AppendText(txtUserName.Text + ":" + rtf1);
                  // }
              // }
              // Array.Clear(lines, 0, lines.Length);
                  
           }

       }

       public void deleteIfExists()
       {
           if (File.Exists(@"D:\communicator\Chat.txt"))
           {
               File.Delete(@"D:\communicator\Chat.txt");
           }
       }

       public void writeToTxt(string rtf1)
       {
          // int i=0;
           //foreach (string line in rtbMessage.Lines)
           //{
           //    if (i < 10)
           //    {
           //        lines[i] = txtUserName.Text + ":" + line;
           //        i++;
           //    }
           //}
            
          // System.IO.File.WriteAllLines(@"D:\communicator\Chat.txt", lines);
           System.IO.File.WriteAllText(@"D:\communicator\Chat.txt", rtf1);
           System.IO.File.WriteAllText(@"D:\communicator\Chathistory.txt", rtf1);
       }
    }
}
