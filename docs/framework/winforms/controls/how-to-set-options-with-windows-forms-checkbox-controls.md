---
title: "How to: Set Options with Windows Forms CheckBox Controls"
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
  - "checked"
helpviewer_keywords: 
  - "CheckBox control [Windows Forms], checked state"
  - "check boxes [Windows Forms], using to set options"
  - "CheckBox control [Windows Forms], using to set options"
ms.assetid: 2ac70498-7e3e-4e07-8901-ccabaeb5fd3e
caps.latest.revision: 13
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Set Options with Windows Forms CheckBox Controls
A Windows Forms <xref:System.Windows.Forms.CheckBox> control is used to give users True/False or Yes/No options. The control displays a check mark when it is selected.  
  
### To set options with CheckBox controls  
  
1.  Examine the value of the <xref:System.Windows.Forms.CheckBox.Checked%2A> property to determine its state, and use that value to set an option.  
  
     In the code sample below, when the <xref:System.Windows.Forms.CheckBox> control's <xref:System.Windows.Forms.CheckBox.CheckedChanged> event is raised, the form's <xref:System.Windows.Forms.Control.AllowDrop%2A> property is set to `false` if the check box is checked. This is useful for situations where you want to restrict user interaction.  
  
    ```vb  
    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, _  
       ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged  
       ' Determine the CheckState of the check box.  
       If CheckBox1.CheckState = CheckState.Checked Then  
          ' If checked, do not allow items to be dragged onto the form.  
          Me.AllowDrop = False  
       End If  
    End Sub  
    ```  
  
    ```csharp  
    private void checkBox1_CheckedChanged(object sender, System.EventArgs e)  
    {  
       // Determine the CheckState of the check box.  
       if (checkBox1.CheckState == CheckState.Checked)   
       {  
          // If checked, do not allow items to be dragged onto the form.  
          this.AllowDrop = false;  
       }  
    }  
    ```  
  
    ```cpp  
    private:  
       void checkBox1_CheckedChanged(System::Object ^ sender,  
          System::EventArgs ^ e)  
       {  
          // Determine the CheckState of the check box.  
          if (checkBox1->CheckState == CheckState::Checked)   
          {  
             // If checked, do not allow items to be dragged onto the form.  
             this->AllowDrop = false;  
          }  
       }  
    ```  
  
## See Also  
 <xref:System.Windows.Forms.CheckBox>  
 [CheckBox Control Overview](../../../../docs/framework/winforms/controls/checkbox-control-overview-windows-forms.md)  
 [How to: Respond to Windows Forms CheckBox Clicks](../../../../docs/framework/winforms/controls/how-to-respond-to-windows-forms-checkbox-clicks.md)  
 [CheckBox Control](../../../../docs/framework/winforms/controls/checkbox-control-windows-forms.md)
