---
title: "#define - C# Reference"
ms.custom: seodec18

ms.date: 06/30/2018
f1_keywords: 
  - "#define"
helpviewer_keywords: 
  - "#define directive [C#]"
ms.assetid: 23638b8f-779c-450e-b600-d55682de7d01
---
# #define (C# Reference)
You use `#define` to define a symbol. When you use the symbol as the expression that's passed to the [#if](./preprocessor-if.md) directive, the expression will evaluate to `true`, as the following example shows:  
 
 ```csharp
 #define DEBUG
 ```
  
## Remarks  
  
> [!NOTE]
>  The `#define` directive cannot be used to declare constant values as is typically done in C and C++. Constants in C# are best defined as static members of a class or struct. If you have several such constants, consider creating a separate "Constants" class to hold them.  
  
 Symbols can be used to specify conditions for compilation. You can test for the symbol with either [#if](./preprocessor-if.md) or [#elif](./preprocessor-elif.md). You can also use the <xref:System.Diagnostics.ConditionalAttribute> to perform conditional compilation.  
  
 You can define a symbol, but you cannot assign a value to a symbol. The `#define` directive must appear in the file before you use any instructions that aren't also preprocessor directives.  
  
 You can also define a symbol with the [-define](../compiler-options/define-compiler-option.md) compiler option. You can undefine a symbol with [#undef](./preprocessor-undef.md).  
  
 A symbol that you define with `-define` or with `#define` does not conflict with a variable of the same name. That is, a variable name should not be passed to a preprocessor directive and a symbol can only be evaluated by a preprocessor directive.  
  
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
  
 For an example of how to undefine a symbol, see [#undef](./preprocessor-undef.md).  
  
## See also

- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [C# Preprocessor Directives](./index.md)
- [const](../keywords/const.md)
- [How to: Compile Conditionally with Trace and Debug](../../../framework/debug-trace-profile/how-to-compile-conditionally-with-trace-and-debug.md)
- [#undef](./preprocessor-undef.md)
- [#if](./preprocessor-if.md)
