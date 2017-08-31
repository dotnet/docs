---
title: "How to: Perform Grouped Joins (C# Programming Guide) | Microsoft Docs"
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
  - "group joins [LINQ in C#]"
  - "joins [C#], group"
  - "query expressions [LINQ in C#], joins"
  - "queries [LINQ in C#], joins"
ms.assetid: 31b654c0-77ac-43fa-be11-aa38e14cae2d
caps.latest.revision: 23
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
---
# How to: Perform Grouped Joins (C# Programming Guide)
[!INCLUDE[csharpbanner](../../../includes/csharpbanner.md)]

The group join is useful for producing hierarchical data structures. It pairs each element from the first collection with a set of correlated elements from the second collection.  
  
 For example, a class or a relational database table named Student might contain two fields: Id and Name. A second class or relational database table named Course might contain two fields: StudentId and CourseTitle. A group join of these two data sources, based on matching Student.Id and Course.StudentId, would group each Student with a collection of Course objects (which might be empty).  
  
> [!NOTE]
>  Each element of the first collection appears in the result set of a group join regardless of whether correlated elements are found in the second collection. In the case where no correlated elements are found, the sequence of correlated elements for that element is empty. The result selector therefore has access to every element of the first collection. This differs from the result selector in a non-group join, which cannot access elements from the first collection that have no match in the second collection.  
  
 The first example in this topic shows you how to perform a group join. The second example shows you how to use a group join to create XML elements.  
  
## Example  
  
### Group Join Example  
 The following example performs a group join of objects of type `Person` and `Pet` based on the `Person` matching the `Pet.Owner` property. Unlike a non-group join, which would produce a pair of elements for each match, the group join produces only one resulting object for each element of the first collection, which in this example is a `Person` object. The corresponding elements from the second collection, which in this example are `Pet` objects, are grouped into a collection. Finally, the result selector function creates an anonymous type for each match that consists of `Person.FirstName` and a collection of `Pet` objects.  
  
 [!code-csharp[CsLINQProgJoining#5](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/CsLINQProgJoining/CS/joins.cs#5)]  
  
## Example  
  
### Group Join to Create XML Example  
 Group joins are ideal for creating XML by using [!INCLUDE[sqltecxlinq](../../../includes/sqltecxlinq-md.md)]. The following example is similar to the previous example except that instead of creating anonymous types, the result selector function creates XML elements that represent the joined objects. For more information about [!INCLUDE[sqltecxlinq](../../../includes/sqltecxlinq-md.md)], see [LINQ to XML](../Topic/LINQ%20to%20XML.md).  
  
 [!code-csharp[CsLINQProgJoining#6](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/CsLINQProgJoining/CS/joins.cs#6)]  
  
## Compiling the Code  
  
-   Create a new **Console Application** project in [!INCLUDE[vs_current_short](../../../includes/vs-current-short-md.md)].  
  
-   Add a reference to System.Core.dll and to System.Xml.Linq.dll if they are not already referenced.  
  
-   Include the <xref:System.Linq> and <xref:System.Xml.Linq> namespaces.  
  
-   Copy and paste the code from the example into the program.cs file, below the `Main` method. Add a line of code to the `Main` method to call the method you pasted in.  
  
-   Run the program.  
  
## See Also  
 <xref:System.Linq.Enumerable.Join%2A>   
 <xref:System.Linq.Enumerable.GroupJoin%2A>   
 [Join Operations](../Topic/Join%20Operations.md)   
 [How to: Perform Inner Joins](../../../csharp/programming-guide/linq-query-expressions/how-to-perform-inner-joins.md)   
 [How to: Perform Left Outer Joins](../../../csharp/programming-guide/linq-query-expressions/how-to-perform-left-outer-joins.md)   
 [LINQ to XML](../Topic/LINQ%20to%20XML.md)   
 [Anonymous Types](../../../csharp/programming-guide/classes-and-structs/anonymous-types.md)   
 [Anonymous Types](../../../visual-basic/programming-guide/language-features/objects-and-classes/anonymous-types.md)