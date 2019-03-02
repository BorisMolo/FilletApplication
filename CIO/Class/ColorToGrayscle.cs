using System;
using System.Drawing;

namespace CIO
{
    public class ColorToGrayscle
    {
        #region Private Fields

        private double kB = 0.30;
        private double kG = 0.59;
        private double kR = 0.11;

        private Bitmap sourceBitmap;

        #endregion Private Fields

        #region Public Constructors

        public ColorToGrayscle(Bitmap source)
        {
            this.sourceBitmap = source;
        }

        public ColorToGrayscle(Bitmap source, double kr, double kg, double kb)
        {
            this.sourceBitmap = source;
            this.kR = kr;
            this.kG = kg;
            this.kB = kb;
        }

        #endregion Public Constructors

        #region Public Properties

        public double KB
        {
            get { return kB; }
            set { kB = value; }
        }

        public double KG
        {
            get { return kG; }
            set { kG = value; }
        }

        public double KR
        {
            get { return kR; }
            set { kR = value; }
        }

        #endregion Public Properties

        #region Public Methods

        public Bitmap GetGrayscale()
        {
            Bitmap resultBitmap = new Bitmap(sourceBitmap.Width, sourceBitmap.Height);
            for (int i = 0; i < sourceBitmap.Width; i++)
            {
                for (int j = 0; j < sourceBitmap.Height; j++)
                {
                    Color c = sourceBitmap.GetPixel(i, j);
                    double gray = kG * c.G + kR * c.R + kB * c.B;
                    if (gray > 255)
                    {
                        gray = 255;
                    }
                    int intGray = Convert.ToInt16(gray);
                    resultBitmap.SetPixel(i, j, Color.FromArgb(intGray, intGray, intGray));
                }
            }

            return resultBitmap;
        }

        #endregion Public Methods
    }
}