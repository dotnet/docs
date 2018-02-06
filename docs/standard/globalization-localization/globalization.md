---
title: "Globalization"
ms.custom: ""
ms.date: "03/30/2017"
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
  - "globalization [.NET Framework], about globalization"
  - "global applications, globalization"
  - "international applications [.NET Framework], globalization"
  - "world-ready applications, globalization"
  - "application development [.NET Framework], globalization"
  - "culture, globalization"
ms.assetid: 4e919934-6b19-42f2-b770-275a4fae87c9
caps.latest.revision: 15
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Globalization
Globalization involves designing and developing a world-ready app that supports localized interfaces and regional data for users in multiple cultures. Before beginning the design phase, you should determine which cultures your app will support. Although an app targets a single culture or region as its default, you can design and write it so that it can easily be extended to users in other cultures or regions.  
  
 As developers, we all have assumptions about user interfaces and data that are formed by our cultures. For example, for an English-speaking developer in the United States, serializing date and time data as a string in the format `MM/dd/yyyy hh:mm:ss` seems perfectly reasonable. However, deserializing that string on a system in a different culture is likely to throw a <xref:System.FormatException> exception or produce inaccurate data. Globalization enables us to identify such culture-specific assumptions and ensure that they do not affect our app's design or code.  
  
 The following sections discuss some of the major issues you should consider and the best practices you can follow when handling strings, date and time values, and numeric values in a globalized app.  
  
-   [Handling Strings](../../../docs/standard/globalization-localization/globalization.md#HandlingStrings)  
  
    -   [Use Unicode Internally](../../../docs/standard/globalization-localization/globalization.md#Strings_Unicode)  
  
    -   [Use Resource Files](../../../docs/standard/globalization-localization/globalization.md#Strings_Resources)  
  
    -   [Searching and Comparing Strings ](../../../docs/standard/globalization-localization/globalization.md#Strings_Searching)  
  
    -   [Testing Strings for Equality](../../../docs/standard/globalization-localization/globalization.md#Strings_Equality)  
  
    -   [Ordering and Sorting Strings ](../../../docs/standard/globalization-localization/globalization.md#Strings_Ordering)  
  
    -   [Avoid String Concatenation](../../../docs/standard/globalization-localization/globalization.md#Strings_Concat)  
  
-   [Handling Dates and Times](../../../docs/standard/globalization-localization/globalization.md#DatesAndTimes)  
  
    -   [Persisting Dates and Times](../../../docs/standard/globalization-localization/globalization.md#DatesAndTimes_Persist)  
  
    -   [Displaying Dates and Times](../../../docs/standard/globalization-localization/globalization.md#DatesAndTimes_Display)  
  
    -   [Serialization and Time Zone Awareness](../../../docs/standard/globalization-localization/globalization.md#DatesAndTimes_TimeZones)  
  
    -   [Performing Date and Time Arithmetic](../../../docs/standard/globalization-localization/globalization.md#DatesAndTimes_Arithmetic)  
  
-   [Handling Numeric Values](../../../docs/standard/globalization-localization/globalization.md#Numbers)  
  
    -   [Displaying Numeric Values](../../../docs/standard/globalization-localization/globalization.md#Numbers_Display)  
  
    -   [Persisting Numeric Values](../../../docs/standard/globalization-localization/globalization.md#Numbers_Persist)  
  
-   [Working with Culture-Specific Settings](../../../docs/standard/globalization-localization/globalization.md#Cultures)  
  
<a name="HandlingStrings"></a>   
## Handling Strings  
 The handling of characters and strings is a central focus of globalization, because each culture or region may use different characters and character sets and sort them differently. This section provides recommendations for using strings in globalized apps.  
  
<a name="Strings_Unicode"></a>   
### Use Unicode Internally  
 By default, the .NET Framework uses Unicode strings. A Unicode string consists of zero, one, or more <xref:System.Char> objects, each of which represents a UTF-16 code unit. There is a Unicode representation for almost every character in every character set in use throughout the world.  
  
 Many applications and operating systems, including the Windows operating system, can use also use code pages to represent character sets. Code pages typically contain the standard ASCII values from 0x00 through 0x7F and map other characters to the remaining values from 0x80 through 0xFF. The interpretation of values from 0x80 through 0xFF depends on the specific code page. Because of this, you should avoid using code pages in a globalized app if possible.  
  
 The following example illustrates the dangers of interpreting code page data when the default code page on a system is different from the code page on which the data was saved. (To simulate this scenario, the example explicitly specifies different code pages.) First, the example defines an array that consists of the uppercase characters of the Greek alphabet. It encodes them into a byte array by using code page 737 (also known as MS-DOS Greek) and saves the byte array to a file. If the file is retrieved and its byte array is decoded by using code page 737, the original characters are restored. However, if the file is retrieved and its byte array is decoded by using code page 1252 (or Windows-1252, which represents characters in the Latin alphabet), the original characters are lost.  
  
 [!code-csharp[Conceptual.Globalization#1](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.globalization/cs/codepages1.cs#1)]
 [!code-vb[Conceptual.Globalization#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.globalization/vb/codepages1.vb#1)]  
  
 The use of Unicode ensures that the same code units always map to the same characters, and that the same characters always map to the same byte arrays.  
  
<a name="Strings_Resources"></a>   
### Use Resource Files  
 Even if you are developing an app that targets a single culture or region, you should use resource files to store strings and other resources that are displayed in the user interface. You should never add them directly to your code. Using resource files has a number of advantages:  
  
-   All the strings are in a single location. You don't have to search throughout your source code to identify strings to modify for a specific language or culture.  
  
-   There is no need to duplicate strings. Developers who don't use resource files often define the same string in multiple source code files. This duplication increases the probability that one or more instances will be overlooked when a string is modified.  
  
-   You can include non-string resources, such as images or binary data, in the resource file instead of storing them in a separate standalone file, so they can be retrieved easily.  
  
 Using resource files has particular advantages if you are creating a localized app. When you deploy resources in satellite assemblies, the common language runtime automatically selects a culture-appropriate resource based on the user's current UI culture as defined by the <xref:System.Globalization.CultureInfo.CurrentUICulture%2A?displayProperty=nameWithType> property. As long as you provide an appropriate culture-specific resource and correctly instantiate a <xref:System.Resources.ResourceManager> object or use a strongly typed resource class, the runtime handles the details of retrieving the appropriate resources.  
  
 For more information about creating resource files, see [Creating Resource Files](../../../docs/framework/resources/creating-resource-files-for-desktop-apps.md). For information about creating and deploying satellite assemblies, see [Creating Satellite Assemblies](../../../docs/framework/resources/creating-satellite-assemblies-for-desktop-apps.md) and [Packaging and Deploying Resources](../../../docs/framework/resources/packaging-and-deploying-resources-in-desktop-apps.md).  
  
<a name="Strings_Searching"></a>   
### Searching and Comparing Strings  
 Whenever possible, you should handle strings as entire strings instead of handling them as a series of individual characters. This is especially important when you sort or search for substrings, to prevent problems associated with parsing combined characters.  
  
> [!TIP]
>  You can use the <xref:System.Globalization.StringInfo> class to work with the text elements rather than the individual characters in a string.  
  
 In string searches and comparisons, a common mistake is to treat the string as a collection of characters, each of which is represented by a <xref:System.Char> object. In fact, a single character may be formed by one, two, or more <xref:System.Char> objects. Such characters are found most frequently in strings from cultures whose alphabets consist of characters outside the Unicode Basic Latin character range (U+0021 through U+007E). The following example tries to find the index of the LATIN CAPITAL LETTER A WITH GRAVE character (U+00C0) in a string. However, this character can be represented in two different ways: as a single code unit (U+00C0) or as a composite character (two code units: U+0021 and U+007E). In this case, the character is represented in the string instance by two <xref:System.Char> objects, U+0021 and U+007E. The example code calls the <xref:System.String.IndexOf%28System.Char%29?displayProperty=nameWithType> and <xref:System.String.IndexOf%28System.String%29?displayProperty=nameWithType> overloads to find the position of this character in the string instance, but these return different results. The first method call has a <xref:System.Char> argument; it performs an ordinal comparison and therefore cannot find a match. The second call has a <xref:System.String> argument; it performs a culture-sensitive comparison and therefore finds a match.  
  
 [!code-csharp[Conceptual.Globalization#18](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.globalization/cs/search1.cs#18)]
 [!code-vb[Conceptual.Globalization#18](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.globalization/vb/search1.vb#18)]  
  
 You can avoid some of the ambiguity of this example (calls to two similar overloads of a method returning different results) by calling an overload that includes a <xref:System.StringComparison> parameter, such as the <xref:System.String.IndexOf%28System.String%2CSystem.StringComparison%29?displayProperty=nameWithType> or <xref:System.String.LastIndexOf%28System.String%2CSystem.StringComparison%29?displayProperty=nameWithType> method.  
  
 However, searches are not always culture-sensitive. If the purpose of the search is to make a security decision or to allow or disallow access to some resource, the comparison should be ordinal, as discussed in the next section.  
  
<a name="Strings_Equality"></a>   
### Testing Strings for Equality  
 If you want to test two strings for equality rather than determining how they compare in the sort order, use the <xref:System.String.Equals%2A?displayProperty=nameWithType> method instead of a string comparison method such as <xref:System.String.Compare%2A?displayProperty=nameWithType> or <xref:System.Globalization.CompareInfo.Compare%2A?displayProperty=nameWithType>.  
  
 Comparisons for equality are typically performed to access some resource conditionally. For example, you might perform a comparison for equality to verify a password or to confirm that a file exists. Such non-linguistic comparisons should always be ordinal rather than culture-sensitive. In general, you should call the instance <xref:System.String.Equals%28System.String%2CSystem.StringComparison%29?displayProperty=nameWithType> method or the static <xref:System.String.Equals%28System.String%2CSystem.String%2CSystem.StringComparison%29?displayProperty=nameWithType> method with a value of <xref:System.StringComparison.Ordinal?displayProperty=nameWithType> for strings such as passwords, and a value of <xref:System.StringComparison.OrdinalIgnoreCase?displayProperty=nameWithType> for strings such as file names or URIs.  
  
 Comparisons for equality sometimes involve searches or substring comparisons rather than calls to the <xref:System.String.Equals%2A?displayProperty=nameWithType> method. In some cases, you may use a substring search to determine whether that substring equals another string. If the purpose of this comparison is non-linguistic, the search should also be ordinal rather than culture-sensitive.  
  
 The following example illustrates the danger of a culture-sensitive search on non-linguistic data. The `AccessesFileSystem` method is designed to prohibit file system access for URIs that begin with the substring "FILE". To do this, it performs a culture-sensitive, case-insensitive comparison of the beginning of the URI with the string "FILE". Because a URI that accesses the file system can begin with either "FILE:" or "file:", the implicit assumption is that that "i" (U+0069) is always the lowercase equivalent of "I" (U+0049). However, in Turkish and Azerbaijani, the uppercase version of "i" is "İ" (U+0130). Because of this discrepancy, the culture-sensitive comparison allows file system access when it should be prohibited.  
  
 [!code-csharp[Conceptual.Globalization#12](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.globalization/cs/equals1.cs#12)]
 [!code-vb[Conceptual.Globalization#12](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.globalization/vb/equals1.vb#12)]  
  
 You can avoid this problem by performing an ordinal comparison that ignores case, as the following example shows.  
  
 [!code-csharp[Conceptual.Globalization#13](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.globalization/cs/equals2.cs#13)]
 [!code-vb[Conceptual.Globalization#13](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.globalization/vb/equals2.vb#13)]  
  
<a name="Strings_Ordering"></a>   
### Ordering and Sorting Strings  
 Typically, ordered strings that are to be displayed in the user interface should be sorted based on culture. For the most part, such string comparisons are handled implicitly by the .NET Framework when you call a method that sorts strings, such as <xref:System.Array.Sort%2A?displayProperty=nameWithType> or <xref:System.Collections.Generic.List%601.Sort%2A?displayProperty=nameWithType>. By default, strings are sorted by using the sorting conventions of the current culture. The following example illustrates the difference when an array of strings is sorted by using the conventions of the English (United States) culture and the Swedish (Sweden) culture.  
  
 [!code-csharp[Conceptual.Globalization#14](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.globalization/cs/sort1.cs#14)]
 [!code-vb[Conceptual.Globalization#14](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.globalization/vb/sort1.vb#14)]  
  
 Culture-sensitive string comparison is defined by the <xref:System.Globalization.CompareInfo> object, which is returned by each culture's <xref:System.Globalization.CultureInfo.CompareInfo%2A?displayProperty=nameWithType> property. Culture-sensitive string comparisons that use the <xref:System.String.Compare%2A?displayProperty=nameWithType> method overloads also use the <xref:System.Globalization.CompareInfo> object.  
  
 The .NET Framework uses tables to perform culture-sensitive sorts on string data. The content of these tables, which contain data on sort weights and string normalization, is determined by the version of the Unicode standard implemented by a particular version of the .NET Framework. The following table lists the versions of Unicode implemented by the specified versions of the .NET Framework. Note that this list of supported Unicode versions applies to character comparison and sorting only; it does not apply to classification of Unicode characters by category. For more information, see the "Strings and The Unicode Standard" section in the <xref:System.String> article.  
  
|.NET Framework version|Operating system|Unicode version|  
|----------------------------|----------------------|---------------------|  
|.NET Framework 2.0|All operating systems|Unicode 4.1|  
|.NET Framework 3.0|All operating systems|Unicode 4.1|  
|.NET Framework 3.5|All operating systems|Unicode 4.1|  
|.NET Framework 4|All operating systems|Unicode 5.0|  
|.NET Framework 4.5|[!INCLUDE[win7](../../../includes/win7-md.md)]|Unicode 5.0|  
|.NET Framework 4.5|[!INCLUDE[win8](../../../includes/win8-md.md)]|Unicode 6.0|  
  
 In the [!INCLUDE[net_v45](../../../includes/net-v45-md.md)], string comparison and sorting depends on the operating system. The [!INCLUDE[net_v45](../../../includes/net-v45-md.md)] running on [!INCLUDE[win7](../../../includes/win7-md.md)] retrieves data from its own tables that implement Unicode 5.0. The [!INCLUDE[net_v45](../../../includes/net-v45-md.md)] running on [!INCLUDE[win8](../../../includes/win8-md.md)] retrieves data from operating system tables that implement Unicode 6.0. If you serialize culture-sensitive sorted data, you can use the <xref:System.Globalization.SortVersion> class to determine when your serialized data needs to be sorted so that it is consistent with the .NET Framework and the operating system's sort order. For an example, see the <xref:System.Globalization.SortVersion> class topic.  
  
 If your app performs extensive culture-specific sorts of string data, you can work with the <xref:System.Globalization.SortKey> class to compare strings. A sort key reflects the culture-specific sort weights, including the alphabetic, case, and diacritic weights of a particular string. Because comparisons using sort keys are binary, they are faster than comparisons that use a <xref:System.Globalization.CompareInfo> object either implicitly or explicitly. You create a culture-specific sort key for a particular string by passing the string to the <xref:System.Globalization.CompareInfo.GetSortKey%2A?displayProperty=nameWithType> method.  
  
 The following example is similar to the previous example. However, instead of calling the <xref:System.Array.Sort%28System.Array%29?displayProperty=nameWithType> method, which implicitly calls the <xref:System.Globalization.CompareInfo.Compare%2A?displayProperty=nameWithType> method, it defines an <xref:System.Collections.Generic.IComparer%601?displayProperty=nameWithType> implementation that compares sort keys, which it instantiates and passes to the <xref:System.Array.Sort%60%601%28%60%600%5B%5D%2CSystem.Collections.Generic.IComparer%7B%60%600%7D%29?displayProperty=nameWithType> method.  
  
 [!code-csharp[Conceptual.Globalization#15](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.globalization/cs/sortkey1.cs#15)]
 [!code-vb[Conceptual.Globalization#15](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.globalization/vb/sortkey1.vb#15)]  
  
<a name="Strings_Concat"></a>   
### Avoid String Concatenation  
 If at all possible, avoid using composite strings that are built at run time from concatenated phrases. Composite strings are difficult to localize, because they often assume a grammatical order in the app's original language that does not apply to other localized languages.  
  
<a name="DatesAndTimes"></a>   
## Handling Dates and Times  
 How you handle date and time values depends on whether they are displayed in the user interface or persisted. This section examines both usages. It also discusses how you can handle time zone differences and arithmetic operations when working with dates and times.  
  
<a name="DatesAndTimes_Display"></a>   
### Displaying Dates and Times  
 Typically, when dates and times are displayed in the user interface, you should use the formatting conventions of the user's culture, which is defined by the <xref:System.Globalization.CultureInfo.CurrentCulture%2A?displayProperty=nameWithType> property and by the <xref:System.Globalization.DateTimeFormatInfo> object returned by the `CultureInfo.CurrentCulture.DateTimeFormat` property. The formatting conventions of the current culture are automatically used when you format a date by using any of these methods:  
  
-   The parameterless <xref:System.DateTime.ToString?displayProperty=nameWithType> method  
  
-   The <xref:System.DateTime.ToString%28System.String%29?displayProperty=nameWithType> method, which includes a format string  
  
-   The parameterless <xref:System.DateTimeOffset.ToString?displayProperty=nameWithType> method  
  
-   The <xref:System.DateTimeOffset.ToString%28System.String%29?displayProperty=nameWithType>, which includes a format string  
  
-   The [composite formatting](../../../docs/standard/base-types/composite-formatting.md) feature, when it is used with dates  
  
 The following example displays sunrise and sunset data twice for October 11, 2012. It first sets the current culture to Croatian (Croatia), and then to English (Great Britain). In each case, the dates and times are displayed in the format that is appropriate for that culture.  
  
 [!code-csharp[Conceptual.Globalization#2](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.globalization/cs/dates1.cs#2)]
 [!code-vb[Conceptual.Globalization#2](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.globalization/vb/dates1.vb#2)]  
  
<a name="DatesAndTimes_Persist"></a>   
### Persisting Dates and Times  
 You should never persist date and time data in a format that can vary by culture. This is a common programming error that results in either corrupted data or a run-time exception. The following example serializes two dates, January 9, 2013 and August 18, 2013, as strings by using the formatting conventions of the English (United States) culture. When the data is retrieved and parsed by using the conventions of the English (United States) culture, it is successfully restored. However, when it is retrieved and parsed by using the conventions of the English (United Kingdom) culture, the first date is wrongly interpreted as September 1, and the second fails to parse because the Gregorian calendar does not have an eighteenth month.  
  
 [!code-csharp[Conceptual.Globalization#3](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.globalization/cs/dates2.cs#3)]
 [!code-vb[Conceptual.Globalization#3](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.globalization/vb/dates2.vb#3)]  
  
 You can avoid this problem in any of three ways:  
  
-   Serialize the date and time in binary format rather than as a string.  
  
-   Save and parse the string representation of the date and time by using a custom format string that is the same regardless of the user's culture.  
  
-   Save the string by using the formatting conventions of the invariant culture.  
  
 The following example illustrates the last approach. It uses the formatting conventions of the invariant culture returned by the static <xref:System.Globalization.CultureInfo.InvariantCulture%2A?displayProperty=nameWithType> property.  
  
 [!code-csharp[Conceptual.Globalization#4](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.globalization/cs/dates3.cs#4)]
 [!code-vb[Conceptual.Globalization#4](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.globalization/vb/dates3.vb#4)]  
  
<a name="DatesAndTimes_TimeZones"></a>   
### Serialization and Time Zone Awareness  
 A date and time value can have multiple interpretations, ranging from a general time ("The stores open on January 2, 2013, at 9:00 A.M.") to a specific moment in time ("Date of birth: January 2, 2013 6:32:00 A.M."). When a time value represents a specific moment in time and you restore it from a serialized value, you should ensure that it represents the same moment in time regardless of the user's geographical location or time zone.  
  
 The following example illustrates this problem. It saves a single local date and time value as a string in three [standard formats](../../../docs/standard/base-types/standard-date-and-time-format-strings.md) ("G" for general date long time, "s" for sortable date/time, and "o" for round-trip date/time) as well as in binary format.  
  
 [!code-csharp[Conceptual.Globalization#10](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.globalization/cs/dates4.cs#10)]
 [!code-vb[Conceptual.Globalization#10](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.globalization/vb/dates4.vb#10)]  
  
 When the data is restored on a system in the same time zone as the system on which it was serialized, the deserialized date and time values accurately reflect the original value, as the output shows:  
  
```  
'3/30/2013 6:00:00 PM' --> 3/30/2013 6:00:00 PM Unspecified  
'2013-03-30T18:00:00' --> 3/30/2013 6:00:00 PM Unspecified  
'2013-03-30T18:00:00.0000000-07:00' --> 3/30/2013 6:00:00 PM Local  
  
3/30/2013 6:00:00 PM Local  
```  
  
 However, if you restore the data on a system in a different time zone, only the date and time value that was formatted with the "o" (round-trip) standard format string preserves time zone information and therefore represents the same instant in time. Here's the output when the date and time data is restored on a system in the Romance Standard Time zone:  
  
```  
'3/30/2013 6:00:00 PM' --> 3/30/2013 6:00:00 PM Unspecified  
'2013-03-30T18:00:00' --> 3/30/2013 6:00:00 PM Unspecified  
'2013-03-30T18:00:00.0000000-07:00' --> 3/31/2013 3:00:00 AM Local  
  
3/30/2013 6:00:00 PM Local  
```  
  
 To accurately reflect a date and time value that represents a single moment of time regardless of the time zone of the system on which the data is deserialized, you can do any of the following:  
  
-   Save the value as a string by using the "o" (round-trip) standard format string. Then deserialize it on the target system.  
  
-   Convert it to UTC and save it as a string by using the "r" (RFC1123) standard format string. Then deserialize it on the target system and convert it to local time.  
  
-   Convert it to UTC and save it as a string by using the "u" (universal sortable) standard format string. Then deserialize it on the target system and convert it to local time.  
  
-   Convert it to UTC and save it in binary format. Then deserialize it on the target system and convert it to local time.  
  
 The following example illustrates each technique.  
  
 [!code-csharp[Conceptual.Globalization#11](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.globalization/cs/dates8.cs#11)]
 [!code-vb[Conceptual.Globalization#11](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.globalization/vb/dates8.vb#11)]  
  
 When the data is serialized on a system in the Pacific Standard Time zone and deserialized on a system in the Romance Standard Time zone, the example displays the following output:  
  
```  
'2013-03-30T18:00:00.0000000-07:00' --> 3/31/2013 3:00:00 AM Local  
'Sun, 31 Mar 2013 01:00:00 GMT' --> 3/31/2013 3:00:00 AM Local  
'2013-03-31 01:00:00Z' --> 3/31/2013 3:00:00 AM Local  
  
3/31/2013 3:00:00 AM Local  
```  
  
 For more information, see [Converting Times Between Time Zones](../../../docs/standard/datetime/converting-between-time-zones.md).  
  
<a name="DatesAndTimes_Arithmetic"></a>   
### Performing Date and Time Arithmetic  
 Both the <xref:System.DateTime> and <xref:System.DateTimeOffset> types support arithmetic operations. You can calculate the difference between two date values, or you can add or subtract particular time intervals to or from a date value. However, arithmetic operations on date and time values do not take time zones and time zone adjustment rules into account. Because of this, date and time arithmetic on values that represent moments in time can return inaccurate results.  
  
 For example, the transition from Pacific Standard Time to Pacific Daylight Time occurs on the second Sunday of March, which is March 10 for the year 2013. As the following example shows, if you calculate the date and time that is 48 hours after March 9, 2013 at 10:30 A.M. on a system in the Pacific Standard Time zone, the result, March 11, 2013 at 10:30 A.M., does not take the intervening time adjustment into account.  
  
 [!code-csharp[Conceptual.Globalization#8](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.globalization/cs/dates5.cs#8)]
 [!code-vb[Conceptual.Globalization#8](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.globalization/vb/dates5.vb#8)]  
  
 To ensure that an arithmetic operation on date and time values produces accurate results, follow these steps:  
  
1.  Convert the time in the source time zone to UTC.  
  
2.  Perform the arithmetic operation.  
  
3.  If the result is a date and time value, convert it from UTC to the time in the source time zone.  
  
 The following example is similar to the previous example, except that it follows these three steps to correctly add 48 hours to March 9, 2013 at 10:30 A.M.  
  
 [!code-csharp[Conceptual.Globalization#9](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.globalization/cs/dates6.cs#9)]
 [!code-vb[Conceptual.Globalization#9](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.globalization/vb/dates6.vb#9)]  
  
 For more information, see [Performing Arithmetic Operations with Dates and Times](../../../docs/standard/datetime/performing-arithmetic-operations.md).  
  
### Using Culture-Sensitive Names for Date Elements  
 Your app may need to display the name of the month or the day of the week. To do this, code such as the following is common.  
  
 [!code-csharp[Conceptual.Globalization#19](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.globalization/cs/monthname1.cs#19)]
 [!code-vb[Conceptual.Globalization#19](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.globalization/vb/monthname1.vb#19)]  
  
 However, this code always returns the names of the days of the week in English. Code that extracts the name of the month is often even more inflexible. It frequently assumes a twelve-month calendar with names of months in a specific language.  
  
 By using [custom date and time format strings](../../../docs/standard/base-types/custom-date-and-time-format-strings.md) or the properties of the <xref:System.Globalization.DateTimeFormatInfo> object, it is easy to extract strings that reflect the names of days of the week or months in the user's culture, as the following example illustrates. It changes the current culture to French (France) and displays the name of the day of the week and the name of the month for July 1, 2013.  
  
 [!code-csharp[Conceptual.Globalization#20](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.globalization/cs/monthname2.cs#20)]
 [!code-vb[Conceptual.Globalization#20](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.globalization/vb/monthname2.vb#20)]  
  
<a name="Numbers"></a>   
## Handling Numeric Values  
 The handling of numbers depends on whether they are displayed in the user interface or persisted. This section examines both usages.  
  
> [!NOTE]
>  In parsing and formatting operations, the .NET Framework recognizes only the Basic Latin characters 0 through 9 (U+0030 through U+0039) as numeric digits.  
  
<a name="Numbers_Display"></a>   
### Displaying Numeric Values  
 Typically, when numbers are displayed in the user interface, you should use the formatting conventions of the user's culture, which is defined by the <xref:System.Globalization.CultureInfo.CurrentCulture%2A?displayProperty=nameWithType> property and by the <xref:System.Globalization.NumberFormatInfo> object returned by the `CultureInfo.CurrentCulture.NumberFormat` property. The formatting conventions of the current culture are automatically used when you format a date by using any of the following methods:  
  
-   The parameterless `ToString` method of any numeric type  
  
-   The `ToString(String)` method of any numeric type, which includes a format string as an argument  
  
-   The [composite formatting](../../../docs/standard/base-types/composite-formatting.md) feature, when it is used with numeric values  
  
 The following example displays the average temperature per month in Paris, France. It first sets the current culture to French (France) before displaying the data, and then sets it to English (United States). In each case, the month names and temperatures are displayed in the format that is appropriate for that culture. Note that the two cultures use different decimal separators in the temperature value. Also note that the example uses the "MMMM" custom date and time format string to display the full month name, and that it allocates the appropriate amount of space for the month name in the result string by determining the length of the longest month name in the <xref:System.Globalization.DateTimeFormatInfo.MonthNames%2A?displayProperty=nameWithType> array.  
  
 [!code-csharp[Conceptual.Globalization#5](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.globalization/cs/numbers1.cs#5)]
 [!code-vb[Conceptual.Globalization#5](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.globalization/vb/numbers1.vb#5)]  
  
<a name="Numbers_Persist"></a>   
### Persisting Numeric Values  
 You should never persist numeric data in a culture-specific format. This is a common programming error that results in either corrupted data or a run-time exception. The following example generates ten random floating-point numbers, and then serializes them as strings by using the formatting conventions of the English (United States) culture. When the data is retrieved and parsed by using the conventions of the English (United States) culture, it is successfully restored. However, when it is retrieved and parsed by using the conventions of the French (France) culture, none of the numbers can be parsed because the cultures use different decimal separators.  
  
 [!code-csharp[Conceptual.Globalization#6](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.globalization/cs/numbers2.cs#6)]
 [!code-vb[Conceptual.Globalization#6](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.globalization/vb/numbers2.vb#6)]  
  
 To avoid this problem, you can use one of these techniques:  
  
-   Save and parse the string representation of the number by using a custom format string that is the same regardless of the user's culture.  
  
-   Save the number as a string by using the formatting conventions of the invariant culture, which is returned by the <xref:System.Globalization.CultureInfo.InvariantCulture%2A?displayProperty=nameWithType> property.  
  
-   Serialize the number in binary instead of string format.  
  
 The following example illustrates the last approach. It serializes the array of <xref:System.Double> values, and then deserializes and displays them by using the formatting conventions of the English (United States) and French (France) cultures.  
  
 [!code-csharp[Conceptual.Globalization#7](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.globalization/cs/numbers3.cs#7)]
 [!code-vb[Conceptual.Globalization#7](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.globalization/vb/numbers3.vb#7)]  
  
 Serializing currency values is a special case. Because a currency value depends on the unit of currency in which it is expressed; it makes little sense to treat it as an independent numeric value. However, if you save a currency value as a formatted string that includes a currency symbol, it cannot be deserialized on a system whose default culture uses a different currency symbol, as the following example shows.  
  
 [!code-csharp[Conceptual.Globalization#16](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.globalization/cs/currency1.cs#16)]
 [!code-vb[Conceptual.Globalization#16](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.globalization/vb/currency1.vb#16)]  
  
 Instead, you should serialize the numeric value along with some cultural information, such as the name of the culture, so that the value and its currency symbol can be deserialized independently of the current culture. The following example does that by defining a `CurrencyValue` structure with two members: the <xref:System.Decimal> value and the name of the culture to which the value belongs.  
  
 [!code-csharp[Conceptual.Globalization#17](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.globalization/cs/currency2.cs#17)]
 [!code-vb[Conceptual.Globalization#17](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.globalization/vb/currency2.vb#17)]  
  
<a name="Cultures"></a>   
## Working with Culture-Specific Settings  
 In the .NET Framework, the <xref:System.Globalization.CultureInfo> class represents a particular culture or region. Some of its properties return objects that provide specific information about some aspect of a culture:  
  
-   The <xref:System.Globalization.CultureInfo.CompareInfo%2A?displayProperty=nameWithType> property returns a <xref:System.Globalization.CompareInfo> object that contains information about how the culture compares and orders strings.  
  
-   The <xref:System.Globalization.CultureInfo.DateTimeFormat%2A?displayProperty=nameWithType> property returns a <xref:System.Globalization.DateTimeFormatInfo> object that provides culture-specific information used in formatting date and time data.  
  
-   The <xref:System.Globalization.CultureInfo.NumberFormat%2A?displayProperty=nameWithType> property returns a <xref:System.Globalization.NumberFormatInfo> object that provides culture-specific information used in formatting numeric data.  
  
-   The <xref:System.Globalization.CultureInfo.TextInfo%2A?displayProperty=nameWithType> property returns a <xref:System.Globalization.TextInfo> object that provides information about the culture's writing system.  
  
 In general, do not make any assumptions about the values of specific <xref:System.Globalization.CultureInfo> properties and their related objects. Instead, you should view culture-specific data as subject to change, for these reasons:  
  
-   Individual property values are subject to change and revision over time, as data is corrected, better data becomes available, or culture-specific conventions change.  
  
-   Individual property values may vary across versions of the .NET Framework or operating system versions.  
  
-   The .NET Framework supports replacement cultures. This makes it possible to define a new custom culture that either supplements existing standard cultures or completely replaces an existing standard culture.  
  
-   The user can customize culture-specific settings by using the **Region and Language** app in Control Panel. When you instantiate a <xref:System.Globalization.CultureInfo> object, you can determine whether it reflects these user customizations by calling the <xref:System.Globalization.CultureInfo.%23ctor%28System.String%2CSystem.Boolean%29?displayProperty=nameWithType> constructor. Typically, for end-user apps, you should respect user preferences so that the user is presented with data in a format that he or she expects.  
  
## See Also  
 [Globalization and Localization](../../../docs/standard/globalization-localization/index.md)  
 [Best Practices for Using Strings](../../../docs/standard/base-types/best-practices-strings.md)
