---
title: "Breaking change: 'dotnet list package' warns if source doesn't provide vulnerability data"
description: "Learn about the breaking change in .NET 8 where 'dotnet list package --vulnerable' emits a warning when audit sources don't support VulnerabilityInfoResource."
ms.date: 09/29/2025
ai-usage: ai-assisted
ms.custom: https://github.com/dotnet/docs/issues/42608
---
# 'dotnet list package' warns if source doesn't provide vulnerability data

When using `dotnet list package --vulnerable`, if a configured `auditsources` doesn't support `VulnerabilityInfoResource`, a warning is now shown to inform the user that the source doesn't provide vulnerability data.

## Version introduced

.NET 8

## Previous behavior

Previously, the command silently skipped `auditsource` sources that lacked vulnerability information.

## New behavior

Starting in .NET 8, the command emits a warning:

> Audit source '{0}' did not provide any vulnerability data.

This warning helps users understand why certain sources might not influence the reported vulnerabilities.

## Type of breaking change

This is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

This warning came as part of the work to allow customers to use `auditsources` when running the `dotnet list package` command. The warning helps users understand when configured audit sources don't provide the expected vulnerability information.

## Recommended action

Check the specified `auditsources` to ensure it supports `VulnerabilityInfoResource`. If it doesn't, either update the source or replace it with one that provides vulnerability data.

## Affected APIs

None.
