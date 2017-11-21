---
title: "#define (C# Reference)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "#define"
helpviewer_keywords: 
  - "#define directive [C#]"
ms.assetid: 23638b8f-779c-450e-b600-d55682de7d01
caps.latest.revision: 22
author: "BillWagner"
ms.author: "wiwagn"
---
# #define (C# Reference)
You use `#define` to define a symbol. When you use the symbol as the expression that's passed to the [#if](../../../csharp/language-reference/preprocessor-directives/preprocessor-if.md) directive, the expression will evaluate to `true`, as the following example shows:  
 
 ```csharp
 #define DEBUG
 ```
  
## Remarks  
  
> [!NOTE]
>  The `#define` directive cannot be used to declare constant values as is typically done in C and C++. Constants in C# are best defined as static members of a class or struct. If you have several such constants, consider creating a separate "Constants" class to hold them.  
  
 Symbols can be used to specify conditions for compilation. You can test for the symbol with either [#if](../../../csharp/language-reference/preprocessor-directives/preprocessor-if.md) or [#elif](../../../csharp/language-reference/preprocessor-directives/preprocessor-elif.md). You can also use the `conditional` attribute to perform conditional compilation.  
  
 You can define a symbol, but you cannot assign a value to a symbol. The `#define` directive must appear in the file before you use any instructions that aren't also preprocessor directives.  
  
 You can also define a symbol with the [/define](../../../csharp/language-reference/compiler-options/define-compiler-option.md) compiler option. You can undefine a symbol with [#undef](../../../csharp/language-reference/preprocessor-directives/preprocessor-undef.md).  
  
 A symbol that you define with `/define` or with `#define` does not conflict with a variable of the same name. That is, a variable name should not be passed to a preprocessor directive and a symbol can only be evaluated by a preprocessor directive.  
  
 The scope of a symbol that was created by using `#define` is the file in which the symbol was defined.  
  
 As the following example shows, you must put `#define` directives at the top of the file.  
  
```csharp  
#define DEBUG  
//#define TRACE  
#undef TRACE  
  
using System;  
  
public class TestDefine  
{  
    static void Main()  
    {  
#if (DEBUG)  
        Console.WriteLine("Debugging is enabled.");  
#endif  
  
#if (TRACE)  
     Console.WriteLine("Tracing is enabled.");  
#endif  
    }  
}  
// Output:  
// Debugging is enabled.  
```  
  
 For an example of how to undefine a symbol, see [#undef](../../../csharp/language-reference/preprocessor-directives/preprocessor-undef.md).  
  
## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [C# Preprocessor Directives](../../../csharp/language-reference/preprocessor-directives/index.md)  
 [const](../../../csharp/language-reference/keywords/const.md)  
 [How to: Compile Conditionally with Trace and Debug](../../../framework/debug-trace-profile/how-to-compile-conditionally-with-trace-and-debug.md)  
 [#undef](../../../csharp/language-reference/preprocessor-directives/preprocessor-undef.md)  
 [#if](../../../csharp/language-reference/preprocessor-directives/preprocessor-if.md)
