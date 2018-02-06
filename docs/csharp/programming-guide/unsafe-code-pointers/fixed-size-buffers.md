---
title: "Fixed Size Buffers (C# Programming Guide)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
helpviewer_keywords: 
  - "fixed size buffers [C#]"
  - "unsafe buffers [C#]"
  - "unsafe code [C#], fixed size buffers"
ms.assetid: 6220d454-947c-4977-ac9d-9308c6ed5051
caps.latest.revision: 31
author: "BillWagner"
ms.author: "wiwagn"
---
# Fixed Size Buffers (C# Programming Guide)
In C#, you can use the [fixed](../../../csharp/language-reference/keywords/fixed-statement.md) statement to create a buffer with a fixed size array in a data structure. This is useful when you are working with existing code, such as code written in other languages, pre-existing DLLs or COM projects. The fixed array can take any attributes or modifiers that are allowed for regular struct members. The only restriction is that the array type must be `bool`, `byte`, `char`, `short`, `int`, `long`, `sbyte`, `ushort`, `uint`, `ulong`, `float`, or `double`.  
  
```  
private fixed char name[30];  
```  
  
## Remarks  
 In early versions of C#, declaring a C++ style fixed-size structure was difficult because a C# struct that contains an array does not contain the array elements. Instead, the struct contains a reference to the elements.  
  
 C# 2.0 added the ability to embed an array of fixed size in a [struct](../../../csharp/language-reference/keywords/struct.md) when it is used in an [unsafe](../../../csharp/language-reference/keywords/unsafe.md) code block.  
  
 For example, before C# 2.0, the following `struct` would be 8 bytes in size. The `pathName` array is a reference to the heap-allocated array:  
  
 [!code-csharp[csProgGuidePointers#19](../../../csharp/programming-guide/unsafe-code-pointers/codesnippet/CSharp/fixed-size-buffers_1.cs)]  
  
 Beginning with C# 2.0, a `struct` can contain an embedded array. In the following example, the `fixedBuffer` array has a fixed size. To access the elements of the array, you use a `fixed` statement to establish a pointer to the first element. The `fixed` statement pins an instance of `fixedBuffer` to a specific location in memory.  
  
 [!code-csharp[csProgGuidePointers#20](../../../csharp/programming-guide/unsafe-code-pointers/codesnippet/CSharp/fixed-size-buffers_2.cs)]  
  
 The size of the 128 element `char` array is 256 bytes. Fixed size [char](../../../csharp/language-reference/keywords/char.md) buffers always take two bytes per character, regardless of the encoding. This is true even when char buffers are marshaled to API methods or structs with `CharSet = CharSet.Auto` or `CharSet = CharSet.Ansi`. For more information, see <xref:System.Runtime.InteropServices.CharSet>.  
  
 Another common fixed-size array is the [bool](../../../csharp/language-reference/keywords/bool.md) array. The elements in a `bool` array are always one byte in size. `bool` arrays are not appropriate for creating bit arrays or buffers.  
  
> [!NOTE]
>  Except for memory created by using [stackalloc](../../../csharp/language-reference/keywords/stackalloc.md), the C# compiler and the common language runtime (CLR) do not perform any security buffer overrun checks. As with all unsafe code, use caution.  
  
 Unsafe buffers differ from regular arrays in the following ways:  
  
-   You can only use unsafe buffers in an unsafe context.  
  
-   Unsafe buffers are always vectors, or one-dimensional arrays.  
  
-   The declaration of the array should include a count, such as `char id[8]`. You cannot use `char id[]` instead.  
  
-   Unsafe buffers can only be instance fields of structs in an unsafe context.  
  
## See Also  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [Unsafe Code and Pointers](../../../csharp/programming-guide/unsafe-code-pointers/index.md)  
 [fixed Statement](../../../csharp/language-reference/keywords/fixed-statement.md)  
 [Interoperability](../../../csharp/programming-guide/interop/index.md)
