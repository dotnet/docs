---
title: "Exceptions Interoperability"
ms.date: "01/16/2020"
ms.technology: dotnet-standard
helpviewer_keywords:
  - "unmanaged code, exceptions"
  - "exceptions, unmanaged code"
  - "interop, exceptions"
  - "exceptions, interop"
---
# Working with Interop Exceptions in Unmanaged Code
Unmanaged code exception interop is supported on Windows platforms only. It is not supported in non-Windows platforms, due to the portability issues that arise, since managed code can't know how these exception mechanisms work under the covers. The Unix ABI has no definition for this and therefore, exceptions end up resulting in unpredictable behaviors and potential crashes.

## Setjmp/Longjmp Behaviors
`Setjmp`/`Longjmp` interop is held to the same constraints as exception handling as it is not supported to skip over managed frames this way.

For further information, take a look at `longjmp` [documentation](https://docs.microsoft.com/cpp/c-runtime-library/reference/longjmp).

## See also

- [Exceptions](index.md)
- [Interop with Native Libraries](https://www.mono-project.com/docs/advanced/pinvoke/#runtime-exception-propagation)
