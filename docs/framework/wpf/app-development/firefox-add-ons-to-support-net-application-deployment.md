---
title: "Firefox Add-ons to Support .NET Application Deployment"
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
  - "Firefox add-ons for .NET application deployment"
  - "WPF plug-in for Firefox"
  - ".NET application deployment [WPF], deploying with Firefox add-ons"
  - ".NET Framework Assistant for Firefox"
ms.assetid: 2403403b-9b14-48e9-b70d-fa288a3c9081
caps.latest.revision: 22
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Firefox Add-ons to Support .NET Application Deployment
The [!INCLUDE[TLA#tla_wpf](../../../../includes/tlasharptla-wpf-md.md)] plug-in for Firefox and the .NET Framework Assistant for Firefox enable [!INCLUDE[TLA#tla_winfxwebapp#plural](../../../../includes/tlasharptla-winfxwebappsharpplural-md.md)], loose [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)], and ClickOnce applications to work with the Mozilla Firefox browser.  
  
## WPF Plug-in for Firefox  
 The WPF plug-in for Firefox enables [!INCLUDE[TLA2#tla_xbap#plural](../../../../includes/tla2sharptla-xbapsharpplural-md.md)] and loose [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)] files to be navigated to and run at the top-level or in an HTML IFRAME in the Firefox browser. An [!INCLUDE[TLA2#tla_xbap](../../../../includes/tla2sharptla-xbap-md.md)] is a [!INCLUDE[TLA2#tla_wpf](../../../../includes/tla2sharptla-wpf-md.md)] application that can be published to a Web server and launched within supported browsers. Loose [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)] is a XAML-only file that can be navigated to and displayed in supported browsers, much like an XML file.  
  
 The [!INCLUDE[TLA2#tla_wpf](../../../../includes/tla2sharptla-wpf-md.md)] plug-in for Firefox is installed with the [!INCLUDE[net_v35_short](../../../../includes/net-v35-short-md.md)]. Window 7 includes the [!INCLUDE[net_v35_short](../../../../includes/net-v35-short-md.md)], but does not include the [!INCLUDE[TLA2#tla_wpf](../../../../includes/tla2sharptla-wpf-md.md)] plug-in for Firefox. You cannot install the [!INCLUDE[TLA2#tla_wpf](../../../../includes/tla2sharptla-wpf-md.md)] plug-in for Firefox on Windows 7.  
  
 The [!INCLUDE[net_v40_short](../../../../includes/net-v40-short-md.md)] does not include the [!INCLUDE[TLA2#tla_wpf](../../../../includes/tla2sharptla-wpf-md.md)] plug-in for Firefox. However, if both the [!INCLUDE[net_v35_short](../../../../includes/net-v35-short-md.md)] and [!INCLUDE[net_v40_short](../../../../includes/net-v40-short-md.md)] are installed, the WPF plug-in for Firefox is installed with the [!INCLUDE[net_v35_short](../../../../includes/net-v35-short-md.md)]. Therefore [!INCLUDE[net_v40_short](../../../../includes/net-v40-short-md.md)] applications will still run because the WPF Host will load the correct version of the framework. For more information, see [WPF Host (PresentationHost.exe)](../../../../docs/framework/wpf/app-development/wpf-host-presentationhost-exe.md).  
  
## .NET Framework Assistant for Firefox  
 The .NET Framework Assistant for Firefox enables stand-alone ClickOnce applications to run from the Firefox browser. The .NET Framework Assistant for Firefox functions identically when it is installed before and after the Firefox browser. When the Firefox browser is launched and the [!INCLUDE[net_v35SP1_short](../../../../includes/net-v35sp1-short-md.md)] is installed, Firefox finds and installs the .NET Framework Assistant for Firefox. Users can configure the .NET Framework Assistant for Firefox to do the following:  
  
-   Prompt before running the ClickOnce application.  
  
-   Report all installed versions of the .NET Framework or just the latest version.  
  
 The .NET Framework Assistant for Firefox is included with the [!INCLUDE[net_v35SP1_short](../../../../includes/net-v35sp1-short-md.md)]. For information about removing the .NET Framework Assistant for Firefox, see [How to remove the .NET Framework Assistant for Firefox](http://go.microsoft.com/fwlink/?LinkId=177944).  
  
## See Also  
 [Deploying a WPF Application](../../../../docs/framework/wpf/app-development/deploying-a-wpf-application-wpf.md)  
 [WPF XAML Browser Applications Overview](../../../../docs/framework/wpf/app-development/wpf-xaml-browser-applications-overview.md)  
 [Detect Whether the WPF Plug-In for Firefox Is Installed](../../../../docs/framework/wpf/app-development/how-to-detect-whether-the-wpf-plug-in-for-firefox-is-installed.md)
