---
title: "Breaking change: Razor run-time compilation is obsolete"
description: Learn about the breaking change in ASP.NET Core 10.0 where Razor run-time compilation APIs have been marked obsolete.
ms.date: 08/08/2025
---

# Razor run-time compilation is obsolete

Razor run-time compilation is obsolete and is not recommended for production scenarios. For production scenarios, use the default build-time compilation. For development scenarios, use Hot Reload instead.

## Version introduced

.NET 10 Preview 7

## Previous behavior

Previously, you could use [Razor run-time compilation](/aspnet/core/mvc/views/view-compilation) to recompile `.cshtml` files while the application was running. This meant you didn't need to restart the application for changes to take effect.

## New behavior

Starting in .NET 10, use of the [affected APIs](#affected-apis) produces a compiler warning with diagnostic ID `ASPDEPR003`:

> warning ASPDEPR003: Razor run-time compilation is obsolete and is not recommended for production scenarios. For production scenarios, use the default build time compilation. For development scenarios, use Hot Reload instead. For more information, visit <https://aka.ms/aspnet/deprecate/003>.

## Type of breaking change

This change can affect [source compatibility](../../categories.md#source-compatibility).

## Reason for change

Razor run-time compilation has been replaced by Hot Reload, which has been the recommended approach for a few years now. This change makes it clearer that Razor run-time compilation doesn't get support for new features and should no longer be used.

## Recommended action

Remove calls to <xref:Microsoft.Extensions.DependencyInjection.RazorRuntimeCompilationMvcBuilderExtensions.AddRazorRuntimeCompilation%2A> and use Hot Reload instead.

## Affected APIs

- <xref:Microsoft.AspNetCore.Mvc.ApplicationParts.AssemblyPartExtensions?displayProperty=fullName>
- <xref:Microsoft.Extensions.DependencyInjection.RazorRuntimeCompilationMvcBuilderExtensions.AddRazorRuntimeCompilation%2A?displayProperty=fullName>
- <xref:Microsoft.Extensions.DependencyInjection.RazorRuntimeCompilationMvcCoreBuilderExtensions.AddRazorRuntimeCompilation%2A?displayProperty=fullName>
- <xref:Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation.FileProviderRazorProjectItem?displayProperty=fullName>
- <xref:Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation.MvcRazorRuntimeCompilationOptions?displayProperty=fullName>
