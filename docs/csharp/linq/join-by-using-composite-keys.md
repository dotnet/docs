---
title: Join by using composite keys
description: How to join by using composite keys.
keywords: .NET, .NET Core, C#
author: BillWagner
manager: wpickett
ms.author: wiwagn
ms.date: 12/1/2016
ms.topic: article
ms.prod: .net
ms.technology: devlang-csharp
ms.assetid: da70b54d-3213-45eb-8437-fbe75cbcf935
---
# Join by using composite keys

This example shows how to perform join operations in which you want to use more than one key to define a match. This is accomplished by using a composite key. You create a composite key as an anonymous type or named typed with the values that you want to compare. If the query variable will be passed across method boundaries, use a named type that overrides <xref:System.Object.Equals%2A> and <xref:System.Object.GetHashCode%2A> for the key. The names of the properties, and the order in which they occur, must be identical in each key.  
  
## Example  
 The following example demonstrates how to use a composite key to join data from three tables:  
  
```csharp  
var query = from o in db.Orders  
    from p in db.Products  
    join d in db.OrderDetails   
        on new {o.OrderID, p.ProductID} equals new {d.OrderID,        d.ProductID} into details  
        from d in details  
        select new {o.OrderID, p.ProductID, d.UnitPrice};  
```  
  
 Type inference on composite keys depends on the names of the properties in the keys, and the order in which they occur. If the properties in the source sequences do not have the same names, you must assign new names in the keys. For example, if the `Orders` table and `OrderDetails` table each used different names for their columns, you could create composite keys by assigning identical names in the anonymous types:  
  
```csharp  
join...on new {Name = o.CustomerName, ID = o.CustID} equals   
    new {Name = d.CustName, ID = d.CustID }  
```  
  
 Composite keys can be also used in a `group` clause.  

## See also  
 [LINQ query expressions](index.md)  
 [join clause](../language-reference/keywords/join-clause.md)  
 [group clause](../language-reference/keywords/group-clause.md)
