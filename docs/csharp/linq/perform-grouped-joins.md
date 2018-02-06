---
title: Perform grouped joins
description: How to perform grouped joins.
keywords: .NET, .NET Core, C#
author: BillWagner
manager: wpickett
ms.author: wiwagn
ms.date: 12/1/2016
ms.topic: article
ms.prod: .net
ms.technology: devlang-csharp
ms.assetid: 9667daf9-a5fd-4b43-a5c4-a9c2b744000e
---
# Perform grouped joins

The group join is useful for producing hierarchical data structures. It pairs each element from the first collection with a set of correlated elements from the second collection.  
  
 For example, a class or a relational database table named `Student` might contain two fields: `Id` and `Name`. A second class or relational database table named `Course` might contain two fields: `StudentId` and `CourseTitle`. A group join of these two data sources, based on matching `Student.Id` and `Course.StudentId`, would group each `Student` with a collection of `Course` objects (which might be empty).  
  
> [!NOTE]
>  Each element of the first collection appears in the result set of a group join regardless of whether correlated elements are found in the second collection. In the case where no correlated elements are found, the sequence of correlated elements for that element is empty. The result selector therefore has access to every element of the first collection. This differs from the result selector in a non-group join, which cannot access elements from the first collection that have no match in the second collection.  
  
 The first example in this topic shows you how to perform a group join. The second example shows you how to use a group join to create XML elements.  
  
## Example  
  
### Group join example  
 The following example performs a group join of objects of type `Person` and `Pet` based on the `Person` matching the `Pet.Owner` property. Unlike a non-group join, which would produce a pair of elements for each match, the group join produces only one resulting object for each element of the first collection, which in this example is a `Person` object. The corresponding elements from the second collection, which in this example are `Pet` objects, are grouped into a collection. Finally, the result selector function creates an anonymous type for each match that consists of `Person.FirstName` and a collection of `Pet` objects.  
  
 [!code-csharp[CsLINQProgJoining#5](../../../samples/snippets/csharp/concepts/linq/how-to-perform-grouped-joins_1.cs)]  
  
## Example  
  
### Group join to create XML example  
 Group joins are ideal for creating XML by using LINQ to XML. The following example is similar to the previous example except that instead of creating anonymous types, the result selector function creates XML elements that represent the joined objects.  
  
 [!code-csharp[CsLINQProgJoining#6](../../../samples/snippets/csharp/concepts/linq/how-to-perform-grouped-joins_2.cs)]  
 
## See also  
 <xref:System.Linq.Enumerable.Join%2A>  
 <xref:System.Linq.Enumerable.GroupJoin%2A>  
 [Perform inner joins](perform-inner-joins.md)  
 [Perform left outer joins](perform-left-outer-joins.md)  
 [Anonymous types](../programming-guide/classes-and-structs/anonymous-types.md)  
 
