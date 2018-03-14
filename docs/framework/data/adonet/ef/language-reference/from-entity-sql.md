---
title: "FROM (Entity SQL)"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: ff3e3048-0d5d-4502-ae5c-9187fcbd0514
caps.latest.revision: 3
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# FROM (Entity SQL)
Specifies the collection used in [SELECT](../../../../../../docs/framework/data/adonet/ef/language-reference/select-entity-sql.md) statements.  
  
## Syntax  
  
```  
FROM expression [ ,...n ] as C  
```  
  
## Arguments  
 `expression`  
 Any valid query expression that yields a collection to use as a source in a `SELECT` statement.  
  
## Remarks  
 A `FROM` clause is a comma-separated list of one or more `FROM` clause items. The `FROM` clause can be used to specify one or more sources for a `SELECT` statement. The simplest form of a `FROM` clause is a single query expression that identifies a collection and an alias used as the source in a `SELECT` statement, as illustrated in the following example:  
  
 `FROM C as c`  
  
## FROM Clause Items  
 Each `FROM` clause item refers to a source collection in the [!INCLUDE[esql](../../../../../../includes/esql-md.md)] query. [!INCLUDE[esql](../../../../../../includes/esql-md.md)] supports the following classes of `FROM` clause items: simple `FROM` clause items, `JOIN FROM` clause items, and `APPLY FROM` clause items. Each of these `FROM` clause items is described in more detail in the following sections.  
  
### Simple FROM Clause Item  
 The simplest `FROM` clause item is a single expression that identifies a collection and an alias. The expression can simply be an entity set, or a subquery, or any other expression that is a collection type. The following is an example:  
  
```  
LOB.Customers as c  
```  
  
 The alias specification is optional. An alternate specification of the above from clause item could be the following:  
  
```  
LOB.Customers  
```  
  
 If no alias is specified, [!INCLUDE[esql](../../../../../../includes/esql-md.md)] attempts to generate an alias based on the collection expression.  
  
### JOIN FROM Clause Item  
 A `JOIN FROM` clause item represents a join between two `FROM` clause items. [!INCLUDE[esql](../../../../../../includes/esql-md.md)] supports cross joins, inner joins, left and right outer joins, and full outer joins. All these joins are supported similar to the way that they are supported in [!INCLUDE[tsql](../../../../../../includes/tsql-md.md)]. As in [!INCLUDE[tsql](../../../../../../includes/tsql-md.md)], the two `FROM` clause items involved in the `JOIN` must be independent. That is, they cannot be correlated. A `CROSS APPLY` or `OUTER APPLY` can be used for these cases.  
  
#### Cross Joins  
 A `CROSS JOIN` query expression produces the Cartesian product of the two collections, as illustrated in the following example:  
  
 `FROM C AS c CROSS JOIN D as d`  
  
#### Inner Joins  
 An `INNER JOIN` produces a constrained Cartesian product of the two collections, as illustrated in the following example:  
  
 `FROM C AS c [INNER] JOIN D AS d ON e`  
  
 The previous query expression processes a combination of every element of the collection on the left paired against every element of the collection on the right, where the `ON` condition is true. If no `ON` condition is specified, an `INNER JOIN` degenerates to a `CROSS JOIN`.  
  
#### Left Outer Joins and Right Outer Joins  
 An `OUTER JOIN` query expression produces a constrained Cartesian product of the two collections, as illustrated in the following example:  
  
 `FROM C AS c LEFT OUTER JOIN D AS d ON e`  
  
 The previous query expression processes a combination of every element of the collection on the left paired against every element of the collection on the right, where the `ON` condition is true. If the `ON` condition is false, the expression still processes a single instance of the element on the left paired against the element on the right, with the value null.  
  
 A `RIGHT OUTER JOIN` may be expressed in a similar manner.  
  
#### Full Outer Joins  
 An explicit `FULL OUTER JOIN` produces a constrained Cartesian product of the two collections as illustrated in the following example:  
  
 `FROM C AS c FULL OUTER JOIN D AS d ON e`  
  
 The previous query expression processes a combination of every element of the collection on the left paired against every element of the collection on the right, where the `ON` condition is true. If the `ON` condition is false, the expression still processes one instance of the element on the left paired against the element on the right, with the value null. It also processes one instance of the element on the right paired against the element on the left, with the value null.  
  
> [!NOTE]
>  To preserve compatibility with SQL-92, in [!INCLUDE[tsql](../../../../../../includes/tsql-md.md)] the OUTER keyword is optional. Therefore, `LEFT JOIN`, `RIGHT JOIN`, and `FULL JOIN` are synonyms for `LEFT OUTER JOIN`, `RIGHT OUTER JOIN`, and `FULL OUTER JOIN`.  
  
### APPLY Clause Item  
 [!INCLUDE[esql](../../../../../../includes/esql-md.md)] supports two kinds of `APPLY`: `CROSS APPLY` and `OUTER APPLY`.  
  
 A `CROSS APPLY` produces a unique pairing of each element of the collection on the left with an element of the collection produced by evaluating the expression on the right. With a `CROSS APPLY`, the expression on the right is functionally dependent on the element on the left, as illustrated in the following associated collection example:  
  
 `SELECT c, f FROM C AS c CROSS APPLY c.Assoc AS f`  
  
 The behavior of `CROSS APPLY` is similar to the join list. If the expression on the right evaluates to an empty collection, the `CROSS APPLY` produces no pairings for that instance of the element on the left.  
  
 An `OUTER APPLY` resembles a `CROSS APPLY`, except a pairing is still produced even when the expression on the right evaluates to an empty collection. The following is an example of an `OUTER APPLY`:  
  
 `SELECT c, f FROM C AS c OUTER APPLY c.Assoc AS f`  
  
> [!NOTE]
>  Unlike in [!INCLUDE[tsql](../../../../../../includes/tsql-md.md)], there is no need for an explicit unnest step in [!INCLUDE[esql](../../../../../../includes/esql-md.md)].  
  
> [!NOTE]
>  `CROSS` and `OUTER APPLY` operators were introduced in [!INCLUDE[ssVersion2005](../../../../../../includes/ssversion2005-md.md)]. In some cases, the query pipeline might produce Transact-SQL that contains `CROSS APPLY` and/or `OUTER APPLY` operators. Because some backend providers, including versions of [!INCLUDE[ssNoVersion](../../../../../../includes/ssnoversion-md.md)] earlier than [!INCLUDE[ssVersion2005](../../../../../../includes/ssversion2005-md.md)], do not support these operators, such queries cannot be executed on these backend providers.  
>   
>  Some typical scenarios that might lead to the presence of `CROSS APPLY` and/or `OUTER APPLY` operators in the output query are the following: a correlated subquery with paging; AnyElement over a correlated subquery or over a collection produced by navigation; LINQ queries that use grouping methods that accept an element selector; a query in which a `CROSS APPLY` or an `OUTER APPLY` are explicitly specified; a query that has a `DEREF` construct over a `REF` construct.  
  
## Multiple Collections in the FROM Clause  
 The `FROM` clause can contain more than one collection separated by commas. In these cases, the collections are assumed to be joined together. Think of these as an n-way CROSS JOIN.  
  
 In the following example, `C` and `D` are independent collections, but `c.Names` is dependent on `C`.  
  
```  
FROM C AS c, D AS d, c.Names AS e  
```  
  
 The previous example is logically equivalent to the following example:  
  
 `FROM (C AS c JOIN D AS d) CROSS APPLY c.Names AS e`  
  
## Left Correlation  
 Items in the `FROM` clause can refer to items specified in earlier clauses. In the following example, `C` and `D` are independent collections, but `c.Names` is dependent on `C`:  
  
```  
from C as c, D as d, c.Names as e  
```  
  
 This is logically equivalent to:  
  
```  
from (C as c join D as d) cross apply c.Names as e  
```  
  
## Semantics  
 Logically, the collections in the `FROM` clause are assumed to be part of an `n`-way cross join (except in the case of a 1-way cross join). Aliases in the `FROM` clause are processed left to right, and are added to the current scope for later reference. The `FROM` clause is assumed to produce a multiset of rows. There will be one field for each item in the `FROM` clause that represents a single element from that collection item.  
  
 The `FROM` clause logically produces a multiset of rows of type Row(c, d, e) where fields c, d, and e are assumed to be of the element type of `C`, `D`, and `c.Names`.  
  
 [!INCLUDE[esql](../../../../../../includes/esql-md.md)] introduces an alias for each simple `FROM` clause item in scope. For example, in the following FROM clause snippet, The names introduced into scope are c, d, and e.  
  
```  
from (C as c join D as d) cross apply c.Names as e  
```  
  
 In [!INCLUDE[esql](../../../../../../includes/esql-md.md)] (unlike [!INCLUDE[tsql](../../../../../../includes/tsql-md.md)]), the `FROM` clause only introduces the aliases into scope. Any references to columns (properties) of these collections must be qualified with the alias.  
  
## Pulling Up Keys from Nested Queries  
 Certain types of queries that require pulling up keys from a nested query are not supported. For example, the following query is valid:  
  
```  
select c.Orders from Customers as c   
```  
  
 However, the following query is not valid, because the nested query does not have any keys:  
  
```  
select {1} from {2, 3}  
```  
  
## See Also  
 [Entity SQL Reference](../../../../../../docs/framework/data/adonet/ef/language-reference/entity-sql-reference.md)  
 [Query Expressions](../../../../../../docs/framework/data/adonet/ef/language-reference/query-expressions-entity-sql.md)  
 [Nullable Structured Types](../../../../../../docs/framework/data/adonet/ef/language-reference/nullable-structured-types-entity-sql.md)
