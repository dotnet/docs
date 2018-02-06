---
title: "WebBrowser Security"
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
  - "WebBrowser control [Windows Forms], security"
  - "security [Windows Forms], WebBrowser control"
ms.assetid: 0968846e-48ee-485a-9797-65b5b9a622f8
caps.latest.revision: 13
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# WebBrowser Security
The <xref:System.Windows.Forms.WebBrowser> control is designed to work in full trust only. The HTML content displayed in the control can come from external Web servers and may contain unmanaged code in the form of scripts or Web controls. If you use the <xref:System.Windows.Forms.WebBrowser> control in this situation, the control is no less secure than Internet Explorer would be, but the managed <xref:System.Windows.Forms.WebBrowser> control does not prevent such unmanaged code from running.  
  
 For more information about security issues relating to the underlying ActiveX `WebBrowser` control, see [WebBrowser Control](http://go.microsoft.com/fwlink/?LinkId=198812).  
  
## See Also  
 <xref:System.Windows.Forms.WebBrowser>  
 [WebBrowser Control Overview](../../../../docs/framework/winforms/controls/webbrowser-control-overview.md)  
 [WebBrowser Control](http://go.microsoft.com/fwlink/?LinkId=198812)
