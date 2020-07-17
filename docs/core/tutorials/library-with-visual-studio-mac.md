---
title: Create a .NET Standard class library using Visual Studio for Mac
description: Learn how to create a .NET Standard class library using Visual Studio for Mac.
ms.date: 06/08/2020
---
# Tutorial: Create a .NET Standard library using Visual Studio for Mac

In this tutorial, you create a class library that contains a single string-handling method. You implement it as an [extension method](../../csharp/programming-guide/classes-and-structs/extension-methods.md) so that you can call it as if it were a member of the <xref:System.String> class.

A *class library* defines types and methods that are called by an application. A class library that targets .NET Standard 2.1 can be used by an application that targets any .NET implementation that supports version 2.1 of .NET Standard. When you finish your class library, you can distribute it as a third-party component or as a bundled component with one or more applications.

> [!NOTE]
> Your feedback is highly valued. There are two ways you can provide feedback to the development team on Visual Studio for Mac:
>
> - In Visual Studio for Mac, select **Help** > **Report a Problem** from the menu or **Report a Problem** from the Welcome screen, which opens a window for filing a bug report. You can track your feedback in the [Developer Community](https://developercommunity.visualstudio.com/spaces/41/index.html) portal.
> - To make a suggestion, select **Help** > **Provide a Suggestion** from the menu or **Provide a Suggestion** from the Welcome screen, which takes you to the [Visual Studio for Mac Developer Community webpage](https://developercommunity.visualstudio.com/content/idea/post.html?space=41).

## Prerequisites

* [Install Visual Studio for Mac version 8.6 or later](https://visualstudio.microsoft.com/vs/mac/?utm_medium=microsoft&utm_source=docs.microsoft.com&utm_campaign=inline+link). Select the option to install .NET Core. Installing Xamarin is optional for .NET Core development. For more information, see the following resources:

  * [Tutorial: Install Visual Studio for Mac](/visualstudio/mac/installation).
  * [Supported macOS versions](../install/dependencies.md?pivots=os-macos).
  * [.NET Core versions supported by Visual Studio for Mac](/visualstudio/mac/net-core-support).

## Create a solution with a class library project

A Visual Studio solution serves as a container for one or more projects. Create a solution and a class library project in the solution. You'll add additional, related projects to the same solution later.

1. Start Visual Studio for Mac.

1. In the start window, select **New Project**.

1. In the **New Project** dialog under the **Multi-Platform** node, select **Library**, then select the **.NET Standard Library** template, and select **Next**.

   :::image type="content" source="media/library-with-visual-studio-mac/visual-studio-mac-new-project.png" alt-text="New Project dialog":::

1. In the **Configure your new .NET Standard Library** dialog, choose ".NET Standard 2.1", and select **Next**.

   :::image type="content" source="media/library-with-visual-studio-mac/choose-net-std-21.png" alt-text="Choose .NET Standard 2.1":::

1. Name the project "StringLibrary" and the solution "ClassLibraryProjects". Leave **Create a project directory within the solution directory** selected. Select **Create**.

   :::image type="content" source="media/library-with-visual-studio-mac/visual-studio-mac-new-project-options.png" alt-text="Visual Studio for Mac New project dialog options":::

1. From the main menu, select **View** > **Pads** > **Solution**, and select the dock icon to keep the pad open.

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

1. Select **.NET Core 3.1** as the **Target Framework** and select **Next**.

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

1. <kbd>ctrl</kbd>-click on the ShowCase project and select **Run project** from the context menu.

1. Try out the program by entering strings and pressing <kbd>enter</kbd>, then press <kbd>enter</kbd> to exit.

   :::image type="content" source="media/library-with-visual-studio-mac/visual-studio-mac-console-window.png" alt-text="Visual Studio for Mac console window showing your app running":::

## Additional resources

* [Develop libraries with the .NET Core CLI](libraries.md)
* [.NET Standard versions and the platforms they support](../../standard/net-standard.md).
* [Visual Studio 2019 for Mac Release Notes](/visualstudio/releasenotes/vs2019-mac-relnotes)

## Next steps

In this tutorial, you created a solution and a library project, and added a console app project that uses the library. In the next tutorial, you add a unit test project to the solution.

> [!div class="nextstepaction"]
> [Test a .NET Standard library with .NET Core using Visual Studio for Mac](testing-library-with-visual-studio-mac.md)
