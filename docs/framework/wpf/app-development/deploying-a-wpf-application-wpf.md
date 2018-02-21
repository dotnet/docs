---
title: "Deploying a WPF Application (WPF)"
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
  - "WPF applications [WPF], deployment"
  - "deployment [WPF], applications"
ms.assetid: 12cadca0-b32c-4064-9a56-e6a306dcc76d
caps.latest.revision: 27
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Deploying a WPF Application (WPF)
After [!INCLUDE[TLA#tla_wpf](../../../../includes/tlasharptla-wpf-md.md)] applications are built, they need to be deployed. [!INCLUDE[TLA#tla_mswin](../../../../includes/tlasharptla-mswin-md.md)] and the [!INCLUDE[TLA2#tla_winfx](../../../../includes/tla2sharptla-winfx-md.md)] include several deployment technologies. The deployment technology that is used to deploy a [!INCLUDE[TLA2#tla_wpf](../../../../includes/tla2sharptla-wpf-md.md)] application depends on the application type. This topic provides a brief overview of each deployment technology, and how they are used in conjunction with the deployment requirements of each [!INCLUDE[TLA2#tla_wpf](../../../../includes/tla2sharptla-wpf-md.md)] application type.  
  
   
<a name="Deployment_Technologies"></a>   
## Deployment Technologies  
 [!INCLUDE[TLA#tla_mswin](../../../../includes/tlasharptla-mswin-md.md)] and the [!INCLUDE[TLA2#tla_winfx](../../../../includes/tla2sharptla-winfx-md.md)] include several deployment technologies, including:  
  
-   XCopy deployment.  
  
-   [!INCLUDE[TLA2#tla_wininstall](../../../../includes/tla2sharptla-wininstall-md.md)] deployment.  
  
-   [!INCLUDE[TLA#tla_clickonce](../../../../includes/tlasharptla-clickonce-md.md)] deployment.  
  
<a name="XCopy_Deployment"></a>   
### XCopy Deployment  
 XCopy deployment refers to the use of the XCopy command-line program to copy files from one location to another. XCopy deployment is suitable under the following circumstances:  
  
-   The application is self-contained. It does not need to update the client to run.  
  
-   Application files must be moved from one location to another, such as from a build location (local disk, [!INCLUDE[TLA2#tla_unc](../../../../includes/tla2sharptla-unc-md.md)] file share, and so on) to a publish location (Web site, [!INCLUDE[TLA2#tla_unc](../../../../includes/tla2sharptla-unc-md.md)] file share, and so on).  
  
-   The application does not require shell integration (Start menu shortcut, desktop icon, and so on).  
  
 Although XCopy is suitable for simple deployment scenarios, it is limited when more complex deployment capabilities are required. In particular, using XCopy often incurs the overhead for creating, executing, and maintaining scripts for managing deployment in a robust way. Furthermore, XCopy does not support versioning, uninstallation, or rollback.  
  
<a name="Windows_Installer"></a>   
### Windows Installer  
 [!INCLUDE[TLA2#tla_wininstall](../../../../includes/tla2sharptla-wininstall-md.md)] allows applications to be packaged as self-contained executables that can be easily distributed to clients and run. Furthermore, [!INCLUDE[TLA2#tla_wininstall](../../../../includes/tla2sharptla-wininstall-md.md)] is installed with [!INCLUDE[TLA#tla_mswin](../../../../includes/tlasharptla-mswin-md.md)] and enables integration with the desktop, the Start menu, and the Programs control panel.  
  
 [!INCLUDE[TLA2#tla_wininstall](../../../../includes/tla2sharptla-wininstall-md.md)] simplifies the installation and uninstallation of applications, but it does not provide facilities for ensuring that installed applications are kept up-to-date from a versioning standpoint.  
  
 For more information about [!INCLUDE[TLA2#tla_wininstall](../../../../includes/tla2sharptla-wininstall-md.md)], see [Windows Installer Deployment](http://msdn.microsoft.com/library/121be21b-b916-43e2-8f10-8b080516d2a0).  
  
<a name="ClickOnce_Deployment"></a>   
### ClickOnce Deployment  
 [!INCLUDE[TLA2#tla_clickonce](../../../../includes/tla2sharptla-clickonce-md.md)] enables Web-style application deployment for non-Web applications. Applications are published to and deployed from Web or file servers. Although [!INCLUDE[TLA2#tla_clickonce](../../../../includes/tla2sharptla-clickonce-md.md)] does not support the full range of client features that [!INCLUDE[TLA2#tla_wininstall](../../../../includes/tla2sharptla-wininstall-md.md)]-installed applications do, it does support a subset that includes the following:  
  
-   Integration with the Start menu and Programs control panel.  
  
-   Versioning, rollback, and uninstallation.  
  
-   Online install mode, which always launches an application from the deployment location.  
  
-   Automatic updating when new versions are released.  
  
-   Registration of file extensions.  
  
 For more information about [!INCLUDE[TLA2#tla_clickonce](../../../../includes/tla2sharptla-clickonce-md.md)], see [ClickOnce Security and Deployment](/visualstudio/deployment/clickonce-security-and-deployment).  
  
<a name="Deploying_WPF_Applications"></a>   
## Deploying WPF Applications  
 The deployment options for a [!INCLUDE[TLA2#tla_wpf](../../../../includes/tla2sharptla-wpf-md.md)] application depend on the type of application. From a deployment perspective, [!INCLUDE[TLA2#tla_wpf](../../../../includes/tla2sharptla-wpf-md.md)] has three significant application types:  
  
-   Standalone applications.  
  
-   Markup-only [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)] applications.  
  
-   [!INCLUDE[TLA#tla_xbap#plural](../../../../includes/tlasharptla-xbapsharpplural-md.md)].  
  
<a name="Deploying_Standalone_Applications"></a>   
### Deploying Standalone Applications  
 Standalone applications are deployed using either [!INCLUDE[TLA#tla_clickonce](../../../../includes/tlasharptla-clickonce-md.md)] or [!INCLUDE[TLA2#tla_wininstall](../../../../includes/tla2sharptla-wininstall-md.md)]. Either way, standalone applications require full trust to run. Full trust is automatically granted to standalone applications that are deployed using [!INCLUDE[TLA2#tla_wininstall](../../../../includes/tla2sharptla-wininstall-md.md)]. Standalone applications that are deployed using [!INCLUDE[TLA2#tla_clickonce](../../../../includes/tla2sharptla-clickonce-md.md)] are not automatically granted full trust. Instead, [!INCLUDE[TLA2#tla_clickonce](../../../../includes/tla2sharptla-clickonce-md.md)] displays a security warning dialog that users must accept before a standalone application is installed. If accepted, the standalone application is installed and granted full trust. If not, the standalone application is not installed.  
  
<a name="Deploying_Markup_Only_XAML_Applications"></a>   
### Deploying Markup-Only XAML Applications  
 Markup-only [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)] pages are usually published to Web servers, like [!INCLUDE[TLA2#tla_html](../../../../includes/tla2sharptla-html-md.md)] pages, and can be viewed using [!INCLUDE[TLA2#tla_iegeneric](../../../../includes/tla2sharptla-iegeneric-md.md)]. Markup-only [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)] pages run within a partial-trust security sandbox with restrictions that are defined by the Internet zone permission set. This provides an equivalent security sandbox to [!INCLUDE[TLA2#tla_html](../../../../includes/tla2sharptla-html-md.md)]-based Web applications.  
  
 For more information about security for [!INCLUDE[TLA2#tla_wpf](../../../../includes/tla2sharptla-wpf-md.md)] applications, see [Security](../../../../docs/framework/wpf/security-wpf.md).  
  
 Markup-only [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)] pages can be installed to the local file system by using either XCopy or [!INCLUDE[TLA2#tla_wininstall](../../../../includes/tla2sharptla-wininstall-md.md)]. These pages can be viewed using [!INCLUDE[TLA2#tla_iegeneric](../../../../includes/tla2sharptla-iegeneric-md.md)] or [!INCLUDE[TLA2#tla_mswin](../../../../includes/tla2sharptla-mswin-md.md)] Explorer.  
  
 For more information about XAML, see [XAML Overview (WPF)](../../../../docs/framework/wpf/advanced/xaml-overview-wpf.md).  
  
<a name="Deploying_XAML_Browser_Applications"></a>   
### Deploying XAML Browser Applications  
 [!INCLUDE[TLA2#tla_xbap#plural](../../../../includes/tla2sharptla-xbapsharpplural-md.md)] are compiled applications that require the following three files to be deployed:  
  
-   *ApplicationName*.exe: The executable assembly application file.  
  
-   *ApplicationName*.xbap: The deployment manifest.  
  
-   *ApplicationName*.exe.manifest: The application manifest.  
  
> [!NOTE]
>  For more information about deployment and application manifests, see [Building a WPF Application](../../../../docs/framework/wpf/app-development/building-a-wpf-application-wpf.md).  
  
 These files are produced when an [!INCLUDE[TLA2#tla_xbap](../../../../includes/tla2sharptla-xbap-md.md)] is built. For more information, see [How to: Create a New WPF Browser Application Project](http://msdn.microsoft.com/library/72ef4d90-e163-42a1-8df0-ea7ccfd1901f). Like markup-only [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)] pages, [!INCLUDE[TLA2#tla_xbap#plural](../../../../includes/tla2sharptla-xbapsharpplural-md.md)] are typically published to a Web server and viewed using [!INCLUDE[TLA2#tla_iegeneric](../../../../includes/tla2sharptla-iegeneric-md.md)].  
  
 [!INCLUDE[TLA2#tla_xbap#plural](../../../../includes/tla2sharptla-xbapsharpplural-md.md)] can be deployed to clients using any of the deployment techniques. However, [!INCLUDE[TLA#tla_clickonce](../../../../includes/tlasharptla-clickonce-md.md)] is recommended since it provides the following capabilities:  
  
1.  Automatic updates when a new version is published.  
  
2.  Elevation privileges for the [!INCLUDE[TLA2#tla_xbap](../../../../includes/tla2sharptla-xbap-md.md)] running with full trust.  
  
 By default, ClickOnce publishes application files with the .deploy extension. This can be problematic, but can be disabled. For more information, see [Server and Client Configuration Issues in ClickOnce Deployments](/visualstudio/deployment/server-and-client-configuration-issues-in-clickonce-deployments).  
  
 For more information about deploying [!INCLUDE[TLA#tla_xbap#plural](../../../../includes/tlasharptla-xbapsharpplural-md.md)], see [WPF XAML Browser Applications Overview](../../../../docs/framework/wpf/app-development/wpf-xaml-browser-applications-overview.md).  
  
<a name="Installing__NET_Framework_3_0"></a>   
## Installing the .NET Framework  
 To run a [!INCLUDE[TLA2#tla_wpf](../../../../includes/tla2sharptla-wpf-md.md)] application, the [!INCLUDE[TLA#tla_winfx](../../../../includes/tlasharptla-winfx-md.md)] must be installed on the client. [!INCLUDE[TLA2#tla_ie](../../../../includes/tla2sharptla-ie-md.md)] automatically detects whether clients are installed with [!INCLUDE[TLA2#tla_winfx](../../../../includes/tla2sharptla-winfx-md.md)] when [!INCLUDE[TLA2#tla_wpf](../../../../includes/tla2sharptla-wpf-md.md)] browser-hosted applications are viewed. If the [!INCLUDE[TLA2#tla_winfx](../../../../includes/tla2sharptla-winfx-md.md)] is not installed, [!INCLUDE[TLA2#tla_ie](../../../../includes/tla2sharptla-ie-md.md)] prompts users to install it.  
  
 To detect whether the [!INCLUDE[TLA2#tla_winfx](../../../../includes/tla2sharptla-winfx-md.md)] is installed, [!INCLUDE[TLA2#tla_ie](../../../../includes/tla2sharptla-ie-md.md)] includes a bootstrapper application that is registered as the fallback [!INCLUDE[TLA#tla_mime](../../../../includes/tlasharptla-mime-md.md)] handler for content files with the following extensions: .xaml, .xps, .xbap, and .application. If you navigate to these file types and the [!INCLUDE[TLA2#tla_winfx](../../../../includes/tla2sharptla-winfx-md.md)] is not installed on the client, the bootstrapper application requests permission to install it. If permission is not provided, neither the [!INCLUDE[TLA2#tla_winfx](../../../../includes/tla2sharptla-winfx-md.md)] nor the application is installed.  
  
 If permission is granted, [!INCLUDE[TLA2#tla_ie](../../../../includes/tla2sharptla-ie-md.md)] downloads and installs the [!INCLUDE[TLA2#tla_winfx](../../../../includes/tla2sharptla-winfx-md.md)] using the [!INCLUDE[TLA#tla_bits](../../../../includes/tlasharptla-bits-md.md)]. After successful installation of the [!INCLUDE[TLA2#tla_winfx](../../../../includes/tla2sharptla-winfx-md.md)], the originally requested file is opened in a new browser window.  
  
 [!INCLUDE[TLA2#tla_winfx](../../../../includes/tla2sharptla-winfx-md.md)] auto-detection is available on [!INCLUDE[TLA#tla_longhorn](../../../../includes/tlasharptla-longhorn-md.md)], [!INCLUDE[TLA#tla_winxpsp2](../../../../includes/tlasharptla-winxpsp2-md.md)], and [!INCLUDE[TLA#tla_winnetsvrfamsp1](../../../../includes/tlasharptla-winnetsvrfamsp1-md.md)] clients that have [!INCLUDE[TLA2#tla_ie7](../../../../includes/tla2sharptla-ie7-md.md)] or later installed.  
  
 For more information, see [Deploying the .NET Framework and Applications](../../../../docs/framework/deployment/index.md).  
  
## See Also  
 [Building a WPF Application](../../../../docs/framework/wpf/app-development/building-a-wpf-application-wpf.md)  
 [Security](../../../../docs/framework/wpf/security-wpf.md)
