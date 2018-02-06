---
title: "WPF and Win32 Interoperation"
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
  - "hosting WPF content in Win32 window [WPF]"
  - "HWND interop [WPF]"
  - "Win32 code [WPF], WPF interoperation"
  - "interoperability [WPF], Win32"
ms.assetid: 0ffbde0d-701d-45a3-a6fa-dd71f4d9772e
caps.latest.revision: 26
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# WPF and Win32 Interoperation
This topic provides an overview of how to interoperate [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] and [!INCLUDE[TLA2#tla_win32](../../../../includes/tla2sharptla-win32-md.md)] code. [!INCLUDE[TLA#tla_winclient](../../../../includes/tlasharptla-winclient-md.md)] provides a rich environment for creating applications. However, when you have a substantial investment in [!INCLUDE[TLA#tla_win32](../../../../includes/tlasharptla-win32-md.md)] code, it might be more effective to reuse some of that code.  
  

  
<a name="basics"></a>   
## WPF and Win32 Interoperation Basics  
 There are two basic techniques for interoperation between [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] and [!INCLUDE[TLA2#tla_win32](../../../../includes/tla2sharptla-win32-md.md)] code.  
  
-   Host [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] content in a [!INCLUDE[TLA2#tla_win32](../../../../includes/tla2sharptla-win32-md.md)] window. With this technique, you can use the advanced graphics capabilities of [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] within the framework of a standard [!INCLUDE[TLA2#tla_win32](../../../../includes/tla2sharptla-win32-md.md)] window and application.  
  
-   Host a [!INCLUDE[TLA2#tla_win32](../../../../includes/tla2sharptla-win32-md.md)] window in [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] content. With this technique, you can use an existing custom [!INCLUDE[TLA2#tla_win32](../../../../includes/tla2sharptla-win32-md.md)] control in the context of other [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] content, and pass data across the boundaries.  
  
 Each of these techniques is conceptually introduced in this topic. For a more code-oriented illustration of hosting [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] in [!INCLUDE[TLA2#tla_win32](../../../../includes/tla2sharptla-win32-md.md)], see [Walkthrough: Hosting WPF Content in Win32](../../../../docs/framework/wpf/advanced/walkthrough-hosting-wpf-content-in-win32.md). For a more code-oriented illustration of hosting [!INCLUDE[TLA2#tla_win32](../../../../includes/tla2sharptla-win32-md.md)] in [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)], see [Walkthrough: Hosting a Win32 Control in WPF](../../../../docs/framework/wpf/advanced/walkthrough-hosting-a-win32-control-in-wpf.md).  
  
<a name="projects"></a>   
## WPF Interoperation Projects  
 [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] [!INCLUDE[TLA2#tla_api#plural](../../../../includes/tla2sharptla-apisharpplural-md.md)] are managed code, but most existing [!INCLUDE[TLA2#tla_win32](../../../../includes/tla2sharptla-win32-md.md)] programs are written in unmanaged [!INCLUDE[TLA2#tla_cpp](../../../../includes/tla2sharptla-cpp-md.md)].  You cannot call [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] [!INCLUDE[TLA2#tla_api#plural](../../../../includes/tla2sharptla-apisharpplural-md.md)] from a true unmanaged program. However, by using the `/clr` option with the [!INCLUDE[TLA#tla_visualcpp](../../../../includes/tlasharptla-visualcpp-md.md)] compiler, you can create a mixed managed-unmanaged program where you can seamlessly mix managed and unmanaged [!INCLUDE[TLA2#tla_api](../../../../includes/tla2sharptla-api-md.md)] calls.  
  
 One project-level complication is that you cannot compile [!INCLUDE[TLA#tla_xaml](../../../../includes/tlasharptla-xaml-md.md)] files into a [!INCLUDE[TLA2#tla_cpp](../../../../includes/tla2sharptla-cpp-md.md)] project.  There are several project division techniques to compensate for this.  
  
-   Create a [!INCLUDE[TLA2#tla_cshrp](../../../../includes/tla2sharptla-cshrp-md.md)] DLL that contains all your [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)] pages as a compiled assembly, and then have your [!INCLUDE[TLA2#tla_cpp](../../../../includes/tla2sharptla-cpp-md.md)] executable include that [!INCLUDE[TLA2#tla_dll](../../../../includes/tla2sharptla-dll-md.md)] as a reference.  
  
-   Create a [!INCLUDE[TLA2#tla_cshrp](../../../../includes/tla2sharptla-cshrp-md.md)] executable for the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] content, and have it reference a [!INCLUDE[TLA2#tla_cpp](../../../../includes/tla2sharptla-cpp-md.md)] [!INCLUDE[TLA2#tla_dll](../../../../includes/tla2sharptla-dll-md.md)] that contains the [!INCLUDE[TLA2#tla_win32](../../../../includes/tla2sharptla-win32-md.md)] content.  
  
-   Use <xref:System.Windows.Markup.XamlReader.Load%2A> to load any [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)] at run time, instead of compiling your [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)].  
  
-   Do not use [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)] at all, and write all your [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] in code, building up the element tree from <xref:System.Windows.Application>.  
  
 Use whatever approach works best for you.  
  
> [!NOTE]
>  If you have not used [!INCLUDE[TLA#tla_cppcli](../../../../includes/tlasharptla-cppcli-md.md)] before, you might notice some "new" keywords such as `gcnew` and `nullptr` in the interoperation code examples. These keywords supersede the older double-underscore syntax (`__gc`) and provide a more natural syntax for managed code in [!INCLUDE[TLA2#tla_cpp](../../../../includes/tla2sharptla-cpp-md.md)].  To learn more about the [!INCLUDE[TLA#tla_cppcli](../../../../includes/tlasharptla-cppcli-md.md)] managed features, see [Component Extensions for Runtime Platforms](/cpp/windows/component-extensions-for-runtime-platforms) and [Hello, C++/CLI](http://go.microsoft.com/fwlink/?LinkId=98739).  
  
<a name="hwnds"></a>   
## How WPF Uses Hwnds  
 To make the most of [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] "HWND interop", you need to understand how [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] uses HWNDs. For any HWND, you cannot mix [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] rendering with [!INCLUDE[TLA2#tla_dx](../../../../includes/tla2sharptla-dx-md.md)] rendering or [!INCLUDE[TLA2#tla_gdi](../../../../includes/tla2sharptla-gdi-md.md)] / [!INCLUDE[TLA2#tla_gdiplus](../../../../includes/tla2sharptla-gdiplus-md.md)] rendering. This has a number of implications. Primarily, in order to mix these rendering models at all, you must create an interoperation solution, and use designated segments of interoperation for each rendering model that you choose to use. Also, the rendering behavior creates an "airspace" restriction for what your interoperation solution can accomplish. The "airspace" concept is explained in greater detail in the topic [Technology Regions Overview](../../../../docs/framework/wpf/advanced/technology-regions-overview.md).  
  
 All [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] elements on the screen are ultimately backed by a HWND. When you create a [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] <xref:System.Windows.Window>, [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] creates a top-level HWND, and uses an <xref:System.Windows.Interop.HwndSource> to put the <xref:System.Windows.Window> and its [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] content inside the HWND.  The rest of your [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] content in the application shares that singular HWND. An exception is menus, combo box drop downs, and other pop-ups. These elements create their own top-level window, which is why a [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] menu can potentially go past the edge of the window HWND that contains it. When you use <xref:System.Windows.Interop.HwndHost> to put an HWND inside [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)], [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] informs [!INCLUDE[TLA2#tla_win32](../../../../includes/tla2sharptla-win32-md.md)] how to position the new child HWND relative to the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] <xref:System.Windows.Window> HWND.  
  
 A related concept to HWND is transparency within and between each HWND. This is also discussed in the topic [Technology Regions Overview](../../../../docs/framework/wpf/advanced/technology-regions-overview.md).  
  
<a name="hosting_a_wpf_page"></a>   
## Hosting WPF Content in a Microsoft Win32 Window  
 The key to hosting a [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] on a [!INCLUDE[TLA2#tla_win32](../../../../includes/tla2sharptla-win32-md.md)] window is the <xref:System.Windows.Interop.HwndSource> class. This class wraps the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] content in a [!INCLUDE[TLA2#tla_win32](../../../../includes/tla2sharptla-win32-md.md)] window, so that the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] content can be incorporated into your [!INCLUDE[TLA#tla_ui](../../../../includes/tlasharptla-ui-md.md)] as a child window. The following approach combines the [!INCLUDE[TLA2#tla_win32](../../../../includes/tla2sharptla-win32-md.md)] and [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] in a single application.  
  
1.  Implement your [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] content (the content root element) as a managed class. Typically, the class inherits from one of the classes that can contain multiple child elements and/or used as a root element, such as <xref:System.Windows.Controls.DockPanel> or <xref:System.Windows.Controls.Page>. In subsequent steps, this class is referred to as the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] content class, and instances of the class are referred to as [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] content objects.  
  
2.  Implement a [!INCLUDE[TLA2#tla_win32](../../../../includes/tla2sharptla-win32-md.md)] application with [!INCLUDE[TLA2#tla_cppcli](../../../../includes/tla2sharptla-cppcli-md.md)]. If you are starting with an existing unmanaged [!INCLUDE[TLA2#tla_cpp](../../../../includes/tla2sharptla-cpp-md.md)] application, you can usually enable it to call managed code by changing your project settings to include the `/clr` compiler flag (the full scope of what might be necessary to support `/clr` compilation is not described in this topic).  
  
3.  Set the threading model to Single Threaded Apartment (STA). [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] uses this threading model.  
  
4.  Handle the WM_CREATE notification in your window procedure.  
  
5.  Within the handler (or a function that the handler calls), do the following:  
  
    1.  Create a new <xref:System.Windows.Interop.HwndSource> object with the parent window HWND as its `parent` parameter.  
  
    2.  Create an instance of your [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] content class.  
  
    3.  Assign a reference to the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] content object to the <xref:System.Windows.Interop.HwndSource> object <xref:System.Windows.Interop.HwndSource.RootVisual%2A> property.  
  
    4.  The <xref:System.Windows.Interop.HwndSource> object <xref:System.Windows.Interop.HwndSource.Handle%2A> property contains the window handle (HWND). To get an HWND that you can use in the unmanaged part of your application, cast `Handle.ToPointer()` to an HWND.  
  
6.  Implement a managed class that contains a static field that holds a reference to your [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] content object. This class allows you to get a reference to the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] content object from your [!INCLUDE[TLA2#tla_win32](../../../../includes/tla2sharptla-win32-md.md)] code, but more importantly it prevents your <xref:System.Windows.Interop.HwndSource> from being inadvertently garbage collected.  
  
7.  Receive notifications from the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] content object by attaching a handler to one or more of the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] content object events.  
  
8.  Communicate with the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] content object by using the reference that you stored in the static field to set properties, call methods, etc.  
  
> [!NOTE]
>  You can do some or all of the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] content class definition for Step One in [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)] using the default partial class of the content class, if you produce a separate assembly and then reference it. Although you typically include an <xref:System.Windows.Application> object as part of compiling the [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)] into an assembly, you do not end up using that <xref:System.Windows.Application> as part of the interoperation, you just use one or more of the root classes for [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)] files referred to by the application and reference their partial classes. The remainder of the procedure is essentially similar to that outlined above.  
>   
>  Each of these steps is illustrated through code in the topic [Walkthrough: Hosting WPF Content in Win32](../../../../docs/framework/wpf/advanced/walkthrough-hosting-wpf-content-in-win32.md).  
  
<a name="hosting_an_hwnd"></a>   
## Hosting a Microsoft Win32 Window in WPF  
 The key to hosting a [!INCLUDE[TLA2#tla_win32](../../../../includes/tla2sharptla-win32-md.md)] window within other [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] content is the <xref:System.Windows.Interop.HwndHost> class. This class wraps the window in a [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] element which can be added to a [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] element tree. <xref:System.Windows.Interop.HwndHost> also supports [!INCLUDE[TLA2#tla_api#plural](../../../../includes/tla2sharptla-apisharpplural-md.md)] that allow you to do such tasks as process messages for the hosted window. The basic procedure is:  
  
1.  Create an element tree for a [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] application (can be through code or markup). Find an appropriate and permissible point in the element tree where the <xref:System.Windows.Interop.HwndHost> implementation can be added as a child element. In the remainder of these steps, this element is referred to as the reserving element.  
  
2.  Derive from <xref:System.Windows.Interop.HwndHost> to create an object that holds your [!INCLUDE[TLA2#tla_win32](../../../../includes/tla2sharptla-win32-md.md)] content.  
  
3.  In that host class, override the <xref:System.Windows.Interop.HwndHost> method <xref:System.Windows.Interop.HwndHost.BuildWindowCore%2A>. Return the HWND of the hosted window. You might want to wrap the actual control(s) as a child window of the returned window; wrapping the controls in a host window provides a simple way for your [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] content to receive notifications from the controls. This technique helps correct for some [!INCLUDE[TLA2#tla_win32](../../../../includes/tla2sharptla-win32-md.md)] issues regarding message handling at the hosted control boundary.  
  
4.  Override the <xref:System.Windows.Interop.HwndHost> methods <xref:System.Windows.Interop.HwndHost.DestroyWindowCore%2A> and <xref:System.Windows.Interop.HwndHost.WndProc%2A>. The intention here is to process cleanup and remove references to the hosted content, particularly if you created references to unmanaged objects.  
  
5.  In your code-behind file, create an instance of the control hosting class and make it a child of the reserving element. Typically you would use an event handler such as <xref:System.Windows.FrameworkElement.Loaded>, or use the partial class constructor. But you could also add the interoperation content through a runtime behavior.  
  
6.  Process selected window messages, such as control notifications. There are two approaches. Both provide identical access to the message stream, so your choice is largely a matter of programming convenience.  
  
    -   Implement message processing for all messages (not just shutdown messages) in your override of the <xref:System.Windows.Interop.HwndHost> method <xref:System.Windows.Interop.HwndHost.WndProc%2A>.  
  
    -   Have the hosting [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] element process the messages by handling the <xref:System.Windows.Interop.HwndHost.MessageHook> event. This event is raised for every message that is sent to the main window procedure of the hosted window.  
  
    -   You cannot process messages from windows that are out of process using <xref:System.Windows.Interop.HwndHost.WndProc%2A>.  
  
7.  Communicate with the hosted window by using platform invoke to call the unmanaged `SendMessage` function.  
  
 Following these steps creates an application that works with mouse input. You can add tabbing support for your hosted window by implementing the <xref:System.Windows.Interop.IKeyboardInputSink> interface.  
  
 Each of these steps is illustrated through code in the topic [Walkthrough: Hosting a Win32 Control in WPF](../../../../docs/framework/wpf/advanced/walkthrough-hosting-a-win32-control-in-wpf.md).  
  
### Hwnds Inside WPF  
 You can think of <xref:System.Windows.Interop.HwndHost> as a special control. (Technically, <xref:System.Windows.Interop.HwndHost> is a <xref:System.Windows.FrameworkElement> derived class, not a <xref:System.Windows.Controls.Control> derived class, but it can be considered a control for purposes of interoperation.) <xref:System.Windows.Interop.HwndHost> abstracts the underlying [!INCLUDE[TLA2#tla_win32](../../../../includes/tla2sharptla-win32-md.md)] nature of the hosted content such that the remainder of [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] considers the hosted content to be another control-like object, which should render and process input. <xref:System.Windows.Interop.HwndHost> generally behaves like any other [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] <xref:System.Windows.FrameworkElement>, although there are some important differences around output (drawing and graphics) and input (mouse and keyboard) based on limitations of what the underlying HWNDs can support.  
  
#### Notable Differences in Output Behavior  
  
-   <xref:System.Windows.FrameworkElement>, which is the <xref:System.Windows.Interop.HwndHost> base class, has quite a few properties that imply changes to the UI. These include properties such as <xref:System.Windows.FrameworkElement.FlowDirection%2A?displayProperty=nameWithType>, which changes the layout of elements within that element as a parent. However, most of these properties are not mapped to possible [!INCLUDE[TLA2#tla_win32](../../../../includes/tla2sharptla-win32-md.md)] equivalents, even if such equivalents might exist. Too many of these properties and their meanings are too rendering-technology specific for mappings to be practical. Therefore, setting properties such as <xref:System.Windows.FrameworkElement.FlowDirection%2A> on <xref:System.Windows.Interop.HwndHost> has no effect.  
  
-   <xref:System.Windows.Interop.HwndHost> cannot be rotated, scaled, skewed, or otherwise affected by a Transform.  
  
-   <xref:System.Windows.Interop.HwndHost> does not support the <xref:System.Windows.UIElement.Opacity%2A> property (alpha blending). If content inside the <xref:System.Windows.Interop.HwndHost> performs <xref:System.Drawing> operations that include alpha information, that is itself not a violation, but the <xref:System.Windows.Interop.HwndHost> as a whole only supports Opacity = 1.0 (100%).  
  
-   <xref:System.Windows.Interop.HwndHost> will appear on top of other [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] elements in the same top-level window. However, a <xref:System.Windows.Controls.ToolTip> or <xref:System.Windows.Controls.ContextMenu> generated menu is a separate top-level window, and so will behave correctly with <xref:System.Windows.Interop.HwndHost>.  
  
-   <xref:System.Windows.Interop.HwndHost> does not respect the clipping region of its parent <xref:System.Windows.UIElement>. This is potentially an issue if you attempt to put an <xref:System.Windows.Interop.HwndHost> class inside a scrolling region or <xref:System.Windows.Controls.Canvas>.  
  
#### Notable Differences in Input Behavior  
  
-   In general, while input devices are scoped within the <xref:System.Windows.Interop.HwndHost> hosted [!INCLUDE[TLA2#tla_win32](../../../../includes/tla2sharptla-win32-md.md)] region, input events go directly to [!INCLUDE[TLA2#tla_win32](../../../../includes/tla2sharptla-win32-md.md)].  
  
-   While the mouse is over the <xref:System.Windows.Interop.HwndHost>, your application does not receive [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] mouse events, and the value of the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] property <xref:System.Windows.UIElement.IsMouseOver%2A> will be `false`.  
  
-   While the <xref:System.Windows.Interop.HwndHost> has keyboard focus, your application will not receive [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] keyboard events and the value of the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] property <xref:System.Windows.UIElement.IsKeyboardFocusWithin%2A> will be `false`.  
  
-   When focus is within the <xref:System.Windows.Interop.HwndHost> and changes to another control inside the <xref:System.Windows.Interop.HwndHost>, your application will not receive the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] events <xref:System.Windows.UIElement.GotFocus> or <xref:System.Windows.UIElement.LostFocus>.  
  
-   Related stylus properties and events are analogous, and do not report information while the stylus is over <xref:System.Windows.Interop.HwndHost>.  
  
<a name="tabbing_mnemonics_accelerators"></a>   
## Tabbing, Mnemonics, and Accelerators  
 The <xref:System.Windows.Interop.IKeyboardInputSink> and <xref:System.Windows.Interop.IKeyboardInputSite> interfaces allow you to create a seamless keyboard experience for mixed [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] and [!INCLUDE[TLA2#tla_win32](../../../../includes/tla2sharptla-win32-md.md)] applications:  
  
-   Tabbing between [!INCLUDE[TLA2#tla_win32](../../../../includes/tla2sharptla-win32-md.md)] and [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] components  
  
-   Mnemonics and accelerators that work both when focus is within a Win32 component and when it is within a WPF component.  
  
 The <xref:System.Windows.Interop.HwndHost> and <xref:System.Windows.Interop.HwndSource> classes both provide implementations of <xref:System.Windows.Interop.IKeyboardInputSink>, but they may not handle all the input messages that you want for more advanced scenarios. Override the appropriate methods to get the keyboard behavior you want.  
  
 The interfaces only provide support for what happens on the transition between the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] and [!INCLUDE[TLA2#tla_win32](../../../../includes/tla2sharptla-win32-md.md)] regions. Within the [!INCLUDE[TLA2#tla_win32](../../../../includes/tla2sharptla-win32-md.md)] region, tabbing behavior is entirely controlled by the [!INCLUDE[TLA2#tla_win32](../../../../includes/tla2sharptla-win32-md.md)] implemented logic for tabbing, if any.  
  
## See Also  
 <xref:System.Windows.Interop.HwndHost>  
 <xref:System.Windows.Interop.HwndSource>  
 <xref:System.Windows.Interop>  
 [Walkthrough: Hosting a Win32 Control in WPF](../../../../docs/framework/wpf/advanced/walkthrough-hosting-a-win32-control-in-wpf.md)  
 [Walkthrough: Hosting WPF Content in Win32](../../../../docs/framework/wpf/advanced/walkthrough-hosting-wpf-content-in-win32.md)
