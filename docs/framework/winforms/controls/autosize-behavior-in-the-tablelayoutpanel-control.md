---
title: "AutoSize Behavior in the TableLayoutPanel Control"
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
  - "AutoSize property [Windows Forms], tableLayoutPanel control"
  - "controls [Windows Forms], sizing"
  - "localizing forms"
  - "layout [Windows Forms], AutoSize"
  - "sizing [Windows Forms], automatic"
  - "TableLayoutPanel control [Windows Forms], AutoSize behavior"
  - "automatic sizing"
  - "AutoSizeMode property"
ms.assetid: 9233e0c3-2fa6-405e-8701-959479b1250e
caps.latest.revision: 8
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# AutoSize Behavior in the TableLayoutPanel Control
## Distinct AutoSize Behaviors  
 The <xref:System.Windows.Forms.TableLayoutPanel> control supports automatic sizing behavior in the following ways:  
  
-   Through the <xref:System.Windows.Forms.Control.AutoSize%2A> property;  
  
-   Through the <xref:System.Windows.Forms.TableLayoutStyle.SizeType%2A> property on the <xref:System.Windows.Forms.TableLayoutPanel> control’s column and row styles.  
  
### The AutoSize Property with Row and Column Styles  
 The following table describes the interaction between the <xref:System.Windows.Forms.Control.AutoSize%2A> property and the <xref:System.Windows.Forms.TableLayoutPanel> control’s column and row styles.  
  
|AutoSize setting|Style interaction|  
|----------------------|-----------------------|  
|`false`|The <xref:System.Windows.Forms.TableLayoutPanel> control proceeds from left to right, and allocates space for the column or row or in the following order.<br /><br /> 1.  If the <xref:System.Windows.Forms.TableLayoutStyle.SizeType%2A> property is set to <xref:System.Windows.Forms.SizeType.Absolute>, the number of pixels specified by <xref:System.Windows.Forms.ColumnStyle.Width%2A> or <xref:System.Windows.Forms.RowStyle.Height%2A> is allocated.<br />2.  If the <xref:System.Windows.Forms.TableLayoutStyle.SizeType%2A> property is set to <xref:System.Windows.Forms.SizeType.AutoSize>, the number of pixels returned by the child control’s <xref:System.Windows.Forms.Control.GetPreferredSize%2A> method is allocated.<br />3.  After space for all <xref:System.Windows.Forms.SizeType.Absolute> and <xref:System.Windows.Forms.SizeType.AutoSize> columns or rows is allocated, any columns or rows with <xref:System.Windows.Forms.TableLayoutStyle.SizeType%2A> set to <xref:System.Windows.Forms.SizeType.Percent> are used to proportionally allocate the remaining free space|  
|`true`|Similar to the previous interaction, with the exception that <xref:System.Windows.Forms.SizeType.Percent> columns or rows acquire an automatic sizing aspect.<br /><br /> The <xref:System.Windows.Forms.TableLayoutPanel> control expands the column or row to create adequate free space, so that no column or row with <xref:System.Windows.Forms.SizeType.Percent> styling clips its contents. The <xref:System.Windows.Forms.TableLayoutPanel> control allocates the new space proportionally according to the <xref:System.Windows.Forms.ColumnStyle.Width%2A> or <xref:System.Windows.Forms.RowStyle.Height%2A> property.|  
  
## See Also  
 <xref:System.Windows.Forms.TableLayoutPanel>  
 [TableLayoutPanel Control Overview](../../../../docs/framework/winforms/controls/tablelayoutpanel-control-overview.md)
