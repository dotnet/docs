---
title: How to: Extract a Protocol and Port Number from a URL
description: How to: Extract a Protocol and Port Number from a URL
keywords: .NET, .NET Core
author: shoag
manager: wpickett
ms.date: 06/20/2016
ms.topic: article
ms.prod: .net-core
ms.technology: .net-core-technologies
ms.devlang: dotnet
ms.assetid: a047da6e-f200-413d-9613-797c57986c18
---

# How to: Extract a Protocol and Port Number from a URL

The following example extracts a protocol and port number from a URL. 

## Example

The example uses the [Match.Result](https://docs.microsoft.com/dotnet/core/api/System.Text.RegularExpressions.Match#System_Text_RegularExpressions_Match_Result_System_String_) method to return the protocol followed by a colon followed by the port number. 

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

The regular expression pattern `^(?<proto>\w+)://[^/]+?(?<port>:\d+)?/` can be interpreted as shown in the following table.

Pattern | Description
------- | ----------- 
`^` | Begin the match at the start of the string.
`(?<proto>\w+)` | Match one or more word characters. Name this group proto.
`://` | Match a colon followed by two slash marks.
`[^/]+?` | Match one or more occurrences (but as few as possible) of any character other than a slash mark.
`(?<port>:\d+)?` | Match zero or one occurrence of a colon followed by one or more digit characters. Name this group port.
`/` | Match a slash mark.
 
The [Match.Result](https://docs.microsoft.com/dotnet/core/api/System.Text.RegularExpressions.Match#System_Text_RegularExpressions_Match_Result_System_String_) method expands the `${proto}${port}` replacement sequence, which concatenates the value of the two named groups captured in the regular expression pattern. It is a convenient alternative to explicitly concatenating the strings retrieved from the collection object returned by the [Match.Groups](https://docs.microsoft.com/dotnet/core/api/System.Text.RegularExpressions.Match#System_Text_RegularExpressions_Match_Groups) property.

The example uses the [Match.Result](https://docs.microsoft.com/dotnet/core/api/System.Text.RegularExpressions.Match#System_Text_RegularExpressions_Match_Result_System_String_) method with two substitutions, `${proto}` and `${port}`, to include the captured groups in the output string. You can retrieve the captured groups from the match's [GroupCollection](https://docs.microsoft.com/dotnet/core/api/System.Text.RegularExpressions.GroupCollection) object instead, as the following code shows.

```csharp
Console.WriteLine(m.Groups["proto"].Value + m.Groups["port"].Value); 
```

## See Also

[Regular Expression Examples](index.md)
