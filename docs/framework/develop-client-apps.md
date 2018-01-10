---
title: "Developing Client Applications with the .NET Framework"
ms.custom: ""
ms.date: "01/09/2018"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "client application services"
  - "applications [Windows Forms]"
  - "Windows Presentation Foundation, in Visual Studio"
  - "WPF, in Visual Studio"
  - "Windows applications"
  - "rich client applications"
  - ".NET applications, Windows applications"
  - "Visual Basic code, creating applications"
  - "Visual C#, creating applications"
  - "client/server applications, Windows applications"
ms.assetid: 2dfb50b7-5af2-4e12-9bbb-c5ade0e39a68
caps.latest.revision: 24
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Developing Client Applications with the .NET Framework
There are several ways to develop Windows-based applications with the .NET framework. This section helps you understand your options.  

You can use any of these types of applications to build for the PC:

* [Universal Windows Platform](https://developer.microsoft.com/windows/apps)
* [Windows Presentation Foundation (WPF)](../../docs/framework/wpf/index.md)
* [Windows Forms](../../docs/framework/winforms/index.md)

If you're targeting Windows 10, consider the Universal Windows Platform. It's the most recent development platform and it's where Microsoft is making all of its new investments. Your app runs and renders properly on all Windows 10 devices both now and in the future, the UI is modern and beautiful, and your app can work with all forms of modern device interactions such as touch and ink.  

That said, Universal Windows applications run in a protected sandboxed environment and if your app requires deep access to the system and you imagine your app running only on PCs, you could create a traditional application that runs only on the desktop PC and then use the Desktop Bridge to create modern deployment packages for Windows 10 users. That gives your Windows 10 users clean, isolated installation experience that has zero registry impact and you could deploy your app to the Windows Store if that's what you want to do.

Here's a quick summary of each option:

## Universal Windows Platform application

:heavy_check_mark: Lets you build modern looking, adaptive UI's with the [Fluent Design System](https://fluent.microsoft.com/).

:heavy_check_mark: Adapts to various screen sizes and resolutions.

:heavy_check_mark: Runs on all Windows 10 devices. This positions you for ongoing innovations in workplace hardware.

:heavy_check_mark: Naturally incorporates modern interaction models such as touch, ink, dial, etc.

:heavy_check_mark: Simple, clean, and trustworthy deployment.

:heavy_check_mark: Access to all Windows 10 APIs.

:heavy_check_mark: Benefits from ongoing investment to the platform.

Here's a few trade-offs to consider. These applications run only in Windows 10 and they run inside of a protected sandbox, which means that file access is limited and communication outside of the application requires some work. The .NET APIs that you can use in a UWP app are limited, but this collection grows with each release. Because this is our investment going forward, we're addressing experience gaps with each release so the platform will continue to improve.

## Desktop application (WPF or Windows Forms)

:heavy_check_mark: Let's you deploy applications to legacy Windows user bases such as Windows 7.

:heavy_check_mark: Gives deep access to file system, the registry and you can more easily interact with other applications on the system.

:heavy_check_mark: Offers time tested and easy-to-use drag-and-drop rapid application design tools.

:heavy_check_mark: Gives access to the full breadth and depth of the .NET Framework.

:heavy_check_mark: Simple, clean, and trustworthy deployment to Windows 10 users by using the Desktop Bridge.

Here's a few important trade-offs to consider. These applications run only on PCs and because we're making very low investments in these technologies, UIs in your application will appear outdated over time.

You can use some Windows 10 APIs directly from your app, but for many of them, you have to create a package by using the Desktop Bridge. To use APIs that depend on modern UIs, you'd have to go one step further and extend your solution with a separate UWP project so there's some work involved in using the most up-to-date Windows APIs.
  
## In This Section  
 [Windows Presentation Foundation](../../docs/framework/wpf/index.md)  
 Provides information about developing applications by using WPF.  
  
 [Windows Forms](../../docs/framework/winforms/index.md)  
 Provides information about developing applications by using Windows Forms.  
  
 [Common Client Technologies](../../docs/framework/common-client-technologies/index.md)  
 Provides information about additional technologies that can be used when developing client applications.  
  
## Related Sections  
[Universal Windows Platform](https://developer.microsoft.com/windows/apps)
 Describes how to create applications for Windows 10 that you can make available to users through the Windows Store.  
  
 [.NET for Store apps](http://msdn.microsoft.com/library/windows/apps/br230302.aspx)  
 Describes the .NET Framework support for Store apps, which can be deployed to Windows computers and devices.  
  
 [.NET API for Windows Phone Silverlight](http://msdn.microsoft.com/library/windows/apps/xaml/jj207211\(v=vs.105\).aspx)  
 List the .NET Framework APIs you can use for building apps with Windows Phone Silverlight  
  
 [Developing for Multiple Platforms](../../docs/standard/cross-platform/index.md)  
 Describes the different methods you can use the .NET Framework to target multiple client app types.  
  
 [Get Started with ASP.NET Web Sites](http://www.asp.net/get-started/websites)  
 Describes the ways you can develop web apps using ASP.NET.  
  
## See Also  
 [Portable Class Library](../../docs/standard/cross-platform/cross-platform-development-with-the-portable-class-library.md)  
 [Overview](../../docs/framework/get-started/overview.md)  
 [Development Guide](../../docs/framework/development-guide.md)  
 [How to: Create a Windows Desktop Application](http://msdn.microsoft.com/library/47021403-eaca-4c34-946a-a26c42a64148)  
 [Windows Service Applications](../../docs/framework/windows-services/index.md)
