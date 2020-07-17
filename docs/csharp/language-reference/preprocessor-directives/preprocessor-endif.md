---
title: "#endif - C# Reference"
ms.date: 07/20/2015
f1_keywords: 
  - "#endif"
helpviewer_keywords: 
  - "#endif directive [C#]"
ms.assetid: 6a5fca55-5aee-441f-86f6-1c99fbe9ec05
---
# #endif (C# Reference)
`#endif` specifies the end of a conditional directive, which began with the [#if](./preprocessor-if.md) directive. For example,  
  
```csharp
#define DEBUG  
// ...  
#if DEBUG  
    Console.WriteLine("Debug version");  
#endif  
```  
  
## Remarks  
 A conditional directive, beginning with a `#if` directive, must explicitly be terminated with a `#endif` directive. See [#if](./preprocessor-if.md) for an example of how to use `#endif`.  
  
## See also

- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [C# Preprocessor Directives](./index.md)
