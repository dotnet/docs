---
title: COM Interop in .NET
description: Learn how to interoperate with COM libraries in .NET.
ms.date: 07/08/2026
---

# COM interop in .NET

The Component Object Model (COM) lets an object expose its functionality to other components and to host applications on Windows platforms. To help enable users to interoperate with their existing code bases, .NET Framework has always provided strong support for interoperating with COM libraries. A large portion of this support has been added to modern .NET (on Windows only). The documentation here explains how the common COM interop technologies work and how you can utilize them to interoperate with your existing COM libraries.

## Built-in and source-generated COM interop

COM interop functionality can be achieved through a built-in system in the .NET runtime or through implementing the [ComWrappers API](./tutorial-comwrappers.md) (introduced in .NET 6). You can use the [COM source generator](./comwrappers-source-generation.md) to automatically implement the `ComWrappers` API for `IUnknown`-based interfaces.

- [COM Wrappers](./com-wrappers.md)
- [COM Callable Wrappers](./com-callable-wrapper.md)
- [Runtime Callable Wrappers](./runtime-callable-wrapper.md)
- [Qualifying .NET Types for COM Interoperation](./qualify-net-types-for-interoperation.md)
- [Trimmer and Native AOT-friendly COM interop](./tutorial-comwrappers.md)
