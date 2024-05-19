---
description: "Compiler Error CS8171"
title: "Compiler Error CS8171"
ms.date: 9/19/2022
f1_keywords:
  - "CS8171"
helpviewer_keywords:
  - "CS8171"
---
# Compiler Error CS8171

Cannot initialize a by-value variable with a reference

## Example

 The following sample generates CS8171:

```csharp
// CS8171.cs (8,13)

class Test
{
    void A()
    {
        int a = 123;
        ref int x = ref a;
        var y = ref x;
    }
}
```

Remember that `var y = ref x` is implicitly `int y = ref x` where `int y` is a by-value variable.

## To correct this error

Removing the `ref` modifier from the right side of the assignment will correct this error:

```csharp
class Test
{
    void A()
    {
        int a = 123;
        ref int x = ref a;
        var y = x;
    }
}
```
