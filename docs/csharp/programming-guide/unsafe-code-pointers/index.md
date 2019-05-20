---
title: "Unsafe code and pointers - C# Programming Guide"
ms.custom: seodec18
ms.date: 07/20/2015
helpviewer_keywords: 
  - "security [C#], type safety"
  - "C# language, unsafe code"
  - "type safety [C#]"
  - "unsafe keyword [C#]"
  - "unsafe code [C#]"
  - "C# language, pointers"
  - "pointers [C#], about pointers"
ms.assetid: b0fcca10-a92d-4f2a-835b-b0ccae6739ee
---
# Unsafe code and pointers (C# Programming Guide)

To maintain type safety and security, C# does not support pointer arithmetic, by default. However, by using the [unsafe](../../language-reference/keywords/unsafe.md) keyword, you can define an unsafe context in which pointers can be used. For more information about pointers, see [Pointer types](pointer-types.md).  
  
> [!NOTE]
> In the common language runtime (CLR), unsafe code is referred to as unverifiable code. Unsafe code in C# is not necessarily dangerous; it is just code whose safety cannot be verified by the CLR. The CLR will therefore only execute unsafe code if it is in a fully trusted assembly. If you use unsafe code, it is your responsibility to ensure that your code does not introduce security risks or pointer errors.  
  
## Unsafe code overview

Unsafe code has the following properties:

- Methods, types, and code blocks can be defined as unsafe.

- In some cases, unsafe code may increase an application's performance by removing array bounds checks.

- Unsafe code is required when you call native functions that require pointers.

- Using unsafe code introduces security and stability risks.

- The code that contains unsafe blocks must be compiled with the [-unsafe](../../language-reference/compiler-options/unsafe-compiler-option.md) compiler option.
  
## Related sections

For more information, see:

- [Pointer types](pointer-types.md)

- [Fixed size buffers](fixed-size-buffers.md)

## C# language specification

For more information, see the [Unsafe code](~/_csharplang/spec/unsafe-code.md) topic of the [C# language specification](~/_csharplang/spec/introduction.md).
  
## See also

- [C# Programming Guide](../index.md)
- [unsafe](../../language-reference/keywords/unsafe.md)
