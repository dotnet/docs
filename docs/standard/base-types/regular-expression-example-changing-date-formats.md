---
title: "Regular Expression Example: Changing Date Formats"
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
  - "searching with regular expressions, examples"
  - "parsing text with regular expressions, examples"
  - "regular expressions, examples"
  - ".NET Framework regular expressions, examples"
  - "regular expressions [.NET Framework], examples"
  - "pattern-matching with regular expressions, examples"
ms.assetid: 5fcc75a5-09d7-45ae-a4c0-9ad6085ac83d
caps.latest.revision: 19
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Regular Expression Example: Changing Date Formats
The following code example uses the <xref:System.Text.RegularExpressions.Regex.Replace%2A?displayProperty=nameWithType> method to replace dates that have the form *mm*/*dd*/*yy* with dates that have the form *dd*-*mm*-*yy*.  
  
## Example  
 [!code-csharp[RegularExpressions.Examples.ChangeDateFormats#1](../../../samples/snippets/csharp/VS_Snippets_CLR/RegularExpressions.Examples.ChangeDateFormats/cs/Example_ChangeDateFormats1.cs#1)]
 [!code-vb[RegularExpressions.Examples.ChangeDateFormats#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR/RegularExpressions.Examples.ChangeDateFormats/vb/Example_ChangeDateFormats1.vb#1)]  
  
 The following code shows how the `MDYToDMY` method can be called in an application.  
  
 [!code-csharp[RegularExpressions.Examples.ChangeDateFormats#2](../../../samples/snippets/csharp/VS_Snippets_CLR/RegularExpressions.Examples.ChangeDateFormats/cs/Example_ChangeDateFormats1.cs#2)]
 [!code-vb[RegularExpressions.Examples.ChangeDateFormats#2](../../../samples/snippets/visualbasic/VS_Snippets_CLR/RegularExpressions.Examples.ChangeDateFormats/vb/Example_ChangeDateFormats1.vb#2)]  
  
## Comments  
 The regular expression pattern  `\b(?<month>\d{1,2})/(?<day>\d{1,2})/(?<year>\d{2,4})\b` is interpreted as shown in the following table.  
  
|Pattern|Description|  
|-------------|-----------------|  
|`\b`|Begin the match at a word boundary.|  
|`(?<month>\d{1,2})`|Match one or two decimal digits. This is the `month` captured group.|  
|`/`|Match the slash mark.|  
|`(?<day>\d{1,2})`|Match one or two decimal digits. This is the `day` captured group.|  
|`/`|Match the slash mark.|  
|`(?<year>\d{2,4})`|Match from two to four decimal digits. This is the `year` captured group.|  
|`\b`|End the match at a word boundary.|  
  
 The pattern `${day}-${month}-${year}` defines the replacement string as shown in the following table.  
  
|Pattern|Description|  
|-------------|-----------------|  
|`$(day)`|Add the string captured by the `day` capturing group.|  
|`-`|Add a hyphen.|  
|`$(month)`|Add the string captured by the `month` capturing group.|  
|`-`|Add a hyphen.|  
|`$(year)`|Add the string captured by the `year` capturing group.|  
  
## See Also  
 [.NET Regular Expressions](../../../docs/standard/base-types/regular-expressions.md)
