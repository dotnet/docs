---
title: Standard TimeSpan format strings
description: Standard TimeSpan format strings
keywords: .NET, .NET Core
author: stevehoag
ms.author: shoag
ms.date: 07/26/2016
ms.topic: article
ms.prod: .net
ms.technology: dotnet-standard
ms.devlang: dotnet
ms.assetid: 4e0f02f1-4abd-47b5-8995-5c3ff45b0ce1
---

# Standard TimeSpan format strings

A standard [TimeSpan](xref:System.TimeSpan) format string uses a single format specifier to define the text representation of a [TimeSpan](xref:System.TimeSpan) value that results from a formatting operation. Any format string that contains more than one character, including white space, is interpreted as a custom [TimeSpan](xref:System.TimeSpan) format string. For more information, see [Custom TimeSpan Format Strings](custom-timespan.md).

The string representations of [TimeSpan](xref:System.TimeSpan) values are produced by calls to the overloads of the [TimeSpan.ToString](xref:System.TimeSpan.ToString) method, as well as by methods that support composite formatting, such as [String.Format](xref:System.String.Format(System.IFormatProvider,System.String,System.Object)). For more information, see [Formatting Types](formatting-types.md) and [Composite Formatting](composite-format.md). The following example illustrates the use of standard format strings in formatting operations

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

```vb
Module Example
   Public Sub Main()
      Dim duration As New TimeSpan(1, 12, 23, 62)
      Dim output As String = "Time of Travel: " + duration.ToString("c")
      Console.WriteLine(output)

      Console.WriteLine("Time of Travel: {0:c}", duration) 
   End Sub
End Module
' The example displays the following output:
'       Time of Travel: 1.12:24:02
'       Time of Travel: 1.12:24:02
```

Standard [TimeSpan](xref:System.TimeSpan) format strings are also used by the [TimeSpan.ParseExact](xref:System.TimeSpan.ParseExact(System.String,System.String,System.IFormatProvider)) and [TimeSpan.TryParseExact](xref:System.TimeSpan.TryParseExact(System.String,System.String,System.IFormatProvider,System.Globalization.TimeSpanStyles,System.TimeSpan@)) methods to define the required format of input strings for parsing operations. (Parsing converts the string representation of a value to that value.) The following example illustrates the use of standard format strings in parsing operations.

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

```vb
Module Example
   Public Sub Main()
      Dim value As String = "1.03:14:56.1667"
      Dim interval As TimeSpan
      Try
         interval = TimeSpan.ParseExact(value, "c", Nothing)
         Console.WriteLine("Converted '{0}' to {1}", value, interval)
      Catch e As FormatException
         Console.WriteLine("{0}: Bad Format", value)
      Catch e As OverflowException
         Console.WriteLine("{0}: Out of Range", value)
      End Try

      If TimeSpan.TryParseExact(value, "c", Nothing, interval) Then
         Console.WriteLine("Converted '{0}' to {1}", value, interval)
      Else
         Console.WriteLine("Unable to convert {0} to a time interval.", 
                           value)
      End If                
   End Sub
End Module
' The example displays the following output:
'       Converted '1.03:14:56.1667' to 1.03:14:56.1667000
'       Converted '1.03:14:56.1667' to 1.03:14:56.1667000
```

The following table lists the standard time interval format specifiers.

Format specifier | Name | Description | Examples
---------------- | ---- | ----------- | --------
"c" | Constant (invariant) format | This specifier is not culture-sensitive. It takes the form [-][d’.’]hh’:’mm’:’ss[‘.’fffffff]. (The "t" and "T" format strings produce the same results.) | `TimeSpan.Zero -> 00:00:00`; `New TimeSpan(0, 0, 30, 0) -> 00:30:00`; `New TimeSpan(3, 17, 25, 30, 500) -> 3.17:25:30.5000000`
"g" | General short format | This specifier outputs only what is needed. It is culture-sensitive and takes the form [-][d’:’]h’:’mm’:’ss[.FFFFFFF]. | `New TimeSpan(1, 3, 16, 50, 500) -> 1:3:16:50.5 (en-US)`; `New TimeSpan(1, 3, 16, 50, 500) -> 1:3:16:50,5 (fr-FR)`; `New TimeSpan(1, 3, 16, 50, 599) -> 1:3:16:50.599 (en-US)`; `New TimeSpan(1, 3, 16, 50, 599) -> 1:3:16:50,599 (fr-FR)`
"G" | General long format | This specifier always outputs days and seven fractional digits. It is culture-sensitive and takes the form [-]d’:’hh’:’mm’:’ss.fffffff. | `New TimeSpan(18, 30, 0) -> 0:18:30:00.0000000 (en-US)`; `New TimeSpan(18, 30, 0) -> 0:18:30:00,0000000 (fr-FR)` 

## The Constant ("c") Format Specifier

The "c" format specifier returns the string representation of a [TimeSpan](xref:System.TimeSpan) value in the following form:

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

Unlike the "g" and "G" format specifiers, the "c" format specifier is not culture-sensitive. It produces the string representation of a [TimeSpan](xref:System.TimeSpan) value that is invariant and that is common to all previous versions of the .NET Framework before the .NET Framework 4. "c" is the default [TimeSpan](xref:System.TimeSpan) format string; the [TimeSpan.ToString](xref:System.TimeSpan.ToString) method formats a time interval value by using the "c" format string.

> [!NOTE]
> [TimeSpan](xref:System.TimeSpan) also supports the "t" and "T" standard format strings, which are identical in behavior to the "c" standard format string.

The following example instantiates two [TimeSpan](xref:System.TimeSpan) objects, uses them to perform arithmetic operations, and displays the result. In each case, it uses composite formatting to display the [TimeSpan](xref:System.TimeSpan) value by using the "c" format specifier.

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

```vb
Module Example
   Public Sub Main()
      Dim interval1, interval2 As TimeSpan
      interval1 = New TimeSpan(7, 45, 16)
      interval2 = New TimeSpan(18, 12, 38)

      Console.WriteLine("{0:c} - {1:c} = {2:c}", interval1, 
                        interval2, interval1 - interval2)
      Console.WriteLine("{0:c} + {1:c} = {2:c}", interval1, 
                        interval2, interval1 + interval2)

      interval1 = New TimeSpan(0, 0, 1, 14, 365)
      interval2 = TimeSpan.FromTicks(2143756)      
      Console.WriteLine("{0:c} + {1:c} = {2:c}", interval1, 
                        interval2, interval1 + interval2)
   End Sub
End Module
' The example displays the following output:
'       07:45:16 - 18:12:38 = -10:27:22
'       07:45:16 + 18:12:38 = 1.01:57:54
'       00:01:14.3650000 + 00:00:00.2143756 = 00:01:14.5793756
```

## The General Short ("g") Format Specifier

The "g" [TimeSpan](xref:System.TimeSpan) format specifier returns the string representation of a [TimeSpan](xref:System.TimeSpan) value in a compact form by including only the elements that are necessary. It has the following form:

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

The following example instantiates two [TimeSpan](xref:System.TimeSpan) objects, uses them to perform arithmetic operations, and displays the result. In each case, it uses composite formatting to display the [TimeSpan](xref:System.TimeSpan) value by using the "g" format specifier. In addition, it formats the [TimeSpan](xref:System.TimeSpan) value by using the formatting conventions of the current system culture (which, in this case, is English - United States or en-US) and the French - France (fr-FR) culture.

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

```vb
Imports System.Globalization

Module Example
   Public Sub Main()
      Dim interval1, interval2 As TimeSpan
      interval1 = New TimeSpan(7, 45, 16)
      interval2 = New TimeSpan(18, 12, 38)

      Console.WriteLine("{0:g} - {1:g} = {2:g}", interval1, 
                        interval2, interval1 - interval2)
      Console.WriteLine(String.Format(New CultureInfo("fr-FR"), 
                        "{0:g} + {1:g} = {2:g}", interval1, 
                        interval2, interval1 + interval2))

      interval1 = New TimeSpan(0, 0, 1, 14, 36)
      interval2 = TimeSpan.FromTicks(2143756)      
      Console.WriteLine("{0:g} + {1:g} = {2:g}", interval1, 
                        interval2, interval1 + interval2)
   End Sub
End Module
' The example displays the following output:
'       7:45:16 - 18:12:38 = -10:27:22
'       7:45:16 + 18:12:38 = 1:1:57:54
'       0:01:14.036 + 0:00:00.2143756 = 0:01:14.2503756
```

## The General Long ("G") Format Specifier

The "G" [TimeSpan](xref:System.TimeSpan) format specifier returns the string representation of a [TimeSpan](xref:System.TimeSpan) value in a long form that always includes both days and fractional seconds. The string that results from the "G" standard format specifier has the following form:

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

The following example instantiates two [TimeSpan](xref:System.TimeSpan) objects, uses them to perform arithmetic operations, and displays the result. In each case, it uses composite formatting to display the [TimeSpan](xref:System.TimeSpan) value by using the "G" format specifier. In addition, it formats the [TimeSpan](xref:System.TimeSpan) value by using the formatting conventions of the current system culture (which, in this case, is English - United States or en-US) and the French - France (fr-FR) culture. 

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

```vb
Imports System.Globalization

Module Example
   Public Sub Main()
      Dim interval1, interval2 As TimeSpan
      interval1 = New TimeSpan(7, 45, 16)
      interval2 = New TimeSpan(18, 12, 38)

      Console.WriteLine("{0:G} - {1:G} = {2:G}", interval1, 
                        interval2, interval1 - interval2)
      Console.WriteLine(String.Format(New CultureInfo("fr-FR"), 
                        "{0:G} + {1:G} = {2:G}", interval1, 
                        interval2, interval1 + interval2))

      interval1 = New TimeSpan(0, 0, 1, 14, 36)
      interval2 = TimeSpan.FromTicks(2143756)      
      Console.WriteLine("{0:G} + {1:G} = {2:G}", interval1, 
                        interval2, interval1 + interval2)
   End Sub
End Module
' The example displays the following output:
'       0:07:45:16.0000000 - 0:18:12:38.0000000 = -0:10:27:22.0000000
'       0:07:45:16,0000000 + 0:18:12:38,0000000 = 1:01:57:54,0000000
'       0:00:01:14.0360000 + 0:00:00:00.2143756 = 0:00:01:14.2503756
```

## See Also

[Formatting types](formatting-types.md)

[Composite formatting](composite-format.md)

[Parsing strings](parsing-strings.md)

