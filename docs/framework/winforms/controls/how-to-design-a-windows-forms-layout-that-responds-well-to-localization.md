---
title: "How to: Design a Windows Forms Layout that Responds Well to Localization"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "TableLayoutPanel control [Windows Forms]"
  - "application design [Windows Forms], localization"
  - "Windows Forms, localization"
  - "localization [Windows Forms], Windows Forms layout"
ms.assetid: d13eff2d-701c-4b6e-8838-3885cbfb7223
---
# How to: Design a Windows Forms Layout that Responds Well to Localization
Creating forms that are ready to be localized greatly speeds development for international markets. You can use the <xref:System.Windows.Forms.TableLayoutPanel> control to implement layouts that respond gracefully as controls resize due to changes in their <xref:System.Windows.Forms.Control.Text%2A> property values.  
  
## Example  
 This form demonstrates how to create a layout that proportionally adjusts when you translate displayed string values into other languages. This process of translation is called *localization*. For more information, see [Localization](../../../standard/globalization-localization/localization.md).  
  
 There is extensive support for this task in Visual Studio.  See also [Walkthrough: Creating a Layout That Adjusts Proportion for Localization](https://docs.microsoft.com/previous-versions/visualstudio/visual-studio-2010/7k9fa71y(v=vs.100)).  
  
 [!code-csharp[System.Windows.Forms.TableLayoutPanel.LocalizableForm#1](~/samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.TableLayoutPanel.LocalizableForm/CS/localizableform.cs#1)]
 [!code-vb[System.Windows.Forms.TableLayoutPanel.LocalizableForm#1](~/samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.TableLayoutPanel.LocalizableForm/VB/localizableform.vb#1)]  
  
## Additional resources

1. [How to: Align and Stretch a Control in a TableLayoutPanel Control](how-to-align-and-stretch-a-control-in-a-tablelayoutpanel-control.md)  
  
2. [Walkthrough: Arranging Controls on Windows Forms Using a FlowLayoutPanel](walkthrough-arranging-controls-on-windows-forms-using-a-flowlayoutpanel.md)  

3. [How to: Span Rows and Columns in a TableLayoutPanel Control](how-to-span-rows-and-columns-in-a-tablelayoutpanel-control.md)  
  
4. [How to: Edit Columns and Rows in a TableLayoutPanel Control](how-to-edit-columns-and-rows-in-a-tablelayoutpanel-control.md)  
  
5. [Walkthrough: Performing Common Tasks Using Smart Tags on Windows Forms Controls](performing-common-tasks-using-smart-tags-on-wf-controls.md)  
  
6. [Walkthrough: Arranging Controls on Windows Forms Using a TableLayoutPanel](walkthrough-arranging-controls-on-windows-forms-using-a-tablelayoutpanel.md)  

7. [Walkthrough: Laying Out Windows Forms Controls with Padding, Margins, and the AutoSize Property](windows-forms-controls-padding-autosize.md)  
  
8. [How to: Support Localization on Windows Forms Using AutoSize and the TableLayoutPanel Control](https://docs.microsoft.com/previous-versions/visualstudio/visual-studio-2010/1zkt8b33(v=vs.100))  
  
9. [Walkthrough: Creating a Resizable Windows Form for Data Entry](https://docs.microsoft.com/previous-versions/visualstudio/visual-studio-2010/991eahec(v=vs.100))  
  
## Compiling the Code  
 This example requires:  
  
- References to the System, System.Data, System.Drawing and System.Windows.Forms assemblies.  
  
## See also

- <xref:System.Windows.Forms.TableLayoutPanel>
- <xref:System.Windows.Forms.FlowLayoutPanel>
- [Localization](../../../standard/globalization-localization/localization.md)
