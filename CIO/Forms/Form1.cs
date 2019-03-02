using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CIO
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Size = new Size(1260, 710);
            trackbar.SetRange(1, 255);
            trackbar_value = trackbar.Value = 150;
        }

        #region Глобальные переменные
        
        public static Class_Image CL; // специальный класс для работы с изображением типа BitMap



        bool Btn_light = false;         // просветление
        bool Btn_binarization = false;  // бинаризация
        bool Btn_smoothing = false;     // сглаживание
        public bool Btn_gistogramma = false;   // гистограммное растягивание

        int trackbar_value = 0; // значение trackbar


        #endregion

        #region Кнопки
        // загрузка файла
        private void btn_openpicture_Click(object sender, EventArgs e)
        {
            try
            {
                chart1.Series["Before"].Points.Clear();

                chart2.Series["After"].Points.Clear();

                OpenFileDialog OFD = new OpenFileDialog();
                if (OFD.ShowDialog() == DialogResult.OK)
                {
                    PictureBox_Main.Image = Image.FromFile(OFD.FileName);
                   
                    Bitmap main_image = new Bitmap(OFD.FileName);
                    CL = new Class_Image(main_image);

                    ProgressBar.Maximum = main_image.Width * main_image.Height; // максимальное значение progress bar 
                    open_buttons();
                    //PictureBox_Main.Width = CL.widht;
                   // PictureBox_Main.Height = CL.height;
                    
                }
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
        }

        //Негатив
        private void btn_negative_Click(object sender, EventArgs e)
        {
            this.Size = new Size(1260, 710);
            ProgressBar.Visible = true;
            chart1.Visible = false;
            chart2.Visible = false;
            ProgressBar.Visible = false;
            trackbar.Visible = false;
            Btn_smoothing = false;
            Btn_gistogramma = false;
            Label_RedColor.Visible = false;

            if (label_max_trackbar.Text != "255") change_trackbar();
            pictureBox_after.Image = CL.Negative();
        }
        
        //Бинеризация
        private void btn_binarization_Click(object sender, EventArgs e)
        {
            this.Size = new Size(1260, 710);

            chart1.Visible = false;
            chart2.Visible = false;
            Btn_light = false;
            ProgressBar.Visible = true;
            Btn_binarization = true;
            trackbar.Visible = true;
            ProgressBar.Visible = true;
            Btn_smoothing = false;
            Btn_gistogramma = false;
            Label_RedColor.Visible = false;

            if (label_max_trackbar.Text != "255") change_trackbar();

            pictureBox_after.Image = CL.binarization(trackbar_value,this);  
        }
       
        // Просветление
        private void btn_light_Click(object sender, EventArgs e)
        {
            this.Size = new Size(1260, 710);
            chart1.Visible = false;
            chart2.Visible = false;
            Btn_binarization = false;
            Btn_light = true;
            ProgressBar.Visible = true;
            trackbar.Visible = true;
            ProgressBar.Visible = true;
            Btn_smoothing = false;
            Btn_gistogramma = false;
            Label_RedColor.Visible = false;
            if (label_max_trackbar.Text != "255") change_trackbar();

            pictureBox_after.Image = CL.lighting(trackbar_value,this);

            
        }

        // сглажевание
        private void btn_smoothing_Click(object sender, EventArgs e)
        {
            this.Size = new Size(1260, 710);
            Btn_smoothing  = true;
            Btn_binarization = false;
            Btn_light = false;
            
            ProgressBar.Visible = true;
            trackbar.Visible = true;
            chart1.Visible = false;
            chart2.Visible = false;
            Btn_gistogramma = false;
            Label_RedColor.Visible = false;

            if (label_max_trackbar.Text != "5")
            {
                trackbar.Minimum = 1;
                trackbar.Maximum = 5;
                trackbar.Value = 1;
                label_min_trackbar.Text = "1";
                label_max_trackbar.Text = "5";
            }

            pictureBox_after.Image = CL.smoothing(trackbar.Value,this);

        }

        // Растягивание гистограммы 
        private void btn_gistogramm_Click(object sender, EventArgs e)
        {
            this.Size = new Size(1260, 730);

            contextMenuStrip1.Items.Clear(); // Ну, или сразу в OnLoad заполняешь пункты
            contextMenuStrip1.Items.Add("Нормализация");
            contextMenuStrip1.Items.Add("Растягивание");


            contextMenuStrip1.Show(btn_gistogramm, new Point(0, btn_gistogramm.Height));
           // ProgressBar.Visible = true;
            Btn_smoothing = false;
            Btn_binarization = false;
            Btn_light = false;

            ProgressBar.Visible = true;
            trackbar.Visible = false;
            chart1.Visible = true;
            chart2.Visible = true;
            Btn_gistogramma = false;
            Label_RedColor.Visible = false;

            if (label_max_trackbar.Text != "255") change_trackbar();

            


           // pictureBox_after.Image = CL.gistogramma(this);
        }

        //растягивание гистограммы линейное
        private void btn_rastagivanie_Click(object sender, EventArgs e)
        {
            ColorToGrayscle ctg = new ColorToGrayscle(CL.get_bitmap, tbrR.Value * 0.01, tbrG.Value * 0.01, tbrB.Value * 0.01);
            //resultBitmap = ctg.GetGrayscale();
            pictureBox_after.Image = ctg.GetGrayscale();
        }

        // Раскрашивание
        private void btn_colorizing_Click(object sender, EventArgs e)
        {
            this.Size = new Size(1260, 710);
            chart1.Visible = false;
            chart2.Visible = false;
            Btn_binarization = false;
            Btn_light = false;
            ProgressBar.Visible = true;
            Btn_smoothing = false;
            trackbar.Visible = false;
            Btn_gistogramma = false;
            Label_RedColor.Visible = false;
            if (label_max_trackbar.Text != "255") change_trackbar();

            pictureBox_after.Image = CL.Colorizing(this);

        }

        // Собель
        private void btn_Sobel_Click(object sender, EventArgs e)
        {
            this.Size = new Size(1260, 710);
            chart1.Visible = false;
            chart2.Visible = false;
            Btn_binarization = false;
            Btn_light = false;
            ProgressBar.Visible = false;
            Btn_smoothing = false;
            trackbar.Visible = false;
            Btn_gistogramma = false;
            Label_RedColor.Visible = false;
            if (label_max_trackbar.Text != "255") change_trackbar();

            pictureBox_after.Image = CL.Sobel3x3Filter();
        }

        // Кирш
        private void btn_Kirch_Click(object sender, EventArgs e)
        {
            this.Size = new Size(1260, 710);
            chart1.Visible = false;
            chart2.Visible = false;
            Btn_binarization = false;
            Btn_light = false;
            ProgressBar.Visible = false;
            Btn_smoothing = false;
            trackbar.Visible = false;
            Btn_gistogramma = false;
            Label_RedColor.Visible = false;
            if (label_max_trackbar.Text != "255") change_trackbar();

            pictureBox_after.Image = CL.KirschFilter();
        }

        // Лаплас
        private void btn_laplas_Click(object sender, EventArgs e)
        {
            this.Size = new Size(1260, 710);
            chart1.Visible = false;
            chart2.Visible = false;
            Btn_binarization = false;
            Btn_light = false;
            ProgressBar.Visible = false;
            Btn_smoothing = false;
            trackbar.Visible = false;
            Btn_gistogramma = false;
            Label_RedColor.Visible = false;
            if (label_max_trackbar.Text != "255") change_trackbar();

           // pictureBox_after.Image = CL.Laplacian3x3Filter();
            pictureBox_after.Image = CL.Gaussuian5x5Filter();
        }

        // Робертс
        private void btn_Roberts_Click(object sender, EventArgs e)
        {
            this.Size = new Size(1260, 710);
            chart1.Visible = false;
            chart2.Visible = false;
            Btn_binarization = false;
            Btn_light = false;
            ProgressBar.Visible = false;
            Btn_smoothing = false;
            Btn_gistogramma = false;
            trackbar.Visible = false;
            Label_RedColor.Visible = false;
            if (label_max_trackbar.Text != "255") change_trackbar();

            pictureBox_after.Image = CL.RobertsFilter();
        }

        // Поиск глаза
        private void btn_FindEye_Click(object sender, EventArgs e)
        {
            /*
            this.Size = new Size(1100, 480);
            this.Size = new Size(1100, 730);
            chart1.Visible = true;
            chart2.Visible = true;
            Btn_binarization = false;
            Btn_light = false;
            ProgressBar.Visible = false;
            Btn_smoothing = false;
            Btn_gistogramma = false;
            */
            Label_RedColor.Visible = false;
            Form_eye fe = new Form_eye();
            fe.ShowDialog(this);
            //fe.Show();

            //pictureBox_after.Image = CL.FindEye(this);
           

        }
        #endregion
        
        #region Побочные функции
        protected void open_buttons()
        {
            btn_binarization.Enabled = true;
            btn_FindEye.Enabled = true;
            btn_gistogramm.Enabled = true;
            btn_Kirch.Enabled = true;
            btn_laplas.Enabled = true;
            btn_laplas.Enabled = true;
            btn_light.Enabled = true;
            btn_negative.Enabled = true;
            btn_Roberts.Enabled = true;
            btn_smoothing.Enabled = true;
            btn_Sobel.Enabled = true;
            btn_colorizing.Enabled = true;
        }
        
        private void trackbar_MouseUp(object sender, MouseEventArgs e)
        {
            trackbar_value = trackbar.Value;// определяем знчение ползунка

            // бинаризация
            if (Btn_binarization)
            { btn_binarization.PerformClick(); }

            //просветление
            if (Btn_light)
            { btn_light.PerformClick(); }

            // сглаживание
            if (Btn_smoothing)
            { btn_smoothing.PerformClick(); }

            if (Btn_gistogramma)
            {
                pictureBox_after.Image = CL.gistogramma(this);
            }
        }
        
        private void trackbar_VisibleChanged(object sender, EventArgs e)
        {
            if (trackbar.Visible == true)
            {
                label_min_trackbar.Visible = true;
                label_max_trackbar.Visible = true;
                Label_value_trackbar.Visible = true;   
            }
            else {
                label_min_trackbar.Visible = false;
                label_max_trackbar.Visible = false;
                Label_value_trackbar.Visible = false;   
            }
        }

        private void trackbar_Scroll(object sender, EventArgs e)
        {
            Label_value_trackbar.Text = Convert.ToString(trackbar.Value);
        }

        private void change_trackbar() {
            trackbar.Minimum = 1;
            trackbar.Maximum = 255;
            trackbar.Value = 100;
            label_min_trackbar.Text = "0";
            label_max_trackbar.Text = "255";
            
            


        }

        private void pictureBox_after_MouseMove(object sender, MouseEventArgs e)
        {

            /* Point p = pictureBox_after.PointToClient(System.Windows.Forms.Cursor.Position);
             label_R.Text = Convert.ToString(  Class_Image.return_color(p.X,p.Y).R);
             label_G.Text = Convert.ToString(Class_Image.return_color(p.X, p.Y).G); ;
             label_B.Text = Convert.ToString(Class_Image.return_color(p.X, p.Y).B); ;
             */
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                Bitmap resultBitmap = new Bitmap(pictureBox_after.Image);

                if (resultBitmap != null)
                {
                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.Title = "Specify a file name and file path";
                    sfd.Filter = "Png Images(*.png)|*.png|Jpeg Images(*.jpg)|*.jpg";
                    sfd.Filter += "|Bitmap Images(*.bmp)|*.bmp";

                    if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        string fileExtension = Path.GetExtension(sfd.FileName).ToUpper();
                        ImageFormat imgFormat = ImageFormat.Png;

                        if (fileExtension == "BMP")
                        {
                            imgFormat = ImageFormat.Bmp;
                        }
                        else if (fileExtension == "JPG")
                        {
                            imgFormat = ImageFormat.Jpeg;
                        }

                        StreamWriter streamWriter = new StreamWriter(sfd.FileName, false);
                        resultBitmap.Save(streamWriter.BaseStream, imgFormat);
                        streamWriter.Flush();
                        streamWriter.Close();

                        resultBitmap = null;
                    }
                }
            }
            catch
            {

            }
        }

        private void PictureBox_Main_Paint(object sender, PaintEventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                this.Size = new Size(1100, 730);
                Btn_smoothing = true;
                Btn_binarization = false;
                Btn_light = false;

                ProgressBar.Visible = true;
                trackbar.Visible = false;
                chart1.Visible = true;
                chart2.Visible = true;

                Class_Image.show_histogram(this);
            }
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "Нормализация")
            {
                pictureBox_after.Image = CL.gistogramma(this);
            }
            else if (e.ClickedItem.Text == "Растягивание")
            {
                trackbar.Visible = false;
                Btn_gistogramma = true;

                Label_RedColor.Visible = true;
            }
        }

        private void Open_Close_Gistogramma() {

            
        }
        #endregion

        #region Properties

        public int ProgressBar_Value
        {
            get
            {
                return this.ProgressBar.Value;
            }
            set
            {
                this.ProgressBar.Value = value;
            }
        }
        public int ProgressBar_Max
        {
            set
            {
                this.ProgressBar.Maximum = value;
            }
            
        }

        public int Trackbar_Value { 
            get
            {
                return this.trackbar.Value;
            }
            set
            {
                this.trackbar.Value = value;
            }
        }

        public  Image picturebx_get {
            get
            {
                return this.PictureBox_Main.Image;
            }
        }
        #endregion

        

        private void Label_RedColor_VisibleChanged(object sender, EventArgs e)
        {
            if (Label_RedColor.Visible == true)
            {
                Label_RedColor.Visible = true;
                Label_BlueColor.Visible = true;
                Label_GreenColor.Visible = true;
                tbrR.Visible = true;
                tbrG.Visible = true;
                tbrB.Visible = true;
                btn_rastagivanie.Visible = true;
            }
            else
            {
                Label_RedColor.Visible = false;
                Label_BlueColor.Visible = false;
                Label_GreenColor.Visible = false;
                tbrR.Visible = false;
                tbrG.Visible = false;
                tbrB.Visible = false;
                btn_rastagivanie.Visible = false;
            }
        }

        private void tbrG_Scroll(object sender, EventArgs e)
        {

        }
               
    }
}
