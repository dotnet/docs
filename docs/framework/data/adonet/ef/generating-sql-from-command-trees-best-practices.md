---
title: "Generating SQL from Command Trees - Best Practices"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 71ef6a24-4c4f-4254-af3a-ffc0d855b0a8
caps.latest.revision: 3
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Generating SQL from Command Trees - Best Practices
Output query command trees closely model queries expressible in SQL. However, there are certain common challenges for provider writers when generating SQL from an output command tree. This topic discusses these challenges. In the next topic, the sample provider shows how to address these challenges.  
  
## Group DbExpression Nodes in a SQL SELECT Statement  
 A typical SQL statement has a nested structure of the following shape:  
  
```  
SELECT …  
FROM …  
WHERE …  
GROUP BY …  
ORDER BY …  
```  
  
 One or more clauses may be empty.  A nested SELECT statement could occur in any of the lines.  
  
 A possible translation of a query command tree into a SQL SELECT statement would produce one subquery for every relational operator. However, that would lead to unnecessary nested subqueries that would be difficult to read.  On some data stores, the query may perform poorly.  
  
 As an example, consider the following query command tree  
  
```  
Project (  
a.x,  
   a = Filter(  
      b.y = 5,   
      b = Scan("TableA")  
   )  
)  
```  
  
 An inefficient translation would produce:  
  
```  
SELECT a.x  
FROM (   SELECT *  
         FROM TableA as b  
         WHERE b.y = 5) as a  
```  
  
 Note that every relational expression node becomes a new SQL SELECT statement.  
  
 Therefore, it is important to aggregate as many expression nodes as possible into a single SQL SELECT statement while preserving correctness.  
  
 The result of such aggregation for the example presented above would be:  
  
```  
SELECT b.x   
FROM TableA as b  
WHERE b.y = 5  
```  
  
## Flatten Joins in a SQL SELECT Statement  
 One case of aggregating multiple nodes into a single SQL SELECT statement is aggregating multiple join expressions into a single SQL SELECT statement. DbJoinExpression represents a single join between two inputs. However, as part of a single SQL SELECT statement, more than one join can be specified. In that case the joins are performed in the order specified.  
  
 Left spine joins, (joins that appear as a left child of another join) can be more easily flattened into a single SQL SELECT statement. For example, consider the following query command tree:  
  
```  
InnerJoin(  
   a = LeftOuterJoin(  
   b = Extent("TableA")  
   c = Extent("TableB")  
   ON b.y = c.x ),  
   d = Extent("TableC")   
   ON a.b.y = d.z  
)  
```  
  
 This can be correctly translated into:  
  
```  
SELECT *  
FROM TableA as b  
LEFT OUTER JOIN TableB as c ON b.y = c.x  
INNER JOIN TableC as d ON b.y = d.z  
```  
  
 However, non-left spine joins cannot easily be flattened, and you should not try to flatten them. For example, the joins in the following query command tree:  
  
```  
InnerJoin(  
   a = Extent("TableA")   
   b = LeftOuterJoin(  
   c = Extent("TableB")  
   d = Extent("TableC")  
   ON c.y = d.x),  
   ON a.z = b.c.y  
)  
```  
  
 Would be translated to a SQL SELECT statement with a sub-query.  
  
```  
SELECT *  
FROM TableA as a  
INNER JOIN (SELECT *   
   FROM TableB as c   
   LEFT OUTER JOIN TableC as d  
   ON c.y = d.x) as b  
ON b.y = d.z  
```  
  
## Input Alias Redirecting  
 To explain input alias redirecting, consider the structure of the relational expressions, such as DbFilterExpression, DbProjectExpression, DbCrossJoinExpression, DbJoinExpression, DbSortExpression, DbGroupByExpression, DbApplyExpression, and DbSkipExpression.  
  
 Each of these types has one or more Input properties that describe an input collection, and a binding variable corresponding to each input is used to represent each element of that input during a collection traversal. The binding variable is used when referring to the input element, for example in the Predicate property of a DbFilterExpression or the Projection property of a DbProjectExpression.  
  
 When aggregating more relational expression nodes into a single SQL SELECT statement, and evaluating an expression that is part of a relational expression (for example part of the Projection property of a DbProjectExpression) the binding variable that it uses may not be the same as the alias of the input, as multiple expression bindings would have to be redirected to a single extent.  This problem is called alias renaming.  
  
 Consider the first example in this topic. If doing the naïve translation and translating the Projection a.x (DbPropertyExpression(a, x)), it is correct to translate it into `a.x` because we have aliased the input as "a" to match the binding variable.  However, when aggregating both the nodes into a single SQL SELECT statement, you need to translate the same DbPropertyExpression into `b.x`, as the input has been aliased with "b".  
  
## Join Alias Flattening  
 Unlike any other relational expression in an output command tree, the DbJoinExpression outputs a result type that is a row consisting of two columns, each of which corresponds to one of the inputs. When a DbPropertyExpresssion is built to access a scalar property originating from a join, it is over another DbPropertyExpresssion.  
  
 Examples include "a.b.y" in example 2 and "b.c.y" in example 3. However in the corresponding SQL statements these are referred as "b.y". This re-aliasing is called join alias flattening.  
  
## Column Name and Extent Alias Renaming  
 If a SQL SELECT query that has a join has to be completed with a projection, when enumerating all the participating columns from the inputs, a name collision may occur, as more than one input may have the same column name. Use a different name for the column to avoid the collision.  
  
 Also, when flattening joins, participating tables (or subqueries) may have colliding aliases in which case these need to be renamed.  
  
## Avoid SELECT *  
 Do not use `SELECT *` to select from base tables. The storage model in an [!INCLUDE[adonet_ef](../../../../../includes/adonet-ef-md.md)] application may only include a subset of the columns that are in the database table. In this case, `SELECT *` may produce an incorrect result. Instead, you should specify all participating columns by using the column names from the result type of the participating expressions.  
  
## Reuse of Expressions  
 Expressions may be reused in the query command tree passed by the [!INCLUDE[adonet_ef](../../../../../includes/adonet-ef-md.md)]. Do not assume that each expression appears only once in the query command tree.  
  
## Mapping Primitive Types  
 When mapping conceptual (EDM) types to provider types, you should map to the widest type (Int32) so that all possible values fit. Also, avoid mapping to types that cannot be used for many operations, like BLOB types (for example, `ntext` in [!INCLUDE[ssNoVersion](../../../../../includes/ssnoversion-md.md)]).  
  
## See Also  
 [SQL Generation](../../../../../docs/framework/data/adonet/ef/sql-generation.md)
