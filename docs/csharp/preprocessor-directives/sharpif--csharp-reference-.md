---
title: "#if (C# Reference)"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: "visual-studio-dev14"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"
ms.tgt_pltfrm: ""
ms.topic: "article"
f1_keywords: 
  - "#if"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "#if directive [C#]"
ms.assetid: 48cabbff-ca82-491f-a56a-eeccd528c7c2
caps.latest.revision: 17
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
# #if (C# Reference)
When the C# compiler encounters an `#if` directive, followed eventually by an [#endif](../preprocessor-directives/sharpendif--csharp-reference-.md) directive, it will compile the code between the directives only if the specified symbol is defined.  Unlike C and C++, you cannot assign a numeric value to a symbol; the #if statement in C# is Boolean and only tests whether the symbol has been defined or not. For example,  
  
```  
#define DEBUG  
// ...  
#if DEBUG  
    Console.WriteLine("Debug version");  
#endif  
```  
  
 You can use the operators [==](../operators/==-operator--csharp-reference-.md) (equality), [!=](../operators/!=-operator--csharp-reference-.md) (inequality) only to test for [true](../keywords/true--csharp-reference-.md) or [false](../keywords/false--csharp-reference-.md) . True means the symbol is defined. The statement `#if DEBUG` has the same meaning as `#if (DEBUG == true)`. You can use the operators [&&](../operators/---operator--csharp-reference-.md) (and), [&#124;&#124;](../operators/---operator--csharp-reference-.md) (or), and [!](../operators/!-operator--csharp-reference-.md) (not) to evaluate whether multiple symbols have been defined. You can also group symbols and operators with parentheses.  
  
## Remarks  
 `#if`, along with the [#else](../preprocessor-directives/sharpelse--csharp-reference-.md), [#elif](../preprocessor-directives/sharpelif--csharp-reference-.md), [#endif](../preprocessor-directives/sharpendif--csharp-reference-.md), [#define](../preprocessor-directives/sharpdefine--csharp-reference-.md), and [#undef](../preprocessor-directives/sharpundef--csharp-reference-.md) directives, lets you include or exclude code based on the existence of one or more symbols. This can be useful when compiling code for a debug build or when compiling for a specific configuration.  
  
 A conditional directive beginning with a `#if` directive must explicitly be terminated with a `#endif` directive.  
  
 `#define` lets you define a symbol, such that, by using the symbol as the expression passed to the `#if` directive, the expression will evaluate to `true`.  
  
 You can also define a symbol with the [/define](../compiler-options/-define--csharp-compiler-options-.md) compiler option. You can undefine a symbol with [#undef](../preprocessor-directives/sharpundef--csharp-reference-.md).  
  
 A symbol that you define with `/define` or with `#define` does not conflict with a variable of the same name. That is, a variable name should not be passed to a preprocessor directive and a symbol can only be evaluated by a preprocessor directive.  
  
 The scope of a symbol created with `#define` is the file in which it was defined.  
  
## Example  
  
```  
// preprocessor_if.cs  
#define DEBUG#define MYTEST  
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
  
 **DEBUG and MYTEST are defined**   
## See Also  
 [C# Reference](../language-reference/csharp-reference.md)   
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [C# Preprocessor Directives](../preprocessor-directives/csharp-preprocessor-directives.md)