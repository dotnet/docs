---
title: Create a .NET console application using Visual Studio
description: Learn how to create a .NET console application with C# or Visual Basic using Visual Studio.
ms.date: 09/02/2021
zone_pivot_groups: dotnet-version
dev_langs:
  - "csharp"
  - "vb"
ms.custom: "vs-dotnet,contperf-fy21q3"
recommendations: false
---
# Tutorial: Create a .NET console application using Visual Studio

::: zone pivot="dotnet-6-0"

This tutorial shows how to create and run a .NET console application in Visual Studio 2022.

## Prerequisites

- [Visual Studio 2022 version 17.0.0 Preview](https://visualstudio.microsoft.com/downloads/?utm_medium=microsoft&utm_source=docs.microsoft.com&utm_campaign=inline+link&utm_content=download+vs2022) with the **.NET desktop development** workload installed. The .NET 6.0 SDK is automatically installed when you select this workload.

  For more information, see [Install the .NET SDK with Visual Studio](../install/windows.md#install-with-visual-studio).

## Create the app

Create a .NET console app project named "HelloWorld".

1. Start Visual Studio 2022.

1. On the start page, choose **Create a new project**.

   :::image type="content" source="./media/with-visual-studio/start-window-2022.png" alt-text="Create a new project button selected on the Visual Studio start page":::

1. On the **Create a new project** page, enter **console** in the search box. Next, choose **C#** or **Visual Basic** from the language list, and then choose **All platforms** from the platform list. Choose the **Console Application** template, and then choose **Next**.

   :::image type="content" source="./media/with-visual-studio/create-new-project.png" alt-text="Create a new project window with filters selected":::

   > [!TIP]
   > If you don't see the .NET templates, you're probably missing the required workload. Under the **Not finding what you're looking for?** message, choose the **Install more tools and features** link. The Visual Studio Installer opens. Make sure you have the **.NET desktop development** workload installed.

1. In the **Configure your new project** dialog,  enter **HelloWorld** in the **Project name** box. Then choose **Next**.

   :::image type="content" source="./media/with-visual-studio/configure-new-project.png" alt-text="Configure your new project window with Project name, location, and solution name fields":::

1. In the **Additional information** dialog, select **.NET 6.0 (Preview)**, and then select **Create**.

The template creates a simple application that displays "Hello World" in the console window. The code is in the *Program.cs* or *Program.vb* file:

```csharp
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

For C#, the code is just a line that calls the <xref:System.Console.WriteLine(System.String)?displayProperty=nameWithType> method to display "Hello World!" in the console window. Replace the contents of *Program.cs* with the following code:

```csharp
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
' This step of the tutorial applies only to C#.
```

The code defines a class, `Program`, with a single method, `Main`, that takes a <xref:System.String> array as an argument.
`Main` is the application entry point, the method that's called automatically by the runtime when it launches the application. Any command-line arguments supplied when the application is launched are available in the *args* array.

In the latest version of C#, a new feature named [top-level statements](../../csharp/fundamentals/program-structure/top-level-statements.md) lets you omit the `Program` class and the `Main` method. Most existing C# programs don't use top-level statements, so this tutorial doesn't use this new feature. But it's available in C# 10, and whether you use it in your programs is a matter of style preference.

## Run the app

1. Press <kbd>Ctrl</kbd>+<kbd>F5</kbd> to run the program without debugging.

   A console window opens with the text "Hello World!" printed on the screen.

   :::image type="content" source="./media/with-visual-studio/hello-world-console-net6.png" alt-text="Console window showing Hello World Press any key to continue":::

1. Press any key to close the console window.

## Enhance the app

Enhance the application to prompt the user for their name and display it along with the date and time.

1. In *Program.cs* or *Program.vb*, replace the contents of the `Main` method, which is the line that calls `Console.WriteLine`, with the following code:

   :::code language="csharp" source="./snippets/with-visual-studio/csharp/Program.cs" id="MainMethod":::
   :::code language="vb" source="./snippets/with-visual-studio/vb/Program.vb" id="MainMethod":::

   This code displays a prompt in the console window and waits until the user enters a string followed by the <kbd>Enter</kbd> key. It stores this string in a variable named `name`. It also retrieves the value of the <xref:System.DateTime.Now?displayProperty=nameWithType> property, which contains the current local time, and assigns it to a variable named `currentDate`. And it displays these values in the console window. Finally, it displays a prompt in the console window and calls the <xref:System.Console.ReadKey(System.Boolean)?displayProperty=nameWithType> method to wait for user input.

   <xref:System.Environment.NewLine?displayProperty=nameWithType> is a platform-independent and language-independent way to represent a line break. Alternatives are `\n` in C# and `vbCrLf` in Visual Basic.

   The dollar sign (`$`) in front of a string lets you put expressions such as variable names in curly braces in the string. The expression value is inserted into the string in place of the expression. This syntax is referred to as [interpolated strings](../../csharp/language-reference/tokens/interpolated.md).

1. Press <kbd>Ctrl</kbd>+<kbd>F5</kbd> to run the program without debugging.

1. Respond to the prompt by entering a name and pressing the <kbd>Enter</kbd> key.

   :::image type="content" source="./media/with-visual-studio/hello-world-update-net6.png" alt-text="Console window with modified program output":::

1. Press any key to close the console window.

## Additional resources

- [Current releases and long-term support releases](../releases-and-support.md#net-core-and-net-5-version-lifecycles)

## Next steps

In this tutorial, you created a .NET console application. In the next tutorial, you debug the app.

> [!div class="nextstepaction"]
> [Debug a .NET console application using Visual Studio](debugging-with-visual-studio.md)

::: zone-end

::: zone pivot="dotnet-5-0"

This tutorial shows how to create and run a .NET console application in Visual Studio 2019.

## Prerequisites

- [Visual Studio 2019 version 16.9.2 or a later version](https://visualstudio.microsoft.com/downloads/?utm_medium=microsoft&utm_source=docs.microsoft.com&utm_campaign=inline+link&utm_content=download+vs2019) with the **.NET Core cross-platform development** workload installed. The .NET 5.0 SDK is automatically installed when you select this workload.

  For more information, see [Install the .NET SDK with Visual Studio](../install/windows.md#install-with-visual-studio).

## Create the app

Create a .NET console app project named "HelloWorld".

1. Start Visual Studio 2019.

1. On the start page, choose **Create a new project**.

   :::image type="content" source="./media/with-visual-studio/start-window.png" alt-text="Create a new project button selected on the Visual Studio start page":::

1. On the **Create a new project** page, enter **console** in the search box. Next, choose **C#** or **Visual Basic** from the language list, and then choose **All platforms** from the platform list. Choose the **Console Application** template, and then choose **Next**.

   :::image type="content" source="./media/with-visual-studio/create-new-project.png" alt-text="Create a new project window with filters selected":::

   > [!TIP]
   > If you don't see the .NET templates, you're probably missing the required workload. Under the **Not finding what you're looking for?** message, choose the **Install more tools and features** link. The Visual Studio Installer opens. Make sure you have the **.NET Core cross-platform development** workload installed.

1. In the **Configure your new project** dialog,  enter **HelloWorld** in the **Project name** box. Then choose **Next**.

   :::image type="content" source="./media/with-visual-studio/configure-new-project.png" alt-text="Configure your new project window with Project name, location, and solution name fields":::

1. In the **Additional information** dialog, select **.NET 5.0 (Current)**, and then select **Create**.

   :::image type="content" source="media/with-visual-studio/additional-info.png" alt-text="Additional information dialog":::

The template creates a simple "Hello World" application. It calls the <xref:System.Console.WriteLine(System.String)?displayProperty=nameWithType> method to display "Hello World!" in the console window.

The template code defines a class, `Program`, with a single method, `Main`, that takes a <xref:System.String> array as an argument:

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

`Main` is the application entry point, the method that's called automatically by the runtime when it launches the application. Any command-line arguments supplied when the application is launched are available in the *args* array.

If the language you want to use is not shown, change the language selector at the top of the page.

## Run the app

1. Press <kbd>Ctrl</kbd>+<kbd>F5</kbd> to run the program without debugging.

   A console window opens with the text "Hello World!" printed on the screen.

   :::image type="content" source="./media/with-visual-studio/hello-world-console.png" alt-text="Console window showing Hello World Press any key to continue":::

1. Press any key to close the console window.

## Enhance the app

Enhance the application to prompt the user for their name and display it along with the date and time.

1. In *Program.cs* or *Program.vb*, replace the contents of the `Main` method, which is the line that calls `Console.WriteLine`, with the following code:

   :::code language="csharp" source="./snippets/with-visual-studio/csharp/Program.cs" id="MainMethod":::
   :::code language="vb" source="./snippets/with-visual-studio/vb/Program.vb" id="MainMethod":::

   This code displays a prompt in the console window and waits until the user enters a string followed by the <kbd>Enter</kbd> key. It stores this string in a variable named `name`. It also retrieves the value of the <xref:System.DateTime.Now?displayProperty=nameWithType> property, which contains the current local time, and assigns it to a variable named `currentDate`. And it displays these values in the console window. Finally, it displays a prompt in the console window and calls the <xref:System.Console.ReadKey(System.Boolean)?displayProperty=nameWithType> method to wait for user input.

   <xref:System.Environment.NewLine?displayProperty=nameWithType> is a platform-independent and language-independent way to represent a line break. Alternatives are `\n` in C# and `vbCrLf` in Visual Basic.

   The dollar sign (`$`) in front of a string lets you put expressions such as variable names in curly braces in the string. The expression value is inserted into the string in place of the expression. This syntax is referred to as [interpolated strings](../../csharp/language-reference/tokens/interpolated.md).

1. Press <kbd>Ctrl</kbd>+<kbd>F5</kbd> to run the program without debugging.

1. Respond to the prompt by entering a name and pressing the <kbd>Enter</kbd> key.

   :::image type="content" source="./media/with-visual-studio/hello-world-update.png" alt-text="Console window with modified program output":::

1. Press any key to close the console window.

## Additional resources

- [Current releases and long-term support releases](../releases-and-support.md#net-core-and-net-5-version-lifecycles)

## Next steps

In this tutorial, you created a .NET console application. In the next tutorial, you debug the app.

> [!div class="nextstepaction"]
> [Debug a .NET console application using Visual Studio](debugging-with-visual-studio.md)

::: zone-end

::: zone pivot="dotnet-core-3-1"

This tutorial is only available for .NET 5 and .NET 6. Select one of those options at the top of the page.

::: zone-end
