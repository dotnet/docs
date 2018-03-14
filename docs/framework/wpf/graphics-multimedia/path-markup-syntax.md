---
title: "Path Markup Syntax"
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
  - "attribute usage in XAML [WPF]"
  - "XAML [WPF], attribute usage"
  - "graphics [WPF], PathGeometry class"
  - "XAML [WPF], object element usage"
ms.assetid: b8586241-a02d-486e-9223-e1e98e047f41
caps.latest.revision: 22
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Path Markup Syntax
Paths are discussed in [Shapes and Basic Drawing in WPF Overview](../../../../docs/framework/wpf/graphics-multimedia/shapes-and-basic-drawing-in-wpf-overview.md) and the [Geometry Overview](../../../../docs/framework/wpf/graphics-multimedia/geometry-overview.md), however, this topic describes in detail the powerful and complex mini-language you can use to specify path geometries more compactly using [!INCLUDE[TLA#tla_xaml](../../../../includes/tlasharptla-xaml-md.md)].  
  
<a name="prerequisites"></a>   
## Prerequisites  
 To understand this topic, you should be familiar with the basic features of <xref:System.Windows.Media.Geometry> objects. For more information, see the [Geometry Overview](../../../../docs/framework/wpf/graphics-multimedia/geometry-overview.md).  
  
<a name="abouthisdocument"></a>   
## StreamGeometry and PathFigureCollection Mini-Languages  
 [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] provides two classes that provide mini-languages for describing geometric paths: <xref:System.Windows.Media.StreamGeometry> and <xref:System.Windows.Media.PathFigureCollection>.  
  
-   You use the <xref:System.Windows.Media.StreamGeometry> mini-language when setting a property of type <xref:System.Windows.Media.Geometry>, such as the <xref:System.Windows.UIElement.Clip%2A> property of a <xref:System.Windows.UIElement> or the <xref:System.Windows.Shapes.Path.Data%2A> property of a <xref:System.Windows.Shapes.Path> element. The following example uses attribute syntax to create a <xref:System.Windows.Media.StreamGeometry>.  
  
     [!code-xaml[GeometrySample_snip_XAML#GraphicsMMStreamGeometryAttributeSyntaxInline](../../../../samples/snippets/csharp/VS_Snippets_Wpf/GeometrySample_snip_XAML/CS/MiniLanguageExample.xaml#graphicsmmstreamgeometryattributesyntaxinline)]  
  
-   You use the <xref:System.Windows.Media.PathFigureCollection> mini-language when setting the <xref:System.Windows.Media.PathGeometry.Figures%2A> property of a <xref:System.Windows.Media.PathGeometry>. The following example uses a attribute syntax to create a <xref:System.Windows.Media.PathFigureCollection> for a <xref:System.Windows.Media.PathGeometry>.  
  
     [!code-xaml[GeometrySample_snip_XAML#GraphicsMMPathFigureCollectionAttributeSyntaxInline](../../../../samples/snippets/csharp/VS_Snippets_Wpf/GeometrySample_snip_XAML/CS/MiniLanguageExample.xaml#graphicsmmpathfigurecollectionattributesyntaxinline)]  
  
 As you can see from the preceding examples, the two mini-languages are very similar. It's always possible to use a <xref:System.Windows.Media.PathGeometry> in any situation where you could use a <xref:System.Windows.Media.StreamGeometry>; so which one should you use? Use a <xref:System.Windows.Media.StreamGeometry> when you don't need to modify the path after creating it; use a <xref:System.Windows.Media.PathGeometry> if you do need to modify the path.  
  
 For more information about the differences between <xref:System.Windows.Media.PathGeometry> and <xref:System.Windows.Media.StreamGeometry> objects, see the [Geometry Overview](../../../../docs/framework/wpf/graphics-multimedia/geometry-overview.md).  
  
### A Note about White Space  
 For brevity, a single space is shown in the syntax sections that follow, but multiple spaces are also acceptable wherever a single space is shown.  
  
 Two numbers don’t actually have to be separated by a comma or whitespace, but this can only be done when the resulting string is unambiguous. For instance, `2..3` is actually two numbers: "2." And ".3". Similarly, `2-3` is "2" and "-3". Spaces are not required before or after commands, either.  
  
### Syntax  
 The [!INCLUDE[TLA#tla_xaml](../../../../includes/tlasharptla-xaml-md.md)] attribute usage syntax for a <xref:System.Windows.Media.StreamGeometry> is composed of an optional <xref:System.Windows.Media.FillRule> value and one or more figure descriptions.  
  
|StreamGeometry XAML Attribute Usage|  
|-----------------------------------------|  
|`<` *object* *property* `="`[ `fillRule`] `figureDescription`[ `figureDescription`]* `" ... />`|  
  
 The [!INCLUDE[TLA#tla_xaml](../../../../includes/tlasharptla-xaml-md.md)] attribute usage syntax for a <xref:System.Windows.Media.PathFigureCollection> is composed of one or more figure descriptions.  
  
|PathFigureCollection XAML Attribute Usage|  
|-----------------------------------------------|  
|`<` *object* *property* `="` `figureDescription`[ `figureDescription`]* `" ... />`|  
  
|Term|Description|  
|----------|-----------------|  
|*fillRule*|<xref:System.Windows.Media.FillRule?displayProperty=nameWithType><br /><br /> Specifies whether the <xref:System.Windows.Media.StreamGeometry> uses the <xref:System.Windows.Media.FillRule.EvenOdd> or <xref:System.Windows.Media.FillRule.Nonzero><xref:System.Windows.Media.PathGeometry.FillRule%2A>.<br /><br /> -   `F0` specifies the <xref:System.Windows.Media.FillRule.EvenOdd> fill rule.<br />-   `F1` specifies the <xref:System.Windows.Media.FillRule.Nonzero> fill rule.<br /><br /> If you omit this command, the subpath uses the default behavior, which is <xref:System.Windows.Media.FillRule.EvenOdd>. If you specify this command, you must place it first.|  
|*figureDescription*|A figure composed of a move command, draw commands, and an optional close command.<br /><br /> `moveCommand` `drawCommands`  `[` `closeCommand` `]`|  
|*moveCommand*|A move command that specifies the start point of the figure. See the [Move Command](#themovecommand) section.|  
|*drawCommands*|One or more drawing commands that describe the figure's contents. See the [Draw Commands](#drawcommands) section.|  
|*closeCommand*|An optional close command that closes figure. See the [Close Command](#closecommand) section.|  
  
<a name="themovecommand"></a>   
## Move Command  
 Specifies the start point of a new figure.  
  
|Syntax|  
|------------|  
|`M` *startPoint*<br /><br /> - or -<br /><br /> `m` *startPoint*|  
  
|Term|Description|  
|----------|-----------------|  
|*startPoint*|<xref:System.Windows.Point?displayProperty=nameWithType><br /><br /> The start point of a new figure.|  
  
 An uppercase `M` indicates that `startPoint` is an absolute value; a lowercase `m` indicates that `startPoint` is an offset to the previous point, or (0,0) if none exists. If you list multiple points after the move command, a line is drawn to those points though you specified the line command.  
  
<a name="drawcommands"></a>   
## Draw Commands  
 A draw command can consist of several shape commands. The following shape commands are available: line, horizontal line, vertical line, cubic Bezier curve, quadratic Bezier curve, smooth cubic Bezier curve, smooth quadratic Bezier curve, and elliptical arc.  
  
 You enter each command by using either an uppercase or a lowercase letter: uppercase letters denote absolute values and lowercase letters denote relative values: the control points for that segment are relative to the end point of the preceding example. When sequentially entering more than one command of the same type, you can omit the duplicate command entry; for example, `L 100,200 300,400` is equivalent to `L 100,200 L 300,400`. The following table describes the **move** and **draw** commands.  
  
### Line Command  
 Creates a straight line between the current point and the specified end point. `l 20 30` and `L 20,30` are examples of valid **line** commands.  
  
|Syntax|  
|------------|  
|`L` *endPoint*<br /><br /> - or -<br /><br /> `l` *endPoint*|  
  
|Term|Description|  
|----------|-----------------|  
|*endPoint*|<xref:System.Windows.Point?displayProperty=nameWithType><br /><br /> The end point of the line.|  

An uppercase `L` indicates that `endPoint` is an absolute value; a lowercase `l` indicates that `endPoint` is an offset to the previous point, or (0,0) if none exists.

### Horizontal Line Command  
 Creates a horizontal line between the current point and the specified x-coordinate. `H 90` is an example of a valid horizontal line command.

  
|Syntax|  
|------------|  
|`H`  *x*<br /><br /> - or -<br /><br /> `h`  *x*|  
  
|Term|Description|  
|----------|-----------------|  
|*x*|<xref:System.Double?displayProperty=nameWithType><br /><br /> The x-coordinate of the end point of the line.|  
  
An uppercase `H` indicates that `x` is an absolute value; a lowercase `h` indicates that `x` is an offset to the previous point, or (0,0) if none exists.
  
### Vertical Line Command  
 Creates a vertical line between the current point and the specified y-coordinate. `v 90` is an example of a valid vertical line command.

  
|Syntax|  
|------------|  
|`V`  *y*<br /><br /> - or -<br /><br /> `v`  *y*|  
  
|Term|Description|  
|----------|-----------------|  
|*y*|<xref:System.Double?displayProperty=nameWithType><br /><br /> The y-coordinate of the end point of the line.|  

An uppercase `V` indicates that `y` is an absolute value; a lowercase `v` indicates that `y` is an offset to the previous point, or (0,0) if none exists.  
    
### Cubic Bezier Curve Command  
 Creates a cubic Bezier curve between the current point and the specified end point by using the two specified control points (`controlPoint`1 and `controlPoint`2). `C 100,200 200,400 300,200` is an example of a valid curve command.  
  
|Syntax|  
|------------|  
|`C` `controlPoint`1`controlPoint`2`endPoint`<br /><br /> - or -<br /><br /> `c` `controlPoint`1`controlPoint`2`endPoint`|  
  
|Term|Description|  
|----------|-----------------|  
|`controlPoint`1|<xref:System.Windows.Point?displayProperty=nameWithType><br /><br /> The first control point of the curve, which determines the starting tangent of the curve.|  
|`controlPoint`2|<xref:System.Windows.Point?displayProperty=nameWithType><br /><br /> The second control point of the curve, which determines the ending tangent of the curve.|  
|`endPoint`|<xref:System.Windows.Point?displayProperty=nameWithType><br /><br /> The point to which the curve is drawn.|  
  
### Quadratic Bezier Curve Command  
 Creates a quadratic Bezier curve between the current point and the specified end point by using the specified control point (`controlPoint`). `q 100,200 300,200` is an example of a valid quadratic Bezier curve command.  
  
|Syntax|  
|------------|  
|`Q` `controlPoint` `endPoint`<br /><br /> - or -<br /><br /> `q` `controlPoint` `endPoint`|  
  
|Term|Description|  
|----------|-----------------|  
|`controlPoint`|<xref:System.Windows.Point?displayProperty=nameWithType><br /><br /> The control point of the curve, which determines the starting and ending tangents of the curve.|  
|`endPoint`|<xref:System.Windows.Point?displayProperty=nameWithType><br /><br /> The point to which the curve is drawn.|  
  
### Smooth cubic Bezier curve Command  
 Creates a cubic Bezier curve between the current point and the specified end point. The first control point is assumed to be the reflection of the second control point of the previous command relative to the current point. If there is no previous command or if the previous command was not a cubic Bezier curve command or a smooth cubic Bezier curve command, assume the first control point is coincident with the current point. The second control point, the control point for the end of the curve, is specified by `controlPoint`2. For example, `S 100,200 200,300` is a valid smooth cubic Bezier curve command.  
  
|Syntax|  
|------------|  
|`S` `controlPoint`2`endPoint`<br /><br /> - or -<br /><br /> `s` `controlPoint`2`endPoint`|  
  
|Term|Description|  
|----------|-----------------|  
|`controlPoint`2|<xref:System.Windows.Point?displayProperty=nameWithType><br /><br /> The control point of the curve, which determines the ending tangent of the curve.|  
|`endPoint`|<xref:System.Windows.Point?displayProperty=nameWithType><br /><br /> The point to which the curve is drawn.|  
  
### Smooth quadratic Bezier curve Command  
 Creates a quadratic Bezier curve between the current point and the specified end point. The control point is assumed to be the reflection of the control point of the previous command relative to the current point. If there is no previous command or if the previous command was not a quadratic Bezier curve command or a smooth quadratic Bezier curve command, the control point is coincident with the current point.  
  
|Syntax|  
|------------|  
|`T` `controlPoint` `endPoint`<br /><br /> - or -<br /><br /> `t` `controlPoint` `endPoint`|  
  
|Term|Description|  
|----------|-----------------|  
|`controlPoint`|<xref:System.Windows.Point?displayProperty=nameWithType><br /><br /> The control point of the curve, which determines the starting and tangent of the curve.|  
|`endPoint`|<xref:System.Windows.Point?displayProperty=nameWithType><br /><br /> The point to which the curve is drawn.|  
  
### Elliptical Arc Command  
 Creates an elliptical arc between the current point and the specified end point.  
  
|Syntax|  
|------------|  
|`A` `size` `rotationAngle` `isLargeArcFlag` `sweepDirectionFlag` `endPoint`<br /><br /> - or -<br /><br /> `a` `size` `rotationAngle` `isLargeArcFlag` `sweepDirectionFlag` `endPoint`|  
  
|Term|Description|  
|----------|-----------------|  
|`size`|<xref:System.Windows.Size?displayProperty=nameWithType><br /><br /> The x- and y-radius of the arc.|  
|`rotationAngle`|<xref:System.Double?displayProperty=nameWithType><br /><br /> The rotation of the ellipse, in degrees.|  
|`isLargeArcFlag`|Set to 1 if the angle of the arc should be 180 degrees or greater; otherwise, set to 0.|  
|`sweepDirectionFlag`|Set to 1 if the arc is drawn in a positive-angle direction; otherwise, set to 0.|  
|`endPoint`|<xref:System.Windows.Point?displayProperty=nameWithType><br /><br /> The point to which the arc is drawn.|  
  
<a name="closecommand"></a>   
## The Close Command  
 Ends the current figure and creates a line that connects the current point to the starting point of the figure. This command creates a line-join (corner) between the last segment and the first segment of the figure.  
  
|Syntax|  
|------------|  
|`Z`<br /><br /> - or -<br /><br /> `z`|  

<a name="pointsyntax"></a>   
## Point Syntax  
 Describes the x- and y-coordinates of a point where (0,0) is the top left corner.
  
|Syntax|  
|------------|  
|`x` `,` `y`<br /><br /> - or -<br /><br /> `x` `y`|  
  
|Term|Description|  
|----------|-----------------|  
|`x`|<xref:System.Double?displayProperty=nameWithType><br /><br /> The x-coordinate of the point.|  
|`y`|<xref:System.Double?displayProperty=nameWithType><br /><br /> The y-coordinate of the point.|  
  
<a name="specialvalues"></a>   
## Special Values  
 Instead of a standard numerical value, you can also use the following special values. These values are case-sensitive.  
  
 Infinity  
 Represents <xref:System.Double.PositiveInfinity?displayProperty=nameWithType>.  
  
 -Infinity  
 Represents <xref:System.Double.NegativeInfinity?displayProperty=nameWithType>.  
  
 NaN  
 Represents <xref:System.Double.NaN?displayProperty=nameWithType>.  
  
 You may also use scientific notation. For example, `+1.e17` is a valid value.  
  
## See Also  
 <xref:System.Windows.Shapes.Path>  
 <xref:System.Windows.Media.StreamGeometry>  
 <xref:System.Windows.Media.PathGeometry>  
 <xref:System.Windows.Media.PathFigureCollection>  
 [Shapes and Basic Drawing in WPF Overview](../../../../docs/framework/wpf/graphics-multimedia/shapes-and-basic-drawing-in-wpf-overview.md)  
 [Geometry Overview](../../../../docs/framework/wpf/graphics-multimedia/geometry-overview.md)  
 [How-to Topics](../../../../docs/framework/wpf/graphics-multimedia/geometries-how-to-topics.md)
