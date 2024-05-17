---
description: "Compiler Error CS8158"
title: "Compiler Error CS8158"
ms.date: 9/19/2022
f1_keywords:
  - "CS8158"
helpviewer_keywords:
  - "CS8158"
---
# Compiler Error CS8158

Cannot return by reference a member because it was initialized to a value that cannot be returned by reference

## Example

 The following sample generates CS8158:

```csharp
// CS8158.cs (11,14)

public class Test
{
    public struct S1
    {
        public char x;
    }

    ref char Test1(char arg1, S1 arg2)
    {
        ref S1 r = ref arg2;
        return ref r.x;
    }
}
```

## To correct this error

To return members initialized to a value that cannot be returned by reference, refactoring to return by value corrects this error:

```csharp
    char Test1(char arg1, S1 arg2)
    {
        ref S1 r = ref arg2;
        return r.x;
    }
```
