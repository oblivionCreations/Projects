using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Camera_data_logger
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            cmbJPEGCompressionRate.SelectedIndex = 1;
        }

        private void btnSaveAt_Click(object sender, EventArgs e)
        {
           
            FolderBrowserDialog openFileDialog1 = new FolderBrowserDialog();
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) 
            {
                txtSaveAt.Text = openFileDialog1.SelectedPath; // append the path into the textbox
            }
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit(); // exit from the application
        }

        private void btnStartDataLogger_Click(object sender, EventArgs e)
        {
            string path = txtSaveAt.Text+"/Camera Data Logger.txt";
                          
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(cmbResolution.Text);
                    sw.WriteLine(cmbFrameRate.Text);
                    sw.WriteLine(cmbJPEGCompressionRate.Text);
                    sw.Flush();
                    sw.Close();
                }
 
        }

        
    }
}
