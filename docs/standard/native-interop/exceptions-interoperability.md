---
description: "Learn more about: Working with Interop Exceptions in Unmanaged Code"
title: "Exceptions Interoperability"
ms.date: "01/16/2020"
helpviewer_keywords:
  - "unmanaged code, exceptions"
  - "exceptions, unmanaged code"
  - "interop, exceptions"
  - "exceptions, interop"
ms.topic: concept-article
---
# Working with Interop Exceptions in Unmanaged Code

Unmanaged code exception interop is supported on Windows platforms only. Portability issues arise on non-Windows platforms. Since the Unix ABI has no definition for exception handling, managed code can't know how exception mechanisms work under the covers. Therefore, exceptions can end up resulting in unpredictable behaviors and crashes.

## Setjmp/Longjmp Behaviors

Interop with `setjmp` and `longjmp` C functions is not supported. You can't use `longjmp` to skip over managed frames.

For more information, see [longjmp documentation](/cpp/c-runtime-library/reference/longjmp).

## See also

- [Exceptions](index.md)
- [Interop with Native Libraries](https://www.mono-project.com/docs/advanced/pinvoke/#runtime-exception-propagation)
