---
title: "How to: Disable Tab Pages"
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
  - "tab pages [Windows Forms], hiding in forms"
  - "TabControl control [Windows Forms], disabling pages"
ms.assetid: adcc6618-8a34-4ee1-bbe3-47e732de6a59
caps.latest.revision: 15
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Disable Tab Pages
On some occasions, you will want to restrict access to data that is available within your Windows Forms application. One example of this might be when you have data displayed in the tab pages of a tab control; administrators could have information on a tab page that you would want to restrict from guest or lower-level users.  
  
### To disable tab pages programmatically  
  
1.  Write code to handle the tab control's <xref:System.Windows.Forms.TabControl.SelectedIndexChanged> event. This is the event that is raised when the user switches from one tab to the next.  
  
2.  Check credentials. Depending upon the information presented, you may want to check the user name the user has logged in with or some other form of credentials before allowing the user to view the tab.  
  
3.  If the user has appropriate credentials, display the tab that was clicked. If the user does not have appropriate credentials, display a message box or some other user interface indicating that they do not have access, and return to the initial tab.  
  
    > [!NOTE]
    >  When you implement this functionality in your production applications, you can perform this credential check during the form's <xref:System.Windows.Forms.Form.Load> event. This will allow you to hide the tab before any user interface is shown, which is a much cleaner approach to programming. The methodology used below (checking credentials and disabling the tab during the <xref:System.Windows.Forms.TabControl.SelectedIndexChanged> event) is for illustrative purposes.  
  
4.  Optionally, if you have more than two tab pages, display a tab page different from the original.  
  
     In the example below, a <xref:System.Windows.Forms.CheckBox> control is used in lieu of checking the credentials, as the criteria for access to the tab will vary by application. When the <xref:System.Windows.Forms.TabControl.SelectedIndexChanged> event is raised, if the credential check is true (that is, the check box is checked) and the selected tab is `TabPage2` (the tab with the confidential information, in this example), then `TabPage2` is displayed. Otherwise, `TabPage3` is displayed and a message box is shown to the user, indicating they did not have appropriate access privileges. The code below assumes a form with a <xref:System.Windows.Forms.CheckBox> control (`CredentialCheck`) and a <xref:System.Windows.Forms.TabControl> control with three tab pages.  
  
    ```vb  
    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged  
       ' Check Credentials Here  
  
       If CredentialCheck.Checked = True And _   
       TabControl1.SelectedTab Is TabPage2 Then  
          TabControl1.SelectedTab = TabPage2  
       ElseIf CredentialCheck.Checked = False _   
       And TabControl1.SelectedTab Is TabPage2 Then  
          MessageBox.Show _   
         ("Unable to load tab. You have insufficient access privileges.")  
          TabControl1.SelectedTab = TabPage3  
       End If  
    End Sub  
    ```  
  
    ```csharp  
    private void tabControl1_SelectedIndexChanged(object sender, System.EventArgs e)  
    {  
        // Check Credentials Here  
  
        if ((CredentialCheck.Checked == true) && (tabControl1.SelectedTab == tabPage2))   
        {  
            tabControl1.SelectedTab = tabPage2;  
        }  
        else if ((CredentialCheck.Checked == false) && (tabControl1.SelectedTab == tabPage2))  
        {  
            MessageBox.Show("Unable to load tab. You have insufficient access privileges.");  
            tabControl1.SelectedTab = tabPage3;  
        }  
    }  
    ```  
  
    ```cpp  
    private:  
       System::Void tabControl1_SelectedIndexChanged(  
          System::Object ^ sender,  
          System::EventArgs ^  e)  
       {  
          // Check Credentials Here  
          if ((CredentialCheck->Checked == true) &&  
              (tabControl1->SelectedTab == tabPage2))  
          {  
             tabControl1->SelectedTab = tabPage2;  
          }  
          else if ((CredentialCheck->Checked == false) &&  
                   (tabControl1->SelectedTab == tabPage2))  
          {  
             MessageBox::Show(String::Concat("Unable to load tab. ",  
                "You have insufficient access privileges."));  
             tabControl1->SelectedTab = tabPage3;  
          }  
       }  
    ```  
  
     (Visual C#, Visual C++) Place the following code in the form's constructor to register the event handler.  
  
    ```csharp  
    this.tabControl1.SelectedIndexChanged +=   
       new System.EventHandler(this.tabControl1_SelectedIndexChanged);  
    ```  
  
    ```cpp  
    this->tabControl1->SelectedIndexChanged +=  
       gcnew System::EventHandler(this, &Form1::tabControl1_SelectedIndexChanged);  
    ```  
  
## See Also  
 [TabControl Control Overview](../../../../docs/framework/winforms/controls/tabcontrol-control-overview-windows-forms.md)  
 [How to: Add a Control to a Tab Page](../../../../docs/framework/winforms/controls/how-to-add-a-control-to-a-tab-page.md)  
 [How to: Add and Remove Tabs with the Windows Forms TabControl](../../../../docs/framework/winforms/controls/how-to-add-and-remove-tabs-with-the-windows-forms-tabcontrol.md)  
 [How to: Change the Appearance of the Windows Forms TabControl](../../../../docs/framework/winforms/controls/how-to-change-the-appearance-of-the-windows-forms-tabcontrol.md)
