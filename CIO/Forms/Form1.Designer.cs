namespace CIO
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea7 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend7 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea8 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend8 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.PictureBox_Main = new System.Windows.Forms.PictureBox();
            this.pictureBox_after = new System.Windows.Forms.PictureBox();
            this.ProgressBar = new System.Windows.Forms.ProgressBar();
            this.btn_gistogramm = new System.Windows.Forms.Button();
            this.trackbar = new System.Windows.Forms.TrackBar();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.btn_openpicture = new System.Windows.Forms.Button();
            this.btn_smoothing = new System.Windows.Forms.Button();
            this.btn_light = new System.Windows.Forms.Button();
            this.btn_binarization = new System.Windows.Forms.Button();
            this.btn_negative = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btn_Sobel = new System.Windows.Forms.Button();
            this.btn_Kirch = new System.Windows.Forms.Button();
            this.btn_laplas = new System.Windows.Forms.Button();
            this.btn_Roberts = new System.Windows.Forms.Button();
            this.label_min_trackbar = new System.Windows.Forms.Label();
            this.label_max_trackbar = new System.Windows.Forms.Label();
            this.Label_value_trackbar = new System.Windows.Forms.Label();
            this.btn_FindEye = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label_R = new System.Windows.Forms.Label();
            this.label_G = new System.Windows.Forms.Label();
            this.label_B = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btn_colorizing = new System.Windows.Forms.Button();
            this.Label_BlueColor = new System.Windows.Forms.Label();
            this.Label_GreenColor = new System.Windows.Forms.Label();
            this.Label_RedColor = new System.Windows.Forms.Label();
            this.tbrB = new System.Windows.Forms.TrackBar();
            this.tbrG = new System.Windows.Forms.TrackBar();
            this.tbrR = new System.Windows.Forms.TrackBar();
            this.btn_rastagivanie = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_Main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_after)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbrB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbrG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbrR)).BeginInit();
            this.SuspendLayout();
            // 
            // PictureBox_Main
            // 
            this.PictureBox_Main.Location = new System.Drawing.Point(12, 12);
            this.PictureBox_Main.Name = "PictureBox_Main";
            this.PictureBox_Main.Size = new System.Drawing.Size(408, 424);
            this.PictureBox_Main.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBox_Main.TabIndex = 10;
            this.PictureBox_Main.TabStop = false;
            this.PictureBox_Main.Paint += new System.Windows.Forms.PaintEventHandler(this.PictureBox_Main_Paint);
            // 
            // pictureBox_after
            // 
            this.pictureBox_after.Location = new System.Drawing.Point(478, 13);
            this.pictureBox_after.Name = "pictureBox_after";
            this.pictureBox_after.Size = new System.Drawing.Size(408, 424);
            this.pictureBox_after.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_after.TabIndex = 9;
            this.pictureBox_after.TabStop = false;
            this.pictureBox_after.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_after_MouseMove);
            // 
            // ProgressBar
            // 
            this.ProgressBar.Location = new System.Drawing.Point(1040, 139);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(187, 23);
            this.ProgressBar.TabIndex = 20;
            this.ProgressBar.Visible = false;
            // 
            // btn_gistogramm
            // 
            this.btn_gistogramm.Enabled = false;
            this.btn_gistogramm.Location = new System.Drawing.Point(1020, 520);
            this.btn_gistogramm.Name = "btn_gistogramm";
            this.btn_gistogramm.Size = new System.Drawing.Size(100, 43);
            this.btn_gistogramm.TabIndex = 19;
            this.btn_gistogramm.Text = "Гистограммное растягивание";
            this.btn_gistogramm.UseVisualStyleBackColor = true;
            this.btn_gistogramm.Click += new System.EventHandler(this.btn_gistogramm_Click);
            // 
            // trackbar
            // 
            this.trackbar.Location = new System.Drawing.Point(1024, 96);
            this.trackbar.Name = "trackbar";
            this.trackbar.Size = new System.Drawing.Size(187, 45);
            this.trackbar.TabIndex = 18;
            this.trackbar.Visible = false;
            this.trackbar.Scroll += new System.EventHandler(this.trackbar_Scroll);
            this.trackbar.VisibleChanged += new System.EventHandler(this.trackbar_VisibleChanged);
            this.trackbar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trackbar_MouseUp);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(1090, 62);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(115, 17);
            this.checkBox1.TabIndex = 17;
            this.checkBox1.Text = "Вывести матрицу";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.Visible = false;
            // 
            // btn_openpicture
            // 
            this.btn_openpicture.Location = new System.Drawing.Point(1088, 13);
            this.btn_openpicture.Name = "btn_openpicture";
            this.btn_openpicture.Size = new System.Drawing.Size(69, 43);
            this.btn_openpicture.TabIndex = 16;
            this.btn_openpicture.Text = "Открыть файл";
            this.btn_openpicture.UseVisualStyleBackColor = true;
            this.btn_openpicture.Click += new System.EventHandler(this.btn_openpicture_Click);
            // 
            // btn_smoothing
            // 
            this.btn_smoothing.Enabled = false;
            this.btn_smoothing.Location = new System.Drawing.Point(1020, 461);
            this.btn_smoothing.Name = "btn_smoothing";
            this.btn_smoothing.Size = new System.Drawing.Size(100, 43);
            this.btn_smoothing.TabIndex = 15;
            this.btn_smoothing.Text = "Сглажевание";
            this.btn_smoothing.UseVisualStyleBackColor = true;
            this.btn_smoothing.Click += new System.EventHandler(this.btn_smoothing_Click);
            // 
            // btn_light
            // 
            this.btn_light.Enabled = false;
            this.btn_light.Location = new System.Drawing.Point(1020, 408);
            this.btn_light.Name = "btn_light";
            this.btn_light.Size = new System.Drawing.Size(100, 43);
            this.btn_light.TabIndex = 14;
            this.btn_light.Text = "Просветление";
            this.btn_light.UseVisualStyleBackColor = true;
            this.btn_light.Click += new System.EventHandler(this.btn_light_Click);
            // 
            // btn_binarization
            // 
            this.btn_binarization.Enabled = false;
            this.btn_binarization.Location = new System.Drawing.Point(1020, 359);
            this.btn_binarization.Name = "btn_binarization";
            this.btn_binarization.Size = new System.Drawing.Size(100, 43);
            this.btn_binarization.TabIndex = 13;
            this.btn_binarization.Text = "Бинаризация";
            this.btn_binarization.UseVisualStyleBackColor = true;
            this.btn_binarization.Click += new System.EventHandler(this.btn_binarization_Click);
            // 
            // btn_negative
            // 
            this.btn_negative.Enabled = false;
            this.btn_negative.Location = new System.Drawing.Point(1021, 310);
            this.btn_negative.Name = "btn_negative";
            this.btn_negative.Size = new System.Drawing.Size(100, 43);
            this.btn_negative.TabIndex = 12;
            this.btn_negative.Text = "Негатив";
            this.btn_negative.UseVisualStyleBackColor = true;
            this.btn_negative.Click += new System.EventHandler(this.btn_negative_Click);
            // 
            // chart1
            // 
            chartArea7.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea7);
            legend7.Name = "Legend1";
            this.chart1.Legends.Add(legend7);
            this.chart1.Location = new System.Drawing.Point(21, 442);
            this.chart1.Name = "chart1";
            series7.ChartArea = "ChartArea1";
            series7.Legend = "Legend1";
            series7.Name = "Before";
            this.chart1.Series.Add(series7);
            this.chart1.Size = new System.Drawing.Size(408, 238);
            this.chart1.TabIndex = 21;
            this.chart1.Text = "chart1";
            this.chart1.Visible = false;
            // 
            // chart2
            // 
            chartArea8.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea8);
            legend8.Name = "Legend1";
            this.chart2.Legends.Add(legend8);
            this.chart2.Location = new System.Drawing.Point(478, 442);
            this.chart2.Name = "chart2";
            series8.ChartArea = "ChartArea1";
            series8.Legend = "Legend1";
            series8.Name = "After";
            this.chart2.Series.Add(series8);
            this.chart2.Size = new System.Drawing.Size(408, 238);
            this.chart2.TabIndex = 22;
            this.chart2.Text = "chart2";
            this.chart2.Visible = false;
            // 
            // btn_Sobel
            // 
            this.btn_Sobel.Enabled = false;
            this.btn_Sobel.Location = new System.Drawing.Point(1128, 310);
            this.btn_Sobel.Name = "btn_Sobel";
            this.btn_Sobel.Size = new System.Drawing.Size(100, 43);
            this.btn_Sobel.TabIndex = 23;
            this.btn_Sobel.Text = "Собель";
            this.btn_Sobel.UseVisualStyleBackColor = true;
            this.btn_Sobel.Click += new System.EventHandler(this.btn_Sobel_Click);
            // 
            // btn_Kirch
            // 
            this.btn_Kirch.Enabled = false;
            this.btn_Kirch.Location = new System.Drawing.Point(1128, 359);
            this.btn_Kirch.Name = "btn_Kirch";
            this.btn_Kirch.Size = new System.Drawing.Size(100, 43);
            this.btn_Kirch.TabIndex = 24;
            this.btn_Kirch.Text = "Кирш";
            this.btn_Kirch.UseVisualStyleBackColor = true;
            this.btn_Kirch.Click += new System.EventHandler(this.btn_Kirch_Click);
            // 
            // btn_laplas
            // 
            this.btn_laplas.Enabled = false;
            this.btn_laplas.Location = new System.Drawing.Point(1128, 408);
            this.btn_laplas.Name = "btn_laplas";
            this.btn_laplas.Size = new System.Drawing.Size(100, 43);
            this.btn_laplas.TabIndex = 25;
            this.btn_laplas.Text = "Лаплас";
            this.btn_laplas.UseVisualStyleBackColor = true;
            this.btn_laplas.Click += new System.EventHandler(this.btn_laplas_Click);
            // 
            // btn_Roberts
            // 
            this.btn_Roberts.Enabled = false;
            this.btn_Roberts.Location = new System.Drawing.Point(1128, 461);
            this.btn_Roberts.Name = "btn_Roberts";
            this.btn_Roberts.Size = new System.Drawing.Size(100, 43);
            this.btn_Roberts.TabIndex = 26;
            this.btn_Roberts.Text = "Робертс";
            this.btn_Roberts.UseVisualStyleBackColor = true;
            this.btn_Roberts.Click += new System.EventHandler(this.btn_Roberts_Click);
            // 
            // label_min_trackbar
            // 
            this.label_min_trackbar.AutoSize = true;
            this.label_min_trackbar.Location = new System.Drawing.Point(1018, 114);
            this.label_min_trackbar.Name = "label_min_trackbar";
            this.label_min_trackbar.Size = new System.Drawing.Size(13, 13);
            this.label_min_trackbar.TabIndex = 27;
            this.label_min_trackbar.Text = "0";
            this.label_min_trackbar.Visible = false;
            // 
            // label_max_trackbar
            // 
            this.label_max_trackbar.AutoSize = true;
            this.label_max_trackbar.Location = new System.Drawing.Point(1198, 113);
            this.label_max_trackbar.Name = "label_max_trackbar";
            this.label_max_trackbar.Size = new System.Drawing.Size(25, 13);
            this.label_max_trackbar.TabIndex = 28;
            this.label_max_trackbar.Text = "255";
            this.label_max_trackbar.Visible = false;
            // 
            // Label_value_trackbar
            // 
            this.Label_value_trackbar.AutoSize = true;
            this.Label_value_trackbar.Location = new System.Drawing.Point(1112, 113);
            this.Label_value_trackbar.Name = "Label_value_trackbar";
            this.Label_value_trackbar.Size = new System.Drawing.Size(0, 13);
            this.Label_value_trackbar.TabIndex = 29;
            // 
            // btn_FindEye
            // 
            this.btn_FindEye.Enabled = false;
            this.btn_FindEye.Location = new System.Drawing.Point(1128, 520);
            this.btn_FindEye.Name = "btn_FindEye";
            this.btn_FindEye.Size = new System.Drawing.Size(100, 43);
            this.btn_FindEye.TabIndex = 30;
            this.btn_FindEye.Text = "Найти граз";
            this.btn_FindEye.UseVisualStyleBackColor = true;
            this.btn_FindEye.Click += new System.EventHandler(this.btn_FindEye_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1021, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 13);
            this.label3.TabIndex = 31;
            this.label3.Text = "R";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1021, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 13);
            this.label4.TabIndex = 32;
            this.label4.Text = "G";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1021, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 13);
            this.label5.TabIndex = 33;
            this.label5.Text = "B";
            // 
            // label_R
            // 
            this.label_R.AutoSize = true;
            this.label_R.Location = new System.Drawing.Point(1042, 13);
            this.label_R.Name = "label_R";
            this.label_R.Size = new System.Drawing.Size(15, 13);
            this.label_R.TabIndex = 34;
            this.label_R.Text = "R";
            // 
            // label_G
            // 
            this.label_G.AutoSize = true;
            this.label_G.Location = new System.Drawing.Point(1042, 28);
            this.label_G.Name = "label_G";
            this.label_G.Size = new System.Drawing.Size(15, 13);
            this.label_G.TabIndex = 35;
            this.label_G.Text = "G";
            // 
            // label_B
            // 
            this.label_B.AutoSize = true;
            this.label_B.Location = new System.Drawing.Point(1041, 43);
            this.label_B.Name = "label_B";
            this.label_B.Size = new System.Drawing.Size(15, 13);
            this.label_B.TabIndex = 36;
            this.label_B.Text = "G";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1163, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(60, 43);
            this.button1.TabIndex = 37;
            this.button1.Text = "save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            this.contextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip1_ItemClicked);
            // 
            // btn_colorizing
            // 
            this.btn_colorizing.Enabled = false;
            this.btn_colorizing.Location = new System.Drawing.Point(1020, 575);
            this.btn_colorizing.Name = "btn_colorizing";
            this.btn_colorizing.Size = new System.Drawing.Size(100, 43);
            this.btn_colorizing.TabIndex = 38;
            this.btn_colorizing.Text = "Раскрашевание";
            this.btn_colorizing.UseVisualStyleBackColor = true;
            this.btn_colorizing.Click += new System.EventHandler(this.btn_colorizing_Click);
            // 
            // Label_BlueColor
            // 
            this.Label_BlueColor.AutoSize = true;
            this.Label_BlueColor.Location = new System.Drawing.Point(985, 254);
            this.Label_BlueColor.Name = "Label_BlueColor";
            this.Label_BlueColor.Size = new System.Drawing.Size(54, 13);
            this.Label_BlueColor.TabIndex = 44;
            this.Label_BlueColor.Text = "Blue color";
            this.Label_BlueColor.Visible = false;
            // 
            // Label_GreenColor
            // 
            this.Label_GreenColor.AutoSize = true;
            this.Label_GreenColor.Location = new System.Drawing.Point(985, 216);
            this.Label_GreenColor.Name = "Label_GreenColor";
            this.Label_GreenColor.Size = new System.Drawing.Size(62, 13);
            this.Label_GreenColor.TabIndex = 43;
            this.Label_GreenColor.Text = "Green color";
            this.Label_GreenColor.Visible = false;
            // 
            // Label_RedColor
            // 
            this.Label_RedColor.AutoSize = true;
            this.Label_RedColor.Location = new System.Drawing.Point(985, 168);
            this.Label_RedColor.Name = "Label_RedColor";
            this.Label_RedColor.Size = new System.Drawing.Size(53, 13);
            this.Label_RedColor.TabIndex = 42;
            this.Label_RedColor.Text = "Red color";
            this.Label_RedColor.Visible = false;
            this.Label_RedColor.VisibleChanged += new System.EventHandler(this.Label_RedColor_VisibleChanged);
            // 
            // tbrB
            // 
            this.tbrB.Location = new System.Drawing.Point(1039, 255);
            this.tbrB.Maximum = 100;
            this.tbrB.Name = "tbrB";
            this.tbrB.Size = new System.Drawing.Size(188, 45);
            this.tbrB.TabIndex = 41;
            this.tbrB.Value = 30;
            this.tbrB.Visible = false;
            // 
            // tbrG
            // 
            this.tbrG.Location = new System.Drawing.Point(1039, 216);
            this.tbrG.Maximum = 100;
            this.tbrG.Name = "tbrG";
            this.tbrG.Size = new System.Drawing.Size(188, 45);
            this.tbrG.TabIndex = 40;
            this.tbrG.Value = 59;
            this.tbrG.Visible = false;
            this.tbrG.Scroll += new System.EventHandler(this.tbrG_Scroll);
            // 
            // tbrR
            // 
            this.tbrR.Location = new System.Drawing.Point(1039, 168);
            this.tbrR.Maximum = 100;
            this.tbrR.Name = "tbrR";
            this.tbrR.Size = new System.Drawing.Size(188, 45);
            this.tbrR.TabIndex = 39;
            this.tbrR.Value = 11;
            this.tbrR.Visible = false;
            // 
            // btn_rastagivanie
            // 
            this.btn_rastagivanie.Location = new System.Drawing.Point(889, 200);
            this.btn_rastagivanie.Name = "btn_rastagivanie";
            this.btn_rastagivanie.Size = new System.Drawing.Size(94, 33);
            this.btn_rastagivanie.TabIndex = 45;
            this.btn_rastagivanie.Text = "Растягивание";
            this.btn_rastagivanie.UseVisualStyleBackColor = true;
            this.btn_rastagivanie.Visible = false;
            this.btn_rastagivanie.Click += new System.EventHandler(this.btn_rastagivanie_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1244, 672);
            this.Controls.Add(this.btn_rastagivanie);
            this.Controls.Add(this.Label_BlueColor);
            this.Controls.Add(this.Label_GreenColor);
            this.Controls.Add(this.Label_RedColor);
            this.Controls.Add(this.tbrB);
            this.Controls.Add(this.tbrG);
            this.Controls.Add(this.tbrR);
            this.Controls.Add(this.btn_colorizing);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label_B);
            this.Controls.Add(this.label_G);
            this.Controls.Add(this.label_R);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_FindEye);
            this.Controls.Add(this.Label_value_trackbar);
            this.Controls.Add(this.label_max_trackbar);
            this.Controls.Add(this.label_min_trackbar);
            this.Controls.Add(this.btn_Roberts);
            this.Controls.Add(this.btn_laplas);
            this.Controls.Add(this.btn_Kirch);
            this.Controls.Add(this.btn_Sobel);
            this.Controls.Add(this.chart2);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.ProgressBar);
            this.Controls.Add(this.btn_gistogramm);
            this.Controls.Add(this.trackbar);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.btn_openpicture);
            this.Controls.Add(this.btn_smoothing);
            this.Controls.Add(this.btn_light);
            this.Controls.Add(this.btn_binarization);
            this.Controls.Add(this.btn_negative);
            this.Controls.Add(this.PictureBox_Main);
            this.Controls.Add(this.pictureBox_after);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_Main)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_after)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbrB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbrG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbrR)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.PictureBox PictureBox_Main;
        public System.Windows.Forms.PictureBox pictureBox_after;
        public System.Windows.Forms.ProgressBar ProgressBar;
        private System.Windows.Forms.Button btn_gistogramm;
        private System.Windows.Forms.TrackBar trackbar;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button btn_openpicture;
        private System.Windows.Forms.Button btn_smoothing;
        private System.Windows.Forms.Button btn_light;
        private System.Windows.Forms.Button btn_binarization;
        private System.Windows.Forms.Button btn_negative;
        public System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        public System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.Button btn_Sobel;
        private System.Windows.Forms.Button btn_Kirch;
        private System.Windows.Forms.Button btn_laplas;
        private System.Windows.Forms.Button btn_Roberts;
        private System.Windows.Forms.Label label_min_trackbar;
        private System.Windows.Forms.Label label_max_trackbar;
        private System.Windows.Forms.Label Label_value_trackbar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label label_R;
        public System.Windows.Forms.Label label_G;
        public System.Windows.Forms.Label label_B;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        public System.Windows.Forms.Button btn_FindEye;
        private System.Windows.Forms.Button btn_colorizing;
        private System.Windows.Forms.Label Label_BlueColor;
        private System.Windows.Forms.Label Label_GreenColor;
        private System.Windows.Forms.Label Label_RedColor;
        private System.Windows.Forms.TrackBar tbrB;
        private System.Windows.Forms.TrackBar tbrG;
        private System.Windows.Forms.TrackBar tbrR;
        private System.Windows.Forms.Button btn_rastagivanie;
    }
}

