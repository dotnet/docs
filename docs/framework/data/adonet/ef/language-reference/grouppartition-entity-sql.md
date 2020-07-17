---
title: "GROUPPARTITION (Entity SQL)"
ms.date: "03/30/2017"
ms.assetid: d0482e9b-086c-451c-9dfa-ccb024a9efb6
---
# GROUPPARTITION (Entity SQL)
Returns a collection of argument values that are projected off the current group partition to which the aggregate is related. The `GroupPartition` aggregate is a group-based aggregate and has no collection-based form.  
  
## Syntax  
  
```sql  
GROUPPARTITION( [ALL|DISTINCT] expression )  
```  
  
## Arguments  
 `expression`  
 Any [!INCLUDE[esql](../../../../../../includes/esql-md.md)] expression.  
  
## Remarks  
 The following query produces a list of products and a collection of order line quantities per each product:  
  
```sql  
SELECT p, GroupPartition(ol.Quantity) FROM LOB.OrderLines AS ol
  GROUP BY ol.Product AS p
```  
  
 The following two queries are semantically equal:  
  
```sql  
SELECT p, Sum(GroupPartition(ol.Quantity)) FROM LOB.OrderLines AS ol
  GROUP BY ol.Product AS p
SELET p, Sum(ol.Quantity) FROM LOB.OrderLines AS ol
  group by ol.Product as p  
```  
  
 The `GROUPPARTITION` operator can be used in conjunction with user-defined aggregate functions.  
  
`GROUPPARTITION` is a special aggregate operator that holds a reference to the grouped input set. This reference can be used anywhere in the query where GROUP BY is in scope. For example:
  
```sql  
SELECT p, GroupPartition(ol.Quantity) FROM LOB.OrderLines AS ol GROUP BY ol.Product AS p
```  
  
 With a regular `GROUP BY`, the results of the grouping are hidden. You can only use the results in an aggregate function. In order to see the results of the grouping, you have to correlate the results of the grouping and the input set by using a subquery. The following two queries are equivalent:  
  
```sql  
SELET p, (SELECT q FROM GroupPartition(ol.Quantity) AS q) FROM LOB.OrderLines AS ol GROUP BY ol.Product AS p
SELECT p, (SELECT ol.Quantity AS q FROM LOB.OrderLines AS ol2 WHERE ol2.Product = p) FROM LOB.OrderLines AS ol GROUP BY ol.Product AS p
```  
  
 As seen from the example, the GROUPPARTITION aggregate operator makes it easier to get a reference to the input set after the grouping.  
  
 The GROUPPARTITION operator can specify any [!INCLUDE[esql](../../../../../../includes/esql-md.md)] expression in the operator input when you use the `expression` parameter.  
  
 For instance all of the following input expressions to the group partition are valid:  
  
```sql  
SELECT groupkey, GroupPartition(b) FROM {1,2,3} AS a INNER JOIN {4,5,6} AS b ON true GROUP BY a AS groupkey
SELECT groupkey, GroupPartition(1) FROM {1,2,3} AS a INNER JOIN {4,5,6} AS b ON true GROUP BY a AS groupkey
SELECT groupkey, GroupPartition(a + b) FROM {1,2,3} AS a INNER JOIN {4,5,6} AS b ON true GROUP BY a AS groupkey
SELECT groupkey, GroupPartition({a + b}) FROM {1,2,3} AS a INNER JOIN {4,5,6} AS b ON true GROUP BY a AS groupkey  
SELECT groupkey, GroupPartition({42}) FROM {1,2,3} AS a INNER JOIN {4,5,6} AS b ON true GROUP BY a AS groupkey  
SELECT groupkey, GroupPartition(b > a) FROM {1,2,3} AS a INNER JOIN {4,5,6} AS b ON true GROUP BY a AS groupkey  
```  
  
## Example  
 The following example shows how to use the GROUPPARTITION clause with the GROUP BY clause. The GROUP BY clause groups `SalesOrderHeader` entities by their `Contact`. The GROUPPARTITION clause then projects the `TotalDue` property for each group, resulting in a collection of decimals.  
  
 [!code-sql[DP EntityServices Concepts#Collection_GroupPartition](~/samples/snippets/tsql/VS_Snippets_Data/dp entityservices concepts/tsql/entitysql.sql#collection_grouppartition)]
