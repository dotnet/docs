---
title: "#undef - C# Reference"
ms.custom: seodec18

ms.date: 06/30/2018
f1_keywords: 
  - "#undef"
helpviewer_keywords: 
  - "#undef directive [C#]"
ms.assetid: 686c92d2-7194-4be4-b2f4-80091712d513
---
# #undef (C# Reference)
`#undef` lets you undefine a symbol, such that, by using the symbol as the expression in a [#if](./preprocessor-if.md) directive, the expression will evaluate to `false`.  
  
 A symbol can be defined either with the [#define](./preprocessor-define.md) directive or the [-define](../compiler-options/define-compiler-option.md) compiler option. The `#undef` directive must appear in the file before you use any statements that are not also directives.  
  
## Example  

```csharp
// preprocessor_undef.cs  
// compile with: /d:DEBUG  
#undef DEBUG  
using System;  
class MyClass
{  
    static void Main()
    {  
#if DEBUG  
        Console.WriteLine("DEBUG is defined");  
#else  
        Console.WriteLine("DEBUG is not defined");  
#endif  
    }  
}  
```

**DEBUG is not defined**

## See also

- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [C# Preprocessor Directives](./index.md)
