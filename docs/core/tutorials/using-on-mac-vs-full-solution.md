---
title: Building a complete .NET Core solution on macOS using Visual Studio for Mac | Microsoft Docs
description: Building a complete .NET Core solution on macOS, using Visual Studio for Mac
keywords: .NET, .NET Core, macOS, Mac
author: bleroy
ms.author: mairaw
ms.date: 03/16/2017
ms.topic: article
ms.prod: .net-core
ms.devlang: dotnet
ms.assetid: 6945bedf-5bf3-4955-8588-83fb87511b79
---

# Building a complete .NET Core solution on macOS using Visual Studio for Mac

Visual Studio for Mac provides a full-featured Integrated Development Environment (IDE) for developing .NET Core applications. This topic walks you through building a .NET Core solution that includes reusable libraries, unit testing, and third-party libraries.

> [!NOTE]
> Visual Studio for Mac is preview software.

## Prerequisites

* [.NET Core and OpenSSL](https://www.microsoft.com/net/core#macos)
* [Visual Studio for Mac](https://www.visualstudio.com/vs/visual-studio-mac/)

For more information on prerequisites, see the [Prerequisites for .NET Core on Mac](../core/macos-prerequisites.md).

## Building a library

1. In Visual Studio, choose **New Project**. In the new project dialog, choose **Library** under **.NET Core**, then select **Class Library (.NET Core)**. Select **Next**.

   ![Creating a new library in Visual Studio for Mac](./media/using-on-mac-vs-full-solution/vsmacfull01.png)

1. Name the project "Library" and the solution "Golden". Leave **Create a project directory within the solution directory** checked. Select **Create**.

   ![Naming the library project](./media/using-on-mac-vs-full-solution/vsmacfull02.png)
   
1. By default, the current project template sets the .NET Standard version to 1.4. We'll bump it up to 1.6. Right-click the project and choose **Tools > Edit File**. Change `<TargetFramework>netstandard1.4</TargetFramework>` to `<TargetFramework>netstandard1.6</TargetFramework>`. Save.

1. In the solution explorer, open the context menu for the **Dependencies** node and choose **Add Packages**.

1. Choose "nuget.org" as the Package source, and check **Json.NET**. Select **Add Package**. The package should now appear under **Dependencies/NuGet** and be automatically restored. [Json.NET](http://www.newtonsoft.com/json) is the recommended library and what our code will use to perform [JSON](http://www.json.org/) serialization and deserialization.

   ![Adding the Json.NET dependency to the library project](./media/using-on-mac-vs-full-solution/vsmacfull03.png)

1. Rename the *MyClass.cs* file to *Thing.cs*. Also rename the class and constructor `Thing`. Add a method: `public int Get(int number) => Newtonsoft.Json.JsonConvert.DeserializeObject<int>($"{number}");`

1. On the **Build** menu, choose **Build All**.

   The solution should build without error.

## Creating a test project

1. In the solution explorer, open the context menu for the Golden solution node and choose **Add**, **Add New Project**. In the new project dialog, choose **.NET Core > App** (and not **Library**), and then **Console Application (.NET Core)**. Select **Next**. Name the new project "TestLibrary" and select **Create**.

   ![Template selection dialog showing Console Application .NET Core option selected](./media/using-on-mac-vs-full-solution/vsmacfull05.png)

1. In the **TestLibrary** project, open the context menu for the **References** node and choose **Edit References**. Check the Library project and select **OK**. This adds a reference to your library from the test project.

   ![Referencing the library from the test project](./media/using-on-mac-vs-full-solution/vsmacfull04.png)

1. The testing framework that we'll use in this tutorial is [xUnit](https://xunit.github.io/). Right-click **Packages** under the solution explorer and choose **Add Packages**. Search for xunit, check "xUnit.net" and select **Add Package** (the version you see may vary; the latest is usually the best choice).

   ![Adding a reference to xUnit](./media/using-on-mac-vs-full-solution/vsmacfull06.png)
   
   Do the same for `Microsoft.NET.Test.Sdk` and "xunit.runner.visualstudio". Those libraries enable the command-line test runner to work.

1. Rename the *Program.cs* file to *LibraryTests.cs*, then open it and change the code to:

    ```cs
    using Library;
    using Xunit;
    
    public class LibraryTests
        [Theory]
        [InlineData(42)]
        [InlineData(0)]
        [InlineData(-1)]
        public void ThingGetsObjectValFromNumber(int number)
        {
            Assert.Equal(number, new Thing().Get(number));
        }
    }
    ```

   You should now be able to build the solution.
   
1. Currently, Visual Studio for Mac doesn't integrate NUnit tests to its built-in test runner. You will still be able to run tests, but from the command-line. Right-click the `TestLibrary` project, and choose **Tools > Open in Terminal** from the menu. In the command-line, enter `dotnet test`.
   
   The tests should pass.

   ![All tests pass](./media/using-on-mac-vs-full-solution/vsmacfull07.png)

## Adding a console app

1. In Solution Explorer, open the context menu for the solution, and add a new **Console Application (.NET Core)** project. Name it "App".

1. In the **App** project, open the context menu for the **References** node and choose **Add**, **Reference**. In the **Reference Manager** dialog, check **Library** under the **Projects**, **Solution** node, and then select **OK**.

1. Open the *Program.cs* file, add a `using Library;` directive to the top of the file, and then add `Console.WriteLine($"The answer is {new Thing().Get(42)}");` to the `Main` method.

1. Set a breakpoint after the line that you just added.

1. Select the play button or **Run > Start Debugging** to run the application.

   The application should build without error, and should hit the breakpoint. You should also be able to check that the application output "The answer is 42."

   ![Our breakpoint is hit](./media/using-on-mac-vs-full-solution/vsmacfull08.png)
