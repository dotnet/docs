---
title: "How to: Ensure Multiple Controls Bound to the Same Data Source Remain Synchronized"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-winforms"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "controls [Windows Forms], binding multiple"
  - "controls [Windows Forms], synchronizing with data source"
ms.assetid: c2f0ecc6-11e6-4c2c-a1ca-0759630c451e
caps.latest.revision: 8
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Ensure Multiple Controls Bound to the Same Data Source Remain Synchronized
Oftentimes when working with data binding in Windows Forms, multiple controls are bound to the same data source. In some cases, it may be necessary to take extra steps to ensure that the bound properties of the controls remain synchronized with each other and the data source. These steps are necessary in two situations:  
  
-   If the data source does not implement <xref:System.ComponentModel.IBindingList>, and therefore generate <xref:System.ComponentModel.IBindingList.ListChanged> events of type <xref:System.ComponentModel.ListChangedType.ItemChanged>.  
  
-   If the data source implements <xref:System.ComponentModel.IEditableObject>.  
  
 In the former case, you can use a <xref:System.Windows.Forms.BindingSource> to bind the data source to the controls. In the latter case, you use a <xref:System.Windows.Forms.BindingSource> and handle the <xref:System.Windows.Forms.BindingSource.BindingComplete> event and call <xref:System.Windows.Forms.BindingManagerBase.EndCurrentEdit%2A> on the associated <xref:System.Windows.Forms.BindingManagerBase>.  
  
## Example  
 The following code example demonstrates how to bind three controls—two text-box controls and a <xref:System.Windows.Forms.DataGridView> control—to the same column in a <xref:System.Data.DataSet> using a <xref:System.Windows.Forms.BindingSource> component. This example demonstrates how to handle the <xref:System.Windows.Forms.BindingSource.BindingComplete> event and ensure that when the text value of one text box is changed, the additional text box and the <xref:System.Windows.Forms.DataGridView> control are updated with the correct value.  
  
 The example uses a <xref:System.Windows.Forms.BindingSource> to bind the data source and the controls. Alternatively, you can bind the controls directly to the data source and retrieve the <xref:System.Windows.Forms.BindingManagerBase> for the binding from the form's <xref:System.Windows.Forms.Control.BindingContext%2A> and then handle the <xref:System.Windows.Forms.BindingManagerBase.BindingComplete> event for the <xref:System.Windows.Forms.BindingManagerBase>. For an example of how to do this, see the Help page about the <xref:System.Windows.Forms.BindingManagerBase.BindingComplete> event of <xref:System.Windows.Forms.BindingManagerBase>.  
  
 [!code-csharp[System.Windows.Forms.BindingSourceMultipleControls#1](../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.BindingSourceMultipleControls/CS/Form1.cs#1)]
 [!code-vb[System.Windows.Forms.BindingSourceMultipleControls#1](../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.BindingSourceMultipleControls/VB/Form1.vb#1)]  
  
## Compiling the Code  
  
-   This code example requires  
  
-   References to the <xref:System>, <xref:System.Windows.Forms>, and <xref:System.Drawing> assemblies.  
  
-   A form with the <xref:System.Windows.Forms.Form.Load> event handled and a call to the `InitializeControlsAndDataSource` method in the example from the form's <xref:System.Windows.Forms.Form.Load> event handler.  
  
## See Also  
 [How to: Share Bound Data Across Forms Using the BindingSource Component](../../../docs/framework/winforms/controls/how-to-share-bound-data-across-forms-using-the-bindingsource-component.md)  
 [Change Notification in Windows Forms Data Binding](../../../docs/framework/winforms/change-notification-in-windows-forms-data-binding.md)  
 [Interfaces Related to Data Binding](../../../docs/framework/winforms/interfaces-related-to-data-binding.md)  
 [Windows Forms Data Binding](../../../docs/framework/winforms/windows-forms-data-binding.md)
