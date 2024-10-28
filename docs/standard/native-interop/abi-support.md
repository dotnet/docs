---
title: Native interoperability ABI support - .NET
description: Defines the current support for interoperability with various ABIs.
ms.date: 10/27/2024
---
# Native interoperability ABI support

[Application Binary Interface](https://wikipedia.org/wiki/Application_binary_interface) (ABI) is the interface which run times and operating systems express low-level binary details. This can include calling conventions (that is, how parameters are passed and results returned), exception handling, as well as symbol mangling. The below list contains the names of languages, run times and even general technologies since these names tend to represent what users will be working with when looking for guidance on interoperability.

## C

The C language represents a stable ABI across all platforms where .NET is supported. It is what most .NET interop APIs assume is the target. This is the recommended target language for most interop in .NET.

<xref:System.Runtime.InteropServices.LibraryImportAttribute> provides source generated support in .NET 7+. Use <xref:System.Runtime.InteropServices.DllImportAttribute> when targeting earlier .NET versions. Refer to [Interop best practices](./best-practices.md) for additional guidance.

Many virtual machine languages define a foreign function interface in C to interoperate with other platforms. The Java Virtual Machine (JVM) and Python runtimes are examples of this.

## C++

The [C++ language](https://isocpp.org/) has no defined ABI across all .NET supported platforms and C++ compiler implementations (that is, MSVC, clang, and GCC). This lack of a stable ABI makes support difficult to provide.

The recommended way to interoperate with C++ is to export functions marked with `extern "C"` and call them as C functions.

## COM and `IUnknown`

The COM and `IUnknown` style ABI was defined to align with the C language. It was specifically to support Object Oriented Programming, similar to C++, but to provide a stable ABI. .NET has a deep history with COM and `IUnknown` and as this ABI was originally designed to align with C, it is supported on all .NET platforms.

In .NET 5+, low-level, cross-platform, `IUnknown` lifetime support is provided by <xref:System.Runtime.InteropServices.ComWrappers>. In .NET 8+, <xref:System.Runtime.InteropServices.Marshalling.GeneratedComInterfaceAttribute> and <xref:System.Runtime.InteropServices.Marshalling.GeneratedComClassAttribute> provide source generated C# projections. The built-in COM interop system is limited to the Windows platforms and required on versions prior to .NET 5.

The WinRT platform represents an evolution of the COM and `IUknown` ABI. Support for this is provided by the [CsWinRT toolkit](/windows/apps/develop/platform/csharp-winrt/) and is built upon <xref:System.Runtime.InteropServices.ComWrappers>.

## Swift

The Swift programming environment has a well-defined stable ABI that is [supported in .NET](https://github.com/dotnet/designs/blob/main/proposed/swift-interop.md). In .NET 9+, specific APIs that support interop with Swift can be found under the <xref:System.Runtime.InteropServices.Swift> namespace.

## Objective-C

The Objective-C language follows the C language's ABI and is [supported in .NET](https://github.com/dotnet/designs/blob/main/accepted/2021/objectivec-interop.md). In .NET 8+, specific APIs that support interop with Objective-C can be found under the <xref:System.Runtime.InteropServices.ObjectiveC> namespace.

## golang

The Go programming language is not supported for in-process interoperability. The Go runtime [imposes requirements](https://pkg.go.dev/os/signal#hdr-Non_Go_programs_that_call_Go_code) on being hosted in a process with another run time. Specifically, the use of the `SA_ONSTACK` flag on threads that run signal handlers. These requirements are not currently met by .NET.

The recommended way to interoperate with golang is using a golang hosted process and communicate through an inter-process communication mechanism.

## ARM64EC

The [ARM64EC](/cpp/build/arm64ec-windows-abi-conventions) ABI is not supported.
