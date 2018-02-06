---
title: "How to: Execute a Polymorphic Query"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
ms.assetid: 2f05da1e-845b-4f14-83e4-c6353a850553
caps.latest.revision: 3
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# How to: Execute a Polymorphic Query
This topic shows how to execute a polymorphic [!INCLUDE[esql](../../../../../includes/esql-md.md)] query using the [OFTYPE](../../../../../docs/framework/data/adonet/ef/language-reference/oftype-entity-sql.md) operator.  
  
### To run the code in this example  
  
1.  Add the [School Model](http://msdn.microsoft.com/library/859a9587-81ea-4a45-9bc0-f8d330e1adac) to your project and configure your project to use the Entity Framework. For more information, see [How to: Use the Entity Data Model Wizard](http://msdn.microsoft.com/library/dadb058a-c5d9-4c5c-8b01-28044112231d).  
  
2.  In the code page for your application, add the following `using` statements (`Imports` in Visual Basic):  
  
     [!code-csharp[DP EntityServices Concepts#Namespaces](../../../../../samples/snippets/csharp/VS_Snippets_Data/dp entityservices concepts/cs/source.cs#namespaces)]
     [!code-vb[DP EntityServices Concepts#Namespaces](../../../../../samples/snippets/visualbasic/VS_Snippets_Data/dp entityservices concepts/vb/source.vb#namespaces)]  
  
3.  Modify the conceptual model to have a table-per-hierrachy inheritance by following the steps in [Walkthrough: Mapping Inheritance - Table-per-Hierarchy](http://msdn.microsoft.com/library/49b685cf-9db8-4d6d-b885-8837ed238f55).  
  
## Example  
 The following example uses an OFTYPE operator to get and display a collection of only `OnsiteCourses` from a collection of `Courses`.  
  
 [!code-csharp[DP EntityServices Concepts#PolymorphicQuery](../../../../../samples/snippets/csharp/VS_Snippets_Data/dp entityservices concepts/cs/source.cs#polymorphicquery)]
 [!code-vb[DP EntityServices Concepts#PolymorphicQuery](../../../../../samples/snippets/visualbasic/VS_Snippets_Data/dp entityservices concepts/vb/source.vb#polymorphicquery)]  
  
## See Also  
 [EntityClient Provider for the Entity Framework](../../../../../docs/framework/data/adonet/ef/entityclient-provider-for-the-entity-framework.md)  
 [Entity SQL Language](../../../../../docs/framework/data/adonet/ef/language-reference/entity-sql-language.md)
