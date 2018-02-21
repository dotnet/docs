---
title: "BindingSource Component Architecture"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-winforms"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "BindingSource component [Windows Forms], architecture"
  - "Windows Forms, data binding"
  - "BindingSource component [Windows Forms], about BindingSource component"
  - "data binding [Windows Forms], BindingSource component"
ms.assetid: 7bc69c90-8a11-48b1-9336-3adab5b41591
caps.latest.revision: 23
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# BindingSource Component Architecture
With the <xref:System.Windows.Forms.BindingSource> component, you can universally bind  all Windows Forms controls to data sources.  
  
 The <xref:System.Windows.Forms.BindingSource> component simplifies the process of binding controls to a data source and provides the following advantages over traditional data binding:  
  
-   Enables design-time binding to business objects.  
  
-   Encapsulates <xref:System.Windows.Forms.CurrencyManager> functionality and exposes <xref:System.Windows.Forms.CurrencyManager> events at design time.  
  
-   Simplifies creating a list that supports the <xref:System.ComponentModel.IBindingList> interface by providing list change notification for data sources that do not natively support list change notification.  
  
-   Provides an extensibility point for the <xref:System.ComponentModel.IBindingList.AddNew%2A?displayProperty=nameWithType> method.  
  
-   Provides a level of indirection between the data source and the control. This indirection is important when the data source may change at run time.  
  
-   Interoperates with other data-related Windows Forms controls, specifically the <xref:System.Windows.Forms.BindingNavigator> and the <xref:System.Windows.Forms.DataGridView> controls.  
  
 For these reasons, the <xref:System.Windows.Forms.BindingSource> component is the preferred way to bind your Windows Forms controls to data sources.  
  
## BindingSource Features  
 The <xref:System.Windows.Forms.BindingSource> component provides several features for binding controls to data. With these features, you can implement most data-binding scenarios with almost no coding on your part.  
  
 The <xref:System.Windows.Forms.BindingSource> component accomplishes this by providing a consistent interface for accessing many different kinds of data sources. This means that you use the same procedure for binding to any type. For example, you can attach the <xref:System.Windows.Forms.BindingSource.DataSource%2A> property to a <xref:System.Data.DataSet> or to a business object and in both cases you use the same set of properties, methods, and events to manipulate the data source.  
  
 The consistent interface provided by the <xref:System.Windows.Forms.BindingSource> component greatly simplifies the process of binding data to controls. For data-source types that provide change notification, the <xref:System.Windows.Forms.BindingSource> component automatically communicates changes between the control and the data source. For data-source types that do not provide change notification, events are provided that let you raise change notifications. The following list shows the features supported by the <xref:System.Windows.Forms.BindingSource> component:  
  
-   Indirection.  
  
-   Currency management.  
  
-   Data source as a list.  
  
-   <xref:System.Windows.Forms.BindingSource> as an <xref:System.ComponentModel.IBindingList>.  
  
-   Custom item creation.  
  
-   Transactional item creation.  
  
-   <xref:System.Collections.IEnumerable> support.  
  
-   Design-time support.  
  
-   Static <xref:System.Windows.Forms.ListBindingHelper> methods.  
  
-   Sorting and filtering with the <xref:System.ComponentModel.IBindingListView> interface.  
  
-   Integration with <xref:System.Windows.Forms.BindingNavigator>.  
  
### Indirection  
 The <xref:System.Windows.Forms.BindingSource> component provides a level of indirection between a control and a data source. Instead of binding a control directly to a data source, you bind the control to a <xref:System.Windows.Forms.BindingSource>, and you attach the data source to the <xref:System.Windows.Forms.BindingSource> component's <xref:System.Windows.Forms.BindingSource.DataSource%2A> property.  
  
 With this level of indirection, you can change the data source without resetting the control binding. This gives you the following capabilities:  
  
-   You can attach the <xref:System.Windows.Forms.BindingSource> to different data sources while retaining the current control bindings.  
  
-   You can change items in the data source and notify bound controls. For more information, see [How to: Reflect Data Source Updates in a Windows Forms Control with the BindingSource](../../../../docs/framework/winforms/controls/reflect-data-source-updates-in-a-wf-control-with-the-bindingsource.md).  
  
-   You can bind to a <xref:System.Type> instead of an object in memory. For more information, see [How to: Bind a Windows Forms Control to a Type](../../../../docs/framework/winforms/controls/how-to-bind-a-windows-forms-control-to-a-type.md). You can then bind to an object at run time.  
  
### Currency Management  
 The <xref:System.Windows.Forms.BindingSource> component implements the <xref:System.Windows.Forms.ICurrencyManagerProvider> interface to handle currency management for you. With the <xref:System.Windows.Forms.ICurrencyManagerProvider> interface, you can also access to the currency manager for a <xref:System.Windows.Forms.BindingSource>, in addition to the currency manager for another <xref:System.Windows.Forms.BindingSource> bound to the same <xref:System.Windows.Forms.BindingSource.DataMember%2A>.  
  
 The <xref:System.Windows.Forms.BindingSource> component encapsulates <xref:System.Windows.Forms.CurrencyManager> functionality and exposes the most common <xref:System.Windows.Forms.CurrencyManager> properties and events. The following table describes some of the members related to currency management.  
  
 <xref:System.Windows.Forms.ICurrencyManagerProvider.CurrencyManager%2A> property  
 Gets the currency manager associated with the <xref:System.Windows.Forms.BindingSource>.  
  
 <xref:System.Windows.Forms.ICurrencyManagerProvider.GetRelatedCurrencyManager%2A> method  
 If there is another <xref:System.Windows.Forms.BindingSource> bound to the specified data member, gets its currency manager.  
  
 <xref:System.Windows.Forms.BindingSource.Current%2A> property  
 Gets the current item of the data source.  
  
 <xref:System.Windows.Forms.BindingSource.Position%2A> property  
 Gets or sets the current position in the underlying list.  
  
 <xref:System.Windows.Forms.BindingSource.EndEdit%2A> method  
 Applies pending changes to the underlying data source.  
  
 <xref:System.Windows.Forms.BindingSource.CancelEdit%2A> method  
 Cancels the current edit operation.  
  
### Data Source as a List  
 The <xref:System.Windows.Forms.BindingSource> component implements the <xref:System.ComponentModel.IBindingListView> and <xref:System.ComponentModel.ITypedList> interfaces. With this implementation, you can use the <xref:System.Windows.Forms.BindingSource> component itself as a data source, without any external storage.  
  
 When the <xref:System.Windows.Forms.BindingSource> component is attached to a data source, it exposes the data source as a list.  
  
 The <xref:System.Windows.Forms.BindingSource.DataSource%2A> property can be set to several data sources. These include types, objects, and lists of types. The resulting data source will be exposed as a list. The following table shows some of the common data sources and the resulting list evaluation.  
  
|DataSource property|List results|  
|-------------------------|------------------|  
|A null reference (`Nothing` in Visual Basic)|An empty <xref:System.ComponentModel.IBindingList> of objects. Adding an item sets the list to the type of the added item.|  
|A null reference (`Nothing` in Visual Basic) with <xref:System.Windows.Forms.BindingSource.DataMember%2A> set|Not supported; raises <xref:System.ArgumentException>.|  
|Non-list type or object of type "T"|An empty <xref:System.ComponentModel.IBindingList> of type "T".|  
|Array instance|An <xref:System.ComponentModel.IBindingList> containing the array elements.|  
|<xref:System.Collections.IEnumerable> instance|An <xref:System.ComponentModel.IBindingList> containing the <xref:System.Collections.IEnumerable> items|  
|List instance containing type "T"|An <xref:System.ComponentModel.IBindingList> instance containing type "T".|  
  
 Additionally, <xref:System.Windows.Forms.BindingSource.DataSource%2A> can be set to other list types, such as <xref:System.ComponentModel.IListSource> and <xref:System.ComponentModel.ITypedList>, and the <xref:System.Windows.Forms.BindingSource> will handle them appropriately. In this case, the type that is contained in the list should have a default constructor.  
  
### BindingSource as an IBindingList  
 The <xref:System.Windows.Forms.BindingSource> component provides members for accessing and manipulating the underlying data as an <xref:System.ComponentModel.IBindingList>. The following table describes some of these members.  
  
|Member|Description|  
|------------|-----------------|  
|<xref:System.Windows.Forms.BindingSource.List%2A> property|Gets the list that results from the evaluation of the <xref:System.Windows.Forms.BindingSource.DataSource%2A> or <xref:System.Windows.Forms.BindingSource.DataMember%2A> properties.|  
|<xref:System.Windows.Forms.BindingSource.AddNew%2A> method|Adds a new item to the underlying list. Applies to data sources that implement the <xref:System.ComponentModel.IBindingList> interface and allow adding items (that is, the <xref:System.Windows.Forms.BindingSource.AllowNew%2A> property is set to `true`).|  
  
### Custom Item Creation  
 You can handle the <xref:System.Windows.Forms.BindingSource.AddingNew> event to provide your own item-creation logic. The <xref:System.Windows.Forms.BindingSource.AddingNew> event occurs before a new object is added to the <xref:System.Windows.Forms.BindingSource>. This event is raised after the <xref:System.Windows.Forms.BindingSource.AddNew%2A> method is called, but before the new item is added to the underlying list. By handling this event, you can provide custom item creation behavior without deriving from the <xref:System.Windows.Forms.BindingSource> class. For more information, see [How to: Customize Item Addition with the Windows Forms BindingSource](../../../../docs/framework/winforms/controls/how-to-customize-item-addition-with-the-windows-forms-bindingsource.md).  
  
### Transactional Item Creation  
 The <xref:System.Windows.Forms.BindingSource> component implements the <xref:System.ComponentModel.ICancelAddNew> interface, which enables transactional item creation. After a new item is provisionally created by using a call to <xref:System.Windows.Forms.BindingSource.AddNew%2A>, the addition may be committed or rolled back in the following ways:  
  
-   The <xref:System.ComponentModel.ICancelAddNew.EndNew%2A> method will explicitly commit the pending addition.  
  
-   Performing another collection operation, such as an insertion, removal, or move, will implicitly commit the pending addition.  
  
-   The <xref:System.ComponentModel.ICancelAddNew.CancelNew%2A> method will roll back the pending addition if the method has not already been committed.  
  
### IEnumerable Support  
 The <xref:System.Windows.Forms.BindingSource> component enables binding controls to <xref:System.Collections.IEnumerable> data sources. With this component, you can bind to a data source such as a <xref:System.Data.SqlClient.SqlDataReader?displayProperty=nameWithType>.  
  
 When an <xref:System.Collections.IEnumerable> data source is assigned to the <xref:System.Windows.Forms.BindingSource> component, the <xref:System.Windows.Forms.BindingSource> creates an <xref:System.ComponentModel.IBindingList> and adds the contents of the <xref:System.Collections.IEnumerable> data source to the list.  
  
### Design-Time Support  
 Some object types cannot be created at design time, such as objects created from a factory class, or objects returned by a Web service. You may sometimes have to bind your controls to these types at design time, even though there is no object in memory to which your controls can bind. You may, for example, need to label the column headers of a <xref:System.Windows.Forms.DataGridView> control with the names of your custom type's public properties.  
  
 To support this scenario, the <xref:System.Windows.Forms.BindingSource> component supports binding to a <xref:System.Type>. When you assign a <xref:System.Type> to the <xref:System.Windows.Forms.BindingSource.DataSource%2A> property, the <xref:System.Windows.Forms.BindingSource> component creates an empty <xref:System.ComponentModel.BindingList%601> of <xref:System.Type> items. Any controls you subsequently bind to the <xref:System.Windows.Forms.BindingSource> component will be alerted to the presence of the properties or schema of your type at design time, or at run time. For more information, see [How to: Bind a Windows Forms Control to a Type](../../../../docs/framework/winforms/controls/how-to-bind-a-windows-forms-control-to-a-type.md).  
  
### Static ListBindingHelper Methods  
 The <xref:System.Windows.Forms.BindingContext?displayProperty=nameWithType>, <xref:System.Windows.Forms.CurrencyManager?displayProperty=nameWithType>, and <xref:System.Windows.Forms.BindingSource> types all share common logic to generate a list from a `DataSource`/`DataMember` pair. Additionally, this common logic is publicly exposed for use by control authors and other third parties in the following `static` methods:  
  
-   <xref:System.Windows.Forms.ListBindingHelper.GetListItemProperties%2A>  
  
-   <xref:System.Windows.Forms.ListBindingHelper.GetList%2A>.  
  
-   <xref:System.Windows.Forms.ListBindingHelper.GetListName%2A>  
  
-   <xref:System.Windows.Forms.ListBindingHelper.GetListItemType%2A>  
  
### Sorting and Filtering with the IBindingListView Interface  
 The <xref:System.Windows.Forms.BindingSource> component implements the <xref:System.ComponentModel.IBindingListView> interface, which extends the <xref:System.ComponentModel.IBindingList> interface. The <xref:System.ComponentModel.IBindingList> offers single column sorting and the <xref:System.ComponentModel.IBindingListView> offers advanced sorting and filtering. With <xref:System.ComponentModel.IBindingListView>, you can sort and filter items in the data source, if the data source also implements one of these interfaces. The <xref:System.Windows.Forms.BindingSource> component does not provide a reference implementation of these members. Instead, calls are forwarded to the underlying list.  
  
 The following table describes the properties you use for sorting and filtering.  
  
|Member|Description|  
|------------|-----------------|  
|<xref:System.Windows.Forms.BindingSource.Filter%2A> property|If the data source is an <xref:System.ComponentModel.IBindingListView>, gets or sets the expression used to filter which rows are viewed.|  
|<xref:System.Windows.Forms.BindingSource.Sort%2A> property|If the data source is an <xref:System.ComponentModel.IBindingList>, gets or sets a column name used for sorting and sort order information.<br /><br /> -or-<br /><br /> If the data source is an <xref:System.ComponentModel.IBindingListView> and supports advanced sorting, gets multiple column names used for sorting and sort order|  
  
### Integration with BindingNavigator  
 You can use the <xref:System.Windows.Forms.BindingSource> component to bind any Windows Forms control to a data source, but the <xref:System.Windows.Forms.BindingNavigator> control is designed specifically to work with the <xref:System.Windows.Forms.BindingSource> component. The <xref:System.Windows.Forms.BindingNavigator> control provides a user interface for controlling the <xref:System.Windows.Forms.BindingSource> component's current item. By default, the <xref:System.Windows.Forms.BindingNavigator> control provides buttons that correspond to the navigation methods on the <xref:System.Windows.Forms.BindingSource> component. For more information, see [How to: Navigate Data with the Windows Forms BindingNavigator Control](../../../../docs/framework/winforms/controls/how-to-navigate-data-with-the-windows-forms-bindingnavigator-control.md).  
  
## See Also  
 <xref:System.Windows.Forms.BindingSource>  
 <xref:System.Windows.Forms.BindingNavigator>  
 [BindingSource Component Overview](../../../../docs/framework/winforms/controls/bindingsource-component-overview.md)  
 [BindingNavigator Control](../../../../docs/framework/winforms/controls/bindingnavigator-control-windows-forms.md)  
 [Windows Forms Data Binding](../../../../docs/framework/winforms/windows-forms-data-binding.md)  
 [Controls to Use on Windows Forms](../../../../docs/framework/winforms/controls/controls-to-use-on-windows-forms.md)  
 [How to: Bind a Windows Forms Control to a Type](../../../../docs/framework/winforms/controls/how-to-bind-a-windows-forms-control-to-a-type.md)  
 [How to: Reflect Data Source Updates in a Windows Forms Control with the BindingSource](../../../../docs/framework/winforms/controls/reflect-data-source-updates-in-a-wf-control-with-the-bindingsource.md)
