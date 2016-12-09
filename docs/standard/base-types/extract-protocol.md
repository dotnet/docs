---
title: "How to: extract a protocol and port number from a URL"
description: How to extract a protocol and port number from a URL
keywords: .NET, .NET Core
author: stevehoag
ms.author: shoag
ms.date: 07/28/2016
ms.topic: article
ms.prod: .net
ms.technology: dotnet-standard
ms.devlang: dotnet
ms.assetid: d2462fb4-6d61-44ab-8466-73f1f06c3058
---

# How to: extract a protocol and port number from a URL

The following example extracts a protocol and port number from a URL. 

## Example

The example uses the [Match.Result](xref:System.Text.RegularExpressions.Match.Result(System.String)) method to return the protocol followed by a colon followed by the port number. 

```csharp
using System;
using System.Text.RegularExpressions;

public class Example
{
   public static void Main()
   {
      string url = "http://www.contoso.com:8080/letters/readme";

      Regex r = new Regex(@"^(?<proto>\w+)://[^/]+?(?<port>:\d+)?/",
                          RegexOptions.None, TimeSpan.FromMilliseconds(150));
      Match m = r.Match(url);
      if (m.Success)
         Console.WriteLine(r.Match(url).Result("${proto}${port}")); 
   }
}
// The example displays the following output:
//       http:8080
```

```vb
Imports System.Text.RegularExpressions

Module Example
   Public Sub Main()
      Dim url As String = "http://www.contoso.com:8080/letters/readme.html" 
      Dim r As New Regex("^(?<proto>\w+)://[^/]+?(?<port>:\d+)?/",
                         RegexOptions.None, TimeSpan.FromMilliseconds(150))

      Dim m As Match = r.Match(url)
      If m.Success Then
         Console.WriteLine(r.Match(url).Result("${proto}${port}"))
      End If   
   End Sub
End Module
' The example displays the following output:
'       http:8080
```

The regular expression pattern `^(?<proto>\w+)://[^/]+?(?<port>:\d+)?/` can be interpreted as shown in the following table.

Pattern | Description
------- | ----------- 
`^` | Begin the match at the start of the string.
`(?<proto>\w+)` | Match one or more word characters. Name this group proto.
`://` | Match a colon followed by two slash marks.
`[^/]+?` | Match one or more occurrences (but as few as possible) of any character other than a slash mark.
`(?<port>:\d+)?` | Match zero or one occurrence of a colon followed by one or more digit characters. Name this group port.
`/` | Match a slash mark.
 
The [Match.Result](xref:System.Text.RegularExpressions.Match.Result(System.String)) method expands the `${proto}${port}` replacement sequence, which concatenates the value of the two named groups captured in the regular expression pattern. It is a convenient alternative to explicitly concatenating the strings retrieved from the collection object returned by the [Match.Groups](xref:System.Text.RegularExpressions.Match.Groups) property.

The example uses the [Match.Result](xref:System.Text.RegularExpressions.Match.Result(System.String)) method with two substitutions, `${proto}` and `${port}`, to include the captured groups in the output string. You can retrieve the captured groups from the match's [GroupCollection](xref:System.Text.RegularExpressions.GroupCollection) object instead, as the following code shows.

```csharp
Console.WriteLine(m.Groups["proto"].Value + m.Groups["port"].Value); 
```

```vb
Console.WriteLine(m.Groups("proto").Value + m.Groups("port").Value)
```

## See Also

[.NET regular expressions](regular-expressions.md)

[Regular expression examples](regex-examples.md)
