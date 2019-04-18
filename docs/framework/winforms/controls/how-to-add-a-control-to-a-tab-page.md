---
title: "How to: Add a Control to a Tab Page"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
  - "cpp"
helpviewer_keywords: 
  - "TabPage control"
  - "tab controls [Windows Forms], tab order"
  - "tab pages [Windows Forms], adding controls"
ms.assetid: b092532e-7346-469f-b9a1-897f9bea4fb7
---
# How to: Add a Control to a Tab Page
You can use the Windows Forms <xref:System.Windows.Forms.TabControl> to display other controls in an organized fashion. The following procedure shows how to add a button to the first tab. For information about adding an icon to the label part of a tab page, see [How to: Change the Appearance of the Windows Forms TabControl](how-to-change-the-appearance-of-the-windows-forms-tabcontrol.md).  
  
### To add a control programmatically  
  
1. Use the <xref:System.Windows.Forms.Control.ControlCollection.Add%2A> method of the collection returned by the <xref:System.Windows.Forms.Control.Controls%2A> property of <xref:System.Windows.Forms.TabPage>:  
  
     [!code-cpp[TabPageControlCollectionHowToAdd#1](~/samples/snippets/cpp/VS_Snippets_Winforms/tabpagecontrolcollectionhowtoadd/cpp/add.cpp#1)]
     [!code-csharp[TabPageControlCollectionHowToAdd#1](~/samples/snippets/csharp/VS_Snippets_Winforms/tabpagecontrolcollectionhowtoadd/cs/add.cs#1)]
     [!code-vb[TabPageControlCollectionHowToAdd#1](~/samples/snippets/visualbasic/VS_Snippets_Winforms/tabpagecontrolcollectionhowtoadd/vb/add.vb#1)]  
  
## See also

- [TabControl Control](tabcontrol-control-windows-forms.md)
- [TabControl Control Overview](tabcontrol-control-overview-windows-forms.md)
- [How to: Change the Appearance of the Windows Forms TabControl](how-to-change-the-appearance-of-the-windows-forms-tabcontrol.md)
- [How to: Disable Tab Pages](how-to-disable-tab-pages.md)
- [How to: Add and Remove Tabs with the Windows Forms TabControl](how-to-add-and-remove-tabs-with-the-windows-forms-tabcontrol.md)
