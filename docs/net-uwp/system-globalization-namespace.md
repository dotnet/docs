---
title: "System.Globalization namespace | Microsoft Docs"
ms.custom: ""
ms.date: "12/16/2016"
ms.prod: "windows-client-threshold"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - ".net-for-windows-store-apps"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: a47f7920-adb6-4352-a0de-1c898cb0b5df
caps.latest.revision: 9
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
---
# System.Globalization namespace
The `System.Globalization` namespace contains classes that define culture-related information, including the language, the country/region, the calendars in use, the format patterns for dates, currency, and numbers, and the sort order for strings.  
  
 This topic displays the types in the `System.Globalization` namespace that are included in the [!INCLUDE[net_win8_profile](../net-uwp/includes/net-win8-profile-md.md)]. Note that the [!INCLUDE[net_win8_profile](../net-uwp/includes/net-win8-profile-md.md)] does not include all the members of each type. For information about individual types, see the linked topics. The documentation for a type indicates which members are included in the [!INCLUDE[net_win8_profile](../net-uwp/includes/net-win8-profile-md.md)].  
  
## System.Globalization namespace  
  
|Types supported in the [!INCLUDE[net_win8_profile](../net-uwp/includes/net-win8-profile-md.md)]|Description|  
|---------------------------------------------------------------------------------------------|-----------------|  
|<xref:System.Globalization.Calendar>|Represents time in divisions, such as weeks, months, and years.|  
|<xref:System.Globalization.CalendarWeekRule>|Defines different rules for determining the first week of the year.|  
|<xref:System.Globalization.CharUnicodeInfo>|Retrieves information about a Unicode character. This class cannot be inherited.|  
|<xref:System.Globalization.CompareInfo>|Implements a set of methods for culture-sensitive string comparisons.|  
|<xref:System.Globalization.CompareOptions>|Defines the string comparison options to use with CompareInfo.|  
|<xref:System.Globalization.CultureInfo>|Provides information about a specific culture (called a "locale" for unmanaged code development). The information includes the names for the culture, the writing system, the calendar used, and formatting for dates and sort strings.|  
|<xref:System.Globalization.CultureNotFoundException>|The exception thrown when a method is invoked which attempts to construct a culture that is not available on the machine.|  
|<xref:System.Globalization.DateTimeFormatInfo>|Defines how System.DateTime values are formatted and displayed, depending on the culture.|  
|<xref:System.Globalization.DateTimeStyles>|Defines the formatting options that customize string parsing for some date and time parsing methods.|  
|<xref:System.Globalization.NumberFormatInfo>|Defines how numeric values are formatted and displayed, depending on the culture.|  
|<xref:System.Globalization.NumberStyles>|Determines the styles permitted in numeric string arguments that are passed to the Parse and TryParse methods of the integral and floating-point numeric types.|  
|<xref:System.Globalization.RegionInfo>|Contains information about the country/region.|  
|<xref:System.Globalization.StringInfo>|Provides functionality to split a string into text elements and to iterate through those text elements.|  
|<xref:System.Globalization.TextElementEnumerator>|Enumerates the text elements of a string.|  
|<xref:System.Globalization.TextInfo>|Defines text properties and behaviors, such as casing, that are specific to a writing system.|  
|<xref:System.Globalization.TimeSpanStyles>|Defines the formatting options that customize string parsing for the ParseExact and TryParseExact methods.|  
|<xref:System.Globalization.UnicodeCategory>|Defines the Unicode category of a character.|  
  
## See Also  
 [.NET for Windows apps](../net-uwp/dotnet-for-windows-apps.md)