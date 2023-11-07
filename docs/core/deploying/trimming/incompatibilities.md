---
title: Known trimming incompatibilities
description: Identify patterns and frameworks that are known to have problems with trimming
author: agocke
ms.author: angocke
ms.date: 11/8/2023
---
# Known trimming incompatibilities

This article lists patterns that are incompatible with trimming with the current tooling.

## Reflection-based serializers

Alternative: Reflection-free serializers.

Many uses of reflection can be made trimming-compatible, as described in [Introduction to trim warnings](fixing-warnings.md). However, serializers tend to have complex uses of reflection. Many of these uses can't be made analyzable at build time. Unfortunately, the best option is often to rewrite the system to use source generation.

The following table lists popular reflection-based serializers and their recommended alternatives:

| Serializers | Alternative |
| :-- | :---------: |
| **Newtonsoft.Json** | [Source generated `System.Text.Json`](../../../standard/serialization/system-text-json/source-generation.md)    |
| **System.Configuration.ConfigurationManager** | [Source generated `Microsoft.Extensions.Configuration`](https://github.com/dotnet/runtime/issues/44493) |
| **System.Runtime.Serialization.Formatters.Binary.BinaryFormatter** | [Migrate away from BinaryFormatter serialization due to its security and reliability flaws.](../../compatibility/serialization/7.0/binaryformatter-apis-produce-errors.md#recommended-action) |

Runtime code generation via JIT, for example, via <xref:System.Reflection.Emit> is also incompatible with trimming.

## Dynamic assembly loading and execution

Trimming and dynamic assembly loading is a common problem for systems that support plugins or extensions, usually through APIs like <xref:System.Reflection.Assembly.LoadFrom(System.String)>. Trimming relies on seeing all assemblies at build time, so it knows which code is used and can't be trimmed away. Most plugin systems load third-party code dynamically, so it's not possible for the trimmer to identify what code is needed.

## Windows platform incompatibilities

The following sections list known incompatibilities with trimming on Windows.

### NET programming with C++/CLI

[NET programming with C++/CLI](/cpp/dotnet/dotnet-programming-with-cpp-cli-visual-cpp) is not supported with trimming.

### Built-in COM marshalling

Alternative: [COM Wrappers](../../../standard/native-interop/com-wrappers.md)

Automatic [COM marshalling](../../../standard/native-interop/cominterop.md) has been built in to .NET since .NET Framework 1.0. It uses run-time code analysis to automatically convert between native COM objects and managed .NET objects. Unfortunately, trimming analysis can't always predict what .NET code needs to be preserved for automatic COM marshalling. However, if [COM Wrappers](../../../standard/native-interop/com-wrappers.md) are used instead, trimming analysis can guarantee that all used code will be correctly preserved.

### WPF

The Windows Presentation Foundation (WPF) framework makes substantial use of reflection and some features are heavily reliant on run-time code inspection. It's not possible for trimming analysis to preserve all necessary code for WPF applications. Unfortunately, almost no WPF apps are runnable after trimming, so trimming support for WPF is currently disabled in the .NET SDK. See [WPF is not trim-compatible](https://github.com/dotnet/wpf/issues/3811) issue for progress on enabling trimming for WPF.

### Windows Forms

The Windows Forms framework makes minimal use of reflection, but is heavily reliant on built-in COM marshalling. Unfortunately, almost no Windows Forms apps are runnable without built-in COM marshalling, so trimming support for Windows Forms apps is disabled in the .NET SDK currently. See [Make WinForms trim compatible](https://github.com/dotnet/winforms/issues/4649) issue for progress on enabling trimming for Windows Forms.
