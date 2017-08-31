---
title: "How to: Initialize a Dictionary with a Collection Initializer (C# Programming Guide) | Microsoft Docs"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: "visual-studio-dev14"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "collection initializers [C#], with Dictionary"
ms.assetid: 25283922-f8ee-40dc-a639-fac30804ec71
caps.latest.revision: 10
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
---
# How to: Initialize a Dictionary with a Collection Initializer (C# Programming Guide)
[!INCLUDE[csharpbanner](../../../includes/csharpbanner.md)]

A <xref:System.Collections.Generic.Dictionary%602> contains a collection of key/value pairs. Its <xref:System.Collections.Generic.Dictionary%602.Add%2A> method takes two parameters, one for the key and one for the value. To initialize a <xref:System.Collections.Generic.Dictionary%602>, or any collection whose `Add` method takes multiple parameters, enclose each set of parameters in braces as shown in the following example.  
  
## Example  
 In the following code example, a <xref:System.Collections.Generic.Dictionary%602> is initialized with instances of type `StudentName`.  
  
 [!code-csharp[csProgGuideLINQ#34](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideLINQ/CS/csRef30LangFeatures_2.cs#34)]  
  
 Note the two pairs of braces in each element of the collection. The innermost braces enclose the object initializer for the `StudentName`, and the outermost braces enclose the initializer for the key/value pair that will be added to the `students`<xref:System.Collections.Generic.Dictionary%602>. Finally, the whole collection initializer for the dictionary is enclosed in braces.  
  
## Compiling the Code  
 To run this code, copy and paste the class into a Visual C# console application project that has been created in [!INCLUDE[vs_current_short](../../../includes/vs-current-short-md.md)]. By default, this project targets version 3.5 of the [!INCLUDE[dnprdnshort](../../../includes/dnprdnshort-md.md)], and it has a reference to System.Core.dll and a using directive for System.Linq. If one or more of these requirements are missing from the project, you can add them manually. For more information, see [How to: Create a LINQ Project](../Topic/How%20to:%20Create%20a%20LINQ%20Project.md).  
  
## See Also  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)   
 [Object and Collection Initializers](../../../csharp/programming-guide/classes-and-structs/object-and-collection-initializers.md)