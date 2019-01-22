---
title: "How to: Create a Grid Element"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "Grid control [WPF], creating [WPF], grid instance"
ms.assetid: b2f07626-9df8-43b8-8d36-492f3cb42837
---
# How to: Create a Grid Element
## Example  
 The following example shows how to create and use an instance of <xref:System.Windows.Controls.Grid> by using either [!INCLUDE[TLA#tla_xaml](../../../../includes/tlasharptla-xaml-md.md)] or code. This example uses three <xref:System.Windows.Controls.ColumnDefinition> objects and three <xref:System.Windows.Controls.RowDefinition> objects to create a grid that has nine cells, such as in a worksheet. Each cell contains a <xref:System.Windows.Controls.TextBlock> element that represents data, and the top row contains a <xref:System.Windows.Controls.TextBlock> with the <xref:System.Windows.Controls.Grid.ColumnSpan%2A> property applied. To show the boundaries of each cell, the <xref:System.Windows.Controls.Grid.ShowGridLines%2A> property is enabled.  
  
 [!code-csharp[Grid#3](../../../../samples/snippets/csharp/VS_Snippets_Wpf/Grid/CSharp/Grid_Code.cs#3)]
 [!code-vb[Grid#3](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/Grid/VisualBasic/grid_vb.vb#3)]
 [!code-xaml[Grid#3](../../../../samples/snippets/xaml/VS_Snippets_Wpf/Grid/XAML/default.xaml#3)]  
  
  Either approach will generate a user interface that looks much the same, like the one below.

  ![a screenshot depicts a WPF user interface which contains a grid broken into three columns.  It bears the heading '2018 Products Shipped' spanning all columns of the top row, and has three columns each with sales figures for a certain quarter.  The bottom row has text spanning two columns with the message 'Total Units: 300,000'](./media/how-to-create-a-grid-element/how-to-create-a-grid-element.png)
## See also
 <xref:System.Windows.Controls.Grid>  
 [Panels Overview](../../../../docs/framework/wpf/controls/panels-overview.md)
