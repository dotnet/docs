---
title: "Walkthrough: Arranging WPF Content on Windows Forms at Design Time"
ms.date: "03/30/2017"
helpviewer_keywords:
  - "WPF user control [Windows Forms], hosting in a layout panel"
  - "WPF content [Windows Forms], arranging at design time"
  - "Windows Forms, arranging WPF content at design time"
  - "WPF content [Windows Forms], hosting in Windows Forms"
  - "Windows Forms, anchoring and docking WPF content"
  - "interoperability [WPF]"
ms.assetid: 5efb1c53-1484-43d6-aa8a-f4861b99bb8a
author: jillre
ms.author: jillfra
manager: jillfra
---
# Walkthrough: Arrange WPF content on Windows Forms at design time

This article shows you how to use the Windows Forms layout features, such as anchoring and snaplines, to arrange Windows Presentation Foundation (WPF) controls.

## Prerequisites

You need Visual Studio to complete this walkthrough.

## Create the project

Open Visual Studio and create a new Windows Forms Application project in Visual Basic or Visual C# named `ArrangeElementHost`.

> [!NOTE]
> When hosting WPF content, only C# and Visual Basic projects are supported.

## Create the WPF control

After you add a WPF control to the project, you can arrange it on the form.

1. Add a new WPF <xref:System.Windows.Controls.UserControl> to the project. Use the default name for the control type, `UserControl1.xaml`. For more information, see [Walkthrough: Creating New WPF Content on Windows Forms at Design Time](walkthrough-creating-new-wpf-content-on-windows-forms-at-design-time.md).

2. In Design view, make sure that `UserControl1` is selected.

3. In the **Properties** window, set the value of the <xref:System.Windows.FrameworkElement.Width%2A> and <xref:System.Windows.FrameworkElement.Height%2A> properties to **200**.

4. Set the value of the <xref:System.Windows.Controls.Control.Background%2A> property to **Blue**.

5. Build the project.

## Host WPF controls in a layout panel

You can use WPF controls in layout panels in the same way you use other Windows Forms controls.

1. Open `Form1` in the Windows Forms Designer.

2. In the **Toolbox**, drag a <xref:System.Windows.Forms.TableLayoutPanel> control onto the form.

3. On the <xref:System.Windows.Forms.TableLayoutPanel> control's smart tag panel, select **Remove Last Row**.

4. Resize the <xref:System.Windows.Forms.TableLayoutPanel> control to a larger width and height.

5. In the **Toolbox**, double-click `UserControl1` to create an instance of `UserControl1` in the first cell of the <xref:System.Windows.Forms.TableLayoutPanel> control.

   The instance of `UserControl1` is hosted in a new <xref:System.Windows.Forms.Integration.ElementHost> control named `elementHost1`.

6. In the **Toolbox**, double-click `UserControl1` to create another instance in the second cell of the <xref:System.Windows.Forms.TableLayoutPanel> control.

7. In the **Document Outline** window, select `tableLayoutPanel1`.

8. In the **Properties** window, set the value of the <xref:System.Windows.Forms.Control.Padding%2A> property to **10, 10, 10, 10**.

   Both <xref:System.Windows.Forms.Integration.ElementHost> controls are resized to fit into the new layout.

## Use snaplines to align WPF controls

Snaplines enable easy alignment of controls on a form. You can use snaplines to align your WPF controls as well. For more information, see [Walkthrough: Arranging Controls on Windows Forms Using Snaplines](../controls/walkthrough-arranging-controls-on-windows-forms-using-snaplines.md).

1. From the **Toolbox**, drag an instance of `UserControl1` onto the form, and place it in the space beneath the <xref:System.Windows.Forms.TableLayoutPanel> control.

   The instance of `UserControl1` is hosted in a new <xref:System.Windows.Forms.Integration.ElementHost> control named `elementHost3`.

2. Using snaplines, align the left edge of `elementHost3` with the left edge of <xref:System.Windows.Forms.TableLayoutPanel> control.

3. Using snaplines, size `elementHost3` to the same width as the <xref:System.Windows.Forms.TableLayoutPanel> control.

4. Move `elementHost3` toward the <xref:System.Windows.Forms.TableLayoutPanel> control until a center snapline appears between the controls.

5. In the **Properties** window, set the value of the Margin property to **20, 20, 20, 20**.

6. Move the `elementHost3` away from the <xref:System.Windows.Forms.TableLayoutPanel> control until the center snapline appears again. The center snapline now indicates a margin of 20.

7. Move `elementHost3` to the right until its left edge aligns with the left edge of `elementHost1`.

8. Change the width of `elementHost3` until its right edge aligns with the right edge of `elementHost2`.

## Anchor and dock WPF controls

A WPF control hosted on a form has the same anchoring and docking behavior as other Windows Forms controls.

1. Select `elementHost1`.

2. In the **Properties** window, set the <xref:System.Windows.Forms.Control.Anchor%2A> property to **Top, Bottom, Left, Right**.

3. Resize the <xref:System.Windows.Forms.TableLayoutPanel> control to a larger size.

   The `elementHost1` control resizes to fill the cell.

4. Select `elementHost2`.

5. In the **Properties** window, set the value of the <xref:System.Windows.Forms.Control.Dock%2A> property to <xref:System.Windows.Forms.DockStyle.Fill>.

   The `elementHost2` control resizes to fill the cell.

6. Select the <xref:System.Windows.Forms.TableLayoutPanel> control.

7. Set the value of its <xref:System.Windows.Forms.Control.Dock%2A> property to <xref:System.Windows.Forms.DockStyle.Top>.

8. Select `elementHost3`.

9. Set the value of its <xref:System.Windows.Forms.Control.Dock%2A> property to <xref:System.Windows.Forms.DockStyle.Fill>.

   The `elementHost3` control resizes to fill the remaining space on the form.

10. Resize the form.

    All three <xref:System.Windows.Forms.Integration.ElementHost> controls resize appropriately.

    For more information, see [How to: Anchor and Dock Child Controls in a TableLayoutPanel Control](../controls/how-to-anchor-and-dock-child-controls-in-a-tablelayoutpanel-control.md).

## See also

- <xref:System.Windows.Forms.Integration.ElementHost>
- <xref:System.Windows.Forms.Integration.WindowsFormsHost>
- [How to: Anchor and Dock Child Controls in a TableLayoutPanel Control](../controls/how-to-anchor-and-dock-child-controls-in-a-tablelayoutpanel-control.md)
- [How to: Align a Control to the Edges of Forms at Design Time](../controls/how-to-align-a-control-to-the-edges-of-forms-at-design-time.md)
- [Walkthrough: Arranging Controls on Windows Forms Using Snaplines](../controls/walkthrough-arranging-controls-on-windows-forms-using-snaplines.md)
- [Migration and Interoperability](../../wpf/advanced/migration-and-interoperability.md)
- [Using WPF Controls](using-wpf-controls.md)
- [Design XAML in Visual Studio](/visualstudio/xaml-tools/designing-xaml-in-visual-studio)
