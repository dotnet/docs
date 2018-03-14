---
title: "Walkthrough: Arranging Controls on Windows Forms Using a TableLayoutPanel"
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
  - "controls [Windows Forms], arranging with TableLayoutPanel"
  - "TableLayoutPanel control [Windows Forms], walkthroughs"
  - "Windows Forms controls, arranging"
ms.assetid: d474885e-12cc-4ab7-b997-2a23a643049b
caps.latest.revision: 28
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Walkthrough: Arranging Controls on Windows Forms Using a TableLayoutPanel
Some applications require a form with a layout that arranges itself appropriately as the form is resized or as the contents change in size. When you need a dynamic layout and you do not want to handle <xref:System.Windows.Forms.Control.Layout> events explicitly in your code, consider using a layout panel.  
  
 The <xref:System.Windows.Forms.FlowLayoutPanel> control and the <xref:System.Windows.Forms.TableLayoutPanel> control provide intuitive ways to arrange controls on your form. Both provide an automatic, configurable ability to control the relative positions of child controls contained within them, and both give you dynamic layout features at run time, so they can resize and reposition child controls as the dimensions of the parent form change. Layout panels can be nested within layout panels, to enable the realization of sophisticated user interfaces.  
  
 The <xref:System.Windows.Forms.FlowLayoutPanel> arranges its contents in a specific flow direction: horizontal or vertical. Its contents can be wrapped from one row to the next, or from one column to the next. Alternately, its contents can be clipped instead of wrapped. For more information, see [Walkthrough: Arranging Controls on Windows Forms Using a FlowLayoutPanel](../../../../docs/framework/winforms/controls/walkthrough-arranging-controls-on-windows-forms-using-a-flowlayoutpanel.md).  
  
 The <xref:System.Windows.Forms.TableLayoutPanel> arranges its contents in a grid, providing functionality similar to the HTML \<table> element. The <xref:System.Windows.Forms.TableLayoutPanel> control allows you to place controls in a grid layout without requiring you to precisely specify the position of each individual control. Its cells are arranged in rows and columns, and these can have different sizes. Cells can be merged across rows and columns. Cells can contain anything a form can contain and behave in most other respects as containers.  
  
 The <xref:System.Windows.Forms.TableLayoutPanel> control also provides a proportional resizing capability at run time, so your layout can change smoothly as your form is resized. This makes the <xref:System.Windows.Forms.TableLayoutPanel> control well suited for purposes such as data-entry forms and localized applications. For more information, see [Walkthrough: Creating a Resizable Windows Form for Data Entry](http://msdn.microsoft.com/library/e193b4fc-912a-4917-b036-b76c7a6f58ab) and [Walkthrough: Creating a Localizable Windows Form](http://msdn.microsoft.com/library/c5240b6e-aaca-4286-9bae-778a416edb9c).  
  
 In general, you should not use a <xref:System.Windows.Forms.TableLayoutPanel> control as a container for the whole layout. Use <xref:System.Windows.Forms.TableLayoutPanel> controls to provide proportional resizing capabilities to parts of the layout.  
  
 Tasks illustrated in this walkthrough include:  
  
-   Creating a Windows Forms project  
  
-   Arranging Controls in Rows and Columns  
  
-   Setting Row and Column Properties  
  
-   Spanning Rows and Columns with a Control  
  
-   Automatic Handling of Overflows  
  
-   Inserting Controls by Double-clicking Them in the Toolbox  
  
-   Inserting a Control by Drawing Its Outline  
  
-   Reassigning Existing Controls to a Different Parent  
  
 When you are finished, you will have an understanding of the role played by these important layout features.  
  
> [!NOTE]
>  The dialog boxes and menu commands you see might differ from those described in Help depending on your active settings or edition. To change your settings, choose **Import and Export Settings** on the **Tools** menu. For more information, see [Customizing Development Settings in Visual Studio](http://msdn.microsoft.com/library/22c4debb-4e31-47a8-8f19-16f328d7dcd3).  
  
## Creating the Project  
 The first step is to create the project and set up the form.  
  
#### To create the project  
  
1.  Create a Windows Application project called "TableLayoutPanelExample". For more information, see [How to: Create a Windows Application Project](http://msdn.microsoft.com/library/b2f93fed-c635-4705-8d0e-cf079a264efa) .  
  
2.  Select the form in the **Windows** **Forms Designer**.  
  
## Arranging Controls in Rows and Columns  
 The <xref:System.Windows.Forms.TableLayoutPanel> control allows you to easily arrange controls into rows and columns.  
  
#### To arrange controls in rows and columns using a TableLayoutPanel  
  
1.  Drag a <xref:System.Windows.Forms.TableLayoutPanel> control from the **Toolbox** onto your form. Note that, by default, the <xref:System.Windows.Forms.TableLayoutPanel> control has four cells.  
  
2.  Drag a <xref:System.Windows.Forms.Button> control from the **Toolbox** into the <xref:System.Windows.Forms.TableLayoutPanel> control and drop it into one of the cells. Note that the <xref:System.Windows.Forms.Button> control is created within the cell you selected.  
  
3.  Drag three more <xref:System.Windows.Forms.Button> controls from the **Toolbox** into the <xref:System.Windows.Forms.TableLayoutPanel> control, so that each cell contains a button.  
  
4.  Grab the vertical sizing handle between the two columns and move it to the left. Note that the <xref:System.Windows.Forms.Button> controls in the first column are resized to a smaller width, while size of the <xref:System.Windows.Forms.Button> controls in the second column is unchanged.  
  
5.  Grab the vertical sizing handle between the two columns and move it to the right. Note that the <xref:System.Windows.Forms.Button> controls in the first column return to their original size, while the <xref:System.Windows.Forms.Button> controls in the second column are moved to the right.  
  
6.  Move the horizontal sizing handle up and down to see the effect on the controls in the panel.  
  
## Positioning Controls Within Cells Using Docking and Anchoring  
 The anchoring behavior of child controls in a <xref:System.Windows.Forms.TableLayoutPanel> differs from the behavior in other container controls. The docking behavior of child controls is the same as other container controls.  
  
#### Positioning controls within cells  
  
1.  Select the first <xref:System.Windows.Forms.Button> control. Change the value of its <xref:System.Windows.Forms.Control.Dock%2A> property to <xref:System.Windows.Forms.DockStyle.Fill>. Note that the <xref:System.Windows.Forms.Button> control expands to fill its cell.  
  
2.  Select one of the other <xref:System.Windows.Forms.Button> controls. Change the value of its <xref:System.Windows.Forms.Control.Anchor%2A> property to <xref:System.Windows.Forms.AnchorStyles.Right>. Note that it is moved so that its right border is near the right border of the cell. The distance between the borders is the sum of the <xref:System.Windows.Forms.Button> control's <xref:System.Windows.Forms.Control.Margin%2A> property and the panel's <xref:System.Windows.Forms.Control.Padding%2A> property.  
  
3.  Change the value of the <xref:System.Windows.Forms.Button> control's <xref:System.Windows.Forms.Control.Anchor%2A> property to <xref:System.Windows.Forms.AnchorStyles.Right> and <xref:System.Windows.Forms.AnchorStyles.Left>. Note that the control is sized to the width of the cell, with the <xref:System.Windows.Forms.Control.Margin%2A> and <xref:System.Windows.Forms.Control.Padding%2A> values taken into account.  
  
4.  Repeat steps 2 and 3 with the <xref:System.Windows.Forms.AnchorStyles.Top> and <xref:System.Windows.Forms.AnchorStyles.Bottom> styles.  
  
## Setting Row and Column Properties  
 You can set individual properties of rows and columns by using the <xref:System.Windows.Forms.TableLayoutPanel.RowStyles%2A> and <xref:System.Windows.Forms.TableLayoutPanel.ColumnStyles%2A> collections.  
  
#### To set row and column properties  
  
1.  Select the <xref:System.Windows.Forms.TableLayoutPanel> control in the **Windows Forms Designer**.  
  
2.  In the **Properties** windows, open the <xref:System.Windows.Forms.TableLayoutPanel.ColumnStyles%2A> collection by clicking the ellipsis (![VisualStudioEllipsesButton screenshot](../../../../docs/framework/winforms/media/vbellipsesbutton.png "vbEllipsesButton")) button next to the **Columns** entry.  
  
3.  Select the first column and change the value of its <xref:System.Windows.Forms.TableLayoutStyle.SizeType%2A> property to <xref:System.Windows.Forms.SizeType.AutoSize>. Click **OK** to accept the change. Note that the width of the first column is reduced to fit the <xref:System.Windows.Forms.Button> control. Also note that the width of the column is not resizable.  
  
4.  In the **Properties** window, open the <xref:System.Windows.Forms.TableLayoutPanel.ColumnStyles%2A> collection and select the first column. Change the value of its <xref:System.Windows.Forms.TableLayoutStyle.SizeType%2A> property to <xref:System.Windows.Forms.SizeType.Percent>. Click **OK** to accept the change. Resize the <xref:System.Windows.Forms.TableLayoutPanel> control to a larger width and note that the width of the first column expands. Resize the <xref:System.Windows.Forms.TableLayoutPanel> control to a smaller width and note that the buttons in the first column are sized to fit the cell. Also note that the width of the column is resizable.  
  
5.  In the **Properties** window, open the <xref:System.Windows.Forms.TableLayoutPanel.ColumnStyles%2A> collection and select all the listed columns. Set the value of every <xref:System.Windows.Forms.TableLayoutStyle.SizeType%2A> property to <xref:System.Windows.Forms.SizeType.Percent>. Click **OK** to accept the change. Repeat with the <xref:System.Windows.Forms.TableLayoutPanel.RowStyles%2A> collection.  
  
6.  Grab one of the corner resizing handles and resize both the width and height of the <xref:System.Windows.Forms.TableLayoutPanel> control. Note that the rows and columns are resized as the <xref:System.Windows.Forms.TableLayoutPanel> control's size changes. Also note that the rows and columns are resizable with the horizontal and vertical sizing handles.  
  
## Spanning Rows and Columns with a Control  
 The <xref:System.Windows.Forms.TableLayoutPanel> control adds several new properties to controls at design time. Two of these properties are `RowSpan` and `ColumnSpan`. You can use these properties to make a control span more than one row or column.  
  
#### To span rows and columns with a control  
  
1.  Select the <xref:System.Windows.Forms.Button> control in the first row and first column.  
  
2.  In the **Properties** windows, change the value of the `ColumnSpan` property to **2**. Note that the <xref:System.Windows.Forms.Button> control fills the first column and the second column. Also note than an extra row has been added to accommodate this change.  
  
3.  Repeat step 2 for the `RowSpan` property.  
  
## Inserting Controls by Double-clicking Them in the Toolbox  
 You can populate your <xref:System.Windows.Forms.TableLayoutPanel> control by double-clicking controls in the **Toolbox**.  
  
#### To insert controls by double-clicking in the Toolbox  
  
1.  Drag a <xref:System.Windows.Forms.TableLayoutPanel> control from the **Toolbox** onto your form.  
  
2.  Double-click the <xref:System.Windows.Forms.Button> control icon in the **Toolbox**. Note that a new button control appears in the <xref:System.Windows.Forms.TableLayoutPanel> control's first cell.  
  
3.  Double-click several more controls in the **Toolbox**. Note that the new controls appear successively in the <xref:System.Windows.Forms.TableLayoutPanel> control's unoccupied cells. Also note that the <xref:System.Windows.Forms.TableLayoutPanel> control expands to accommodate the new controls if no open cells are available.  
  
## Automatic Handling of Overflows  
 When you are inserting controls into the <xref:System.Windows.Forms.TableLayoutPanel> control, you may run out of empty cells for your new controls. The <xref:System.Windows.Forms.TableLayoutPanel> control handles this situation automatically by increasing the number of cells.  
  
#### To observe automatic handling of overflows  
  
1.  If there are still empty cells in the <xref:System.Windows.Forms.TableLayoutPanel> control, continue inserting new <xref:System.Windows.Forms.Button> controls until the <xref:System.Windows.Forms.TableLayoutPanel> control is full.  
  
2.  Once the <xref:System.Windows.Forms.TableLayoutPanel> control is full, double-click the <xref:System.Windows.Forms.Button> icon in the **Toolbox** to insert another <xref:System.Windows.Forms.Button> control. Note that the <xref:System.Windows.Forms.TableLayoutPanel> control creates new cells to accommodate the new control. Insert a few more controls and observe the resizing behavior.  
  
3.  Change the value of the <xref:System.Windows.Forms.TableLayoutPanel> control's <xref:System.Windows.Forms.TableLayoutPanel.GrowStyle%2A> property to <xref:System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize>. Double-click the <xref:System.Windows.Forms.Button> icon in the **Toolbox** to insert <xref:System.Windows.Forms.Button> controls until the <xref:System.Windows.Forms.TableLayoutPanel> control is full. Double-click the <xref:System.Windows.Forms.Button> icon in the **Toolbox** again. Note that you receive an error message from the **Windows Forms Designer** informing you that additional rows and columns cannot be created.  
  
## Inserting a Control by Drawing Its Outline  
 You can insert a control into a <xref:System.Windows.Forms.TableLayoutPanel> control and specify its size by drawing its outline in a cell.  
  
#### To insert a Control by drawing its outline  
  
1.  Drag a <xref:System.Windows.Forms.TableLayoutPanel> control from the **Toolbox** onto your form.  
  
2.  In the **Toolbox**, click the <xref:System.Windows.Forms.Button> control icon. Do not drag it onto the form.  
  
3.  Move the mouse pointer over the <xref:System.Windows.Forms.TableLayoutPanel> control. Note that the pointer changes to a crosshair with the <xref:System.Windows.Forms.Button> control icon attached.  
  
4.  Click and hold the mouse button.  
  
5.  Drag the mouse pointer to draw the outline of the <xref:System.Windows.Forms.Button> control. When you are satisfied with the size, release the mouse button. Note that the <xref:System.Windows.Forms.Button> control is created in the cell in which you drew the control's outline.  
  
## Multiple Controls Within Cells Are Not Permitted  
 The <xref:System.Windows.Forms.TableLayoutPanel> control can contain only one child control per cell.  
  
#### To demonstrate that multiple controls within cells are not permitted  
  
-   Drag a <xref:System.Windows.Forms.Button> control from the **Toolbox** into the <xref:System.Windows.Forms.TableLayoutPanel> control and drop it into one of the occupied cells. Note that the <xref:System.Windows.Forms.TableLayoutPanel> control does not allow you to drop the <xref:System.Windows.Forms.Button> control into the occupied cell.  
  
## Swapping Controls  
 The <xref:System.Windows.Forms.TableLayoutPanel> control enables you to swap the controls occupying two different cells.  
  
#### To swap controls  
  
-   Drag one of the <xref:System.Windows.Forms.Button> controls from an occupied cell and drop into onto another occupied cell. Note that the two controls are moved from one cell into the other.  
  
## Next Steps  
 You can achieve a complex layout using a combination of layout panels and controls. Suggestions for more exploration include:  
  
-   Try resizing one of the <xref:System.Windows.Forms.Button> controls to a larger size and note the effect on the layout.  
  
-   Paste a selection of multiple controls into the <xref:System.Windows.Forms.TableLayoutPanel> control and note how the controls are inserted.  
  
-   Layout panels can contain other layout panels. Experiment with dropping a <xref:System.Windows.Forms.TableLayoutPanel> control into the existing control.  
  
-   Dock the <xref:System.Windows.Forms.TableLayoutPanel> control to the parent form. Resize the form and note the effect on the layout.  
  
## See Also  
 <xref:System.Windows.Forms.FlowLayoutPanel>  
 <xref:System.Windows.Forms.TableLayoutPanel>  
 [Walkthrough: Arranging Controls on Windows Forms Using a FlowLayoutPanel](../../../../docs/framework/winforms/controls/walkthrough-arranging-controls-on-windows-forms-using-a-flowlayoutpanel.md)  
 [Walkthrough: Arranging Controls on Windows Forms Using Snaplines](../../../../docs/framework/winforms/controls/walkthrough-arranging-controls-on-windows-forms-using-snaplines.md)  
 [Microsoft Windows User Experience, Official Guidelines for User Interface Developers and Designers. Redmond, WA: Microsoft Press, 1999. (USBN: 0-7356-0566-1)](http://www.microsoft.com/mspress/southpacific/books/book11588.htm)  
 [Walkthrough: Creating a Resizable Windows Form for Data Entry](http://msdn.microsoft.com/library/e193b4fc-912a-4917-b036-b76c7a6f58ab)  
 [Walkthrough: Creating a Localizable Windows Form](http://msdn.microsoft.com/library/c5240b6e-aaca-4286-9bae-778a416edb9c)  
 [Best Practices for the TableLayoutPanel Control](../../../../docs/framework/winforms/controls/best-practices-for-the-tablelayoutpanel-control.md)  
 [AutoSize Property Overview](../../../../docs/framework/winforms/controls/autosize-property-overview.md)  
 [How to: Dock Controls on Windows Forms](../../../../docs/framework/winforms/controls/how-to-dock-controls-on-windows-forms.md)  
 [How to: Anchor Controls on Windows Forms](../../../../docs/framework/winforms/controls/how-to-anchor-controls-on-windows-forms.md)  
 [Walkthrough: Laying Out Windows Forms Controls with Padding, Margins, and the AutoSize Property](../../../../docs/framework/winforms/controls/windows-forms-controls-padding-autosize.md)
