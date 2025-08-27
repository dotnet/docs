---
title: "Breaking change: NuGet packages may not be included in deps.json files if no runtime assets were included from the package"
description: "Learn about the breaking change in .NET 10 where NuGet packages that don't contribute runtime assets may be excluded from deps.json files."
ms.date: 08/27/2025
ai-usage: ai-assisted
ms.custom: https://github.com/dotnet/docs/issues/48132
---
# NuGet packages may not be included in deps.json files if no runtime assets were included from the package

NuGet packages or other libraries may now be excluded from the deps.json file if they don't contribute any runtime assets and removing them wouldn't cause dependency resolution issues.

## Version introduced

.NET 10 Preview 5

## Previous behavior

Previously, all referenced NuGet packages and projects would be included in the deps.json file as library entries, even if there were no assets used from them.

## New behavior

NuGet packages or other libraries may be excluded from the deps.json file if:

- They don't contribute any runtime assets
- Removing the library from the deps.json would not cause any libraries which do contribute runtime assets to no longer have a dependency path to them.

## Type of breaking change

This change can affect [source compatibility](../../categories.md#source-compatibility).

## Reason for change

The deps.json file lists runtime dependencies and is used by the loader to load those dependencies. Some other tools also process the deps.json file. Including libraries that are not actually used is less accurate and can lead to false positives for security scanners that use the deps.json file if the file lists dependencies that are not actually used.

## Recommended action

To disable the new behavior, set the `TrimDepsJsonLibrariesWithoutAssets` MSBuild property to `false`:

```xml
<PropertyGroup>
  <TrimDepsJsonLibrariesWithoutAssets>false</TrimDepsJsonLibrariesWithoutAssets>
</PropertyGroup>
```

## Affected APIs

None.
