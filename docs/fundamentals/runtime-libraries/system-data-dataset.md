---
title: System.Data.DataSet class
description: Learn about the System.Data.DataSet class through these additional API remarks.
ms.date: 01/02/2024
---
# System.Data.DataSet class

[!INCLUDE [context](includes/context.md)]

The <xref:System.Data.DataSet> class, which is an in-memory cache of data retrieved from a data source, is a major component of the ADO.NET architecture. The <xref:System.Data.DataSet> consists of a collection of <xref:System.Data.DataTable> objects that you can relate to each other with <xref:System.Data.DataRelation> objects. You can also enforce data integrity in the <xref:System.Data.DataSet> by using the <xref:System.Data.UniqueConstraint> and <xref:System.Data.ForeignKeyConstraint> objects. For further details about working with <xref:System.Data.DataSet> objects, see [DataSets, DataTables, and DataViews](../../framework/data/adonet/dataset-datatable-dataview/index.md).

Whereas <xref:System.Data.DataTable> objects contain the data, the <xref:System.Data.DataRelationCollection> allows you to navigate though the table hierarchy. The tables are contained in a <xref:System.Data.DataTableCollection> accessed through the <xref:System.Data.DataSet.Tables%2A> property. When accessing <xref:System.Data.DataTable> objects, note that they are conditionally case sensitive. For example, if one <xref:System.Data.DataTable> is named "mydatatable" and another is named "Mydatatable", a string used to search for one of the tables is regarded as case sensitive. However, if "mydatatable" exists and "Mydatatable" does not, the search string is regarded as case insensitive. For more information about working with <xref:System.Data.DataTable> objects, see [Creating a DataTable](../../framework/data/adonet/dataset-datatable-dataview/creating-a-datatable.md).

A <xref:System.Data.DataSet> can read and write data and schema as XML documents. The data and schema can then be transported across HTTP and used by any application, on any platform that is XML-enabled. You can save the schema as an XML schema with the <xref:System.Data.DataSet.WriteXmlSchema%2A> method, and both schema and data can be saved using the <xref:System.Data.DataSet.WriteXml%2A> method. To read an XML document that includes both schema and data, use the <xref:System.Data.DataSet.ReadXml%2A> method.

In a typical multiple-tier implementation, the steps for creating and refreshing a <xref:System.Data.DataSet>, and in turn, updating the original data are to:

1. Build and fill each <xref:System.Data.DataTable> in a <xref:System.Data.DataSet> with data from a data source using a <xref:System.Data.Common.DataAdapter>.

2. Change the data in individual <xref:System.Data.DataTable> objects by adding, updating, or deleting <xref:System.Data.DataRow> objects.

3. Invoke the <xref:System.Data.DataSet.GetChanges%2A> method to create a second <xref:System.Data.DataSet> that features only the changes to the data.

4. Call the <xref:System.Data.Common.DataAdapter.Update%2A> method of the <xref:System.Data.Common.DataAdapter>, passing the second <xref:System.Data.DataSet> as an argument.

5. Invoke the <xref:System.Data.DataSet.Merge%2A> method to merge the changes from the second <xref:System.Data.DataSet> into the first.

6. Invoke the <xref:System.Data.DataSet.AcceptChanges%2A> on the <xref:System.Data.DataSet>. Alternatively, invoke <xref:System.Data.DataSet.RejectChanges%2A> to cancel the changes.

> [!NOTE]
> The <xref:System.Data.DataSet> and <xref:System.Data.DataTable> objects inherit from <xref:System.ComponentModel.MarshalByValueComponent>, and support the <xref:System.Runtime.Serialization.ISerializable> interface for remoting. These are the only ADO.NET objects that can be remoted.

> [!NOTE]
> Classes inherited from <xref:System.Data.DataSet> are not finalized by the garbage collector, because the finalizer has been suppressed in <xref:System.Data.DataSet>. The derived class can call the <xref:System.GC.ReRegisterForFinalize%2A> method in its constructor to allow the class to be finalized by the garbage collector.

## Security considerations

For information about DataSet and DataTable security, see [Security guidance](../../framework/data/adonet/dataset-datatable-dataview/security-guidance.md).
