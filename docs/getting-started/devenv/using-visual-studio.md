# Development using Visual Studio 2015

by [Bertrand Le Roy](https://github.com/bleroy) and [Phillip Carter](https://github.com/cartermp)

Visual Studio 2015 provides a full-featured development environment for developing .NET Core applications. The procedures in this document describe the steps necessary to build a number of typical .NET Core solutions, or solutions that include .NET Core components, using Visual Studio. The scenarios include testing and using third-party libraries that have not been explicitly built for the most recent version of .NET Core.

## Prerequisites

* Visual Studio 2015 Update 2. If you don't have Visual Studio already, you can download [Visual Studio Community 2015](https://www.visualstudio.com/products/visual-studio-community-vs) for free. 

* NuGet Manager extension for Visual Studio. NuGet is the package manager for the Microsoft development platform including .NET Core. When you use NuGet to install a package, it copies the library files to your solution and automatically updates your project (add references, change config files, etc.). 

* .NET Core Tooling Preview 1 for Visual Studio 2015. This installs templates and other tools as well as .NET Core itself.

* A supported version of the Windows client or server operating system. For a list of supported versions, see [.NET Core System Requirements](../system-reqs.md). 

## Getting Started

The following steps will set up Visual Studio 2015 for .NET Core development:

1. Verify that you're running Visual Studio 2015 Update 2:

   * On the **File** menu, choose **Help**, **About Microsoft Visual Studio**.

   * In the About Microsoft Visual Studio dialog, the version number should include "Update 2" (or higher).

2. Download and install the [MSI Installer for .NET Core Tooling Preview 1](https://go.microsoft.com/fwlink/?linkid=798481). This will install the .NET Core Tooling Preview 1 for Visual Studio 2015.

3. Download and install [NuGet Manager extension for Visual Studio](https://dist.nuget.org/visualstudio-2015-vsix/v3.5.0-beta/NuGet.Tools.vsix). This will install the latest version of the extension.

4. Open Visual Studio, and on the **File** menu, choose **New**, **Project**.

5. In the **New Project** dialog, in the **Templates** list, expand the **Visual C#** node and choose **.NET Core**. You should see three new project templates for **Class Library (.NET Core)**, **Console Application (.NET Core)**, and **ASP.NET Core Web Application (.NET Core)**.

A solution using only .NET Core projects
----------------------------------------

### Writing the library

1. In Visual Studio, choose **File**, **New**, **Project**. In the **New Project** dialog, expand the **Visual C#** and **.NET Core** nodes, and choose **Class Library (.NET Core)**. 

2. Name the project "Library" and the solution "Golden". Leave **Create directory for solution** checked. Click **OK**.

3. In Solution Explorer, open the context menu for the **References** node and choose **Manage NuGet Packages**.

4. Choose "nuget.org" as the **Package source**, and choose the **Browse** tab. Check the **Including prerelease** checkbox, and then browse for **Newtonsoft.Json**. Click **Install**. 

5. Open the context menu for the **References** node and choose  **Restore packages**.

6. Rename the `Class1.cs` file to `Thing.cs`. Accept the rename of the class. Remove the constructor and add a method: `public int Get(int number) => Newtonsoft.Json.JsonConvert.DeserializeObject<int>($"{number}");`

7. On the **Build** menu, choose **Build Solution**.

   The solution should build without error.

### Writing the test project

1. In Solution Explorer, open the context menu for the **Solution** node and choose **Add**, **New Solution Folder**. Name the folder "test". 
   This is only a solution folder, not a physical folder.

2. Open the context menu for the **test** folder and choose **Add**. **New Project**. In the **New Project** dialog, choose **Console Application (.NET Core)**. Name it "TestLibrary" and explicitly put it under the `Golden\test` path. 

   > **Important**
   >
   > The project needs to be a console application, not a class library.

3. In the **TestLibrary** project, open the context menu for the **References** node and choose **Add Reference**. 

4. In the **Reference Manager** dialog, check **Library** under the **Projects**, **Solution** node, and then click **OK**. 

5. In the **TestLibrary** project, open the `project.json` file, and replace `"Library": "1.0.0-*"` with `"Library": {"target": "project", "version": "1.0.0-*"}`. 

   This is to avoid the resolution of the `Library` project to a NuGet package with the same name. Explicitly setting the target to "project" ensures that the tooling will first search for a project with that name, and not a package. 
   
6. In the **TestLibrary** project, open the context menu for the **References** node and choose **Restore Packages**.

7. Open the context menu for the **References** node and choose **Manage NuGet Packages**.

8. Choose "nuget.org" as the **Package source**, and choose the **Browse** tab. Check the **Including prerelease** checkbox, and then browse for **xUnit** version 2.1.0, and then click **Install**. 

9. Browse for **dotnet-test-xunit** version 1.0.0-rc2 or newer, and then click **Install**.

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
    * Optionally, delete the `Program.cs` file from the **TestLibrary** project, and remove `"buildOptions": {"emitEntryPoint": true}` from `project.json`.

   You should now be able to build the solution. 
   
13. On the **Test** menu, choose **Windows**, **Test Explorer**, and in Test Explorer choose **Run All**.
   
   The test should pass.

### Writing the console app

1. In Solution Explorer, open the context menu for the `src` folder, and add a new **Console Application (.NET Core)** project. Name it "App", and set the location to `Golden\src`.

2. In the **App** project, open the context menu for the **References** node and choose **Add**,  **Reference**. 

3. In the **Reference Manager** dialog, check **Library** under the **Projects**, **Solution** node, and then click **OK** 

4. Open the context menu for the **References** node and choose **Restore Packages**.

5. Open the context menu for the **App** node and choose **Set as StartUp Project**.

6. Open the `Program.cs` file, add a `using Library;` directive to the top of the file, and then add `Console.WriteLine($"The answer is {new Thing().Get(42)}");` to the `Main` method.

7. Set a breakpoint after the line that you just added.

8. Press F5 to run the application..

   The application should build without error, and should hit the breakpoint. You should also be able to check that the application output "The answer is 42.".

A mixed .NET Core library and .NET Framework application
--------------------------------------------------------

Starting from the solution obtained with the previous script, execute the following steps:

1. In Solution Explorer, open the `project.json` file for the **Library** project and replace `"frameworks": {
    "netstandard1.5"` with `"frameworks": {
    "netstandard1.4"`.

2. In the **Library** project, open the context menu for the **References** node and choose **Restore Packages**.

   The solution should still build and function exactly like it did before: the test should pass, and the console application should run and be debuggable.

3. In Solution Explorer, open the context menu for the `src` folder, and choose **Add**. , **New Project**.

4. In the **New Project** dialog, choose the **Visual C#** node, and then choose **Console Application**.

   > **Important**
   >
   > Make sure you choose a standard console application, not the .NET Core version. In this section, you'll be  consuming the library from a .NET Framework application

5. Name the project "FxApp", and set the location to `Golden\src`.

6. In the **FxApp** project, open the the context menu for the **References** node and choose **Add Reference**.

7. In the **Reference Manager** dialog, choose **Browse** and browse to the location of the built `Library.dll` (under the ..Golden\src\Library\bin\Debug\netstandard1.4 path), and then click **Add**. 

   You could also package the library and reference the package, as another way to reference .NET Core code from the .NET Framework.

8. Open the context menu for the **References** node and choose **Manage NuGet Packages**.

9. Choose "nuget.org" as the **Package source**, and choose the **Browse** tab. Check the **Including prerelease** checkbox, and then browse for **Newtonsoft.Json**. Click **Install**. 

10. In the **FxApp** project, open the `Program.cs` file and add a `using Library;` directive to the top of the file, and add `Console.WriteLine($"The answer is {new Thing().Get(42)}.");` to the `Main` method of the program.

11. Set a breakpoint after the line that you just added.

12. Make **FxApp** the startup application for the solution.

13. Press F5 to run the app.

   The application should build and hit the breakpoint. The application output should be "The answer is 42.".

Moving a library from netstandard 1.4 to 1.3
--------------------------------------------

1. In Solution Explorer, open the `project.json` file in the **Library** project.

2. Replace `frameworks": { "netstandard1.4"` with `frameworks": { "netstandard1.3"`.

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

4. Choose "nuget.org" as the **Package source**, and choose the **Browse** tab. Check the **Including prerelease** checkbox, and then browse for **Newtonsoft.Json**. Click **Install**. 

5. Rename the class "Thing" and add a method: `public int Get(int number) => Newtonsoft.Json.JsonConvert.DeserializeObject<int>($"{number}");`

6. On the **Build** menu, choose **Build Solution**, and verify that the solution builds.

### Writing the console app

1. In Solution Explorer, open the contaxt menu for the **Solution 'GoldenPCL'** node and choose **Add**. **New Project**. In the **New Project** dialog, expand the **Visual C#** node, choose **Console Application**, and name the project "App". 

2. In the **App** project, open the context menu for the **References** node and choose **Add**,  **Reference**. 

3. In the **Reference Manager** dialog, choose **Browse** and browse to the location of the built `PCLLibrary.dll` (under the ..\GoldenPCL\PCLLibrary\bin\Debug path), and then click **Add**. 

4. In the **App** project, open the `Program.cs` file and add a `using PCLLibrary;` directive to the top of the file, and add `Console.WriteLine($"The answer is {new Thing().Get(42)}.");` to the `Main` method of the program.

5. Set a breakpoint after the line that you just added..

6. In Solution Explorer, open the context menu for the **App** node and choose **Set as StartUp Project**.

7. Press F5 to run the app.

   The application should build, run, and hit the breakpoint after it outputs "The answer is 42.".

Moving a PCL to a NetStandard library
-------------------------------------

The PCL library that we built in the previous procedure is based on a `csproj` project file. In order to move it to NetStandard, the simplest solution is to manually move its code into a new empty **.NET Core Class Library** project.

If you have pre-RC2 PCL libraries with a `xproj` file and a `project.json` file, you should be able to edit the `project.json` file instead, to reference `"NETStandard.Library": "1.5.0-rc2-24027"`, and target "netstandard1.3".



