using System;

namespace TimeZoneConvertor
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "TimeZoneConvertorService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select TimeZoneConvertorService.svc or TimeZoneConvertorService.svc.cs at the Solution Explorer and start debugging.
    public class TimeZoneConvertorService : ITimeZoneConvertor
    {
        public ConvertToOffsetResponse ConvertToOffset(ConvertToOffsetRequest request)
        {
            var conversionRequest = request.TimeZoneConversionRequest;

            var fromDateTime = new DateTimeOffset(conversionRequest.FromDateTime, conversionRequest.FromOffset);

            var response = new TimeZoneConversionResponse()
            {
                ToDateTimeOffset = fromDateTime.ToOffset(conversionRequest.ToOffset)
            };

            return new ConvertToOffsetResponse(response);
        }
    }
}
