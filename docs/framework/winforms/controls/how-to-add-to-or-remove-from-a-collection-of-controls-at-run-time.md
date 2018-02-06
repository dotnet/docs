---
title: "How to: Add to or Remove from a Collection of Controls at Run Time"
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
  - "run time [Windows Forms], removing controls"
  - "controls [Windows Forms], adding using collections"
  - "controls collections"
  - "collections [Windows Forms], adding items"
  - "run time [Windows Forms], adding controls"
  - "controls [Windows Forms], removing using collections"
ms.assetid: 771bf895-3d5f-469b-a324-3528f343657e
caps.latest.revision: 10
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Add to or Remove from a Collection of Controls at Run Time
Common tasks in application development are adding controls to and removing controls from any container control on your forms (such as the <xref:System.Windows.Forms.Panel> or <xref:System.Windows.Forms.GroupBox> control, or even the form itself). At design time, controls can be dragged directly onto a panel or group box. At run time, these controls maintain a `Controls` collection, which keeps track of what controls are placed on them.  
  
> [!NOTE]
>  The following code example applies to any control that maintains a collection of controls within it.  
  
### To add a control to a collection programmatically  
  
1.  Create an instance of the control to be added.  
  
2.  Set properties of the new control.  
  
3.  Add the control to the `Controls` collection of the parent control.  
  
     The following code example shows how to create an instance of the <xref:System.Windows.Forms.Button> control. It requires a form with a <xref:System.Windows.Forms.Panel> control and that the event-handling method for the button being created, `NewPanelButton_Click`, already exists.  
  
    ```vb  
    Public NewPanelButton As New Button()  
  
    Public Sub AddNewControl()  
       ' The Add method will accept as a parameter any object that derives  
       ' from the Control class. In this case, it is a Button control.  
       Panel1.Controls.Add(NewPanelButton)  
       ' The event handler indicated for the Click event in the code   
       ' below is used as an example. Substite the appropriate event  
       ' handler for your application.  
       AddHandler NewPanelButton.Click, AddressOf NewPanelButton_Click  
    End Sub  
    ```  
  
    ```csharp  
    public Button newPanelButton = new Button();  
  
    public void addNewControl()  
    {   
       // The Add method will accept as a parameter any object that derives  
       // from the Control class. In this case, it is a Button control.  
       panel1.Controls.Add(newPanelButton);  
       // The event handler indicated for the Click event in the code   
       // below is used as an example. Substitute the appropriate event  
       // handler for your application.  
       this.newPanelButton.Click += new System.EventHandler(this. NewPanelButton_Click);  
    }  
    ```  
  
### To remove controls from a collection programmatically  
  
1.  Remove the event handler from the event. In [!INCLUDE[vbprvb](../../../../includes/vbprvb-md.md)], use the [RemoveHandler Statement](~/docs/visual-basic/language-reference/statements/removehandler-statement.md) keyword; in [!INCLUDE[csprcs](../../../../includes/csprcs-md.md)], use the [-= Operator (C# Reference)](~/docs/csharp/language-reference/operators/subtraction-assignment-operator.md).  
  
2.  Use the `Remove` method to delete the desired control from the panel's `Controls` collection.  
  
3.  Call the <xref:System.Windows.Forms.Control.Dispose%2A> method to release all the resources used by the control.  
  
    ```vb  
    Public Sub RemoveControl()  
    ' NOTE: The code below uses the instance of   
    ' the button (NewPanelButton) from the previous example.  
       If Panel1.Controls.Contains(NewPanelButton) Then  
          RemoveHandler NewPanelButton.Click, AddressOf _   
             NewPanelButton_Click  
          Panel1.Controls.Remove(NewPanelButton)  
          NewPanelButton.Dispose()  
       End If  
    End Sub  
    ```  
  
    ```csharp  
    private void removeControl(object sender, System.EventArgs e)  
    {  
    // NOTE: The code below uses the instance of   
    // the button (newPanelButton) from the previous example.  
       if(panel1.Controls.Contains(newPanelButton))  
       {  
          this.newPanelButton.Click -= new System.EventHandler(this.   
             NewPanelButton_Click);  
          panel1.Controls.Remove(newPanelButton);  
          newPanelButton.Dispose();  
       }  
    }  
    ```  
  
## See Also  
 <xref:System.Windows.Forms.Panel>  
 [Panel Control](../../../../docs/framework/winforms/controls/panel-control-windows-forms.md)
