---
title: Microsoft.Testing.Platform extensions
description: Learn about the various Microsoft.Testing.Platform extensions and how to use them.
author: nohwnd
ms.author: jajares
ms.date: 12/15/2023
ms.topic: article
---

# Microsoft.Testing.Platform extensions

Microsoft.Testing.Platform can be customized through extensions. These extension are either built-in or can be installed as NuGet packages. Extensions installed through NuGet packages will auto-register the extensions they are holding to become available in test execution.

Each and every extension is shipped with its own licensing model (some less permissive), be sure to refer to the license associated with the extensions you want to use.

## Extensions

**[Code Coverage](./microsoft-testing-platform-extensions-code-coverage.md)**

Extensions designed to provide code coverage support.

**[Diagnostics](./microsoft-testing-platform-extensions-diagnostics.md)**

Extensions offering diagnostics and troubleshooting functionalities.

**[Hosting](./microsoft-testing-platform-extensions-hosting.md)**

Extensions affecting how the test execution is hosted.

**[Policy](./microsoft-testing-platform-extensions-policy.md)**

Extensions allowing to define policies around the test execution.

**[Test Reports](./microsoft-testing-platform-extensions-test-reports.md)**

Extensions allowing to produce test report files that contains information about the execution and outcome of the tests.

**[VSTest Bridge](./microsoft-testing-platform-extensions-vstest-bridge.md)**

This extension provides a compatibility layer with VSTest allowing the test frameworks depending on it to continue supporting running in VSTest mode (`vstest.console.exe`, usual `dotnet test`, `VSTest task` on AzDo, Test Explorers of Visual Studio and Visual Studio Code...).

**[Microsoft Fakes](./microsoft-testing-platform-extensions-fakes.md)**

This extension provides support to execute a test project that makes use of `Microsoft Fakes`.
