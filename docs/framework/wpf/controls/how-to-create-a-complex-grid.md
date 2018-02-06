---
title: "How to: Create a Complex Grid"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-wpf"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "calendar [WPF], creating"
  - "monthly calendar [WPF], creating"
  - "Grid control [WPF], creating [WPF], complex grid"
ms.assetid: 4ce3040a-a156-4364-9596-98ca1eca5550
caps.latest.revision: 10
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Create a Complex Grid
This example shows how to use a <xref:System.Windows.Controls.Grid> to create layout that looks like a monthly calendar.  
  
## Example  
 The following example defines eight rows and eight columns by using the <xref:System.Windows.Controls.RowDefinition> and <xref:System.Windows.Controls.ColumnDefinition> classes. It uses the <xref:System.Windows.Controls.Grid.ColumnSpan%2A?displayProperty=nameWithType> and <xref:System.Windows.Controls.Grid.RowSpan%2A?displayProperty=nameWithType> attached properties, together with <xref:System.Windows.Shapes.Rectangle> elements, which fill the backgrounds of various columns and rows. This design is possible because more than one element can exist in each cell in a <xref:System.Windows.Controls.Grid>, a principle difference between <xref:System.Windows.Controls.Grid> and <xref:System.Windows.Documents.Table>.  
  
 The example uses vertical gradients to <xref:System.Windows.Shapes.Shape.Fill%2A> the columns and rows in order to improve the visual presentation and readability of the calendar. Styled <xref:System.Windows.Controls.TextBlock> elements represent the dates and days of the week. <xref:System.Windows.Controls.TextBlock> elements are absolutely positioned within their cells by using the <xref:System.Windows.FrameworkElement.Margin%2A> property and alignment properties that are defined within the style for the application.  
  
 [!code-xaml[GridComplex#1](../../../../samples/snippets/csharp/VS_Snippets_Wpf/GridComplex/CS/default.xaml#1)]  
  
## See Also  
 <xref:System.Windows.Controls.Grid>  
 <xref:System.Windows.Documents.TableCell>  
 [Painting with Solid Colors and Gradients Overview](../../../../docs/framework/wpf/graphics-multimedia/painting-with-solid-colors-and-gradients-overview.md)  
 [Panels Overview](../../../../docs/framework/wpf/controls/panels-overview.md)  
 [Table Overview](../../../../docs/framework/wpf/advanced/table-overview.md)
