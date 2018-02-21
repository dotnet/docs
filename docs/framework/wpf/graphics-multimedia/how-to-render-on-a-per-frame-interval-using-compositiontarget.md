---
title: "How to: Render on a Per Frame Interval Using CompositionTarget"
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
  - "CompositionTarget objects [WPF], rendering per frame"
  - "rendering per frame using CompositionTarget objects [WPF]"
ms.assetid: 701246cd-66b7-4d69-ada9-17b3b433d95d
caps.latest.revision: 12
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Render on a Per Frame Interval Using CompositionTarget
The [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] animation engine provides many features for creating frame-based animation. However, there are application scenarios in which you need finer-grained control over rendering on a per frame basis. The <xref:System.Windows.Media.CompositionTarget> object provides the ability to create custom animations based on a per-frame callback.  
  
 <xref:System.Windows.Media.CompositionTarget> is a static class which represents the display surface on which your application is being drawn. The <xref:System.Windows.Media.CompositionTarget.Rendering> event is raised each time the application's scene is drawn. The rendering frame rate is the number of times the scene is drawn per second.  
  
> [!NOTE]
>  For a complete code sample using <xref:System.Windows.Media.CompositionTarget>, see [Using the CompositionTarget Sample](http://go.microsoft.com/fwlink/?LinkID=160045).  
  
## Example  
 The <xref:System.Windows.Media.CompositionTarget.Rendering> event fires during the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] rendering process. The following example shows how you register an <xref:System.EventHandler> delegate to the static <xref:System.Windows.Media.CompositionTarget.Rendering> method on <xref:System.Windows.Media.CompositionTarget>.  
  
 [!code-csharp[CompositionTargetSample#CompositionTarget1](../../../../samples/snippets/csharp/VS_Snippets_Wpf/CompositionTargetSample/CSharp/Window1.xaml.cs#compositiontarget1)]
 [!code-vb[CompositionTargetSample#CompositionTarget1](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/CompositionTargetSample/visualbasic/window1.xaml.vb#compositiontarget1)]  
  
 You can use your rendering event handler method to create custom drawing content. This event handler method gets called once per frame. Each time that [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] marshals the persisted rendering data in the visual tree across to the composition scene graph, your event handler method is called. In addition, if changes to the visual tree force updates to the composition scene graph, your event handler method is also called. Note that your event handler method is called after layout has been computed. However, you can modify layout in your event handler method, which means that layout will be computed once more before rendering.  
  
 The following example shows how you can provide custom drawing in a <xref:System.Windows.Media.CompositionTarget> event handler method. In this case, the background color of the <xref:System.Windows.Controls.Canvas> is drawn with a color value based on the coordinate position of the mouse. If you move the mouse inside the <xref:System.Windows.Controls.Canvas>, its background color changes. In addition, the average frame rate is calculated, based on the current elapsed time and the total number of rendered frames.  
  
 [!code-csharp[CompositionTargetSample#CompositionTarget2](../../../../samples/snippets/csharp/VS_Snippets_Wpf/CompositionTargetSample/CSharp/Window1.xaml.cs#compositiontarget2)]
 [!code-vb[CompositionTargetSample#CompositionTarget2](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/CompositionTargetSample/visualbasic/window1.xaml.vb#compositiontarget2)]  
  
 You may discover that your custom drawing runs at different speeds on different computers. This is because your custom drawing is not frame-rate independent. Depending on the system you are running and the workload of that system, the <xref:System.Windows.Media.CompositionTarget.Rendering> event may be called a different number of times per second. For information on determining the graphics hardware capability and performance for a device that runs a [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] application, see [Graphics Rendering Tiers](../../../../docs/framework/wpf/advanced/graphics-rendering-tiers.md).  
  
 Adding or removing a rendering <xref:System.EventHandler> delegate while the event is firing will be delayed until after the event is finished firing. This is consistent with how <xref:System.MulticastDelegate>-based events are handled in the Common Language Runtime (CLR). Also note that rendering events are not guaranteed to be called in any particular order. If you have multiple <xref:System.EventHandler> delegates that rely on a particular order, you should register a single <xref:System.Windows.Media.CompositionTarget.Rendering> event and multiplex the delegates in the correct order yourself.  
  
## See Also  
 <xref:System.Windows.Media.CompositionTarget>  
 [WPF Graphics Rendering Overview](../../../../docs/framework/wpf/graphics-multimedia/wpf-graphics-rendering-overview.md)
