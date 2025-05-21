---
title: "Breaking change: Environment variable prefixes"
description: Learn about the .NET 7 breaking change in .NET extensions where the comparison of normalized prefixes and environment variables has changed.
ms.date: 10/12/2022
ms.topic: concept-article
---
# Environment variable prefixes

[Hierarchical data](../../../extensions/configuration.md#binding-hierarchies) is represented using `:` as the level delimiter. However, for environmental variables, the `:` character is normalized to `__`, because the latter is supported on all platforms. This change affects how normalized and non-normalized prefixes and keys are compared. Specifically, you can now add environment variables by specifying a prefix containing either `:` or `__` as the delimiter. Either syntax will match any environment variables with a matching prefix followed by either a `:` or `__`. Some environment variables that theoretically didn't match the filter previously may now match the filter.

## Version introduced

.NET 7 Preview 4

## Previous behavior

Previously, the following code printed `False`:

```csharp
using Microsoft.Extensions.Configuration;

const string myValue = "value1";
Environment.SetEnvironmentVariable("MY_PREFIX__ConfigKey", myValue);

IConfiguration config = new ConfigurationBuilder()
    .AddEnvironmentVariables(prefix: "MY_PREFIX__")
    .Build();

var loadedValue = config.GetValue<string?>("ConfigKey", null);

Console.WriteLine(String.Equals(myValue, loadedValue));
// False
```

In order for the `MY_PREFIX__ConfigKey` environment variable to be added to the configuration, you had to add environment variables using a delimiter of `:` instead of `__`:

```csharp
using Microsoft.Extensions.Configuration;

const string myValue = "value1";
Environment.SetEnvironmentVariable("MY_PREFIX__ConfigKey", myValue);

IConfiguration config = new ConfigurationBuilder()
    .AddEnvironmentVariables(prefix: "MY_PREFIX:")
    .Build();

var loadedValue = config.GetValue<string?>("ConfigKey", null);

Console.WriteLine(String.Equals(myValue, loadedValue));
// True
```

## New behavior

Starting in .NET 7, the following code prints `True`:

```csharp
using Microsoft.Extensions.Configuration;

const string myValue = "value1";
Environment.SetEnvironmentVariable("MY_PREFIX__ConfigKey", myValue);

IConfiguration config = new ConfigurationBuilder()
    .AddEnvironmentVariables(prefix: "MY_PREFIX__")
    .Build();

var loadedValue = config.GetValue<string?>("ConfigKey", null);

Console.WriteLine(String.Equals(myValue, loadedValue));
// True
```

## Type of breaking change

This change can affect [binary compatibility](../../categories.md#binary-compatibility).

## Reason for change

This change was made to fix an unintentional behavior change for normalizing environment variable prefix filters in .NET 6. The new behavior matches the .NET 5 behavior.

## Recommended action

Most developers won't be affected by this change, since it corrects previously erroneous behavior. In the unlikely case that you relied on the fact that a prefix containing `__` didn't match an environment variable containing `__`, consider changing the prefixes of those variables.

## Affected APIs

- <xref:Microsoft.Extensions.Configuration.EnvironmentVariablesExtensions.AddEnvironmentVariables(Microsoft.Extensions.Configuration.IConfigurationBuilder,System.String)?displayProperty=fullName>

## See also

- [Configuration in .NET](../../../extensions/configuration.md)
