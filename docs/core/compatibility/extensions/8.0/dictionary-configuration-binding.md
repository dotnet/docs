---
title: "Breaking change: Empty keys added to dictionary by configuration binder"
description: Learn about the .NET 8 breaking change in .NET extensions where empty keys are now added to dictionary types by the configuration binder.
ms.date: 07/27/2023
---
# Empty keys added to dictionary by configuration binder

In previous versions, when configuration was bound to a dictionary type, any keys without corresponding values in the configuration were skipped and weren't added to the dictionary. The behavior has changed such that those keys are no longer skipped but instead automatically created with their default values. This change ensures that all keys listed in the configuration will be present within the dictionary.

## Version introduced

.NET 8 Preview 5

## Previous behavior

Previously, empty keys in the configuration were skipped when bound to a dictionary type. Consider the following configuration string and binding code.

```csharp
var json = @"{
    ""Queues"": {
        ""q1"": {
            ""V"": 1
        },
        ""q2"": {
            ""V"": 2
        },
        ""q3"": {
        }
    }
}";
```

```csharp
public class Q
{
    public Dictionary<string, QueueValue> Queues { get; set; } = new();
}

public class QueueValue
{
    public int V { get; set; }
}

var configuration = new ConfigurationBuilder()
    .AddJsonStream(StringToStream(json))
    .Build();

Q options = new Q();
configuration.Bind(options);
foreach (var kvp in options.Queues)
{
    Console.WriteLine($"{kvp.Key}: {kvp.Value.V}");
}
```

Previously, you'd see the following output (notice that key `q3` is missing):

```output
q1: 1
q2: 2
```

## New behavior

Starting in .NET 8, empty configuration keys are added to the dictionary with their default value during configuration binding.

Consider the code from the [previous behavior](#previous-behavior) section, which now outputs the following text showing that `q3` was added to the dictionary with its default value:

```output
q1: 1
q2: 2
q3: 0
```

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

This user-requested change ensures that all keys listed in the configuration are present within the dictionary. Having all keys present streamlines the process and avoids potential issues with missing keys.

## Recommended action

Verify and adapt your application logic to accommodate the presence of the newly created dictionary entries with empty values. If the new behavior is undesirable, remove empty-value entries from the configuration. By eliminating these entries, no dictionary entries with empty values will be added during the binding process.

## Affected APIs

- <xref:Microsoft.Extensions.Configuration.ConfigurationBinder?displayProperty=fullName>
- [IConfigurationRoot extension methods](xref:Microsoft.Extensions.Configuration.IConfigurationRoot#extension-methods)
- <xref:Microsoft.Extensions.DependencyInjection.OptionsConfigurationServiceCollectionExtensions?displayProperty=fullName>
