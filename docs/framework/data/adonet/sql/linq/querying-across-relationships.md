---
title: "Querying Across Relationships"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
ms.assetid: 297878d0-685b-4c01-b2e0-9d731b7322bc
caps.latest.revision: 5
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Querying Across Relationships
References to other objects or collections of other objects in your class definitions directly correspond to foreign-key relationships in the database. You can use these relationships when you query by using dot notation to access the relationship properties and navigate from one object to another. These access operations translate to more complex joins or correlated subqueries in the equivalent SQL.  
  
 For example, the following query navigates from orders to customers as a way to restrict the results to only those orders for customers located in London.  
  
 [!code-csharp[DLinqQueryConcepts#3](../../../../../../samples/snippets/csharp/VS_Snippets_Data/DLinqQueryConcepts/cs/Program.cs#3)]
 [!code-vb[DLinqQueryConcepts#3](../../../../../../samples/snippets/visualbasic/VS_Snippets_Data/DLinqQueryConcepts/vb/Module1.vb#3)]  
  
 If relationship properties did not exist you would have to write them manually as *joins*, just as you would do in a SQL query, as in the following code:  
  
 [!code-csharp[DLinqQueryConcepts#4](../../../../../../samples/snippets/csharp/VS_Snippets_Data/DLinqQueryConcepts/cs/Program.cs#4)]
 [!code-vb[DLinqQueryConcepts#4](../../../../../../samples/snippets/visualbasic/VS_Snippets_Data/DLinqQueryConcepts/vb/Module1.vb#4)]  
  
 You can use the *relationship* property to define this particular relationship one time. You can then use the more convenient dot syntax. But relationship properties exist more importantly because domain-specific object models are typically defined as hierarchies or graphs. The objects that you program against have references to other objects. It is only a happy coincidence that object-to-object relationships correspond to foreign-key-styled relationships in databases. Property access then provides a convenient way to write joins.  
  
 With regard to this, relationship properties are more important on the results side of a query than as part of the query itself. After the query has retrieved data about a particular customer, the class definition indicates that customers have orders. In other words, you expect the `Orders` property of a particular customer to be a collection that is populated with all the orders from that customer. That is in fact the contract you declared by defining the classes in this manner. You expect to see the orders there even if the query did not request orders. You expect your object model to maintain an illusion that it is an in-memory extension of the database with related objects immediately available.  
  
 Now that you have relationships, you can write queries by referring to the relationship properties defined in your classes. These relationship references correspond to foreign-key relationships in the database. Operations that use these relationships translate to more complex joins in the equivalent SQL. As long as you have defined a relationship (using the <xref:System.Data.Linq.Mapping.AssociationAttribute> attribute), you do not have to code an explicit join in [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)].  
  
 To help maintain this illusion, [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] implements a technique called *deferred loading*. For more information, see [Deferred versus Immediate Loading](../../../../../../docs/framework/data/adonet/sql/linq/deferred-versus-immediate-loading.md).  
  
 Consider the following SQL query to project a list of `CustomerID`-`OrderID` pairs:  
  
```  
SELECT t0.CustomerID, t1.OrderID  
FROM   Customers AS t0 INNER JOIN  
          Orders AS t1 ON t0.CustomerID = t1.CustomerID  
WHERE  (t0.City = @p0)  
```  
  
 To obtain the same results by using [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)], you use the `Orders` property reference already existing in the `Customer` class. The `Orders` reference provides the necessary information to execute the query and project the `CustomerID`-`OrderID` pairs, as in the following code:  
  
 [!code-csharp[DLinqQueryConcepts#5](../../../../../../samples/snippets/csharp/VS_Snippets_Data/DLinqQueryConcepts/cs/Program.cs#5)]
 [!code-vb[DLinqQueryConcepts#5](../../../../../../samples/snippets/visualbasic/VS_Snippets_Data/DLinqQueryConcepts/vb/Module1.vb#5)]  
  
 You can also do the reverse. That is, you can query `Orders` and use its `Customer` relationship reference to access information about the associated `Customer` object. The following code projects the same `CustomerID`-`OrderID` pairs as before, but this time by querying `Orders` instead of `Customers`.  
  
 [!code-csharp[DLinqQueryConcepts#6](../../../../../../samples/snippets/csharp/VS_Snippets_Data/DLinqQueryConcepts/cs/Program.cs#6)]
 [!code-vb[DLinqQueryConcepts#6](../../../../../../samples/snippets/visualbasic/VS_Snippets_Data/DLinqQueryConcepts/vb/Module1.vb#6)]  
  
## See Also  
 [Query Concepts](../../../../../../docs/framework/data/adonet/sql/linq/query-concepts.md)
