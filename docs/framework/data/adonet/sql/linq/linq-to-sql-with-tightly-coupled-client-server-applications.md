---
title: "LINQ to SQL with Tightly-Coupled Client-Server Applications"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: e083d805-dcf6-459d-b9af-9ef0563f2dd7
caps.latest.revision: 2
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# LINQ to SQL with Tightly-Coupled Client-Server Applications
[!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] can be used on the middle tier with tightly-coupled Smart Clients on the presentation layer. In scenarios that involve read-only data access, no optimistic concurrency checks, or optimistic concurrency with timestamps, there is not much more complexity than with non-remote scenarios. However, when a database requires optimistic concurrency checks with original values, [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] does not provide the level of support for round-tripping of data that you find in DataSets. However, a [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] middle tier can exchange data with clients on any platform.  
  
 [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] in [!INCLUDE[vs_orcas_long](../../../../../../includes/vs-orcas-long-md.md)] provides no infrastructure for tracking entity state after they have been serialized to a client. [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] enables service-oriented architectures where interactions between the data and presentation layers are small and relatively atomic, but does not perform any round-tripping of original values. Therefore, if you want to use a tightly-coupled Smart Client with [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)], and a database uses optimistic concurrency with original values, you will have to implement your own mechanism for communicating changes between the presentation tier and middle tier. It is up to the system designer to decide whether it makes sense to do this bit of extra work in exchange for the benefits that [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] provides on the middle tier. On the other hand, if the database has timestamps, then there is no need for custom change-tracking logic.  
  
## See Also  
 [N-Tier and Remote Applications with LINQ to SQL](../../../../../../docs/framework/data/adonet/sql/linq/n-tier-and-remote-applications-with-linq-to-sql.md)  
 [LINQ to SQL N-Tier with Web Services](../../../../../../docs/framework/data/adonet/sql/linq/linq-to-sql-n-tier-with-web-services.md)  
 [Work with datasets in n-tier applications](http://msdn.microsoft.com/library/f6ae2ee0-ea5f-4a79-8f4b-e21c115afb20)
