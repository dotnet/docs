Building simple C# solutions with the .NET CLI
==============================================

by [Bertrand Le Roy](https://github.com/bleroy) and [Phillip Carter](https://github.com/cartermp)

The scripts in this document describe the steps necessary to build a number of typical .NET Core solutions, using the .NET CLI. The scenarios include testing, and using third-party libraries.

Prerequisites
-------------

These scripts assume that .NET Core RC2 CLI SDK preview and VS Code or another code editor are installed on the machine.

A solution using only .NET Core projects
----------------------------------------

1. Create a new `GoldenCLI` directory and inside of that, create `src` and `test`. Under `src`, create `Library` and `App`, and under `test`, create `TestLibrary`.
2. Open a command-line on `GoldenCLI/src/Library`, and another on `GoldenCLI/test/TestLibrary`.
3. Open VS Code on `GoldenCLI`.
4. Create `GoldenCLI/global.json` with `{"projects":["src", "test"]}`.

### Writing the library

1. Open a command-line on `GoldenCLI/src/Library`, then do `dotnet new`.
2. Edit `GoldenCLI/src/Library/project.json` and remove the `buildOptions` section.
3. Change dependencies to `"NETStandard.Library": "1.5.0-rc2-24027", "Newtonsoft.Json": "9.0.1-beta1"`.
4. Under `frameworks`, change `netcoreapp1.0` to `netstandard1.5`.
5. From `GoldenCLI/src/Library`, run  `dotnet restore`.
6. Rename `Program.cs` to `Thing.cs`, and replace its contents with:
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
7. Run `dotnet build`

We now have a built `Library.dll` file under `GoldenCLI/src/Library/bin/Debug/netstandard1.5`.

### Writing the test project

1. Open a command-line on `GoldenCLI/test/TestLibrary`, then do `dotnet new`.
2. Edit `GoldenCLI/test/TestLibrary/project.json` and remove `buildOptions` section.
3. Add the following to dependencies:
    ```json
    "Library": {
        "target": "project",
        "version": "1.0.0-*"
    },
    "xunit": "2.1.0",
    "dotnet-test-xunit": "1.0.0-rc2-build10025"
    ```
    The `target` under `Library` is important so that the project is built using our `Library` project, and not some NuGet package with the same name.
4. `dotnet restore`.
5. Add `"testRunner": "xunit"` at the `project.json` file's top-level, after the dependencies section.
6. Rename `Program.cs` to `LibraryTest.cs`, and replace its contents with:
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
7. Run `dotnet build`
8. Run `dotnet test`

You should now see one test passing.

### Writing the console app

1. Open a command-line on `GoldenCLI/src/App`, then do `dotnet new`.
2. Edit `GoldenCLI/src/App/project.json` and add `"Library": { "target": "project", "version": "1.0.0-*" }` to `dependencies`. The `target` is important so that the project is built using our `Library` project, and not some NuGet package with the same name. If you are building on Windows, also add `"debugType": "portable"` under `buildOptions`.
3. Run `dotnet restore`.
4. Open `Program.cs`, add `using Library;` to the top of the file, then replace the Main method with `Console.WriteLine($"The answer is {new Thing().Get(42)}.");`.
5. Run the app using `dotnet run` from the command-line, or set a breakpoint after the `WriteLine`, and hit F5 from Visual Studio Code. Please refer to [the Visual Studio Code C# Extension documentation](https://github.com/OmniSharp/omnisharp-vscode/blob/master/debugger.md) for details on setting-up debugging.

The application should build correctly, and should hit the breakpoint if you've launched the debugger. You should also be able to verify that in both cases the application output is "The answer is 42.".
