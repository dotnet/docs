---
title: "Filtering Data (C#)"
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
ms.assetid: fbaece0d-0f23-47f7-89c5-f3ea8db692b6
caps.latest.revision: 4
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
translation.priority.mt: 
  - "cs-cz"
  - "pl-pl"
  - "pt-br"
  - "tr-tr"
---
# Filtering Data (C#)
Filtering refers to the operation of restricting the result set to contain only those elements that satisfy a specified condition. It is also known as selection.  
  
 The following illustration shows the results of filtering a sequence of characters. The predicate for the filtering operation specifies that the character must be 'A'.  
  
 ![LINQ Filtering Operation](../linq/media/linq_filter.png "LINQ_Filter")  
  
 The standard query operator methods that perform selection are listed in the following section.  
  
## Methods  
  
|Method Name|Description|C# Query Expression Syntax|More Information|  
|-----------------|-----------------|---------------------------------|----------------------|  
|OfType|Selects values, depending on their ability to be cast to a specified type.|Not applicable.|<xref:System.Linq.Enumerable.OfType*?displayProperty=fullName><br /><br /> <xref:System.Linq.Queryable.OfType*?displayProperty=fullName>|  
|Where|Selects values that are based on a predicate function.|`where`|<xref:System.Linq.Enumerable.Where*?displayProperty=fullName><br /><br /> <xref:System.Linq.Queryable.Where*?displayProperty=fullName>|  
  
## Query Expression Syntax Example  
 The following example uses the `where` clause to filter from an array those strings that have a specific length.  
  
```c#  
string[] words = { "the", "quick", "brown", "fox", "jumps" };  
  
IEnumerable<string> query = from word in words  
                            where word.Length == 3  
                            select word;  
  
foreach (string str in query)  
    Console.WriteLine(str);  
  
/* This code produces the following output:  
  
    the  
    fox  
*/  
```  
  
## See Also  
 <xref:System.Linq>   
 [Standard Query Operators Overview (C#)](../linq/standard-query-operators-overview--csharp-.md)   
 [where clause](../keywords/where-clause--csharp-reference-.md)   
 [How to: Dynamically Specify Predicate Filters at Runtime](../linq-query-expressions/52f2dc7a-8353-4c6e-98d3-eec99a907a5f.md)   
 [How to: Query An Assembly's Metadata with Reflection (LINQ) (C#)](../linq/how-to--query-an-assembly-s-metadata-with-reflection--linq---csharp-.md)   
 [How to: Query for Files with a Specified Attribute or Name (C#)](../linq/how-to--query-for-files-with-a-specified-attribute-or-name--csharp-.md)   
 [How to: Sort or Filter Text Data by Any Word or Field (LINQ) (C#)](../linq/how-to--sort-or-filter-text-data-by-any-word-or-field--linq---csharp-.md)