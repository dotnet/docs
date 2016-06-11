Building simple F# solutions with the .NET CLI
==============================================

by [Bertrand Le Roy](https://github.com/bleroy) and [Phillip Carter](https://github.com/cartermp)

The scripts in this document describe the steps necessary to build a number of typical .NET Core F# solutions, using the .NET CLI. The scenarios include testing, and using third-party libraries.

Prerequisites
-------------

These scripts assume that .NET Core RC2 CLI SDK preview and VS Code or another code editor are installed on the machine.

A solution using only .NET Core projects
----------------------------------------

1. Create a `GoldenF` directory and open a command-line and Visual Studio Code on it.
2. Create `src` and `test` directories under `GoldenF`.
3. Create `GoldenF/global.json` with `{"projects": ["src", "test"]}`.

### Writing the library

1. Create a `Library` folder under `GoldenF/src`.
2. From `GoldenF/src/Library`, `dotnet new -l F#`.
3. Open `project.json`, remove the `emitEntryPoint` entry.
4. In the `dependencies` section, change the version of `Microsoft.FSharp.Core.netcore` to "1.0.0-alpha-160509".
5. Under `buildOptions/compile/includeFiles`, replace `Program.fs` with `Thing.fs`, then rename the `Program.fs` file to `Thing.fs`.
6. In the `dependencies` section, add `"Newtonsoft.Json": "9.0.1-beta1"`.
7. Under `frameworks/netstandard1.5`, remove the `imports`.
8. In `Thing.fs`, paste the following code:
    ```fs
    namespace Library
    open System
    open Newtonsoft.Json

    module Thing =
        let get x = JsonConvert.DeserializeObject<int>(sprintf "%A" x)
    ```
9. Run `dotnet restore` and `dotnet build`.

### Writing the app

1. Create an `App` folder under `GoldenF/src`.
2. From `GoldenF/src/App`, `dotnet new -l F#`
3. In `GoldenF/src/App/project.json`, replace `netstandard1.5` with `netcoreapp1.0` under `frameworks` and remove its `imports`. 
4. Add the following to `dependencies`:
    ```json
        "Library": {
        "target": "project",
        "version": "1.0.0-*"
        },
    ```
5. Under `dependencies`, change the version of `Microsoft.FSharp.Core.netcore` to "1.0.0-alpha-160509".
6. Change `Program.fs` to:
    ```fs
    open System
    open Library

    [<EntryPoint>]
    let main argv = 
        printfn "Hello World!"
        printfn "%A" (Thing.get 42)
        0 // return an integer exit code
    ```
7. Run `dotnet restore` and `dotnet build`.

You should now be able to `dotnet run` and get "Hello World!" and "42" output to the console.

### Writing the test project

1. Create a `TestLibrary` folder under `GoldenF/test`.
2. From `GoldenF/test/TestLibrary`, `dotnet new -l F#`
3. In `GoldenF/test/TestLibrary/project.json`, replace `netstandard1.5` with `netcoreapp1.0` under `frameworks`. 
4. Add the following to `dependencies`:
    ```json
        "Library": {
        "target": "project",
        "version": "1.0.0-*"
        },
        "xunit": "2.1.0",
        "dotnet-test-xunit": "1.0.0-rc2-build10025"
    ```
5. Under `dependencies`, change the version of `Microsoft.FSharp.Core.netcore` to "1.0.0-alpha-160509".
6. Remove `emitEntryPoint`.
7. Rename the `Program.fs` file to `Test.fs`, and also do the rename in `project.json` under `buildOptions/compile/includeFiles`.
8. Add `"testRunner": "xunit"` at the `project.json` file's top-level, after the dependencies section.
9. In `test.fs`, paste the following code:
    ```fs
    module Test

    open Xunit
    open Library

    [<Fact>]    
    let ``Success``() = Assert.Equal(42, Thing.get 42)
    ```
10. Run `dotnet restore` and `dotnet build`.

You should now be able to run the test and verify it passes by doing `dotnet test`.

**Note**: This will temporarily fail on OS X. This is a known issue.