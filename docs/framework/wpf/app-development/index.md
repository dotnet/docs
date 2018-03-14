---
title: "Application Development"
ms.custom: ""
ms.date: "01/26/2018"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-wpf"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "WPF [WPF], about application development"
  - "application development [WPF], about"
ms.assetid: 2996ce5e-81e9-49ae-881b-952db3dd1b7e
caps.latest.revision: 21
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Application Development
<a name="introduction"></a>
[!INCLUDE[TLA#tla_wpf](../../../../includes/tlasharptla-wpf-md.md)] is a presentation framework that can be used to develop the following types of applications:  
  
-   Standalone Applications (traditional style [!INCLUDE[TLA#tla_mswin](../../../../includes/tlasharptla-mswin-md.md)] applications built as executable assemblies that are installed to and run from the client computer).  
  
-   [!INCLUDE[TLA#tla_xbap#plural](../../../../includes/tlasharptla-xbapsharpplural-md.md)] (applications composed of navigation pages that are built as executable assemblies and hosted by Web browsers such as [!INCLUDE[TLA#tla_ie](../../../../includes/tlasharptla-ie-md.md)] or Mozilla Firefox).  
  
-   Custom Control Libraries (non-executable assemblies containing reusable controls).  
  
-   Class Libraries (non-executable assemblies that contain reusable classes).  
  
> [!NOTE]
>  Using WPF types in a Windows service is strongly discouraged. If you attempt to use these features in a Windows service, they may not work as expected.  
  
 To build this set of applications, [!INCLUDE[TLA2#tla_wpf](../../../../includes/tla2sharptla-wpf-md.md)] implements a host of services. This topic provides an overview of these services and where to find more information.  
  

  
<a name="Application_Management"></a>   
## Application Management  
 Executable [!INCLUDE[TLA2#tla_wpf](../../../../includes/tla2sharptla-wpf-md.md)] applications commonly require a core set of functionality that includes the following:  
  
-   Creating and managing common application infrastructure (including creating an entry point method and a Windows message loop to receive system and input messages).  
  
-   Tracking and interacting with the lifetime of an application.  
  
-   Retrieving and processing command-line parameters.  
  
-   Sharing application-scope properties and [!INCLUDE[TLA2#tla_ui](../../../../includes/tla2sharptla-ui-md.md)] resources.  
  
-   Detecting and processing unhandled exceptions.  
  
-   Returning exit codes.  
  
-   Managing windows in standalone applications.  
  
-   Tracking navigation in [!INCLUDE[TLA#tla_xbap#plural](../../../../includes/tlasharptla-xbapsharpplural-md.md)], and standalone applications with navigation windows and frames.  
  
 These capabilities are implemented by the <xref:System.Windows.Application> class, which you add to your applications using an *application definition*.  
  
 For more information, see [Application Management Overview](../../../../docs/framework/wpf/app-development/application-management-overview.md).  
  
<a name="WPF_Application_Resource__Content__and_Data_Files"></a>   
## WPF Application Resource, Content, and Data Files  
 [!INCLUDE[TLA2#tla_wpf](../../../../includes/tla2sharptla-wpf-md.md)] extends the core support in the [!INCLUDE[TLA#tla_winfx](../../../../includes/tlasharptla-winfx-md.md)] for embedded resources with support for three kinds of non-executable data files: resource, content, and data. For more information, see [WPF Application Resource, Content, and Data Files](../../../../docs/framework/wpf/app-development/wpf-application-resource-content-and-data-files.md).  
  
 A key component of the support for WPF non-executable data files is the ability to identify and load them using a unique [!INCLUDE[TLA2#tla_uri](../../../../includes/tla2sharptla-uri-md.md)]. For more information, see [Pack URIs in WPF](../../../../docs/framework/wpf/app-development/pack-uris-in-wpf.md).  
  
<a name="Windows_and_Dialog_Boxes"></a>   
## Windows and Dialog Boxes  
 Users interact with [!INCLUDE[TLA2#tla_wpf](../../../../includes/tla2sharptla-wpf-md.md)] standalone applications through windows. The purpose of a window is to host application content and expose application functionality that usually allows users to interact with the content. In [!INCLUDE[TLA2#tla_wpf](../../../../includes/tla2sharptla-wpf-md.md)], windows are encapsulated by the <xref:System.Windows.Window> class, which supports:  
  
-   Creating and showing windows.  
  
-   Establishing owner/owned window relationships.  
  
-   Configuring window appearance (for example, size, location, icons, title bar text, border).  
  
-   Tracking and interacting with the lifetime of a window.  
  
 For more information, see [WPF Windows Overview](../../../../docs/framework/wpf/app-development/wpf-windows-overview.md).  
  
 <xref:System.Windows.Window> supports the ability to create a special type of window known as a dialog box. Both modal and modeless types of dialog boxes can be created.  
  
 For convenience, and the benefits of reusability and a consistent user experience across applications, [!INCLUDE[TLA2#tla_wpf](../../../../includes/tla2sharptla-wpf-md.md)] exposes three of the common [!INCLUDE[TLA2#tla_mswin](../../../../includes/tla2sharptla-mswin-md.md)] dialog boxes: <xref:Microsoft.Win32.OpenFileDialog>, <xref:Microsoft.Win32.SaveFileDialog>, and <xref:System.Windows.Controls.PrintDialog>.  
  
 A message box is a special type of dialog box for showing important textual information to users, and for asking simple Yes/No/OK/Cancel questions. You use the <xref:System.Windows.MessageBox> class to create and show message boxes.  
  
 For more information, see [Dialog Boxes Overview](../../../../docs/framework/wpf/app-development/dialog-boxes-overview.md).  
  
<a name="Navigation"></a>   
## Navigation  
 [!INCLUDE[TLA2#tla_wpf](../../../../includes/tla2sharptla-wpf-md.md)] supports Web-style navigation using pages (<xref:System.Windows.Controls.Page>) and hyperlinks (<xref:System.Windows.Documents.Hyperlink>). Navigation can be implemented in a variety of ways that include the following:  
  
-   Standalone pages that are hosted in a Web browser.  
  
-   Pages compiled into an [!INCLUDE[TLA2#tla_xbap](../../../../includes/tla2sharptla-xbap-md.md)] that is hosted in a Web browser.  
  
-   Pages compiled into a standalone application and hosted by a navigation window (<xref:System.Windows.Navigation.NavigationWindow>).  
  
-   Pages that are hosted by a frame (<xref:System.Windows.Controls.Frame>), which may be hosted in a standalone page, or a page compiled into either an [!INCLUDE[TLA2#tla_xbap](../../../../includes/tla2sharptla-xbap-md.md)] or a standalone application.  
  
 To facilitate navigation, [!INCLUDE[TLA2#tla_wpf](../../../../includes/tla2sharptla-wpf-md.md)] implements the following:  
  
-   <xref:System.Windows.Navigation.NavigationService>, the shared navigation engine for processing navigation requests that is used by <xref:System.Windows.Controls.Frame>, <xref:System.Windows.Navigation.NavigationWindow>, and [!INCLUDE[TLA2#tla_xbap#plural](../../../../includes/tla2sharptla-xbapsharpplural-md.md)] to support intra-application navigation.  
  
-   Navigation methods to initiate navigation.  
  
-   Navigation events to track and interact with navigation lifetime.  
  
-   Remembering back and forward navigation using a journal, which can also be inspected and manipulated.  
  
 For information, see [Navigation Overview](../../../../docs/framework/wpf/app-development/navigation-overview.md).  
  
 [!INCLUDE[TLA2#tla_wpf](../../../../includes/tla2sharptla-wpf-md.md)] also supports a special type of navigation known as structured navigation. Structured navigation can be used to call one or more pages that return data in a structured and predictable way that is consistent with calling functions. This capability depends on the <xref:System.Windows.Navigation.PageFunction%601> class, which is described further in [Structured Navigation Overview](../../../../docs/framework/wpf/app-development/structured-navigation-overview.md). <xref:System.Windows.Navigation.PageFunction%601> also serves to simplify the creation of complex navigation topologies, which are described in [Navigation Topologies Overview](../../../../docs/framework/wpf/app-development/navigation-topologies-overview.md).  
  
<a name="Hosting"></a>   
## Hosting  
 [!INCLUDE[TLA2#tla_xbap#plural](../../../../includes/tla2sharptla-xbapsharpplural-md.md)] can be hosted in [!INCLUDE[TLA#tla_ie](../../../../includes/tlasharptla-ie-md.md)] or Firefox. Each hosting model has its own set of considerations and constraints that are covered in [Hosting](../../../../docs/framework/wpf/app-development/hosting-wpf-applications.md).  
  
<a name="Build_and_Deploy"></a>   
## Build and Deploy  
 Although simple [!INCLUDE[TLA2#tla_wpf](../../../../includes/tla2sharptla-wpf-md.md)] applications can be built from a command prompt using command-line compilers, [!INCLUDE[TLA2#tla_wpf](../../../../includes/tla2sharptla-wpf-md.md)] integrates with [!INCLUDE[TLA#tla_visualstu](../../../../includes/tlasharptla-visualstu-md.md)] to provide additional support that simplified the development and build process. For more information, see [Building a WPF Application](../../../../docs/framework/wpf/app-development/building-a-wpf-application-wpf.md).  
  
 Depending on the type of application you build, there are one or more deployment options to choose from. For more information, see [Deploying a WPF Application](../../../../docs/framework/wpf/app-development/deploying-a-wpf-application-wpf.md).  
  
<a name="related_topics"></a>   
## Related Topics  
  
|Title|Description|  
|-----------|-----------------|  
|[Application Management Overview](../../../../docs/framework/wpf/app-development/application-management-overview.md)|Provides an overview of the <xref:System.Windows.Application> class including managing application lifetime, windows, application resources, and navigation.|  
|[Windows in WPF](../../../../docs/framework/wpf/app-development/windows-in-wpf-applications.md)|Provides details of managing windows in your application including how to use the <xref:System.Windows.Window> class and dialog boxes.|  
|[Navigation Overview](../../../../docs/framework/wpf/app-development/navigation-overview.md)|Provides an overview of managing navigation between pages of your application.|  
|[Hosting](../../../../docs/framework/wpf/app-development/hosting-wpf-applications.md)|Provides an overview of [!INCLUDE[TLA#tla_xbap#plural](../../../../includes/tlasharptla-xbapsharpplural-md.md)].|  
|[Build and Deploy](../../../../docs/framework/wpf/app-development/building-and-deploying-wpf-applications.md)|Describes how to build and deploy your WPF application.|  
|[Introduction to WPF in Visual Studio](../../../../docs/framework/wpf/getting-started/introduction-to-wpf-in-vs.md)|Describes the main features of WPF.|  
|[Walkthrough: My first WPF desktop application](../../../../docs/framework/wpf/getting-started/walkthrough-my-first-wpf-desktop-application.md)|A walkthrough that shows how to create a WPF application using page navigation, layout, controls, images, styles, and binding.|
