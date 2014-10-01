using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Simple_Edit
{
    public partial class Form1 : Form
    {
        public static bool textchanged = false;
        public static string filename = "Document1";
        public Form1()
        {
            InitializeComponent();
        }
        //New button
        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            if (textchanged == true)
            {
                const string message = "You have usaved changes. Continue?";
                const string caption = "Form Closing";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    richTextBox1.Clear();
                    richTextBox1.Focus();
                    textchanged = false;
                }
            }
        }
        //Open button
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            textchanged = true;
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Text Files|*.txt";
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                richTextBox1.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                filename = openFileDialog1.FileName;
                this.Text = filename;
            }
        }
    }
}
