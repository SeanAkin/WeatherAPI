namespace WeatherAPI.Common.Extensions
{
    public static class LongExtensions
    {
        /// <summary>
        /// Gets a DateTime from a Unix Value
        /// </summary>
        /// <param name="unix">Unix Timestamp</param>
        /// <returns>String</returns>
        public static string ConverToDateTimeString(this long unix)
        {
            DateTime baseDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            string dateTime = baseDateTime.AddSeconds(unix).ToString("dd/MM/yyyy HH:mm");
            return dateTime;
        }
    }
}
