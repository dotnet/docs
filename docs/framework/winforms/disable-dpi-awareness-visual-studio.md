---
title: Disable DPI-awareness in Visual Studio
ms.date: 08/14/2018
ms.prod: visual-studio-dev15
ms.technology: vs-ide-designers
ms.topic: conceptual
author: gewarren
ms.author: gewarren
manager: douge
---
# Disable DPI-awareness in Visual Studio

Visual Studio is a dots per inch (DPI) aware application, which means the display scales automatically. If an application states that it's not DPI-aware, the operating system scales the application as a bitmap. This behavior is also called DPI virtualization. The application still thinks that it's running at 100% scaling, or 96 dpi.

## Rendering issue

The **Windows Forms Designer** in Visual Studio doesn't currently have scaling support. This can cause display issues when you open forms in the **Windows Forms Designer** on high dots per inch (HDPI) monitors.

For example, the first image that follows shows **Windows Forms Designer** on a monitor at 100% scaling. The second image shows what the form looks like when it's opened on an HDPI monitor:

![Designer scaling at 100%](media/scaling-100-percent.png)

![Designer on HDPI monitor](media/win-forms-designer-hdpi.png)

In Visual Studio 2017 version 15.8 and later, when you open a form in the **Windows Forms Designer** on an HDPI monitor, Visual Studio displays a yellow informational bar at the top of the designer:

![Scaling on your monitor informational bar in Visual Studio](media/scaling-gold-bar.png)

The message reads **Scaling on your main display is set to 200% (192 dpi). This might cause rendering problems in the designer window.**

## To resolve the problem

There are three options to resolve the display problem.

### Restart Visual Studio as a DPI-unaware process

You can restart Visual Studio as a DPI-unaware process by selecting the option on the yellow informational bar.

When Visual Studio runs as a DPI-unaware process, the designer layout issues are resolved, but fonts may appear blurry. Visual Studio displays a different yellow informational message when it runs as a DPI-unaware process that says **Visual Studio is running as a DPI-unaware process. WPF and XAML designers might not display correctly.**. The informational bar also provides an option to **Restart Visual Studio as a DPI-aware process**.

> [!NOTE]
> - If you had undocked tool windows in Visual Studio when you selected the option to restart as a DPI-unaware process, the position of those tool windows may change.
> - If you use the default Visual Basic profile, or if you have the **Save new projects when created** option deselected in **Tools** > **Options** > **Projects and Solutions**, Visual Studio cannot reopen your project when it restarts as a DPI-unaware process. However, you can open the project by selecting it under **File** > **Recent Projects and Solutions**.

It's important to restart Visual Studio as a DPI-aware process when you're finished working in the **Windows Forms Designer**. When it's running as a DPI-unaware process, fonts can look blurry and you may see issues in the **XAML Designer**. If you close and reopen Visual Studio when it's running in DPI-unaware mode, it becomes DPI-aware again. You can also click the **Restart Visual Studio as a DPI-aware process** option in the informational bar.

### Add a registry entry

You can mark Visual Studio as DPI-unaware by modifying the registry. Open **Registry Editor** and add an entry to the **HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows NT\CurrentVersion\AppCompatFlags\Layers** subkey:

**Entry**: %ProgramFiles(x86)%\Microsoft Visual Studio\2017\<edition>\Common7\IDE\devenv.exe

**Type**: REG_SZ

**Value**: DPIUNAWARE

### Set your display scaling setting to 100%

To set your display scaling setting to 100% in Windows 10, type **display settings** in the Cortana search box, and then select **Change display settings**. In the **Settings** window, set **Change the size of text, apps, and other items** to **100%**.

Setting your display scaling to 100% may be undesirable, because it can make the user interface too small to be usable.

## See also

- [Automatic scaling in Windows Forms](automatic-scaling-in-windows-forms.md)