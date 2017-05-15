---
title: "Padding Strings in .NET | Microsoft Docs"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "strings [.NET Framework], padding"
  - "white space"
  - "PadRight method"
  - "PadLeft method"
  - "padding strings"
ms.assetid: 84a9f142-3244-4c90-ba02-21af9bbaff71
caps.latest.revision: 12
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
---
# Padding Strings in .NET
Use one of the following <xref:System.String> methods to create a new string that consists of an original string that is padded with leading or trailing characters to a specified total length. The padding character can be spaces or a specified character, and consequently appears to be either right-aligned or left-aligned.  
  
|Method name|Use|  
|-----------------|---------|  
|<xref:System.String.PadLeft%2A?displayProperty=fullName>|Pads a string with leading characters to a specified total length.|  
|<xref:System.String.PadRight%2A?displayProperty=fullName>|Pads a string with trailing characters to a specified total length.|  
  
## PadLeft  
 The <xref:System.String.PadLeft%2A?displayProperty=fullName> method creates a new string by concatenating enough leading pad characters to an original string to achieve a specified total length. The <xref:System.String.PadLeft%28System.Int32%29?displayProperty=fullName> method uses white space as the padding character and the <xref:System.String.PadLeft%28System.Int32%2CSystem.Char%29?displayProperty=fullName> method enables you to specify your own padding character.  
  
 The following code example uses the <xref:System.String.PadLeft%2A> method to create a new string that is twenty characters long. The example displays "`--------Hello World!`" to the console.  
  
 [!code-cpp[Conceptual.String.BasicOps#3](../../../samples/snippets/cpp/VS_Snippets_CLR/conceptual.string.basicops/cpp/padding.cpp#3)]
 [!code-csharp[Conceptual.String.BasicOps#3](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.string.basicops/cs/padding.cs#3)]
 [!code-vb[Conceptual.String.BasicOps#3](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.string.basicops/vb/padding.vb#3)]  
  
## PadRight  
 The <xref:System.String.PadRight%2A?displayProperty=fullName> method creates a new string by concatenating enough trailing pad characters to an original string to achieve a specified total length. The <xref:System.String.PadRight%28System.Int32%29?displayProperty=fullName> method uses white space as the padding character and the <xref:System.String.PadRight%28System.Int32%2CSystem.Char%29?displayProperty=fullName> method enables you to specify your own padding character.  
  
 The following code example uses the <xref:System.String.PadRight%2A> method to create a new string that is twenty characters long. The example displays "`Hello World!--------`" to the console.  
  
 [!code-cpp[Conceptual.String.BasicOps#4](../../../samples/snippets/cpp/VS_Snippets_CLR/conceptual.string.basicops/cpp/padding.cpp#4)]
 [!code-csharp[Conceptual.String.BasicOps#4](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.string.basicops/cs/padding.cs#4)]
 [!code-vb[Conceptual.String.BasicOps#4](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.string.basicops/vb/padding.vb#4)]  
  
## See Also  
 [Basic String Operations](../../../docs/standard/base-types/basic-string-operations.md)