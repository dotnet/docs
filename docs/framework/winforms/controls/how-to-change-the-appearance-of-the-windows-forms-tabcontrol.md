---
title: "How to: Change the Appearance of the Windows Forms TabControl"
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
  - "icons [Windows Forms], displaying on tabs"
  - "TabControl control [Windows Forms], changing page appearance"
  - "tabs [Windows Forms], controlling appearance"
  - "buttons [Windows Forms], displaying tabs as"
ms.assetid: 7c6cc443-ed62-4d26-b94d-b8913b44f773
caps.latest.revision: 16
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Change the Appearance of the Windows Forms TabControl
You can change the appearance of tabs in Windows Forms by using properties of the <xref:System.Windows.Forms.TabControl> and the <xref:System.Windows.Forms.TabPage> objects that make up the individual tabs on the control. By setting these properties, you can display images on tabs, display tabs vertically instead of horizontally, display multiple rows of tabs, and enable or disable tabs programmatically.  
  
### To display an icon on the label part of a tab  
  
1.  Add an <xref:System.Windows.Forms.ImageList> control to the form.  
  
2.  Add images to the image list.  
  
     For more information about image lists, see [ImageList Component](../../../../docs/framework/winforms/controls/imagelist-component-windows-forms.md) and [How to: Add or Remove Images with the Windows Forms ImageList Component](../../../../docs/framework/winforms/controls/how-to-add-or-remove-images-with-the-windows-forms-imagelist-component.md).  
  
3.  Set the <xref:System.Windows.Forms.TabControl.ImageList%2A> property of the <xref:System.Windows.Forms.TabControl> to the <xref:System.Windows.Forms.ImageList> control.  
  
4.  Set the <xref:System.Windows.Forms.TabPage.ImageIndex%2A> property of the <xref:System.Windows.Forms.TabPage> to the index of an appropriate image in the list.  
  
### To create multiple rows of tabs  
  
1.  Add the number of tab pages you want.  
  
2.  Set the <xref:System.Windows.Forms.TabControl.Multiline%2A> property of the <xref:System.Windows.Forms.TabControl> to `true`.  
  
3.  If the tabs do not already appear in multiple rows, set the <xref:System.Windows.Forms.Control.Width%2A> property of the <xref:System.Windows.Forms.TabControl> to be narrower than all the tabs.  
  
### To arrange tabs on the side of the control  
  
-   Set the <xref:System.Windows.Forms.TabControl.Alignment%2A> property of the <xref:System.Windows.Forms.TabControl> to <xref:System.Windows.Forms.TabAlignment.Left> or <xref:System.Windows.Forms.TabAlignment.Right>.  
  
### To programmatically enable or disable all controls on a tab  
  
1.  Set the <xref:System.Windows.Forms.TabPage.Enabled%2A> property of the <xref:System.Windows.Forms.TabPage> to `true` or `false`.  
  
    ```vb  
    TabPage1.Enabled = False  
    ```  
  
    ```csharp  
    tabPage1.Enabled = false;  
    ```  
  
    ```cpp  
    tabPage1->Enabled = false;  
    ```  
  
### To display tabs as buttons  
  
-   Set the <xref:System.Windows.Forms.TabControl.Appearance%2A> property of the <xref:System.Windows.Forms.TabControl> to <xref:System.Windows.Forms.TabAppearance.Buttons> or <xref:System.Windows.Forms.TabAppearance.FlatButtons>.  
  
## See Also  
 [TabControl Control](../../../../docs/framework/winforms/controls/tabcontrol-control-windows-forms.md)  
 [TabControl Control Overview](../../../../docs/framework/winforms/controls/tabcontrol-control-overview-windows-forms.md)  
 [How to: Add a Control to a Tab Page](../../../../docs/framework/winforms/controls/how-to-add-a-control-to-a-tab-page.md)  
 [How to: Disable Tab Pages](../../../../docs/framework/winforms/controls/how-to-disable-tab-pages.md)  
 [How to: Add and Remove Tabs with the Windows Forms TabControl](../../../../docs/framework/winforms/controls/how-to-add-and-remove-tabs-with-the-windows-forms-tabcontrol.md)
