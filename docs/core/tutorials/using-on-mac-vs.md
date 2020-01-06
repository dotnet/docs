---
title: Get started with .NET Core using Visual Studio for Mac
description: This topic walks you through building a simple console application using Visual Studio for Mac and .NET Core.
author: mairaw
ms.date: 12/19/2019
---
# Get started with .NET Core on macOS using Visual Studio for Mac

Visual Studio for Mac provides a full-featured Integrated Development Environment (IDE) for developing .NET Core applications. This article walks you through building a simple console application using Visual Studio for Mac and .NET Core.

> [!NOTE]
> Your feedback is highly valued. There are two ways you can provide feedback to the development team on Visual Studio for Mac:
>
> * In Visual Studio for Mac, select **Help** > **Report a Problem** from the menu or **Report a Problem** from the Welcome screen, which will open a window for filing a bug report. You can track your feedback in the [Developer Community](https://developercommunity.visualstudio.com/spaces/8/index.html) portal.
> * To make a suggestion, select **Help** > **Provide a Suggestion** from the menu or **Provide a Suggestion** from the Welcome screen, which will take you to the [Visual Studio for Mac Developer Community webpage](https://developercommunity.visualstudio.com/content/idea/post.html?space=41).

## Prerequisites

See the [.NET Core dependencies and requirements](../install/dependencies.md?pivots=os-macos) article.

Check the [.NET Core Support](/visualstudio/mac/net-core-support) article to ensure you're using a supported version of .NET Core.

## Get started

If you've already installed the prerequisites and Visual Studio for Mac, skip this section and proceed to [Creating a project](#creating-a-project). Follow these steps to install the prerequisites and Visual Studio for Mac:

Download the [Visual Studio for Mac installer](https://visualstudio.microsoft.com/vs/mac/?utm_medium=microsoft&utm_source=docs.microsoft.com&utm_campaign=inline+link). Run the installer. Read and accept the license agreement. During the install, select the option to install .NET Core. You're provided the opportunity to install Xamarin, a cross-platform mobile app development technology. Installing Xamarin and its related components is optional for .NET Core development. For a walk-through of the Visual Studio for Mac install process, see [Visual Studio for Mac documentation](/visualstudio/mac/). When the install is complete, start the Visual Studio for Mac IDE.

## Creating a project

1. Select **New** on the start window.

   ![New button on the Visual Studio for Mac Start screen](./media/using-on-mac-vs/visual-studio-mac-new-project.png)

1. In the **New Project** dialog, select **App** under the **.NET Core** node. Select the **Console Application** template followed by **Next**.

   ![New project templates list](./media/using-on-mac-vs/visual-studio-mac-new-dialog.png)

1. If you have more than one version of .NET Core installed, select the target framework for your project.

1. Type "HelloWorld" for the **Project Name**. Select **Create**.

   ![Configure your new Console Application dialog](./media/using-on-mac-vs/visual-studio-mac-new-options.png)

1. Wait while the project's dependencies are restored. The project has a single C# file, *Program.cs*, containing a `Program` class with a `Main` method. The `Console.WriteLine` statement will output "Hello World!" to the console when the app is run.

   ![Main window with the Program.cs file open](./media/using-on-mac-vs/visual-studio-mac-editor.png)

## Run the application

Run the app in Debug mode using ⌘ ↵ (command + enter) or in Release mode using ⌥ ⌘ ↵ (option + command + enter).

![The Application Output pane shows Hello World!](./media/using-on-mac-vs/visual-studio-mac-output.png)

## Next step

The [Building a complete .NET Core solution on macOS using Visual Studio for Mac](using-on-mac-vs-full-solution.md) topic shows you how to build a complete .NET Core solution that includes a reusable library and unit testing.
