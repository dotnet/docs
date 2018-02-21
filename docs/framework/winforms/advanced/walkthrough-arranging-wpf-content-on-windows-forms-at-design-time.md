---
title: "Walkthrough: Arranging WPF Content on Windows Forms at Design Time"
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
  - "WPF user control [Windows Forms], hosting in a layout panel"
  - "WPF content [Windows Forms], arranging at design time"
  - "Windows Forms, arranging WPF content at design time"
  - "WPF content [Windows Forms], hosting in Windows Forms"
  - "Windows Forms, anchoring and docking WPF content"
  - "interoperability [WPF]"
ms.assetid: 5efb1c53-1484-43d6-aa8a-f4861b99bb8a
caps.latest.revision: 20
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Walkthrough: Arranging WPF Content on Windows Forms at Design Time
This walkthrough shows you how to use the Windows Forms layout features, such as anchoring and snaplines, to arrange Windows Presentation Foundation (WPF) controls.  
  
 In this walkthrough, you perform the following tasks:  
  
-   Create the project.  
  
-   Create the WPF control.  
  
-   Host WPF controls in a layout panel.  
  
-   Use snaplines to align WPF controls.  
  
-   Anchor and dock WPF controls.  
  
> [!NOTE]
>  The dialog boxes and menu commands you see might differ from those described in Help depending on your active settings or edition. To change your settings, choose **Import and Export Settings** on the **Tools** menu. For more information, see [Customizing Development Settings in Visual Studio](http://msdn.microsoft.com/library/22c4debb-4e31-47a8-8f19-16f328d7dcd3).  
  
## Prerequisites  
 You need the following components to complete this walkthrough:  
  
-   [!INCLUDE[vs_dev11_long](../../../../includes/vs-dev11-long-md.md)].  
  
## Creating the Project  
 The first step is to create the Windows Forms project.  
  
> [!NOTE]
>  When hosting WPF content, only C# and Visual Basic projects are supported.  
  
#### To create the project  
  
-   Create a new Windows Forms Application project in Visual Basic or Visual C# named `ArrangeElementHost`.  
  
## Creating the WPF Control  
 After you add a WPF control to the project, you can arrange it on the form.  
  
#### To create WPF controls  
  
1.  Add a new WPF <xref:System.Windows.Controls.UserControl> to the project. Use the default name for the control type, `UserControl1.xaml`. For more information, see [Walkthrough: Creating New WPF Content on Windows Forms at Design Time](../../../../docs/framework/winforms/advanced/walkthrough-creating-new-wpf-content-on-windows-forms-at-design-time.md).  
  
2.  In Design view, make sure that `UserControl1` is selected. For more information, see [How to: Select and Move Elements on the Design Surface](http://msdn.microsoft.com/library/54cb70b6-b35b-46e4-a0cc-65189399c474).  
  
3.  In the **Properties** window, set the value of the <xref:System.Windows.FrameworkElement.Width%2A> and <xref:System.Windows.FrameworkElement.Height%2A> properties to `200`.  
  
4.  Set the value of the <xref:System.Windows.Controls.Control.Background%2A> property to `Blue`.  
  
5.  Build the project.  
  
## Hosting WPF Controls in a Layout Panel  
 You can use WPF controls in layout panels in the same way you use other Windows Forms controls.  
  
#### To host WPF controls in a layout panel  
  
1.  Open `Form1` in the Windows Forms Designer.  
  
2.  In the **Toolbox**, drag a <xref:System.Windows.Forms.TableLayoutPanel> control onto the form.  
  
3.  On the <xref:System.Windows.Forms.TableLayoutPanel> control's smart tag panel, select **Remove Last Row**.  
  
4.  Resize the <xref:System.Windows.Forms.TableLayoutPanel> control to a larger width and height.  
  
5.  In the **Toolbox**, double-click `UserControl1` to create an instance of `UserControl1` in the first cell of the <xref:System.Windows.Forms.TableLayoutPanel> control.  
  
     The instance of `UserControl1` is hosted in a new <xref:System.Windows.Forms.Integration.ElementHost> control named `elementHost1`.  
  
6.  In the **Toolbox**, double-click `UserControl1` to create another instance in the second cell of the <xref:System.Windows.Forms.TableLayoutPanel> control.  
  
7.  In the **Document Outline** window, select `tableLayoutPanel1`. For more information, see [Document Outline Window](http://msdn.microsoft.com/library/9054f2bc-f6f8-4242-9fe0-be71089b12f8).  
  
8.  In the **Properties** window, set the value of the <xref:System.Windows.Forms.Control.Padding%2A> property to `10, 10, 10, 10`.  
  
     Both <xref:System.Windows.Forms.Integration.ElementHost> controls are resized to fit into the new layout.  
  
## Using Snaplines to Align WPF Controls  
 Snaplines enable easy alignment of controls on a form. You can use snaplines to align your WPF controls as well. For more information, see [Walkthrough: Arranging Controls on Windows Forms Using Snaplines](../../../../docs/framework/winforms/controls/walkthrough-arranging-controls-on-windows-forms-using-snaplines.md).  
  
#### To use snaplines to align WPF controls  
  
1.  From the **Toolbox**, drag an instance of `UserControl1` onto the form and place it in the space beneath the <xref:System.Windows.Forms.TableLayoutPanel> control.  
  
     The instance of `UserControl1` is hosted in a new <xref:System.Windows.Forms.Integration.ElementHost> control named `elementHost3`.  
  
2.  Using snaplines, align the left edge of `elementHost3` with the left edge of <xref:System.Windows.Forms.TableLayoutPanel> control.  
  
3.  Using snaplines, size `elementHost3` to the same width as the <xref:System.Windows.Forms.TableLayoutPanel> control.  
  
4.  Move `elementHost3` toward the <xref:System.Windows.Forms.TableLayoutPanel> control until a center snapline appears between the controls.  
  
5.  In the **Properties** window, set the value of the Margin property to `20, 20, 20, 20`.  
  
6.  Move the `elementHost3` away from the <xref:System.Windows.Forms.TableLayoutPanel> control until the center snapline appears again. The center snapline now indicates a margin of 20.  
  
7.  Move `elementHost3` to the right, until its left edge aligns with the left edge of `elementHost1`.  
  
8.  Change the width of `elementHost3` until its right edge aligns with the right edge of `elementHost2`.  
  
## Anchoring and Docking WPF Controls  
 A WPF control hosted on a form has the same anchoring and docking behavior as other Windows Forms controls.  
  
#### To anchor and dock WPF controls  
  
1.  Select `elementHost1`.  
  
2.  In the **Properties** window, set the <xref:System.Windows.Forms.Control.Anchor%2A> property to **Top, Bottom, Left, Right**.  
  
3.  Resize the <xref:System.Windows.Forms.TableLayoutPanel> control to a larger size.  
  
     The `elementHost1` control resizes to fill the cell.  
  
4.  Select `elementHost2`.  
  
5.  In the **Properties** window, set the value of the <xref:System.Windows.Forms.Control.Dock%2A> property to <xref:System.Windows.Forms.DockStyle.Fill>.  
  
     The `elementHost2` control resizes to fill the cell.  
  
6.  Select the <xref:System.Windows.Forms.TableLayoutPanel> control.  
  
7.  Set the value of its <xref:System.Windows.Forms.Control.Dock%2A> property to <xref:System.Windows.Forms.DockStyle.Top>.  
  
8.  Select `elementHost3`.  
  
9. Set the value of its <xref:System.Windows.Forms.Control.Dock%2A> property to <xref:System.Windows.Forms.DockStyle.Fill>.  
  
     The `elementHost3` control resizes to fill the remaining space on the form.  
  
10. Resize the form.  
  
     All three <xref:System.Windows.Forms.Integration.ElementHost> controls resize appropriately.  
  
     For more information, see [How to: Anchor and Dock Child Controls in a TableLayoutPanel Control](../../../../docs/framework/winforms/controls/how-to-anchor-and-dock-child-controls-in-a-tablelayoutpanel-control.md).  
  
## See Also  
 <xref:System.Windows.Forms.Integration.ElementHost>  
 <xref:System.Windows.Forms.Integration.WindowsFormsHost>  
 [How to: Anchor and Dock Child Controls in a TableLayoutPanel Control](../../../../docs/framework/winforms/controls/how-to-anchor-and-dock-child-controls-in-a-tablelayoutpanel-control.md)  
 [How to: Align a Control to the Edges of Forms at Design Time](../../../../docs/framework/winforms/controls/how-to-align-a-control-to-the-edges-of-forms-at-design-time.md)  
 [Walkthrough: Arranging Controls on Windows Forms Using Snaplines](../../../../docs/framework/winforms/controls/walkthrough-arranging-controls-on-windows-forms-using-snaplines.md)  
 [Migration and Interoperability](../../../../docs/framework/wpf/advanced/migration-and-interoperability.md)  
 [Using WPF Controls](../../../../docs/framework/winforms/advanced/using-wpf-controls.md)  
 [WPF Designer](http://msdn.microsoft.com/library/c6c65214-8411-4e16-b254-163ed4099c26)
