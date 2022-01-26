---
title: "Breaking change: CA1416: Platform compatibility"
description: Learn about the breaking change in .NET 5 caused by the enablement of code analysis rule CA1416.
ms.date: 05/04/2021
---
# Warning CA1416: Platform compatibility

.NET code analyzer rule [CA1416](/visualstudio/code-quality/ca1416) is enabled, by default, starting in .NET 5. It produces a build warning for calls to platform-specific APIs from call sites that don't verify the operating system.

## Change description

Starting in .NET 5, the .NET SDK includes [.NET source code analyzers](../../../../fundamentals/code-analysis/overview.md). Several of these rules are enabled, by default, including [CA1416](/visualstudio/code-quality/ca1416). If your project contains code that violates this rule and is configured to treat warnings as errors, this change could break your build. Rule CA1416 informs you when you're using platform-specific APIs from places where the platform context isn't verified.

Rule [CA1416](/visualstudio/code-quality/ca1416), the platform compatibility analyzer, works hand-in-hand with some other features that are new in .NET 5. .NET 5 introduces the <xref:System.Runtime.Versioning.SupportedOSPlatformAttribute> and <xref:System.Runtime.Versioning.UnsupportedOSPlatformAttribute>, which let you specify the platforms that an API *is* or *isn't* supported on. In the absence of these attributes, an API is assumed to be supported on all platforms. These attributes have been applied to platform-specific APIs in the core .NET libraries.

In projects that target platforms for which APIs that they use aren't available, rule [CA1416](/visualstudio/code-quality/ca1416) flags any platform-specific API call where the platform context isn't verified. Most of the APIs that are now decorated with the <xref:System.Runtime.Versioning.SupportedOSPlatformAttribute> and <xref:System.Runtime.Versioning.UnsupportedOSPlatformAttribute> attributes throw <xref:System.PlatformNotSupportedException> exceptions when they're invoked on an unsupported operating system. Now that these APIs are marked as platform-specific, rule [CA1416](/visualstudio/code-quality/ca1416) helps you prevent run-time <xref:System.PlatformNotSupportedException> exceptions by adding OS checks to your call sites.

## Examples

- The <xref:System.Console.Beep(System.Int32,System.Int32)?displayProperty=nameWithType> method is only supported on Windows and is decorated with `[SupportedOSPlatform("windows")]`. The following code will produce a CA1416 warning at build time if the project [targets](../../../../standard/frameworks.md) `net5.0` (cross platform). But this code won't warn if the project [targets Windows](../../../../fundamentals/code-analysis/quality-rules/ca1416.md#tfm-target-platforms) (`net5.0-windows`) and the `GenerateAssemblyInfo` is enabled for the project. For actions you can take to avoid the warning, see [Recommended action](#recommended-action).

  ```csharp
  public void PlayCMajor()
  {
      Console.Beep(261, 1000);
  }
  ```

- The <xref:System.Drawing.Image.FromFile(System.String)?displayProperty=nameWithType> method is not supported in the browser and is decorated with `[UnsupportedOSPlatform("browser")]`. The following code will produce a CA1416 warning at build time if the project supports the browser platform.

  ```csharp
  public void CreateImage()
  {
      Image newImage = Image.FromFile("SampImag.jpg");
  }
  ```

  > [!TIP]
  >
  > - Blazor WebAssembly projects and Razor class library projects include browser support automatically.
  > - To manually add the browser as a supported platform for your project, add the following entry to your project file:
  >
  >  ```xml
  >  <ItemGroup>
  >    <SupportedPlatform Include="browser" />
  >  </ItemGroup>
  >  ```

## Version introduced

5.0

## Recommended action

Ensure that platform-specific APIs are only called when the code is running on an appropriate platform. You can check the current operating system using one of the `Is<Platform>` methods in the <xref:System.OperatingSystem?displayProperty=nameWithType> class, for example, <xref:System.OperatingSystem.IsWindows?displayProperty=nameWithType>, before calling a platform-specific API.

You can use one of the `Is<Platform>` methods in the condition of an `if` statement:

```csharp
public void PlayCMajor()
{
    if (OperatingSystem.IsWindows())
    {
        Console.Beep(261, 1000);
    }
}
```

Or, if you don't want the overhead of an additional `if` statement at run time, call <xref:System.Diagnostics.Debug.Assert(System.Boolean)?displayProperty=nameWithType> instead:

```csharp
public void PlayCMajor()
{
    Debug.Assert(OperatingSystem.IsWindows());
    Console.Beep(261, 1000);
}
```

If you're authoring a library, you can mark your API as platform-specific. In this case, the burden of checking requirements falls on your callers. You can mark specific methods or types or an entire assembly.

```csharp
[SupportedOSPlatform("windows")]
public void PlayCMajor()
{
    Console.Beep(261, 1000);
}
```

If you don't want to fix all your call sites, you can choose one of the following options to suppress the warning:

- To suppress rule CA1416, you can do so using `#pragma` or the [**DisabledWarnings**](../../../../csharp/language-reference/compiler-options/errors-warnings.md#disabledwarnings) compiler flag, or by [setting the rule's severity](../../../../fundamentals/code-analysis/configuration-options.md#severity-level) to `none` in an .editorconfig file.

  ```csharp
  public void PlayCMajor()
  {
  #pragma warning disable CA1416
      Console.Beep(261, 1000);
  #pragma warning restore CA1416
  }
  ```

- To disable code analysis completely, set `EnableNETAnalyzers` to `false` in your project file. For more information, see [EnableNETAnalyzers](../../../project-sdk/msbuild-props.md#enablenetanalyzers).

## Affected APIs

For Windows platform:

- All APIs listed at <https://github.com/dotnet/designs/blob/main/accepted/2020/windows-specific-apis/windows-specific-apis.md>.
- <xref:System.Security.Cryptography.DSAOpenSsl?displayProperty=fullName>
- <xref:System.Security.Cryptography.ECDiffieHellmanOpenSsl?displayProperty=fullName>
- <xref:System.Security.Cryptography.ECDsaOpenSsl?displayProperty=fullName>
- <xref:System.Security.Cryptography.RSAOpenSsl?displayProperty=fullName>

For Blazor WebAssembly platform:

- All APIs listed at <https://github.com/dotnet/runtime/issues/41087>.

<!--

### Affected APIs

- ``

### Category

- Code analysis
- Core .NET libraries

-->

## See also

- [CA1416: Validate platform compatibility](/visualstudio/code-quality/ca1416)
- [Platform compatibility analyzer](../../../../standard/analyzers/platform-compat-analyzer.md)
