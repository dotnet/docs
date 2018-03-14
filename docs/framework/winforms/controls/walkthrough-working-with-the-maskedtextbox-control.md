---
title: "Walkthrough: Working with the MaskedTextBox Control"
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
  - "input [Windows Forms], controlling to ensure validity"
  - "MaskedTextBox control [Windows Forms], walkthroughs"
  - "MaskedTextBox control [Windows Forms], validation"
  - "user input [Windows Forms], controlling"
  - "text [Windows Forms], controls for input"
ms.assetid: df60565e-5447-4110-92a6-be1f6ff5faa3
caps.latest.revision: 16
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Walkthrough: Working with the MaskedTextBox Control
Tasks illustrated in this walkthrough include:  
  
-   Initializing the <xref:System.Windows.Forms.MaskedTextBox> control  
  
-   Using the <xref:System.Windows.Forms.MaskedTextBox.MaskInputRejected> event handler to alert the user when a character does not conform to the mask  
  
-   Assigning a type to the <xref:System.Windows.Forms.MaskedTextBox.ValidatingType%2A> property and using the <xref:System.Windows.Forms.MaskedTextBox.TypeValidationCompleted> event handler to alert the user when the value they're attempting to commit is not valid for the type  
  
## Creating the Project and Adding a Control  
  
#### To add a MaskedTextBox control to your form  
  
1.  Open the form on which you want to place the <xref:System.Windows.Forms.MaskedTextBox> control.  
  
2.  Drag a <xref:System.Windows.Forms.MaskedTextBox> control from the **Toolbox** to your form.  
  
3.  Right-click the control and choose **Properties**. In the **Properties** window, select the **Mask** property and click the **...** (ellipsis) button next to the property name.  
  
4.  In the **Input Mask** dialog box, select the **Short Date** mask and click **OK**.  
  
5.  In the **Properties** window set the <xref:System.Windows.Forms.MaskedTextBox.BeepOnError%2A> property to `true`. This property causes a short beep to sound every time the user attempts to input a character that violates the mask definition.  
  
 For a summary of the characters that the Mask property supports, see the Remarks section of the <xref:System.Windows.Forms.MaskedTextBox.Mask%2A> property.  
  
## Alert the User to Input Errors  
  
#### Add a balloon tip for rejected mask input  
  
1.  Return to the **Toolbox** and add a <xref:System.Windows.Forms.ToolTip> to your form.  
  
2.  Create an event handler for the <xref:System.Windows.Forms.MaskedTextBox.MaskInputRejected> event that raises the <xref:System.Windows.Forms.ToolTip> when an input error occurs. The balloon tip remains visible for five seconds, or until the user clicks it.  
  
    ```csharp  
    public void Form1_Load(Object sender, EventArgs e)   
    {  
        ... // Other initialization code  
        maskedTextBox1.Mask = "00/00/0000";  
        maskedTextBox1.MaskInputRejected += new MaskInputRejectedEventHandler(maskedTextBox1_MaskInputRejected)  
    }  
  
    void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)  
    {  
        toolTip1.ToolTipTitle = "Invalid Input";  
        toolTip1.Show("We're sorry, but only digits (0-9) are allowed in dates.", maskedTextBox1, maskedTextBox1.Location, 5000);  
    }  
    ```  
  
    ```vb  
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load  
        Me.ToolTip1.IsBalloon = True  
        Me.MaskedTextBox1.Mask = "00/00/0000"  
    End Sub  
  
    Private Sub MaskedTextBox1_MaskInputRejected(sender as Object, e as MaskInputRejectedEventArgs) Handles MaskedTextBox1.MaskInputRejected  
        ToolTip1.ToolTipTitle = "Invalid Input"  
        ToolTip1.Show("We're sorry, but only digits (0-9) are allowed in dates.", MaskedTextBox1, 5000)  
    End Sub  
    ```  
  
## Alert the User to a Type that Is Not Valid  
  
#### Add a balloon tip for invalid data types  
  
1.  In your form's <xref:System.Windows.Forms.Form.Load> event handler, assign a <xref:System.Type> object representing the <xref:System.DateTime> type to the <xref:System.Windows.Forms.MaskedTextBox> control's <xref:System.Windows.Forms.MaskedTextBox.ValidatingType%2A> property:  
  
    ```csharp  
    private void Form1_Load(Object sender, EventArgs e)  
    {  
        // Other code  
        maskedTextBox1.ValidatingType = typeof(System.DateTime);  
        maskedTextBox1.TypeValidationCompleted += new TypeValidationEventHandler(maskedTextBox1_TypeValidationCompleted);  
    }  
    ```  
  
    ```vb  
    Private Sub Form1_Load(sender as Object, e as EventArgs)  
        // Other code  
        MaskedTextBox1.ValidatingType = GetType(System.DateTime)  
    End Sub  
    ```  
  
2.  Add an event handler for the <xref:System.Windows.Forms.MaskedTextBox.TypeValidationCompleted> event:  
  
    ```csharp  
    public void maskedTextBox1_TypeValidationCompleted(object sender, TypeValidationEventArgs e)  
    {  
        if (!e.IsValidInput)  
        {  
           toolTip1.ToolTipTitle = "Invalid Date Value";  
           toolTip1.Show("We're sorry, but the value you entered is not a valid date. Please change the value.", maskedTextBox1, 5000);  
           e.Cancel = true;  
        }  
    }  
    ```  
  
    ```vb  
    Public Sub MaskedTextBox1_TypeValidationCompleted(sender as Object, e as TypeValidationEventArgs)  
        If Not e.IsValidInput Then  
           ToolTip1.ToolTipTitle = "Invalid Date Value"  
           ToolTip1.Show("We're sorry, but the value you entered is not a valid date. Please change the value.", maskedTextBox1, 5000)  
           e.Cancel = True  
        End If  
    End Sub  
    ```  
  
## See Also  
 <xref:System.Windows.Forms.MaskedTextBox>  
 [MaskedTextBox Control](../../../../docs/framework/winforms/controls/maskedtextbox-control-windows-forms.md)
