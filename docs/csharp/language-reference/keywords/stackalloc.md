---
title: "stackalloc (C# Reference) | Microsoft Docs"
ms.date: "2015-07-20"
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "stackalloc_CSharpKeyword"
  - "stackalloc"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "stackalloc keyword [C#]"
ms.assetid: adc04c28-3ed2-4326-807a-7545df92b852
caps.latest.revision: 27
author: "BillWagner"
ms.author: "wiwagn"
translation.priority.ht: 
  - "cs-cz"
  - "de-de"
  - "es-es"
  - "fr-fr"
  - "it-it"
  - "ja-jp"
  - "ko-kr"
  - "pl-pl"
  - "pt-br"
  - "ru-ru"
  - "tr-tr"
  - "zh-cn"
  - "zh-tw"
---
# stackalloc (C# Reference)
The `stackalloc` keyword is used in an unsafe code context to allocate a block of memory on the stack.  
  
```  
int* block = stackalloc int[100];  
```  
  
## Remarks  
 The keyword is valid only in local variable initializers. The following code causes compiler errors.  
  
```  
int* block;  
// The following assignment statement causes compiler errors. You  
// can use stackalloc only when declaring and initializing a local   
// variable.  
block = stackalloc int[100];  
```  
  
 Because pointer types are involved, `stackalloc` requires [unsafe](../../../csharp/language-reference/keywords/unsafe.md) context. For more information, see [Unsafe Code and Pointers](../../../csharp/programming-guide/unsafe-code-pointers/index.md).  
  
 `stackalloc` is like [_alloca](https://docs.microsoft.com/cpp/c-runtime-library/reference/alloca) in the C run-time library.  
  
 The following example calculates and displays the first 20 numbers in the Fibonacci sequence. Each number is the sum of the previous two numbers. In the code, a block of memory of sufficient size to contain 20 elements of type `int` is allocated on the stack, not the heap. The address of the block is stored in the pointer `fib`. This memory is not subject to garbage collection and therefore does not have to be pinned (by using [fixed](../../../csharp/language-reference/keywords/fixed-statement.md)). The lifetime of the memory block is limited to the lifetime of the method that defines it. You cannot free the memory before the method returns.  
  
## Example  
 [!code-cs[csrefKeywordsOperator#15](../../../csharp/language-reference/keywords/codesnippet/CSharp/stackalloc_1.cs)]  
  
## Security  
 Unsafe code is less secure than safe alternatives. However, the use of `stackalloc` automatically enables buffer overrun detection features in the common language runtime (CLR). If a buffer overrun is detected, the process is terminated as quickly as possible to minimize the chance that malicious code is executed.  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](../../../csharp/language-reference/keywords/includes/csharplangspec_md.md)]  
  
## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)   
 [C# Programming Guide](../../../csharp/programming-guide/index.md)   
 [C# Keywords](../../../csharp/language-reference/keywords/index.md)   
 [Operator Keywords](../../../csharp/language-reference/keywords/operator-keywords.md)   
 [Unsafe Code and Pointers](../../../csharp/programming-guide/unsafe-code-pointers/index.md)