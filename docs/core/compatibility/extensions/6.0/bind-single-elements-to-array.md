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

Consider the following JSON snippet and C# class definitions:

```json
{
   "tvshow": {
        "metadata": {
            "name": "PrisonBreak"
          }
    }
}
```

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

The JSON configuration provider would not bind that JSON because it does not specify an array. The JSON would need to appear as follows in order to bind:

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

In addition, when binding the following XML in previous .NET versions, the XML configuration provider has no way of knowing that `TvShows` can contain multiple `Metadata` elements and that they are bound to an array. Thus, the binder fails to bind when a single element is provided. The key doesn't contain any index in the target array, which the binder expects when binding to an array, and the binder returns a `Metadata[]` array with a `null` object.

```xml
<TvShow>
  <Metadata>
    <Name>Prison Break</Name>
  </Metadata>
</TvShow>
```

## New behavior

To support binding to array elements for the XML configuration provider, we changed the binder to account for keys without an index suffix&mdash;that is, there is a single child element. Now, the following XML will bind to the previous classes and the `Metadata` property will not be `null`.

```xml
<TvShow>
  <Metadata>
    <Name>Prison Break</Name>
  </Metadata>
</TvShow>
```

This is a breaking change for other providers. For example, even if the JSON does not specify an array, it will still bind to the previous class that contains an array of `Metadata` objects:

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

This change was made to allow the XML configuration provider to bind a single element to an array. It was originally requested as an API addition to <xref:Microsoft.Extensions.Configuration.BinderOptions>. For more information, see [dotnet/runtime#57325](https://github.com/dotnet/runtime/issues/57325).

## Recommended action

If you want to switch back to the previous behavior where the JSON would need to specify an array to bind to an array, you can set the following app context switch:

```csharp
AppContext.SetSwitch("Microsoft.Extensions.Configuration.BindSingleElementsToArray", false);
```

## Affected APIs

- <xref:Microsoft.Extensions.Configuration.ConfigurationBinder.Bind(Microsoft.Extensions.Configuration.IConfiguration,System.Object,System.Action{Microsoft.Extensions.Configuration.BinderOptions})?displayProperty=fullName>
- <xref:Microsoft.Extensions.Configuration.ConfigurationBinder.Bind(Microsoft.Extensions.Configuration.IConfiguration,System.String,System.Object)?displayProperty=fullName>
- <xref:Microsoft.Extensions.Configuration.ConfigurationBinder.Bind(Microsoft.Extensions.Configuration.IConfiguration,System.Object)?displayProperty=fullName>
