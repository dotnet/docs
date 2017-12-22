---
title: "Maximize WPF 3D Performance"
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
  - "3-D graphics [WPF]"
ms.assetid: 4bcf949d-d92f-4d8d-8a9b-1e4c61b25bf6
caps.latest.revision: 9
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Maximize WPF 3D Performance
As you use the [!INCLUDE[TLA#tla_winclient](../../../../includes/tlasharptla-winclient-md.md)] to build 3D controls and include 3D scenes in your applications, it is important to consider performance optimization. This topic provides a list of 3D classes and properties that have performance implications for your application, along with recommendations for optimizing performance when you use them.  
  
 This topic assumes an advanced understanding of [!INCLUDE[TLA#tla_winclient](../../../../includes/tlasharptla-winclient-md.md)] 3D features. The suggestions in this document apply to "rendering tier 2"—roughly defined as hardware that supports pixel shader version 2.0 and vertex shader version 2.0. For more details, see [Graphics Rendering Tiers](../../../../docs/framework/wpf/advanced/graphics-rendering-tiers.md).  
  
## Performance Impact: High  
  
|Property|Recommendation|  
|-|-|  
|<xref:System.Windows.Media.Brush>|Brush speed (fastest to slowest):<br /><br /> <xref:System.Windows.Media.SolidColorBrush><br /><br /> <xref:System.Windows.Media.LinearGradientBrush><br /><br /> <xref:System.Windows.Media.ImageBrush><br /><br /> <xref:System.Windows.Media.DrawingBrush> (cached)<br /><br /> <xref:System.Windows.Media.VisualBrush> (cached)<br /><br /> <xref:System.Windows.Media.RadialGradientBrush><br /><br /> <xref:System.Windows.Media.DrawingBrush> (uncached)<br /><br /> <xref:System.Windows.Media.VisualBrush> (uncached)|  
|<xref:System.Windows.UIElement.ClipToBoundsProperty>|Set `Viewport3D.ClipToBounds` to false whenever you do not need to have [!INCLUDE[TLA#tla_winclient](../../../../includes/tlasharptla-winclient-md.md)] explicitly clip the content of a <xref:System.Windows.Controls.Viewport3D> to the Viewport3D’s rectangle. [!INCLUDE[TLA#tla_winclient](../../../../includes/tlasharptla-winclient-md.md)] antialiased clipping can be very slow, and `ClipToBounds` is enabled (slow) by default on <xref:System.Windows.Controls.Viewport3D>.|  
|<xref:System.Windows.UIElement.IsHitTestVisible%2A>|Set `Viewport3D.IsHitTestVisible` to false whenever you do not need [!INCLUDE[TLA#tla_winclient](../../../../includes/tlasharptla-winclient-md.md)] to consider the content of a <xref:System.Windows.Controls.Viewport3D> when performing mouse hit testing.  Hit testing 3D content is done in software and can be slow with large meshes. <xref:System.Windows.UIElement.IsHitTestVisible%2A> is enabled (slow) by default on <xref:System.Windows.Controls.Viewport3D>.|  
|<xref:System.Windows.Media.Media3D.GeometryModel3D>|Create different models only when they require different Materials or Transforms.  Otherwise, try to coalesce many <xref:System.Windows.Media.Media3D.GeometryModel3D> instances with the same Materials and Transforms into a few larger <xref:System.Windows.Media.Media3D.GeometryModel3D> and <xref:System.Windows.Media.Media3D.MeshGeometry3D> instances.|  
|<xref:System.Windows.Media.Media3D.MeshGeometry3D>|Mesh animation—changing the individual vertices of a mesh on a per-frame basis—is not always efficient in [!INCLUDE[TLA#tla_winclient](../../../../includes/tlasharptla-winclient-md.md)].  To minimize the performance impact of change notifications when each vertex is modified, detach the mesh from the visual tree before performing per-vertex modification.  Once the mesh has been modified, reattach it to the visual tree.  Also, try to minimize the size of meshes that will be animated in this way.|  
|3D Antialiasing|To increase rendering speed, disable multisampling on a <xref:System.Windows.Controls.Viewport3D> by setting the attached property <xref:System.Windows.Media.RenderOptions.EdgeMode%2A> to `Aliased`.  By default, 3D antialiasing is disabled on [!INCLUDE[TLA#tla_winxp](../../../../includes/tlasharptla-winxp-md.md)] and enabled on [!INCLUDE[TLA#tla_longhorn](../../../../includes/tlasharptla-longhorn-md.md)] with 4 samples per pixel.|  
|Text|Live text in a 3D scene (live because it’s in a <xref:System.Windows.Media.DrawingBrush> or <xref:System.Windows.Media.VisualBrush>) can be slow. Try to use images of the text instead (via <xref:System.Windows.Media.Imaging.RenderTargetBitmap>) unless the text will change.|  
|<xref:System.Windows.Media.TileBrush>|If you must use a <xref:System.Windows.Media.VisualBrush> or a <xref:System.Windows.Media.DrawingBrush> in a 3D scene because the brush’s content is not static, try caching the brush (setting the attached property <xref:System.Windows.Media.RenderOptions.CachingHint%2A> to `Cache`).  Set the minimum and maximum scale invalidation thresholds (with the attached properties <xref:System.Windows.Media.RenderOptions.CacheInvalidationThresholdMinimum%2A> and <xref:System.Windows.Media.RenderOptions.CacheInvalidationThresholdMaximum%2A>) so that the cached brushes won’t be regenerated too frequently, while still maintaining your desired level of quality.  By default, <xref:System.Windows.Media.DrawingBrush> and <xref:System.Windows.Media.VisualBrush> are not cached, meaning that every time something painted with the brush has to be re-rendered, the entire content of the brush must first be re-rendered to an intermediate surface.|  
|<xref:System.Windows.Media.Effects.BitmapEffect>|<xref:System.Windows.Media.Effects.BitmapEffect> forces all affected content to be rendered without hardware acceleration.  For best performance, do not use <xref:System.Windows.Media.Effects.BitmapEffect>.|  
  
## Performance Impact: Medium  
  
|Property|Recommendation|  
|-|-|  
|<xref:System.Windows.Media.Media3D.MeshGeometry3D>|When a mesh is defined as abutting triangles with shared vertices and those vertices have the same position, normal, and texture coordinates, define each shared vertex only once and then define your triangles by index with <xref:System.Windows.Media.Media3D.MeshGeometry3D.TriangleIndices%2A>.|  
|<xref:System.Windows.Media.ImageBrush>|Try to minimize texture sizes when you have explicit control over the size (when you’re using a <xref:System.Windows.Media.Imaging.RenderTargetBitmap> and/or an <xref:System.Windows.Media.ImageBrush>).  Note that lower resolution textures can decrease visual quality, so try to find the right balance between quality and performance.|  
|Opacity|When rendering translucent 3D content (such as reflections), use the opacity properties on brushes or materials (via <xref:System.Windows.Media.Brush.Opacity%2A> or <xref:System.Windows.Media.Media3D.DiffuseMaterial.Color%2A>) instead of creating a separate translucent <xref:System.Windows.Controls.Viewport3D> by setting `Viewport3D.Opacity` to a value less than 1.|  
|<xref:System.Windows.Controls.Viewport3D>|Minimize the number of <xref:System.Windows.Controls.Viewport3D> objects you’re using in a scene.  Put many 3D models in the same Viewport3D rather than creating separate Viewport3D instances for each model.|  
|<xref:System.Windows.Freezable>|Typically it’s beneficial to reuse <xref:System.Windows.Media.Media3D.MeshGeometry3D>, <xref:System.Windows.Media.Media3D.GeometryModel3D>, Brushes, and Materials.  All are multiparentable since they’re derived from `Freezable`.|  
|<xref:System.Windows.Freezable>|Call the <xref:System.Windows.Freezable.Freeze%2A> method on Freezables when their properties will remain unchanged in your application.  Freezing can decrease working set and increase speed.|  
|<xref:System.Windows.Media.Brush>|Use <xref:System.Windows.Media.ImageBrush> instead of <xref:System.Windows.Media.VisualBrush> or <xref:System.Windows.Media.DrawingBrush> when the content of the brush will not change.  2D content can be converted to an <xref:System.Windows.Controls.Image> via <xref:System.Windows.Media.Imaging.RenderTargetBitmap> and then used in an <xref:System.Windows.Media.ImageBrush>.|  
|<xref:System.Windows.Media.Media3D.GeometryModel3D.BackMaterial%2A>|Don’t use <xref:System.Windows.Media.Media3D.GeometryModel3D.BackMaterial%2A> unless you actually need to see the back faces of your <xref:System.Windows.Media.Media3D.GeometryModel3D>.|  
|<xref:System.Windows.Media.Media3D.Light>|Light speed (fastest to slowest):<br /><br /> <xref:System.Windows.Media.Media3D.AmbientLight><br /><br /> <xref:System.Windows.Media.Media3D.DirectionalLight><br /><br /> <xref:System.Windows.Media.Media3D.PointLight><br /><br /> <xref:System.Windows.Media.Media3D.SpotLight>|  
|<xref:System.Windows.Media.Media3D.MeshGeometry3D>|Try to keep mesh sizes under these limits:<br /><br /> <xref:System.Windows.Media.Media3D.MeshGeometry3D.Positions%2A>: 20,001 <xref:System.Windows.Media.Media3D.Point3D> instances<br /><br /> <xref:System.Windows.Media.Media3D.MeshGeometry3D.TriangleIndices%2A>: 60,003 <xref:System.Int32> instances|  
|<xref:System.Windows.Media.Media3D.Material>|Material speed (fastest to slowest):<br /><br /> <xref:System.Windows.Media.Media3D.EmissiveMaterial><br /><br /> <xref:System.Windows.Media.Media3D.DiffuseMaterial><br /><br /> <xref:System.Windows.Media.Media3D.SpecularMaterial>|  
|<xref:System.Windows.Media.Brush>|[!INCLUDE[TLA#tla_winclient](../../../../includes/tlasharptla-winclient-md.md)] 3D doesn't opt out of invisible brushes (black ambient brushes, clear brushes, etc.) in a consistent way.  Consider omitting these from your scene.|  
|<xref:System.Windows.Media.Media3D.MaterialGroup>|Each <xref:System.Windows.Media.Media3D.Material> in a <xref:System.Windows.Media.Media3D.MaterialGroup> causes another rendering pass, so including many materials, even simple materials, can dramatically increase the fill demands on your GPU.  Minimize the number of materials in your <xref:System.Windows.Media.Media3D.MaterialGroup>.|  
  
## Performance Impact: Low  
  
|Property|Recommendation|  
|-|-|  
|<xref:System.Windows.Media.Media3D.Transform3DGroup>|When you don’t need animation or data binding, instead of using a transform group containing multiple transforms, use a single <xref:System.Windows.Media.Media3D.MatrixTransform3D>, setting it to be the product of all the transforms that would otherwise exist independently in the transform group.|  
|<xref:System.Windows.Media.Media3D.Light>|Minimize the number of lights in your scene. Too many lights in a scene will force [!INCLUDE[TLA#tla_winclient](../../../../includes/tlasharptla-winclient-md.md)] to fall back to software rendering.  The limits are roughly 110 <xref:System.Windows.Media.Media3D.DirectionalLight> objects, 70 <xref:System.Windows.Media.Media3D.PointLight> objects, or 40 <xref:System.Windows.Media.Media3D.SpotLight> objects.|  
|<xref:System.Windows.Media.Media3D.ModelVisual3D>|Separate moving objects from static objects by putting them in separate <xref:System.Windows.Media.Media3D.ModelVisual3D> instances.  ModelVisual3D is "heavier" than <xref:System.Windows.Media.Media3D.GeometryModel3D> because it caches transformed bounds.  GeometryModel3D is optimized to be a model; ModelVisual3D is optimized to be a scene node.  Use ModelVisual3D to put shared instances of GeometryModel3D into the scene.|  
|<xref:System.Windows.Media.Media3D.Light>|Minimize the number of times you change the number of lights in the scene.  Each change of light count forces a shader regeneration and recompilation unless that configuration has existed previously (and thus had its shader cached).|  
|Light|Black lights won’t be visible, but they will add to render time; consider omitting them.|  
|<xref:System.Windows.Media.Media3D.MeshGeometry3D>|To minimize the construction time of large collections in [!INCLUDE[TLA#tla_winclient](../../../../includes/tlasharptla-winclient-md.md)], such as a MeshGeometry3D’s <xref:System.Windows.Media.Media3D.MeshGeometry3D.Positions%2A>, <xref:System.Windows.Media.Media3D.MeshGeometry3D.Normals%2A>, <xref:System.Windows.Media.Media3D.MeshGeometry3D.TextureCoordinates%2A>, and <xref:System.Windows.Media.Media3D.MeshGeometry3D.TriangleIndices%2A>, pre-size the collections before value population. If possible, pass the collections’ constructors prepopulated data structures such as arrays or Lists.|  
  
## See Also  
 [3-D Graphics Overview](../../../../docs/framework/wpf/graphics-multimedia/3-d-graphics-overview.md)
