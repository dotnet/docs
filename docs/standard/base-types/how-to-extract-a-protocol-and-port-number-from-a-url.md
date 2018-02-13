---
title: "How to: Extract a Protocol and Port Number from a URL"
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
ms.assetid: ab7f62b3-6d2c-4efb-8ac6-28600df5fd5c
caps.latest.revision: 15
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# How to: Extract a Protocol and Port Number from a URL
The following example extracts a protocol and port number from a URL.  
  
## Example  
 The example uses the <xref:System.Text.RegularExpressions.Match.Result%2A?displayProperty=nameWithType> method to return the protocol followed by a colon followed by the port number.  
  
 [!code-csharp[RegularExpressions.Examples.Protocol#1](../../../samples/snippets/csharp/VS_Snippets_CLR/RegularExpressions.Examples.Protocol/cs/Example.cs#1)]
 [!code-vb[RegularExpressions.Examples.Protocol#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR/RegularExpressions.Examples.Protocol/vb/Example.vb#1)]  
  
 The regular expression pattern `^(?<proto>\w+)://[^/]+?(?<port>:\d+)?/` can be interpreted as shown in the following table.  
  
|Pattern|Description|  
|-------------|-----------------|  
|`^`|Begin the match at the start of the string.|  
|`(?<proto>\w+)`|Match one or more word characters. Name this group `proto`.|  
|`://`|Match a colon followed by two slash marks.|  
|`[^/]+?`|Match one or more occurrences (but as few as possible) of any character other than a slash mark.|  
|`(?<port>:\d+)?`|Match zero or one occurrence of a colon followed by one or more digit characters. Name this group `port`.|  
|`/`|Match a slash mark.|  
  
 The <xref:System.Text.RegularExpressions.Match.Result%2A?displayProperty=nameWithType> method expands the `${proto}${port}` replacement sequence, which concatenates the value of the two named groups captured in the regular expression pattern. It is a convenient alternative to explicitly concatenating the strings retrieved from the collection object returned by the <xref:System.Text.RegularExpressions.Match.Groups%2A?displayProperty=nameWithType> property.  
  
 The example uses the <xref:System.Text.RegularExpressions.Match.Result%2A?displayProperty=nameWithType> method with two substitutions, `${proto}` and `${port}`, to include the captured groups in the output string. You can retrieve the captured groups from the match's <xref:System.Text.RegularExpressions.GroupCollection> object instead, as the following code shows.  
  
 [!code-csharp[RegularExpressions.Examples.Protocol#2](../../../samples/snippets/csharp/VS_Snippets_CLR/RegularExpressions.Examples.Protocol/cs/example2.cs#2)]
 [!code-vb[RegularExpressions.Examples.Protocol#2](../../../samples/snippets/visualbasic/VS_Snippets_CLR/RegularExpressions.Examples.Protocol/vb/example2.vb#2)]  
  
## See Also  
 [.NET Regular Expressions](../../../docs/standard/base-types/regular-expressions.md)
