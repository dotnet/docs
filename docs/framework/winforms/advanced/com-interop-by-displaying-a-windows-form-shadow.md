---
title: "How to: Support COM Interop by Displaying a Windows Form with the ShowDialog Method"
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
  - "COM interop [Windows Forms], calling methods"
  - "ActiveX controls [Windows Forms], COM interop"
  - "Windows Forms, interop"
ms.assetid: 87aac8ad-3c04-43b3-9b0c-d0b00df9ee74
caps.latest.revision: 6
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Support COM Interop by Displaying a Windows Form with the ShowDialog Method
You can resolve Component Object Model (COM) interoperability problems by displaying your Windows Form on a [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)] message loop, which is created by using the <xref:System.Windows.Forms.Application.Run%2A?displayProperty=nameWithType> method.  
  
 To make a form work correctly from a COM client application, you must run it on a Windows Forms message loop. To do this, use one of the following approaches:  
  
-   Use the <xref:System.Windows.Forms.Form.ShowDialog%2A?displayProperty=nameWithType> method to display the Windows Form;  
  
-   Display each Windows Form on a separate thread. For more information, see [How to: Support COM Interop by Displaying Each Windows Form on Its Own Thread](../../../../docs/framework/winforms/advanced/how-to-support-com-interop-by-displaying-each-windows-form-on-its-own-thread.md).  
  
## Procedure  
 Using the <xref:System.Windows.Forms.Form.ShowDialog%2A?displayProperty=nameWithType> method can be the easiest way to display a form on a [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)] message loop because, of all the approaches, it requires the least code to implement.  
  
 The <xref:System.Windows.Forms.Form.ShowDialog%2A?displayProperty=nameWithType> method suspends the unmanaged application's message loop and displays the form as a dialog box. Because the host application's message loop has been suspended, the <xref:System.Windows.Forms.Form.ShowDialog%2A?displayProperty=nameWithType> method creates a new [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)] message loop to process the form's messages.  
  
 The disadvantage of using the <xref:System.Windows.Forms.Form.ShowDialog%2A?displayProperty=nameWithType> method is that the form will be opened as a modal dialog box. This behavior blocks any user interface (UI) in the calling application while the Windows Form is open. When the user exits the form, the [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)] message loop closes and the earlier application's message loop starts running again.  
  
 You can create a class library in Windows Forms which has a method to show the form, and then build the class library for COM interop. You can use this DLL file from Visual Basic 6.0 or Microsoft Foundation Classes (MFC), and from either of these environments you can call the <xref:System.Windows.Forms.Form.ShowDialog%2A?displayProperty=nameWithType> method to display the form.  
  
#### To support COM interop by displaying a windows form with the ShowDialog method  
  
-   Replace all calls to the <xref:System.Windows.Forms.Form.Show%2A?displayProperty=nameWithType> method with calls to the <xref:System.Windows.Forms.Form.ShowDialog%2A?displayProperty=nameWithType> method in your [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)] component.  
  
## See Also  
 [Exposing .NET Framework Components to COM](../../../../docs/framework/interop/exposing-dotnet-components-to-com.md)  
 [How to: Support COM Interop by Displaying Each Windows Form on Its Own Thread](../../../../docs/framework/winforms/advanced/how-to-support-com-interop-by-displaying-each-windows-form-on-its-own-thread.md)  
 [Windows Forms and Unmanaged Applications](../../../../docs/framework/winforms/advanced/windows-forms-and-unmanaged-applications.md)
