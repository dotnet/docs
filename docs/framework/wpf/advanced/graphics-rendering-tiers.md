---
title: "Graphics Rendering Tiers"
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
  - "rendering graphics [WPF]"
  - "rendering tiers [WPF]"
  - "graphics rendering tiers [WPF]"
  - "graphics [WPF], rendering tiers"
ms.assetid: 08dd1606-02a2-4122-9351-c0afd2ec3a70
caps.latest.revision: 44
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Graphics Rendering Tiers
A rendering tier defines a level of graphics hardware capability and performance for a device that runs a [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] application.  
  

  
<a name="graphics_hardware"></a>   
## Graphics Hardware  
 The features of the graphics hardware that most impact the rendering tier levels are:  
  
-   **Video RAM** The amount of video memory on the graphics hardware determines the size and number of buffers that can be used for compositing graphics.  
  
-   **Pixel Shader** A pixel shader is a graphics processing function that calculates effects on a per-pixel basis. Depending on the resolution of the displayed graphics, there could be several million pixels that need to be processed for each display frame.  
  
-   **Vertex Shader** A vertex shader is a graphics processing function that performs mathematical operations on the vertex data of the object.  
  
-   **Multitexture Support** Multitexture support refers to the ability to apply two or more distinct textures during a blending operation on a 3D graphics object. The degree of multitexture support is determined by the number of multitexture units on the graphics hardware.  
  
<a name="rendering_tier_definitions"></a>   
## Rendering Tier Definitions  
 The features of the graphics hardware determine the rendering capability of a [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] application. The [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] system defines three rendering tiers:  
  
-   **Rendering Tier 0** No graphics hardware acceleration. All graphics features use software acceleration. The [!INCLUDE[TLA2#tla_dx](../../../../includes/tla2sharptla-dx-md.md)] version level is less than version 9.0.  
  
-   **Rendering Tier 1** Some graphics features use graphics hardware acceleration. The [!INCLUDE[TLA2#tla_dx](../../../../includes/tla2sharptla-dx-md.md)] version level is greater than or equal to version 9.0.  
  
-   **Rendering Tier 2** Most graphics features use graphics hardware acceleration. The [!INCLUDE[TLA2#tla_dx](../../../../includes/tla2sharptla-dx-md.md)] version level is greater than or equal to version 9.0.  
  
 The <xref:System.Windows.Media.RenderCapability.Tier%2A?displayProperty=nameWithType> property allows you to retrieve the rendering tier at application run time. You use the rendering tier to determine whether the device supports certain hardware-accelerated graphics features. Your application can then take different code paths at run time depending on the rendering tier supported by the device.  
  
### Rendering Tier 0  
 A rendering tier value of 0 means that there is no graphics hardware acceleration available for the application on the device. At this tier level, you should assume that all graphics will be rendered by software with no hardware acceleration. This tier's functionality corresponds to a [!INCLUDE[TLA2#tla_dx](../../../../includes/tla2sharptla-dx-md.md)] version that is less than 9.0.  
  
### Rendering Tier 1 and Rendering Tier 2  
  
> [!NOTE]
>  Starting in the .NET Framework 4, rendering tier 1 has been redefined to only include graphics hardware that supports [!INCLUDE[TLA2#tla_dx](../../../../includes/tla2sharptla-dx-md.md)] 9.0 or greater. Graphics hardware that supports [!INCLUDE[TLA2#tla_dx](../../../../includes/tla2sharptla-dx-md.md)] 7 or 8 is now defined as rendering tier 0.  
  
 A rendering tier value of 1 or 2 means that most of the graphics features of [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] will use hardware acceleration if the necessary system resources are available and have not been exhausted. This corresponds to a [!INCLUDE[TLA2#tla_dx](../../../../includes/tla2sharptla-dx-md.md)] version that is greater than or equal to 9.0.  
  
 The following table shows the differences in graphics hardware requirements for rendering tier 1 and rendering tier 2:  
  
|Feature|Tier 1|Tier 2|  
|-------------|------------|------------|  
|[!INCLUDE[TLA2#tla_dx](../../../../includes/tla2sharptla-dx-md.md)] version|Must be greater than or equal to 9.0.|Must be greater than or equal to 9.0.|  
|Video RAM|Must be greater than or equal to 60MB.|Must be greater than or equal to 120MB.|  
|Pixel shader|Version level must greater than or equal to 2.0.|Version level must greater than or equal to 2.0.|  
|Vertex shader|No requirement.|Version level must greater than or equal to 2.0.|  
|Multitexture units|No requirement.|Number of units must greater than or equal to 4.|  
  
 The following features and capabilities are hardware accelerated for rendering tier 1 and rendering tier 2:  
  
|Feature|Notes|  
|-------------|-----------|  
|2D rendering|Most 2D rendering is supported.|  
|3D rasterization|Most 3D rasterization is supported.|  
|3D anisotropic filtering|[!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] attempts to use anisotropic filtering when rendering 3D content. Anisotropic filtering refers to enhancing the image quality of textures on surfaces that are far away and steeply angled with respect to the camera.|  
|3D MIP mapping|[!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] attempts to use MIP mapping when rendering 3D content. MIP mapping improves the quality of texture rendering when a texture occupies a smaller field of view in a <xref:System.Windows.Controls.Viewport3D>.|  
|Radial gradients|While supported, avoid the use of <xref:System.Windows.Media.RadialGradientBrush> on large objects.|  
|3D lighting calculations|[!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] performs per-vertex lighting, which means that a light intensity must be calculated at each vertex for each material applied to a mesh.|  
|Text rendering|Sub-pixel font rendering uses available pixel shaders on the graphics hardware.|  
  
 The following features and capabilities are hardware accelerated only for rendering tier 2:  
  
|Feature|Notes|  
|-------------|-----------|  
|3D anti-aliasing|3D anti-aliasing is supported only on operating systems that support Windows Display Driver Model (WDDM), such as [!INCLUDE[TLA2#tla_winvista](../../../../includes/tla2sharptla-winvista-md.md)] and [!INCLUDE[win7](../../../../includes/win7-md.md)].|  
  
 The following features and capabilities are **not** hardware accelerated:  
  
|Feature|Notes|  
|-------------|-----------|  
|Printed content|All printed content is rendered using the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] software pipeline.|  
|Rasterized content that uses <xref:System.Windows.Media.Imaging.RenderTargetBitmap>|Any content rendered by using the <xref:System.Windows.Media.Imaging.RenderTargetBitmap.Render%2A> method of <xref:System.Windows.Media.Imaging.RenderTargetBitmap>.|  
|Tiled content that uses <xref:System.Windows.Media.TileBrush>|Any tiled content in which the <xref:System.Windows.Media.TileBrush.TileMode%2A> property of the <xref:System.Windows.Media.TileBrush> is set to <xref:System.Windows.Media.TileMode.Tile>.|  
|Surfaces that exceed the maximum texture size of the graphics hardware|For most graphics hardware, large surfaces are 2048x2048 or 4096x4096 pixels in size.|  
|Any operation whose video RAM requirement exceeds the memory of the graphics hardware|You can monitor application video RAM usage by using the Perforator tool that is included in the [WPF Performance Suite](http://msdn.microsoft.com/library/67cafaad-57ad-4ecb-9c08-57fac144393e) in the Windows SDK.|  
|Layered windows|Layered windows allow [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] applications to render content to the screen in a non-rectangular window. On operating systems that support Windows Display Driver Model (WDDM), such as [!INCLUDE[TLA2#tla_winvista](../../../../includes/tla2sharptla-winvista-md.md)] and [!INCLUDE[win7](../../../../includes/win7-md.md)], layered windows are hardware accelerated. On other systems, such as [!INCLUDE[winxp](../../../../includes/winxp-md.md)], layered windows are rendered by software with no hardware acceleration.<br /><br /> You can enable layered windows in [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] by setting the following <xref:System.Windows.Window> properties:<br /><br /> -   <xref:System.Windows.Window.WindowStyle%2A> = <xref:System.Windows.WindowStyle.None><br />-   <xref:System.Windows.Window.AllowsTransparency%2A> = `true`<br />-   <xref:System.Windows.Controls.Control.Background%2A> = <xref:System.Windows.Media.Brushes.Transparent%2A>|  
  
<a name="other_resources"></a>   
## Other Resources  
 The following resources can help you analyze the performance characteristics of your [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] application.  
  
### Graphics Rendering Registry Settings  
 [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] provides four registry settings for controlling [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] rendering:  
  
|Setting|Description|  
|-------------|-----------------|  
|**Disable Hardware Acceleration Option**|Specifies whether hardware acceleration should be enabled.|  
|**Maximum Multisample Value**|Specifies the degree of multisampling for antialiasing [!INCLUDE[TLA2#tla_3d](../../../../includes/tla2sharptla-3d-md.md)] content.|  
|**Required Video Driver Date Setting**|Specifies whether the system disables hardware acceleration for drivers released before November 2004.|  
|**Use Reference Rasterizer Option**|Specifies whether [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] should use the reference rasterizer.|  
  
 These settings can be accessed by any external configuration utility that knows how to reference the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] registry settings. These settings can also be created or modified by accessing the values directly by using the [!INCLUDE[TLA#tla_mswin](../../../../includes/tlasharptla-mswin-md.md)] Registry Editor. For more information, see [Graphics Rendering Registry Settings](../../../../docs/framework/wpf/graphics-multimedia/graphics-rendering-registry-settings.md).  
  
### WPF Performance Profiling Tools  
 [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] provides a suite of performance profiling tools that allow you to analyze the run-time behavior of your application and determine the types of performance optimizations you can apply. The following table lists the performance profiling tools that are included in the [!INCLUDE[TLA2#tla_lhsdk](../../../../includes/tla2sharptla-lhsdk-md.md)] tool, WPF Performance Suite:  
  
|Tool|Description|  
|----------|-----------------|  
|Perforator|Use for analyzing rendering behavior.|  
|Visual Profiler|Use for profiling the use of [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] services, such as layout and event handling, by elements in the visual tree.|  
  
 The WPF Performance Suite provides a rich, graphical view of performance data. For more information about WPF performance tools, see [WPF Performance Suite](http://msdn.microsoft.com/library/67cafaad-57ad-4ecb-9c08-57fac144393e).  
  
### DirectX Diagnostic Tool  
 The [!INCLUDE[TLA2#tla_dx](../../../../includes/tla2sharptla-dx-md.md)] Diagnostic Tool, Dxdiag.exe, is designed to help you troubleshoot [!INCLUDE[TLA2#tla_dx](../../../../includes/tla2sharptla-dx-md.md)]-related issues. The default installation folder for the [!INCLUDE[TLA2#tla_dx](../../../../includes/tla2sharptla-dx-md.md)] Diagnostic Tool is:  
  
 `~\Windows\System32`  
  
 When you run the [!INCLUDE[TLA2#tla_dx](../../../../includes/tla2sharptla-dx-md.md)] Diagnostic Tool, the main window contains a set of tabs that allow you to display and diagnose [!INCLUDE[TLA2#tla_dx](../../../../includes/tla2sharptla-dx-md.md)]-related information. For example, the **System** tab provides system information about your computer and specifies the version of [!INCLUDE[TLA2#tla_dx](../../../../includes/tla2sharptla-dx-md.md)] that is installed on your computer.  
  
 ![Screenhot: DirectX Diagnostic Tool](../../../../docs/framework/wpf/advanced/media/directxdiagnostictool-01.png "DirectXDiagnosticTool_01")  
DirectX Diagnostic Tool main window  
  
## See Also  
 <xref:System.Windows.Media.RenderCapability>  
 <xref:System.Windows.Media.RenderOptions>  
 [Optimizing WPF Application Performance](../../../../docs/framework/wpf/advanced/optimizing-wpf-application-performance.md)  
 [WPF Performance Suite](http://msdn.microsoft.com/library/67cafaad-57ad-4ecb-9c08-57fac144393e)  
 [Graphics Rendering Registry Settings](../../../../docs/framework/wpf/graphics-multimedia/graphics-rendering-registry-settings.md)  
 [Animation Tips and Tricks](../../../../docs/framework/wpf/graphics-multimedia/animation-tips-and-tricks.md)
