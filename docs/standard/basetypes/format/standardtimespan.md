---
title: Standard TimeSpan Format Strings
description: Standard TimeSpan Format Strings
keywords: .NET, .NET Core
author: shoag
manager: wpickett
ms.date: 06/20/2016
ms.topic: article
ms.prod: .net-core
ms.technology: .net-core-technologies
ms.devlang: dotnet
ms.assetid: df592c05-fb7f-47a9-b615-2cc696b111d7
---

# Standard TimeSpan Format Strings

A standard [TimeSpan](https://docs.microsoft.com/dotnet/core/api/System.TimeSpan) format string uses a single format specifier to define the text representation of a [TimeSpan](https://docs.microsoft.com/dotnet/core/api/System.TimeSpan) value that results from a formatting operation. Any format string that contains more than one character, including white space, is interpreted as a custom [TimeSpan](https://docs.microsoft.com/dotnet/core/api/System.TimeSpan) format string. For more information, see [Custom TimeSpan Format Strings](customtimespan.md).

The string representations of [TimeSpan](https://docs.microsoft.com/dotnet/core/api/System.TimeSpan) values are produced by calls to the overloads of the [TimeSpan.ToString](https://docs.microsoft.com/dotnet/core/api/System.TimeSpan#System_TimeSpan_ToString) method, as well as by methods that support composite formatting, such as [String.Format](https://docs.microsoft.com/dotnet/core/api/System.String#System_String_Format_System_IFormatProvider_System_String_System_Object_). For more information, see [Formatting Types](../index.md) and [Composite Formatting](compositeformat.md). The following example illustrates the use of standard format strings in formatting operations

```csharp
using System;

public class Example
{
   public static void Main()
   {
      TimeSpan duration = new TimeSpan(1, 12, 23, 62);
      string output = "Time of Travel: " + duration.ToString("c");
      Console.WriteLine(output);

      Console.WriteLine("Time of Travel: {0:c}", duration); 
   }
}
// The example displays the following output:
//       Time of Travel: 1.12:24:02
//       Time of Travel: 1.12:24:02
```

Standard [TimeSpan](https://docs.microsoft.com/dotnet/core/api/System.TimeSpan) format strings are also used by the [TimeSpan.ParseExact](https://docs.microsoft.com/dotnet/core/api/System.TimeSpan#System_TimeSpan_ParseExact_System_String_System_String_System_IFormatProvider_) and [TimeSpan.TryParseExact](https://docs.microsoft.com/dotnet/core/api/System.TimeSpan#System_TimeSpan_TryParseExact_System_String_System_String_System_IFormatProvider_System_Globalization_TimeSpanStyles_System_TimeSpan__) methods to define the required format of input strings for parsing operations. (Parsing converts the string representation of a value to that value.) The following example illustrates the use of standard format strings in parsing operations.

```csharp
using System;

public class Example
{
   public static void Main()
   {
      string value = "1.03:14:56.1667";
      TimeSpan interval;
      try {
         interval = TimeSpan.ParseExact(value, "c", null);
         Console.WriteLine("Converted '{0}' to {1}", value, interval);
      }   
      catch (FormatException) {
         Console.WriteLine("{0}: Bad Format", value);
      }   
      catch (OverflowException) {
         Console.WriteLine("{0}: Out of Range", value);
      }

      if (TimeSpan.TryParseExact(value, "c", null, out interval))
         Console.WriteLine("Converted '{0}' to {1}", value, interval);
      else
         Console.WriteLine("Unable to convert {0} to a time interval.", 
                           value);
   }
}
// The example displays the following output:
//       Converted '1.03:14:56.1667' to 1.03:14:56.1667000
//       Converted '1.03:14:56.1667' to 1.03:14:56.1667000
```

The following table lists the standard time interval format specifiers.

Format specifier | Name | Description | Examples
---------------- | ---- | ----------- | --------
"c" | Constant (invariant) format | This specifier is not culture-sensitive. It takes the form [-][d’.’]hh’:’mm’:’ss[‘.’fffffff]. (The "t" and "T" format strings produce the same results.) | `TimeSpan.Zero -> 00:00:00`; `New TimeSpan(0, 0, 30, 0) -> 00:30:00`; `New TimeSpan(3, 17, 25, 30, 500) -> 3.17:25:30.5000000`
"g" | General short format | This specifier outputs only what is needed. It is culture-sensitive and takes the form [-][d’:’]h’:’mm’:’ss[.FFFFFFF]. | `New TimeSpan(1, 3, 16, 50, 500) -> 1:3:16:50.5 (en-US)`; `New TimeSpan(1, 3, 16, 50, 500) -> 1:3:16:50,5 (fr-FR)`; `New TimeSpan(1, 3, 16, 50, 599) -> 1:3:16:50.599 (en-US)`; `New TimeSpan(1, 3, 16, 50, 599) -> 1:3:16:50,599 (fr-FR)`
"G" | General long format | This specifier always outputs days and seven fractional digits. It is culture-sensitive and takes the form [-]d’:’hh’:’mm’:’ss.fffffff. | `New TimeSpan(18, 30, 0) -> 0:18:30:00.0000000 (en-US)`; `New TimeSpan(18, 30, 0) -> 0:18:30:00,0000000 (fr-FR)` 

## The Constant ("c") Format Specifier

The "c" format specifier returns the string representation of a [TimeSpan](https://docs.microsoft.com/dotnet/core/api/System.TimeSpan) value in the following form:

[-][_d_.]_hh_:_mm_:_ss_[._fffffff_]

Elements in square brackets ([ and ]) are optional. The period (.) and colon (:) are literal symbols. The following table describes the remaining elements. 

Element | Description
------- | -----------
- | An optional negative sign, which indicates a negative time interval.
*d* | The optional number of days, with no leading zeros.
*hh* | The number of hours, which ranges from "00" to "23".
*mm* | The number of minutes, which ranges from "00" to "59".
*ss* | The number of seconds, which ranges from "0" to "59".
*fffffff* | The optional fractional portion of a second. Its value can range from "0000001" (one tick, or one ten-millionth of a second) to "9999999" (9,999,999 ten-millionths of a second, or one second less one tick). 

Unlike the "g" and "G" format specifiers, the "c" format specifier is not culture-sensitive. It produces the string representation of a [TimeSpan](https://docs.microsoft.com/dotnet/core/api/System.TimeSpan) value that is invariant and that is common to all previous versions of the .NET Framework before the .NET Framework 4. "c" is the default [TimeSpan](https://docs.microsoft.com/dotnet/core/api/System.TimeSpan) format string; the [TimeSpan.ToString](https://docs.microsoft.com/dotnet/core/api/System.TimeSpan#System_TimeSpan_ToString) method formats a time interval value by using the "c" format string.

> **Note**
>
> [TimeSpan](https://docs.microsoft.com/dotnet/core/api/System.TimeSpan) also supports the "t" and "T" standard format strings, which are identical in behavior to the "c" standard format string.

The following example instantiates two [TimeSpan](https://docs.microsoft.com/dotnet/core/api/System.TimeSpan) objects, uses them to perform arithmetic operations, and displays the result. In each case, it uses composite formatting to display the [TimeSpan](https://docs.microsoft.com/dotnet/core/api/System.TimeSpan) value by using the "c" format specifier.

```csharp
using System;

public class Example
{
   public static void Main()
   {
      TimeSpan interval1, interval2;
      interval1 = new TimeSpan(7, 45, 16);
      interval2 = new TimeSpan(18, 12, 38);

      Console.WriteLine("{0:c} - {1:c} = {2:c}", interval1, 
                        interval2, interval1 - interval2);
      Console.WriteLine("{0:c} + {1:c} = {2:c}", interval1, 
                        interval2, interval1 + interval2);

      interval1 = new TimeSpan(0, 0, 1, 14, 365);
      interval2 = TimeSpan.FromTicks(2143756);  
      Console.WriteLine("{0:c} + {1:c} = {2:c}", interval1, 
                        interval2, interval1 + interval2);
   }
}
// The example displays the following output:
//       07:45:16 - 18:12:38 = -10:27:22
//       07:45:16 + 18:12:38 = 1.01:57:54
//       00:01:14.3650000 + 00:00:00.2143756 = 00:01:14.5793756
```

## The General Short ("g") Format Specifier

The "g" [TimeSpan](https://docs.microsoft.com/dotnet/core/api/System.TimeSpan) format specifier returns the string representation of a [TimeSpan](https://docs.microsoft.com/dotnet/core/api/System.TimeSpan) value in a compact form by including only the elements that are necessary. It has the following form:

[-][_d_:]_h_:_mm_:_ss_[._FFFFFFF_]

Elements in square brackets ([ and ]) are optional. The colon (:) is a literal symbol. The following table describes the remaining elements.

Element | Description
------- | -----------
- | An optional negative sign, which indicates a negative time interval.
*d* | The optional number of days, with no leading zeros.
*hh* | The number of hours, which ranges from "0" to "23", with no leading zeros. 
*mm* | The number of minutes, which ranges from "00" to "59".
*ss* | The number of seconds, which ranges from "0" to "59".
. | The fractional seconds separator.
*FFFFFFF* | The fractional seconds. As few digits as possible are displayed.

Like the "G" format specifier, the "g" format specifier is localized. Its fractional seconds separator is based on the current culture.

The following example instantiates two [TimeSpan](https://docs.microsoft.com/dotnet/core/api/System.TimeSpan) objects, uses them to perform arithmetic operations, and displays the result. In each case, it uses composite formatting to display the [TimeSpan](https://docs.microsoft.com/dotnet/core/api/System.TimeSpan) value by using the "g" format specifier. In addition, it formats the [TimeSpan](https://docs.microsoft.com/dotnet/core/api/System.TimeSpan) value by using the formatting conventions of the current system culture (which, in this case, is English - United States or en-US) and the French - France (fr-FR) culture.

```csharp
using System;
using System.Globalization;

public class Example
{
   public static void Main()
   {
      TimeSpan interval1, interval2;
      interval1 = new TimeSpan(7, 45, 16);
      interval2 = new TimeSpan(18, 12, 38);

      Console.WriteLine("{0:g} - {1:g} = {2:g}", interval1, 
                        interval2, interval1 - interval2);
      Console.WriteLine(String.Format(new CultureInfo("fr-FR"), 
                        "{0:g} + {1:g} = {2:g}", interval1, 
                        interval2, interval1 + interval2));

      interval1 = new TimeSpan(0, 0, 1, 14, 36);
      interval2 = TimeSpan.FromTicks(2143756);      
      Console.WriteLine("{0:g} + {1:g} = {2:g}", interval1, 
                        interval2, interval1 + interval2);
   }
}
// The example displays the following output:
//       7:45:16 - 18:12:38 = -10:27:22
//       7:45:16 + 18:12:38 = 1:1:57:54
//       0:01:14.036 + 0:00:00.2143756 = 0:01:14.2503756
```

## The General Long ("G") Format Specifier

The "G" [TimeSpan](https://docs.microsoft.com/dotnet/core/api/System.TimeSpan) format specifier returns the string representation of a [TimeSpan](https://docs.microsoft.com/dotnet/core/api/System.TimeSpan) value in a long form that always includes both days and fractional seconds. The string that results from the "G" standard format specifier has the following form:

[-]*d*:*hh*:*mm*:*ss*.*fffffff*

Elements in square brackets ([ and ]) are optional. The colon (:) is a literal symbol. The following table describes the remaining elements.

Element | Description
------- | -----------
- | An optional negative sign, which indicates a negative time interval.
*d* | The optional number of days, with no leading zeros.
*hh* | The number of hours, which ranges from "0" to "23". 
*mm* | The number of minutes, which ranges from "00" to "59".
*ss* | The number of seconds, which ranges from "0" to "59".
. | The fractional seconds separator.
*fffffff* | The fractional seconds.

Like the "G" format specifier, the "g" format specifier is localized. Its fractional seconds separator is based on the current culture.

The following example instantiates two [TimeSpan](https://docs.microsoft.com/dotnet/core/api/System.TimeSpan) objects, uses them to perform arithmetic operations, and displays the result. In each case, it uses composite formatting to display the [TimeSpan](https://docs.microsoft.com/dotnet/core/api/System.TimeSpan) value by using the "G" format specifier. In addition, it formats the [TimeSpan](https://docs.microsoft.com/dotnet/core/api/System.TimeSpan) value by using the formatting conventions of the current system culture (which, in this case, is English - United States or en-US) and the French - France (fr-FR) culture. 

```csharp
using System;
using System.Globalization;

public class Example
{
   public static void Main()
   {
      TimeSpan interval1, interval2;
      interval1 = new TimeSpan(7, 45, 16);
      interval2 = new TimeSpan(18, 12, 38);

      Console.WriteLine("{0:G} - {1:G} = {2:G}", interval1, 
                        interval2, interval1 - interval2);
      Console.WriteLine(String.Format(new CultureInfo("fr-FR"), 
                        "{0:G} + {1:G} = {2:G}", interval1, 
                        interval2, interval1 + interval2));

      interval1 = new TimeSpan(0, 0, 1, 14, 36);
      interval2 = TimeSpan.FromTicks(2143756);      
      Console.WriteLine("{0:G} + {1:G} = {2:G}", interval1, 
                        interval2, interval1 + interval2);
   }
}
// The example displays the following output:
//       0:07:45:16.0000000 - 0:18:12:38.0000000 = -0:10:27:22.0000000
//       0:07:45:16,0000000 + 0:18:12:38,0000000 = 1:01:57:54,0000000
//       0:00:01:14.0360000 + 0:00:00:00.2143756 = 0:00:01:14.2503756
```

## See Also

[Composite Formatting](compositeformat.md)


