---
title: Test a .NET Standard class library with .NET Core using Visual Studio
description: Create a unit test project for a .NET Core class library. Verify that a .NET Core class library works correctly with unit tests.
ms.date: 06/08/2020
dev_langs:
  - "csharp"
  - "vb"
ms.custom: "vs-dotnet"
---
# Tutorial: Test a .NET Standard class library with .NET Core using Visual Studio

This tutorial shows how to automate unit testing by adding a test project to a solution.

## Prerequisites

- This tutorial works with the solution that you create in [Create a .NET Standard library using Visual Studio](library-with-visual-studio.md).

## Create a unit test project

Unit tests provide automated software testing during your development and publishing. [MSTest](https://github.com/Microsoft/testfx-docs) is one of three test frameworks you can choose from. The others are [xUnit](https://xunit.net/) and [nUnit](https://nunit.org/).

1. Start Visual Studio.

1. Open the `ClassLibraryProjects` solution you created in [Create a .NET Standard library using Visual Studio](library-with-visual-studio.md).

1. Add a new unit test project named "StringLibraryTest" to the solution.

   1. Right-click on the solution in **Solution Explorer** and select **Add** > **New project**.

   1. On the **Add a new project** page, enter **mstest** in the search box. Choose **C#** or **Visual Basic** from the Language list, and then choose **All platforms** from the Platform list.

   1. Choose the **MSTest Test Project (.NET Core)** template, and then choose **Next**.

   1. On the **Configure your new project** page, enter **StringLibraryTest** in the **Project name** box. Then choose **Create**.

1. Visual Studio creates the project and opens the class file in the code window with the following code. If the language you want to use is not shown, change the language selector at the top of the page.

   ```csharp
   using Microsoft.VisualStudio.TestTools.UnitTesting;

   namespace StringLibraryTest
   {
       [TestClass]
       public class UnitTest1
       {
           [TestMethod]
           public void TestMethod1()
           {
           }
       }
   }
   ```

   ```vb
   Imports Microsoft.VisualStudio.TestTools.UnitTesting

   Namespace StringLibraryTest
       <TestClass>
       Public Class UnitTest1
           <TestMethod>
           Sub TestSub()

           End Sub
       End Class
   End Namespace
   ```

   The source code created by the unit test template does the following:

   - It imports the <xref:Microsoft.VisualStudio.TestTools.UnitTesting?displayProperty=nameWithType> namespace, which contains the types used for unit testing.
   - It applies the <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute> attribute to the `UnitTest1` class.
   - It applies the <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute> attribute to define `TestMethod1` in C# or `TestSub` in Visual Basic.

   Each method tagged with [[TestMethod]](xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute) in a test class tagged with [[TestClass]](xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute) is executed automatically when the unit test is run.

## Add a project reference

For the test project to work with the `StringLibrary` class, add a reference in the **StringLibraryTest** project to the `StringLibrary` project.

1. In **Solution Explorer**, right-click the **Dependencies** node of the **StringLibraryTest** project and select **Add Project Reference** from the context menu.

1. In the **Reference Manager** dialog, expand the **Projects** node, and select the box next to **StringLibrary**. Adding a reference to the `StringLibrary` assembly allows the compiler to find **StringLibrary** methods while compiling the **StringLibraryTest** project.

1. Select **OK**.

## Add and run unit test methods

When Visual Studio runs a unit test, it executes each method that is marked with the <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute> attribute in a class that is marked with the  <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute> attribute. A test method ends when the first failure is found or when all tests contained in the method have succeeded.

The most common tests call members of the <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert> class. Many assert methods include at least two parameters, one of which is the expected test result and the other of which is the actual test result. Some of the `Assert` class's most frequently called methods are shown in the following table:

| Assert methods     | Function |
| ------------------ | -------- |
| `Assert.AreEqual`  | Verifies that two values or objects are equal. The assert fails if the values or objects aren't equal. |
| `Assert.AreSame`   | Verifies that two object variables refer to the same object. The assert fails if the variables refer to different objects. |
| `Assert.IsFalse`   | Verifies that a condition is `false`. The assert fails if the condition is `true`. |
| `Assert.IsNotNull` | Verifies that an object isn't `null`. The assert fails if the object is `null`. |

You can also use the <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert.ThrowsException%2A?displayProperty=nameWithType> method in a test method to indicate the type of exception it's expected to throw. The test fails if the specified exception isn't thrown.

In testing the `StringLibrary.StartsWithUpper` method, you want to provide a number of strings that begin with an uppercase character. You expect the method to return `true` in these cases, so you can call the <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue%2A?displayProperty=nameWithType> method. Similarly, you want to provide a number of strings that begin with something other than an uppercase character. You expect the method to return `false` in these cases, so you can call the <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsFalse%2A?displayProperty=nameWithType> method.

Since your library method handles strings, you also want to make sure that it successfully handles an [empty string (`String.Empty`)](xref:System.String.Empty), a valid string that has no characters and whose <xref:System.String.Length> is 0, and a `null` string that hasn't been initialized. You can call `StartsWithUpper` directly as a static method and pass a single <xref:System.String> argument. Or you can call `StartsWithUpper` as an extension method on a `string` variable assigned to `null`.

You'll define three methods, each of which calls an <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert> method for each element in a string array. You'll call a method overload that lets you specify an error message to be displayed in case of test failure. The message identifies the string that caused the failure.

To create the test methods:

1. In the *UnitTest1.cs* or *UnitTest1.vb* code window, replace the code with the following code:

   :::code language="csharp" source="./snippets/library-with-visual-studio/csharp/StringLibraryTest/UnitTest1.cs":::
   :::code language="vb" source="./snippets/library-with-visual-studio/vb/StringLibraryTest/UnitTest1.vb":::

   The test of uppercase characters in the `TestStartsWithUpper` method includes the Greek capital letter alpha (U+0391) and the Cyrillic capital letter EM (U+041C). The test of lowercase characters in the `TestDoesNotStartWithUpper` method includes the Greek small letter alpha (U+03B1) and the Cyrillic small letter Ghe (U+0433).

1. On the menu bar, select **File** > **Save UnitTest1.cs As** or **File** > **Save UnitTest1.vb As**. In the **Save File As** dialog, select the arrow beside the **Save** button, and select **Save with Encoding**.

   > [!div class="mx-imgBorder"]
   > ![Visual Studio Save File As dialog](./media/testing-library-with-visual-studio/save-file-as-dialog.png)

1. In the **Confirm Save As** dialog, select the **Yes** button to save the file.

1. In the **Advanced Save Options** dialog, select **Unicode (UTF-8 with signature) - Codepage 65001** from the **Encoding** drop-down list and select **OK**.

   > [!div class="mx-imgBorder"]
   > ![Visual Studio Advanced Save Options dialog](./media/testing-library-with-visual-studio/advanced-save-options.png)

   If you fail to save your source code as a UTF8-encoded file, Visual Studio may save it as an ASCII file. When that happens, the runtime doesn't accurately decode the UTF8 characters outside of the ASCII range, and the test results won't be correct.

1. On the menu bar, select **Test** > **Run All Tests**. If the **Test Explorer** window doesn't open, open it by choosing **Test** > **Test Explorer**. The three tests are listed in the **Passed Tests** section, and the **Summary** section reports the result of the test run.

   > [!div class="mx-imgBorder"]
   > ![Test Explorer window with passing tests](./media/testing-library-with-visual-studio/test-explorer-window.png)

## Handle test failures

If you're doing test-driven development (TDD), you write tests first and they fail the first time you run them. Then you add code to the app that makes the test succeed. For this tutorial, you created the test after writing the app code that it validates, so you haven't seen the test fail. To validate that a test fails when you expect it to fail, add an invalid value to the test input.

1. Modify the `words` array in the `TestDoesNotStartWithUpper` method to include the string "Error". You don't need to save the file because Visual Studio automatically saves open files when a solution is built to run tests.

   ```csharp
   string[] words = { "alphabet", "Error", "zebra", "abc", "αυτοκινητοβιομηχανία", "государство",
                      "1234", ".", ";", " " };
   ```

   ```vb
   Dim words() As String = { "alphabet", "Error", "zebra", "abc", "αυτοκινητοβιομηχανία", "государство",
                      "1234", ".", ";", " " }

   ```

1. Run the test by selecting **Test** > **Run All Tests** from the menu bar. The **Test Explorer** window indicates that two tests succeeded and one failed.

   > [!div class="mx-imgBorder"]
   > ![Test Explorer window with failing tests](./media/testing-library-with-visual-studio/failed-test-window.png)

1. Select the failed test, `TestDoesNotStartWith`.

   The **Test Explorer** window displays the message produced by the assert: "Assert.IsFalse failed. Expected for 'Error': false; actual: True". Because of the failure, no strings in the array after "Error" were tested.

   > [!div class="mx-imgBorder"]
   > ![Test Explorer window showing the IsFalse assertion failure](./media/testing-library-with-visual-studio/failed-test-detail.png)

1. Remove the string "Error" that you added in step 1. Rerun the test and the tests pass.

## Test the Release version of the library

Now that the tests have all passed when running the Debug build of the library, run the tests an additional time against the Release build of the library. A number of factors, including compiler optimizations, can sometimes produce different behavior between Debug and Release builds.

To test the Release build:

1. In the Visual Studio toolbar, change the build configuration from **Debug** to **Release**.

   > [!div class="mx-imgBorder"]
   > ![Visual Studio toolbar with release build highlighted](./media/testing-library-with-visual-studio/visual-studio-toolbar-release.png)

1. In **Solution Explorer**, right-click the **StringLibrary** project and select **Build** from the context menu to recompile the library.

   > [!div class="mx-imgBorder"]
   > ![StringLibrary context menu with build command](./media/testing-library-with-visual-studio/build-library-context-menu.png)

1. Run the unit tests by choosing **Test Run** > **All Tests** from the menu bar. The tests pass.

## Additional resources

* [Unit test basics - Visual Studio](/visualstudio/test/unit-test-basics)
* [Unit testing in .NET Core and .NET Standard](../testing/index.md)

## Next steps

In this tutorial, you unit tested a class library. You can make the library available to others by publishing it to [NuGet](https://nuget.org) as a package. To learn how, follow a NuGet tutorial:

> [!div class="nextstepaction"]
> [Create and publish a NuGet package using Visual Studio](/nuget/quickstart/create-and-publish-a-package-using-visual-studio?tabs=netcore-cli)

If you publish a library as a NuGet package, others can install and use it. To learn how, follow a NuGet tutorial:

> [!div class="nextstepaction"]
> [Install and use a package in Visual Studio](/nuget/quickstart/install-and-use-a-package-in-visual-studio)

A library doesn't have to be distributed as a package. It can be bundled with a console app that uses it. To learn how to publish a console app, see the earlier tutorial in this series:

> [!div class="nextstepaction"]
> [Publish a .NET Core console application using Visual Studio](publishing-with-visual-studio.md)
