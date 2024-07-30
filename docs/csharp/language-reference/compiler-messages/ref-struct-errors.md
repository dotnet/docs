---
title: Errors and warnings associated with `ref struct` types
description: Learn about errors and warnings related to `ref struct` types. The compiler enforces several restrictions on `ref struct` types to enforce ref safety rules
f1_keywords:
  - "CS8343"
  - "CS8344"
  - "CS8345"
  - "CS9048"
  - "CS9050"
  - "CS9059"
  - "CS9241"
  - "CS9242"
  - "CS9243"
  - "CS9244"
  - "CS9245"
  - "CS9246"
  - "CS9247"
helpviewer_keywords:
  - "CS8343"
  - "CS8344"
  - "CS8345"
  - "CS9048"
  - "CS9050"
  - "CS9059"
  - "CS9241"
  - "CS9242"
  - "CS9243"
  - "CS9244"
  - "CS9245"
  - "CS9246"
  - "CS9247"
ms.date: 07/30/2024
---
# Errors and warnings associated with `ref struct` types

- [**CS8343**](#ref-struct-interface-implementations): *`ref structs` cannot implement interfaces*
- [**CS8344**](#ref-struct-interface-implementations): *`foreach` statement cannot operate on enumerators in async or iterator methods because type is a `ref struct` or a type parameter that allows `ref struct`.*
- [**CS8345**](#ref-safety-violations): *Field or auto-implemented property cannot be of type unless it is an instance member of a `ref struct`.*
- [**CS9048**](#ref-safety-violations): *The `scoped` modifier can be used for refs and `ref struct` values only.*
- [**CS9050**](#compiler-error-cs9050): *A `ref` field cannot refer to a `ref struct`.*
- [**CS9059**](#ref-safety-violations): *A ref field can only be declared in a ref struct.*
- [**CS9241**](#ref-struct-interface-implementations): *'ref struct' is already specified.*
- [**CS9242**](#ref-struct-interface-implementations): *The 'allows' constraint clause must be the last constraint specified.*
- [**CS9243**](#ref-struct-interface-implementations): *Cannot allow ref structs for a type parameter known from other constraints to be a class.*
- [**CS9244**](#ref-struct-interface-implementations): *The type may not be a `ref struct` or a type parameter allowing ref structs in order to use it as parameter in the generic type or method.*
- [**CS9245**](#ref-struct-interface-implementations): *Type cannot implement interface member for `ref struct` type.*
- [**CS9246**](#ref-struct-interface-implementations): *A non-virtual instance interface member cannot be accessed on a type parameter that allows ref struct.*
- [**CS9247**](#ref-struct-interface-implementations): *foreach statement cannot operate on enumerators of type '{0}' because it is a type parameter that allows ref struct and it is not known at compile time to implement IDisposable.*

## ref struct interface implementations

More content here.

## ref safety violations

Even more content goes here.

## Compiler Error CS9050

A `ref` field cannot refer to a `ref struct`.

The compiler does not support the `ref` modifier on a field within a struct (to declare a stack-allocated field) of a type already declared stack-allocated (`ref struct`).

The following sample generates CS9050:

```csharp
// CS9050.cs (0,0)
ref struct Color
{
    public float r, g, b;
}
ref struct Group
{
    public ref Color color;
}
```

In this example, it is most likely a typo to have included a `ref` modifier on a field of a `ref struct` type within the declaration of a `ref struct`.  Removing the `ref` modifier corrects this error.

```csharp
ref struct Color
{
    public float r, g, b;
}
ref struct Group
{
    public Color color;
}
```
