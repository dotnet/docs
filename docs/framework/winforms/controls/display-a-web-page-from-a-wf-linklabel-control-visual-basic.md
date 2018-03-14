---
title: "How to: Display a Web Page from a Windows Forms LinkLabel Control (Visual Basic)"
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
  - "vb"
f1_keywords: 
  - "LinkLabel1_LinkClicked"
helpviewer_keywords: 
  - "examples [Windows Forms], LinkLabel control"
  - "Web pages [Windows Forms], displaying"
  - "linking [Windows Forms], to Web pages from forms"
  - "Windows Forms, linking to Web pages"
  - "LinkLabel control [Windows Forms], examples"
ms.assetid: 477a7398-5971-4de3-b24c-f49f32bdb28a
caps.latest.revision: 7
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Display a Web Page from a Windows Forms LinkLabel Control (Visual Basic)
This example displays a Web page in the default browser when a user clicks a Windows Forms <xref:System.Windows.Forms.LinkLabel> control.  
  
## Example  
  
```vb  
Private Sub Form1_Load(ByVal sender As System.Object, ByVal e _  
As System.EventArgs) Handles MyBase.Load  
    LinkLabel1.Text = "Click here to get more info."  
    LinkLabel1.Links.Add(6, 4, "www.microsoft.com")  
End Sub  
Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal _  
e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles _  
LinkLabel1.LinkClicked  
    System.Diagnostics.Process.Start(e.Link.LinkData.ToString())  
End Sub  
```  
  
## Compiling the Code  
 This example requires:  
  
-   A Windows Form named `Form1`.  
  
-   A <xref:System.Windows.Forms.LinkLabel> control named `LinkLabel1`.  
  
-   An active Internet connection.  
  
## .NET Framework Security  
 The call to the <xref:System.Diagnostics.Process.Start%2A> method requires full trust. For more information, see <xref:System.Security.SecurityException>.  
  
## See Also  
 <xref:System.Windows.Forms.LinkLabel>  
 [LinkLabel Control](../../../../docs/framework/winforms/controls/linklabel-control-windows-forms.md)
