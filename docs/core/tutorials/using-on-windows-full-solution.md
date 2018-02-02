---
title: Building a complete .NET Core solution on Windows, using Visual Studio 2017
description: Learn how to build a complete .NET Core solution in Visual Studio 2017 on Windows.
keywords: .NET, .NET Core
author: bleroy
ms.author: mairaw
ms.date: 11/16/2016
ms.topic: article
ms.prod: .net-core
ms.devlang: dotnet
ms.assetid: ba7e082c-a7c8-431e-a342-f67734b660f6
ms.workload: 
  - dotnetcore
---

# Building a complete .NET Core solution on Windows, using Visual Studio 2017

Visual Studio 2017 provides a full-featured development environment for developing .NET Core applications. The procedures in this document describe the steps necessary to build a typical .NET Core solution that includes reusable libraries, testing, and using third-party libraries. 

## Prerequisites

Follow the instructions on [our prerequisites page](../windows-prerequisites.md) to update your environment.

## A solution using only .NET Core projects

### Writing the library

1. In Visual Studio, choose **File**, **New**, **Project**. In the **New Project** dialog, expand the **Visual C#** node and choose the **.NET Standard** node, and then choose **Class Library (.NET Standard)**. 

2. Name the project "Library" and the solution "Golden". Leave **Create directory for solution** checked. Click **OK**.

3. In Solution Explorer, open the context menu for the **Dependencies** node and choose **Manage NuGet Packages**.

4. Choose "nuget.org" as the **Package source**, and choose the **Browse** tab. Browse for **Newtonsoft.Json**. Click **Install**, and accept the license agreement. The package should now appear under **Dependencies/NuGet** and be automatically restored.

5. Rename the `Class1.cs` file to `Thing.cs`. Accept the rename of the class. Add a method: `public int Get(int number) => Newtonsoft.Json.JsonConvert.DeserializeObject<int>($"{number}");`

7. On the **Build** menu, choose **Build Solution**.

   The solution should build without error.

### Writing the test project

1. In Solution Explorer, open the context menu for the **Solution** node and choose **Add**, **New Project**. In the **New Project** dialog, under **Visual C# / .NET Core**, choose **Unit Test Project (.NET Core)**. Name it "TestLibrary" and click OK. 

2. In the **TestLibrary** project, open the context menu for the **Dependencies** node and choose **Add Reference**. Click **Projects**, then check the Library project and click OK. This adds a reference to your library from the test project.

3. Rename the `UnitTest1.cs` file to `LibraryTests.cs` and accept the class rename. Add `using Library;` to the top of the file, and replace the `TestMethod1` method with the following code:
    ```csharp
    [TestMethod]
    public void ThingGetsObjectValFromNumber()
    {
        Assert.AreEqual(42, new Thing().Get(42));
    }
    ```

   You should now be able to build the solution. 
   
4. On the **Test** menu, choose **Windows**, **Test Explorer** in order to get the test explorer window into your workspace. After a few seconds, the `ThingGetsObjectValFromNumber` test should appear in the test explorer. Choose **Run All**.
   
   The test should pass.

### Writing the console app

1. In Solution Explorer, open the context menu for the solution, and add a new **Console App (.NET Core)** project. Name it "App".

2. In the **App** project, open the context menu for the **Dependencies** node and choose **Add**,  **Reference**. 

3. In the **Reference Manager** dialog, check **Library** under the **Projects**, **Solution** node, and then click **OK**

6. Open the context menu for the **App** node and choose **Set as StartUp Project**. This ensures that hitting F5 or CTRL+F5 will start the console app.

7. Open the `Program.cs` file, add a `using Library;` directive to the top of the file, and then add `Console.WriteLine($"The answer is {new Thing().Get(42)}.");` to the `Main` method.

8. Set a breakpoint after the line that you just added.

9. Press F5 to run the application..

   The application should build without error, and should hit the breakpoint. You should also be able to check that the application output "The answer is 42.".
