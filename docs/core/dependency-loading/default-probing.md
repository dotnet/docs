---
title: Default probing - .NET Core
description: Overview of .NET Core's <xref:System.Runtime.Loader.AssemblyLoadContext.Default%2A?displayProperty=nameWithType> probing logic to locate dependencies.
ms.date: 08/09/2019
author: sdmaclea
ms.author: stmaclea
---
# Default probing

The <xref:System.Runtime.Loader.AssemblyLoadContext.Default%2A?displayProperty=nameWithType> instance is responsible for locating an assembly's dependencies. This article describes the <xref:System.Runtime.Loader.AssemblyLoadContext.Default%2A?displayProperty=nameWithType> instance's probing logic.

## Host configured probing properties

When the runtime is started, the runtime host provides a set of named probing properties that configure <xref:System.Runtime.Loader.AssemblyLoadContext.Default%2A?displayProperty=nameWithType> probe paths.

Each probing property is optional.  If present, each contains a ':' separated list of absolute paths.

|Property Name                 |Description  |
|------------------------------|---------|
|`TRUSTED_PLATFORM_ASSEMBLIES`   | List of platform and application assembly file paths. |
|`PLATFORM_RESOURCE_ROOTS`       | List of directory paths to search for satellite resource assemblies. |
|`NATIVE_DLL_SEARCH_DIRECTORIES` | List of directory paths to search for unmanaged (native) libraries.        |
|`APP_PATHS`                     | List of directory paths to search for managed assemblies |
|`APP_NI_PATHS`                  | List of directory paths to search for native images of managed assemblies. |

### How are the properties populated?

There are two main scenarios for populating the properties depending on whether the `<myapp>.deps.json` file exists.

- When the `*.deps.json` file is present, it's parsed to populate the probing properties.
- When the `*.deps.json` file isn't present, the application's directory is assumed to contain all the dependencies. The directory's contents are used to populate the probing properties.

Additionally the `*.deps.json` files for any referenced frameworks are similarly parsed.

### How do I see the probing properties from managed code?

Each property is available by calling the <xref:AppContext.GetData(string)?displayProperty=nameWithType> function with any Property Name from the table above.

### How to I debug the probing properties' construction?

The .NET Core runtime host will output useful trace messages when certain environment variables are enabled:

|Environment Variable        |Description  |
|----------------------------|---------|
|`COREHOST_TRACE=1`          |Enables tracing.|
|`COREHOST_TRACEFILE=<path>` |Traces to a file path instead of the default `stderr`.|
|`COREHOST_TRACE_VERBOSITY`  |Sets the verbosity from 1 lowest to 4 highest.|

## Managed assembly default probing

When probing to locate a managed assembly, the <xref:System.Runtime.Loader.AssemblyLoadContext.Default%2A?displayProperty=nameWithType> looks in order at:
- Files matching the <xref:System.Reflection.AssemblyName.Name?displayProperty=nameWithType> in `TRUSTED_PLATFORM_ASSEMBLIES` (after removing file extensions)
- Native image assembly files in `APP_NI_PATHS` with common file extensions
- Assembly files in `APP_PATHS` with common file extensions

## Satellite (resource) assembly probing

To find a satellite assembly for a specific culture, construct a set of file paths.

For each path in `PLATFORM_RESOURCE_ROOTS` and then `APP_PATHS`, append the <xref:System.Globalization.CultureInfo.Name?displayProperty=nameWithType> string, a directory separator, the <xref:System.Reflection.AssemblyName.Name?displayProperty=nameWithType> string, and the extension '.dll'.

If any matching file exists attempt to load and return it.

## Unmanaged (native) library probing

When probing to locate an unmanaged library, the `NATIVE_DLL_SEARCH_DIRECTORIES` are searched looking for a matching library,
