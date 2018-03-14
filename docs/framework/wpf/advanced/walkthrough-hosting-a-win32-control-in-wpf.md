---
title: "Walkthrough: Hosting a Win32 Control in WPF"
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
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "hosting Win32 control in WPF [WPF]"
  - "Win32 code [WPF], WPF interoperation"
ms.assetid: a676b1eb-fc55-4355-93ab-df840c41cea0
caps.latest.revision: 21
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Walkthrough: Hosting a Win32 Control in WPF
[!INCLUDE[TLA#tla_winclient](../../../../includes/tlasharptla-winclient-md.md)] provides a rich environment for creating applications. However, when you have a substantial investment in [!INCLUDE[TLA#tla_win32](../../../../includes/tlasharptla-win32-md.md)] code, it may be more effective to reuse at least some of that code in your [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] application rather than rewrite it completely. [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] provides a straightforward mechanism for hosting a [!INCLUDE[TLA2#tla_win32](../../../../includes/tla2sharptla-win32-md.md)] window, on a [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] page.  
  
 This topic walks you through an application, [Hosting a Win32 ListBox Control in WPF Sample](http://go.microsoft.com/fwlink/?LinkID=159998), that hosts a [!INCLUDE[TLA2#tla_win32](../../../../includes/tla2sharptla-win32-md.md)] list box control. This general procedure can be extended to hosting any [!INCLUDE[TLA2#tla_win32](../../../../includes/tla2sharptla-win32-md.md)] window.  
  
  
<a name="requirements"></a>   
## Requirements  
 This topic assumes a basic familiarity with both [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] and [!INCLUDE[TLA2#tla_win32](../../../../includes/tla2sharptla-win32-md.md)] programming. For a basic introduction to [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] programming, see [Getting Started](../../../../docs/framework/wpf/getting-started/index.md). For an introduction to [!INCLUDE[TLA2#tla_win32](../../../../includes/tla2sharptla-win32-md.md)] programming, you should reference any of the numerous books on the subject, in particular *Programming Windows* by Charles Petzold.  
  
 Because the sample that accompanies this topic is implemented in [!INCLUDE[TLA#tla_cshrp](../../../../includes/tlasharptla-cshrp-md.md)], it makes use of [!INCLUDE[TLA#tla_pinvoke](../../../../includes/tlasharptla-pinvoke-md.md)] to access the [!INCLUDE[TLA2#tla_win32](../../../../includes/tla2sharptla-win32-md.md)][!INCLUDE[TLA#tla_api](../../../../includes/tlasharptla-api-md.md)]. Some familiarity with [!INCLUDE[TLA2#tla_pinvoke](../../../../includes/tla2sharptla-pinvoke-md.md)] is helpful but not essential.  
  
> [!NOTE]
>  This topic includes a number of code examples from the associated sample. However, for readability, it does not include the complete sample code. You can obtain or view complete code from     [Hosting a Win32 ListBox Control in WPF Sample](http://go.microsoft.com/fwlink/?LinkID=159998).  
  
<a name="basic_procedure"></a>   
## The Basic Procedure  
 This section outlines the basic procedure for hosting a [!INCLUDE[TLA2#tla_win32](../../../../includes/tla2sharptla-win32-md.md)] window on a [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] page. The remaining sections go through the details of each step.  
  
 The basic hosting procedure is:  
  
1.  Implement a [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] page to host the window. One technique is to create a <xref:System.Windows.Controls.Border> element to reserve a section of the page for the hosted window.  
  
2.  Implement a class to host the control that inherits from <xref:System.Windows.Interop.HwndHost>.  
  
3.  In that class, override the <xref:System.Windows.Interop.HwndHost> class member <xref:System.Windows.Interop.HwndHost.BuildWindowCore%2A>.  
  
4.  Create the hosted window as a child of the window that contains the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] page. Although conventional [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] programming does not need to explicitly make use of it, the hosting page is a window with a handle (HWND). You receive the page HWND through the `hwndParent` parameter of the <xref:System.Windows.Interop.HwndHost.BuildWindowCore%2A> method. The hosted window should be created as a child of this HWND.  
  
5.  Once you have created the host window, return the HWND of the hosted window. If you want to host one or more [!INCLUDE[TLA2#tla_win32](../../../../includes/tla2sharptla-win32-md.md)] controls, you typically create a host window as a child of the HWND and make the controls children of that host window. Wrapping the controls in a host window provides a simple way for your [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] page to receive notifications from the controls, which deals with some particular [!INCLUDE[TLA2#tla_win32](../../../../includes/tla2sharptla-win32-md.md)] issues with notifications across the HWND boundary.  
  
6.  Handle selected messages sent to the host window, such as notifications from child controls. There are two ways to do this.  
  
    -   If you prefer to handle messages in your hosting class, override the <xref:System.Windows.Interop.HwndHost.WndProc%2A> method of the <xref:System.Windows.Interop.HwndHost> class.  
  
    -   If you prefer to have the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] handle the messages, handle the <xref:System.Windows.Interop.HwndHost> class <xref:System.Windows.Interop.HwndHost.MessageHook> event in your code-behind. This event occurs for every message that is received by the hosted window. If you choose this option, you must still override <xref:System.Windows.Interop.HwndHost.WndProc%2A>, but you only need a minimal implementation.  
  
7.  Override the <xref:System.Windows.Interop.HwndHost.DestroyWindowCore%2A> and <xref:System.Windows.Interop.HwndHost.WndProc%2A> methods of <xref:System.Windows.Interop.HwndHost>. You must override these methods to satisfy the <xref:System.Windows.Interop.HwndHost> contract, but you may only need to provide a minimal implementation.  
  
8.  In your code-behind file, create an instance of the control hosting class and make it a child of the <xref:System.Windows.Controls.Border> element that is intended to host the window.  
  
9. Communicate with the hosted window by sending it [!INCLUDE[TLA#tla_win](../../../../includes/tlasharptla-win-md.md)] messages and handling messages from its child windows, such as notifications sent by controls.  
  
<a name="page_layout"></a>   
## Implement the Page Layout  
 The layout for the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] page that hosts the ListBox Control consists of two regions. The left side of the page hosts several [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] controls that provide a [!INCLUDE[TLA#tla_ui](../../../../includes/tlasharptla-ui-md.md)] that allows you to manipulate the [!INCLUDE[TLA2#tla_win32](../../../../includes/tla2sharptla-win32-md.md)] control. The upper right corner of the page has a square region for the hosted ListBox Control.  
  
 The code to implement this layout is quite simple. The root element is a <xref:System.Windows.Controls.DockPanel> that has two child elements. The first is a <xref:System.Windows.Controls.Border> element that hosts the ListBox Control. It occupies a 200x200 square in the upper right corner of the page. The second is a <xref:System.Windows.Controls.StackPanel> element that contains a set of [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] controls that display information and allow you to manipulate the ListBox Control by setting exposed interoperation properties. For each of the elements that are children of the <xref:System.Windows.Controls.StackPanel>, see the reference material for the various elements used for details on what these elements are or what they do, these are listed in the example code below but will not be explained here (the basic interoperation model does not require any of them, they are provided to add some interactivity to the sample).  
  
 [!code-xaml[WPFHostingWin32Control#WPFUI](../../../../samples/snippets/csharp/VS_Snippets_Wpf/WPFHostingWin32Control/CSharp/Page1.xaml#wpfui)]  
  
<a name="host_class"></a>   
## Implement a Class to Host the Microsoft Win32 Control  
 The core of this sample is the class that actually hosts the control, ControlHost.cs. It inherits from <xref:System.Windows.Interop.HwndHost>. The constructor takes two parameters, height and width, which correspond to the height and width of the <xref:System.Windows.Controls.Border> element that hosts the ListBox control. These values are used later to ensure that the size of the control matches the <xref:System.Windows.Controls.Border> element.  
  
 [!code-csharp[WPFHostingWin32Control#ControlHostClass](../../../../samples/snippets/csharp/VS_Snippets_Wpf/WPFHostingWin32Control/CSharp/ControlHost.cs#controlhostclass)]
 [!code-vb[WPFHostingWin32Control#ControlHostClass](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/WPFHostingWin32Control/VisualBasic/ControlHost.vb#controlhostclass)]  
  
 There is also a set of constants. These constants are largely taken from Winuser.h, and allow you to use conventional names when calling [!INCLUDE[TLA2#tla_win32](../../../../includes/tla2sharptla-win32-md.md)] functions.  
  
 [!code-csharp[WPFHostingWin32Control#ControlHostConstants](../../../../samples/snippets/csharp/VS_Snippets_Wpf/WPFHostingWin32Control/CSharp/ControlHost.cs#controlhostconstants)]
 [!code-vb[WPFHostingWin32Control#ControlHostConstants](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/WPFHostingWin32Control/VisualBasic/ControlHost.vb#controlhostconstants)]  
  
<a name="buildwindowcore"></a>   
### Override BuildWindowCore to Create the Microsoft Win32 Window  
 You override this method to create the [!INCLUDE[TLA2#tla_win32](../../../../includes/tla2sharptla-win32-md.md)] window that will be hosted by the page, and make the connection between the window and the page. Because this sample involves hosting a ListBox Control, two windows are created. The first is the window that is actually hosted by the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] page. The ListBox Control is created as a child of that window.  
  
 The reason for this approach is to simplify the process of receiving notifications from the control. The <xref:System.Windows.Interop.HwndHost> class allows you to process messages sent to the window that it is hosting. If you host a [!INCLUDE[TLA2#tla_win32](../../../../includes/tla2sharptla-win32-md.md)] control directly, you receive the messages sent to the internal message loop of the control. You can display the control and send it messages, but you do not receive the notifications that the control sends to its parent window. This means, among other things, that you have no way of detecting when the user interacts with the control. Instead, create a host window and make the control a child of that window. This allows you to process the messages for the host window including the notifications sent to it by the control. For convenience, since the host window is little more than a simple wrapper for the control, the package will be referred to as a ListBox control.  
  
<a name="create_the_window_and_listbox"></a>   
#### Create the Host Window and ListBox Control  
 You can use [!INCLUDE[TLA2#tla_pinvoke](../../../../includes/tla2sharptla-pinvoke-md.md)] to create a host window for the control by creating and registering a window class, and so on. However, a much simpler approach is to create a window with the predefined "static" window class. This provides you with the window procedure you need in order to receive notifications from the control, and requires minimal coding.  
  
 The HWND of the control is exposed through a read-only property, such that the host page can use it to send messages to the control.  
  
 [!code-csharp[WPFHostingWin32Control#IntPtrProperty](../../../../samples/snippets/csharp/VS_Snippets_Wpf/WPFHostingWin32Control/CSharp/ControlHost.cs#intptrproperty)]
 [!code-vb[WPFHostingWin32Control#IntPtrProperty](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/WPFHostingWin32Control/VisualBasic/ControlHost.vb#intptrproperty)]  
  
 The ListBox control is created as a child of the host window. The height and width of both windows are set to the values passed to the constructor, discussed above. This ensures that the size of the host window and control is identical to the reserved area on the page.  After the windows are created, the sample returns a <xref:System.Runtime.InteropServices.HandleRef> object that contains the HWND of the host window.  
  
 [!code-csharp[WPFHostingWin32Control#BuildWindowCore](../../../../samples/snippets/csharp/VS_Snippets_Wpf/WPFHostingWin32Control/CSharp/ControlHost.cs#buildwindowcore)]
 [!code-vb[WPFHostingWin32Control#BuildWindowCore](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/WPFHostingWin32Control/VisualBasic/ControlHost.vb#buildwindowcore)]  
  
 [!code-csharp[WPFHostingWin32Control#BuildWindowCoreHelper](../../../../samples/snippets/csharp/VS_Snippets_Wpf/WPFHostingWin32Control/CSharp/ControlHost.cs#buildwindowcorehelper)]
 [!code-vb[WPFHostingWin32Control#BuildWindowCoreHelper](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/WPFHostingWin32Control/VisualBasic/ControlHost.vb#buildwindowcorehelper)]  
  
<a name="destroywindow_wndproc"></a>   
### Implement DestroyWindow and WndProc  
 In addition to <xref:System.Windows.Interop.HwndHost.BuildWindowCore%2A>, you must also override the <xref:System.Windows.Interop.HwndHost.WndProc%2A> and <xref:System.Windows.Interop.HwndHost.DestroyWindowCore%2A> methods of the <xref:System.Windows.Interop.HwndHost>. In this example, the messages for the control are handled by the <xref:System.Windows.Interop.HwndHost.MessageHook> handler, thus the implementation of <xref:System.Windows.Interop.HwndHost.WndProc%2A> and <xref:System.Windows.Interop.HwndHost.DestroyWindowCore%2A> is minimal. In the case of <xref:System.Windows.Interop.HwndHost.WndProc%2A>, set `handled` to `false` to indicate that the  message was not handled and return 0. For <xref:System.Windows.Interop.HwndHost.DestroyWindowCore%2A>, simply destroy the window.  
  
 [!code-csharp[WPFHostingWin32Control#WndProcDestroy](../../../../samples/snippets/csharp/VS_Snippets_Wpf/WPFHostingWin32Control/CSharp/ControlHost.cs#wndprocdestroy)]
 [!code-vb[WPFHostingWin32Control#WndProcDestroy](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/WPFHostingWin32Control/VisualBasic/ControlHost.vb#wndprocdestroy)]  
  
 [!code-csharp[WPFHostingWin32Control#WndProcDestroyHelper](../../../../samples/snippets/csharp/VS_Snippets_Wpf/WPFHostingWin32Control/CSharp/ControlHost.cs#wndprocdestroyhelper)]
 [!code-vb[WPFHostingWin32Control#WndProcDestroyHelper](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/WPFHostingWin32Control/VisualBasic/ControlHost.vb#wndprocdestroyhelper)]  
  
<a name="host_the_control"></a>   
## Host the Control on the Page  
 To host the control on the page, you first create a new instance of the `ControlHost` class. Pass the height and width of the border element that contains the control (`ControlHostElement`) to the `ControlHost` constructor. This ensures that the ListBox is sized correctly. You then host the control on the page by assigning the `ControlHost` object to the <xref:System.Windows.Controls.Decorator.Child%2A> property of the host <xref:System.Windows.Controls.Border>.  
  
 The sample attaches a handler to the <xref:System.Windows.Interop.HwndHost.MessageHook> event of the `ControlHost` to receive messages from the control. This event is raised for every message sent to the hosted window. In this case, these are the messages sent to window that wraps the actual ListBox control, including notifications from the control. The sample calls SendMessage to obtain information from the control and modify its contents. The details of how the page communicates with the control are discussed in the next section.  
  
> [!NOTE]
>  Notice that there are two [!INCLUDE[TLA2#tla_pinvoke](../../../../includes/tla2sharptla-pinvoke-md.md)] declarations for SendMessage. This is necessary because one uses the `wParam` parameter to pass a string and the other uses it to pass an integer. You need a separate declaration for each signature to ensure that the data is marshaled correctly.  
  
 [!code-csharp[WPFHostingWin32Control#HostWindowClass](../../../../samples/snippets/csharp/VS_Snippets_Wpf/WPFHostingWin32Control/CSharp/Page1.xaml.cs#hostwindowclass)]
 [!code-vb[WPFHostingWin32Control#HostWindowClass](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/WPFHostingWin32Control/VisualBasic/Page1.xaml.vb#hostwindowclass)]  
  
 [!code-csharp[WPFHostingWin32Control#ControlMsgFilterSendMessage](../../../../samples/snippets/csharp/VS_Snippets_Wpf/WPFHostingWin32Control/CSharp/Page1.xaml.cs#controlmsgfiltersendmessage)]
 [!code-vb[WPFHostingWin32Control#ControlMsgFilterSendMessage](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/WPFHostingWin32Control/VisualBasic/Page1.xaml.vb#controlmsgfiltersendmessage)]  
  
<a name="communication"></a>   
## Implement Communication Between the Control and the Page  
 You manipulate the control by sending it [!INCLUDE[TLA2#tla_win](../../../../includes/tla2sharptla-win-md.md)] messages. The control notifies you when the user interacts with it by sending notifications to its host window. The [Hosting a Win32 ListBox Control in WPF Sample](http://go.microsoft.com/fwlink/?LinkID=159998) sample includes a UI that provides several examples of how this works:  
  
-   Append an item to the list.  
  
-   Delete the selected item from the list  
  
-   Display the text of the currently selected item.  
  
-   Display the number of items in the list.  
  
 The user can also select an item in the list box by clicking on it, just as they would for a conventional [!INCLUDE[TLA2#tla_win32](../../../../includes/tla2sharptla-win32-md.md)] application. The displayed data is updated each time the user changes the state of the list box by selecting, adding, or appending an item.  
  
 To append items, send the list box an LB_ADDSTRING message. To delete items, send LB_GETCURSEL to get the index of the current selection and then LB_DELETESTRING to delete the item. The sample also sends LB_GETCOUNT, and uses the returned value to update the display that shows the number of items. Both these instances of SendMessage use one of the [!INCLUDE[TLA2#tla_pinvoke](../../../../includes/tla2sharptla-pinvoke-md.md)] declarations discussed in the previous section.  
  
 [!code-csharp[WPFHostingWin32Control#AppendDeleteText](../../../../samples/snippets/csharp/VS_Snippets_Wpf/WPFHostingWin32Control/CSharp/Page1.xaml.cs#appenddeletetext)]
 [!code-vb[WPFHostingWin32Control#AppendDeleteText](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/WPFHostingWin32Control/VisualBasic/Page1.xaml.vb#appenddeletetext)]  
  
 When the user selects an item or changes their selection, the control notifies the host window by sending it a WM_COMMAND message, which raises the <xref:System.Windows.Interop.HwndHost.MessageHook> event for the page. The handler receives the same information as the main window procedure of the host window. It also passes a reference to a Boolean value, `handled`. You set `handled` to `true` to indicate that you have handled the message and no further processing is needed.  
  
 WM_COMMAND is sent for a variety of reasons, so you must examine the notification ID to determine whether it is an event that you wish to handle. The ID is contained in the high word of the `wParam` parameter. Since [!INCLUDE[TLA#tla_net](../../../../includes/tlasharptla-net-md.md)] does not have a HIWORD macro, the sample uses bitwise operators to extract the ID. If the user has made or changed their selection, the ID will be LBN_SELCHANGE.  
  
 When LBN_SELCHANGE is received, the sample gets the index of the selected item by sending the control a LB_GETCURSEL message. To get the text, you first create a <xref:System.Text.StringBuilder>. You then send the control an LB_GETTEXT message. Pass the empty <xref:System.Text.StringBuilder> object as the `wParam` parameter. When SendMessage returns, the <xref:System.Text.StringBuilder> will contain the text of the selected item. This use of SendMessage requires yet another [!INCLUDE[TLA2#tla_pinvoke](../../../../includes/tla2sharptla-pinvoke-md.md)] declaration.  
  
 Finally, set `handled` to `true` to indicate that the message has been handled.  
  
## See Also  
 <xref:System.Windows.Interop.HwndHost>  
 [WPF and Win32 Interoperation](../../../../docs/framework/wpf/advanced/wpf-and-win32-interoperation.md)  
 [Walkthrough: My first WPF desktop application](../../../../docs/framework/wpf/getting-started/walkthrough-my-first-wpf-desktop-application.md)
