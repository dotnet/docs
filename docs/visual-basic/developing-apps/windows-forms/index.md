---
description: "Learn more about: Windows Forms Application Basics (Visual Basic)"
title: "Windows Forms Application Basics"
ms.date: 07/20/2015
helpviewer_keywords:
  - "Windows applications"
  - "Windows Forms, Visual Basic"
ms.assetid: 0b919d30-7fd6-42db-85c8-543d15312441
---
# Windows Forms Application Basics (Visual Basic)

An important part of Visual Basic is the ability to create Windows Forms applications that run locally on users' computers. You can use Visual Studio to create the application and user interface using Windows Forms. A Windows Forms application is built on classes from the <xref:System.Windows.Forms> namespace.

## Designing Windows Forms Applications

You can create Windows Forms and Windows service applications with Visual Studio. For more information, see the following topics:

- [Getting Started with Windows Forms](/dotnet/desktop/winforms/getting-started-with-windows-forms). Provides information on how to create and program Windows Forms.

- [Windows Forms Controls](/dotnet/desktop/winforms/controls/). Collection of topics detailing the use of Windows Forms controls.

- [Windows Service Applications](../../../framework/windows-services/index.md). Lists topics that explain how to create Windows services.

## Building Rich, Interactive User Interfaces

Windows Forms is the smart-client component of the .NET Framework and .NET Core (since .NET Core 3.0). It's a set of managed libraries that enable common application tasks, such as reading and writing to the file system. Using a development environment like Visual Studio, you can create Windows Forms applications that display information, request input from users, and communicate with remote computers over a network.

In Windows Forms, a form is a visual surface on which you display information to the user. You commonly build Windows Forms applications by placing controls on forms and developing responses to user actions, such as mouse clicks or key presses. A *control* is a discrete user interface (UI) element that displays data or accepts data input.

### Events

When a user does something to your form or one of its controls, it generates an event. Your application reacts to these events by using code, and processes the events when they occur. For more information, see [Creating Event Handlers in Windows Forms](/dotnet/desktop/winforms/creating-event-handlers-in-windows-forms).

### Controls

Windows Forms contains a variety of controls that you can place on forms: controls that display text boxes, buttons, drop-down boxes, radio buttons, and even Web pages. For a list of all the controls you can use on a form, see [Controls to Use on Windows Forms](/dotnet/desktop/winforms/controls/controls-to-use-on-windows-forms). If an existing control does not meet your needs, Windows Forms also supports creating your own custom controls using the <xref:System.Windows.Forms.UserControl> class.

Windows Forms has rich UI controls that emulate features in high-end applications like Microsoft Office. Using the <xref:System.Windows.Forms.ToolStrip> and <xref:System.Windows.Forms.MenuStrip> control, you can create toolbars and menus that contain text and images, display submenus, and host other controls such as text boxes and combo boxes.

With the Visual Studio drag-and-drop forms designer, you can easily create Windows Forms applications: just select the controls with your cursor and place them where you want on the form. The designer provides tools such as grid lines and "snap lines" to take the hassle out of aligning controls. And whether you use Visual Studio or compile at the command line, you can use the <xref:System.Windows.Forms.FlowLayoutPanel>, <xref:System.Windows.Forms.TableLayoutPanel> and <xref:System.Windows.Forms.SplitContainer> controls to create advanced form layouts with minimal time and effort.

### Custom UI Elements

Finally, if you must create your own custom UI elements, the <xref:System.Drawing> namespace contains all of the classes you need to render lines, circles, and other shapes directly on a form.

For step-by-step information about using these features, see the following Help topics.

|To|See|
|--------|---------|
|Create a new Windows Forms application with Visual Studio|[Tutorial 1: Create a picture viewer](/visualstudio/ide/tutorial-1-create-a-picture-viewer)|
|Use controls on forms|[How to: Add Controls to Windows Forms](/dotnet/desktop/winforms/controls/how-to-add-controls-to-windows-forms)|
|Create graphics with <xref:System.Drawing>|[Getting Started with Graphics Programming](/dotnet/desktop/winforms/advanced/getting-started-with-graphics-programming)|
|Create custom controls|[How to: Inherit from the UserControl Class](/dotnet/desktop/winforms/controls/how-to-inherit-from-the-usercontrol-class)|

## Displaying and Manipulating Data

Many applications must display data from a database, XML file, XML Web service, or other data source. Windows Forms provides a flexible control called the <xref:System.Windows.Forms.DataGridView> control for rendering such tabular data in a traditional row and column format, so that every piece of data occupies its own cell. Using <xref:System.Windows.Forms.DataGridView> you can customize the appearance of individual cells, lock arbitrary rows and columns in place, and display complex controls inside cells, among other features.

Connecting to data sources over a network is a simple task with Windows Forms smart clients. The <xref:System.Windows.Forms.BindingSource> component, new with Windows Forms in Visual Studio 2005 and the .NET Framework 2.0, represents a connection to a data source, and exposes methods for binding data to controls, navigating to the previous and next records, editing records, and saving changes back to the original source. The <xref:System.Windows.Forms.BindingNavigator> control provides a simple interface over the <xref:System.Windows.Forms.BindingSource> component for users to navigate between records.

### Data-Bound Controls

You can create data-bound controls easily using the Data Sources window, which displays data sources such as databases, Web services, and objects in your project. You can create data-bound controls by dragging items from this window onto forms in your project. You can also data-bind existing controls to data by dragging objects from the Data Sources window onto existing controls.

### Settings

Another type of data binding you can manage in Windows Forms is settings. Most smart-client applications must retain some information about their run-time state, such as the last-known size of forms, and retain user-preference data, such as default locations for saved files. The application-settings feature addresses these requirements by providing an easy way to store both types of settings on the client computer. Once defined using either Visual Studio or a code editor, these settings are persisted as XML and automatically read back into memory at run time.

For step-by-step information about using these features, see the following Help topics.

|To|See|
|--------|---------|
|Use the <xref:System.Windows.Forms.BindingSource> component|[How to: Bind Windows Forms Controls with the BindingSource Component Using the Designer](/dotnet/desktop/winforms/controls/bind-wf-controls-with-the-bindingsource)|
|Work with ADO.NET data sources|[How to: Sort and Filter ADO.NET Data with the Windows Forms BindingSource Component](/dotnet/desktop/winforms/controls/sort-and-filter-ado-net-data-with-wf-bindingsource-component)|
|Use the Data Sources window|[Walkthrough: Displaying Data on a Windows Form](/visualstudio/data-tools/accessing-data-in-visual-studio)|

## Deploying Applications to Client Computers

Once you have written your application, you must send it to your users so that they can install and run it on their own client computers. Using the ClickOnce technology, you can deploy your applications from within Visual Studio by using just a few clicks and provide users with a URL pointing to your application on the Web. ClickOnce manages all of the elements and dependencies in your application and ensures that the application is properly installed on the client computer.

ClickOnce applications can be configured to run only when the user is connected to the network, or to run both online and offline. When you specify that an application should support offline operation, ClickOnce adds a link to your application in the user's **Start** menu, so that the user can open it without using the URL.

When you update your application, you publish a new deployment manifest and a new copy of your application to your Web server. ClickOnce detects that there is an update available and upgrades the user's installation; no custom programming is required to update old assemblies.

For a full introduction to ClickOnce, see [ClickOnce Security and Deployment](/visualstudio/deployment/clickonce-security-and-deployment). For step-by-step information about using these features, see the following Help topics:

|To|See|
|--------|---------|
|Deploy an application with ClickOnce|[How to: Publish a ClickOnce Application using the Publish Wizard](/visualstudio/deployment/how-to-publish-a-clickonce-application-using-the-publish-wizard)<br /><br /> [Walkthrough: Manually Deploying a ClickOnce Application](/visualstudio/deployment/walkthrough-manually-deploying-a-clickonce-application)|
|Update a ClickOnce deployment|[How to: Manage Updates for a ClickOnce Application](/visualstudio/deployment/how-to-manage-updates-for-a-clickonce-application)|
|Manage security with ClickOnce|[How to: Enable ClickOnce Security Settings](/visualstudio/deployment/how-to-enable-clickonce-security-settings)|

## Other Controls and Features

There are many other features in Windows Forms that make implementing common tasks fast and easy, such as support for creating dialog boxes, printing, adding documentation, and localizing your application to multiple languages. In addition, Windows Forms relies on the robust security system of .NET, enabling you to release more secure applications to your customers.

For step-by-step information about using these features, see the following Help topics:

|To|See|
|--------|---------|
|Print the contents of a form|[How to: Print Graphics in Windows Forms](/dotnet/desktop/winforms/advanced/how-to-print-graphics-in-windows-forms)<br /><br /> [How to: Print a Multi-Page Text File in Windows Forms](/dotnet/desktop/winforms/advanced/how-to-print-a-multi-page-text-file-in-windows-forms)|
|Learn more about Windows Forms security|[Security in Windows Forms Overview](/dotnet/desktop/winforms/security-in-windows-forms-overview)|

## See also

- <xref:Microsoft.VisualBasic.ApplicationServices.WindowsFormsApplicationBase>
- [Windows Forms Overview](/dotnet/desktop/winforms/windows-forms-overview)
- [My.Forms Object](../../language-reference/objects/my-forms-object.md)
