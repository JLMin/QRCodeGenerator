using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace QRGenerator.Library.Tests
{
    [TestClass]
    public class QRSettingsTest
    {
        [TestMethod]
        public void Settings_default_data()
        {
            string url = "https://github.com/JLMin/QRCodeGenerator";
            QRSettings settings = new QRSettings();
            Assert.AreEqual(url, settings.Data);
        }

        [DataTestMethod]
        [DataRow("English")]
        [DataRow("中文")]
        [DataRow("http://www.example.com")]
        public void Settings_set_data(string data)
        {
            QRSettings settings = new QRSettings(data);
            Assert.AreEqual(data, settings.Data);
        }
    }
}