# How to: Instantiate a TimeZoneInfo Object

The most common way to instantiate a `TimeZoneInfo` object is to retrieve information about it from the operating system. This topic discusses how to instantiate a `TimeZoneInfo` object from the local system.

## To instantiate a TimeZoneInfo Object

1. Declare a `TimeZoneInfo` object.

2. Call the static `TimeZoneInfo.FindSystemTimeZoneById` method.

3. Handle any exceptions thrown by the method, particularly the `System.TimeZoneNotFoundException` that is thrown if the time zone is not defined in the registry.

## See Also

[Dates, Times, and Time Zones](essentials\datetime\DatesTimesTimezones.md)

[Finding the Time Zones Defined on a Local System](essentials\datetime\FindingtheTimeZonesonLocalSystem.md)