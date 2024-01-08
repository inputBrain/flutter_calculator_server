using System;

namespace FlutterApp.Server.Utils;

public static class Timestamp
{
    public static int Current => ToUnixTime(DateTimeOffset.UtcNow);

    public static int CurrentDate => ToUnixTime(DateTimeOffset.UtcNow.Date);


    public static int ToUnixTime(DateTimeOffset date)
    {
        return checked((int) date.ToUnixTimeSeconds());
    }


    public static DateTime TimestampToDateTime( int unixTimestamp )
    {
        System.DateTime dtDateTime = new DateTime(1970,1,1,0,0,0,0,System.DateTimeKind.Utc);
        dtDateTime = dtDateTime.AddSeconds( unixTimestamp ).ToLocalTime();
        return dtDateTime;
    }
}