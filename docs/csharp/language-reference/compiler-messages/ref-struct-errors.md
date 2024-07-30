---
title: Errors and warnings associated with `ref struct` types
description: Learn about errors and warnings related to `ref struct` types. The compiler enforces several restrictions on `ref struct` types to enforce ref safety rules
f1_keywords:
  - "CS8343"
  - "CS8344"
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
- [**CS9241**](#ref-struct-interface-implementations): *'ref struct' is already specified.*
- [**CS9242**](#ref-struct-interface-implementations): *The 'allows' constraint clause must be the last constraint specified.*
- [**CS9243**](#ref-struct-interface-implementations): *Cannot allow ref structs for a type parameter known from other constraints to be a class.*
- [**CS9244**](#ref-struct-interface-implementations): *The type may not be a `ref struct` or a type parameter allowing ref structs in order to use it as parameter in the generic type or method.*
- [**CS9245**](#ref-struct-interface-implementations): *Type cannot implement interface member for `ref struct` type.*
- [**CS9246**](#ref-struct-interface-implementations): *A non-virtual instance interface member cannot be accessed on a type parameter that allows ref struct.*
- [**CS9247**](#ref-struct-interface-implementations): *foreach statement cannot operate on enumerators of type '{0}' because it is a type parameter that allows ref struct and it is not known at compile time to implement IDisposable.*

## ref struct interface implementations

More content here.
