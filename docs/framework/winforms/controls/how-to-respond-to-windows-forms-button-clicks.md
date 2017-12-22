---
title: "How to: Respond to Windows Forms Button Clicks"
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
  - "buttons [Windows Forms], responding to Click events"
  - "events [Windows Forms], Click events"
  - "Click event [Windows Forms], Button control"
  - "MouseDown event"
  - "Button control [Windows Forms], click response"
  - "double-clicks"
  - "examples [Windows Forms], controls"
  - "Click event [Windows Forms], responding to"
ms.assetid: 7a4951bd-369c-4662-b246-28ad83eda484
caps.latest.revision: 14
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Respond to Windows Forms Button Clicks
The most basic use of a Windows Forms <xref:System.Windows.Forms.Button> control is to run some code when the button is clicked.  
  
 Clicking a <xref:System.Windows.Forms.Button> control also generates a number of other events, such as the <xref:System.Windows.Forms.Control.MouseEnter>, <xref:System.Windows.Forms.Control.MouseDown>, and <xref:System.Windows.Forms.Control.MouseUp> events. If you intend to attach event handlers for these related events, be sure that their actions do not conflict. For example, if clicking the button clears information that the user has typed in a text box, pausing the mouse pointer over the button should not display a tool tip with that now-nonexistent information.  
  
 If the user attempts to double-click the <xref:System.Windows.Forms.Button> control, each click will be processed separately; that is, the control does not support the double-click event.  
  
### To respond to a button click  
  
-   In the button's `Click` <xref:System.EventHandler> write the code to run. `Button1_Click` must be bound to the control. For more information, see [How to: Create Event Handlers at Run Time for Windows Forms](../../../../docs/framework/winforms/how-to-create-event-handlers-at-run-time-for-windows-forms.md).  
  
    ```vb  
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click  
       MessageBox.Show("Button1 was clicked")  
    End Sub  
    ```  
  
    ```csharp  
    private void button1_Click(object sender, System.EventArgs e)  
    {  
       MessageBox.Show("button1 was clicked");  
    }  
    ```  
  
    ```cpp  
    private:  
       void button1_Click(System::Object ^ sender,  
          System::EventArgs ^ e)  
       {  
          MessageBox::Show("button1 was clicked");  
       }  
    ```  
  
## See Also  
 [Button Control Overview](../../../../docs/framework/winforms/controls/button-control-overview-windows-forms.md)  
 [Ways to Select a Windows Forms Button Control](../../../../docs/framework/winforms/controls/ways-to-select-a-windows-forms-button-control.md)  
 [Button Control](../../../../docs/framework/winforms/controls/button-control-windows-forms.md)
