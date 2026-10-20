---
title: "Breaking change: Empty strings in chained configuration override earlier providers"
description: "Learn about the breaking change in .NET 11 RC 1 where an empty string in a chained configuration overrides earlier providers."
ms.date: 10/20/2026
ai-usage: ai-assisted
---

# Empty strings in chained configuration override earlier providers

Starting in .NET 11 RC 1, a configuration added by using `AddConfiguration` treats an empty string as a present value. The empty string therefore overrides values from providers registered earlier in the outer configuration instead of allowing those earlier values to remain effective.

This change continues the distinction between empty and `null` configuration values established in .NET 10 by [Null values preserved in configuration](../10.0/configuration-null-values-preserved.md). The handling of `null` by chained configuration is unchanged.

## Version introduced

.NET 11 RC 1

## Previous behavior

`ChainedConfigurationProvider.TryGet` reported an empty string as not found. Consequently, an empty value in a chained configuration did not override a value supplied by an earlier provider:

```csharp
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

IConfiguration inner = new ConfigurationBuilder()
    .AddInMemoryCollection(new Dictionary<string, string?>
    {
        ["Endpoint"] = "",
    })
    .Build();

IConfiguration configuration = new ConfigurationBuilder()
    .AddInMemoryCollection(new Dictionary<string, string?>
    {
        ["Endpoint"] = "https://example.com",
    })
    .AddConfiguration(inner)
    .Build();

Console.WriteLine($"Endpoint: '{configuration["Endpoint"]}'");
```

Before .NET 11 RC 1, the output was:

```text
Endpoint: 'https://example.com'
```

When there was no earlier value, reading the key returned `null`, and a section whose only value was the chained empty string was considered not to exist.

## New behavior

Starting in .NET 11 RC 1, `ChainedConfigurationProvider.TryGet` reports an empty string as found. With the preceding example, the empty value from `inner` overrides the earlier value, and the output is:

```text
Endpoint: ''
```

A section whose value is an empty string is now considered to exist. Binding also observes the empty value instead of an earlier provider's value. For example, binding an empty string over an earlier numeric value to an integer property throws `InvalidOperationException`, consistently with an empty value supplied by a directly added provider.

A `null` value in the wrapped `IConfiguration` continues to be treated as absent, because the `IConfiguration` indexer cannot distinguish a key whose value is `null` from a missing key.

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

An empty string is a valid configuration value. Treating it as missing made chained configuration inconsistent with directly added configuration providers and prevented applications from intentionally clearing or disabling a setting by overriding it with an empty string. The new behavior preserves the configuration provider's distinction between an empty value and an absent value. For more information, see [dotnet/runtime#131480](https://github.com/dotnet/runtime/pull/131480).

## Recommended action

If an empty string is intended to override an earlier value, no action is required.

If an application relied on an empty string in a chained configuration allowing an earlier provider's value to win, remove that key from the chained configuration or represent it as missing or `null`. Applications that bind chained values to non-string types should also validate or normalise empty values before binding if an empty value is not valid for the target type. There is no compatibility switch to restore the previous behavior.

## Affected APIs

- `Microsoft.Extensions.Configuration.ChainedConfigurationProvider.TryGet(string, out string?)`
- `Microsoft.Extensions.Configuration.ChainedBuilderExtensions.AddConfiguration(IConfigurationBuilder, IConfiguration)`
- `Microsoft.Extensions.Configuration.ChainedConfigurationSource.Build(IConfigurationBuilder)`
