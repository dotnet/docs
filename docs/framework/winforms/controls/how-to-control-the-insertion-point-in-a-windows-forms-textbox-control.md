---
title: "How to: Control the Insertion Point in a Windows Forms TextBox Control"
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
  - "TextBox control [Windows Forms], insertion point"
  - "insertion points [Windows Forms], TextBox controls"
  - "text boxes [Windows Forms], controlling insertion point"
ms.assetid: 5bee7d34-5121-429e-ab1f-d8ff67bc74c1
caps.latest.revision: 19
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Control the Insertion Point in a Windows Forms TextBox Control
When a Windows Forms <xref:System.Windows.Forms.TextBox> control first receives the focus, the default insertion within the text box is to the left of any existing text. The user can move the insertion point with the keyboard or the mouse. If the text box loses and then regains the focus, the insertion point will be wherever the user last placed it.  
  
 In some cases, this behavior can be disconcerting to the user. In a word processing application, the user might expect new characters to appear after any existing text. In a data entry application, the user might expect new characters to replace any existing entry. The <xref:System.Windows.Forms.TextBoxBase.SelectionStart%2A> and <xref:System.Windows.Forms.TextBoxBase.SelectionLength%2A> properties enable you to modify the behavior to suit your purpose.  
  
### To control the insertion point in a TextBox control  
  
1.  Set the <xref:System.Windows.Forms.TextBoxBase.SelectionStart%2A> property to an appropriate value. Zero places the insertion point immediately to the left of the first character.  
  
2.  (Optional) Set the <xref:System.Windows.Forms.TextBoxBase.SelectionLength%2A> property to the length of the text you want to select.  
  
     The code below always returns the insertion point to 0. The `TextBox1_Enter` event handler must be bound to the control; for more information, see [Creating Event Handlers in Windows Forms](../../../../docs/framework/winforms/creating-event-handlers-in-windows-forms.md).  
  
    ```vb  
    Private Sub TextBox1_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.Enter  
       TextBox1.SelectionStart = 0  
       TextBox1.SelectionLength = 0  
    End Sub  
    ```  
  
    ```csharp  
    private void textBox1_Enter(Object sender, System.EventArgs e) {  
       textBox1.SelectionStart = 0;  
       textBox1.SelectionLength = 0;  
    }  
    ```  
  
    ```cpp  
    private:  
       void textBox1_Enter(System::Object ^  sender,  
          System::EventArgs ^  e)  
       {  
          textBox1->SelectionStart = 0;  
          textBox1->SelectionLength = 0;  
       }  
    ```  
  
## Making the Insertion Point Visible by Default  
 The <xref:System.Windows.Forms.TextBox> insertion point is visible by default in a new form only if the <xref:System.Windows.Forms.TextBox> control is first in the tab order. Otherwise, the insertion point appears only if you give the <xref:System.Windows.Forms.TextBox> the focus with either the keyboard or the mouse.  
  
#### To make the text box insertion point visible by default on a new form  
  
-   Set the <xref:System.Windows.Forms.TextBox> control's <xref:System.Windows.Forms.Control.TabIndex%2A> property to `0`.  
  
## See Also  
 <xref:System.Windows.Forms.TextBox>  
 [TextBox Control Overview](../../../../docs/framework/winforms/controls/textbox-control-overview-windows-forms.md)  
 [How to: Create a Password Text Box with the Windows Forms TextBox Control](../../../../docs/framework/winforms/controls/how-to-create-a-password-text-box-with-the-windows-forms-textbox-control.md)  
 [How to: Create a Read-Only Text Box](../../../../docs/framework/winforms/controls/how-to-create-a-read-only-text-box-windows-forms.md)  
 [How to: Put Quotation Marks in a String](../../../../docs/framework/winforms/controls/how-to-put-quotation-marks-in-a-string-windows-forms.md)  
 [How to: Select Text in the Windows Forms TextBox Control](../../../../docs/framework/winforms/controls/how-to-select-text-in-the-windows-forms-textbox-control.md)  
 [How to: View Multiple Lines in the Windows Forms TextBox Control](../../../../docs/framework/winforms/controls/how-to-view-multiple-lines-in-the-windows-forms-textbox-control.md)  
 [TextBox Control](../../../../docs/framework/winforms/controls/textbox-control-windows-forms.md)
