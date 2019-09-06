---
title: "#pragma - C# Reference"
ms.custom: seodec18

ms.date: 07/20/2015
f1_keywords: 
  - "#pragma"
helpviewer_keywords: 
  - "#pragma directive [C#]"
ms.assetid: 5b7944cd-d402-46a1-ad8f-feffb2d83673
---
# #pragma (C# Reference)
`#pragma` gives the compiler special instructions for the compilation of the file in which it appears. The instructions must be supported by the compiler. In other words, you cannot use `#pragma` to create custom preprocessing instructions. The Microsoft C# compiler supports the following two `#pragma` instructions:  
  
 [#pragma warning](./preprocessor-pragma-warning.md)  
  
 [#pragma checksum](./preprocessor-pragma-checksum.md)  
  
## Syntax  
  
```csharp
#pragma pragma-name pragma-arguments  
```  
  
## Parameters  
 `pragma-name`  
 The name of a recognized pragma.  
  
 `pragma-arguments`  
 Pragma-specific arguments.  
  
## See also

- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [C# Preprocessor Directives](./index.md)
- [#pragma warning](./preprocessor-pragma-warning.md)
- [#pragma checksum](./preprocessor-pragma-checksum.md)
