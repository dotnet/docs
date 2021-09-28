---
description: "Learn more about: Loading Data Into a DataSet"
title: "Loading Data Into a DataSet"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
ms.assetid: a53e5dc1-9669-49d4-828d-efa633237066
---
# Loading Data Into a DataSet

A <xref:System.Data.DataSet> object must first be populated before you can query over it with LINQ to DataSet. There are several different ways to populate the <xref:System.Data.DataSet>. For example, you can use [!INCLUDE[vbtecdlinq](../../../../includes/vbtecdlinq-md.md)] to query the database and load the results into the <xref:System.Data.DataSet>. For more information, see [LINQ to SQL](./sql/linq/index.md).  
  
 Another common way to load data into a <xref:System.Data.DataSet> is to use the <xref:System.Data.Common.DataAdapter> class to retrieve data from the database. This is illustrated in the following example.  
  
## Example  

 This example uses a <xref:System.Data.Common.DataAdapter> to query the AdventureWorks database for sales information from the year 2002, and loads the results into a <xref:System.Data.DataSet>. After the <xref:System.Data.DataSet> has been populated, you can write queries against it by using LINQ to DataSet. The `FillDataSet` method in this example is used in the example queries in [LINQ to DataSet Examples](linq-to-dataset-examples.md). For more information, see [Querying DataSets](querying-datasets-linq-to-dataset.md).  
  
 [!code-csharp[DP LINQ to DataSet Examples#FillDataSet](../../../../samples/snippets/csharp/VS_Snippets_ADO.NET/DP LINQ to DataSet Examples/CS/Program.cs#filldataset)]
 [!code-vb[DP LINQ to DataSet Examples#FillDataSet](../../../../samples/snippets/visualbasic/VS_Snippets_ADO.NET/DP LINQ to DataSet Examples/VB/Module1.vb#filldataset)]  
  
## See also

- [LINQ to DataSet Overview](linq-to-dataset-overview.md)
- [Querying DataSets](querying-datasets-linq-to-dataset.md)
- [LINQ to DataSet Examples](linq-to-dataset-examples.md)
