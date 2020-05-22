---
title: "Globalization and ICU"
ms.date: "05/21/2020"
ms.technology: dotnet-standard
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "globalization [.NET Framework], about globalization"
  - "global applications, globalization"
  - "international applications [.NET Framework], globalization"
  - "world-ready applications, globalization"
  - "application development [.NET Framework], globalization"
  - "culture, globalization"
  - "icu, icu on windows, ms-icu"
ms.assetid: 4e919934-6b19-42f2-b770-275a4fae87c9
---

# .NET Globalization and ICU

In the past, the .NET globalization APIs have used different underlying libraries on different platforms.  On Unix, it used [International Components for Unicode (ICU)](http://site.icu-project.org/home), and on Windows, it used [National Language Support (NLS)](https://docs.microsoft.com/en-us/windows/win32/intl/national-language-support). This resulted in some behavioral differences in a handful of globalization APIs when running applications on different platforms, in particular affecting:

- Cultures and culture data
- String casing
- String sorting and searching
- Sort keys
- String Normalization
- Internationalized Domain Names (IDN) support
- Time Zone display name on Linux

Starting with .NET 5, developers have more control over the underlying library utilized, enabling applications to avoid such differences across platforms.

## ICU on Windows

Windows 10 May 2019 Update and later versions include [icu.dll](https://docs.microsoft.com/en-us/windows/win32/intl/international-components-for-unicode--icu-) as part of the OS, and .NET 5 now uses that by default. When running on Windows, .NET 5 tries to load `icu.dll` and uses it for the globalization implementation if it's available.  If that library can't be found or loaded, such as when running on older versions of Windows, .NET 5 will fall back to NLS-based implementation.

*Note: Even when using ICU, the `CurrentCulture`, `CurrentUICulture`, and `CurrentRegion` members still use Windows OS APIs to honor user settings.*

### Using NLS instead of ICU

Using ICU instead of NLS may result in behavioral differences with some globalization-related operations. To revert back to using NLS, a developer can opt-out of the ICU implementation. Applications can enable NLS mode by either of the following:

1. In the project file:

```xml
<ItemGroup>
  <RuntimeHostConfigurationOption Include="System.Globalization.UseNls" Value="true" />
</ItemGroup>
```

2. In the `runtimeconfig.json` file:

```json
{
  "runtimeOptions": {
     "configProperties": {
       "System.Globalization.UseNls": true
      }
  }
}
```

3. Setting the environment variable `DOTNET_SYSTEM_GLOBALIZATION_USENLS` to the value `true` or `1` (without quotes).

*Note: A value set in the project or in the `runtimeconfig.json` file takes precedence over the environment variable.*

## App-local ICU

Each release of ICU may bring with it bug fixes as well as updated Common Locale Data Repository (CLDR) data describing the world's languages.  Moving between versions of ICU can thus subtly impact application behavior when it comes to globalization-related operations.  To help application developer's ensure consistency across all deployments, .NET starting with .NET 5 also enables applications on both Windows and Unix to carry and use their own copy of ICU.

Applications can opt-in to an app-local ICU implementation mode by either of the following:

1. In  the project file:

```xml
<ItemGroup>
  <RuntimeHostConfigurationOption Include="System.Globalization.AppLocalIcu" Value="<suffix>:<version> or <version>" />
</ItemGroup>
```

2. In the `runtimeconfig.json` file:

```json
{
  "runtimeOptions": {
     "configProperties": {
       "System.Globalization.AppLocalIcu": "<suffix>:<version> or <version>"
      }
  }
}
```

3. Setting the environment variable `DOTNET_SYSTEM_GLOBALIZATION_APPLOCALICU` to the value `<suffix>:<version>` or `<version>` (without quotes). 

`<suffix>`: Optional suffix of less than 36 characters in length, following the public ICU packaging conventions. When building a custom ICU, you can customize it to produce the lib names and exported symbol names to contain a suffix, e.g. `libicuucmyapp` where `myapp` is the suffix.

`<version>`: A valid ICU version, e.g. 67.1. This version will be used to load the binaries and to get the exported symbols.

To load ICU when the app-local switch is set, .NET uses the [NativeLibrary.TryLoad](https://docs.microsoft.com/dotnet/api/system.runtime.interopservices.nativelibrary.tryload) method which probes multiple paths, first trying to find the library in the `NATIVE_DLL_SEARCH_DIRECTORIES` property which is created by the dotnet host based on the `deps.json` file for the app. More details [here](https://docs.microsoft.com/en-us/dotnet/core/dependency-loading/default-probing)

For self-contained apps, no special action is required by the user, other than making sure ICU is in the APP directory (for self-contained apps, the working directory defaults to `NATIVE_DLL_SEARCH_DIRECTORIES`).

If you're consuming ICU via a NuGet package, this will work in framework-dependent applications as NuGet will resolve the native assets and include them in the `deps.json` file and in the output directory for the application under the `runtimes` dir, and .NET will load it from there.

For framework-dependent apps (not self contained) where ICU is consumed from a local build, additional steps must be taken. The .NET SDK doesn't yet have a feature for "loose" native binaries to be incorporated into `deps.json` (https://github.com/dotnet/sdk/issues/11373). Instead, a developer can enable this by adding additional information into the application's project file, e.g.:

```xml
<ItemGroup>
  <IcuAssemblies Include="icu\*.so*" />
  <RuntimeTargetsCopyLocalItems Include="@(IcuAssemblies)" AssetType="native" CopyLocal="true" DestinationSubDirectory="runtimes/linux-x64/native/" DestinationSubPath="%(FileName)%(Extension)" RuntimeIdentifier="linux-x64" NuGetPackageId="System.Private.Runtime.UnicodeData" />
</ItemGroup>
```

Note that this will have to be done for all the ICU binaries for the supported runtimes. Also, the `NuGetPackageId` metadata in the `RuntimeTargetsCopyLocalItems` item group needs to match a NuGet package that the project actually references.

### macOS behavior

`macOS` has a different behavior for resolving dependent dynamic libraries from the load commands specified in the `match-o` file than the Linux loader. In the Linux loader, .NET can try `libicudata` first, then `libicuuc`, and last `libicui18n` in that order to satisfy ICU dependency graph. However, on `macOS` this doesn't work. When building ICU on `macOS`, you by default get a dynamic library with these load commands in libicuuc, e.g.:

```sh
~/ % otool -L /Users/santifdezm/repos/icu-build/icu/install/lib/libicuuc.67.1.dylib
/Users/santifdezm/repos/icu-build/icu/install/lib/libicuuc.67.1.dylib:
 libicuuc.67.dylib (compatibility version 67.0.0, current version 67.1.0)
 libicudata.67.dylib (compatibility version 67.0.0, current version 67.1.0)
 /usr/lib/libSystem.B.dylib (compatibility version 1.0.0, current version 1281.100.1)
 /usr/lib/libc++.1.dylib (compatibility version 1.0.0, current version 902.1.0)
```

These commands are just referencing the name of the dependent libraries for the other components of ICU, so the loader will do the search following the `dlopen` conventions, which involve having these libraries in the system directories or setting the `LD_LIBRARY_PATH` env vars, or having ICU at the app level directory. So if you can't set `LD_LIBRARY_PATH` or make sure that ICU binaries are at the app level directory, you will need to do some extra work.

There are some directives for the loader, like `@loader_path` which tells the loader to search for that dependency in the same directory as the binary with that load command. So there's 2 ways to achieve this:

##### install_name_tool -change
Running:
```
install_name_tool -change "libicudata.67.dylib" "@loader_path/libicudata.67.dylib" /path/to/libicuuc.67.1.dylib
install_name_tool -change "libicudata.67.dylib" "@loader_path/libicudata.67.dylib" /path/to/libicui18n.67.1.dylib
install_name_tool -change "libicuuc.67.dylib" "@loader_path/libicuuc.67.dylib" /path/to/libicui18n.67.1.dylib
```

##### patching ICU to produce the install names with @loader_path
Before running autoconf (`./runConfigureICU`), you need to change [these lines](https://github.com/unicode-org/icu/blob/ef91cc3673d69a5e00407cda94f39fcda3131451/icu4c/source/config/mh-darwin#L32-L37) to: 
```
LD_SONAME = -Wl,-compatibility_version -Wl,$(SO_TARGET_VERSION_MAJOR) -Wl,-current_version -Wl,$(SO_TARGET_VERSION) -install_name @loader_path/$(notdir $(MIDDLE_SO_TARGET))
```
