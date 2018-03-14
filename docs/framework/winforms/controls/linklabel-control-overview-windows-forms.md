---
title: "LinkLabel Control Overview (Windows Forms)"
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
  - "LinkLabel"
helpviewer_keywords: 
  - "links [Windows Forms], LinkLabel control"
  - "Label control [Windows Forms], about Label control"
  - "LinkLabel control [Windows Forms], about LinkLabel control"
ms.assetid: 9e248549-10ca-43a3-bb5e-60f583d369f1
caps.latest.revision: 9
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# LinkLabel Control Overview (Windows Forms)
The Windows Forms <xref:System.Windows.Forms.LinkLabel> control allows you to add Web-style links to Windows Forms applications. You can use the <xref:System.Windows.Forms.LinkLabel> control for everything that you can use the <xref:System.Windows.Forms.Label> control for; you also can set part of the text as a link to a file, folder, or Web page.  
  
## What You Can Do with the LinkLabel Control  
 In addition to all the properties, methods, and events of the <xref:System.Windows.Forms.Label> control, the <xref:System.Windows.Forms.LinkLabel> control has properties for hyperlinks and link colors. The <xref:System.Windows.Forms.LinkLabel.LinkArea%2A> property sets the area of the text that activates the link. The <xref:System.Windows.Forms.LinkLabel.LinkColor%2A>, <xref:System.Windows.Forms.LinkLabel.VisitedLinkColor%2A>, and <xref:System.Windows.Forms.LinkLabel.ActiveLinkColor%2A> properties set the colors of the link. The <xref:System.Windows.Forms.LinkLabel.LinkClicked> event determines what happens when the link text is selected.  
  
 The simplest use of the <xref:System.Windows.Forms.LinkLabel> control is to display a single link using the <xref:System.Windows.Forms.LinkLabel.LinkArea%2A> property, but you can also display multiple hyperlinks using the <xref:System.Windows.Forms.LinkLabel.Links%2A> property. The <xref:System.Windows.Forms.LinkLabel.Links%2A> property enables you to access a collection of links. You can also specify data in the <xref:System.Windows.Forms.LinkLabel.Link.LinkData%2A> property of each individual <xref:System.Windows.Forms.LinkLabel.Link> object. The value of the <xref:System.Windows.Forms.LinkLabel.Link.LinkData%2A> property can be used to store the location of a file to display or the address of a Web site.  
  
## See Also  
 <xref:System.Windows.Forms.LinkLabel>  
 [Label Control Overview](../../../../docs/framework/winforms/controls/label-control-overview-windows-forms.md)  
 [How to: Link to an Object or Web Page with the Windows Forms LinkLabel Control](../../../../docs/framework/winforms/controls/link-to-an-object-or-web-page-with-wf-linklabel-control.md)  
 [How to: Change the Appearance of the Windows Forms LinkLabel Control](../../../../docs/framework/winforms/controls/how-to-change-the-appearance-of-the-windows-forms-linklabel-control.md)
