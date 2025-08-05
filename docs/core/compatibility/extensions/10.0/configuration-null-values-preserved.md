---
title: "Breaking change: Preserving null values in configuration"
description: "Learn about the breaking change in .NET 10 where configuration providers now preserve null values instead of treating them as missing values."
ms.date: 12/17/2024
ai-usage: ai-assisted
ms.custom: https://github.com/dotnet/docs/issues/46890
---

# Preserving null values in configuration

The .NET configuration binder now preserves null values in configuration instead of treating them as missing values. This change affects how the JSON configuration provider handles null values and how the configuration binder processes them during binding operations.

## Version introduced

.NET 10 Preview 7

## Previous behavior

Previously, when a configuration value was `null`, the binder treated it as if the value didn't exist at all, and therefore skipped the binding. The system didn't distinguish between `null` values and missing values.

Additionally, the JSON configuration provider converted `null` values in the configuration to empty strings. This caused properties bound to these values to receive an empty string rather than the expected `null`.

Consider the following configuration file `appsettings.json`:

```json
{
    "NullConfiguration": {
        "StringProperty": null,
        "IntProperty": null,
        "Array1": [null, null],
        "Array2": []
    }
}
```

And the corresponding binding code:

```csharp
public class NullConfiguration
{
    public NullConfiguration()
    {
        // Initialize with non-default value to ensure binding will override these values
        StringProperty = "Initial Value";
        IntProperty = 123;
    }
    public string? StringProperty { get; set; }
    public int? IntProperty { get; set; }
    public string[]? Array1 { get; set; }
    public string[]? Array2 { get; set; }
}

var configuration = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json")
                    .Build().GetSection("NullConfiguration");

// Now bind the configuration
NullConfiguration? result = configuration.Get<NullConfiguration>();

Console.WriteLine($"StringProperty: '{result!.StringProperty}', intProperty: {(result!.IntProperty.HasValue ? result!.IntProperty : "null")}");
Console.WriteLine($"Array1: {(result!.Array1 is null ? "null" : string.Join(", ", result!.Array1.Select(a => $"'{(a is null ? "null" : a)}'")))}");
Console.WriteLine($"Array2: {(result!.Array2 is null ? "null" : string.Join(", ", result!.Array2.Select(a => $"'{(a is null ? "null" : a)}'")))}");
```

Output:

```
StringProperty: '', intProperty: 123
Array1: '', ''
Array2: null
```

Explanation:
- `StringProperty`: The null value in the JSON was converted by the JSON provider into an empty string (""), overwriting the initial value.
- `IntProperty`: Remained unchanged (123) because the provider converted null to an empty string, which couldn't be parsed as an `int?`, so the original value was retained.
- `Array1`: Bound to an array containing two empty strings because each null array element was treated as an empty string.
- `Array2`: Remained null since an empty array `[]` in the JSON was ignored by the binder.

## New behavior

Null values in the configuration are now correctly honored. Running the same code sample produces the following results:

Using the JSON configuration provider:

```
StringProperty: 'null', intProperty: null
Array1: 'null', 'null'
Array2:
```

Null values are now properly bound to their corresponding properties, including array elements. Even empty arrays are correctly recognized and bound as empty arrays rather than being ignored.

## Type of breaking change

This is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

The previous behavior was confusing and frequently led to user complaints. By addressing this issue, the configuration binding process is now more intuitive and consistent, reducing confusion and aligning the behavior with user expectations.

## Recommended action

If you prefer the previous behavior, you can adjust your configuration accordingly:

- When using the **JSON configuration provider**, replace `null` values with empty strings (`""`) to restore the original behavior, where empty strings are bound instead of `null`.
- For other providers that support `null` values, simply **remove the `null` entries** from the configuration to replicate the earlier behavior, where missing values are ignored and existing property values remain unchanged.

## Affected APIs

- <xref:Microsoft.Extensions.Configuration.ConfigurationBinder.Get``1(Microsoft.Extensions.Configuration.IConfiguration)?displayProperty=fullName>
- <xref:Microsoft.Extensions.Configuration.ConfigurationBinder.Get``1(Microsoft.Extensions.Configuration.IConfiguration,System.Action{Microsoft.Extensions.Configuration.BinderOptions})?displayProperty=fullName>
- <xref:Microsoft.Extensions.Configuration.ConfigurationBinder.Get(Microsoft.Extensions.Configuration.IConfiguration,System.Type)?displayProperty=fullName>
- <xref:Microsoft.Extensions.Configuration.ConfigurationBinder.Get(Microsoft.Extensions.Configuration.IConfiguration,System.Type,System.Action{Microsoft.Extensions.Configuration.BinderOptions})?displayProperty=fullName>
- <xref:Microsoft.Extensions.Configuration.ConfigurationBinder.Bind(Microsoft.Extensions.Configuration.IConfiguration,System.Object)?displayProperty=fullName>
- <xref:Microsoft.Extensions.Configuration.ConfigurationBinder.Bind(Microsoft.Extensions.Configuration.IConfiguration,System.Object,System.Action{Microsoft.Extensions.Configuration.BinderOptions})?displayProperty=fullName>