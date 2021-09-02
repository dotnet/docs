---
title: "Preview-to-preview breaking change: Implicit namespaces disabled by default"
description: Learn about the preview-to-preview breaking change in .NET 6 where the implicit namespaces feature is disabled by default in C# projects.
ms.date: 09/02/2021
---
# Implicit namespaces disabled by default

C# 10.0 introduced [global namespace](../../../../csharp/language-reference/keywords/using-directive.md#global-modifier) support for C# projects. In Preview 7, [the .NET SDK implicitly added global namespaces](implicit-namespaces.md) to .NET projects, and the feature was enabled by default. In .NET 6 RC 1, implicit namespaces are disabled by default, and some of the associated MSBuild property and item names have changed. You may need to re-enable the feature or explicitly include namespaces that your project depends on.

## Version introduced

.NET 6 RC 1

## Old behavior

In .NET 6 Preview 7, the .NET SDK implicitly includes a set of default namespaces for C# projects that target .NET 6 or later and that use one of the following SDKs:

- Microsoft.NET.Sdk
- Microsoft.NET.Sdk.Web
- Microsoft.NET.Sdk.Worker

In addition, you could:

- Disable the feature globally using the `DisableImplicitNamespaceImports` MSBuild property, or on an SDK-specific basis using the `DisableImplicitNamespaceImports_DotNet`, `DisableImplicitNamespaceImports_Web`, and `DisableImplicitNamespaceImports_Worker` properties.
- Import specific namespaces using the `Import` item type.

## New behavior

Starting in .NET 6 RC 1, no implicit namespaces are included, by default. However, you can enable the feature in your C# project by setting the [`ImplicitUsings` MSBuild property](../../../project-sdk/msbuild-props.md#implicitusings) to `true` or `enable`.

If you enable the feature, the default namespaces are included by adding `global using` directives to a generated file in the project's *obj* directory. The default namespaces are as follows:

| SDK | Default namespaces |
| - | - |
| Microsoft.NET.Sdk | <xref:System><br/><xref:System.Collections.Generic?displayProperty=fullName><br/><xref:System.IO?displayProperty=fullName><br/><xref:System.Linq?displayProperty=fullName><br/><xref:System.Net.Http?displayProperty=fullName><br/><xref:System.Threading?displayProperty=fullName><br/><xref:System.Threading.Tasks?displayProperty=fullName> |
| Microsoft.NET.Sdk.Web | <xref:System.Net.Http.Json?displayProperty=fullName><br/><xref:Microsoft.AspNetCore.Builder?displayProperty=fullName><br/><xref:Microsoft.AspNetCore.Hosting?displayProperty=fullName><br/><xref:Microsoft.AspNetCore.Http?displayProperty=fullName><br/><xref:Microsoft.AspNetCore.Routing?displayProperty=fullName><br/><xref:Microsoft.Extensions.Configuration?displayProperty=fullName><br/><xref:Microsoft.Extensions.DependencyInjection?displayProperty=fullName><br/><xref:Microsoft.Extensions.Hosting?displayProperty=fullName><br/><xref:Microsoft.Extensions.Logging?displayProperty=fullName> |
| Microsoft.NET.Sdk.Worker | <xref:Microsoft.Extensions.Configuration?displayProperty=fullName><br/><xref:Microsoft.Extensions.DependencyInjection?displayProperty=fullName><br/><xref:Microsoft.Extensions.Hosting?displayProperty=fullName><br/><xref:Microsoft.Extensions.Logging?displayProperty=fullName> |

In addition, for C# projects:

- The MSBuild property used to enable or disable the feature is renamed to `ImplicitUsings`, and the SDK-specific properties, such as `DisableImplicitNamespaceImports_DotNet`, are no longer valid. The feature is either completely enabled or completely disabled.
- The item type to include a specific namespaces is renamed to `Using`. For Visual Basic projects, you can continue to use the `Import` item type.

## Change category

This change may affect [*source compatibility*](../../categories.md#source-compatibility).

## Reason for change

The [Preview 7 breaking change](implicit-namespaces.md) caused a few issues in some important scenarios. We are changing the feature to mitigate the issues and generally improve its usability.

## Recommended action

If you relied on namespaces being implicitly included in your C# project, you can:

- Re-enable implicit namespaces by setting the [`ImplicitUsings` MSBuild property](../../../project-sdk/msbuild-props.md#implicitusings) to `true` or `enable`.
- Add `using` directives to your source files.
- Include the namespaces globally by adding `Using` items to your project file (or renaming your existing `Import` items). For example:

  ```xml
  <ItemGroup>
    <Using Include="System.IO.Pipes" />
  </ItemGroup>
  ```

## Affected APIs

N/A
