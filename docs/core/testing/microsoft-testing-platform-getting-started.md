---
title: Get started with Microsoft.Testing.Platform
description: Learn how to create and run your first test project using Microsoft.Testing.Platform in under 5 minutes.
author: Evangelink
ms.author: amauryleve
ms.date: 11/27/2025
---

# Get started with Microsoft.Testing.Platform

This guide helps you create and run your first test project using Microsoft.Testing.Platform in under 5 minutes.

## Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) or .NET Framework 4.6.2 or later
- A code editor (Visual Studio, Visual Studio Code, or any text editor)

## Create your first test project

The fastest way to get started is using the MSTest SDK, which comes with Microsoft.Testing.Platform built-in.

### [.NET CLI](#tab/dotnetcli)

Open a terminal and run:

```dotnetcli
dotnet new mstest -n MyFirstTests
cd MyFirstTests
```

### [Visual Studio](#tab/visual-studio)

1. Open Visual Studio
1. Select **Create a new project**
1. Search for "MSTest"
1. Select **MSTest Test Project** and select **Next**
1. Name your project "MyFirstTests" and select **Create**

---

The project is created with Microsoft.Testing.Platform already configured and includes a sample test.

## Run your tests

### [.NET CLI](#tab/dotnetcli)

Run the tests directly:

```dotnetcli
dotnet run --project MyFirstTests
```

Or use `dotnet test`:

```dotnetcli
dotnet test
```

You should see output similar to:

```output
Passed! - Failed: 0, Passed: 1, Skipped: 0, Total: 1, Duration: 20ms
```

### [Visual Studio](#tab/visual-studio)

**Option 1: Using Test Explorer**

1. Open **Test Explorer** (Test > Test Explorer)
1. Select **Run All Tests** (or press <kbd>Ctrl</kbd>+<kbd>R</kbd>, <kbd>A</kbd>)

**Option 2: Run directly**

1. Right-click the test project in Solution Explorer
1. Select **Set as Startup Project**
1. Press <kbd>F5</kbd> to run

### [Visual Studio Code](#tab/visual-studio-code)

1. Install the [C# Dev Kit extension](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp)
1. Open the test project folder
1. Open the **Test Explorer** view
1. Select **Run All Tests**

Or use the integrated terminal:

```dotnetcli
dotnet run --project MyFirstTests
```

Or use `dotnet test`:

```dotnetcli
dotnet test --project MyFirstTests
```

---

## Understanding the test project

The generated test project includes:

**Project file** (*MyFirstTests.csproj*):

```xml
<Project Sdk="MSTest.Sdk/4.0.2">
  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
  </PropertyGroup>
</Project>
```

The `MSTest.Sdk` automatically configures Microsoft.Testing.Platform.

**Sample test file** (*UnitTest1.cs*):

```csharp
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestMethod1()
    {
        Assert.IsTrue(true);
    }
}
```

## Write your first test

Let's write a simple calculator test. Create a new file *CalculatorTests.cs*:

```csharp
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class CalculatorTests
{
    [TestMethod]
    public void Add_TwoNumbers_ReturnsSum()
    {
        // Arrange
        int a = 2;
        int b = 3;
        
        // Act
        int result = a + b;
        
        // Assert
        Assert.AreEqual(5, result);
    }
}
```

Run the tests again and you should see:

```output
Passed! - Failed: 0, Passed: 2, Skipped: 0, Total: 2, Duration: 25ms
```

## Enable in an existing project

If you have an existing test project using MSTest, NUnit, or xUnit.net, you can enable Microsoft.Testing.Platform:

### [MSTest](#tab/mstest)

Update your project file to use MSTest SDK:

```xml
<Project Sdk="MSTest.Sdk/4.0.2">
  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
  </PropertyGroup>
</Project>
```

Or enable the MSTest runner:

```xml
<PropertyGroup>
  <EnableMSTestRunner>true</EnableMSTestRunner>
  <OutputType>Exe</OutputType>
</PropertyGroup>
```

For more information, see [MSTest runner](unit-testing-mstest-runner-intro.md).

### [NUnit](#tab/nunit)

Add to your project file:

```xml
<PropertyGroup>
  <EnableNUnitRunner>true</EnableNUnitRunner>
  <OutputType>Exe</OutputType>
</PropertyGroup>
```

For more information, see [NUnit runner](unit-testing-nunit-runner-intro.md).

### [xUnit.net](#tab/xunit)

xUnit.net v3 supports Microsoft.Testing.Platform. Add to your project file:

```xml
<PropertyGroup>
  <UseMicrosoftTestingPlatformRunner>true</UseMicrosoftTestingPlatformRunner>
  <OutputType>Exe</OutputType>
</PropertyGroup>
```

For more information, see [xUnit.net documentation](https://xunit.net/docs/getting-started/v3/microsoft-testing-platform).

---

## Next steps

Now that you have tests running, explore these common scenarios:

### Run specific tests

Filter which tests to run:

```dotnetcli
dotnet run --project MyFirstTests -- --filter "FullyQualifiedName~Calculator"
```

For more information, see [Running selective unit tests](selective-unit-tests.md).

### Collect code coverage

Add code coverage to see which code is tested:

1. Add the package (if not using MSTest SDK):

   ```dotnetcli
   dotnet add package Microsoft.Testing.Extensions.CodeCoverage
   ```

1. Run with coverage:

   ```dotnetcli
   dotnet run --project MyFirstTests -- --coverage
   ```

For more information, see [Code coverage extensions](microsoft-testing-platform-extensions-code-coverage.md).

### Generate test reports

Create TRX reports for CI/CD:

1. Add the package (if not using MSTest SDK):

   ```dotnetcli
   dotnet add package Microsoft.Testing.Extensions.TrxReport
   ```

1. Run with reports:

   ```dotnetcli
   dotnet run --project MyFirstTests -- --report-trx
   ```

For more information, see [Test reports extensions](microsoft-testing-platform-extensions-test-reports.md).

### Debug failing tests

Set breakpoints in your test code and debug:

- **Visual Studio**: Right-click test in Test Explorer > **Debug**
- **Visual Studio Code**: Use F5 with the test project as startup
- **CLI**: Use `dotnet run` and attach a debugger

### Run in CI/CD pipelines

Tests run as regular executables in CI:

```yml
- task: CmdLine@2
  displayName: "Run Tests"
  inputs:
    script: 'dotnet run --project MyFirstTests'
```

For more information, see [Microsoft.Testing.Platform overview](microsoft-testing-platform-intro.md#continuous-integration-ci).

### Configure test execution

Learn about all available options:

- [Configuration reference](microsoft-testing-platform-options.md) - All command-line options, environment variables, and config files
- [Exit codes](microsoft-testing-platform-exit-codes.md) - Understanding test results

### Learn your test framework

Deep dive into writing tests with your chosen framework:

- [MSTest](unit-testing-mstest-intro.md) - Microsoft's test framework
- [NUnit](unit-testing-csharp-with-nunit.md) - Popular cross-platform framework
- [xUnit.net](unit-testing-csharp-with-xunit.md) - Modern testing framework

## See also

- [Microsoft.Testing.Platform overview](microsoft-testing-platform-intro.md)
- [Configuration reference](microsoft-testing-platform-options.md)
- [Unit testing best practices](unit-testing-best-practices.md)
