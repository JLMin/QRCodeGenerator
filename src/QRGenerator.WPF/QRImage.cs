using QRGenerator.Library;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Media.Imaging;

namespace QRGenerator.WPF
{
    struct ImageSettings
    {
        public int qrSize;
        public int blockSize;
        public Color bgColor;
        public Color qrColor;
        public int[] data;
    }

    public class QRImage
    {
        public static Bitmap CreateBitmap(QRSettings settings)
        {
            // TODO: from settings
            ImageSettings imSettings;
            imSettings.qrSize = 400;
            imSettings.blockSize = 20;
            imSettings.data = RandomData(400);
            // TODO: from gui
            imSettings.bgColor = Color.Gray;
            imSettings.qrColor = Color.Black;

            return FillBitmap(imSettings);
        }

        public static BitmapImage BitmapToImageSource(Bitmap bitmap)
        {
            using MemoryStream memory = new MemoryStream();
            bitmap.Save(memory, ImageFormat.Png);
            memory.Position = 0;
            BitmapImage bitmapimage = new BitmapImage();
            bitmapimage.BeginInit();
            bitmapimage.StreamSource = memory;
            bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
            bitmapimage.EndInit();
            return bitmapimage;
        }

        private static Bitmap FillBitmap(ImageSettings settings)
        {
            int qrSize = settings.qrSize;
            int blockSize = settings.blockSize;
            Color bgColor = settings.bgColor;
            Brush qrColor = new SolidBrush(settings.qrColor);
            Brush white = Brushes.White;
            int[] data = settings.data;

            Bitmap bitmap = new Bitmap(qrSize, qrSize);
            Point p = new Point(0, 0);
            Graphics graphic = Graphics.FromImage(bitmap);
            graphic.Clear(bgColor);

            for (int i = 0; i < data.Length; i++)
            {
                Brush brush = (data[i] == 1) ? qrColor : white;
                Rectangle rect = new Rectangle(p.X, p.Y, blockSize, blockSize);
                graphic.FillRectangle(brush, rect);
                p.X += blockSize;
                if (p.X >= qrSize)
                {
                    p.X = 0;
                    p.Y += blockSize;
                }
            }
            return bitmap;
        }

        private static int[] RandomData(int size)
        {
            Random random = new Random();
            int[] array = new int[size];
            for (int i = 0; i < size; i++)
            {
                array[i] = random.Next(0, 2);
            }
            return array;
        }

    }
}
