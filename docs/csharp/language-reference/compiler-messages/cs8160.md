---
description: "Compiler Error CS8160"
title: "Compiler Error CS8160"
ms.date: 9/19/2022
f1_keywords:
  - "CS8160"
helpviewer_keywords:
  - "CS8160"
---
# Compiler Error CS8160

A readonly field cannot be returned by writable reference

## Example

 The following sample generates CS8160:

```csharp
// CS8160.cs (8,20)

class Program
{
    readonly int i = 0;

    ref int M()
    {
        return ref i;
    }
}
```

## To correct this error

To return a `readonly` field, refactor to return by value:

```csharp
class Program
{
    readonly int i = 0;

    int M()
    {
        return i;
    }
}
```
