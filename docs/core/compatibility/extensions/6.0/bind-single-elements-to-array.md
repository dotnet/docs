---
title: "Breaking change: Configuration binder binds single elements to an array"
description: Learn about the .NET 6.0 breaking change in .NET extensions where Microsoft.Extensions.Configuration binder will now bind a single element to an array.
ms.date: 09/08/2021
---
# Microsoft.Extensions.Configuration binder binds single elements to an array

Starting in .NET 6, the <xref:Microsoft.Extensions.Configuration?displayProperty=fullName> binder will bind single elements to an array.

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

The JSON configuration provider would bind that JSON to the following classes without any problem:

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

However, when binding the following XML in previous .NET versions, the XML configuration provider has no way of knowing that `TvShows` can contain multiple `Metadata` elements and that they are bound to an array.

```xml
<TvShow>
  <Metadata>
    <Name>Prison Break</Name>
  </Metadata>
</TvShow>
```

Thus, the binder fails to bind when a single element is provided. The key doesn't contain any index in the target array, which the binder expects when binding to an array, and the binder returns a `Metadata[]` array with a `null` object.

## New behavior

To support binding to array elements for the XML configuration provider, we changed the binder to account for keys without an index suffix&mdash;that is, there is a single child element.

This is a breaking change for other providers. For example, if you change the JSON shown in the [Previous behavior](#previous-behavior) section so that it does not specify an array, it will still bind to the previous class that contains an array of `Metadata` objects:

```json
{
   "tvshow": {
        "metadata": {
            "name": "PrisonBreak"
          }
    }
}
```

## Type of breaking change

This change can affect [source compatibility](../../categories.md#source-compatibility).

## Reason for change

This change was made to allow the XML configuration provider to bind a single element to an array. It was originally requested as an API addition to <xref:Microsoft.Extensions.Configuration.BinderOptions>. For more information, see [dotnet/runtime#57325]().

## Recommended action

If you want to switch back to the previous behavior where the JSON would need to specify an array to bind to an array, you can set the following app context switch:

```csharp
AppContext.SetSwitch("Microsoft.Extensions.Configuration.BindSingleElementsToArray", false);
```

## Affected APIs

- <xref:Microsoft.Extensions.Configuration.ConfigurationBinder.Bind(Microsoft.Extensions.Configuration.IConfiguration,System.Object,System.Action{Microsoft.Extensions.Configuration.BinderOptions})?displayProperty=fullName>
- <xref:Microsoft.Extensions.Configuration.ConfigurationBinder.Bind(Microsoft.Extensions.Configuration.IConfiguration,System.String,System.Object)?displayProperty=fullName>
- <xref:Microsoft.Extensions.Configuration.ConfigurationBinder.Bind(Microsoft.Extensions.Configuration.IConfiguration,System.Object)?displayProperty=fullName>
