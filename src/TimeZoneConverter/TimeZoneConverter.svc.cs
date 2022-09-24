using System;
using System.Globalization;

namespace TimeZoneConverter;

public class TimeZoneConverterService : ITimeZoneConverter
{
    [TimeZoneConversionResponseSerializer]
    public ConvertToOffsetResponse ConvertToOffset(ConvertToOffsetRequest request)
    {
        var conversionRequest = request.TimeZoneConversionRequest;

        var fromDateTime = new DateTimeOffset(conversionRequest.FromDateTime, TimeSpan.FromMinutes((double)conversionRequest.FromOffset));
        var toDateTime = fromDateTime.ToOffset(TimeSpan.FromMinutes((double)conversionRequest.ToOffset));

        var response = new TimeZoneConversionResponse()
        {
            ToDateTimeOffset = toDateTime.ToString("o", CultureInfo.InvariantCulture)
        };

        return new ConvertToOffsetResponse(response);
    }
}
