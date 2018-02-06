---
title: "Navigating DataRelations"
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
ms.assetid: e5e673f4-9b44-45ae-aaea-c504d1cc5d3e
caps.latest.revision: 3
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Navigating DataRelations
One of the primary functions of a <xref:System.Data.DataRelation> is to allow navigation from one <xref:System.Data.DataTable> to another within a <xref:System.Data.DataSet>. This allows you to retrieve all the related <xref:System.Data.DataRow> objects in one **DataTable** when given a single **DataRow** from a related **DataTable**. For example, after establishing a **DataRelation** between a table of customers and a table of orders, you can retrieve all the order rows for a particular customer row using **GetChildRows**.  
  
 The following code example creates a **DataRelation** between the **Customers** table and the **Orders** table of a **DataSet** and returns all the orders for each customer.  
  
 [!code-csharp[DataWorks Data.DataTableRelation#1](../../../../../samples/snippets/csharp/VS_Snippets_ADO.NET/DataWorks Data.DataTableRelation/CS/source.cs#1)]
 [!code-vb[DataWorks Data.DataTableRelation#1](../../../../../samples/snippets/visualbasic/VS_Snippets_ADO.NET/DataWorks Data.DataTableRelation/VB/source.vb#1)]  
  
 The next example builds on the preceding example, relating four tables together and navigating those relationships. As in the previous example, **CustomerID** relates the **Customers** table to the **Orders** table. For each customer in the **Customers** table, all the child rows in the **Orders** table are determined, in order to return the number of orders a particular customer has and their **OrderID** values.  
  
 The expanded example also returns the values from the **OrderDetails** and **Products** tables. The **Orders** table is related to the **OrderDetails** table using **OrderID** to determine, for each customer order, what products and quantities were ordered. Because the **OrderDetails** table only contains the **ProductID** of an ordered product, **OrderDetails** is related to **Products** using **ProductID** in order to return the **ProductName**. In this relation, the **Products** table is the parent and the **Order Details** table is the child. As a result, when iterating through the **OrderDetails** table, **GetParentRow** is called to retrieve the related **ProductName** value.  
  
 Notice that when the **DataRelation** is created for the **Customers** and **Orders** tables, no value is specified for the **createConstraints** flag (the default is **true**). This assumes that all the rows in the **Orders** table have a **CustomerID** value that exists in the parent **Customers** table. If a **CustomerID** exists in the **Orders** table that does not exist in the **Customers** table, a <xref:System.Data.ForeignKeyConstraint> causes an exception to be thrown.  
  
 When the child column might contain values that the parent column does not contain, set the **createConstraints** flag to **false** when adding the **DataRelation**. In the example, the **createConstraints** flag is set to **false** for the **DataRelation** between the **Orders** table and the **OrderDetails** table. This enables the application to return all the records from the **OrderDetails** table and only a subset of records from the **Orders** table without generating a run-time exception. The expanded sample generates output in the following format.  
  
```  
Customer ID: NORTS  
  Order ID: 10517  
        Order Date: 4/24/1997 12:00:00 AM  
           Product: Filo Mix  
          Quantity: 6  
           Product: Raclette Courdavault  
          Quantity: 4  
           Product: Outback Lager  
          Quantity: 6  
  Order ID: 11057  
        Order Date: 4/29/1998 12:00:00 AM  
           Product: Outback Lager  
          Quantity: 3  
```  
  
 The following code example is an expanded sample where the values from the **OrderDetails** and **Products** tables are returned, with only a subset of the records in the **Orders** table being returned.  
  
 [!code-csharp[DataWorks Data.DataTableNavigation#1](../../../../../samples/snippets/csharp/VS_Snippets_ADO.NET/DataWorks Data.DataTableNavigation/CS/source.cs#1)]
 [!code-vb[DataWorks Data.DataTableNavigation#1](../../../../../samples/snippets/visualbasic/VS_Snippets_ADO.NET/DataWorks Data.DataTableNavigation/VB/source.vb#1)]  
  
## See Also  
 [DataSets, DataTables, and DataViews](../../../../../docs/framework/data/adonet/dataset-datatable-dataview/index.md)  
 [ADO.NET Managed Providers and DataSet Developer Center](http://go.microsoft.com/fwlink/?LinkId=217917)
