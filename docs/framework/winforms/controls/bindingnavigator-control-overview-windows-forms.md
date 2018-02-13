---
title: "BindingNavigator Control Overview (Windows Forms)"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-winforms"
ms.tgt_pltfrm: ""
ms.topic: "article"
f1_keywords: 
  - "DataNavigator"
helpviewer_keywords: 
  - "BindingNavigator control [Windows Forms], about BindingNavigator control"
  - "records [Windows Forms], navigating on a form"
  - "data [Windows Forms], navigating"
  - "data navigation"
ms.assetid: 4423eede-f8d1-4d02-822f-5bf8432680d0
caps.latest.revision: 26
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# BindingNavigator Control Overview (Windows Forms)
You can use the <xref:System.Windows.Forms.BindingNavigator> control to create a standardized means for users to search and change data on a Windows Form. You frequently use <xref:System.Windows.Forms.BindingNavigator> with the <xref:System.Windows.Forms.BindingSource> component to enable users to move through data records on a form and interact with the records.  
  
## How the BindingNavigator Works  
 The <xref:System.Windows.Forms.BindingNavigator> control is composed of a <xref:System.Windows.Forms.ToolStrip> with a series of <xref:System.Windows.Forms.ToolStripItem> objects for most of the common data-related actions: adding data, deleting data, and navigating through data. By default, the <xref:System.Windows.Forms.BindingNavigator> control contains these standard buttons. The following screen shot shows the <xref:System.Windows.Forms.BindingNavigator> control on a form.  
  
 ![BindingNavigator Control](../../../../docs/framework/winforms/controls/media/cpdatacontainerctrl.gif "cpDataContainerCtrl")  
  
 The following table lists the controls and describes their functions.  
  
|Control|Function|  
|-------------|--------------|  
|<xref:System.Windows.Forms.BindingNavigator.AddNewItem%2A> button|Inserts a new row into the underlying data source.|  
|<xref:System.Windows.Forms.BindingNavigator.DeleteItem%2A> button|Deletes the current row from the underlying data source.|  
|<xref:System.Windows.Forms.BindingNavigator.MoveFirstItem%2A> button|Moves to the first item in the underlying data source.|  
|<xref:System.Windows.Forms.BindingNavigator.MoveLastItem%2A> button|Moves to the last item in the underlying data source.|  
|<xref:System.Windows.Forms.BindingNavigator.MoveNextItem%2A> button|Moves to the next item in the underlying data source.|  
|<xref:System.Windows.Forms.BindingNavigator.MovePreviousItem%2A> button|Moves to the previous item in the underlying data source.|  
|<xref:System.Windows.Forms.BindingNavigator.PositionItem%2A> text box|Returns the current position within the underlying data source.|  
|<xref:System.Windows.Forms.BindingNavigator.CountItem%2A> text box|Returns the total number of items in the underlying data source.|  
  
 For each control in this collection, there is a corresponding member of the <xref:System.Windows.Forms.BindingSource> component that programmatically provides the same functionality. For example, the <xref:System.Windows.Forms.BindingNavigator.MoveFirstItem%2A> button corresponds to the <xref:System.Windows.Forms.BindingSource.MoveFirst%2A> method of the <xref:System.Windows.Forms.BindingSource> component, the <xref:System.Windows.Forms.BindingNavigator.DeleteItem%2A> button corresponds to the <xref:System.Windows.Forms.BindingSource.RemoveCurrent%2A> method, and so on.  
  
 If the default buttons are not suited to your application, or if you require additional buttons to support other types of functionality, you can supply your own <xref:System.Windows.Forms.ToolStrip> buttons. Also see [How to: Add Load, Save, and Cancel Buttons to the Windows Forms BindingNavigator Control](../../../../docs/framework/winforms/controls/load-save-and-cancel-bindingnavigator.md).  
  
## See Also  
 <xref:System.Windows.Forms.BindingNavigator>  
 <xref:System.Windows.Forms.BindingSource>  
 [BindingNavigator Control](../../../../docs/framework/winforms/controls/bindingnavigator-control-windows-forms.md)
