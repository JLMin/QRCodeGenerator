using System.Windows;
using System.Drawing;
using System.IO;
using System.Windows.Media.Imaging;
using QRGenerator.Library;

namespace QRGenerator.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Btn_Generate_Click(object sender, RoutedEventArgs e)
        {
            //first, create a dummy bitmap just to get a graphics object
            //using Image bitmap = new Bitmap(1, 1);
            //using Graphics drawing = Graphics.FromImage(bitmap);
            //drawing.Clear(Color.Red);
            //drawing.Save();

            //using MemoryStream memory = new MemoryStream();
            //bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
            //memory.Position = 0;
            //BitmapImage bitmapimage = new BitmapImage();
            //bitmapimage.BeginInit();
            //bitmapimage.StreamSource = memory;
            //bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
            //bitmapimage.EndInit();
            QRSettings settings = new QRSettings();
            Bitmap bitmap = QRImage.CreateBitmap(settings);
            Img_QR.Source = QRImage.BitmapToImageSource(bitmap);
        }
    }
}
