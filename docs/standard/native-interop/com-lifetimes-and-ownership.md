---
title: Lifetimes and ownership in COM Interop
description: Learn how lifetimes and ownership works in COM Interop
ms.date: 06/30/2023
zone-pivot-groups: interop-types
---

# Ownership and Lifetimes of COM parameters

## Motivation

COM Interop passes values and references to the heap across interop boundaries, and may or may not transfer ownership of references to heap memory depending on whether or not a COM method succeeds or not.
A COM method may fail at any point during execution, and it may fail after it has already allocated memory that is meant to be transfered to the caller.
It is important to make sure these failures do not lead to a memory leak or double free.
This document outlines the lifetimes and ownerships of the parameters as they are passed from across COM boundaries.

## Definitions

This document uses terms that may not be standard or well known. They are defined below.

- "Transitive References": A value may contain one or more references to values in memory, which may contain one or more other references to values in memory, and so on. A rule, property, or ownership of memory that is applied to the "transitive references" of a value means that the rule applies to all references, references of references, and so forth.

## Characteristics

The result of the application of the rule depends on the indirection level and the mutability of a value.

### Indirection level
There are three relevant levels of indirection: By Value, Single Indirection, and Multiple Indirection

#### By Value
A By Value parameter is copied to the parameter and passed to a method. Examples of these include `int`, `float`, and structs in C, C++, and C#.

Method signatures with a By Value parameter look like the following.

```cpp
void Method(int x);
void Method2(Struct x);
```
```csharp
void Method(int x);
void Method2(Struct x);
```

#### Single Indirection
A Single Indirection value a reference to a value. Examples include pointers to values (`int*`), reference types in C# (any class or type that derives from `Object`), and references to value types in C# (`ref int`).

Method signatures with Single Indirection look like the following.

```cpp
void Method(int* x);
void Method2(Struct* x);
```
```csharp
void Method(ref int x);
void Method2(ref Struct x);
void Method3(Class x);
```

A reference in a By Value struct is also a Single Indirection value.

```csharp
struct StructWithReference
{
    int* ptr;
}
void Method(StructWithReference x);
```

In the above example, the `ptr` field of parameter `x` is a Single Indirection value.

Values with Single Indirection do not transfer ownership, but may be mutated by the callee if the declared mutability allows it.

#### Multiple Indirection
A Multiple Indirection value is a reference to a reference to a value. Examples include pointers to pointers (`int**`), and references to reference types in C# (`ref Class`).

Method signatures with Multiple Indirection look like the following.

```cpp
void Method(int** x);
void Method2(Struct** x);
```
```csharp
void Method3(ref Class x);
```

A reference in a field of a Single Indirection parameter type is also a Multiple Indirection value.

```csharp
class ClassWithAnotherClass
{
    ClassWithInt c;
}
class ClassWithInt
{
    int x;
}
void Method(ClassWithInt x);
```
In the example above, x is a Single Indirection value, but it contains a reference (its field `c`), which is a Multiple Indirection value.

Multiple Indirection values may transfer ownership.

### Mutability

Mutability is the other characteristic of parameters that influence the ownership rules of COM values. The three mutability kinds are Immutable, Mutable, and Requires Mutation. Since By Value passes a copy of a value, Mutability does not apply to By Value and declaring Mutability on a By Value parameter will have no effect. The mutability rules apply to the referenced memory and all memory transitively referenced from it.

#### Immutable

Immutable parameters cannot be modified by the callee. This characteristic applies transitively to all values transitively referenced by the parameter. Since the parameter cannot be modified, all Immutable parameters will always be owned by the caller.

You can make a parameter Immutable by using the `const` keyword in C++, or with the `in` keyword or <xref:System.Runtime.InteropServices.InAttribute> in C#.

#### Mutable

Mutable parameters have references may be modified by the callee, but it is not required. This is the most complex application of the rule

You can make a parameter Mutable in C# by using the `ref` keyword or both the <xref:System.Runtime.InteropServices.InAttribute> and <xref:System.Runtime.InteropServices.OutAttribute>. Mutable is the default for C++. This is the situation where the most complex implementations

#### Requires Mutation

Requires Mutation parameters have references that __must__ be modified call the callee, and the values in the referenced memory at the start of the call are considered invalid. Because the original value in the referenced memory is invalid when the method is called, the callee does not take ownership of any memory from the callee. On a successful return, the caller takes ownership of the transitive references from the final value of the parameter reference.

You can designate that a parameter Requires Mutation in C# with the `out` keyword or the <xref:System.Runtime.InteropServices.OutAttribute>, or in C++ with the `[out]` attribute.

## Arrays

Arrays can cause confusion because they have memory allocated for the container, and may have memory allocated for each element as well. However, we can treat the container as any other Single Reference value and treat the elements as fields on a struct. For example,

```csharp
class ClassWithInt
{
    int x;
}
class ArrayLikeClass
{
    ClassWithInt element1;
    ClassWithInt element2;
    ClassWithInt element3;
    ...
}
void Method(ArrayLikeClass param1, ClassWithInt[] param2);
void Method2(ref ArrayLikeClass param1, ref ClassWithInt[] param2)
```

In both methods above, the ownership of the elements of the elements of `param2` follow the exact same rules as the fields of `param1`, and the memory containing the `ArrayLikeClass` follows the same ownership rules as the array container for param2.

## Examples

For more examples, go to [Examples](./com-lifetimes-and-ownership-examples.md)

