---
title: Unmanaged calling conventions
description: Learn how to specify unmanaged calling conventions in .NET
author: jkotas
ms.date: 08/19/2023
---

# Unmanaged calling conventions

[Calling conventions](https://en.wikipedia.org/wiki/Calling_convention) describe low-level details for how method arguments and return values
are passed between the caller and the called method.

It's important that the unmanaged calling convention declared in a P/Invoke declaration matches the unmanaged calling convention
used by the native implementation. Mismatches in unmanaged calling conventions lead to data corruptions and fatal crashes that require
low-level debugging skills to diagnose.

## Platform default calling convention

Most platforms use one canonical calling convention and an explicitly specified calling convention is unnecessary in most cases.

For the x86 architecture, the default calling convention is platform specific. `Stdcall` ("standard call") is the default calling convention on Windows x86
and it is used by most Win32 APIs. `Cdecl` is the default calling convention on Linux x86. Windows ports of open-source libraries that
originated on Unix often use the `Cdecl` calling convention even on Windows x86. It's necessary to explicitly specify the `Cdecl` calling
convention in P/Invoke declarations for interop with these libraries.

For non-x86 architectures, both `Stdcall` and `Cdecl` calling conventions are treated as the canonical platform default calling convention.

## Specifying calling conventions in managed P/Invoke declarations

The calling conventions are specified by types in the `System.Runtime.CompilerServices` namespace or their combinations:

- [CallConvCdecl](xref:System.Runtime.CompilerServices.CallConvCdecl)
- [CallConvFastcall](xref:System.Runtime.CompilerServices.CallConvFastcall)
- [CallConvMemberFunction](xref:System.Runtime.CompilerServices.CallConvMemberFunction)
- [CallConvStdcall](xref:System.Runtime.CompilerServices.CallConvStdcall)
- [CallConvSuppressGCTransition](xref:System.Runtime.CompilerServices.CallConvSuppressGCTransition)
- [CallConvThiscall](xref:System.Runtime.CompilerServices.CallConvThiscall)

Examples of explicitly specified calling conventions:

```csharp
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

// P/Invoke declaration using SuppressGCTransition calling convention.
[LibraryImport("kernel32.dll")]
[UnmanagedCallConv(CallConvs = new Type[] { typeof(CallConvSuppressGCTransition) })]
extern static ulong GetTickCount64();

// Unmanaged callback with Cdecl calling convention.
[UnmanagedCallersOnly(CallConvs = new Type[] { typeof(CallConvCdecl) })]
static unsafe int NativeCallback(void* context);

// Method returning function pointer with combination of Cdecl and MemberFunction calling conventions.
static unsafe delegate* unmanaged[Cdecl, MemberFunction]<int> GetHandler();
```

## Specifying calling conventions in earlier .NET versions

.NET Framework and .NET versions prior to .NET 5 are limited to a subset of calling conventions that can described by the [CallingConvention](xref:System.Runtime.InteropServices.CallingConvention) enumeration.

Examples of explicitly specified calling conventions:

```csharp
using System.Runtime.InteropServices;

// P/Invoke declaration using Cdecl calling convention
[DllImport("ucrtbase.dll", CallingConvention=CallingConvention.Cdecl)]
static void* malloc(UIntPtr size);

// Delegate marshalled as callback with Cdecl calling convention
[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
delegate void Callback(IntPtr context);
```

## See also

- [Platform Invoke (P/Invoke)](pinvoke.md)
