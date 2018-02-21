---
title: "How to: Display Dialog Boxes for Windows Forms"
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
  - "cpp"
helpviewer_keywords: 
  - "Windows Forms, displaying"
  - "Windows Forms dialog boxes [Windows Forms], displaying"
  - "Windows Forms, calling one form from another"
  - "dialog boxes [Windows Forms], displaying for Windows Forms"
ms.assetid: aaac1b38-c651-495a-8d3d-5a9bfb32fee3
caps.latest.revision: 10
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Display Dialog Boxes for Windows Forms
You display a dialog box in the same way you display any other form in an application. The startup form loads automatically when the application is run. To make a second form or dialog box appear in the application, write code to load and display it. Similarly, to make the form or dialog box disappear, write code to unload or hide it.  
  
### To display a dialog box  
  
1.  Navigate to the event handler with which you want to open the dialog box. This can happen when a menu command is selected, when a button is clicked, or when any other event occurs.  
  
2.  In the event handler, add code to open the dialog box. In this example, a button-click event is used to show the dialog box:  
  
    ```vb  
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click  
       Dim dlg1 as new Form()  
       dlg1.ShowDialog()  
    End Sub  
    ```  
  
    ```csharp  
    private void button1_Click(object sender, System.EventArgs e)   
    {  
       Form dlg1 = new Form();  
       dlg1.ShowDialog();  
    }  
    ```  
  
    ```cpp  
    private:   
      void button1_Click(System::Object ^ sender,  
        System::EventArgs ^ e)  
      {  
        Form ^ dlg1 = gcnew Form();  
        dlg1->ShowDialog();  
      }  
    ```
