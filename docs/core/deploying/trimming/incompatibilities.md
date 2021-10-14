---
title: Known trimming incompatibilities
description: Identify patterns and frameworks that are known to have problems with trimming
author: agocke
ms.author: angocke
ms.date: 10/08/2021
---
# Known trimming incompatibilities

There are some patterns that are known to be incompatible with trimming. Some of these patterns may become compatible as tooling improves or as libraries make modifications to become trimming compatible.

## Built-in COM marshalling

Alternative: [COM Wrappers](../../../standard/native-interop/com-wrappers.md)

Automatic [COM marshalling](../../../standard/native-interop/cominterop.md) has been built in to .NET since .NET Framework 1.0. It uses run-time code analysis to automatically convert between native COM objects and managed .NET objects. Unfortunately, trimming analysis cannot always predict what .NET code will need to be preserved for automatic COM marshalling. However, if [COM Wrappers](../../../standard/native-interop/com-wrappers.md) are used instead, trimming analysis can guarantee that all used code will be correctly preserved.

## WPF

The Windows Presentation Foundation (WPF) framework makes substantial use of reflection and some features are heavily reliant on run-time code inspection. In .NET 6, it's not possible for trimming analysis to preserve all necessary code for WPF applications. Unfortunately, almost no WPF apps are runnable after trimming, so trimming support for WPF has been disabled in the .NET 6 SDK.

## Windows Forms

The Windows Forms framework makes minimal use of reflection, but is heavily reliant on built-in COM marshalling. In .NET 6, it has not yet been converted to use ComWrappers. Unfortunately, almost no Windows Forms apps are runnable without built-in COM marshalling, so trimming support for Windows Forms apps has been disabled in the .NET 6 SDK.

## Reflection-based serializers

Alternative: Reflection-free serializers, like source-generated [System.Text.Json](../../../standard/serialization/system-text-json-source-generation.md).

Many uses of reflection can be made trimming-compatible, as described in [Introduction to trim warnings](fixing-warnings.md). However, serializers tend to have very complex uses of reflection. Many of these uses cannot be made analyzable at build time. Unfortunately, the best option is often to rewrite the system to use source generation instead.

## Dynamic assembly loading and execution

Trimming and dynamic assembly loading is a common problem for systems that support plugins or extensions, usually through APIs like <xref:System.Reflection.Assembly.LoadFrom(System.String)>. Trimming relies on seeing all assemblies at build time, so it knows which code is used and cannot be trimmed away. Most plugin systems load third-party code dynamically, so it's not possible for the trimmer to identify what code is needed.
