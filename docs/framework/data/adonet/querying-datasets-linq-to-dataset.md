---
title: "Querying DataSets (LINQ to DataSet)"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: bb68d2e4-623d-4d60-85e3-965254f6fee7
caps.latest.revision: 2
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Querying DataSets (LINQ to DataSet)
After a <xref:System.Data.DataSet> object has been populated with data, you can begin querying it. Formulating queries with [!INCLUDE[linq_dataset](../../../../includes/linq-dataset-md.md)] is similar to using [!INCLUDE[vbteclinqext](../../../../includes/vbteclinqext-md.md)] against other [!INCLUDE[vbteclinq](../../../../includes/vbteclinq-md.md)]-enabled data sources. Remember, however, that when you use [!INCLUDE[vbteclinq](../../../../includes/vbteclinq-md.md)] queries over a <xref:System.Data.DataSet> object you are querying an enumeration of <xref:System.Data.DataRow> objects, instead of an enumeration of a custom type. This means that you can use any of the members of the <xref:System.Data.DataRow> class in your [!INCLUDE[vbteclinq](../../../../includes/vbteclinq-md.md)] queries. This lets you to create rich, complex queries.  
  
 As with other implementations of [!INCLUDE[vbteclinq](../../../../includes/vbteclinq-md.md)], you can create [!INCLUDE[linq_dataset](../../../../includes/linq-dataset-md.md)] queries in two different forms: query expression syntax and method-based query syntax. For more information about these two forms, see [Getting Started with LINQ](http://msdn.microsoft.com/library/6cc9af04-950a-4cc3-83d4-2aeb4abe4de9). You can use query expression syntax or method-based query syntax to perform queries against single tables in a <xref:System.Data.DataSet>, against multiple tables in a <xref:System.Data.DataSet>, or against tables in a typed <xref:System.Data.DataSet>.  
  
## In This Section  
 [Single-Table Queries](../../../../docs/framework/data/adonet/single-table-queries-linq-to-dataset.md)  
 Describes how to perform single-table queries.  
  
 [Cross-Table Queries](../../../../docs/framework/data/adonet/cross-table-queries-linq-to-dataset.md)  
 Describes how to perform cross-table queries.  
  
 [Querying Typed DataSets](../../../../docs/framework/data/adonet/querying-typed-datasets.md)  
 Describes how to query typed <xref:System.Data.DataSet> objects.  
  
## See Also  
 [LINQ to DataSet Examples](../../../../docs/framework/data/adonet/linq-to-dataset-examples.md)  
 [Loading Data Into a DataSet](../../../../docs/framework/data/adonet/loading-data-into-a-dataset.md)
