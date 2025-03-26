using System;

public static class Utils
{
    public static DateTime ParseDate(string dateStr)
    {
        return DateTime.ParseExact(dateStr, "yyyy-MM-dd", null);
    }
}
