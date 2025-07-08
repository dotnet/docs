---
title: Static abstract interface members errors and warnings
description: These warnings and errors are generated when static abstract or virtual members are used incorrectly. Learn how to correct these errors.
f1_keywords:
  - "CS8920"
  - "CS8921"
  - "CS8922"
  - "CS8923"
  - "CS8924"
  - "CS8925"
  - "CS8926"
  - "CS8928"
  - "CS9030"
  - "CS8931"
  - "CS8932"
helpviewer_keywords:
  - "CS8920"
  - "CS8921"
  - "CS8922"
  - "CS8923"
  - "CS8924"
  - "CS8925"
  - "CS8926"
  - "CS8928"
  - "CS8930"
  - "CS8931"
  - "CS8932"
ms.date: 11/29/2023
---
# Static abstract and virtual interface member errors and warnings

The compiler generates the following errors for invalid declarations of static abstract or virtual members in interfaces:

<!-- The text in this list generates issues for Acrolinx, because they don't use contractions.
That's be design. The text closely matches the text of the compiler error / warning for SEO purposes.
 -->
- [**CS8920**](#errors-calling-static-abstract-interface-members): *The interface cannot be used as type argument. Static member does not have a most specific implementation in the interface.*
- [**CS8921**](#errors-in-interface-declaration): *The parameter of a unary operator must be the containing type, or its type parameter constrained to it.*
- [**CS8922**](#errors-in-interface-declaration): *The parameter type for `++` or `--` operator must be the containing type, or its type parameter constrained to it.*
- [**CS8923**](#errors-in-interface-declaration): *The return type for `++` or `--` operator must either match the parameter type, or be derived from the parameter type, or be the containing type's type parameter constrained to it unless the parameter type is a different type parameter.*
- [**CS8924**](#errors-in-interface-declaration): *One of the parameters of a binary operator must be the containing type, or its type parameter constrained to it.*
- [**CS8925**](#errors-in-interface-declaration): *The first operand of an overloaded shift operator must have the same type as the containing type or its type parameter constrained to it*
- [**CS8926**](#errors-calling-static-abstract-interface-members): *A static virtual or abstract interface member can be accessed only on a type parameter.*
- [**CS8928**](#errors-in-type-implementing-interface-declaration): *Type does not implement static interface member. The method cannot implement the interface member because it is not static.*
- [**CS8930**](#errors-in-type-implementing-interface-declaration): *Explicit implementation of a user-defined operator must be declared static*
- [**CS8931**](#errors-in-interface-declaration): *User-defined conversion in an interface must convert to or from a type parameter on the enclosing type constrained to the enclosing type*
- [**CS8932**](#errors-in-type-implementing-interface-declaration): *'UnmanagedCallersOnly' method cannot implement interface member in type*

These errors occur in three places in your code:

- When you [declare an interface with static abstract or virtual members](#errors-in-interface-declaration),
- When you [declare a type that implements an interface with static abstract or virtual members](#errors-in-type-implementing-interface-declaration), and
- When you access a [static abstract or virtual method declared in an interface](#errors-calling-static-abstract-interface-members).

## Errors in interface declaration

The following errors might occur when you declare an interface with `static abstract` or `static virtual` members:

- **CS8921**: *The parameter of a unary operator must be the containing type, or its type parameter constrained to it.*
- **CS8922**: *The parameter type for `++` or `--` operator must be the containing type, or its type parameter constrained to it.*
- **CS8923**: *The return type for `++` or `--` operator must either match the parameter type, or be derived from the parameter type, or be the containing type's type parameter constrained to it unless the parameter type is a different type parameter.*
- **CS8924**: *One of the parameters of a binary operator must be the containing type, or its type parameter constrained to it.*
- **CS8925**: *The first operand of an overloaded shift operator must have the same type as the containing type or its type parameter constrained to it*
- **CS8931**: *User-defined conversion in an interface must convert to or from a type parameter on the enclosing type constrained to the enclosing type*

All these rules are extensions of the rules for declaring overloaded operators. The distinction is that the parameter can be either the interface type, or the interface's type parameter if that type parameter is constrained to implement the interface for its type. For binary operators, only one parameter must satisfy this rule.

For example, `INumber<T>` can declare an `T operator++(T)` because `T` is constrained to implement `INumber<T>`.

To fix these errors, ensure that the parameters of any operators defined in the interface obey these rules. You can learn more in the language reference article on [static abstract members in interfaces](../keywords/interface.md#static-abstract-and-virtual-members) or in the tutorial to [explore static abstract interface members](../../whats-new/tutorials/static-virtual-interface-members.md).

## Errors in type implementing interface declaration

The following errors might occur when you define a type that implements an interface with `static abstract` or `static virtual` methods:

- **CS8928**: *Type does not implement static interface member. The method cannot implement the interface member because it is not static.*
- **CS8930**: *Explicit implementation of a user-defined operator must be declared static*
- **CS8932**: *'UnmanagedCallersOnly' method cannot implement interface member in type*

These errors all indicate that you declared the method that implements a static abstract interface member incorrectly. These members must be declared `static`; they can't be instance members. Methods that implement interface members can't have the <xref:System.Runtime.InteropServices.UnmanagedCallersOnlyAttribute?displayProperty=nameWithType> attribute applied to them.

## Errors calling static abstract interface members

The following errors might occur when you attempt to call a member defined as a `static abstract` or `static virtual` member of an interface:

- **CS8920**: *The interface cannot be used as type argument. Static member does not have a most specific implementation in the interface.*
- **CS8926**: *A static virtual or abstract interface member can be accessed only on a type parameter.*

Calls to interface members declared as `static abstract` or `static virtual` must be resolved to at compile-time. They must resolve to a static member defined in a type that implements that interface. That means you must access those members using either a concrete type that implements the interface, or a type parameter that is constrained to implement the interface. To fix these errors, change the type used to access the static member.
