using System;

namespace TimeZoneConverter;

public partial class TimeZoneConversionResponse
{
    private DateTimeOffset ToDateTimeOffsetField;

    public DateTimeOffset ToDateTimeOffset
    {
        get 
        {
            return ToDateTimeOffsetField;
        }
        set 
        {
            ToDateTimeOffsetField = value;
            toDateTimeField = value.UtcDateTime;
        }
    }
}