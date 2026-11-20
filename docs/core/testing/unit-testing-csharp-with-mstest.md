---
title: Get started with C# and MSTest
description: Learn unit test concepts in C# and .NET through an interactive experience building a sample solution step-by-step using dotnet test and MSTest.
author: ncarandini
ms.author: wiwagn
ms.date: 11/05/2026
ai-usage: ai-assisted
---
# Get started with C# and MSTest

This tutorial takes you through an interactive experience building a sample solution step-by-step to learn unit testing concepts. If you prefer to follow the tutorial using a pre-built solution, [view or download the sample code](https://github.com/dotnet/samples/blob/main/core/getting-started/unit-testing-using-mstest/) before you begin. For download instructions, see [Samples and Tutorials](../../samples-and-tutorials/index.md#view-and-download-samples).

[!INCLUDE [testing an ASP.NET Core project from .NET](../../../includes/core-testing-note-aspnet.md)]

## Prerequisites

[!INCLUDE [Prerequisites](../../../includes/prerequisites-basic.md)]

## Create the source project

Open a shell window. Create a directory called *unit-testing-using-mstest* to hold the solution. Inside this new directory, run [`dotnet new sln`](../tools/dotnet-new.md) to create a new solution file for the class library and the test project. Create a *PrimeService* directory. The following outline shows the directory and file structure thus far:

```console
/unit-testing-using-mstest
    unit-testing-using-mstest.sln
    /PrimeService
```

Make *PrimeService* the current directory and run [`dotnet new classlib`](../tools/dotnet-new.md) to create the source project.

Change the directory back to the *unit-testing-using-mstest* directory. Run [`dotnet sln add`](../tools/dotnet-sln.md) to add the class library project to the solution:

```dotnetcli
dotnet sln add PrimeService/PrimeService.csproj
```

Rename `Class1.cs` in the `PrimeService` directory to `PrimeService.cs`. Replace the code in the file with the following code to create a failing implementation of the `PrimeService` class:

```csharp
using System;

namespace Prime.Services
{
    public class PrimeService
    {
        public bool IsPrime(int candidate)
        {
            throw new NotImplementedException("Please create a test first.");
        }
    }
}
```

## Create the test project

Create the *PrimeService.Tests* directory. The following outline shows the directory structure:

```console
/unit-testing-using-mstest
    unit-testing-using-mstest.sln
    /PrimeService
        Source Files
        PrimeService.csproj
    /PrimeService.Tests
```

Make the *PrimeService.Tests* directory the current directory and create a new project using [`dotnet new mstest`](../tools/dotnet-new.md). The dotnet new command creates a test project that uses MSTest as the test library. The template configures the test runner in the *PrimeServiceTests.csproj* file:

```xml
<ItemGroup>
  <PackageReference Include="MSTest" Version="4.1.0" />
</ItemGroup>
```

[!INCLUDE [MSTest package versions](../../../includes/mstest-package-versions.md)]

The test project requires other packages to create and run unit tests. `dotnet new` in the previous step added the necessary MSTest packages and tools for code coverage reporting.

Add the `PrimeService` class library as another dependency to the project. Use the [`dotnet reference add`](../tools/dotnet-reference-add.md) command:

```dotnetcli
dotnet reference add ../PrimeService/PrimeService.csproj
```

You can see the entire file in the [samples repository](https://github.com/dotnet/samples/blob/main/core/getting-started/unit-testing-using-mstest/PrimeService.Tests/PrimeService.Tests.csproj) on GitHub.

The following outline shows the final solution layout:

```console
/unit-testing-using-mstest
    unit-testing-using-mstest.sln
    /PrimeService
        Source Files
        PrimeService.csproj
    /PrimeService.Tests
        Test Source Files
        PrimeServiceTests.csproj
```

Change to the *unit-testing-using-mstest* directory, and run [`dotnet sln add`](../tools/dotnet-sln.md):

```dotnetcli
dotnet sln add ./PrimeService.Tests/PrimeService.Tests.csproj
```

## Create the first test

Write a failing test, make it pass, then repeat the process. Remove *UnitTest1.cs* from the *PrimeService.Tests* directory and create a new C# file named *PrimeService_IsPrimeShould.cs* with the following content:

```csharp
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prime.Services;

namespace Prime.UnitTests.Services
{
    [TestClass]
    public class PrimeService_IsPrimeShould
    {
        private readonly PrimeService _primeService;

        public PrimeService_IsPrimeShould()
        {
            _primeService = new PrimeService();
        }

        [TestMethod]
        public void IsPrime_InputIs1_ReturnFalse()
        {
            bool result = _primeService.IsPrime(1);

            Assert.IsFalse(result, "1 shouldn't be prime");
        }
    }
}
```

The [TestClass attribute](xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute) denotes a class that contains unit tests. The [TestMethod attribute](xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute) indicates a method is a test method.

MSTest creates a new instance of the test class for each test, so the constructor creates a separate `PrimeService` for each test. The constructor contains only setup that every test in this class needs. If your tests need different setup, create objects in the test methods or call helper methods from those methods. For guidance, see [Use helper methods instead of Setup and Teardown](unit-testing-best-practices.md#use-helper-methods-instead-of-setup-and-teardown).

Save this file and execute [`dotnet test`](../tools/dotnet-test.md) to build the tests and the class library and then run the tests. The MSTest test runner contains the program entry point to run your tests. `dotnet test` starts the test runner using the unit test project you created.

Your test fails because you didn't create the implementation yet. Make this test pass by writing the simplest code in the `PrimeService` class that works:

```csharp
public bool IsPrime(int candidate)
{
    if (candidate == 1)
    {
        return false;
    }
    throw new NotImplementedException("Please create a test first.");
}
```

In the *unit-testing-using-mstest* directory, run `dotnet test` again. The `dotnet test` command runs a build for the `PrimeService` project and then for the `PrimeService.Tests` project. After building both projects, it runs this single test. It passes.

## Add more features

Now that you made one test pass, it's time to write more. There are a few other simple cases for prime numbers: 0, -1. You could add new tests with the [TestMethod attribute](xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute), but that quickly becomes tedious. There are other MSTest attributes that enable you to write a suite of similar tests. A test method can execute the same code but have different input arguments. You can use the [DataRow attribute](xref:Microsoft.VisualStudio.TestTools.UnitTesting.DataRowAttribute) to specify values for those inputs.

Instead of creating new tests, apply these two attributes to create a single data driven test. The data driven test is a method that tests several values less than two, which is the lowest prime number. Add a new test method in *PrimeService_IsPrimeShould.cs*:

:::code language="csharp" source="snippets/unit-testing-using-mstest/csharp/PrimeService.Tests/PrimeService_IsPrimeShould.cs" id="Sample_TestCode":::

Run `dotnet test`, and two of these tests fail. To make all of the tests pass, change the `if` clause at the beginning of the `IsPrime` method in the *PrimeService.cs* file:

```csharp
if (candidate < 2)
```

Continue to iterate by adding more tests, more theories, and more code in the main library. You have the [finished version of the tests](https://github.com/dotnet/samples/blob/main/core/getting-started/unit-testing-using-mstest/PrimeService.Tests/PrimeService_IsPrimeShould.cs) and the [complete implementation of the library](https://github.com/dotnet/samples/blob/main/core/getting-started/unit-testing-using-mstest/PrimeService/PrimeService.cs).

You built a small library and a set of unit tests for that library. You structured the solution so that adding new packages and tests is part of the normal workflow. You concentrated most of your time and effort on solving the goals of the application.

## Run tests in Azure Pipelines

To run your tests automatically when you push changes, add an Azure Pipelines configuration to the repository that contains your completed solution. You need an Azure DevOps project and access to a Microsoft-hosted agent. For prerequisites, see [Create your first pipeline](/azure/devops/pipelines/create-first-pipeline).

1. At the root of your repository, create an `azure-pipelines.yml` file with the following content. The example assumes that the `PrimeService` and `PrimeService.Tests` directories are at the repository root and both projects target .NET 10.

   :::code language="yaml" source="./snippets/unit-testing-csharp-with-mstest/azure-pipelines.yml":::

1. Adjust the configuration to match your repository:

   - If your branch has a different name, replace `main` in `trigger` with that branch name.
   - If your solution is in a subdirectory, update `projects` to the test project's path relative to the repository root.
   - If your projects target a different .NET version, change `version` in the `UseDotNet@2` task to match. For example, use `8.0.x` for projects that target `net8.0`. If your repository contains a `global.json` file, ensure that the installed SDK satisfies its version requirements.

1. Commit and push your solution and `azure-pipelines.yml` file to your Git repository.
1. In your Azure DevOps project, select **Pipelines** > **New pipeline**, or **Create pipeline** if it's your first pipeline. Select your repository provider and repository.
1. On the **Configure your pipeline** page, select **Existing Azure Pipelines YAML file**, select the branch and `/azure-pipelines.yml`, and then select **Continue**. Review the configuration and select **Run**.

The [`UseDotNet@2` task](/azure/devops/pipelines/tasks/reference/use-dotnet-v2) installs the .NET SDK. The [`DotNetCoreCLI@2` task](/azure/devops/pipelines/tasks/reference/dotnet-core-cli-v2) runs `dotnet test`, which restores dependencies, builds the test project and its referenced library, and runs the tests in the Release configuration.

With `publishTestResults: true`, the task generates a TRX results file and publishes the results, even if a test fails. After the run, open the pipeline run's **Tests** tab to review passed and failed tests. A failed test also causes the test task and pipeline to fail.

> [!NOTE]
> This example uses the default VSTest configuration from `dotnet new mstest` with the .NET 10 SDK. If you enable Microsoft.Testing.Platform (MTP), see [Run MTP tests in continuous integration](microsoft-testing-platform-run-and-debug.md?tabs=continuous-integration) for the required runner configuration.

## See also

- <xref:Microsoft.VisualStudio.TestTools.UnitTesting>
- [Use the MSTest framework in unit tests](/visualstudio/test/using-microsoft-visualstudio-testtools-unittesting-members-in-unit-tests)
- [MSTest V2 test framework docs](https://github.com/Microsoft/testfx-docs)
