using System;

namespace TimeZoneConverter
{
    public class TimeZoneConverterService : ITimeZoneConverter
    {
        [TimeZoneConversionResponseSerializer]
        public ConvertToOffsetResponse ConvertToOffset(ConvertToOffsetRequest request)
        {
            var conversionRequest = request.TimeZoneConversionRequest;

            var fromDateTime = new DateTimeOffset(conversionRequest.FromDateTime, TimeSpan.FromMinutes((double)conversionRequest.FromOffset));

            var response = new TimeZoneConversionResponse()
            {
                ToDateTimeOffset = fromDateTime.ToOffset(TimeSpan.FromMinutes((double)conversionRequest.ToOffset))
            };

            return new ConvertToOffsetResponse(response);
        }
    }
}
