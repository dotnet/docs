Building simple C# solutions with Visual Studio
===============================================

by [Bertrand Le Roy](https://github.com/bleroy) and [Phillip Carter](https://github.com/cartermp)

The scripts in this document describe the steps necessary to build a number of typical .NET Core solutions, or solutions that include .NET Core components, using Visual Studio. The scenarios include testing and using third-party libraries that have not been explicitly built for the most recent version of .NET Core.

Prerequisites
-------------

These scripts assume that [Visual Studio 2015 Update 2](https://www.visualstudio.com/en-us/news/vs2015-update2-vs.aspx) and the [.NET Core RC2 SDK preview with Visual Studio tooling](https://www.microsoft.com/net/core) are installed on the machine.

A solution using only .NET Core projects
----------------------------------------

### Writing the library

1. Launch Visual Studio, then choose File -> New -> Project. Under Templates / Visual C# / .NET Core, choose "Class Library (.NET Core)" and name the project "Library" and the solution "Golden". Leave "Create directory for solution" checked.
2. Under References, manage NuGet packages, use "nuget.org" as the package source, and browse (including prerelease) for `Newtonsoft.Json`. Click `Install`. Right-click the dependencies folder and click "Restore packages".
3. Rename the `Class1.cs` file to `Thing.cs`. Accept the rename of the class. Remove the constructor and add a method: `public int Get(int number) => Newtonsoft.Json.JsonConvert.DeserializeObject<int>($"{number}");`

The solution should build without error.

### Writing the test project

1. Right-click the solution in the Solution Explorer and create a "test" solution folder. This is only a solution folder, not a physical folder.
2. Right-click the new "test" solution folder, add -> New Project. Choose "Console Application (.NET Core)", call it "TestLibrary" and explicitly put it under `Golden/test`. *Important*: the project needs to be a console application, not a class library.
3. Right-click References and choose "Add reference". Check "Library" under Projects/solution. Edit `project.json` and replace `"Library": "1.0.0-*"` with `"Library": {"target": "project", "version": "1.0.0-*"}`. This is to avoid the resolution of the `Library` project to a NuGet package with the same name. Explicitly setting the target to "project" ensures that the tooling will first search for a project with that name, and not a package. Right-click the dependencies folder and click "Restore packages".
4. Manage NuGet packages with the nuget.org package source, install `xUnit` 2.1.0 and `dotnet-test-xunit` 1.0.0-rc2-* packages from nuget.org to the project. Edit `project.json` and change `imports` to be `[ "dnxcore50", "portable-net45+win8" ]` instead of simply `"dnxcore50"`. This enables the xunit libraries to be correctly restored and used by the project: those libraries have been compiled to be used with portable profiles that include "portable-net45+win8", but not .NET Core, which didn't exist when they were built. The `import` relaxes the tooling version checks at build time. You may now restore packages without error.
5. Edit `project.json` to add `"testRunner": "xunit",`.
6. Add a `LibraryTests.cs` file, add `using Xunit;` and `using Library;` to the top of the file, and the following code to the class:
    ```csharp
    [Fact]
    public void ThingGetsObjectValFromNumber() {
        Assert.Equal(42, new Thing().Get(42));
    }
    ```
7. Optionally, remove the `Program.cs` file, and remove `"compilationOptions": {"emitEntryPoint": true}` from `project.json`.

You should be able to build the solution. You may now go to Test -> Windows -> Test Explorer and run all tests, which should pass.

### Writing the console app

1. Right-click the `src` folder, and add a new "Console Application (.NET Core)" project. Call it "App". Make sure to point the location to `Golden/src`.
2. Add reference to Projects/Solution/Library. Right-click the dependencies folder and click "Restore packages".
3. Right-click the project and set it as the startup project.
4. Open `Program.cs`, add `using Library;` to the top of the file, then add `Console.WriteLine($"The answer is {new Thing().Get(42)}");` to the Main method of Program.cs.
6. Set a breakpoint after the `WriteLine`.
7. Run the app using F5.

The application should have built correctly, and should hit the breakpoint. You should also be able to check that the application output "The answer is 42.".

A mixed .NET Core library and .NET Framework application
--------------------------------------------------------

Starting from the solution obtained with the previous script, execute the following steps:

1. Change the library's `project.json` to use `frameworks/netstandard1.4` instead of 1.5. Restore packages. The solution should still build and function exactly like it did before: the test should pass, and the console application should run and be debuggable.
2. Right-click src, and add a new console application project (not Core, this time, as we want to consume our library from a .NET Framework application). Call it FxApp. Don't forget to use `Golden\src` as the location.
3. Add a reference to the Library project. In theory, you should be able to add the reference to the project, but this scenario is currently broken. As a workaround, build the library project, then browse to the built dll. You could also package the library and reference the package, as another way to reference Core code from the .NET Framework. You will also need to manually add to your project the NuGet packages that the `Library` project is using (namely, `Newtonsoft.Json`), if you included it as a dll.
4. Open `Program.cs`, add `using Library;` to the top of the file, and add `Console.WriteLine($"The answer is {new Thing().Get(42)}.");` to the Main method of the program.
5. Make FxApp the startup application for the solution.
6. Set a breakpoint after the `WriteLine`.
7. Run the app using F5.

The application should build and hit the breakpoint. The application output should be "The answer is 42.".

Moving a library from netstandard 1.4 to 1.3
--------------------------------------------

1. Modify the library's `project.json` to use `frameworks/netstandard1.3` instead of 1.4.
2. Restore packages for the library and build it.
3. Remove the `Library` reference from `FxApp` then add it back, but pointing at the 1.3 version now.

Everything should still work as it did before. Check that the application output "The answer is 42." that the breakpoint was hit, and that variables can be inspected.

A mixed PCL library and .NET Framework application
--------------------------------------------------

Close the previous solution if it was open: we are starting a new script from this section on.

### Writing the library

1. In Visual Studio, do File -> New -> Project. Under Templates / Visual C\#, choose "Class Library (Portable for iOS, Android and Windows)" and name the project "PCLLibrary" and the solution "GoldenPCL".
2. Under References, manage NuGet packages, use "nuget.org" as the package source, and browse (including prerelease) for `Newtonsoft.Json`. Install.
3. Rename the class "Thing". Add a method: `public int Get(int number) => Newtonsoft.Json.JsonConvert.DeserializeObject<int>($"{number}");`
4. Verify that the solution builds.

### Writing the console app

1. Add a new "Console Application" project and call it "App".
2. Add a reference to Projects/Solution/PCLLibrary.
3. Add `Console.WriteLine($"The answer is {new Thing().Get(42)}");` to the Main method of Program.cs, with `using PCLLibrary;` at the top of the file.
4. Right-click App, set it as the startup project.
5. Set a breakpoint after the `WriteLine`.
6. Run the app using F5.

The application should build, run, and hit the breakpoint after it outputs "The answer is 42.".

Moving a PCL to a NetStandard library
-------------------------------------

The PCL library that we built in this script is based on a `csproj`project file. In order to move it to NetStandard, the simplest solution is to manually move its code into a new empty .NET Core Class Library project.

If you have pre-RC2 PCL libraries with a `xproj` file and a `project.json`, you should be able to edit the `project.json` file instead, to reference `"NETStandard.Library": "1.5.0-rc2-24027"`, and target "netstandard1.3".
