---
title: "Unsafe Code and Pointers (C# Programming Guide)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
helpviewer_keywords: 
  - "security [C#], type safety"
  - "C# language, unsafe code"
  - "type safety [C#]"
  - "unsafe keyword [C#]"
  - "unsafe code [C#]"
  - "C# language, pointers"
  - "pointers [C#], about pointers"
ms.assetid: b0fcca10-a92d-4f2a-835b-b0ccae6739ee
caps.latest.revision: 24
author: "BillWagner"
ms.author: "wiwagn"
---
# Unsafe Code and Pointers (C# Programming Guide)
To maintain type safety and security, C# does not support pointer arithmetic, by default. However, by using the [unsafe](../../../csharp/language-reference/keywords/unsafe.md) keyword, you can define an unsafe context in which pointers can be used. For more information about pointers, see the topic [Pointer types](../../../csharp/programming-guide/unsafe-code-pointers/pointer-types.md).  
  
> [!NOTE]
>  In the common language runtime (CLR), unsafe code is referred to as unverifiable code. Unsafe code in C# is not necessarily dangerous; it is just code whose safety cannot be verified by the CLR. The CLR will therefore only execute unsafe code if it is in a fully trusted assembly. If you use unsafe code, it is your responsibility to ensure that your code does not introduce security risks or pointer errors.  
  
## Unsafe Code Overview  
 Unsafe code has the following properties:  
  
-   Methods, types, and code blocks can be defined as unsafe.  
  
-   In some cases, unsafe code may increase an application's performance by removing array bounds checks.  
  
-   Unsafe code is required when you call native functions that require pointers.  
  
-   Using unsafe code introduces security and stability risks.  
  
-   In order for C# to compile unsafe code, the application must be compiled with [/unsafe](../../../csharp/language-reference/compiler-options/unsafe-compiler-option.md).  
  
## Related Sections  
 For more information, see:  
  
-   [Pointer types](../../../csharp/programming-guide/unsafe-code-pointers/pointer-types.md)  
  
-   [Fixed Size Buffers](../../../csharp/programming-guide/unsafe-code-pointers/fixed-size-buffers.md)  
  
-   [How to: Use Pointers to Copy an Array of Bytes](../../../csharp/programming-guide/unsafe-code-pointers/how-to-use-pointers-to-copy-an-array-of-bytes.md)  
  
-   [unsafe](../../../csharp/language-reference/keywords/unsafe.md)  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]  
  
## See Also  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)
