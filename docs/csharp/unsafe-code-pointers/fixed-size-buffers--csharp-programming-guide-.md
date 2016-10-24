---
title: "Fixed Size Buffers (C# Programming Guide)"
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
  - "fixed size buffers [C#]"
  - "unsafe buffers [C#]"
  - "unsafe code [C#], fixed size buffers"
ms.assetid: 6220d454-947c-4977-ac9d-9308c6ed5051
caps.latest.revision: 31
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
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
# Fixed Size Buffers (C# Programming Guide)
In C#, you can use the [fixed](../keywords/fixed-statement--csharp-reference-.md) statement to create a buffer with a fixed size array in a data structure. This is useful when you are working with existing code, such as code written in other languages, pre-existing DLLs or COM projects. The fixed array can take any attributes or modifiers that are allowed for regular struct members. The only restriction is that the array type must be `bool`, `byte`, `char`, `short`, `int`, `long`, `sbyte`, `ushort`, `uint`, `ulong`, `float`, or `double`.  
  
```  
private fixed char name[30];  
```  
  
## Remarks  
 In early versions of C#, declaring a C++ style fixed-size structure was difficult because a C# struct that contains an array does not contain the array elements. Instead, the struct contains a reference to the elements.  
  
 C# 2.0 added the ability to embed an array of fixed size in a [struct](../keywords/struct--csharp-reference-.md) when it is used in an [unsafe](../keywords/unsafe--csharp-reference-.md) code block.  
  
 For example, before C# 2.0, the following `struct` would be 8 bytes in size. The `pathName` array is a reference to the heap-allocated array:  
  
 [!code[csProgGuidePointers#19](../unsafe-code-pointers/codesnippet/CSharp/fixed-size-buffers--csharp-programming-guide-_1.cs)]  
  
 Beginning with C# 2.0, a `struct` can contain an embedded array. In the following example, the `fixedBuffer` array has a fixed size. To access the elements of the array, you use a `fixed` statement to establish a pointer to the first element. The `fixed` statement pins an instance of `fixedBuffer` to a specific location in memory.  
  
 [!code[csProgGuidePointers#20](../unsafe-code-pointers/codesnippet/CSharp/fixed-size-buffers--csharp-programming-guide-_2.cs)]  
  
 The size of the 128 element `char` array is 256 bytes. Fixed size [char](../keywords/char--csharp-reference-.md) buffers always take two bytes per character, regardless of the encoding. This is true even when char buffers are marshaled to API methods or structs with `CharSet = CharSet.Auto` or `CharSet = CharSet.Ansi`. For more information, see <xref:System.Runtime.InteropServices.CharSet>.  
  
 Another common fixed-size array is the [bool](../keywords/bool--csharp-reference-.md) array. The elements in a `bool` array are always one byte in size. `bool` arrays are not appropriate for creating bit arrays or buffers.  
  
> [!NOTE]
>  Except for memory created by using [stackalloc](../keywords/stackalloc--csharp-reference-.md), the C# compiler and the common language runtime (CLR) do not perform any security buffer overrun checks. As with all unsafe code, use caution.  
  
 Unsafe buffers differ from regular arrays in the following ways:  
  
-   You can only use unsafe buffers in an unsafe context.  
  
-   Unsafe buffers are always vectors, or one-dimensional arrays.  
  
-   The declaration of the array should include a count, such as `char id[8]`. You cannot use `char id[]` instead.  
  
-   Unsafe buffers can only be instance fields of structs in an unsafe context.  
  
## See Also  
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [Unsafe Code and Pointers](../unsafe-code-pointers/unsafe-code-and-pointers--csharp-programming-guide-.md)   
 [fixed Statement](../keywords/fixed-statement--csharp-reference-.md)   
 [Interoperability](../interop/interoperability--csharp-programming-guide-.md)