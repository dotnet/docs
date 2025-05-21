---
title: System.DateTime.ToBinary and FromBinary methods
description: Learn about the System.DateTime.ToBinary and System.DateTime.FromBinary methods.
ms.date: 01/24/2024
dev_langs:
  - CSharp
  - FSharp
  - VB
ms.topic: article
---
# System.DateTime.ToBinary and FromBinary methods

[!INCLUDE [context](includes/context.md)]

Use the <xref:System.DateTime.ToBinary%2A> method to convert the value of the current <xref:System.DateTime> object to a binary value. Subsequently, use the binary value and the <xref:System.DateTime.FromBinary%2A> method to recreate the original <xref:System.DateTime> object.

> [!IMPORTANT]
> In some cases, the <xref:System.DateTime> value returned by the <xref:System.DateTime.FromBinary%2A> method is not identical to the original <xref:System.DateTime> value supplied to the <xref:System.DateTime.ToBinary%2A> method. For more information, see the next section, "Local Time Adjustment".

A <xref:System.DateTime> structure consists of a private <xref:System.DateTime.Kind> field, which indicates whether the specified time value is based on local time, Coordinated Universal Time (UTC), or neither, concatenated to a private <xref:System.DateTime.Ticks> field, which contains the number of 100-nanosecond ticks that specify a date and time.

## Local time adjustment

A local time, which is a Coordinated Universal Time adjusted to the local time zone, is represented by a <xref:System.DateTime> structure whose <xref:System.DateTime.Kind> property has the value <xref:System.DateTimeKind.Local>. When restoring a local <xref:System.DateTime> value from the binary representation that is produced by the <xref:System.DateTime.ToBinary%2A> method, the <xref:System.DateTime.FromBinary%2A> method may adjust the recreated value so that it is not equal to the original value. This can occur under the following conditions:

- If a local <xref:System.DateTime> object is serialized in one time zone by the <xref:System.DateTime.ToBinary%2A> method, and then deserialized in a different time zone by the <xref:System.DateTime.FromBinary%2A> method, the local time represented by the resulting <xref:System.DateTime> object is automatically adjusted to the second time zone.

  For example, consider a <xref:System.DateTime> object that represents a local time of 3 P.M. An application that is executing in the U.S. Pacific Time zone uses the <xref:System.DateTime.ToBinary%2A> method to convert that <xref:System.DateTime> object to a binary value. Another application that is executing in the U.S. Eastern Time zone then uses the <xref:System.DateTime.FromBinary%2A> method to convert the binary value to a new <xref:System.DateTime> object. The value of the new <xref:System.DateTime> object is 6 P.M., which represents the same point in time as the original 3 P.M. value, but is adjusted to local time in the Eastern Time zone.

- If the binary representation of a local <xref:System.DateTime> value represents an invalid time in the local time zone of the system on which <xref:System.DateTime.FromBinary%2A> is called, the time is adjusted so that it is valid.

  For example, the transition from standard time to daylight saving time occurs in the Pacific Time zone of the United States on March 14, 2010, at 2:00 A.M., when the time advances by one hour, to 3:00 A.M. This hour interval is an invalid time, that is, a time interval that does not exist in this time zone. The following example shows that when a time that falls within this range is converted to a binary value by the <xref:System.DateTime.ToBinary%2A> method and is then restored by the <xref:System.DateTime.FromBinary%2A> method, the original value is adjusted to become a valid time. You can determine whether a particular date and time value may be subject to modification by passing it to the <xref:System.TimeZoneInfo.IsInvalidTime%2A?displayProperty=nameWithType> method, as the example illustrates.

  :::code language="csharp" source="./snippets/System/DateTime/FromBinary/csharp/frombinary1.cs" id="Snippet1":::
  :::code language="fsharp" source="./snippets/System/DateTime/FromBinary/fsharp/frombinary1.fs" id="Snippet1":::
  :::code language="vb" source="./snippets/System/DateTime/FromBinary/vb/frombinary1.vb" id="Snippet1":::
