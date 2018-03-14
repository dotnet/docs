---
title: "TREAT (Entity SQL)"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 5b77f156-55de-4cb4-8154-87f707d4c635
caps.latest.revision: 4
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# TREAT (Entity SQL)
Treats an object of a particular base type as an object of the specified derived type.  
  
## Syntax  
  
```  
TREAT ( expression as type)  
```  
  
## Arguments  
 `expression`  
 Any valid query expression that returns an entity.  
  
> [!NOTE]
>  The type of the specified expression must be a subtype of the specified data type, or the data type must be a subtype of the type of expression.  
  
 `type`  
 An entity type. The type must be qualified by a namespace.  
  
> [!NOTE]
>  The specified expression must be a subtype of the specified data type, or the data type must be a subtype of the expression.  
  
## Return Value  
 A value of the specified data type.  
  
## Remarks  
 TREAT is used to perform upcasting between related classes. For example, if `Employee` derives from `Person` and p is of type `Person`, `TREAT(p AS NamespaceName.Employee)` upcasts a generic `Person` instance to `Employee`; that is, it allows you to treat p as `Employee`.  
  
 TREAT is used in inheritance scenarios where you can do a query like the following:  
  
```  
SELECT TREAT(p AS NamespaceName.Employee)  
FROM ContainerName.Person AS p  
WHERE p IS OF (NamespaceName.Employee)   
```  
  
 This query upcasts `Person` entities to the `Employee` type. If the value of p is not actually of type `Employee`, the expression yields the value `null`.  
  
> [!NOTE]
>  The specified expression `Employee` must be a subtype of the specified data type `Person`, or the data type must be a subtype of the expression. Otherwise, the expression will result in a compile-time error.  
  
 The following table shows the behavior of treat over some typical patterns and some less common patterns. All exceptions are thrown from the client side before the provider gets invoked:  
  
|Pattern|Behavior|  
|-------------|--------------|  
|`TREAT (null AS EntityType)`|Returns `DbNull`.|  
|`TREAT (null AS ComplexType)`|Throws an exception.|  
|`TREAT (null AS RowType)`|Throws an exception/|  
|`TREAT (EntityType AS EntityType)`|Returns `EntityType` or `null`.|  
|`TREAT (ComplexType AS ComplexType)`|Throws an exception.|  
|`TREAT (RowType AS RowType)`|Throws an exception.|  
  
## Example  
 The following [!INCLUDE[esql](../../../../../../includes/esql-md.md)] query uses the TREAT operator to convert an object of the type Course to a collection of objects of the type OnsiteCourse. The query is based on the [School Model](http://msdn.microsoft.com/library/859a9587-81ea-4a45-9bc0-f8d330e1adac).  
  
 [!code-csharp[DP EntityServices Concepts 2#TREAT_ISOF](../../../../../../samples/snippets/csharp/VS_Snippets_Data/dp entityservices concepts 2/cs/entitysql.cs#treat_isof)]  
  
## See Also  
 [Entity SQL Reference](../../../../../../docs/framework/data/adonet/ef/language-reference/entity-sql-reference.md)  
 [Nullable Structured Types](../../../../../../docs/framework/data/adonet/ef/language-reference/nullable-structured-types-entity-sql.md)
