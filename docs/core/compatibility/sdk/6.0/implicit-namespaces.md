---
title: "Breaking change: Implicit `global using` directives in C# projects"
description: Learn about the breaking change in .NET 6 where the .NET SDK implicitly includes some namespaces globally in C# projects.
ms.date: 07/20/2021
---
# Implicit `global using` directives in C# projects

.NET 6 introduces implicit namespace support for C# projects. To reduce the amount of `using` directives boilerplate in .NET C# project templates, namespaces are implicitly included by utilizing the `global using` feature introduced in C# 10.

The implicit namespace feature is enabled by default for C# projects that target the `net6.0` TFM or higher and use the Microsoft.NET.Sdk, Microsoft.NET.Sdk.Web, or Microsoft.NET.Sdk.Worker SDK. The feature generates a source file that's passed to the compiler and contains `global using` directives for the default namespaces.

If your project uses a C# version less than 10, you must explicitly [disable this feature](#recommended-action).

> [!IMPORTANT]
> The implicit `global using` directives feature was [changed in .NET 6 RC1](implicit-namespaces-rc1.md), such that this is only a breaking change for the Preview 7 version of .NET 6.

## Version introduced

.NET 6 Preview 7

## Old behavior

No implicit `global using` directives are added to C# projects and there are no type conflicts.

## New behavior

The .NET SDK implicitly includes a set of default namespaces for C# projects that target .NET 6 or later and that use one of the following SDKs:

- Microsoft.NET.Sdk
- Microsoft.NET.Sdk.Web
- Microsoft.NET.Sdk.Worker

The default namespaces are included by adding `global using` directives to a generated file in the project's *obj* directory. The default namespaces are as follows:

| SDK | Default namespaces |
| - | - |
| Microsoft.NET.Sdk | <xref:System><br/><xref:System.Collections.Generic?displayProperty=fullName><br/><xref:System.IO?displayProperty=fullName><br/><xref:System.Linq?displayProperty=fullName><br/><xref:System.Net.Http?displayProperty=fullName><br/><xref:System.Threading?displayProperty=fullName><br/><xref:System.Threading.Tasks?displayProperty=fullName> |
| Microsoft.NET.Sdk.Web | <xref:System.Net.Http.Json?displayProperty=fullName><br/><xref:Microsoft.AspNetCore.Builder?displayProperty=fullName><br/><xref:Microsoft.AspNetCore.Hosting?displayProperty=fullName><br/><xref:Microsoft.AspNetCore.Http?displayProperty=fullName><br/><xref:Microsoft.AspNetCore.Routing?displayProperty=fullName><br/><xref:Microsoft.Extensions.Configuration?displayProperty=fullName><br/><xref:Microsoft.Extensions.DependencyInjection?displayProperty=fullName><br/><xref:Microsoft.Extensions.Hosting?displayProperty=fullName><br/><xref:Microsoft.Extensions.Logging?displayProperty=fullName> |
| Microsoft.NET.Sdk.Worker | <xref:Microsoft.Extensions.Configuration?displayProperty=fullName><br/><xref:Microsoft.Extensions.DependencyInjection?displayProperty=fullName><br/><xref:Microsoft.Extensions.Hosting?displayProperty=fullName><br/><xref:Microsoft.Extensions.Logging?displayProperty=fullName> |

These implicit namespaces may cause type conflicts. For example, if you're authoring an MSBuild task, and thus deriving from the abstract <xref:Microsoft.Build.Utilities.Task?displayProperty=fullName> class, you'll see a conflict with the <xref:System.Threading.Tasks.Task?displayProperty=fullName> class. This conflict occurs because the <xref:System.Threading.Tasks?displayProperty=fullName> namespace is implicitly included. The error looks similar to:

```txt
... error CS0104: 'Task' is an ambiguous reference between 'Microsoft.Build.Utilities.Task' and 'System.Threading.Tasks.Task'
... error CS0115: 'SomeTask.Execute()': no suitable method found to override
```

## Change category

This change may affect [*source compatibility*](../../categories.md#source-compatibility) if there are type conflicts to resolve.

## Reason for change

This change was made to reduce the number of boilerplate `using` directives that appear at the top of C# source files in most projects.

## Recommended action

For most users, you need take no action. However, this change can cause type-name conflicts with the namespaces that are implicitly included. If that happens, modify the list of `global using` directives or fully qualify your type references. You can modify the list of `global using` directives in several ways:

- Disable the feature completely by setting `<DisableImplicitNamespaceImports>` to `true` in the project file. For more information, see [DisableImplicitNamespaceImports](../../../project-sdk/msbuild-props.md#disableimplicitnamespaceimports).
- Disable a set of implicit `global using` directives added by an SDK by setting the `DisableImplicitNamespaceImports_DotNet`, `DisableImplicitNamespaceImports_Web`, or `DisableImplicitNamespaceImports_Worker` property to `true` in the project file. For more information, see [DisableImplicitNamespaceImports](../../../project-sdk/msbuild-props.md#disableimplicitnamespaceimports).
- Add or remove individual namespaces by modifying the `<Import>` item group in the project file. For example:

  ```xml
  <ItemGroup>
    <Import Remove="System.Net.Http" />
    <Import Include="System.IO.Pipes" />
  </ItemGroup>
  ```

## Affected APIs

N/A

<!--

### Affected APIs

Not detectable via API analysis.

### Category

SDK

-->
