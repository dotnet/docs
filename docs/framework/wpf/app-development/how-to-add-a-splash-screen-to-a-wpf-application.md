---
title: "How to: Add a Splash Screen to a WPF Application"
ms.date: 08/18/2018
helpviewer_keywords:
  - "WPF [WPF], splash screen"
  - "startup window [WPF]"
  - "SplashScreen class [WPF]"
  - "splash screen [WPF]"
ms.assetid: d70a25c4-5fb9-4c27-b01d-b1b8ef39b3fd
---
# How to: Add a Splash Screen to a WPF Application

This topic shows how to add a startup window, or *splash screen*, to a Windows Presentation Foundation (WPF) application.

## To add an existing image as a splash screen

1. Create or find an image that you want to use for the splash screen. You can use any image format that is supported by the Windows Imaging Component (WIC). For example, you can use the BMP, GIF, JPEG, PNG, or TIFF format.

2. Add the image file to the WPF Application project.

3. In **Solution Explorer**, select the image.

4. In the Properties window, click the drop-down arrow for the **Build Action** property.

5. Select **SplashScreen** from the drop-down list.

6. Press **F5** to build and run the application.

     The splash screen image appears in the center of the screen, and then fades when the main application window appears.

## To exclude the splash screen from build

1. In **Solution Explorer**, select the splash screen image.

2. In the **Properties** window, set the **Build Action** to **None**.

## To remove the splash screen from an application

In **Solution Explorer**, delete the splash screen image.

## See also

- <xref:System.Windows.SplashScreen>
- [How to: Add Existing Items to a Project](https://docs.microsoft.com/previous-versions/visualstudio/visual-studio-2010/9f4t9t92(v=vs.100))
