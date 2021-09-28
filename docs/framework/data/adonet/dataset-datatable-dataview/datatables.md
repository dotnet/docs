---
title: "DataTables"
description: Learn about an ADO.NET DataTable, which represents one table of in-memory relational data, local to the .NET-based application where it resides.
ms.date: "03/30/2017"
ms.assetid: 52ff0e32-3e5a-41de-9a3b-7b04ea52b83e
---
# DataTables

A <xref:System.Data.DataSet> is made up of a collection of tables, relationships, and constraints. In ADO.NET, <xref:System.Data.DataTable> objects are used to represent the tables in a **DataSet**. A **DataTable** represents one table of in-memory relational data; the data is local to the .NET-based application in which it resides, but can be populated from a data source such as Microsoft SQL Server using a **DataAdapter** For more information, see [Populating a DataSet from a DataAdapter](../populating-a-dataset-from-a-dataadapter.md).  
  
 The **DataTable** class is a member of the **System.Data** namespace within the .NET Framework class library. You can create and use a **DataTable** independently or as a member of a **DataSet**, and **DataTable** objects can also be used in conjunction with other .NET Framework objects, including the <xref:System.Data.DataView>. You access the collection of tables in a **DataSet** through the **Tables** property of the **DataSet** object.  
  
 The schema, or structure of a table is represented by columns and constraints. You define the schema of a **DataTable** using <xref:System.Data.DataColumn> objects as well as <xref:System.Data.ForeignKeyConstraint> and <xref:System.Data.UniqueConstraint> objects. The columns in a table can map to columns in a data source, contain calculated values from expressions, automatically increment their values, or contain primary key values.  
  
 In addition to a schema, a **DataTable** must also have rows to contain and order data. The <xref:System.Data.DataRow> class represents the actual data contained in a table. You use the **DataRow** and its properties and methods to retrieve, evaluate, and manipulate the data in a table. As you access and change the data within a row, the **DataRow** object maintains both its current and original state.  
  
 You can create parent-child relationships between tables using one or more related columns in the tables. You create a relationship between **DataTable** objects using a <xref:System.Data.DataRelation>. **DataRelation** objects can then be used to return the related child or parent rows of a particular row. For more information, see [Adding DataRelations](adding-datarelations.md).  
  
## In This Section  

 [Creating a DataTable](creating-a-datatable.md)  
 Explains how to create a **DataTable** and add it to a **DataSet**.  
  
 [DataTable Schema Definition](datatable-schema-definition.md)  
 Provides information about creating and using **DataColumn** objects and constraints.  
  
 [Manipulating Data in a DataTable](manipulating-data-in-a-datatable.md)  
 Explains how to add, modify, and delete data in a table. Explains how to use **DataTable** events to examine changes to data in the table.  
  
 [Handling DataTable Events](handling-datatable-events.md)  
 Provides information about the events available for use with a **DataTable**, including events when column values are modified and rows are added or deleted.  
  
## Related Sections  

 [ADO.NET](../index.md)  
 Describes the ADO.NET architecture and components, and how to use them to access existing data sources and manage application data.  
  
 [DataSets, DataTables, and DataViews](index.md)  
 Provides information about the ADO.NET **DataSet** including how to create relationships between tables.  
  
 <xref:System.Data.Constraint>  
 Provides reference information about the **Constraint** object.  
  
 <xref:System.Data.DataColumn>  
 Provides reference information about the **DataColumn** object.  
  
 <xref:System.Data.DataSet>  
 Provides reference information about the **DataSet** object.  
  
 <xref:System.Data.DataTable>  
 Provides reference information about the **DataTable** object.  
  
 [Class Library Overview](../../../../standard/class-library-overview.md)  
 Provides an overview of the .NET Framework class library, including the **System** namespace as well as its second-level namespace, **System.Data**.  
  
## See also

- [ADO.NET Overview](../ado-net-overview.md)
