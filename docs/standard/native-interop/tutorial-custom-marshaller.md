---
title: Use custom marshallers in source-generated P/Invokes
description: Learn how to use the CustomMarshallerAttribute and implement a custom marshaller for use with source generation.
author: AaronRobinsonMSFT
ms.date: 08/22/2022
helpviewer_keywords:
  - "Interop"
  - "Marshalling"
  - "NativeAOT"
---

# Tutorial: Use custom marshallers in source-generated P/Invokes

In this tutorial, you'll learn how to implement a marshaller and use it for [custom marshalling](custom-marshalling-source-generation.md) in [source-generated P/Invokes](pinvoke-source-generation.md).

We will implement marshallers for a built-in C++ type, customize marshalling for a specific parameter, and a user-defined type, specify default marshalling for a user-defined type defined below.

All source code used in this tutorial is available in the [dotnet/samples repository](https://github.com/dotnet/samples/tree/main/core/interop/source-generation/custom-marshalling).

```cpp
struct error_data
{
    int code;
    bool is_fatal_error;
    char32_t* message;    // UTF-32 encoded string
};
```

## Overview of the `LibraryImportAttribute` design

The `LibraryImportAttribute` is the user entry point for a source generator introduced in .NET 7. This new source generator is designed to generate all marshalling code at compile-time instead of at run-time. This has historically been done using `DllImport`, but that approach comes with costs that may not always be acceptable. The most important cost is generation of marshalling code at run-time. This cost can be measured in terms of application performance but also in terms of potential target platforms that may not support dynamic code generation. The NativeAOT application model addresses issues with dynamic code generation by precompiling all code ahead of time directly into native code. Using `DllImport` is therefore not an option because of its run-time generation semantics. The `LibraryImportAttribute` source generator can generate all marshalling code and remove the run-time generation requirement intrinsic to `DllImport`.

Complete details on the design can be found in the [dotnet/runtime](https://github.com/dotnet/runtime/tree/main/docs/design/libraries/LibraryImportGenerator) repository.

## Customize marshalling for a built-in type

built-in type doesn't matter, really just type where however it is marshalled by default doesn't suit the use case

- `MarshalUsing` - at use site, overrides any default marshalling for the type
- stateless vs stateful
- Caller-allocated buffer optimization
- marshal mode
  - default, used for anything possible
  - specific mode ManagedToUnmanagedIn takes precedence over default

## Customize marshalling for a user-defined type

- `NativeMarshalling` - default marshalling for the type
- marshal mode
  - specific modes, can point to separate marshaller implementations
  - trying to use in other scenarios would fail