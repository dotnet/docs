---
title: "Breaking change: configProperties in .runtimeconfig.dev.json override .runtimeconfig.json"
description: "Learn about the breaking change in .NET 11 where configProperties in .runtimeconfig.dev.json override matching configProperties in .runtimeconfig.json."
ms.date: 07/05/2026
ai-usage: ai-assisted
---

# configProperties in .runtimeconfig.dev.json override .runtimeconfig.json

If an app defines the same runtime `configProperties` key in both `.runtimeconfig.json` and `.runtimeconfig.dev.json`, the `.runtimeconfig.dev.json` value takes precedence.

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

To support development-time overrides in .NET 11, `.runtimeconfig.dev.json` takes precedence over `.runtimeconfig.json` for duplicate `configProperties` keys.

Using the same example, the runtime now uses `System.GC.Concurrent: false`.

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

This change enables developers to override production settings during development without modifying production configuration files.

For more information, see [dotnet/runtime#126606](https://github.com/dotnet/runtime/issues/126606).

## Recommended action

For predictable production behavior, only place development-time overrides in `.runtimeconfig.dev.json`.

To prevent a development-time override, remove the duplicate key from `.runtimeconfig.dev.json`.

## Affected APIs

None.

## See also

- [.NET runtime configuration settings](../../../runtime-config/index.md)
