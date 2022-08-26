---
title: Use custom marshallers in source-generated P/Invokes
description: Learn how to use the CustomMarshallerAttribute and implement a custom marshaller for use with source generation.
ms.date: 08/22/2022
---

# Tutorial: Use custom marshallers in source-generated P/Invokes

In this tutorial, you'll learn how to implement a marshaller and use it for [custom marshalling](custom-marshalling-source-generation.md) in [source-generated P/Invokes](pinvoke-source-generation.md).

We will implement marshallers for a built-in type, customizing marshalling for a specific parameter, and a user-defined type, specifying default marshalling for a user-defined type.

All source code used in this tutorial is available in the [dotnet/samples repository](https://github.com/dotnet/samples/tree/main/core/interop/source-generation/custom-marshalling).

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