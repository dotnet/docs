---
title: Get started with .NET
description: Create a Hello World .NET app.
author: adegeo
ms.author: adegeo
ms.date: 10/21/2025
ms.custom: vs-dotnet, devdivchpfy22
ms.topic: tutorial
ai-usage: ai-assisted
---
# Get started with .NET

This tutorial teaches you how to create and run your first .NET app. You write a simple program and see the results of running your code.

In this tutorial, you:

> [!div class="checklist"]
>
> * Launch a GitHub Codespace with a .NET development environment.
> * Create your first .NET app.
> * Run your program.

## Prerequisites

You must have one of the following options:

- A GitHub account to use [GitHub Codespaces](https://github.com/codespaces). If you don't already have one, you can create a free account at [GitHub.com](https://github.com).
- A computer with the following tools installed:
  - The [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0).
  - [Visual Studio Code](https://code.visualstudio.com/download).
  - The [C# Dev Kit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit).

## Open Codespaces

To start a GitHub Codespace with the tutorial environment, open a browser window to the [tutorial codespace](https://github.com/dotnet/tutorial-codespace) repository. Select the green **Code** button, and the **Codespaces** tab. Then select the `+` sign to create a new Codespace using this environment.

## Run your first program

1. When your codespace loads, create a new file in the `tutorials` folder named `hello-world.cs`.
1. Open your new file.
1. Type or copy the following code into `hello-world.cs`:

   :::code language="csharp" source="./snippets/get-started/csharp/hello-world.cs" id="HelloWorld":::

1. In the integrated terminal window, make the `tutorials` folder the current folder, and run your program:

   ```dotnetcli
   cd tutorials
   dotnet run hello-world.cs
   ```

You ran your first .NET program. It's a simple program that prints the message "Hello, World!" It uses the <xref:System.Console.WriteLine%2A?displayProperty=nameWithType> method to print that message. `Console` is a type that represents the console window. `WriteLine` is a method of the `Console` type that prints a line of text to that text console.

Congratulations! You created a simple .NET application.

## Cleanup resources

GitHub automatically deletes your Codespace after 30 days of inactivity. If you plan to continue with .NET tutorials, you can leave your Codespace provisioned. If you're ready to download the .NET SDK to your computer, you can delete your Codespace. To delete your Codespace, open a browser window and navigate to [your Codespaces](https://github.com/codespaces). You should see a list of your codespaces in the window. Select the three dots (`...`) in the entry for the tutorial codespace and select **delete**.

## Next steps

Get started developing .NET applications by following a [step-by-step tutorial](../standard/get-started.md) or by watching [.NET 101 videos](https://www.youtube.com/playlist?list=PLdo4fOcmZ0oWoazjhXQzBKMrFuArxpW80) on YouTube.
