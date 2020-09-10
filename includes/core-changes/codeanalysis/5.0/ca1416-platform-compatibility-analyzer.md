### CA1416: Platform compatibility

.NET code analyzer rule CA1416 is enabled, by default, starting in .NET 5.0. It produces a build warning for calls to platform-specific APIs from call sites that don't verify the operating system.

#### Change description

Starting in .NET 5.0, the .NET SDK includes [.NET source code analyzers](../../../../docs/fundamentals/productivity/code-analysis.md). Several of these rules are enabled, by default, including CA1416. If your project contains code that violates this rule and is configured to treat warnings as errors, this change could break your build. Rule CA1416 informs you when you're using platform-specific APIs from call sites that don't gate the call on the operating system (OS) that the code is running on.

Starting in .NET 5.0, some .NET APIs are decorated with the `SupportedOSPlatform` and `UnsupportedOSPlatform` attributes. An API that's decorated with `SupportedOSPlatform`, which can be applied multiple times, is only supported on the specified platform(s). An API that's decorated with `UnsupportedOSPlatform`, which also can be applied multiple times, is supported on all platforms *except* those that are specified. For projects that target platforms for which APIs that they use aren't available, rule CA1416 flags any platform-specific API call where the platform context isn't verified.

Most of the APIs that are now decorated with the `SupportedOSPlatform` and `UnsupportedOSPlatform` attributes throw <xref:System.PlatformNotSupportedException> exceptions when they're invoked on an unsupported operating system. Now that these APIs are marked as platform-specific, rule CA1416 helps you prevent <xref:System.PlatformNotSupportedException> exceptions from being thrown at run time by adding OS checks to your call sites.

#### Examples

- The <xref:System.Console.Beep(System.Int32,System.Int32)?displayProperty=nameWithType> method is only supported on Windows (`[SupportedOSPlatform("windows")]`). The following code will produce a CA1416 warning if the project [targets](../../../../docs/standard/frameworks.md) `net5.0` (but not `net5.0-windows`).

  ```csharp
  public void PlayCMajor()
  {
      Console.Beep(261, 1000);
  }
  ```

- The <xref:System.Drawing.Image.FromFile(System.String)?displayProperty=nameWithType> method is *not* supported in the browser (`[UnsupportedOSPlatform("browser")]`). The following code will produce a CA1416 warning if the project uses the Blazor WebAssembly SDK (`<Project Sdk="Microsoft.NET.Blazor.WebAssembly.Sdk">`) or includes `browser` as a supported platform (`<SupportedPlatform Include="browser" />`).

  ```csharp
  public void CreateImage()
  {
      Image newImage = Image.FromFile("SampImag.jpg");
  }
  ```

#### Version introduced

5.0 RC1

#### Recommended action

Ensure that you only call platform-specific APIs when running on an appropriate platform. You can achieve this at build time, using preprocessor directives, or at run time, by using the <xref:System.OperatingSystem?displayProperty=nameWithType> methods:

- Add a `#if` [preprocessor directive](../csharp/language-reference/preprocessor-directives/preprocessor-if.md) around platform-specific API calls:

  ```csharp
  #if NET50_WINDOWS
      Console.Beep(261, 1000);
  #endif
  ```

- Check the current operating system using one of the <xref:System.OperatingSystem?displayProperty=nameWithType> methods before calling a platform-specific API. You can use these methods in a conditional `if` statement:

  ```csharp
  public void PlayCMajor()
  {
      if (OperatingSystem.IsWindows())
      {
          Console.Beep(261, 1000);
      }
  }
  ```

  ...or as an argument to <xref:System.Debug.Assert(System.Boolean?displayProperty=nameWithType)>:

  ```csharp
  public void PlayCMajor()
  {
      Debug.Assert(OperatingSystem.IsWindows());
      Console.Beep(261, 1000);
  }
  ```

  Use <xref:System.Debug.Assert(System.Boolean?displayProperty=nameWithType)> when you want the checks to be trimmed out of release builds.

You can also mark your API as platform-specific, in which case the burden of checking requirements falls on your callers. You can mark specific methods or types or an entire assembly.

```csharp
[SupportedOSPlatform("windows")]
public void PlayCMajor ()
{
    Console.Beep(261, 1000);
}
```

If you don't want to fix all your call sites, you can choose one of the following options to suppress the warning:

- To suppress rule CA1416, you can do so using `#pragma` or the [-nowarn](../../../../docs/csharp/language-reference/compiler-options/nowarn-compiler-option.md) compiler flag, or by [setting the rule's severity](../../../../docs/fundamentals/productivity/configure-code-analysis-rules.md#suppress-violations) to `none` in an .editorconfig file.

  ```csharp
  public void PlayCMajor ()
  { 
  #pragma warning disable CA1416
      Console.Beep(261, 1000);
  #pragma warning restore CA1416
  }
  ```

- To disable code analysis completely, set `EnableNETAnalyzers` to `false` in your project file. For more information, see [EnableNETAnalyzers](../../../../docs/core/project-sdk/msbuild-props.md#enablenetanalyzers).

#### Category

- Code analysis
- Core .NET libraries

#### Affected APIs

For Windows platform:

- All APIs listed at <https://github.com/dotnet/designs/blob/master/accepted/2020/windows-specific-apis/windows-specific-apis.md>.
- <xref:System.Security.Cryptography.DSAOpenSsl?displayProperty=fullName>
- <xref:System.Security.Cryptography.ECDiffieHellmanOpenSsl?displayProperty=fullName>
- <xref:System.Security.Cryptography.ECDsaOpenSsl?displayProperty=fullName>
- <xref:System.Security.Cryptography.RSAOpenSsl?displayProperty=fullName>

For Blazor WebAssembly platform:

- All APIs listed at <https://github.com/dotnet/runtime/issues/41087>.

<!--

#### Affected APIs

- ``

-->
