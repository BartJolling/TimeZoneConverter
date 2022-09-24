using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;
using TimeZoneConverter;

namespace TimeZoneConverterTest
{
    [TestClass]
    public class ConversionReponseSerializerTest
    {
        private readonly XmlObjectSerializer _serializer = new TimeZoneConversionResponseSerializer();

        private const string _expectedDateTimeOffset = "2022-07-31T13:01:41.6400000+02:00";
        private readonly string _expectedResponse = "<?xml version=\"1.0\" encoding=\"utf-8\"?>" +
            "<TimeZoneConversionResponse xmlns:i=\"http://www.w3.org/2001/XMLSchema-instance\">" +
            $"<ToDateTime xmlns=\"http://bartjolling.github.io/\">{_expectedDateTimeOffset}</ToDateTime>" +
            "</TimeZoneConversionResponse>";

        [TestMethod]
        public void WriteObject()
        {
            //Arrange
            var response = new TimeZoneConversionResponse()
            {
                ToDateTimeOffset = _expectedDateTimeOffset
            };

            using MemoryStream stream = new();
            using XmlDictionaryWriter writer = XmlDictionaryWriter.CreateTextWriter(stream, Encoding.UTF8, false /*ownsStream*/);

            //Act
            _serializer.WriteObject(writer, response);

            //Assert
            StreamReader reader = new (stream);
            stream.Seek(0, SeekOrigin.Begin);
            string actualResponse = reader.ReadToEnd();
            
            Assert.AreEqual(new DateTime(2022, 07, 31, 11, 01, 41, 640, DateTimeKind.Utc), response.ToDateTime);
            Assert.AreEqual(_expectedResponse, actualResponse);
        }

        [TestMethod]
        public void ReadObject()
        {
            // Arrange            
            using var reader = new StringReader(_expectedResponse);
            using var xmlReader = XmlReader.Create(reader);

            // Act
            var actualResponse = _serializer.ReadObject(xmlReader, false) as TimeZoneConversionResponse;

            // Assert
            Assert.AreEqual(new DateTime(2022, 07, 31, 11, 01, 41, 640, DateTimeKind.Utc), actualResponse?.ToDateTime);
            Assert.AreEqual(_expectedDateTimeOffset, actualResponse?.ToDateTimeOffset);
        }
    }
}