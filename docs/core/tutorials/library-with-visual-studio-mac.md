---
title: Create a .NET class library using Visual Studio for Mac
description: Learn how to create a .NET class library using Visual Studio for Mac.
ms.date: 11/30/2020
recommendations: false
---
# Tutorial: Create a .NET class library using Visual Studio for Mac

In this tutorial, you create a class library that contains a single string-handling method.

A *class library* defines types and methods that are called by an application. If the library targets .NET Standard 2.0, it can be called by any .NET implementation (including .NET Framework) that supports .NET Standard 2.0. If the library targets .NET 5, it can be called by any application that targets .NET 5. This tutorial shows how to target .NET 5.

> [!NOTE]
> Your feedback is highly valued. There are two ways you can provide feedback to the development team on Visual Studio for Mac:
>
> - In Visual Studio for Mac, select **Help** > **Report a Problem** from the menu or **Report a Problem** from the Welcome screen, which opens a window for filing a bug report. You can track your feedback in the [Developer Community](https://aka.ms/feedback/report?space=41) portal.
> - To make a suggestion, select **Help** > **Provide a Suggestion** from the menu or **Provide a Suggestion** from the Welcome screen, which takes you to the [Visual Studio for Mac Developer Community webpage](https://aka.ms/feedback/suggest?space=41).

## Prerequisites

* [Install Visual Studio for Mac version 8.8 or later](https://visualstudio.microsoft.com/vs/mac/?utm_medium=microsoft&utm_source=docs.microsoft.com&utm_campaign=inline+link). Select the option to install .NET Core. Installing Xamarin is optional for .NET development. For more information, see the following resources:

  * [Tutorial: Install Visual Studio for Mac](/visualstudio/mac/installation).
  * [Supported macOS versions](../install/macos.md).
  * [.NET versions supported by Visual Studio for Mac](/visualstudio/mac/net-core-support).

## Create a solution with a class library project

A Visual Studio solution serves as a container for one or more projects. Create a solution and a class library project in the solution. You'll add additional, related projects to the same solution later.

1. Start Visual Studio for Mac.

1. In the start window, select **New Project**.

1. In the **Choose a template for your new project** dialog select **Web and Console** > **Library** > **Class Library**, and then select **Next**.

   :::image type="content" source="media/library-with-visual-studio-mac/visual-studio-mac-new-project.png" alt-text="New Project dialog":::

1. In the **Configure your new Class Library** dialog, choose **.NET 5.0**, and select **Next**.

1. Name the project "StringLibrary" and the solution "ClassLibraryProjects". Leave **Create a project directory within the solution directory** selected. Select **Create**.

   :::image type="content" source="media/library-with-visual-studio-mac/visual-studio-mac-new-project-options.png" alt-text="Visual Studio for Mac New project dialog options":::

1. From the main menu, select **View** > **Solution**, and select the dock icon to keep the pad open.

   :::image type="content" source="media/library-with-visual-studio-mac/solution-dock-icon.png" alt-text="Dock icon for Solution pad":::

1. In the **Solution** pad, expand the `StringLibrary` node to reveal the class file provided by the template, *Class1.cs*. <kbd>ctrl</kbd>-click the file, select **Rename** from the context menu, and rename the file to *StringLibrary.cs*. Open the file and replace the contents with the following code:

   :::code language="csharp" source="./snippets/library-with-visual-studio/csharp/StringLibrary/Class1.cs":::

1. Press <kbd>⌘</kbd><kbd>S</kbd> (<kbd>command</kbd>+<kbd>S</kbd>) to save the file.

1. Select **Errors** in the margin at the bottom of the IDE window to open the **Errors** panel. Select the **Build Output** button.

   :::image type="content" source="media/library-with-visual-studio-mac/visual-studio-mac-error-button.png" alt-text="Bottom margin of the Visual Studio Mac IDE showing the Errors button":::

1. Select **Build** > **Build All** from the menu.

   The solution builds. The build output panel shows that the build is successful.

   :::image type="content" source="media/library-with-visual-studio-mac/visual-studio-mac-build-panel.png" alt-text="Visual Studio Mac Build output pane of the Errors panel with Build successful message":::

## Add a console app to the solution

Add a console application that uses the class library. The app will prompt the user to enter a string and report whether the string begins with an uppercase character.

1. In the **Solution** pad, <kbd>ctrl</kbd>-click the `ClassLibraryProjects` solution. Add a new **Console Application** project by selecting the template from the **Web and Console** > **App** templates, and select **Next**.

1. Select **.NET 5.0** as the **Target Framework** and select **Next**.

1. Name the project **ShowCase**. Select **Create** to create the project in the solution.

   :::image type="content" source="media/library-with-visual-studio-mac/add-showcase-project.png" alt-text="Add ShowCase project":::

1. Open the *Program.cs* file. Replace the code with the following code:

   :::code language="csharp" source="./snippets/library-with-visual-studio/csharp/ShowCase/Program.cs":::

   The program prompts the user to enter a string. It indicates whether the string starts with an uppercase character. If the user presses the <kbd>enter</kbd> key without entering a string, the application ends, and the console window closes.

   The code uses the `row` variable to maintain a count of the number of rows of data written to the console window. Whenever it's greater than or equal to 25, the code clears the console window and displays a message to the user.

## Add a project reference

Initially, the new console app project doesn't have access to the class library. To allow it to call methods in the class library, create a project reference to the class library project.

1. In the **Solutions** pad, <kbd>ctrl</kbd>-click the **Dependencies** node of the new **ShowCase** project. In the context menu, select **Add Reference**.

1. In the **References** dialog, select **StringLibrary** and select **OK**.

## Run the app

1. <kbd>ctrl</kbd>-click the **ShowCase** project and select **Run project** from the context menu.

1. Try out the program by entering strings and pressing <kbd>enter</kbd>, then press <kbd>enter</kbd> to exit.

   :::image type="content" source="media/library-with-visual-studio-mac/visual-studio-mac-console-window.png" alt-text="Visual Studio for Mac console window showing your app running":::

## Additional resources

* [Develop libraries with the .NET CLI](libraries.md)
* [Visual Studio 2019 for Mac Release Notes](/visualstudio/releasenotes/vs2019-mac-relnotes)
* [.NET Standard versions and the platforms they support](../../standard/net-standard.md).

## Next steps

In this tutorial, you created a solution and a library project, and added a console app project that uses the library. In the next tutorial, you add a unit test project to the solution.

> [!div class="nextstepaction"]
> [Test a .NET class library using Visual Studio for Mac](testing-library-with-visual-studio-mac.md)
