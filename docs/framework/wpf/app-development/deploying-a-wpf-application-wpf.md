---
title: "Deploying a WPF Application (WPF)"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "WPF applications [WPF], deployment"
  - "deployment [WPF], applications"
ms.assetid: 12cadca0-b32c-4064-9a56-e6a306dcc76d
---
# Deploying a WPF Application (WPF)
After Windows Presentation Foundation (WPF) applications are built, they need to be deployed. Windows and the .NET Framework include several deployment technologies. The deployment technology that is used to deploy a [!INCLUDE[TLA2#tla_wpf](../../../../includes/tla2sharptla-wpf-md.md)] application depends on the application type. This topic provides a brief overview of each deployment technology, and how they are used in conjunction with the deployment requirements of each [!INCLUDE[TLA2#tla_wpf](../../../../includes/tla2sharptla-wpf-md.md)] application type.  

<a name="Deployment_Technologies"></a>   
## Deployment Technologies  
 Windows and the .NET Framework include several deployment technologies, including:  
  
- XCopy deployment.  
  
- [!INCLUDE[TLA2#tla_wininstall](../../../../includes/tla2sharptla-wininstall-md.md)] deployment.  
  
- ClickOnce deployment.  
  
<a name="XCopy_Deployment"></a>   
### XCopy Deployment  
 XCopy deployment refers to the use of the XCopy command-line program to copy files from one location to another. XCopy deployment is suitable under the following circumstances:  
  
- The application is self-contained. It does not need to update the client to run.  
  
- Application files must be moved from one location to another, such as from a build location (local disk, [!INCLUDE[TLA2#tla_unc](../../../../includes/tla2sharptla-unc-md.md)] file share, and so on) to a publish location (Web site, [!INCLUDE[TLA2#tla_unc](../../../../includes/tla2sharptla-unc-md.md)] file share, and so on).  
  
- The application does not require shell integration (Start menu shortcut, desktop icon, and so on).  
  
 Although XCopy is suitable for simple deployment scenarios, it is limited when more complex deployment capabilities are required. In particular, using XCopy often incurs the overhead for creating, executing, and maintaining scripts for managing deployment in a robust way. Furthermore, XCopy does not support versioning, uninstallation, or rollback.  
  
<a name="Windows_Installer"></a>   
### Windows Installer  
 [!INCLUDE[TLA2#tla_wininstall](../../../../includes/tla2sharptla-wininstall-md.md)] allows applications to be packaged as self-contained executables that can be easily distributed to clients and run. Furthermore, [!INCLUDE[TLA2#tla_wininstall](../../../../includes/tla2sharptla-wininstall-md.md)] is installed with Windows and enables integration with the desktop, the Start menu, and the Programs control panel.  
  
 [!INCLUDE[TLA2#tla_wininstall](../../../../includes/tla2sharptla-wininstall-md.md)] simplifies the installation and uninstallation of applications, but it does not provide facilities for ensuring that installed applications are kept up-to-date from a versioning standpoint.  
  
 For more information about Windows Installer, see [Windows Installer Deployment](/visualstudio/deployment/deploying-applications-services-and-components#create-an-installer-package-windows-desktop).
  
<a name="ClickOnce_Deployment"></a>   
### ClickOnce Deployment  
 ClickOnce enables Web-style application deployment for non-Web applications. Applications are published to and deployed from Web or file servers. Although ClickOnce does not support the full range of client features that [!INCLUDE[TLA2#tla_wininstall](../../../../includes/tla2sharptla-wininstall-md.md)]-installed applications do, it does support a subset that includes the following:  
  
- Integration with the Start menu and Programs control panel.  
  
- Versioning, rollback, and uninstallation.  
  
- Online install mode, which always launches an application from the deployment location.  
  
- Automatic updating when new versions are released.  
  
- Registration of file extensions.  
  
 For more information about ClickOnce, see [ClickOnce Security and Deployment](/visualstudio/deployment/clickonce-security-and-deployment).  
  
<a name="Deploying_WPF_Applications"></a>   
## Deploying WPF Applications  
 The deployment options for a [!INCLUDE[TLA2#tla_wpf](../../../../includes/tla2sharptla-wpf-md.md)] application depend on the type of application. From a deployment perspective, [!INCLUDE[TLA2#tla_wpf](../../../../includes/tla2sharptla-wpf-md.md)] has three significant application types:  
  
- Standalone applications.  
  
- Markup-only [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)] applications.  
  
- [!INCLUDE[TLA#tla_xbap#plural](../../../../includes/tlasharptla-xbapsharpplural-md.md)].  
  
<a name="Deploying_Standalone_Applications"></a>   
### Deploying Standalone Applications  
 Standalone applications are deployed using either ClickOnce or [!INCLUDE[TLA2#tla_wininstall](../../../../includes/tla2sharptla-wininstall-md.md)]. Either way, standalone applications require full trust to run. Full trust is automatically granted to standalone applications that are deployed using [!INCLUDE[TLA2#tla_wininstall](../../../../includes/tla2sharptla-wininstall-md.md)]. Standalone applications that are deployed using ClickOnce are not automatically granted full trust. Instead, ClickOnce displays a security warning dialog that users must accept before a standalone application is installed. If accepted, the standalone application is installed and granted full trust. If not, the standalone application is not installed.  
  
<a name="Deploying_Markup_Only_XAML_Applications"></a>   
### Deploying Markup-Only XAML Applications  
 Markup-only [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)] pages are usually published to Web servers, like HTML pages, and can be viewed using Internet Explorer. Markup-only [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)] pages run within a partial-trust security sandbox with restrictions that are defined by the Internet zone permission set. This provides an equivalent security sandbox to HTML-based Web applications.  
  
 For more information about security for [!INCLUDE[TLA2#tla_wpf](../../../../includes/tla2sharptla-wpf-md.md)] applications, see [Security](../security-wpf.md).  
  
 Markup-only [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)] pages can be installed to the local file system by using either XCopy or [!INCLUDE[TLA2#tla_wininstall](../../../../includes/tla2sharptla-wininstall-md.md)]. These pages can be viewed using Internet Explorer or Windows Explorer.  
  
 For more information about XAML, see [XAML Overview (WPF)](../advanced/xaml-overview-wpf.md).  
  
<a name="Deploying_XAML_Browser_Applications"></a>   
### Deploying XAML Browser Applications  
 [!INCLUDE[TLA2#tla_xbap#plural](../../../../includes/tla2sharptla-xbapsharpplural-md.md)] are compiled applications that require the following three files to be deployed:  
  
- *ApplicationName*.exe: The executable assembly application file.  
  
- *ApplicationName*.xbap: The deployment manifest.  
  
- *ApplicationName*.exe.manifest: The application manifest.  
  
> [!NOTE]
> For more information about deployment and application manifests, see [Building a WPF Application](building-a-wpf-application-wpf.md).  
  
 These files are produced when an [!INCLUDE[TLA2#tla_xbap](../../../../includes/tla2sharptla-xbap-md.md)] is built. For more information, see [How to: Create a New WPF Browser Application Project](https://docs.microsoft.com/previous-versions/visualstudio/visual-studio-2010/bb628663(v=vs.100)). Like markup-only [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)] pages, [!INCLUDE[TLA2#tla_xbap#plural](../../../../includes/tla2sharptla-xbapsharpplural-md.md)] are typically published to a Web server and viewed using Internet Explorer.  
  
 [!INCLUDE[TLA2#tla_xbap#plural](../../../../includes/tla2sharptla-xbapsharpplural-md.md)] can be deployed to clients using any of the deployment techniques. However, ClickOnce is recommended since it provides the following capabilities:  
  
1. Automatic updates when a new version is published.  
  
2. Elevation privileges for the [!INCLUDE[TLA2#tla_xbap](../../../../includes/tla2sharptla-xbap-md.md)] running with full trust.  
  
 By default, ClickOnce publishes application files with the .deploy extension. This can be problematic, but can be disabled. For more information, see [Server and Client Configuration Issues in ClickOnce Deployments](/visualstudio/deployment/server-and-client-configuration-issues-in-clickonce-deployments).  
  
 For more information about deploying [!INCLUDE[TLA#tla_xbap#plural](../../../../includes/tlasharptla-xbapsharpplural-md.md)], see [WPF XAML Browser Applications Overview](wpf-xaml-browser-applications-overview.md).  
  
<a name="Installing__NET_Framework_3_0"></a>   
## Installing the .NET Framework  
 To run a [!INCLUDE[TLA2#tla_wpf](../../../../includes/tla2sharptla-wpf-md.md)] application, the Microsoft .NET Framework must be installed on the client. Internet Explorer automatically detects whether clients are installed with .NET Framework when [!INCLUDE[TLA2#tla_wpf](../../../../includes/tla2sharptla-wpf-md.md)] browser-hosted applications are viewed. If the .NET Framework is not installed, Internet Explorer prompts users to install it.  
  
 To detect whether the .NET Framework is installed, Internet Explorer includes a bootstrapper application that is registered as the fallback Multipurpose Internet Mail Extensions (MIME) handler for content files with the following extensions: .xaml, .xps, .xbap, and .application. If you navigate to these file types and the .NET Framework is not installed on the client, the bootstrapper application requests permission to install it. If permission is not provided, neither the .NET Framework nor the application is installed.  
  
 If permission is granted, Internet Explorer downloads and installs the .NET Framework using the Microsoft Background Intelligent Transfer Service (BITS). After successful installation of the .NET Framework, the originally requested file is opened in a new browser window.  
  
 For more information, see [Deploying the .NET Framework and Applications](../../deployment/index.md).  
  
## See also

- [Building a WPF Application](building-a-wpf-application-wpf.md)
- [Security](../security-wpf.md)
