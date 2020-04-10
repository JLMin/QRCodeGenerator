using System.Windows;
using System.Drawing;
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
            QRSettings settings = new QRSettings();
            Bitmap bitmap = QRImage.CreateBitmap(settings);
            Img_QR.Source = QRImage.BitmapToImageSource(bitmap);
        }
    }
}
