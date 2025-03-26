using System;
class Utils
{
    public static DateTime ParseDate(string dateStr)
    {
        return DateTime.ParseExact(dateStr, "yyyy-MM-dd", null);
    }
}
