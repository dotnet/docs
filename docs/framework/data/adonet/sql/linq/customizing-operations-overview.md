---
title: "Customizing Operations: Overview"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: a3546296-1443-4b88-aa6e-d41011041ba7
caps.latest.revision: 2
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Customizing Operations: Overview
By default, [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] generates dynamic SQL for insert, update, and delete operations based on mapping. However, in practice you typically want to add your own business logic to provide for security, validation, and so forth.  
  
 [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] techniques for customizing these operations include the following.  
  
## Loading Options  
 In your queries, you can control how much data related to your main target is retrieved when you connect to the database. This functionality is implemented largely by using <xref:System.Data.Linq.DataLoadOptions>. For more information, see [Deferred versus Immediate Loading](../../../../../../docs/framework/data/adonet/sql/linq/deferred-versus-immediate-loading.md).  
  
## Partial Methods  
 In its default mapping, [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] provides partial methods to help you implement your business logic. For more information, see [Adding Business Logic By Using Partial Methods](../../../../../../docs/framework/data/adonet/sql/linq/adding-business-logic-by-using-partial-methods.md).  
  
## Stored Procedures and User-Defined Functions  
 [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] supports the use of stored procedures and user-defined functions. Stored procedures are frequently used to customize operations. For more information, see [Stored Procedures](../../../../../../docs/framework/data/adonet/sql/linq/stored-procedures.md).  
  
## See Also  
 [Customizing Insert, Update, and Delete Operations](../../../../../../docs/framework/data/adonet/sql/linq/customizing-insert-update-and-delete-operations.md)
