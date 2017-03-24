---
title: "How to: Join by Using Composite Keys (C# Programming Guide) | Microsoft Docs"
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
  - "composite keys [LINQ in C#]"
  - "joins [C#]"
  - "query expressions [LINQ in C#], joins"
  - "joins [C#], composite keys"
  - "queries [LINQ in C#], joins"
ms.assetid: 3e015b3f-9cca-4b0c-aa97-dca0d36ea592
caps.latest.revision: 8
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
---
# How to: Join by Using Composite Keys (C# Programming Guide)
[!INCLUDE[csharpbanner](../../../includes/csharpbanner.md)]

This example shows how to perform join operations in which you want to use more than one key to define a match. This is accomplished by using a composite key. You create a composite key as an anonymous type or named typed with the values that you want to compare. If the query variable will be passed across method boundaries, use a named type that overrides <xref:System.Object.Equals%2A> and <xref:System.Object.GetHashCode%2A> for the key. The names of the properties, and the order in which they occur, must be identical in each key.  
  
## Example  
 The following example demonstrates how to use a composite key to join data from three tables:  
  
```  
var query = from o in db.Orders  
    from p in db.Products  
    join d in db.OrderDetails   
        on new {o.OrderID, p.ProductID} equals new {d.OrderID,        d.ProductID} into details  
        from d in details  
        select new {o.OrderID, p.ProductID, d.UnitPrice};  
```  
  
 Type inference on composite keys depends on the names of the properties in the keys, and the order in which they occur. If the properties in the source sequences do not have the same names, you must assign new names in the keys. For example, if the `Orders` table and `OrderDetails` table each used different names for their columns, you could create composite keys by assigning identical names in the anonymous types:  
  
```  
join...on new {Name = o.CustomerName, ID = o.CustID} equals   
    new {Name = d.CustName, ID = d.CustID }  
```  
  
 Composite keys can be also used in a `group` clause.  
  
## Compiling the Code  
  
-   To compile and run this code, follow these steps:  
  
-   Open [How to: Connect to the Northwind Database](../Topic/How%20to:%20Connect%20to%20the%20Northwind%20Database.md) and follow the instructions to set up the project and create the database connection. For more information, see [How to: Install Sample Databases](../Topic/How%20to:%20Install%20Sample%20Databases.md).  
  
-   In samples.cs, create a new empty method that takes a Northwind input parameter named db (similar to the other methods in that file). Paste the code from this example into the method body.  
  
-   Modify program.cs to call the new method from `Main`.  
  
-   Press F5 to compile and run the query.  
  
## See Also  
 [LINQ Query Expressions](../../../csharp/programming-guide/linq-query-expressions/index.md)   
 [join clause](../../../csharp/language-reference/keywords/join-clause.md)   
 [group clause](../../../csharp/language-reference/keywords/group-clause.md)