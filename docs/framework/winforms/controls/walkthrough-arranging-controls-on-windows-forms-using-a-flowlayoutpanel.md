---
title: "Walkthrough: Arranging Controls on Windows Forms Using a FlowLayoutPanel"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-winforms"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "FlowLayoutPanel control [Windows Forms], walkthroughs"
  - "Windows Forms controls, arranging"
  - "controls [Windows Forms], arranging with FlowLayoutPanel"
  - "layout [Windows Forms], walkthroughs"
ms.assetid: a1744323-0316-49c2-992e-ebfc0a976b85
caps.latest.revision: 22
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Walkthrough: Arranging Controls on Windows Forms Using a FlowLayoutPanel
Some applications require a form with a layout that arranges itself appropriately as the form is resized or as the contents change in size. When you need a dynamic layout and you do not want to handle <xref:System.Windows.Forms.Control.Layout> events explicitly in your code, consider using a layout panel.  
  
 The <xref:System.Windows.Forms.FlowLayoutPanel> control and the <xref:System.Windows.Forms.TableLayoutPanel> control provide intuitive ways to arrange controls on your form. Both provide an automatic, configurable ability to control the relative positions of child controls contained within them, and both give you dynamic layout features at run time, so they can resize and reposition child controls as the dimensions of the parent form change. Layout panels can be nested within layout panels, to enable the realization of sophisticated user interfaces.  
  
 The <xref:System.Windows.Forms.TableLayoutPanel> arranges its contents in a grid, providing functionality similar to the HTML \<table> element. Its cells are arranged in rows and columns, and these can have different sizes. For more information, see [Walkthrough: Arranging Controls on Windows Forms Using a TableLayoutPanel](../../../../docs/framework/winforms/controls/walkthrough-arranging-controls-on-windows-forms-using-a-tablelayoutpanel.md).  
  
 The <xref:System.Windows.Forms.FlowLayoutPanel> arranges its contents in a specific flow direction: horizontal or vertical. Its contents can be wrapped from one row to the next, or from one column to the next. Alternately, its contents can be clipped instead of wrapped. Tasks illustrated in this walkthrough include:  
  
-   Creating a Windows Forms project  
  
-   Arranging Controls Horizontally and Vertically  
  
-   Changing Flow Direction  
  
-   Inserting Flow Breaks  
  
-   Arranging Controls Using Padding and Margins  
  
-   Inserting Controls by Double-clicking Them in the Toolbox  
  
-   Inserting a Control by Drawing Its Outline  
  
-   Inserting Controls Using the Caret  
  
-   Reassigning Existing Controls to a Different Parent  
  
 When you are finished, you will have an understanding of the role played by these important layout features.  
  
> [!NOTE]
>  The dialog boxes and menu commands you see might differ from those described in Help depending on your active settings or edition. To change your settings, choose **Import and Export Settings** on the **Tools** menu. For more information, see [Customizing Development Settings in Visual Studio](http://msdn.microsoft.com/library/22c4debb-4e31-47a8-8f19-16f328d7dcd3).  
  
## Creating the Project  
 The first step is to create the project and set up the form.  
  
#### To create the project  
  
1.  Create a Windows-based application project called "FlowLayoutPanelExample". For more information, see [How to: Create a Windows Application Project](http://msdn.microsoft.com/library/b2f93fed-c635-4705-8d0e-cf079a264efa).  
  
2.  Select the form in the **Forms Designer**.  
  
## Arranging Controls Horizontally and Vertically  
 The <xref:System.Windows.Forms.FlowLayoutPanel> control allows you to place controls along rows or columns without requiring you to precisely specify the position of each individual control.  
  
 The <xref:System.Windows.Forms.FlowLayoutPanel> control can resize or reflow its child controls as the dimensions of the parent form change.  
  
#### To arrange controls horizontally and vertically using a FlowLayoutPanel  
  
1.  Drag a <xref:System.Windows.Forms.FlowLayoutPanel> control from the **Toolbox** onto your form.  
  
2.  Drag a <xref:System.Windows.Forms.Button> control from the **Toolbox** into the <xref:System.Windows.Forms.FlowLayoutPanel>. Note that it is automatically moved to the upper-left corner of the <xref:System.Windows.Forms.FlowLayoutPanel> control.  
  
3.  Drag another <xref:System.Windows.Forms.Button> control from the **Toolbox** into the <xref:System.Windows.Forms.FlowLayoutPanel>. Note that the <xref:System.Windows.Forms.Button> control is automatically moved to a position next to the first <xref:System.Windows.Forms.Button> control. If your <xref:System.Windows.Forms.FlowLayoutPanel> is too narrow to fit the two controls on the same row, the new <xref:System.Windows.Forms.Button> control is automatically moved to the next row.  
  
4.  Drag several more <xref:System.Windows.Forms.Button> controls from the **Toolbox** into the <xref:System.Windows.Forms.FlowLayoutPanel>. Continue placing <xref:System.Windows.Forms.Button> controls until one wraps to the next row.  
  
5.  Change the value of the <xref:System.Windows.Forms.FlowLayoutPanel> control's <xref:System.Windows.Forms.FlowLayoutPanel.WrapContents%2A> property to `false`. Note that the child controls no longer flow to the next row. Instead, they are moved to the first row and clipped.  
  
6.  Change the value of the <xref:System.Windows.Forms.FlowLayoutPanel> control's <xref:System.Windows.Forms.FlowLayoutPanel.WrapContents%2A> property to `true`. Note that the child controls again wrap to the next row.  
  
7.  Decrease the width of the <xref:System.Windows.Forms.FlowLayoutPanel> control until all the <xref:System.Windows.Forms.Button> controls are moved into the first column.  
  
8.  Increase the width of the <xref:System.Windows.Forms.FlowLayoutPanel> control until all the <xref:System.Windows.Forms.Button> controls are moved into the first row. You may need to resize your form to accommodate the greater width.  
  
## Changing Flow Direction  
 The <xref:System.Windows.Forms.FlowLayoutPanel.FlowDirection%2A> property allows you to change the direction in which controls are arranged. You can arrange the child controls from left to right, from right to left, from top to bottom, or from bottom to top.  
  
#### To change the flow direction in a FlowLayoutPanel  
  
1.  Change the value of the <xref:System.Windows.Forms.FlowLayoutPanel> control's <xref:System.Windows.Forms.FlowLayoutPanel.FlowDirection%2A> property to <xref:System.Windows.Forms.FlowDirection.TopDown>. Note that the child controls are rearranged into one or more columns, depending on the height of the control.  
  
2.  Resize the <xref:System.Windows.Forms.FlowLayoutPanel> so its height is shorter than the column of <xref:System.Windows.Forms.Button> controls. Note that the <xref:System.Windows.Forms.FlowLayoutPanel> rearranges the child controls to flow into the next column. Continue decreasing the height and note that the child controls flow into consecutive columns. Change the value of the <xref:System.Windows.Forms.FlowLayoutPanel> control's <xref:System.Windows.Forms.FlowLayoutPanel.FlowDirection%2A> property to <xref:System.Windows.Forms.FlowDirection.RightToLeft>. Note that the positions of the child controls are reversed. Observe the layout when you change the value of the <xref:System.Windows.Forms.FlowLayoutPanel.FlowDirection%2A> property to <xref:System.Windows.Forms.FlowDirection.BottomUp>.  
  
## Inserting Flow Breaks  
 The <xref:System.Windows.Forms.FlowLayoutPanel> control provides a FlowBreak property to its child controls. Setting the value of the FlowBreak property to `true` causes the <xref:System.Windows.Forms.FlowLayoutPanel> control to stop laying out controls in the current flow direction and wrap to the next row or column.  
  
#### To insert flow breaks  
  
1.  Change the value of the <xref:System.Windows.Forms.FlowLayoutPanel> control's <xref:System.Windows.Forms.FlowLayoutPanel.FlowDirection%2A> property to <xref:System.Windows.Forms.FlowDirection.TopDown>.  
  
2.  Select one of the <xref:System.Windows.Forms.Button> controls in the middle of the leftmost column.  
  
3.  Set the value of the <xref:System.Windows.Forms.Button> control's FlowBreak property to `true`. Note that the column is broken and the controls following the selected <xref:System.Windows.Forms.Button> control flow into the next column. Set the value of the <xref:System.Windows.Forms.Button> control's FlowBreak property to `false` to return to the original behavior.  
  
## Positioning Controls Using Docking and Anchoring  
 Docking and anchoring behaviors of child controls differ from the behaviors in other container controls. Both docking and anchoring are relative to the largest control in the flow direction.  
  
#### To position controls using docking and anchoring  
  
1.  Increase the size of the <xref:System.Windows.Forms.FlowLayoutPanel> until the <xref:System.Windows.Forms.Button> controls are all arranged in a column.  
  
2.  Select the top <xref:System.Windows.Forms.Button> control. Increase its width so that it is about twice as wide as the other <xref:System.Windows.Forms.Button> controls.  
  
3.  Select the second <xref:System.Windows.Forms.Button> control. Change the value of its <xref:System.Windows.Forms.Control.Anchor%2A> property to <xref:System.Windows.Forms.AnchorStyles.Right>. Note that it is moved so that its right border is aligned with the first <xref:System.Windows.Forms.Button> control's right border.  
  
4.  Change the value of its <xref:System.Windows.Forms.Control.Anchor%2A> property to <xref:System.Windows.Forms.AnchorStyles.Right> and <xref:System.Windows.Forms.AnchorStyles.Left>. Note that it is sized to the same width as the first <xref:System.Windows.Forms.Button> control.  
  
5.  Select the third <xref:System.Windows.Forms.Button> control. Change the value of its <xref:System.Windows.Forms.Control.Dock%2A> property to <xref:System.Windows.Forms.DockStyle.Fill>. Note that it is sized to the same width as the first <xref:System.Windows.Forms.Button> control.  
  
## Arranging Controls Using Padding and Margins  
 You can also arrange controls in your <xref:System.Windows.Forms.FlowLayoutPanel> control by changing the <xref:System.Windows.Forms.Control.Padding%2A> and <xref:System.Windows.Forms.Control.Margin%2A> properties.  
  
 The <xref:System.Windows.Forms.Control.Padding%2A> property allows you to control the placement of controls within a <xref:System.Windows.Forms.FlowLayoutPanel> control's cell. It specifies the spacing between the child controls and the <xref:System.Windows.Forms.FlowLayoutPanel> control's border.  
  
 The <xref:System.Windows.Forms.Control.Margin%2A> property allows you to control the spacing between controls.  
  
#### To arrange controls using the Padding and Margin properties  
  
1.  Change the value of the <xref:System.Windows.Forms.FlowLayoutPanel> control's <xref:System.Windows.Forms.Control.Dock%2A> property to <xref:System.Windows.Forms.DockStyle.Fill>. If your form is large enough, the <xref:System.Windows.Forms.Button> controls will be moved into the first column of the <xref:System.Windows.Forms.FlowLayoutPanel> control.  
  
2.  Change the value of the <xref:System.Windows.Forms.FlowLayoutPanel> control's <xref:System.Windows.Forms.Control.Padding%2A> property by expanding the <xref:System.Windows.Forms.Control.Padding%2A> entry in the **Properties** window and setting the <xref:System.Windows.Forms.Padding.All%2A> property to **20**. For more information, see [Walkthrough: Laying Out Windows Forms Controls with Padding, Margins, and the AutoSize Property](../../../../docs/framework/winforms/controls/windows-forms-controls-padding-autosize.md). Note that the child controls are moved toward the center of the <xref:System.Windows.Forms.FlowLayoutPanel> control. The increased value for the <xref:System.Windows.Forms.Control.Padding%2A> property pushes the child controls away from the <xref:System.Windows.Forms.FlowLayoutPanel> control's borders.  
  
3.  Select all of the <xref:System.Windows.Forms.Button> controls in the <xref:System.Windows.Forms.FlowLayoutPanel> and set the value of the <xref:System.Windows.Forms.Control.Margin%2A> property to **20**. Note that the spacing between the <xref:System.Windows.Forms.Button> controls increases, so they are moved further apart. You may need to resize the <xref:System.Windows.Forms.FlowLayoutPanel> control to be larger to see all of the child controls.  
  
## Inserting Controls by Double-clicking Them in the Toolbox  
 You can populate your <xref:System.Windows.Forms.FlowLayoutPanel> control by double-clicking controls in the **Toolbox**.  
  
#### To insert controls by double-clicking in the Toolbox  
  
1.  Double-click the <xref:System.Windows.Forms.Button> control icon in the **Toolbox**. Note that a new <xref:System.Windows.Forms.Button> control appears in the <xref:System.Windows.Forms.FlowLayoutPanel> control.  
  
2.  Double-click several more controls in the **Toolbox**. Note that the new controls appear successively in the <xref:System.Windows.Forms.FlowLayoutPanel> control.  
  
## Inserting a Control by Drawing Its Outline  
 You can insert a control into a <xref:System.Windows.Forms.FlowLayoutPanel> control and specify its size by drawing its outline in a cell.  
  
#### To insert a Control by drawing its outline  
  
1.  In the **Toolbox**, click the <xref:System.Windows.Forms.Button> control icon. Do not drag it onto the form.  
  
2.  Move the mouse pointer over the <xref:System.Windows.Forms.FlowLayoutPanel> control. Note that the pointer changes to a crosshair with the <xref:System.Windows.Forms.Button> control icon attached.  
  
3.  Click and hold the mouse button.  
  
4.  Drag the mouse pointer to draw the outline of the <xref:System.Windows.Forms.Button> control. When you are satisfied with the size, release the mouse button. Note that the <xref:System.Windows.Forms.Button> control is created in the next open location of the <xref:System.Windows.Forms.FlowLayoutPanel> control.  
  
## Inserting Controls Using the Insertion Bar  
 You can insert controls at a specific position in a <xref:System.Windows.Forms.FlowLayoutPanel> control. When you drag a control into the <xref:System.Windows.Forms.FlowLayoutPanel> control's client area, an insertion bar appears to indicate where the control will be inserted.  
  
#### To insert a control using the caret  
  
1.  Drag a <xref:System.Windows.Forms.Button> control from the **Toolbox** into the <xref:System.Windows.Forms.FlowLayoutPanel> control and point to the space between two <xref:System.Windows.Forms.Button> controls. Note that an insertion bar is drawn, indicating where the <xref:System.Windows.Forms.Button> will be placed when it is dropped into the <xref:System.Windows.Forms.FlowLayoutPanel> control. Before you drop the new <xref:System.Windows.Forms.Button> control into the <xref:System.Windows.Forms.FlowLayoutPanel> control, move the mouse pointer around to observe how the insertion bar moves.  
  
2.  Drop the new <xref:System.Windows.Forms.Button> control into the <xref:System.Windows.Forms.FlowLayoutPanel> control. Note that the new <xref:System.Windows.Forms.Button> control is not aligned with the others, because its <xref:System.Windows.Forms.Control.Margin%2A> property has a different value.  
  
## Reassigning Existing Controls to a Different Parent  
 You can assign controls that exist on your form to a new <xref:System.Windows.Forms.FlowLayoutPanel> control.  
  
#### To reparent existing controls  
  
1.  Drag three <xref:System.Windows.Forms.Button> controls from the **Toolbox** onto the form. Position them near to each other, but leave them unaligned.  
  
2.  In the **Toolbox**, click the <xref:System.Windows.Forms.FlowLayoutPanel> control icon. Do not drag it onto the form.  
  
3.  Move the mouse pointer close to the three <xref:System.Windows.Forms.Button> controls. Note that the pointer changes to a crosshair with the <xref:System.Windows.Forms.FlowLayoutPanel> control icon attached.  
  
4.  Click and hold the mouse button.  
  
5.  Drag the mouse pointer to draw the outline of the <xref:System.Windows.Forms.FlowLayoutPanel> control. Draw the outline around the three <xref:System.Windows.Forms.Button> controls.  
  
6.  Release the mouse button. Note that the three <xref:System.Windows.Forms.Button> controls are inserted into the <xref:System.Windows.Forms.FlowLayoutPanel> control.  
  
## Next Steps  
 You can achieve a complex layout using a combination of layout panels and controls. Suggestions for more exploration include:  
  
-   Resize one of the <xref:System.Windows.Forms.Button> controls to a larger size and note the effect on the layout.  
  
-   Layout panels can contain other layout panels. Experiment with dropping a <xref:System.Windows.Forms.TableLayoutPanel> control into the existing control.  
  
-   Dock the <xref:System.Windows.Forms.FlowLayoutPanel> control to the parent form. Resize the form and note the effect on the layout.  
  
-   Set the <xref:System.Windows.Forms.Control.Visible%2A> property of one of the controls to `false` and note how the <xref:System.Windows.Forms.FlowLayoutPanel> reflows in response.  
  
## See Also  
 <xref:System.Windows.Forms.FlowLayoutPanel>  
 <xref:System.Windows.Forms.TableLayoutPanel>  
 [Walkthrough: Arranging Controls on Windows Forms Using a TableLayoutPanel](../../../../docs/framework/winforms/controls/walkthrough-arranging-controls-on-windows-forms-using-a-tablelayoutpanel.md)  
 [Walkthrough: Arranging Controls on Windows Forms Using Snaplines](../../../../docs/framework/winforms/controls/walkthrough-arranging-controls-on-windows-forms-using-snaplines.md)  
 [Microsoft Windows User Experience, Official Guidelines for User Interface Developers and Designers. Redmond, WA: Microsoft Press, 1999. (USBN: 0-7356-0566-1)](http://www.microsoft.com/mspress/southpacific/books/book11588.htm)  
 [AutoSize Property Overview](../../../../docs/framework/winforms/controls/autosize-property-overview.md)  
 [How to: Dock Controls on Windows Forms](../../../../docs/framework/winforms/controls/how-to-dock-controls-on-windows-forms.md)  
 [How to: Anchor Controls on Windows Forms](../../../../docs/framework/winforms/controls/how-to-anchor-controls-on-windows-forms.md)  
 [Walkthrough: Laying Out Windows Forms Controls with Padding, Margins, and the AutoSize Property](../../../../docs/framework/winforms/controls/windows-forms-controls-padding-autosize.md)
