---
title: Getting started with Visual Studio Code | C# Guide
description: Learn how to create and debug your first .NET Core application in C# using VS Code. 
keywords: C#, Getting Started, Acquisition, Install, Visual Studio Code, Cross Platform
author: kendrahavens
ms.author: wiwagn
ms.date: 12/09/2016
ms.topic: article
ms.prod: .net
ms.technology: devlang-csharp
ms.devlang: csharp
ms.assetid: 76c23597-4cf9-467e-8a47-0c3703ce37e7
---

# Getting Started with Visual Studio Code

.NET Core gives you a fast and modular platform for creating server applications that run on Windows, Linux and macOS. Use Visual Studio Code with the C# extension to get a powerful editing experience with full support for C# IntelliSense (smart code completion) and debugging.

## Prerequisites

1. Install [Visual Studio Code](https://code.visualstudio.com/).
2. Install the [.NET Core SDK](https://www.microsoft.com/net/download/core).
3. Install the [C# extension](https://marketplace.visualstudio.com/items?itemName=ms-vscode.csharp) from the VS Code Marketplace.

## Hello World

Let's get started with a simple "Hello World" program on .NET Core:

1. Open a project:

    * Open VS Code.
    * Click on the Explorer icon on the left menu and then click **Open Folder**.
    * Select the folder you want your C# project to be in and click **Select Folder**.

  ![VSCodeOpenFolder](media/with-visual-studio-code/vscodeopenfolder.png)

    * Alternatively, you can select **File** > **Open Folder** from the main menu to open your project folder.

2. Initialize a C# project:
    * Open the Integrated Terminal from VS Code by typing <kbd>CTRL</kbd>+<kbd>`</kbd> (backtick).
    * In the terminal window, type `dotnet new`.
    * This creates a `Program.cs` file in your folder with a simple "Hello World" program already written.

  ![dotnet new command](media/with-visual-studio-code/dotnetnew.png)

3. Resolve the build assets:

    * Type `dotnet restore`. Running `dotnet restore` pulls down the required packages declared in the `project.json` file.
    * You'll see a new `project.lock.json` file in your project folder.
    * This file contains information about your project's dependencies to make subsequent restores quicker.

  > TIP: If you are using the MSBuild-based .NET Core Tools a .csproj file will be created instead of a project.json one, but the `dotnet` commands you need to execute remain the same. For more information, see the [MSBuild-based tooling announcement](https://blogs.msdn.microsoft.com/dotnet/2016/11/16/announcing-net-core-tools-msbuild-alpha/) on the .NET blog.

  ![dotnet restore command](media/with-visual-studio-code/dotnetrestore.png)

4. Run the "Hello World" program:

    * Type `dotnet run`. 

  ![dotnet run command](media/with-visual-studio-code/dotnetrun.png)

You can also watch a short video tutorial for further setup help on [Windows](https://channel9.msdn.com/Blogs/dotnet/Get-started-with-VS-Code-using-CSharp-and-NET-Core), [macOS](https://channel9.msdn.com/Blogs/dotnet/Get-started-with-VS-Code-using-CSharp-and-NET-Core-on-MacOS), or [Linux](https://channel9.msdn.com/Blogs/dotnet/Get-started-with-VS-Code-Csharp-dotnet-Core-Ubuntu).

## Debug
1. Open Program.cs by clicking on it. The first time you open a C# file in VS Code, OmniSharp will load in the editor.

  ![Open Program.cs file](media/with-visual-studio-code/opencs.png)

2. VS Code will prompt you to add the missing assets to build and debug your app. Click **Yes**. 

  ![Prompt for missing assets](media/with-visual-studio-code/missing-assets.png)

3. To open the Debug view, click on the Debugging icon on the left side menu.

  ![Open the Debug tab](media/with-visual-studio-code/opendebug.png)

4. Locate the green arrow at the top of the pane. Make sure the drop-down next to it has `.NET Core Launch (console)` selected.

  ![Select .NET Core](media/with-visual-studio-code/selectcore.png)

5. Add a breakpoint to your project by clicking on the **editor margin** (the space on the left of the line numbers in the editor).

  ![Set a Breakpoint](media/with-visual-studio-code/setbreakpoint.png)

6. Hit <kbd>F5</kbd> or the green arrow to start debugging. The debugger stops execution of your program when it reaches the breakpoint you set the previous step.
    * While debugging you can view your local variables in the top left pane or use the debug console.

  ![Run and Debug](media/with-visual-studio-code/rundebug.png)

7. Hit the green arrow at the top to continue debugging or press the red square to stop.

## See also
- [Setting up Visual Studio Code](https://code.visualstudio.com/docs/setup/setup-overview)
- [Debugging in Visual Studio Code](https://code.visualstudio.com/Docs/editor/debugging)
