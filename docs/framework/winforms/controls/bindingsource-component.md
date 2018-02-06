---
title: "BindingSource Component"
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
  - "data binding [Windows Forms], Windows Forms"
  - "Windows Forms, data binding control"
  - "BindingSource component [Windows Forms]"
ms.assetid: 3e2faf4c-f5b8-4fa6-9fbc-f59c37ec2fb9
caps.latest.revision: 20
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# BindingSource Component
Encapsulates a data source for binding to controls.  
  
 The <xref:System.Windows.Forms.BindingSource> component serves two purposes. First, it provides a layer of indirection when binding the controls on a form to data. This is accomplished by binding the <xref:System.Windows.Forms.BindingSource> component to your data source, and then binding the controls on your form to the <xref:System.Windows.Forms.BindingSource> component. All further interaction with the data, including navigating, sorting, filtering, and updating, is accomplished with calls to the <xref:System.Windows.Forms.BindingSource> component.  
  
 Second, the <xref:System.Windows.Forms.BindingSource> component can act as a strongly typed data source. Adding a type to the <xref:System.Windows.Forms.BindingSource> component with the <xref:System.Windows.Forms.BindingSource.Add%2A> method creates a list of that type.  
  
## In This Section  
 [BindingSource Component Overview](../../../../docs/framework/winforms/controls/bindingsource-component-overview.md)  
 Introduces the general concepts of the <xref:System.Windows.Forms.BindingSource> component, which allows you to bind a data source to a control.  
  
 [How to: Bind Windows Forms Controls to DBNull Database Values](../../../../docs/framework/winforms/controls/how-to-bind-windows-forms-controls-to-dbnull-database-values.md)  
 Shows how to handle a <xref:System.DBNull> value from the data source using the <xref:System.Windows.Forms.BindingSource> component.  
  
 [How to: Sort and Filter ADO.NET Data with the Windows Forms BindingSource Component](../../../../docs/framework/winforms/controls/sort-and-filter-ado-net-data-with-wf-bindingsource-component.md)  
 Demonstrates using the <xref:System.Windows.Forms.BindingSource> component to apply sorts and filters to displayed data.  
  
 [How to: Bind to a Web Service Using the Windows Forms BindingSource](../../../../docs/framework/winforms/controls/how-to-bind-to-a-web-service-using-the-windows-forms-bindingsource.md)  
 Shows how to use the <xref:System.Windows.Forms.BindingSource> component to bind to a Web service.  
  
 [How to: Handle Errors and Exceptions that Occur with Databinding](../../../../docs/framework/winforms/controls/how-to-handle-errors-and-exceptions-that-occur-with-databinding.md)  
 Demonstrates using the <xref:System.Windows.Forms.BindingSource> component to gracefully handle errors that occur in a data binding operation.  
  
 [How to: Bind a Windows Forms Control to a Type](../../../../docs/framework/winforms/controls/how-to-bind-a-windows-forms-control-to-a-type.md)  
 Demonstrates using a <xref:System.Windows.Forms.BindingSource> component to bind to a type.  
  
 [How to: Bind a Windows Forms Control to a Factory Object](../../../../docs/framework/winforms/controls/how-to-bind-a-windows-forms-control-to-a-factory-object.md)  
 Demonstrates using a <xref:System.Windows.Forms.BindingSource> component to bind to a factory object or method.  
  
 [How to: Customize Item Addition with the Windows Forms BindingSource](../../../../docs/framework/winforms/controls/how-to-customize-item-addition-with-the-windows-forms-bindingsource.md)  
 Demonstrates using a <xref:System.Windows.Forms.BindingSource> component to create new items and add them to a data source.  
  
 [How to: Raise Change Notifications Using the BindingSource ResetItem Method](../../../../docs/framework/winforms/controls/how-to-raise-change-notifications-using-the-bindingsource-resetitem-method.md)  
 Demonstrates using a <xref:System.Windows.Forms.BindingSource> component to raise change-notification events for data sources that do not support change notification.  
  
 [How to: Raise Change Notifications Using a BindingSource and the INotifyPropertyChanged Interface](../../../../docs/framework/winforms/controls/raise-change-notifications--bindingsource.md)  
 Demonstrates how to use a type that inherits from the <xref:System.ComponentModel.INotifyPropertyChanged> with a <xref:System.Windows.Forms.BindingSource> control.  
  
 [How to: Reflect Data Source Updates in a Windows Forms Control with the BindingSource](../../../../docs/framework/winforms/controls/reflect-data-source-updates-in-a-wf-control-with-the-bindingsource.md)  
 Demonstrates how to respond to changes in the data source using the <xref:System.Windows.Forms.BindingSource> component.  
  
 [How to: Share Bound Data Across Forms Using the BindingSource Component](../../../../docs/framework/winforms/controls/how-to-share-bound-data-across-forms-using-the-bindingsource-component.md)  
 Shows how to use the <xref:System.Windows.Forms.BindingSource> to bind multiple forms to the same data source.  
  
## Reference  
 <xref:System.Windows.Forms.BindingSource>  
 Provides reference documentation for the <xref:System.Windows.Forms.BindingSource> component.  
  
 <xref:System.Windows.Forms.BindingNavigator>  
 Provides reference documentation for the <xref:System.Windows.Forms.BindingNavigator> control.  
  
## Related Sections  
 [Windows Forms Data Binding](../../../../docs/framework/winforms/windows-forms-data-binding.md)  
 Contains links to topics describing the Windows Forms data binding architecture.  
  
 Also see [Bind controls to data in Visual Studio](/visualstudio/data-tools/bind-controls-to-data-in-visual-studio).
