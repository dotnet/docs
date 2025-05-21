---
title: Native interoperability ABI support - .NET
description: Defines the current support for interoperability with various ABIs.
ms.date: 10/28/2024
ms.topic: article
---
# Native interoperability ABI support

The [Application Binary Interface](https://wikipedia.org/wiki/Application_binary_interface) (ABI) is the interface that runtimes and operating systems use to express low-level binary details. Those details can include calling conventions (that is, how parameters are passed and results returned), exception handling, and symbol mangling. The list that follows contains the names of languages, runtimes, and even general technologies that you might use when looking for guidance on interoperability.

## C

The C language represents a stable ABI across all platforms where .NET is supported. In general, C is the assumed target for .NET interop APIs and is the recommended target language for most interop scenarios.

In .NET 7+, <xref:System.Runtime.InteropServices.LibraryImportAttribute> provides source-generated support for calling C functions. If you're targeting .NET 6 or earlier, use <xref:System.Runtime.InteropServices.DllImportAttribute>. For more information, see [Interop best practices](./best-practices.md).

Additional links:

* [`LibraryImportAttribute` walkthrough](pinvoke-source-generation.md)
* [CsWin32](https://github.com/microsoft/CsWin32) is a source generator for accessing the Windows Win32 API surface

## C++

The [C++ language](https://isocpp.org/) has no defined ABI across all .NET supported platforms and the most popular C++ compiler implementations (that is, MSVC, clang, and GCC). This lack of a consistent ABI makes it difficult to target directly.

The recommended way to interoperate with C++ is to export functions marked with [`extern "C"`](/cpp/cpp/extern-cpp) and call them as C functions.

Additional links:

* [ClangSharp](https://github.com/dotnet/ClangSharp) binding generator

## COM and `IUnknown`

The COM and `IUnknown` ABI was defined to align with the C language. It was specifically designed to support object-oriented programming, similar to C++, but to provide a stable ABI. .NET has a deep history with COM and `IUnknown`, and as this ABI was originally designed to align with C, it's supported on all .NET platforms.

In .NET 5+, low-level, cross-platform, `IUnknown` lifetime support is provided by <xref:System.Runtime.InteropServices.ComWrappers>. In .NET 8+, <xref:System.Runtime.InteropServices.Marshalling.GeneratedComInterfaceAttribute> and <xref:System.Runtime.InteropServices.Marshalling.GeneratedComClassAttribute> provide source generated C# projections. If you're targeting versions prior to .NET 5, you must use the [built-in COM interop system](cominterop.md), and this support is limited to Windows.

The WinRT platform represents an evolution of the COM and `IUnknown` ABI. Support for this is provided by the [CsWinRT toolkit](/windows/apps/develop/platform/csharp-winrt/) and is built upon <xref:System.Runtime.InteropServices.ComWrappers>.

Additional links:

* [`ComWrappers` walkthrough](tutorial-comwrappers.md)
* [COM source generator sample](comwrappers-source-generation.md)
* [ClangSharp](https://github.com/dotnet/ClangSharp) binding generator

## Java Virtual Machine (JVM) based languages

The Java Virtual Machine (JVM) defines a foreign function interface (FFI) in C to interoperate with other platforms. Interoperability between .NET and Java can be achieved via this interface.

Additional links:

* [Java binding generator](https://github.com/dotnet/java-interop)

## Swift

The Swift programming environment has a well-defined stable ABI that is [supported in .NET](https://github.com/dotnet/designs/blob/main/proposed/swift-interop.md). In .NET 9+, specific APIs that support interop with Swift can be found under the <xref:System.Runtime.InteropServices.Swift> namespace.

## Objective-C

The Objective-C language follows the C language's ABI and is [supported in .NET](https://github.com/dotnet/designs/blob/main/accepted/2021/objectivec-interop.md). In .NET 8+, specific APIs that support interop with Objective-C can be found under the <xref:System.Runtime.InteropServices.ObjectiveC> namespace.

Additional links:

* [Objective-C binding walkthrough](/dotnet/maui/migration/ios-binding-projects)

## Python

The reference implementation of the Python run-time, [CPython](https://github.com/python/cpython), defines a foreign function interface (FFI) in C to interoperate with other platforms. Interoperability between .NET and Python can be achieved via this interface.

Additional links:

* [Providing a C API for an Extension Module](https://docs.python.org/3/extending/extending.html#providing-a-c-api-for-an-extension-module)
* [Python for .NET](https://github.com/pythonnet/pythonnet)

## golang

The Go programming language is not supported for in-process interoperability. The Go runtime [imposes requirements](https://pkg.go.dev/os/signal#hdr-Non_Go_programs_that_call_Go_code) on being hosted in a process with another runtime. Specifically, that requirement is the use of the `SA_ONSTACK` flag on threads that run signal handlers. These requirements are not currently met by .NET.

The recommended way to interoperate with golang is to use a golang-hosted process and communicate through an inter-process communication mechanism.

## ARM64EC

The [ARM64EC](/cpp/build/arm64ec-windows-abi-conventions) ABI is not supported.
