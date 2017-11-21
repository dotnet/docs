---
title: Perform left outer joins
description: How to perform left outer joins.
keywords: .NET, .NET Core, C#
author: BillWagner
manager: wpickett
ms.author: wiwagn
ms.date: 12/1/2016
ms.topic: article
ms.prod: .net
ms.technology: devlang-csharp
ms.assetid: f542cee6-3169-4dcf-a631-3a6a79ccd473
---
# Perform left outer joins
A left outer join is a join in which each element of the first collection is returned, regardless of whether it has any correlated elements in the second collection. You can use LINQ to perform a left outer join by calling the <xref:System.Linq.Enumerable.DefaultIfEmpty%2A> method on the results of a group join.  
  
## Example  
 The following example demonstrates how to use the <xref:System.Linq.Enumerable.DefaultIfEmpty%2A> method on the results of a group join to perform a left outer join.  
  
 The first step in producing a left outer join of two collections is to perform an inner join by using a group join. (See [Perform inner joins](perform-inner-joins.md) for an explanation of this process.) In this example, the list of `Person` objects is inner-joined to the list of `Pet` objects based on a `Person` object that matches `Pet.Owner`.  
  
 The second step is to include each element of the first (left) collection in the result set even if that element has no matches in the right collection. This is accomplished by calling <xref:System.Linq.Enumerable.DefaultIfEmpty%2A> on each sequence of matching elements from the group join. In this example, <xref:System.Linq.Enumerable.DefaultIfEmpty%2A> is called on each sequence of matching `Pet` objects. The method returns a collection that contains a single, default value if the sequence of matching `Pet` objects is empty for any `Person` object, thereby ensuring that each `Person` object is represented in the result collection.  
  
> [!NOTE]
>  The default value for a reference type is `null`; therefore, the example checks for a null reference before accessing each element of each `Pet` collection.  
  
 [!code-csharp[CsLINQProgJoining#7](../../../samples/snippets/csharp/concepts/linq/how-to-perform-left-outer-joins_1.cs)]  
 
## See also  
 <xref:System.Linq.Enumerable.Join%2A>  
 <xref:System.Linq.Enumerable.GroupJoin%2A>  
 [Perform inner joins](perform-inner-joins.md)  
 [Perform grouped joins](perform-grouped-joins.md)  
 [Anonymous types](../programming-guide/classes-and-structs/anonymous-types.md)  
 
