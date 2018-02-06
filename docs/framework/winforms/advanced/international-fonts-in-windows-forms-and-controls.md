---
title: "International Fonts in Windows Forms and Controls"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-winforms"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "fonts [Windows Forms], international"
  - "international applications [Windows Forms], character display"
  - "fonts [Windows Forms], globalization considerations"
  - "localization [Windows Forms], fonts"
  - "Windows Forms controls, labels"
  - "font fallback in Windows Forms"
  - "globalization [Windows Forms], character sets"
ms.assetid: 2c3066df-9bac-479a-82b2-79e484b346a3
caps.latest.revision: 6
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# International Fonts in Windows Forms and Controls
In International applications the recommended method of selecting fonts is to use font fallback wherever possible. Font fallback means that the system determines what script the character belongs to.  
  
## Using Font Fallback  
 To take advantage of this feature, do not set the <xref:System.Drawing.Font> property for your form or any other element. The application will automatically use the default system font, which differs from one localized language of the operating system to another. When the application runs, the system will automatically provide the correct font for the culture selected in the operating system.  
  
 There is an exception to the rule of not setting the font, which is for changing the font style. This might be important for an application in which the user clicks a button to make text in a text box appear in boldface. To do that, you would write a function to change the text box's font style to bold, based on whatever the form's font is. It is important to call this function in two places: in the button's <xref:System.Windows.Forms.Control.Click> event handler and in the <xref:System.Windows.Forms.Control.FontChanged> event handler. If the function is called only in the <xref:System.Windows.Forms.Control.Click> event handler and some other piece of code changes the font family of the entire form, the text box will not change with the rest of the form.  
  
```  
' Visual Basic  
Private Sub MakeBold()  
   ' Change the TextBox to a bold version of the form font  
   TextBox1.Font = New Font(Me.Font, FontStyle.Bold)  
End Sub  
  
Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click  
   ' Clicking this button makes the TextBox bold  
   MakeBold()  
End Sub  
  
Private Sub Form1_FontChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.FontChanged  
   ' If the TextBox is already bold and the form's font changes,  
   ' change the TextBox to a bold version of the new form font  
   If (TextBox1.Font.Style = FontStyle.Bold) Then  
      MakeBold()  
   End If  
End Sub  
  
// C#  
private void button1_Click(object sender, System.EventArgs e)  
{  
   // Clicking this button makes the TextBox bold  
   MakeBold();  
}  
  
private void MakeBold()   
{  
   // Change the TextBox to a bold version of the form's font  
   textBox1.Font = new Font(this.Font, FontStyle.Bold);  
}  
  
private void Form1_FontChanged(object sender, System.EventArgs e)  
{  
   // If the TextBox is already bold and the form's font changes,  
   // change the TextBox to a bold version of the new form font  
   if (textBox1.Font.Style == FontStyle.Bold)   
   {  
      MakeBold();  
   }  
}  
```  
  
 However, when you localize your application, the bold font may display poorly for certain languages. If this is a concern, you want the localizers to have the option of switching the font from bold to regular text. Since localizers are typically not developers and do not have access to source code, only to resource files, this option needs to be set in the resource files. To do this, you would set the <xref:System.Drawing.Font.Bold%2A> property to `true`. This results in the font setting being written out to the resource files, where localizers can edit it. You then write code after the `InitializeComponent` method to reset the font based on whatever the form's font is, but using the font style specified in the resource file.  
  
```  
' Visual Basic  
TextBox1.Font = New System.Drawing.Font(Me.Font, TextBox1.Font.Style)  
  
// C#  
textBox1.Font = new System.Drawing.Font(this.Font, textBox1.Font.Style);  
```  
  
## See Also  
 [Globalizing Windows Forms](../../../../docs/framework/winforms/advanced/globalizing-windows-forms.md)  
 [Using Fonts and Text](../../../../docs/framework/winforms/advanced/using-fonts-and-text.md)
