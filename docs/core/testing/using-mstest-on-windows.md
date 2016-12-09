---
title: Use MSTest with .NET Core on Windows
description: How to use MSTest with .NET Core on Windows, using Visual Studio 2015
keywords: MSTest, .NET, .NET Core
author: ncarandini
ms.author: wiwagn
ms.date: 08/18/2016
ms.topic: article
ms.prod: .net-core
ms.devlang: dotnet
ms.assetid: ed447641-3e85-4e50-b7ed-004630048a3e
---

# Unit testing with MSTest and .NET Core on Windows, using Visual Studio 2015

While xUnit could be a better choice when targeting multiple platforms, with .NET Core on Windows is also possible to use MSTest.

## Prerequisites

Follow the instructions on [Getting started with .NET Core on Windows](../tutorials/using-on-windows.md) to create the library project.

### Writing the test project using MSTest

1. In Solution Explorer, open the context menu for the **Solution** node and choose **Add**, **New Solution Folder**. Name the folder "test". 
   This is only a solution folder, not a physical folder.

2. Open the context menu for the **test** folder and choose **Add**. **New Project**. In the **New Project** dialog, choose **Console Application (.NET Core)**. Name it "TestLibrary" and explicitly put it under the `Golden\test` path. 

   > [!IMPORTANT]
   > The project needs to be a console application, not a class library.

3. In the **TestLibrary** project, open the context menu for the **References** node and choose **Add Reference**. 

4. In the **Reference Manager** dialog, check **Library** under the **Projects**, **Solution** node, and then click **OK**. 

5. In the **TestLibrary** project, open the `project.json` file, and replace `"Library": "1.0.0-*"` with `"Library": {"target": "project"}`. 

   This is to avoid the resolution of the `Library` project to a NuGet package with the same name. Explicitly setting the target to "project" ensures that the tooling will first search for a project with that name, and not a package. 

6. Open the context menu for the **References** node and choose **Manage NuGet Packages**.

7. Choose "nuget.org" as the **Package source**, and choose the **Browse** tab. Check the **Include prerelease** checkbox, and then browse for **MSTest.TestFramework** version 1.0.1-preview or newer, and then click **Install**. 

8. Browse for **dotnet-test-mstest** version 1.1.1-preview or newer, and then click **Install**.

9. Edit `project.json` to add `"testRunner": "mstest",` after the `"version"` section.

10. Add a `LibraryTests.cs` class file to the **TestLibrary** project, add the `using` directives `Microsoft.VisualStudio.TestTools.UnitTesting;` and `using Library;` to the top of the file, and add the following code to the class:
    ```csharp
    [TestClass]
    public class LibraryTests
    {
        [TestMethod]
        public void ThingGetsObjectValFromNumber()
        {
            Assert.AreEqual(42, new Thing().Get(42));
        }
    }
    ```
    * Optionally, delete the `Program.cs` file from the **TestLibrary** project, and remove `"buildOptions": {"emitEntryPoint": true},` from `project.json`.

   You should now be able to build the solution. 
   
11. On the **Test** menu, choose **Windows**, **Test Explorer**, and in Test Explorer choose **Run All**.
   
   The test should pass.
