---
title: "Method Parameters - C# Reference"
ms.custom: seodec18

ms.date: 07/20/2015
helpviewer_keywords: 
  - "methods [C#], parameters"
  - "method parameters [C#]"
  - "parameters [C#]"
ms.assetid: 680e39ff-775b-48b0-9f47-4186a5bfc4a1
---
# Method Parameters (C# Reference)

Parameters declared for a method without [in](./in-parameter-modifier.md), [ref](./ref.md) or [out](./out-parameter-modifier.md), are passed to the called method by value. That value can be changed in the method, but the changed value will not be retained when control passes back to the calling procedure. By using a method parameter keyword, you can change this behavior.  
  
 This section describes the keywords you can use when declaring method parameters:  
  
- [params](./params.md) specifies that this parameter may take a variable number of arguments.
  
- [in](./in-parameter-modifier.md) specifies that this parameter is passed by reference but is only read by the called method.
  
- [ref](./ref.md) specifies that this parameter is passed by reference and may be read or written by the called method.
  
- [out](./out-parameter-modifier.md) specifies that this parameter is passed by reference and is written by the called method.
  
## See also

- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [C# Keywords](./index.md)
