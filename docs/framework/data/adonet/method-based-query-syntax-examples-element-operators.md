---
title: "Method-Based Query Syntax Examples: Element Operators (LINQ to DataSet) | Microsoft Docs"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework-4.6"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: eedf2fbd-f407-4f62-bb1a-c00eb001b1dd
caps.latest.revision: 2
author: "JennieHubbard"
ms.author: "jhubbard"
manager: "jhubbard"
---
# Method-Based Query Syntax Examples: Element Operators (LINQ to DataSet)
The examples in this topic demonstrate how to use the <xref:System.Linq.Enumerable.First%2A> and <xref:System.Linq.Enumerable.ElementAt%2A> methods to get <xref:System.Data.DataRow> elements from a <xref:System.Data.DataSet> using the query expression syntax.  
  
 The `FillDataSet` method used in these examples is specified in [Loading Data Into a DataSet](../../../../docs/framework/data/adonet/loading-data-into-a-dataset.md).  
  
 The examples in this topic use the Contact, Address, Product, SalesOrderHeader, and SalesOrderDetail tables in the AdventureWorks sample database.  
  
 The examples in this topic use the following `using`/`Imports` statements:  
  
<!-- TODO: review snippet reference  [!CODE [DP LINQ to DataSetExamples#ImportsUsing](DP LINQ to DataSetExamples#ImportsUsing)]  -->  
  
 For more information, see [How to: Create a LINQ to DataSet Project In Visual Studio](../../../../docs/framework/data/adonet/how-to-create-a-linq-to-dataset-project-in-vs.md).  
  
## ElementAt  
  
### Example  
 This example uses the <xref:System.Linq.Enumerable.ElementAt%2A> method to retrieve the fifth address where `PostalCode` == "M4B 1V7".  
  
<!-- TODO: review snippet reference  [!CODE [DP LINQ to DataSetExamples#ElementAt](DP LINQ to DataSetExamples#ElementAt)]  -->  
  
## First  
  
### Example  
 This example uses the <xref:System.Linq.Enumerable.First%2A> method to return the first contact whose first name is 'Brooke'.  
  
<!-- TODO: review snippet reference  [!CODE [DP LINQ to DataSetExamples#FirstSimple](DP LINQ to DataSetExamples#FirstSimple)]  -->  
  
## See Also  
 [Loading Data Into a DataSet](../../../../docs/framework/data/adonet/loading-data-into-a-dataset.md)   
 [LINQ to DataSet Examples](../../../../docs/framework/data/adonet/linq-to-dataset-examples.md)   
 [Standard Query Operators Overview](http://msdn.microsoft.com/library/24cda21e-8af8-4632-b519-c404a839b9b2)