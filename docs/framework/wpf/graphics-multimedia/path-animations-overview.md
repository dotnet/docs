---
title: "Path Animations Overview"
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
  - "animation [WPF], paths"
  - "path animations [WPF]"
ms.assetid: 979c732c-df74-47a6-be96-8e07b3707d53
caps.latest.revision: 13
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Path Animations Overview
<a name="introduction"></a> This topic introduces path animations, which enable you to use a geometric path to generate output values. Path animations are useful for moving and rotating objects along complex paths.  
  
<a name="prerequisites"></a>   
## Prerequisites  
 To understand this topic, you should be familiar with [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] animations features. For an introduction to animation features, see the [Animation Overview](../../../../docs/framework/wpf/graphics-multimedia/animation-overview.md).  
  
 Because you use a <xref:System.Windows.Media.PathGeometry> object to define a path animation, you should also be familiar with <xref:System.Windows.Media.PathGeometry> and the different types of <xref:System.Windows.Media.PathSegment> objects. For more information, see the [Geometry Overview](../../../../docs/framework/wpf/graphics-multimedia/geometry-overview.md).  
  
<a name="what_is_a_path_animation"></a>   
## What Is a Path Animation?  
 A path animation is a type of <xref:System.Windows.Media.Animation.AnimationTimeline> that uses a <xref:System.Windows.Media.PathGeometry> as its input. Instead of setting a From, To, or By property (as you do for a From/To/By animation) or using key frames (as you use for a key-frame animation), you define a geometric path and use it to set the `PathGeometry` property of the path animation. As the path animation progresses, it reads the x, y, and angle information from the path and uses that information to generate its output.  
  
 Path animations are very useful for animating an object along a complex path. One way to move an object along a path is to use a <xref:System.Windows.Media.MatrixTransform> and a <xref:System.Windows.Media.Animation.MatrixAnimationUsingPath> to transform an object along a complex path. The following example demonstrates this technique by using the <xref:System.Windows.Media.Animation.MatrixAnimationUsingPath> object to animate the <xref:System.Windows.Media.MatrixTransform.Matrix%2A> property of a <xref:System.Windows.Media.MatrixTransform>. The <xref:System.Windows.Media.MatrixTransform> is applied to a button and causes it to move along a curved path. Because the <xref:System.Windows.Media.Animation.MatrixAnimationUsingPath.DoesRotateWithTangent%2A> property is set to `true`, the rectangle rotates along the tangent of the path.  
  
 [!code-xaml[PathAnimationGallery_snippet#MatrixAnimationUsingPathDoesRotateWithTangentWholePage](../../../../samples/snippets/csharp/VS_Snippets_Wpf/PathAnimationGallery_snippet/CS/matrixanimationusingpathdoesrotatewithtangentexample.xaml#matrixanimationusingpathdoesrotatewithtangentwholepage)]  
  
 [!code-csharp[PathAnimationGallery_procedural_snip#MatrixAnimationUsingPathDoesRotateWithTangentWholePage](../../../../samples/snippets/csharp/VS_Snippets_Wpf/PathAnimationGallery_procedural_snip/CSharp/MatrixAnimationUsingPathDoesRotateWithTangentExample.cs#matrixanimationusingpathdoesrotatewithtangentwholepage)]
 [!code-vb[PathAnimationGallery_procedural_snip#MatrixAnimationUsingPathDoesRotateWithTangentWholePage](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/PathAnimationGallery_procedural_snip/VisualBasic/MatrixAnimationUsingPathDoesRotateWithTangentExample.vb#matrixanimationusingpathdoesrotatewithtangentwholepage)]  
  
 For more information about the path syntax that is used in the [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)] example, see the [Path Markup Syntax](../../../../docs/framework/wpf/graphics-multimedia/path-markup-syntax.md) overview. For the complete sample, see [Path Animation Sample](http://go.microsoft.com/fwlink/?LinkID=160028).  
  
 You can apply a path animation to a property by using a <xref:System.Windows.Media.Animation.Storyboard> in [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)] and code, or by using the <xref:System.Windows.Media.Animation.Animatable.BeginAnimation%2A> method in code. You can also use a path animation to create an <xref:System.Windows.Media.Animation.AnimationClock> and apply it to one or more properties. For more information about the different methods for applying animations, see [Property Animation Techniques Overview](../../../../docs/framework/wpf/graphics-multimedia/property-animation-techniques-overview.md).  
  
<a name="animation_types"></a>   
## Path Animation Types  
 Because animations generate property values, there are different animation types for different property types. To animate a property that takes a <xref:System.Double> (such as the <xref:System.Windows.Media.TranslateTransform.X%2A> property of a <xref:System.Windows.Media.TranslateTransform>), you use an animation that produces <xref:System.Double> values. To animate a property that takes a <xref:System.Windows.Point>, you use an animation that produces <xref:System.Windows.Point> values, and so on.  
  
 Path animation classes belong to the <xref:System.Windows.Media.Animation> namespace and use the following naming convention:  
  
 *\<Type>* `AnimationUsingPath`  
  
 Where *\<Type>* is the type of value that the class animates.  
  
 [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] provides the following path animation classes.  
  
|Property type|Corresponding path animation class|Example|  
|-------------------|----------------------------------------|-------------|  
|<xref:System.Double>|<xref:System.Windows.Media.Animation.DoubleAnimationUsingPath>|[Animate an Object Along a Path (Double Animation)](../../../../docs/framework/wpf/graphics-multimedia/how-to-animate-an-object-along-a-path-double-animation.md)|  
|<xref:System.Windows.Media.Matrix>|<xref:System.Windows.Media.Animation.MatrixAnimationUsingPath>|[Animate an Object Along a Path (Matrix Animation)](../../../../docs/framework/wpf/graphics-multimedia/how-to-animate-an-object-along-a-path-matrix-animation.md)|  
|<xref:System.Windows.Point>|<xref:System.Windows.Media.Animation.PointAnimationUsingPath>|[Animate an Object Along a Path (Point Animation)](../../../../docs/framework/wpf/graphics-multimedia/how-to-animate-an-object-along-a-path-point-animation.md)|  
  
 A <xref:System.Windows.Media.Animation.MatrixAnimationUsingPath> generates <xref:System.Windows.Media.Matrix> values from its <xref:System.Windows.Media.Animation.MatrixAnimationUsingPath.PathGeometry%2A>. When used with a <xref:System.Windows.Media.MatrixTransform>, a <xref:System.Windows.Media.Animation.MatrixAnimationUsingPath> can move an object along a path. If you set the <xref:System.Windows.Media.Animation.MatrixAnimationUsingPath.DoesRotateWithTangent%2A> property of the <xref:System.Windows.Media.Animation.MatrixAnimationUsingPath> to `true`, it also rotates the object along the curves of the path.  
  
 A <xref:System.Windows.Media.Animation.PointAnimationUsingPath> generates <xref:System.Windows.Point> values from the x- and y-coordinates of its <xref:System.Windows.Media.Animation.PointAnimationUsingPath.PathGeometry%2A>. By using a <xref:System.Windows.Media.Animation.PointAnimationUsingPath> to animate a property that takes <xref:System.Windows.Point> values, you can move an object along a path. A <xref:System.Windows.Media.Animation.PointAnimationUsingPath> cannot rotate objects.  
  
 A <xref:System.Windows.Media.Animation.DoubleAnimationUsingPath> generates <xref:System.Double> values from its <xref:System.Windows.Media.Animation.DoubleAnimationUsingPath.PathGeometry%2A>. By setting the <xref:System.Windows.Media.Animation.DoubleAnimationUsingPath.Source%2A> property, you can specify whether the <xref:System.Windows.Media.Animation.DoubleAnimationUsingPath> uses the x-coordinate, y-coordinate, or angle of the path as its output. You can use a <xref:System.Windows.Media.Animation.DoubleAnimationUsingPath> to rotate an object or move it along the x-axis or y-axis.  
  
<a name="pathanimationinput"></a>   
## Path Animation Input  
 Each path animation class provides a <xref:System.Windows.Media.PathGeometry> property for specifying its input. The path animation uses the <xref:System.Windows.Media.PathGeometry> to generate its output values. The <xref:System.Windows.Media.PathGeometry> class lets you describe multiple complex figures that are composed of arcs, curves, and lines.  
  
 At the heart of a <xref:System.Windows.Media.PathGeometry> is a collection of <xref:System.Windows.Media.PathFigure> objects; these objects are so named because each figure describes a discrete shape in the <xref:System.Windows.Media.PathGeometry>. Each <xref:System.Windows.Media.PathFigure> consists of one or more <xref:System.Windows.Media.PathSegment> objects, each of which describes a segment of the figure.  
  
 There are many types of segments.  
  
|Segment Type|Description|  
|------------------|-----------------|  
|<xref:System.Windows.Media.ArcSegment>|Creates an elliptical arc between two points.|  
|<xref:System.Windows.Media.BezierSegment>|Creates a cubic Bezier curve between two points.|  
|<xref:System.Windows.Media.LineSegment>|Creates a line between two points.|  
|<xref:System.Windows.Media.PolyBezierSegment>|Creates a series of cubic Bezier curves.|  
|<xref:System.Windows.Media.PolyLineSegment>|Creates a series of lines.|  
|<xref:System.Windows.Media.PolyQuadraticBezierSegment>|Creates a series of quadratic Bezier curves.|  
|<xref:System.Windows.Media.QuadraticBezierSegment>|Creates a quadratic Bezier curve.|  
  
 The segments in a <xref:System.Windows.Media.PathFigure> are combined into a single geometric shape, which uses the end point of a segment as the start point of the next segment. The <xref:System.Windows.Media.PathFigure.StartPoint%2A> property of a <xref:System.Windows.Media.PathFigure> specifies the point from which the first segment is drawn. Each subsequent segment starts at the end point of the previous segment. For example, a vertical line from `10,50` to `10,150` can be defined by setting the <xref:System.Windows.Media.PathFigure.StartPoint%2A> property to `10,50` and creating a <xref:System.Windows.Media.LineSegment> with a <xref:System.Windows.Media.LineSegment.Point%2A> property setting of `10,150`.  
  
 For more information about <xref:System.Windows.Media.PathGeometry> objects, see the [Geometry Overview](../../../../docs/framework/wpf/graphics-multimedia/geometry-overview.md).  
  
 In [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)], you can also use a special abbreviated syntax to set the <xref:System.Windows.Media.PathGeometry.Figures%2A> property of a <xref:System.Windows.Media.PathGeometry>. For more information, see [Path Markup Syntax](../../../../docs/framework/wpf/graphics-multimedia/path-markup-syntax.md) overview.  
  
 For more information about the path syntax that is used in the [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)] example, see the [Path Markup Syntax](../../../../docs/framework/wpf/graphics-multimedia/path-markup-syntax.md) overview.  
  
## See Also  
 [Path Animation Sample](http://go.microsoft.com/fwlink/?LinkID=160028)  
 [Path Markup Syntax](../../../../docs/framework/wpf/graphics-multimedia/path-markup-syntax.md)  
 [Path Animation How-to Topics](../../../../docs/framework/wpf/graphics-multimedia/path-animation-how-to-topics.md)  
 [Animation Overview](../../../../docs/framework/wpf/graphics-multimedia/animation-overview.md)  
 [Property Animation Techniques Overview](../../../../docs/framework/wpf/graphics-multimedia/property-animation-techniques-overview.md)
