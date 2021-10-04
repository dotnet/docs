---
title: .NET-related GitHub Actions
description: Learn about the available .NET-related GitHub Actions.
ms.topic: reference
ms.date: 09/17/2021
---
# .NET-related GitHub Actions

This article lists some of the first party .NET GitHub actions that are hosted on the [dotnet GitHub organization](https://github.com/dotnet).

> [!NOTE]
> This article is a work-in-progress, and may not list all the available .NET GitHub Actions.

## .NET version sweeper

[dotnet/versionsweeper](https://github.com/dotnet/versionsweeper)

This action sweeps .NET repos for out-of-support target versions of .NET.

The .NET docs team uses the .NET version sweeper GitHub Action to automate issue creation. The Action runs on a schedule (as a cron job). When it detects that .NET projects target out-of-support versions, it creates issues to report its findings. The output is configurable and helpful for tracking .NET version support concerns.

The Action is available on [GitHub Marketplace](https://github.com/marketplace/actions/net-version-sweeper).

## .NET code analysis

[dotnet/code-analysis](https://github.com/dotnet/code-analysis)

This action runs the code analysis rules that are included in the .NET SDK as part of continuous integration (CI). The action runs both [code-quality (CAXXXX) rules](../fundamentals/code-analysis/quality-rules/index.md) and [code-style (IDEXXXX) rules](../fundamentals/code-analysis/style-rules/index.md). Consider using this GitHub Action in the following scenarios:

- You only want to see compiler diagnostics when you compile locally, but you still want to catch code analysis issues in a separate phase.
- You want to improve compile-time performance by offloading expensive analyzers, such as the dataflow analysis-based security analyzers, to the CI phase.
- You want to run the default .NET SDK code analyzers when you compile locally, but you want to run an extended set of code analyzers in the CI phase.

You can configure the action in various ways, including whether you want violations to break the CI build. For more information, see the [README file](https://github.com/dotnet/code-analysis/blob/main/README.md). For more information about .NET code analysis, see [Overview of .NET code analysis](../fundamentals/code-analysis/overview.md).
