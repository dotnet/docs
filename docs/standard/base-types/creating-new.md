---
title: "Creating New Strings in .NET"
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
  - "CopyTo method"
  - "Join method"
  - "Format method"
  - "Concat method"
  - "strings [.NET Framework], creating"
  - "Insert method"
ms.assetid: 06fdf123-2fac-4459-8904-eb48ab908a30
caps.latest.revision: 11
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Creating New Strings in .NET
The [!INCLUDE[dnprdnshort](../../../includes/dnprdnshort-md.md)] allows strings to be created using simple assignment, and also overloads a class constructor to support string creation using a number of different parameters. The [!INCLUDE[dnprdnshort](../../../includes/dnprdnshort-md.md)] also provides several methods in the <xref:System.String?displayProperty=nameWithType> class that create new string objects by combining several strings, arrays of strings, or objects.  
  
## Creating Strings Using Assignment  
 The easiest way to create a new <xref:System.String> object is simply to assign a string literal to a <xref:System.String> object.  
  
## Creating Strings Using a Class Constructor  
 You can use overloads of the <xref:System.String> class constructor to create strings from character arrays. You can also create a new string by duplicating a particular character a specified number of times.  
  
## Methods that Return Strings  
 The following table lists several useful methods that return new string objects.  
  
|Method name|Use|  
|-----------------|---------|  
|<xref:System.String.Format%2A?displayProperty=nameWithType>|Builds a formatted string from a set of input objects.|  
|<xref:System.String.Concat%2A?displayProperty=nameWithType>|Builds strings from two or more strings.|  
|<xref:System.String.Join%2A?displayProperty=nameWithType>|Builds a new string by combining an array of strings.|  
|<xref:System.String.Insert%2A?displayProperty=nameWithType>|Builds a new string by inserting a string into the specified index of an existing string.|  
|<xref:System.String.CopyTo%2A?displayProperty=nameWithType>|Copies specified characters in a string into a specified position in an array of characters.|  
  
### Format  
 You can use the **String.Format** method to create formatted strings and concatenate strings representing multiple objects. This method automatically converts any passed object into a string. For example, if your application must display an **Int32** value and a **DateTime** value to the user, you can easily construct a string to represent these values using the **Format** method. For information about formatting conventions used with this method, see the section on [composite formatting](../../../docs/standard/base-types/composite-formatting.md).  
  
 The following example uses the **Format** method to create a string that uses an integer variable.  
  
 [!code-csharp[Strings.Creating#1](../../../samples/snippets/csharp/VS_Snippets_CLR/Strings.Creating/cs/Example.cs#1)]
 [!code-vb[Strings.Creating#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR/Strings.Creating/vb/Example.vb#1)]  
  
 In this example,<xref:System.DateTime.Now%2A?displayProperty=nameWithType> displays the current date and time in a manner specified by the culture associated with the current thread.  
  
### Concat  
 The **String.Concat** method can be used to easily create a new string object from two or more existing objects. It provides a language-independent way to concatenate strings. This method accepts any class that derives from **System.Object**. The following example creates a string from two existing string objects and a separating character.  
  
 [!code-csharp[Strings.Creating#2](../../../samples/snippets/csharp/VS_Snippets_CLR/Strings.Creating/cs/Example.cs#2)]
 [!code-vb[Strings.Creating#2](../../../samples/snippets/visualbasic/VS_Snippets_CLR/Strings.Creating/vb/Example.vb#2)]  
  
### Join  
 The **String.Join** method creates a new string from an array of strings and a separator string. This method is useful if you want to concatenate multiple strings together, making a list perhaps separated by a comma.  
  
 The following example uses a space to bind a string array.  
  
 [!code-csharp[Strings.Creating#3](../../../samples/snippets/csharp/VS_Snippets_CLR/Strings.Creating/cs/Example.cs#3)]
 [!code-vb[Strings.Creating#3](../../../samples/snippets/visualbasic/VS_Snippets_CLR/Strings.Creating/vb/Example.vb#3)]  
  
### Insert  
 The **String.Insert** method creates a new string by inserting a string into a specified position in another string. This method uses a zero-based index. The following example inserts a string into the fifth index position of `MyString` and creates a new string with this value.  
  
 [!code-csharp[Strings.Creating#4](../../../samples/snippets/csharp/VS_Snippets_CLR/Strings.Creating/cs/Example.cs#4)]
 [!code-vb[Strings.Creating#4](../../../samples/snippets/visualbasic/VS_Snippets_CLR/Strings.Creating/vb/Example.vb#4)]  
  
### CopyTo  
 The **String.CopyTo** method copies portions of a string into an array of characters. You can specify both the beginning index of the string and the number of characters to be copied. This method takes the source index, an array of characters, the destination index, and the number of characters to copy. All indexes are zero-based.  
  
 The following example uses the **CopyTo** method to copy the characters of the word "Hello" from a string object to the first index position of an array of characters.  
  
 [!code-csharp[Strings.Creating#5](../../../samples/snippets/csharp/VS_Snippets_CLR/Strings.Creating/cs/Example.cs#5)]
 [!code-vb[Strings.Creating#5](../../../samples/snippets/visualbasic/VS_Snippets_CLR/Strings.Creating/vb/Example.vb#5)]  
  
## See Also  
 [Basic String Operations](../../../docs/standard/base-types/basic-string-operations.md)  
 [Composite Formatting](../../../docs/standard/base-types/composite-formatting.md)
