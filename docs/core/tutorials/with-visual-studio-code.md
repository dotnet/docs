---
title: Get started with C# and Visual Studio Code - C# Guide
description: Learn how to create and debug your first .NET Core application in C# using Visual Studio Code.
author: kendrahavens
ms.author: mairaw
ms.date: 09/27/2017
ms.topic: article
ms.prod: .net
ms.technology: devlang-csharp
ms.workload: 
  - dotnetcore
---
# Get Started with C# and Visual Studio Code

.NET Core gives you a fast and modular platform for creating applications that run on Windows, Linux, and macOS. Use Visual Studio Code with the C# extension to get a powerful editing experience with full support for C# IntelliSense (smart code completion) and debugging.

## Prerequisites

1. Install [Visual Studio Code](https://code.visualstudio.com/).
2. Install the [.NET Core SDK](https://www.microsoft.com/net/download/core).
3. Install the [C# extension](https://marketplace.visualstudio.com/items?itemName=ms-vscode.csharp) for Visual Studio Code. For more information about how to install extensions on Visual Studio Code, see [VS Code Extension Marketplace](https://code.visualstudio.com/docs/editor/extension-gallery).

## Hello World

Let's get started with a simple "Hello World" program on .NET Core:

1. Open a project:

    * Open Visual Studio Code.
    * Click on the Explorer icon on the left menu and then click **Open Folder**.
    * Select **File** > **Open Folder** from the main menu to open the folder you want your C# project to be in and click **Select Folder**. For our example, we're creating a folder for our project named *HelloWorld*.

      ![VSCodeOpenFolder](media/with-visual-studio-code/vscodeopenfolder.png)

2. Initialize a C# project:
    * Open the Integrated Terminal from Visual Studio Code by selecting **View** > **Integrated Terminal** from the main menu.
    * In the terminal window, type `dotnet new console`.
    * This command creates a `Program.cs` file in your folder with a simple "Hello World" program already written, along with a C# project file named `HelloWorld.csproj`.

      ![The dotnet new command](media/with-visual-studio-code/dotnetnew.png)

3. Resolve the build assets:

    * For **.NET Core 1.x**, type `dotnet restore`. Running `dotnet restore` gives you access to the  required .NET Core packages that are needed to build your project.

      ![The dotnet restore command](media/with-visual-studio-code/dotnetrestore.png)

      [!INCLUDE[DotNet Restore Note](~/includes/dotnet-restore-note.md)]

4. Run the "Hello World" program:

    * Type `dotnet run`. 

      ![The dotnet run command](media/with-visual-studio-code/dotnetrun.png)

You can also watch a short video tutorial for further setup help on [Windows](https://channel9.msdn.com/Blogs/dotnet/Get-started-with-VS-Code-using-CSharp-and-NET-Core), [macOS](https://channel9.msdn.com/Blogs/dotnet/Get-started-with-VS-Code-using-CSharp-and-NET-Core-on-MacOS), or [Linux](https://channel9.msdn.com/Blogs/dotnet/Get-started-with-VS-Code-Csharp-dotnet-Core-Ubuntu).

## Debug

1. Open *Program.cs* by clicking on it. The first time you open a C# file in Visual Studio Code, [OmniSharp](http://www.omnisharp.net/) loads in the editor.

    ![Open the Program.cs file](media/with-visual-studio-code/opencs.png)

2. Visual Studio Code should prompt you to add the missing assets to build and debug your app. Select **Yes**. 

    ![Prompt for missing assets](media/with-visual-studio-code/missing-assets.png)

3. To open the Debug view, click on the Debugging icon on the left side menu.

    ![Open the Debug tab](media/with-visual-studio-code/opendebug.png)

4. Locate the green arrow at the top of the pane. Make sure the drop-down next to it has `.NET Core Launch (console)` selected.

    ![Selecting .NET Core](media/with-visual-studio-code/selectcore.png)

5. Add a breakpoint to your project by clicking on the **editor margin**, which is the space on the left of the line numbers in the editor, next to line 9.

    ![Setting a Breakpoint](media/with-visual-studio-code/setbreakpoint.png)

6. To start debugging, select <kbd>F5</kbd> or the green arrow. The debugger stops execution of your program when it reaches the breakpoint you set in the previous step.
    * While debugging, you can view your local variables in the top left pane or use the debug console.

    ![Run and Debug](media/with-visual-studio-code/rundebug.png)

7. Select the green arrow at the top to continue debugging, or select the red square at the top to stop.

> [!TIP] 
> For more information and troubleshooting tips on .NET Core debugging with OmniSharp in Visual Studio Code, see [Instructions for setting up the .NET Core debugger](https://github.com/OmniSharp/omnisharp-vscode/blob/master/debugger.md).

## See also
[Setting up Visual Studio Code](https://code.visualstudio.com/docs/setup/setup-overview)   
[Debugging in Visual Studio Code](https://code.visualstudio.com/Docs/editor/debugging)
