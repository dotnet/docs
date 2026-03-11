---
title: "Breaking change: ConfigurationBinder silently skips invalid array elements"
description: "Learn about the breaking change in .NET 8 where ConfigurationBinder silently skips array or list elements that fail type conversion instead of preserving null placeholders."
ms.date: 03/11/2026
ai-usage: ai-assisted
---

# ConfigurationBinder silently skips invalid array elements

Starting in .NET 8, <xref:Microsoft.Extensions.Configuration.ConfigurationBinder> silently skips array and list elements whose values can't be converted to the target type. Previously, failed elements were preserved as `null` placeholders, and the resulting collection retained the same length as the number of elements in the configuration source.

## Version introduced

.NET 8

## Previous behavior

Previously, when binding an array or list property via <xref:Microsoft.Extensions.Configuration.ConfigurationBinder.Get%60%601(Microsoft.Extensions.Configuration.IConfiguration)> or <xref:Microsoft.Extensions.Configuration.ConfigurationBinder.Bind(Microsoft.Extensions.Configuration.IConfiguration,System.Object)>, if an element's value couldn't be converted to the target type, that element was preserved as a `null` placeholder in the result. The collection length matched the number of elements in the configuration.

```csharp
// Configuration source, for example, appsettings.json:
// "Items": [
//   { "Name": "A", "Interval": 10 },
//   { "Name": "B", "Interval": "a" }   <-- invalid int
// ]

var settings = configuration.GetSection("Items").Get<MyItem[]>();

// .NET 6/7 result:
// settings.Length == 2
// settings[0] = { Name = "A", Interval = 10 }
// settings[1] = null   (conversion failed, placeholder preserved)
```

## New behavior

Starting in .NET 8, elements that fail type conversion are silently skipped. The resulting collection contains only successfully bound elements and has a shorter length than the number of entries in the configuration source.

```csharp
var settings = configuration.GetSection("Items").Get<MyItem[]>();

// .NET 8+ result:
// settings.Length == 1
// settings[0] = { Name = "A", Interval = 10 }
// settings[1] is gone entirely -- no null placeholder
```

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

The internal implementation of <xref:Microsoft.Extensions.Configuration.ConfigurationBinder> was refactored in .NET 8. Instead of pre-allocating the target array and binding elements in-place (which left `null` on conversion failure), the binder now collects only successfully bound elements into a temporary list before materializing the final array.

The previous behavior was also problematic for value types such as `int[]`. For an invalid configuration value, the binder would store `0`, which was indistinguishable from a legitimate value of `0`. The new behavior avoids this ambiguity.

## Recommended action

- **Enable `ErrorOnUnknownConfiguration` during development** to surface invalid configuration values immediately rather than silently dropping elements:

  ```csharp
  var settings = configuration.GetSection("Items").Get<MyItem[]>(options =>
      options.ErrorOnUnknownConfiguration = true);
  ```

  Starting in .NET 8, this option also causes <xref:Microsoft.Extensions.Configuration.ConfigurationBinder> to throw an <xref:System.InvalidOperationException> when a value can't be converted to the target type. For more information, see [ConfigurationBinder throws for mismatched value](configurationbinder-exceptions.md).

- **Fix invalid configuration values.** Ensure all values in your configuration source match the expected types for the bound model.

- **Validate collection lengths** after binding if your code depends on the number of elements matching the configuration source.

- **Use string properties with manual parsing** if you need to gracefully handle unconvertible values and preserve all array entries.

## Affected APIs

- <xref:Microsoft.Extensions.Configuration.ConfigurationBinder.Get%60%601(Microsoft.Extensions.Configuration.IConfiguration)?displayProperty=fullName>
- <xref:Microsoft.Extensions.Configuration.ConfigurationBinder.Get%60%601(Microsoft.Extensions.Configuration.IConfiguration,System.Action{Microsoft.Extensions.Configuration.BinderOptions})?displayProperty=fullName>
- <xref:Microsoft.Extensions.Configuration.ConfigurationBinder.Bind(Microsoft.Extensions.Configuration.IConfiguration,System.Object)?displayProperty=fullName>
- <xref:Microsoft.Extensions.Configuration.ConfigurationBinder.Bind(Microsoft.Extensions.Configuration.IConfiguration,System.Object,System.Action{Microsoft.Extensions.Configuration.BinderOptions})?displayProperty=fullName>
