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
Unmanaged code exception interop is not supported due to the portability issues that arise, since managed code can't know how these exception mechanisms work under the covers.

## Setjmp/Longjmp Behaviors
Setjmp/Longjmp interop is held to the same constraints as exception handling as it is not supported to skip over managed frames this way.

When unmanaged code moves on through the `longjmp` C library function, the runtime observes different behaviors between Windows and Unix operating systems. On Windows, there is support to unwind the stack properly when dealing with exceptions thrown by external components. On the other hand, Unix does not support exception interop as currently the Unix ABI has no definition for it. Therefore, exceptions here end up resulting in unpredictable behaviors and potential crashes.

For further information, take a look at `longjmp` [documentation](https://docs.microsoft.com/cpp/c-runtime-library/reference/longjmp).

## See also

- [Exceptions](index.md)
- [Interop with Native Libraries](https://www.mono-project.com/docs/advanced/pinvoke/#runtime-exception-propagation)
