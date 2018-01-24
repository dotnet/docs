---
title: "ADO.NET DataSets"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 82b641bb-6001-4512-bf1a-2830acdd92ab
caps.latest.revision: 6
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# ADO.NET DataSets
The <xref:System.Data.DataSet> object is central to supporting disconnected, distributed data scenarios with [!INCLUDE[vstecado](../../../../includes/vstecado-md.md)]. The **DataSet** is a memory-resident representation of data that provides a consistent relational programming model regardless of the data source. It can be used with multiple and differing data sources, with XML data, or to manage data local to the application. The **DataSet** represents a complete set of data, including related tables, constraints, and relationships among the tables. The following illustration shows the **DataSet** object model.  
  
 ![ADO.Net graphic](../../../../docs/framework/data/adonet/media/ado-1-bpuedev11.png "ado_1_bpuedev11")  
DataSet Object Model  
  
 The methods and objects in a **DataSet** are consistent with those in the relational database model.  
  
 The **DataSet** can also persist and reload its contents as XML, and its schema as XML schema definition language (XSD) schema. For more information, see [Using XML in a DataSet](../../../../docs/framework/data/adonet/dataset-datatable-dataview/using-xml-in-a-dataset.md).  
  
## The DataTableCollection  
 An [!INCLUDE[vstecado](../../../../includes/vstecado-md.md)] **DataSet** contains a collection of zero or more tables represented by <xref:System.Data.DataTable> objects. The <xref:System.Data.DataTableCollection> contains all the **DataTable** objects in a **DataSet**.  
  
 A **DataTable** is defined in the <xref:System.Data> namespace and represents a single table of memory-resident data. It contains a collection of columns represented by a <xref:System.Data.DataColumnCollection>, and constraints represented by a <xref:System.Data.ConstraintCollection>, which together define the schema of the table. A **DataTable** also contains a collection of rows represented by the <xref:System.Data.DataRowCollection>, which contains the data in the table. Along with its current state, a <xref:System.Data.DataRow> retains both its current and original versions to identify changes to the values stored in the row.  
  
## The DataView Class  
 A <xref:System.Data.DataView> enables you to create different views of the data stored in a <xref:System.Data.DataTable>, a capability that is often used in data-binding applications. Using a <xref:System.Data.DataView>, you can expose the data in a table with different sort orders, and you can filter the data by row state or based on a filter expression. For more information, see [DataViews](../../../../docs/framework/data/adonet/dataset-datatable-dataview/dataviews.md).  
  
## The DataRelationCollection  
 A **DataSet** contains relationships in its <xref:System.Data.DataRelationCollection> object. A relationship, represented by the <xref:System.Data.DataRelation> object, associates rows in one **DataTable** with rows in another **DataTable**. A relationship is analogous to a join path that might exist between primary and foreign key columns in a relational database. A **DataRelation** identifies matching columns in two tables of a **DataSet**.  
  
 Relationships enable navigation from one table to another in a **DataSet**. The essential elements of a **DataRelation** are the name of the relationship, the name of the tables being related, and the related columns in each table. Relationships can be built with more than one column per table by specifying an array of <xref:System.Data.DataColumn> objects as the key columns. When you add a relationship to the <xref:System.Data.DataRelationCollection>, you can optionally add a **UniqueKeyConstraint** and a **ForeignKeyConstraint** to enforce integrity constraints when changes are made to related column values.  
  
 For more information, see [Adding DataRelations](../../../../docs/framework/data/adonet/dataset-datatable-dataview/adding-datarelations.md).  
  
## XML  
 You can fill a **DataSet** from an XML stream or document. You can use the XML stream or document to supply to the **DataSet** either data, schema information, or both. The information supplied from the XML stream or document can be combined with existing data or schema information already present in the **DataSet**. For more information, see [Using XML in a DataSet](../../../../docs/framework/data/adonet/dataset-datatable-dataview/using-xml-in-a-dataset.md).  
  
## ExtendedProperties  
 The **DataSet**, **DataTable**, and **DataColumn** all have an **ExtendedProperties** property. **ExtendedProperties** is a **PropertyCollection** where you can place custom information, such as the SELECT statement that was used to generate the result set, or the time when the data was generated. The **ExtendedProperties** collection is persisted with the schema information for the **DataSet**.  
  
## LINQ to DataSet  
 [!INCLUDE[linq_dataset](../../../../includes/linq-dataset-md.md)] provides language-integrated querying capabilities for disconnected data stored in a DataSet. [!INCLUDE[linq_dataset](../../../../includes/linq-dataset-md.md)] uses standard [!INCLUDE[vbteclinq](../../../../includes/vbteclinq-md.md)] syntax and provides compile-time syntax checking, static typing, and IntelliSense support when you are using the [!INCLUDE[vsprvs](../../../../includes/vsprvs-md.md)] IDE.  
  
 For more information, see [LINQ to DataSet](../../../../docs/framework/data/adonet/linq-to-dataset.md).  
  
## See Also  
 [ADO.NET Overview](../../../../docs/framework/data/adonet/ado-net-overview.md)  
 [DataSets, DataTables, and DataViews](../../../../docs/framework/data/adonet/dataset-datatable-dataview/index.md)  
 [Retrieving and Modifying Data in ADO.NET](../../../../docs/framework/data/adonet/retrieving-and-modifying-data.md)  
 [ADO.NET Managed Providers and DataSet Developer Center](http://go.microsoft.com/fwlink/?LinkId=217917)
