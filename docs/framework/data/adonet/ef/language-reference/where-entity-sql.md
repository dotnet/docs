---
title: "WHERE (Entity SQL)"
ms.date: "03/30/2017"
ms.assetid: a8e1061e-0028-4a6f-8f19-b9f48e96c4b8
---
# WHERE (Entity SQL)
The WHERE clause is applied directly after the [FROM](from-entity-sql.md) clause.  
  
## Syntax  
  
```  
[ WHERE expression ]  
```  
  
## Arguments  
 `expression`  
 A Boolean type.  
  
## Remarks  
 The WHERE clause has the same semantics as described for Transact-SQL. It restricts the objects produced by the query expression by limiting the elements of the source collections to those that pass the condition.  
  
```  
select c from cs as c where e  
```  
  
 The expression `e` must have the type Boolean.  
  
 The WHERE clause is applied directly after the FROM clause and before any grouping, ordering, or projection takes place. All element names defined in the FROM clause are visible to the expression of the WHERE clause.  
  
## See also

- [Entity SQL Reference](entity-sql-reference.md)
- [Query Expressions](query-expressions-entity-sql.md)
