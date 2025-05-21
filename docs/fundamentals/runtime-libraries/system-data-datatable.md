---
title: System.Data.DataTable class
description: Learn about the System.Data.DataTable class through these additional API remarks.
ms.date: 01/02/2024
dev_langs:
  - CSharp
  - VB
ms.topic: article
---
# System.Data.DataTable class

[!INCLUDE [context](includes/context.md)]

The <xref:System.Data.DataTable> class is a central object in the ADO.NET library. Other objects that use <xref:System.Data.DataTable> include the <xref:System.Data.DataSet> and the <xref:System.Data.DataView>.

<xref:System.Data.DataTable> object names are conditionally case sensitive. For example, if one <xref:System.Data.DataTable> is named "mydatatable" and another is named "Mydatatable", a string used to search for one of the tables is regarded as case sensitive. However, if "mydatatable" exists and "Mydatatable" does not, the search string is regarded as case insensitive. A <xref:System.Data.DataSet> can contain two <xref:System.Data.DataTable> objects that have the same <xref:System.Data.DataTable.TableName%2A> property value but different <xref:System.Data.DataTable.Namespace%2A> property values. For more information about working with <xref:System.Data.DataTable> objects, see [Creating a DataTable](../../framework/data/adonet/dataset-datatable-dataview/creating-a-datatable.md).

If you're creating a <xref:System.Data.DataTable> programmatically, you must first define its schema by adding <xref:System.Data.DataColumn> objects to the <xref:System.Data.DataColumnCollection> (accessed through the <xref:System.Data.DataTable.Columns%2A> property). For more information about adding <xref:System.Data.DataColumn> objects, see [Adding Columns to a DataTable](../../framework/data/adonet/dataset-datatable-dataview/adding-columns-to-a-datatable.md).

To add rows to a <xref:System.Data.DataTable>, you must first use the <xref:System.Data.DataTable.NewRow%2A> method to return a new <xref:System.Data.DataRow> object. The <xref:System.Data.DataTable.NewRow%2A> method returns a row with the schema of the <xref:System.Data.DataTable>, as it is defined by the table's <xref:System.Data.DataColumnCollection>. The maximum number of rows that a <xref:System.Data.DataTable> can store is 16,777,216. For more information, see [Adding Data to a DataTable](../../framework/data/adonet/dataset-datatable-dataview/adding-data-to-a-datatable.md).

The <xref:System.Data.DataTable> also contains a collection of <xref:System.Data.Constraint> objects that can be used to ensure the integrity of the data. For more information, see [DataTable Constraints](../../framework/data/adonet/dataset-datatable-dataview/datatable-constraints.md).

There are many <xref:System.Data.DataTable> events that can be used to determine when changes are made to a table. These include <xref:System.Data.DataTable.RowChanged>, <xref:System.Data.DataTable.RowChanging>, <xref:System.Data.DataTable.RowDeleting>, and <xref:System.Data.DataTable.RowDeleted>. For more information about the events that can be used with a <xref:System.Data.DataTable>, see [Handling DataTable Events](../../framework/data/adonet/dataset-datatable-dataview/handling-datatable-events.md).

When an instance of <xref:System.Data.DataTable> is created, some of the read/write properties are set to initial values. For a list of these values, see the <xref:System.Data.DataTable.%23ctor%2A> constructor.

> [!NOTE]
> The <xref:System.Data.DataSet> and <xref:System.Data.DataTable> objects inherit from <xref:System.ComponentModel.MarshalByValueComponent> and support the <xref:System.Runtime.Serialization.ISerializable> interface for .NET remoting. These are the only ADO.NET objects that you can use for .NET remoting.

## Security considerations

For information about DataSet and DataTable security, see [Security guidance](../../framework/data/adonet/dataset-datatable-dataview/security-guidance.md).

## Examples

This sample demonstrates how to create a DataTable manually with specific schema definitions:

- Create multiple DataTables and define the initial columns.
- Create the table constraints.
- Insert the values and display the tables.
- Create the expression columns and display the tables.

:::code language="csharp" source="./snippets/System.Data/DataTable/Overview/cs/source.cs" id="Snippet1":::
:::code language="vb" source="./snippets/System.Data/DataTable/Overview/vb/source.vb" id="Snippet1":::
