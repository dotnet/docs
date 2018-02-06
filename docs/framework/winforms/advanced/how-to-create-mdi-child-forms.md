---
title: "How to: Create MDI Child Forms"
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
  - "MDI [Windows Forms], creating forms"
  - "child forms"
ms.assetid: 164b69bb-2eca-4339-ada3-0679eb2c6dda
caps.latest.revision: 21
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Create MDI Child Forms
MDI child forms are an essential element of [Multiple-Document Interface (MDI) Applications](../../../../docs/framework/winforms/advanced/multiple-document-interface-mdi-applications.md), as these forms are the center of user interaction.  
  
 In the following procedure, you will create MDI child form that displays a <xref:System.Windows.Forms.RichTextBox> control, similar to most word-processing applications. Substituting the <xref:System.Windows.Forms> control with other controls, such as the <xref:System.Windows.Forms.DataGridView> control, or a mixture of controls enables you to create MDI child windows (and, by extension, MDI applications) with diverse possibilities.  
  
> [!NOTE]
>  The dialog boxes and menu commands you see might differ from those described in Help depending on your active settings or edition. To change your settings, choose **Import and Export Settings** on the **Tools** menu. For more information, see [Customizing Development Settings in Visual Studio](http://msdn.microsoft.com/library/22c4debb-4e31-47a8-8f19-16f328d7dcd3).  
  
### To create MDI child forms  
  
1.  Create a new Windows Forms project. In **the Properties Windows** for the form, set its <xref:System.Windows.Forms.Form.IsMdiContainer%2A> property to `true`, and its `WindowsState` property to `Maximized`.  
  
     This designates the form as an MDI container for child windows.  
  
2.  From the `Toolbox`, drag a <xref:System.Windows.Forms.MenuStrip> control to the form. Set its `Text` property to **File**.  
  
3.  Click the ellipses (…) next to the **Items** property, and click **Add** to add two child tool strip menu items. Set the `Text` property for these items to **New** and **Window**.  
  
4.  In **Solution Explorer**, right-click the project, point to **Add**, and then select **Add New Item**.  
  
5.  In the **Add New Item** dialog box, select **Windows Form** (in [!INCLUDE[vbprvb](../../../../includes/vbprvb-md.md)] or in [!INCLUDE[csprcs](../../../../includes/csprcs-md.md)]) or **Windows Forms Application (.NET)** (in [!INCLUDE[vcprvc](../../../../includes/vcprvc-md.md)]) from the **Templates** pane. In the **Name** box, name the form **Form2**. Click the **Open** button to add the form to the project.  
  
    > [!NOTE]
    >  The MDI child form you created in this step is a standard Windows Form. As such, it has an <xref:System.Windows.Forms.Form.Opacity%2A> property, which enables you to control the transparency of the form. However, the <xref:System.Windows.Forms.Form.Opacity%2A> property was designed for top-level windows. Do not use it with MDI child forms, as painting problems can occur.  
  
     This form will be the template for your MDI child forms.  
  
     The **Windows Forms Designer** opens, displaying **Form2**.  
  
6.  From the **Toolbox**, drag a **RichTextBox** control to the form.  
  
7.  In the **Properties** window, set the `Anchor` property to **Top, Left** and the `Dock` property to **Fill**.  
  
     This causes the <xref:System.Windows.Forms.RichTextBox> control to completely fill the area of the MDI child form, even when the form is resized.  
  
8.  Double click the **New** menu item to create a <xref:System.Windows.Forms.Control.Click> event handler for it.  
  
9. Insert code similar to the following to create a new MDI child form when the user clicks the **New** menu item.  
  
    > [!NOTE]
    >  In the following example, the event handler handles the <xref:System.Windows.Forms.Control.Click> event for `MenuItem2`. Be aware that, depending on the specifics of your application architecture, your **New** menu item may not be `MenuItem2`.  
  
    ```vb  
    Protected Sub MDIChildNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem2.Click  
       Dim NewMDIChild As New Form2()  
       'Set the Parent Form of the Child window.  
       NewMDIChild.MdiParent = Me  
       'Display the new form.  
       NewMDIChild.Show()  
    End Sub  
    ```  
  
    ```csharp  
    protected void MDIChildNew_Click(object sender, System.EventArgs e){  
       Form2 newMDIChild = new Form2();  
       // Set the Parent Form of the Child window.  
       newMDIChild.MdiParent = this;  
       // Display the new form.  
       newMDIChild.Show();  
    }  
    ```  
  
    ```cpp  
    private:  
       void menuItem2_Click(System::Object ^ sender,  
          System::EventArgs ^ e)  
       {  
          Form2^ newMDIChild = gcnew Form2();  
          // Set the Parent Form of the Child window.  
          newMDIChild->MdiParent = this;  
          // Display the new form.  
          newMDIChild->Show();  
       }  
    ```  
  
     In [!INCLUDE[vcprvc](../../../../includes/vcprvc-md.md)], add the following `#include` directive at the top of Form1.h:  
  
    ```cpp  
    #include "Form2.h"  
    ```  
  
10. In the drop-down list at the top of the **Properties** window, select the menu strip that corresponds to the **File** menu strip and set the <xref:System.Windows.Forms.MenuStrip.MdiWindowListItem%2A> property to the Window <xref:System.Windows.Forms.ToolStripMenuItem>.  
  
     This will enable the **Window** menu to maintain a list of open MDI child windows with a check mark next to the active child window.  
  
11. Press F5 to run the application. By selecting **New** from the **File** menu, you can create new MDI child forms, which are kept track of in the **Window** menu item.  
  
    > [!NOTE]
    >  When an MDI child form has a <xref:System.Windows.Forms.MainMenu> component (with, usually, a menu structure of menu items) and it is opened within an MDI parent form that has a <xref:System.Windows.Forms.MainMenu> component (with, usually, a menu structure of menu items), the menu items will merge automatically if you have set the <xref:System.Windows.Forms.MenuItem.MergeType%2A> property (and optionally, the <xref:System.Windows.Forms.MenuItem.MergeOrder%2A> property). Set the <xref:System.Windows.Forms.MenuItem.MergeType%2A> property of both <xref:System.Windows.Forms.MainMenu> components and all of the menu items of the child form to <xref:System.Windows.Forms.MenuMerge.MergeItems>. Additionally, set the <xref:System.Windows.Forms.MenuItem.MergeOrder%2A> property so that the menu items from both menus appear in the desired order. Moreover, keep in mind that when you close an MDI parent form, each of the MDI child forms raises a <xref:System.Windows.Forms.Form.Closing> event before the <xref:System.Windows.Forms.Form.Closing> event for the MDI parent is raised. Canceling an MDI child's <xref:System.Windows.Forms.Form.Closing> event will not prevent the MDI parent's <xref:System.Windows.Forms.Form.Closing> event from being raised; however, the <xref:System.ComponentModel.CancelEventArgs> argument for the MDI parent's <xref:System.Windows.Forms.Form.Closing> event will now be set to `true`. You can force the MDI parent and all MDI child forms to close by setting the <xref:System.ComponentModel.CancelEventArgs> argument to `false`.  
  
## See Also  
 [Multiple-Document Interface (MDI) Applications](../../../../docs/framework/winforms/advanced/multiple-document-interface-mdi-applications.md)  
 [How to: Create MDI Parent Forms](../../../../docs/framework/winforms/advanced/how-to-create-mdi-parent-forms.md)  
 [How to: Determine the Active MDI Child](../../../../docs/framework/winforms/advanced/how-to-determine-the-active-mdi-child.md)  
 [How to: Send Data to the Active MDI Child](../../../../docs/framework/winforms/advanced/how-to-send-data-to-the-active-mdi-child.md)  
 [How to: Arrange MDI Child Forms](../../../../docs/framework/winforms/advanced/how-to-arrange-mdi-child-forms.md)
