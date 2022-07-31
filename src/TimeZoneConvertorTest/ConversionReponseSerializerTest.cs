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
            string expected = "<TimeZoneConversionResponse xmlns:i=\"http://www.w3.org/2001/XMLSchema-instance\"><ToDateTime>2022-07-31T13:01:41.64+02:00</ToDateTime></TimeZoneConversionResponse>";

            //Arrange
            var response = new TimeZoneConversionResponse()
            {
                ToDateTimeOffset = new DateTimeOffset(2022, 07, 31, 13, 01, 41, 640, TimeSpan.FromHours(2))
            };

            using StringWriter stream = new();
            using XmlWriter writer = XmlWriter.Create(stream, new XmlWriterSettings { Indent = false, OmitXmlDeclaration = true, NewLineHandling = NewLineHandling.None });

            //Act
            _serializer.WriteObject(writer, response);
            var actual = stream.ToString();

            //Assert
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