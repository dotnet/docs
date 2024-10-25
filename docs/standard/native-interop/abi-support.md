---
title: Native interoperability ABI support - .NET
description: Defines the current support for interoperability with various ABIs.
ms.date: 10/25/2024
---
# Native interoperability ABI support

Application Binary Interface (ABI) is the interface which run times and operating systems express low-level binary details. This can include calling conventions (that is, how parameters are passed and results returned), exception handling, as well as symbol mangling. The below list contains the names of languages, run times and even general technologies since these names tend to represent what users will be working with when looking for guidance on interoperability.

## C

The C language represents a stable ABI across all platforms where .NET is supported. It is what most .NET interop APIs assume is the target. This is the recommended approach for most interop in .NET.

## C++

The [C++ language](https://isocpp.org/) has no defined ABI across all .NET supported platforms and C++ compiler implementations (that is, MSVC, clang, and GCC). This lack of a stable ABI makes support difficult to provide. The recommended way to interoperate with C++ is to export functions marked with `extern "C"` and then call them as C functions.

## COM and `IUnknown`

The COM and `IUnknown` style ABI was defined to align with the C language. It was specifically to support Object Oriented Programming, similar to C++, but to provide a stable ABI. .NET has a deep history with COM and `IUnknown` and as this ABI was originally designed to align with C, it is supported in all .NET platforms through the <xref:System.Runtime.InteropServices.ComWrappers> API.

## Swift

The Swift programming environment has a well-defined stable ABI that is [supported in .NET](https://github.com/dotnet/designs/blob/main/proposed/swift-interop.md). The specific APIs that support interop with Swift can be found under the <xref:System.Runtime.InteropServices.Swift> namespace.

## Objective-C

The Objective-C language follows the C language's ABI and is [supported in .NET](https://github.com/dotnet/designs/blob/main/accepted/2021/objectivec-interop.md). The specific APIs that support interop with Objective-C can be found under the <xref:System.Runtime.InteropServices.ObjectiveC> namespace.

## Java Virtual Machine (JVM)

The JVM is a virtual machine with managed memory, similar to the .NET runtime. Interoperability with the JVM is limited through tooling like [dotnet/java-interop](https://github.com/dotnet/java-interop) and comes with performance costs. The largest cost of interoperating with the JVM is the coordination between the two virtual machine's Garbage Collectors.

## golang

The Go programming language is not supported for in-process interoperability. The Go runtime [imposes requirements](https://pkg.go.dev/os/signal#hdr-Non_Go_programs_that_call_Go_code) on being hosted in a process with another run time. Specifically, the use of the `SA_ONSTACK` flag on threads that run signal handlers. These requirements are not currently met by .NET and meeting them would impose non-trivial costs.

It is recommended that users with golang dependencies use a cross-process communication technology to interoperate.

## ARM64EC

There are currently no plans to add support for [ARM64EC](https://learn.microsoft.com/cpp/build/arm64ec-windows-abi-conventions) in .NET 5+.
