---
title: "How to: Set the Text Displayed by a Windows Forms Control"
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
  - "Windows Forms, captions"
  - "Button control [Windows Forms], button text"
  - "StdFont object and CommandButton caption"
  - "captions [Windows Forms], Windows Forms controls"
  - "Text property [Windows Forms], Windows Forms control"
  - "Button control [Windows Forms], text display"
  - "labels [Windows Forms], adding to CommandButton control"
  - "buttons [Windows Forms], text"
  - "captions [Windows Forms], setting"
  - "text"
  - "examples [Windows Forms], controls"
  - "text [Windows Forms], Windows Forms controls"
  - "controls [Windows Forms], captions"
  - "forms [Windows Forms], captions"
ms.assetid: 36b95bff-8780-479d-b86a-f1a0673653aa
caps.latest.revision: 18
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Set the Text Displayed by a Windows Forms Control
Windows Forms controls usually display some text that is related to the primary function of the control. For example, a <xref:System.Windows.Forms.Button> control usually displays a caption indicating what action will be performed when the button is clicked. For all controls, you can set or return the text by using the <xref:System.Windows.Forms.Control.Text%2A> property. You can change the font by using the <xref:System.Windows.Forms.Control.Font%2A> property. You can also set the text using the designer.  Also see [How to: Create Access Keys for Windows Forms Controls Using the Designer](http://msdn.microsoft.com/library/ms233673\(v=vs.110\)), [How to: Set the Text Displayed by a Windows Forms Control Using the Designer](http://msdn.microsoft.com/library/ms233665\(v=vs.110\)), [How to: Set the Image Displayed by a Windows Forms Control Using the Designer](http://msdn.microsoft.com/library/ms233656\(v=vs.110\)).  
  
### To set the text displayed by a control programmatically  
  
1.  Set the <xref:System.Windows.Forms.Control.Text%2A> property to a string.  
  
     To create an underlined access key, includes an ampersand (&) before the letter that will be the access key.  
  
2.  Set the <xref:System.Windows.Forms.Control.Font%2A> property to an object of type <xref:System.Drawing.Font>.  
  
    ```vb  
    Button1.Text = "Click here to save changes"  
    Button1.Font = New Font("Arial", 10, FontStyle.Bold, GraphicsUnit.Point)  
    ```  
  
    ```csharp  
    button1.Text = "Click here to save changes";  
    button1.Font = new Font("Arial", 10, FontStyle.Bold,  
       GraphicsUnit.Point);  
    ```  
  
    ```cpp  
    button1->Text = "Click here to save changes";  
    button1->Font = new System::Drawing::Font("Arial",  
       10, FontStyle::Bold, GraphicsUnit::Point);  
    ```  
  
    > [!NOTE]
    >  You can use an escape character to display a special character in user-interface elements that would normally interpret them differently, such as menu items. For example, the following line of code sets the menu item's text to read "& Now For Something Completely Different":  
  
    ```vb  
    MPMenuItem.Text = "&& Now For Something Completely Different"  
    ```  
  
    ```csharp  
    mpMenuItem.Text = "&& Now For Something Completely Different";  
    ```  
  
    ```cpp  
    mpMenuItem->Text = "&& Now For Something Completely Different";  
    ```  
  
## See Also  
 <xref:System.Windows.Forms.Control.Text%2A?displayProperty=nameWithType>  
 [How to: Create Access Keys for Windows Forms Controls](../../../../docs/framework/winforms/controls/how-to-create-access-keys-for-windows-forms-controls.md)  
 [How to: Respond to Windows Forms Button Clicks](../../../../docs/framework/winforms/controls/how-to-respond-to-windows-forms-button-clicks.md)
