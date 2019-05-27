---
title: "How to: Create an Elliptical Arc"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "graphics [WPF], elliptical arcs"
  - "elliptical arcs [WPF], creating"
  - "arcs [WPF], elliptical"
ms.assetid: 3dcfe502-3485-45de-99fb-d53a1367c484
---
# How to: Create an Elliptical Arc
This example shows how to draw an elliptical arc. To create an elliptical arc, use the <xref:System.Windows.Media.PathGeometry>, <xref:System.Windows.Media.PathFigure>, and <xref:System.Windows.Media.ArcSegment> classes.  
  
## Example  
 In the following examples, an elliptical arc is drawn from (10,100) to (200,100). The arc has a <xref:System.Windows.Media.ArcSegment.Size%2A> of 100 by 50 device-independent pixels, a <xref:System.Windows.Media.ArcSegment.RotationAngle%2A> of 45 degrees, an <xref:System.Windows.Media.ArcSegment.IsLargeArc%2A> setting of `true`, and a <xref:System.Windows.Media.ArcSegment.SweepDirection%2A> of <xref:System.Windows.Media.SweepDirection.Counterclockwise>.  
  
 [xaml]  
  
 In [!INCLUDE[TLA#tla_xaml](../../../../includes/tlasharptla-xaml-md.md)], you can use attribute syntax to describe a path.  
  
 [!code-xaml[GeometrySample#56](~/samples/snippets/csharp/VS_Snippets_Wpf/GeometrySample/CS/geometryattributesyntaxexample.xaml#56)]  
  
 [xaml]  
  
 (Note that this attribute syntax actually creates a <xref:System.Windows.Media.StreamGeometry>, a lighter-weight version of a <xref:System.Windows.Media.PathGeometry>. For more information, see the [Path Markup Syntax](path-markup-syntax.md) page.)  
  
 In [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)], you can also draw an elliptical arc by explicitly using object tags. The following is equivalent to the preceding [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)] markup.  
  
 [!code-xaml[GeometrySample#36](~/samples/snippets/csharp/VS_Snippets_Wpf/GeometrySample/CS/pathgeometryexample.xaml#36)]  
  
 This example is part of a larger sample. For the complete sample, see the [Geometries Sample](https://go.microsoft.com/fwlink/?LinkID=159989).  
  
## See also

- [Create a Quadratic Bezier Curve](how-to-create-a-quadratic-bezier-curve.md)
- [Create a Cubic Bezier Curve](how-to-create-a-cubic-bezier-curve.md)
