---
title: "How to: instantiate a TimeZoneInfo object"
description: How to instantiate a TimeZoneInfo object
keywords: .NET, .NET Core
author: stevehoag
ms.author: shoag
ms.date: 08/15/2016
ms.topic: article
ms.prod: .net
ms.technology: dotnet-standard
ms.devlang: dotnet
ms.assetid: bff137e5-d550-44c3-b460-b3f2dabd4035
---

# How to: instantiate a TimeZoneInfo object

The most common way to instantiate a [TimeZoneInfo](xref:System.TimeZoneInfo) object is to retrieve information about it from the operating system. This topic discusses how to instantiate a [TimeZoneInfo](xref:System.TimeZoneInfo) object from the local system.

## To instantiate a TimeZoneInfo Object

1. Declare a [TimeZoneInfo](xref:System.TimeZoneInfo) object.

2. Call the `static` (`Shared` in Visual Basic) [TimeZoneInfo.FindSystemTimeZoneById](xref:System.TimeZoneInfo.FindSystemTimeZoneById(System.String)) method.

3. Handle any exceptions thrown by the method.

## Example

The following code retrieves a [TimeZoneInfo](xref:System.TimeZoneInfo) object that represents the Eastern Standard Time zone and displays the Eastern Standard time that corresponds to the local time.

```csharp
DateTime timeNow = DateTime.Now;
try
{
   TimeZoneInfo easternZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
   DateTime easternTimeNow = TimeZoneInfo.ConvertTime(timeNow, TimeZoneInfo.Local, 
                                                   easternZone);
   Console.WriteLine("{0} {1} corresponds to {2} {3}.",
                     timeNow, 
                     TimeZoneInfo.Local.IsDaylightSavingTime(timeNow) ?
                               TimeZoneInfo.Local.DaylightName : 
                               TimeZoneInfo.Local.StandardName,
                     easternTimeNow, 
                     easternZone.IsDaylightSavingTime(easternTimeNow) ?
                                 easternZone.DaylightName : 
                                 easternZone.StandardName);
}
// Handle exception
//
// As an alternative to simply displaying an error message, an alternate Eastern
// Standard Time TimeZoneInfo object could be instantiated here either by restoring
// it from a serialized string or by providing the necessary data to the
// CreateCustomTimeZone method.
catch (InvalidTimeZoneException)
{
   Console.WriteLine("The Eastern Standard Time Zone contains invalid or missing data.");
}
catch (SecurityException)
{
   Console.WriteLine("The application lacks permission to read time zone information from the registry.");
}
catch (OutOfMemoryException)
{
   Console.WriteLine("Not enough memory is available to load information on the Eastern Standard Time zone.");
}
// If we weren't passing FindSystemTimeZoneById a literal string, we also 
// would handle an ArgumentNullException.
```

```vb
Dim timeNow As Date = Date.Now
Try
   Dim easternZone As TimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time")
   Dim easternTimeNow As Date = TimeZoneInfo.ConvertTime(timeNow, TimeZoneInfo.Local, easternZone)
   Console.WriteLine("{0} {1} corresponds to {2} {3}.", _
                     timeNow, _
                     IIf(TimeZoneInfo.Local.IsDaylightSavingTime(timeNow), _
                         TimeZoneInfo.Local.DaylightName, TimeZoneInfo.Local.StandardName), _
                     easternTimeNow, _
                     IIf(easternZone.IsDaylightSavingTime(easternTimeNow), _
                         easternZone.DaylightName, easternZone.StandardName))
' Handle exception
'
' As an alternative to simply displaying an error message, an alternate Eastern
' Standard Time TimeZoneInfo object could be instantiated here either by restoring
' it from a serialized string or by providing the necessary data to the
' CreateCustomTimeZone method.
Catch e As InvalidTimeZoneException
   Console.WriteLine("The Eastern Standard Time Zone contains invalid or missing data.")   
Catch e As SecurityException
   Console.WriteLine("The application lacks permission to read time zone information from the registry.")
Catch e As OutOfMemoryException
   Console.WriteLine("Not enough memory is available to load information on the Eastern Standard Time zone.")
' If we weren't passing FindSystemTimeZoneById a literal string, we also 
' would handle an ArgumentNullException.
End
``` 

The [TimeZoneInfo.FindSystemTimeZoneById](xref:System.TimeZoneInfo.FindSystemTimeZoneById(System.String)) method's single parameter is the identifier of the time zone that you want to retrieve, which corresponds to the object's [TimeZoneInfo.Id](xref:System.TimeZoneInfo.Id) property. The time zone identifier is a key field that uniquely identifies the time zone. While most keys are relatively short, the time zone identifier is comparatively long. In most cases, its value corresponds to the [StandardName](xref:System.TimeZoneInfo.StandardName) property of a [TimeZoneInfo](xref:System.TimeZoneInfo) object, which is used to provide the name of the time zone's standard time. However, there are exceptions. The best way to make sure that you supply a valid identifier is to enumerate the time zones available on your system and note the identifiers of the time zones present on them. For an illustration, see [How to: enumerate time zones present on a computer](enumerate-time-zones.md). The [Finding the time zones defined on a local system](finding-the-time-zones-on-local-system.md) topic also contains a list of selected time zone identifiers.

If the time zone is found, the method returns its [TimeZoneInfo](xref:System.TimeZoneInfo) object. If the time zone is found but its data is corrupted or incomplete, the method throws an [InvalidTimeZoneException](xref:System.InvalidTimeZoneException). 

## See Also

[Dates, times, and time zones](index.md)

[Finding the time zones defined on a local system](finding-the-time-zones-on-local-system.md)