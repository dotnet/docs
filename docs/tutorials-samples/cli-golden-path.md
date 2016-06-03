Building simple solutions with the .NET CLI
===========================================

The scripts in this document describe the steps necessary to build a number of typical .NET Core solutions, or solutions that include .NET Core components, using the .NET CLI. The scenarios include testing, and using third-party libraries that have not been explicitly built for the most recent version of .NET Core.

Prerequisites
-------------

These scripts assume that .NET Core RC2 CLI SDK preview and VS Code or another code editor are installed on the machine.

A solution using only .NET Core projects
----------------------------------------

1. Create a new `GoldenCLI` directory and inside of that, create `src` and `test`. Under `src`, create `Library`, and under `test`, create `TestLibrary`.
2. Open a command-line on `GoldenCLI/src/Library`, and another on `GoldenCLI/test/TestLibrary`.
3. Open VS Code on `GoldenCLI`.
4. Create `GoldenCLI/global.json` with `{"projects":["src", "test"]}`.

### Writing the library

1. From `GoldenCLI/src/Library`, `dotnet new`.
2. Edit `GoldenCLI/src/Library/project.json` to remove the `buildOptions`, and more specifically, `emitEntryPoint`.
3. Change dependencies to `"NETStandard.Library": "1.5.0-rc2-24027", "Newtonsoft.Json": "9.0.1-beta1"`.
4. Under `frameworks`, change `netcoreapp1.0` to `netstandard1.5`.
5. From `GoldenCLI/src/Library`, `dotnet restore`.
6. Rename `Program.cs` to `Thing.cs`, put the following code in there:
```csharp
using System;

namespace Library
{
    public class Thing
    {
        public int Get(int number) => Newtonsoft.Json.JsonConvert.DeserializeObject<int>($"{number}");
    }
}
```
7. `dotnet build`

We now have a build dll under `GoldenCLI/src/Library/bin/Debug/netstandard1.5`.

### Writing the test project

1. From `GoldenCLI/test/TestLibrary`, `dotnet new`.
2. Edit `GoldenCLI/test/TestLibrary/project.json` to remove the `buildOptions`. Leave frameworks as is.
3. Add `"Library": { "target": "project", "version": "1.0.0-*" }, "xunit": "2.1.0"` to `dependencies`. The `target` is important so that the project is built using our `Library` project, and not some NuGet package with the same name.
4. `dotnet restore`.
5. Add `"testRunner": "xunit"` at the `project.json` file's top-level.
6. Rename `Program.js` to `LibraryTest.cs`, replace its contents with:
```csharp
using Library;
using Xunit;

namespace TestApp
{
    public class LibraryTests
    {
        [Fact]
        public void TestThing() {
            Assert.Equal(42, new Thing().Get(42));
        }
    }
}
```
7. `dotnet build`

