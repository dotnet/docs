---
title: "How to: Send Data to the Active MDI Child"
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
helpviewer_keywords: 
  - "child forms"
  - "MDI [Windows Forms], sending data to forms"
  - "Clipboard [Windows Forms], pasting"
  - "Clipboard [Windows Forms], getting data from"
ms.assetid: 1047d2fe-1235-46db-aad9-563aea1d743b
caps.latest.revision: 12
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Send Data to the Active MDI Child
Often, within the context of [Multiple-Document Interface (MDI) Applications](../../../../docs/framework/winforms/advanced/multiple-document-interface-mdi-applications.md), you will need to send data to the active child window, such as when the user pastes data from the Clipboard into an MDI application.  
  
> [!NOTE]
>  For information about verifying which child window has focus and sending its contents to the Clipboard, see [Determining the Active MDI Child](../../../../docs/framework/winforms/advanced/how-to-determine-the-active-mdi-child.md).  
  
### To send data to the active MDI child window from the Clipboard  
  
1.  Within a method, copy the text on the Clipboard to the active control of the active child form.  
  
    > [!NOTE]
    >  This example assumes there is an MDI parent form (`Form1`) that has one or more MDI child windows containing a <xref:System.Windows.Forms.RichTextBox> control. For more information, see [Creating MDI Parent Forms](../../../../docs/framework/winforms/advanced/how-to-create-mdi-parent-forms.md).  
  
    ```vb  
    Public Sub mniPaste_Click(ByVal sender As Object, _  
       ByVal e As System.EventArgs) Handles mniPaste.Click  
  
       ' Determine the active child form.  
       Dim activeChild As Form = Me.ParentForm.ActiveMDIChild  
  
       ' If there is an active child form, find the active control, which  
       ' in this example should be a RichTextBox.  
       If (Not activeChild Is Nothing) Then  
          Try  
             Dim theBox As RichTextBox = Ctype(activeChild.ActiveControl, RichTextBox)  
             If (Not theBox Is Nothing) Then  
                ' Create a new instance of the DataObject interface.  
                Dim data As IDataObject = Clipboard.GetDataObject()  
                ' If the data is text, then set the text of the   
                ' RichTextBox to the text in the clipboard.  
                If (data.GetDataPresent(DataFormats.Text)) Then  
                   theBox.SelectedText = data.GetData(DataFormats.Text).ToString()  
                End If  
             End If  
          Catch  
             MessageBox.Show("You need to select a RichTextBox.")  
          End Try  
       End If  
    End Sub  
    ```  
  
    ```csharp  
    protected void mniPaste_Click (object sender, System.EventArgs e)  
    {  
      // Determine the active child form.  
       Form activeChild = this.ParentForm.ActiveMdiChild;  
  
       // If there is an active child form, find the active control, which  
       // in this example should be a RichTextBox.  
       if (activeChild != null)  
       {  
          try   
          {  
             RichTextBox theBox = (RichTextBox)activeChild.ActiveControl;  
             if (theBox != null)  
             {  
                // Create a new instance of the DataObject interface.  
                IDataObject data = Clipboard.GetDataObject();  
                // If the data is text, then set the text of the   
                // RichTextBox to the text in the clipboard.  
                if (data.GetDataPresent(DataFormats.Text))  
                {  
                   theBox.SelectedText = data.GetData(DataFormats.Text).ToString();                 
                }  
             }  
          }  
          catch   
          {  
             MessageBox.Show("You need to select a RichTextBox.");  
          }  
       }  
    }  
    ```  
  
## See Also  
 [Multiple-Document Interface (MDI) Applications](../../../../docs/framework/winforms/advanced/multiple-document-interface-mdi-applications.md)  
 [How to: Create MDI Parent Forms](../../../../docs/framework/winforms/advanced/how-to-create-mdi-parent-forms.md)  
 [How to: Create MDI Child Forms](../../../../docs/framework/winforms/advanced/how-to-create-mdi-child-forms.md)  
 [How to: Determine the Active MDI Child](../../../../docs/framework/winforms/advanced/how-to-determine-the-active-mdi-child.md)  
 [How to: Arrange MDI Child Forms](../../../../docs/framework/winforms/advanced/how-to-arrange-mdi-child-forms.md)
