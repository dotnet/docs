---
title: Getting started with visual Studio Code | C# Guide
description: Getting Started with Visual Studio Code
keywords: C#, Getting Started, Acquisition, Install, Visual Studio Code, Cross Platform
author: dotnet-bot
manager: wpickett
ms.date: 08/23/2016
ms.topic: article
ms.prod: visual-studio-dev-14
ms.technology: devlang-csharp
ms.devlang: csharp
ms.assetid: 76c23597-4cf9-467e-8a47-0c3703ce37e7

---

# 🔧 Getting started with Visual Studio Code

<<<<<<< HEAD
> **Note**
> 
> This topic hasn’t been written yet! 
>
> We welcome your input to help shape the scope and approach. You can track the status and provide input on this
> [issue](https://github.com/dotnet/docs/issues/944) at GitHub.
> 
> If you would like to review early drafts and outlines of this topic, please leave a note with your contact information in the issue.
>
> Learn more about how you can contribute on [GitHub](https://github.com/dotnet/docs/blob/master/CONTRIBUTING.md).
>
=======
.NET Core gives you a blazing fast and modular platform for creating server applications that run on Windows, Linux and macOS. Use Visual Studio Code with the C# extension to get a powerful editing experience with full support for C# IntelliSense (smart code completion) and debugging.

## Getting Started

1. Install [.NET Core](https://microsoft.com/net/core).
2. Install the [C# extension](https://marketplace.visualstudio.com/items?itemName=ms-vscode.csharp) from the VS Code Marketplace.

## Hello World

If you'd like to get started with a simple "Hello World" program on .NET Core, follow the steps below:

1. Open a project:

    * Open VS Code.
    * Go to the File Explorer Tab on the left.
    * Open the folder you want you C# project to be in.

  ![VSCodeOpenFolder](https://github.com/dotnet/core-docs/blob/master/docs/images/VSCodeOpenFolder.PNG)

2. Initialize a C# project:
    * Open the command prompt (or terminal). You can open the terminal from VS Code by typing <kbd>CTRL</kbd>+<kbd>`</kbd> (Back Tick)
    * Type `dotnet new`
    * This creates a `Program.cs` file in your folder with a simple "Hello World" program already written.

  ![dotnetNew](https://github.com/dotnet/core-docs/blob/master/docs/images/dotnetNew.PNG)

3. Resolve the build assets by typing `dotnet restore`

    * Running `restore` pulls down the required packages declared in the `project.json` file.
    * You'll see a new `project.lock.json` file in your project folder.
    * This file contains information about your project's dependencies to make subsequent restores quicker.

  ![Image dotnet restore](https://github.com/dotnet/core-docs/blob/master/docs/images/dotnetRestore.PNG)

4. Run the "Hello World" program by typing `dotnet run`

  ![dotnetRun](https://github.com/dotnet/core-docs/blob/master/docs/images/dotnetRun.PNG)

You can also watch a short fun video tutorial for further setup help on [Windows](https://channel9.msdn.com/Blogs/dotnet/Get-started-with-VS-Code-using-CSharp-and-NET-Core), [macOS](https://channel9.msdn.com/Blogs/dotnet/Get-started-with-VS-Code-using-CSharp-and-NET-Core-on-MacOS), or [Linux](https://channel9.msdn.com/Blogs/dotnet/Get-started-with-VS-Code-Csharp-dotnet-Core-Ubuntu).

## Next Steps

* [Editing Evolved](/docs/editor/editingevolved.md) - Lint, IntelliSense, Lightbulbs, Peek and Go to Definition and more
* [Working with C#](/docs/languages/csharp.md) - Learn about the great C# support you'll have when working on your .NET Core application.
* [Tasks](/docs/editor/tasks.md) - Running tasks with Gulp, Grunt and Jake.  Showing Errors and Warnings
>>>>>>> Propose VS Code Getting Started
