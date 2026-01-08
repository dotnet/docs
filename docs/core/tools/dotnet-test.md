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

### Choosing a test runner

To enable Microsoft.Testing.Platform, you need to specify the test runner in the [`global.json`](global-json.md) file:

```json
{
    "test": {
        "runner": "Microsoft.Testing.Platform"
    }
}
```

> [!NOTE]
> "VSTest" is a valid value for test runner as well. However, it's already the current default and is not necessary to set explicitly.
>
> [!IMPORTANT]
> The `dotnet test` experience for MTP is only supported in `Microsoft.Testing.Platform` version 1.7 and later.

### Test runner documentation

The available command-line options, behavior, and capabilities differ depending on which test runner you use:

- **[dotnet test with VSTest](dotnet-test-vstest.md)** - The traditional test platform, available in .NET 6 SDK and later. Provides comprehensive test discovery, filtering, and result reporting capabilities.

- **[dotnet test with MTP](dotnet-test-mtp.md)** - The modern testing platform, available in .NET 10 SDK and later. Offers faster test execution and more flexible test module selection.

> [!TIP]
> For conceptual documentation about `dotnet test`, see [Testing with dotnet test](../testing/unit-testing-with-dotnet-test.md).

## See also

- [Testing with dotnet test](../testing/unit-testing-with-dotnet-test.md)
- [dotnet test with VSTest](dotnet-test-vstest.md)
- [dotnet test with MTP](dotnet-test-mtp.md)
- [Frameworks and Targets](../../standard/frameworks.md)
- [.NET Runtime Identifier (RID) catalog](../rid-catalog.md)
