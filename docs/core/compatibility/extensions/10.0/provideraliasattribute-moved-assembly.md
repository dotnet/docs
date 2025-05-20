---
title: "Breaking change: ProviderAliasAttribute moved to Microsoft.Extensions.Logging.Abstractions assembly"
description: Learn about the breaking change in .NET 10 where the ProviderAliasAttribute class moved from the Microsoft.Extensions.Logging assembly to the Microsoft.Extensions.Logging.Abstractions assembly.
ms.date: 05/19/2025
---

# ProviderAliasAttribute moved to Microsoft.Extensions.Logging.Abstractions

In previous versions of .NET, <xref:Microsoft.Extensions.Logging.ProviderAliasAttribute> was defined in the `Microsoft.Extensions.Logging` assembly. Starting in .NET 10, this attribute has been moved to the `Microsoft.Extensions.Logging.Abstractions` assembly.

## Version introduced

.NET 10 Preview 4

## Type of breaking change

This change can affect [source compatibility](../../categories.md#source-incompatible).

## Reason for change

This change allows applications that depend on [Microsoft.Extensions.Logging.Abstractions](https://www.nuget.org/packages/Microsoft.Extensions.Logging.Abstractions) and that use <xref:Microsoft.Extensions.Logging.ProviderAliasAttribute> to avoid taking a dependency on the full [Microsoft.Extensions.Logging package](https://www.nuget.org/packages/Microsoft.Extensions.Logging).

## Recommended action

In most scenarios, no action is required. The type is [type-forwarded](../../../../standard/assembly/type-forwarding.md) from `Microsoft.Extensions.Logging` to `Microsoft.Extensions.Logging.Abstractions`, which allows existing code to continue to work without modification.

The only potential breaking scenario occurs when your project references an older version of `Microsoft.Extensions.Logging` alongside the .NET 10 version of `Microsoft.Extensions.Logging.Abstractions`. In this situation, a compilation error might occur due to <xref:Microsoft.Extensions.Logging.ProviderAliasAttribute> being defined in both assemblies.

## Affected APIs

- <xref:Microsoft.Extensions.Logging.ProviderAliasAttribute?displayProperty=fullName> 
