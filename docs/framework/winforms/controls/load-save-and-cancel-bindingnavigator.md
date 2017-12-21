---
title: "How to: Add Load, Save, and Cancel Buttons to the Windows Forms BindingNavigator Control"
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
  - "controls [Windows Forms], manipulating"
  - "BindingNavigator control [Windows Forms], adding buttons"
ms.assetid: faa33042-186e-4bb2-8798-17ceb987ec62
caps.latest.revision: 17
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Add Load, Save, and Cancel Buttons to the Windows Forms BindingNavigator Control
The <xref:System.Windows.Forms.BindingNavigator> control is a special-purpose <xref:System.Windows.Forms.ToolStrip> control that is intended for navigating and manipulating controls on your form that are bound to data.  
  
 Because it is a <xref:System.Windows.Forms.ToolStrip> control, the <xref:System.Windows.Forms.BindingNavigator> component can be easily modified to include additional or alternative commands for the user.  
  
 In the following procedure, a <xref:System.Windows.Forms.TextBox> control is bound to data, and the <xref:System.Windows.Forms.ToolStrip> control that is added to the form is modified to include load, save, and cancel buttons.  
  
### To add load, save, and cancel buttons to the BindingNavigator component  
  
1.  Add a <xref:System.Windows.Forms.TextBox> control to your form.  
  
2.  Bind it to a <xref:System.Windows.Forms.BindingSource>, which is bound to a data source. For this example, the <xref:System.Windows.Forms.BindingSource> is bound to a database.  
  
3.  After the dataset and table adapter are generated, drag a <xref:System.Windows.Forms.BindingNavigator> control to the form.  
  
4.  Set the <xref:System.Windows.Forms.BindingNavigator> control's <xref:System.Windows.Forms.BindingNavigator.BindingSource%2A> property to the <xref:System.Windows.Forms.BindingSource> on the form that is bound to the controls.  
  
5.  Select the <xref:System.Windows.Forms.BindingNavigator> control.  
  
6.  Click the smart tag glyph (![Smart Tag Glyph](../../../../docs/framework/winforms/controls/media/vs-winformsmttagglyph.gif "VS_WinFormSmtTagGlyph")) so the **BindingNavigator Tasks** dialog appears and select **Edit Items**.  
  
     The **Items Collection Editor** appears.  
  
7.  In the **Items Collection Editor**, complete the following:  
  
    1.  Add a <xref:System.Windows.Forms.ToolStripSeparator> and three <xref:System.Windows.Forms.ToolStripButton> items by selecting the appropriate type of <xref:System.Windows.Forms.ToolStripItem> and clicking the **Add** button.  
  
    2.  Set the <xref:System.Windows.Forms.ToolStripItem.Name%2A> property of the buttons to**LoadButton**,**SaveButton**, and**CancelButton**, respectively.  
  
    3.  Set the <xref:System.Windows.Forms.ToolStripItem.Text%2A> property of the buttons to**Load**`,` **Save**, and**Cancel**.  
  
    4.  Set the <xref:System.Windows.Forms.ToolStripItem.DisplayStyle%2A> property for each of the buttons to**Text**. Alternatively, you can set this property to**Image**or**ImageAndText**and set the image to be displayed in the <xref:System.Windows.Forms.ToolStripItem.Image%2A> property.  
  
    5.  Click **OK** to close the dialog box.The buttons are added to the <xref:System.Windows.Forms.ToolStrip>.  
  
8.  Right-click the form and choose **View Code**.  
  
9. In the Code Editor, find the line of code that loads data into the table adapter. This code was generated when you set up the data binding in step 2. The code should be similar to the following: `TableAdapterName.Fill(DataSetName.TableName)`. It will most likely be in the form's <xref:System.Windows.Forms.Form.Load> event.  
  
10. Create an event handler for the <xref:System.Windows.Forms.ToolStripItem.Click> event of the**Load**<xref:System.Windows.Forms.ToolStripButton> you created earlier and move this data-loading code into it.  
  
     Your code should now look similar to the following:  
  
    ```vb  
    Private Sub LoadButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadButton.Click  
        TableAdapterName.Fill(DataSetName.TableName)  
    End Sub  
    ```  
  
    ```csharp  
    private void LoadButton_Click(System.Object sender,   
        System.EventArgs e)  
    {  
        TableAdapterName.Fill(DataSetName.TableName);  
    }  
    ```  
  
11. Create an event handler for the <xref:System.Windows.Forms.ToolStripItem.Click> event of the **Save**<xref:System.Windows.Forms.ToolStripButton> you created earlier and write code to update the data within the table the control is bound to.  
  
    ```vb  
    Private Sub SaveButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveButton.Click  
        TableAdapterName.Update(DataSetName.TableName)  
    End Sub  
    ```  
  
    ```csharp  
    private void SaveButton_Click(System.Object sender,   
        System.EventArgs e)  
    {  
        TableAdapterName.Update(DataSetName.TableName);  
    }  
    ```  
  
    > [!NOTE]
    >  In some cases, the <xref:System.Windows.Forms.BindingNavigator> component will already have a**Save** button, but no code will have been generated by the Windows Forms Designer. In this case, you can place the preceding code in the <xref:System.Windows.Forms.ToolStripItem.Click> event handler for that button, rather than creating an entirely new button on the <xref:System.Windows.Forms.ToolStrip>. However, the button is disabled by default, so you must set the <xref:System.Windows.Forms.ToolBarButton.Enabled%2A> property of the button to `true` to have the button function correctly.  
  
12. Create an event handler for the <xref:System.Windows.Forms.ToolStripItem.Click> event of the**Cancel**<xref:System.Windows.Forms.ToolStripButton> you created earlier and write code to cancel any changes to the data record that is displayed.  
  
    ```vb  
    Private Sub CancelButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancelButton.Click  
        BindingSourceName.CancelEdit()  
    End Sub  
    ```  
  
    ```csharp  
    private void CancelButton_Click(System.Object sender, System.EventArgs e)  
    {  
        BindingSourceName.CancelEdit();  
    }  
    ```  
  
    > [!NOTE]
    >  The <xref:System.Windows.Forms.BindingSource.CancelEdit%2A> method is scoped to the row of data. Save any changes you make while viewing that individual record before navigating to the next record.  
  
## See Also  
 <xref:System.Windows.Forms.BindingNavigator>  
 <xref:System.Windows.Forms.BindingSource>  
 <xref:System.Windows.Forms.ToolStrip>  
 [BindingNavigator Control](../../../../docs/framework/winforms/controls/bindingnavigator-control-windows-forms.md)  
 [BindingSource Component Overview](../../../../docs/framework/winforms/controls/bindingsource-component-overview.md)
