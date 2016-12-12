---
title: "Regular expression example: changing date formats"
description: Regular expression example changing date formats
keywords: .NET, .NET Core
author: stevehoag
ms.author: shoag
ms.date: 07/28/2016
ms.topic: article
ms.prod: .net
ms.technology: dotnet-standard
ms.devlang: dotnet
ms.assetid: 3e196697-981c-4c1d-93dd-c3b236ef36dd
---

# Regular expression example: changing date formats

The following code example uses the [Regex.Replace](xref:System.Text.RegularExpressions.Regex.Replace(System.String,System.String)) method to replace dates that have the form *mm/dd/yy* with dates that have the form *dd-mm-yy*.

## Example

```csharp
static string MDYToDMY(string input) 
{
   try {
      return Regex.Replace(input, 
            "\\b(?<month>\\d{1,2})/(?<day>\\d{1,2})/(?<year>\\d{2,4})\\b",
            "${day}-${month}-${year}", RegexOptions.None,
            TimeSpan.FromMilliseconds(150));
   }         
   catch (RegexMatchTimeoutException) {
      return input;
   }
}
```

```vb
Function MDYToDMY(input As String) As String
   Try
      Return Regex.Replace(input, _
             "\b(?<month>\d{1,2})/(?<day>\d{1,2})/(?<year>\d{2,4})\b", _
             "${day}-${month}-${year}", RegexOptions.None,
             TimeSpan.FromMilliseconds(150))
    Catch e As RegexMatchTimeoutException
       Return input
    End Try         
End Function
```

The following code shows how the `MDYToDMY` method can be called in an application. 

```csharp
using System;
using System.Globalization;
using System.Text.RegularExpressions;

public class Class1
{
   public static void Main()
   {
      string dateString = DateTime.Today.ToString("d", 
                                        DateTimeFormatInfo.InvariantInfo);
      string resultString = MDYToDMY(dateString);
      Console.WriteLine("Converted {0} to {1}.", dateString, resultString);
   }

   static string MDYToDMY(string input) 
   {
      try {
         return Regex.Replace(input, 
               "\\b(?<month>\\d{1,2})/(?<day>\\d{1,2})/(?<year>\\d{2,4})\\b",
               "${day}-${month}-${year}", RegexOptions.None,
               TimeSpan.FromMilliseconds(150));
      }         
      catch (RegexMatchTimeoutException) {
         return input;
      }
   }

}
// The example displays the following output to the console if run on 8/21/2007:
//      Converted 08/21/2007 to 21-08-2007.
```

```vb
Imports System.Globalization
Imports System.Text.RegularExpressions

Module DateFormatReplacement
   Public Sub Main()
      Dim dateString As String = Date.Today.ToString("d", _
                                           DateTimeFormatInfo.InvariantInfo)
      Dim resultString As String = MDYToDMY(dateString)
      Console.WriteLine("Converted {0} to {1}.", dateString, resultString)
   End Sub

    Function MDYToDMY(input As String) As String
       Try
          Return Regex.Replace(input, _
                 "\b(?<month>\d{1,2})/(?<day>\d{1,2})/(?<year>\d{2,4})\b", _
                 "${day}-${month}-${year}", RegexOptions.None,
                 TimeSpan.FromMilliseconds(150))
        Catch e As RegexMatchTimeoutException
           Return input
        End Try         
    End Function
End Module
' The example displays the following output to the console if run on 8/21/2007:
'      Converted 08/21/2007 to 21-08-2007.
```

## Comments

The regular expression pattern `\b(?<month>\d{1,2})/(?<day>\d{1,2})/(?<year>\d{2,4})\b` is interpreted as shown in the following table.

Pattern | Description
------- | ----------- 
`\b` | Begin the match at a word boundary.
`(?<month>\d{1,2})` | Match one or two decimal digits. This is the `month` captured group.
`/` | Match the slash mark.
`(?<day>\d{1,2})` | Match one or two decimal digits. This is the `day` captured group.
`/` | Match the slash mark.
`(?<year>\d{2,4})` | Match from two to four decimal digits. This is the `year` captured group.
`\b` | End the match at a word boundary.
 
The pattern `${day}-${month}-${year}` defines the replacement string as shown in the following table.

Pattern | Description
------- | ----------- 
`$(day)` | Add the string captured by the `day` capturing group.
`-` | Add a hyphen.
`$(month)` | Add the string captured by the `month` capturing group.
`-` | Add a hyphen.
`$(year)` | Add the string captured by the `year` capturing group.
 
## See Also

[.NET regular expressions](regular-expressions.md)

[Regular expression examples](regex-examples.md)
