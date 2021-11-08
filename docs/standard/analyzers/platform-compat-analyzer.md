---
title: Platform compatibility analyzer
description: A Roslyn analyzer that can help detect platform compatibility issues in cross-platform apps and libraries.
author: buyaa-n
ms.date: 09/20/2021
---

# Platform compatibility analyzer

You've probably heard the motto of "One .NET": a single, unified platform for building any type of application. The .NET 5 SDK includes ASP.NET Core, Entity Framework Core, WinForms, WPF, Xamarin, and ML.NET, and will add support for more platforms over time. .NET 5 strives to provide an experience where you don't have to reason about the different flavors of .NET, but doesn't attempt to fully abstract away the underlying operating system (OS). You'll continue to be able to call platform-specific APIs, for example, P/Invokes, WinRT, or the Xamarin bindings for iOS and Android.

But using platform-specific APIs on a component means the code no longer works across all platforms. We needed a way to detect this at design time so developers get diagnostics when they inadvertently use platform-specific APIs. To achieve this goal, .NET 5 introduces the [platform compatibility analyzer](../../fundamentals/code-analysis/quality-rules/ca1416.md) and complementary APIs to help developers identify and use platform-specific APIs where appropriate.

The new APIs include:

- <xref:System.Runtime.Versioning.SupportedOSPlatformAttribute> to annotate APIs as being platform-specific and <xref:System.Runtime.Versioning.UnsupportedOSPlatformAttribute> to annotate APIs as being unsupported on a particular OS. These attributes can optionally include the version number, and have already been applied to some platform-specific APIs in the core .NET libraries.
- `Is<Platform>()` and `Is<Platform>VersionAtLeast(int major, int minor = 0, int build = 0, int revision = 0)` static methods in the <xref:System.OperatingSystem?displayProperty=nameWithType> class for safely calling platform-specific APIs. For example, <xref:System.OperatingSystem.IsWindows?displayProperty=nameWithType> can be used to guard a call to a Windows-specific API, and <xref:System.OperatingSystem.IsWindowsVersionAtLeast%2A?displayProperty=nameWithType>() can be used to guard a versioned Windows-specific API call. See these [examples](#guard-platform-specific-apis-with-guard-methods) of how these methods can be used as guards of platform-specific API references.

## Prerequisites

The platform compatibility analyzer is one of the Roslyn code quality analyzers. Starting in .NET 5, these analyzers are [included with the .NET SDK](../../fundamentals/code-analysis/overview.md). The platform compatibility analyzer is enabled by default only for projects that target `net5.0` or a later version. However, you can [enable it](../../fundamentals/code-analysis/quality-rules/ca1416.md#configure-code-to-analyze) for projects that target other frameworks.

## How the analyzer determines platform dependency

- An **unattributed API** is considered to work on **all OS platforms**.
- An API marked with `[SupportedOSPlatform("platform")]` is considered only portable to the specified platform and any platforms it's a subset of.
  - The attribute can be applied multiple times to indicate **multiple platform support**, for example `[SupportedOSPlatform("windows"), SupportedOSPlatform("Android29.0")]`.
  - If the platform is a [subset of another platform](#platform-inclusion), the attribute implies that the superset platform is also supported. For example, `[SupportedOSPlatform("iOS")]` implies that the API is supported on `iOS` and also on its superset platform, `MacCatalyst`.
  - The analyzer will produce a **warning** if platform-specific APIs are referenced without a proper **platform context**:
    - **Warns** if the project doesn't target the supported platform (for example, a Windows-specific API called from a project targeting iOS `<TargetFramework>net5.0-ios14.0</TargetFramework>`).
    - **Warns** if the project is cross-platform and calls platform-specific APIs (for example, a Windows-specific API called from cross platform TFM `<TargetFramework>net5.0</TargetFramework>`).
    - **Doesn't warn** if the platform-specific API is referenced within a project that targets any of the **specified platforms** (for example, for a Windows-specific API called from a project targeting windows `<TargetFramework>net5.0-windows</TargetFramework>` and the *AssemblyInfo.cs* file generation is enabled for the project).
    - **Doesn't warn** if the platform-specific API call is guarded by corresponding platform-check methods (for example, a Windows-specific API call guarded by `OperatingSystem.IsWindows()`).
    - **Doesn't warn** if the platform-specific API is referenced from the same platform-specific context (**call site also attributed** with `[SupportedOSPlatform("platform")`).
- An API marked with `[UnsupportedOSPlatform("platform")]` is considered to be unsupported on the specified platform and any platforms it's a subset of, but supported for all other platforms.
  - The attribute can be applied multiple times with different platforms, for example, `[UnsupportedOSPlatform("iOS"), UnsupportedOSPlatform("Android29.0")]`.
  - If the platform is a [subset of another platform](#platform-inclusion), the attribute implies that the superset platform is also unsupported. For example, `[UnsupportedOSPlatform("iOS")]` implies that the API is unsupported on `iOS` and also on its superset platform, `MacCatalyst`.
  - The analyzer produces a **warning** only if the `platform` is effective for the call site:
    - **Warns** if the project targets the platform that's attributed as unsupported (for example, if the API is attributed with `[UnsupportedOSPlatform("windows")]` and the call site targets `<TargetFramework>net5.0-windows</TargetFramework>`).
    - **Warns** if the project is multi-targeted and the `platform` is included in the default [MSBuild `<SupportedPlatform>`](https://github.com/dotnet/sdk/blob/main/src/Tasks/Microsoft.NET.Build.Tasks/targets/Microsoft.NET.SupportedPlatforms.props) items group, or the `platform` is manually included within the `MSBuild` \<SupportedPlatform> items group:

      ```XML
      <ItemGroup>
          <SupportedPlatform Include="platform" />
      </ItemGroup>
      ```

    - **Doesn't warn** if you're building an app that doesn't target the unsupported platform or is multi-targeted and the platform is not included in the default [MSBuild `<SupportedPlatform>`](https://github.com/dotnet/sdk/blob/main/src/Tasks/Microsoft.NET.Build.Tasks/targets/Microsoft.NET.SupportedPlatforms.props) items group.

- Both attributes can be instantiated with or without version numbers as part of the platform name. Version numbers are in the format of `major.minor[.build[.revision]]`; `major.minor` is required and the `build` and `revision` parts are optional. For example, "Windows6.1" indicates Windows version 6.1, but "Windows" is interpreted as Windows 0.0.

For more information, see [examples of how the attributes work and what diagnostics they cause](#examples-of-how-the-attributes-work-and-what-diagnostics-they-produce).

## How the analyzer recognizes TFM target platforms

The analyzer does not check target framework moniker (TFM) target platforms from MSBuild properties, such as `<TargetFramework>` or `<TargetFrameworks>`. If the TFM has a target platform, MSBuild injects a `SupportedOSPlatform` attribute with the targeted platform name in the *AssemblyInfo.cs* file, which is consumed by the analyzer. For example, if the TFM is `net5.0-windows10.0.19041`, MSBuild injects the `[assembly: System.Runtime.Versioning.SupportedOSPlatform("windows10.0.19041")]` attribute into the *AssemblyInfo.cs* file, and the entire assembly is considered to be Windows only. Therefore, calling Windows-only APIs versioned with 7.0 or below  would not cause any warnings in the project.

  > [!NOTE]
  > If the *AssemblyInfo.cs* file generation is disabled for the project (that is, the `<GenerateAssemblyInfo>` property is set to `false`), the required assembly level `SupportedOSPlatform` attribute can't be added by MSBuild. In this case, you could see warnings for a platform-specific APIs usage even if you're targeting that platform. To resolve the warnings, enable the *AssemblyInfo.cs* file generation or add the attribute manually in your project.

### Platform inclusion

.NET 6 introduces the concept of *platform inclusion*, where one platform can be a subset of another platform. An annotation for the subset platform implies the same support (or lack thereof) for the superset platform. If a platform check method in the <xref:System.OperatingSystem> type has a `SupportedOSPlatformGuard("supersetPlatform")]` attribute, then `supersetPlatform` is considered a superset of the OS platform that the method checks for.

For example, the <xref:System.OperatingSystem.IsIOS?displayProperty=nameWithType> method is attributed `[SupportedOSPlatformGuard("MacCatalyst")]`. Therefore, the following statements apply:

- The <xref:System.OperatingSystem.IsIOS?displayProperty=nameWithType> and <xref:System.OperatingSystem.IsIOSVersionAtLeast%2A?displayProperty=nameWithType> methods check not only the `iOS` platform, but also the `MacCatalyst` platform.
- `[SupportedOSPlatform("iOS")]` implies that the API is supported on `iOS` and also on its superset platform, `MacCatalyst`. You can use the `[UnsupportedOSPlatform("MacCatalyst")]` attribute to exclude this implied support.
- `[UnsupportedOSPlatform("iOS")` implies that the API is not supported on `iOS` and `MacCatalyst`. You can use the `[SupportedOSPlatform("MacCatalyst")]` attribute to exclude this implied lack of support.

Consider the following coverage matrix, where ✔️ indicates that the platform is supported, and ❌ indicates that the platform is *not* supported.

| Platform | `SupportedOSPlatform(subset)` | `SupportedOSPlatform(superset)` | `UnsupportedOSPlatform(subset)` | `UnsupportedOSPlatform(superset)` |
| - | - | - | - | - |
| **Subset** | ✔️ | ❌ | ✔️ | ❌ |
| **Superset** | ✔️ | ✔️ | ✔️ | ✔️ |

> [!TIP]
> The same rules apply for the `SupportedOSPlatformGuard` and `UnsupportedOSPlatformGuard` attributes.

The following code snippet shows how you can combine attributes to set the right level of support.

```csharp
  // MacCatalyst is a superset of iOS therefore supported on iOS and MacCatalyst  
  [SupportedOSPlatform("iOS")]
  public void ApiOnlySupportedOnIOSAndMacCatalyst() { }

  // Does not imply iOS, only supported on MacCatalyst
  [SupportedOSPlatform("MacCatalyst")]
  public void ApiOnlySupportedOnMacCatalyst() { }

  [SupportedOSPlatform("iOS")] // Supported on iOS and MacCatalyst  
  [UnsupportedOSPlatform("MacCatalyst")] // Removes implied MacCatalyst support
  public void ApiOnlySupportedOnIos() { }

  // Unsupported on iOS and MacCatalyst  
  [UnsupportedOSPlatform("iOS")]
  public void ApiUnsupportedOnIOSAndMacCatalyst();

  // Does not imply iOS, only unsupported on MacCatalyst
  [UnsupportedOSPlatform("MacCatalyst")]
  public void ApiUnsupportedOnMacCatalyst() { }

  [UnsupportedOSPlatform("iOS")] // Unsupported on iOS and MacCatalyst  
  [SupportedOSPlatform("MacCatalyst")] // Removes implied MacCatalyst unsupportedness
  public void ApiUnsupportedOnIos() { }
```

### Advanced scenarios for attribute combinations

- If a combination of `[SupportedOSPlatform]` and `[UnsupportedOSPlatform]` attributes are present, all attributes are grouped by OS platform identifier:
  - **Supported only list**. If the lowest version for each OS platform is a `[SupportedOSPlatform]` attribute, the API is considered to only be supported by the listed platforms and unsupported by all other platforms. The optional `[UnsupportedOSPlatform]` attributes for each platform can only have higher version of the minimum supported version, which denotes that the API is removed starting from the specified version.

    ```csharp
    // API is only supported on Windows from version 6.2 to 10.0.19041.0 and all versions of Linux
    // The API is considered not supported for all other platforms.
    [SupportedOSPlatform("windows6.2")]
    [UnsupportedOSPlatform("windows10.0.19041.0")]
    [SupportedOSPlatform("linux")]
    public void ApiSupportedFromWindows80SupportFromCertainVersion();
    ```

  - **Unsupported only list**. If the lowest version for each OS platform is an `[UnsupportedOSPlatform]` attribute, then the API is considered to only be unsupported by the listed platforms and supported by all other platforms. The list could have `[SupportedOSPlatform]` attribute with the same platform but a higher version, which denotes that the API is supported starting from that version.

    ```csharp
    // The API is unsupported on all Linux versions was unsupported on Windows until version 10.0.19041.0.
    // The API is considered supported everywhere else without constraints.
    [UnsupportedOSPlatform("windows")]
    [SupportedOSPlatform("windows10.0.19041.0")]
    [UnsupportedOSPlatform("linux")]
    public void ApiSupportedFromWindows8UnsupportFromWindows10();
    ```

  - **Inconsistent list**. If the lowest version for some platforms is `[SupportedOSPlatform]` while it is `[UnsupportedOSPlatform]` for other platforms, it's considered to be inconsistent, which is not supported for the analyzer. If inconsistency occurs, the analyzer ignores the `[UnsupportedOSPlatform]` platforms.
    - If the lowest versions of `[SupportedOSPlatform]` and `[UnsupportedOSPlatform]` attributes are equal, the analyzer considers the platform as part of the **Supported only list**.
- Platform attributes can be applied to types, members (methods, fields, properties, and events) and assemblies with different platform names or versions.
  - Attributes applied at the top level `target` affect all of its members and types.
  - Child-level attributes only apply if they adhere to the rule "child annotations can narrow the platforms support, but they cannot widen it".
    - When parent has **Supported only** list, then child member attributes cannot add a new platform support, as that would be extending parent support. Support for a new platform can only be added to the parent itself. But the child can have the `Supported` attribute for the same platform with later versions as that narrows the support. Also, the child can have the `Unsupported` attribute with the same platform as that also narrows parent support.
    - When parent has **Unsupported only** list, then child member attributes can add support for a new platform, as that narrows parent support. But it cannot have the `Supported` attribute for the same platform as the parent, because that extends parent support. Support for the same platform can only be added to the parent where the original `Unsupported` attribute was applied.
  - If `[SupportedOSPlatform("platformVersion")]` is applied more than once for an API with the same `platform` name, the analyzer only considers the one with the minimum version.
  - If `[UnsupportedOSPlatform("platformVersion")]` is applied more than twice for an API with the same `platform` name, the analyzer only considers the two with the earliest versions.

  > [!NOTE]
  > An API that was supported initially but unsupported (removed) in a later version is not expected to get re-supported in an even later version.

### Examples of how the attributes work and what diagnostics they produce

  ```csharp
  // An API supported only on Windows all versions.
  [SupportedOSPlatform("Windows")]
  public void WindowsOnlyApi() { }

  // an API supported on Windows and Linux.
  [SupportedOSPlatform("Windows")]
  [SupportedOSPlatform("Linux")]
  public void SupportedOnWindowsAndLinuxOnly() { }

  // an API only supported on Windows 6.2 and later, not supported for all other.
  // an API is removed/unsupported from version 10.0.19041.0.
  [SupportedOSPlatform("windows6.2")]
  [UnsupportedOSPlatform("windows10.0.19041.0")]
  public void ApiSupportedFromWindows8UnsupportFromWindows10() { }

  // an Assembly supported on Windows, the API added from version 10.0.19041.0.
  [assembly: SupportedOSPlatform("Windows")]
  [SupportedOSPlatform("windows10.0.19041.0")]
  public void AssemblySupportedOnWindowsApiSupportedFromWindows10() { }

  public void Caller()
  {
      WindowsOnlyApi(); // warns: This call site is reachable on all platforms. 'WindowsOnlyApi()' is only supported on: 'windows'

      // This call site is reachable on all platforms. 'SupportedOnWindowsAndLinuxOnly()' is only supported on: 'Windows', 'Linux'
      SupportedOnWindowsAndLinuxOnly();

      // This call site is reachable on all platforms. 'ApiSupportedFromWindows8UnsupportFromWindows10()' is only supported on: 'windows' from version 6.2 to 10.0.19041.0
      ApiSupportedFromWindows8UnsupportFromWindows10();

      // for same platform analyzer only warn for the latest version.
      // This call site is reachable on all platforms. 'AssemblySupportedOnWindowsApiSupportedFromWindows10()' is only supported on: 'windows' 10.0.19041.0 and later
      AssemblySupportedOnWindowsApiSupportedFromWindows10();
  }

  // an API not supported on android but supported on all other.
  [UnsupportedOSPlatform("android")]
  public void DoesNotWorkOnAndroid() { }

  // an API was unsupported on Windows until version 6.2.
  // The API is considered supported everywhere else without constraints.
  [UnsupportedOSPlatform("windows")]
  [SupportedOSPlatform("windows6.2")]
  public void StartedWindowsSupportFromVersion8() { }

  // an API was unsupported on Windows until version 6.2.
  // Then the API is removed (unsupported) from version 10.0.19041.0.
  // The API is considered supported everywhere else without constraints.
  [UnsupportedOSPlatform("windows")]
  [SupportedOSPlatform("windows6.2")]
  [UnsupportedOSPlatform("windows10.0.19041.0")]
  public void StartedWindowsSupportFrom8UnsupportedFrom10() { }

  public void Caller2()
  {
      DoesNotWorkOnAndroid(); // This call site is reachable on all platforms.'DoesNotWorkOnAndroid()' is unsupported on: 'android'

      // This call site is reachable on all platforms. 'StartedWindowsSupportFromVersion8()' is unsupported on: 'windows' 6.2 and before.
      StartedWindowsSupportFromVersion8();

      // This call site is reachable on all platforms. 'StartedWindowsSupportFrom8UnsupportedFrom10()' is supported on: 'windows' from version 6.2 to 10.0.19041.0
      StartedWindowsSupportFrom8UnsupportedFrom10();
  }
  ```

## Handle reported warnings

The recommended way to deal with these diagnostics is to make sure you only call platform-specific APIs when running on an appropriate platform. Following are the options you can use to address the warnings; choose whichever is most appropriate for your situation:

- **Guard the call**. You can achieve this by conditionally calling the code at run time. Check whether you're running on a desired `Platform` by using one of platform-check methods, for example, `OperatingSystem.Is<Platform>()` or `OperatingSystem.Is<Platform>VersionAtLeast(int major, int minor = 0, int build = 0, int revision = 0)`. [Example](#guard-platform-specific-apis-with-guard-methods).

- **Mark the call site as platform-specific**. You can also choose to mark your own APIs as being platform-specific, thus effectively just forwarding the requirements to your callers. Mark the containing method or type or the entire assembly with the same attributes as the referenced platform-dependent call. [Examples](#mark-call-site-as-platform-specific).

- **Assert the call site with platform check**. If you don't want the overhead of an additional `if` statement at run time, use <xref:System.Diagnostics.Debug.Assert(System.Boolean)?displayProperty=nameWithType>. [Example](#assert-the-call-site-with-platform-check).

- **Delete the code**. Generally not what you want because it means you lose fidelity when your code is used by Windows users. For cases where a cross-platform alternative exists, you're likely better off using that over platform-specific APIs.

- **Suppress the warning**. You can also simply suppress the warning, either via an [EditorConfig](/visualstudio/ide/create-portable-custom-editor-options) entry or `#pragma warning disable CA1416`. However, this option should be a last resort when using platform-specific APIs.

  > [!TIP]
  > When disabling warnings using the `#pragma` pre-compiler directives, the identifiers you're targeting are case sensitive. For example, `ca1416` would not actually disable warning CA1416.

### Guard platform-specific APIs with guard methods

The guard method's platform name should match with the calling platform-dependent API platform name. If the platform string of the calling API includes the version:

- For the `[SupportedOSPlatform("platformVersion")]` attribute, the guard method platform `version` should be greater than or equal to the calling platform's `Version`.
- For the `[UnsupportedOSPlatform("platformVersion")]` attribute, the guard method's platform `version` should be less than or equal to the calling platform's `Version`.

  ```csharp
  public void CallingSupportedOnlyApis() // Allow list calls
  {
      if (OperatingSystem.IsWindows())
      {
          WindowsOnlyApi(); // will not warn
      }

      if (OperatingSystem.IsLinux())
      {
          SupportedOnWindowsAndLinuxOnly(); // will not warn, within one of the supported context
      }

      // Can use &&, || logical operators to guard combined attributes
      if (OperatingSystem.IsWindowsVersionAtLeast(6, 2) && !OperatingSystem.IsWindowsVersionAtLeast(10, 0, 19041)))
      {
          ApiSupportedFromWindows8UnsupportFromWindows10();
      }

      if (OperatingSystem.IsWindowsVersionAtLeast(10, 0, 19041, 0))
      {
          AssemblySupportedOnWindowsApiSupportedFromWindows10(); // Only need to check latest supported version
      }
  }

  public void CallingUnsupportedApis()
  {
      if (!OperatingSystem.IsAndroid())
      {
          DoesNotWorkOnAndroid(); // will not warn
      }

      if (!OperatingSystem.IsWindows() || OperatingSystem.IsWindowsVersionAtLeast(6, 2))
      {
          StartedWindowsSupportFromVersion8(); // will not warn
      }

      if (!OperatingSystem.IsWindows() || // supported all other platforms
         (OperatingSystem.IsWindowsVersionAtLeast(6, 2) && !OperatingSystem.IsWindowsVersionAtLeast(10, 0, 19041)))
      {
          StartedWindowsSupportFrom8UnsupportedFrom10(); // will not warn
      }
  }
  ```

- If you need to guard code that targets `netstandard` or `netcoreapp` where new <xref:System.OperatingSystem> APIs are not available, the <xref:System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform%2A?displayProperty=nameWithType> API can be used and will be respected by the analyzer. But it's not as optimized as the new APIs added in <xref:System.OperatingSystem>. If the platform is not supported in the <xref:System.Runtime.InteropServices.OSPlatform> struct, you can call <xref:System.Runtime.InteropServices.OSPlatform.Create(System.String)?displayProperty=nameWithType> and pass in the platform name, which the analyzer also respects.

  ```csharp
  public void CallingSupportedOnlyApis()
  {
      if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
      {
          SupportedOnWindowsAndLinuxOnly(); // will not warn
      }

      if (RuntimeInformation.IsOSPlatform(OSPlatform.Create("browser")))
      {
          ApiOnlySupportedOnBrowser(); // call of browser specific API
      }
  }
  ```

#### Annotate APIs with platform guard attributes and use it as a custom guard

As shown previously, the analyzer recognizes the platform-guard static methods in the <xref:System.OperatingSystem> type, such as `OperatingSystem.IsWindows`, and also <xref:System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform%2A?displayProperty=nameWithType>. However, you might want to cache the guard result in a field and reuse it, or use custom guard methods for checking a platform. The analyzer needs to recognize such APIs as a custom guard and should not warn for the APIs guarded by them. The guard attributes were introduced in .NET 6 to support this scenario:

- `SupportedOSPlatformGuardAttribute` annotates APIs that can be used as a guard for APIs annotated with <xref:System.Runtime.Versioning.SupportedOSPlatformAttribute>.
- `UnsupportedOSPlatformGuardAttribute` annotates APIs that can be used as a guard for APIs annotated with <xref:System.Runtime.Versioning.UnsupportedOSPlatformAttribute>.

These attributes can optionally include a version number. They can be applied multiple times to guard more than one platform and can be used for annotating a field, property, or method.

```cs
class Test
{
    [UnsupportedOSPlatformGuard("browser")] // The platform guard attribute
#if TARGET_BROWSER
    internal bool IsSupported => false;
#else
    internal bool IsSupported => true;
#endif

    [UnsupportedOSPlatform("browser")]
    void ApiNotSupportedOnBrowser() { }

    void M1()
    {
        ApiNotSupportedOnBrowser();  // Warns: This call site is reachable on all platforms.'ApiNotSupportedOnBrowser()' is unsupported on: 'browser'

        if (IsSupported)
        {
            ApiNotSupportedOnBrowser();  // Not warn
        }
    }

    [SupportedOSPlatform("Windows")]
    [SupportedOSPlatform("Linux")]
    void ApiOnlyWorkOnWindowsLinux() { }

    [SupportedOSPlatformGuard("Linux")]
    [SupportedOSPlatformGuard("Windows")]
    private readonly bool _isWindowOrLinux = OperatingSystem.IsLinux() || OperatingSystem.IsWindows();

    void M2()
    {
        ApiOnlyWorkOnWindowsLinux();  // This call site is reachable on all platforms.'ApiOnlyWorkOnWindowsLinux()' is only supported on: 'Linux', 'Windows'.

        if (_isWindowOrLinux)
        {
            ApiOnlyWorkOnWindowsLinux();  // Not warn
        }
    }
}
```

### Mark call site as platform-specific

Platform names should match the calling platform-dependent API. If the platform string includes a version:

- For the `[SupportedOSPlatform("platformVersion")]` attribute, the call site platform `version` should be greater than or equal to the calling platform's `Version`
- For the `[UnsupportedOSPlatform("platformVersion")]` attribute, the call site platform `version` should be less than or equal to the calling platform's `Version`

  ```csharp
  // an API supported only on Windows.
  [SupportedOSPlatform("windows")]
  public void WindowsOnlyApi() { }

  // an API supported on Windows and Linux.
  [SupportedOSPlatform("Windows")]
  [SupportedOSPlatform("Linux")]
  public void SupportedOnWindowsAndLinuxOnly() { }

  // an API only supported on Windows 6.2 and later, not supported for all other.
  // an API is removed/unsupported from version 10.0.19041.0.
  [SupportedOSPlatform("windows6.2")]
  [UnsupportedOSPlatform("windows10.0.19041.0")]
  public void ApiSupportedFromWindows8UnsupportFromWindows10() { }

  // an Assembly supported on Windows, the API added from version 10.0.19041.0.
  [assembly: SupportedOSPlatform("Windows")]
  [SupportedOSPlatform("windows10.0.19041.0")]
  public void AssemblySupportedOnWindowsApiSupportedFromWindows10() { }

  [SupportedOSPlatform("windows6.2")] // call site attributed Windows 6.2 or above.
  public void Caller()
  {
      WindowsOnlyApi(); // will not warn as call site is for Windows.

      // will not warn as call site is for Windows all versions.
      SupportedOnWindowsAndLinuxOnly();

      // will not warn for the [SupportedOSPlatform("windows6.2")] attribute, but warns for [UnsupportedOSPlatform("windows10.0.19041.0")]
      // This call site is reachable on: 'windows' 6.2 and later. 'ApiSupportedFromWindows8UnsupportFromWindows10()' is unsupported on: 'windows' 10.0.19041.0 and later.
      ApiSupportedFromWindows8UnsupportFromWindows10();

      // The call site version is lower than the calling version, so warns:
      // This call site is reachable on: 'windows' 6.2 and later. 'AssemblySupportedOnWindowsApiSupportedFromWindows10()' is only supported on: 'windows' 10.0.19041.0 and later
      AssemblySupportedOnWindowsApiSupportedFromWindows10();
  }

  [SupportedOSPlatform("windows10.0.22000")] // call site attributed with windows 10.0.22000 or above.
  public void Caller2()
  {
      // This call site is reachable on: 'windows' 10.0.22000 and later. 'ApiSupportedFromWindows8UnsupportFromWindows10()' is unsupported on: 'windows' 10.0.19041.0 and later.
      ApiSupportedFromWindows8UnsupportFromWindows10();

      // will not warn as call site version higher than calling API.
      AssemblySupportedOnWindowsApiSupportedFromWindows10();
  }

  [SupportedOSPlatform("windows6.2")]
  [UnsupportedOSPlatform("windows10.0.19041.0")] // call site supports Windows from version 6.2 to 10.0.19041.0.
  public void Caller3()
  {
      // will not warn as caller has exact same attributes.
      ApiSupportedFromWindows8UnsupportFromWindows10();

      // The call site reachable for the version not supported in the calling API, therefore warns:
      // This call site is reachable on: 'windows' from version 6.2 to 10.0.19041.0. 'AssemblySupportedOnWindowsApiSupportedFromWindows10()' is only supported on: 'windows' 10.0.19041.0 and later.
      AssemblySupportedOnWindowsApiSupportedFromWindows10();
  }

  // an API not supported on Android but supported on all other.
  [UnsupportedOSPlatform("android")]
  public void DoesNotWorkOnAndroid() { }

  // an API was unsupported on Windows until version 6.2.
  // The API is considered supported everywhere else without constraints.
  [UnsupportedOSPlatform("windows")]
  [SupportedOSPlatform("windows6.2")]
  public void StartedWindowsSupportFromVersion8() { }

  // an API was unsupported on Windows until version 6.2.
  // Then the API is removed (unsupported) from version 10.0.19041.0.
  // The API is considered supported everywhere else without constraints.
  [UnsupportedOSPlatform("windows")]
  [SupportedOSPlatform("windows6.2")]
  [UnsupportedOSPlatform("windows10.0.19041.0")]
  public void StartedWindowsSupportFrom8UnsupportedFrom10() { }

  [UnsupportedOSPlatform("windows")] // Caller no support Windows for any version.
  public void Caller4()
  {
      // This call site is reachable on all platforms.'DoesNotWorkOnAndroid()' is unsupported on: 'android'
      DoesNotWorkOnAndroid();

      // will not warns as the call site not support Windows at all, but supports all other.
      StartedWindowsSupportFromVersion8();

      // same, will not warns as the call site not support Windows at all, but supports all other.
      StartedWindowsSupportFrom8UnsupportedFrom10();
  }

  [UnsupportedOSPlatform("windows")]
  [UnsupportedOSPlatform("android")] // Caller not support Windows and Android for any version.
  public void Caller4()
  {
      DoesNotWorkOnAndroid(); // will not warn as call site not supports Android.

      // will not warns as the call site not support Windows at all, but supports all other.
      StartedWindowsSupportFromVersion8();

      // same, will not warns as the call site not support Windows at all, but supports all other.
      StartedWindowsSupportFrom8UnsupportedFrom10();
  }
  ```

### Assert the call-site with platform check

All the conditional checks used in the [platform guard examples](#guard-platform-specific-apis-with-guard-methods) can also be used as the condition for <xref:System.Diagnostics.Debug.Assert(System.Boolean)?displayProperty=nameWithType>.

  ```csharp
  // An API supported only on Linux.
  [SupportedOSPlatform("linux")]
  public void LinuxOnlyApi() { }

  public void Caller()
  {
      Debug.Assert(OperatingSystem.IsLinux());

      LinuxOnlyApi(); // will not warn
  }
  ```

## See also

- [Target Framework Names in .NET 5](https://github.com/dotnet/designs/blob/main/accepted/2020/net5/net5.md)
- [Annotating platform-specific APIs and detecting its use](https://github.com/dotnet/designs/blob/main/accepted/2020/platform-checks/platform-checks.md)
- [Annotating APIs as unsupported on specific platforms](https://github.com/dotnet/designs/blob/main/accepted/2020/platform-exclusion/platform-exclusion.md)
- [CA1416 Platform compatibility analyzer](../../fundamentals/code-analysis/quality-rules/ca1416.md)
