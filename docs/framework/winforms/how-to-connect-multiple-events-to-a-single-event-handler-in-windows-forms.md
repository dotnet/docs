---
title: "How to: Connect Multiple Events to a Single Event Handler in Windows Forms"
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
helpviewer_keywords: 
  - "events [Windows Forms], connecting multiple to single event handler"
  - "event handlers [Windows Forms], connecting events to"
  - "menus [Windows Forms], event-handling methods for multiple menu items"
  - "Windows Forms controls, events"
  - "menu items [Windows Forms], multicasting event-handling methods"
ms.assetid: 5a20749a-41b5-4acc-8eb1-9e5040b0a2c4
caps.latest.revision: 10
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Connect Multiple Events to a Single Event Handler in Windows Forms
In your application design, you may find it necessary to use a single event handler for multiple events or have multiple events perform the same procedure. For example, it is often a powerful time-saver to have a menu command raise the same event as a button on your form does if they expose the same functionality. You can do this by using the Events view of the Properties window in C# or using the `Handles` keyword and the **Class Name** and **Method Name** drop-down boxes in the Visual Basic Code Editor.  
  
### To connect multiple events to a single event handler in Visual Basic  
  
1.  Right-click the form and choose **View Code**.  
  
2.  From the **Class Name** drop-down box, select one of the controls that you want to have the event handler handle.  
  
3.  From the **Method Name** drop-down box, select one of the events that you want the event handler to handle.  
  
4.  The Code Editor inserts the appropriate event handler and positions the insertion point within the method. In the example below, it is the <xref:System.Windows.Forms.Control.Click> event for the <xref:System.Windows.Forms.Button> control.  
  
    ```vb  
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click  
    ' Add event-handler code here.  
    End Sub  
    ```  
  
5.  Append the other events you would like handled to the `Handles` clause.  
  
    ```vb  
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click, Button2.Click  
    ' Add event-handler code here.  
    End Sub  
    ```  
  
6.  Add the appropriate code to the event handler.  
  
### To connect multiple events to a single event handler in C#  
  
1.  Select the control to which you want to connect an event handler.  
  
2.  In the Properties window, click the **Events** button (![Events Button](../../../docs/framework/winforms/media/vxeventsbutton-propertieswindow.png "vxEventsButton_PropertiesWindow")).  
  
3.  Click the name of the event that you want to handle.  
  
4.  In the value section next to the event name, click the drop-down button to display a list of existing event handlers that match the method signature of the event you want to handle.  
  
5.  Select the appropriate event handler from the list.  
  
     Code will be added to the form to bind the event to the existing event handler.  
  
## See Also  
 [Creating Event Handlers in Windows Forms](../../../docs/framework/winforms/creating-event-handlers-in-windows-forms.md)  
 [Event Handlers Overview](../../../docs/framework/winforms/event-handlers-overview-windows-forms.md)
