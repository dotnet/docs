---
title: "How to: Access the Managed HTML Document Object Model"
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
helpviewer_keywords: 
  - "HTML DOM [Windows Forms], accessing"
  - "managed HTML DOM [Windows Forms], accessing"
ms.assetid: 40fa5cd5-1ed8-42f6-a93f-9ac01608bbeb
caps.latest.revision: 12
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Access the Managed HTML Document Object Model
You can access the managed HTML Document Object Model (DOM) from two types of applications:  
  
-   A Windows Forms application (.exe) that hosted the managed <xref:System.Windows.Forms.WebBrowser> control. These two technologies complement one another, with the <xref:System.Windows.Forms.WebBrowser> control displaying the page to the user and the HTML DOM representing the document's logical structure.  
  
-   A Windows Forms <xref:System.Windows.Forms.UserControl> hosted within Internet Explorer. You can access the HTML DOM representing the page on which your <xref:System.Windows.Forms.UserControl> is hosted in order to change the document's structure or open modal dialog boxes, among many other possibilities.  
  
### To access DOM from a Windows Forms application  
  
1.  Host a <xref:System.Windows.Forms.WebBrowser> control within your Windows Forms application and monitor for the <xref:System.Windows.Forms.WebBrowser.DocumentCompleted> event. For details on hosting controls and monitoring for events, see [Events](../../../../docs/standard/events/index.md).  
  
2.  Retrieve the <xref:System.Windows.Forms.HtmlDocument> for the current page by accessing the <xref:System.Windows.Forms.WebBrowser.Document%2A> property of the <xref:System.Windows.Forms.WebBrowser> control.  

### To access DOM from a UserControl hosted in Internet Explorer  
  
1.  Create your own custom derived class of the <xref:System.Windows.Forms.UserControl> class. For more information, see [How to: Author Composite Controls](../../../../docs/framework/winforms/controls/how-to-author-composite-controls.md).  
  
2.  Place the following code inside of your Load event handler for your <xref:System.Windows.Forms.UserControl>:  
  
 [!code-csharp[AccessHTMLDOMControl#1](../../../../samples/snippets/csharp/VS_Snippets_Winforms/AccessHTMLDOMControl/cs/UserControl1.cs#1)]
 [!code-vb[AccessHTMLDOMControl#1](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/AccessHTMLDOMControl/vb/UserControl1.vb#1)]  
  
## Robust Programming  
  
1.  When using the DOM through the <xref:System.Windows.Forms.WebBrowser> control, you should always wait until the <xref:System.Windows.Forms.WebBrowser.DocumentCompleted> event occurs before attempting to access the <xref:System.Windows.Forms.WebBrowser.Document%2A> property of the <xref:System.Windows.Forms.WebBrowser> control. The <xref:System.Windows.Forms.WebBrowser.DocumentCompleted> event is raised after the entire document has loaded; if you use the DOM before then, you risk causing a run-time exception in your application.  
  
## .NET Framework Security  
  
1.  Your application or <xref:System.Windows.Forms.UserControl> will require full trust in order to access the managed HTML DOM. If you are deploying a Windows Forms application using [!INCLUDE[ndptecclick](../../../../includes/ndptecclick-md.md)], you can request full trust using either Permission Elevation or Trusted Application Deployment; see [Securing ClickOnce Applications](/visualstudio/deployment/securing-clickonce-applications) for details.  
  
## See Also  
 [Using the Managed HTML Document Object Model](../../../../docs/framework/winforms/controls/using-the-managed-html-document-object-model.md)
