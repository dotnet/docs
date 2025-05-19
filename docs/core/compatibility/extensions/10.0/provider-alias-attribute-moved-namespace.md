---
title: "Breaking change: ProviderAliasAttribute moved to Microsoft.Extensions.Logging.Abstractions"
description: Learn about the breaking change in .NET 10 where the ProviderAliasAttribute class moved from Microsoft.Extensions.Logging to Microsoft.Extensions.Logging.Abstractions.
ms.date: 05/16/2024
---

# ProviderAliasAttribute moved to Microsoft.Extensions.Logging.Abstractions

## Change description

In previous versions of .NET, `ProviderAliasAttribute` was defined in the `Microsoft.Extensions.Logging` assembly. Starting in .NET 10, this attribute has been moved to the `Microsoft.Extensions.Logging.Abstractions` assembly.

## Version introduced

.NET 10 Preview 4

## Type of breaking change

This change is [source-incompatible](../../categories.md#source-incompatible).

## Reason for change

This change allows applications that depend on `Microsoft.Extensions.Logging.Abstractions` and use `ProviderAliasAttribute` to avoid taking a dependency on the full `Microsoft.Extensions.Logging` package.

## Recommended action

In most scenarios, no action is required. The type is [type-forwarded](../../../../standard/assembly/type-forwarding.md) from `Microsoft.Extensions.Logging` to `Microsoft.Extensions.Logging.Abstractions`, allowing existing code to continue working without modification.

The only potential breaking scenario occurs when your project references an older version of `Microsoft.Extensions.Logging` alongside the .NET 10 version of `Microsoft.Extensions.Logging.Abstractions`. In this situation, a compilation error may occur due to `ProviderAliasAttribute` being defined in both assemblies.

If you encounter this issue, update your reference to `Microsoft.Extensions.Logging` to the .NET 10 version.

For code that explicitly references `ProviderAliasAttribute`, you can update your using directives from:

```csharp
using Microsoft.Extensions.Logging;
```

To:

```csharp
using Microsoft.Extensions.Logging.Abstractions;
```

Alternatively, if you need your code to be compatible with both pre-.NET 10 and .NET 10, you can use conditional compilation:

```csharp
#if NET10_0_OR_GREATER
using Microsoft.Extensions.Logging.Abstractions;
#else
using Microsoft.Extensions.Logging;
#endif
```

## Affected APIs

- `Microsoft.Extensions.Logging.ProviderAliasAttribute`