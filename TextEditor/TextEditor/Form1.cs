﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace TextEditor
{
    public partial class TextEditor : Form
    {

        string filename=null;
        public TextEditor()
        {
            InitializeComponent();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
        }


        public static String fileToText(String filePath)
        {
            StreamReader file = new StreamReader(filePath);
            String text = file.ReadToEnd();
            file.Close();
            return text;
        }

        public static void textToFile(String filePath, String text)
        {
            StreamWriter file = new StreamWriter(filePath);
            file.Write(text);
            file.Close();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            // saveFileDialog1.RestoreDirectory = true;
            if (filename == null)
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {

                    textToFile(saveFileDialog1.FileName, richTextBox1.Text);

                }
                filename = saveFileDialog1.FileName;
            }
            else
                textToFile(saveFileDialog1.FileName, richTextBox1.Text);



        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {


            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
              
                richTextBox1.Text = fileToText(openFileDialog1.FileName);

                 filename = openFileDialog1.FileName;
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DateTime myDate = DateTime.Now;
            string myDateString = myDate.ToString("yyyy-MM-dd HH:mm");
            MessageBox.Show("This is texteditor for txt\nVersion:01",myDateString);
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
           

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
