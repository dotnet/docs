---
title: "How to: Control How Much Related Data Is Retrieved"
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
ms.assetid: efdc203e-3da9-4477-815e-54f10c3d7c6c
caps.latest.revision: 2
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# How to: Control How Much Related Data Is Retrieved
Use the <xref:System.Data.Linq.DataLoadOptions.LoadWith%2A> method to specify which data related to your main target should be retrieved at the same time. For example, if you know you will need information about customers' orders, you can use <xref:System.Data.Linq.DataLoadOptions.LoadWith%2A> to make sure that the order information is retrieved at the same time as the customer information. This approach results in only one trip to the database for both sets of information.  
  
> [!NOTE]
>  You can retrieve data related to the main target of your query by retrieving a cross-product as one large projection, such as retrieving orders when you target customers. But this approach often has disadvantages. For example, the results are just projections and not entities that can be changed and persisted by [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)]. And you can be retrieving lots of data that you do not need.  
  
## Example  
 In the following example, all the `Orders` for all the `Customers` who are located in London are retrieved when the query is executed. As a result, successive access to the `Orders` property on a `Customer` object does not trigger a new database query.  
  
 [!code-csharp[System.Data.Linq.DataLoadOptions#2](../../../../../../samples/snippets/csharp/VS_Snippets_Data/system.data.linq.dataloadoptions/cs/program.cs#2)]
 [!code-vb[System.Data.Linq.DataLoadOptions#2](../../../../../../samples/snippets/visualbasic/VS_Snippets_Data/system.data.linq.dataloadoptions/vb/module1.vb#2)]  
  
## See Also  
 [Querying the Database](../../../../../../docs/framework/data/adonet/sql/linq/querying-the-database.md)
