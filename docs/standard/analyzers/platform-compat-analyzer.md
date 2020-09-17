---
title: Platform compatibility analyzer
description: A Roslyn analyzer can help detect platform compatibility issues across cross platform .NET 5.0.
author: buyaa-n
ms.date: 09/17/2020
---

# Platform compatibility analyzer

By now everybody must heard of the mojo of `One .NET` - a single unified platform for building any type of application. The `.NET 5.0` SDK includes ASP.NET Core, Entity Framework Core, WinForms, WPF, Xamarin and ML.NET and we will continue to gain support for more platforms over time. While we strive to provide an experience where you don't have to reason about the different kinds of .NET, we still don't want to fully abstract away the underlying OS, so you'll continue to be able to call OS specific APIs, be that via P/Invokes, WinRT, or the Xamarin bindings for iOS and Android.

But using platform-dependent APIs on a component makes the code no longer work across all platforms. We needed a way to detect this at design-time so that developers get diagnostics when they inadvertently use platform-specific APIs. To achieve this goal we introduced [platform compatibility analyzer](/visualstudio/code-quality/ca1416) and complementary APIs help developers identify and use platform-specific APIs where appropriate, the new APIs include:

- Added <xref:System.Runtime.Versioning.SupportedOSPlatformAttribute> to annotate APIs as being platform-specific and <xref:System.Runtime.Versioning.UnsupportedOSPlatformAttribute> to express that and API is unsupported on a particular OS, optionally including the version numbers. These attributes have been applied to platform-specific APIs in the core .NET libraries (still in progress).
- Added `Is<Platform>()` and `Is<Platform>VersionAtLeast(int major, int minor = 0, int build = 0, int revision = 0)` style static methods in the <xref:System.OperatingSystem?displayProperty=nameWithType> class for safely calling platform dependent APIs, for example, <xref:System.OperatingSystem.IsWindows?displayProperty=nameWithType> could be used for guarding a call of windows specific APIs and  <xref:System.OperatingSystem.IsWindowsVersionAtLeast%2A?displayProperty=nameWithType>() could be used for guarding a versioned windows specific API call. Learn [more](#the-platform-specific-api-calls-in-the-above-examples-guarded-with-guard-methods) about how they used as guards of platform-specific API references.

> [!TIP]
> Platform compatibility analyzer upgrades/replaces [Discovering cross-platform issues](../../standard/analyzers/api-analyzer.md#discover-cross-platform-issues) feature of the [.NET API analyzer](../../standard/analyzers/api-analyzer.md).

## Prerequisites

The platform compatibility analyzer is one of the Roslyn code quality analyzers. Starting in .NET 5.0, these analyzers are [included with the .NET SDK](../../fundamentals/productivity/code-analysis.md). For older .NET versions, you can install code quality analyzers from [NuGet package](https://www.nuget.org/packages/Microsoft.CodeAnalysis.FxCopAnalyzers). The platform compatibility analyzer is enabled by default only for projects that target `net5.0` or a later version. However, you can [enable](/visualstudio/code-quality/ca1416.md#configurability) it for projects that target other frameworks.

### How the analyzer detect platform dependency using the `SupportedOSPlatform` and `UnsupportedOSPlatform` attributes?

- An **unattributed API** is considered to work on **all OS platforms**.
- An API marked with `[SupportedOSPlatform("platform")]` is considered only portable to the specified OS `platform`.
  - The attribute can be applied multiple times to indicate **multiple platform support** (`[SupportedOSPlatform("windows"), SupportedOSPlatform("Android6.0")]`).
  - The analyzer would produce **warning** if platform-specific APIs referenced without a proper **platform context** such as:
    - **Warns** if the project is not targeting the supported platform (for example for windows-specific API call the project is targeting `<TargetFramework>net5.0-ios14.0</TargetFramework>`).
    - **Warns** if the project is multi-targeted (`<TargetFramework>net5.0</TargetFramework>`).
    - **Not warns** if the platform-specific API is referenced within a project targeting any of the **specified platforms** (for example for windows-specific API call the project is targeting `<TargetFramework>net5.0-windows</TargetFramework>`).
    - **Not warns** if the platform specific API call is guarded by corresponding platform check methods (for example as within `if(OperatingSystem.IsWindows())` condition).
    - **Not warns** if the `platform` specific API is referenced from the same `platform` specific context (**call site also attributed** with `[SupportedOSPlatform("platform")`).
- An API marked with `[UnsupportedOSPlatform("platform")]` is considered unsupported only to the specified OS `platform` but supported for all other platforms.
  - The attribute can be applied multiple times with different platforms. (`[UnsupportedOSPlatform("iOS"), UnsupportedOSPlatform("Android6.0")]`).
  - The analyzer could produce **warning** only if the `platform` is effective for the call site, such as:
    - **Warns** if the project is targeting the `platform` attributed as unsupported (for example if the API attributed with `[UnsupportedOSPlatform("browser")]` and call site targeting `<TargetFramework>net5.0-browser</TargetFramework>`).
    - **Warns** if the project is multi-targeted and the `platform` is included in the default [MSBuild `<SupportedPlatform>`](https://github.com/dotnet/sdk/blob/master/src/Tasks/Microsoft.NET.Build.Tasks/targets/Microsoft.NET.SupportedPlatforms.props) items group or the `platform` manually included within the `MSBuild` \<SupportedPlatform> items group:

    ```XML
    <ItemGroup>
        <SupportedPlatform Include="platform" />
    </ItemGroup>
    ```

    - **Not warns** if you're building an app that is not targeting the unsupported `platform` or it is multi-targeted and the `platform` is not included in the default [MSBuild `<SupportedPlatform>`](https://github.com/dotnet/sdk/blob/master/src/Tasks/Microsoft.NET.Build.Tasks/targets/Microsoft.NET.SupportedPlatforms.props) items group.
- Both attributes can be instantiated with or without version numbers as part of the platform name.
  - Version numbers are in the format of `major.minor[.build[.revision]]`; `major.minor` is required and the `build` and `revision` parts are optional. For example, "Windows7.0" indicates Windows version 7.0, but "Windows" is interpreted as Windows 0.0.
- Platform attributes can be applied to `Types, Members (methods, fields, properties and events) and Assembly`.
  - Attributes applied at the top level `target` affects into all `Members and/or Types` inside it.
- Same `platform` attribute can be applied across the symbol tree for different symbols only with different versions. (Example: assume an `Assembly` having a `[SupportedOSPlatform("windows")]` attribute and there is a new `Type` added with `windows 10.0.17763.0` release, that `Type` should be annotated with `[SupportedOSPlatform("window10.0.17763.0")]`).
  - In case `[SupportedOSPlatform("platformVersion")]` applied more than twice for the referenced member with same `platform` only Min and Max versions will be accounted for the analyzer.
  - In case `[UnsupportedOSPlatform("platformVersion")]` applied more than twice for the referenced member with same `platform` only Min and next Min versions will be accounted for the analyzer.

See [examples of how the attributes work and what diagnostics they cause](#examples-of-how-the-attributes-work-and-what-diagnostics-they-produce)
### Advanced scenarios for attributes combination

- If a combination of `[SupportedOSPlatform] and [UnsupportedOSPlatform]` attributes are present, we group all attributes by OS platform identifier:
  - **Allow list**. If the lowest version for each OS platform is a `[SupportedOSPlatform]` attribute, the API is considered to only be supported by the listed platforms and unsupported by all other platforms. The optional `[UnsupportedOSPlatform]` attributes for each platforms could only have higher version of the Min supported version, which denotes that the API is removed starting from the specified version.

  ```csharp
  // The API only supported on windows 8.0 and later, not supported for all other
  // The API is removed/unsupported from version 10.0.19041.0
  [SupportedOSPlatform("windows8.0")]
  [UnsupportedOSPlatform("windows10.0.19041.0")]
  public void ApiSupportedFromWindows80SupportFromCertainVersion();
  ```

  - **Deny list**. If the lowest version for each OS platform is an `[UnsupportedOSPlatform]` attribute, then the API is considered to only be unsupported by the listed platforms and supported by all other platforms. The list could have `[SupportedOSPlatform]` attribute with same platform but only with higher version which denotes that the API is added support from that version.
  
  ```csharp
  // The API was unsupported on windows until version 10.0.19041.0
  // The API is considered supported everywhere else without constraints.
  [UnsupportedOSPlatform("windows")]
  [SupportedOSPlatform("windows10.0.19041.0")]
  public void ApiSupportedFromWindows8UnsupportFromWindows10();
  ```

  - **Inconsistent list**. If the lowest version for some platforms is `[SupportedOSPlatform]` while it is `[UnsupportedOSPlatform]` for other platforms, is considered inconsistent, which is not supported for the analyzer. We plan to introduce another analyzer producing a warning in case of inconsistency in the future.
  - If the lowest versions of `[SupportedOSPlatform]` and `[UnsupportedOSPlatform]` attributes are equal the analyzer would count it as **Deny list**.
  
  > [!NOTE]
  > An API that was supported initially and unsupported (removed) later versions are not expected to get supported back

### Examples of how the attributes work and what diagnostics they produce

  ```csharp Examples
  // An API supported only on Windows.
  [SupportedOSPlatform("windows")]
  public void WindowsOnlyApi() { }

  // an API supported on windows and linux
  [SupportedOSPlatform("Windows")]
  [SupportedOSPlatform("Linux")]
  public void SupportedOnWindowsAndLinuxOnly() { }

  // an API only supported on windows 8.0 and later, not supported for all other
  // an API is removed/unsupported from version 10.0.19041.0
  [SupportedOSPlatform("windows8.0")]
  [UnsupportedOSPlatform("windows10.0.19041.0")]
  public void ApiSupportedFromWindows8UnsupportFromWindows10() { }

  // an Assembly supported on windows, the API added from version 10.0.19041.0
  [assembly: SupportedOSPlatform("Windows")]
  [SupportedOSPlatform("windows10.0.19041.0")]
  public void AssemblySupportedOnWindowsApiSupportedFromWindows10() { }

  public void Caller()
  {
      WindowsOnlyApi(); // warns: 'WindowsOnlyApi' is supported on 'windows'

      // warns: 'SupportedOnWindowsAndLinuxOnly' is supported on 'Windows'  
      // warns: 'SupportedOnWindowsAndLinuxOnly' is supported on 'Linux'
      SupportedOnWindowsAndLinuxOnly();

      // warns: 'ApiSupportedFromWindows8UnsupportFromWindows10' is supported on 'windows' 8.0 and later  
      // warns: 'ApiSupportedFromWindows8UnsupportFromWindows10' is unsupported on 'windows' 10.0.19041.0 and later
      ApiSupportedFromWindows8UnsupportFromWindows10();

      // warns: 'ApiSupportedFromWindows8UnsupportFromWindows10' is supported on 'windows' 10.0.19041.0 and later
      // for same platform analyzer only warn for the latest version
      AssemblySupportedOnWindowsApiSupportedFromWindows10();
  }

  // an API not supported on android but supported on all other
  [UnsupportedOSPlatform("android")]  
  public void DoesNotWorkOnAndroid() { }

  // an API was unsupported on windows until version 8.0.
  // The API is considered supported everywhere else without constraints.
  [UnsupportedOSPlatform("windows")]
  [SupportedOSPlatform("windows8.0")]
  public void StartedWindowsSupportFromVersion8() { }

  // an API was unsupported on windows until version8.0.
  // Then the API is removed (unsupported) from version 10.0.19041.0.
  // The API is considered supported everywhere else without constraints.
  [UnsupportedOSPlatform("windows")]
  [SupportedOSPlatform("windows8.0")]
  [UnsupportedOSPlatform("windows10.0.19041.0")]
  public void StartedWindowsSupportFrom8UnsupportedFrom10() { }

  public void Caller2()
  {
      DoesNotWorkOnAndroid(); // warns 'DoesNotWorkOnAndroid' is unsupported on 'android'

      // warns:'StartedWindowsSupportFromVersion8' is unsupported on 'windows'  
      // warns:'StartedWindowsSupportFromVersion8' is supported on 'windows' 8.0 and later
      StartedWindowsSupportFromVersion8();

      // warns:'StartedWindowsSupportFrom8UnsupportedFrom10' is unsupported on 'windows'  
      // warns:'StartedWindowsSupportFrom8UnsupportedFrom10' is supported on 'windows' 8.0 and later
      // even there were 3 diagnostics found analyzer warn only for the first 2
      StartedWindowsSupportFrom8UnsupportedFrom10();
  }
  ```

### How to handle the warnings reported?

The recommend way to deal with these diagnostics is by making sure you only call these APIs when running on the appropriate platforms. You have five options on how you can address these warnings, choose which ever appropriate for your situation.

- **Guard the call**. You can either achieve this by excluding the code at build time using `#if` and multi-targeting or by conditionally calling the code at run time. Check whether you’re running on a desired `Platform` by using one of platform-check methods, for example, `OperatingSystem.Is<Platform>()` or `OperatingSystem.Is<Platform>VersionAtLeast(int major, int minor = 0, int build = 0, int revision = 0)`.

2. **Mark the call site as platform-specific**. You can also choose to mark your own APIs as being platform-specific, thus effectively just forwarding the requirements to your callers. You can mark the containing method or type or the entire assembly with same attributes as of the referenced platform-dependent call. [Examples](#call-site-marked-as-platform-specific-for-platform-specific-api-calls-in-above-examples)

- **Assert the call site with platform check**. If you don't want the overhead of an additional `if` statement at run time, use <xref:System.Diagnostics.Debug.Assert(System.Boolean)?displayProperty=nameWithType>. [Example](#assert-the-call-site-with-platform-check).

4. **Delete the code**. Generally not what you want because it means you lose fidelity when your code is used by Windows users, but for cases where a cross-platform alternative exists, you’re likely better off using that over platform-specific APIs.

5. **Suppress the warning**. You can of course cheat and simply suppress the warning, either via editor.config or #pragma warning disable. However, you should prefer options (1), (2) and (3) when using platform-specific APIs.

### Guard platform-specific APIs with guard methods

Guard methods platform name should match with the calling platform dependent API platform name. If platform string of the calling API include version:

- For `[SupportedOSPlatform("platformVersion")]` attribute, guard method platform `version` should be >= calling platform `Version`
- For `[UnsupportedOSPlatform("platformVersion")]` attribute, guard method platform `version` should be <= calling platform `Version`

  ```csharp
  public void CallingSupportedOnlyApis() // Allow list calls
  {
      if (OperatingSystem.IsWindows())
      {
          WindowsOnlyApi(); // not warn
      }

      if (OperatingSystem.IsLinux())
      {
          SupportedOnWindowsAndLinuxOnly(); // nor warn, within one of the supported context
      }

      if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) // traditional method
      {
          SupportedOnWindowsAndLinux(); // not warn
      }

      // Can use &&, || logical operators to guard combined attributes
      if (OperatingSystem.IsWindowsVersionAtLeast(8) && !OperatingSystem.IsWindowsVersionAtLeast(10.0.19041)))
      {
          ApiSupportedFromWindows8UnsupportFromWindows10();
      }

      if (OperatingSystem.IsWindowsVersionAtLeast(10, 0, 1903))
      {
          AssemblySupportedOnWindowsApiSupportedFromWindows10(); // Only need to check latest supported version
      }
  }

  public void CallingUnsupportedApis() // Deny list calls
  {
      if (!OperatingSystem.IsAndroid())
      {
          DoesNotWorkOnAndroid(); // no diagnostic
      }

      if (!OperatingSystem.IsWindows() || OperatingSystem.IsWindowsVersionAtLeast(8))
      {
          StartedWindowsSupportFromVersion8(); // no diagnostic
      }

      if (!OperatingSystem.IsWindows() || // supported all other platform
         (OperatingSystem.IsWindowsVersionAtLeast(8) && !OperatingSystem.IsWindowsVersionAtLeast(10, 0, 1903)))
      {
          StartedWindowsSupportFrom8UnsupportedFrom10(); // no diagnostic
      }
  }
  ```

### Call site marked as platform specific for platform specific API calls in above examples

Platform names should match with the calling platform dependent API. If platform string include version:

- For `[SupportedOSPlatform("platformVersion")]` attribute, the call site platform `version` should be >= calling platform `Version`
- For `[UnsupportedOSPlatform("platformVersion")]` attribute, the call site platform `version` should be <>= calling platform `Version`

  ```csharp
  // an API supported only on windows
  [SupportedOSPlatform("windows")]
  public void WindowsOnlyApi() { }

  // an API supported on windows and linux
  [SupportedOSPlatform("Windows")]
  [SupportedOSPlatform("Linux")]
  public void SupportedOnWindowsAndLinuxOnly() { }

  // an API only supported on windows 8.0 and later, not supported for all other
  // an API is removed/unsupported from version 10.0.19041.0
  [SupportedOSPlatform("windows8.0")]
  [UnsupportedOSPlatform("windows10.0.19041.0")]
  public void ApiSupportedFromWindows8UnsupportFromWindows10() { }

  // an Assembly supported on windows, the API added from version 10.0.19041.0
  [assembly: SupportedOSPlatform("Windows")]
  [SupportedOSPlatform("windows10.0.19041.0")]
  public void AssemblySupportedOnWindowsApiSupportedFromWindows10() { }

  [SupportedOSPlatform("windows8.0")] // call site attributed windows 8.0 or above
  public void Caller()
  {
      WindowsOnlyApi(); // Not warn as call site is for windows

      // Not warn as call site is for windows  
      SupportedOnWindowsAndLinuxOnly();

      // Not warn for the API's [SupportedOSPlatform("windows8.0")] attribute
      // Warns: 'ApiSupportedFromWindows8UnsupportFromWindows10' is unsupported on 'windows' 10.0.19041.0 and later
      ApiSupportedFromWindows8UnsupportFromWindows10();

      // warns: 'ApiSupportedFromWindows8UnsupportFromWindows10' is supported on 'windows' 10.0.19041.0 and later
      // as the call site version is lower than calling version
      AssemblySupportedOnWindowsApiSupportedFromWindows10();
  }

  [SupportedOSPlatform("windows11.0")] // call site attributed with windows 11.0 or above
  public void Caller2()
  {
      // Warns: 'ApiSupportedFromWindows8UnsupportFromWindows10' is unsupported on 'windows' 10.0.19041.0 and later
      ApiSupportedFromWindows8UnsupportFromWindows10();

      // Not warn as call site version higher than calling API
      AssemblySupportedOnWindowsApiSupportedFromWindows10();
  }

  [SupportedOSPlatform("windows8.0")]
  [UnsupportedOSPlatform("windows10.0.19041.0")] // call site supports windows from version 8.0 to 10.0.19041.0
  public void Caller3()
  {
      // Not warn as caller has exact same attributes
      ApiSupportedFromWindows8UnsupportFromWindows10();

      // Warns: 'ApiSupportedFromWindows8UnsupportFromWindows10' is supported on 'windows' 10.0.19041.0 and later
      // As call site stopped support from that version
      AssemblySupportedOnWindowsApiSupportedFromWindows10();
  }

  // an API not supported on android but supported on all other
  [UnsupportedOSPlatform("android")]  
  public void DoesNotWorkOnAndroid() { }

  // an API was unsupported on windows until version 8.0.
  // The API is considered supported everywhere else without constraints.
  [UnsupportedOSPlatform("windows")]
  [SupportedOSPlatform("windows8.0")]
  public void StartedWindowsSupportFromVersion8() { }

  // an API was unsupported on windows until version8.0.
  // Then the API is removed (unsupported) from version 10.0.19041.0.
  // The API is considered supported everywhere else without constraints.
  [UnsupportedOSPlatform("windows")]
  [SupportedOSPlatform("windows8.0")]
  [UnsupportedOSPlatform("windows10.0.19041.0")]
  public void StartedWindowsSupportFrom8UnsupportedFrom10() { }

  [UnsupportedOSPlatform("windows")] // Caller no support windows for any version
  public void Caller4()
  {
      DoesNotWorkOnAndroid(); // warns 'DoesNotWorkOnAndroid' is unsupported on 'android'

      // not warns as the call site not support windows at all, but supports all other
      StartedWindowsSupportFromVersion8();

      // same, not warns as the call site not support windows at all, but supports all other
      StartedWindowsSupportFrom8UnsupportedFrom10();
  }

  [UnsupportedOSPlatform("windows")]
  [UnsupportedOSPlatform("android")] // Caller not support windows and android for any version
  public void Caller4()
  {
      DoesNotWorkOnAndroid(); // not warn as call site not supports android

      // not warns as the call site not support windows at all, but supports all other
      StartedWindowsSupportFromVersion8();

      // same, not warns as the call site not support windows at all, but supports all other
      StartedWindowsSupportFrom8UnsupportedFrom10();
  }
  ```

### Assert the call-site with platform check
All conditional checks used for [platform guard examples](#the-platform-specific-api-calls-in-the-above-examples-guarded-with-guard-methods) can be used as the condition for <xref:System.Diagnostics.Debug.Assert(System.Boolean)?displayProperty=nameWithType>

  ```csharp
  // an API supported only on linux
  [SupportedOSPlatform("linux")]
  public void LinuxOnlyApi() { }

  public void Caller()
  {
      Debug.Assert(OperatingSystem.IsLinux());

      LinuxOnlyApi(); // No diagnostic
  }
  ```

## See also

- [Target Framework Names in .NET 5](https://github.com/dotnet/designs/blob/master/accepted/2020/net5/net5.md)
- [Annotating platform-specific APIs and detecting its use](https://github.com/dotnet/designs/blob/master/accepted/2020/platform-checks/platform-checks.md)
- [Annotating APIs as unsupported on specific platforms](https://github.com/dotnet/designs/blob/master/accepted/2020/platform-exclusion/platform-exclusion.md)
- [CA1416 Platform compatibility analyzer](/visualstudio/code-quality/ca1416)
- [.NET API analyzer](../../standard/analyzers/api-analyzer.md)
