---
title: "Handling DataTable Events"
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
ms.assetid: 62f404a5-13ea-4b93-a29f-55b74a16c9d3
caps.latest.revision: 4
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Handling DataTable Events
The <xref:System.Data.DataTable> object provides a series of events that can be processed by an application. The following table describes `DataTable` events.  
  
|Event|Description|  
|-----------|-----------------|  
|<xref:System.Data.DataTable.Initialized>|Occurs after the <xref:System.Data.DataTable.EndInit%2A> method of a `DataTable` is called. This event is intended primarily to support design-time scenarios.|  
|<xref:System.Data.DataTable.ColumnChanged>|Occurs after a value has been successfully changed in a <xref:System.Data.DataColumn>.|  
|<xref:System.Data.DataTable.ColumnChanging>|Occurs when a value has been submitted for a `DataColumn`.|  
|<xref:System.Data.DataTable.RowChanged>|Occurs after a `DataColumn` value or the <xref:System.Data.DataRow.RowState%2A> of a <xref:System.Data.DataRow> in the `DataTable` has been changed successfully.|  
|<xref:System.Data.DataTable.RowChanging>|Occurs when a change has been submitted for a `DataColumn` value or the `RowState` of a `DataRow` in the `DataTable`.|  
|<xref:System.Data.DataTable.RowDeleted>|Occurs after a `DataRow` in the `DataTable` has been marked as `Deleted`.|  
|<xref:System.Data.DataTable.RowDeleting>|Occurs before a `DataRow` in the `DataTable` is marked as `Deleted`.|  
|<xref:System.Data.DataTable.TableCleared>|Occurs after a call to the <xref:System.Data.DataTable.Clear%2A> method of the `DataTable` has successfully cleared every `DataRow`.|  
|<xref:System.Data.DataTable.TableClearing>|Occurs after the `Clear` method is called but before the `Clear` operation begins.|  
|<xref:System.Data.DataTable.TableNewRow>|Occurs after a new `DataRow` is created by a call to the `NewRow` method of the `DataTable`.|  
|<xref:System.ComponentModel.MarshalByValueComponent.Disposed>|Occurs when the `DataTable` is `Disposed`. Inherited from <xref:System.ComponentModel.MarshalByValueComponent>.|  
  
> [!NOTE]
>  Most operations that add or delete rows do not raise the `ColumnChanged` and `ColumnChanging` events. However, the `ReadXml` method does raise `ColumnChanged` and `ColumnChanging` events, unless the `XmlReadMode` is set to `DiffGram` or is set to `Auto` when the XML document being read is a `DiffGram`.  
  
> [!WARNING]
>  Data corruption can occur if data is modified in a `DataSet` from which the `RowChanged` event is raised. No exception will be raised if such data corruption occurs.  
  
## Additional Related Events  
 The <xref:System.Data.DataTable.Constraints%2A> property holds a <xref:System.Data.ConstraintCollection> instance. The <xref:System.Data.ConstraintCollection> class exposes a <xref:System.Data.ConstraintCollection.CollectionChanged> event. This event fires when a constraint is added, modified, or removed from the `ConstraintCollection`.  
  
 The <xref:System.Data.DataTable.Columns%2A> property holds a <xref:System.Data.DataColumnCollection> instance. The `DataColumnCollection` class exposes a <xref:System.Data.DataColumnCollection.CollectionChanged> event. This event fires when a `DataColumn` is added, modified, or removed from the `DataColumnCollection`. Modifications that cause the event to fire include changes to the name, type, expression or ordinal position of a column.  
  
 The <xref:System.Data.DataSet.Tables%2A> property of a <xref:System.Data.DataSet> holds a <xref:System.Data.DataTableCollection> instance. The `DataTableCollection` class exposes both a `CollectionChanged` and a `CollectionChanging` event. These events fire when a `DataTable` is added to or removed from the `DataSet`.  
  
 Changes to `DataRows` can also trigger events for an associated <xref:System.Data.DataView>. The `DataView` class exposes a <xref:System.Data.DataView.ListChanged> event that fires when a `DataColumn` value changes or when the composition or sort order of the view changes. The <xref:System.Data.DataRowView> class exposes a <xref:System.Data.DataRowView.PropertyChanged> event that fires when an associated `DataColumn` value changes.  
  
## Sequence of Operations  
 Here is the sequence of operations that occur when a `DataRow` is added, modified, or deleted:  
  
1.  Create the proposed record and apply any changes.  
  
2.  Check constraints for non-expression columns.  
  
3.  Raise the `RowChanging` or `RowDeleting` events as applicable.  
  
4.  Set the proposed record to be the current record.  
  
5.  Update any associated indexes.  
  
6.  Raise `ListChanged` events for associated `DataView` objects and `PropertyChanged` events for associated `DataRowView` objects.  
  
7.  Evaluate all expression columns, but delay checking any constraints on these columns.  
  
8.  Raise `ListChanged` events for associated `DataView` objects and `PropertyChanged` events for associated `DataRowView` objects affected by the expression column evaluations.  
  
9. Raise `RowChanged` or `RowDeleted` events as applicable.  
  
10. Check constraints on expression columns.  
  
> [!NOTE]
>  Changes to expression columns never raise `DataTable` events. Changes to expression columns only raise `DataView` and `DataRowView` events. Expression columns can have dependencies on multiple other columns, and can be evaluated multiple times during a single `DataRow` operation. Each expression evaluation raises events, and a single `DataRow` operation can raise multiple `ListChanged` and `PropertyChanged` events when expression columns are affected, possibly including multiple events for the same expression column.  
  
> [!WARNING]
>  Do not throw a <xref:System.NullReferenceException> within the `RowChanged` event handler. If a <xref:System.NullReferenceException> is thrown within the `RowChanged` event of a `DataTable`, then the `DataTable` will be corrupted.  
  
### Example  
 The following example demonstrates how to create event handlers for the `RowChanged`, `RowChanging`, `RowDeleted`, `RowDeleting`, `ColumnChanged`, `ColumnChanging`, `TableNewRow`, `TableCleared`, and `TableClearing` events. Each event handler displays output in the console window when it is fired.  
  
 [!code-csharp[DataWorks DataTable.Events#1](../../../../../samples/snippets/csharp/VS_Snippets_ADO.NET/DataWorks DataTable.Events/CS/source.cs#1)]
 [!code-vb[DataWorks DataTable.Events#1](../../../../../samples/snippets/visualbasic/VS_Snippets_ADO.NET/DataWorks DataTable.Events/VB/source.vb#1)]  
  
## See Also  
 [Manipulating Data in a DataTable](../../../../../docs/framework/data/adonet/dataset-datatable-dataview/manipulating-data-in-a-datatable.md)  
 [Handling DataAdapter Events](../../../../../docs/framework/data/adonet/handling-dataadapter-events.md)  
 [Handling DataSet Events](../../../../../docs/framework/data/adonet/dataset-datatable-dataview/handling-dataset-events.md)  
 [ADO.NET Managed Providers and DataSet Developer Center](http://go.microsoft.com/fwlink/?LinkId=217917)
