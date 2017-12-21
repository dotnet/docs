---
title: "Interfaces Related to Data Binding"
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
  - "data [Windows Forms], data-binding interfaces"
  - "INotifyPropertyChanged interface"
  - "IBindingListView interface"
  - "IList interface [Windows Forms], Windows Forms data binding"
  - "IBindingList interface [Windows Forms], Windows Forms data binding"
  - "interfaces [Windows Forms], Windows Forms data binding"
  - "IEditableObject interface [Windows Forms], Windows Forms data binding"
  - "data binding [Windows Forms], interfaces"
  - "IDataErrorInfo interface [Windows Forms], Windows Forms data binding"
ms.assetid: 14e49a2e-3e46-47ca-b491-70d546333277
caps.latest.revision: 23
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Interfaces Related to Data Binding
With [!INCLUDE[vstecado](../../../includes/vstecado-md.md)], you can create many different data structures to suit the binding needs of your application and the data you are working with. You may want to create your own classes that provide or consume data in Windows Forms. These objects can offer varying levels of functionality and complexity, from basic data binding, to providing design-time support, error checking, change notification, or even support for a structured rollback of the changes made to the data itself.  
  
## Consumers of Data-Binding Interfaces  
 Following sections describe two groups of interface objects. The first group lists interfaces that are implemented on data sources by data source authors. These interfaces are designed to be consumed by data source consumers, which are in most cases Windows Forms controls or components. The second group lists interfaces designed for use by component authors. Component authors use these interfaces when they are creating a component that supports data binding to be consumed by the Windows Forms data-binding engine. You can implement these interfaces within classes associated with your form to enable data binding; each case presents a class that implements an interface that enables interaction with data. [!INCLUDE[vsprvs](../../../includes/vsprvs-md.md)] rapid application development (RAD) data design experience tools already take advantage of this functionality.  
  
### Interfaces for Implementation by Data Source Authors  
 The following interfaces are designed to be consumed by Windows Forms controls:  
  
-   <xref:System.Collections.IList> interface  
  
     A class that implements the <xref:System.Collections.IList> interface could be an <xref:System.Array>, <xref:System.Collections.ArrayList>, or <xref:System.Collections.CollectionBase>. These are indexed lists of items of type <xref:System.Object>. These lists must contain homogenous types, because the first item of the index determines the type. <xref:System.Collections.IList> would be available for binding only at run time.  
  
    > [!NOTE]
    >  If you want to create a list of business objects for binding with Windows Forms, you should consider using the <xref:System.ComponentModel.BindingList%601>. The <xref:System.ComponentModel.BindingList%601> is an extensible class that implements the primary interfaces required for two-way Windows Forms data binding.  
  
-   <xref:System.ComponentModel.IBindingList> interface  
  
     A class that implements the <xref:System.ComponentModel.IBindingList> interface provides a much higher level of data-binding functionality. This implementation offers you basic sorting capabilities and change notification, both for when the list items change (for example, the third item in a list of customers has a change to the Address field), as well as when the list itself changes (for example, the number of items in the list increases or decreases). Change notification is important if you plan to have multiple controls bound to the same data, and you want data changes made in one of the controls to propagate to the other bound controls.  
  
    > [!NOTE]
    >  Change notification is enabled for the <xref:System.ComponentModel.IBindingList> interface through the <xref:System.ComponentModel.IBindingList.SupportsChangeNotification%2A> property which, when `true`, raises a <xref:System.ComponentModel.IBindingList.ListChanged> event, indicating the list changed or an item in the list changed.  
  
     The type of change is described by the <xref:System.ComponentModel.ListChangedType> property of the <xref:System.ComponentModel.ListChangedEventArgs> parameter. Hence, whenever the data model is updated, any dependent views, such as other controls bound to the same data source, will also be updated. However, objects contained within the list will have to notify the list when they change so that the list can raise the <xref:System.ComponentModel.IBindingList.ListChanged> event.  
  
    > [!NOTE]
    >  The <xref:System.ComponentModel.BindingList%601> provides a generic implementation of the <xref:System.ComponentModel.IBindingList> interface.  
  
-   <xref:System.ComponentModel.IBindingListView> interface  
  
     A class that implements the <xref:System.ComponentModel.IBindingListView> interface provides all the functionality of an implementation of <xref:System.ComponentModel.IBindingList>, as well as filtering and advanced sorting functionality. This implementation offers string-based filtering, and multicolumn sorting with property descriptor-direction pairs.  
  
-   <xref:System.ComponentModel.IEditableObject> interface  
  
     A class that implements the <xref:System.ComponentModel.IEditableObject> interface allows an object to control when changes to that object are made permanent. This implementation affords you the <xref:System.ComponentModel.IEditableObject.BeginEdit%2A>, <xref:System.ComponentModel.IEditableObject.EndEdit%2A>, and <xref:System.ComponentModel.IEditableObject.CancelEdit%2A> methods, which enable you to roll back changes made to the object. Following is a brief explanation of the functioning of the <xref:System.ComponentModel.IEditableObject.BeginEdit%2A>, <xref:System.ComponentModel.IEditableObject.EndEdit%2A>, and <xref:System.ComponentModel.IEditableObject.CancelEdit%2A> methods and how they work in conjunction with one another to enable a possible rollback of changes made to the data:  
  
    -   The <xref:System.ComponentModel.IEditableObject.BeginEdit%2A> method signals the start of an edit on an object. An object that implements this interface will need to store any updates after the <xref:System.ComponentModel.IEditableObject.BeginEdit%2A> method call in such a way that the updates can be discarded if the <xref:System.ComponentModel.IEditableObject.CancelEdit%2A> method is called. In data binding Windows Forms, you can call <xref:System.ComponentModel.IEditableObject.BeginEdit%2A> multiple times within the scope of a single edit transaction (for example, <xref:System.ComponentModel.IEditableObject.BeginEdit%2A>, <xref:System.ComponentModel.IEditableObject.BeginEdit%2A>, <xref:System.ComponentModel.IEditableObject.EndEdit%2A>). Implementations of <xref:System.ComponentModel.IEditableObject> should keep track of whether <xref:System.ComponentModel.IEditableObject.BeginEdit%2A> has already been called and ignore subsequent calls to <xref:System.ComponentModel.IEditableObject.BeginEdit%2A>. Because this method can be called multiple times, it is important that subsequent calls to it are nondestructive; that is, subsequent <xref:System.ComponentModel.IEditableObject.BeginEdit%2A> calls cannot destroy the updates that have been made or change the data that was saved on the first <xref:System.ComponentModel.IEditableObject.BeginEdit%2A> call.  
  
    -   The <xref:System.ComponentModel.IEditableObject.EndEdit%2A> method pushes any changes since <xref:System.ComponentModel.IEditableObject.BeginEdit%2A> was called into the underlying object, if the object is currently in edit mode.  
  
    -   The <xref:System.ComponentModel.IEditableObject.CancelEdit%2A> method discards any changes made to the object.  
  
     For more information about how the <xref:System.ComponentModel.IEditableObject.BeginEdit%2A>, <xref:System.ComponentModel.IEditableObject.EndEdit%2A>, and <xref:System.ComponentModel.IEditableObject.CancelEdit%2A> methods work, see [Save data back to the database](/visualstudio/data-tools/save-data-back-to-the-database).  
  
     This transactional notion of data functionality is used by the <xref:System.Windows.Forms.DataGridView> control.  
  
-   <xref:System.ComponentModel.ICancelAddNew> interface  
  
     A class that implements the <xref:System.ComponentModel.ICancelAddNew> interface usually implements the <xref:System.ComponentModel.IBindingList> interface and allows you to roll back an addition made to the data source with the <xref:System.ComponentModel.IBindingList.AddNew%2A> method. If your data source implements the <xref:System.ComponentModel.IBindingList> interface, you should also have it implement the <xref:System.ComponentModel.ICancelAddNew> interface.  
  
-   <xref:System.ComponentModel.IDataErrorInfo> interface  
  
     A class that implements the <xref:System.ComponentModel.IDataErrorInfo> interface allows objects to offer custom error information to bound controls:  
  
    -   The <xref:System.ComponentModel.IDataErrorInfo.Error%2A> property returns general error message text (for example, "An error has occurred").  
  
    -   The <xref:System.ComponentModel.IDataErrorInfo.Item%2A> property returns a string with the specific error message from the column (for example, "The value in the `State` column is invalid").  
  
-   <xref:System.Collections.IEnumerable> interface  
  
     A class that implements the <xref:System.Collections.IEnumerable> interface is typically consumed by [!INCLUDE[vstecasp](../../../includes/vstecasp-md.md)]. Windows Forms support for this interface is only available through the <xref:System.Windows.Forms.BindingSource> component.  
  
    > [!NOTE]
    >  The <xref:System.Windows.Forms.BindingSource> component copies all <xref:System.Collections.IEnumerable> items into a separate list for binding purposes.  
  
-   <xref:System.ComponentModel.ITypedList> interface  
  
     A collections class that implements the <xref:System.ComponentModel.ITypedList> interface provides the ability to control the order and the set of properties exposed to the bound control.  
  
    > [!NOTE]
    >  When you implement the <xref:System.ComponentModel.ITypedList.GetItemProperties%2A> method, and the <xref:System.ComponentModel.PropertyDescriptor> array is not null, the last entry in the array will be the property descriptor that describes the list property that is another list of items.  
  
-   <xref:System.ComponentModel.ICustomTypeDescriptor> interface  
  
     A class that implements the <xref:System.ComponentModel.ICustomTypeDescriptor> interface provides dynamic information about itself. This interface is similar to <xref:System.ComponentModel.ITypedList> but is used for objects rather than lists. This interface is used by <xref:System.Data.DataRowView> to project the schema of the underlying rows. A simple implementation of <xref:System.ComponentModel.ICustomTypeDescriptor> is provided by the <xref:System.ComponentModel.CustomTypeDescriptor> class.  
  
    > [!NOTE]
    >  To support design-time binding to types that implement <xref:System.ComponentModel.ICustomTypeDescriptor>, the type must also implement <xref:System.ComponentModel.IComponent> and exist as an instance on the Form.  
  
-   <xref:System.ComponentModel.IListSource> interface  
  
     A class that implements the <xref:System.ComponentModel.IListSource> interface enables list-based binding on non-list objects. The <xref:System.ComponentModel.IListSource.GetList%2A> method of <xref:System.ComponentModel.IListSource> is used to return a bindable list from an object that does not inherit from <xref:System.Collections.IList>. <xref:System.ComponentModel.IListSource> is used by the <xref:System.Data.DataSet> class.  
  
-   <xref:System.ComponentModel.IRaiseItemChangedEvents> interface  
  
     A class that implements the <xref:System.ComponentModel.IRaiseItemChangedEvents> interface is a bindable list that also implements the <xref:System.ComponentModel.IBindingList> interface. This interface is used to indicate if your type raises <xref:System.ComponentModel.IBindingList.ListChanged> events of type <xref:System.ComponentModel.ListChangedType.ItemChanged> through its <xref:System.ComponentModel.IRaiseItemChangedEvents.RaisesItemChangedEvents%2A> property.  
  
    > [!NOTE]
    >  You should implement the <xref:System.ComponentModel.IRaiseItemChangedEvents> if your data source provides the property to list event conversion described previously and is interacting with the <xref:System.Windows.Forms.BindingSource> component. Otherwise, the <xref:System.Windows.Forms.BindingSource> will also perform property to list event conversion resulting in slower performance.  
  
-   <xref:System.ComponentModel.ISupportInitialize> interface  
  
     A component that implements the <xref:System.ComponentModel.ISupportInitialize> interface takes advantages of batch optimizations for setting properties and initializing co-dependent properties. The <xref:System.ComponentModel.ISupportInitialize> contains two methods:  
  
    -   <xref:System.ComponentModel.ISupportInitialize.BeginInit%2A> signals that object initialization is starting.  
  
    -   <xref:System.ComponentModel.ISupportInitialize.EndInit%2A> signals that object initialization is finishing.  
  
-   <xref:System.ComponentModel.ISupportInitializeNotification> interface  
  
     A component that implements the <xref:System.ComponentModel.ISupportInitializeNotification> interface also implements the <xref:System.ComponentModel.ISupportInitialize> interface. This interface allows you to notify other <xref:System.ComponentModel.ISupportInitialize> components that initialization is complete. The <xref:System.ComponentModel.ISupportInitializeNotification> interface contains two members:  
  
    -   <xref:System.ComponentModel.ISupportInitializeNotification.IsInitialized%2A> returns a `boolean` value indicating whether the component is initialized.  
  
    -   <xref:System.ComponentModel.ISupportInitializeNotification.Initialized> occurs when <xref:System.ComponentModel.ISupportInitialize.EndInit%2A> is called.  
  
-   <xref:System.ComponentModel.INotifyPropertyChanged> interface  
  
     A class that implements this interface is a type that raises an event when any of its property values change. This interface is designed to replace the pattern of having a change event for each property of a control. When used in a <xref:System.ComponentModel.BindingList%601>, a business object should implement the <xref:System.ComponentModel.INotifyPropertyChanged> interface and the BindingList\`1 will convert <xref:System.ComponentModel.INotifyPropertyChanged.PropertyChanged> events to <xref:System.ComponentModel.BindingList%601.ListChanged> events of type <xref:System.ComponentModel.ListChangedType.ItemChanged>.  
  
    > [!NOTE]
    >  For change notification to occur in a binding between a bound client and a data source your bound data-source type should either implement the <xref:System.ComponentModel.INotifyPropertyChanged> interface (preferred) or you can provide *propertyName*`Changed` events for the bound type, but you shouldn't do both.  
  
### Interfaces for Implementation by Component Authors  
 The following interfaces are designed for consumption by the Windows Forms data-binding engine:  
  
-   <xref:System.Windows.Forms.IBindableComponent> interface  
  
     A class that implements this interface is a non-control component that supports data binding. This class returns the data bindings and binding context of the component through the <xref:System.Windows.Forms.IBindableComponent.DataBindings%2A> and <xref:System.Windows.Forms.IBindableComponent.BindingContext%2A> properties of this interface.  
  
    > [!NOTE]
    >  If your component inherits from <xref:System.Windows.Forms.Control>, you do not need to implement the <xref:System.Windows.Forms.IBindableComponent> interface.  
  
-   <xref:System.Windows.Forms.ICurrencyManagerProvider> interface  
  
     A class that implements the <xref:System.Windows.Forms.ICurrencyManagerProvider> interface is a component that provides its own <xref:System.Windows.Forms.CurrencyManager> to manage the bindings associated with this particular component. Access to the custom <xref:System.Windows.Forms.CurrencyManager> is provided by the <xref:System.Windows.Forms.ICurrencyManagerProvider.CurrencyManager%2A> property.  
  
    > [!NOTE]
    >  A class that inherits from <xref:System.Windows.Forms.Control> manages bindings automatically through its <xref:System.Windows.Forms.Control.BindingContext%2A> property, so cases in which you need to implement the <xref:System.Windows.Forms.ICurrencyManagerProvider> are fairly rare.  
  
## See Also  
 [Data Binding and Windows Forms](../../../docs/framework/winforms/data-binding-and-windows-forms.md)  
 [How to: Create a Simple-Bound Control on a Windows Form](../../../docs/framework/winforms/how-to-create-a-simple-bound-control-on-a-windows-form.md)  
 [Windows Forms Data Binding](../../../docs/framework/winforms/windows-forms-data-binding.md)
