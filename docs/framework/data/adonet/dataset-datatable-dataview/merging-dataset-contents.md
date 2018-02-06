---
title: "Merging DataSet Contents"
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
ms.assetid: e5e9309a-3ebb-4a9c-9d78-21c4e2bafc5b
caps.latest.revision: 4
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Merging DataSet Contents
You can use the <xref:System.Data.DataSet.Merge%2A> method to merge the contents of a <xref:System.Data.DataSet>, <xref:System.Data.DataTable>, or <xref:System.Data.DataRow> array into an existing `DataSet`. Several factors and options affect how new data is merged into an existing `DataSet`.  
  
## Primary Keys  
 If the table receiving new data and schema from a merge has a primary key, new rows from the incoming data are matched with existing rows that have the same <xref:System.Data.DataRowVersion.Original> primary key values as those in the incoming data. If the columns from the incoming schema match those of the existing schema, the data in the existing rows is modified. Columns that do not match the existing schema are either ignored or added based on the <xref:System.Data.Common.DataAdapter.MissingSchemaAction%2A> parameter. New rows with primary key values that do not match any existing rows are appended to the existing table.  
  
 If incoming or existing rows have a row state of <xref:System.Data.DataRowState.Added>, their primary key values are matched using the <xref:System.Data.DataRowVersion.Current> primary key value of the `Added` row because no `Original` row version exists.  
  
 If an incoming table and an existing table contain a column with the same name but different data types, an exception is thrown and the <xref:System.Data.DataSet.MergeFailed> event of the `DataSet` is raised. If an incoming table and an existing table both have defined keys, but the primary keys are for different columns, an exception is thrown and the `MergeFailed` event of the `DataSet` is raised.  
  
 If the table receiving new data from a merge does not have a primary key, new rows from the incoming data cannot be matched to existing rows in the table and are instead appended to the existing table.  
  
## Table Names and Namespaces  
 <xref:System.Data.DataTable> objects can optionally be assigned a <xref:System.Data.DataTable.Namespace%2A> property value. When <xref:System.Data.DataTable.Namespace%2A> values are assigned, a <xref:System.Data.DataSet> can contain multiple <xref:System.Data.DataTable> objects with the same <xref:System.Data.DataTable.TableName%2A> value. During merge operations, both <xref:System.Data.DataTable.TableName%2A> and <xref:System.Data.DataTable.Namespace%2A> are used to identify the target of a merge. If no <xref:System.Data.DataTable.Namespace%2A> has been assigned, only the <xref:System.Data.DataTable.TableName%2A> is used to identify the target of a merge.  
  
> [!NOTE]
>  This behavior changed in version 2.0 of the .NET Framework. In version 1.1, namespaces were supported but were ignored during merge operations. For this reason, a <xref:System.Data.DataSet> that uses <xref:System.Data.DataTable.Namespace%2A> property values will have different behaviors depending on which version of the .NET Framework you are running. For example, suppose you have two `DataSets` containing `DataTables` with the same <xref:System.Data.DataTable.TableName%2A> property values but different <xref:System.Data.DataTable.Namespace%2A> property values. In version 1.1 of the .NET Framework, the different <xref:System.Data.DataTable.Namespace%2A> names will be ignored when merging the two <xref:System.Data.DataSet> objects. However, starting with version 2.0, merging causes two new `DataTables` to be created in the target <xref:System.Data.DataSet>. The original `DataTables` will be unaffected by the merge.  
  
## PreserveChanges  
 When you pass a `DataSet`, `DataTable`, or `DataRow` array to the `Merge` method, you can include optional parameters that specify whether or not to preserve changes in the existing `DataSet`, and how to handle new schema elements found in the incoming data. The first of these parameters after the incoming data is a Boolean flag, <xref:System.Data.LoadOption.PreserveChanges>, which specifies whether or not to preserve the changes in the existing `DataSet`. If the `PreserveChanges` flag is set to `true`, incoming values do not overwrite existing values in the `Current` row version of the existing row. If the `PreserveChanges` flag is set to `false`, incoming values do overwrite the existing values in the `Current` row version of the existing row. If the `PreserveChanges` flag is not specified, it is set to `false` by default. For more information about row versions, see [Row States and Row Versions](../../../../../docs/framework/data/adonet/dataset-datatable-dataview/row-states-and-row-versions.md).  
  
 When `PreserveChanges` is `true`, the data from the existing row is maintained in the <xref:System.Data.DataRowVersion.Current> row version of the existing row, while the data from the <xref:System.Data.DataRowVersion.Original> row version of the existing row is overwritten with the data from the `Original` row version of the incoming row. The <xref:System.Data.DataRow.RowState%2A> of the existing row is set to <xref:System.Data.DataRowState.Modified>. The following exceptions apply:  
  
-   If the existing row has a `RowState` of `Deleted`, this `RowState` remains `Deleted` and is not set to `Modified`. In this case, the data from the incoming row will still be stored in the `Original` row version of the existing row, overwriting the `Original` row version of the existing row (unless the incoming row has a `RowState` of `Added`).  
  
-   If the incoming row has a `RowState` of `Added`, the data from the `Original` row version of the existing row will not be overwritten with data from the incoming row, because the incoming row does not have an `Original` row version.  
  
 When `PreserveChanges` is `false`, both the `Current` and `Original` row versions in the existing row are overwritten with the data from the incoming row, and the `RowState` of the existing row is set to the `RowState` of the incoming row. The following exceptions apply:  
  
-   If the incoming row has a `RowState` of `Unchanged` and the existing row has a `RowState` of `Modified`, `Deleted`, or `Added`, the `RowState` of the existing row is set to `Modified`.  
  
-   If the incoming row has a `RowState` of `Added`, and the existing row has a `RowState` of `Unchanged`, `Modified`, or `Deleted`, the `RowState` of the existing row is set to `Modified`. Also, the data from the `Original` row version of the existing row is not overwritten with data from the incoming row, because the incoming row does not have an `Original` row version.  
  
## MissingSchemaAction  
 You can use the optional <xref:System.Data.MissingSchemaAction> parameter of the `Merge` method to specify how `Merge` will handle schema elements in the incoming data that are not part of the existing `DataSet`.  
  
 The following table describes the options for `MissingSchemaAction`.  
  
|MissingSchemaAction option|Description|  
|--------------------------------|-----------------|  
|<xref:System.Data.MissingSchemaAction.Add>|Add the new schema information to the `DataSet` and populate the new columns with the incoming values. This is the default.|  
|<xref:System.Data.MissingSchemaAction.AddWithKey>|Add the new schema and primary key information to the `DataSet` and populate the new columns with the incoming values.|  
|<xref:System.Data.MissingSchemaAction.Error>|Throw an exception if mismatched schema information is encountered.|  
|<xref:System.Data.MissingSchemaAction.Ignore>|Ignore the new schema information.|  
  
## Constraints  
 With the `Merge` method, constraints are not checked until all new data has been added to the existing `DataSet`. Once the data has been added, constraints are enforced on the current values in the `DataSet`. You must ensure that your code handles any exceptions that might be thrown due to constraint violations.  
  
 Consider a case where an existing row in a `DataSet` is an `Unchanged` row with a primary key value of 1. During a merge operation with a `Modified` incoming row with an `Original` primary key value of 2 and a `Current` primary key value of 1, the existing row and the incoming row are not considered matching because the `Original` primary key values differ. However, when the merge is completed and constraints are checked, an exception will be thrown because the `Current` primary key values violate the unique constraint for the primary key column.  
  
> [!NOTE]
>  When rows are inserted into a database table containing an auto incrementing column such as an identity column, the identity column value returned by the insert may not match the value in the `DataSet`, causing the returned rows to be appended instead of merged. For more information, see [Retrieving Identity or Autonumber Values](../../../../../docs/framework/data/adonet/retrieving-identity-or-autonumber-values.md).  
  
 The following code example merges two `DataSet` objects with differents schemas into one `DataSet` with the combined schemas of the two incoming `DataSet` objects.  
  
 [!code-csharp[DataWorks DataSet.Merge#1](../../../../../samples/snippets/csharp/VS_Snippets_ADO.NET/DataWorks DataSet.Merge/CS/source.cs#1)]
 [!code-vb[DataWorks DataSet.Merge#1](../../../../../samples/snippets/visualbasic/VS_Snippets_ADO.NET/DataWorks DataSet.Merge/VB/source.vb#1)]  
  
 The following code example takes an existing `DataSet` with updates and passes those updates to a `DataAdapter` to be processed at the data source. The results are then merged into the original `DataSet`. After rejecting changes that resulted in an error, the merged changes are committed with `AcceptChanges`.  
  
 [!code-csharp[DataWorks DataSet.MergeAcceptChanges#1](../../../../../samples/snippets/csharp/VS_Snippets_ADO.NET/DataWorks DataSet.MergeAcceptChanges/CS/source.cs#1)]
 [!code-vb[DataWorks DataSet.MergeAcceptChanges#1](../../../../../samples/snippets/visualbasic/VS_Snippets_ADO.NET/DataWorks DataSet.MergeAcceptChanges/VB/source.vb#1)]  
  
 [!code-csharp[DataWorks DataSet.MergeAcceptChanges#2](../../../../../samples/snippets/csharp/VS_Snippets_ADO.NET/DataWorks DataSet.MergeAcceptChanges/CS/source.cs#2)]
 [!code-vb[DataWorks DataSet.MergeAcceptChanges#2](../../../../../samples/snippets/visualbasic/VS_Snippets_ADO.NET/DataWorks DataSet.MergeAcceptChanges/VB/source.vb#2)]  
  
## See Also  
 [DataSets, DataTables, and DataViews](../../../../../docs/framework/data/adonet/dataset-datatable-dataview/index.md)  
 [Row States and Row Versions](../../../../../docs/framework/data/adonet/dataset-datatable-dataview/row-states-and-row-versions.md)  
 [DataAdapters and DataReaders](../../../../../docs/framework/data/adonet/dataadapters-and-datareaders.md)  
 [Retrieving and Modifying Data in ADO.NET](../../../../../docs/framework/data/adonet/retrieving-and-modifying-data.md)  
 [Retrieving Identity or Autonumber Values](../../../../../docs/framework/data/adonet/retrieving-identity-or-autonumber-values.md)  
 [ADO.NET Managed Providers and DataSet Developer Center](http://go.microsoft.com/fwlink/?LinkId=217917)
