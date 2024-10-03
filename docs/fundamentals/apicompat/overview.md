---
title: API compatibility tools
description: Learn how .NET compatibility features, including MSBuild tasks and a command-line tool, can be used to develop consistent and well-formed multi-targeting libraries.
ms.date: 12/01/2023
ms.topic: overview
---

# API compatibility tools

Cross-platform compatibility has become a mainstream requirement for .NET library authors. However, without tooling to validate assemblies and packages, they might contain unintentional breaking changes. As a library author, you need to ensure that multi-targeted assemblies are compatible. For example, for a package that multi-targets for .NET 6 and .NET Standard 2.0, you must ensure that code compiled against the .NET Standard 2.0 binary can run against the .NET 6 binary.

You might think that a change is safe and compatible if source consuming that change continues to compile without changes. However, the changes can still cause problems at run time if the consumer wasn't recompiled. For example, adding an optional parameter to a method or changing the value of a constant can cause these kinds of compatibility issues.

The .NET SDK provides various ways you can compare versions built for different target frameworks. You can also validate a newer version against a baseline version to ensure no breaking changes have been introduced. Enable MSBuild tasks to validate your assemblies at compile time or your packages when you [pack](../../core/tools/dotnet-pack.md). Or, use the [Microsoft.DotNet.ApiCompat.Tool global tool](global-tool.md) to validate outside of MSBuild.

For more information about package validation, see [Package validation](package-validation/overview.md).Assembly validation should be used when your app isn't packable. For more information about assembly validation, see [Assembly validation](assembly-validation.md).

> [!NOTE]
> To run assembly validation as an MSBuild task, you must add a package reference to [Microsoft.DotNet.ApiCompat.Task](https://www.nuget.org/packages/Microsoft.DotNet.ApiCompat.Task). Similarly, you can also add a reference to this package when you want to test newer features that aren't yet available in the .NET SDK. For example, you can reference the 9.0.100-preview version of the [Microsoft.DotNet.ApiCompat.Task package](https://www.nuget.org/packages/Microsoft.DotNet.ApiCompat.Task) while using the .NET 8 SDK.

## Strict mode

By default, the validation performs *compatibility* checks. However, you can also opt in to *strict mode*. In strict mode, the validation performs *equality* checks. Equality means that no API additions or assembly changes, even compatible ones, have been made.

The use cases for strict mode include the following:

- Servicing, in which API additions are usually forbidden.
- For tracking API changes. The API compatibility functionality records all compatibility differences in the suppression file if you set [ApiCompatGenerateSuppressionFile](../../core/project-sdk/msbuild-props.md#apicompatgeneratesuppressionfile) to `true`.

To enable strict mode for the command-line tool, specify the `--strict-mode` option or one of the `--enable-strict*` options. To enable strict mode for the MSBuild tasks, add one or more of the following MSBuild properties to your project file:

- [ApiCompatStrictMode](../../core/project-sdk/msbuild-props.md#apicompatstrictmode)
- [EnableStrictModeForBaselineValidation](../../core/project-sdk/msbuild-props.md#enablestrictmodeforbaselinevalidation)
- [EnableStrictModeForCompatibleTfms](../../core/project-sdk/msbuild-props.md#enablestrictmodeforcompatibletfms)
- [EnableStrictModeForCompatibleFrameworksInPackage](../../core/project-sdk/msbuild-props.md#enablestrictmodeforcompatibleframeworksinpackage)
