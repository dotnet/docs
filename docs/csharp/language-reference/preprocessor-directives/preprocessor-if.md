---
title: "#if preprocessor directive (C# Reference)"
ms.date: "02/13/2017"
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "#if"
helpviewer_keywords: 
  - "#if directive [C#]"
ms.assetid: 48cabbff-ca82-491f-a56a-eeccd528c7c2
author: "BillWagner"
ms.author: "wiwagn"
---
# #if (C# Reference)

When the C# compiler encounters an `#if` directive, followed eventually by an [#endif](preprocessor-endif.md) directive, it compiles the code between the directives only if the specified symbol is defined. Unlike C and C++, you cannot assign a numeric value to a symbol. The #if statement in C# is Boolean and only tests whether the symbol has been defined or not. For example:

```csharp
#if DEBUG
    Console.WriteLine("Debug version");
#endif
```

You can use the operators [==](../operators/equality-comparison-operator.md) (equality) and [!=](../operators/not-equal-operator.md) (inequality) only to test for [true](../keywords/true.md) or [false](../keywords/false.md). True means the symbol is defined. The statement `#if DEBUG` has the same meaning as `#if (DEBUG == true)`. You can use the operators [&&](../operators/conditional-and-operator.md) (and), [&#124;&#124;](../operators/conditional-or-operator.md) (or), and [!](../operators/logical-negation-operator.md) (not) to evaluate whether multiple symbols have been defined. You can also group symbols and operators with parentheses.

## Remarks

`#if`, along with the [#else](preprocessor-else.md), [#elif](preprocessor-elif.md), [#endif](preprocessor-endif.md), [#define](preprocessor-define.md), and [#undef](preprocessor-undef.md) directives, lets you include or exclude code based on the existence of one or more symbols. This can be useful when compiling code for a debug build or when compiling for a specific configuration.

A conditional directive beginning with a `#if` directive must explicitly be terminated with a `#endif` directive.

`#define` lets you define a symbol. By then using the symbol as the expression passed to the `#if` directive, the expression evaluates to `true`.

You can also define a symbol with the [/define](../compiler-options/define-compiler-option.md) compiler option. You can undefine a symbol with [#undef](preprocessor-undef.md).

A symbol that you define with `/define` or with `#define` doesn't conflict with a variable of the same name. That is, a variable name should not be passed to a preprocessor directive, and a symbol can only be evaluated by a preprocessor directive.

The scope of a symbol created with `#define` is the file in which it was defined.

The build system is also aware of predefined preprocessor symbols representing different [target frameworks](../../../standard/frameworks.md). They're useful when creating applications that can target more than one .NET implementation or version.

[!INCLUDE [Preprocessor symbols](~/includes/preprocessor-symbols.md)]

Other predefined symbols include the DEBUG and TRACE constants. You can override the values set for the project using `#define`. The DEBUG symbol, for example, is automatically set depending on your build configuration properties ("Debug" or "Release" mode).

## Examples

The following example shows you how to define a MYTEST symbol on a file and then test the values of the MYTEST and DEBUG symbols. The output of this example depends on whether you built the project on Debug or Release configuration mode.

```csharp
#define MYTEST
using System;
public class MyClass
{
    static void Main()
    {
#if (DEBUG && !MYTEST)
        Console.WriteLine("DEBUG is defined");
#elif (!DEBUG && MYTEST)
        Console.WriteLine("MYTEST is defined");
#elif (DEBUG && MYTEST)
        Console.WriteLine("DEBUG and MYTEST are defined");  
#else
        Console.WriteLine("DEBUG and MYTEST are not defined");
#endif
    }
}
```

The following example shows you how to test for different target frameworks so you can use newer APIs when possible:

```csharp
public class MyClass
{
    static void Main()
    {
#if NET40
        WebClient _client = new WebClient();
#else
        HttpClient _client = new HttpClient();
#endif
    }
    //...
}
```

## See also

[C# Reference](../../../csharp/language-reference/index.md)  
[C# Programming Guide](../../../csharp/programming-guide/index.md)  
[C# Preprocessor Directives](index.md)  
[How to: Compile Conditionally with Trace and Debug](../../../framework/debug-trace-profile/how-to-compile-conditionally-with-trace-and-debug.md).
