---
title: SYSLIB diagnostics for Microsoft.Interop.ComInterfaceGenerator
description: Learn about the COM interop source-generation analyzers that generate compile-time suggestions SYSLIB1090 through SYSLIB1099 and SYSLIB1230 through SYSLIB1239.
ms.date: 10/08/2024
f1_keywords:
  - syslib1090
  - syslib1091
  - syslib1092
  - syslib1093
  - syslib1094
  - syslib1095
  - syslib1096
  - syslib1097
  - syslib1098
  - syslib1099
---
# SYSLIB diagnostics for COM interop source generation

The following table shows the diagnostic IDs for COM interop source-generation analyzers.

| Diagnostic ID | Description                                     |
|---------------|-------------------------------------------------|
| `SYSLIB1090`  | Invalid `GeneratedComInterfaceAttribute` usage. |
| `SYSLIB1091`  | Method is declared in different partial declaration than the `GeneratedComInterface` attribute. To ensure reliable calculation for virtual method table offsets, all methods must be declared in the same partial definition of a `GeneratedComInterface`-attributed interface type. |
| `SYSLIB1092` | Usage of `LibraryImport` or `GeneratedComInterface` attribute does not follow recommendation. |
| `SYSLIB1093` | Analysis for COM interface generation has failed. |
| `SYSLIB1094` | The base COM interface failed to generate source. Code will not be generated for this interface. |
| `SYSLIB1095` | Invalid `GeneratedComClassAttribute` usage. |
| `SYSLIB1096` | Use `GeneratedComInterfaceAttribute` instead of `ComImportAttribute` to generate COM marshalling code at compile time. |
| `SYSLIB1097` | This type implements at least one type with the `GeneratedComInterfaceAttribute` attribute. Add the `GeneratedComClassAttribute` to enable passing this type to COM and exposing the COM interfaces for the types with the `GeneratedComInterfaceAttribute` from objects of this type. |
| `SYSLIB1098` | .NET COM hosting with `EnableComHosting` only supports built-in COM interop. It does not support source-generated COM interop with `GeneratedComInterfaceAttribute`. |
| `SYSLIB1099` | COM Interop APIs on `System.Runtime.InteropServices.Marshal` do not support source-generated COM and will fail at run time. |
| [`SYSLIB1230`](syslib1230.md) | Deriving from a `GeneratedComInterface`-attributed interface defined in another assembly is not supported. |
