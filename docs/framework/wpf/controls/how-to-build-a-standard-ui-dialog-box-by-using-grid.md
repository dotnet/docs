---
title: "How to: Build a Standard UI Dialog Box by Using Grid"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-wpf"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "dialog boxes [WPF], creating"
  - "Grid control [WPF], creating [WPF], dialog box"
ms.assetid: d6ac3d51-844b-4d29-96d8-81a696a7b960
caps.latest.revision: 14
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Build a Standard UI Dialog Box by Using Grid
This example shows how to create a standard [!INCLUDE[TLA#tla_ui](../../../../includes/tlasharptla-ui-md.md)] dialog box by using the <xref:System.Windows.Controls.Grid> element.  
  
## Example  
 The following example creates a dialog box like the **Run** dialog box in the [!INCLUDE[TLA#tla_mswin](../../../../includes/tlasharptla-mswin-md.md)] operating system.  
  
 The example creates a <xref:System.Windows.Controls.Grid> and uses the <xref:System.Windows.Controls.ColumnDefinition> and <xref:System.Windows.Controls.RowDefinition> classes to define five columns and four rows.  
  
 The example then adds and positions an <xref:System.Windows.Controls.Image>, `RunIcon.png`, to represent the image that is found in the dialog box. The image is placed in the first column and row of the <xref:System.Windows.Controls.Grid> (the upper-left corner).  
  
 Next, the example adds a <xref:System.Windows.Controls.TextBlock> element to the first column, which spans the remaining columns of the first row. It adds another <xref:System.Windows.Controls.TextBlock> element to the second row in the first column, to represent the **Open** text box. A <xref:System.Windows.Controls.TextBlock> follows, which represents the data entry area.  
  
 Finally, the example adds three <xref:System.Windows.Controls.Button> elements to the final row, which represent the **OK**, **Cancel**, and **Browse** events.  
  
 [!code-csharp[GridRunDialog#1](../../../../samples/snippets/csharp/VS_Snippets_Wpf/GridRunDialog/CSharp/window1.xaml.cs#1)]
 [!code-vb[GridRunDialog#1](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/GridRunDialog/VisualBasic/grid_vb.vb#1)]  
  
## See Also  
 <xref:System.Windows.Controls.Grid>  
 <xref:System.Windows.GridUnitType>  
 [Panels Overview](../../../../docs/framework/wpf/controls/panels-overview.md)  
 [How-to Topics](../../../../docs/framework/wpf/controls/grid-how-to-topics.md)
