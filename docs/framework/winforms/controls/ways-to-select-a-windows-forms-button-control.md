---
title: "Ways to Select a Windows Forms Button Control"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "Button control [Windows Forms], selecting"
ms.assetid: fe2fc058-5118-4f70-b264-6147d64a7a8d
---
# Ways to Select a Windows Forms Button Control
A Windows Forms button can be selected in the following ways:  
  
-   Use a mouse to click the button.  
  
-   Invoke the button's <xref:System.Windows.Forms.Control.Click> event in code.  
  
-   Move the focus to the button by pressing the TAB key, and then choose the button by pressing the SPACEBAR or ENTER.  
  
-   Press the access key (ALT + the underlined letter) for the button. For more information about access keys, see [How to: Create Access Keys for Windows Forms Controls](how-to-create-access-keys-for-windows-forms-controls.md).  
  
-   If the button is the "accept" button of the form, pressing ENTER chooses the button, even if another control has the focus — except if that other control is another button, a multi-line text box, or a custom control that traps the enter key.  
  
-   If the button is the "cancel" button of the form, pressing ESC chooses the button, even if another control has the focus.  
  
-   Call the <xref:System.Windows.Forms.Button.PerformClick%2A> method to select the button programmatically.  
  
## See also

- [Button Control Overview](button-control-overview-windows-forms.md)
- [How to: Respond to Windows Forms Button Clicks](how-to-respond-to-windows-forms-button-clicks.md)
- [Button Control](button-control-windows-forms.md)
