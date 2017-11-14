---
title: What's new in C# 7.2
description: An overview of new features in C# 7.2.
keywords: C# language design, 7.2, Visual Studio 2017, 
author: billwagner
ms.author: wiwagn
ms.date: 08/16/2017
ms.topic: article
ms.prod: .net
ms.devlang: devlang-csharp
---
# What's new in C# 7.2

C# 7.2 is another point release that adds a number of useful features.
One theme for this release is working more efficiently with value types by
avoiding unecessary copies or allocations. 

The remaining features are small, nice to have features.

C# 7.2 uses the [language version selection](csharp-7-1.md#language-version-selection)
configuration element to select the compiler language version.

The new language features in this release are:

* [Reference semantics with value types](#reference-semantics-with-value-types)
  - A combination of syntax improvements that enable working with value types using reference semantics.
* [Non-trailing named arguments](#non-trailing-named-arguments)
  - Named arguments can be followed by positional arguments.
* [Leading underscores in numeric literals](#leading-underscores-in-numeric-literals)
  - Number literals can now have leading underscores before any printed digits.
* [`private protected` access modifier](#private-protected)
  - The `private protected` access modifier enables access for derived classes in the same assembly.

## Reference semantics with value types

A number of language features were introduced in 7.2 that enable scenarios
for working with value types while using reference semantics. These features
are designed to increase performance by minimize copying value types without
incurring the memory allocations associated with using reference types. The
features include:

 - The `in` modifier on parameters to specify that an argument is passed by reference, but not modified by the called method.
 - The `ref readonly` modifier on method returns indicates that a method returns its value by reference, and the [caller cannot directly modify that reference.
 - The `readonly struct` declaration indicates that a struct is immutable and should be passed as an `in` parameter to its members methods.
 - The `ref struct` declarations indicates that a struct type accesses managed memory directly and must always be stack allocated.

You can read more about all these changes in [Using value types with reference semantics](../ref-locals-and-returns.md).

## Non-trailing named arguments

Method calls may now use named arguments that precede positional arguments when those
named arguments are in the correct positions. Read more in the updated content for
[Named and optional arguments](../programming-guide/classes-and-structs/named-and-optional-arguments.md).

## Leading underscores in numeric literals

The first implementation of allowing `_` characters in numeric literals did not allow the
`_` to be the first character of the literal value. That has been fixed, and now numeric
literals may begin with an `_`. 

For example:

```csharp
int binaryValue = 0b_0101_0101;
```

## `private protected`

Finally, a new compound access modifier: `private protected`, indicates that a member may be
accessed by derived classes that are declared in the same assembly. Where `protected internal`
access allows access by derived classes or classes that are in the same assembly, this new
more restrictive designation limits access to derived types declared in the same assembly.

You can read more of the details in the language reference article on [access modifiers](../language-reference/keywords/access-modifiers.md).


