using System;
using System.Globalization;
using System.Xml.Serialization;

namespace TimeZoneConverter.Contracts;

public partial class TimeZoneConversionResponse
{
    private DateTimeOffset ToDateTimeOffsetField;

    [XmlElement(Order = 1)]
    public string ToDateTimeOffset
    {
        get
        {
            return ToDateTimeOffsetField.ToString("o", CultureInfo.InvariantCulture);
        }
        set
        {
            ToDateTimeOffsetField = DateTimeOffset.ParseExact(value, "o", CultureInfo.InvariantCulture);
            toDateTimeField = ToDateTimeOffsetField.UtcDateTime;
        }
    }
}