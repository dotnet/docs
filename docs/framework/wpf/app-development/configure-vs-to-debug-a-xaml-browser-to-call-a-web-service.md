---
title: "How to: Configure Visual Studio to Debug a XAML Browser Application to Call a Web Service"
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
  - "debugging XBAPs that call a Web service [WPF]"
  - "debugging security exceptions for XBAPs [WPF]"
  - "security exception for XBAPs [WPF], debugging"
  - "configuring Visual Studio to debug XAML browser applications [WPF]"
  - "configuring Visual Studio to debug XBAPs [WPF]"
ms.assetid: fd1db082-a7bb-4c4b-9331-6ad74a0682d0
caps.latest.revision: 9
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Configure Visual Studio to Debug a XAML Browser Application to Call a Web Service
[!INCLUDE[TLA#tla_xbap#plural](../../../../includes/tlasharptla-xbapsharpplural-md.md)] run within a partial-trust security sandbox that is restricted to the Internet zone set of permissions. This permission set restricts Web service calls to only Web services that are located at the [!INCLUDE[TLA2#tla_xbap](../../../../includes/tla2sharptla-xbap-md.md)] application's site of origin. When an [!INCLUDE[TLA2#tla_xbap](../../../../includes/tla2sharptla-xbap-md.md)] is debugged from [!INCLUDE[TLA#tla_visualstu2005](../../../../includes/tlasharptla-visualstu2005-md.md)], though, it is not considered to have the same site of origin as the Web service it references. This causes security exceptions to be raised when the [!INCLUDE[TLA2#tla_xbap](../../../../includes/tla2sharptla-xbap-md.md)] attempts to call the Web service. However, a [!INCLUDE[TLA#tla_visualstu2005](../../../../includes/tlasharptla-visualstu2005-md.md)] [!INCLUDE[TLA#tla_wpfbrowserappproj](../../../../includes/tlasharptla-wpfbrowserappproj-md.md)] project can be configured to simulate having the same site of origin as the Web service it calls while debugging. This allows the [!INCLUDE[TLA2#tla_xbap](../../../../includes/tla2sharptla-xbap-md.md)] to safely call the Web service without causing security exceptions.  
  
## Configuring Visual Studio  
 To configure [!INCLUDE[TLA#tla_visualstu2005](../../../../includes/tlasharptla-visualstu2005-md.md)] to debug an [!INCLUDE[TLA2#tla_xbap](../../../../includes/tla2sharptla-xbap-md.md)] that calls a Web service:  
  
1.  With a project selected in **Solution Explorer**, on the **Project** menu, click **Properties**.  
  
2.  In the **Project Designer**, click the **Debug** tab.  
  
3.  In the **Start Action** section, select **Start external program** and enter the following:  
  
     `C:\WINDOWS\System32\PresentationHost.exe`  
  
4.  In the **Start Options** section, enter the following into the **Command line arguments** text box:  
  
     `-debug`  *filename*  
  
     The *filename* value for the **-debug** parameter is the .xbap filename; for example:  
  
     `-debug c:\example.xbap`  
  
> [!NOTE]
>  This is the default configuration for solutions that are created with the [!INCLUDE[TLA2#tla_visualstu2005](../../../../includes/tla2sharptla-visualstu2005-md.md)] [!INCLUDE[TLA#tla_wpfbrowserappproj](../../../../includes/tlasharptla-wpfbrowserappproj-md.md)] project template.  
  
1.  With a project selected in **Solution Explorer**, on the **Project** menu, click **Properties**.  
  
2.  In the **Project Designer**, click the **Debug** tab.  
  
3.  In the **Start Options** section, add the following command-line parameter to the **Command line arguments** text box:  
  
     `-debugSecurityZoneURL`  *URL*  
  
     The *URL* value for the **-debugSecurityZoneURL** parameter is the [!INCLUDE[TLA#tla_url](../../../../includes/tlasharptla-url-md.md)] for the location that you want to simulate as being the site of origin of your application.  
  
 As an example, consider a [!INCLUDE[TLA#tla_xbap](../../../../includes/tlasharptla-xbap-md.md)] that uses a Web service with the following [!INCLUDE[TLA2#tla_url](../../../../includes/tla2sharptla-url-md.md)]:  
  
 `http://services.msdn.microsoft.com/ContentServices/ContentService.asmx`  
  
 The site of origin [!INCLUDE[TLA2#tla_url](../../../../includes/tla2sharptla-url-md.md)] for this Web service is:  
  
 `http://services.msdn.microsoft.com`  
  
 Consequently, the complete **-debugSecurityZoneURL** command-line parameter and value is:  
  
 `-debugSecurityZoneURL http://services.msdn.microsoft.com`  
  
## See Also  
 [WPF Host (PresentationHost.exe)](../../../../docs/framework/wpf/app-development/wpf-host-presentationhost-exe.md)
