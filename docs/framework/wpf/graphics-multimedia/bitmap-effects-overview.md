---
title: "Bitmap Effects Overview"
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
  - "bitmap effects [WPF]"
ms.assetid: 23cb338e-4b59-4b52-b294-96431f9c9568
caps.latest.revision: 34
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Bitmap Effects Overview
Bitmap effects enable designers and developers to apply visual effects to rendered [!INCLUDE[TLA#tla_wpf](../../../../includes/tlasharptla-wpf-md.md)] content. For example, bitmap effects allow you to easily apply a <xref:System.Windows.Media.Effects.DropShadowBitmapEffect> effect or a blur effect to an image or a button.  
  
> [!IMPORTANT]
>  In the [!INCLUDE[net_v40_short](../../../../includes/net-v40-short-md.md)] or later, the <xref:System.Windows.Media.Effects.BitmapEffect> class is obsolete. If you try to use the <xref:System.Windows.Media.Effects.BitmapEffect> class, you will get an obsolete exception. The non-obsolete alternative to the <xref:System.Windows.Media.Effects.BitmapEffect> class is the <xref:System.Windows.Media.Effects.Effect> class. In most situations, the <xref:System.Windows.Media.Effects.Effect> class is significantly faster.  
  
  
  
<a name="wpf_effects"></a>   
## WPF Bitmap Effects  
 Bitmap effects (<xref:System.Windows.Media.Effects.BitmapEffect> object) are simple pixel processing operations. A bitmap effect takes a <xref:System.Windows.Media.Imaging.BitmapSource> as an input and produces a new <xref:System.Windows.Media.Imaging.BitmapSource> after applying the effect, such as a blur or drop shadow. Each bitmap effect exposes properties that can control the filtering properties, such as <xref:System.Windows.Media.Effects.BlurBitmapEffect.Radius%2A> of <xref:System.Windows.Media.Effects.BlurBitmapEffect>.  
  
 As a special case, in [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)], effects can be set as properties on live <xref:System.Windows.Media.Visual> objects, such as a <xref:System.Windows.Controls.Button> or <xref:System.Windows.Controls.TextBox>. The pixel processing is applied and rendered at run-time. In this case, at the time of rendering, a <xref:System.Windows.Media.Visual> is automatically converted to its <xref:System.Windows.Media.Imaging.BitmapSource> equivalent and is fed as input to the <xref:System.Windows.Media.Effects.BitmapEffect>. The output replaces the <xref:System.Windows.Media.Visual> object's default rendering behavior. This is why <xref:System.Windows.Media.Effects.BitmapEffect> objects force visuals to render in software only i.e. no hardware acceleration on visuals when effects are applied.  
  
-   <xref:System.Windows.Media.Effects.BlurBitmapEffect> simulates an object that appears out-of-focus.  
  
-   <xref:System.Windows.Media.Effects.OuterGlowBitmapEffect> creates a halo of color around the perimeter of an object.  
  
-   <xref:System.Windows.Media.Effects.DropShadowBitmapEffect> creates a shadow behind an object.  
  
-   <xref:System.Windows.Media.Effects.BevelBitmapEffect> creates a bevel which raises the surface of an image according to a specified curve.  
  
-   <xref:System.Windows.Media.Effects.EmbossBitmapEffect> creates a bump mapping of a <xref:System.Windows.Media.Visual> to give the impression of depth and texture from an artificial light source.  
  
> [!NOTE]
>  [!INCLUDE[TLA2#tla_wpf](../../../../includes/tla2sharptla-wpf-md.md)] bitmap effects are rendered in software mode. Any object that applies an effect will also be rendered in software. Performance is degraded the most when using Bitmap effects on large visuals or animating properties of a Bitmap effect. This is not to say that you should not use Bitmap effects in this way at all, but you should use caution and test thoroughly to ensure that your users are getting the experience you expect.  
  
> [!NOTE]
>  [!INCLUDE[TLA2#tla_wpf](../../../../includes/tla2sharptla-wpf-md.md)] bitmap effects do not support partial trust execution. An application must have full trust permissions to use bitmap effects.  
  
<a name="applyeffects"></a>   
## How to Apply an Effect  
 <xref:System.Windows.Media.Effects.BitmapEffect> is a property on <xref:System.Windows.Media.Visual>. Therefore applying effects to Visuals, such as a <xref:System.Windows.Controls.Button>, <xref:System.Windows.Controls.Image>, <xref:System.Windows.Media.DrawingVisual>, or <xref:System.Windows.UIElement>, is as easy as setting a property. <xref:System.Windows.UIElement.BitmapEffect%2A> can be set to a single <xref:System.Windows.Media.Effects.BitmapEffect> object or multiple effects can be chained by using the <xref:System.Windows.Media.Effects.BitmapEffectGroup> object.  
  
 The following example demonstrates how to apply a <xref:System.Windows.Media.Effects.BitmapEffect> in [!INCLUDE[TLA#tla_xaml](../../../../includes/tlasharptla-xaml-md.md)].  
  
 [!code-xaml[EffectsGallery_snip#BlurSimpleExampleInline](../../../../samples/snippets/csharp/VS_Snippets_Wpf/EffectsGallery_snip/CSharp/blursimpleexample.xaml#blursimpleexampleinline)]  
  
 The following example demonstrates how to apply a <xref:System.Windows.Media.Effects.BitmapEffect> in code.  
  
 [!code-csharp[EffectsGallery_snip#CodeBehindBlurCodeBehindExampleInline](../../../../samples/snippets/csharp/VS_Snippets_Wpf/EffectsGallery_snip/CSharp/blurcodebehindexample.xaml.cs#codebehindblurcodebehindexampleinline)]  
  
> [!NOTE]
>  When a <xref:System.Windows.Media.Effects.BitmapEffect> is applied to a layout container, such as <xref:System.Windows.Controls.DockPanel> or <xref:System.Windows.Controls.Canvas>, the effect is applied to the visual tree of the element or visual, including all of its child elements.  
  
<a name="customeffects"></a>   
## Creating Custom Effects  
 [!INCLUDE[TLA2#tla_wpf](../../../../includes/tla2sharptla-wpf-md.md)] also provides unmanaged interfaces to create custom effects that can be used in managed [!INCLUDE[TLA2#tla_wpf](../../../../includes/tla2sharptla-wpf-md.md)] applications. For additional reference material for creating custom bitmap effects, see the [Unmanaged WPF Bitmap Effect](https://msdn.microsoft.com/library/ms735092.aspx) documentation.  
  
## See Also  
 <xref:System.Windows.Media.Effects.BitmapEffectGroup>  
 <xref:System.Windows.Media.Effects.BitmapEffectInput>  
 <xref:System.Windows.Media.Effects.BitmapEffectCollection>  
 [Unmanaged WPF Bitmap Effect](https://msdn.microsoft.com/library/ms735092.aspx)  
 [Imaging Overview](../../../../docs/framework/wpf/graphics-multimedia/imaging-overview.md)  
 [Security](../../../../docs/framework/wpf/security-wpf.md)  
 [WPF Graphics Rendering Overview](../../../../docs/framework/wpf/graphics-multimedia/wpf-graphics-rendering-overview.md)  
 [2D Graphics and Imaging](../../../../docs/framework/wpf/advanced/optimizing-performance-2d-graphics-and-imaging.md)
