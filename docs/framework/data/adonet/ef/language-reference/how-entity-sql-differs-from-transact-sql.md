---
title: "How Entity SQL Differs from Transact-SQL"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 9c9ee36d-f294-4c8b-a196-f0114c94f559
caps.latest.revision: 3
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# How Entity SQL Differs from Transact-SQL
This topic describes the differences between [!INCLUDE[esql](../../../../../../includes/esql-md.md)] and [!INCLUDE[tsql](../../../../../../includes/tsql-md.md)].  
  
## Inheritance and Relationships Support  
 [!INCLUDE[esql](../../../../../../includes/esql-md.md)] works directly with conceptual entity schemas and supports conceptual model features such as inheritance and relationships.  
  
 When working with inheritance, it is often useful to select instances of a subtype from a collection of supertype instances. The [oftype](../../../../../../docs/framework/data/adonet/ef/language-reference/oftype-entity-sql.md) operator in [!INCLUDE[esql](../../../../../../includes/esql-md.md)] (similar to `oftype` in C# Sequences) provides this capability.  
  
## Support for Collections  
 [!INCLUDE[esql](../../../../../../includes/esql-md.md)] treats collections as first-class entities. For example:  
  
-   Collection expressions are valid in a `from` clause.  
  
-   `in` and `exists` subqueries have been generalized to allow any collections.  
  
     A subquery is one kind of collection. `e1 in e2` and `exists(e)` are the [!INCLUDE[esql](../../../../../../includes/esql-md.md)] constructs to perform these operations.  
  
-   Set operations, such as `union`, `intersect`, and `except`, now operate on collections.  
  
-   Joins operate on collections.  
  
## Support for Expressions  
 [!INCLUDE[tsql](../../../../../../includes/tsql-md.md)] has subqueries (tables) and expressions (rows and columns).  
  
 To support collections and nested collections, [!INCLUDE[esql](../../../../../../includes/esql-md.md)] makes everything an expression. [!INCLUDE[esql](../../../../../../includes/esql-md.md)] is more composable than [!INCLUDE[tsql](../../../../../../includes/tsql-md.md)]—every expression can be used anywhere. Query expressions always result in collections of the projected types and can be used anywhere a collection expression is allowed. For information about [!INCLUDE[tsql](../../../../../../includes/tsql-md.md)] expressions that are not supported in [!INCLUDE[esql](../../../../../../includes/esql-md.md)], see [Unsupported Expressions](../../../../../../docs/framework/data/adonet/ef/language-reference/unsupported-expressions-entity-sql.md).  
  
 The following are all valid [!INCLUDE[esql](../../../../../../includes/esql-md.md)] queries:  
  
```  
1+2 *3  
"abc"  
row(1 as a, 2 as b)  
{ 1, 3, 5}   
e1 union all e2  
set(e1)  
```  
  
## Uniform Treatment of Subqueries  
 Given its emphasis on tables, [!INCLUDE[tsql](../../../../../../includes/tsql-md.md)] performs contextual interpretation of subqueries. For example, a subquery in the `from` clause is considered to be a multiset (table). But the same subquery used in the `select` clause is considered to be a scalar subquery. Similarly, a subquery used on the left side of an `in` operator is considered to be a scalar subquery, while the right side is expected to be a multiset subquery.  
  
 [!INCLUDE[esql](../../../../../../includes/esql-md.md)] eliminates these differences. An expression has a uniform interpretation that does not depend on the context in which it is used. [!INCLUDE[esql](../../../../../../includes/esql-md.md)] considers all subqueries to be multiset subqueries. If a scalar value is desired from the subquery, [!INCLUDE[esql](../../../../../../includes/esql-md.md)] provides the `anyelement` operator that operates on a collection (in this case, the subquery), and extracts a singleton value from the collection.  
  
### Avoiding Implicit Coercions for Subqueries  
 A related side effect of uniform treatment of subqueries is implicit conversion of subqueries to scalar values. Specifically, in [!INCLUDE[tsql](../../../../../../includes/tsql-md.md)], a multiset of rows (with a single field) is implicitly converted into a scalar value whose data type is that of the field.  
  
 [!INCLUDE[esql](../../../../../../includes/esql-md.md)] does not support this implicit coercion. [!INCLUDE[esql](../../../../../../includes/esql-md.md)] provides the ANYELEMENT operator to extract a singleton value from a collection, and a `select value` clause to avoid creating a row-wrapper during a query expression.  
  
## Select Value: Avoiding the Implicit Row Wrapper  
 The select clause in a [!INCLUDE[tsql](../../../../../../includes/tsql-md.md)] subquery implicitly creates a row wrapper around the items in the clause. This implies that we cannot create collections of scalars or objects. [!INCLUDE[tsql](../../../../../../includes/tsql-md.md)] allows an implicit coercion between a rowtype with one field, and a singleton value of the same data type.  
  
 [!INCLUDE[esql](../../../../../../includes/esql-md.md)] provides the `select value` clause to skip the implicit row construction. Only one item may be specified in a `select value` clause. When such a clause is used, no row wrapper is constructed around the items in the `select` clause, and a collection of the desired shape may be produced, for example: `select value a`.  
  
 [!INCLUDE[esql](../../../../../../includes/esql-md.md)] also provides the row constructor to construct arbitrary rows. `select` takes one or more elements in the projection and results in a data record with fields, as follows:  
  
 `select a, b, c`  
  
## Left Correlation and Aliasing  
 In [!INCLUDE[tsql](../../../../../../includes/tsql-md.md)], expressions in a given scope (a single clause like `select` or `from`) cannot reference expressions defined earlier in the same scope. Some dialects of SQL (including [!INCLUDE[tsql](../../../../../../includes/tsql-md.md)]) do support limited forms of these in the `from` clause.  
  
 [!INCLUDE[esql](../../../../../../includes/esql-md.md)] generalizes left correlations in the `from` clause, and treats them uniformly. Expressions in the `from` clause can reference earlier definitions (definitions to the left) in the same clause without the need for additional syntax.  
  
 [!INCLUDE[esql](../../../../../../includes/esql-md.md)] also imposes additional restrictions on queries involving `group by` clauses. Expressions in the `select` clause and `having` clause of such queries may only refer to the `group by` keys via their aliases. The following construct is valid in [!INCLUDE[tsql](../../../../../../includes/tsql-md.md)] but are not in [!INCLUDE[esql](../../../../../../includes/esql-md.md)]:  
  
```  
select t.x + t.y from T as t group by t.x + t.y  
```  
  
 To do this in [!INCLUDE[esql](../../../../../../includes/esql-md.md)]:  
  
```  
select k from T as t group by (t.x + t.y) as k  
```  
  
## Referencing Columns (Properties) of Tables (Collections)  
 All column references in [!INCLUDE[esql](../../../../../../includes/esql-md.md)] must be qualified with the table alias. The following construct (assuming that `a` is a valid column of table `T`) is valid in [!INCLUDE[tsql](../../../../../../includes/tsql-md.md)] but not in [!INCLUDE[esql](../../../../../../includes/esql-md.md)].  
  
```  
select a from T  
```  
  
 The [!INCLUDE[esql](../../../../../../includes/esql-md.md)] form is  
  
```  
select t.a as A from T as t  
```  
  
 The table aliases are optional in the `from` clause. The name of the table is used as the implicit alias. [!INCLUDE[esql](../../../../../../includes/esql-md.md)] allows the following form as well:  
  
```  
select Tab.a from Tab  
```  
  
## Navigation Through Objects  
 [!INCLUDE[tsql](../../../../../../includes/tsql-md.md)] uses the "." notation for referencing columns of (a row of) a table. [!INCLUDE[esql](../../../../../../includes/esql-md.md)] extends this notation (borrowed from programming languages) to support navigation through properties of an object.  
  
 For example, if `p` is an expression of type Person, the following is the [!INCLUDE[esql](../../../../../../includes/esql-md.md)] syntax for referencing the city of the address of this person.  
  
```  
p.Address.City   
```  
  
## No Support for *  
 [!INCLUDE[tsql](../../../../../../includes/tsql-md.md)] supports the unqualified * syntax as an alias for the entire row, and the qualified \* syntax (t.\*) as a shortcut for the fields of that table. In addition, [!INCLUDE[tsql](../../../../../../includes/tsql-md.md)] allows for a special count(\*) aggregate, which includes nulls.  
  
 [!INCLUDE[esql](../../../../../../includes/esql-md.md)] does not support the * construct. [!INCLUDE[tsql](../../../../../../includes/tsql-md.md)] queries of the form `select * from T` and `select T1.* from T1, T2...` can be expressed in [!INCLUDE[esql](../../../../../../includes/esql-md.md)] as `select value t from T as t` and `select value t1 from T1 as t1, T2 as t2...`, respectively. Additionally, these constructs handle inheritance (value substitutability), while the `select *` variants are restricted to top-level properties of the declared type.  
  
 [!INCLUDE[esql](../../../../../../includes/esql-md.md)] does not support the `count(*)` aggregate. Use `count(0)` instead.  
  
## Changes to Group By  
 [!INCLUDE[esql](../../../../../../includes/esql-md.md)] supports aliasing of `group by` keys. Expressions in the `select` clause and `having` clause must refer to the `group by` keys via these aliases. For example, this [!INCLUDE[esql](../../../../../../includes/esql-md.md)] syntax:  
  
```  
select k1, count(t.a), sum(t.a)  
from T as t  
group by t.b + t.c as k1  
```  
  
 ...is equivalent to the following [!INCLUDE[tsql](../../../../../../includes/tsql-md.md)]:  
  
```  
select b + c, count(*), sum(a)   
from T  
group by b + c  
```  
  
## Collection-Based Aggregates  
 [!INCLUDE[esql](../../../../../../includes/esql-md.md)] supports two kinds of aggregates.  
  
 Collection-based aggregates operate on collections and produce the aggregated result. These can appear anywhere in the query, and do not require a `group by` clause. For example:  
  
```  
select t.a as a, count({1,2,3}) as b from T as t     
```  
  
 [!INCLUDE[esql](../../../../../../includes/esql-md.md)] also supports SQL-style aggregates. For example:  
  
```  
select a, sum(t.b) from T as t group by t.a as a  
```  
  
## ORDER BY Clause Usage  
 [!INCLUDE[tsql](../../../../../../includes/tsql-md.md)] allows ORDER BY clauses to be specified only in the topmost SELECT .. FROM .. WHERE block. In [!INCLUDE[esql](../../../../../../includes/esql-md.md)] you can use a nested ORDER BY expression and it can be placed anywhere in the query, but ordering in a nested query is not preserved.  
  
```  
-- The following query will order the results by the last name  
SELECT C1.FirstName, C1.LastName  
        FROM AdventureWorks.Contact as C1  
        ORDER BY C1.LastName  
```  
  
```  
-- In the following query ordering of the nested query is ignored.  
SELECT C2.FirstName, C2.LastName  
    FROM (SELECT C1.FirstName, C1.LastName  
        FROM AdventureWorks.Contact as C1  
        ORDER BY C1.LastName) as C2  
```  
  
## Identifiers  
 In [!INCLUDE[tsql](../../../../../../includes/tsql-md.md)], identifier comparison is based on the collation of the current database. In [!INCLUDE[esql](../../../../../../includes/esql-md.md)], identifiers are always case insensitive and accent sensitive (that is, [!INCLUDE[esql](../../../../../../includes/esql-md.md)] distinguishes between accented and unaccented characters; for example, 'a' is not equal to 'ấ'). [!INCLUDE[esql](../../../../../../includes/esql-md.md)] treats versions of letters that appear the same but are from different code pages as different characters. For more information, see [Input Character Set](../../../../../../docs/framework/data/adonet/ef/language-reference/input-character-set-entity-sql.md).  
  
## Transact-SQL Functionality Not Available in Entity SQL  
 The following [!INCLUDE[tsql](../../../../../../includes/tsql-md.md)] functionality is not available in [!INCLUDE[esql](../../../../../../includes/esql-md.md)].  
  
 DML  
 [!INCLUDE[esql](../../../../../../includes/esql-md.md)] currently provides no support for DML statements (insert, update, delete).  
  
 DDL  
 [!INCLUDE[esql](../../../../../../includes/esql-md.md)] provides no support for DDL in the current version.  
  
 Imperative Programming  
 [!INCLUDE[esql](../../../../../../includes/esql-md.md)] provides no support for imperative programming, unlike [!INCLUDE[tsql](../../../../../../includes/tsql-md.md)]. Use a programming language instead.  
  
 Grouping Functions  
 [!INCLUDE[esql](../../../../../../includes/esql-md.md)] does not yet provide support for grouping functions (for example, CUBE, ROLLUP, and GROUPING_SET).  
  
 Analytic Functions  
 [!INCLUDE[esql](../../../../../../includes/esql-md.md)] does not (yet) provide support for analytic functions.  
  
 Built-in Functions, Operators  
 [!INCLUDE[esql](../../../../../../includes/esql-md.md)] supports a subset of [!INCLUDE[tsql](../../../../../../includes/tsql-md.md)]'s built in functions and operators. These operators and functions are likely to be supported by the major store providers. [!INCLUDE[esql](../../../../../../includes/esql-md.md)] uses the store-specific functions declared in a provider manifest. Additionally, the [!INCLUDE[adonet_ef](../../../../../../includes/adonet-ef-md.md)] allows you to declare built-in and user-defined existing store functions, for [!INCLUDE[esql](../../../../../../includes/esql-md.md)] to use.  
  
 Hints  
 [!INCLUDE[esql](../../../../../../includes/esql-md.md)] does not provide mechanisms for query hints.  
  
 Batching Query Results  
 [!INCLUDE[esql](../../../../../../includes/esql-md.md)] does not support batching query results. For example, the following is valid [!INCLUDE[tsql](../../../../../../includes/tsql-md.md)] (sending as a batch):  
  
```  
select * from products;  
select * from catagories;  
```  
  
 However, the equivalent [!INCLUDE[esql](../../../../../../includes/esql-md.md)] is not supported:  
  
```  
Select value p from Products as p;  
Select value c from Categories as c;  
```  
  
 [!INCLUDE[esql](../../../../../../includes/esql-md.md)] only supports one result-producing query statement per command.  
  
## See Also  
 [Entity SQL Overview](../../../../../../docs/framework/data/adonet/ef/language-reference/entity-sql-overview.md)  
 [Unsupported Expressions](../../../../../../docs/framework/data/adonet/ef/language-reference/unsupported-expressions-entity-sql.md)
