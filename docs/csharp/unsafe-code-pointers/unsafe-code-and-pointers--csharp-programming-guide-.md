---
title: "Unsafe Code and Pointers (C# Programming Guide)"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: "visual-studio-dev14"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "CSharp"
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
manager: "wpickett"
translation.priority.ht: 
  - "de-de"
  - "es-es"
  - "fr-fr"
  - "it-it"
  - "ja-jp"
  - "ko-kr"
  - "ru-ru"
  - "zh-cn"
  - "zh-tw"
translation.priority.mt: 
  - "cs-cz"
  - "pl-pl"
  - "pt-br"
  - "tr-tr"
---
# Unsafe Code and Pointers (C# Programming Guide)
To maintain type safety and security, C# does not support pointer arithmetic, by default. However, by using the [unsafe](../keywords/unsafe--csharp-reference-.md) keyword, you can define an unsafe context in which pointers can be used. For more information about pointers, see the topic [Pointer types](../unsafe-code-pointers/pointer-types--csharp-programming-guide-.md).  
  
> [!NOTE]
>  In the common language runtime (CLR), unsafe code is referred to as unverifiable code. Unsafe code in C# is not necessarily dangerous; it is just code whose safety cannot be verified by the CLR. The CLR will therefore only execute unsafe code if it is in a fully trusted assembly. If you use unsafe code, it is your responsibility to ensure that your code does not introduce security risks or pointer errors.  
  
## Unsafe Code Overview  
 Unsafe code has the following properties:  
  
-   Methods, types, and code blocks can be defined as unsafe.  
  
-   In some cases, unsafe code may increase an application's performance by removing array bounds checks.  
  
-   Unsafe code is required when you call native functions that require pointers.  
  
-   Using unsafe code introduces security and stability risks.  
  
-   In order for C# to compile unsafe code, the application must be compiled with [/unsafe](../compiler-options/-unsafe--csharp-compiler-options-.md).  
  
## Related Sections  
 For more information, see:  
  
-   [Pointer types](../unsafe-code-pointers/pointer-types--csharp-programming-guide-.md)  
  
-   [Fixed Size Buffers](../unsafe-code-pointers/fixed-size-buffers--csharp-programming-guide-.md)  
  
-   [How to: Use Pointers to Copy an Array of Bytes](../unsafe-code-pointers/how-to--use-pointers-to-copy-an-array-of-bytes---csharp-programming-guide-.md)  
  
-   [unsafe](../keywords/unsafe--csharp-reference-.md)  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](../arrays/includes/csharplangspec_md.md)]  
  
## See Also  
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)