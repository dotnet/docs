---
title: "TextBox Control Overview (Windows Forms)"
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
f1_keywords: 
  - "TextBox"
helpviewer_keywords: 
  - "TextBox control [Windows Forms], about TextBox controls"
  - "text boxes [Windows Forms], adding"
ms.assetid: d1a9c7f5-fa53-480a-a75c-158f8649ea2f
caps.latest.revision: 11
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# TextBox Control Overview (Windows Forms)
Windows Forms text boxes are used to get input from the user or to display text. The <xref:System.Windows.Forms.TextBox> control is generally used for editable text, although it can also be made read-only. Text boxes can display multiple lines, wrap text to the size of the control, and add basic formatting. The <xref:System.Windows.Forms.TextBox> control provides a single format style for text displayed or entered into the control. To display multiple types of formatted text, use the <xref:System.Windows.Forms.RichTextBox> control. For more information, see [RichTextBox Control Overview](../../../../docs/framework/winforms/controls/richtextbox-control-overview-windows-forms.md).  
  
## Working with the TextBox Control  
 The text displayed by the control is contained in the <xref:System.Windows.Forms.TextBox.Text%2A> property. By default, you can enter up to 2048 characters in a text box. If you set the <xref:System.Windows.Forms.TextBox.Multiline%2A> property to `true`, you can enter up to 32 KB of text. The <xref:System.Windows.Forms.TextBox.Text%2A> property can be set at design time with the Properties Window, at run time in code, or by user input at run time. The current contents of a text box can be retrieved at run time by reading the <xref:System.Windows.Forms.TextBox.Text%2A> property.  
  
 The following code example sets text in the control at run time. The `InitializeMyControl` procedure will not execute automatically; it must be called.  
  
```vb  
Private Sub InitializeMyControl()  
   ' Put some text into the control first.  
   TextBox1.Text = "This is a TextBox control."  
End Sub  
```  
  
```csharp  
private void InitializeMyControl() {  
   // Put some text into the control first.  
   textBox1.Text = "This is a TextBox control.";  
}  
```  
  
```cpp  
private:  
   void InitializeMyControl()  
   {  
      // Put some text into the control first.  
      textBox1->Text = "This is a TextBox control.";  
   }  
```  
  
## See Also  
 <xref:System.Windows.Forms.TextBox>  
 [How to: Control the Insertion Point in a Windows Forms TextBox Control](../../../../docs/framework/winforms/controls/how-to-control-the-insertion-point-in-a-windows-forms-textbox-control.md)  
 [How to: Create a Password Text Box with the Windows Forms TextBox Control](../../../../docs/framework/winforms/controls/how-to-create-a-password-text-box-with-the-windows-forms-textbox-control.md)  
 [How to: Create a Read-Only Text Box](../../../../docs/framework/winforms/controls/how-to-create-a-read-only-text-box-windows-forms.md)  
 [How to: Put Quotation Marks in a String](../../../../docs/framework/winforms/controls/how-to-put-quotation-marks-in-a-string-windows-forms.md)  
 [How to: Select Text in the Windows Forms TextBox Control](../../../../docs/framework/winforms/controls/how-to-select-text-in-the-windows-forms-textbox-control.md)  
 [How to: View Multiple Lines in the Windows Forms TextBox Control](../../../../docs/framework/winforms/controls/how-to-view-multiple-lines-in-the-windows-forms-textbox-control.md)  
 [TextBox Control](../../../../docs/framework/winforms/controls/textbox-control-windows-forms.md)
