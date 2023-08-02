---
title: "Breaking change: Binding config to dictionary extends values"
description: Learn about the .NET 7 breaking change in .NET extensions where binding a configuration to a dictionary extends collection values instead of replacing the entire collection for a key.
ms.date: 08/02/2023
---
# Binding config to dictionary extends values

When binding a configuration using a <xref:System.Collections.Generic.Dictionary%602> object where the value is a mutable collection type, binding to the same key more than once now extends the values collection instead of replacing the whole collection with the new value.

## Version introduced

.NET 7

## Previous behavior

Consider the following code that binds a configuration that has a single key named `Key` to a dictionary multiple times.

```csharp
using Microsoft.Extensions.Configuration;

IConfiguration config = new ConfigurationBuilder()
    .AddInMemoryCollection()
    .Build();

config["Key:0"] = "NewValue";
var dict = new Dictionary<string, string[]>() { { "Key", new[] { "InitialValue" } } };

Console.WriteLine($"Initially: {String.Join(", ", dict["Key"])}");
config.Bind(dict);
Console.WriteLine($"Bind: {String.Join(", ", dict["Key"])}");
config.Bind(dict);
Console.WriteLine($"Bind again: {String.Join(", ", dict["Key"])}");
```

Prior to .NET 7, the value for `Key` was overwritten one each bind. The code produced the following output:

```output
Initially: InitialValue
Bind: NewValue
Bind again: NewValue
```

## New behavior

Starting in .NET 7, the dictionary value is extended each time the same key is bound, adding the new value but also keeping any existing values in the array. The same code from the [Previous behavior](#previous-behavior) section produces the following output:

```output
Initially: InitialValue
Bind: InitialValue, NewValue
Bind again: InitialValue, NewValue, NewValue
```

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

This change improves binding behavior by not overriding previously added values in dictionary value arrays.

## Recommended action

If the new behavior is not satisfactory, you can manually manipulate the values inside the array after binding.

## Affected APIs

- [ConfigurationBinder methods](xref:Microsoft.Extensions.Configuration.ConfigurationBinder#methods)
