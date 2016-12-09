---
title: Converting times between time zones
description: Converting times between time zones
keywords: .NET, .NET Core
author: stevehoag
ms.author: shoag
ms.date: 08/15/2016
ms.topic: article
ms.prod: .net
ms.technology: dotnet-standard
ms.devlang: dotnet
ms.assetid: bf8f74e6-e7f2-4c2a-a04c-57db0e28dd36
---

# Converting times between time zones

It is becoming increasingly important for any application that works with dates and times to handle differences between time zones. An application can no longer assume that all times can be expressed in the local time, which is the time available from the [System.DateTime](xref:System.DateTime) structure. For example, a Web page that displays the current time in the eastern part of the United States will lack credibility to a customer in eastern Asia. This topic explains how to convert times from one time zone to another, as well as how to convert [System.DateTimeOffset](xref:System.DateTimeOffset) values that have limited time zone awareness.

## Converting to Coordinated Universal Time

Coordinated Universal Time (UTC) is a high-precision, atomic time standard. The world’s time zones are expressed as positive or negative offsets from UTC. Thus, UTC provides a kind of time-zone free or time-zone neutral time. The use of UTC time is recommended when a date and time's portability across computers is important. Converting individual time zones to UTC makes time comparisons easy.

> [!NOTE]
> You can also serialize a [DateTimeOffset](xref:System.DateTimeOffset) structure to unambiguously represent a single point in time. Because [DateTimeOffset](xref:System.DateTimeOffset) objects store a date and time value along with its offset from UTC, they always represent a particular point in time in relationship to UTC.

The easiest way to convert a time to UTC is to call the `static` (`Shared` in Visual Basic) [TimeZoneInfo.ConvertTimeToUtc(DateTime)](https://msdn.microsoft.com/library/bb381744(v=vs.110).aspx) method. 

> [!IMPORTANT]
> The `TimeZoneInfo.ConvertTimeToUtc(DateTime)` method isn't currently available in .NET Core. 

The exact conversion performed by the method depends on the value of the `DateTime` parameter's [Kind](xref:System.DateTime.Kind) property, as the following table shows.

[DateTime.Kind](xref:System.DateTimeKind) property | Conversion
---------------------------------------------------------------------------------------------- | ----------
[DateTimeKind.Local](xref:System.DateTimeKind.Local) | Converts local time to UTC.
[DateTimeKind.Unspecified](xref:System.DateTimeKind.Unspecified) | Assumes the `DateTime` parameter is local time and converts local time to UTC.
[DateTimeKind.Utc](xref:System.DateTimeKind.Utc) | Returns the `DateTime` parameter unchanged.

The following code converts the current local time to UTC and displays the result to the console.

```csharp
DateTime dateNow = DateTime.Now;
Console.WriteLine("The date and time are {0} UTC.", 
                   TimeZoneInfo.ConvertTimeToUtc(dateNow));
```

```vb
Dim dateNow As Date = Date.Now      
Console.WriteLine("The date and time are {0} UTC.", _
                  TimeZoneInfo.ConvertTimeToUtc(dateNow))
```

> [!NOTE]
>The [TimeZoneInfo.ConvertTimeToUtc(DateTime)](https://msdn.microsoft.com/library/bb381744(v=vs.110).aspx) method does not necessarily produce results that are identical to the [TimeZone.ToUniversalTime](https://msdn.microsoft.com/library/System.TimeZone.ToUniversalTime(v=vs.110).aspx) and [DateTime.ToUniversalTime](xref:System.DateTime.ToUniversalTime) methods. If the host system's local time zone includes multiple adjustment rules, [TimeZoneInfo.ConvertTimeToUtc(DateTime)](https://msdn.microsoft.com/library/System.TimeZone.ConvertTimeToUtc(v=vs.110).aspx) applies the appropriate rule to a particular date and time. The other two methods always apply the latest adjustment rule.

If the date and time value does not represent either the local time or UTC, the [ToUniversalTime](https://msdn.microsoft.com/library/System.TimeZone.ToUniversalTime(v=vs.110).aspx) method will likely return an erroneous result. However, you can use the [TimeZoneInfo.ConvertTimeToUtc](https://msdn.microsoft.com/library/bb381744(v=vs.110).aspx) method to convert the date and time from a specified time zone. (For details on retrieving a TimeZoneInfo object that represents the destination time zone, see [Finding the time zones defined on a local system](finding-the-time-zones-on-local-system.md). The following code uses the [TimeZoneInfo.ConvertTimeToUtc](https://msdn.microsoft.com/library/bb381744(v=vs.110).aspx) method to convert Eastern Standard Time to UTC.

```csharp
DateTime easternTime = new DateTime(2007, 01, 02, 12, 16, 00);
string easternZoneId = "Eastern Standard Time";
try
{
   TimeZoneInfo easternZone = TimeZoneInfo.FindSystemTimeZoneById(easternZoneId);
   Console.WriteLine("The date and time are {0} UTC.", 
                     TimeZoneInfo.ConvertTimeToUtc(easternTime, easternZone));
}
catch (TimeZoneNotFoundException)
{
   Console.WriteLine("Unable to find the {0} zone in the registry.", 
                     easternZoneId);
}                           
catch (InvalidTimeZoneException)
{
   Console.WriteLine("Registry data on the {0} zone has been corrupted.", 
                     easternZoneId);
}
```

```vb
Dim easternTime As New Date(2007, 01, 02, 12, 16, 00)
Dim easternZoneId As String = "Eastern Standard Time"
Try
   Dim easternZone As TimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(easternZoneId)
   Console.WriteLine("The date and time are {0} UTC.", _ 
                     TimeZoneInfo.ConvertTimeToUtc(easternTime, easternZone))
Catch e As TimeZoneNotFoundException
   Console.WriteLine("Unable to find the {0} zone in the registry.", _
                     easternZoneId)
Catch e As InvalidTimeZoneException
   Console.WriteLine("Registry data on the {0} zone has been corrupted.", _ 
                     easternZoneId)
End Try    
```

Note that this method throws an [ArgumentException](xref:System.ArgumentException) if the [DateTime](xref:System.DateTime) object's [Kind](xref:System.DateTimeKind) property and the time zone are mismatched. A mismatch occurs if the Kind property is [DateTimeKind.Local](xref:System.DateTimeKind.Local) but the [TimeZoneInfo](xref:System.TimeZoneInfo) object does not represent the local time zone, or if the Kind property is [DateTimeKind.Utc](xref:System.DateTimeKind.Utc) but the [TimeZoneInfo](xref:System.TimeZoneInfo) object does not equal [DateTimeKind.Utc](xref:System.DateTimeKind.Utc).

All of these methods take [DateTime](xref:System.DateTime) values as parameters and return a [DateTime](xref:System.DateTime) value. For [DateTimeOffset](xref:System.DateTimeOffset) values, the [DateTimeOffset](xref:System.DateTimeOffset) structure has a [ToUniversalTime](xref:System.DateTimeOffset.ToUniversalTime) instance method that converts the date and time of the current instance to UTC. The following example calls the [ToUniversalTime](xref:System.DateTimeOffset.ToUniversalTime) method to convert a local time and several other times to Coordinated Universal Time (UTC).

```csharp
DateTimeOffset localTime, otherTime, universalTime;

// Define local time in local time zone
localTime = new DateTimeOffset(new DateTime(2007, 6, 15, 12, 0, 0));
Console.WriteLine("Local time: {0}", localTime);
Console.WriteLine();

// Convert local time to offset 0 and assign to otherTime
otherTime = localTime.ToOffset(TimeSpan.Zero);
Console.WriteLine("Other time: {0}", otherTime);
Console.WriteLine("{0} = {1}: {2}", 
                  localTime, otherTime, 
                  localTime.Equals(otherTime));
Console.WriteLine("{0} exactly equals {1}: {2}", 
                  localTime, otherTime, 
                  localTime.EqualsExact(otherTime));
Console.WriteLine();

// Convert other time to UTC
universalTime = localTime.ToUniversalTime(); 
Console.WriteLine("Universal time: {0}", universalTime);
Console.WriteLine("{0} = {1}: {2}", 
                  otherTime, universalTime, 
                  universalTime.Equals(otherTime));
Console.WriteLine("{0} exactly equals {1}: {2}", 
                  otherTime, universalTime, 
                  universalTime.EqualsExact(otherTime));
Console.WriteLine();
// The example produces the following output to the console:
//    Local time: 6/15/2007 12:00:00 PM -07:00
//    
//    Other time: 6/15/2007 7:00:00 PM +00:00
//    6/15/2007 12:00:00 PM -07:00 = 6/15/2007 7:00:00 PM +00:00: True
//    6/15/2007 12:00:00 PM -07:00 exactly equals 6/15/2007 7:00:00 PM +00:00: False
//    
//    Universal time: 6/15/2007 7:00:00 PM +00:00
//    6/15/2007 7:00:00 PM +00:00 = 6/15/2007 7:00:00 PM +00:00: True
//    6/15/2007 7:00:00 PM +00:00 exactly equals 6/15/2007 7:00:00 PM +00:00: True 
```

```vb
Dim localTime, otherTime, universalTime As DateTimeOffset

' Define local time in local time zone
localTime = New DateTimeOffset(#6/15/2007 12:00:00PM#)
Console.WriteLine("Local time: {0}", localTime)
Console.WriteLine()

' Convert local time to offset 0 and assign to otherTime
otherTime = localTime.ToOffset(TimeSpan.Zero)
Console.WriteLine("Other time: {0}", otherTime)
Console.WriteLine("{0} = {1}: {2}", _
                  localTime, otherTime, _
                  localTime.Equals(otherTime))
Console.WriteLine("{0} exactly equals {1}: {2}", _ 
                  localTime, otherTime, _
                  localTime.EqualsExact(otherTime))
Console.WriteLine()

' Convert other time to UTC
universalTime = localTime.ToUniversalTime() 
Console.WriteLine("Universal time: {0}", universalTime)
Console.WriteLine("{0} = {1}: {2}", _
                  otherTime, universalTime, _ 
                  universalTime.Equals(otherTime))
Console.WriteLine("{0} exactly equals {1}: {2}", _ 
                  otherTime, universalTime, _
                  universalTime.EqualsExact(otherTime))
Console.WriteLine()
' The example produces the following output to the console:
'    Local time: 6/15/2007 12:00:00 PM -07:00
'    
'    Other time: 6/15/2007 7:00:00 PM +00:00
'    6/15/2007 12:00:00 PM -07:00 = 6/15/2007 7:00:00 PM +00:00: True
'    6/15/2007 12:00:00 PM -07:00 exactly equals 6/15/2007 7:00:00 PM +00:00: False
'    
'    Universal time: 6/15/2007 7:00:00 PM +00:00
'    6/15/2007 7:00:00 PM +00:00 = 6/15/2007 7:00:00 PM +00:00: True
'    6/15/2007 7:00:00 PM +00:00 exactly equals 6/15/2007 7:00:00 PM +00:00: True 
```

## Converting UTC to a designated time zone

To convert UTC to local time, see the [Converting UTC to local time](#converting-utc-to-local-time) section that follows. 

To convert UTC to the time in any time zone that you designate, call the [ConvertTimeFromUtc](https://msdn.microsoft.com/library/System.TimeZoneInfo.converttimefromutc(v=vs.110).aspx) method. 

> [!IMPORTANT]
> The `TimeZoneInfo.ConvertTimeFromUtc' method isn't currently available in .NET Core. 

The method takes two parameters:

* The UTC to convert. This must be a [DateTime](xref:System.DateTime) value whose [Kind](xref:System.DateTime.Kind) property is set to [DateTimeKind.Utc](xref:System.DateTimeKind.Utc) or [DateTimeKind.Unspecified](xref:System.DateTimeKind.Unspecified). 

* The time zone to convert the UTC to. 

The following code converts UTC to Central Standard Time.

```csharp
DateTime timeUtc = DateTime.UtcNow;
try
{
   TimeZoneInfo cstZone = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
   DateTime cstTime = TimeZoneInfo.ConvertTimeFromUtc(timeUtc, cstZone);
   Console.WriteLine("The date and time are {0} {1}.", 
                     cstTime, 
                     cstZone.IsDaylightSavingTime(cstTime) ?
                             cstZone.DaylightName : cstZone.StandardName);
}
catch (TimeZoneNotFoundException)
{
   Console.WriteLine("The registry does not define the Central Standard Time zone.");
}                           
catch (InvalidTimeZoneException)
{
   Console.WriteLine("Registry data on the Central Standard Time zone has been corrupted.");
}
```

```vb
Dim timeUtc As Date = Date.UtcNow
Try
   Dim cstZone As TimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time")
   Dim cstTime As Date = TimeZoneInfo.ConvertTimeFromUtc(timeUtc, cstZone)
   Console.WriteLine("The date and time are {0} {1}.", _
                     cstTime, _
                     IIf(cstZone.IsDaylightSavingTime(cstTime), _
                         cstZone.DaylightName, cstZone.StandardName))
Catch e As TimeZoneNotFoundException
   Console.WriteLine("The registry does not define the Central Standard Time zone.")
Catch e As InvalidTimeZoneException
   Console.WriteLine("Registry data on the Central Standard Time zone has been corrupted.")
End Try
``` 

## Converting UTC to local time

To convert UTC to local time, call the [DateTime.ToLocalTime](xref:System.DateTime) method of the [DateTime](xref:System.DateTime) object whose time you want to convert. The exact behavior of the method depends on the value of the object’s [Kind](xref:System.DateTime.Kind) property, as the following table shows.

[DateTime.Kind](xref:System.DateTimeKind) property | Conversion
---------------------------------------------------------------------------------------------- | ----------
[DateTimeKind.Local](xref:System.DateTimeKind.Local) | Returns the [DateTime](xref:System.DateTime) value unchanged.
[DateTimeKind.Unspecified](xref:System.DateTimeKind.Unspecified) | Assumes that the [DateTime](xref:System.DateTime) value is UTC and converts the UTC to local time.
[DateTimeKind.Utc](xref:System.DateTimeKind.Utc) | Converts the [DateTime](xref:System.DateTime) value to local time.

## Converting between any two time zones

You can convert between any two time zones by using the static [TimeZoneInfo.ConvertTime](xref:System.TimeZoneInfo.ConvertTime(System.DateTime,System.TimeZoneInfo)) method. This method's parameters are the [DateTime](xref:System.DateTime) value to convert, a [TimeZoneInfo](xref:System.TimeZoneInfo) object that represents the time zone of the date and time value, and a [TimeZoneInfo](xref:System.TimeZoneInfo) object that represents the time zone to convert the date and time value to.

The method requires that the [Kind](xref:System.DateTime.Kind) property of the date and time value to convert and the [TimeZoneInfo](xref:System.TimeZoneInfo) object or time zone identifier that represents its time zone correspond to one another. Otherwise, an [ArgumentException](xref:System.ArgumentException) is thrown. For example, if the [Kind](xref:System.DateTime.Kind) property of the date and time value is [DateTimeKind.Local](xref:System.DateTimeKind.Local), an exception is thrown if the [TimeZoneInfo](xref:System.TimeZoneInfo) object passed as a parameter to the method is not equal to [TimeZoneInfo.Local](xref:System.TimeZoneInfo.Local). An exception is also thrown if the identifier passed as a parameter to the method is not equal to [TimeZoneInfo.Id](xref:System.TimeZoneInfo.Id).

The following example uses the [ConvertTime](xref:System.TimeZoneInfo.ConvertTime(System.DateTime,System.TimeZoneInfo)) method to convert from Hawaiian Standard Time to local time.

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

```vb
Dim hwTime As Date = #2/01/2007 8:00:00 AM#
Try
   Dim hwZone As TimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Hawaiian Standard Time")
   Console.WriteLine("{0} {1} is {2} local time.", _
                     hwTime, _
                     IIf(hwZone.IsDaylightSavingTime(hwTime), hwZone.DaylightName, hwZone.StandardName), _
                     TimeZoneInfo.ConvertTime(hwTime, hwZone, TimeZoneInfo.Local))
Catch e As TimeZoneNotFoundException
   Console.WriteLine("The registry does not define the Hawaiian Standard Time zone.")
Catch e As InvalidTimeZoneException
   Console.WriteLine("Registry data on the Hawaiian Standard Time zone has been corrupted.")
End Try
```

## Converting DateTimeOffset values

Date and time values represented by [System.DateTimeOffset](xref:System.DateTimeOffset) objects are not fully time-zone aware because the object is disassociated from its time zone at the time it is instantiated. However, in many cases an application simply needs to convert a date and time based on two different offsets from UTC rather than on the time in particular time zones. To perform this conversion, you can call the current instance's [ToOffset](xref:System.DateTimeOffset.ToOffset(System.TimeSpan)) method. The method's single parameter is [TimeSpan](xref:System.TimeSpan) representing the offset of the new date and time value that the method is to return.  

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

```vb
Public Function ReturnTimeOnServer(clientString As String) As DateTimeOffset
   Dim format As String = "M/d/yyyy H:m:s zzz"
   Dim serverOffset As TimeSpan = TimeZoneInfo.Local.GetUtcOffset(DateTimeOffset.Now)

   Try      
      Dim clientTime As DateTimeOffset = DateTimeOffset.ParseExact(clientString, format, CultureInfo.InvariantCulture)
      Dim serverTime As DateTimeOffset = clientTime.ToOffset(serverOffset)
      Return serverTime
   Catch e As FormatException
      Return DateTimeOffset.MinValue
   End Try    
End Function
```

If the method is passed the string "9/1/2007 5:32:07 -05:00", which represents the date and time in a time zone five hours earlier than UTC, it returns 9/1/2007 3:32:07 AM -07:00 for a server located in the U.S. Pacific Standard Time zone.

The [TimeZoneInfo](xref:System.TimeZoneInfo) class also includes an overloaded [TimeZoneInfo.ConvertTime(DateTimeOffset, TimeZoneInfo)](xref:System.TimeZoneInfo.ConvertTime(System.DateTimeOffset,System.TimeZoneInfo)) method that performs time zone conversions with [System.DateTimeOffset](xref:System.DateTimeOffset) values. The method's parameters are a [System.DateTimeOffset](xref:System.DateTimeOffset) value and a reference to the time zone to which the time is to be converted. The method call returns a [System.DateTimeOffset](xref:System.DateTimeOffset) value. For example, the `ReturnTimeOnServer` method in the previous example could be rewritten as follows to call the [ConvertTime(DateTimeOffset, TimeZoneInfo)](xref:System.TimeZoneInfo.ConvertTime(System.DateTimeOffset,System.TimeZoneInfo)) method.

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

```vb
Public Function ReturnTimeOnServer(clientString As String) As DateTimeOffset
   Dim format As String = "M/d/yyyy H:m:s zzz"

   Try      
      Dim clientTime As DateTimeOffset = DateTimeOffset.ParseExact(clientString, format, CultureInfo.InvariantCulture)
      Dim serverTime As DateTimeOffset = TimeZoneInfo.ConvertTime(clientTime, TimeZoneInfo.Local)
      Return serverTime
   Catch e As FormatException
      Return DateTimeOffset.MinValue
   End Try    
End Function
```

## See also

[TimeZoneInfo](xref:System.TimeZoneInfo)

[Dates, times, and time zones](index.md)

[Finding the time zones defined on a local system](finding-the-time-zones-on-local-system.md)


