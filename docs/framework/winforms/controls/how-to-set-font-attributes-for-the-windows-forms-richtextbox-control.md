---
title: "How to: Set Font Attributes for the Windows Forms RichTextBox Control"
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
  - ".rtf files [Windows Forms], formatting in RichTextBox control"
  - "fonts [Windows Forms], changing attributes in RichTextBox control"
  - "RTF files [Windows Forms], formatting in RichTextBox control"
  - "RichTextBox control [Windows Forms], setting font attributes"
  - "text [Windows Forms]"
  - "text boxes [Windows Forms], formatting text"
  - "formatting [Windows Forms]"
ms.assetid: 2bc23ddb-0529-4489-a1a2-ad253cb43f9a
caps.latest.revision: 13
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Set Font Attributes for the Windows Forms RichTextBox Control
The Windows Forms <xref:System.Windows.Forms.RichTextBox> control has numerous options for formatting the text it displays. You can make the selected characters bold, underlined, or italic, using the <xref:System.Windows.Forms.RichTextBox.SelectionFont%2A> property. You can also use this property to change the size and typeface of the selected characters. The <xref:System.Windows.Forms.RichTextBox.SelectionColor%2A> property enables you to change the selected characters' color.  
  
### To change the appearance of characters  
  
1.  Set the <xref:System.Windows.Forms.RichTextBox.SelectionFont%2A> property to an appropriate font.  
  
     To enable users to set the font family, size, and typeface in an application, you would typically use the <xref:System.Windows.Forms.FontDialog> component. For an overview, see [FontDialog Component Overview](../../../../docs/framework/winforms/controls/fontdialog-component-overview-windows-forms.md).  
  
2.  Set the <xref:System.Windows.Forms.RichTextBox.SelectionColor%2A> property to an appropriate color.  
  
     To enable users to set the color in an application, you would typically use the <xref:System.Windows.Forms.ColorDialog> component. For an overview, see [ColorDialog Component Overview](../../../../docs/framework/winforms/controls/colordialog-component-overview-windows-forms.md).  
  
    ```vb  
    RichTextBox1.SelectionFont = New Font("Tahoma", 12, FontStyle.Bold)  
    RichTextBox1.SelectionColor = System.Drawing.Color.Red  
    ```  
  
    ```csharp  
    richTextBox1.SelectionFont = new Font("Tahoma", 12, FontStyle.Bold);  
    richTextBox1.SelectionColor = System.Drawing.Color.Red;  
    ```  
  
    ```cpp  
    richTextBox1->SelectionFont =  
       gcnew System::Drawing::Font("Tahoma", 12, FontStyle::Bold);  
    richTextBox1->SelectionColor = System::Drawing::Color::Red;  
    ```  
  
    > [!NOTE]
    >  These properties only affect selected text, or, if no text is selected, the text that is typed at the current location of the insertion point. For information on selecting text programmatically, see <xref:System.Windows.Forms.TextBoxBase.Select%2A>.  
  
## See Also  
 <xref:System.Windows.Forms.RichTextBox>  
 [RichTextBox Control](../../../../docs/framework/winforms/controls/richtextbox-control-windows-forms.md)  
 [Controls to Use on Windows Forms](../../../../docs/framework/winforms/controls/controls-to-use-on-windows-forms.md)
