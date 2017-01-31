---
title: "System.Globalization namespace for UWP apps | Microsoft Docs"
ms.custom: ""
ms.date: "12/14/2016"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: bbf76566-8b08-4eb0-8905-8a40a4ef1096
caps.latest.revision: 5
author: "msatranjr"
ms.author: "misatran"
manager: "markl"
---
# System.Globalization namespace for UWP apps
The `System.Globalization` namespace contains classes that define culture-related information, including the language, the country/region, the calendars in use, the format patterns for dates, currency, and numbers, and the sort order for strings.  
  
 This topic displays the types in the `System.Globalization` namespace that are included in [!INCLUDE[net_win10_profile](../net-uwp/includes/net-win10-profile-md.md)]. Note that [!INCLUDE[net_win10_profile](../net-uwp/includes/net-win10-profile-md.md)] does not include all the members of each type. For information about individual types, see the linked topics. The documentation for a type indicates which members are included in [!INCLUDE[net_win10_profile](../net-uwp/includes/net-win10-profile-md.md)].  
  
## System.Globalization namespace  
  
|Types supported in [!INCLUDE[net_win10_profile](../net-uwp/includes/net-win10-profile-md.md)]|Description|  
|------------------------------------------------------------------------------------------|-----------------|  
|<xref:System.Globalization.Calendar>|Represents time in divisions, such as weeks, months, and years.|  
|<xref:System.Globalization.CalendarWeekRule>|Defines different rules for determining the first week of the year.|  
|<xref:System.Globalization.CharUnicodeInfo>|Retrieves information about a Unicode character. This class cannot be inherited.|  
|<xref:System.Globalization.ChineseLunisolarCalendar>|Represents time in divisions; such as months; days; and years. Years are calculated using the Chinese calendar; while days and months are calculated using the lunisolar calendar.|  
|<xref:System.Globalization.CompareInfo>|Implements a set of methods for culture-sensitive string comparisons.|  
|<xref:System.Globalization.CompareOptions>|Defines the string comparison options to use with CompareInfo.|  
|<xref:System.Globalization.CultureInfo>|Provides information about a specific culture (called a "locale" for unmanaged code development). The information includes the names for the culture, the writing system, the calendar used, and formatting for dates and sort strings.|  
|<xref:System.Globalization.CultureNotFoundException>|The exception thrown when a method is invoked which attempts to construct a culture that is not available on the machine.|  
|<xref:System.Globalization.DateTimeFormatInfo>|Defines how System.DateTime values are formatted and displayed, depending on the culture.|  
|<xref:System.Globalization.DateTimeStyles>|Defines the formatting options that customize string parsing for some date and time parsing methods.|  
|<xref:System.Globalization.EastAsianLunisolarCalendar>|Represents a calendar that divides time into months; days; years; and eras; and has dates that are based on cycles of the sun and the moon.|  
|<xref:System.Globalization.GlobalizationExtensions>|For more information, see <xref:System.Globalization.GlobalizationExtensions>.|  
|<xref:System.Globalization.GregorianCalendar>|Represents the Gregorian calendar.|  
|<xref:System.Globalization.GregorianCalendarTypes>|Defines the different language versions of the Gregorian calendar.|  
|<xref:System.Globalization.HebrewCalendar>|Represents the Hebrew calendar.|  
|<xref:System.Globalization.HijriCalendar>|Represents the Hijri calendar.|  
|<xref:System.Globalization.IdnMapping>|Supports the use of non-ASCII characters for Internet domain names. This class cannot be inherited.|  
|<xref:System.Globalization.JapaneseCalendar>|Represents the Japanese calendar.|  
|<xref:System.Globalization.JapaneseLunisolarCalendar>|Represents time in divisions; such as months; days; and years. Years are calculated as for the Japanese calendar; while days and months are calculated using the lunisolar calendar.|  
|<xref:System.Globalization.JulianCalendar>|Represents the Julian calendar.|  
|<xref:System.Globalization.KoreanCalendar>|Represents the Korean calendar.|  
|<xref:System.Globalization.KoreanLunisolarCalendar>|Represents time in divisions; such as months; days; and years. Years are calculated using the Gregorian calendar; while days and months are calculated using the lunisolar calendar.|  
|<xref:System.Globalization.NumberFormatInfo>|Defines how numeric values are formatted and displayed, depending on the culture.|  
|<xref:System.Globalization.NumberStyles>|Determines the styles permitted in numeric string arguments that are passed to the Parse and TryParse methods of the integral and floating-point numeric types.|  
|<xref:System.Globalization.PersianCalendar>|Represents the Persian calendar.|  
|<xref:System.Globalization.RegionInfo>|Contains information about the country/region.|  
|<xref:System.Globalization.StringInfo>|Provides functionality to split a string into text elements and to iterate through those text elements.|  
|<xref:System.Globalization.TaiwanCalendar>|the Taiwan calendar.|  
|<xref:System.Globalization.TaiwanLunisolarCalendar>|Represents the Taiwan lunisolar calendar. As for the Taiwan calendar; years are calculated using the Gregorian calendar; while days and months are calculated using the lunisolar calendar.|  
|<xref:System.Globalization.TextElementEnumerator>|Enumerates the text elements of a string.|  
|<xref:System.Globalization.TextInfo>|Defines text properties and behaviors, such as casing, that are specific to a writing system.|  
|<xref:System.Globalization.ThaiBuddhistCalendar>|Represents the Thai Buddhist calendar.|  
|<xref:System.Globalization.TimeSpanStyles>|Defines the formatting options that customize string parsing for the ParseExact and TryParseExact methods.|  
|<xref:System.Globalization.UmAlQuraCalendar>|Represents the Saudi Hijri (Um Al Qura) calendar.|  
|<xref:System.Globalization.UnicodeCategory>|Defines the Unicode category of a character.|  
  
## See Also  
 [.NET for Windows apps](../net-uwp/dotnet-for-windows-apps.md)