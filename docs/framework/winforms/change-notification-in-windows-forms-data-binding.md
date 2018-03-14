---
title: "Change Notification in Windows Forms Data Binding"
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
  - "Windows Forms, data binding"
  - "Windows Forms, adding change notification for data binding"
ms.assetid: b5b10f90-0585-41d9-a377-409835262a92
caps.latest.revision: 17
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Change Notification in Windows Forms Data Binding
One of the most important concepts of Windows Forms data binding is *change notification*. To ensure that your data source and bound controls always have the most recent data, you must add change notification for data binding. Specifically, you want to ensure that bound controls are notified of changes that were made to their data source, and the data source is notified of changes that were made to the bound properties of a control.  
  
 There are different kinds of change notification, depending on the kind of data binding:  
  
-   Simple binding, in which a single control property is bound to a single instance of an object.  
  
-   List-based binding, which can include a single control property bound to the property of an item in a list or a control property bound to a list of objects.  
  
 Additionally, if you are creating Windows Forms controls that you want to use for data binding, you must apply the *PropertyName*Changed pattern to the controls, so that changes to the bound property of a control are propagated to the data source.  
  
## Change Notification for Simple Binding  
 For simple binding, business objects must provide change notification when the value of a bound property changes. You can do this by exposing an *PropertyName*Changed event for each property of your business object and binding the business object to controls with the <xref:System.Windows.Forms.BindingSource> or the preferred method in which your business object implements the <xref:System.ComponentModel.INotifyPropertyChanged> interface and raises a <xref:System.ComponentModel.INotifyPropertyChanged.PropertyChanged> event when the value of a property changes. For more information, see [How to: Implement the INotifyPropertyChanged Interface](../../../docs/framework/winforms/how-to-implement-the-inotifypropertychanged-interface.md). When you use objects that implement the <xref:System.ComponentModel.INotifyPropertyChanged> interface, you do not have to use the <xref:System.Windows.Forms.BindingSource> to bind the object to a control, but using the <xref:System.Windows.Forms.BindingSource> is recommended.  
  
## Change Notification for List-Based Binding  
 Windows Forms depends on a bound list to provide property change (a list item property value changes) and list changed (an item is deleted or added to the list) information to bound controls. Therefore, lists used for data binding must implement the <xref:System.ComponentModel.IBindingList>, which provides both types of change notification. The <xref:System.ComponentModel.BindingList%601> is a generic implementation of <xref:System.ComponentModel.IBindingList> and is designed for use with Windows Forms data binding. You can create a <xref:System.ComponentModel.BindingList%601> that contains a business object type that implements <xref:System.ComponentModel.INotifyPropertyChanged> and the list will automatically convert the <xref:System.ComponentModel.INotifyPropertyChanged.PropertyChanged> events to <xref:System.ComponentModel.IBindingList.ListChanged> events. If the bound list is not an <xref:System.ComponentModel.IBindingList>, you must bind the list of objects to Windows Forms controls by using the <xref:System.Windows.Forms.BindingSource> component. The <xref:System.Windows.Forms.BindingSource> component will provide property-to-list conversion similar to that of the <xref:System.ComponentModel.BindingList%601>. For more information, see [How to: Raise Change Notifications Using a BindingSource and the INotifyPropertyChanged Interface](../../../docs/framework/winforms/controls/raise-change-notifications--bindingsource.md).  
  
## Change Notification for Custom Controls  
 Finally, from the control side you must expose a *PropertyName*Changed event for each property designed to be bound to data. The changes to the control property are then propagated to the bound data source. For more information, see [How to: Apply the PropertyNameChanged Pattern](../../../docs/framework/winforms/how-to-apply-the-propertynamechanged-pattern.md)  
  
## See Also  
 <xref:System.Windows.Forms.BindingSource>  
 <xref:System.ComponentModel.INotifyPropertyChanged>  
 <xref:System.ComponentModel.BindingList%601>  
 [Windows Forms Data Binding](../../../docs/framework/winforms/windows-forms-data-binding.md)  
 [Data Sources Supported by Windows Forms](../../../docs/framework/winforms/data-sources-supported-by-windows-forms.md)  
 [Data Binding and Windows Forms](../../../docs/framework/winforms/data-binding-and-windows-forms.md)
