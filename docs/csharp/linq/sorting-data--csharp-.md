---
title: "Sorting Data (C#)"
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
ms.assetid: d93fa055-2f19-46d2-9898-e2aed628f1c9
caps.latest.revision: 3
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
translation.priority.mt: 
  - "cs-cz"
  - "pl-pl"
  - "pt-br"
  - "tr-tr"
---
# Sorting Data (C#)
A sorting operation orders the elements of a sequence based on one or more attributes. The first sort criterion performs a primary sort on the elements. By specifying a second sort criterion, you can sort the elements within each primary sort group.  
  
 The following illustration shows the results of an alphabetical sort operation on a sequence of characters.  
  
 ![LINQ Sorting Operation](../linq/media/linq_ordering.png "LINQ_Ordering")  
  
 The standard query operator methods that sort data are listed in the following section.  
  
## Methods  
  
|Method Name|Description|C# Query Expression Syntax|More Information|  
|-----------------|-----------------|---------------------------------|----------------------|  
|OrderBy|Sorts values in ascending order.|`orderby`|<xref:System.Linq.Enumerable.OrderBy*?displayProperty=fullName><br /><br /> <xref:System.Linq.Queryable.OrderBy*?displayProperty=fullName>|  
|OrderByDescending|Sorts values in descending order.|`orderby … descending`|<xref:System.Linq.Enumerable.OrderByDescending*?displayProperty=fullName><br /><br /> <xref:System.Linq.Queryable.OrderByDescending*?displayProperty=fullName>|  
|ThenBy|Performs a secondary sort in ascending order.|`orderby …, …`|<xref:System.Linq.Enumerable.ThenBy*?displayProperty=fullName><br /><br /> <xref:System.Linq.Queryable.ThenBy*?displayProperty=fullName>|  
|ThenByDescending|Performs a secondary sort in descending order.|`orderby …, … descending`|<xref:System.Linq.Enumerable.ThenByDescending*?displayProperty=fullName><br /><br /> <xref:System.Linq.Queryable.ThenByDescending*?displayProperty=fullName>|  
|Reverse|Reverses the order of the elements in a collection.|Not applicable.|<xref:System.Linq.Enumerable.Reverse*?displayProperty=fullName><br /><br /> <xref:System.Linq.Queryable.Reverse*?displayProperty=fullName>|  
  
## Query Expression Syntax Examples  
  
### Primary Sort Examples  
  
#### Primary Ascending Sort  
 The following example demonstrates how to use the `orderby` clause in a LINQ query to sort the strings in an array by string length, in ascending order.  
  
```c#  
string[] words = { "the", "quick", "brown", "fox", "jumps" };  
  
IEnumerable<string> query = from word in words  
                            orderby word.Length  
                            select word;  
  
foreach (string str in query)  
    Console.WriteLine(str);  
  
/* This code produces the following output:  
  
    the  
    fox  
    quick  
    brown  
    jumps  
*/  
```  
  
#### Primary Descending Sort  
 The next example demonstrates how to use the `orderby``descending` clause in a LINQ query to sort the strings by their first letter, in descending order.  
  
```c#  
string[] words = { "the", "quick", "brown", "fox", "jumps" };  
  
IEnumerable<string> query = from word in words  
                            orderby word.Substring(0, 1) descending  
                            select word;  
  
foreach (string str in query)  
    Console.WriteLine(str);  
  
/* This code produces the following output:  
  
    the  
    quick  
    jumps  
    fox  
    brown  
*/  
```  
  
### Secondary Sort Examples  
  
#### Secondary Ascending Sort  
 The following example demonstrates how to use the `orderby` clause in a LINQ query to perform a primary and secondary sort of the strings in an array. The strings are sorted primarily by length and secondarily by the first letter of the string, both in ascending order.  
  
```c#  
string[] words = { "the", "quick", "brown", "fox", "jumps" };  
  
IEnumerable<string> query = from word in words  
                            orderby word.Length, word.Substring(0, 1)  
                            select word;  
  
foreach (string str in query)  
    Console.WriteLine(str);  
  
/* This code produces the following output:  
  
    fox  
    the  
    brown  
    jumps  
    quick  
*/  
```  
  
#### Secondary Descending Sort  
 The next example demonstrates how to use the `orderby``descending` clause in a LINQ query to perform a primary sort, in ascending order, and a secondary sort, in descending order. The strings are sorted primarily by length and secondarily by the first letter of the string.  
  
```c#  
string[] words = { "the", "quick", "brown", "fox", "jumps" };  
  
IEnumerable<string> query = from word in words  
                            orderby word.Length, word.Substring(0, 1) descending  
                            select word;  
  
foreach (string str in query)  
    Console.WriteLine(str);  
  
/* This code produces the following output:  
  
    the  
    fox  
    quick  
    jumps  
    brown  
*/  
```  
  
## See Also  
 <xref:System.Linq>   
 [Standard Query Operators Overview (C#)](../linq/standard-query-operators-overview--csharp-.md)   
 [orderby clause](../keywords/orderby-clause--csharp-reference-.md)   
 [How to: Order the Results of a Join Clause](../linq-query-expressions/how-to--order-the-results-of-a-join-clause--csharp-programming-guide-.md)   
 [How to: Sort or Filter Text Data by Any Word or Field (LINQ) (C#)](../linq/how-to--sort-or-filter-text-data-by-any-word-or-field--linq---csharp-.md)