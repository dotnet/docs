---
title: Examples of lifetimes and ownership in COM Interop
description: Learn how lifetimes and ownership works in COM Interop with examples
ms.date: 06/30/2023
---

# Examples of COM Interface ownership rules

This document outlines how the rules outlined in [Ownership and Lifetimes of COM parameters](./com-parameter-ownership.md) are applied to values and method signatures.

## Primitives and blittable structs

```csharp
int Method1(int x);
int Method2(float y);
int Method3(PrimitiveStruct s);
struct PrimitiveStruct
{
    int a;
    float b;
}
```
```cpp
int Method1(int x);
int Method2(float y);
int Method3(PrimitiveStruct s);
struct PrimitiveStruct
{
    int a;
    float b;
}
```


## References to primitives and references struct of primitives

```csharp
int Method1(ref int x);
int Method2(ref float y);
int Method3(ref PrimitiveStruct s);
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
int Method1(int* x);
int Method2(float* y);
int Method3(PrimitiveStruct* s);
struct PrimitiveStruct
{
    int a;
    float b;
}
```


## Structs with references to blittable values

```csharp
int Method(StructWithReference s);

struct StructWithReference
{
    PrimitiveClass a;
    float b;
}
class PrimitiveClass
{
    int a;
    float b;
}
```
```cpp
int Method(PrimitiveStruct s);

struct StructWithReference
{
    PrimitiveStruct* a;
    float b;
}
struct PrimitiveStruct
{
    int a;
    float b;
}
```


## Reference to struct with reference to blittable struct

```csharp
int Method(ref StructWithReference param);

struct StructWithReference
{
    PrimitiveClass a;
    float b;
}
class PrimitiveClass
{
    int a;
    float b;
}
```
```cpp
int Method(StructWithReference* param);
struct StructWithReference
{
    PrimitiveStruct* a;
    float b;
}
struct PrimitiveStruct
{
    int a;
    float b;
}
```


## Reference to struct with recursive reference

## Array with blittable type

## Array of references to struct

## Array of references to struct with reference to blittable type

## Array of references to struct with recursive reference
