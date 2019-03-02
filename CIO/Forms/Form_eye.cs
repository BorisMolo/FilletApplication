using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CIO
{
    public partial class Form_eye : Form
    {
        public Form_eye()
        {
            InitializeComponent();
        }

        private void Form_eye_Load(object sender, EventArgs e)
        {
            //pictureBox1.Image = Form1);
            PictureBox_Main.Image = Form1.CL.get_image;
            splitContainer1.SplitterDistance = Form1.CL.widht;

            label1.Text = Convert.ToString(PictureBox_Main.Width);
            label2.Text = Convert.ToString(PictureBox_Main.Height);
            MessageBox.Show(Convert.ToString(PictureBox_Main.Image.Height));
            MessageBox.Show(Convert.ToString(PictureBox_Main.Image.Width));

            splitContainer1.Panel1.AutoScroll = true;
           // pictureBox_after.SizeMode = AutoSize; 
            //
        }

        private void findEyeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox_after.Image = Form1.CL.FindEye(this);
        }
    }
}
