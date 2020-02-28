---
title: "How to: Copy and Paste an ElementHost Control at Design Time"
ms.date: "03/30/2017"
helpviewer_keywords:
  - "Windows Forms, content copying and pasting"
  - "interoperability [WPF]"
  - "ElementHost control [Windows Forms], copying and pasting at design time"
  - "WPF user control [Windows Forms], hosting in Windows Forms"
ms.assetid: e570375d-2a68-44ba-b4f7-c781af2d20e8
author: jillre
ms.author: jillfra
manager: jillfra
---
# How to: Copy and paste an ElementHost control

This procedure shows you how to copy a Windows Presentation Foundation (WPF) control on a Windows Form in Visual Studio.

1. In Visual Studio, add a new WPF <xref:System.Windows.Controls.UserControl> to a Windows Forms project. Use the default name for the control type, `UserControl1.xaml`. For more information, see [Walkthrough: Creating New WPF Content on Windows Forms at Design Time](walkthrough-creating-new-wpf-content-on-windows-forms-at-design-time.md).

2. In the **Properties** window, set the value of the <xref:System.Windows.FrameworkElement.Width%2A> and <xref:System.Windows.FrameworkElement.Height%2A> properties of `UserControl1` to **200**.

3. Set the value of the <xref:System.Windows.Controls.Control.Background%2A> property to **Blue**.

4. Build the project.

5. Open `Form1` in the Windows Forms Designer.

6. From the **Toolbox**, drag an instance of `UserControl1` onto the form.

   An instance of `UserControl1` is hosted in a new <xref:System.Windows.Forms.Integration.ElementHost> control named `elementHost1`.

7. With `elementHost1` selected, press **Ctrl**+**C** to copy it to the clipboard.

8. Press **Ctrl**+**V** to paste the copied control onto the form.

   A new <xref:System.Windows.Forms.Integration.ElementHost> control named `elementHost2` is created on the form.

## See also

- <xref:System.Windows.Forms.Integration.ElementHost>
- <xref:System.Windows.Forms.Integration.WindowsFormsHost>
- [Migration and Interoperability](../../wpf/advanced/migration-and-interoperability.md)
- [Using WPF Controls](using-wpf-controls.md)
- [Design XAML in Visual Studio](/visualstudio/xaml-tools/designing-xaml-in-visual-studio)
