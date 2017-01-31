---
title: "Using Windows Runtime objects in a multithreaded environment | Microsoft Docs"
ms.custom: ""
ms.date: "01/14/2017"
ms.prod: "windows-client-threshold"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 43ffd28c-c4df-405c-bf5c-29c94e0d142b
caps.latest.revision: 8
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
---
# Using Windows Runtime objects in a multithreaded environment
This article discusses the way the .NET Framework handles calls from C# and Visual Basic code to objects that are provided by the [!INCLUDE[wrt](../net-uwp/includes/wrt-md.md)] or by [!INCLUDE[wrt](../net-uwp/includes/wrt-md.md)] Components.  
  
 In the .NET Framework, you can access any object from multiple threads by default, without special handling. All you need is a reference to the object. In the [!INCLUDE[wrt](../net-uwp/includes/wrt-md.md)], such objects are called *agile*. Most [!INCLUDE[wrt](../net-uwp/includes/wrt-md.md)] classes are agile, but a few classes are not, and even agile classes may require special handling.  
  
 Wherever possible, the common language runtime (CLR) treats objects from other sources, such as the [!INCLUDE[wrt](../net-uwp/includes/wrt-md.md)], as if they were .NET Framework objects:  
  
-   If the object implements the [IAgileObject](http://msdn.microsoft.com/library/Hh802476.aspx) interface, or has the [MarshalingBehaviorAttribute](http://go.microsoft.com/fwlink/p/?LinkId=256022) attribute with [MarshalingType.Agile](http://go.microsoft.com/fwlink/p/?LinkId=256023), the CLR treats it as agile.  
  
-   If CLR can marshal a call from the thread where it was made to the threading context of the target object, it does so transparently.  
  
-   If the object has the [MarshalingBehaviorAttribute](http://go.microsoft.com/fwlink/p/?LinkId=256022) attribute with [MarshalingType.None](http://go.microsoft.com/fwlink/p/?LinkId=256023), the class does not provide marshaling information. The CLR cannot marshal the call, so it throws an <xref:System.InvalidCastException> exception with a message indicating that the object can be used only in the threading context where it was created.  
  
 The following sections describe the effects of this behavior on objects from various sources.  
  
## Objects from a [!INCLUDE[wrt](../net-uwp/includes/wrt-md.md)] component that is written in C# or Visual Basic  
 All the types in the component that can be activated are agile by default.  
  
> [!NOTE]
>  Agility doesn't imply thread safety. In both the [!INCLUDE[wrt](../net-uwp/includes/wrt-md.md)] and the .NET Framework, most classes are not thread safe because thread safety has a performance cost, and most objects are never accessed by multiple threads. It's more efficient to synchronize access to individual objects (or to use thread-safe classes) only as necessary.  
  
 When you author a [!INCLUDE[wrt](../net-uwp/includes/wrt-md.md)] component, you can override the default. See the <xref:System.Runtime.InteropServices.ICustomQueryInterface> interface and the [IAgileObject](http://msdn.microsoft.com/library/Hh802476.aspx) interface.  
  
## Objects from the [!INCLUDE[wrt](../net-uwp/includes/wrt-md.md)]  
 Most classes in the [!INCLUDE[wrt](../net-uwp/includes/wrt-md.md)] are agile, and the CLR treats them as agile. The documentation for these classes lists "MarshalingBehaviorAttribute(Agile)" among the class attributes. However, the members of some of these agile classes, such as XAML controls, throw exceptions if they aren't called on the UI thread. For example, the following code tries to use a background thread to set a property of the button that was clicked. The button's [Content](http://go.microsoft.com/fwlink/p/?LinkId=256025) property throws an exception.  
  
```c#  
  
private async void Button_Click_2(object sender, RoutedEventArgs e)  
{  
    Button b = (Button) sender;  
    await Task.Run(() => {   
        b.Content += ".";   
    });  
}  
  
```  
  
```vb  
  
Private Async Sub Button_Click_2(sender As Object, e As RoutedEventArgs)  
    Dim b As Button = CType(sender, Button)  
    Await Task.Run(Sub()  
                       b.Content &= "."  
                   End Sub)  
End Sub  
  
```  
  
 You can access the button safely by using its [Dispatcher](http://go.microsoft.com/fwlink/p/?LinkId=256026) property, or the `Dispatcher` property of any object that exists in the context of the UI thread (such as the page the button is on). The following code uses the [CoreDispatcher](http://go.microsoft.com/fwlink/p/?LinkId=256029) object's [RunAsync](http://go.microsoft.com/fwlink/p/?LinkId=256030) method to dispatch the call on the UI thread.  
  
```c#  
  
private async void Button_Click_2(object sender, RoutedEventArgs e)  
{  
    Button b = (Button) sender;  
    await b.Dispatcher.RunAsync(  
        Windows.UI.Core.CoreDispatcherPriority.Normal,   
        () => {   
            b.Content += ".";   
    });  
}  
  
```  
  
```vb  
Private Async Sub Button_Click_2(sender As Object, e As RoutedEventArgs)  
    Dim b As Button = CType(sender, Button)  
    Await b.Dispatcher.RunAsync(  
        Windows.UI.Core.CoreDispatcherPriority.Normal,   
        Sub()  
            b.Content &= "."  
        End Sub)  
End Sub  
  
```  
  
> [!NOTE]
>  The `Dispatcher` property does not throw an exception when it's called from another thread.  
  
 The lifetime of a [!INCLUDE[wrt](../net-uwp/includes/wrt-md.md)] object that is created on the UI thread is bounded by the lifetime of the thread. Do not try to access objects on a UI thread after the window has closed.  
  
 If you create your own control by inheriting a XAML control, or by composing a set of XAML controls, your control is agile because it's a .NET Framework object. However, if it calls members of its base class or constituent classes, or if you call inherited members, those members will throw exceptions when they are called from any thread except the UI thread.  
  
### Classes that can't be marshaled  
 [!INCLUDE[wrt](../net-uwp/includes/wrt-md.md)] classes that do not provide marshaling information have the [MarshalingBehaviorAttribute](http://go.microsoft.com/fwlink/p/?LinkId=256022) attribute with [MarshalingType.None](http://go.microsoft.com/fwlink/p/?LinkId=256023). The documentation for such a class lists "MarshalingBehaviorAttribute(None)" among its attributes.  
  
 The following code creates a [CameraCaptureUI](http://go.microsoft.com/fwlink/p/?LinkId=256027) object on the UI thread, and then tries to set a property of the object from a thread pool thread. The CLR is unable to marshal the call, and throws an <xref:System.InvalidCastException> exception with a message indicating that the object can be used only in the threading context where it was created.  
  
```c#  
  
Windows.Media.Capture.CameraCaptureUI ccui;  
  
private async void Button_Click_1(object sender, RoutedEventArgs e)  
{  
    ccui = new Windows.Media.Capture.CameraCaptureUI();  
  
    await Task.Run(() => {   
        ccui.PhotoSettings.AllowCropping = true;   
    });  
}  
  
```  
  
```vb  
  
Private ccui As Windows.Media.Capture.CameraCaptureUI  
  
Private Async Sub Button_Click_1(sender As Object, e As RoutedEventArgs)  
    ccui = New Windows.Media.Capture.CameraCaptureUI()  
  
    Await Task.Run(Sub()  
                       ccui.PhotoSettings.AllowCropping = True  
                   End Sub)  
End Sub  
  
```  
  
 The documentation for [CameraCaptureUI](http://go.microsoft.com/fwlink/p/?LinkId=256027) also lists "ThreadingAttribute(STA)" among the class's attributes, because it must be created in a single-threaded context such as the UI thread.  
  
 If you want to access the [CameraCaptureUI](http://go.microsoft.com/fwlink/p/?LinkId=256027) object from another thread, you can cache the [CoreDispatcher](http://go.microsoft.com/fwlink/p/?LinkId=256029) object for the UI thread and use it later to dispatch the call on that thread. Or you can obtain the dispatcher from a XAML object such as the page, as shown in the following code.  
  
```c#  
  
Windows.Media.Capture.CameraCaptureUI ccui;  
  
private async void Button_Click_3(object sender, RoutedEventArgs e)  
{  
    ccui = new Windows.Media.Capture.CameraCaptureUI();  
  
    await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal,  
        () => {  
            ccui.PhotoSettings.AllowCropping = true;  
        });  
}  
  
```  
  
```vb  
  
Dim ccui As Windows.Media.Capture.CameraCaptureUI  
  
Private Async Sub Button_Click_3(sender As Object, e As RoutedEventArgs)  
  
    ccui = New Windows.Media.Capture.CameraCaptureUI()  
  
    Await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal,  
                                Sub()  
                                    ccui.PhotoSettings.AllowCropping = True  
                                End Sub)  
End Sub  
  
```  
  
## Objects from a [!INCLUDE[wrt](../net-uwp/includes/wrt-md.md)] component that is written in C++  
 By default, classes in the component that can be activated are agile. However, C++ allows a significant amount of control over threading models and marshaling behavior. As described earlier in this article, the CLR recognizes agile classes, tries to marshal calls when classes are not agile, and throws an <xref:System.InvalidCastException> exception when a class has no marshaling information.  
  
 For objects that run on the UI thread and throw exceptions when they are called from a thread other than the UI thread, you can use the UI thread’s [CoreDispatcher](http://go.microsoft.com/fwlink/p/?LinkId=256029) object to dispatch the call.  
  
## See Also  
 [Visual Basic and C# language reference](../Topic/Visual%20Basic%20and%20C%23%20language%20reference.md)