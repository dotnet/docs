---
title: "IWpfHostSupport"
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
  - "IWpfHostSupport interface [WPF]"
ms.assetid: cc5a0281-de81-4cc1-87e4-0e46b1a811e9
caps.latest.revision: 8
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# IWpfHostSupport
Applications that host [!INCLUDE[TLA#tla_winclient](../../../../includes/tlasharptla-winclient-md.md)] content via PresentationHost.exe implement this interface to provide a point of integration between the host and PresentationHost.exe.  
  
## Remarks  
 [!INCLUDE[TLA#tla_win32](../../../../includes/tlasharptla-win32-md.md)] applications such as Web browsers can host [!INCLUDE[TLA#tla_titlewinclient](../../../../includes/tlasharptla-titlewinclient-md.md)] content, including [!INCLUDE[TLA#tla_xbap#plural](../../../../includes/tlasharptla-xbapsharpplural-md.md)] and loose XAML. To host [!INCLUDE[TLA#tla_titlewinclient](../../../../includes/tlasharptla-titlewinclient-md.md)] content, [!INCLUDE[TLA#tla_win32](../../../../includes/tlasharptla-win32-md.md)] applications create an instance of the [WebBrowser control](http://go.microsoft.com/fwlink/?LinkId=97911). To be hosted, [!INCLUDE[TLA#tla_titlewinclient](../../../../includes/tlasharptla-titlewinclient-md.md)] creates an instance of PresentationHost.exe, which provides the hosted [!INCLUDE[TLA#tla_titlewinclient](../../../../includes/tlasharptla-titlewinclient-md.md)] content to the host for display in the [WebBrowser control](http://go.microsoft.com/fwlink/?LinkId=97911).  
  
 The integration enabled by `IWpfHostSupport` allows PresentationHost.exe to:  
  
-   Discover and register with the raw input devices (Human Interface Devices) that the host application is interested in.  
  
-   Receive input messages from the registered raw input devices and forward appropriate messages to the host application.  
  
-   Query the host application for custom progress and error user interfaces.  
  
> [!NOTE]
>  This API is only intended and supported for use on the local client machine  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|[GetRawInputDevices](../../../../docs/framework/wpf/app-development/getrawinputdevices.md)|Allows PresentationHost.exe to discover the raw input devices (Human Interface Devices) that the host application is interested in.|  
|[FilterInputMessage](../../../../docs/framework/wpf/app-development/filterinputmessage.md)|Called by PresentationHost.exe whenever a message is received unless E_NOTIMPL is returned.|  
|[GetCustomUI](../../../../docs/framework/wpf/app-development/getcustomui.md)|By default, PresentationHost.exe provides its own deployment progress and deployment error user interfaces that are displayed when WPF content is deployed.|
