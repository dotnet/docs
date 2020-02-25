---
title: "Application Development"
ms.date: "01/26/2018"
helpviewer_keywords: 
  - "WPF [WPF], about application development"
  - "application development [WPF], about"
ms.assetid: 2996ce5e-81e9-49ae-881b-952db3dd1b7e
---
# Application Development
<a name="introduction"></a>
Windows Presentation Foundation (WPF) is a presentation framework that can be used to develop the following types of applications:  
  
- Standalone Applications (traditional style Windows applications built as executable assemblies that are installed to and run from the client computer).  
  
- XAML browser applications (XBAPs) (applications composed of navigation pages that are built as executable assemblies and hosted by Web browsers such as Microsoft Internet Explorer or Mozilla Firefox).  
  
- Custom Control Libraries (non-executable assemblies containing reusable controls).  
  
- Class Libraries (non-executable assemblies that contain reusable classes).  
  
> [!NOTE]
> Using WPF types in a Windows service is strongly discouraged. If you attempt to use these features in a Windows service, they may not work as expected.  
  
 To build this set of applications, WPF implements a host of services. This topic provides an overview of these services and where to find more information.  

<a name="Application_Management"></a>   
## Application Management  
 Executable WPF applications commonly require a core set of functionality that includes the following:  
  
- Creating and managing common application infrastructure (including creating an entry point method and a Windows message loop to receive system and input messages).  
  
- Tracking and interacting with the lifetime of an application.  
  
- Retrieving and processing command-line parameters.  
  
- Sharing application-scope properties and [!INCLUDE[TLA2#tla_ui](../../../../includes/tla2sharptla-ui-md.md)] resources.  
  
- Detecting and processing unhandled exceptions.  
  
- Returning exit codes.  
  
- Managing windows in standalone applications.  
  
- Tracking navigation in XAML browser applications (XBAPs), and standalone applications with navigation windows and frames.  
  
 These capabilities are implemented by the <xref:System.Windows.Application> class, which you add to your applications using an *application definition*.  
  
 For more information, see [Application Management Overview](application-management-overview.md).  
  
<a name="WPF_Application_Resource__Content__and_Data_Files"></a>   
## WPF Application Resource, Content, and Data Files  
 WPF extends the core support in the Microsoft .NET Framework for embedded resources with support for three kinds of non-executable data files: resource, content, and data. For more information, see [WPF Application Resource, Content, and Data Files](wpf-application-resource-content-and-data-files.md).  
  
 A key component of the support for WPF non-executable data files is the ability to identify and load them using a unique URI. For more information, see [Pack URIs in WPF](pack-uris-in-wpf.md).  
  
<a name="Windows_and_Dialog_Boxes"></a>   
## Windows and Dialog Boxes  
 Users interact with WPF standalone applications through windows. The purpose of a window is to host application content and expose application functionality that usually allows users to interact with the content. In WPF, windows are encapsulated by the <xref:System.Windows.Window> class, which supports:  
  
- Creating and showing windows.  
  
- Establishing owner/owned window relationships.  
  
- Configuring window appearance (for example, size, location, icons, title bar text, border).  
  
- Tracking and interacting with the lifetime of a window.  
  
 For more information, see [WPF Windows Overview](wpf-windows-overview.md).  
  
 <xref:System.Windows.Window> supports the ability to create a special type of window known as a dialog box. Both modal and modeless types of dialog boxes can be created.  
  
 For convenience, and the benefits of reusability and a consistent user experience across applications, WPF exposes three of the common Windows dialog boxes: <xref:Microsoft.Win32.OpenFileDialog>, <xref:Microsoft.Win32.SaveFileDialog>, and <xref:System.Windows.Controls.PrintDialog>.  
  
 A message box is a special type of dialog box for showing important textual information to users, and for asking simple Yes/No/OK/Cancel questions. You use the <xref:System.Windows.MessageBox> class to create and show message boxes.  
  
 For more information, see [Dialog Boxes Overview](dialog-boxes-overview.md).  
  
<a name="Navigation"></a>   
## Navigation  
 WPF supports Web-style navigation using pages (<xref:System.Windows.Controls.Page>) and hyperlinks (<xref:System.Windows.Documents.Hyperlink>). Navigation can be implemented in a variety of ways that include the following:  
  
- Standalone pages that are hosted in a Web browser.  
  
- Pages compiled into an XBAP that is hosted in a Web browser.  
  
- Pages compiled into a standalone application and hosted by a navigation window (<xref:System.Windows.Navigation.NavigationWindow>).  
  
- Pages that are hosted by a frame (<xref:System.Windows.Controls.Frame>), which may be hosted in a standalone page, or a page compiled into either an XBAP or a standalone application.  
  
 To facilitate navigation, WPF implements the following:  
  
- <xref:System.Windows.Navigation.NavigationService>, the shared navigation engine for processing navigation requests that is used by <xref:System.Windows.Controls.Frame>, <xref:System.Windows.Navigation.NavigationWindow>, and XBAPs to support intra-application navigation.  
  
- Navigation methods to initiate navigation.  
  
- Navigation events to track and interact with navigation lifetime.  
  
- Remembering back and forward navigation using a journal, which can also be inspected and manipulated.  
  
 For information, see [Navigation Overview](navigation-overview.md).  
  
 WPF also supports a special type of navigation known as structured navigation. Structured navigation can be used to call one or more pages that return data in a structured and predictable way that is consistent with calling functions. This capability depends on the <xref:System.Windows.Navigation.PageFunction%601> class, which is described further in [Structured Navigation Overview](structured-navigation-overview.md). <xref:System.Windows.Navigation.PageFunction%601> also serves to simplify the creation of complex navigation topologies, which are described in [Navigation Topologies Overview](navigation-topologies-overview.md).  
  
<a name="Hosting"></a>   
## Hosting  
 XBAPs can be hosted in Microsoft Internet Explorer or Firefox. Each hosting model has its own set of considerations and constraints that are covered in [Hosting](hosting-wpf-applications.md).  
  
<a name="Build_and_Deploy"></a>   
## Build and Deploy  
 Although simple WPF applications can be built from a command prompt using command-line compilers, WPF integrates with Visual Studio to provide additional support that simplified the development and build process. For more information, see [Building a WPF Application](building-a-wpf-application-wpf.md).  
  
 Depending on the type of application you build, there are one or more deployment options to choose from. For more information, see [Deploying a WPF Application](deploying-a-wpf-application-wpf.md).  
  
<a name="related_topics"></a>   
## Related Topics  
  
|Title|Description|  
|-----------|-----------------|  
|[Application Management Overview](application-management-overview.md)|Provides an overview of the <xref:System.Windows.Application> class including managing application lifetime, windows, application resources, and navigation.|  
|[Windows in WPF](windows-in-wpf-applications.md)|Provides details of managing windows in your application including how to use the <xref:System.Windows.Window> class and dialog boxes.|  
|[Navigation Overview](navigation-overview.md)|Provides an overview of managing navigation between pages of your application.|  
|[Hosting](hosting-wpf-applications.md)|Provides an overview of XAML browser applications (XBAPs).|  
|[Build and Deploy](building-and-deploying-wpf-applications.md)|Describes how to build and deploy your WPF application.|  
|[Introduction to WPF in Visual Studio](../getting-started/introduction-to-wpf-in-vs.md)|Describes the main features of WPF.|  
|[Walkthrough: My first WPF desktop application](../getting-started/walkthrough-my-first-wpf-desktop-application.md)|A walkthrough that shows how to create a WPF application using page navigation, layout, controls, images, styles, and binding.|
