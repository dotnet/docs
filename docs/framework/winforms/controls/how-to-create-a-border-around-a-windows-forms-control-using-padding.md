---
title: "How to: Create a Border Around a Windows Forms Control Using Padding"
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
  - "margins"
  - "controls [Windows Forms], Margin property"
  - "padding [Windows Forms], Windows Forms"
  - "controls [Windows Forms], Padding property"
  - "controls [Windows Forms], outlining"
  - "Padding property [Windows Forms]"
  - "margins [Windows Forms], Windows Forms"
  - "Margin property [Windows Forms]"
ms.assetid: bac7ed4d-a163-4259-98bd-155a36345890
caps.latest.revision: 5
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Create a Border Around a Windows Forms Control Using Padding
The following code example demonstrates how to create a border or outline around a <xref:System.Windows.Forms.RichTextBox> control. The example sets the value of a <xref:System.Windows.Forms.Panel> control’s <xref:System.Windows.Forms.Padding> property to 5 and sets the <xref:System.Windows.Forms.Control.Dock%2A> property of a child <xref:System.Windows.Forms.RichTextBox> control to <xref:System.Windows.Forms.DockStyle.Fill>. The <xref:System.Windows.Forms.Control.BackColor%2A> of the <xref:System.Windows.Forms.Panel> control is set to <xref:System.Drawing.Color.Blue%2A>, which creates a blue border around the <xref:System.Windows.Forms.RichTextBox> control.  
  
## Example  
 [!code-csharp[System.Windows.Forms.Padding#1](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.Padding/CS/Form1.cs#1)]
 [!code-vb[System.Windows.Forms.Padding#1](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.Padding/VB/Form1.vb#1)]  
  
## See Also  
 <xref:System.Windows.Forms.Padding>  
 [Margin and Padding in Windows Forms Controls](../../../../docs/framework/winforms/controls/margin-and-padding-in-windows-forms-controls.md)
