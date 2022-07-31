using System;

namespace TimeZoneConvertor
{
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
                ToDateTimeField = value.UtcDateTime;
            }
        }
    }
}