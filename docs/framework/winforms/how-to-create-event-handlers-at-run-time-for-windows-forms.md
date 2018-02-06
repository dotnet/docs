---
title: "How to: Create Event Handlers at Run Time for Windows Forms"
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
  - "Windows Forms, event handling"
  - "event handlers [Windows Forms], creating"
  - "run time [Windows Forms], creating event handlers at"
  - "examples [Windows Forms], event handling"
  - "Button control [Windows Forms], event handlers"
ms.assetid: 2e7c9e1a-61fe-444d-8113-3c5bacf1c8cb
caps.latest.revision: 15
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Create Event Handlers at Run Time for Windows Forms
In addition to creating events using the Windows Forms Designer, you can also create an event handler at run time. This action allows you to connect event handlers based on conditions in code at run time as opposed to having them connected when the program initially starts.  
  
### To create an event handler at run time  
  
1.  Open the form in the Code Editor that you want to add an event handler to.  
  
2.  Add a method to your form with the method signature for the event that you want to handle.  
  
     For example, if you were handling the <xref:System.Windows.Forms.Control.Click> event of a <xref:System.Windows.Forms.Button> control, you would create a method such as the following:  
  
    ```vb  
    Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs)  
       ' Add event handler code here.  
    End Sub  
    ```  
  
    ```csharp  
    private void button1_Click(object sender, System.EventArgs e)   
    {  
    // Add event handler code here.  
    }  
    ```  
  
    ```cpp  
    private:  
       void button1_Click(System::Object ^ sender,   
          System::EventArgs ^ e)  
       {  
          // Add event handler code here.  
       }  
    ```  
  
3.  Add code to the event handler as appropriate to your application.  
  
4.  Determine which form or control you want to create an event handler for.  
  
5.  In a method within your form's class, add code that specifies the event handler to handle the event. For example, the following code specifies the event handler `button1_Click` handles the <xref:System.Windows.Forms.Control.Click> event of a <xref:System.Windows.Forms.Button> control:  
  
    ```vb  
    AddHandler Button1.Click, AddressOf Button1_Click  
    ```  
  
    ```csharp  
    button1.Click += new EventHandler(button1_Click);  
    ```  
  
    ```cpp  
    button1->Click += gcnew System::EventHandler(this, &Form1::button1_Click);  
    ```  
  
     The <xref:System.ComponentModel.EventHandlerList.AddHandler%2A> method demonstrated in the Visual Basic code above establishes a click event handler for the button.  
  
## See Also  
 [Creating Event Handlers in Windows Forms](../../../docs/framework/winforms/creating-event-handlers-in-windows-forms.md)  
 [Event Handlers Overview](../../../docs/framework/winforms/event-handlers-overview-windows-forms.md)  
 [Troubleshooting Inherited Event Handlers in Visual Basic](~/docs/visual-basic/programming-guide/language-features/events/troubleshooting-inherited-event-handlers.md)
