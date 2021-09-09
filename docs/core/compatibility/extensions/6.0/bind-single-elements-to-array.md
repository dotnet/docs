---
title: "Breaking change: Configuration binder binds single elements to an array"
description: Learn about the .NET 6.0 breaking change in .NET extensions where Microsoft.Extensions.Configuration binder will now bind a single element to an array.
ms.date: 09/08/2021
---
# Microsoft.Extensions.Configuration binder binds single elements to an array




## Version introduced

6.0 RC 1

## Previous behavior

Consider the following JSON snippet:

```json
{
   "tvshow": {
        "metadata": [
            {
               "name": "PrisonBreak"
            }
         ]
    }
}
```

In previous .NET versions, the JSON configuration provider would bind that JSON to the following classes without any problem:

```csharp
public class TvShow
{
  public Metadata[] Metadata { get; set; }
}

public class Metadata
{
  public string Name { get; set; }
}
```

However, when binding the following XML to the same classes, the XML configuration provider has no way of knowing that `TvShows` can contain multiple `Metadata` elements and that they are bound to an array.

```xml
<TvShow>
  <Metadata>
    <Name>Prison Break</Name>
  </Metadata>
</TvShow>
```

Thus, the binder fails to bind when a single element is provided. The key doesn't contain any index in the target array, which the binder expects when binding to an array, and the binder returns a `Metadata[]` array with a `null` object.

## New behavior



## Type of breaking change

This change can affect [source compatibility](../../categories.md#source-compatibility).

## Reason for change



## Recommended action



## Affected APIs

- <xref:Microsoft.Extensions.Configuration.ConfigurationBinder.Bind(Microsoft.Extensions.Configuration.IConfiguration,System.Object,System.Action{Microsoft.Extensions.Configuration.BinderOptions})?displayProperty=fullName>
- <xref:Microsoft.Extensions.Configuration.ConfigurationBinder.Bind(Microsoft.Extensions.Configuration.IConfiguration,System.String,System.Object)?displayProperty=fullName>
- <xref:Microsoft.Extensions.Configuration.ConfigurationBinder.Bind(Microsoft.Extensions.Configuration.IConfiguration,System.Object)?displayProperty=fullName>
