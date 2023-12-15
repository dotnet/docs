---
title: MSTest runner overview
description: Learn about the MSTest runner, a lightweight way to run tests without depending on the .NET SDK.
author: nohwnd
ms.author: jajares
ms.date: 12/15/2023
---

# MSTest runner overview

The MSTest runner is a lightweight and portable alternative to [VSTest](https://github.com/microsoft/vstest) for running tests in continuous integration (CI) pipelines, and in Visual Studio Test Explorer. The MSTest runner is embedded directly in your MSTest test projects, and there's no other app dependencies, such as `vstest.console` or `dotnet test` needed to run your tests.

The MSTest runner is open source, and builds on a Microsoft.`Testing.Platform` library. You can find Microsoft.`Testing.Platform` code in [microsoft/testfx](https://github.com/microsoft/testfx/tree/main/src/Platform/Microsoft.`Testing.Platform`) GitHub repository. The MSTest runner comes bundled with MSTest in 3.2.0-preview. This preview is available in the [test-tools NuGet feed](https://pkgs.dev.azure.com/dnceng/public/_packaging/test-tools/nuget/v3/index.json).

## Enable MSTest runner in a MSTest project

To enable the MSTest runner in an MSTest project, you need to add the `UseMSTestRunner` in your project file, and unsure that you're using MSTest 3.2.0-preview or newer, consider the following example _*.csproj_ file:

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <!-- Enable the MSTest runner, this is an opt-in feature -->
    <EnableMSTestRunner>true</EnableMSTestRunner>

    <TargetFramework>net8.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>

    <IsPackable>false</IsPackable>
    <IsTestProject>true</IsTestProject>
  </PropertyGroup>

  <ItemGroup>
    <!-- 
      MSTest meta package is the recommended way to reference MSTest.
      It's equivalent to referencing:
          Microsoft.NET.Test.Sdk
          MSTest.TestAdapter
          MSTest.TestFramework
          MSTest.Analyzers
    -->    
    <PackageReference Include="MSTest" Version="3.2.0-preview.23570.1" />

    <!-- 
      Coverlet collector isn't compatible with MSTest runner, you can 
      either switch to Microsoft CodeCoverage (as shown below),
      or switch to be using coverlet global tool
      https://github.com/coverlet-coverage/coverlet#net-global-tool-guide-suffers-from-possible-known-issue
    --> 
    <PackageReference Include="Microsoft.`Testing.Platform`.Extensions.CodeCoverage" 
                      Version="17.9.4-beta.23563.1" />
  </ItemGroup>

</Project>
```

## Run and debug tests

MSTest runner test projects are built as executables that can be run (or debugged) directly. There's no extra test running console or command. The app exits with a nonzero exit code if there's an error, as typical with most executables. For more information on the known exit codes, see [MStest runner exit codes](unit-testing-mstest-runner-exit-codes.md).

> [!IMPORTANT]
> By default, the MStest runner collects telemetry. For more information and options on opting out, see [MSTest runner telemetry](unit-testing-mstest-runner-telemetry.md).

### [.NET CLI](#tab/dotnetcli)

Publishing the test project using `dotnet publish` and running the app directly is another way to run your tests. For example, executing the `./Contoso.MyTests.exe`. In some scenarios it's also viable to use `dotnet build` to produce the executable, but there can be edge cases to consider, such [Native AOT](../deploying/native-aot/index.md).

### Use `dotnet run`

The `dotnet run` command can be used to build and run your test project. This is the easiest, although sometimes slowest, way to run your tests. Using `dotnet run` is practical when you're editing and running tests locally, because it ensures that the test project is rebuilt when needed. `dotnet run` will also automatically find the project in the current folder.

```dotnetcli
dotnet run --project Contoso.MyTests
```

For more information on `dotnet run`, see [dotnet run](../tools/dotnet-run.md).

### Use `dotnet exec`

The `dotnet exec` command is used to execute (or run) an already built test project, this is an alternative to running the application directly. `dotnet exec` requires path to the built test project dll.

```dotnetcli
dotnet exec Contoso.MyTests.dll
```

> [!NOTE]
> Providing the path to the test project executable (_*.exe_) results in an error:
>
> ```Output
> Error:
>   An assembly specified in the application dependencies manifest
>   (Contoso.MyTests.deps.json) has already been found but with a different
>   file extension:
>     package: 'Contoso.MyTests', version: '1.0.0'
>     path: 'Contoso.MyTests.dll'
>     previously found assembly: 'S:\t\Contoso.MyTests\bin\Debug\net8.0\Contoso.MyTests.exe'
> ```

For more information on `dotnet exec`, see [dotnet exec](../tools/dotnet.md#options-for-running-an-application-with-the-exec-command).

### Use `dotnet test`

For tests authored with MSTest, NUnit or xUnit test framework, it's possible to run tests with [dotnet test](../tools/dotnet-test.md). The `dotnet test` command only works with MSTest, NUnit and xUnit tests. Provide a path to the tested dll, or to the project and your tests run:

```dotnetcli
dotnet test Contoso.MyTests.dll
```

### [Visual Studio](#tab/visual-studio)

The `Testing.Platform` tests can be run (and debugged) in Visual Studio, they integrate with Test Explorer, and can also be run directly as startup project.

#### Run the app with Visual Studio

`Testing.Platform` test project are built as executables, and can be run directly. This runs all the tests in the given executable, unless a filter is provided.

1. Navigate the test project you want to run in Solution Explorer, right select it and select **Set as Startup Project**.
1. Select **Debug** > **Start without Debugging** (or use <kbd>Ctrl</kbd>+<kbd>F5</kbd>) to run the selected test project.

Console window pops up with the execution and summary of your test run.

### Debug the app directly in Visual Studio

`Testing.Platform` test project can be debugged directly. To debug all the tests in the given executable, unless a filter is provided:

1. Navigate the test project you want to run in Solution Explorer, right select it and select **Set as Startup Project**.
1. Set breakpoint into the test that you'd like to debug.
1. Go to **Debug** > **Start Debugging** (or press <kbd>F5</kbd>) to debug the selected test project.

All tests are executed until your test with a breakpoint is reached. Step through your test to debug it. Once you're done debugging the app resumes running all remaining tests, unless you stop it.

### Use Test Explorer

`Testing.Platform` tests partially integrate with Visual Studio's **Test Explorer**. Tests can be run and debugged from **Test Explorer**.

To run a test, navigate to **Test Explorer**, select the test (or tests) to run. Right select it, and choose **Run**. Similarly to debug a test, select the test (or tests) in **Test Explorer**, right select and choose **Debug**.

> [!TIP]
> Automatic update of tests without building the project isn't available.

### [Continuous integration (CI)](#tab/continuous-integration)

There's no special pipeline task, or any extra tooling to run `Testing.Platform` tests. There's also no other tooling required to run multiple tests projects through a single command.

To run a test project in CI add one step for each test executable that you wish to run, such as this on Azure DevOps:

```yml
- task: CmdLine@2
  displayName: "Run Contoso.MyTests.exe"
  inputs:
    script: '.\Contoso.MyTests\bin\Debug\net8.0\Contoso.MyTests.exe'
```

---

## See also

- [MSTest runner and VSTest comparison](unit-testing-mstest-runner-vs-vstest.md)
- [MSTest runner extensions](unit-testing-mstest-runner-extensions.md)
- [MSTest runner telemetry](unit-testing-mstest-runner-telemetry.md)
- [MSTest runner exit codes](unit-testing-mstest-runner-exit-codes.md)
