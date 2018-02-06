---
title: "Adding a DataTable to a DataSet"
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
ms.assetid: 556d29a3-8fc9-4e38-b3ee-c188f7e7b155
caps.latest.revision: 4
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Adding a DataTable to a DataSet
ADO.NET enables you to create <xref:System.Data.DataTable> objects and add them to an existing <xref:System.Data.DataSet>. You can set constraint information for a <xref:System.Data.DataTable> by using the <xref:System.Data.DataTable.PrimaryKey%2A> and <xref:System.Data.DataColumn.Unique%2A> properties.  
  
## Example  
 The following example constructs a <xref:System.Data.DataSet>, adds a new <xref:System.Data.DataTable> object to the <xref:System.Data.DataSet>, and then adds three <xref:System.Data.DataColumn> objects to the table. Finally, the code sets one column as the primary key column.  
  
 [!code-csharp[DataWorks Data.DataTableAdd#1](../../../../../samples/snippets/csharp/VS_Snippets_ADO.NET/DataWorks Data.DataTableAdd/CS/source.cs#1)]
 [!code-vb[DataWorks Data.DataTableAdd#1](../../../../../samples/snippets/visualbasic/VS_Snippets_ADO.NET/DataWorks Data.DataTableAdd/VB/source.vb#1)]  
  
## Case Sensitivity  
 Two or more tables or relations with the same name, but different casing, can exist in a <xref:System.Data.DataSet>. In such cases, references by name to tables and relations are case sensitive. For example, if the <xref:System.Data.DataSet> **dataSet** contains tables **Table1** and **table1**, you would reference **Table1** by name as **dataSet.Tables["Table1"]**, and **table1** as **dataSet.Tables["table1"]**. Attempting to reference either of the tables as **dataSet.Tables["TABLE1"]** would generate an exception.  
  
 The case-sensitivity behavior does not apply if only one table or relation has a particular name. For example, if the <xref:System.Data.DataSet> has only **Table1**, you can reference it using **dataSet.Tables["TABLE1"]**.  
  
> [!NOTE]
>  The <xref:System.Data.DataSet.CaseSensitive%2A> property of the <xref:System.Data.DataSet> does not affect this behavior. The <xref:System.Data.DataSet.CaseSensitive%2A> property applies to the data in the <xref:System.Data.DataSet> and affects sorting, searching, filtering, enforcing constraints, and so on.  
  
## Namespace Support  
 In versions of ADO.NET earlier than 2.0, two tables could not have the same name, even if they were in different namespaces. This limitation was removed in ADO.NET 2.0. A <xref:System.Data.DataSet> can contain two tables that have the same <xref:System.Data.DataTable.TableName%2A> property value but different <xref:System.Data.DataTable.Namespace%2A> property values.  
  
## See Also  
 [DataSets, DataTables, and DataViews](../../../../../docs/framework/data/adonet/dataset-datatable-dataview/index.md)  
 [ADO.NET Managed Providers and DataSet Developer Center](http://go.microsoft.com/fwlink/?LinkId=217917)
