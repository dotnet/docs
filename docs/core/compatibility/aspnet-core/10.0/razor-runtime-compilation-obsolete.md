---
title: "Breaking change: Razor runtime compilation is obsolete"
description: Learn about the breaking change in ASP.NET Core 10.0 where Razor runtime compilation APIs have been marked obsolete.
ms.date: 08/08/2025
---

# Razor runtime compilation is obsolete

Razor runtime compilation is obsolete and is not recommended for production scenarios. For production scenarios, use the default build time compilation. For development scenarios, use Hot Reload instead.

## Version introduced

.NET 10 Preview 7

## Previous behavior

Developers could use [Razor runtime compilation](/aspnet/core/mvc/views/view-compilation) to recompile `.cshtml` files while the application is running. This is useful for development time so you don't need to restart the application for changes to take effect.

## New behavior

Using the APIs listed below will produce a compiler warning with diagnostic ID `ASPDEPR003`:

> warning ASPDEPR003: Razor runtime compilation is obsolete and is not recommended for production scenarios. For production scenarios, use the default build time compilation. For development scenarios, use Hot Reload instead. For more information, visit <https://aka.ms/aspnet/deprecate/003>.

## Type of breaking change

This change affects [source compatibility](../../categories.md#source-compatibility).

## Reason for change

Razor Runtime compilation has been replaced by Hot Reload which has been the recommended approach for a few years now. This change makes it clearer that Razor Runtime compilation is not getting support for new features and should no longer be used.

## Recommended action

Remove calls to `.AddRazorRuntimeCompilation()` and use Hot Reload.

### Before

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddMvc()
        .AddRazorRuntimeCompilation();
}
```

### After

Remove the call to `AddRazorRuntimeCompilation()`:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddMvc();
}
```

For development scenarios, use [Hot Reload](/dotnet/core/tools/dotnet-watch) instead:

```console
dotnet watch
```

## Affected APIs

- <xref:Microsoft.AspNetCore.Mvc.ApplicationParts.AssemblyPartExtensions?displayProperty=fullName>
- <xref:Microsoft.Extensions.DependencyInjection.RazorRuntimeCompilationMvcBuilderExtensions.AddRazorRuntimeCompilation%2A?displayProperty=fullName>
- <xref:Microsoft.Extensions.DependencyInjection.RazorRuntimeCompilationMvcCoreBuilderExtensions.AddRazorRuntimeCompilation%2A?displayProperty=fullName>
- <xref:Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation.FileProviderRazorProjectItem?displayProperty=fullName>
- <xref:Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation.MvcRazorRuntimeCompilationOptions?displayProperty=fullName>
