---
title: "Windows Forms and Unmanaged Applications Overview"
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
  - "COM [Windows Forms]"
  - "Windows Forms, unmanaged"
  - "COM interop"
  - "ActiveX controls [Windows Forms], about ActiveX controls"
  - "Windows Forms, interop"
ms.assetid: 0a26d99d-8135-4895-8760-c9a2b5f67f14
caps.latest.revision: 12
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Windows Forms and Unmanaged Applications Overview
Windows Forms applications and controls can interoperate with unmanaged applications, with some caveats. The following sections describe the scenarios and configurations that Windows Forms applications and controls support and those that they do not support.  
  
## Windows Forms Controls and ActiveX Applications  
 With the exception of Microsoft Internet Explorer and Microsoft Foundation Classes (MFC), Windows Forms controls are not supported in applications designed to host ActiveX controls. Other applications and development tools that are capable of hosting ActiveX controls, including the ActiveX test containers from versions of Visual Studio that are earlier than Visual Studio .NET 2003, are not supported hosts for Windows Forms controls.  
  
 These constraints also apply to the use of Windows Forms controls through Component Object Model COM interop. The use of a Windows Forms control through a COM callable wrapper (CCW) is supported only in Internet Explorer. For more information about COM interop, see  
  
 [COM Interop](../../../visual-basic/programming-guide/com-interop/index.md).  
  
 The following table shows the available ActiveX hosting support for Windows Forms controls.  
  
|Windows Forms version|Support|  
|---------------------------|-------------|  
|.NET Framework version 1.0|Internet Explorer 5.01 and later versions|  
|.NET Framework version 1.1 and later|Internet Explorer 5.01 and later versions<br /><br /> Microsoft Foundation Classes (MFC) 7.0 and later|  
  
## Hosting Windows Forms components as ActiveX controls  
 In the .NET Framework 1.1, support was extended to include MFC 7.0 and later versions. This support includes any container that is fully compatible with the MFC 7.0 and later ActiveX control container.  
  
 However, registration of Windows Forms controls as ActiveX controls is not supported. Also, calling the `com.ms.win32.Ole32.CoCreateInstance` method for Windows Forms controls is not supported. Only managed activation of Windows Forms controls is supported. Once you create a Windows Forms control, you can host it in an MFC application just as with an ActiveX control.  
  
 To use Windows Forms controls in your unmanaged application, you must either host the CLR using the unmanaged CLR hosting APIs or use the C++ interop features. Using the C++ interop features is the recommended solution.  
  
## Windows Forms in COM client applications  
 When you open a Windows Form from a COM client application, such as a Visual Basic 6.0 application or an MFC application, the form may behave unexpectedly. For example, when you press the TAB key, the focus does not change from one control to another control. When you press the ENTER key while a command button has focus, the button's <xref:System.Windows.Forms.Control.Click> event is not raised. You may also experience unexpected behavior for keystrokes or mouse activity.  
  
 This behavior occurs because the unmanaged application does not implement the message loop support that Windows Forms requires to work correctly. The message loop provided by the COM client application is fundamentally different from the Windows Forms message loop.  
  
 An application's message loop is an internal program loop that retrieves messages from a thread's message queue, translates them, and then sends them to the application to be handled. The message loop for a Windows Form does not have the same architecture as message loops that earlier applications, such as Visual Basic 6.0 applications and MFC applications, provide. The window messages that are posted to the message loop may be handled differently than the Windows Form expects. Therefore, unexpected behavior may occur. Some keystroke combinations may not work, some mouse activity may not work, or some events may not be raised as expected.  
  
## Resolving Interoperability Issues  
 You can resolve these problems by displaying the form on a [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)] message loop, which is created by using the <xref:System.Windows.Forms.Application.Run%2A?displayProperty=nameWithType> method.  
  
 To make a Windows Form work correctly from a COM client application, you must run it on a Windows Forms message loop. To do this, use one of the following approaches:  
  
-   Use the <xref:System.Windows.Forms.Form.ShowDialog%2A?displayProperty=nameWithType> method to display the Windows Form. For more information, see [How to: Support COM Interop by Displaying a Windows Form with the ShowDialog Method](../../../../docs/framework/winforms/advanced/com-interop-by-displaying-a-windows-form-shadow.md).  
  
-   Display each Windows Form on a new thread. For more information, see [How to: Support COM Interop by Displaying Each Windows Form on Its Own Thread](../../../../docs/framework/winforms/advanced/how-to-support-com-interop-by-displaying-each-windows-form-on-its-own-thread.md).  
  
## See Also  
 [Windows Forms and Unmanaged Applications](../../../../docs/framework/winforms/advanced/windows-forms-and-unmanaged-applications.md)  
 [COM Interop](../../../visual-basic/programming-guide/com-interop/index.md)  
 [COM Interoperability in .NET Framework Applications](~/docs/visual-basic/programming-guide/com-interop/com-interoperability-in-net-framework-applications.md)  
 [COM Interoperability Samples](http://msdn.microsoft.com/library/09c38567-6380-4d70-848a-e896a4ca05f4)  
 [Aximp.exe (Windows Forms ActiveX Control Importer)](../../../../docs/framework/tools/aximp-exe-windows-forms-activex-control-importer.md)  
 [Exposing .NET Framework Components to COM](../../../../docs/framework/interop/exposing-dotnet-components-to-com.md)  
 [Packaging an Assembly for COM](../../../../docs/framework/interop/packaging-an-assembly-for-com.md)  
 [Registering Assemblies with COM](../../../../docs/framework/interop/registering-assemblies-with-com.md)  
 [How to: Support COM Interop by Displaying a Windows Form with the ShowDialog Method](../../../../docs/framework/winforms/advanced/com-interop-by-displaying-a-windows-form-shadow.md)  
 [How to: Support COM Interop by Displaying Each Windows Form on Its Own Thread](../../../../docs/framework/winforms/advanced/how-to-support-com-interop-by-displaying-each-windows-form-on-its-own-thread.md)
