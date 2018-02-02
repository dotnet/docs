---
title: "How to: Add a Splash Screen to a WPF Application"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-wpf"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "WPF [WPF], splash screen"
  - "startup window [WPF]"
  - "SplashScreen class [WPF]"
  - "splash screen [WPF]"
ms.assetid: d70a25c4-5fb9-4c27-b01d-b1b8ef39b3fd
caps.latest.revision: 14
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Add a Splash Screen to a WPF Application
This topic shows how to add a startup window, or *splash screen*, to a Windows Presentation Foundation (WPF) application.  
  
### To add an existing image as a splash screen  
  
1.  Create or find an image that you want to use for the splash screen. You can use any image format that is supported by the Windows Imaging Component (WIC). For example, you can use the BMP, GIF, JPEG, PNG, or TIFF format.  
  
2.  Add the image file to the WPF Application project. For more information, see [NIB:How to: Add Existing Items to a Project](http://msdn.microsoft.com/library/15f4cfb7-78ab-457f-9f14-099a25a6a2d3).  
  
3.  In Solution Explorer, select the image.  
  
4.  In the Properties window, click the drop-down arrow for the **Build Action** property.  
  
5.  Select **SplashScreen** from the drop-down list.  
  
    > [!NOTE]
    >  If you do not see the **SplashScreen** option, be sure to check that you are using [!INCLUDE[vs_orcas_long](../../../../includes/vs-orcas-long-md.md)] SP1 or later.  
  
6.  Press F5 to build and run the application.  
  
     The splash screen image appears in the center of the screen, and then fades when the main application window appears.  
  
### To remove the splash screen from an application  
  
1.  In Solution Explorer, select the splash screen image.  
  
2.  In the Properties window, set the **Build Action** to **None**.  
  
### To remove the splash screen from an application  
  
-   In Solution Explorer, delete the splash screen image.  
  
-   Exclude the splash screen image from the project.  
  
## See Also  
 <xref:System.Windows.SplashScreen>  
 [NIB:How to: Add Existing Items to a Project](http://msdn.microsoft.com/library/15f4cfb7-78ab-457f-9f14-099a25a6a2d3)
