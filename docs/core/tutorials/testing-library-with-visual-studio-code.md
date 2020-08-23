---
title: Test a .NET Standard class library with .NET Core using Visual Studio Code
description: Create a unit test project for a .NET Core class library. Verify that a .NET Core class library works correctly with unit tests.
ms.date: 06/08/2020
---
# Tutorial: Test a .NET Standard class library with .NET Core using Visual Studio Code

This tutorial shows how to automate unit testing by adding a test project to a solution.

## Prerequisites

- This tutorial works with the solution that you create in [Create a .NET Standard library in Visual Studio Code](library-with-visual-studio-code.md).

## Create a unit test project

Unit tests provide automated software testing during your development and publishing. The testing framework that you use in this tutorial is MSTest. [MSTest](https://github.com/Microsoft/testfx-docs) is one of three test frameworks you can choose from. The others are [xUnit](https://xunit.net/) and [nUnit](https://nunit.org/).

1. Start Visual Studio Code.

1. Open the `ClassLibraryProjects` solution you created in [Create a .NET Standard library in Visual Studio](library-with-visual-studio.md).

1. Create a unit test project named "StringLibraryTest".

   ```dotnetcli
   dotnet new mstest -o StringLibraryTest
   ```

   The project template creates a UnitTest1.cs file with the following code:

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

   The source code created by the unit test template does the following:

   - It imports the <xref:Microsoft.VisualStudio.TestTools.UnitTesting?displayProperty=nameWithType> namespace, which contains the types used for unit testing.
   - It applies the <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute> attribute to the `UnitTest1` class.
   - It applies the <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute> attribute to define `TestMethod1`.

   Each method tagged with [[TestMethod]](xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute) in a test class tagged with [[TestClass]](xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute) is executed automatically when the unit test is run.

1. Add the test project to the solution.

   ```dotnetcli
   dotnet sln add StringLibraryTest/StringLibraryTest.csproj
   ```

## Add a project reference

For the test project to work with the `StringLibrary` class, add a reference in the `StringLibraryTest` project to the `StringLibrary` project.

1. Run the following command:

   ```dotnetcli
   dotnet add StringLibraryTest/StringLibraryTest.csproj reference StringLibrary/StringLibrary.csproj
   ```

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

Since your library method handles strings, you also want to make sure that it successfully handles an [empty string (`String.Empty`)](xref:System.String.Empty) and a and a `null` string. An empty string is one that has no characters and whose <xref:System.String.Length> is 0. A `null` string is one that hasn't been initialized. You can call `StartsWithUpper` directly as a static method and pass a single <xref:System.String> argument. Or you can call `StartsWithUpper` as an extension method on a `string` variable assigned to `null`.

You'll define three methods, each of which calls an <xref:Microsoft.VisualStudio.TestTools.UnitTesting.Assert> method for each element in a string array. You'll call a method overload that lets you specify an error message to be displayed in case of test failure. The message identifies the string that caused the failure.

To create the test methods:

1. Open *StringLibraryTest/UnitTest1.cs* and replace all of the code with the following code.

   :::code language="csharp" source="./snippets/library-with-visual-studio/csharp/StringLibraryTest/UnitTest1.cs":::

   The test of uppercase characters in the `TestStartsWithUpper` method includes the Greek capital letter alpha (U+0391) and the Cyrillic capital letter EM (U+041C). The test of lowercase characters in the `TestDoesNotStartWithUpper` method includes the Greek small letter alpha (U+03B1) and the Cyrillic small letter Ghe (U+0433).

1. Save your changes.

1. Run the tests:

   ```dotnetcli
   dotnet test StringLibraryTest/StringLibraryTest.csproj
   ```

   The terminal output shows that all tests passed.

   ```output
   Starting test execution, please wait...

   A total of 1 test files matched the specified pattern.

   Test Run Successful.
   Total tests: 3
        Passed: 3
   Total time: 5.1116 Seconds
   ```

## Handle test failures

If you're doing test-driven development (TDD), you write tests first and they fail the first time you run them. Then you add code to the app that makes the test succeed. For this tutorial, you created the test after writing the app code that it validates, so you haven't seen the test fail. To validate that a test fails when you expect it to fail, add an invalid value to the test input.

1. Modify the `words` array in the `TestDoesNotStartWithUpper` method to include the string "Error".

   ```csharp
   string[] words = { "alphabet", "Error", "zebra", "abc", "αυτοκινητοβιομηχανία", "государство",
                      "1234", ".", ";", " " };
   ```

1. Run the tests:

   ```dotnetcli
   dotnet test StringLibraryTest/StringLibraryTest.csproj
   ```

   The terminal output shows that one test fails, and it provides an error message for the failed test: "Assert.IsFalse failed. Expected for 'Error': false; actual: True". Because of the failure, no strings in the array after "Error" were tested.

   ```output
   Starting test execution, please wait...

   A total of 1 test files matched the specified pattern.
     X TestDoesNotStartWithUpper [283ms]
     Error Message:
      Assert.IsFalse failed. Expected for 'Error': false; Actual: True
     Stack Trace:
     at StringLibraryTest.UnitTest1.TestDoesNotStartWithUpper()
       in C:\Projects\ClassLibraryProjects\StringLibraryTest\UnitTest1.cs:line 33

   Test Run Failed.
   Total tests: 3
        Passed: 2
        Failed: 1
   Total time: 1.7825 Seconds
   ```

1. Remove the string "Error" that you added in step 1. Rerun the test and the tests pass.

## Test the Release version of the library

Now that the tests have all passed when running the Debug build of the library, run the tests an additional time against the Release build of the library. A number of factors, including compiler optimizations, can sometimes produce different behavior between Debug and Release builds.

1. Run the tests with the Release build configuration:

   ```dotnetcli
   dotnet test StringLibraryTest/StringLibraryTest.csproj --configuration Release
   ```

   The tests pass.

## Additional resources

* [Unit testing in .NET Core and .NET Standard](../testing/index.md)

## Next steps

In this tutorial, you unit tested a class library. You can make the library available to others by publishing it to [NuGet](https://nuget.org) as a package. To learn how, follow a NuGet tutorial:

> [!div class="nextstepaction"]
> [Create and publish a package using the dotnet CLI](/nuget/quickstart/create-and-publish-a-package-using-the-dotnet-cli)

If you publish a library as a NuGet package, others can install and use it. To learn how, follow a NuGet tutorial:

> [!div class="nextstepaction"]
> [Install and use a package using the dotnet CLI](/nuget/quickstart/install-and-use-a-package-using-the-dotnet-cli)

A library doesn't have to be distributed as a package. It can be bundled with a console app that uses it. To learn how to publish a console app, see the earlier tutorial in this series:

> [!div class="nextstepaction"]
> [Publish a .NET Core console application with Visual Studio Code](publishing-with-visual-studio-code.md)
