---
title: Create a .NET console application using Visual Studio
description: Learn how to create a .NET console application with C# or Visual Basic using Visual Studio.
ms.date: 01/13/2026
dev_langs:
  - "csharp"
  - "vb"
ms.custom: vs-dotnet
---
# Tutorial: Create a .NET console application using Visual Studio

This tutorial shows how to create and run a .NET console application in Visual Studio 2026.

## Prerequisites

- [Visual Studio 2026 or later](https://visualstudio.microsoft.com/downloads/?utm_medium=microsoft&utm_source=learn.microsoft.com&utm_campaign=inline+link) with the **.NET desktop development** workload installed. The .NET SDK is automatically installed when you select this workload.

  For more information, see [Install the .NET SDK with Visual Studio](../install/windows.md#install-with-visual-studio).

## Create the app

Create a .NET console app project named "HelloWorld".

1. Start Visual Studio.

1. On the start page, choose **Create a new project**.

   :::image type="content" source="./media/with-visual-studio/start-window.png" alt-text="Create a new project button selected on the Visual Studio start page":::

1. On the **Create a new project** page, enter **console** in the search box. Next, choose **C#** or **Visual Basic** from the language list, and then choose **All platforms** from the platform list. Choose the **Console App** template, and then choose **Next**.

   :::image type="content" source="./media/with-visual-studio/create-new-project.png" alt-text="Create a new project window with filters selected":::

   > [!TIP]
   > If you don't see the .NET templates, you're probably missing the required workload. Under the **Not finding what you're looking for?** message, choose the **Install more tools and features** link. The Visual Studio Installer opens. Make sure you have the **.NET desktop development** workload installed.

1. In the **Configure your new project** dialog,  enter **HelloWorld** in the **Project name** box. Then choose **Next**.

   :::image type="content" source="./media/with-visual-studio/configure-new-project.png" alt-text="Configure your new project window with Project name, location, and solution name fields":::

1. In the **Additional information** dialog:
   - Select **.NET 10.0 (Long Term Support)**.
   - Select **Create**.

   :::image type="content" source="./media/with-visual-studio/additional-information.png" alt-text="Enter additional information for the console app.":::

   The template creates a simple application that displays "Hello, World!" in the console window. The code is in the *Program.cs* or *Program.vb* file:

   ```csharp
   // See https://aka.ms/new-console-template for more information
   Console.WriteLine("Hello, World!");
   ```

   ```vb
   Imports System

   Module Program
       Sub Main(args As String())
           Console.WriteLine("Hello World!")
       End Sub
   End Module
   ```

   If the language you want to use is not shown, change the language selector at the top of the page.

   The C# template uses top-level statements to call the <xref:System.Console.WriteLine(System.String)?displayProperty=nameWithType> method to display a message in the console window. The Visual Basic template defines a `Module Program` with a `Sub Main` method that calls the same method.

## Run the app

1. Press <kbd>Ctrl</kbd>+<kbd>F5</kbd> to run the program without debugging.

   A console window opens with the text "Hello, World!" printed on the screen. (Or "Hello World!" without a comma in the Visual Basic project template.)

1. Press any key to close the console window.

## Enhance the app

Enhance the application to prompt the user for their name and display it along with the date and time.

1. In *Program.cs* or *Program.vb*, replace the contents with the following code:

   :::code language="csharp" source="./snippets/with-visual-studio/csharp/Program.cs" id="MainMethod":::
   :::code language="vb" source="./snippets/with-visual-studio/vb/Program.vb" id="MainMethod":::

   This code displays a prompt in the console window and waits until the user enters a string followed by the <kbd>Enter</kbd> key. It stores this string in a variable named `name`. It also retrieves the value of the <xref:System.DateTime.Now?displayProperty=nameWithType> property, which contains the current local time, and assigns it to a variable named `currentDate`. And it displays these values in the console window. Finally, it displays a prompt in the console window and calls the <xref:System.Console.Read> method to wait for user input.

   <xref:System.Environment.NewLine?displayProperty=nameWithType> is a platform-independent and language-independent way to represent a line break. Alternatives are `\n` in C# and `vbCrLf` in Visual Basic.

   The dollar sign (`$`) in front of a string lets you put expressions such as variable names in curly braces in the string. The expression value is inserted into the string in place of the expression. This syntax is referred to as [interpolated strings](../../csharp/language-reference/tokens/interpolated.md).

1. Press <kbd>Ctrl</kbd>+<kbd>F5</kbd> to run the program without debugging.

1. Respond to the prompt by entering a name and pressing the <kbd>Enter</kbd> key.

   :::image type="content" source="./media/with-visual-studio/hello-world-update.png" alt-text="Console window with modified program output":::

1. Press any key to close the console window.

## Additional resources

- [Standard-term support (STS) releases and long-term support (LTS) releases](../releases-and-support.md#release-tracks).

## Next steps

In this tutorial, you created a .NET console application. In the next tutorial, you debug the app.

> [!div class="nextstepaction"]
> [Debug a .NET console application using Visual Studio](debugging-with-visual-studio.md)
