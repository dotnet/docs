---
title: "#warning - C# Reference"
ms.custom: seodec18

ms.date: 07/20/2015
f1_keywords: 
  - "#warning"
helpviewer_keywords: 
  - "#warning directive [C#]"
ms.assetid: e6fb496d-bb8b-4018-baf6-5b60a0c8902b
---
# #warning (C# Reference)
`#warning` lets you generate a [CS1030](../../misc/cs1030.md) level one compiler warning from a specific location in your code. For example:  
  
```csharp
#warning Deprecated code in this method.  
```  
  
## Remarks
 A common use of `#warning` is in a conditional directive. It is also possible to generate a user-defined error with [#error](../../../csharp/language-reference/preprocessor-directives/preprocessor-error.md).  
  
## Example  

```csharp
// preprocessor_warning.cs  
// CS1030 expected  
#define DEBUG  
class MainClass
{  
    static void Main()
    {  
#if DEBUG  
#warning DEBUG is defined  
#endif  
    }  
}  
```  

## See also

- [C# Reference](../../../csharp/language-reference/index.md)
- [C# Programming Guide](../../../csharp/programming-guide/index.md)
- [C# Preprocessor Directives](../../../csharp/language-reference/preprocessor-directives/index.md)
