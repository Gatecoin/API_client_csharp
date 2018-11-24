using System;
using System.Globalization;

namespace GatecoinServiceInterface.WebSocket.Client
{
    internal static class Unix
    {
        public static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
    }

    internal static class DateTimeExtensions
    {
        public static string ToUnixTimeString(this DateTime? dateTime)
        {
            return dateTime.ToUnixTime().ToString("F0", CultureInfo.InvariantCulture);
        }

        public static string ToUnixTimeString(this DateTime dateTime)
        {
            return dateTime.ToUnixTime().ToString("F0", CultureInfo.InvariantCulture);
        }

        public static double ToUnixTime(this DateTime? dateTime)
        {
            if (dateTime == null)
            {
                return 0;
            }

            return dateTime.Value.TotalSeconds();
        }

        public static double ToUnixTime(this DateTime dateTime)
        {
            return dateTime.TotalSeconds();
        }

        private static double TotalSeconds(this DateTime dateTime)
        {
            return (dateTime.ToUniversalTime() - Unix.Epoch).TotalSeconds;
        }
    }
}