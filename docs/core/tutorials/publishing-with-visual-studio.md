---
title: Publish your Hello World application with Visual Studio 2017
description: Publishing creates the set of files that are needed to run your application.
keywords: .NET, .NET Core, console application, publishing, deployment
author: BillWagner
ms.author: wiwagn
ms.date: 10/05/2017
ms.topic: article
ms.prod: .net-core
ms.technology: devlang-csharp
ms.devlang: csharp
ms.assetid: a19545d3-24af-4a32-9778-cfb5ae938287
ms.workload: 
  - dotnetcore
---

# Publish your Hello World application with Visual Studio 2017

In [Build a C# Hello World application with .NET Core in Visual Studio 2017](with-visual-studio.md) or [Build a Visual Basic Hello World application with .NET Core in Visual Studio 2017](vb-with-visual-studio.md), you built a Hello World console application. In [Debug your C# Hello World application with Visual Studio 2017](debugging-with-visual-studio.md), you tested it using the Visual Studio debugger. Now that you're sure that it works as expected, you can publish it so that other users can run it. Publishing creates the set of files that are needed to run your application, and you can deploy the files by copying them to a target machine.

To publish and run your application: 

1. Make sure that Visual Studio is building the Release version of your application. If necessary, change the build configuration setting on the toolbar from **Debug** to **Release**.

   ![Visual Studio toolbar](media/publishing-with-visual-studio/toolbar.png)

1. Right-click on the **HelloWorld** project (not the HelloWorld solution) and select **Publish** from the menu. You can also select **Publish HelloWorld** from the main Visual Studio **Build** menu.

   ![Visual Studio toolbar](media/publishing-with-visual-studio/publish1.png)


   ![Visual Studio toolbar](media/publishing-with-visual-studio/publishwindow.png)

1. Open a console window. For example in the **Type here to search** text box in the Windows taskbar, enter `Command Prompt` (or `cmd` for short), and open a console window by either selecting the **Command Prompt** desktop app or pressing Enter if it's selected in the search results.

1. Navigate to the published application in the `bin\release\PublishOutput` subdirectory of your application's project directory. As the following figure shows, the published output includes the following four files:

      * *HelloWorld.deps.json*

         The application's runtime dependencies file. It defines the .NET Core components and the libraries (including the dynamic link library that contains your application) needed to run your application. For more information, see [Runtime Configuration Files](https://github.com/dotnet/cli/blob/85ca206d84633d658d7363894c4ea9d59e515c1a/Documentation/specs/runtime-configuration-file.md).
 
      * *HelloWorld.dll*

         The file that contains your application. It is a dynamic link library that can be executed by entering the `dotnet HelloWorld.dll` command in a console window. 

      * *HelloWorld.pdb* (optional for deployment)

         A file that contains debug symbols. You aren't required to deploy this file along with your application, although you should save it in the event that you need to debug the published version of your application.

      * *HelloWorld.runtimeconfig.json*

         The application's runtime configuration file. It identifies the version of .NET Core that your application was built to run on. For more information, see [Runtime Configuration Files](https://github.com/dotnet/cli/blob/85ca206d84633d658d7363894c4ea9d59e515c1a/Documentation/specs/runtime-configuration-file.md).  

   ![Console window showing published files](media/publishing-with-visual-studio/publishedfiles.png)

The publishing process creates a framework-dependent deployment, which is a type of deployment where the published application will run on any platform supported by .NET Core with .NET Core installed on the system. Users can run your application by issuing the `dotnet HelloWorld.dll` command from a console window.

For more information on publishing and deploying .NET Core applications, see [.NET Core Application Deployment](../../core/deploying/index.md).
