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

Visual Studio is a dots per inch (DPI) aware application, which means displays scale automatically. If an application states that it's not DPI-aware, the operating system scales the application as a bitmap. This behavior is also called DPI virtualization. The application still thinks that it's running at 100% scaling, or 96 dpi.

## Rendering issue

The **Windows Forms Designer** in Visual Studio doesn't currently have scaling support. This can cause display issues when you open forms in the **Windows Forms Designer** on HDPI monitors.

For example, the first image that follows shows **Windows Forms Designer** on a monitor at 100% scaling. The second image shows what the form looks like when it's opened on a high dots per inch (HDPI) monitor:

![Windows Forms Designer scaling at 100%](media/scaling-100-percent.png)

![Windows Forms Designer on HDPI monitor](media/win-forms-designer-hdpi.png)

In Visual Studio 2017 version 15.8 and later, when you open a form in the **Windows Forms Designer**ga . on an HDPI monitor, Visual Studio displays a yellow message bar at the top of the designer:

![Scaling on your monitor yellow message bar in Visual Studio](media/scaling-gold-bar.png)

The message reads **Scaling on your main display is set to 200%. This might cause rendering problems in the designer window.**

## To resolve the problem

There are two options to resolve the display problem:

- Set your display scaling setting to 100%.

   To do this in Windows 10, type **display settings** in the Cortana search box, and then select **Change display settings**. In the **Settings** window, set **Change the size of text, apps, and other items** to **100%**.

- Select the option on the yellow message bar to restart Visual Studio as a DPI-unaware process.

   > [!NOTE]
   > - If you had undocked tool windows in Visual Studio when you selected the option to restart as a DPI-unaware process, the position of those tool windows may change.
   > - If you use the default Visual Basic profile, or if you have the **Save new projects when created** option deselected in **Tools** > **Options** > **Projects and Solutions**, Visual Studio cannot reopen your project when it restarts as a DPI-unaware process. However, you can open the project by selecting it under **File** > **Recent Projects and Solutions**.

   If you close and reopen Visual Studio when it's running in DPI-unaware mode, it becomes DPI-aware again. It's important to restart Visual Studio as a DPI-aware process when you're finished working in the **Windows Forms Designer**.

## See also

- [Automatic scaling in Windows Forms](automatic-scaling-in-windows-forms.md)