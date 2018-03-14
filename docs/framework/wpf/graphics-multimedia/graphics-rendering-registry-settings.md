---
title: "Graphics Rendering Registry Settings"
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
  - "rendering graphics [WPF], registry settings"
  - "rendering graphics [WPF]"
  - "rendering graphics [WPF], troubleshooting"
  - "troubleshooting graphics rendering [WPF]"
  - "graphics [WPF], rendering"
ms.assetid: f4b41b42-327d-407c-b398-3ed5f505df8b
caps.latest.revision: 18
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Graphics Rendering Registry Settings
This topic provides an overview of the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] graphics rendering registry settings that affect [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] applications.  
  

  
<a name="overview"></a>   
## When to Use Graphics Rendering Registry Settings  
 These registry settings are provided for troubleshooting, debugging, and product support purposes. Because changes to the registry affect all [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] applications, your application should never alter these registry keys automatically, or during installation.  
  
<a name="xpdmandwddm"></a>   
## What are XPDM and WDDM?  
 Some of the graphics rendering registry settings have different default values, depending on whether your video card uses an XPDM or WDDM driver. XPDM is the [!INCLUDE[TLA#tla_winxp](../../../../includes/tlasharptla-winxp-md.md)] Display Driver Model and WDDM is the Windows Display Driver Model. WDDM is available on computers running [!INCLUDE[TLA2#tla_winvista](../../../../includes/tla2sharptla-winvista-md.md)] and [!INCLUDE[win7](../../../../includes/win7-md.md)]. XPDM is available on computers running [!INCLUDE[TLA2#tla_winvista](../../../../includes/tla2sharptla-winvista-md.md)], [!INCLUDE[TLA#tla_winxp](../../../../includes/tlasharptla-winxp-md.md)], and [!INCLUDE[TLA#tla_winnetsvrfam](../../../../includes/tlasharptla-winnetsvrfam-md.md)]. For more information about WDDM, see [Windows Vista Display Driver Model Design Guide](http://go.microsoft.com/fwlink/?LinkId=178394).  
  
<a name="registry_settings"></a>   
## Registry Settings  
 [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] provides four registry settings for controlling [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] rendering:  
  
|Setting|Description|  
|-------------|-----------------|  
|**Disable Hardware Acceleration Option**|Specifies whether hardware acceleration should be enabled.|  
|**Maximum Multisample Value**|Specifies the degree of multisampling for antialiasing [!INCLUDE[TLA2#tla_3d](../../../../includes/tla2sharptla-3d-md.md)] content.|  
|**Required Video Driver Date Setting**|Specifies whether the system disables hardware acceleration for drivers released before November 2004.|  
|**Use Reference Rasterizer Option**|Specifies whether [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] should use the reference rasterizer.|  
  
 These settings can be accessed by any external configuration utility that knows how to reference the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] registry settings. These settings can also be created or modified by accessing the values directly by using the [!INCLUDE[TLA#tla_mswin](../../../../includes/tlasharptla-mswin-md.md)] Registry Editor.  
  
<a name="disablehardwareacceleration"></a>   
## Disable Hardware Acceleration Option  
  
|Registry key|Value type|  
|------------------|----------------|  
|`HKEY_CURRENT_USER\SOFTWARE\Microsoft\Avalon.Graphics\DisableHWAcceleration`|DWORD|  
  
 The **disable hardware acceleration option** enables you to turn off hardware acceleration for debugging and test purposes. When you see rendering artifacts in an application, try turning off hardware acceleration. If the artifact disappears, the problem might be with your video driver.  
  
 The **disable hardware acceleration option** is a DWORD value that is either 0 or 1. A value of 1 disables hardware acceleration. A value of 0 enables hardware acceleration, provided the system meets hardware acceleration requirements; for more information, see [Graphics Rendering Tiers](../../../../docs/framework/wpf/advanced/graphics-rendering-tiers.md).  
  
<a name="maxmultisample"></a>   
## Maximum Multisample Value  
  
|Registry key|Value type|  
|------------------|----------------|  
|`HKEY_CURRENT_USER\SOFTWARE\Microsoft\Avalon.Graphics\MaxMultisampleType`|DWORD|  
  
 The **maximum multisample value** enables you to adjust the maximum amount of antialiasing of [!INCLUDE[TLA2#tla_3d](../../../../includes/tla2sharptla-3d-md.md)] content. Use this level to disable [!INCLUDE[TLA2#tla_3d](../../../../includes/tla2sharptla-3d-md.md)] antialiasing in [!INCLUDE[TLA2#tla_winvista](../../../../includes/tla2sharptla-winvista-md.md)] or enable it in [!INCLUDE[TLA#tla_winxp](../../../../includes/tlasharptla-winxp-md.md)].  
  
 The **maximum multisample value** is a DWORD value that ranges from 0 to 16. A value of 0 specifies that multisample antialiasing of 3-D content should be disabled, and a value of 16 will attempt to use up to 16x multisample antialiasing, if supported by the video card. Beware that setting this registry key value on computers using XPDM drivers will cause applications to use a large amount of additional video memory, decrease the performance of [!INCLUDE[TLA2#tla_3d](../../../../includes/tla2sharptla-3d-md.md)] rendering, and has the potential to introduce rendering errors and stability problems.  
  
 When this registry key is not set, [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] defaults to 0 for XPDM drivers and 4 for WDDM drivers.  
  
<a name="requiredvideodriverdatesetting"></a>   
## Required Video Driver Date Setting  
  
|Registry key|Value type|  
|------------------|----------------|  
|`HKEY_CURRENT_USER\SOFTWARE\Microsoft\Avalon.Graphics\RequiredVideoDriverDate`|String|  
  
 In November, 2004, [!INCLUDE[TLA#tla_ms](../../../../includes/tlasharptla-ms-md.md)] released a new version of the driver testing guidelines; the drivers written after this date offer better stability. By default, [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] will use the hardware acceleration pipeline for these drivers and will fall back to software rendering for XPDM drivers published before this date.  
  
 The **required video driver date setting** enables you to specify an alternate minimum date for XPDM drivers. You should only specify a date earlier than November, 2004 if you are confident that your video driver is stable enough to support [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)].  
  
 The required video driver setting takes a string of the following format:  
  
||  
|-|  
|*YYYY* `/` *MM* `/` *DD*|  
  
 Where *YYYY* is the four-digit year, *MM* is the two-digit month, and *DD* is the two digit day. When this value is unset, [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] uses November, 2004 as its required video driver date.  
  
<a name="usereferencerasterizeroption"></a>   
## Use Reference Rasterizer Option  
  
|Registry key|Value type|  
|------------------|----------------|  
|`HKEY_CURRENT_USER\SOFTWARE\Microsoft\Avalon.Graphics\UseReferenceRasterizer`|DWORD|  
  
 The **use reference rasterizer option** enables you to force [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] into a simulated hardware rendering mode for debugging: [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] goes into hardware mode, but uses the [!INCLUDE[TLA#tla_d3d](../../../../includes/tlasharptla-d3d-md.md)] reference software rasterizer, d3dref9.dll, instead of an actual hardware device.  
  
 The reference rasterizer is very slow, but bypasses your video driver to avoid any rendering issues caused by driver problems. For this reason, you can use the reference rasterizer to determine if rendering issues are caused by the video driver. The d3dref9.dll file must be in a location where the application can access it, such as in any location in the system path or in the local directory of the application.  
  
 The **use reference rasterizer option** takes a DWORD value. A value of 0 indicates that the reference rasterizer is not used. Any other non-zero value forces [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] to use the reference rasterizer.  
  
## See Also  
 [Graphics Rendering Tiers](../../../../docs/framework/wpf/advanced/graphics-rendering-tiers.md)  
 [WPF Graphics Rendering Overview](../../../../docs/framework/wpf/graphics-multimedia/wpf-graphics-rendering-overview.md)
