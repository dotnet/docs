---
title: "GROUPPARTITION (Entity SQL)"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: d0482e9b-086c-451c-9dfa-ccb024a9efb6
caps.latest.revision: 3
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# GROUPPARTITION (Entity SQL)
Returns a collection of argument values that are projected off the current group partition to which the aggregate is related. The `GroupPartition` aggregate is a group-based aggregate and has no collection-based form.  
  
## Syntax  
  
```  
GROUPPARTITION( [ALL|DISTINCT] expression )  
```  
  
## Arguments  
 `expression`  
 Any [!INCLUDE[esql](../../../../../../includes/esql-md.md)] expression.  
  
## Remarks  
 The following query produces a list of products and a collection of order line quantities per each product:  
  
```  
select p, GroupPartition(ol.Quantity) from LOB.OrderLines as ol  
  group by ol.Product as p  
```  
  
 The following two queries are semantically equal:  
  
```  
select p, Sum(GroupPartition(ol.Quantity)) from LOB.OrderLines as ol  
  group by ol.Product as p  
select p, Sum(ol.Quantity) from LOB.OrderLines as ol  
  group by ol.Product as p  
```  
  
 The `GROUPPARTITION` operator can be used in conjunction with user-defined aggregate functions.  
  
 `GROUPPARTITION` is a special aggregate operator that holds a reference to the grouped input set. This reference can be used anywhere in the query where GROUP BY is in scope. For example,  
  
```  
select p, GroupPartition(ol.Quantity) from LOB.OrderLines as ol group by ol.Product as p  
```  
  
 With a regular GROUP BY, the results of the grouping are hidden. You can only use the results in an aggregate function. In order to see the results of the grouping, you have to correlate the results of the grouping and the input set by using a subquery. The following two queries are equivalent:  
  
```  
select p, (select q from GroupPartition(ol.Quantity) as q) from LOB.OrderLines as ol group by ol.Product as p  
select p, (select ol.Quantity as q from LOB.OrderLines as ol2 where ol2.Product = p) from LOB.OrderLines as ol group by ol.Product as p  
```  
  
 As seen from the example, the GROUPPARTITION aggregate operator makes it easier to get a reference to the input set after the grouping.  
  
 The GROUPPARTITION operator can specify any [!INCLUDE[esql](../../../../../../includes/esql-md.md)] expression in the operator input when you use the `expression` parameter.  
  
 For instance all of the following input expressions to the group partition are valid:  
  
```  
select groupkey, GroupPartition(b) from {1,2,3} as a inner join {4,5,6} as b on true group by a as groupkey  
select groupkey, GroupPartition(1) from {1,2,3} as a inner join {4,5,6} as b on true group by a as groupkey  
select groupkey, GroupPartition(a + b) from {1,2,3} as a inner join {4,5,6} as b on true group by a as groupkey  
select groupkey, GroupPartition({a + b}) from {1,2,3} as a inner join {4,5,6} as b on true group by a as groupkey  
select groupkey, GroupPartition({42}) from {1,2,3} as a inner join {4,5,6} as b on true group by a as groupkey  
select groupkey, GroupPartition(b > a) from {1,2,3} as a inner join {4,5,6} as b on true group by a as groupkey  
```  
  
## Example  
 The following example shows how to use the GROUPPARTITION clause with the GROUP BY clause. The GROUP BY clause groups `SalesOrderHeader` entities by their `Contact`. The GROUPPARTITION clause then projects the `TotalDue` property for each group, resulting in a collection of decimals.  
  
 [!code-csharp[DP EntityServices Concepts 2#Collection_GroupPartition](../../../../../../samples/snippets/csharp/VS_Snippets_Data/dp entityservices concepts 2/cs/entitysql.cs#collection_grouppartition)]
