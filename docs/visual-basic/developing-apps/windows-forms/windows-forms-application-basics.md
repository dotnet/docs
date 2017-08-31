---
title: "Windows Forms Application Basics (Visual Basic) | Microsoft Docs"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: "visual-studio-dev14"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "VB"
helpviewer_keywords: 
  - "Windows applications"
  - "Windows Forms, Visual Basic"
ms.assetid: 0b919d30-7fd6-42db-85c8-543d15312441
caps.latest.revision: 20
author: "stevehoag"
ms.author: "shoag"
manager: "wpickett"
---
# Windows Forms Application Basics (Visual Basic)
[!INCLUDE[vs2017banner](../../../includes/vs2017banner.md)]

An important part of [!INCLUDE[vbprvb](../../../includes/vbprvb-md.md)] is the ability to create Windows Forms applications that run locally on users' computers. You can use Visual Studio to create the application and user interface using Windows Forms. A Windows Forms application is built on classes from the <xref:System.Windows.Forms> namespace.  
  
## Designing Windows Forms Applications  
 You can create Windows Forms and Windows service applications with [!INCLUDE[vsprvs](../../../includes/vsprvs-md.md)]. For more information, see the following topics:  
  
-   [Getting Started with Windows Forms](../Topic/Getting%20Started%20with%20Windows%20Forms.md). Provides information on how to create and program Windows Forms.  
  
-   [Windows Forms Walkthroughs](http://msdn.microsoft.com/en-us/fd44d13d-4733-416f-aefc-32592e59e5d9). Lists topics that provide a step-by-step development of commonly created Windows Forms applications based on Windows Forms.  
  
-   [Windows Forms Controls](../Topic/Windows%20Forms%20Controls.md). Collection of topics detailing the use of Windows Forms controls.  
  
-   [Windows Service Applications](../Topic/Developing%20Windows%20Service%20Applications.md). Lists topics that explain how to create Windows services.  
  
## Building Rich, Interactive User Interfaces  
 Windows Forms is the smart-client component of the [!INCLUDE[dnprdnshort](../../../includes/dnprdnshort-md.md)], a set of managed libraries that enable common application tasks such as reading and writing to the file system. Using a development environment like [!INCLUDE[vsprvs](../../../includes/vsprvs-md.md)], you can create Windows Forms applications that display information, request input from users, and communicate with remote computers over a network.  
  
 In Windows Forms, a form is a visual surface on which you display information to the user. You commonly build Windows Forms applications by placing controls on forms and developing responses to user actions, such as mouse clicks or key presses. A *control* is a discrete user interface (UI) element that displays data or accepts data input.  
  
### Events  
 When a user does something to your form or one of its controls, it generates an event. Your application reacts to these events by using code, and processes the events when they occur. For more information, see [Creating Event Handlers in Windows Forms](../Topic/Creating%20Event%20Handlers%20in%20Windows%20Forms.md).  
  
### Controls  
 Windows Forms contains a variety of controls that you can place on forms: controls that display text boxes, buttons, drop-down boxes, radio buttons, and even Web pages. For a list of all the controls you can use on a form, see [Controls to Use on Windows Forms](../Topic/Controls%20to%20Use%20on%20Windows%20Forms.md). If an existing control does not meet your needs, Windows Forms also supports creating your own custom controls using the <xref:System.Windows.Forms.UserControl> class.  
  
 Windows Forms has rich UI controls that emulate features in high-end applications like Microsoft Office. Using the <xref:System.Windows.Forms.ToolStrip> and <xref:System.Windows.Forms.MenuStrip> control, you can create toolbars and menus that contain text and images, display submenus, and host other controls such as text boxes and combo boxes.  
  
 With the [!INCLUDE[vsprvs](../../../includes/vsprvs-md.md)] drag-and-drop forms designer, you can easily create Windows Forms applications: just select the controls with your cursor and place them where you want on the form. The designer provides tools such as grid lines and "snap lines" to take the hassle out of aligning controls. And whether you use [!INCLUDE[vsprvs](../../../includes/vsprvs-md.md)] or compile at the command line, you can use the <xref:System.Windows.Forms.FlowLayoutPanel>, <xref:System.Windows.Forms.TableLayoutPanel> and <xref:System.Windows.Forms.SplitContainer> controls to create advanced form layouts with minimal time and effort.  
  
### Custom UI Elements  
 Finally, if you must create your own custom UI elements, the <xref:System.Drawing> namespace contains all of the classes you need to render lines, circles, and other shapes directly on a form.  
  
 For step-by-step information about using these features, see the following Help topics.  
  
|To|See|  
|--------|---------|  
|Create a new Windows Forms application with [!INCLUDE[vsprvs](../../../includes/vsprvs-md.md)]|[Walkthrough: Creating a Simple Windows Form](http://msdn.microsoft.com/en-us/2d9daec0-0543-41d0-acb1-964f685bddbb)|  
|Use controls on forms|[How to: Add Controls to Windows Forms](../Topic/How%20to:%20Add%20Controls%20to%20Windows%20Forms.md)|  
|Handle events from a form and its controls|[How to: Create Event Handlers Using the Designer](http://msdn.microsoft.com/en-us/8461e9b8-14e8-406f-936e-3726732b23d2)|  
|Use the <xref:System.Windows.Forms.ToolStrip> Control|[How to: Create a Basic ToolStrip with Standard Items Using the Designer](../Topic/How%20to:%20Create%20a%20Basic%20Windows%20Forms%20ToolStrip%20with%20Standard%20Items%20Using%20the%20Designer.md)|  
|Create graphics with <xref:System.Drawing>|[Getting Started with Graphics Programming](../Topic/Getting%20Started%20with%20Graphics%20Programming.md)|  
|Create custom controls|[How to: Inherit from the UserControl Class](../Topic/How%20to:%20Inherit%20from%20the%20UserControl%20Class.md)|  
  
## Displaying and Manipulating Data  
 Many applications must display data from a database, XML file, XML Web service, or other data source. Windows Forms provides a flexible control called the <xref:System.Windows.Forms.DataGridView> control for rendering such tabular data in a traditional row and column format, so that every piece of data occupies its own cell. Using <xref:System.Windows.Forms.DataGridView> you can customize the appearance of individual cells, lock arbitrary rows and columns in place, and display complex controls inside cells, among other features.  
  
 Connecting to data sources over a network is a simple task with Windows Forms smart clients. The <xref:System.Windows.Forms.BindingSource> component, new with Windows Forms in [!INCLUDE[vsprvslong](../../../includes/vsprvslong-md.md)] and the [!INCLUDE[dnprdnlong](../../../includes/dnprdnlong-md.md)], represents a connection to a data source, and exposes methods for binding data to controls, navigating to the previous and next records, editing records, and saving changes back to the original source. The <xref:System.Windows.Forms.BindingNavigator> control provides a simple interface over the <xref:System.Windows.Forms.BindingSource> component for users to navigate between records.  
  
### Data-Bound Controls  
 You can create data-bound controls easily using the Data Sources window, which displays data sources such as databases, Web services, and objects in your project. You can create data-bound controls by dragging items from this window onto forms in your project. You can also data-bind existing controls to data by dragging objects from the Data Sources window onto existing controls.  
  
### Settings  
 Another type of data binding you can manage in Windows Forms is settings. Most smart-client applications must retain some information about their run-time state, such as the last-known size of forms, and retain user-preference data, such as default locations for saved files. The application-settings feature addresses these requirements by providing an easy way to store both types of settings on the client computer. Once defined using either [!INCLUDE[vsprvs](../../../includes/vsprvs-md.md)] or a code editor, these settings are persisted as XML and automatically read back into memory at run time.  
  
 For step-by-step information about using these features, see the following Help topics.  
  
|To|See|  
|--------|---------|  
|Use the <xref:System.Windows.Forms.BindingSource> component|[How to: Bind Windows Forms Controls with the BindingSource Component Using the Designer](../Topic/How%20to:%20Bind%20Windows%20Forms%20Controls%20with%20the%20BindingSource%20Component%20Using%20the%20Designer.md)|  
|Work with [!INCLUDE[vstecado](../../../includes/vstecado-md.md)] data sources|[How to: Sort and Filter ADO.NET Data with the Windows Forms BindingSource Component](../Topic/How%20to:%20Sort%20and%20Filter%20ADO.NET%20Data%20with%20the%20Windows%20Forms%20BindingSource%20Component.md)|  
|Use the Data Sources window|[Walkthrough: Displaying Data on a Windows Form](../Topic/Walkthrough:%20Displaying%20Data%20on%20a%20Windows%20Form.md)|  
|Use application settings|[How to: Create Application Settings Using the Designer](http://msdn.microsoft.com/en-us/53b3af80-1c02-4e35-99c6-787663148945)|  
  
## Deploying Applications to Client Computers  
 Once you have written your application, you must send it to your users so that they can install and run it on their own client computers. Using the [!INCLUDE[ndptecclick](../../../includes/ndptecclick-md.md)] technology, you can deploy your applications from within [!INCLUDE[vsprvs](../../../includes/vsprvs-md.md)] by using just a few clicks and provide users with a URL pointing to your application on the Web. [!INCLUDE[ndptecclick](../../../includes/ndptecclick-md.md)] manages all of the elements and dependencies in your application and ensures that the application is properly installed on the client computer.  
  
 [!INCLUDE[ndptecclick](../../../includes/ndptecclick-md.md)] applications can be configured to run only when the user is connected to the network, or to run both online and offline. When you specify that an application should support offline operation, [!INCLUDE[ndptecclick](../../../includes/ndptecclick-md.md)] adds a link to your application in the user's **Start** menu, so that the user can open it without using the URL.  
  
 When you update your application, you publish a new deployment manifest and a new copy of your application to your Web server. [!INCLUDE[ndptecclick](../../../includes/ndptecclick-md.md)] detects that there is an update available and upgrades the user's installation; no custom programming is required to update old assemblies.  
  
 For a full introduction to [!INCLUDE[ndptecclick](../../../includes/ndptecclick-md.md)], see [ClickOnce Security and Deployment](/visual-studio/deployment/clickonce-security-and-deployment). For step-by-step information about using these features, see the following Help topics:  
  
|To|See|  
|--------|---------|  
|Deploy an application with [!INCLUDE[ndptecclick](../../../includes/ndptecclick-md.md)]|[How to: Publish a ClickOnce Application using the Publish Wizard](../Topic/How%20to:%20Publish%20a%20ClickOnce%20Application%20using%20the%20Publish%20Wizard.md)<br /><br /> [Walkthrough: Manually Deploying a ClickOnce Application](../Topic/Walkthrough:%20Manually%20Deploying%20a%20ClickOnce%20Application.md)|  
|Update a [!INCLUDE[ndptecclick](../../../includes/ndptecclick-md.md)] deployment|[How to: Manage Updates for a ClickOnce Application](../Topic/How%20to:%20Manage%20Updates%20for%20a%20ClickOnce%20Application.md)|  
|Manage security with [!INCLUDE[ndptecclick](../../../includes/ndptecclick-md.md)]|[How to: Enable ClickOnce Security Settings](../Topic/How%20to:%20Enable%20ClickOnce%20Security%20Settings.md)|  
  
## Other Controls and Features  
 There are many other features in Windows Forms that make implementing common tasks fast and easy, such as support for creating dialog boxes, printing, adding Help and documentation, and localizing your application to multiple languages. In addition, Windows Forms relies on the robust security system of the [!INCLUDE[dnprdnshort](../../../includes/dnprdnshort-md.md)], enabling you to release more secure applications to your customers.  
  
 For step-by-step information about using these features, see the following Help topics:  
  
|To|See|  
|--------|---------|  
|Print the contents of a form|[How to: Print Graphics in Windows Forms](../Topic/How%20to:%20Print%20Graphics%20in%20Windows%20Forms.md)<br /><br /> [How to: Print a Multi-Page Text File in Windows Forms](../Topic/How%20to:%20Print%20a%20Multi-Page%20Text%20File%20in%20Windows%20Forms.md)|  
|Globalize a Windows Forms application|[Walkthrough: Localizing Windows Forms](http://msdn.microsoft.com/en-us/9a96220d-a19b-4de0-9f48-01e5d82679e5)|  
|Learn more about Windows Forms security|[Security in Windows Forms Overview](../Topic/Security%20in%20Windows%20Forms%20Overview.md)|  
  
## See Also  
 <xref:Microsoft.VisualBasic.ApplicationServices.WindowsFormsApplicationBase>   
 [Windows Forms Overview](../Topic/Windows%20Forms%20Overview.md)   
 [My.Forms Object](../../../visual-basic/language-reference/objects/my-forms-object.md)