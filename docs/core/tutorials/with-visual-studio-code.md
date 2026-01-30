---
title: Create a .NET console application using Visual Studio Code
description: Learn how to create a .NET console application using Visual Studio Code.
ms.date: 01/26/2026
zone_pivot_groups: code-editor-set-one
---
# Tutorial: Create a .NET console application using Visual Studio Code

::: zone pivot="vscode"

This tutorial shows how to create and run a .NET console application by using Visual Studio Code.

In this tutorial, you:

> [!div class="checklist"]
>
> * Launch Visual Studio Code with a C# development environment.
> * Create a "HelloWorld" .NET console application.
> * Enhance the app to prompt the user for their name and display it in the console window.

::: zone-end

::: zone pivot="codespaces"

This tutorial shows how to create and run a .NET console application by using GitHub Codespaces.

In this tutorial, you:

> [!div class="checklist"]
>
> * Launch a GitHub Codespace with a C# development environment.
> * Create a "HelloWorld" .NET single-file app.
> * Enhance the app to prompt the user for their name and display it in the console window.

::: zone-end

## Prerequisites

::: zone pivot="vscode"

[!INCLUDE [Prerequisites](../../../includes/prerequisites-basic-winget.md)]

::: zone-end

::: zone pivot="codespaces"

- A GitHub account to use [GitHub Codespaces](https://github.com/codespaces). If you don't already have one, you can create a free account at [GitHub.com](https://github.com).

::: zone-end

## Create the app

::: zone pivot="vscode"

Create a .NET console app project named "HelloWorld".

1. Start Visual Studio Code.

1. Go to the Explorer view and select **Create .NET Project**. Alternatively, you can bring up the Command Palette using Ctrl+Shift+P (Command+Shift+P on MacOS) and then type ".NET" and find and select the .NET: New Project command.

    :::image type="content" source="media/with-visual-studio-code/create-dotnet-project.png" alt-text="The .NET: New Project command in the Command Palette":::

1. After selecting the command, you need to choose the project template. Choose **Console App**.

1. Select the location where you would like the new project to be created.

1. Give your new project a name, "HelloWorld".

1. Select **.sln** for the solution file format.

1. Select **Create Project**.

1. The project is created and the *Program.cs* file opens. You see the simple application created by the template:

   ```csharp
   // See https://aka.ms/new-console-template for more information
   Console.WriteLine("Hello, World!");
   ```

    The code defines a class, `Program`, that calls the <xref:System.Console.WriteLine(System.String)?displayProperty=nameWithType> method to display a message in the console window.

::: zone-end

::: zone pivot="codespaces"

### Open Codespaces

Start a GitHub Codespace with the tutorial environment.

1. Open a browser window and navigate to the [tutorial codespace](https://github.com/dotnet/tutorial-codespace) repository.

1. Select the green **Code** button, and then the **Codespaces** tab.

1. Select the `+` sign or the green **Create codespace on main** button to create a new Codespace using this environment.

    :::image type="content" source="media/with-visual-studio-code/create-codespace-on-main.png" alt-text="Create a new Codespace from the tutorial repository":::

### Create a .NET file-based app

In Codespaces, you'll create a [file-based app](../sdk/file-based-apps.md). File-based apps let you build .NET applications from a single C# file without creating a traditional project file.

1. When your codespace loads, right-click on the *tutorials* folder and select **New File...**. Enter the name *HelloWorld.cs* and then press <kbd>Enter</kbd>.

    :::image type="content" source="media/with-visual-studio-code/codespaces-create-new-file.png" alt-text="Create a new file named HelloWorld.cs in the tutorials folder":::

1. *HelloWorld.cs* opens in the editor. Type or copy the following code into the file:

    :::code language="csharp" source="./snippets/with-visual-studio-code/csharp/HelloWorld.cs" id="HelloWorld":::

::: zone-end

## Run the app

::: zone pivot="vscode"

To run your app, select **Run** > **Run without Debugging** in the upper menu, or use the keyboard shortcut (Ctrl+F5).

If asked to select a debugger, select **C#** as the debugger, then select **C#: Debug Active File** as the Launch configuration.

The program displays "Hello, World!" and ends.

::: zone-end

::: zone pivot="codespaces"

In the terminal window, make sure the tutorials folder is the current folder, and run your program:

```dotnetcli
cd tutorials
dotnet HelloWorld.cs
```

The program displays "Hello, World!" and ends.

::: zone-end

## Enhance the app

Enhance the application to prompt the user for their name and display it along with the date and time.

::: zone pivot="vscode"

1. Open *Program.cs*.

1. Replace the contents of the class with the following code:

   :::code language="csharp" source="./snippets/with-visual-studio/csharp/Program-Read.cs" id="MainMethod":::

   This code displays a prompt in the console window and waits until the user enters a string followed by the <kbd>Enter</kbd> key. It stores this string in a variable named `name`. It also retrieves the value of the <xref:System.DateTime.Now?displayProperty=nameWithType> property, which contains the current local time, and assigns it to a variable named `currentDate`. And it displays these values in the console window. Finally, it displays a prompt in the console window and calls the <xref:System.Console.Read> method to wait for user input.

   <xref:System.Environment.NewLine> is a platform-independent and language-independent way to represent a line break. It's the same as `\n` in C#.

   The dollar sign (`$`) in front of a string lets you put expressions such as variable names in curly braces in the string. The expression value is inserted into the string in place of the expression. This syntax is referred to as [interpolated strings](../../csharp/language-reference/tokens/interpolated.md).

1. Save your changes.

   > [!IMPORTANT]
   > In Visual Studio Code, you have to explicitly save changes. Unlike Visual Studio, file changes are not automatically saved when you build and run an app.

1. Select **Run**>**Run without debugging**.

1. Respond to the prompt by entering a name and pressing the <kbd>Enter</kbd> key.

   :::image type="content" source="media/with-visual-studio-code/run-program-class.png" alt-text="Terminal window with modified program output":::

    Press <kbd>Enter</kbd> to exit the program.

::: zone-end

::: zone pivot="codespaces"

1. Update *HelloWorld.cs* with the following code:

    :::code language="csharp" source="./snippets/with-visual-studio-code/csharp/HelloWorld.cs" id="MainMethod":::

   This code displays a prompt in the console window and waits until the user enters a string followed by the <kbd>Enter</kbd> key. It stores this string in a variable named `name`. It also retrieves the value of the <xref:System.DateTime.Now?displayProperty=nameWithType> property, which contains the current local time, and assigns it to a variable named `currentDate`. And it displays these values in the console window. Finally, it displays a prompt in the console window and calls the <xref:System.Console.Read> method to wait for user input.

   <xref:System.Environment.NewLine> is a platform-independent and language-independent way to represent a line break. It's the same as `\n` in C#.

   The dollar sign (`$`) in front of a string lets you put expressions such as variable names in curly braces in the string. The expression value is inserted into the string in place of the expression. This syntax is referred to as [interpolated strings](../../csharp/language-reference/tokens/interpolated.md).

1. Run the updated app using the following command:

   ```dotnetcli
   dotnet HelloWorld.cs
   ```

1. Respond to the prompt by entering a name and pressing the <kbd>Enter</kbd> key.

   You'll see output similar to the following:

   ```output
   What is your name? Mark
   Hello, Mark, on 1/29/2026 at 4:40 PM!
   Press Enter to exit...
   ```

Press <kbd>Enter</kbd> to exit the program.

::: zone-end

## Additional resources

::: zone pivot="vscode"

* [Setting up Visual Studio Code](https://code.visualstudio.com/docs/setup/setup-overview)

::: zone-end

::: zone pivot="codespaces"

* [GitHub Codespaces documentation](https://docs.github.com/codespaces)
* [Getting started with GitHub Codespaces](https://docs.github.com/codespaces/getting-started)

## Cleanup resources

GitHub automatically deletes your Codespace after 30 days of inactivity. If you plan to explore more tutorials in this series, you can leave your Codespace provisioned. If you're ready to visit the [.NET site](https://dotnet.microsoft.com/download/dotnet) to download the .NET SDK, you can delete your Codespace. To delete your Codespace, open a browser window and navigate to [your Codespaces](https://github.com/codespaces). You see a list of your codespaces in the window. Select the three dots (`...`) in the entry for the learn tutorial codespace. Then select "delete".

::: zone-end

## Next steps

In this tutorial, you created a .NET console application. In the next tutorial, you debug the app.

> [!div class="nextstepaction"]
> [Debug a .NET console application using Visual Studio Code](debugging-with-visual-studio-code.md)
