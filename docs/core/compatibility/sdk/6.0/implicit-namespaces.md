---
title: "Breaking change: Implicit namespaces in C# projects"
description: Learn about the breaking change in .NET 6 where the .NET SDK implicitly includes some namespaces globally in C# projects.
ms.date: 07/20/2021
---
# Implicit namespaces in C# projects

.NET 6 introduces implicit namespace support for C# projects. To reduce the amount of `using` directives boilerplate in .NET C# project templates, namespaces are implicitly included by utilizing the `global using` feature introduced in C# 10.

The implicit namespace feature is enabled by default for C# projects that target the `net6.0` TFM or higher and use Microsoft.NET.Sdk, Microsoft.NET.Sdk.Web, or Microsoft.NET.Sdk.Worker SDK. The feature generates a source file that's passed to the compiler and contains `global using` directives for the default namespaces.

If your project uses a C# version less than 10, you must explicitly [disable this feature](#recommended-action).

## Version introduced

.NET 6 Preview 7

## Old behavior

No implicit namespaces are added to C# projects.

## New behavior

The .NET SDK implicitly includes a set of default namespaces for C# projects that target .NET 6 or later and that use one of the following SDKs:

- Microsoft.NET.Sdk
- Microsoft.NET.Sdk.Web
- Microsoft.NET.Sdk.Worker

The default namespaces are included by adding `global using` directives to a generated file in the project's *obj* directory. The default namespaces are as follows:

| SDK | Default namespaces |
| - | - |
| Microsoft.NET.Sdk | System<br/>System.Collections.Generic<br/>System.IO<br/>System.Linq<br/>System.Net.Http<br/>System.Threading<br/>System.Threading.Tasks |
| Microsoft.NET.Sdk.Web | System.Net.Http.Json<br/>Microsoft.AspNetCore.Builder<br/>Microsoft.AspNetCore.Hosting<br/>Microsoft.AspNetCore.Http<br/>Microsoft.AspNetCore.Routing<br/>Microsoft.Extensions.Configuration<br/>Microsoft.Extensions.DependencyInjection<br/>Microsoft.Extensions.Hosting<br/>Microsoft.Extensions.Logging |
| Microsoft.NET.Sdk.Worker | Microsoft.Extensions.Configuration<br/>Microsoft.Extensions.DependencyInjection<br/>Microsoft.Extensions.Hosting<br/>Microsoft.Extensions.Logging |

## Change category

This change may affect *source compatibility* if there are type conflicts to resolve.

## Reason for change

This change was made to reduce the number of boilerplate `using` directives that appear at the top of C# source files in most projects.

## Recommended action

For most users, you need take no action. However, this change can cause type-name conflicts with the namespaces that are implicitly included. If that happens, modify the list of implicit namespaces or fully qualify your type references. You can modify the list of implicit namespaces in several ways:

- Disable the feature completely by setting `<DisableImplicitNamespaceImports>` to `true` in the project file. For more information, see [DisableImplicitNamespaceImports](../../../project-sdk/msbuild-props.md#disableimplicitnamespaceimports).
- Disable a set of implicit namespaces added by an SDK by setting the `DisableImplicitNamespaceImports_DotNet`, `DisableImplicitNamespaceImports_Web`, or `DisableImplicitNamespaceImports_Worker` property to `true` in the project file. For more information, see [DisableImplicitNamespaceImports](../../../project-sdk/msbuild-props.md#disableimplicitnamespaceimports).
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
