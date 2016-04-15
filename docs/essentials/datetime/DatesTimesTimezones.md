# Dates, Times, and Time Zones

In addition to the basic [System.DateTime](http://dotnet.github.io/api/System.DateTime.html) structure, .NET Core provides the following classes that support working with time zones:

* [System.TimeZoneInfo](http://dotnet.github.io/api/System.TimeZoneInfo.html)
    
  Use this class to work with the system's local time zone and the Coordinated Universal Time (UTC) zone.
  
* [System.DateTimeOffset](http://dotnet.github.io/api/System.DateTimeOffset.html)  

  Use this structure to work with dates and times whose offset (or difference) from UTC is known. The `DateTimeOffset` structure combines a date and time value with that time's offset from UTC. Because of its relationship to UTC, an individual date and time value unambiguously identifies a single point in time. This makes a `DateTimeOffset` value more portable from one computer to another than a `DateTime` value. 
  
This section of the documentation provides the information that you need to work with time zones and to create time zone-aware applications that can convert dates and times from one time zone to another.

## In This Section

[Time Zone Overview](essentials\datetime\TimeZoneOverview.md) - Discusses the terminology, concepts, and issues involved in creating time zone-aware applications.
    
[Choosing Between DateTime, DateTimeOffset, TimeSpan, and TimeZoneInfo](essentials\datetime\ChoosingBetweenDateTime.md) - Discusses when to use the `DateTime`, `DateTimeOffset`, and `TimeZoneInfo` types when working with date and time data.
    
[Finding the Time Zones Defined on a Local System](essentials\datetime\FindingtheTimeZonesonLocalSystem.md) - Describes how to enumerate the time zones found on a local system.

[Instantiating a DateTimeOffset Object](essentials\datetime\InstantiatingaDateTimeOffsetObject.md) - Discusses the ways in which a `DateTimeOffset` object can be instantiated, and the ways in which a `DateTime` value can be converted to a `DateTimeOffset` value.

[Performing Arithmetic Operations with Dates and Times](essentials\datetime\PerformingArithmeticOperations.md) - Discusses the issues involved in adding, subtracting, and comparing `DateTime` and `DateTimeOffset` values.

[Converting Between DateTime and DateTimeOffset](essentials\datetime\ConvertingBetweenDateTimeandOffset.md) - Describes how to convert between `DateTime` and `DateTimeOffset` values.

[Converting Times Between Time Zones](essentials\datetime\ConvertingBetweenTimeZones.md) - Describes how to convert times from one time zone to another.

## Related Topics

[How to: Enumerate Time Zones Present on a Computer](essentials\datetime\EnumerateTimeZones.md) - Provides examples that enumerate the time zones defined in a computer's registry and that let users select a predefined time zone from a list.

[How to: Access the Predefined UTC and Local Time Zone Objects](essentials\datetime\AccessUTCandLocal.md) - Describes how to access Coordinated Universal Time and the local time zone.

[How to: Instantiate a TimeZoneInfo Object](essentials\datetime\InstantiateTimeZoneInfo.md) - Describes how to instantiate a `TimeZoneInfo` object from the local system registry.

[How to: Use Time Zones in Date and Time Arithmetic](essentials\datetime\UseTimeZonesinArithmetic.md) - Discusses how to perform date and time arithmetic that reflects a time zone's adjustment rules.

[How to: Resolve Ambiguous Times](essentials\datetime\ResolveAmbiguousTimes.md) - Describes how to resolve an ambiguous time by mapping it to the time zone's standard time.

[How to: Let Users Resolve Ambiguous Times](essentials\datetime\LetUsersResolveAmbiguousTimes.md) - Describes how to let a user determine the mapping between an ambiguous local time and Coordinated Universal Time.

## Reference

[System.TimeZoneInfo](http://dotnet.github.io/api/System.TimeZoneInfo.html)

[System.DateTimeOffset](http://dotnet.github.io/api/System.DateTimeOffset.html)

[System.DateTime](http://dotnet.github.io/api/System.DateTime.html)
