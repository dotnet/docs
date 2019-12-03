---
title: "OFTYPE (Entity SQL)"
ms.date: "03/30/2017"
ms.assetid: 6d259ca7-bbf0-40f8-a154-181d25c0d67e
---
# OFTYPE (Entity SQL)
Returns a collection of objects from a query expression that is of a specific type.  
  
## Syntax  
  
```sql  
OFTYPE ( expression, [ONLY] test_type )  
```  
  
## Arguments  
 `expression`  
 Any valid query expression that returns a collection of objects.  
  
 `test_type`  
 The type to test each object returned by `expression` against. The type must be qualified by a namespace.  
  
## Return Value  
 A collection of objects that are of type `test_type`, or a base type or derived type of `test_type`. If ONLY is specified, only instances of the `test_type` or an empty collection will be returned.  
  
## Remarks  
 An `OFTYPE` expression specifies a type expression that is issued to perform a type test against each element of a collection.  The `OFTYPE` expression produces a new collection of the specified type containing only those elements that were either equivalent to that type or a sub-type of it.  
  
 An `OFTYPE` expression is an abbreviation of the following query expression:  
  
```sql  
select value treat(t as T) from ts as t where t is of (T)  
```  
  
 Given that a Manager is a subtype of Employee, the following expression produces a collection of only managers from a collection of employees:  
  
```sql  
OfType(employees, NamespaceName.Manager)  
```  
  
 It is also possible to up cast a collection using the type filter:  
  
```sql
OfType(executives, NamespaceName.Manager)  
```  
  
 Since all executives are managers, the resulting collection still contains all the original executives, though the collection is now typed as a collection of managers.  
  
 The following table shows the behavior of the `OFTYPE` operator over some patterns. All exceptions are thrown from the client side before the provider is invoked:  
  
|Pattern|Behavior|  
|-------------|--------------|  
|OFTYPE(Collection(EntityType), EntityType)|Collection(EntityType)|  
|OFTYPE(Collection(ComplexType), ComplexType)|Throws|  
|OFTYPE(Collection(RowType), RowType)|Throws|  
  
## Example  
 The following [!INCLUDE[esql](../../../../../../includes/esql-md.md)] query uses the OFTYPE operator to return a collection of OnsiteCourse objects from a collection of Course objects. The query is based on the [School Model](https://docs.microsoft.com/previous-versions/dotnet/netframework-4.0/bb896300(v=vs.100)).  
  
 [!code-sql[DP EntityServices Concepts#OFTYPE](~/samples/snippets/tsql/VS_Snippets_Data/dp entityservices concepts/tsql/entitysql.sql#oftype)]  
  
## See also

- [Entity SQL Reference](entity-sql-reference.md)
