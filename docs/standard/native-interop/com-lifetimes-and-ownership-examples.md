---
title: Examples of lifetimes and ownership in COM Interop
description: Learn how lifetimes and ownership works in COM Interop with examples
ms.date: 06/30/2023
---

# Examples of COM Interface ownership rules

This document outlines how the rules outlined in [Ownership and Lifetimes of COM parameters](./com-lifetimes-and-ownership.md) are applied to values and method signatures.

## Primitives and blittable structs

```csharp
void Method1(int x);
void Method2(float y);
void Method3(PrimitiveStruct s);
struct PrimitiveStruct
{
    int a;
    float b;
}
```
```cpp
void Method1(int x);
void Method2(float y);
void Method3(PrimitiveStruct s);
struct PrimitiveStruct
{
    int a;
    float b;
}
```

Primitives and structs with only primitive fields are all By Value and contain no references, so there is no ownership transfer in COM.

## References to primitives and references struct of primitives

```csharp
void Method1(ref int x);
void Method2(ref float y);
void Method3(ref PrimitiveStruct s);
struct PrimitiveStruct
{
    int a;
    float b;
}
class PrimitiveClass
{
    int a;
    float b;
}
```
```cpp
void Method1(int* x);
void Method2(float* y);
void Method3(PrimitiveStruct* s);
struct PrimitiveStruct
{
    int a;
    float b;
}
```

References to primitives and references to structs with only primitive fields are both Single Indirection and contain no references, so there is no ownership transfer in COM.

## Structs with references to blittable values

## Reference to struct with reference to blittable struct

## Reference to struct with recursive reference

## Array with blittable type

## Array of references to struct

## Array of references to struct with reference to blittable type

## Array of references to struct with recursive reference
