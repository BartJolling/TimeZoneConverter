using System.Globalization;
using TimeZoneConverter.Contracts;

namespace TimeZoneConverter;

public class TimeZoneConverterService : ITimeZoneConverter
{
    [RequestResponseSerializer()]
    public Task<ConvertToOffsetResponse> ConvertToOffsetAsync(ConvertToOffsetRequest request)
    {
        var conversionRequest = request.TimeZoneConversionRequest;

        var fromDateTime = new DateTimeOffset(
            conversionRequest.FromDateTime,
            TimeSpan.FromMinutes((double)conversionRequest.FromOffset));

        var toDateTime = fromDateTime.ToOffset(
            TimeSpan.FromMinutes((double)conversionRequest.ToOffset));

        var response = new TimeZoneConversionResponse
        {
            ToDateTimeOffset = toDateTime.ToString("o", CultureInfo.InvariantCulture)
        };

        return Task.FromResult(new ConvertToOffsetResponse(response));
    }
}
