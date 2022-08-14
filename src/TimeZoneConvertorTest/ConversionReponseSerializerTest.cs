using System.Text;
using System.Xml;
using TimeZoneConvertor;

namespace TimeZoneConvertorTest
{
    [TestClass]
    public class ConversionReponseSerializerTest
    {
        private readonly TimeZoneConversionResponseSerializer _serializer = new();

        [TestMethod]
        public void WriteObject()
        {
            string expected = "<?xml version=\"1.0\" encoding=\"utf-8\"?><TimeZoneConversionResponse xmlns:i=\"http://www.w3.org/2001/XMLSchema-instance\"><ToDateTime>2022-07-31T13:01:41.64+02:00</ToDateTime></TimeZoneConversionResponse>";

            //Arrange
            var response = new TimeZoneConversionResponse()
            {
                ToDateTimeOffset = new DateTimeOffset(2022, 07, 31, 13, 01, 41, 640, TimeSpan.FromHours(2))
            };

            using MemoryStream stream = new();
            using XmlDictionaryWriter writer = XmlDictionaryWriter.CreateTextWriter(stream, Encoding.UTF8, false /*ownsStream*/);

            //Act
            _serializer.WriteObject(writer, response);

            //Assert
            StreamReader reader = new (stream);
            stream.Seek(0, SeekOrigin.Begin);
            string actual = reader.ReadToEnd();
            
            Assert.AreEqual(new DateTime(2022, 07, 31, 11, 01, 41, 640, DateTimeKind.Utc), response.ToDateTime);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ReadObject()
        {
            string message = "<TimeZoneConversionResponse xmlns:i=\"http://www.w3.org/2001/XMLSchema-instance\"><ToDateTime>2022-07-31T13:01:41.64+02:00</ToDateTime></TimeZoneConversionResponse>";

            using var reader = new StringReader(message);
            using var xmlReader = XmlReader.Create(reader);

            var response = _serializer.ReadObject(xmlReader, false) as TimeZoneConversionResponse;

            Assert.AreEqual(new DateTime(2022, 07, 31, 11, 01, 41, 640, DateTimeKind.Utc), response?.ToDateTime);
            Assert.AreEqual(new DateTimeOffset(2022, 07, 31, 13, 01, 41, 640, TimeSpan.FromHours(2)), response?.ToDateTimeOffset);
        }
    }
}