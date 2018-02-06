---
title: "WebBrowser Control Overview"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-winforms"
ms.tgt_pltfrm: ""
ms.topic: "article"
f1_keywords: 
  - "WebBrowser"
helpviewer_keywords: 
  - "WebBrowser control [Windows Forms], about"
  - "Web pages [Windows Forms], displaying in applications"
ms.assetid: 6e3e1cc2-9c48-4136-9659-e99e4e60b7e9
caps.latest.revision: 15
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# WebBrowser Control Overview
The <xref:System.Windows.Forms.WebBrowser> control provides a managed wrapper for the WebBrowser ActiveX control. The managed wrapper lets you display Web pages in your Windows Forms client applications. You can use the <xref:System.Windows.Forms.WebBrowser> control to duplicate Internet Explorer Web browsing functionality in your application or you can disable default Internet Explorer functionality and use the control as a simple HTML document viewer. You can also use the control to add DHTML-based user interface elements to your form and hide the fact that they are hosted in the <xref:System.Windows.Forms.WebBrowser> control. This approach lets you seamlessly combine Web controls with Windows Forms controls in a single application.  
  
## Frequently Used Properties, Methods, and Events  
 The <xref:System.Windows.Forms.WebBrowser> control has several properties, methods, and events that you can use to implement controls found in Internet Explorer. For example, you can use the `Navigate` method to implement an address bar, and the `GoBack`, `GoForward`, `Stop`, and `Refresh` methods to implement navigation buttons on a toolbar. You can handle the `Navigated` event to update the address bar with the value of the `Url` property and the title bar with the value of the `DocumentTitle` property.  
  
 If you want to generate your own page content within your application, you can set the `DocumentText` property. If you are familiar with the HTML document object model (DOM), you can also manipulate the contents of the current Web page through the `Document` property. With this property, you can store and modify documents in memory instead of navigating among files.  
  
 The `Document` property also lets you call methods implemented in Web page scripting code from your client application code. To access your client application code from your scripting code, set the `ObjectForScripting` property. The object that you specify can be accessed by your script code as the `window.external` object.  
  
|Name|Description|  
|----------|-----------------|  
|<xref:System.Windows.Forms.WebBrowser.Document%2A> property|Gets an object that provides managed access to the HTML document object model (DOM) of the current Web page.|  
|<xref:System.Windows.Forms.WebBrowser.DocumentCompleted> event|Occurs when a Web page finishes loading.|  
|<xref:System.Windows.Forms.WebBrowser.DocumentText%2A> property|Gets or sets the HTML content of the current Web page.|  
|<xref:System.Windows.Forms.WebBrowser.DocumentTitle%2A> property|Gets the title of the current Web page.|  
|<xref:System.Windows.Forms.WebBrowser.GoBack%2A> method|Navigates to the previous page in history.|  
|<xref:System.Windows.Forms.WebBrowser.GoForward%2A> method|Navigates to the next page in history.|  
|<xref:System.Windows.Forms.WebBrowser.Navigate%2A> method|Navigates to the specified URL.|  
|<xref:System.Windows.Forms.WebBrowser.Navigating> event|Occurs before navigation begins, enabling the action to be canceled.|  
|<xref:System.Windows.Forms.WebBrowser.ObjectForScripting%2A> property|Gets or sets an object that Web page scripting code can use to communicate with your application.|  
|<xref:System.Windows.Forms.WebBrowser.Print%2A> method|Prints the current Web page.|  
|<xref:System.Windows.Forms.WebBrowser.Refresh%2A> method|Reloads the current Web page.|  
|<xref:System.Windows.Forms.WebBrowser.Stop%2A> method|Halts the current navigation and stops dynamic page elements such as sounds and animation.|  
|<xref:System.Windows.Forms.WebBrowser.Url%2A> property|Gets or sets the URL of the current Web page. Setting this property navigates the control to the new URL.|  
  
## See Also  
 <xref:System.Windows.Forms.WebBrowser>  
 <xref:System.Windows.Forms.WebBrowserDocumentCompletedEventArgs>  
 <xref:System.Windows.Forms.WebBrowserDocumentCompletedEventHandler>  
 <xref:System.Windows.Forms.WebBrowserEncryptionLevel>  
 <xref:System.Windows.Forms.WebBrowserNavigatedEventArgs>  
 <xref:System.Windows.Forms.WebBrowserNavigatedEventHandler>  
 <xref:System.Windows.Forms.WebBrowserNavigatingEventArgs>  
 <xref:System.Windows.Forms.WebBrowserNavigatingEventHandler>  
 <xref:System.Windows.Forms.WebBrowserProgressChangedEventArgs>  
 <xref:System.Windows.Forms.WebBrowserReadyState>  
 <xref:System.Windows.Forms.WebBrowserRefreshOption>  
 [How to: Navigate to a URL with the WebBrowser Control](../../../../docs/framework/winforms/controls/how-to-navigate-to-a-url-with-the-webbrowser-control.md)  
 [How to: Print with a WebBrowser Control](../../../../docs/framework/winforms/controls/how-to-print-with-a-webbrowser-control.md)  
 [How to: Add Web Browser Capabilities to a Windows Forms Application](../../../../docs/framework/winforms/controls/how-to-add-web-browser-capabilities-to-a-windows-forms-application.md)  
 [How to: Create an HTML Document Viewer in a Windows Forms Application](../../../../docs/framework/winforms/controls/how-to-create-an-html-document-viewer-in-a-windows-forms-application.md)  
 [How to: Implement Two-Way Communication Between DHTML Code and Client Application Code](../../../../docs/framework/winforms/controls/implement-two-way-com-between-dhtml-and-client.md)  
 [WebBrowser Security](../../../../docs/framework/winforms/controls/webbrowser-security.md)
