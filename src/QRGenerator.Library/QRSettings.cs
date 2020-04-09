namespace QRGenerator.Library
{
    public class QRSettings
    {
        public string Data { get; set; }

        public QRSettings()
        {
            this.Data = "https://github.com/JLMin/QRCodeGenerator";
        }

        public QRSettings(string data)
        {
            this.Data = data;
        }
    }
}