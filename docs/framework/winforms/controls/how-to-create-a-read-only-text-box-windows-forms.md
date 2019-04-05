---
title: "How to: Create a Read-Only Text Box (Windows Forms)"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "TextBox control [Windows Forms], read-only"
  - "read-only text boxes"
  - "text boxes [Windows Forms], read-only"
ms.assetid: 60baa9ab-fa57-44ad-bb7c-61b05aa64296
---
# How to: Create a Read-Only Text Box (Windows Forms)
You can transform an editable Windows Forms text box into a read-only control. For example, the text box may display a value that is usually edited but may not be currently, due to the state of the application.  
  
### To create a read-only text box  
  
1.  Set the <xref:System.Windows.Forms.TextBox> control's <xref:System.Windows.Forms.TextBoxBase.ReadOnly%2A> property to `true`. With the property set to `true`, users can still scroll and highlight text in a text box without allowing changes. A **Copy** command is functional in a text box, but **Cut** and **Paste** commands are not.  
  
    > [!NOTE]
    >  The <xref:System.Windows.Forms.TextBoxBase.ReadOnly%2A> property only affects user interaction at run time. You can still change text box contents programmatically at run time by changing the <xref:System.Windows.Forms.TextBox.Text%2A> property of the text box.  
  
## See also

- <xref:System.Windows.Forms.TextBox>
- [TextBox Control Overview](textbox-control-overview-windows-forms.md)
- [How to: Control the Insertion Point in a Windows Forms TextBox Control](how-to-control-the-insertion-point-in-a-windows-forms-textbox-control.md)
- [How to: Create a Password Text Box with the Windows Forms TextBox Control](how-to-create-a-password-text-box-with-the-windows-forms-textbox-control.md)
- [How to: Put Quotation Marks in a String](how-to-put-quotation-marks-in-a-string-windows-forms.md)
- [How to: Select Text in the Windows Forms TextBox Control](how-to-select-text-in-the-windows-forms-textbox-control.md)
- [How to: View Multiple Lines in the Windows Forms TextBox Control](how-to-view-multiple-lines-in-the-windows-forms-textbox-control.md)
- [TextBox Control](textbox-control-windows-forms.md)
