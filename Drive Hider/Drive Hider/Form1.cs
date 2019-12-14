using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Reflection;
using Microsoft.Win32;

namespace Drive_Hider
{
    public partial class Form1 : Form
    {
		/*
		  Written by 
		  Aavesh Jilani
		  */
        public Form1()
        {
            InitializeComponent();
        }
        String ou = "";
        private void Form1_Load(object sender, EventArgs e)
        {
            Process p = new Process();

            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
			//diskpart to get the storage drives data.
            p.StartInfo.FileName = @"C:\Windows\System32\diskpart.exe";
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.CreateNoWindow = true;
			//for admin permissions
            p.StartInfo.Verb = "runas";

            p.Start();
            p.StandardInput.WriteLine("List Volume");
            p.StandardInput.WriteLine("exit");
            ou = p.StandardOutput.ReadToEnd();
            string[] oi = Regex.Split(ou, "DISKPART>");
            
         
            string h = oi[1].Replace("Volume", "Drive");
      h = h.Replace("###", "#");
         
            richTextBox1.Text = h;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string lt = textBox1.Text;
            string sb = textBox2.Text;
			//if values are empty.
            if (lt.Equals("") || lt.Equals(null) || sb.Equals(null) || sb.Equals(""))
            {

                MessageBox.Show("Please enter values.");
            }
            else {

              



                Process p = new Process();

                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.FileName = @"C:\Windows\System32\diskpart.exe";
                p.StartInfo.RedirectStandardInput = true;
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.Verb = "runas";

                p.Start();
                p.StandardInput.WriteLine("List Volume");
				//hiding the drive with commands.
                p.StandardInput.WriteLine("Select Volume " + lt);
                p.StandardInput.WriteLine("Remove Letter " + sb);
                p.StandardInput.WriteLine("exit");
                ou = p.StandardOutput.ReadToEnd();
                string[] oi = Regex.Split(ou, "DISKPART>");

               
                richTextBox1.Text = oi[1].ToString();
                MessageBox.Show("Drive Hidden Successfully!");


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string lt = textBox1.Text;
            string sb = textBox2.Text;
            if (lt.Equals("") || lt.Equals(null) || sb.Equals(null) || sb.Equals(""))
            {
                MessageBox.Show("Please enter values.");


            }
            else
            {

           



                Process p = new Process();

                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.FileName = @"C:\Windows\System32\diskpart.exe";
                p.StartInfo.RedirectStandardInput = true;
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.Verb = "runas";

                p.Start();
                p.StandardInput.WriteLine("List Volume");
				//unhiding the drive with commands
                p.StandardInput.WriteLine("Select Volume " + lt);
                p.StandardInput.WriteLine("Assign Letter " + sb);
                p.StandardInput.WriteLine("exit");
                ou = p.StandardOutput.ReadToEnd();
                string[] oi = Regex.Split(ou, "DISKPART>");

                
                richTextBox1.Text = oi[1].ToString();
                MessageBox.Show("Drive Unhide Successfully!");





            }



        }
    }
}
