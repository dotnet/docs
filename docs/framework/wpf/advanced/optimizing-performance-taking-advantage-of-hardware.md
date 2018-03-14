---
title: "Optimizing Performance: Taking Advantage of Hardware"
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
  - "graphics [WPF], performance"
  - "hardware rendering pipeline [WPF]"
  - "rendering tiers [WPF]"
  - "graphics rendering tiers [WPF]"
  - "graphics [WPF], rendering tiers"
  - "software rendering pipeline [WPF]"
ms.assetid: bfb89bae-7aab-4cac-a26c-a956eda8fce2
caps.latest.revision: 6
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Optimizing Performance: Taking Advantage of Hardware
The internal architecture of [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] has two rendering pipelines, hardware and software. This topic provides information about these rendering pipelines to help you make decisions about performance optimizations of your applications.  
  
## Hardware Rendering Pipeline  
 One of the most important factors in determining [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] performance is that it is render bound—the more pixels you have to render, the greater the performance cost. However, the more rendering that can be offloaded to the [!INCLUDE[TLA#tla_gpu](../../../../includes/tlasharptla-gpu-md.md)], the more performance benefits you can gain. The [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] application hardware rendering pipeline takes full advantage of [!INCLUDE[TLA#tla_dx](../../../../includes/tlasharptla-dx-md.md)] features on hardware that supports a minimum of [!INCLUDE[TLA#tla_dx](../../../../includes/tlasharptla-dx-md.md)] version 7.0. Further optimizations can be gained by hardware that supports [!INCLUDE[TLA#tla_dx](../../../../includes/tlasharptla-dx-md.md)] version 7.0 and PixelShader 2.0+ features.  
  
## Software Rendering Pipeline  
 The [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] software rendering pipeline is entirely CPU bound. [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] takes advantage of the SSE and SSE2 instruction sets in the CPU to implement an optimized, fully-featured software rasterizer. Fallback to software is seamless any time application functionality cannot be rendered using the hardware rendering pipeline.  
  
 The biggest performance issue you will encounter when rendering in software mode is related to fill rate, which is defined as the number of pixels that you are rendering. If you are concerned about performance in software rendering mode, try to minimize the number of times a pixel is redrawn. For example, if you have an application with a blue background, which then renders a slightly transparent image over it, you will render all of the pixels in the application twice. As a result, it will take twice as long to render the application with the image than if you had only the blue background.  
  
### Graphics Rendering Tiers  
 It may be very difficult to predict the hardware configuration that your application will be running on. However, you might want to consider a design that allows your application to seamlessly switch features when running on different hardware, so that it can take full advantage of each different hardware configuration.  
  
 To achieve this, [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] provides functionality to determine the graphics capability of a system at runtime. Graphics capability is determined by categorizing the video card as one of three rendering capability tiers. [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] exposes an [!INCLUDE[TLA#tla_api](../../../../includes/tlasharptla-api-md.md)] that allows an application to query the rendering capability tier. Your application can then take different code paths at run time depending on the rendering tier supported by the hardware.  
  
 The features of the graphics hardware that most impact the rendering tier levels are:  
  
-   **Video RAM** The amount of video memory on the graphics hardware determines the size and number of buffers that can be used for compositing graphics.  
  
-   **Pixel Shader** A pixel shader is a graphics processing function that calculates effects on a per-pixel basis. Depending on the resolution of the displayed graphics, there could be several million pixels that need to be processed for each display frame.  
  
-   **Vertex Shader** A vertex shader is a graphics processing function that performs mathematical operations on the vertex data of the object.  
  
-   **Multitexture Support** Multitexture support refers to the ability to apply two or more distinct textures during a blending operation on a 3D graphics object. The degree of multitexture support is determined by the number of multitexture units on the graphics hardware.  
  
 The pixel shader, vertex shader, and multitexture features are used to define specific [!INCLUDE[TLA2#tla_dx](../../../../includes/tla2sharptla-dx-md.md)] version levels, which, in turn, are used to define the different rendering tiers in [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)].  
  
 The features of the graphics hardware determine the rendering capability of a [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] application. The [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] system defines three rendering tiers:  
  
-   **Rendering Tier 0** No graphics hardware acceleration. The [!INCLUDE[TLA2#tla_dx](../../../../includes/tla2sharptla-dx-md.md)] version level is less than version 7.0.  
  
-   **Rendering Tier 1** Partial graphics hardware acceleration. The [!INCLUDE[TLA2#tla_dx](../../../../includes/tla2sharptla-dx-md.md)] version level is greater than or equal to version 7.0, and **lesser** than version 9.0.  
  
-   **Rendering Tier 2** Most graphics features use graphics hardware acceleration. The [!INCLUDE[TLA2#tla_dx](../../../../includes/tla2sharptla-dx-md.md)] version level is greater than or equal to version 9.0.  
  
 For more information on [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] rendering tiers, see [Graphics Rendering Tiers](../../../../docs/framework/wpf/advanced/graphics-rendering-tiers.md).  
  
## See Also  
 [Optimizing WPF Application Performance](../../../../docs/framework/wpf/advanced/optimizing-wpf-application-performance.md)  
 [Planning for Application Performance](../../../../docs/framework/wpf/advanced/planning-for-application-performance.md)  
 [Layout and Design](../../../../docs/framework/wpf/advanced/optimizing-performance-layout-and-design.md)  
 [2D Graphics and Imaging](../../../../docs/framework/wpf/advanced/optimizing-performance-2d-graphics-and-imaging.md)  
 [Object Behavior](../../../../docs/framework/wpf/advanced/optimizing-performance-object-behavior.md)  
 [Application Resources](../../../../docs/framework/wpf/advanced/optimizing-performance-application-resources.md)  
 [Text](../../../../docs/framework/wpf/advanced/optimizing-performance-text.md)  
 [Data Binding](../../../../docs/framework/wpf/advanced/optimizing-performance-data-binding.md)  
 [Other Performance Recommendations](../../../../docs/framework/wpf/advanced/optimizing-performance-other-recommendations.md)
