---
title: "How to: Respond to Windows Forms CheckBox Clicks"
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
  - "Click event [Windows Forms], CheckBox control"
  - "CheckBox control [Windows Forms], Click events"
  - "events [Windows Forms], Click events"
  - "double-clicks"
  - "check boxes [Windows Forms], responding to events"
ms.assetid: c39f901e-8899-43b6-aa31-939cbf7089fb
caps.latest.revision: 11
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Respond to Windows Forms CheckBox Clicks
Whenever a user clicks a Windows Forms <xref:System.Windows.Forms.CheckBox> control, the <xref:System.Windows.Forms.Control.Click> event occurs. You can program your application to perform some action depending upon the state of the check box.  
  
### To respond to CheckBox clicks  
  
1.  In the <xref:System.Windows.Forms.Control.Click> event handler, use the <xref:System.Windows.Forms.CheckBox.Checked%2A> property to determine the control's state, and perform any necessary action.  
  
    ```vb  
    Private Sub CheckBox1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox1.Click  
       ' The CheckBox control's Text property is changed each time the   
       ' control is clicked, indicating a checked or unchecked state.  
       If CheckBox1.Checked = True Then  
          CheckBox1.Text = "Checked"  
       Else  
          CheckBox1.Text = "Unchecked"  
       End If  
    End Sub  
    ```  
  
    ```csharp  
    private void checkBox1_Click(object sender, System.EventArgs e)  
    {  
       // The CheckBox control's Text property is changed each time the   
       // control is clicked, indicating a checked or unchecked state.  
       if (checkBox1.Checked)  
       {  
          checkBox1.Text = "Checked";  
       }  
       else  
       {  
          checkBox1.Text = "Unchecked";  
       }  
    }  
    ```  
  
    ```cpp  
    private:  
       void checkBox1_CheckedChanged(System::Object ^ sender,  
          System::EventArgs ^ e)  
       {  
          if (checkBox1->Checked)  
          {  
             checkBox1->Text = "Checked";  
          }  
          else  
          {  
             checkBox1->Text = "Unchecked";  
          }  
       }  
    ```  
  
    > [!NOTE]
    >  If the user attempts to double-click the <xref:System.Windows.Forms.CheckBox> control, each click will be processed separately; that is, the <xref:System.Windows.Forms.CheckBox> control does not support the double-click event.  
  
    > [!NOTE]
    >  When the <xref:System.Windows.Forms.CheckBox.AutoCheck%2A> property is `true` (the default), the <xref:System.Windows.Forms.CheckBox> is automatically selected or cleared when it is clicked. Otherwise, you must manually set the <xref:System.Windows.Forms.CheckBox.Checked%2A> property when the <xref:System.Windows.Forms.Control.Click> event occurs.  
  
     You can also use the <xref:System.Windows.Forms.CheckBox> control to determine a course of action.  
  
### To determine a course of action when a check box is clicked  
  
1.  Use a case statement to query the value of the <xref:System.Windows.Forms.CheckBox.CheckState%2A> property to determine a course of action. When the <xref:System.Windows.Forms.CheckBox.ThreeState%2A> property is set to `true`, the <xref:System.Windows.Forms.CheckBox.CheckState%2A> property may return three possible values, which represent the box being checked, the box being unchecked, or a third indeterminate state in which the box is displayed with a dimmed appearance to indicate the option is unavailable.  
  
    ```vb  
    Private Sub CheckBox1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox1.Click  
       Select Case CheckBox1.CheckState  
          Case CheckState.Checked  
             ' Code for checked state.  
          Case CheckState.Unchecked  
             ' Code for unchecked state.  
          Case CheckState.Indeterminate  
             ' Code for indeterminate state.  
       End Select   
    End Sub  
    ```  
  
    ```csharp  
    private void checkBox1_Click(object sender, System.EventArgs e)  
    {  
       switch(checkBox1.CheckState)  
       {  
          case CheckState.Checked:  
             // Code for checked state.  
             break;  
          case CheckState.Unchecked:  
             // Code for unchecked state.  
             break;  
          case CheckState.Indeterminate:  
             // Code for indeterminate state.  
             break;  
       }  
    }  
    ```  
  
    ```cpp  
    private:  
       void checkBox1_CheckedChanged(System::Object ^ sender,  
          System::EventArgs ^ e)  
       {  
          switch(checkBox1->CheckState) {  
             case CheckState::Checked:  
                // Code for checked state.  
                break;  
             case CheckState::Unchecked:  
                // Code for unchecked state.  
                break;  
             case CheckState::Indeterminate:  
                // Code for indeterminate state.  
                break;  
          }  
       }  
    ```  
  
    > [!NOTE]
    >  When the <xref:System.Windows.Forms.CheckBox.ThreeState%2A> property is set to `true`, the <xref:System.Windows.Forms.CheckBox.Checked%2A> property returns `true` for both <xref:System.Windows.Forms.CheckState.Checked> and <xref:System.Windows.Forms.CheckState.Indeterminate>.  
  
## See Also  
 <xref:System.Windows.Forms.CheckBox>  
 [CheckBox Control Overview](../../../../docs/framework/winforms/controls/checkbox-control-overview-windows-forms.md)  
 [How to: Set Options with Windows Forms CheckBox Controls](../../../../docs/framework/winforms/controls/how-to-set-options-with-windows-forms-checkbox-controls.md)  
 [CheckBox Control](../../../../docs/framework/winforms/controls/checkbox-control-windows-forms.md)
