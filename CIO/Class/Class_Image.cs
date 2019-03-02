using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CIO
{
    public class Class_Image
    {
        #region Public Fields

        public static Bitmap IMAGE;
        public static Color[,] massive_color;
        public static Color[,] massive_color_old;

        #endregion Public Fields

        #region Private Fields

        private int Height;
        private int Widht;

        #endregion Private Fields

        #region Public Constructors

        public Class_Image(Bitmap InputImage)
        {
            this.Widht = InputImage.Width;
            this.Height = InputImage.Height;
            IMAGE = new Bitmap(InputImage);

            massive_color = new Color[IMAGE.Width, IMAGE.Height];
            massive_color_old = new Color[IMAGE.Width, IMAGE.Height];

            for (int i = 0; i < Widht; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    massive_color[i, j] = InputImage.GetPixel(i, j);
                    massive_color_old[i, j] = InputImage.GetPixel(i, j);
                }
            }
        }

        #endregion Public Constructors

        #region Public Properties

        public Image get_image
        {
            get
            {
                return (Bitmap)IMAGE;
            }
        }

        public Bitmap get_bitmap
        {
            get
            {
                return IMAGE;
            }
        }


        public int height
        {
            get
            {
                return this.Height;
            }
            set
            {
                this.Height = value;
            }
        }

        public int widht
        {
            get
            {
                return this.Widht;
            }
            set
            {
                this.Widht = value;
            }
        }

        #endregion Public Properties

        #region Public Methods

        public static Color return_color(int x, int y)
        {
            Color cl = new Color();
            // cl = Color.FromArgb(massive_color_old[x, y].R, massive_color_old[x, y].G,
            // massive_color_old[x, y].B);
            return cl;
        }

        // отображение гистограммы входящего изображения
        public static void show_histogram(Form1 form)
        {
            Bitmap Local_Bitmap = new Bitmap(IMAGE);
            form.chart1.Visible = true;
            form.chart2.Visible = true;

            int[] R = new int[256];
            int[] G = new int[256];
            int[] B = new int[256];
            int[] Histo = new int[256];

            for (int i = 0; i < Local_Bitmap.Width; ++i)
            {
                for (int j = 0; j < Local_Bitmap.Height; ++j)
                {
                    ++R[Local_Bitmap.GetPixel(i, j).R];
                    ++G[Local_Bitmap.GetPixel(i, j).G];
                    ++B[Local_Bitmap.GetPixel(i, j).B];
                    ++Histo[(byte)(0.3 * (double)(Local_Bitmap.GetPixel(i, j).R) + 0.59 * (double)(Local_Bitmap.GetPixel(i, j).B) + 0.11 * (double)(Local_Bitmap.GetPixel(i, j).B))];
                }
            }

            for (int i = 0; i < 255; ++i)
            {
                form.chart1.Series["Before"].Points.AddXY(i, Histo[i]);

                // определение первого максимума на графике
            }

            // определение первого максимума на диаграмме
            int max = 0, max_h = 0;

            for (int i = 0; i < 255; ++i)
            {
                // определение первого максимума на графике
                if ((Math.Abs(max_h - Histo[i]) > 10) && max_h < Histo[i])
                {
                    max_h = Histo[i];
                    max = 1 + i;
                }
                if (max_h > Histo[i])
                {
                    break;
                }
            }
            form.label_G.Text = Convert.ToString(max);
        }

        /* 
        Бинаризация изображения
        */
        public Bitmap binarization(int trackbar_value, Form1 f)
        {
            Bitmap Local_Bitmap = new Bitmap(IMAGE);

            for (int i = 0; i < Local_Bitmap.Width; i++)
            {
                for (int j = 0; j < Local_Bitmap.Height; j++)
                {
                    if (massive_color_old[i, j].R > trackbar_value && massive_color_old[i, j].G > trackbar_value && massive_color_old[i, j].B > trackbar_value)
                    {
                        massive_color[i, j] = Color.FromArgb(255, 255, 255);
                    }
                    else
                    {
                        massive_color[i, j] = Color.FromArgb(0, 0, 0);
                    }
                    Local_Bitmap.SetPixel(i, j, massive_color[i, j]);
                    f.ProgressBar.Value++;
                }
            }
            f.ProgressBar.Value = 0;
            return Local_Bitmap;
        }

        public Bitmap binarization(int trackbar_value)
        {
            Bitmap Local_Bitmap = new Bitmap(IMAGE);

            for (int i = 0; i < Local_Bitmap.Width; i++)
            {
                for (int j = 0; j < Local_Bitmap.Height; j++)
                {
                    if (massive_color_old[i, j].R > trackbar_value && massive_color_old[i, j].G > trackbar_value && massive_color_old[i, j].B > trackbar_value)
                    {
                        massive_color[i, j] = Color.FromArgb(255, 255, 255);
                    }
                    else
                    {
                        massive_color[i, j] = Color.FromArgb(0, 0, 0);
                    }
                    Local_Bitmap.SetPixel(i, j, massive_color[i, j]);
                }
            }
            return Local_Bitmap;
        }

        // псевдораскршивание
        public Bitmap Colorizing(Form1 form)
        {
            Bitmap Local_Bitmap = new Bitmap(IMAGE);

            /*
            Bitmap GrayScale = Local_Bitmap;
            // Loop through the images pixels to reset color.
            for (int x = 0; x < this.Widht; x++)
            {
                for (int y = 0; y < this.Height; y++)
                {
                    Color oc = Local_Bitmap.GetPixel(x, y);
                    int grayScale = (int)((oc.R * 0.3) + (oc.G * 0.59) + (oc.B * 0.11));
                    Color newColor = Color.FromArgb(grayScale, grayScale, grayScale);
                    GrayScale.SetPixel(x, y, newColor); // Now greyscale
                }
            }
            */
            Bitmap main_image = new Bitmap(IMAGE);
            try
            {
                OpenFileDialog OFD = new OpenFileDialog();

                if (OFD.ShowDialog() == DialogResult.OK)
                {
                    main_image = new Bitmap(OFD.FileName);
                }
                else { return Local_Bitmap; }
            }
            catch
            {
            }

            int H = main_image.Height;
            int W = main_image.Width;
            for (int i = 0; i < this.widht; i++)
            {
                for (int j = 0; j < this.height; j++)
                {
                    Color color = new Color();
                    int R = Local_Bitmap.GetPixel(i, j).R;
                    if (R >= 255) R = 254;
                    color = main_image.GetPixel(R, 1);
                    Local_Bitmap.SetPixel(i, j, color);
                    form.ProgressBar.Value++;
                }
            }

            form.ProgressBar.Value = 0;
            show_histogram(form);

            return Local_Bitmap;
        }

        // поиск глаза
        public Bitmap FindEye(Form_eye form)
        {
            Bitmap Local_Bitmap = new Bitmap(IMAGE);

            // составление диаграммы

            int[] Histo = new int[256];
            for (int i = 0; i < Local_Bitmap.Width; ++i)
            {
                for (int j = 0; j < Local_Bitmap.Height; ++j)
                {
                    ++Histo[(byte)(0.3 * (double)(Local_Bitmap.GetPixel(i, j).R) + 0.59 * (double)(Local_Bitmap.GetPixel(i, j).B) + 0.11 * (double)(Local_Bitmap.GetPixel(i, j).B))];
                }
            }

            for (int i = 0; i < 255; ++i)
            {
                // form.chart1.Series["Before"].Points.AddXY(i, Histo[i]);
            }

            // определение первого максимума на диаграмме
            int max = 0, max_h = 0;

            for (int i = 0; i < 255; ++i)
            {
                // определение первого максимума на графике
                if ((Math.Abs(max_h - Histo[i]) > 10) && max_h < Histo[i])
                {
                    max_h = Histo[i];
                    max = 1 + i;
                }
                if (max_h > Histo[i])
                {
                    break;
                }
            }
            //form.label_G.Text = Convert.ToString(max);

            // биниризация отнтсительно первого максимума
            int trackbar_value = max;
            Bitmap binary = new Bitmap(IMAGE);
            for (int i = 0; i < Local_Bitmap.Width; i++)
            {
                for (int j = 0; j < Local_Bitmap.Height; j++)
                {
                    if (massive_color_old[i, j].R > trackbar_value && massive_color_old[i, j].G > trackbar_value && massive_color_old[i, j].B > trackbar_value)
                    {
                        massive_color[i, j] = Color.FromArgb(255, 255, 255);
                    }
                    else
                    {
                        massive_color[i, j] = Color.FromArgb(0, 0, 0);
                    }
                    binary.SetPixel(i, j, massive_color[i, j]);
                }
            }

            /* нахождение зрачка по горизонтали
             * чёрный — (0,0,0)
             * белый — (255,255,255)
            */

            /*

            DataGrid_Form DT = new DataGrid_Form();
            DT.Show();
            DT.dataGridView1.RowCount = findXY.Width;
            DT.dataGridView1.ColumnCount = findXY.Height;
            for (int i = 0; i < findXY.Width; i++)
            {
                for (int j = 0; j < findXY.Height; j++)
                {
                    if (true) {
                        DT.dataGridView1.Rows[i].Cells[j].Value = Convert.ToString(findXY.GetPixel(i, j).R);
                    }
                }
                DT.dataGridView1.Rows[i].HeaderCell.Value = i.ToString();
            }

            */

            int max_colorOfBlack = 0, max_colorOfBlack_count = 0;
            int X = 0; // point of centre eye
            Bitmap findXY = binary;

            // ПОИСК X
            for (int i = 0; i < findXY.Width; i++)
            {
                for (int j = 0; j < findXY.Height; j++)
                {
                    Color cl = binary.GetPixel(i, j);

                    if (cl.R == 0 && cl.G == 0 && cl.B == 0)
                    {
                        max_colorOfBlack_count++;
                    }
                }
                if (max_colorOfBlack < max_colorOfBlack_count)
                {
                    max_colorOfBlack = max_colorOfBlack_count;
                    max_colorOfBlack_count = 0;
                    X = i;
                }
                else
                {
                    max_colorOfBlack_count = 0;
                }
            }

            // ПОИСК Y
            int Y = 0;
            int r = 1;
            int Y_count = 0;
            int r_count = 1;
            for (int J = 5; J < findXY.Height; J++)
            {
                while (binary.GetPixel(X, J + r_count).R == 0 && binary.GetPixel(X, J - r_count).R == 0)
                {
                    r_count++;
                    Y_count = J;
                    if (r_count > r)
                    {
                        Y = Y_count;
                        r = r_count;
                    }
                    if (J + 1 + r_count >= findXY.Height || J + 1 - r_count <= 0)
                    {
                        break;
                    }
                }
                if (J + 1 + r_count >= findXY.Height || J + 1 - r_count <= 0)
                {
                    break;
                }
                r_count = 1;
                //if (binary.GetPixel(X, j).R == 0 && binary.GetPixel(X, j).R == 0)
            }

            //Bitmap Rober = Laplacian3x3Filter();
            Bitmap Rober = binary;

            // Rober = Rober.Sobel3x3Filter();
            Rober = Rober.KirschFilter();
            Graphics g = form.PictureBox_Main.CreateGraphics();
            g.DrawLine(new Pen(Brushes.Red, 1), new Point(0, Y), new Point(findXY.Width, Y));
            g.DrawLine(new Pen(Brushes.Red, 1), new Point(X, 0), new Point(X, findXY.Height));

            int R = 0;
            R = Draw_zrachor(X, Y, binary, form);
            Draw_radujka(X, Y, Rober, form, R);

            return Rober;
        }

        //растягивание гистограммы
        public Bitmap gistogramma(Form1 form)
        {
            form.chart1.Series["Before"].Points.Clear();

            form.chart2.Series["After"].Points.Clear();

            Bitmap Local_Bitmap = new Bitmap(IMAGE);

            int[] R = new int[256];
            int[] G = new int[256];
            int[] B = new int[256];

            int[] newR = new int[256];
            int[] newG = new int[256];
            int[] newB = new int[256];
            int[] Histo = new int[256];

            for (int i = 0; i < Local_Bitmap.Width; ++i)
            {
                for (int j = 0; j < Local_Bitmap.Height; ++j)
                {
                    ++R[Local_Bitmap.GetPixel(i, j).R];
                    ++G[Local_Bitmap.GetPixel(i, j).G];
                    ++B[Local_Bitmap.GetPixel(i, j).B];
                    ++Histo[(byte)(0.3 * (double)(Local_Bitmap.GetPixel(i, j).R) + 0.59 * (double)(Local_Bitmap.GetPixel(i, j).B) + 0.11 * (double)(Local_Bitmap.GetPixel(i, j).B))];
                }
            }

            //Y := 0.3 * R + 0.59 * G + 0.11 * B

            double Ra = 0, Ga = 0, Ba = 0, Rb = 0, Gb = 0, Bb = 0;
            int max_R = 0, max_G = 0, max_B = 0;
            if (!form.Btn_gistogramma) // линейная нормализация
            {
                max_R = find_max(R);
                max_G = find_max(G);
                max_B = find_max(B);
            }

            Rb = 255.0 / (double)(max_R - find_min(R));
            Ra = -Rb * (double)(find_min(R));

            Gb = 255 / (double)(max_G - find_min(G));
            Ga = -Gb * (double)find_min(G);

            Bb = 255 / (double)(max_B - find_min(B));
            Ba = -Bb * (double)find_min(B);

            for (int i = 0; i < 255; ++i)
            {
                newR[i] = (byte)(Ra + Rb * R[i]);
                newG[i] = (byte)(Ga + Gb * G[i]);
                newB[i] = (byte)(Ba + Bb * B[i]);

                form.chart1.Series["Before"].Points.AddXY(i, Histo[i]);
            }

            for (int i = 0; i < Local_Bitmap.Width; ++i)
            {
                for (int j = 0; j < Local_Bitmap.Height; ++j)
                {
                    int R1 = 0, G1 = 0, B1 = 0;

                     R1 = Local_Bitmap.GetPixel(i, j).R;
                     G1 = Local_Bitmap.GetPixel(i, j).G;
                     B1 = Local_Bitmap.GetPixel(i, j).B;

                    if (!form.Btn_gistogramma) // нормализация
                    {
                        R1 = (byte)(Ra + Rb * massive_color_old[i, j].R);
                        G1 = (byte)(Ga + Gb * massive_color_old[i, j].G);
                        B1 = (byte)(Ba + Bb * massive_color_old[i, j].B);
                    }
                    else
                    { // экпонента
                        int value = form.Trackbar_Value;
                        if (R1 + value >= 0 && G1 + value >= 0 && B1 + value >= 0 &&
                            R1 + value <= 255 && G1 + value <= 255 && B1 + value <= 255
                            )
                        {
                            R1 += value;
                            G1 += value;
                            B1 += value;
                        }
                    }

                    massive_color[i, j] = Color.FromArgb(
                        R1,
                        G1,
                        B1);
                    form.ProgressBar.Value++;
                    Local_Bitmap.SetPixel(i, j, massive_color[i, j]);
                }
            }

            for (int i = 0; i < Local_Bitmap.Width; ++i)
            {
                for (int j = 0; j < Local_Bitmap.Height; ++j)
                {
                    ++R[Local_Bitmap.GetPixel(i, j).R];
                    ++G[Local_Bitmap.GetPixel(i, j).G];
                    ++B[Local_Bitmap.GetPixel(i, j).B];
                    ++Histo[(byte)(0.3 * (double)(Local_Bitmap.GetPixel(i, j).R) + 0.59 * (double)(Local_Bitmap.GetPixel(i, j).B) + 0.11 * (double)(Local_Bitmap.GetPixel(i, j).B))];
                }
            }

            for (int i = 0; i < 255; ++i) { form.chart2.Series["After"].Points.AddXY(i, Histo[i]); }
            form.ProgressBar.Value = 0;
            return Local_Bitmap;
        }

        // Кирш
        public Bitmap KirschFilter()
        {
            double[,] xFilterMatrix = Matrix.Kirsch3x3Horizontal;
            double[,] yFilterMatrix = Matrix.Kirsch3x3Vertical;

            bool grayscale = false;

            BitmapData sourceData = IMAGE.LockBits(new Rectangle(0, 0,
                                     IMAGE.Width, IMAGE.Height),
                                                       ImageLockMode.ReadOnly,
                                                  PixelFormat.Format32bppArgb);

            byte[] pixelBuffer = new byte[sourceData.Stride * sourceData.Height];
            byte[] resultBuffer = new byte[sourceData.Stride * sourceData.Height];

            Marshal.Copy(sourceData.Scan0, pixelBuffer, 0, pixelBuffer.Length);
            IMAGE.UnlockBits(sourceData);

            if (grayscale == true)
            {
                float rgb = 0;

                for (int k = 0; k < pixelBuffer.Length; k += 4)
                {
                    rgb = pixelBuffer[k] * 0.11f;
                    rgb += pixelBuffer[k + 1] * 0.59f;
                    rgb += pixelBuffer[k + 2] * 0.3f;

                    pixelBuffer[k] = (byte)rgb;
                    pixelBuffer[k + 1] = pixelBuffer[k];
                    pixelBuffer[k + 2] = pixelBuffer[k];
                    pixelBuffer[k + 3] = 255;
                }
            }

            double blueX = 0.0;
            double greenX = 0.0;
            double redX = 0.0;

            double blueY = 0.0;
            double greenY = 0.0;
            double redY = 0.0;

            double blueTotal = 0.0;
            double greenTotal = 0.0;
            double redTotal = 0.0;

            int filterOffset = 1;
            int calcOffset = 0;

            int byteOffset = 0;

            for (int offsetY = filterOffset; offsetY <
                IMAGE.Height - filterOffset; offsetY++)
            {
                for (int offsetX = filterOffset; offsetX <
                    IMAGE.Width - filterOffset; offsetX++)
                {
                    blueX = greenX = redX = 0;
                    blueY = greenY = redY = 0;

                    blueTotal = greenTotal = redTotal = 0.0;

                    byteOffset = offsetY *
                                 sourceData.Stride +
                                 offsetX * 4;

                    for (int filterY = -filterOffset;
                        filterY <= filterOffset; filterY++)
                    {
                        for (int filterX = -filterOffset;
                            filterX <= filterOffset; filterX++)
                        {
                            calcOffset = byteOffset +
                                         (filterX * 4) +
                                         (filterY * sourceData.Stride);

                            blueX += (double)(pixelBuffer[calcOffset]) *
                                      xFilterMatrix[filterY + filterOffset,
                                              filterX + filterOffset];

                            greenX += (double)(pixelBuffer[calcOffset + 1]) *
                                      xFilterMatrix[filterY + filterOffset,
                                              filterX + filterOffset];

                            redX += (double)(pixelBuffer[calcOffset + 2]) *
                                      xFilterMatrix[filterY + filterOffset,
                                              filterX + filterOffset];

                            blueY += (double)(pixelBuffer[calcOffset]) *
                                      yFilterMatrix[filterY + filterOffset,
                                              filterX + filterOffset];

                            greenY += (double)(pixelBuffer[calcOffset + 1]) *
                                      yFilterMatrix[filterY + filterOffset,
                                              filterX + filterOffset];

                            redY += (double)(pixelBuffer[calcOffset + 2]) *
                                      yFilterMatrix[filterY + filterOffset,
                                              filterX + filterOffset];
                        }
                    }

                    blueTotal = Math.Sqrt((blueX * blueX) + (blueY * blueY));
                    greenTotal = Math.Sqrt((greenX * greenX) + (greenY * greenY));
                    redTotal = Math.Sqrt((redX * redX) + (redY * redY));

                    if (blueTotal > 255)
                    { blueTotal = 255; }
                    else if (blueTotal < 0)
                    { blueTotal = 0; }

                    if (greenTotal > 255)
                    { greenTotal = 255; }
                    else if (greenTotal < 0)
                    { greenTotal = 0; }

                    if (redTotal > 255)
                    { redTotal = 255; }
                    else if (redTotal < 0)
                    { redTotal = 0; }

                    resultBuffer[byteOffset] = (byte)(blueTotal);
                    resultBuffer[byteOffset + 1] = (byte)(greenTotal);
                    resultBuffer[byteOffset + 2] = (byte)(redTotal);
                    resultBuffer[byteOffset + 3] = 255;
                }
            }

            Bitmap resultBitmap = new Bitmap(IMAGE.Width, IMAGE.Height);

            BitmapData resultData = resultBitmap.LockBits(new Rectangle(0, 0,
                                     resultBitmap.Width, resultBitmap.Height),
                                                      ImageLockMode.WriteOnly,
                                                  PixelFormat.Format32bppArgb);

            Marshal.Copy(resultBuffer, 0, resultData.Scan0, resultBuffer.Length);
            resultBitmap.UnlockBits(resultData);

            return resultBitmap;
        }

        // Лаплас
        public Bitmap Laplacian3x3Filter()
        {
            //double[,] xFilterMatrix = Matrix.Kirsch3x3Horizontal;
            //double[,] yFilterMatrix = Matrix.Kirsch3x3Vertical;
            double[,] filterMatrix = Matrix.Laplacian3x3;
            //double[,] filterMatrix = Matrix.Gaussian5x5Type3;
            double factor = 1;
            int bias = 0;
            bool grayscale = false;

            BitmapData sourceData = IMAGE.LockBits
                (
                new Rectangle(0, 0, IMAGE.Width, IMAGE.Height),
                ImageLockMode.ReadOnly,
                PixelFormat.Format32bppArgb
                );

            byte[] pixelBuffer = new byte[sourceData.Stride * sourceData.Height];
            byte[] resultBuffer = new byte[sourceData.Stride * sourceData.Height];

            Marshal.Copy(sourceData.Scan0, pixelBuffer, 0, pixelBuffer.Length);
            IMAGE.UnlockBits(sourceData);

            if (grayscale == true)
            {
                float rgb = 0;

                for (int k = 0; k < pixelBuffer.Length; k += 4)
                {
                    rgb = pixelBuffer[k] * 0.11f;
                    rgb += pixelBuffer[k + 1] * 0.59f;
                    rgb += pixelBuffer[k + 2] * 0.3f;

                    pixelBuffer[k] = (byte)rgb;
                    pixelBuffer[k + 1] = pixelBuffer[k];
                    pixelBuffer[k + 2] = pixelBuffer[k];
                    pixelBuffer[k + 3] = 255;
                }
            }

            double blue = 0.0;
            double green = 0.0;
            double red = 0.0;

            int filterWidth = filterMatrix.GetLength(1);
            int filterHeight = filterMatrix.GetLength(0);

            int filterOffset = (filterWidth - 1) / 2;
            int calcOffset = 0;

            int byteOffset = 0;

            for (int offsetY = filterOffset; offsetY <
                IMAGE.Height - filterOffset; offsetY++)
            {
                for (int offsetX = filterOffset; offsetX <
                    IMAGE.Width - filterOffset; offsetX++)
                {
                    blue = 0;
                    green = 0;
                    red = 0;

                    byteOffset = offsetY *
                                 sourceData.Stride +
                                 offsetX * 4;

                    for (int filterY = -filterOffset;
                        filterY <= filterOffset; filterY++)
                    {
                        for (int filterX = -filterOffset;
                            filterX <= filterOffset; filterX++)
                        {
                            calcOffset = byteOffset +
                                         (filterX * 4) +
                                         (filterY * sourceData.Stride);

                            blue += (double)(pixelBuffer[calcOffset]) *
                                    filterMatrix[filterY + filterOffset,
                                                        filterX + filterOffset];

                            green += (double)(pixelBuffer[calcOffset + 1]) *
                                     filterMatrix[filterY + filterOffset,
                                                        filterX + filterOffset];

                            red += (double)(pixelBuffer[calcOffset + 2]) *
                                   filterMatrix[filterY + filterOffset,
                                                      filterX + filterOffset];
                        }
                    }

                    blue = factor * blue + bias;
                    green = factor * green + bias;
                    red = factor * red + bias;

                    if (blue > 255)
                    { blue = 255; }
                    else if (blue < 0)
                    { blue = 0; }

                    if (green > 255)
                    { green = 255; }
                    else if (green < 0)
                    { green = 0; }

                    if (red > 255)
                    { red = 255; }
                    else if (red < 0)
                    { red = 0; }

                    resultBuffer[byteOffset] = (byte)(blue);
                    resultBuffer[byteOffset + 1] = (byte)(green);
                    resultBuffer[byteOffset + 2] = (byte)(red);
                    resultBuffer[byteOffset + 3] = 255;
                }
            }

            Bitmap resultBitmap = new Bitmap(IMAGE.Width, IMAGE.Height);

            BitmapData resultData = resultBitmap.LockBits(new Rectangle(0, 0,
                                     resultBitmap.Width, resultBitmap.Height),
                                                      ImageLockMode.WriteOnly,
                                                 PixelFormat.Format32bppArgb);

            Marshal.Copy(resultBuffer, 0, resultData.Scan0, resultBuffer.Length);
            resultBitmap.UnlockBits(resultData);

            return resultBitmap;
        }

        public  Bitmap Gaussuian5x5Filter()
        {
            double[,] filterMatrix = Matrix.Gaussian5x5Type3;
            double factor = 1;
            int bias = 1;
            Bitmap sourceBitmap = IMAGE;
            BitmapData sourceData = sourceBitmap.LockBits(new Rectangle(0, 0,
                                    sourceBitmap.Width, sourceBitmap.Height),
                                                      ImageLockMode.ReadOnly,
                                                PixelFormat.Format32bppArgb);


            byte[] pixelBuffer = new byte[sourceData.Stride * sourceData.Height];
            byte[] resultBuffer = new byte[sourceData.Stride * sourceData.Height];


            Marshal.Copy(sourceData.Scan0, pixelBuffer, 0, pixelBuffer.Length);
            sourceBitmap.UnlockBits(sourceData);


            double blue = 0.0;
            double green = 0.0;
            double red = 0.0;


            int filterWidth = filterMatrix.GetLength(1);
            int filterHeight = filterMatrix.GetLength(0);


            int filterOffset = (filterWidth - 1) / 2;
            int calcOffset = 0;


            int byteOffset = 0;


            for (int offsetY = filterOffset; offsetY <
                sourceBitmap.Height - filterOffset; offsetY++)
            {
                for (int offsetX = filterOffset; offsetX <
                    sourceBitmap.Width - filterOffset; offsetX++)
                {
                    blue = 0;
                    green = 0;
                    red = 0;


                    byteOffset = offsetY *
                                 sourceData.Stride +
                                 offsetX * 4;


                    for (int filterY = -filterOffset;
                        filterY <= filterOffset; filterY++)
                    {
                        for (int filterX = -filterOffset;
                            filterX <= filterOffset; filterX++)
                        {


                            calcOffset = byteOffset +
                                         (filterX * 4) +
                                         (filterY * sourceData.Stride);


                            blue += (double)(pixelBuffer[calcOffset]) *
                                    filterMatrix[filterY + filterOffset,
                                                        filterX + filterOffset];


                            green += (double)(pixelBuffer[calcOffset + 1]) *
                                     filterMatrix[filterY + filterOffset,
                                                        filterX + filterOffset];


                            red += (double)(pixelBuffer[calcOffset + 2]) *
                                   filterMatrix[filterY + filterOffset,
                                                      filterX + filterOffset];
                        }
                    }

                    blue = factor * blue + bias;
                    green = factor * green + bias;
                    red = factor * red + bias;

                    if (blue > 255)
                    { blue = 255; }
                    else if (blue < 0)
                    { blue = 0; }

                    if (green > 255)
                    { green = 255; }
                    else if (green < 0)
                    { green = 0; }

                    if (red > 255)
                    { red = 255; }
                    else if (red < 0)
                    { red = 0; }

                    resultBuffer[byteOffset] = (byte)(blue);
                    resultBuffer[byteOffset + 1] = (byte)(green);
                    resultBuffer[byteOffset + 2] = (byte)(red);
                    resultBuffer[byteOffset + 3] = 255;
                }
            }


            Bitmap resultBitmap = new Bitmap(sourceBitmap.Width, sourceBitmap.Height);


            BitmapData resultData = resultBitmap.LockBits(new Rectangle(0, 0,
                                     resultBitmap.Width, resultBitmap.Height),
                                                      ImageLockMode.WriteOnly,
                                                 PixelFormat.Format32bppArgb);


            Marshal.Copy(resultBuffer, 0, resultData.Scan0, resultBuffer.Length);
            resultBitmap.UnlockBits(resultData);


            return resultBitmap;
        }



        // Бинаризация изображения
        public Bitmap lighting(int trackbar_value, Form1 form)
        {
            Bitmap Local_Bitmap = new Bitmap(IMAGE);

            /*
            * 255 - 100%
            *   1 - 0 %
            */

            double trackbar_value1 = trackbar_value;
            trackbar_value1 = trackbar_value1 * (100.0 / 255.0);

            for (int i = 0; i < Local_Bitmap.Width; i++)
            {
                for (int j = 0; j < Local_Bitmap.Height; j++)
                {
                    if (massive_color_old[i, j].R + (byte)(trackbar_value1 * 128.0 / 100.0) > 255)
                    {
                        massive_color[i, j] = Color.FromArgb(
                             255,
                            massive_color_old[i, j].G,
                            massive_color_old[i, j].B);
                    }
                    if (massive_color_old[i, j].G + (byte)(trackbar_value1 * 128.0 / 100.0) > 255)
                    {
                        massive_color[i, j] = Color.FromArgb(
                            massive_color_old[i, j].R,
                            255,
                            massive_color_old[i, j].B);
                    }
                    if (massive_color_old[i, j].B + (byte)(trackbar_value1 * 128.0 / 100.0) > 255)
                    {
                        massive_color[i, j] = Color.FromArgb(
                            massive_color_old[i, j].G,
                            massive_color_old[i, j].G,
                            255);
                    }
                    if (
                        massive_color_old[i, j].R + (byte)(trackbar_value1 * 128.0 / 100.0) < 255 &&
                        massive_color_old[i, j].G + (byte)(trackbar_value1 * 128.0 / 100.0) < 255 &&
                        massive_color_old[i, j].B + (byte)(trackbar_value1 * 128.0 / 100.0) < 255)
                    {
                        massive_color[i, j] = Color.FromArgb(
                         massive_color_old[i, j].R + (byte)(trackbar_value1 * 128.0 / 100.0),
                        massive_color_old[i, j].G + (byte)(trackbar_value1 * 128.0 / 100.0),
                        massive_color_old[i, j].B + (byte)(trackbar_value1 * 128.0 / 100.0));
                    }
                    Local_Bitmap.SetPixel(i, j, massive_color[i, j]);
                    //ProgressBar_Value(i, j);
                    form.ProgressBar.Value++;
                }
            }//I = I + N • 128 / 100 (1)
            form.ProgressBar.Value = 0;
            return Local_Bitmap;
        }

        // Негатив изображения
        public Bitmap Negative()
        {
            Bitmap Local_Bitmap = new Bitmap(IMAGE);

            for (int i = 0; i < Local_Bitmap.Width; i++)
            {
                for (int j = 0; j < Local_Bitmap.Height; j++)
                {
                    massive_color[i, j] = Color.FromArgb(255 - massive_color_old[i, j].R, 255 - massive_color_old[i, j].G, 255 - massive_color_old[i, j].B);
                    Local_Bitmap.SetPixel(i, j, massive_color[i, j]);
                    //Laboratory_1.Form1.ProgressBar_Value(i, j);
                }
            }
            return Local_Bitmap;
        }

        // Робертс
        public Bitmap RobertsFilter()
        {
            double[,] xFilterMatrix = Matrix.Roberts2x2Horizontal;
            double[,] yFilterMatrix = Matrix.Roberts2x2Vertical;
            bool grayscale = true;

            BitmapData sourceData = IMAGE.LockBits(new Rectangle(0, 0,
                                     IMAGE.Width, IMAGE.Height),
                                                       ImageLockMode.ReadOnly,
                                                  PixelFormat.Format32bppArgb);

            byte[] pixelBuffer = new byte[sourceData.Stride * sourceData.Height];
            byte[] resultBuffer = new byte[sourceData.Stride * sourceData.Height];

            Marshal.Copy(sourceData.Scan0, pixelBuffer, 0, pixelBuffer.Length);
            IMAGE.UnlockBits(sourceData);

            if (grayscale == true)
            {
                float rgb = 0;

                for (int k = 0; k < pixelBuffer.Length; k += 4)
                {
                    rgb = pixelBuffer[k] * 0.11f;
                    rgb += pixelBuffer[k + 1] * 0.59f;
                    rgb += pixelBuffer[k + 2] * 0.3f;

                    pixelBuffer[k] = (byte)rgb;
                    pixelBuffer[k + 1] = pixelBuffer[k];
                    pixelBuffer[k + 2] = pixelBuffer[k];
                    pixelBuffer[k + 3] = 255;
                }
            }

            double blueX = 0.0;
            double greenX = 0.0;
            double redX = 0.0;

            double blueY = 0.0;
            double greenY = 0.0;
            double redY = 0.0;

            double blueTotal = 0.0;
            double greenTotal = 0.0;
            double redTotal = 0.0;

            int filterOffset = 1;
            int calcOffset = 0;

            int byteOffset = 0;

            for (int offsetY = filterOffset; offsetY < IMAGE.Height - filterOffset; offsetY++)
            {
                for (int offsetX = filterOffset; offsetX < IMAGE.Width - filterOffset; offsetX++)
                {
                    blueX = greenX = redX = 0;
                    blueY = greenY = redY = 0;

                    blueTotal = greenTotal = redTotal = 0.0;

                    byteOffset = offsetY *
                                 sourceData.Stride +
                                 offsetX * 4;

                    for (int filterY = -filterOffset; filterY <= filterOffset; filterY++)
                    {
                        for (int filterX = -filterOffset; filterX <= filterOffset; filterX++)
                        {
                            calcOffset = byteOffset + (filterX * 4) + (filterY * sourceData.Stride);

                            blueX += (double)(pixelBuffer[calcOffset]) * xFilterMatrix[filterY + filterOffset, filterX + filterOffset];

                            greenX += (double)(pixelBuffer[calcOffset + 1]) * xFilterMatrix[filterY + filterOffset, filterX + filterOffset];

                            redX += (double)(pixelBuffer[calcOffset + 2]) * xFilterMatrix[filterY + filterOffset, filterX + filterOffset];

                            blueY += (double)(pixelBuffer[calcOffset]) * yFilterMatrix[filterY + filterOffset, filterX + filterOffset];

                            greenY += (double)(pixelBuffer[calcOffset + 1]) * yFilterMatrix[filterY + filterOffset, filterX + filterOffset];

                            redY += (double)(pixelBuffer[calcOffset + 2]) * yFilterMatrix[filterY + filterOffset, filterX + filterOffset];
                        }
                    }

                    blueTotal = Math.Sqrt((blueX * blueX) + (blueY * blueY));
                    greenTotal = Math.Sqrt((greenX * greenX) + (greenY * greenY));
                    redTotal = Math.Sqrt((redX * redX) + (redY * redY));

                    if (blueTotal > 255)
                    { blueTotal = 255; }
                    else if (blueTotal < 0)
                    { blueTotal = 0; }

                    if (greenTotal > 255)
                    { greenTotal = 255; }
                    else if (greenTotal < 0)
                    { greenTotal = 0; }

                    if (redTotal > 255)
                    { redTotal = 255; }
                    else if (redTotal < 0)
                    { redTotal = 0; }

                    resultBuffer[byteOffset] = (byte)(blueTotal);
                    resultBuffer[byteOffset + 1] = (byte)(greenTotal);
                    resultBuffer[byteOffset + 2] = (byte)(redTotal);
                    resultBuffer[byteOffset + 3] = 255;
                }
            }

            Bitmap resultBitmap = new Bitmap(IMAGE.Width, IMAGE.Height);

            BitmapData resultData = resultBitmap.LockBits(new Rectangle(0, 0,
                                     resultBitmap.Width, resultBitmap.Height),
                                                      ImageLockMode.WriteOnly,
                                                  PixelFormat.Format32bppArgb);

            Marshal.Copy(resultBuffer, 0, resultData.Scan0, resultBuffer.Length);
            resultBitmap.UnlockBits(resultData);

            return resultBitmap;
        }

        // сглажевание
        public Bitmap smoothing(int power_smoothing, Form1 form)
        {
            Bitmap Local_Bitmap = new Bitmap(IMAGE);

            int kernelWidth = Matrix.Karnel.GetLength(0);
            int kernelHeight = Matrix.Karnel.GetLength(1);
            form.ProgressBar.Maximum *= power_smoothing;

            Color[,] massive_color_new;
            massive_color_new = new Color[IMAGE.Width, IMAGE.Height];
            massive_color_new = massive_color_old;

            for (int k = 0; k < power_smoothing; k++)
            {
                for (int i = 0; i < Local_Bitmap.Width; i++)
                {
                    for (int j = 0; j < Local_Bitmap.Height; j++)
                    {
                        massive_color[i, j] = Mid_color(massive_color_new, i, j, Matrix.Karnel);
                        Local_Bitmap.SetPixel(i, j, massive_color[i, j]);
                        form.ProgressBar.Value++;
                    }
                }
                massive_color_new = massive_color;
            }
            form.ProgressBar.Value = 0;
            return Local_Bitmap;
        }

        // собель
        public Bitmap Sobel3x3Filter()
        {
            double[,] xFilterMatrix = Matrix.Sobel3x3Horizontal;
            double[,] yFilterMatrix = Matrix.Sobel3x3Vertical;
            bool grayscale = false;

            BitmapData sourceData = IMAGE.LockBits(new Rectangle(0, 0,
                                     IMAGE.Width, IMAGE.Height),
                                                       ImageLockMode.ReadOnly,
                                                  PixelFormat.Format32bppArgb);

            byte[] pixelBuffer = new byte[sourceData.Stride * sourceData.Height];
            byte[] resultBuffer = new byte[sourceData.Stride * sourceData.Height];

            Marshal.Copy(sourceData.Scan0, pixelBuffer, 0, pixelBuffer.Length);
            IMAGE.UnlockBits(sourceData);

            if (grayscale == true)
            {
                float rgb = 0;

                for (int k = 0; k < pixelBuffer.Length; k += 4)
                {
                    rgb = pixelBuffer[k] * 0.11f;
                    rgb += pixelBuffer[k + 1] * 0.59f;
                    rgb += pixelBuffer[k + 2] * 0.3f;

                    pixelBuffer[k] = (byte)rgb;
                    pixelBuffer[k + 1] = pixelBuffer[k];
                    pixelBuffer[k + 2] = pixelBuffer[k];
                    pixelBuffer[k + 3] = 255;
                }
            }

            double blueX = 0.0;
            double greenX = 0.0;
            double redX = 0.0;

            double blueY = 0.0;
            double greenY = 0.0;
            double redY = 0.0;

            double blueTotal = 0.0;
            double greenTotal = 0.0;
            double redTotal = 0.0;

            int filterOffset = 1;
            int calcOffset = 0;

            int byteOffset = 0;

            for (int offsetY = filterOffset; offsetY <
                IMAGE.Height - filterOffset; offsetY++)
            {
                for (int offsetX = filterOffset; offsetX <
                    IMAGE.Width - filterOffset; offsetX++)
                {
                    blueX = greenX = redX = 0;
                    blueY = greenY = redY = 0;

                    blueTotal = greenTotal = redTotal = 0.0;

                    byteOffset = offsetY *
                                 sourceData.Stride +
                                 offsetX * 4;

                    for (int filterY = -filterOffset;
                        filterY <= filterOffset; filterY++)
                    {
                        for (int filterX = -filterOffset;
                            filterX <= filterOffset; filterX++)
                        {
                            calcOffset = byteOffset +
                                         (filterX * 4) +
                                         (filterY * sourceData.Stride);

                            blueX += (double)(pixelBuffer[calcOffset]) *
                                      xFilterMatrix[filterY + filterOffset,
                                              filterX + filterOffset];

                            greenX += (double)(pixelBuffer[calcOffset + 1]) *
                                      xFilterMatrix[filterY + filterOffset,
                                              filterX + filterOffset];

                            redX += (double)(pixelBuffer[calcOffset + 2]) *
                                      xFilterMatrix[filterY + filterOffset,
                                              filterX + filterOffset];

                            blueY += (double)(pixelBuffer[calcOffset]) *
                                      yFilterMatrix[filterY + filterOffset,
                                              filterX + filterOffset];

                            greenY += (double)(pixelBuffer[calcOffset + 1]) *
                                      yFilterMatrix[filterY + filterOffset,
                                              filterX + filterOffset];

                            redY += (double)(pixelBuffer[calcOffset + 2]) *
                                      yFilterMatrix[filterY + filterOffset,
                                              filterX + filterOffset];
                        }
                    }

                    blueTotal = Math.Sqrt((blueX * blueX) + (blueY * blueY));
                    greenTotal = Math.Sqrt((greenX * greenX) + (greenY * greenY));
                    redTotal = Math.Sqrt((redX * redX) + (redY * redY));

                    if (blueTotal > 255)
                    { blueTotal = 255; }
                    else if (blueTotal < 0)
                    { blueTotal = 0; }

                    if (greenTotal > 255)
                    { greenTotal = 255; }
                    else if (greenTotal < 0)
                    { greenTotal = 0; }

                    if (redTotal > 255)
                    { redTotal = 255; }
                    else if (redTotal < 0)
                    { redTotal = 0; }

                    resultBuffer[byteOffset] = (byte)(blueTotal);
                    resultBuffer[byteOffset + 1] = (byte)(greenTotal);
                    resultBuffer[byteOffset + 2] = (byte)(redTotal);
                    resultBuffer[byteOffset + 3] = 255;
                }
            }

            Bitmap resultBitmap = new Bitmap(IMAGE.Width, IMAGE.Height);

            BitmapData resultData = resultBitmap.LockBits(new Rectangle(0, 0,
                                     resultBitmap.Width, resultBitmap.Height),
                                                      ImageLockMode.WriteOnly,
                                                  PixelFormat.Format32bppArgb);

            Marshal.Copy(resultBuffer, 0, resultData.Scan0, resultBuffer.Length);
            resultBitmap.UnlockBits(resultData);

            return resultBitmap;
        }

        #endregion Public Methods

        #region Private Methods

        private void Draw_radujka(int X0, int Y0, Bitmap binary, Form_eye form, int R)
        {
            Graphics g = form.PictureBox_Main.CreateGraphics();
            int radius = R + 20;
            int radius_max = 0;
            int r_count = R;
            int count_pixel = 0;
            int pixel_max = 0;

            while (X0 + radius < this.Widht && X0 - radius > 0)
            {
                int x1 = X0 + radius;
                int x2 = X0 - radius;
                for (int y = 0; y < this.height; y++)
                {
                    if (
                           binary.GetPixel(x1, y).R == 255
                        && binary.GetPixel(x1, y).G == 255
                        && binary.GetPixel(x1, y).B == 255)
                        count_pixel++;

                    if (
                           binary.GetPixel(x2, y).R == 255
                        && binary.GetPixel(x2, y).G == 255
                        && binary.GetPixel(x2, y).B == 255)
                        count_pixel++;
                }

                if (count_pixel > pixel_max)
                {
                    radius_max = radius;
                    pixel_max = count_pixel;
                }

                radius++;
                count_pixel = 0;
            }

            /*
             * // алгоритм ХАФА
            while(X0 + radius < this.Widht && X0 - radius > 0  )
            {
                for (int i = X0 - radius; i < X0 + radius; i++)
                {
                    int j = (int)(Math.Sqrt(Math.Pow(radius,2) - Math.Pow(i-X0,2)) + Y0);
                    int x = i;
                    int y = j;

                    if (y >= this.height) break;

                    if (binary.GetPixel(x, y).R == 255
                        && binary.GetPixel(x, y).G == 255
                        && binary.GetPixel(x, y).B == 255) count_pixel++;

                    if (binary.GetPixel(x, Y0 + Math.Abs(y - Y0)).R == 255
                        && binary.GetPixel(x, Y0 + Math.Abs(y - Y0)).G == 255
                        && binary.GetPixel(x, Y0 + Math.Abs(y - Y0)).B == 255) count_pixel++;
                }

                if (count_pixel > pixel_max)
                {
                    radius_max = radius;
                    pixel_max = count_pixel;
                }

                radius++;
                count_pixel = 0;
            }
            */

            /*
            while (
                (binary.GetPixel(X0 + r_count, Y0).R + binary.GetPixel(X0 + r_count, Y0).G + binary.GetPixel(X0 + r_count, Y0).B) != 765
                &&
                (binary.GetPixel(X0 - r_count, Y0).R +binary.GetPixel(X0 - r_count, Y0).G + binary.GetPixel(X0 - r_count, Y0).B) != 765
                ){
                r_count--;
                if (r_count < radius)
                {
                    radius = r_count;
                }
            }*/
            //radius_max = 90;
            g.DrawEllipse(new Pen(Brushes.BlueViolet, 5), X0 - radius_max, Y0 - radius_max, 2 * radius_max, 2 * radius_max);
        }

        private int Draw_zrachor(int X0, int Y0, Bitmap binary, Form_eye form)
        {
            Graphics g = form.PictureBox_Main.CreateGraphics();
            int radius = 1;
            int r_count = 1;
            while (binary.GetPixel(X0, Y0 + r_count).R == 0 && binary.GetPixel(X0, Y0 - r_count).R == 0)
            {
                r_count++;
                if (r_count > radius)
                {
                    radius = r_count;
                }
            }
            g.DrawEllipse(new Pen(Brushes.GreenYellow, 2), X0 - radius, Y0 - radius, 2 * radius, 2 * radius);

            return radius;
        }

        // Максимальная яркость
        private int find_max(int[] massive)
        {
            int max = 0;
            for (int i = 0; i < massive.Length; ++i)
            {
                if (massive[i] > (int)((double)(find_max_pixel(massive)) / 100.0)) max = i;
            }
            return max;
        }

        // нахождение максимального количества пиксель на яркость
        private int find_max_pixel(int[] massive)
        {
            int max = 0;
            for (int i = 0; i < massive.Length; ++i)
            {
                if (massive[i] > max) max = massive[i];
            }
            return max;
        }

        //Минимальная яркость
        private int find_min(int[] massive)
        {
            int min = 255;
            for (int i = 0; i < massive.Length; ++i)
            {
                if (massive[i] > (int)((double)(find_max_pixel(massive)) / 100.0))
                    return i;
                if (massive[i] < (int)((double)(find_max_pixel(massive)) / 100.0) && i < find_max(massive)) min = i;
            }
            return min;
        }

        // нахождение минимального количества пиксель на яркость
        private int find_min_pixel(int[] massive)
        {
            int max = find_max_pixel(massive);
            for (int i = 0; i < massive.Length; ++i)
            {
                if (massive[i] < max) max = massive[i];
            }
            return max;
        }

        // средняя яркость
        private Color Mid_color(Color[,] massive_color_old, int i, int j, double[,] karnel)
        {
            int kernelWidth = karnel.GetLength(0);
            int kernelHeight = karnel.GetLength(1);

            double redSum = 0, greenSum = 0, blueSum = 0, kSum = 0;

            for (int x = 0; x < kernelWidth; x++)
            {
                for (int y = 0; y < kernelHeight; y++)
                {
                    int pixelPosX = i + (x - (kernelWidth / 2));
                    int pixelPosY = j + (y - (kernelHeight / 2));
                    if ((pixelPosX < 0) || (pixelPosX >= IMAGE.Width) || (pixelPosY < 0) || (pixelPosY >= IMAGE.Height)) continue;

                    redSum += massive_color_old[pixelPosX, pixelPosY].R * karnel[x, y];
                    greenSum += massive_color_old[pixelPosX, pixelPosY].G * karnel[x, y];
                    blueSum += massive_color_old[pixelPosX, pixelPosY].B * karnel[x, y];

                    kSum = karnel[x, y];

                    if (kSum <= 0) kSum = 1;
                    /*
                    //Контролируем переполнения переменных
                    redSum /= kSum;
                    if (redSum < 0) redSum = 0;
                    if (redSum > 255) redSum = 255;

                    greenSum /= kSum;
                    if (greenSum < 0) greenSum = 0;
                    if (greenSum > 255) greenSum = 255;

                    blueSum /= kSum;
                    if (blueSum < 0) blueSum = 0;
                    if (blueSum > 255) blueSum = 255;
                      */
                }
            }

            double kof = 9;
            redSum = redSum / kof;
            greenSum = greenSum / kof;
            blueSum = blueSum / kof;

            return Color.FromArgb((byte)redSum, (byte)greenSum, (byte)blueSum);
        }

        #endregion Private Methods
    }
}