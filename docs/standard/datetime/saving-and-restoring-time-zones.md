---
title: "Saving and restoring time zones"
ms.custom: ""
ms.date: "04/10/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "restoring time zones"
  - "deserialization [.NET Framework], time zones"
  - "serialization [.NET Framework], time zones"
  - "time zone objects [.NET Framework], restoring"
  - "saving time zones"
  - "time zone objects [.NET Framework], deserializing"
  - "time zones [.NET Framework], saving"
  - "time zones [.NET Framework], restoring"
  - "time zone objects [.NET Framework], serializing"
  - "time zone objects [.NET Framework], saving"
ms.assetid: 4028b310-e7ce-49d4-a646-1e83bfaf6f9d
caps.latest.revision: 9
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---

# Saving and restoring time zones

The <xref:System.TimeZoneInfo> class relies on the registry to retrieve predefined time zone data. However, the registry is a dynamic structure. Additionally, the time zone information that the registry contains is used by the operating system primarily to handle time adjustments and conversions for the current year. This has two major implications for applications that rely on accurate time zone data:

* A time zone that is required by an application may not be defined in the registry, or it may have been renamed or removed from the registry.

* A time zone that is defined in the registry may lack information about the particular adjustment rules that are necessary for historical time zone conversions.

The <xref:System.TimeZoneInfo> class addresses these limitations through its support for serialization (saving) and deserialization (restoring) of time zone data.

## Time zone serialization and deserialization

Saving and restoring a time zone by serializing and deserializing time zone data involves just two method calls:

* You can serialize a <xref:System.TimeZoneInfo> object by calling that object's <xref:System.TimeZoneInfo.ToSerializedString%2A> method. The method takes no parameters and returns a string that contains time zone information.

* You can deserialize a <xref:System.TimeZoneInfo> object from a serialized string by passing that string to the `static` (`Shared` in Visual Basic) <xref:System.TimeZoneInfo.FromSerializedString%2A?displayProperty=nameWithType> method.

## Serialization and deserialization scenarios

The ability to save (or serialize) a <xref:System.TimeZoneInfo> object to a string and to restore (or deserialize) it for later use increases both the utility and the flexibility of the <xref:System.TimeZoneInfo> class. This section examines some of the situations in which serialization and deserialization are most useful.

### Serializing and deserializing time zone data in an application

A serialized time zone can be restored from a string when it is needed. An application might do this if the time zone retrieved from the registry is unable to correctly convert a date and time within a particular date range. For example, time zone data in the Windows XP registry supports a single adjustment rule, while time zones defined in the Windows Vista registry typically provide information about two adjustment rules. This means that historical time conversions may be inaccurate. Serialization and deserialization of time zone data can handle this limitation.

In the following example, a custom <xref:System.TimeZoneInfo> class that has no adjustment rules is defined to represent the U.S. Eastern Standard Time zone from 1883 to 1917, before the introduction of daylight saving time in the United States. The custom time zone is serialized in a variable that has global scope. The time zone conversion method, `ConvertUtcTime`, is passed Coordinated Universal Time (UTC) times to convert. If the date and time occurs in 1917 or earlier, the custom Eastern Standard Time zone is restored from a serialized string and replaces the time zone retrieved from the registry.

[!code-csharp[System.TimeZone2.Serialization.1#1](../../../samples/snippets/csharp/VS_Snippets_CLR_System/system.TimeZone2.Serialization.1/cs/Serialization.cs#1)]
[!code-vb[System.TimeZone2.Serialization.1#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR_System/system.TimeZone2.Serialization.1/vb/Serialization.vb#1)]

### Handling time zone exceptions

Because the registry is a dynamic structure, its contents are subject to accidental or deliberate modification. This means that a time zone that should be defined in the registry and that is required for an application to execute successfully may be absent. Without support for time zone serialization and deserialization, you have little choice but to handle the resulting <xref:System.TimeZoneNotFoundException> by ending the application. However, by using time zone serialization and deserialization, you can handle an unexpected <xref:System.TimeZoneNotFoundException> by restoring the required time zone from a serialized string, and the application will continue to run.

The following example creates and serializes a custom Central Standard Time zone. It then tries to retrieve the Central Standard Time zone from the registry. If the retrieval operation throws either a <xref:System.TimeZoneNotFoundException> or an <xref:System.InvalidTimeZoneException>, the exception handler deserializes the time zone.

[!code-csharp[System.TimeZone2.Serialization.2#1](../../../samples/snippets/csharp/VS_Snippets_CLR_System/system.TimeZone2.Serialization.2/cs/Serialization2.cs#1)]
[!code-vb[System.TimeZone2.Serialization.2#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR_System/system.TimeZone2.Serialization.2/vb/Serialization2.vb#1)]

### Storing a serialized string and restoring it when needed

The previous examples have stored time zone information to a string variable and restored it when needed. However, the string that contains serialized time zone information can itself be stored in some storage medium, such as an external file, a resource file embedded in the application, or the registry. (Note that information about custom time zones should be stored apart from the system's time zone keys in the registry.)

Storing a serialized time zone string in this manner also separates the time zone creation routine from the application itself. For example, a time zone creation routine can execute and create a data file that contains historical time zone information that an application can use. The data file can be then be installed with the application, and it can be opened and one or more of its time zones can be deserialized when the application requires them.

For an example that uses an embedded resource to store serialized time zone data, see [How to: Save time zones to an embedded resource](../../../docs/standard/datetime/save-time-zones-to-an-embedded-resource.md) and [How to: Restore time zones from an embedded resource](../../../docs/standard/datetime/restore-time-zones-from-an-embedded-resource.md).

## See also

[Dates, times, and time zones](../../../docs/standard/datetime/index.md)
