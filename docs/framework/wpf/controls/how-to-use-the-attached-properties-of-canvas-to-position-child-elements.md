---
title: "How to: Use the Attached Properties of Canvas to Position Child Elements"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
  - "cpp"
helpviewer_keywords: 
  - "attached properties [WPF Designer]"
  - "Canvas control [WPF], attached properties"
ms.assetid: 48f1d25d-3820-4107-a4cc-d6c1e5664a44
---
# How to: Use the Attached Properties of Canvas to Position Child Elements
This example shows how to use the attached properties of <xref:System.Windows.Controls.Canvas> to position child elements.  
  
## Example  
 The following example adds four <xref:System.Windows.Controls.Button> elements as child elements of a parent <xref:System.Windows.Controls.Canvas>. Each element is represented by a <xref:System.Windows.Controls.Canvas.Bottom%2A>, <xref:System.Windows.Controls.Canvas.Left%2A>, <xref:System.Windows.Controls.Canvas.Right%2A>, and <xref:System.Windows.Controls.Canvas.Top%2A>.
 Each <xref:System.Windows.Controls.Button> is positioned relative to the parent <xref:System.Windows.Controls.Canvas> and according to its assigned property value.  
  
 [!code-cpp[CanvasAttachedProperties#1](../../../../samples/snippets/cpp/VS_Snippets_Wpf/CanvasAttachedProperties/CPP/CanvasAttachedProps.cpp#1)]
 [!code-csharp[CanvasAttachedProperties#1](../../../../samples/snippets/csharp/VS_Snippets_Wpf/CanvasAttachedProperties/CSharp/CanvasAttachedProps.cs#1)]
 [!code-vb[CanvasAttachedProperties#1](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/CanvasAttachedProperties/VisualBasic/CanvasAttachedProps.vb#1)]  
  
## See also
 <xref:System.Windows.Controls.Canvas>  
 <xref:System.Windows.Controls.Canvas.Bottom%2A>  
 <xref:System.Windows.Controls.Canvas.Left%2A>  
 <xref:System.Windows.Controls.Canvas.Right%2A>  
 <xref:System.Windows.Controls.Canvas.Top%2A>  
 <xref:System.Windows.Controls.Button>  
 [Panels Overview](../../../../docs/framework/wpf/controls/panels-overview.md)  
 [How-to Topics](../../../../docs/framework/wpf/controls/canvas-how-to-topics.md)  
 [Attached Properties Overview](../../../../docs/framework/wpf/advanced/attached-properties-overview.md)
