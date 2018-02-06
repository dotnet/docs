---
title: "How to: Create a Password Text Box with the Windows Forms TextBox Control"
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
  - "TextBox control [Windows Forms], entering passwords"
  - "password boxes [Windows Forms], creating"
  - "PasswordChar property in text boxes"
  - "passwords [Windows Forms], input mask"
  - "passwords [Windows Forms], password text box"
ms.assetid: d105d6b9-3d50-44cd-80d8-2c0e2f486727
caps.latest.revision: 13
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Create a Password Text Box with the Windows Forms TextBox Control
A password box is a Windows Forms text box that displays placeholder characters while a user types a string.  
  
### To create a password text box  
  
1.  Set the <xref:System.Windows.Forms.TextBox.PasswordChar%2A> property of the <xref:System.Windows.Forms.TextBox> control to a specific character.  
  
     The <xref:System.Windows.Forms.TextBox.PasswordChar%2A> property specifies the character displayed in the text box. For example, if you want asterisks displayed in the password box, specify * for the <xref:System.Windows.Forms.TextBox.PasswordChar%2A> property in the Properties window. Then, regardless of what character a user types in the text box, an asterisk is displayed.  
  
2.  (Optional) Set the <xref:System.Windows.Forms.TextBoxBase.MaxLength%2A> property. The property determines how many characters can be typed in the text box. If the maximum length is exceeded, the system emits a beep and the text box does not accept any more characters. Note that you may not wish to do this as the maximum length of a password may be of use to hackers who are trying to guess the password.  
  
     The following code example shows how to initialize a text box that will accept a string up to 14 characters long and display asterisks in place of the string. The `InitializeMyControl` procedure will not execute automatically; it must be called.  
  
    > [!IMPORTANT]
    >  Using the <xref:System.Windows.Forms.TextBox.PasswordChar%2A> property on a text box can help ensure that other people will not be able to determine a user's password if they observe the user entering it. This security measure does not cover any sort of storage or transmission of the password that can occur due to your application logic. Because the text entered is not encrypted in any way, you should treat it as you would any other confidential data. Even though it does not appear as such, the password is still being treated as a plain-text string (unless you have implemented some additional security measure).  
  
    ```vb  
    Private Sub InitializeMyControl()  
       ' Set to no text.  
       TextBox1.Text = ""  
       ' The password character is an asterisk.  
       TextBox1.PasswordChar = "*"  
       ' The control will allow no more than 14 characters.  
       TextBox1.MaxLength = 14  
    End Sub  
    ```  
  
    ```csharp  
    private void InitializeMyControl()  
    {  
       // Set to no text.  
       textBox1.Text = "";  
       // The password character is an asterisk.  
       textBox1.PasswordChar = '*';  
       // The control will allow no more than 14 characters.  
       textBox1.MaxLength = 14;  
    }  
    ```  
  
    ```cpp  
    private:  
       void InitializeMyControl()  
       {  
          // Set to no text.  
          textBox1->Text = "";  
          // The password character is an asterisk.  
          textBox1->PasswordChar = '*';  
          // The control will allow no more than 14 characters.  
          textBox1->MaxLength = 14;  
       }  
    ```  
  
## See Also  
 <xref:System.Windows.Forms.TextBox>  
 [TextBox Control Overview](../../../../docs/framework/winforms/controls/textbox-control-overview-windows-forms.md)  
 [How to: Control the Insertion Point in a Windows Forms TextBox Control](../../../../docs/framework/winforms/controls/how-to-control-the-insertion-point-in-a-windows-forms-textbox-control.md)  
 [How to: Create a Read-Only Text Box](../../../../docs/framework/winforms/controls/how-to-create-a-read-only-text-box-windows-forms.md)  
 [How to: Put Quotation Marks in a String](../../../../docs/framework/winforms/controls/how-to-put-quotation-marks-in-a-string-windows-forms.md)  
 [How to: Select Text in the Windows Forms TextBox Control](../../../../docs/framework/winforms/controls/how-to-select-text-in-the-windows-forms-textbox-control.md)  
 [How to: View Multiple Lines in the Windows Forms TextBox Control](../../../../docs/framework/winforms/controls/how-to-view-multiple-lines-in-the-windows-forms-textbox-control.md)  
 [TextBox Control](../../../../docs/framework/winforms/controls/textbox-control-windows-forms.md)
