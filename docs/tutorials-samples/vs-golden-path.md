Building simple solutions with Visual Studio
============================================

The scripts in this document describe the steps necessary to build a number of typical .NET Core solutions, or solutions that include .NET Core components, using Visual Studio. The scenarios include testing, and using third-party libraries that have not been explicitly built for the most recent version of .NET Core.

Prerequisites
-------------

These scripts assume that .NET Core CLI (latest RC2 version), Visual Studio Update 2, and Visual Studio tooling (latest RC2 version) are installed on the machine.

A solution using only .NET Core projects
----------------------------------------

### Writing the library

1. File -> New. Under Templates / .NET Core, choose "Class Library (.NET Core)" and name the project "Library" and the solution "Golden".
2. Under References, manage NuGet packages, use "nuget.org" as the package source, and browse (including prerelease) for `Newtonsoft.Json`. Install.
3. Go back to packages and install `Microsoft.NETCore.Portable.Compatibility` from the Core MyGet package source (use the latest rc2 version). Restore packages. (\*)
4. Open `project.json` and under frameworks/netstandard1.5, add `"imports": ["portable-net40+sl5+win8+wp8+wpa81", "dotnet"]`. Restore packages. (\*)
5. Rename the class "Thing". Add a method: `public int Get(int number) => Newtonsoft.Json.JsonConvert.DeserializeObject<int>($"{number}");`
6. Verify that the solution builds.

### Writing the test project

1. Create a "test" solution folder. This is only a solution folder, not a physical folder.
2. Right-click the new "test" solution folder, add/new .NET Core class library project, call it "TestLibrary" and explicitly put it under `Golden/test`.
3. Right-click References and choose "Add reference". Check "Library" under Projects/solution.
4. Add references to `Newtonsoft.Json`, `Microsoft.NETCore.Portable.Compatibility`, and add `"imports": [ "portable-net40+sl5+win8+wp8+wpa81", "dotnet" ]` to `frameworks/netstandard1.5` in `project.json`. Restore packages. (\*)
5. Add the `xUnit` and `xunit.runner.visualstudio` packages from nuget.org to the project. Use "portable-net45+win8+wp8+wpa81" in the imports in project.json.
6. Go back to packages and install `Microsoft.NETCore.Portable.Compatibility` from the Core MyGet package source (use the latest rc2 version). Restore packages. (\*)
7. Rename `Class1.cs` to `LibraryTests.cs`, add the following code to the class:
    ```csharp
        [Fact]
        public void ThingGetsObjectValFromNumber() {
            Assert.Equal(42, new Thing().Get(42));
        }
    ```
8. Build. Test -> Windows -> Test Explorer. Run all tests. (this doesn't work)

### Writing the console app

1. Right-click the src folder, and add a new Core console app project, call it App.
2. Add reference to Projects/Solution/Library.
3. Add references to `Newtonsoft.Json` (\*)
3.1. Add a dependency to `"System.Runtime.Serialization.Primitives": "4.1.1-rc2-24008"`, references to `Microsoft.NETCore.Portable.Compatibility` (use the latest rc2 version), and add `"imports": [ "portable-net40+sl5+win8+wp8+wpa81", "dotnet" ]` to frameworks/netcoreapp1.0 in `project.json`. Restore packages. (\*)
4. Add `Console.WriteLine($"The answer is {new Thing().Get(42)}");` to the Main method of Program.cs.
5. Right-click App, set it as the startup project.
6. Set a breakpoint after the `WriteLine`.
7. Run the app using F5.
8. Check that the application output "The answer is 42." that the breakpoint was hit, and that variables can be inspected.

(\*) Those steps are temporary workarounds and will not be necessary with the released bits.

A mixed .NET Core library and .NET Framework application
--------------------------------------------------------

Starting from the solution obtained with the previous script, execute the following steps:

1. Change the library's `project.json` to use `frameworks/netstandard1.4` instead of 1.5.
2. Right-click src, and add a new console application project (not Core). Call it FxApp. Don't forget to use `Golden\src` as the location, as this isn't happening automatically for non-Core projects.
3. Add a reference to Library.
4. Add `Console.WriteLine($"The answer is {new Thing().Get(42)}.");` to the Main method of the program.
5. Make FxApp the startup application for the solution.
6. Set a breakpoint after the `WriteLine`.
7. Run the app using F5.
8. Check that the application output "The answer is 42." that the breakpoint was hit, and that variables can be inspected.

Moving a library from netstandard 1.4 to 1.3
--------------------------------------------

1. Modify the library's `project.json` to use `frameworks/netstandard1.3` instead of 1.4.
2. Restore references for the library.
3. Set a breakpoint after the `WriteLine`.
4. Run the app using F5.
5. Check that the application output "The answer is 42." that the breakpoint was hit, and that variables can be inspected.

A mixed PCL library and .NET Framework application
--------------------------------------------------

### Writing the library

1. File -> New. Under Templates / Visual C\#, choose "Class Library (Portable)" and name the project "PCLLibrary" and the solution "GoldenPCL". Leave .NET Framework 4.6 and ASP.NET Core 5.0 checked.
2. Under References, manage NuGet packages, use "nuget.org" as the package source, and browse (including prerelease) for `Newtonsoft.Json`. Install.
3. Rename the class "Thing". Add a method: `public int Get(int number) => Newtonsoft.Json.JsonConvert.DeserializeObject<int>($"{number}");`
4. Verify that the solution builds.

### Writing the console app

1. Add a new .NET console app project, call it App.
2. Add reference to Projects/Solution/PCLLibrary.
3. Add references to `Newtonsoft.Json` (\*)
4. Add `Console.WriteLine($"The answer is {new Thing().Get(42)}");` to the Main method of Program.cs.
5. Right-click App, set it as the startup project.
6. Set a breakpoint after the `WriteLine`.
7. Run the app using F5.
8. Check that the application output "The answer is 42." that the breakpoint was hit, and that variables can be inspected.

(\*) Those steps are temporary workarounds and will not be necessary with the released bits.

Moving a PCL to a Netstandard library
-------------------------------------

From the previous solution:

1. In `project.json`, remove the "supports" section.
2. In `project.json`/dependencies, update the versions to `"Microsoft.NETCore.Portable.Compatibility": "1.0.1-rc2-24018"` and `"NETStandard.Library": "1.5.0-rc2-24008"`.
3. Under frameworks, set `"netstandard1.3": { "imports": "portable-net40+sl5+win8+wp8+wpa81" }`
