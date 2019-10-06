---
title: "#elif - C# Reference"
ms.custom: seodec18

ms.date: 07/20/2015
f1_keywords: 
  - "#elif"
helpviewer_keywords: 
  - "#elif directive [C#]"
ms.assetid: 731d78df-08e0-4d51-b8c8-f193c27de13f
---
# #elif (C# Reference)
`#elif` lets you create a compound conditional directive. The `#elif` expression will be evaluated if neither the preceding [#if](./preprocessor-if.md) nor any preceding, optional, `#elif` directive expressions evaluate to `true`. If a `#elif` expression evaluates to `true`, the compiler evaluates all the code between the `#elif` and the next conditional directive. For example:  
  
```csharp
#define VC7  
//...  
#if debug  
    Console.WriteLine("Debug build");  
#elif VC7  
    Console.WriteLine("Visual Studio 7");  
#endif  
```  
  
 You can use the operators `==` (equality), `!=` (inequality), `&&` (and), and `||` (or), to evaluate multiple symbols. You can also group symbols and operators with parentheses.  
  
## Remarks  
 `#elif` is equivalent to using:  
  
```csharp
#else  
#if  
```  
  
 Using `#elif` is simpler, because each `#if` requires a [#endif](./preprocessor-endif.md), whereas a `#elif` can be used without a matching `#endif`.  
  
 See [#if](./preprocessor-if.md) for an example of how to use `#elif`.  
  
## See also

- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [C# Preprocessor Directives](./index.md)
