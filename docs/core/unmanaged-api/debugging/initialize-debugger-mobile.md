---
title: How to initialize a custom debugger on mobile platforms
description: Learn how to initialize a custom ICorDebug-based debugger for .NET 11 mobile apps that use CoreCLR.
ms.date: 09/22/2026
ms.topic: how-to
ai-usage: ai-generated
---

# How to initialize a custom debugger on mobile platforms

Custom .NET debuggers are typically hosted in a separate process. Mobile platforms restrict or prohibit creating such processes, so the target-side custom debugger component must instead be loaded into the application process.

This article applies only to debugger initialization on mobile platforms (iOS and Android) in .NET 11. It does not apply to NativeAOT.

## Implement and deploy the target-side component

The target-side debugger component should be implemented as a profiler dynamic library with a `DllGetClassObject` entry point. For example implementations, see the [.NET profiler samples](https://github.com/dotnet/samples/tree/main/core/profiling).

It should be deployed together with libmscordbi and libmscordaccore dynamic libraries as part of the application in compliance with the target platform's native library packaging, code-signing, and loading requirements.

## Load the target-side component at startup

To have CoreCLR load your component as a profiler, supply the following environment settings before the runtime starts:

| Environment variable | Value |
| --- | --- |
| `DOTNET_ENABLE_PROFILING` | `1` |
| `DOTNET_PROFILER` | `{<profiler-CLSID>}` |
| `DOTNET_PROFILER_PATH` | `<component-path>` |

Replace `<profiler-CLSID>` with your component's profiler GUID, and keep the enclosing braces. Replace `<component-path>` with the path to the native component in the target app's deployment.

For details about these settings, see [Runtime configuration options for debugging and profiling](../../runtime-config/debugging-profiling.md).

Use your platform's app-launch configuration to supply these settings.

> [!NOTE]
> While this procedure uses the profiler mechanism to initialize a debugger, it doesn't establish general-purpose support for third-party profilers on mobile platforms.

## Create the debugger interface

In the target-side component, perform the following initialization:

1. Load `libmscordbi` dynamic library and call its `CoreCLRCreateCordbObjectEx` export. Query the returned object for `ICorDebug`.
2. Call [ICorDebug::Initialize](icordebug/icordebug-initialize-method.md), and register your managed-event handler with [ICorDebug::SetManagedHandler](icordebug/icordebug-setmanagedhandler-method.md).
3. Attach to the app with [ICorDebug::DebugActiveProcess](icordebug/icordebug-debugactiveprocess-method.md).

To avoid missing early module-load and startup events, coordinate attachment with runtime startup so that managed execution doesn't proceed before `DebugActiveProcess` completes.

After initialization, use the `ICorDebug` debugger interfaces as on other Unix platforms.
