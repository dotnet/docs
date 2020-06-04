---
title: Create a .NET Standard class library in Visual Studio for Mac
description: Learn how to create a .NET Standard class library using Visual Studio for Mac.
ms.date: 06/03/2020
---
# Tutorial: Create a .NET Standard library in Visual Studio for Mac

In this tutorial, you create a simple class library that contains a single string-handling method. You implement it as an [extension method](../../csharp/programming-guide/classes-and-structs/extension-methods.md) so that you can call it as if it were a member of the <xref:System.String> class.

A *class library* defines types and methods that are called by an application. A class library that targets .NET Standard 2.1 can be used by an application that targets any .NET implementation that supports version 2.1 of .NET Standard. When you finish your class library, you can decide whether you want to distribute it as a third-party component or whether you want to include it as a bundled component with one or more applications.

> [!NOTE]
> Your feedback is highly valued. There are two ways you can provide feedback to the development team on Visual Studio for Mac:
>
> - In Visual Studio for Mac, select **Help** > **Report a Problem** from the menu or **Report a Problem** from the Welcome screen, which opens a window for filing a bug report. You can track your feedback in the [Developer Community](https://developercommunity.visualstudio.com/spaces/41/index.html) portal.
> - To make a suggestion, select **Help** > **Provide a Suggestion** from the menu or **Provide a Suggestion** from the Welcome screen, which takes you to the [Visual Studio for Mac Developer Community webpage](https://developercommunity.visualstudio.com/content/idea/post.html?space=41).

## Prerequisites

* [Install Visual Studio for Mac](https://visualstudio.microsoft.com/vs/mac/?utm_medium=microsoft&utm_source=docs.microsoft.com&utm_campaign=inline+link). Select the option to install .NET Core. Installing Xamarin is optional for .NET Core development. For more information, see the following resources:

  * [Tutorial: Install Visual Studio for Mac](/visualstudio/mac/installation).
  * [Supported macOS versions](../install/dependencies.md?pivots=os-macos).
  * [.NET Core versions supported by Visual Studio for Mac](/visualstudio/mac/net-core-support).

## Create a solution with a library project

A Visual Studio solution serves as a container for one or more projects. Create a solution and a class library project in the solution. You'll add additional, related projects to the same solution later.

1. Start Visual Studio for Mac.

1. On the start window, select **New Project**.

1. In the **New Project** dialog under the **.NET Core** node, select the **.NET Standard Library** template. Choose ".NET Standard 2.1" and select **Next**.

   > [!div class="mx-imgBorder"]
   > ![Visual Studio for Mac New project dialog](./media/using-on-mac-vs-full-solution/visual-studio-mac-new-project.png)

1. Name the project "StringLibrary" and the solution "ClassLibraryProjects". Leave **Create a project directory within the solution directory** selected. Select **Create**.

   > [!div class="mx-imgBorder"]
   > ![Visual Studio for Mac New project dialog options](./media/using-on-mac-vs-full-solution/visual-studio-mac-new-project-options.png)

1. In the **Solution** pad, expand the `StringLibrary` node to reveal the class file provided by the template, *Class1.cs*. <kbd>control</kbd>-click the file, select **Rename** from the context menu, and rename the file to *StringLibrary.cs*. Open the file and replace the contents with the following code:

   :::code language="csharp" source="./snippets/library-with-visual-studio/csharp/StringLibrary/Class1.cs":::

1. Press ⌘ s (<kbd>command</kbd>+<kbd>s</kbd>) to save the file.

   The following image shows the IDE window:

   > [!div class="mx-imgBorder"]
   > ![Visual Studio for Mac IDE window with class library file and method](./media/using-on-mac-vs-full-solution/visual-studio-mac-editor.png)

1. Select **Errors** in the margin at the bottom of the IDE window to open the **Errors** panel. Select the **Build Output** button.

   > [!div class="mx-imgBorder"]
   > ![Bottom margin of the Visual Studio Mac IDE showing the Errors button](./media/using-on-mac-vs-full-solution/visual-studio-mac-error-button.png)

1. Select **Build** > **Build All** from the menu.

   The solution builds. The build output panel shows that the build is successful.

   > [!div class="mx-imgBorder"]
   > ![Visual Studio Mac Build output pane of the Errors panel with Build successful message](./media/using-on-mac-vs-full-solution/visual-studio-mac-build-panel.png)

## Add a console app project

1. In the **Solution** sidebar, <kbd>control</kbd>-click the `ClassLibraryProjects` solution. Add a new **Console Application** project by selecting the template from the **.NET Core** > **App** templates. Select **Next**. Name the project **ShowCase**. Select **Create** to create the project in the solution.

1. In the **Solutions** sidebar, <kbd>control</kbd>-click the **Dependencies** node of the new **ShowCase** project. In the **Edit References** dialog, select **StringLibrary** and select **OK**.

1. Open the *Program.cs* file. Replace the code with the following code:

   :::code language="csharp" source="./snippets/library-with-visual-studio/csharp/ShowCase/Program.cs":::

   The program prompts the user to enter a string. It indicates whether the string starts with an uppercase character. If the user presses the Enter key without entering a string, the application ends, and the console window closes.

   The code uses the `row` variable to maintain a count of the number of rows of data written to the console window. Whenever it's greater than or equal to 25, the code clears the console window and displays a message to the user.

1. <kbd>control</kbd>-click on the ShowCase project and select **Run project** from the context menu.

1. Try out the program by entering strings and pressing <kbd>Enter</kbd>, then press <kbd>Enter</kbd> to exit.

   > [!div class="mx-imgBorder"]
   > ![Visual Studio for Mac console window showing your app running](./media/using-on-mac-vs-full-solution/visual-studio-mac-console-window.png)

## Additional resources

- [Visual Studio 2019 for Mac Release Notes](/visualstudio/releasenotes/vs2019-mac-relnotes)
- [.NET Standard versions and the platforms they support](../../standard/net-standard.md).

## Next steps

In this tutorial, you created a solution, added a library project, and added a console app project that uses the library. In the next tutorial, you add a unit test project to the solution.

> [!div class="nextstepaction"]
> [Test a .NET Standard library with .NET Core in Visual Studio](testing-library-with-visual-studio.md)





## Creating a test project

Unit tests provide automated software testing during your development and publishing. The testing framework that you use in this tutorial is [xUnit (version 2.4.0 or later)](https://xunit.github.io/), which is installed automatically when the xUnit test project is added to the solution in the following steps:

1. In the **Solution** sidebar, ctrl-click the `WordCounter` solution and select **Add** > **Add New Project**.

1. In the **New Project** dialog, select **Tests** from the **.NET Core** node. Select the **xUnit Test Project** followed by **Next**.

   > [!div class="mx-imgBorder"]
   > ![Visual Studio Mac New Project dialog creating xUnit test project](./media/using-on-mac-vs-full-solution/visual-studio-mac-unit-test-project.png)

1. If you have multiple versions of the .NET Core SDK, you'll need to select the version for this project. Select **.NET Core 3.1**. Name the new project "TestLibrary" and select **Create**.

   > [!div class="mx-imgBorder"]
   > ![Visual Studio Mac New Project dialog providing project name](./media/using-on-mac-vs-full-solution/visual-studio-mac-new-project-name.png)

1. In order for the test library to work with the `WordCount` class, add a reference to the `TextUtils` project. In the **Solution** sidebar, ctrl-click **Dependencies** under **TestLibrary**. Select **Edit References** from the context menu.

1. In the **Edit References** dialog, select the **TextUtils** project on the **Projects** tab. Select **OK**.

   > [!div class="mx-imgBorder"]
   > ![Visual Studio Mac Edit References dialog](./media/using-on-mac-vs-full-solution/visual-studio-mac-edit-references.png)

1. In the **TestLibrary** project, rename the *UnitTest1.cs* file to *TextUtilsTests.cs*.

1. Open the file and replace the code with the following code:

   ```csharp
   using Xunit;
   using TextUtils;
   using System.Diagnostics;

   namespace TestLibrary
   {
       public class TextUtils_GetWordCountShould
       {
           [Fact]
           public void IgnoreCasing()
           {
               var wordCount = WordCount.GetWordCount("Jack", "Jack jack");

               Assert.NotEqual(2, wordCount);
           }
       }
   }
   ```

   The following image shows the IDE with the unit test code in place. Pay attention to the `Assert.NotEqual` statement.

   > [!div class="mx-imgBorder"]
   > ![Visual Studio for Mac Initial unit test in the IDE main window](./media/using-on-mac-vs-full-solution/visual-studio-mac-assert-test.png)

   It's important to make a new test fail once to confirm its testing logic is correct. The method passes in the name "Jack" (uppercase) and a string with "Jack" and "jack" (uppercase and lowercase). If the `GetWordCount` method is working properly, it returns a count of two instances of the search word. In order to fail this test on purpose, you first implement the test asserting that two instances of the search word "Jack" aren't returned by the `GetWordCount` method. Continue to the next step to fail the test on purpose.

1. Open the **Unit Tests** panel on the right side of the screen. Select **View** > **Tests** from the menu.

   > [!div class="mx-imgBorder"]
   > ![Visual Studio for Mac Unit Tests panel](./media/using-on-mac-vs-full-solution/visual-studio-mac-unit-test-panel.png)

1. Click the **Dock** icon to keep the panel open. (Highlighted in the following image.)

   > [!div class="mx-imgBorder"]
   > ![Visual Studio for Mac Unit Tests panel dock icon](./media/using-on-mac-vs-full-solution/visual-studio-mac-unit-test-dock-icon.png)

1. Click the **Run All** button.

   The test fails, which is the correct result. The test method asserts that two instances of the `inputString`, "Jack," aren't returned from the string "Jack jack" provided to the `GetWordCount` method. Since word casing was factored out in the `GetWordCount` method, two instances are returned. The assertion that 2 *is not equal to* 2 fails. This result is the correct outcome, and the logic of our test is good.

   > [!div class="mx-imgBorder"]
   > ![Visual Studio for Mac test failure display](./media/using-on-mac-vs-full-solution/visual-studio-for-mac-unit-test-failure.png)

1. Modify the `IgnoreCasing` test method by changing `Assert.NotEqual` to `Assert.Equal`. Save the file by using the keyboard shortcut <kbd>Ctrl</kbd>+<kbd>s</kbd>, **File** > **Save** from the menu, or ctrl-clicking on the file's tab and selecting **Save** from the context menu.

   You expect that the `searchWord` "Jack" returns two instances with `inputString` "Jack jack" passed into `GetWordCount`. Run the test again by clicking the **Run Tests** button in the **Unit Tests** panel or the **Rerun Tests** button in the **Test Results** panel at the bottom of the screen. The test passes. There are two instances of "Jack" in the string "Jack jack" (ignoring casing), and the test assertion is `true`.

   > [!div class="mx-imgBorder"]
   > ![Visual Studio for Mac tests pass display](./media/using-on-mac-vs-full-solution/visual-studio-mac-unit-test-pass.png)

1. Testing individual return values with a `Fact` is only the beginning of what you can do with unit testing. Another powerful technique allows you to test several values at once using a `Theory`. Add the following method to your `TextUtils_GetWordCountShould` class. You have two methods in the class after you add this method:

   ```csharp
   [Theory]
   [InlineData(0, "Ting", "Does not appear in the string.")]
   [InlineData(1, "Ting", "Ting appears once.")]
   [InlineData(2, "Ting", "Ting appears twice with Ting.")]
   public void CountInstancesCorrectly(int count,
                                       string searchWord,
                                       string inputString)
   {
       Assert.NotEqual(count, WordCount.GetWordCount(searchWord,
                                                  inputString));
   }
   ```

   The `CountInstancesCorrectly` checks that the `GetWordCount` method counts correctly. The `InlineData` provides a count, a search word, and an input string to check. The test method runs once for each line of data. Note once again that you're asserting a failure first by using `Assert.NotEqual`, even when you know that the counts in the data are correct and that the values match the counts returned by the `GetWordCount` method. Performing the step of failing the test on purpose might seem like a waste of time at first, but checking the logic of the test by failing it first is an important check on the logic of your tests. When you come across a test method that passes when you expect it to fail, you've found a bug in the logic of the test. It's worth the effort to take this step every time you create a test method.

1. Save the file and run the tests again. The casing test passes but the three count tests fail. This outcome is exactly what you expect to happen.

   > [!div class="mx-imgBorder"]
   > ![Visual Studio for Mac expected test failure](./media/using-on-mac-vs-full-solution/visual-studio-mac-unit-test-failure.png)

1. Modify the `CountInstancesCorrectly` test method by changing `Assert.NotEqual` to `Assert.Equal`. Save the file. Run the tests again. All tests pass.

   > [!div class="mx-imgBorder"]
   > ![Visual Studio for Mac expected test passes](./media/using-on-mac-vs-full-solution/visual-studio-mac-unit-test-pass.png)

You can use the same process to debug code using your unit test project. Instead of starting the WordCount app project, ctrl-click the **Test Library** project, and select **Start Debugging Project** from the context menu. Visual Studio for Mac starts your test project with the debugger attached. Execution will stop at any breakpoint you've added to the test project, or the underlying library code.
