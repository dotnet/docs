---
title: "How to return subsets of element properties in a query - C# Programming Guide"
description: Learn how to use an anonymous type in a query expression in C# to return some of the properties of each source element.
ms.date: 07/20/2015
helpviewer_keywords: 
  - "anonymous types [C#], for subsets of element properties"
ms.topic: how-to
ms.custom: contperf-fy21q2
ms.assetid: fabdf349-f443-4e3f-8368-6c471be1dd7b
---
# How to return subsets of element properties in a query (C# Programming Guide)

Use an anonymous type in a query expression when both of these conditions apply:  
  
- You want to return only some of the properties of each source element.  
  
- You do not have to store the query results outside the scope of the method in which the query is executed.  
  
 If you only want to return one property or field from each source element, then you can just use the dot operator in the `select` clause. For example, to return only the `ID` of each `student`, write the `select` clause as follows:  
  
```csharp  
select student.ID;  
```  
  
## Example  

 The following example shows how to use an anonymous type to return only a subset of the properties of each source element that matches the specified condition.  
  
 [!code-csharp[csProgGuideLINQ#31](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideLINQ/CS/csRef30LangFeatures_2.cs#31)]  
  
 Note that the anonymous type uses the source element's names for its properties if no names are specified. To give new names to the properties in the anonymous type, write the `select` statement as follows:  
  
```csharp  
select new { First = student.FirstName, Last = student.LastName };  
```  
  
 If you try this in the previous example, then the `Console.WriteLine` statement must also change:  
  
```csharp  
Console.WriteLine(student.First + " " + student.Last);  
```  
  
## Compiling the Code  
  
To run this code, copy and paste the class into a C# console application  with a `using` directive for System.Linq.
  
## See also

- [C# Programming Guide](../index.md)
- [Anonymous Types](../../fundamentals/types/anonymous-types.md)
- [LINQ in C#](../../linq/index.md)
