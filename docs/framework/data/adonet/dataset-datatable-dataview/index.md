---
title: "DataSets, DataTables, and DataViews"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 6d4c4b69-8919-4224-8a65-6cca1c61b48f
caps.latest.revision: 4
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# DataSets, DataTables, and DataViews
The ADO.NET <xref:System.Data.DataSet> is a memory-resident representation of data that provides a consistent relational programming model regardless of the source of the data it contains. A <xref:System.Data.DataSet> represents a complete set of data including the tables that contain, order, and constrain the data, as well as the relationships between the tables.  
  
 There are several ways of working with a <xref:System.Data.DataSet>, which can be applied independently or in combination. You can:  
  
-   Programmatically create a <xref:System.Data.DataTable>, <xref:System.Data.DataRelation>, and <xref:System.Data.Constraint> within a <xref:System.Data.DataSet> and populate the tables with data.  
  
-   Populate the <xref:System.Data.DataSet> with tables of data from an existing relational data source using a `DataAdapter`.  
  
-   Load and persist the <xref:System.Data.DataSet> contents using XML. For more information, see [Using XML in a DataSet](../../../../../docs/framework/data/adonet/dataset-datatable-dataview/using-xml-in-a-dataset.md).  
  
 A strongly typed <xref:System.Data.DataSet> can also be transported using an XML Web service. The design of the <xref:System.Data.DataSet> makes it ideal for transporting data using XML Web services. For an overview of XML Web services, see [XML Web Services Overview](http://msdn.microsoft.com/library/9db0c7b8-bca6-462b-9be5-f5f9a7f05a4d). For an example of consuming a <xref:System.Data.DataSet> from an XML Web service, see [Consuming a DataSet from an XML Web Service](../../../../../docs/framework/data/adonet/dataset-datatable-dataview/consuming-a-dataset-from-an-xml-web-service.md).  
  
## In This Section  
 [Creating a DataSet](../../../../../docs/framework/data/adonet/dataset-datatable-dataview/creating-a-dataset.md)  
 Describes the syntax for creating an instance of a <xref:System.Data.DataSet>.  
  
 [Adding a DataTable to a DataSet](../../../../../docs/framework/data/adonet/dataset-datatable-dataview/adding-a-datatable-to-a-dataset.md)  
 Describes how to create and add tables and columns to a <xref:System.Data.DataSet>.  
  
 [Adding DataRelations](../../../../../docs/framework/data/adonet/dataset-datatable-dataview/adding-datarelations.md)  
 Describes how to create relations between tables in a <xref:System.Data.DataSet>.  
  
 [Navigating DataRelations](../../../../../docs/framework/data/adonet/dataset-datatable-dataview/navigating-datarelations.md)  
 Describes how to use the relations between tables in a <xref:System.Data.DataSet> to return the child or parent rows of a parent-child relationship.  
  
 [Merging DataSet Contents](../../../../../docs/framework/data/adonet/dataset-datatable-dataview/merging-dataset-contents.md)  
 Describes how to merge the contents of one <xref:System.Data.DataSet>, <xref:System.Data.DataTable>, or <xref:System.Data.DataRow> array into another <xref:System.Data.DataSet>.  
  
 [Copying DataSet Contents](../../../../../docs/framework/data/adonet/dataset-datatable-dataview/copying-dataset-contents.md)  
 Describes how to create a copy of a <xref:System.Data.DataSet> that can contain schema as well as specified data.  
  
 [Handling DataSet Events](../../../../../docs/framework/data/adonet/dataset-datatable-dataview/handling-dataset-events.md)  
 Describes the events of a <xref:System.Data.DataSet> and how to use them.  
  
 [Typed DataSets](../../../../../docs/framework/data/adonet/dataset-datatable-dataview/typed-datasets.md)  
 Discusses what a typed <xref:System.Data.DataSet> is and how to create and use it.  
  
 [DataTables](../../../../../docs/framework/data/adonet/dataset-datatable-dataview/datatables.md)  
 Describes how to create a <xref:System.Data.DataTable>, define the schema, and manipulate data.  
  
 [DataTableReaders](../../../../../docs/framework/data/adonet/dataset-datatable-dataview/datatablereaders.md)  
 Describes how to create and use a <xref:System.Data.DataTableReader>.  
  
 [DataViews](../../../../../docs/framework/data/adonet/dataset-datatable-dataview/dataviews.md)  
 Describes how to create and work with `DataViews` and work with <xref:System.Data.DataView> events.  
  
 [Using XML in a DataSet](../../../../../docs/framework/data/adonet/dataset-datatable-dataview/using-xml-in-a-dataset.md)  
 Describes how the <xref:System.Data.DataSet> interacts with XML as a data source, including loading and persisting the contents of a <xref:System.Data.DataSet> as XML data.  
  
 [Consuming a DataSet from an XML Web Service](../../../../../docs/framework/data/adonet/dataset-datatable-dataview/consuming-a-dataset-from-an-xml-web-service.md)  
 Describes how to create an XML Web service that uses a <xref:System.Data.DataSet> to transport data.  
  
## Related Sections  
 [What's New in ADO.NET](../../../../../docs/framework/data/adonet/whats-new.md)  
 Introduces features that are new in ADO.NET.  
  
 [ADO.NET Overview](../../../../../docs/framework/data/adonet/ado-net-overview.md)  
 Provides an introduction to the design and components of ADO.NET.  
  
 [Populating a DataSet from a DataAdapter](../../../../../docs/framework/data/adonet/populating-a-dataset-from-a-dataadapter.md)  
 Describes how to load a **DataSet** with data from a data source.  
  
 [Updating Data Sources with DataAdapters](../../../../../docs/framework/data/adonet/updating-data-sources-with-dataadapters.md)  
 Describes how to resolve changes to the data in a **DataSet** back to the data source.  
  
 [Adding Existing Constraints to a DataSet](../../../../../docs/framework/data/adonet/adding-existing-constraints-to-a-dataset.md)  
 Describes how to populate a **DataSet** with primary key information from a data source.  
  
## See Also  
 [ADO.NET](../../../../../docs/framework/data/adonet/index.md)  
 [ADO.NET Managed Providers and DataSet Developer Center](http://go.microsoft.com/fwlink/?LinkId=217917)
