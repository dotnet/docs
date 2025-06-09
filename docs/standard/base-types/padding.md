---
title: "Padding Strings in .NET"
description: Learn how to pad strings in .NET. Use the String.PadLeft and String.PadRight methods to add leading or trailing characters to achieve a specified total length.
ms.date: "03/15/2018"
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "strings [.NET], padding"
  - "white space"
  - "PadRight method"
  - "PadLeft method"
  - "padding strings"
---
# Pad strings in .NET

Use one of the following <xref:System.String> methods to create a new string that consists of an original string that is padded with leading or trailing characters to a specified total length. The padding character can be a space or a specified character. The resulting string appears to be either right-aligned or left-aligned. If the original string's length is already equal to or greater than the desired total length, the padding methods return the original string unchanged; for more information, see the **Returns** sections of the two overloads of the <xref:System.String.PadLeft%2A?displayProperty=nameWithType> and <xref:System.String.PadRight%2A?displayProperty=nameWithType> methods.

|Method name|Use|
|-----------------|---------|
|<xref:System.String.PadLeft%2A?displayProperty=nameWithType>|Pads a string with leading characters to a specified total length.|
|<xref:System.String.PadRight%2A?displayProperty=nameWithType>|Pads a string with trailing characters to a specified total length.|

## PadLeft

 The <xref:System.String.PadLeft%2A?displayProperty=nameWithType> method creates a new string by concatenating enough leading pad characters to an original string to achieve a specified total length. The <xref:System.String.PadLeft%28System.Int32%29?displayProperty=nameWithType> method uses white space as the padding character and the <xref:System.String.PadLeft%28System.Int32%2CSystem.Char%29?displayProperty=nameWithType> method enables you to specify your own padding character.

 The following code example uses the <xref:System.String.PadLeft%2A> method to create a new string that is twenty characters long. The example displays "`--------Hello World!`" to the console.

 [!code-csharp[Conceptual.String.BasicOps#3](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.string.basicops/cs/padding.cs#3)]
 [!code-vb[Conceptual.String.BasicOps#3](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.string.basicops/vb/padding.vb#3)]

## PadRight

 The <xref:System.String.PadRight%2A?displayProperty=nameWithType> method creates a new string by concatenating enough trailing pad characters to an original string to achieve a specified total length. The <xref:System.String.PadRight%28System.Int32%29?displayProperty=nameWithType> method uses white space as the padding character and the <xref:System.String.PadRight%28System.Int32%2CSystem.Char%29?displayProperty=nameWithType> method enables you to specify your own padding character.

 The following code example uses the <xref:System.String.PadRight%2A> method to create a new string that is twenty characters long. The example displays "`Hello World!--------`" to the console.

 [!code-csharp[Conceptual.String.BasicOps#4](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.string.basicops/cs/padding.cs#4)]
 [!code-vb[Conceptual.String.BasicOps#4](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.string.basicops/vb/padding.vb#4)]

## See also

- [Basic String Operations](basic-string-operations.md)
