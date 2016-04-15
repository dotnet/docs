# Converting Times Between Time Zones

It is becoming increasingly important for any application that works with dates and times to handle differences between time zones. An application can no longer assume that all times can be expressed in the local time, which is the time available from the [System.DateTime](http://dotnet.github.io/api/System.DateTime.html) structure. For example, a Web page that displays the current time in the eastern part of the United States will lack credibility to a customer in eastern Asia. This topic explains how to convert times from one time zone to another, as well as how to convert `DateTimeOffset` values that have limited time zone awareness.

## Converting UTC to Local Time

To convert UTC to local time, call the [DateTime.ToLocalTime](http://dotnet.github.io/api/System.DateTime.html#methods) method of the `DateTime` object whose time you want to convert. The exact behavior of the method depends on the value of the object’s `Kind` property, as the following table shows.

DateTime.Kind property | Conversion
---------------------- | ----------
`DateTimeKind.Local` | Returns the `DateTime` value unchanged.
`DateTimeKind.Unspecified` | Assumes that the `DateTime` value is UTC and converts the UTC to local time.
`DateTimeKind.Utc` | Converts the `DateTime` value to local time.

## Converting Between Any Two Time Zones

You can convert between any two time zones by using the static [TimeZoneInfo.ConvertTime](http://dotnet.github.io/api/System.TimeZoneInfo.html#System_TimeZoneInfo_ConvertTime_System_DateTime_System_TimeZoneInfo_) method. This method's parameters are the `DateTime` value to convert, a `TimeZoneInfo` object that represents the time zone of the date and time value, and a `TimeZoneInfo` object that represents the time zone to convert the date and time value to.

The method requires that the `Kind` property of the date and time value to convert and the `TimeZoneInfo` object or time zone identifier that represents its time zone correspond to one another. Otherwise, an [ArgumentException](http://dotnet.github.io/api/System.ArgumentException.html) is thrown. For example, if the `Kind` property of the date and time value is `DateTimeKind.Local`, an exception is thrown if the `TimeZoneInfo` object passed as a parameter to the method is not equal to `TimeZoneInfo.Local`. An exception is also thrown if the identifier passed as a parameter to the method is not equal to `TimeZoneInfo.Local.Id`.

The following example uses the `ConvertTime` method to convert from Hawaiian Standard Time to local time.

```csharp
DateTime hwTime = new DateTime(2007, 02, 01, 08, 00, 00);
try
{
   TimeZoneInfo hwZone = TimeZoneInfo.FindSystemTimeZoneById("Hawaiian Standard Time");
   Console.WriteLine("{0} {1} is {2} local time.", 
           hwTime, 
           hwZone.IsDaylightSavingTime(hwTime) ? hwZone.DaylightName : hwZone.StandardName, 
           TimeZoneInfo.ConvertTime(hwTime, hwZone, TimeZoneInfo.Local));
}
catch (TimeZoneNotFoundException)
{
   Console.WriteLine("The registry does not define the Hawaiian Standard Time zone.");
}                           
catch (InvalidTimeZoneException)
{
   Console.WriteLine("Registry data on the Hawaiian STandard Time zone has been corrupted.");
}
```

## Converting DateTimeOffset Values

Date and time values represented by [System.DateTimeOffset](http://dotnet.github.io/api/System.DateTimeOffset.html) objects are not fully time-zone aware because the object is disassociated from its time zone at the time it is instantiated. However, in many cases an application simply needs to convert a date and time based on two different offsets from UTC rather than on the time in particular time zones. To perform this conversion, you can call the current instance's `ToOffset` method. The method's single parameter is `TimeSpan` representing the offset of the new date and time value that the method is to return.  

For example, if the date and time of a user request for a Web page is known and is serialized as a string in the format MM/dd/yyyy hh:mm:ss zzzz, the following `ReturnTimeOnServer` method converts this date and time value to the date and time on the Web server.

```csharp
public DateTimeOffset ReturnTimeOnServer(string clientString)
{
   string format = @"M/d/yyyy H:m:s zzz";
   TimeSpan serverOffset = TimeZoneInfo.Local.GetUtcOffset(DateTimeOffset.Now);

   try
   {      
      DateTimeOffset clientTime = DateTimeOffset.ParseExact(clientString, format, CultureInfo.InvariantCulture);
      DateTimeOffset serverTime = clientTime.ToOffset(serverOffset);
      return serverTime;
   }
   catch (FormatException)
   {
      return DateTimeOffset.MinValue;
   }
}
```
If the method is passed the string "9/1/2007 5:32:07 -05:00", which represents the date and time in a time zone five hours earlier than UTC, it returns 9/1/2007 3:32:07 AM -07:00 for a server located in the U.S. Pacific Standard Time zone.

The `TimeZoneInfo` class also includes an overloaded [TimeZoneInfo.ConvertTime(DateTimeOffset, TimeZoneInfo)](http://dotnet.github.io/api/System.TimeZoneInfo.html#System_TimeZoneInfo_ConvertTime_System_DateTimeOffset_System_TimeZoneInfo_) method that performs time zone conversions with `DateTimeOffset` values. The method's parameters are a `DateTimeOffset` value and a reference to the time zone to which the time is to be converted. The method call returns a `DateTimeOffset` value. For example, the `ReturnTimeOnServer` method in the previous example could be rewritten as follows to call the `ConvertTime(DateTimeOffset, TimeZoneInfo)` method.

```csharp
public DateTimeOffset ReturnTimeOnServer(string clientString)
{
   string format = @"M/d/yyyy H:m:s zzz";

   try
   {      
      DateTimeOffset clientTime = DateTimeOffset.ParseExact(clientString, format, 
                                  CultureInfo.InvariantCulture);
      DateTimeOffset serverTime = TimeZoneInfo.ConvertTime(clientTime, 
                                  TimeZoneInfo.Local);
      return serverTime;
   }
   catch (FormatException)
   {
      return DateTimeOffset.MinValue;
   }
}
```

## See Also

[TimeZoneInfo](http://dotnet.github.io/api/System.TimeZoneInfo.html)

[Dates, Times, and Time Zones](essentials\datetime\DatesTimesTimezones.md)

[Finding the Time Zones Defined on a Local System](essentials\datetime\FindingtheTimeZonesonLocalSystem.md)


