---
title: "+ (Add)"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 51769b02-a8f7-4177-9e99-bbd10e77092c
caps.latest.revision: 4
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# + (Add)
Adds two numbers.  
  
## Syntax  
  
```  
expression + expression  
```  
  
## Arguments  
 `expression`  
 Any valid expression of any one of the numeric data types.  
  
## Result Types  
 The data type that results from the implicit type promotion of the two arguments. For more information about implicit type promotion, see [Type System](../../../../../../docs/framework/data/adonet/ef/language-reference/type-system-entity-sql.md).  
  
## Remarks  
 For EDM.String types, addition is concatenation.  
  
## Example  
 The following Entity SQL query uses the + arithmetic operator to add two numbers. The query is based on the AdventureWorks Sales Model. To compile and run this query, follow these steps:  
  
1.  Follow the procedure in [How to: Execute a Query that Returns StructuralType Results](../../../../../../docs/framework/data/adonet/ef/how-to-execute-a-query-that-returns-structuraltype-results.md).  
  
2.  Pass the following query as an argument to the `ExecuteStructuralTypeQuery` method:  
  
 [!code-csharp[DP EntityServices Concepts 2#ADD](../../../../../../samples/snippets/csharp/VS_Snippets_Data/dp entityservices concepts 2/cs/entitysql.cs#add)]  
  
## See Also  
 [Entity SQL Reference](../../../../../../docs/framework/data/adonet/ef/language-reference/entity-sql-reference.md)  
 [Conceptual Model Types (CSDL)](http://msdn.microsoft.com/library/987b995f-e429-4569-9559-b4146744def4)
