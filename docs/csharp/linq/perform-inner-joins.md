---
title: Perform inner joins
description: How to perform inner joins.
keywords: .NET, .NET Core, C#
author: BillWagner
manager: wpickett
ms.author: wiwagn
ms.date: 12/1/2016
ms.topic: article
ms.prod: .net
ms.technology: devlang-csharp
ms.assetid: 45bceed6-f549-4114-a9b1-b44feb497742
---
# Perform inner joins

In relational database terms, an *inner join* produces a result set in which each element of the first collection appears one time for every matching element in the second collection. If an element in the first collection has no matching elements, it does not appear in the result set. The <xref:System.Linq.Enumerable.Join%2A> method, which is called by the `join` clause in C#, implements an inner join.  
  
 This topic shows you how to perform four variations of an inner join:  
  
-   A simple inner join that correlates elements from two data sources based on a simple key.  
  
-   An inner join that correlates elements from two data sources based on a *composite* key. A composite key, which is a key that consists of more than one value, enables you to correlate elements based on more than one property.  
  
-   A *multiple join* in which successive join operations are appended to each other.  
  
-   An inner join that is implemented by using a group join.  
  
## Example  
  
## Simple key join example  
 The following example creates two collections that contain objects of two user-defined types, `Person` and `Pet`. The query uses the `join` clause in C# to match `Person` objects with `Pet` objects whose `Owner` is that `Person`. The `select` clause in C# defines how the resulting objects will look. In this example the resulting objects are anonymous types that consist of the owner's first name and the pet's name.  
  
 [!code-csharp[CsLINQProgJoining#1](../../../samples/snippets/csharp/concepts/linq/how-to-perform-inner-joins_1.cs)]  
  
 Note that the `Person` object whose `LastName` is "Huff" does not appear in the result set because there is no `Pet` object that has `Pet.Owner` equal to that `Person`.  
  
## Example  
  
## Composite key join example  
 Instead of correlating elements based on just one property, you can use a composite key to compare elements based on multiple properties. To do this, specify the key selector function for each collection to return an anonymous type that consists of the properties you want to compare. If you label the properties, they must have the same label in each key's anonymous type. The properties must also appear in the same order.  
  
 The following example uses a list of `Employee` objects and a list of `Student` objects to determine which employees are also students. Both of these types have a `FirstName` and a `LastName` property of type <xref:System.String>. The functions that create the join keys from each list's elements return an anonymous type that consists of the `FirstName` and `LastName` properties of each element. The join operation compares these composite keys for equality and returns pairs of objects from each list where both the first name and the last name match.  
  
 [!code-csharp[CsLINQProgJoining#2](../../../samples/snippets/csharp/concepts/linq/how-to-perform-inner-joins_2.cs)]  
  
## Example  
  
## Multiple join example  
 Any number of join operations can be appended to each other to perform a multiple join. Each `join` clause in C# correlates a specified data source with the results of the previous join.  
  
 The following example creates three collections: a list of `Person` objects, a list of `Cat` objects, and a list of `Dog` objects.  
  
 The first `join` clause in C# matches people and cats based on a `Person` object matching `Cat.Owner`. It returns a sequence of anonymous types that contain the `Person` object and `Cat.Name`.  
  
 The second `join` clause in C# correlates the anonymous types returned by the first join with `Dog` objects in the supplied list of dogs, based on a composite key that consists of the `Owner` property of type `Person`, and the first letter of the animal's name. It returns a sequence of anonymous types that contain the `Cat.Name` and `Dog.Name` properties from each matching pair. Because this is an inner join, only those objects from the first data source that have a match in the second data source are returned.  
  
 [!code-csharp[CsLINQProgJoining#3](../../../samples/snippets/csharp/concepts/linq/how-to-perform-inner-joins_3.cs)]  
  
## Example  
  
## Inner join by using grouped join example  
 The following example shows you how to implement an inner join by using a group join.  
  
 In `query1`, the list of `Person` objects is group-joined to the list of `Pet` objects based on the `Person` matching the `Pet.Owner` property. The group join creates a collection of intermediate groups, where each group consists of a `Person` object and a sequence of matching `Pet` objects.  
  
 By adding a second `from` clause to the query, this sequence of sequences is combined (or flattened) into one longer sequence. The type of the elements of the final sequence is specified by the `select` clause. In this example, that type is an anonymous type that consists of the `Person.FirstName` and `Pet.Name` properties for each matching pair.  
  
 The result of `query1` is equivalent to the result set that would have been obtained by using the `join` clause without the `into` clause to perform an inner join. The `query2` variable demonstrates this equivalent query.  
  
 [!code-csharp[CsLINQProgJoining#4](../../../samples/snippets/csharp/concepts/linq/how-to-perform-inner-joins_4.cs)]  
  
## See also  
 <xref:System.Linq.Enumerable.Join%2A>  
 <xref:System.Linq.Enumerable.GroupJoin%2A>  
 [Perform grouped joins](perform-grouped-joins.md)  
 [Perform left outer joins](perform-left-outer-joins.md)  
 [Anonymous types](../programming-guide/classes-and-structs/anonymous-types.md)  
 
