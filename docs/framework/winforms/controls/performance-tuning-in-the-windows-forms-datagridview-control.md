---
title: "Performance Tuning in the Windows Forms DataGridView Control"
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
  - "DataGridView control [Windows Forms], performance tuning"
  - "performance [Windows Forms], DataGridView control"
  - "performance tuning [Windows Forms], data grids"
ms.assetid: 6ccbff28-a0ff-41e4-b601-61b31b61851d
caps.latest.revision: 9
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Performance Tuning in the Windows Forms DataGridView Control
When working with large amounts of data, the `DataGridView` control can consume a large amount of memory in overhead, unless you use it carefully. On clients with limited memory, you can avoid some of this overhead by avoiding features that have a high memory cost. You can also manage some or all of the data maintenance and retrieval tasks yourself using virtual mode in order to customize the memory usage for your scenario.  
  
## In This Section  
 [Best Practices for Scaling the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/best-practices-for-scaling-the-windows-forms-datagridview-control.md)  
 Describes how to use the `DataGridView` control in a way that avoids unnecessary memory usage and performance penalties when working with large amounts of data.  
  
 [Virtual Mode in the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/virtual-mode-in-the-windows-forms-datagridview-control.md)  
 Describes how to use virtual mode to supplement or replace the standard data-binding mechanism.  
  
 [Walkthrough: Implementing Virtual Mode in the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/implementing-virtual-mode-wf-datagridview-control.md)  
 Describes how to implement handlers for several virtual-mode events. Also demonstrates how to implement row-level rollback and commit for user edits.  
  
 [Implementing Virtual Mode with Just-In-Time Data Loading in the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/implementing-virtual-mode-jit-data-loading-in-the-datagrid.md)  
 Describes how to load data on demand, which is useful when you have more data to display than the available client memory can store.  
  
## Reference  
 <xref:System.Windows.Forms.DataGridView>  
 Provides reference documentation for the <xref:System.Windows.Forms.DataGridView> control.  
  
 <xref:System.Windows.Forms.DataGridView.VirtualMode%2A>  
 Provides reference documentation for the <xref:System.Windows.Forms.DataGridView.VirtualMode%2A> property.  
  
## See Also  
 [DataGridView Control](../../../../docs/framework/winforms/controls/datagridview-control-windows-forms.md)  
 [Data Display Modes in the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/data-display-modes-in-the-windows-forms-datagridview-control.md)
