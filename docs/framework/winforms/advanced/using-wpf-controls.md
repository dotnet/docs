---
title: "Using WPF Controls"
ms.date: "03/30/2017"
helpviewer_keywords:
  - "Windows Forms Designer [Windows Forms], interoperability with WPF"
  - "interoperability [WPF]"
ms.assetid: 03c85dce-26ad-44cd-bc1d-8e0cb56de096
author: gewarren
ms.author: gewarren
manager: jillfra
---
# Use WPF controls in Windows Forms apps

You can use Windows Presentation Foundation (WPF) controls in Windows Forms-based applications. Although these are two different view technologies, they interoperate smoothly.

The Windows Forms Designer in Visual Studio provides a visual design environment for hosting Windows Presentation Foundation controls. A WPF control is hosted by a special Windows Forms control that's named <xref:System.Windows.Forms.Integration.ElementHost>. This control enables the WPF control to participate in the form's layout and to receive keyboard and mouse messages. At design time, you can arrange the <xref:System.Windows.Forms.Integration.ElementHost> control just as you would any Windows Forms control.

You can also use Windows Forms controls in WPF-based applications. For more information, see [Design XAML in Visual Studio](/visualstudio/designers/designing-xaml-in-visual-studio).

## See also

- [WPF and Windows Forms interoperation](/dotnet/framework/wpf/advanced/wpf-and-windows-forms-interoperation)
