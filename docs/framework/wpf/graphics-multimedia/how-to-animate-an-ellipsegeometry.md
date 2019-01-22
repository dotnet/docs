---
title: "How to: Animate an EllipseGeometry"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "animation [WPF], EllipseGeometry objects [WPF]"
  - "EllipseGeometry objects [WPF], animating"
  - "graphics [WPF], animation"
ms.assetid: 767b9b6e-9cb7-482e-b6c2-fee7750c3995
---
# How to: Animate an EllipseGeometry
This example shows how to animate a <xref:System.Windows.Media.Geometry> within a <xref:System.Windows.Shapes.Path> element. In the following example, a <xref:System.Windows.Media.Animation.PointAnimation> is used to animate the <xref:System.Windows.Media.EllipseGeometry.Center%2A> of an <xref:System.Windows.Media.EllipseGeometry>.  
  
## Example  
 [!code-xaml[animatepath_snip_XAML#1](../../../../samples/snippets/csharp/VS_Snippets_Wpf/animatepath_snip_XAML/CS/EllipseGeometryExample.xaml#1)]  
  
 [!code-csharp[animatepath_snip#101](../../../../samples/snippets/csharp/VS_Snippets_Wpf/animatepath_snip/CSharp/EllipseGeometryExample.cs#101)]  
  
 [!code-vb[animatepath_snip#201](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/animatepath_snip/VisualBasic/EllipseGeometryExample.vb#201)]  
  
## See also
- [Animation Overview](../../../../docs/framework/wpf/graphics-multimedia/animation-overview.md)
- [Geometry Overview](../../../../docs/framework/wpf/graphics-multimedia/geometry-overview.md)
