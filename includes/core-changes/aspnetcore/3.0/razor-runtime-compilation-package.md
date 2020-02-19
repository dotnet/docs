### Razor: Runtime compilation moved to a package

Support for runtime compilation of Razor views and Razor Pages has moved to a separate package.

#### Version introduced

3.0

#### Old behavior

Runtime compilation is available without needing additional packages.

#### New behavior

The functionality has been moved to the [Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation](https://www.nuget.org/packages/Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation/) package.

The following APIs were previously available in `Microsoft.AspNetCore.Mvc.Razor.RazorViewEngineOptions` to support runtime compilation. The APIs are now available via
`Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation.MvcRazorRuntimeCompilationOptions`.

- `RazorViewEngineOptions.FileProviders` is now `MvcRazorRuntimeCompilationOptions.FileProviders`
- `RazorViewEngineOptions.AdditionalCompilationReferences` is now `MvcRazorRuntimeCompilationOptions.AdditionalReferencePaths`

In addition, `Microsoft.AspNetCore.Mvc.Razor.RazorViewEngineOptions.AllowRecompilingViewsOnFileChange` has been removed. Recompilation on file changes is enabled by default by referencing the `Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation` package.

#### Reason for change

This change was necessary to remove the ASP.NET Core shared framework dependency on Roslyn.

#### Recommended action

Apps that require runtime compilation or recompilation of Razor files should take the following steps:

1. Add a reference to the `Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation` package.
1. Update the project's `Startup.ConfigureServices` method to include a call to `AddRazorRuntimeCompilation`. For example:

    ```csharp
    services.AddMvc()
        .AddRazorRuntimeCompilation();
    ```

#### Category

ASP.NET Core

#### Affected APIs

<xref:Microsoft.AspNetCore.Mvc.Razor.RazorViewEngineOptions?displayProperty=fullName>

<!--

#### Affected APIs

`T:Microsoft.AspNetCore.Mvc.Razor.RazorViewEngineOptions`

-->
