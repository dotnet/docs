---
title: "Data Binding"
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
ms.assetid: cbec8b02-a1e8-4ae8-a83b-bb5190413ac5
caps.latest.revision: 2
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Data Binding
[!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] supports binding to common controls, such as grid controls. Specifically, [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] defines the basic patterns for binding to a data grid and handling master-detail binding, both with regard to display and updating.  
  
## Underlying Principle  
 [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] translates [!INCLUDE[vbteclinq](../../../../../../includes/vbteclinq-md.md)] queries to SQL for execution on a database. The results are strongly typed `IEnumerable`. Because these objects are ordinary common language runtime (CLR) objects, ordinary object data binding can be used to display the results. On the other hand, change operations (inserts, updates, and deletes) require additional steps.  
  
## Operation  
 Implicitly binding to Windows Forms controls is accomplished by implementing <xref:System.ComponentModel.IListSource>. Data sources generic <xref:System.Data.Linq.Table%601> (`Table<T>` in C# or `Table(Of T)` in [!INCLUDE[vbprvb](../../../../../../includes/vbprvb-md.md)]) and generic `DataQuery` have been updated to implement <xref:System.ComponentModel.IListSource>. User interface (UI) data-binding engines (Windows Forms and Windows Presentation Foundation) both test whether their data source implements <xref:System.ComponentModel.IListSource>. Therefore, writing a direct affectation of a query to a data source of a control implicitly calls [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] collection generation, as in the following example:  
  
 [!code-csharp[DLinqDataBinding#1](../../../../../../samples/snippets/csharp/VS_Snippets_Data/DLinqDataBinding/cs/Program.cs#1)]
 [!code-vb[DLinqDataBinding#1](../../../../../../samples/snippets/visualbasic/VS_Snippets_Data/DLinqDataBinding/vb/Module1.vb#1)]  
  
 The same occurs with Windows Presentation Foundation:  
  
 [!code-csharp[DLinqDataBinding#2](../../../../../../samples/snippets/csharp/VS_Snippets_Data/DLinqDataBinding/cs/Program.cs#2)]
 [!code-vb[DLinqDataBinding#2](../../../../../../samples/snippets/visualbasic/VS_Snippets_Data/DLinqDataBinding/vb/Module1.vb#2)]  
  
 Collection generations are implemented by generic <xref:System.Data.Linq.Table%601> and generic `DataQuery` in <xref:System.ComponentModel.IListSource.GetList%2A>.  
  
## IListSource Implementation  
 [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] implements <xref:System.ComponentModel.IListSource> in two locations:  
  
-   The data source is a <xref:System.Data.Linq.Table%601>: [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] browses the table to fill a `DataBindingList` collection that keeps a reference on the table.  
  
-   The data source is an <xref:System.Linq.IQueryable%601>. There are two scenarios:  
  
    -   If [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] finds the underlying <xref:System.Data.Linq.Table%601> from the <xref:System.Linq.IQueryable%601>, the source allows for edition and the situation is the same as in the first bullet point.  
  
    -   If [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] cannot find the underlying <xref:System.Data.Linq.Table%601>, the source does not allow for edition (for example, `groupby`). [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] browses the query to fill a generic `SortableBindingList`, which is a simple <xref:System.ComponentModel.BindingList%601> that implements the sorting feature for T entities for a given property.  
  
## Specialized Collections  
 For many features described earlier in this document, <xref:System.ComponentModel.BindingList%601> has been specialized to some different classes. These classes are generic `SortableBindingList` and generic `DataBindingList`. Both are declared as internal.  
  
### Generic SortableBindingList  
 This class inherits from <xref:System.ComponentModel.BindingList%601>, and is a sortable version of <xref:System.ComponentModel.BindingList%601>. Sorting is an in-memory solution and never contacts the database itself. <xref:System.ComponentModel.BindingList%601> implements <xref:System.ComponentModel.IBindingList> but does not support sorting by default. However, <xref:System.ComponentModel.BindingList%601> implements <xref:System.ComponentModel.IBindingList> with virtual *core* methods. You can easily override these methods. Generic `SortableBindingList` overrides <xref:System.ComponentModel.BindingList%601.SupportsSortingCore%2A>, <xref:System.ComponentModel.BindingList%601.SortPropertyCore%2A>, <xref:System.ComponentModel.BindingList%601.SortDirectionCore%2A>, and <xref:System.ComponentModel.BindingList%601.ApplySortCore%2A>. `ApplySortCore` is called by <xref:System.ComponentModel.IBindingList.ApplySort%2A> and sorts the list of T items for a given property.  
  
 An exception is raised if the property does not belong to T.  
  
 To achieve sorting, [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] creates a generic `SortableBindingList.PropertyComparer` class that inherits from generic <xref:System.Collections.Generic.Comparer%601.System%23Collections%23IComparer%23Compare%2A> and implements a default comparer for a given type T, a `PropertyDescriptor`, and a direction. This class dynamically creates a `Comparer` of T where T is the `PropertyType` of the `PropertyDescriptor`. Then, the default comparer is retrieved from the static generic `Comparer`. A default instance is obtained by using reflection.  
  
 Generic `SortableBindingList` is also the base class for `DataBindingList`. Generic `SortableBindingList` offers two virtual methods for suspending or resuming items add/remove tracking. Those two methods can be used for base features such as sorting, but will really be implemented by upper classes like generic `DataBindingList`.  
  
### Generic DataBindingList  
 This class inherits from generic `SortableBindingLIst`. Generic `DataBindingList` keeps a reference on the underlying generic `Table` of the generic `IQueryable` used for the initial filling of the collection. Generic `DatabindingList` adds tracking for item add/remove to the collection by overriding `InsertItem`() and `RemoveItem`(). It also implements the abstract suspend/resume tracking feature to make tracking conditional. This feature makes generic `DataBindingList` take advantage of all the polymorphic usage of the tracking feature of the parent classes.  
  
## Binding to EntitySets  
 Binding to `EntitySet` is a special case because `EntitySet` is already a collection that implements <xref:System.ComponentModel.IBindingList>. [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] adds sorting and canceling (<xref:System.ComponentModel.ICancelAddNew>) support. An `EntitySet` class uses an internal list to store entities. This list is a low-level collection based on a generic array, the generic `ItemList` class.  
  
### Adding a Sorting Feature  
 Arrays offer a sort method (`Array.Sort()`) that you can be used with a `Comparer` of T. [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] uses the generic `SortableBindingList.PropertyComparer` class described earlier in this topic to obtain this `Comparer` for the property and the direction to be sorted on. An `ApplySort` method is added to generic `ItemList` to call this feature.  
  
 On the `EntitySet` side, you now have to declare sorting support:  
  
-   <xref:System.ComponentModel.IBindingList.SupportsSorting%2A> returns `true`.  
  
-   <xref:System.ComponentModel.IBindingList.ApplySort%2A> calls `entities.ApplySort()` and then `OnListChanged()`.  
  
-   <xref:System.ComponentModel.IBindingList.SortDirection%2A> and <xref:System.ComponentModel.IBindingList.SortProperty%2A> properties expose the current sorting definition, which is stored in local members.  
  
 When you use a System.Windows.Forms.BindingSource and bind an EntitySet\<TEntity> to the System.Windows.Forms.BindingSource.DataSource, you must call EntitySet\<Tentity>.GetNewBindingList to update BindingSource.List.  
  
 If you use a System.Windows.Forms.BindingSource and set the BindingSource.DataMember property and set BindingSource.DataSource to a class that has a property named in the BindingSource.DataMember that exposes the EntitySet\<TEntity>, you don’t have to call EntitySet\<Tentity>.GetNewBindingList to update the BindingSource.List but you lose Sorting capability.  
  
## Caching  
 [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] queries implement <xref:System.ComponentModel.IListSource.GetList%2A>. When the Windows Forms BindingSource class meets this interface, it calls GetList() threes time for a single connection. To work around this situation, [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] implements a cache per instance to store and always return the same generated collection.  
  
## Cancellation  
 <xref:System.ComponentModel.IBindingList> defines an <xref:System.ComponentModel.IBindingList.AddNew%2A> method that is used by controls to create a new item from a bound collection. The `DataGridView` control shows this feature very well when the last visible row contains a star in its header. The star shows you that you can add a new item.  
  
 In addition to this feature, a collection can also implement <xref:System.ComponentModel.ICancelAddNew>. This feature allows for the controls to cancel or validate that the new edited item has been validated or not.  
  
 <xref:System.ComponentModel.ICancelAddNew> is implemented in all [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] databound collections (generic `SortableBindingList` and generic `EntitySet`). In both implementations the code performs as follows:  
  
-   Lets items be inserted and then removed from the collection.  
  
-   Does not track changes as long as the UI does not commit the edition.  
  
-   Does not track changes as long as the edition is canceled (<xref:System.ComponentModel.ICancelAddNew.CancelNew%2A>).  
  
-   Allows tracking when the edition is committed (<xref:System.ComponentModel.ICancelAddNew.EndNew%2A>).  
  
-   Lets the collection behave normally if the new item does not come from <xref:System.ComponentModel.IBindingList.AddNew%2A>.  
  
## Troubleshooting  
 This section calls out several items that might help troubleshoot your [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] data binding applications.  
  
-   You must use properties; using only fields is not sufficient. Windows Forms require this usage.  
  
-   By default, `image`, `varbinary`, and `timestamp` database types map to byte array. Because `ToString()` is not supported in this scenario, these objects cannot be displayed.  
  
-   A class member mapped to a primary key has a setter, but [!INCLUDE[vbtecdlinq](../../../../../../includes/vbtecdlinq-md.md)] does not support object identity change. Therefore, the primary/unique key that is used in mapping cannot be updated in the database. A change in the grid causes an exception when you call <xref:System.Data.Linq.DataContext.SubmitChanges%2A>.  
  
-   If an entity is bound in two separate grids (for example, one master and another detail), a `Delete` in the master grid is not propagated to the detail grid.  
  
## See Also  
 [Background Information](../../../../../../docs/framework/data/adonet/sql/linq/background-information.md)
