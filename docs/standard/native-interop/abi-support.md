---
title: Native interoperability ABI support - .NET
description: Defines the current support for interoperability with various ABIs.
ms.date: 10/28/2024
---
# Native interoperability ABI support

The [Application Binary Interface](https://wikipedia.org/wiki/Application_binary_interface) (ABI) is the interface which run-times and operating systems express low-level binary details. This can include calling conventions (that is, how parameters are passed and results returned), exception handling, as well as symbol mangling. The below list contains the names of languages, run-times and even general technologies since these names tend to represent what users will be working with when looking for guidance on interoperability.

## C

The C language represents a stable ABI across all platforms where .NET is supported. It is what most .NET interop APIs assume is the target. This is the recommended target language for most interop scenarios using .NET.

In .NET 7+, <xref:System.Runtime.InteropServices.LibraryImportAttribute> provides source generated support for calling C functions. When targeting .NET 6 or earlier, use <xref:System.Runtime.InteropServices.DllImportAttribute>. Refer to [Interop best practices](./best-practices.md) for additional guidance.

Additional links:

* [`LibraryImportAttribute` walkthrough](/dotnet/standard/native-interop/pinvoke-source-generation)
* [CsWin32](https://github.com/microsoft/CsWin32) is a source generator for accessing the Windows Win32 API surface

## C++

The [C++ language](https://isocpp.org/) has no defined ABI across all .NET supported platforms and the most popular C++ compiler implementations (that is, MSVC, clang, and GCC). This lack of a consistent ABI makes support difficult to provide.

The recommended way to interoperate with C++ is to export functions marked with [`extern "C"`](/cpp/cpp/extern-cpp) and call them as C functions.

Additional links:

* [ClangSharp](https://github.com/dotnet/ClangSharp) binding generator

## COM and `IUnknown`

The COM and `IUnknown` ABI was defined to align with the C language. It was specifically designed to support Object Oriented Programming, similar to C++, but to provide a stable ABI. .NET has a deep history with COM and `IUnknown` and as this ABI was originally designed to align with C, it is supported on all .NET platforms.

In .NET 5+, low-level, cross-platform, `IUnknown` lifetime support is provided by <xref:System.Runtime.InteropServices.ComWrappers>. In .NET 8+, <xref:System.Runtime.InteropServices.Marshalling.GeneratedComInterfaceAttribute> and <xref:System.Runtime.InteropServices.Marshalling.GeneratedComClassAttribute> provide source generated C# projections. When targeting versions prior to .NET 5, the [built-in COM interop system](/dotnet/standard/native-interop/cominterop) must be used and is limited to the Windows platforms.

The WinRT platform represents an evolution of the COM and `IUnknown` ABI. Support for this is provided by the [CsWinRT toolkit](/windows/apps/develop/platform/csharp-winrt/) and is built upon <xref:System.Runtime.InteropServices.ComWrappers>.

Additional links:

* [`ComWrappers` walkthrough](/dotnet/standard/native-interop/tutorial-comwrappers)
* [COM source generator sample](/dotnet/standard/native-interop/comwrappers-source-generation)
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

* [Objective-Sharpie](/previous-versions/xamarin/cross-platform/macios/binding/)
* [Objective-C binding walkthrough](/dotnet/maui/migration/ios-binding-projects)

## Python

The reference implementation of the Python run-time, [CPython](https://github.com/python/cpython), defines a foreign function interface (FFI) in C to interoperate with other platforms. Interoperability between .NET and Python can be achieved via this interface.

Additional links:

* [Providing a C API for an Extension Module](https://docs.python.org/3/extending/extending.html#providing-a-c-api-for-an-extension-module)

## golang

The Go programming language is not supported for in-process interoperability. The Go runtime [imposes requirements](https://pkg.go.dev/os/signal#hdr-Non_Go_programs_that_call_Go_code) on being hosted in a process with another run-time. Specifically, the use of the `SA_ONSTACK` flag on threads that run signal handlers. These requirements are not currently met by .NET.

The recommended way to interoperate with golang is using a golang hosted process and communicate through an inter-process communication mechanism.

## ARM64EC

The [ARM64EC](/cpp/build/arm64ec-windows-abi-conventions) ABI is not supported.
