---
title: ". (Member Access) (Entity SQL)"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 4733e3b2-3efa-4b96-b591-ac31350e96ad
caps.latest.revision: 2
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# . (Member Access) (Entity SQL)
The dot operator (.) is the [!INCLUDE[esql](../../../../../../includes/esql-md.md)] member access operator. You use the member access operator to yield the value of a property or field of an instance of structural conceptual model type.  
  
## Syntax  
  
```  
expression.identifier  
```  
  
## Arguments  
 `expression`  
 An instance of a structural conceptual model type.  
  
 `identifier`  
 A property or field that belongs to an object instance.  
  
## Remarks  
 The dot (.) operator may be used to extract fields from a record, similar to extracting properties of a complex or entity type. For example, if n of type Name is a member of type Person, and p is an instance of type Person, then p.n is a legal member access expression that yields a value of type Name.  
  
 `select p.Name.FirstName from LOB.Person as p`  
  
## See Also  
 [Entity SQL Reference](../../../../../../docs/framework/data/adonet/ef/language-reference/entity-sql-reference.md)
