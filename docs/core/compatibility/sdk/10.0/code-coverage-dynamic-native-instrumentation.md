---
title: "Breaking change - Code coverage EnableDynamicNativeInstrumentation defaults to false"
description: "Learn about the breaking change in .NET 10 where dynamic native instrumentation is disabled by default when collecting code coverage."
ms.date: 11/05/2025
ai-usage: ai-assisted
ms.custom: https://github.com/dotnet/docs/issues/50950
---

# Code coverage EnableDynamicNativeInstrumentation defaults to false

Running `dotnet test --collect:"Code Coverage"` now disables dynamic native instrumentation by default. This change affects how code coverage is collected from native code. It doesn't affect how code coverage is collected from managed code.

## Version introduced

.NET 10 GA

## Previous behavior

Dynamic native instrumentation was enabled by default, and used a fallback for native modules when static native instrumentation couldn't be used. As described in [Static and dynamic native instrumentation](/visualstudio/test/customizing-code-coverage-analysis?view=vs-2022#static-and-dynamic-native-instrumentation).

```bash
dotnet test --collect:"Code Coverage"
# Dynamic native instrumentation was enabled by default
```

## New behavior

Dynamic native instrumentation is disabled by default. The `<EnableDynamicNativeInstrumentation>false</EnableDynamicNativeInstrumentation>` option is set by default from `dotnet test` and `vstest`. If you explicitly set the option in a runsettings file, it won't be overridden.

```bash
dotnet test --collect:"Code Coverage"
# Dynamic native instrumentation is now disabled by default
```

When you re-enable dynamic native instrumentation, it might fail with "The code execution cannot proceed because covrun64.dll was not found." This error can also happen for `covrun32.dll` in a 32-bit process.

## Type of breaking change

This is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

Dynamic native instrumentation was enabled by default to maintain backwards compatibility in `dotnet test`. However, its way of injecting DLLs into the process isn't standard. With [security hardening changes](https://github.com/dotnet/runtime/pull/112359) in .NET 10 runtime, it fails to find the linked DLL, causing process crash with error [dotnet/sdk#50950](https://github.com/dotnet/sdk/issues/50950).

The error might not be visible in non-interactive sessions or in the command line, but the process crash happens.

Dynamic native instrumentation is already disabled by default by `dotnet-coverage`, an alternative way to collect code coverage using the same underlying tools. It's also disabled by default for solutions in Visual Studio that don't have native projects.

## Recommended action

Users who collect coverage on solutions that don't have any native components shouldn't be affected. They might observe increased performance when collecting coverage.

Users who collect coverage on solutions that include native components, such as C++ projects, and wish to re-enable dynamic native instrumentation should remain on .NET 9, or disable collecting code coverage until the problem is resolved.

Users who wish to globally opt out from this new default can set the `VSTEST_DISABLE_DYNAMICNATIVE_CODECOVERAGE_DEFAULT_SETTING=1` environment variable.

## Affected APIs

None.
