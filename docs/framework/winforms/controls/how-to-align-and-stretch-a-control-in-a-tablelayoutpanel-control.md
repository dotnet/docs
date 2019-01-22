---
title: "How to: Align and Stretch a Control in a TableLayoutPanel Control"
ms.date: "03/30/2017"
f1_keywords: 
  - "net.ComponentModel.StyleCollectionEditor.TLP.AlignStretchCtrl"
helpviewer_keywords: 
  - "TableLayoutPanel control [Windows Forms], stretching controls"
  - "controls [Windows Forms], stretching"
  - "controls [Windows Forms], aligning"
ms.assetid: 7dc1a157-6fee-4995-8ebc-b65bdc0909a8
---
# How to: Align and Stretch a Control in a TableLayoutPanel Control
You can align and stretch controls in a <xref:System.Windows.Forms.TableLayoutPanel> with the <xref:System.Windows.Forms.Control.Anchor%2A> and <xref:System.Windows.Forms.Control.Dock%2A> properties.  
  
> [!NOTE]
>  The dialog boxes and menu commands you see might differ from those described in Help depending on your active settings or edition. To change your settings, choose **Import and Export Settings** on the **Tools** menu. For more information, see [Personalize the Visual Studio IDE](/visualstudio/ide/personalizing-the-visual-studio-ide).  
  
### To align and stretch a control  
  
1.  Drag a <xref:System.Windows.Forms.TableLayoutPanel> control from the **Toolbox** onto your form.  
  
2.  Drag a <xref:System.Windows.Forms.Button> control from the **Toolbox** into the upper-left cell of the <xref:System.Windows.Forms.TableLayoutPanel> control. The <xref:System.Windows.Forms.Button> control is centered in the cell.  
  
3.  Set the value of the <xref:System.Windows.Forms.Button> control's <xref:System.Windows.Forms.Control.Anchor%2A> property to `Left,Right`. The <xref:System.Windows.Forms.Button> control stretches to match the width of the cell.  
  
4.  Set the value of the <xref:System.Windows.Forms.Button> control's <xref:System.Windows.Forms.Control.Anchor%2A> property to `Top,Bottom`. The <xref:System.Windows.Forms.Button> control stretches to match the height of the cell.  
  
5.  Set the value of the <xref:System.Windows.Forms.Button> control's <xref:System.Windows.Forms.Control.Dock%2A> property to <xref:System.Windows.Forms.DockStyle.Fill>. The <xref:System.Windows.Forms.Button> control expands to fill the cell.  
  
6.  Set the value of the <xref:System.Windows.Forms.Button> control's <xref:System.Windows.Forms.Control.Dock%2A> property to <xref:System.Windows.Forms.DockStyle.None>. The <xref:System.Windows.Forms.Button> control returns to its original size and moves to the upper-left corner of the cell. The **Windows Forms Designer** has set the <xref:System.Windows.Forms.Control.Anchor%2A> property to `Top, Left`.  
  
7.  Set the value of the <xref:System.Windows.Forms.Button> control's <xref:System.Windows.Forms.Control.Anchor%2A> property to `Bottom,Right`. The <xref:System.Windows.Forms.Button> control moves to the lower-right corner of the cell.  
  
8.  Set the value of the <xref:System.Windows.Forms.Button> control's <xref:System.Windows.Forms.Control.Anchor%2A> property to <xref:System.Windows.Forms.AnchorStyles.None>. The <xref:System.Windows.Forms.Button> control moves to the center of the cell.  
  
## See also
 [TableLayoutPanel Control](../../../../docs/framework/winforms/controls/tablelayoutpanel-control-windows-forms.md)
