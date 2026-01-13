---
title: dotnet test command
description: The dotnet test command is used to execute unit tests in a given project.
ms.date: 12/29/2024
ai-usage: ai-assisted
---
# dotnet test

**This article applies to:** ✔️ .NET 6 SDK and later versions

## Name

`dotnet test` - .NET test driver used to execute unit tests.

## Description

The `dotnet test` command builds the solution and runs the tests with either VSTest or Microsoft Testing Platform (MTP). The test runner you use determines the available command-line options and behavior.

> [!NOTE]
> Test runner selection is available starting with .NET 10 SDK. In earlier versions of .NET, tests are always executed with VSTest.

### Choosing a test runner

To enable MTP, you need to specify the test runner in the [`global.json`](global-json.md) file. Here are examples of how to configure the test runner:

**Microsoft Testing Platform:**

```json
{
    "test": {
        "runner": "Microsoft.Testing.Platform"
    }
}
```

**VSTest:**

```json
{
    "test": {
        "runner": "VSTest"
    }
}
```

> [!IMPORTANT]
> The `dotnet test` experience for MTP is only supported in `Microsoft.Testing.Platform` version 1.7 and later.

### Test runner documentation

The available command-line options, behavior, and capabilities differ depending on which test runner you use:

- **[dotnet test with VSTest](dotnet-test-vstest.md)** - The traditional test platform, available in .NET 6 SDK and later. This is the default and only test runner for .NET 6, .NET 7, .NET 8, and .NET 9. Provides comprehensive test discovery, filtering, and result reporting capabilities.

- **[dotnet test with MTP](dotnet-test-mtp.md)** - The modern testing platform, available in .NET 10 SDK and later. Offers faster test execution and more flexible test module selection.

> [!TIP]
> For conceptual documentation about `dotnet test`, see [Testing with dotnet test](../testing/unit-testing-with-dotnet-test.md).

## See also

- [Testing with dotnet test](../testing/unit-testing-with-dotnet-test.md)
- [dotnet test with VSTest](dotnet-test-vstest.md)
- [dotnet test with MTP](dotnet-test-mtp.md)
- [Frameworks and Targets](../../standard/frameworks.md)
- [.NET Runtime Identifier (RID) catalog](../rid-catalog.md)
