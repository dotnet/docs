---
title: "Sharing Message Loops Between Win32 and WPF"
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
  - "Win32 code [WPF], sharing message loops"
  - "message loops [WPF]"
  - "sharing message loops [WPF]"
  - "interoperability [WPF], Win32"
ms.assetid: 39ee888c-e5ec-41c8-b11f-7b851a554442
caps.latest.revision: 10
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Sharing Message Loops Between Win32 and WPF
This topic describes how to implement a message loop for interoperation with [!INCLUDE[TLA#tla_winclient](../../../../includes/tlasharptla-winclient-md.md)], either by using existing message loop exposure in <xref:System.Windows.Threading.Dispatcher> or by creating a separate message loop on the [!INCLUDE[TLA#tla_win32](../../../../includes/tlasharptla-win32-md.md)] side of your interoperation code.  
  
## ComponentDispatcher and the Message Loop  
 A normal scenario for interoperation and keyboard event support is to implement <xref:System.Windows.Interop.IKeyboardInputSink>, or to subclass from classes that already implement <xref:System.Windows.Interop.IKeyboardInputSink>, such as <xref:System.Windows.Interop.HwndSource> or <xref:System.Windows.Interop.HwndHost>. However, keyboard sink support does not address all possible message loop needs you might have when sending and receiving messages across your interoperation boundaries. To help formalize an application message loop architecture, [!INCLUDE[TLA#tla_winclient](../../../../includes/tlasharptla-winclient-md.md)] provides the <xref:System.Windows.Interop.ComponentDispatcher> class, which defines a simple protocol for a message loop to follow.  
  
 <xref:System.Windows.Interop.ComponentDispatcher> is a static class that exposes several members. The scope of each method is implicitly tied to the calling thread. A message loop must call some of those [!INCLUDE[TLA2#tla_api#plural](../../../../includes/tla2sharptla-apisharpplural-md.md)] at critical times (as defined in the next section).  
  
 <xref:System.Windows.Interop.ComponentDispatcher> provides events that other components (such as the keyboard sink) can listen for. The <xref:System.Windows.Threading.Dispatcher> class calls all the appropriate <xref:System.Windows.Interop.ComponentDispatcher> methods in an appropriate sequence. If you are implementing your own message loop, your code is responsible for calling <xref:System.Windows.Interop.ComponentDispatcher> methods in a similar fashion.  
  
 Calling <xref:System.Windows.Interop.ComponentDispatcher> methods on a thread will only invoke event handlers that were registered on that thread.  
  
## Writing Message Loops  
 The following is a checklist of <xref:System.Windows.Interop.ComponentDispatcher> members you will use if you write your own message loop:  
  
-   <xref:System.Windows.Interop.ComponentDispatcher.PushModal%2A>: your message loop should call this to indicate that the thread is modal.  
  
-   <xref:System.Windows.Interop.ComponentDispatcher.PopModal%2A>:your message loop should call this to indicate that the thread has reverted to nonmodal.  
  
-   <xref:System.Windows.Interop.ComponentDispatcher.RaiseIdle%2A>: your message loop should call this to indicate that <xref:System.Windows.Interop.ComponentDispatcher> should raise the <xref:System.Windows.Interop.ComponentDispatcher.ThreadIdle> event. <xref:System.Windows.Interop.ComponentDispatcher> will not raise <xref:System.Windows.Interop.ComponentDispatcher.ThreadIdle> if <xref:System.Windows.Interop.ComponentDispatcher.IsThreadModal%2A> is `true`, but message loops may choose to call <xref:System.Windows.Interop.ComponentDispatcher.RaiseIdle%2A> even if <xref:System.Windows.Interop.ComponentDispatcher> cannot respond to it while in modal state.  
  
-   <xref:System.Windows.Interop.ComponentDispatcher.RaiseThreadMessage%2A>: your message loop should call this to indicate that a new message is available. The return value indicates whether a listener to a <xref:System.Windows.Interop.ComponentDispatcher> event handled the message. If <xref:System.Windows.Interop.ComponentDispatcher.RaiseThreadMessage%2A> returns `true` (handled), the dispatcher should do nothing further with the message. If the return value is `false`, the dispatcher is expected to call the [!INCLUDE[TLA2#tla_win32](../../../../includes/tla2sharptla-win32-md.md)] function `TranslateMessage`, then call `DispatchMessage`.  
  
## Using ComponentDispatcher and Existing Message Handling  
 The following is a checklist of <xref:System.Windows.Interop.ComponentDispatcher> members you will use if you rely on the inherent [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] message loop.  
  
-   <xref:System.Windows.Interop.ComponentDispatcher.IsThreadModal%2A>: returns whether the application has gone modal (e.g., a modal message loop has been pushed). <xref:System.Windows.Interop.ComponentDispatcher> can track this state because the class maintains a count of <xref:System.Windows.Interop.ComponentDispatcher.PushModal%2A> and <xref:System.Windows.Interop.ComponentDispatcher.PopModal%2A> calls from the message loop.  
  
-   <xref:System.Windows.Interop.ComponentDispatcher.ThreadFilterMessage> and <xref:System.Windows.Interop.ComponentDispatcher.ThreadPreprocessMessage> events follow the standard rules for delegate invocations. Delegates are invoked in an unspecified order, and all delegates are invoked even if the first one marks the message as handled.  
  
-   <xref:System.Windows.Interop.ComponentDispatcher.ThreadIdle>: indicates an appropriate and efficient time to do idle processing (there are no other pending messages for the thread). <xref:System.Windows.Interop.ComponentDispatcher.ThreadIdle> will not be raised if the thread is modal.  
  
-   <xref:System.Windows.Interop.ComponentDispatcher.ThreadFilterMessage>: raised for all messages that the message pump processes.  
  
-   <xref:System.Windows.Interop.ComponentDispatcher.ThreadPreprocessMessage>: raised for all messages that were not handled during <xref:System.Windows.Interop.ComponentDispatcher.ThreadFilterMessage>.  
  
 A message is considered handled if after the <xref:System.Windows.Interop.ComponentDispatcher.ThreadFilterMessage> event or <xref:System.Windows.Interop.ComponentDispatcher.ThreadPreprocessMessage> event, the `handled` parameter passed by reference in event data is `true`. Event handlers should ignore the message if `handled` is `true`, because that means the different handler handled the message first. Event handlers to both events may modify the message. The dispatcher should dispatch the modified message and not the original unchanged message. <xref:System.Windows.Interop.ComponentDispatcher.ThreadPreprocessMessage> is delivered to all listeners, but the architectural intention is that only the top-level window containing the HWND at which the messages targeted should invoke code in response to the message.  
  
## How HwndSource Treats ComponentDispatcher Events  
 If the <xref:System.Windows.Interop.HwndSource> is a top-level window (no parent HWND), it will register with <xref:System.Windows.Interop.ComponentDispatcher>. If <xref:System.Windows.Interop.ComponentDispatcher.ThreadPreprocessMessage> is raised, and if the message is intended for the <xref:System.Windows.Interop.HwndSource> or child windows, <xref:System.Windows.Interop.HwndSource> calls its <xref:System.Windows.Interop.HwndSource.System%23Windows%23Interop%23IKeyboardInputSink%23TranslateAccelerator%2A>, <xref:System.Windows.Interop.IKeyboardInputSink.TranslateChar%2A>, <xref:System.Windows.Interop.IKeyboardInputSink.OnMnemonic%2A> keyboard sink sequence.  
  
 If the <xref:System.Windows.Interop.HwndSource> is not a top-level window (has a parent HWND), there will be no handling. Only the top level window is expected to do the handling, and there is expected to be a top level window with keyboard sink support as part of any interoperation scenario.  
  
 If <xref:System.Windows.Interop.HwndHost.WndProc%2A> on an <xref:System.Windows.Interop.HwndSource> is called without an appropriate keyboard sink method being called first, your application will receive the higher level keyboard events such as <xref:System.Windows.UIElement.KeyDown>. However, no keyboard sink methods will be called, which circumvents desirable keyboard input model features such as access key support. This might happen because the message loop did not properly notify the relevant thread on the <xref:System.Windows.Interop.ComponentDispatcher>, or because the parent HWND did not invoke the proper keyboard sink responses.  
  
 A message that goes to the keyboard sink might not be sent to the HWND if you added hooks for that message by using the <xref:System.Windows.Interop.HwndSource.AddHook%2A> method. The message might have been handled at the message pump level directly and not submitted to the `DispatchMessage` function.  
  
## See Also  
 <xref:System.Windows.Interop.ComponentDispatcher>  
 <xref:System.Windows.Interop.IKeyboardInputSink>  
 [WPF and Win32 Interoperation](../../../../docs/framework/wpf/advanced/wpf-and-win32-interoperation.md)  
 [Threading Model](../../../../docs/framework/wpf/advanced/threading-model.md)  
 [Input Overview](../../../../docs/framework/wpf/advanced/input-overview.md)
