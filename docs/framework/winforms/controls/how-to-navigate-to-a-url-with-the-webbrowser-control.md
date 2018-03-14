---
title: "How to: Navigate to a URL with the WebBrowser Control"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-winforms"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
f1_keywords: 
  - "WebBrowser.Navigate"
helpviewer_keywords: 
  - "WebBrowser control [Windows Forms], examples"
  - "URLs [Windows Forms], navigating to"
  - "WebBrowser control [Windows Forms], navigating to URLs"
  - "examples [Windows Forms], WebBrowser control"
ms.assetid: b3ec38cb-f509-4d0b-bd79-9f3611259c62
caps.latest.revision: 13
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Navigate to a URL with the WebBrowser Control
The following code example demonstrates how to navigate the <xref:System.Windows.Forms.WebBrowser> control to a specific URL.  
  
 To determine when the new document is fully loaded, handle the <xref:System.Windows.Forms.WebBrowser.DocumentCompleted> event. For a demonstration of this event, see [How to: Print with a WebBrowser Control](../../../../docs/framework/winforms/controls/how-to-print-with-a-webbrowser-control.md).  
  
## Example  
  
```vb  
Me.webBrowser1.Navigate("http://www.microsoft.com")  
```  
  
```csharp  
this.webBrowser1.Navigate("http://www.microsoft.com");  
```  
  
## Compiling the Code  
 This example requires:  
  
-   A <xref:System.Windows.Forms.WebBrowser> control named `webBrowser1`.  
  
-   References to the `System` and `System.Windows.Forms` assemblies.  
  
## See Also  
 <xref:System.Windows.Forms.WebBrowser>  
 <xref:System.Windows.Forms.WebBrowser.DocumentCompleted?displayProperty=nameWithType>  
 <xref:System.Windows.Forms.WebBrowser.Navigating?displayProperty=nameWithType>  
 <xref:System.Windows.Forms.WebBrowser.Navigated?displayProperty=nameWithType>  
 [WebBrowser Control](../../../../docs/framework/winforms/controls/webbrowser-control-windows-forms.md)  
 [How to: Print with a WebBrowser Control](../../../../docs/framework/winforms/controls/how-to-print-with-a-webbrowser-control.md)
