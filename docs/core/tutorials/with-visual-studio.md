---
title: Create a console application with .NET Core in Visual Studio
description: Learn how to create a .NET Core console application with C# or Visual Basic using Visual Studio.
author: BillWagner
ms.author: wiwagn
ms.date: 05/20/2020
dev_langs:
  - "csharp"
  - "vb"
ms.custom: "vs-dotnet"
---
# Tutorial: Create a .NET Core console application in Visual Studio 2019

This tutorial shows how to create and run a .NET Core console application in Visual Studio 2019.

## Prerequisites

- [Visual Studio 2019 version 16.6 or a later version](https://visualstudio.microsoft.com/downloads/?utm_medium=microsoft&utm_source=docs.microsoft.com&utm_campaign=inline+link&utm_content=download+vs2019) with the **.NET Core cross-platform development** workload installed. The .NET Core 3.1 SDK is automatically installed when you select this workload.

  For more information, see the [Install with Visual Studio](../install/sdk.md?pivots=os-windows#install-with-visual-studio) section on the [Install the .NET Core SDK](../install/sdk.md?pivots=os-windows) article.

## Create the app

<!-- markdownlint-disable MD025 -->

1. Open Visual Studio 2019.

1. Create a new .NET Core console app project named "HelloWorld".

   1. On the start page, choose **Create a new project**.

      ![Create a new project button selected on the Visual Studio start page](./media/with-visual-studio/start-window.png)

   1. On the **Create a new project** page, enter **console** in the search box. Next, choose **C#** or **Visual Basic** from the language list, and then choose **All platforms** from the platform list. Choose the **Console App (.NET Core)** template, and then choose **Next**.

      ![Create a new project window with filters selected](./media/with-visual-studio/create-new-project.png)

      > [!TIP]
      > If you don't see the .NET Core templates, you're probably missing the required workload. Under the **Not finding what you're looking for?** message, choose the **Install more tools and features** link. The Visual Studio Installer opens. Make sure you have the **.NET Core cross-platform development** workload installed.

   1. On the **Configure your new project** page,  enter **HelloWorld** in the **Project name** box. Then choose **Create**.

      ![Configure your new project window with Project name, location, and solution name fields](./media/with-visual-studio/configure-new-project.png)

   The Console Application template for .NET Core defines a class, `Program`, with a single method, `Main`, that takes a <xref:System.String> array as an argument. `Main` is the application entry point, the method that's called automatically by the runtime when it launches the application. Any command-line arguments supplied when the application is launched are available in the *args* array.

   If the language you want to use is not shown, change the language selector at the top of the page.

   ```csharp
   using System;

   namespace HelloWorld
   {
       class Program
       {
           static void Main(string[] args)
           {
               Console.WriteLine("Hello World!");
           }
       }
   }
   ```

   ```vb
   Imports System

   Module Program
       Sub Main(args As String())
           Console.WriteLine("Hello World!")
       End Sub
   End Module
   ```

   The template creates a simple "Hello World" application. It calls the <xref:System.Console.WriteLine(System.String)?displayProperty=nameWithType> method to display "Hello World!" in the console window.

## Run the app

1. To run the program, choose **HelloWorld** on the toolbar, or press **F5**.

   ![Visual Studio toolbar with the HelloWorld run button selected](./media/with-visual-studio/run-program.png)

   A console window opens with the text "Hello World!" printed on the screen and some Visual Studio debug information.

   ![Console window showing Hello World Press any key to continue](./media/with-visual-studio/hello-world-console.png)

1. Press any key to close the console window.

## Enhance the app

Enhance the application to prompt the user for their name and display it along with the date and time. The following instructions modify the app and run it again:

1. Replace the contents of the `Main` method, which is currently just the line that calls `Console.WriteLine`, with the following code:

   :::code language="csharp" source="./snippets/with-visual-studio/csharp/Program.cs" id="Snippet1":::

   :::code language="vb" source="./snippets/with-visual-studio/vb/Program.vb" id="Snippet1":::

   This code displays "What is your name?" in the console window and waits until the user enters a string followed by the Enter key. It stores this string in a variable named `name`. It also retrieves the value of the <xref:System.DateTime.Now?displayProperty=nameWithType> property, which contains the current local time, and assigns it to a variable named `date` (`currentDate` in Visual Basic). Finally, it displays these values in the console window.

   The `\n` (`vbCrLf` in Visual Basic) represents a newline character.

   The dollar sign (`$`) in front of a string lets you put expressions such as variable names in curly braces in the string. The expression value is inserted into the string in place of the expression. This syntax is referred to as [interpolated strings](../../csharp/language-reference/tokens/interpolated.md).

1. To run the program, choose **HelloWorld** on the toolbar, or press **F5**.

1. Respond to the prompt by entering a name and pressing the **Enter** key.

   ![Console window with modified program output](./media/with-visual-studio/hello-world-update.png)

1. Press any key to close the console window.

## Next steps

In this tutorial, you created a .NET Core application. In the next tutorial, you debug the app.

> [!div class="nextstepaction"]
> [Debug a .NET Core console application in Visual Studio](debugging-with-visual-studio.md)
