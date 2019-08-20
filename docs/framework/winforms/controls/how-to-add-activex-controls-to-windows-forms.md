---
title: "How to: Add ActiveX Controls to Windows Forms"
ms.date: "03/30/2017"
helpviewer_keywords:
  - "Windows Forms controls, ActiveX controls"
  - "forms [Windows Forms], adding ActiveX controls"
  - "ActiveX controls [Windows Forms], adding"
ms.assetid: 54a61e5b-555e-4887-b41e-6244fed271eb
---
# How to: Add ActiveX Controls to Windows Forms

While the Windows Forms Designer in Visual Studio is optimized to host Windows Forms controls, you can also put ActiveX controls on Windows Forms.

> [!CAUTION]
> There are performance limitations for Windows Forms when ActiveX controls are added to them.

Before you add ActiveX controls to your form, you must add them to the Toolbox. For more information, see [COM Components, Customize Toolbox Dialog Box](https://docs.microsoft.com/previous-versions/visualstudio/visual-studio-2010/cby6tzh5(v=vs.100)).

## Add an ActiveX control to your Windows Form

To add an ActiveX control to your Windows Form, double-click the control on the Toolbox.

Visual Studio adds all references to the control in your project. For more information about things to keep in mind when using ActiveX controls on Windows Forms, see [Considerations When Hosting an ActiveX Control on a Windows Form](considerations-when-hosting-an-activex-control-on-a-windows-form.md).

> [!NOTE]
> The Windows Forms ActiveX Control Importer (AxImp.exe) creates event arguments of a different type than expected upon importation of ActiveX dynamic link libraries. The arguments created by AxImp.exe are similar to the following: `Invoke(object sender, DWebBrowserEvents2_ProgressChangeEvent e)`, when `Invoke(object sender, DWebBrowserEvents2_ProgressChangeEventArgs e)` is expected. Be aware that this irregularity does not prevent code from functioning normally. For details, see [Windows Forms ActiveX Control Importer (Aximp.exe)](../../tools/aximp-exe-windows-forms-activex-control-importer.md).

## See also

- [Windows Forms Controls](index.md)
- [Controls and Programmable Objects Compared in Various Languages and Libraries](https://docs.microsoft.com/previous-versions/visualstudio/visual-studio-2010/0061wezk(v=vs.100))
- [How to: Add Controls to Windows Forms](how-to-add-controls-to-windows-forms.md)
- [Labeling Individual Windows Forms Controls and Providing Shortcuts to Them](labeling-individual-windows-forms-controls-and-providing-shortcuts-to-them.md)
- [Controls to Use on Windows Forms](controls-to-use-on-windows-forms.md)
- [Windows Forms Controls by Function](windows-forms-controls-by-function.md)
