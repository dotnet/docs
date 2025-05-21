---
title: Default probing - .NET Core
description: Overview of .NET Core's System.Runtime.Loader.AssemblyLoadContext.Default probing logic to locate dependencies.
ms.date: 08/09/2019
author: sdmaclea
ms.topic: article
---
# Default probing

The <xref:System.Runtime.Loader.AssemblyLoadContext.Default%2A?displayProperty=nameWithType> instance is responsible for locating an assembly's dependencies. This article describes the <xref:System.Runtime.Loader.AssemblyLoadContext.Default%2A?displayProperty=nameWithType> instance's probing logic.

## Host configured probing properties

When the runtime is started, the runtime host provides a set of named probing properties that configure <xref:System.Runtime.Loader.AssemblyLoadContext.Default%2A?displayProperty=nameWithType> probe paths.

Each probing property is optional. If present, each property is a string value that contains a delimited list of absolute paths. The delimiter is ';' on Windows and ':' on all other platforms.

|Property Name                 |Description  |
|------------------------------|---------|
|`TRUSTED_PLATFORM_ASSEMBLIES`   | List of platform and application assembly file paths. |
|`PLATFORM_RESOURCE_ROOTS`       | List of directory paths to search for satellite resource assemblies. |
|`NATIVE_DLL_SEARCH_DIRECTORIES` | List of directory paths to search for unmanaged (native) libraries.        |
|`APP_PATHS`                     | List of directory paths to search for managed assemblies. |

### How are the properties populated?

There are two main scenarios for populating the properties depending on whether the *\<myapp>.deps.json* file exists.

- When the *\*.deps.json* file is present, it's parsed to populate the probing properties.
- When the *\*.deps.json* file isn't present, the application's directory is assumed to contain all the dependencies. The directory's contents are used to populate the probing properties.

Additionally, the *\*.deps.json* files for any referenced frameworks are similarly parsed.

The environment variable `DOTNET_ADDITIONAL_DEPS` can be used to add additional dependencies.  `dotnet.exe` also contains an optional `--additional-deps` parameter to set this value on application startup.

The `APP_PATHS` property is not populated by default and is omitted for most applications.

The list of all *\*.deps.json* files used by the application can be accessed via `System.AppContext.GetData("APP_CONTEXT_DEPS_FILES")`.

### How do I see the probing properties from managed code?

Each property is available by calling the <xref:System.AppContext.GetData(System.String)?displayProperty=nameWithType> function with the property name from the table above.

### How do I debug the probing properties' construction?

The .NET Core runtime host will output useful trace messages when certain environment variables are enabled:

|Environment Variable        |Description  |
|----------------------------|---------|
|`COREHOST_TRACE=1`          |Enables tracing.|
|`COREHOST_TRACEFILE=<path>` |Traces to a file path instead of the default `stderr`.|
|`COREHOST_TRACE_VERBOSITY`  |Sets the verbosity from 1 (lowest) to 4 (highest).|

## Managed assembly default probing

When probing to locate a managed assembly, the <xref:System.Runtime.Loader.AssemblyLoadContext.Default%2A?displayProperty=nameWithType> looks in order at:

- Files matching the <xref:System.Reflection.AssemblyName.Name?displayProperty=nameWithType> in `TRUSTED_PLATFORM_ASSEMBLIES` (after removing file extensions).
- Assembly files in `APP_PATHS` with common file extensions.

## Satellite (resource) assembly probing

To find a satellite assembly for a specific culture, construct a set of file paths.

For each path in `PLATFORM_RESOURCE_ROOTS` and then `APP_PATHS`, append the <xref:System.Globalization.CultureInfo.Name?displayProperty=nameWithType> string, a directory separator, the <xref:System.Reflection.AssemblyName.Name?displayProperty=nameWithType> string, and the extension '.dll'.

If any matching file exists, attempt to load and return it.

## Unmanaged (native) library probing

The runtime's unmanaged library probing algorithm is identical on all platforms. However, since the actual load of the unmanaged library is performed by the underlying platform, the observed behavior can be slightly different.

1) Check if the supplied library name represents an absolute or relative path.

1) If the name represents an absolute path, use the name directly for all subsequent operations. Otherwise, use the name and create platform-defined combinations to consider. Combinations consist of platform specific prefixes (for example, `lib`) and/or suffixes (for example, `.dll`, `.dylib`, and `.so`). This is not an exhaustive list, and it doesn't represent the exact effort made on each platform. It's just an example of what is considered.  For more information, see [native library loading](../../standard/native-interop/native-library-loading.md).

1) The name and, if the path is relative, each combination, is then used in the following steps. The first successful load attempt immediately returns the handle to the loaded library.

    - Append it to each path supplied in the `NATIVE_DLL_SEARCH_DIRECTORIES` property and attempt to load.

    - If <xref:System.Runtime.InteropServices.DefaultDllImportSearchPathsAttribute> is either not defined on the calling assembly or p/invoke or is defined and includes `DllImportSearchPath.AssemblyDirectory`, append the name or combination to the calling assembly's directory and attempt to load.

    - Use it directly to load the library.

1) Indicate that the library failed to load.
