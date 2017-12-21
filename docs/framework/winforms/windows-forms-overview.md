---
title: "Windows Forms Overview"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-winforms"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "smart clients"
  - "Windows Forms, about Windows Forms"
ms.assetid: 3a2b6284-c8d6-4e1c-8c69-0bed38f38cd4
caps.latest.revision: 34
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Windows Forms Overview
The following overview discusses the advantages of smart client applications, the main features of Windows Forms programming, and how you can use Windows Forms to build smart clients that meet the needs of today's enterprises and end users.  
  
## Windows Forms and Smart Client Applications  
 With Windows Forms you develop smart clients. *Smart clients* are graphically rich applications that are easy to deploy and update, can work when they are connected to or disconnected from the Internet, and can access resources on the local computer in a more secure manner than traditional Windows-based applications.  
  
### Building Rich, Interactive User Interfaces  
 Windows Forms is a smart client technology for the [!INCLUDE[dnprdnshort](../../../includes/dnprdnshort-md.md)], a set of managed libraries that simplify common application tasks such as reading and writing to the file system. When you use a development environment like [!INCLUDE[vsprvs](../../../includes/vsprvs-md.md)], you can create Windows Forms smart-client applications that display information, request input from users, and communicate with remote computers over a network.  
  
 In Windows Forms, a *form* is a visual surface on which you display information to the user. You ordinarily build Windows Forms applications by adding controls to forms and developing responses to user actions, such as mouse clicks or key presses. A *control* is a discrete user interface (UI) element that displays data or accepts data input.  
  
 When a user does something to your form or one of its controls, the action generates an event. Your application reacts to these events by using code, and processes the events when they occur. For more information, see [Creating Event Handlers in Windows Forms](../../../docs/framework/winforms/creating-event-handlers-in-windows-forms.md).  
  
 Windows Forms contains a variety of controls that you can add to forms: controls that display text boxes, buttons, drop-down boxes, radio buttons, and even Web pages. For a list of all the controls you can use on a form, see [Controls to Use on Windows Forms](../../../docs/framework/winforms/controls/controls-to-use-on-windows-forms.md). If an existing control does not meet your needs, Windows Forms also supports creating your own custom controls using the <xref:System.Windows.Forms.UserControl> class.  
  
 Windows Forms has rich UI controls that emulate features in high-end applications like Microsoft Office. When you use the <xref:System.Windows.Forms.ToolStrip> and <xref:System.Windows.Forms.MenuStrip> control, you can create toolbars and menus that contain text and images, display submenus, and host other controls such as text boxes and combo boxes.  
  
 With the [!INCLUDE[vsprvs](../../../includes/vsprvs-md.md)] drag-and-drop Windows Forms Designer, you can easily create Windows Forms applications. Just select the controls with your cursor and add them where you want on the form. The designer provides tools such as gridlines and snap lines to take the hassle out of aligning controls. And whether you use [!INCLUDE[vsprvs](../../../includes/vsprvs-md.md)] or compile at the command line, you can use the <xref:System.Windows.Forms.FlowLayoutPanel>, <xref:System.Windows.Forms.TableLayoutPanel> and <xref:System.Windows.Forms.SplitContainer> controls to create advanced form layouts in less time.  
  
 Finally, if you must create your own custom UI elements, the <xref:System.Drawing> namespace contains a large selection of classes to render lines, circles, and other shapes directly on a form.  
  
> [!NOTE]
>  Windows Forms controls are not designed to be marshaled across application domains. For this reason, Microsoft does not support passing a Windows Forms control across an <xref:System.AppDomain> boundary, even though the <xref:System.Windows.Controls.Control> base type of <xref:System.MarshalByRefObject> would seem to indicate that this is possible. Windows Forms applications that have multiple application domains are supported as long as no Windows Forms controls are passed across application domain boundaries.  
  
#### Help Creating Forms and Controls  
 For step-by-step information about how to use these features, see the following Help topics.  
  
|Description|Help topic|  
|-----------------|----------------|  
|Using controls on forms|[How to: Add Controls to Windows Forms](../../../docs/framework/winforms/controls/how-to-add-controls-to-windows-forms.md)|  
|Using the <xref:System.Windows.Forms.ToolStrip> Control|[How to: Create a Basic ToolStrip with Standard Items Using the Designer](../../../docs/framework/winforms/controls/create-a-basic-wf-toolstrip-with-standard-items-using-the-designer.md)|  
|Creating graphics with <xref:System.Drawing>|[Getting Started with Graphics Programming](../../../docs/framework/winforms/advanced/getting-started-with-graphics-programming.md)|  
|Creating custom controls|[How to: Inherit from the UserControl Class](../../../docs/framework/winforms/controls/how-to-inherit-from-the-usercontrol-class.md)|  
  
### Displaying and Manipulating Data  
 Many applications must display data from a database, XML file, XML Web service, or other data source. Windows Forms provides a flexible control that is named the <xref:System.Windows.Forms.DataGridView> control for displaying such tabular data in a traditional row and column format, so that every piece of data occupies its own cell. When you use <xref:System.Windows.Forms.DataGridView>, you can customize the appearance of individual cells, lock arbitrary rows and columns in place, and display complex controls inside cells, among other features.  
  
 Connecting to data sources over a network is a simple task with Windows Forms smart clients. The <xref:System.Windows.Forms.BindingSource> component, new with Windows Forms in [!INCLUDE[vsprvslong](../../../includes/vsprvslong-md.md)] and the [!INCLUDE[dnprdnlong](../../../includes/dnprdnlong-md.md)], represents a connection to a data source, and exposes methods for binding data to controls, navigating to the previous and next records, editing records, and saving changes back to the original source. The <xref:System.Windows.Forms.BindingNavigator> control provides a simple interface over the <xref:System.Windows.Forms.BindingSource> component for users to navigate between records.  
  
 You can create data-bound controls easily by using the Data Sources window. The window displays data sources such as databases, Web services, and objects in your project. You can create data-bound controls by dragging items from this window onto forms in your project. You can also data-bind existing controls to data by dragging objects from the Data Sources window onto existing controls.  
  
 Another type of data binding you can manage in Windows Forms is *settings*. Most smart client applications must retain some information about their run-time state, such as the last-known size of forms, and retain user preference data, such as default locations for saved files. The Application Settings feature addresses these requirements by providing an easy way to store both types of settings on the client computer. After you define these settings by using either [!INCLUDE[vsprvs](../../../includes/vsprvs-md.md)] or a code editor, the settings are persisted as XML and automatically read back into memory at run time.  
  
#### Help Displaying and Manipulating Data  
 For step-by-step information about how to use these features, see the following Help topics.  
  
|Description|Help topic|  
|-----------------|----------------|  
|Using the <xref:System.Windows.Forms.BindingSource> component|[How to: Bind Windows Forms Controls with the BindingSource Component Using the Designer](../../../docs/framework/winforms/controls/bind-wf-controls-with-the-bindingsource.md)|  
|Working with [!INCLUDE[vstecado](../../../includes/vstecado-md.md)] data sources|[How to: Sort and Filter ADO.NET Data with the Windows Forms BindingSource Component](../../../docs/framework/winforms/controls/sort-and-filter-ado-net-data-with-wf-bindingsource-component.md)|  
|Using the Data Sources window|[Walkthrough: Displaying Data on a Windows Form](http://msdn.microsoft.com/library/f6e08c2c-c792-43de-adf3-3e52c0100225)|  
|Using application settings|[How to: Create Application Settings](../../../docs/framework/winforms/advanced/how-to-create-application-settings.md)|  
  
### Deploying Applications to Client Computers  
 After you have written your application, you must send the application to your users so that they can install and run it on their own client computers. When you use the [!INCLUDE[ndptecclick](../../../includes/ndptecclick-md.md)] technology, you can deploy your applications from within [!INCLUDE[vsprvs](../../../includes/vsprvs-md.md)] by using just a few clicks, and provide your users with a URL pointing to your application on the Web. [!INCLUDE[ndptecclick](../../../includes/ndptecclick-md.md)] manages all the elements and dependencies in your application, and ensures that the application is correctly installed on the client computer.  
  
 [!INCLUDE[ndptecclick](../../../includes/ndptecclick-md.md)] applications can be configured to run only when the user is connected to the network, or to run both online and offline. When you specify that an application should support offline operation, [!INCLUDE[ndptecclick](../../../includes/ndptecclick-md.md)] adds a link to your application in the user's **Start** menu. The user can then open the application without using the URL.  
  
 When you update your application, you publish a new deployment manifest and a new copy of your application to your Web server. [!INCLUDE[ndptecclick](../../../includes/ndptecclick-md.md)] will detect that there is an update available and upgrade the user's installation; no custom programming is required to update old assemblies.  
  
#### Help Deploying ClickOnce Applications  
 For a full introduction to [!INCLUDE[ndptecclick](../../../includes/ndptecclick-md.md)], see [ClickOnce Security and Deployment](/visualstudio/deployment/clickonce-security-and-deployment). For step-by-step information about how to use these features, see the following Help topics,  
  
|Description|Help topic|  
|-----------------|----------------|  
|Deploying an application by using [!INCLUDE[ndptecclick](../../../includes/ndptecclick-md.md)]|[How to: Publish a ClickOnce Application using the Publish Wizard](/visualstudio/deployment/how-to-publish-a-clickonce-application-using-the-publish-wizard)<br /><br /> [Walkthrough: Manually Deploying a ClickOnce Application](/visualstudio/deployment/walkthrough-manually-deploying-a-clickonce-application)|  
|Updating a [!INCLUDE[ndptecclick](../../../includes/ndptecclick-md.md)] deployment|[How to: Manage Updates for a ClickOnce Application](/visualstudio/deployment/how-to-manage-updates-for-a-clickonce-application)|  
|Managing security with [!INCLUDE[ndptecclick](../../../includes/ndptecclick-md.md)]|[How to: Enable ClickOnce Security Settings](/visualstudio/deployment/how-to-enable-clickonce-security-settings)|  
  
### Other Controls and Features  
 There are many other features in Windows Forms that make implementing common tasks fast and easy, such as support for creating dialog boxes, printing, adding Help and documentation, and localizing your application to multiple languages. Additionally, Windows Forms relies on the robust security system of the [!INCLUDE[dnprdnshort](../../../includes/dnprdnshort-md.md)]. With this system, you can release more secure applications to your customers.  
  
#### Help Implementing Other Controls and Features  
 For step-by-step information about how to use these features, see the following Help topics.  
  
|Description|Help topic|  
|-----------------|----------------|  
|Printing the contents of a form|[How to: Print Graphics in Windows Forms](../../../docs/framework/winforms/advanced/how-to-print-graphics-in-windows-forms.md)<br /><br /> [How to: Print a Multi-Page Text File in Windows Forms](../../../docs/framework/winforms/advanced/how-to-print-a-multi-page-text-file-in-windows-forms.md)|  
|Learn more about Windows Forms security|[Security in Windows Forms Overview](../../../docs/framework/winforms/security-in-windows-forms-overview.md)|  
  
## See Also  
 [Getting Started with Windows Forms](../../../docs/framework/winforms/getting-started-with-windows-forms.md)  
 [Creating a New Windows Form](../../../docs/framework/winforms/creating-a-new-windows-form.md)  
 [ToolStrip Control Overview](../../../docs/framework/winforms/controls/toolstrip-control-overview-windows-forms.md)  
 [DataGridView Control Overview](../../../docs/framework/winforms/controls/datagridview-control-overview-windows-forms.md)  
 [BindingSource Component Overview](../../../docs/framework/winforms/controls/bindingsource-component-overview.md)  
 [Application Settings Overview](../../../docs/framework/winforms/advanced/application-settings-overview.md)  
 [ClickOnce Security and Deployment](/visualstudio/deployment/clickonce-security-and-deployment)
