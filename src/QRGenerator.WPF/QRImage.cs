using QRGenerator.Library;
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
            Bitmap bitmap = new Bitmap(400, 400);
            Point p = new Point(0, 0);
            using Graphics graphic = Graphics.FromImage(bitmap);
            graphic.Clear(Color.Gray);

            int[] data = { 1, 0, 1, 0, 1, 0, 1, 0 };

            for (int i = 0; i < data.Length; i++)
            {
                Brush brush = (data[i] == 1) ? Brushes.Black : Brushes.White;
                Rectangle rect = new Rectangle(p.X, p.Y, 20, 20);
                graphic.FillRectangle(brush, rect);
                if (p.X > 400)
                {
                    p.X = 0;
                    p.Y += 20;
                }
                else
                {
                    p.X += 20;
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
    }
}
