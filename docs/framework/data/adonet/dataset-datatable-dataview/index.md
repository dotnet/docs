---
title: "DataSets, DataTables, and DataViews"
ms.date: "03/30/2017"
ms.assetid: 6d4c4b69-8919-4224-8a65-6cca1c61b48f
---
# DataSets, DataTables, and DataViews
The ADO.NET <xref:System.Data.DataSet> is a memory-resident representation of data that provides a consistent relational programming model regardless of the source of the data it contains. A <xref:System.Data.DataSet> represents a complete set of data including the tables that contain, order, and constrain the data, as well as the relationships between the tables.  
  
 There are several ways of working with a <xref:System.Data.DataSet>, which can be applied independently or in combination. You can:  
  
- Programmatically create a <xref:System.Data.DataTable>, <xref:System.Data.DataRelation>, and <xref:System.Data.Constraint> within a <xref:System.Data.DataSet> and populate the tables with data.  
  
- Populate the <xref:System.Data.DataSet> with tables of data from an existing relational data source using a `DataAdapter`.  
  
- Load and persist the <xref:System.Data.DataSet> contents using XML. For more information, see [Using XML in a DataSet](using-xml-in-a-dataset.md).  
  
 A strongly typed <xref:System.Data.DataSet> can also be transported using an XML Web service. The design of the <xref:System.Data.DataSet> makes it ideal for transporting data using XML Web services. For an overview of XML Web services, see [XML Web Services Overview](https://docs.microsoft.com/previous-versions/dotnet/netframework-4.0/w9fdtx28(v=vs.100)). For an example of consuming a <xref:System.Data.DataSet> from an XML Web service, see [Consuming a DataSet from an XML Web Service](consuming-a-dataset-from-an-xml-web-service.md).  
  
## In This Section  
 [Creating a DataSet](creating-a-dataset.md)  
 Describes the syntax for creating an instance of a <xref:System.Data.DataSet>.  
  
 [Adding a DataTable to a DataSet](adding-a-datatable-to-a-dataset.md)  
 Describes how to create and add tables and columns to a <xref:System.Data.DataSet>.  
  
 [Adding DataRelations](adding-datarelations.md)  
 Describes how to create relations between tables in a <xref:System.Data.DataSet>.  
  
 [Navigating DataRelations](navigating-datarelations.md)  
 Describes how to use the relations between tables in a <xref:System.Data.DataSet> to return the child or parent rows of a parent-child relationship.  
  
 [Merging DataSet Contents](merging-dataset-contents.md)  
 Describes how to merge the contents of one <xref:System.Data.DataSet>, <xref:System.Data.DataTable>, or <xref:System.Data.DataRow> array into another <xref:System.Data.DataSet>.  
  
 [Copying DataSet Contents](copying-dataset-contents.md)  
 Describes how to create a copy of a <xref:System.Data.DataSet> that can contain schema as well as specified data.  
  
 [Handling DataSet Events](handling-dataset-events.md)  
 Describes the events of a <xref:System.Data.DataSet> and how to use them.  
  
 [Typed DataSets](typed-datasets.md)  
 Discusses what a typed <xref:System.Data.DataSet> is and how to create and use it.  
  
 [DataTables](datatables.md)  
 Describes how to create a <xref:System.Data.DataTable>, define the schema, and manipulate data.  
  
 [DataTableReaders](datatablereaders.md)  
 Describes how to create and use a <xref:System.Data.DataTableReader>.  
  
 [DataViews](dataviews.md)  
 Describes how to create and work with `DataViews` and work with <xref:System.Data.DataView> events.  
  
 [Using XML in a DataSet](using-xml-in-a-dataset.md)  
 Describes how the <xref:System.Data.DataSet> interacts with XML as a data source, including loading and persisting the contents of a <xref:System.Data.DataSet> as XML data.  
  
 [Consuming a DataSet from an XML Web Service](consuming-a-dataset-from-an-xml-web-service.md)  
 Describes how to create an XML Web service that uses a <xref:System.Data.DataSet> to transport data.  
  
## Related Sections  
 [What's New in ADO.NET](../whats-new.md)  
 Introduces features that are new in ADO.NET.  
  
 [ADO.NET Overview](../ado-net-overview.md)  
 Provides an introduction to the design and components of ADO.NET.  
  
 [Populating a DataSet from a DataAdapter](../populating-a-dataset-from-a-dataadapter.md)  
 Describes how to load a **DataSet** with data from a data source.  
  
 [Updating Data Sources with DataAdapters](../updating-data-sources-with-dataadapters.md)  
 Describes how to resolve changes to the data in a **DataSet** back to the data source.  
  
 [Adding Existing Constraints to a DataSet](../adding-existing-constraints-to-a-dataset.md)  
 Describes how to populate a **DataSet** with primary key information from a data source.  
  
## See also

- [ADO.NET](../index.md)
- [ADO.NET Overview](../ado-net-overview.md)
