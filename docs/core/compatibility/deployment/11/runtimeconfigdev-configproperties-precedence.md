---
title: "Breaking change: configProperties in .runtimeconfig.dev.json override .runtimeconfig.json"
description: "Learn about the breaking change in .NET 11 where configProperties in .runtimeconfig.dev.json override matching configProperties in .runtimeconfig.json."
ms.date: 07/05/2026
ai-usage: ai-assisted
---

# configProperties in .runtimeconfig.dev.json override .runtimeconfig.json

If an app defines the same runtime `configProperties` key in both `.runtimeconfig.json` and `.runtimeconfig.dev.json`, the `.runtimeconfig.dev.json` value now wins.

## Version introduced

.NET 11 Preview 6

## Previous behavior

Previously, `.runtimeconfig.json` took precedence over `.runtimeconfig.dev.json` for duplicate `configProperties` keys.

For example:

```json
// app.runtimeconfig.json
{
  "runtimeOptions": {
    "configProperties": {
      "System.GC.Concurrent": true
    }
  }
}
```

```json
// app.runtimeconfig.dev.json
{
  "runtimeOptions": {
    "configProperties": {
      "System.GC.Concurrent": false
    }
  }
}
```

With this configuration, the runtime used `System.GC.Concurrent: true`.

## New behavior

Starting in .NET 11, `.runtimeconfig.dev.json` takes precedence over `.runtimeconfig.json` for duplicate `configProperties` keys.

Using the same example, the runtime now uses `System.GC.Concurrent: false`.

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

To support development-time overrides, `.runtimeconfig.dev.json` now overrides matching values in `.runtimeconfig.json`.

For more information, see [dotnet/runtime issue #126606](https://github.com/dotnet/runtime/issues/126606).

## Recommended action

To keep production behavior predictable, only put development-time overrides in `.runtimeconfig.dev.json`.

If you don't want an override at development time, remove the duplicate key from `.runtimeconfig.dev.json`.

## Affected APIs

None.

## See also

- [.NET runtime configuration settings](../../../runtime-config/index.md)
