---
title: "Breaking change: ConfigurationBinder throws for mismatched value"
description: Learn about the .NET 8 breaking change in .NET extensions where ConfigurationBinder throws an exception if ErrorOnUnknownConfiguration is true and a config value doesn't match the model value.
ms.date: 01/27/2023
ms.topic: concept-article
---
# ConfigurationBinder throws for mismatched value

Previously, <xref:Microsoft.Extensions.Configuration.BinderOptions.ErrorOnUnknownConfiguration?displayProperty=nameWithType> was used solely to raise an exception if a value existed in the configuration but not in the model being bound to. Now, if this property is set to `true`, an exception is also thrown if the value in the configuration can't be converted to the type of value in the model.

## Version introduced

.NET 8 Preview 1

## Previous behavior

Previously, the following code silently swallowed the exceptions for the fields that contained invalid enums:

```csharp
public enum TestSettingsEnum
{
    Option1,
    Option2,
}

public class MyModelContainingArray
{
    public TestSettingsEnum[] Enums { get; set; }
}

public void SilentlySwallowsInvalidItems()
{
    var dictionary = new Dictionary<string, string>
    {
        ["Section:Enums:0"] = "Option1",
        ["Section:Enums:1"] = "Option3", // invalid - ignored
        ["Section:Enums:2"] = "Option4", // invalid - ignored
        ["Section:Enums:3"] = "Option2",
    };

    var configurationBuilder = new ConfigurationBuilder();
    configurationBuilder.AddInMemoryCollection(dictionary);
    var config = configurationBuilder.Build();
    var configSection = config.GetSection("Section");

    var model = configSection.Get<MyModelContainingArray>(o => o.ErrorOnUnknownConfiguration = true);

    // Only Option1 and Option2 are in the bound collection at this point.
}
```

## New behavior

Starting in .NET 8, if a configuration value can't be converted to the type of the value in the model, an <xref:System.InvalidOperationException> is thrown.

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

The previous behavior was confusing for some developers. They set <xref:Microsoft.Extensions.Configuration.BinderOptions.ErrorOnUnknownConfiguration?displayProperty=nameWithType> to `true` and expected an exception to be thrown if *any* issue was encountered when the configuration was bound.

## Recommended action

If your app has configuration values that can't be converted to the properties in the bound model, change or remove the values.

Alternatively, set <xref:Microsoft.Extensions.Configuration.BinderOptions.ErrorOnUnknownConfiguration?displayProperty=nameWithType> to `false`.

## Affected APIs

- <xref:Microsoft.Extensions.Configuration.ConfigurationBinder.Bind(Microsoft.Extensions.Configuration.IConfiguration,System.Object,System.Action{Microsoft.Extensions.Configuration.BinderOptions})?displayProperty=fullName>
- <xref:Microsoft.Extensions.Configuration.ConfigurationBinder.Get%60%601(Microsoft.Extensions.Configuration.IConfiguration,System.Action{Microsoft.Extensions.Configuration.BinderOptions})?displayProperty=fullName>
- <xref:Microsoft.Extensions.Configuration.ConfigurationBinder.Get(Microsoft.Extensions.Configuration.IConfiguration,System.Type,System.Action{Microsoft.Extensions.Configuration.BinderOptions})?displayProperty=fullName>
