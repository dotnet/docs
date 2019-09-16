---
title: "How to: Define an Icon for a ToolBar Button Using the Designer"
ms.date: "03/30/2017"
helpviewer_keywords:
  - "toolbars [Windows Forms], adding icons to buttons"
  - "examples [Windows Forms], toolbars"
  - "images [Windows Forms], toolbar buttons"
  - "buttons [Windows Forms], images"
  - "icons [Windows Forms], toolbar buttons"
  - "ToolBar control [Windows Forms], adding icons to buttons"
ms.assetid: d848f38e-67f2-49d4-8e88-01c845c06c02
---
# How to: Define an Icon for a ToolBar Button Using the Designer

> [!NOTE]
> The <xref:System.Windows.Forms.ToolStrip> control replaces and adds functionality to the <xref:System.Windows.Forms.ToolBar> control; however, the <xref:System.Windows.Forms.ToolBar> control is retained for both backward compatibility and future use, if you choose.

<xref:System.Windows.Forms.ToolBar> buttons are able to display icons within them for easy identification by users. This is achieved through adding images to the <xref:System.Windows.Forms.ImageList> component and associating it with the <xref:System.Windows.Forms.ToolBar> control.

The following procedure requires a **Windows Application** project with a form containing a <xref:System.Windows.Forms.ToolBar> control and an <xref:System.Windows.Forms.ImageList> component. For information about setting up such a project, see [How to: Create a Windows Forms application project](/visualstudio/ide/step-1-create-a-windows-forms-application-project) and [How to: Add Controls to Windows Forms](how-to-add-controls-to-windows-forms.md).

### To set an icon for a toolbar button at design time

1. Add images to the <xref:System.Windows.Forms.ImageList> component. For more information, see [How to: Add or Remove ImageList Images with the Designer](how-to-add-or-remove-imagelist-images-with-the-designer.md).

2. Select the <xref:System.Windows.Forms.ToolBar> control on your form.

3. In the **Properties** window, set the <xref:System.Windows.Forms.ToolBar> control's <xref:System.Windows.Forms.ToolBar.ImageList%2A> property to the <xref:System.Windows.Forms.ImageList> component.

4. Click the <xref:System.Windows.Forms.ToolBar> control's <xref:System.Windows.Forms.ToolBar.Buttons%2A> property to select it, and click the ellipsis (![The Ellipsis button (...) in the Properties window of Visual Studio.](./media/visual-studio-ellipsis-button.png)) button to open the **ToolBarButton Collection Editor**.

5. Use the **Add** button to add buttons to the <xref:System.Windows.Forms.ToolBar> control.

6. In the **Properties** window that appears in the pane on the right side of the **ToolBarButton Collection Editor**, set the <xref:System.Windows.Forms.ToolBarButton.ImageIndex%2A> property of each toolbar button to one of the values in the list, which is drawn from the images you added to the <xref:System.Windows.Forms.ImageList> component.

## See also

- <xref:System.Windows.Forms.ToolBar>
- [How to: Trigger Menu Events for Toolbar Buttons](how-to-trigger-menu-events-for-toolbar-buttons.md)
- [ToolBar Control](toolbar-control-windows-forms.md)
- [ImageList Component](imagelist-component-windows-forms.md)
