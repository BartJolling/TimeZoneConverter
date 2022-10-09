using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;
using TimeZoneConverter.Contracts;
using TimeZoneConvertor.Serializers;

namespace TimeZoneConverterTest
{
    [TestClass]
    public class ConversionReponseSerializerTest
    {
        private readonly XmlObjectSerializer _serializer = new ConvertToOffsetResponseSerializer();

        private const string _expectedDateTimeOffset = "2022-07-31T13:01:41.6400000+02:00";
        private readonly string _expectedResponse = "<?xml version=\"1.0\" encoding=\"utf-8\"?><ConvertToOffsetResponse xmlns=\"http://bartjolling.github.io/\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\"><TimeZoneConversionResponse><ToDateTime>2022-07-31T13:01:41.6400000+02:00</ToDateTime></TimeZoneConversionResponse></ConvertToOffsetResponse>";

        [TestMethod]
        public void WriteObject()
        {
            //Arrange
            var response = new ConvertToOffsetResponse()
            {
                TimeZoneConversionResponse = new TimeZoneConversionResponse()
                {
                    ToDateTimeOffset = _expectedDateTimeOffset
                }
            };

            using MemoryStream stream = new();
            using XmlDictionaryWriter writer = XmlDictionaryWriter.CreateTextWriter(stream, Encoding.UTF8, false /*ownsStream*/);

            //Act
            _serializer.WriteObject(writer, response);

            //Assert
            StreamReader reader = new(stream);
            stream.Seek(0, SeekOrigin.Begin);
            string actualResponse = reader.ReadToEnd();

            Assert.AreEqual(new DateTime(2022, 07, 31, 11, 01, 41, 640, DateTimeKind.Utc), response.TimeZoneConversionResponse.ToDateTime);
            Assert.AreEqual(_expectedResponse, actualResponse);
        }

        [TestMethod]
        public void ReadObject()
        {
            // Arrange            
            using var reader = new StringReader(_expectedResponse);
            using var xmlReader = XmlReader.Create(reader);

            // Act
            var actualResponse = _serializer.ReadObject(xmlReader, false) as ConvertToOffsetResponse;

            // Assert
            Assert.AreEqual(new DateTime(2022, 07, 31, 11, 01, 41, 640, DateTimeKind.Utc), actualResponse?.TimeZoneConversionResponse.ToDateTime);
            Assert.AreEqual(_expectedDateTimeOffset, actualResponse?.TimeZoneConversionResponse.ToDateTimeOffset);
        }
    }
}