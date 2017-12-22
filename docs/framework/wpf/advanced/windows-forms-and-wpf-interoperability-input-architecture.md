---
title: "Windows Forms and WPF Interoperability Input Architecture"
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
  - "input architecture [WPF interoperability]"
  - "messages [WPF]"
  - "Windows Forms [WPF], interoperability with"
  - "Windows Forms [WPF], WPF interoperation"
  - "interoperability [WPF], Windows Forms"
  - "modeless forms [WPF]"
  - "ElementHost keyboard and messages [WPF]"
  - "keyboard interoperation [WPF]"
  - "WindowsFormsHost keyboard and messages [WPF]"
  - "modeless dialog boxes [WPF]"
ms.assetid: 0eb6f137-f088-4c5e-9e37-f96afd28f235
caps.latest.revision: 20
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Windows Forms and WPF Interoperability Input Architecture
Interoperation between the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] and [!INCLUDE[TLA#tla_winforms](../../../../includes/tlasharptla-winforms-md.md)] requires that both technologies have the appropriate keyboard input processing. This topic describes how these technologies implement keyboard and message processing to enable smooth interoperation in hybrid applications.  
  
 This topic contains the following subsections:  
  
-   Modeless Forms and Dialog Boxes  
  
-   WindowsFormsHost Keyboard and Message Processing  
  
-   ElementHost Keyboard and Message Processing  
  
## Modeless Forms and Dialog Boxes  
 Call the <xref:System.Windows.Forms.Integration.WindowsFormsHost.EnableWindowsFormsInterop%2A> method on the <xref:System.Windows.Forms.Integration.WindowsFormsHost> element to open a modeless form or dialog box from a [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)]-based application.  
  
 Call the <xref:System.Windows.Forms.Integration.ElementHost.EnableModelessKeyboardInterop%2A> method on the <xref:System.Windows.Forms.Integration.ElementHost> control to open a modeless [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] page in a [!INCLUDE[TLA#tla_winforms](../../../../includes/tlasharptla-winforms-md.md)]-based application.  
  
## WindowsFormsHost Keyboard and Message Processing  
 When hosted by a [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)]-based application, [!INCLUDE[TLA#tla_winforms](../../../../includes/tlasharptla-winforms-md.md)] keyboard and message processing consists of the following:  
  
-   The <xref:System.Windows.Forms.Integration.WindowsFormsHost> class acquires messages from the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] message loop, which is implemented by the <xref:System.Windows.Interop.ComponentDispatcher> class.  
  
-   The <xref:System.Windows.Forms.Integration.WindowsFormsHost> class creates a surrogate [!INCLUDE[TLA#tla_winforms](../../../../includes/tlasharptla-winforms-md.md)] message loop to ensure that ordinary [!INCLUDE[TLA#tla_winforms](../../../../includes/tlasharptla-winforms-md.md)] keyboard processing occurs.  
  
-   The <xref:System.Windows.Forms.Integration.WindowsFormsHost> class implements the <xref:System.Windows.Interop.IKeyboardInputSink> interface to coordinate focus management with [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)].  
  
-   The <xref:System.Windows.Forms.Integration.WindowsFormsHost> controls register themselves and start their message loops.  
  
 The following sections describe these parts of the process in more detail.  
  
### Acquiring Messages from the WPF Message Loop  
 The <xref:System.Windows.Interop.ComponentDispatcher> class implements the message loop manager for [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)]. The <xref:System.Windows.Interop.ComponentDispatcher> class provides hooks to enable external clients to filter messages before [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] processes them.  
  
 The interoperation implementation handles the <xref:System.Windows.Interop.ComponentDispatcher.ThreadFilterMessage?displayProperty=nameWithType> event, which enables [!INCLUDE[TLA#tla_winforms](../../../../includes/tlasharptla-winforms-md.md)] controls to process messages before [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] controls.  
  
### Surrogate Windows Forms Message Loop  
 By default, the <xref:System.Windows.Forms.Application?displayProperty=nameWithType> class contains the primary message loop for [!INCLUDE[TLA#tla_winforms](../../../../includes/tlasharptla-winforms-md.md)] applications. During interoperation, the [!INCLUDE[TLA#tla_winforms](../../../../includes/tlasharptla-winforms-md.md)] message loop does not process messages. Therefore, this logic must be reproduced. The handler for the <xref:System.Windows.Interop.ComponentDispatcher.ThreadFilterMessage?displayProperty=nameWithType> event performs the following steps:  
  
1.  Filters the message using the <xref:System.Windows.Forms.IMessageFilter> interface.  
  
2.  Calls the <xref:System.Windows.Forms.Control.PreProcessMessage%2A?displayProperty=nameWithType> method.  
  
3.  Translates and dispatches the message, if it is required.  
  
4.  Passes the message to the hosting control, if no other controls process the message.  
  
### IKeyboardInputSink Implementation  
 The surrogate message loop handles keyboard management. Therefore, the <xref:System.Windows.Interop.IKeyboardInputSink.TabInto%2A?displayProperty=nameWithType> method is the only <xref:System.Windows.Interop.IKeyboardInputSink> member that requires an implementation in the <xref:System.Windows.Forms.Integration.WindowsFormsHost> class.  
  
 By default, the <xref:System.Windows.Interop.HwndHost> class returns `false` for its <xref:System.Windows.Interop.HwndHost.System%23Windows%23Interop%23IKeyboardInputSink%23TabInto%2A> implementation. This prevents tabbing from a [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] control to a [!INCLUDE[TLA#tla_winforms](../../../../includes/tlasharptla-winforms-md.md)] control.  
  
 The <xref:System.Windows.Forms.Integration.WindowsFormsHost> implementation of the <xref:System.Windows.Interop.IKeyboardInputSink.TabInto%2A?displayProperty=nameWithType> method performs the following steps:  
  
1.  Finds the first or last [!INCLUDE[TLA#tla_winforms](../../../../includes/tlasharptla-winforms-md.md)] control that is contained by the <xref:System.Windows.Forms.Integration.WindowsFormsHost> control and that can receive focus. The control choice depends on traversal information.  
  
2.  Sets focus to the control and returns `true`.  
  
3.  If no control can receive focus, returns `false`.  
  
### WindowsFormsHost Registration  
 When the window handle to a <xref:System.Windows.Forms.Integration.WindowsFormsHost> control is created, the <xref:System.Windows.Forms.Integration.WindowsFormsHost> control calls an internal static method that registers its presence for the message loop.  
  
 During registration, the <xref:System.Windows.Forms.Integration.WindowsFormsHost> control examines the message loop. If the message loop has not been started, the <xref:System.Windows.Interop.ComponentDispatcher.ThreadFilterMessage?displayProperty=nameWithType> event handler is created. The message loop is considered to be running when the <xref:System.Windows.Interop.ComponentDispatcher.ThreadFilterMessage?displayProperty=nameWithType> event handler is attached.  
  
 When the window handle is destroyed, the <xref:System.Windows.Forms.Integration.WindowsFormsHost> control removes itself from registration.  
  
## ElementHost Keyboard and Message Processing  
 When hosted by a [!INCLUDE[TLA#tla_winforms](../../../../includes/tlasharptla-winforms-md.md)] application, [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] keyboard and message processing consists of the following:  
  
-   <xref:System.Windows.Interop.HwndSource>, <xref:System.Windows.Interop.IKeyboardInputSink>, and <xref:System.Windows.Interop.IKeyboardInputSite> interface implementations.  
  
-   Tabbing and arrow keys.  
  
-   Command keys and dialog box keys.  
  
-   [!INCLUDE[TLA#tla_winforms](../../../../includes/tlasharptla-winforms-md.md)] accelerator processing.  
  
 The following sections describe these parts in more detail.  
  
### Interface Implementations  
 In [!INCLUDE[TLA#tla_winforms](../../../../includes/tlasharptla-winforms-md.md)], keyboard messages are routed to the window handle of the control that has focus. In the <xref:System.Windows.Forms.Integration.ElementHost> control, these messages are routed to the hosted element. To accomplish this, the <xref:System.Windows.Forms.Integration.ElementHost> control provides an <xref:System.Windows.Interop.HwndSource> instance. If the <xref:System.Windows.Forms.Integration.ElementHost> control has focus, the <xref:System.Windows.Interop.HwndSource> instance routes most keyboard input so that it can be processed by the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] <xref:System.Windows.Input.InputManager> class.  
  
 The <xref:System.Windows.Interop.HwndSource> class implements the <xref:System.Windows.Interop.IKeyboardInputSink> and <xref:System.Windows.Interop.IKeyboardInputSite> interfaces.  
  
 Keyboard interoperation relies on implementing the <xref:System.Windows.Interop.IKeyboardInputSite.OnNoMoreTabStops%2A> method to handle TAB key and arrow key input that moves focus out of hosted elements.  
  
### Tabbing and Arrow Keys  
 The [!INCLUDE[TLA#tla_winforms](../../../../includes/tlasharptla-winforms-md.md)] selection logic is mapped to the <xref:System.Windows.Interop.HwndSource.System%23Windows%23Interop%23IKeyboardInputSink%23TabInto%2A> and <xref:System.Windows.Interop.IKeyboardInputSite.OnNoMoreTabStops%2A> methods to implement TAB and arrow key navigation. Overriding the <xref:System.Windows.Forms.Integration.ElementHost.Select%2A> method accomplishes this mapping.  
  
### Command Keys and Dialog Box Keys  
 To give [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] the first opportunity to process command keys and dialog keys, [!INCLUDE[TLA#tla_winforms](../../../../includes/tlasharptla-winforms-md.md)] command preprocessing is connected to the <xref:System.Windows.Interop.IKeyboardInputSink.TranslateAccelerator%2A> method. Overriding the <xref:System.Windows.Forms.Control.ProcessCmdKey%2A?displayProperty=nameWithType> method connects the two technologies.  
  
 With the <xref:System.Windows.Interop.IKeyboardInputSink.TranslateAccelerator%2A> method, the hosted elements can handle any key message, such as WM_KEYDOWN, WM_KEYUP, WM_SYSKEYDOWN, or WM_SYSKEYUP, including command keys, such as TAB, ENTER, ESC, and arrow keys. If a key message is not handled, it is sent up the [!INCLUDE[TLA#tla_winforms](../../../../includes/tlasharptla-winforms-md.md)] ancestor hierarchy for handling.  
  
### Accelerator Processing  
 To process accelerators correctly, [!INCLUDE[TLA#tla_winforms](../../../../includes/tlasharptla-winforms-md.md)] accelerator processing must be connected to the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] <xref:System.Windows.Input.AccessKeyManager> class. Additionally, all WM_CHAR messages must be correctly routed to hosted elements.  
  
 Because the default <xref:System.Windows.Interop.HwndSource> implementation of the <xref:System.Windows.Interop.IKeyboardInputSink.TranslateChar%2A> method returns `false`, WM_CHAR messages are processed using the following logic:  
  
-   The <xref:System.Windows.Forms.Control.IsInputChar%2A?displayProperty=nameWithType> method is overridden to ensure that all WM_CHAR messages are forwarded to hosted elements.  
  
-   If the ALT key is pressed, the message is WM_SYSCHAR. [!INCLUDE[TLA#tla_winforms](../../../../includes/tlasharptla-winforms-md.md)] does not preprocess this message through the <xref:System.Windows.Forms.Control.IsInputChar%2A> method. Therefore, the <xref:System.Windows.Forms.Control.ProcessMnemonic%2A> method is overridden to query the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] <xref:System.Windows.Input.AccessKeyManager> for a registered accelerator. If a registered accelerator is found, <xref:System.Windows.Input.AccessKeyManager> processes it.  
  
-   If the ALT key is not pressed, the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] <xref:System.Windows.Input.InputManager> class processes the unhandled input. If the input is an accelerator, the <xref:System.Windows.Input.AccessKeyManager> processes it. The <xref:System.Windows.Input.InputManager.PostProcessInput> event is handled for WM_CHAR messages that were not processed.  
  
 When the user presses the ALT key, accelerator visual cues are shown on the whole form. To support this behavior, all <xref:System.Windows.Forms.Integration.ElementHost> controls on the active form receive WM_SYSKEYDOWN messages, regardless of which control has focus.  
  
 Messages are sent only to <xref:System.Windows.Forms.Integration.ElementHost> controls in the active form.  
  
## See Also  
 <xref:System.Windows.Forms.Integration.WindowsFormsHost.EnableWindowsFormsInterop%2A>  
 <xref:System.Windows.Forms.Integration.ElementHost.EnableModelessKeyboardInterop%2A>  
 <xref:System.Windows.Forms.Integration.ElementHost>  
 <xref:System.Windows.Forms.Integration.WindowsFormsHost>  
 [Walkthrough: Hosting a Windows Forms Composite Control in WPF](../../../../docs/framework/wpf/advanced/walkthrough-hosting-a-windows-forms-composite-control-in-wpf.md)  
 [Walkthrough: Hosting a WPF Composite Control in Windows Forms](../../../../docs/framework/wpf/advanced/walkthrough-hosting-a-wpf-composite-control-in-windows-forms.md)  
 [WPF and Win32 Interoperation](../../../../docs/framework/wpf/advanced/wpf-and-win32-interoperation.md)
