---
title: Known trimming incompatibilities
description: Identify patterns and frameworks that are known to have problems with trimming
author: agocke
ms.author: angocke
ms.date: 10/08/2021
---
# Known trimming incompatibilities

There are some patterns which are currently known to be incompatible with trimming. Some of these patterns may become compatible as tooling improves, or libraries make modifications to become trimming compatible.

## Built-in COM marshalling

Alternative: [COM Wrappers](../../../standard/native-interop/com-wrappers.md)

Automatic [COM marshalling](../../../standard/native-interop/cominterop.md) has been built-in to .NET since .NET Framework 1.0. It uses runtime code analysis to automatically convert between native COM objects and managed .NET objects. Unfortunately, trimming analysis cannot always predict what .NET code will need to be preserved for automatic COM marshalling. However, if [COM Wrappers](../../../standard/native-interop/com-wrappers.md) are used instead, trimming analysis can guarantee that all used code will be correctly preserved.

## WPF

The WPF framework makes substantial use of reflection and some features are heavily reliant on run-time code inspection. In .NET 6 it is not possible for trimming analysis to preserve all necessary code for WPF applications. Unfortunately, almost no WPF apps are runnable after trimming, so trimming support for WPF has been disabled in the .NET 6 SDK.

## WinForms

The WinForms framework makes minimal use of reflection, but is heavily reliant on built-in COM marshalling. In .NET 6 it has not yet been converted to use ComWrappers. Unfortunately, almost no WinForms apps are runnable without built-in COM marshalling, so trimming support for WinForms has been disabled in the .NET 6 SDK.

## Reflection-based Serializers

Alternative: Reflection-free serializers, like source-generated [System.Text.Json](../../../standard/serialization/system-text-json-source-generation.md).

Many uses of reflection can be made trimming-compatible, as described in [Introduction to trim warnings](fixing-warnings.md). However, serializers tend to have very complex uses of reflection. Many of these uses cannot be made analyzable at build-time. Unfortunately, the best option is often to rewrite the system to use source generation instead.

## Dynamic Assembly Loading & Execution

This is a common problem for systems which support plugins or extensions, usually through APIs like <xref:System.Reflection.Assembly.LoadFrom(System.String)>. Trimming relies on seeing all assemblies at build time, so it knows which code is used and cannot be trimmed away. Most plugin systems load third-party code dynamically, so it is not possible for the trimmer to identify what code is needed.
