---
title: Getting started with .NET Core on Windows
description: Getting started with .NET Core on Windows, using Visual Studio 2015
keywords: .NET, .NET Core
author: bleroy
ms.author: mairaw
ms.date: 06/20/2016
ms.topic: article
ms.prod: .net-core
ms.devlang: dotnet
ms.assetid: d743134a-08a3-4ff6-aab7-49f71f0568c3
---

# Getting started with .NET Core on Windows, using Visual Studio 2015

by [Bertrand Le Roy](https://github.com/bleroy) and [Phillip Carter](https://github.com/cartermp)

Visual Studio 2015 provides a full-featured development environment for developing .NET Core applications. The procedures in this document describe the steps necessary to build a number of typical .NET Core solutions, or solutions that include .NET Core components, using Visual Studio. The scenarios include testing and using third-party libraries that have not been explicitly built for the most recent version of .NET Core. 

## Prerequisites

Follow the instructions on [our prerequisites page](../windows-prerequisites.md) to update your environment.

## Getting Started

The following steps will set up Visual Studio 2015 for .NET Core development:

1. Open Visual Studio, and on the **File** menu, choose **New**, **Project**.

2. In the **New Project** dialog, in the **Templates** list, expand the **Visual C#** node and choose **.NET Core**. You should see three new project templates for **Class Library (.NET Core)**, **Console Application (.NET Core)**, and **ASP.NET Core Web Application (.NET Core)**.

A solution using only .NET Core projects
----------------------------------------

### Writing the library

1. In Visual Studio, choose **File**, **New**, **Project**. In the **New Project** dialog, expand the **Visual C#** node and choose the **.NET Core** node, and then choose **Class Library (.NET Core)**. 

2. Name the project "Library" and the solution "Golden". Leave **Create directory for solution** checked. Click **OK**.

3. In Solution Explorer, open the context menu for the **References** node and choose **Manage NuGet Packages**.

4. Choose "nuget.org" as the **Package source**, and choose the **Browse** tab. Browse for **Newtonsoft.Json**. Click **Install**. 

5. Open the context menu for the **References** node and choose  **Restore packages**.

6. Rename the `Class1.cs` file to `Thing.cs`. Accept the rename of the class. Remove the constructor and add a method: `public int Get(int number) => Newtonsoft.Json.JsonConvert.DeserializeObject<int>($"{number}");`

7. On the **Build** menu, choose **Build Solution**.

   The solution should build without error.

### Writing the test project

1. In Solution Explorer, open the context menu for the **Solution** node and choose **Add**, **New Solution Folder**. Name the folder "test". 
   This is only a solution folder, not a physical folder.

2. Open the context menu for the **test** folder and choose **Add**. **New Project**. In the **New Project** dialog, choose **Console Application (.NET Core)**. Name it "TestLibrary" and explicitly put it under the `Golden\test` path. 

> [!IMPORTANT]
> The project needs to be a console application, not a class library.

3. In the **TestLibrary** project, open the context menu for the **References** node and choose **Add Reference**. 

4. In the **Reference Manager** dialog, check **Library** under the **Projects**, **Solution** node, and then click **OK**. 

5. In the **TestLibrary** project, open the `project.json` file, and replace `"Library": "1.0.0-*"` with `"Library": {"target": "project", "version": "1.0.0-*"}`. 

   This is to avoid the resolution of the `Library` project to a NuGet package with the same name. Explicitly setting the target to "project" ensures that the tooling will first search for a project with that name, and not a package. 
   
6. In the **TestLibrary** project, open the context menu for the **References** node and choose **Restore Packages**.

7. Open the context menu for the **References** node and choose **Manage NuGet Packages**.

8. Choose "nuget.org" as the **Package source**, and choose the **Browse** tab. Check the **Include prerelease** checkbox, and then browse for **xUnit** version 2.2.0 or newer, and then click **Install**. 

9. Browse for **dotnet-test-xunit** version 2.2.0 or newer, and then click **Install**.

10. Edit `project.json` and replace `"imports": "dnxcore50"` with `"imports": [ "dnxcore50", "portable-net45+win8" ]`. 

   This enables the xunit libraries to be correctly restored and used by the project: those libraries have been compiled to be used with portable profiles that include "portable-net45+win8", but not .NET Core, which didn't exist when they were built. The `import` relaxes the tooling version checks at build time. You may now restore packages without error.

11. Edit `project.json` to add `"testRunner": "xunit",` after the `"frameworks"` section.

12. Add a `LibraryTests.cs` class file to the **TestLibrary** project, add the `using` directives `using Xunit;` and `using Library;` to the top of the file, and add the following code to the class:
    ```csharp
    [Fact]
    public void ThingGetsObjectValFromNumber() {
        Assert.Equal(42, new Thing().Get(42));
    }
    ```
    * Optionally, delete the `Program.cs` file from the **TestLibrary** project, and remove `"buildOptions": {"emitEntryPoint": true},` from `project.json`.

   You should now be able to build the solution. 
   
13. On the **Test** menu, choose **Windows**, **Test Explorer**, and in Test Explorer choose **Run All**.
   
   The test should pass.

### Writing the console app

1. In Solution Explorer, open the context menu for the `src` folder, and add a new **Console Application (.NET Core)** project. Name it "App", and set the location to `Golden\src`.

2. In the **App** project, open the context menu for the **References** node and choose **Add**,  **Reference**. 

3. In the **Reference Manager** dialog, check **Library** under the **Projects**, **Solution** node, and then click **OK**

4. In the **App** project, open the `project.json` file, and replace `"Library": "1.0.0-*"` with `"Library": {"target": "project"}`.

5. Open the context menu for the **References** node and choose **Restore Packages**.

6. Open the context menu for the **App** node and choose **Set as StartUp Project**.

7. Open the `Program.cs` file, add a `using Library;` directive to the top of the file, and then add `Console.WriteLine($"The answer is {new Thing().Get(42)}");` to the `Main` method.

8. Set a breakpoint after the line that you just added.

9. Press F5 to run the application..

   The application should build without error, and should hit the breakpoint. You should also be able to check that the application output "The answer is 42.".

A mixed .NET Core library and .NET Framework application
--------------------------------------------------------

Starting from the solution obtained with the previous script, execute the following steps:

1. In Solution Explorer, open the `project.json` file for the **Library** project and replace `"frameworks": {
    "netstandard1.6" }` with `"frameworks": {
    "netstandard1.4" }`.

2. In the **Library** project, open the context menu for the **References** node and choose **Restore Packages**.

   The solution should still build and function exactly like it did before: the test should pass, and the console application should run and be debuggable.

3. In the **Library** project, open the context menu and choose **Build**.

4. In Solution Explorer, open the context menu for the `src` folder, and choose **Add**. , **New Project**.

5. In the **New Project** dialog, choose the **Visual C#** node, and then choose **Console Application**.

> [!IMPORTANT]
> Make sure you choose a standard console application, not the .NET Core version. In this section, you'll be consuming the library from a .NET Framework application.

6. Name the project "FxApp", and set the location to `Golden\src`.

7. In the **FxApp** project, open the context menu for the **References** node and choose **Add Reference**.

8. In the **Reference Manager** dialog, choose **Browse** and browse to the location of the built `Library.dll` (under the ..Golden\src\Library\bin\Debug\netstandard1.4 path), and then click **Add**. 

   You could also package the library and reference the package, as another way to reference .NET Core code from the .NET Framework.

9. Open the context menu for the **References** node and choose **Manage NuGet Packages**.

10. Choose "nuget.org" as the **Package source**, and choose the **Browse** tab. Check the **Include prerelease** checkbox, and then browse for **Newtonsoft.Json**. Click **Install**. 

11. In the **FxApp** project, open the `Program.cs` file and add a `using Library;` directive to the top of the file, and add `Console.WriteLine($"The answer is {new Thing().Get(42)}.");` to the `Main` method of the program.

12. Set a breakpoint after the line that you just added.

13. Make **FxApp** the startup application for the solution.

14. Press F5 to run the app.

   The application should build and hit the breakpoint. The application output should be "The answer is 42.".
   
   > [!TIP]
   > On Windows platform you can use MSTest. Find out more in the [Using MSTest on Windows document](../testing/using-mstest-on-windows.md).

Moving a library from netstandard 1.4 to 1.3
--------------------------------------------

1. In Solution Explorer, open the `project.json` file in the **Library** project.

2. Replace `frameworks": { "netstandard1.4" }` with `frameworks": { "netstandard1.3" }`.

3. In the **Library** project, open the context menu for the **References** node and choose **Restore Packages**.

4. On the **Build** menu, choose **Build Library**.

5. Remove the `Library` reference from the **FxApp** then add it back using the ..Golden\src\Library\bin\Debug\netstandard1.3 path. This will now reference the 1.3 version.

6. Press F5 to run the application.

   Everything should still work as it did before. Check that the application output is "The answer is 42.", that the breakpoint was hit, and that variables can be inspected.

A mixed PCL library and .NET Framework application
--------------------------------------------------

Close the previous solution if it was open: you will be starting a new script from this section on.

### Writing the library

1. In Visual Studio, choose **File**, **New**, **Project**. In the **New Project** dialog, expand the **Visual C#** node, and choose **Class Library (Portable for iOS, Android and Windows)**. 

2. Name the project "PCLLibrary" and the solution "GoldenPCL". Leave **Create directory for solution** checked. Click **OK**.

3. In Solution Explorer, open the context menu for the **References** node and choose **Manage NuGet Packages**.

4. Choose "nuget.org" as the **Package source**, and choose the **Browse** tab. Check the **Include prerelease** checkbox, and then browse for **Newtonsoft.Json**. Click **Install**. 

5. Rename the class "Thing" and add a method: `public int Get(int number) => Newtonsoft.Json.JsonConvert.DeserializeObject<int>($"{number}");`

6. On the **Build** menu, choose **Build Solution**, and verify that the solution builds.

### Writing the console app

1. In Solution Explorer, open the context menu for the **Solution 'GoldenPCL'** node and choose **Add**. **New Project**. In the **New Project** dialog, expand the **Visual C#** node, choose **Console Application**, and name the project "App". 

2. In the **App** project, open the context menu for the **References** node and choose **Add**,  **Reference**. 

3. In the **Reference Manager** dialog, choose **Browse** and browse to the location of the built `PCLLibrary.dll` (under the ..\GoldenPCL\PCLLibrary\bin\Debug path), and then click **Add**. 

4. In the **App** project, open the `Program.cs` file and add a `using PCLLibrary;` directive to the top of the file, and add `Console.WriteLine($"The answer is {new Thing().Get(42)}.");` to the `Main` method of the program.

5. Set a breakpoint after the line that you just added..

6. In Solution Explorer, open the context menu for the **App** node and choose **Set as StartUp Project**.

7. Press F5 to run the app.

   The application should build, run, and hit the breakpoint after it outputs "The answer is 42.".

Moving a PCL to a NetStandard library
-------------------------------------
The Portable Class Library tooling can automatically modify your PCL to target .NET Standard. 

1.	Double click on the “Properties” node to open the Project Property page

2.	Under the “Targeting header” click the hyperlink “Target .NET Platform Standard”

3.	Click “Yes” when asked for confirmation

The tooling will automatically select the version of .NET Standard that includes all of the targets originally targeted by your PCL. You can target a different version of .NET Standard using the .NET Standard dropdown in the project property page.
 
* If you previously had a packages.config, you may be prompted to uninstall any installed packages before the conversion.

### Manually edit project.json to target .NET Standard from an existing Portable Class Library

1.	If your project.json contains “dnxcore50” in the “supports” element, remove it.

2.	Remove the dependency on “Microsoft.NETCore”

3.	Modify the dependency on “Microsoft.NETCore.Portable.Compatibility” version “1.0.0” to version “1.0.1”

4.	Add a dependency on “NETStandard.Library” version “1.6.0”

5.	From the “frameworks” element, remove the “dotnet” framework (and the “imports” element within it)

6.	Add ` "netstandard1.x” : { } ` to the frameworks element, where x is replaced with the version of .NET Standard you want to target

### Example project.json

This project.json includes supports clauses for UWP and .NET 4.6 and targets netstandard1.3:
```
{
  "supports": {
    "net46.app": {},
    "uwp.10.0.app": {},
  },
  "dependencies": {
    "NETStandard.Library": "1.6.0",
    "Microsoft.NETCore.Portable.Compatibility": "1.0.1"
  },
  "frameworks": {
    "netstandard1.3" : {}
  }
}
```


