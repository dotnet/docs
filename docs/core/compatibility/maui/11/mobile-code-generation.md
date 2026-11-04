---
title: "Breaking change - Code generation on mobile changes from Mono to CoreCLR"
description: "Learn about the breaking change in .NET 11 where code generation on mobile changes from Mono to CoreCLR."
ms.date: 10/21/2026
ai-usage: ai-generated
ms.custom: https://github.com/dotnet/docs/issues/56478
---

# Code generation on mobile changes from Mono to CoreCLR

.NET 11 mobile apps can use the CoreCLR JIT, ReadyToRun (R2R), and the CoreCLR
interpreter. The available modes still depend on the target and build
configuration.

## Version introduced

.NET 11

## Previous behavior

.NET 10 mobile apps could use the Mono JIT, Mono AOT, Mono AOT with LLVM, and the
Mono interpreter. The available modes depended on the target and build
configuration.

Some apps used the Mono interpreter for only a selected list of assemblies.
This helped those apps balance compatibility and speed.

## New behavior

.NET 11 mobile apps can use the CoreCLR JIT, ReadyToRun (R2R), and the CoreCLR
interpreter. The available modes still depend on the target and build
configuration.

R2R is an AOT technology, but it is not a new name for Mono AOT. It keeps IL
and metadata in the app and can use the JIT or interpreter when the target
allows it.

Android Release builds use CoreCLR R2R to precompile part of the app and use the
JIT for the rest. `MauiEnableFullReadyToRun=true` applies R2R to the entire app.
The app can still use the JIT at run time for dynamic behavior. Debug builds use
less R2R, so most of the app runs with the JIT.

Apple Release builds precompile the entire app with R2R and can use the
interpreter at run time for dynamic behavior. Debug builds use less R2R, so most
of the app runs with the interpreter.

[NativeAOT](/dotnet/maui/deployment/nativeaot?view=net-maui-11.0)
is another code generation option on mobile platforms. It is different from
both Mono AOT and CoreCLR R2R. Android NativeAOT is experimental in .NET 11.

## Type of breaking change

This change can affect [source compatibility](../../categories.md#source-compatibility) and [behavior](../../categories.md#behavioral-change).

## Reason for change

CoreCLR uses its own compiler and execution model. Mono AOT settings don't
control CoreCLR R2R.

## Recommended action

- Use the R2R defaults from the mobile workload.
- Don't try to translate each Mono AOT setting into an R2R setting.
- Use `MauiEnableFullReadyToRun` only after you measure the app.
- Measure startup time, speed, memory use, and app size.
- If you are considering NativeAOT, review the
  [.NET MAUI Native AOT deployment guidance](/dotnet/maui/deployment/nativeaot?view=net-maui-11.0)
  because it is a separate deployment model with different restrictions.
  Treat Android NativeAOT as experimental in .NET 11.

## Affected APIs

No managed APIs are removed. The following MSBuild properties and items no
longer provide their Mono code-generation effect when the app uses CoreCLR:

- **Android:** `RunAOTCompilation`, `AotAssemblies`, `EnableLLVM`,
  `AndroidEnableProfiledAot`, `AndroidAotMode`,
  `AndroidAotAdditionalArguments`, `AndroidExtraAotOptions`,
  `@(AndroidAotProfile)`, `AndroidAotEnableLazyLoad`,
  `AndroidUseInterpreter`, `UseInterpreter`, and
  `AndroidEnableMarshalMethods`.
- **iOS, tvOS, and Mac Catalyst:** `UseInterpreter`, `MtouchInterpreter`,
  `MtouchUseLlvm`, `MtouchFloat32`, `MonoUseCompressedInterfaceBitmap`,
  `RunAotCompilation`, `AotAssemblies`, and
  `AotCompileMaxDegreeOfParallelism`.

These settings configure Mono AOT compilation, LLVM, interpreter selection,
AOT inputs, or generated marshal methods. They don't configure the CoreCLR
ReadyToRun pipeline. For the detailed migration and build-diagnostic behavior,
see
[Mono project properties no longer configure mobile apps](https://github.com/dotnet/docs/issues/56477).
