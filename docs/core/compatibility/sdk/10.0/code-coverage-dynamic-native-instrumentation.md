---
title: "Breaking change - Code coverage EnableDynamicNativeInstrumentation defaults to false"
description: "Learn about the breaking change in .NET 10 where dynamic native instrumentation is disabled by default when collecting code coverage."
ms.date: 11/05/2025
ai-usage: ai-assisted
ms.custom: https://github.com/dotnet/docs/issues/49376
---

# Code coverage EnableDynamicNativeInstrumentation defaults to false

Running `dotnet test --collect:"Code Coverage"` now disables dynamic native instrumentation by default. This change affects how code coverage is collected from native code. It doesn't affect how code coverage is collected from managed code.

## Version introduced

.NET 10 GA

## Previous behavior

Previously, dynamic native instrumentation was enabled by default and used a fallback for native modules when static native instrumentation couldn't be used. This behavior is described in [Static and dynamic native instrumentation](/visualstudio/test/customizing-code-coverage-analysis?view=vs-2022#static-and-dynamic-native-instrumentation).

```bash
dotnet test --collect:"Code Coverage"
# Dynamic native instrumentation was enabled by default
```

## New behavior

Starting in .NET 10, dynamic native instrumentation is disabled by default. The `<EnableDynamicNativeInstrumentation>false</EnableDynamicNativeInstrumentation>` option is set by default from `dotnet test` and `vstest`. If you explicitly set the option in a *runsettings* file, it isn't overridden.

```bash
dotnet test --collect:"Code Coverage"
# Dynamic native instrumentation is now disabled by default
```

You can re-enable dynamic native instrumentation by setting `<EnableDynamicNativeInstrumentation>true</EnableDynamicNativeInstrumentation>` in your *runsettings* file. However, when you do so, it might fail with "The code execution cannot proceed because covrun64.dll was not found." This error can also happen for `covrun32.dll` in a 32-bit process.

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

Dynamic native instrumentation was enabled by default to maintain backwards compatibility in `dotnet test`. However, its way of injecting DLLs into the process isn't standard. With [security hardening changes](https://github.com/dotnet/runtime/pull/112359) in the .NET 10 runtime, it fails to find the linked DLL, causing the process to [crash with error](https://github.com/dotnet/sdk/issues/50950). The error might not be visible in non-interactive sessions or in the command line, but the process does crash.

Dynamic native instrumentation is already disabled by default by `dotnet-coverage`, which is an alternative way to collect code coverage using the same underlying tools. It's also disabled by default for solutions in Visual Studio that don't have native projects.

## Recommended action

If you collect coverage on solutions that don't have any native components, you shouldn't be affected. However, you might observe increased performance when collecting coverage.

If you collect coverage on solutions that include native components, such as C++ projects, you have the following options:

- Configure your projects to use [static native instrumentation](/visualstudio/test/customizing-code-coverage-analysis#static-and-dynamic-native-instrumentation)

  OR

- Update to Microsoft.CodeCoverage 18.0.1 and enable dynamic native instrumentation:

  - Add the setting `<EnableDynamicNativeInstrumentation>true</EnableDynamicNativeInstrumentation>` to your *runsettings* file.
  - Globally opt out from this new default by setting the `VSTEST_DISABLE_DYNAMICNATIVE_CODECOVERAGE_DEFAULT_SETTING=1` environment variable.

  Similarly, when collecting code coverage with `vstest.console`, VSTest version 18.0.1 and newer is required to successfully collect dynamic native coverage on systems that have the .NET 10 SDK installed.

## Affected APIs

None.
