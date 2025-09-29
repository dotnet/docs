---
title: "Breaking change: New warning introduced in dotnet list package command"
description: "Learn about the breaking change in .NET 8 where dotnet list package --vulnerable emits a warning when audit sources don't support the VulnerabilityInfoResource."
ms.date: 01/18/2025
ai-usage: ai-assisted
ms.custom: https://github.com/dotnet/docs/issues/42608
---
# New warning introduced in dotnet list package command

When using `dotnet list package --vulnerable`, if a configured `auditsources` does not support the `VulnerabilityInfoResource`, a warning is now shown to inform the user that the source does not provide vulnerability data.

## Version introduced

.NET 8

## Previous behavior

The command would silently skip `auditsource`s that lacked vulnerability information, because the command did not use `auditsources` as a source of vulnerability data.

## New behavior

The command now emits a warning:
**`Audit source '{0}' did not provide any vulnerability data.`**
This helps users understand why certain sources may not influence the reported vulnerabilities.

## Type of breaking change

This is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

This warning came as part of the work to allow customers to use `auditsources` when running the `dotnet list package` command. The warning helps users understand when configured audit sources are not providing the expected vulnerability information.

## Recommended action

Check the specified `auditsources` to ensure it supports the `VulnerabilityInfoResource`. If it doesn't, either update the source or replace it with one that provides vulnerability data.

## Affected APIs

None.
