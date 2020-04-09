using QRGenerator.Library;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Media.Imaging;

namespace QRGenerator.WPF
{
    public class QRImage
    {
        public static Bitmap CreateBitmap(QRSettings settings)
        {
            // TODO: from settings
            int qr_size = 400;
            int block_size = 20;
            Color bgcolor = Color.Gray;
            Brush black = Brushes.Black;
            Brush white = Brushes.White;

            Bitmap bitmap = new Bitmap(qr_size, qr_size);
            Point p = new Point(0, 0);
            using Graphics graphic = Graphics.FromImage(bitmap);
            graphic.Clear(bgcolor);

            int[] data = RandomData((int)Math.Pow(qr_size / block_size, 2));

            for (int i = 0; i < data.Length; i++)
            {
                Brush brush = (data[i] == 1) ? black : white;
                Rectangle rect = new Rectangle(p.X, p.Y, block_size, block_size);
                graphic.FillRectangle(brush, rect);
                p.X += block_size;
                if (p.X >= qr_size)
                {
                    p.X = 0;
                    p.Y += block_size;
                }
            }
            return bitmap;
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
