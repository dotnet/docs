---
title: Testing a class library with .NET Core in Visual Studio 2017
description: Create a unit test project for your .NET Core class library. Verify that your .NET Core class library works correctly with unit tests.
author: BillWagner
ms.author: wiwagn
ms.date: 08/07/2017
dev_langs: 
  - "csharp"
  - "vb"
ms.custom: "vs-dotnet, seodoc18"
---
# Testing a class library with .NET Core in Visual Studio 2017

In [Building a class library with C# and .NET Core in Visual Studio 2017](library-with-visual-studio.md) or [Building a class library with Visual Basic and .NET Core in Visual Studio 2017](vb-library-with-visual-studio.md), you created a simple class library that adds an extension method to the <xref:System.String> class. Now, you'll create a unit test to make sure that it works as expected. You'll add your unit test project to the solution you created in the previous topic.

## Creating a unit test project

To create the unit test project, do the following:

# [C#](#tab/csharp)
1. In **Solution Explorer**, open the context menu for the **ClassLibraryProjects** solution node and select **Add** > **New Project**.

1. In the **Add New Project** dialog, select the **Visual C#** node. Then select the **.NET Core** node followed by the **MSTest Test Project (.NET Core)** project template. In the **Name** text box, enter "StringLibraryTest" as the name of the project. Select **OK** to create the unit test project.

   ![Add New Project dialog with unit test project displayed - C#](./media/testing-library-with-visual-studio/create-new-test-project.png)

   > [!NOTE]  
   > In addition to an MSTest Test project, you can also use Visual Studio to create an xUnit test project for .NET Core.

1. Visual Studio creates the project and opens the *UnitTest1.cs* file in the code window.

   ![Visual Studio code window for the unit test project class and method - C#](./media/testing-library-with-visual-studio/unit-test-editor-window.png)

   The source code created by the unit test template does the following:

   * It imports the <xref:Microsoft.VisualStudio.TestTools.UnitTesting?displayProperty=nameWithType> namespace, which contains the types used for unit testing.

   * It applies the <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute> attribute to the `UnitTest1` class. Each test method in a test class tagged with the \[TestMethod\] attribute is executed automatically when the unit test is run.

   * It applies the <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute> attribute to define `TestMethod1` as a test method for automatic execution when the unit test is run.

1. In **Solution Explorer**, right-click the **Dependencies** node of the **StringLibraryTest** project and select **Add Reference** from the context menu.

   ![Context menu of StringLibraryTest Dependencies - C#](./media/testing-library-with-visual-studio/add-reference-context-menu.png)

1. In the **Reference Manager** dialog, expand the **Projects** node and check the box next to **StringLibrary**. Adding a reference to the `StringLibrary` assembly allows the compiler to find **StringLibrary** methods. Select the **OK** button. This adds a reference to your class library project, `StringLibrary`.

   ![Visual Studio add project reference dialog](./media/testing-library-with-visual-studio/project-reference-manager.png)
# [Visual Basic](#tab/vb) 
1. In **Solution Explorer**, open the context menu for the **ClassLibraryProjects** solution node and select **Add** > **New Project**.

1. In the **Add New Project** dialog, select the **Visual Basic** node. Then select the **.NET Core** node followed by the **MSTest Test Project (.NET Core)** project template. In the **Name** text box, enter "StringLibraryTest" as the name of the project. Select **OK** to create the unit test project.

   ![Add New Project dialog with unit test project displayed - Visual Basic](./media/testing-library-with-visual-studio/vb-create-new-test-project.png)

   > [!NOTE]  
   > In addition to an MSTest Test project, you can also use Visual Studio to create an xUnit test project for .NET Core.

1. Visual Studio creates the project and opens the *UnitTest1.vb* file in the code window.

   ![Visual Studio code window for the unit test project class and method - Visual Basic](./media/testing-library-with-visual-studio/vb-unit-test-editor-window.png)

   The source code created by the unit test template does the following:

   * It imports the [Microsoft.VisualStudio.TestTools.UnitTesting]<xref:Microsoft.VisualStudio.TestTools.UnitTesting?displayProperty=namewithType> namespace, which contains the types used for unit testing.

   * It applies the <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute>) attribute to the `UnitTest1` class. Each test method in a test class tagged with the <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute> attribute is executed automatically when the unit test is run.

   * It applies the <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute> attribute to define `TestMethod1` as a test method for automatic execution when the unit test is run.

1. In **Solution Explorer**, right-click the **Dependencies** node of the **StringLibraryTest** project and select **Add Reference** from the context menu.

   ![Context menu of StringLibraryTest Dependencies](./media/testing-library-with-visual-studio/add-reference-context-menu.png)

1. In the **Reference Manager** dialog, expand the **Projects** node and check the box next to **StringLibrary**. Adding a reference to the `StringLibrary` assembly allows the compiler to find **StringLibrary** methods. Select the **OK** button. This adds a reference to your class library project, `StringLibrary`.

   ![Visual Studio add project reference dialog - Visual Basic](./media/testing-library-with-visual-studio/project-reference-manager.png)
---

## Adding and running unit test methods

When Visual Studio runs a unit test, it executes each method marked with the <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute> attribute in a unit test class, the class to which the  <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute> attribute is applied. A test method ends when the first failure is encountered or when all tests contained in the method have succeeded.

The most common tests call members of the <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert> class. Many assert methods include at least two parameters, one of which is the expected test result and the other of which is the actual test result. Some of its most frequently called methods are shown in the table below.

Assert methods | Function
--- | ---
`Assert.AreEqual` | Verifies that two values or objects are equal. The assert fails if the values or objects are not equal.
`Assert.AreSame` | Verifies that two object variables refer to the same object. The assert fails if the variables refer to different objects.
`Assert.IsFalse` | Verifies that a condition is `false`. The assert fails if the condition is `true`.
`Assert.IsNotNull` | Verifies that an object is not `null`. The assert fails if the object is `null`.

You can also apply the <xref:Microsoft.VisualStudio.TestTools.UnitTesting.ExpectedExceptionAttribute> attribute to a test method. It indicates the type of exception a test method is expected to throw. The test fails if the specified exception is not thrown.

In testing the `StringLibrary.StartsWithUpper` method, you want to provide a number of strings that begin with an uppercase character. You expect the method to return `true` in these cases, so you can call the <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue%2A> method. Similarly, you want to provide a number of strings that begin with something other than an uppercase character. You expect the method to return `false` in these cases, so you can call the <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsFalse%2A> method.

Since your library method handles strings, you also want to make sure that it successfully handles an [empty string (`String.Empty`)](xref:System.String.Empty), a valid string that has no characters and whose <xref:System.String.Length> is 0, and a `null` string that has not been initialized. If `StartsWithUpper` is called as an extension method on a <xref:System.String> instance, it cannot be passed a `null` string. However, you can also call it directly as a static method and pass a single <xref:System.String> argument.

You'll define three methods, each of which calls its <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert> method repeatedly for each element in a string array. Because the test method fails as soon as it encounters the first failure, you'll call a method overload that allows you to pass a string that indicates the string value used in the method call.

To create the test methods:

# [C#](#tab/csharp) 
1. In the *UnitTest1.cs* code window, replace the code with the following code:

   [!CODE-csharp[Test#1](../../../samples/snippets/csharp/getting_started/with_visual_studio_2017/testlib1.cs)]

   Note that your test of uppercase characters in the `TestStartsWithUpper` method includes the Greek capital letter alpha (U+0391) and the Cyrillic capital letter EM (U+041C), and the test of lowercase characters in the `TestDoesNotStartWithUpper` method includes the Greek small letter alpha (U+03B1) and the Cyrillic small letter Ghe (U+0433).

1. On the menu bar, select **File** > **Save UnitTest1.cs As**. In the **Save File As** dialog, select the arrow beside the **Save** button, and select **Save with Encoding**.

   ![Visual Studio Save File As dialog - C#](./media/testing-library-with-visual-studio/save-file-as-dialog.png)
# [Visual Basic](#tab/vb) 
1. In the *UnitTest1.vb* code window, replace the code with the following code:

    [!CODE-vb[Test#1](../../../samples/snippets/core/tutorials/vb-library-with-visual-studio/testlib.vb)]

   Note that your test of uppercase characters in the `TestStartsWithUpper` method includes the Greek capital letter alpha (U+0391) and the Cyrillic capital letter EM (U+041C), and the test of lowercase characters in the `TestDoesNotStartWithUpper` method includes the Greek small letter alpha (U+03B1) and the Cyrillic small letter Ghe (U+0433).

1. On the menu bar, select **File** > **Save UnitTest1.vb As**. In the **Save File As** dialog, select the arrow beside the **Save** button, and select **Save with Encoding**.

   ![Visual Studio Save File As dialog - Visual Basic](./media/testing-library-with-visual-studio/save-file-as-dialog.png)
---

1. In the **Confirm Save As** dialog, select the **Yes** button to save the file.

1. In the **Advanced Save Options** dialog, select **Unicode (UTF-8 with signature) - Codepage 65001** from the **Encoding** drop-down list and select **OK**.

   ![Visual Studio Advanced Save Options dialog](./media/testing-library-with-visual-studio/advanced-save-options.png)

   If you fail to save your source code as a UTF8-encoded file, Visual Studio may save it as an ASCII file. When that happens, the runtime doesn't accurately decode the UTF8 characters outside of the ASCII range, and the test results won't be accurate.

1. On the menu bar, select **Test** > **Run** > **All Tests**. The **Test Explorer** window opens and shows that the tests ran successfully. The three tests are listed in the **Passed Tests** section, and the **Summary** section reports the result of the test run.

   ![Test Explorer window with passing tests](./media/testing-library-with-visual-studio/test-explorer-window.png)

## Handling test failures

Your test run had no failures, but change it slightly so that one of the test methods fails:

1. Modify the `words` array in the `TestDoesNotStartWithUpper` method to include the string "Error". You don't need to save the file because Visual Studio automatically saves open files when a solution is built to run tests.

   ```csharp
   string[] words = { "alphabet", "Error", "zebra", "abc", "αυτοκινητοβιομηχανία", "государство",
                      "1234", ".", ";", " " };
   ```
   ```vb
   Dim words() As String = { "alphabet", "Error", "zebra", "abc", "αυτοκινητοβιομηχανία", "государство",
                      "1234", ".", ";", " " }

   ```
1. Run the test by selecting **Test** > **Run** > **All Tests** from the menu bar. The **Test Explorer** window indicates that two tests succeeded and one failed.

   ![Test Explorer window with failing tests](./media/testing-library-with-visual-studio/failed-test-window.png)

1. In the **Failed Tests** section, select the failed test, `TestDoesNotStartWith`. The **Test Explorer** window displays the message produced by the assert: "Assert.IsFalse failed. Expected for 'Error': false; actual: True". Because of the failure, all strings in the array after "Error" were not tested.

   ![Test Explorer window showing the Is False assertion failure](./media/testing-library-with-visual-studio/failed-test-detail.png)

1. Remove the code that you added (`"Error", `) and rerun the test. The tests will pass.

## Testing the Release version of the library

You've been running your tests against the Debug version of the library. Now that your tests have all passed and you've adequately tested your library, you should run the tests an additional time against the Release build of the library. A number of factors, including compiler optimizations, can sometimes produce different behavior between Debug and Release builds.

To test the Release build:

1. In the Visual Studio toolbar, change the build configuration from **Debug** to **Release**.

   ![Visual Studio toolbar with release build highlighted](./media/testing-library-with-visual-studio/visual-studio-toolbar-release.png)

1. In **Solution Explorer**, right-click the **StringLibrary** project and select **Build** from the context menu to recompile the library.

   ![StringLibrary context menu with build command](./media/testing-library-with-visual-studio/build-library-context-menu.png)

1. Run the unit tests by choosing **Test** > **Run** > **All Tests** from the menu bar. The tests pass.

Now that you've finished testing your library, the next step is to make it available to callers. You can bundle it with one or more applications, or you can distribute it as a NuGet package. For more information, see [Consuming a .NET Standard Class Library](./consuming-library-with-visual-studio.md).
