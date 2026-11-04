---
title: "Breaking change - Mono project properties no longer configure mobile apps"
description: "Learn about the breaking change in .NET 11 where Mono project properties no longer configure mobile apps."
ms.date: 10/21/2026
ai-usage: ai-generated
ms.custom: https://github.com/dotnet/docs/issues/56477
---

# Mono project properties no longer configure mobile apps

In .NET 11, Mono project properties no longer configure mobile apps.

## Version introduced

.NET 11

## Previous behavior

The following Android settings controlled Mono AOT, LLVM, profiling, or the
Mono interpreter:

- `RunAOTCompilation`
- `AotAssemblies`
- `EnableLLVM`
- `AndroidEnableProfiledAot`
- `AndroidAotMode`
- `AndroidAotAdditionalArguments`
- `AndroidExtraAotOptions`
- `@(AndroidAotProfile)`
- `AndroidAotEnableLazyLoad`
- `AndroidUseInterpreter`
- `UseInterpreter`

`AndroidEnableMarshalMethods` isn't Mono-specific, but .NET 10 Android projects
could use it with the previous code-generation pipeline.

The following Apple settings controlled the Mono interpreter, SGen garbage
collector (GC), LLVM, float handling, interface layout, or Mono AOT:

- `UseInterpreter`
- `MtouchInterpreter`
- `EnableSGenConc`
- `MtouchEnableSGenConc`
- `MtouchUseLlvm`
- `MtouchFloat32`
- `MonoUseCompressedInterfaceBitmap`
- `RunAotCompilation`
- `AotAssemblies`
- `AotCompileMaxDegreeOfParallelism`

## New behavior

The Mono-specific settings don't provide their previous behavior on CoreCLR.
Some settings have no effect. Others cause a build warning or error.

`AndroidEnableMarshalMethods` can't be combined with ReadyToRun. This
combination causes build error `XA1049`.

## Type of breaking change

This change can affect [source compatibility](../../categories.md#source-compatibility) and [behavior](../../categories.md#behavioral-change).

## Reason for change

Most of these settings configure Mono components that aren't used by CoreCLR.
`AndroidEnableMarshalMethods` is included because its previous build
configuration isn't compatible with the CoreCLR ReadyToRun path.

## Recommended action

- Remove the Mono-specific settings from .NET 11 projects, or set them only for
  .NET 10.
- Don't enable `AndroidEnableMarshalMethods` in a CoreCLR ReadyToRun build.
- Retest the app's performance and memory use.

## Affected APIs

None. This change affects MSBuild properties and items.
