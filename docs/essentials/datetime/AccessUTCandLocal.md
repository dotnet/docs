# How to: Access the Predefined UTC and Local Time Zone Objects

The [System.TimeZoneInfo](http://dotnet.github.io/api/System.TimeZoneInfo.html) class provides two properties, `Utc` and `Local`, that give your code access to predefined time zone objects. This topic discusses how to access the `TimeZoneInfo` objects returned by those properties.

## To access the Coordinated Universal Time (UTC) TimeZoneInfo object

1. Use the **static** `TimeZoneInfo.Utc` property to access Coordinated Universal Time.

2. Rather than assigning the `TimeZoneInfo` object returned by the property to an object variable, continue to access Coordinated Universal Time through the `TimeZoneInfo.Utc` property.


## To access the local time zone

1. Use the **static** `TimeZoneInfo.Local` property to access the local system time zone.

2. Rather than assigning the `TimeZoneInfo` object returned by the property to an object variable, continue to access the local time zone through the `TimeZoneInfo.Local` property.


## See Also

[Dates, Times, and Time Zones](essentials\datetime\DatesTimesTimezones.md)

[Finding the Time Zones Defined on a Local System](essentials\datetime\FindingtheTimeZonesonLocalSystem.md)
