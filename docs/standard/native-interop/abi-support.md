---
title: Native interoperability ABI support - .NET
description: Defines the current support for interoperability with various ABIs.
ms.date: 10/25/2024
---
# Native interoperability ABI support

[Application Binary Interface](https://wikipedia.org/wiki/Application_binary_interface) (ABI) is the interface which run times and operating systems express low-level binary details. This can include calling conventions (that is, how parameters are passed and results returned), exception handling, as well as symbol mangling. The below list contains the names of languages, run times and even general technologies since these names tend to represent what users will be working with when looking for guidance on interoperability.

|   | Support | APIs |
|---|---------|----------------|
| **C**                          | ✔️                | <xref:System.Runtime.InteropServices.LibraryImportAttribute> <xref:System.Runtime.InteropServices.DllImportAttribute> |
| **C++**                        | [Note](#cpp)     |          |
| **COM and `IUnknown`**         | ✔️                | <xref:System.Runtime.InteropServices.ComWrappers> <xref:System.Runtime.InteropServices.Marshalling.GeneratedComInterfaceAttribute> <xref:System.Runtime.InteropServices.Marshalling.GeneratedComClassAttribute> |
| **Swift**                      | ✔️                | <xref:System.Runtime.InteropServices.Swift> namespace      |
| **Objective-C**                | ✔️                | <xref:System.Runtime.InteropServices.ObjectiveC> namespace |
| **golang**                     | [Note](#golang)  |          |
| **ARM64EC**                    | [Note](#arm64ec) |          |

## <a name="cpp"></a> C++

The [C++ language](https://isocpp.org/) has no defined ABI across all .NET supported platforms and C++ compiler implementations (that is, MSVC, clang, and GCC). This lack of a stable ABI makes support difficult to provide. The recommended way to interoperate with C++ is to export functions marked with `extern "C"` and then call them as C functions.

## <a name="golang"></a> golang

The Go programming language is not supported for in-process interoperability. The Go runtime [imposes requirements](https://pkg.go.dev/os/signal#hdr-Non_Go_programs_that_call_Go_code) on being hosted in a process with another run time. Specifically, the use of the `SA_ONSTACK` flag on threads that run signal handlers. These requirements are not currently met by .NET and meeting them would impose non-trivial costs.

## <a name="arm64ec"></a> ARM64EC

The [ARM64EC](https://learn.microsoft.com/cpp/build/arm64ec-windows-abi-conventions) ABI is not supported.
