---
title: "Trimming and Removing Characters from Strings in .NET"
description: Learn to trim blank spaces from the beginning or end of a string, or remove any number of spaces or characters from a specified position in the string in .NET.
ms.date: "07/22/2022"
ms.custom: devdivchpfy22
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "strings [.NET], removing characters"
  - "Remove method"
  - "TrimEnd method"
  - "Trim method"
  - "trimming characters"
  - "TrimStart method"
  - "removing characters"
---
# Trim and remove characters from strings in .NET

If you're parsing a sentence into individual words, you might end up with words that have blank spaces (also called white spaces) on either end of the word. In this situation, you can use one of the trim methods in the `System.String` class to remove any number of spaces or other characters from a specified position in the string. The following table describes the available trim methods:

|Method name|Use|
|-----------------|---------|
|<xref:System.String.Trim%2A?displayProperty=nameWithType>|Removes white spaces or characters specified in an array of characters from the beginning and end of a string.|
|<xref:System.String.TrimEnd%2A?displayProperty=nameWithType>|Removes characters specified in an array of characters from the end of a string.|
|<xref:System.String.TrimStart%2A?displayProperty=nameWithType>|Removes characters specified in an array of characters from the beginning of a string.|
|<xref:System.String.Remove%2A?displayProperty=nameWithType>|Removes a specified number of characters from a specified index position in a string.|

## Trim

 You can easily remove white spaces from both ends of a string by using the <xref:System.String.Trim%2A?displayProperty=nameWithType> method, as shown in the following example:
 [!code-csharp[Conceptual.String.BasicOps#17](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.string.basicops/cs/trimming.cs#17)]
 [!code-vb[Conceptual.String.BasicOps#17](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.string.basicops/vb/trimming.vb#17)]

 You can also remove characters that you specify in a character array from the beginning and end of a string. The following example removes white-space characters, periods, and asterisks:

 [!code-csharp[Conceptual.String.BasicOps#22](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.string.basicops/cs/trim2.cs#22)]
 [!code-vb[Conceptual.String.BasicOps#22](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.string.basicops/vb/trim2.vb#22)]

## TrimEnd

 The `String.TrimEnd` method removes characters from the end of a string, creating a new string object. An array of characters is passed to this method to specify the characters to be removed. The order of the elements in the character array doesn't affect the trim operation. The trim stops when a character not specified in the array is found.

 The following example removes the last letters of a string using the `TrimEnd` method. In this example, the position of the `'r'` character and the `'W'` character are reversed to illustrate that the order of characters in the array doesn't matter. Notice that this code removes the last word of `MyString` plus part of the first.
 [!code-csharp[Conceptual.String.BasicOps#18](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.string.basicops/cs/trimming.cs#18)]
 [!code-vb[Conceptual.String.BasicOps#18](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.string.basicops/vb/trimming.vb#18)]

 This code displays `He` to the console.

 The following example removes the last word of a string using the `TrimEnd` method. In this code, a comma follows the word `Hello` and because the comma isn't specified in the array of characters to trim, the trim ends at the comma.
 [!code-csharp[Conceptual.String.BasicOps#19](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.string.basicops/cs/trimming.cs#19)]
 [!code-vb[Conceptual.String.BasicOps#19](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.string.basicops/vb/trimming.vb#19)]

 This code displays `Hello,` to the console.

## TrimStart

 The `String.TrimStart` method is similar to the `String.TrimEnd` method except that it creates a new string by removing characters from the beginning of an existing string object. An array of characters is passed to the `TrimStart` method to specify the characters to be removed. As with the `TrimEnd` method, the order of the elements in the character array doesn't affect the trim operation. The trim stops when a character not specified in the array is found.

 The following example removes the first word of a string. In this example, the position of the `'l'` character and the `'H'` character are reversed to illustrate that the order of characters in the array doesn't matter.
 [!code-csharp[Conceptual.String.BasicOps#20](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.string.basicops/cs/trimming.cs#20)]
 [!code-vb[Conceptual.String.BasicOps#20](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.string.basicops/vb/trimming.vb#20)]

 This code displays `World!` to the console.

## Remove

 The <xref:System.String.Remove%2A?displayProperty=nameWithType> method removes a specified number of characters that begin at a specified position in an existing string. This method assumes a zero-based index.

 The following example removes 10 characters from a string beginning at position five of a zero-based index of the string.
 [!code-csharp[Conceptual.String.BasicOps#21](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.string.basicops/cs/trimming.cs#21)]
 [!code-vb[Conceptual.String.BasicOps#21](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.string.basicops/vb/trimming.vb#21)]

## Replace

 You can also remove a specified character or substring from a string by calling the <xref:System.String.Replace%28System.String%2CSystem.String%29?displayProperty=nameWithType> method and specifying an empty string (<xref:System.String.Empty?displayProperty=nameWithType>) as the replacement. The following example removes all commas from a string:

 [!code-csharp[Conceptual.String.BasicOps#23](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.string.basicops/cs/replace1.cs#23)]
 [!code-vb[Conceptual.String.BasicOps#23](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.string.basicops/vb/replace1.vb#23)]

## See also

- [Basic String Operations](basic-string-operations.md)
