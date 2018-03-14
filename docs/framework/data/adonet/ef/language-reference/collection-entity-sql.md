---
title: "COLLECTION (Entity SQL)"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 03228bfa-be3a-4ccc-82f8-eee429f85cf1
caps.latest.revision: 3
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# COLLECTION (Entity SQL)
The COLLECTION keyword is only used in the definition of an inline function. Collection functions are functions that operate on a collection of values and produce a scalar output.  
  
## Syntax  
  
```  
COLLECTION(type_definition)   
```  
  
## Arguments  
 `type_definition`  
 An expression that returns a collection of supported types, rows, or references.  
  
## Remarks  
 For more information about the COLLECTION keyword, see [Type Definitions](../../../../../../docs/framework/data/adonet/ef/language-reference/type-definitions-entity-sql.md).  
  
## Example  
 The following sample shows how to use the COLLECTION keyword to declare a collection of decimals as an argument for an inline query function.  
  
 [!code-csharp[DP EntityServices Concepts 2#Collection_GroupPartition](../../../../../../samples/snippets/csharp/VS_Snippets_Data/dp entityservices concepts 2/cs/entitysql.cs#collection_grouppartition)]  
  
## See Also  
 [Entity SQL Reference](../../../../../../docs/framework/data/adonet/ef/language-reference/entity-sql-reference.md)
