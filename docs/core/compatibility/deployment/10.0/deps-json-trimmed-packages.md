---
title: "Breaking change: NuGet packages with no runtime assets aren't included in deps.json"
description: "Learn about the breaking change in .NET 10 where NuGet packages that don't contribute runtime assets might be excluded from deps.json files."
ms.date: 08/27/2025
ai-usage: ai-assisted
ms.custom: https://github.com/dotnet/docs/issues/48132
---
# NuGet packages with no runtime assets aren't included in deps.json

NuGet packages or other libraries that don't contribute any runtime assets are now excluded from the deps.json file if removing them wouldn't cause dependency resolution issues.

## Version introduced

.NET 10 Preview 5

## Previous behavior

Previously, all referenced NuGet packages and projects were included in the deps.json file as library entries, even if there were no assets used from them.

## New behavior

NuGet packages or other libraries might be excluded from the deps.json file if:

- They don't contribute any runtime assets.
- Removing the library from the deps.json would not cause any libraries that do contribute runtime assets to no longer have a dependency path to them.

## Type of breaking change

This change can affect [source compatibility](../../categories.md#source-compatibility).

## Reason for change

The deps.json file lists runtime dependencies and is used by the loader to load those dependencies. Some other tools also process the deps.json file. Including libraries that aren't actually used is less accurate and can lead to false positives for security scanners that use the deps.json file.

## Recommended action

To disable the new behavior, set the `TrimDepsJsonLibrariesWithoutAssets` MSBuild property to `false`:

```xml
<PropertyGroup>
  <TrimDepsJsonLibrariesWithoutAssets>false</TrimDepsJsonLibrariesWithoutAssets>
</PropertyGroup>
```

## Affected APIs

None.
