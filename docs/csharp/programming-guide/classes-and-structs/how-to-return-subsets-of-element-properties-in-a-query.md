---
title: "How to: Return Subsets of Element Properties in a Query (C# Programming Guide) | Microsoft Docs"
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
  - "anonymous types [C#], for subsets of element properties"
ms.assetid: fabdf349-f443-4e3f-8368-6c471be1dd7b
caps.latest.revision: 11
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
---
# How to: Return Subsets of Element Properties in a Query (C# Programming Guide)
[!INCLUDE[csharpbanner](../../../includes/csharpbanner.md)]

Use an anonymous type in a query expression when both of these conditions apply:  
  
-   You want to return only some of the properties of each source element.  
  
-   You do not have to store the query results outside the scope of the method in which the query is executed.  
  
 If you only want to return one property or field from each source element, then you can just use the dot operator in the `select` clause. For example, to return only the `ID` of each `student`, write the `select` clause as follows:  
  
```  
select student.ID;  
```  
  
## Example  
 The following example shows how to use an anonymous type to return only a subset of the properties of each source element that matches the specified condition.  
  
 [!code-csharp[csProgGuideLINQ#31](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideLINQ/CS/csRef30LangFeatures_2.cs#31)]  
  
 Note that the anonymous type uses the source element's names for its properties if no names are specified. To give new names to the properties in the anonymous type, write the `select` statement as follows:  
  
```  
select new { First = student.FirstName, Last = student.LastName };  
```  
  
 If you try this in the previous example, then the `Console.WriteLine` statement must also change:  
  
```  
Console.WriteLine(student.First + " " + student.Last);  
```  
  
## Compiling the Code  
  
-   To run this code, copy and paste the class into a Visual C# console application project that has been created in [!INCLUDE[vs_current_short](../../../includes/vs-current-short-md.md)]. By default, this project targets version 3.5 of the [!INCLUDE[dnprdnshort](../../../includes/dnprdnshort-md.md)], and it will have a reference to System.Core.dll and a `using` directive for System.Linq. If one or more of these requirements are missing from the project, you can add them manually. For more information, see [How to: Create a LINQ Project](http://msdn.microsoft.com/library/a929e653-09a3-44be-881f-68ca33f192b2).  
  
## See Also  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)   
 [Anonymous Types](../../../csharp/programming-guide/classes-and-structs/anonymous-types.md)   
 [LINQ Query Expressions](../../../csharp/programming-guide/linq-query-expressions/index.md)