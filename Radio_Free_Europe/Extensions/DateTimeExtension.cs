using System;
using System.Runtime.InteropServices;

namespace Radio_Free_Europe.Extensions
{
    public static class DateTimeExtension
    {
        public static DateTime SystemNow()
        {
            return DateTime.UtcNow;
        }
    }
}