// <Snippet6>
using System;

namespace DateTimeExtensions
{
    [Serializable]
    public struct DateWithTimeZone
    {
        private TimeZoneInfo tz;
        private DateTime dt;

        public DateWithTimeZone(DateTime dateValue, TimeZoneInfo timeZone)
        {
            dt = dateValue;
            tz = timeZone ?? TimeZoneInfo.Local;
        }

        public TimeZoneInfo TimeZone
        {
            get { return (tz); }
            set { tz = value; }
        }

        public DateTime DateTime
        {
            get { return (dt); }
            set { dt = value; }
        }
    }
}
// </Snippet6>
