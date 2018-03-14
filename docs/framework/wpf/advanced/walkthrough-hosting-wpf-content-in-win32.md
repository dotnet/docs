---
title: "Walkthrough: Hosting WPF Content in Win32"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-wpf"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "cpp"
helpviewer_keywords: 
  - "hosting WPF content in Win32 window [WPF]"
ms.assetid: 38ce284a-4303-46dd-b699-c9365b22a7dc
caps.latest.revision: 24
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Walkthrough: Hosting WPF Content in Win32
[!INCLUDE[TLA#tla_winclient](../../../../includes/tlasharptla-winclient-md.md)] provides a rich environment for creating applications. However, when you have a substantial investment in [!INCLUDE[TLA#tla_win32](../../../../includes/tlasharptla-win32-md.md)] code, it might be more effective to add [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] functionality to your application rather than rewriting your original code. [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] provides a straightforward mechanism for hosting [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] content in a [!INCLUDE[TLA2#tla_win32](../../../../includes/tla2sharptla-win32-md.md)] window.  
  
 This tutorial describes how to write a sample application, [Hosting WPF Content in a Win32 Window Sample](http://go.microsoft.com/fwlink/?LinkID=160004), that hosts [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] content in a [!INCLUDE[TLA2#tla_win32](../../../../includes/tla2sharptla-win32-md.md)] window. You can extend this sample to host any [!INCLUDE[TLA2#tla_win32](../../../../includes/tla2sharptla-win32-md.md)] window. Because it involves mixing managed and unmanaged code, the application is written in [!INCLUDE[TLA#tla_cppcli](../../../../includes/tlasharptla-cppcli-md.md)].  
  
 
  
<a name="requirements"></a>   
## Requirements  
 This tutorial assumes a basic familiarity with both [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] and [!INCLUDE[TLA2#tla_win32](../../../../includes/tla2sharptla-win32-md.md)] programming. For a basic introduction to [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] programming, see [Getting Started](../../../../docs/framework/wpf/getting-started/index.md). For an introduction to [!INCLUDE[TLA2#tla_win32](../../../../includes/tla2sharptla-win32-md.md)] programming, you should reference any of the numerous books on the subject, in particular *Programming Windows* by Charles Petzold.  
  
 Because the sample that accompanies this tutorial is implemented in [!INCLUDE[TLA#tla_cppcli](../../../../includes/tlasharptla-cppcli-md.md)], this tutorial assumes familiarity with the use of [!INCLUDE[TLA#tla_cpp](../../../../includes/tlasharptla-cpp-md.md)] to program the [!INCLUDE[TLA2#tla_win32](../../../../includes/tla2sharptla-win32-md.md)][!INCLUDE[TLA2#tla_api](../../../../includes/tla2sharptla-api-md.md)] plus an understanding of managed code programming. Familiarity with [!INCLUDE[TLA#tla_cppcli](../../../../includes/tlasharptla-cppcli-md.md)] is helpful but not essential.  
  
> [!NOTE]
>  This tutorial includes a number of code examples from the associated sample. However, for readability, it does not include the complete sample code. For the complete sample code, see [Hosting WPF Content in a Win32 Window Sample](http://go.microsoft.com/fwlink/?LinkID=160004).  
  
<a name="basic_procedure"></a>   
## The Basic Procedure  
 This section outlines the basic procedure you use to host [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] content in a [!INCLUDE[TLA2#tla_win32](../../../../includes/tla2sharptla-win32-md.md)] window. The remaining sections explain the details of each step.  
  
 The key to hosting [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] content on a [!INCLUDE[TLA2#tla_win32](../../../../includes/tla2sharptla-win32-md.md)] window is the <xref:System.Windows.Interop.HwndSource> class. This class wraps the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] content in a [!INCLUDE[TLA2#tla_win32](../../../../includes/tla2sharptla-win32-md.md)] window, allowing it to be incorporated into your [!INCLUDE[TLA#tla_ui](../../../../includes/tlasharptla-ui-md.md)] as a child window. The following approach combines the [!INCLUDE[TLA2#tla_win32](../../../../includes/tla2sharptla-win32-md.md)] and [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] in a single application.  
  
1.  Implement your [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] content as a managed class.  
  
2.  Implement a [!INCLUDE[TLA2#tla_win32](../../../../includes/tla2sharptla-win32-md.md)] application with [!INCLUDE[TLA#tla_cppcli](../../../../includes/tlasharptla-cppcli-md.md)]. If you are starting with an existing application and unmanaged [!INCLUDE[TLA#tla_cpp](../../../../includes/tlasharptla-cpp-md.md)] code, you can usually enable it to call managed code by changing your project settings to include the `/clr` compiler flag.  
  
3.  Set the threading model to single-threaded apartment (STA).  
  
4.  Handle the [WM_CREATE](http://msdn.microsoft.com/library/ms632619.aspx)notification in your window procedure and do the following:  
  
    1.  Create a new <xref:System.Windows.Interop.HwndSource> object with the parent window as its `parent` parameter.  
  
    2.  Create an instance of your [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] content class.  
  
    3.  Assign a reference to the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] content object to the <xref:System.Windows.Interop.HwndSource.RootVisual%2A> property of the <xref:System.Windows.Interop.HwndSource>.  
  
    4.  Get the HWND for the content. The <xref:System.Windows.Interop.HwndSource.Handle%2A> property of the <xref:System.Windows.Interop.HwndSource> object contains the window handle (HWND). To get an HWND that you can use in the unmanaged part of your application, cast `Handle.ToPointer()` to an HWND.  
  
5.  Implement a managed class that contains a static field to hold a reference to your [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] content. This class allows you to get a reference to the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] content from your [!INCLUDE[TLA2#tla_win32](../../../../includes/tla2sharptla-win32-md.md)] code.  
  
6.  Assign the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] content to the static field.  
  
7.  Receive notifications from the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] content by attaching a handler to one or more of the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] events.  
  
8.  Communicate with the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] content by using the reference that you stored in the static field to set properties, and so on.  
  
> [!NOTE]
>  You can also use [!INCLUDE[TLA#tla_xaml](../../../../includes/tlasharptla-xaml-md.md)] to implement your [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] content. However, you will have to compile it separately as a [!INCLUDE[TLA#tla_dll](../../../../includes/tlasharptla-dll-md.md)] and reference that [!INCLUDE[TLA2#tla_dll](../../../../includes/tla2sharptla-dll-md.md)] from your [!INCLUDE[TLA2#tla_win32](../../../../includes/tla2sharptla-win32-md.md)] application. The remainder of the procedure is similar to that outlined above.  
  
<a name="implementing_the_application"></a>   
## Implementing the Host Application  
 This section describes how to host [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] content in a basic [!INCLUDE[TLA2#tla_win32](../../../../includes/tla2sharptla-win32-md.md)] application. The content itself is implemented in [!INCLUDE[TLA#tla_cppcli](../../../../includes/tlasharptla-cppcli-md.md)] as a managed class. For the most part, it is straightforward [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] programming. The key aspects of the content implementation are discussed in [Implementing the WPF Content](#implementing_the_wpf_page).  
  
<a name="autoNestedSectionsOUTLINE1"></a>   
-   [The Basic Application](#the_basic_application)  
  
-   [Hosting the WPF Content](#hosting_the_wpf_page)  
  
-   [Holding a Reference to the WPF Content](#holding_a_reference)  
  
-   [Communicating with the WPF Content](#communicating_with_the_page)  
  
<a name="the_basic_application"></a>   
### The Basic Application  
 The starting point for the host application was to create a [!INCLUDE[TLA#tla_visualstu2005](../../../../includes/tlasharptla-visualstu2005-md.md)] template.  
  
1.  Open [!INCLUDE[TLA2#tla_visualstu2005](../../../../includes/tla2sharptla-visualstu2005-md.md)], and select **New Project** from the **File** menu.  
  
2.  Select **Win32** from the list of [!INCLUDE[TLA2#tla_visualcpp](../../../../includes/tla2sharptla-visualcpp-md.md)] project types. If your default language is not [!INCLUDE[TLA2#tla_cpp](../../../../includes/tla2sharptla-cpp-md.md)], you will find these project types under **Other Languages**.  
  
3.  Select a **Win32 Project** template, assign a name to the project and click **OK** to launch the **Win32 Application Wizard**.  
  
4.  Accept the wizard's default settings and click **Finish** to start the project.  
  
 The template creates a basic [!INCLUDE[TLA2#tla_win32](../../../../includes/tla2sharptla-win32-md.md)] application, including:  
  
-   An entry point for the application.  
  
-   A window, with an associated window procedure (WndProc).  
  
-   A menu with **File** and **Help** headings. The **File** menu has an **Exit** item that closes the application. The **Help** menu has an **About** item that launches a simple dialog box.  
  
 Before you start writing code to host the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] content, you need to make two modifications to the basic template.  
  
 The first is to compile the project as managed code. By default, the project compiles as unmanaged code. However, because [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] is implemented in managed code, the project must be compiled accordingly.  
  
1.  Right-click the project name in **Solution Explorer** and select **Properties** from the context menu to launch the **Property Pages** dialog box.  
  
2.  Select **Configuration Properties** from the tree view in the left pane.  
  
3.  Select **Common Language Runtime** support from the **Project Defaults** list in the right pane.  
  
4.  Select **Common Language Runtime Support (/clr)** from the drop-down list box.  
  
> [!NOTE]
>  This compiler flag allows you to use managed code in your application, but your unmanaged code will still compile as before.  
  
 [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] uses the single-threaded apartment (STA) threading model. In order to work properly with the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] content code, you must set the application's threading model to STA by applying an attribute to the entry point.  
  
 [!code-cpp[Win32HostingWPFPage#WinMain](../../../../samples/snippets/cpp/VS_Snippets_Wpf/Win32HostingWPFPage/CPP/Win32HostingWPFPage.cpp#winmain)]  
  
<a name="hosting_the_wpf_page"></a>   
### Hosting the WPF Content  
 The [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] content is a simple address entry application. It consists of several <xref:System.Windows.Controls.TextBox> controls to take user name, address, and so on. There are also two <xref:System.Windows.Controls.Button> controls, **OK** and **Cancel**. When the user clicks **OK**, the button's <xref:System.Windows.Controls.Primitives.ButtonBase.Click> event handler collects the data from the <xref:System.Windows.Controls.TextBox> controls, assigns it to corresponding properties, and raises a custom event, `OnButtonClicked`. When the user clicks **Cancel**, the handler simply raises `OnButtonClicked`. The event argument object for `OnButtonClicked` contains a Boolean field that indicates which button was clicked.  
  
 The code to host the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] content is implemented in a handler for the [WM_CREATE](http://msdn.microsoft.com/library/ms632619.aspx) notification on the host window.  
  
 [!code-cpp[Win32HostingWPFPage#WMCreate](../../../../samples/snippets/cpp/VS_Snippets_Wpf/Win32HostingWPFPage/CPP/Win32HostingWPFPage.cpp#wmcreate)]  
  
 The `GetHwnd` method takes size and position information plus the parent window handle and returns the window handle of the hosted [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] content.  
  
> [!NOTE]
>  You cannot use a `#using` directive for the `System::Windows::Interop` namespace. Doing so creates a name collision between the <xref:System.Windows.Interop.MSG> structure in that namespace and the MSG structure declared in winuser.h. You must instead use fully-qualified names to access the contents of that namespace.  
  
 [!code-cpp[Win32HostingWPFPage#GetHwnd](../../../../samples/snippets/cpp/VS_Snippets_Wpf/Win32HostingWPFPage/CPP/Win32HostingWPFPage.cpp#gethwnd)]  
  
 You cannot host the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] content directly in your application window. Instead, you first create an <xref:System.Windows.Interop.HwndSource> object to wrap the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] content. This object is basically a window that is designed to host a [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] content. You host the <xref:System.Windows.Interop.HwndSource> object in the parent window by creating it as a child of a [!INCLUDE[TLA2#tla_win32](../../../../includes/tla2sharptla-win32-md.md)] window that is part of your application. The <xref:System.Windows.Interop.HwndSource> constructor parameters contain much the same information that you would pass to CreateWindow when you create a [!INCLUDE[TLA2#tla_win32](../../../../includes/tla2sharptla-win32-md.md)] child window.  
  
 You next create an instance of the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] content object. In this case, the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] content is implemented as a separate class, `WPFPage`, using [!INCLUDE[TLA#tla_cppcli](../../../../includes/tlasharptla-cppcli-md.md)]. You could also implement the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] content with [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)]. However, to do so you need to set up a separate project and build the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] content as a [!INCLUDE[TLA2#tla_dll](../../../../includes/tla2sharptla-dll-md.md)]. You can add a reference to that [!INCLUDE[TLA2#tla_dll](../../../../includes/tla2sharptla-dll-md.md)] to your project, and use that reference to create an instance of the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] content.  
  
 You display the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] content in your child window by assigning a reference to the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] content to the <xref:System.Windows.Interop.HwndSource.RootVisual%2A> property of the <xref:System.Windows.Interop.HwndSource>.  
  
 The next line of code attaches an event handler, `WPFButtonClicked`, to the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] content `OnButtonClicked` event. This handler is called when the user clicks the **OK** or **Cancel** button. See [communicating_with_the_WPF content](#communicating_with_the_page) for further discussion of this event handler.  
  
 The final line of code shown returns the window handle (HWND) that is associated with the <xref:System.Windows.Interop.HwndSource> object. You can use this handle from your [!INCLUDE[TLA2#tla_win32](../../../../includes/tla2sharptla-win32-md.md)] code to send messages to the hosted window, although the sample does not do so. The <xref:System.Windows.Interop.HwndSource> object raises an event every time it receives a message. To process the messages, call the <xref:System.Windows.Interop.HwndSource.AddHook%2A> method to attach a message handler and then process the messages in that handler.  
  
<a name="holding_a_reference"></a>   
### Holding a Reference to the WPF Content  
 For many applications, you will want to communicate with the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] content later. For example, you might want to modify the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] content properties, or perhaps have the <xref:System.Windows.Interop.HwndSource> object host different [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] content. To do this, you need a reference to the <xref:System.Windows.Interop.HwndSource> object or the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] content. The <xref:System.Windows.Interop.HwndSource> object and its associated [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] content remain in memory until you destroy the window handle. However, the variable you assign to the <xref:System.Windows.Interop.HwndSource> object will go out of scope as soon as you return from the window procedure. The customary way to handle this issue with [!INCLUDE[TLA2#tla_win32](../../../../includes/tla2sharptla-win32-md.md)] applications is to use a static or global variable. Unfortunately, you cannot assign a managed object to those types of variables. You can assign the window handle associated with <xref:System.Windows.Interop.HwndSource> object to a global or static variable, but that doe not provide access to the object itself.  
  
 The simplest solution to this issue is to implement a managed class that contains a set of static fields to hold references to any managed objects that you need access to. The sample uses the `WPFPageHost` class to hold a reference to the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] content, plus the initial values of a number of its properties that might be changed later by the user. This is defined in the header.  
  
 [!code-cpp[Win32HostingWPFPage#WPFPageHost](../../../../samples/snippets/cpp/VS_Snippets_Wpf/Win32HostingWPFPage/CPP/Win32HostingWPFPage.h#wpfpagehost)]  
  
 The latter part of the `GetHwnd` function assigns values to those fields for later use while `myPage` is still in scope.  
  
<a name="communicating_with_the_page"></a>   
### Communicating with the WPF Content  
 There are two types of communication with the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] content. The application receives information from the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] content when the user clicks the **OK** or **Cancel** buttons. The application also has a [!INCLUDE[TLA2#tla_ui](../../../../includes/tla2sharptla-ui-md.md)] that allows the user to change various [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] content properties, such as the background color or default font size.  
  
 As mentioned above, when the user clicks either button the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] content raises an `OnButtonClicked` event. The application attaches a handler to this event to receive these notifications. If the **OK** button was clicked, the handler gets the user information from the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] content and displays it in a set of static controls.  
  
 [!code-cpp[Win32HostingWPFPage#WPFButtonClicked](../../../../samples/snippets/cpp/VS_Snippets_Wpf/Win32HostingWPFPage/CPP/Win32HostingWPFPage.cpp#wpfbuttonclicked)]  
  
 The handler receives a custom event argument object from the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] content, `MyPageEventArgs`. The object's `IsOK` property is set to `true` if the **OK** button was clicked, and `false` if the **Cancel** button was clicked.  
  
 If the **OK** button was clicked, the handler gets a reference to the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] content from the container class. It then collects the user information that is held by the associated [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] content properties and uses the static controls to display the information on the parent window. Because the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] content data is in the form of a managed string, it has to be marshaled for use by a [!INCLUDE[TLA2#tla_win32](../../../../includes/tla2sharptla-win32-md.md)] control. If the **Cancel** button was clicked, the handler clears the data from the static controls.  
  
 The application [!INCLUDE[TLA2#tla_ui](../../../../includes/tla2sharptla-ui-md.md)] provides a set of radio buttons that allow the user to modify the background color of the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] content, and several font-related properties. The following example is an excerpt from the application's window procedure (WndProc) and its message handling that sets various properties on different messages, including the background color. The others are similar, and are not shown. See the complete sample for details and context.  
  
 [!code-cpp[Win32HostingWPFPage#WMCommandToBG](../../../../samples/snippets/cpp/VS_Snippets_Wpf/Win32HostingWPFPage/CPP/Win32HostingWPFPage.cpp#wmcommandtobg)]  
  
 To set the background color, get a reference to the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] content (`hostedPage`) from `WPFPageHost` and set the background color property to the appropriate color. The sample uses three color options: the original color, light green, or light salmon. The original background color is stored as a static field in the `WPFPageHost` class. To set the other two, you create a new <xref:System.Windows.Media.SolidColorBrush> object and pass the constructor a static colors value from the <xref:System.Windows.Media.Colors> object.  
  
<a name="implementing_the_wpf_page"></a>   
## Implementing the WPF Page  
 You can host and use the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] content without any knowledge of the actual implementation. If the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] content had been packaged in a separate [!INCLUDE[TLA2#tla_dll](../../../../includes/tla2sharptla-dll-md.md)], it could have been built in any [!INCLUDE[TLA#tla_clr](../../../../includes/tlasharptla-clr-md.md)] language. Following is a brief walkthrough of the [!INCLUDE[TLA#tla_cppcli](../../../../includes/tlasharptla-cppcli-md.md)] implementation that is used in the sample. This section contains the following subsections.  
  
<a name="autoNestedSectionsOUTLINE2"></a>   
-   [Layout](#page_layout)  
  
-   [Returning the Data to the Host Window](#returning_data_to_window)  
  
-   [Setting the WPF Properties](#set_page_properties)  
  
<a name="page_layout"></a>   
### Layout  
 The [!INCLUDE[TLA2#tla_ui](../../../../includes/tla2sharptla-ui-md.md)] elements in the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] content consist of five <xref:System.Windows.Controls.TextBox> controls, with associated <xref:System.Windows.Controls.Label> controls: Name, Address, City, State, and Zip. There are also two <xref:System.Windows.Controls.Button> controls, **OK** and **Cancel**  
  
 The [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] content is implemented in the `WPFPage` class. Layout is handled with a <xref:System.Windows.Controls.Grid> layout element. The class inherits from <xref:System.Windows.Controls.Grid>, which effectively makes it the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] content root element.  
  
 The [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] content constructor takes the required width and height, and sizes the <xref:System.Windows.Controls.Grid> accordingly. It then defines the basic layout by creating a set of <xref:System.Windows.Controls.ColumnDefinition> and <xref:System.Windows.Controls.RowDefinition> objects and adding them to the <xref:System.Windows.Controls.Grid> object base <xref:System.Windows.Controls.Grid.ColumnDefinitions%2A> and <xref:System.Windows.Controls.Grid.RowDefinitions%2A> collections, respectively. This defines a grid of five rows and seven columns, with the dimensions determined by the contents of the cells.  
  
 [!code-cpp[Win32HostingWPFPage#WPFPageCtorToGridDef](../../../../samples/snippets/cpp/VS_Snippets_Wpf/Win32HostingWPFPage/CPP/WPFPage.cpp#wpfpagectortogriddef)]  
  
 Next, the constructor adds the [!INCLUDE[TLA2#tla_ui](../../../../includes/tla2sharptla-ui-md.md)] elements to the <xref:System.Windows.Controls.Grid>. The first element is the title text, which is a <xref:System.Windows.Controls.Label> control that is centered in the first row of the grid.  
  
 [!code-cpp[Win32HostingWPFPage#WPFPageCtorTitle](../../../../samples/snippets/cpp/VS_Snippets_Wpf/Win32HostingWPFPage/CPP/WPFPage.cpp#wpfpagectortitle)]  
  
 The next row contains the Name <xref:System.Windows.Controls.Label> control and its associated <xref:System.Windows.Controls.TextBox> control. Because the same code is used for each label/textbox pair, it is placed in a pair of private methods and used for all five label/textbox pairs. The methods create the appropriate control, and call the <xref:System.Windows.Controls.Grid> class static <xref:System.Windows.Controls.Grid.SetColumn%2A> and <xref:System.Windows.Controls.Grid.SetRow%2A> methods to place the controls in the appropriate cell. After the control is created, the sample calls the <xref:System.Windows.Controls.UIElementCollection.Add%2A> method on the <xref:System.Windows.Controls.Panel.Children%2A> property of the <xref:System.Windows.Controls.Grid> to add the control to the grid. The code to add the remaining label/textbox pairs is similar. See the sample code for details.  
  
 [!code-cpp[Win32HostingWPFPage#WPFPageCtorName](../../../../samples/snippets/cpp/VS_Snippets_Wpf/Win32HostingWPFPage/CPP/WPFPage.cpp#wpfpagectorname)]  
  
 The implementation of the two methods is as follows:  
  
 [!code-cpp[Win32HostingWPFPage#WPFPageCreateHelpers](../../../../samples/snippets/cpp/VS_Snippets_Wpf/Win32HostingWPFPage/CPP/WPFPage.cpp#wpfpagecreatehelpers)]  
  
 Finally, the sample adds the **OK** and **Cancel** buttons and attaches an event handler to their <xref:System.Windows.Controls.Primitives.ButtonBase.Click> events.  
  
 [!code-cpp[Win32HostingWPFPage#WPFPageCtorButtonsEvents](../../../../samples/snippets/cpp/VS_Snippets_Wpf/Win32HostingWPFPage/CPP/WPFPage.cpp#wpfpagectorbuttonsevents)]  
  
<a name="returning_data_to_window"></a>   
### Returning the Data to the Host Window  
 When either button is clicked, its <xref:System.Windows.Controls.Primitives.ButtonBase.Click> event is raised. The host window could simply attach handlers to these events and get the data directly from the <xref:System.Windows.Controls.TextBox> controls. The sample uses a somewhat less direct approach. It handles the <xref:System.Windows.Controls.Primitives.ButtonBase.Click> within the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] content, and then raises a custom event `OnButtonClicked`, to notify the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] content. This allows the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] content to do some parameter validation before notifying the host. The handler gets the text from the <xref:System.Windows.Controls.TextBox> controls and assigns it to public properties, from which the host can retrieve the information.  
  
 The event declaration, in WPFPage.h:  
  
 [!code-cpp[Win32HostingWPFPage#WPFPageEventDecl](../../../../samples/snippets/cpp/VS_Snippets_Wpf/Win32HostingWPFPage/CPP/WPFPage.h#wpfpageeventdecl)]  
  
 The <xref:System.Windows.Controls.Primitives.ButtonBase.Click> event handler, in WPFPage.cpp:  
  
 [!code-cpp[Win32HostingWPFPage#WPFPageButtonClicked](../../../../samples/snippets/cpp/VS_Snippets_Wpf/Win32HostingWPFPage/CPP/WPFPage.cpp#wpfpagebuttonclicked)]  
  
<a name="set_page_properties"></a>   
### Setting the WPF Properties  
 The [!INCLUDE[TLA2#tla_win32](../../../../includes/tla2sharptla-win32-md.md)] host allows the user to change several [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] content properties. From the [!INCLUDE[TLA2#tla_win32](../../../../includes/tla2sharptla-win32-md.md)] side, it is simply a matter of changing the properties. The implementation in the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] content class is somewhat more complicated, because there is no single global property that controls the fonts for all controls. Instead, the appropriate property for each control is changed in the properties' set accessors. The following example shows the code for the `DefaultFontFamily` property. Setting the property calls a private method that in turn sets the <xref:System.Windows.Controls.Control.FontFamily%2A> properties for the various controls.  
  
 From WPFPage.h:  
  
 [!code-cpp[Win32HostingWPFPage#WPFPageFontFamilyProperty](../../../../samples/snippets/cpp/VS_Snippets_Wpf/Win32HostingWPFPage/CPP/WPFPage.h#wpfpagefontfamilyproperty)]  
  
 From WPFPage.cpp:  
  
 [!code-cpp[Win32HostingWPFPage#WPFPageSetFontFamily](../../../../samples/snippets/cpp/VS_Snippets_Wpf/Win32HostingWPFPage/CPP/WPFPage.cpp#wpfpagesetfontfamily)]  
  
## See Also  
 <xref:System.Windows.Interop.HwndSource>  
 [WPF and Win32 Interoperation](../../../../docs/framework/wpf/advanced/wpf-and-win32-interoperation.md)
