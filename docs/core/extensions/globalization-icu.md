---
description: "Learn more about: .NET globalization and ICU"
title: "Globalization and ICU"
ms.date: 03/13/2023
helpviewer_keywords:
  - "globalization [.NET], about globalization"
  - "global applications, globalization"
  - "international applications [.NET], globalization"
  - "world-ready applications, globalization"
  - "application development [.NET], globalization"
  - "culture, globalization"
  - "icu, icu on windows, ms-icu"
ms.topic: article
---

# .NET globalization and ICU

Before .NET 5, the .NET globalization APIs used different underlying libraries on different platforms. On Unix, the APIs used [International Components for Unicode (ICU)](https://icu.unicode.org/), and on Windows, they used [National Language Support (NLS)](/windows/win32/intl/national-language-support). This resulted in some behavioral differences in a handful of globalization APIs when running applications on different platforms. Behavior differences were evident in these areas:

- Cultures and culture data
- String casing
- String sorting and searching
- Sort keys
- String normalization
- Internationalized Domain Names (IDN) support
- Time zone display name on Linux

Starting with .NET 5, developers have more control over which underlying library is used, enabling applications to avoid differences across platforms.

> [!NOTE]
> The culture data that drives the behavior of the ICU library is usually maintained by the [Common Locale Data Repository (CLDR)](https://cldr.unicode.org/), not the runtime.

## ICU on Windows

Windows now incorporates a preinstalled [icu.dll](/windows/win32/intl/international-components-for-unicode--icu-) version as part of its features that's automatically employed for globalization tasks. This modification allows .NET to use this ICU library for its globalization support. In cases where the ICU library is unavailable or can't be loaded, as is the case with older Windows versions, .NET 5 and subsequent versions revert to using the NLS-based implementation.

The following table shows which versions of .NET are capable of loading the ICU library across different Windows client and server versions:

| .NET version     | Windows version                         |
|------------------|-----------------------------------------|
| .NET 5 or .NET 6 | Windows client 10 version 1903 or later |
| .NET 5 or .NET 6 | Windows Server 2022 or later            |
| .NET 7 or later  | Windows client 10 version 1703 or later |
| .NET 7 or later  | Windows Server 2019 or later            |

> [!NOTE]
> .NET 7 and later versions have the capability to load ICU on older Windows versions, in contrast to .NET 6 and .NET 5.

> [!NOTE]
> Even when using ICU, the `CurrentCulture`, `CurrentUICulture`, and `CurrentRegion` members still use Windows operating system APIs to honor user settings.

### Behavioral differences

If you upgrade your app to target .NET 5 or later, you might see changes in your app even if you don't realize you're using globalization facilities. The following section lists some behavioral changes you might experience.

#### String sorting and `System.Globalization.CompareOptions`

`CompareOptions` is the options enumeration which can be passed to `String.Compare` to influence how two strings are compared.

Comparing strings for equality and determining their sort order differs between NLS and ICU. In particular:

- The default string sort order is different, so this will be apparent even if you don't use `CompareOptions` directly. When using ICU, the `None` default option performs the same as `StringSort`. `StringSort` sorts non-alphanumeric characters before alphanumeric ones (so "bill's" sorts before "bills", for example). To restore the previous `None` functionality, you must use the NLS-based implementation.
- The default handling of ligature characters differs. Under NLS, ligatures and their non-ligature counterparts (for example, "oeuf" and "œuf") are considered equal, but this isn't the case with ICU in .NET. This is because of a different collation strength between the two implementations. To restore the NLS behavior when using ICU, use the `CompareOptions.IgnoreNonSpace` value.

#### String.IndexOf

Consider the following code that calls <xref:System.String.IndexOf(System.String)?displayProperty=nameWithType> to find the index of the null character `\0` in a string.

```csharp
const string greeting = "Hel\0lo";
Console.WriteLine($"{greeting.IndexOf("\0")}");
Console.WriteLine($"{greeting.IndexOf("\0", StringComparison.CurrentCulture)}");
Console.WriteLine($"{greeting.IndexOf("\0", StringComparison.Ordinal)}");
```

- In .NET Core 3.1 and earlier versions on Windows, the snippet prints `3` on each of the three lines.
- For .NET 5 and later versions running on the Windows versions listed in the [ICU on Windows](#icu-on-windows) section table, the snippet prints `0`, `0`, and `3` (for the ordinal search).

By default, <xref:System.String.IndexOf(System.String)?displayProperty=nameWithType> performs a culture-aware linguistic search. ICU considers the null character `\0` to be a *zero-weight character*, and thus the character isn't found in the string when using a linguistic search on .NET 5 and later. However, NLS doesn't consider the null character `\0` to be a zero-weight character, and a linguistic search on .NET Core 3.1 and earlier locates the character at position 3. An ordinal search finds the character at position 3 on all .NET versions.

You can run code analysis rules [CA1307: Specify StringComparison for clarity](../../fundamentals/code-analysis/quality-rules/ca1307.md) and [CA1309: Use ordinal StringComparison](../../fundamentals/code-analysis/quality-rules/ca1309.md) to find call sites in your code where the string comparison isn't specified or it isn't ordinal.

For more information, see [Behavior changes when comparing strings on .NET 5+](../../standard/base-types/string-comparison-net-5-plus.md).

#### String.EndsWith

```csharp
const string foo = "abc";

Console.WriteLine(foo.EndsWith("\0"));
Console.WriteLine(foo.EndsWith("c"));
Console.WriteLine(foo.EndsWith("\0", StringComparison.CurrentCulture));
Console.WriteLine(foo.EndsWith("\0", StringComparison.Ordinal));
Console.WriteLine(foo.EndsWith('\0'));
```

> [!IMPORTANT]
> In .NET 5+ running on Windows versions listed in the [ICU on Windows](#icu-on-windows) table, the preceding snippet prints:
>
> ```Output
> True
> True
> True
> False
> False
> ```

To avoid this behavior, use the `char` parameter overload or `StringComparison.Ordinal`.

#### String.StartsWith

```csharp
const string foo = "abc";

Console.WriteLine(foo.StartsWith("\0"));
Console.WriteLine(foo.StartsWith("a"));
Console.WriteLine(foo.StartsWith("\0", StringComparison.CurrentCulture));
Console.WriteLine(foo.StartsWith("\0", StringComparison.Ordinal));
Console.WriteLine(foo.StartsWith('\0'));
```

> [!IMPORTANT]
> In .NET 5+ running on Windows versions listed in the [ICU on Windows](#icu-on-windows) table, the preceding snippet prints:
>
> ```Output
> True
> True
> True
> False
> False
> ```

To avoid this behavior, use the `char` parameter overload or `StringComparison.Ordinal`.

#### TimeZoneInfo.FindSystemTimeZoneById

ICU provides the flexibility to create <xref:System.TimeZoneInfo> instances using [IANA](https://www.iana.org/time-zones) time zone IDs, even when the application is running on Windows. Similarly, you can create <xref:System.TimeZoneInfo> instances with Windows time zone IDs, even when running on non-Windows platforms. However, it's important to note that this functionality isn't available when using [NLS mode](#use-nls-instead-of-icu) or [globalization invariant mode](https://github.com/dotnet/runtime/blob/main/docs/design/features/globalization-invariant-mode.md).

#### Day-of-week abbreviations

The <xref:System.Globalization.DateTimeFormatInfo.GetShortestDayName(System.DayOfWeek)?displayProperty=nameWithType> method obtains the shortest abbreviated day name for a specified day of the week.

- In .NET Core 3.1 and earlier versions on Windows, these day-of-week abbreviations consisted of two characters, for example, "Su".
- In .NET 5 and later versions, these day-of-week abbreviations consist of only one character, for example, "S".

#### ICU-dependent APIs

.NET introduced APIs that are dependent on ICU. These APIs can succeed only when using ICU. Here are some examples:

- <xref:System.TimeZoneInfo.TryConvertIanaIdToWindowsId(System.String,System.String@)>
- <xref:System.TimeZoneInfo.TryConvertWindowsIdToIanaId%2A>

On the Windows versions listed in the [ICU on Windows](#icu-on-windows) section table, the mentioned APIs succeed. However, on older versions of Windows, these APIs fail. In such cases, you can enable the [app-local ICU](#app-local-icu) feature to ensure the success of these APIs. On non-Windows platforms, these APIs always succeed regardless of the version.

In addition, it's crucial for apps to ensure that they're not running in [globalization invariant mode](https://github.com/dotnet/runtime/blob/main/docs/design/features/globalization-invariant-mode.md) or [NLS mode](#use-nls-instead-of-icu) to guarantee the success of these APIs.

### Use NLS instead of ICU

Using ICU instead of NLS might result in behavioral differences with some globalization-related operations. To revert back to using NLS, you can opt out of the ICU implementation. Applications can enable NLS mode in any of the following ways:

- In the project file:

  ```xml
  <ItemGroup>
    <RuntimeHostConfigurationOption Include="System.Globalization.UseNls" Value="true" />
  </ItemGroup>
  ```

- In the `runtimeconfig.json` file:

  ```json
  {
    "runtimeOptions": {
       "configProperties": {
         "System.Globalization.UseNls": true
        }
    }
  }
  ```

- By setting the environment variable `DOTNET_SYSTEM_GLOBALIZATION_USENLS` to the value `true` or `1`.

> [!NOTE]
> A value set in the project or in the `runtimeconfig.json` file takes precedence over the environment variable.

For more information, see [Runtime config settings](../../core/runtime-config/globalization.md#nls).

### Determine if your app is using ICU

The following code snippet can help you determine if your app is running with ICU libraries (and not NLS).

```csharp
public static bool ICUMode()
{
    SortVersion sortVersion = CultureInfo.InvariantCulture.CompareInfo.Version;
    byte[] bytes = sortVersion.SortId.ToByteArray();
    int version = bytes[3] << 24 | bytes[2] << 16 | bytes[1] << 8 | bytes[0];
    return version != 0 && version == sortVersion.FullVersion;
}
```

To determine the version of .NET, use <xref:System.Runtime.InteropServices.RuntimeInformation.FrameworkDescription?displayProperty=nameWithType>.

## App-local ICU

Each release of ICU might bring with it bug fixes and updated Common Locale Data Repository (CLDR) data that describes the world's languages. Moving between versions of ICU can subtly impact app behavior when it comes to globalization-related operations. To help application developers ensure consistency across all deployments, .NET 5 and later versions enable apps on both Windows and Unix to carry and use their own copy of ICU.

Applications can opt in to an app-local ICU implementation mode in one of the following ways:

- In the project file, set the appropriate `RuntimeHostConfigurationOption` value:

  ```xml
  <ItemGroup>
    <RuntimeHostConfigurationOption Include="System.Globalization.AppLocalIcu" Value="<suffix>:<version> or <version>" />
  </ItemGroup>
  ```

- Or in the _runtimeconfig.json_ file, set the appropriate `runtimeOptions.configProperties` value:

  ```json
  {
    "runtimeOptions": {
       "configProperties": {
         "System.Globalization.AppLocalIcu": "<suffix>:<version> or <version>"
       }
    }
  }
  ```

- Or by setting the environment variable `DOTNET_SYSTEM_GLOBALIZATION_APPLOCALICU` to the value `<suffix>:<version>` or `<version>`.

  `<suffix>`: Optional suffix of fewer than 36 characters in length, following the public ICU packaging conventions. When building a custom ICU, you can customize it to produce the lib names and exported symbol names to contain a suffix, for example, `libicuucmyapp`, where `myapp` is the suffix.

  `<version>`: A valid ICU version, for example, 67.1. This version is used to load the binaries and to get the exported symbols.

When either of these options is set, you can add a [Microsoft.ICU.ICU4C.Runtime](https://www.nuget.org/packages/Microsoft.ICU.ICU4C.Runtime) `PackageReference` to your project that corresponds to the configured `version` and that's all that is needed.

Alternatively, to load ICU when the app-local switch is set, .NET uses the <xref:System.Runtime.InteropServices.NativeLibrary.TryLoad%2A?displayProperty=nameWithType> method, which probes multiple paths. The method first tries to find the library in the `NATIVE_DLL_SEARCH_DIRECTORIES` property, which is created by the dotnet host based on the `deps.json` file for the app. For more information, see [Default probing](../../core/dependency-loading/default-probing.md).

For self-contained apps, no special action is required by the user, other than making sure ICU is in the app directory (for self-contained apps, the working directory defaults to `NATIVE_DLL_SEARCH_DIRECTORIES`).

If you're consuming ICU via a NuGet package, this works in framework-dependent applications. NuGet resolves the native assets and includes them in the `deps.json` file and in the output directory for the application under the `runtimes` directory. .NET loads it from there.

For framework-dependent apps (not self-contained) where ICU is consumed from a local build, you must take additional steps. The .NET SDK doesn't yet have a feature for "loose" native binaries to be incorporated into `deps.json` (see [this SDK issue](https://github.com/dotnet/sdk/issues/11373)). Instead, you can enable this by adding additional information into the application's project file. For example:

```xml
<ItemGroup>
  <IcuAssemblies Include="icu\*.so*" />
  <RuntimeTargetsCopyLocalItems Include="@(IcuAssemblies)" AssetType="native" CopyLocal="true"
    DestinationSubDirectory="runtimes/linux-x64/native/" DestinationSubPath="%(FileName)%(Extension)"
    RuntimeIdentifier="linux-x64" NuGetPackageId="System.Private.Runtime.UnicodeData" />
</ItemGroup>
```

This must be done for all the ICU binaries for the supported runtimes. Also, the `NuGetPackageId` metadata in the `RuntimeTargetsCopyLocalItems` item group needs to match a NuGet package that the project actually references.

## Load specific ICU version on Linux

By default, when using ICU on Linux, .NET attempts to load the latest installed version of ICU from the system. However, you can specify a specific version of ICU to load by setting the `DOTNET_ICU_VERSION_OVERRIDE` environment variable.

For example, if the environment variable is set to a specific version number, such as `67.1`, .NET attempts to load that version of ICU. For example, .NET looks for the libraries `libicuuc.so.67.1` and `libicui18n.so.67.1`.

> [!NOTE]
> This environment variable is supported only on .NET builds provided by Microsoft and is not supported on builds supplied by Linux distributions.
> For .NET versions earlier than .NET 10, the environment variable is called `CLR_ICU_VERSION_OVERRIDE`.

If the specified version isn't found, .NET falls back to loading the highest installed ICU version from the system.

This configuration provides flexibility in controlling ICU version usage, ensuring compatibility with application-specific or system-provided ICU versions.

## macOS behavior

macOS has a different behavior for resolving dependent dynamic libraries from the load commands specified in the `Mach-O` file than the Linux loader. In the Linux loader, .NET can try `libicudata`, `libicuuc`, and `libicui18n` (in that order) to satisfy ICU dependency graph. However, on macOS, this doesn't work. When building ICU on macOS, you, by default, get a dynamic library with these load commands in `libicuuc`. The following snippet shows an example.

```sh
~/ % otool -L /Users/santifdezm/repos/icu-build/icu/install/lib/libicuuc.67.1.dylib
/Users/santifdezm/repos/icu-build/icu/install/lib/libicuuc.67.1.dylib:
 libicuuc.67.dylib (compatibility version 67.0.0, current version 67.1.0)
 libicudata.67.dylib (compatibility version 67.0.0, current version 67.1.0)
 /usr/lib/libSystem.B.dylib (compatibility version 1.0.0, current version 1281.100.1)
 /usr/lib/libc++.1.dylib (compatibility version 1.0.0, current version 902.1.0)
```

These commands just reference the name of the dependent libraries for the other components of ICU. The loader performs the search following the `dlopen` conventions, which involves having these libraries in the system directories or setting the `LD_LIBRARY_PATH` env vars, or having ICU at the app-level directory. If you can't set `LD_LIBRARY_PATH` or ensure that ICU binaries are at the app-level directory, you'll need to do some extra work.

There are some directives for the loader, like `@loader_path`, which tell the loader to search for that dependency in the same directory as the binary with that load command. There are two ways to achieve this:

- `install_name_tool -change`

  Run the following commands:

  ```bash
  install_name_tool -change "libicudata.67.dylib" "@loader_path/libicudata.67.dylib" /path/to/libicuuc.67.1.dylib
  install_name_tool -change "libicudata.67.dylib" "@loader_path/libicudata.67.dylib" /path/to/libicui18n.67.1.dylib
  install_name_tool -change "libicuuc.67.dylib" "@loader_path/libicuuc.67.dylib" /path/to/libicui18n.67.1.dylib
  ```

- Patch ICU to produce the install names with `@loader_path`

  Before running autoconf (`./runConfigureICU`), change [these lines](https://github.com/unicode-org/icu/blob/ef91cc3673d69a5e00407cda94f39fcda3131451/icu4c/source/config/mh-darwin#L32-L37) to:

  ```
  LD_SONAME = -Wl,-compatibility_version -Wl,$(SO_TARGET_VERSION_MAJOR) -Wl,-current_version -Wl,$(SO_TARGET_VERSION) -install_name @loader_path/$(notdir $(MIDDLE_SO_TARGET))
  ```

## ICU on WebAssembly

A version of ICU is available that's specifically for WebAssembly workloads. This version provides globalization compatibility with desktop profiles. To reduce the ICU data file size from 24 MB to 1.4 MB (or ~0.3 MB if compressed with Brotli), this workload has a handful of limitations.

The following APIs are not supported:

- <xref:System.Globalization.CultureInfo.EnglishName?displayProperty=nameWithType>
- <xref:System.Globalization.CultureInfo.NativeName?displayProperty=nameWithType>
- <xref:System.Globalization.DateTimeFormatInfo.NativeCalendarName?displayProperty=nameWithType>
- <xref:System.Globalization.RegionInfo.NativeName?displayProperty=nameWithType>

The following APIs are supported with limitations:

- <xref:System.String.Normalize(System.Text.NormalizationForm)?displayProperty=nameWithType> and <xref:System.String.IsNormalized(System.Text.NormalizationForm)?displayProperty=nameWithType> don't support the rarely used <xref:System.Text.NormalizationForm.FormKC> and <xref:System.Text.NormalizationForm.FormKD> forms.
- <xref:System.Globalization.RegionInfo.CurrencyNativeName?displayProperty=nameWithType> returns the same value as <xref:System.Globalization.RegionInfo.CurrencyEnglishName?displayProperty=nameWithType>.

In addition, fewer locales are supported. The supported list can be found in the [dotnet/icu repo](https://github.com/dotnet/icu/blob/dotnet/main/icu-filters/icudt_wasm.json#L7-L195).

## Globalization setup in .NET apps

.NET globalization initialization is a complex process that involves loading the appropriate globalization library, setting up the culture data, and configuring the globalization settings. The following sections describe how globalization initialization works on different platforms.

### Windows

On Windows, .NET follow the following steps to initialize globalization:

- Check whether [Globalization Invariant Mode](https://github.com/dotnet/runtime/blob/main/docs/design/features/globalization-invariant-mode.md) is enabled. When this mode is active, .NET bypasses loading the ICU library and avoids using NLS APIs. Instead, it relies on built-in invariant culture data, ensuring that behavior remains fully independent of the operating system and the ICU library.

- Check whether [NLS mode](#use-nls-instead-of-icu) is enabled. If enabled, .NET will skip loading the ICU library and instead rely on Windows [NLS](/windows/win32/intl/national-language-support) APIs for globalization support.

- Check whether the [app-local ICU](#app-local-icu) feature is enabled. If it is, .NET will attempt to load the ICU library from the application directory by appending the specified version to the library names. For instance, if the version is 72.1, .NET will first try to load `icuuc72.dll`, `icuin72.dll`, and `icudt72.dll`. If these libraries cannot be loaded, it will then attempt to load `icuuc72.1.dll`, `icuin72.1.dll`, and `icudt72.1.dll`. If none of the libraries are found, the process will terminate with an error message such as: `Failed to load app-local ICU: {library name}`.

- If none of the preceding conditions are satisfied, .NET attempts to load the ICU library from the system directory. It first tries to load `icu.dll`. If this library is unavailable, it then attempts to load `icuuc.dll` and `icuin.dll` from the system directory. If any of these libraries aren't found, the runtime falls back to using NLS APIs for globalization support.

> [!NOTE]
> NLS APIs are always available in all Windows versions, so .NET can always fall back on them for globalization support.

### Linux

- Check whether [Globalization Invariant Mode](https://github.com/dotnet/runtime/blob/main/docs/design/features/globalization-invariant-mode.md) is enabled. When this mode is active, .NET bypasses loading the ICU library. Instead, it relies on built-in invariant culture data, ensuring that behavior remains fully independent of the operating system and the ICU library.
- Check whether the [app-local ICU](#app-local-icu) feature is enabled. If it is, .NET will attempt to load the ICU library from the application directory by appending the specified version to the library names. For instance, if the version is 68.2.0.9, .NET will try to load `libicuuc.so.68.2.0.9` and `libicui18n.so.68.2.0.9`. If none of the libraries are found, the process will terminate with an error message such as: `Failed to load app-local ICU: {library name}`.
- Check if the `DOTNET_ICU_VERSION_OVERRIDE` environment variable is set. If it is, .NET will attempt to load the specified version of ICU as described in [Load specific ICU version on Linux](#load-specific-icu-version-on-linux).
- If none of the preceding conditions are satisfied, .NET attempts to load the highest installed version of the ICU library from the system. It tries to load the libraries `libicuuc.so.[version]` and `libicui18n.so.[version]`, where `[version]` is the highest installed version of ICU on the system. If the libraries aren't found, the process terminates with an error message such as: `Failed to load system ICU: {library name}`.

### macOS

- Check whether [Globalization Invariant Mode](https://github.com/dotnet/runtime/blob/main/docs/design/features/globalization-invariant-mode.md) is enabled. When this mode is active, .NET bypasses loading the ICU library. Instead, it relies on built-in invariant culture data, ensuring that behavior remains fully independent of the operating system and the ICU library.
- Check whether the [app-local ICU](#app-local-icu) feature is enabled. If it is, .NET will attempt to load the ICU library from the application directory by appending the specified version to the library names. For instance, if the version is 68.2.0.9, .NET will try to load `libicuuc68.2.0.9.dylib` and `libicui18n68.2.0.9.dylib`. If none of the libraries are found, the process terminates with an error message such as: `Failed to load app-local ICU: {library name}`.
- If none of the preceding conditions are satisfied, .NET will attempt to load the installed version of the ICU library as described in [macOS behavior](#macos-behavior).
