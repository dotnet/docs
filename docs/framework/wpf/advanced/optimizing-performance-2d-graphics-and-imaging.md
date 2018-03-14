---
title: "Optimizing Performance: 2D Graphics and Imaging"
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
  - "graphics [WPF], performance"
  - "drawing [WPF], optimizing performance"
  - "imaging [WPF], optimizing performance"
  - "shapes [WPF], optimizing performance"
  - "2-D graphics [WPF]"
  - "images [WPF], optimizing performance"
ms.assetid: e335601e-28c8-4d64-ba27-778fffd55f72
caps.latest.revision: 8
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Optimizing Performance: 2D Graphics and Imaging
[!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] provides a wide range of 2D graphics and imaging functionality that can be optimized for your application requirements. This topic provides information about performance optimization in those areas.  
  
  
<a name="Drawing_and_Shapes"></a>   
## Drawing and Shapes  
 [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] provides both <xref:System.Windows.Media.Drawing> and <xref:System.Windows.Shapes.Shape> objects to represent graphical drawing content. However, <xref:System.Windows.Media.Drawing> objects are simpler constructs than <xref:System.Windows.Shapes.Shape> objects and provide better performance characteristics.  
  
 A <xref:System.Windows.Shapes.Shape> allows you to draw a graphical shape to the screen. Because they are derived from the <xref:System.Windows.FrameworkElement> class, <xref:System.Windows.Shapes.Shape> objects can be used inside panels and most controls.  
  
 [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] offers several layers of access to graphics and rendering services. At the top layer, <xref:System.Windows.Shapes.Shape> objects are easy to use and provide many useful features, such as layout and event handling. [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] provides a number of ready-to-use shape objects. All shape objects inherit from the <xref:System.Windows.Shapes.Shape> class. Available shape objects include <xref:System.Windows.Shapes.Ellipse>, <xref:System.Windows.Shapes.Line>, <xref:System.Windows.Shapes.Path>, <xref:System.Windows.Shapes.Polygon>, <xref:System.Windows.Shapes.Polyline>, and <xref:System.Windows.Shapes.Rectangle>.  
  
 <xref:System.Windows.Media.Drawing> objects, on the other hand, do not derive from the <xref:System.Windows.FrameworkElement> class and provide a lighter-weight implementation for rendering shapes, images, and text.  
  
 There are four types of <xref:System.Windows.Media.Drawing> objects:  
  
-   <xref:System.Windows.Media.GeometryDrawing> Draws a shape.  
  
-   <xref:System.Windows.Media.ImageDrawing> Draws an image.  
  
-   <xref:System.Windows.Media.GlyphRunDrawing> Draws text.  
  
-   <xref:System.Windows.Media.DrawingGroup> Draws other drawings. Use a drawing group to combine other drawings into a single composite drawing.  
  
 The <xref:System.Windows.Media.GeometryDrawing> object is used to render geometry content. The <xref:System.Windows.Media.Geometry> class and the concrete classes which derive from it, such as <xref:System.Windows.Media.CombinedGeometry>, <xref:System.Windows.Media.EllipseGeometry>, and <xref:System.Windows.Media.PathGeometry>, provide a means for rendering 2D graphics, as well as providing hit-testing and clipping support. Geometry objects can be used to define the region of a control, for example, or to define the clip region to apply to an image. Geometry objects can be simple regions, such as rectangles and circles, or composite regions created from two or more geometry objects. More complex geometric regions can be created by combining <xref:System.Windows.Media.PathSegment>-derived objects, such as <xref:System.Windows.Media.ArcSegment>, <xref:System.Windows.Media.BezierSegment>, and <xref:System.Windows.Media.QuadraticBezierSegment>.  
  
 On the surface, the <xref:System.Windows.Media.Geometry> class and the <xref:System.Windows.Shapes.Shape> class are quite similar. Both are used in the rendering of 2D graphics and both have similar concrete classes which derive from them, for example, <xref:System.Windows.Media.EllipseGeometry> and <xref:System.Windows.Shapes.Ellipse>. However, there are important differences between these two sets of classes. For one, the <xref:System.Windows.Media.Geometry> class lacks some of the functionality of the <xref:System.Windows.Shapes.Shape> class, such as the ability to draw itself. To draw a geometry object, another class such as DrawingContext, Drawing, or a Path (it is worth noting that a Path is a Shape) must be used to perform the drawing operation. Rendering properties such as fill, stroke, and the stroke thickness are on the class which draws the geometry object, while a shape object contains these properties. One way to think of this difference is that a geometry object defines a region, a circle for example, while a shape object defines a region, defines how that region is filled and outlined, and participates in the layout system.  
  
 Since <xref:System.Windows.Shapes.Shape> objects derive from the <xref:System.Windows.FrameworkElement> class, using them can add significantly more memory consumption in your application. If you really do not need the <xref:System.Windows.FrameworkElement> features for your graphical content, consider using the lighter-weight <xref:System.Windows.Media.Drawing> objects.  
  
 For more information on <xref:System.Windows.Media.Drawing> objects, see [Drawing Objects Overview](../../../../docs/framework/wpf/graphics-multimedia/drawing-objects-overview.md).  
  
<a name="StreamGeometry_Objects"></a>   
## StreamGeometry Objects  
 The <xref:System.Windows.Media.StreamGeometry> object is a light-weight alternative to <xref:System.Windows.Media.PathGeometry> for creating geometric shapes. Use a <xref:System.Windows.Media.StreamGeometry> when you need to describe a complex geometry. <xref:System.Windows.Media.StreamGeometry> is optimized for handling many <xref:System.Windows.Media.PathGeometry> objects and performs better when compared to using many individual <xref:System.Windows.Media.PathGeometry> objects.  
  
 The following example uses attribute syntax to create a triangular <xref:System.Windows.Media.StreamGeometry> in [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)].  
  
 [!code-xaml[GeometriesMiscSnippets_snip#StreamGeometryTriangleExampleWholePage](../../../../samples/snippets/xaml/VS_Snippets_Wpf/GeometriesMiscSnippets_snip/XAML/StreamGeometryExample.xaml#streamgeometrytriangleexamplewholepage)]  
  
 For more information on <xref:System.Windows.Media.StreamGeometry> objects, see [Create a Shape Using a StreamGeometry](../../../../docs/framework/wpf/graphics-multimedia/how-to-create-a-shape-using-a-streamgeometry.md).  
  
<a name="DrawingVisual_Objects"></a>   
## DrawingVisual Objects  
 The <xref:System.Windows.Media.DrawingVisual> object is a lightweight drawing class that is used to render shapes, images, or text. This class is considered lightweight because it does not provide layout or event handling, which improves its performance. For this reason, drawings are ideal for backgrounds and clip art. For more information, see [Using DrawingVisual Objects](../../../../docs/framework/wpf/graphics-multimedia/using-drawingvisual-objects.md).  
  
<a name="Images"></a>   
## Images  
 [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] imaging provides a significant improvement over the imaging capabilities in previous versions of [!INCLUDE[TLA#tla_mswin](../../../../includes/tlasharptla-mswin-md.md)]. Imaging capabilities, such as displaying a bitmap or using an image on a common control were primarily handled by the Microsoft Windows Graphics Device Interface (GDI) or Microsoft Windows GDI+ application programming interface (API). These API provided baseline imaging functionality, but lacked features such as support for codec extensibility and high fidelity image support. WPF Imaging API have been redesigned to overcome the shortcomings of GDI and GDI+ and provide a new set of API to display and use images within your applications.  
  
 When using images, consider the following recommendations for gaining better performance:  
  
-   If your application requires you to display thumbnail images, consider creating a reduced-sized version of the image. By default, [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] loads your image and decodes it to its full size. If you only want a thumbnail version of the image, [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] unnecessary decodes the image to its full-size and then scales it down to a thumbnail size. To avoid this unnecessary overhead, you can either request [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] to decode the image to a thumbnail size, or request [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] to load a thumbnail size image.  
  
-   Always decode the image to desired size and not to the default size. As mentioned above, request [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] to decode your image to a desired size and not the default full size. You will reduce not only your application's working set, but execution speed as well.  
  
-   If possible, combine the images into a single image, such as a film strip composed of multiple images.  
  
-   For more information, see [Imaging Overview](../../../../docs/framework/wpf/graphics-multimedia/imaging-overview.md).  
  
### BitmapScalingMode  
 When animating the scale of any bitmap, the default high-quality image re-sampling algorithm can sometimes consume sufficient system resources to cause frame rate degradation, effectively causing animations to stutter. By setting the <xref:System.Windows.Media.RenderOptions.BitmapScalingMode%2A> property of the <xref:System.Windows.Media.RenderOptions> object to <xref:System.Windows.Media.BitmapScalingMode.LowQuality> you can create a smoother animation when scaling a bitmap. <xref:System.Windows.Media.BitmapScalingMode.LowQuality> mode tells the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] rendering engine to switch from a quality-optimized algorithm to a speed-optimized algorithm when processing images.  
  
 The following example shows how to set the <xref:System.Windows.Media.BitmapScalingMode> for an image object.  
  
 [!code-csharp[RenderOptions#RenderOptionsSnippet2](../../../../samples/snippets/csharp/VS_Snippets_Wpf/RenderOptions/CSharp/Window1.xaml.cs#renderoptionssnippet2)]
 [!code-vb[RenderOptions#RenderOptionsSnippet2](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/RenderOptions/visualbasic/window1.xaml.vb#renderoptionssnippet2)]  
  
### CachingHint  
 By default, [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] does not cache the rendered contents of <xref:System.Windows.Media.TileBrush> objects, such as <xref:System.Windows.Media.DrawingBrush> and <xref:System.Windows.Media.VisualBrush>. In static scenarios where neither the contents nor use of the <xref:System.Windows.Media.TileBrush> in the scene is changing, this makes sense, since it conserves video memory. It does not make as much sense when a <xref:System.Windows.Media.TileBrush> with static content is used in a non-static way—for example, when a static <xref:System.Windows.Media.DrawingBrush> or <xref:System.Windows.Media.VisualBrush> is mapped to the surface of a rotating 3D object. The default behavior of [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] is to re-render the entire content of the <xref:System.Windows.Media.DrawingBrush> or <xref:System.Windows.Media.VisualBrush> for every frame, even though the content is unchanging.  
  
 By setting the <xref:System.Windows.Media.RenderOptions.CachingHint%2A> property of the <xref:System.Windows.Media.RenderOptions> object to <xref:System.Windows.Media.CachingHint.Cache> you can increase performance by using cached versions of the tiled brush objects.  
  
 The <xref:System.Windows.Media.RenderOptions.CacheInvalidationThresholdMinimum%2A> and <xref:System.Windows.Media.RenderOptions.CacheInvalidationThresholdMaximum%2A> property values are relative size values that determine when the <xref:System.Windows.Media.TileBrush> object should be regenerated due to changes in scale. For example, by setting the <xref:System.Windows.Media.RenderOptions.CacheInvalidationThresholdMaximum%2A> property to 2.0, the cache for the <xref:System.Windows.Media.TileBrush> only needs to be regenerated when its size exceeds twice the size of the current cache.  
  
 The following example shows how to use the caching hint option for a <xref:System.Windows.Media.DrawingBrush>.  
  
 [!code-csharp[RenderOptions#RenderOptionsSnippet3](../../../../samples/snippets/csharp/VS_Snippets_Wpf/RenderOptions/CSharp/Window1.xaml.cs#renderoptionssnippet3)]
 [!code-vb[RenderOptions#RenderOptionsSnippet3](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/RenderOptions/visualbasic/window1.xaml.vb#renderoptionssnippet3)]  
  
## See Also  
 [Optimizing WPF Application Performance](../../../../docs/framework/wpf/advanced/optimizing-wpf-application-performance.md)  
 [Planning for Application Performance](../../../../docs/framework/wpf/advanced/planning-for-application-performance.md)  
 [Taking Advantage of Hardware](../../../../docs/framework/wpf/advanced/optimizing-performance-taking-advantage-of-hardware.md)  
 [Layout and Design](../../../../docs/framework/wpf/advanced/optimizing-performance-layout-and-design.md)  
 [Object Behavior](../../../../docs/framework/wpf/advanced/optimizing-performance-object-behavior.md)  
 [Application Resources](../../../../docs/framework/wpf/advanced/optimizing-performance-application-resources.md)  
 [Text](../../../../docs/framework/wpf/advanced/optimizing-performance-text.md)  
 [Data Binding](../../../../docs/framework/wpf/advanced/optimizing-performance-data-binding.md)  
 [Other Performance Recommendations](../../../../docs/framework/wpf/advanced/optimizing-performance-other-recommendations.md)  
 [Animation Tips and Tricks](../../../../docs/framework/wpf/graphics-multimedia/animation-tips-and-tricks.md)
