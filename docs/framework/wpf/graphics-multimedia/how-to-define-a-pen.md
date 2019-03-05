---
title: "How to: Define a Pen"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "pens [WPF], defining"
  - "creating [WPF], pens"
ms.assetid: 7a4f2900-cdf9-49de-84e0-ba5d0ded4d33
---
# How to: Define a Pen
This example shows how use a <xref:System.Windows.Media.Pen> to outline a shape. To create a simple <xref:System.Windows.Media.Pen>, you need only specify its <xref:System.Windows.Media.Pen.Thickness%2A> and <xref:System.Windows.Media.Pen.Brush%2A>. You can create more complex pen's by specifying a <xref:System.Windows.Media.Pen.DashStyle%2A>, <xref:System.Windows.Media.Pen.DashCap%2A>, <xref:System.Windows.Media.Pen.LineJoin%2A>, <xref:System.Windows.Media.Pen.StartLineCap%2A>, and <xref:System.Windows.Media.Pen.EndLineCap%2A>.  
  
## Example  
 The following example uses a <xref:System.Windows.Media.Pen> to outline a shape defined by a <xref:System.Windows.Media.GeometryDrawing>.  
  
 [!code-csharp[PenExamples_snip#PenExampleWholePage](~/samples/snippets/csharp/VS_Snippets_Wpf/PenExamples_snip/CSharp/PenExample.cs#penexamplewholepage)]
 [!code-vb[PenExamples_snip#PenExampleWholePage](~/samples/snippets/visualbasic/VS_Snippets_Wpf/PenExamples_snip/VisualBasic/PenExample.vb#penexamplewholepage)]  
  
 ![Outlines produces by a Pen](./media/graphicsmm-simple-pen.jpg "graphicsmm_simple_pen")  
A GeometryDrawing
