---
title: "Performance Considerations for Direct3D9 and WPF Interoperability"
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
  - "WPF [WPF], Direct3D9 interop performance"
  - "Direct3D9 [WPF interoperability], performance"
ms.assetid: ea8baf91-12fe-4b44-ac4d-477110ab14dd
caps.latest.revision: 19
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Performance Considerations for Direct3D9 and WPF Interoperability
You can host Direct3D9 content by using the <xref:System.Windows.Interop.D3DImage> class. Hosting Direct3D9 content can affect the performance of your application. This topic describes best practices to optimize performance when hosting Direct3D9 content in a Windows Presentation Foundation (WPF) application. These best practices include how to use <xref:System.Windows.Interop.D3DImage> and best practices when you are using Windows Vista, Windows XP, and multi-monitor displays.  
  
> [!NOTE]
>  For code examples that demonstrate these best practices, see [WPF and Direct3D9 Interoperation](../../../../docs/framework/wpf/advanced/wpf-and-direct3d9-interoperation.md).  
  
## Use D3DImage Sparingly  
 Direct3D9 content hosted in a <xref:System.Windows.Interop.D3DImage> instance does not render as fast as in a pure Direct3D application. Copying the surface and flushing the command buffer can be costly operations. As the number of <xref:System.Windows.Interop.D3DImage> instances increases, more flushing occurs, and performance degrades. Therefore, you should use <xref:System.Windows.Interop.D3DImage> sparingly.  
  
## Best Practices on Windows Vista  
 For best performance on Windows Vista with a display that is configured to use the Windows Display Driver Model (WDDM), create your Direct3D9 surface on an `IDirect3DDevice9Ex` device. This enables surface sharing. The video card must support the `D3DDEVCAPS2_CAN_STRETCHRECT_FROM_TEXTURES` and `D3DCAPS2_CANSHARERESOURCE` driver capabilities on Windows Vista. Any other settings cause the surface to be copied through software, which reduces performance significantly.  
  
> [!NOTE]
>  If Windows Vista has a display that is configured to use the Windows XP Display Driver Model (XDDM), the surface is always copied through software, regardless of settings. With the proper settings and video card, you will see better performance on Windows Vista when you use the WDDM because surface copies are performed in hardware.  
  
## Best Practices on Windows XP  
 For best performance on Windows XP, which uses the Windows XP Display Driver Model (XDDM), create a lockable surface that behaves correctly when the `IDirect3DSurface9::GetDC` method is called. Internally, the `BitBlt` method transfers the surface across devices in hardware. The `GetDC` method always works on XRGB surfaces. However, if the client computer is running Windows XP with SP3 or SP2, and if the client also has the hotfix for the layered-window feature, this method only works on ARGB surfaces. The video card must support the `D3DDEVCAPS2_CAN_STRETCHRECT_FROM_TEXTURES` driver capability.  
  
 A 16-bit desktop display depth can significantly reduce performance. A 32-bit desktop is recommended.  
  
 If you are developing for Windows Vista and Windows XP, test the performance on Windows XP. Running out of video memory on Windows XP is a concern. In addition, <xref:System.Windows.Interop.D3DImage> on Windows XP uses more video memory and bandwidth than Windows Vista WDDM, due to a necessary extra video memory copy. Therefore, you can expect performance to be worse on Windows XP than on Windows Vista for the same video hardware.  
  
> [!NOTE]
>  XDDM is available on both Windows XP and Windows Vista; however, WDDM is available only on Windows Vista.  
  
## General Best Practices  
 When you create the device, use the `D3DCREATE_MULTITHREADED` creation flag. This reduces performance, but the WPF rendering system calls methods on this device from another thread. Be sure to follow the locking protocol correctly, so that no two threads access the device at the same time.  
  
 If your rendering is performed on a WPF managed thread, it is strongly recommended that you create the device with the `D3DCREATE_FPU_PRESERVE` creation flag. Without this setting, the D3D rendering can reduce the accuracy of WPF double-precision operations and introduce rendering issues.  
  
 Tiling a <xref:System.Windows.Interop.D3DImage> is fast, unless you tile a non-pow2 surface without hardware support, or if you tile a <xref:System.Windows.Media.DrawingBrush> or <xref:System.Windows.Media.VisualBrush> that contains a <xref:System.Windows.Interop.D3DImage>.  
  
## Best Practices for Multi-Monitor Displays  
 If you are using a computer that has multiple monitors, you should follow the previously described best practices. There are also some additional performance considerations for a multi-monitor configuration.  
  
 When you create the back buffer, it is created on a specific device and adapter, but WPF may display the front buffer on any adapter. Copying across adapters to update the front buffer can be very expensive. On Windows Vista that is configured to use the WDDM with multiple video cards and with an `IDirect3DDevice9Ex` device, if the front buffer is on a different adapter but still the same video card, there is no performance penalty. However, on Windows XP and the XDDM with multiple video cards, there is a significant performance penalty when the front buffer is displayed on a different adapter than the back buffer. For more information, see [WPF and Direct3D9 Interoperation](../../../../docs/framework/wpf/advanced/wpf-and-direct3d9-interoperation.md).  
  
## Performance Summary  
 The following table shows performance of the front buffer update as a function of operating system, pixel format, and surface lockability. The front buffer and back buffer are assumed to be on the same adapter. Depending on the adapter configuration, hardware updates are generally much faster than software updates.  
  
|Surface pixel format|Windows Vista, WDDM and 9Ex|Other Windows Vista configurations|Windows XP SP3 or SP2 w/ hotfix|Windows XP SP2|  
|--------------------------|---------------------------------|----------------------------------------|--------------------------------------|--------------------|  
|D3DFMT_X8R8G8B8 (not lockable)|**Hardware Update**|Software Update|Software Update|Software Update|  
|D3DFMT_X8R8G8B8 (lockable)|**Hardware Update**|Software Update|**Hardware Update**|**Hardware Update**|  
|D3DFMT_A8R8G8B8 (not lockable)|**Hardware Update**|Software Update|Software Update|Software Update|  
|D3DFMT_A8R8G8B8 (lockable)|**Hardware Update**|Software Update|**Hardware Update**|Software Update|  
  
## See Also  
 <xref:System.Windows.Interop.D3DImage>  
 [WPF and Direct3D9 Interoperation](../../../../docs/framework/wpf/advanced/wpf-and-direct3d9-interoperation.md)  
 [Walkthrough: Creating Direct3D9 Content for Hosting in WPF](../../../../docs/framework/wpf/advanced/walkthrough-creating-direct3d9-content-for-hosting-in-wpf.md)  
 [Walkthrough: Hosting Direct3D9 Content in WPF](../../../../docs/framework/wpf/advanced/walkthrough-hosting-direct3d9-content-in-wpf.md)
