---
title: "Accessing Frames in the Managed HTML Document Object Model"
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
  - "HTML [Windows Forms], dOM"
  - "managed HTML DOM"
  - "HTML [Windows Forms], managed"
  - "HTML DOM [Windows Forms], managed"
  - "frames [Windows Forms], accessing"
  - "DOM [Windows Forms], accessing frames in managed HTML"
ms.assetid: cdeeaa22-0be4-4bbf-9a75-4ddc79199f8d
caps.latest.revision: 10
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Accessing Frames in the Managed HTML Document Object Model
Some HTML documents are composed out of *frames*, or windows that can hold their own distinct HTML documents. Using frames makes it easy to create HTML pages in which one or more pieces of the page remain static, such as a navigation bar, while other frames constantly change their content.  
  
 HTML authors can create frames in one of two ways:  
  
-   Using the `FRAMESET` and `FRAME` tags, which create fixed windows.  
  
 -or-  
  
-   Using the `IFRAME` tag, which creates a floating window that can be repositioned at run time.  
  
1.  Because frames contain HTML documents, they are represented in the Document Object Model (DOM) as both window elements and frame elements.  
  
2.  When you access a `FRAME` or `IFRAME` tag by using the Frames collection of <xref:System.Windows.Forms.HtmlWindow>, you are retrieving the window element corresponding to the frame. This represents all of the frame's dynamic properties, such as its current URL, document, and size.  
  
3.  When you access a `FRAME` or `IFRAME` tag by using the <xref:System.Windows.Forms.HtmlWindow.WindowFrameElement%2A> property of <xref:System.Windows.Forms.HtmlWindow>, the <xref:System.Windows.Forms.HtmlElement.Children%2A> collection, or methods such as <xref:System.Windows.Forms.HtmlElementCollection.GetElementsByName%2A> or <xref:System.Windows.Forms.HtmlDocument.GetElementById%2A>, you are retrieving the frame element. This represents the static properties of the frame, including the URL specified in the original HTML file.  
  
## Frames and Security  
 Access to frames is complicated by the fact that the managed HTML DOM implements a security measure known as *cross-frame scripting security*. If a document contains a `FRAMESET` with two or more `FRAME`s in different domains, these `FRAME`s cannot interact with one another. In other words, a `FRAME` that displays content from your Web site cannot access information in a `FRAME` that hosts a third-party site such as http://www.adatum.com/. This security is implemented at the level of the <xref:System.Windows.Forms.HtmlWindow> class. You can obtain general information about a `FRAME` hosting another Web site, such as its URL, but you will be unable to access its <xref:System.Windows.Forms.HtmlWindow.Document%2A> or change the size or location of its hosting `FRAME` or `IFRAME`.  
  
 This rule also applies to windows that you open using the <xref:System.Windows.Forms.HtmlWindow.Open%2A> and <xref:System.Windows.Forms.HtmlWindow.OpenNew%2A> methods. If the window you open is in a different domain from the page hosted in the <xref:System.Windows.Forms.WebBrowser> control, you will not be able to move that window or examine its contents. These restrictions are also enforced if you use the <xref:System.Windows.Forms.WebBrowser> control to display a Web site that is different from the Web site used to deploy your Windows Forms-based application. If you use [!INCLUDE[ndptecclick](../../../../includes/ndptecclick-md.md)] deployment technology to install your application from Web site A, and you use the <xref:System.Windows.Forms.WebBrowser> to display Web site B, you will not be able to access Web site B's data.  
  
 For more information about cross-site scripting, see[About Cross-Frame Scripting and Security](http://msdn.microsoft.com/library/ms533028.aspx).  
  
## See Also  
 [FRAME Element &#124; frame Object](http://msdn.microsoft.com/library/ms535250.aspx)  
 [Using the Managed HTML Document Object Model](../../../../docs/framework/winforms/controls/using-the-managed-html-document-object-model.md)
