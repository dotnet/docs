---
title: "#else - C# Reference"
ms.custom: seodec18

ms.date: 07/20/2015
f1_keywords: 
  - "#else"
helpviewer_keywords: 
  - "#else directive [C#]"
ms.assetid: 6a347322-cfa2-4a86-98f8-ddfa2cb7d4db
---
# #else (C# Reference)
`#else` lets you create a compound conditional directive, so that, if none of the expressions in the preceding [#if](./preprocessor-if.md) or (optional) [#elif](./preprocessor-elif.md) directives evaluate to `true`, the compiler will evaluate all code between `#else` and the subsequent `#endif`.  
  
## Remarks  
 [#endif](./preprocessor-endif.md) must be the next preprocessor directive after `#else`. See [#if](./preprocessor-if.md) for an example of how to use `#else`.  
  
## See also

- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [C# Preprocessor Directives](./index.md)
