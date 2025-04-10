---
title: "Breaking change - .NET CLI `--interactive` defaults to `true` in user scenarios"
description: "Learn about the breaking change in .NET 10 Preview 3 where the --interactive flag defaults to true in user-centric scenarios."
ms.date: 4/3/2025
ai-usage: ai-assisted
ms.custom: https://github.com/dotnet/docs/issues/45548
---

# .NET CLI `--interactive` defaults to `true` in user scenarios

The `--interactive` flag for the .NET CLI now defaults to `true` in user-centric scenarios. The behavior remains unchanged for CI/CD environments.

## Version introduced

.NET 10 Preview 3

## Previous behavior

The `--interactive` flag always defaulted to `false` unless explicitly specified by the user.

```bash
dotnet restore --interactive
# Required explicitly to enable interactivity
```

## New behavior

The `--interactive` flag defaults to `true` in user-centric scenarios, such as when commands are run directly by a user. In CI/CD environments or when the process output stream is redirected, the flag defaults to `false`.

```bash
dotnet restore
# Interactivity is enabled by default in user-centric scenarios
```

## Type of breaking change

This is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

This change improves the user experience by:

- Simplifying NuGet authentication, addressing a common pain point.
- Providing a unified signal for enabling future CLI interactivity features.

## Recommended action

No action is required for most users. To explicitly disable interactivity, pass the `--interactive false` flag:

```bash
dotnet restore --interactive false
```

## Affected APIs

None.
