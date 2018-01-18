---
title: "Composing Nested Entity SQL Queries"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 685d4cd3-2c1f-419f-bb46-c9d97a351eeb
caps.latest.revision: 4
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Composing Nested Entity SQL Queries
[!INCLUDE[esql](../../../../../../includes/esql-md.md)] is a rich functional language. The building block of [!INCLUDE[esql](../../../../../../includes/esql-md.md)] is an expression. Unlike conventional SQL, [!INCLUDE[esql](../../../../../../includes/esql-md.md)] is not limited to a tabular result set: [!INCLUDE[esql](../../../../../../includes/esql-md.md)] supports composing complex expressions that can have literals, parameters, or nested expressions. A value in the expression can be parameterized or composed of some other expression.  
  
## Nested Expressions  
 A nested expression can be placed anywhere a value of the type it returns is accepted. For example:  
  
```  
-- Returns a hierarchical collection of three elements at top-level.   
-- x must be passed in the parameter collection.  
ROW(@x, {@x}, {@x, 4, 5}, {@x, 7, 8, 9})  
  
-- Returns a hierarchical collection of one element at top-level.  
-- x must be passed in the parameter collection.  
{{{@x}}};  
```  
  
 A nested query can be placed in a projection clause. For example:  
  
```  
-- Returns a collection of rows where each row contains an Address entity.  
-- and a collection of references to its corresponding SalesOrderHeader entities.  
SELECT address, (SELECT DEREF(soh)   
                    FROM NAVIGATE(address, AdventureWorksModel.FK_SalesOrderHeader_Address_BillToAddressID) AS soh)   
                    AS salesOrderHeader FROM AdventureWorksEntities.Address AS address  
```  
  
 In [!INCLUDE[esql](../../../../../../includes/esql-md.md)], nested queries must always be enclosed in parentheses:  
  
```  
-- Pseudo-Entity SQL  
( SELECT …  
FROM … )  
UNION ALL  
( SELECT …  
FROM … );  
```  
  
 The following example demonstrates how to properly nest expressions in [!INCLUDE[esql](../../../../../../includes/esql-md.md)]: [How to: Order the Union of Two Queries](http://msdn.microsoft.com/library/853c583a-eaba-4400-830d-be974e735313).  
  
## Nested Queries in Projection  
 Nested queries in the project clause might get translated into Cartesian product queries on the server. In some backend servers, including SLQ Server, this can cause the TempDB table to get very large, which can adversely affect server performance.  
  
 The following is an example of such a query:  
  
```  
SELECT c, (SELECT c, (SELECT c FROM AdventureWorksModel.Vendor AS c  ) As Inner2 FROM AdventureWorksModel.JobCandidate AS c  ) As Inner1 FROM AdventureWorksModel.EmployeeDepartmentHistory AS c  
```  
  
## Ordering Nested Queries  
 In the Entity Framework, a nested expression can be placed anywhere in the query. Because Entity SQL allows great flexibility in writing queries, it is possible to write a query that contains an ordering of nested queries. However, the order of a nested query is not preserved.  
  
```  
-- The following query will order the results by last name.  
SELECT C1.FirstName, C1.LastName  
        FROM AdventureWorksModel.Contact as C1  
        ORDER BY C1.LastName  
```  
  
```  
-- In the following query, ordering of the nested query is ignored.  
SELECT C2.FirstName, C2.LastName  
    FROM (SELECT C1.FirstName, C1.LastName  
        FROM AdventureWorksModel.Contact as C1  
        ORDER BY C1.LastName) as C2  
```  
  
## See Also  
 [Entity SQL Overview](../../../../../../docs/framework/data/adonet/ef/language-reference/entity-sql-overview.md)
