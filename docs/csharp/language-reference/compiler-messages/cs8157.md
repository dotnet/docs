---
description: "Compiler Error CS8157"
title: "Compiler Error CS8157"
ms.date: 9/19/2022
f1_keywords:
  - "CS8157"
helpviewer_keywords:
  - "CS8157"
---
# Compiler Error CS8157

Cannot return by reference because it was initialized to a value that cannot be returned by reference

## Example

 The following sample generates CS8157:

```csharp
// CS8157.cs (8,21)

class C
{
    ref int M()
    {
        int x = 0;
        ref int rx = ref x;
        return ref (rx = ref (new int[1])[0]);
    }
}
```

## To correct this error

To return a value that cannot be returned by reference, refactoring to return by value corrects this error:

```csharp
class C
{
    int M()
    {
        int x = 0;
        ref int rx = ref x;
        return rx = ref (new int[1])[0];
    }
}
```
