---
title: "ISOF (Entity SQL)"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 5b2b0d34-d0a7-4bcd-baf2-58aa8456d00b
caps.latest.revision: 4
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# ISOF (Entity SQL)
Determines whether the type of an expression is of the specified type or one of its subtypes.  
  
## Syntax  
  
```  
expression IS [ NOT ] OF ( [ ONLY ] type )  
```  
  
## Arguments  
 `expression`  
 Any valid query expression to determine the type of.  
  
 NOT  
 Negates the EDM.Boolean result of IS OF.  
  
 ONLY  
 Specifies that IS OF returns `true` only if `expression` is of type `type` and not any of one its subtypes.  
  
 `type`  
 The type to test `expression` against. The type must be namespace-qualified.  
  
## Return Value  
 `true` if `expression` is of type T and T is either a base type, or a derived type of `type`; null if `expression` is null at runtime; otherwise, `false`.  
  
## Remarks  
 The expressions `expression IS NOT OF (type)` and `expression IS NOT OF (ONLY type)` are syntactically equivalent to `NOT (expression IS OF (type))` and `NOT (expression IS OF (ONLY type))`, respectively.  
  
 The following table shows the behavior of `IS OF` operator over some typical- and corner patterns. All exceptions are thrown from the client side before the provider gets invoked:  
  
|Pattern|Behavior|  
|-------------|--------------|  
|null IS OF (EntityType)|Throws|  
|null IS OF (ComplexType)|Throws|  
|null IS OF (RowType)|Throws|  
|TREAT (null AS EntityType) IS OF (EntityType)|Returns DBNull|  
|TREAT (null AS ComplexType) IS OF (ComplexType)|Throws|  
|TREAT (null AS RowType) IS OF (RowType)|Throws|  
|EntityType IS OF (EntityType)|Returns true/false|  
|ComplexType IS OF (ComplexType)|Throws|  
|RowType IS OF (RowType)|Throws|  
  
## Example  
 The following [!INCLUDE[esql](../../../../../../includes/esql-md.md)] query uses the IS OF operator to determine the type of a query expression, and then uses the TREAT operator to convert an object of the type Course to a collection of objects of the type OnsiteCourse. The query is based on the [School Model](http://msdn.microsoft.com/library/859a9587-81ea-4a45-9bc0-f8d330e1adac).  
  
 [!code-csharp[DP EntityServices Concepts 2#TREAT_ISOF](../../../../../../samples/snippets/csharp/VS_Snippets_Data/dp entityservices concepts 2/cs/entitysql.cs#treat_isof)]  
  
## See Also  
 [Entity SQL Reference](../../../../../../docs/framework/data/adonet/ef/language-reference/entity-sql-reference.md)
