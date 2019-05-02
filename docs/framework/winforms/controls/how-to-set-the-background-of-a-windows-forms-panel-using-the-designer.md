---
title: "How to: Set the Background of a Windows Forms Panel Using the Designer"
ms.date: "03/30/2017"
helpviewer_keywords:
  - "background colors [Windows Forms], Windows Forms Panel controls"
  - "background images [Windows Forms], Windows Forms Panel controls"
  - "Panel control [Windows Forms], background"
  - "colors [Windows Forms], Windows Forms Panel controls"
ms.assetid: db83cf54-3c69-4b08-ac6c-25b9b5abb1b0
---
# How to: Set the background of a Windows Forms panel using the Designer

A Windows Forms <xref:System.Windows.Forms.Panel> control can display both a background color and a background image. The <xref:System.Windows.Forms.Control.BackColor%2A> property sets the background color for controls that are contained in the panel, such as labels and radio buttons. If the <xref:System.Windows.Forms.Control.BackgroundImage%2A> property is not set, the <xref:System.Windows.Forms.Control.BackColor%2A> selection will fill all of the panel. If the <xref:System.Windows.Forms.Control.BackgroundImage%2A> property is set, the image will be displayed behind the controls that are contained in the panel.

The following procedure requires a **Windows Application** project with a form that contains a <xref:System.Windows.Forms.Panel> control. For information about how to set up such a project in Visual Studio, see [How to: Create a Windows Forms application project](/visualstudio/ide/step-1-create-a-windows-forms-application-project) and [How to: Add Controls to Windows Forms](how-to-add-controls-to-windows-forms.md).

## Set the background in the Windows Forms Designer

1. Open the project in Visual Studio and select the <xref:System.Windows.Forms.Panel> control.

2. In the **Properties** window, click the arrow button next to the <xref:System.Windows.Forms.Control.BackColor%2A> property to display a window with three tabs.

3. Select the **Custom** tab to display a palette of colors.

4. Select the **Web** or **System** tab to display a list of predefined names for colors, and then select a color.

5. In the **Properties** window, click the arrow button next to the <xref:System.Windows.Forms.Control.BackgroundImage%2A> property.

6. In the **Open** dialog box, select the file that you want to display.

## See also

- <xref:System.Windows.Forms.Control.BackColor%2A>
- <xref:System.Windows.Forms.Control.BackgroundImage%2A>
- [Panel Control](panel-control-windows-forms.md)
- [Panel Control Overview](panel-control-overview-windows-forms.md)
- [How to: Group Controls with the Windows Forms Panel Control Using the Designer](group-controls-with-wf-panel-control-using-the-designer.md)
