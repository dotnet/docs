---
title: "How to: Designate a Windows Forms Button as the Accept Button Using the Designer"
ms.date: "03/30/2017"
helpviewer_keywords:
  - "buttons [Windows Forms], default on Windows Forms"
  - "Accept button on Windows Forms"
  - "Button control [Windows Forms], designating as default"
  - "Windows Forms controls, default button on form"
ms.assetid: a1da0590-755f-49f2-aca7-609fac6351bf
---
# How to: Designate a Windows Forms Button as the Accept Button Using the Designer
On any Windows Form, you can designate a <xref:System.Windows.Forms.Button> control to be the accept button, also known as the default button. Whenever the user presses the ENTER key, the default button is clicked regardless of which other control on the form has the focus. The exceptions to this are when the control with focus is another button — in that case, the button with the focus will be clicked — or a multiline text box, or a custom control that traps the ENTER key.

### To designate the accept button

1. Select the form on which the button resides.

2. In the **Properties** window, set the form's <xref:System.Windows.Forms.Form.AcceptButton%2A> property to the <xref:System.Windows.Forms.Button> control's name.

## See also

- <xref:System.Windows.Forms.Form.AcceptButton%2A>
- [Button Control Overview](button-control-overview-windows-forms.md)
- [Ways to Select a Windows Forms Button Control](ways-to-select-a-windows-forms-button-control.md)
- [How to: Respond to Windows Forms Button Clicks](how-to-respond-to-windows-forms-button-clicks.md)
- [How to: Designate a Windows Forms Button as the Cancel Button Using the Designer](designate-a-wf-button-as-the-cancel-button-using-the-designer.md)
- [Button Control](button-control-windows-forms.md)
