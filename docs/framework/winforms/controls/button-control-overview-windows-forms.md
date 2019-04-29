---
title: "Button Control Overview (Windows Forms)"
ms.date: "03/30/2017"
f1_keywords: 
  - "Button"
helpviewer_keywords: 
  - "Button control [Windows Forms], about Button control"
  - "buttons [Windows Forms], about buttons"
ms.assetid: 255b291b-51a9-4a92-a1a4-2400cd82443f
---
# Button Control Overview (Windows Forms)
The Windows Forms <xref:System.Windows.Forms.Button> control allows the user to click it to perform an action. When the button is clicked, it looks as if it is being pushed in and released. Whenever the user clicks a button, the <xref:System.Windows.Forms.Control.Click> event handler is invoked. You place code in the <xref:System.Windows.Forms.Control.Click> event handler to perform any action you choose.  
  
 The text displayed on the button is contained in the <xref:System.Windows.Forms.Control.Text%2A> property. If your text exceeds the width of the button, it will wrap to the next line. However, it will be clipped if the control cannot accommodate its overall height. For more information, see [How to: Set the Text Displayed by a Windows Forms Control](how-to-set-the-text-displayed-by-a-windows-forms-control.md). The <xref:System.Windows.Forms.Control.Text%2A> property can contain an access key, which allows a user to "click" the control by pressing the ALT key with the access key. For details, see [How to: Create Access Keys for Windows Forms Controls](how-to-create-access-keys-for-windows-forms-controls.md). The appearance of the text is controlled by the <xref:System.Windows.Forms.Control.Font%2A> property and the <xref:System.Windows.Forms.ButtonBase.TextAlign%2A> property.  
  
 The <xref:System.Windows.Forms.Button> control can also display images using the <xref:System.Windows.Forms.ButtonBase.Image%2A> and <xref:System.Windows.Forms.ButtonBase.ImageList%2A> properties. For more information, see [How to: Set the Image Displayed by a Windows Forms Control](how-to-set-the-image-displayed-by-a-windows-forms-control.md).  
  
## See also

- <xref:System.Windows.Forms.Button>
- [How to: Respond to Windows Forms Button Clicks](how-to-respond-to-windows-forms-button-clicks.md)
- [Ways to Select a Windows Forms Button Control](ways-to-select-a-windows-forms-button-control.md)
- [How to: Designate a Windows Forms Button as the Accept Button Using the Designer](designate-a-wf-button-as-the-accept-button-using-the-designer.md)
- [How to: Designate a Windows Forms Button as the Cancel Button Using the Designer](designate-a-wf-button-as-the-cancel-button-using-the-designer.md)
- [Button Control](button-control-windows-forms.md)
