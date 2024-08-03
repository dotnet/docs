---
title: .NET-related GitHub Actions
description: Learn about the available .NET-related GitHub Actions.
ms.date: 07/29/2024
---
# .NET-related GitHub Actions

This article lists some of the first party .NET GitHub actions that are hosted on the [dotnet GitHub organization](https://github.com/dotnet).

> [!NOTE]
> This article is a work-in-progress, and might not list all the available .NET GitHub Actions.

## .NET version sweeper

[dotnet/versionsweeper](https://github.com/dotnet/versionsweeper)

This action sweeps .NET repos for out-of-support target versions of .NET.

The .NET docs team uses the .NET version sweeper GitHub Action to automate issue creation. The Action runs on a schedule (as a cron job). When it detects that .NET projects target out-of-support versions, it creates issues to report its findings. The output is configurable and helpful for tracking .NET version support concerns.

The Action is available on [GitHub Marketplace](https://github.com/marketplace/actions/net-version-sweeper).
