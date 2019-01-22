---
title: "How to: Designate a Windows Forms Button as the Cancel Button Using the Designer"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "buttons [Windows Forms], cancel buttons"
  - "Button control [Windows Forms], designating as cancel button"
ms.assetid: 30e77d9c-d565-4ab5-a84a-62c043af8822
---
# How to: Designate a Windows Forms Button as the Cancel Button Using the Designer
On any Windows Form, you can designate a <xref:System.Windows.Forms.Button> control to be the cancel button. A cancel button is clicked whenever the user presses the ESC key, regardless of which other control on the form has the focus. Such a button is usually programmed to enable the user to quickly exit an operation without committing to any action.  
  
> [!NOTE]
>  The dialog boxes and menu commands you see might differ from those described in Help depending on your active settings or edition. To change your settings, choose **Import and Export Settings** on the **Tools** menu. For more information, see [Personalize the Visual Studio IDE](/visualstudio/ide/personalizing-the-visual-studio-ide).  
  
### To designate the cancel button  
  
1.  Select the form on which the button resides.  
  
2.  In the **Properties** window, set the form's <xref:System.Windows.Forms.Form.CancelButton%2A> property to the <xref:System.Windows.Forms.Button> control's name.  
  
## See also
 <xref:System.Windows.Forms.Form.CancelButton%2A>  
 [Button Control Overview](../../../../docs/framework/winforms/controls/button-control-overview-windows-forms.md)  
 [Ways to Select a Windows Forms Button Control](../../../../docs/framework/winforms/controls/ways-to-select-a-windows-forms-button-control.md)  
 [How to: Respond to Windows Forms Button Clicks](../../../../docs/framework/winforms/controls/how-to-respond-to-windows-forms-button-clicks.md)  
 [How to: Designate a Windows Forms Button as the Accept Button Using the Designer](../../../../docs/framework/winforms/controls/designate-a-wf-button-as-the-accept-button-using-the-designer.md)  
 [Button Control](../../../../docs/framework/winforms/controls/button-control-windows-forms.md)
