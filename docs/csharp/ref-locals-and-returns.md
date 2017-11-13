---
title: Reference semantics with value types
description: Understand the language features that minimize copying structures safely
author: billwagner
ms.author: wiwagn
ms.date: 11/10/2017
ms.topic: article
ms.prod: .net
ms.technology: devlang-csharp
ms.devlang: csharp
ms.custom: mvc
---

# Reference semantics with value types

An advantage to using value types is that they often avoid heap allocations.
The corresponding disadvantage is that they are copied by value. This tradeoff
makes it harder to optimize algorithms that operate on very large amounts of
data. New language features in C# 7.2 provide mechanisms that enable pass-by-refernce
semantics with value types. Use these features wisely, and you can minimize both allocations
and copy operations. This topic explores those new features.

## Specifying `in` parameters

C# 7.2 adds the `in` keyword to complement the existing `ref`
and `out` keywords when you write a method that passes arguments
by reference. The `in` keyword specifies that you are passing
the parameter by reference and the called method will not modify
the value passed to it. 

This addition provides a full vocabulary to express your design intent:

- `out`: This method will set the value of the argument used as this parameter.
- `ref`: This method may set the value of the arguement used as this parameter.
- `in`: This method will not modify the value of the argument used as this parameter.

When you add the `in` modify to pass an argument by reference you declare
that your design intent is that you want to pass arguments by reference to
avoid unnecessary copying. You do not intend to modify the object used
as that argument. The following code shows an example of a method
that calculates the distance between two points in 3D space. 

<< include First example>>

The arguments are two structures that contain 3 doubles. A double is 8 bytes,
so each argument is 24 bytes. By specifying the `in` modifier, you pass a
reference to those arguments, either 4 bytes or 8 bytes each depending on the
architecture of the machine. That is a small savings, but it can quickly add
up if your application calls this method in a tight loop.
 
The `in` modifier complements `out` and `ref` in other ways as well. You
cannot create overloads of a method that differ only in the presence of
`in`, `out` or `ref`. This extends the same behavior that had always been
defined for `out` and `ref` parameters.

The `in` modifier may be applied to any member that takes parameters:
methods, delegates, lambdas, local functions, indexers, operators.

Unlike `ref` and `out` arguments, you may use literal values or constants
for the argument to an `in` parameter. Also, unlike a `ref` or `out` parameter,
you don't need to apply the `in` modifier at the call site.

<< Example calculating the distance, using the origin Or
addition using an int?.>>

There are serveral ways in which the compiler ensures that the readonly
nature of an `in` argument is enforced.  First of all, the called method
can't directly assign to an `in` parameter. It can't directly assign
to any field of an `in` parameter. In addition, you cannot pass
an `in` parameter to any method demanding the `ref` or `out` modifier.
The compiler enforces that the `in` argument is a readonly variable.

You can call any instance method that uses pass-by-value semantics. In
those instances a copy of the `in` variable is createdd.

<< NOTE TO VSadov: Passing a 'ref' argument to a method by Value,
 or calling an instance method on that type does not generate a warning. >>

## `ref readonly` returns

You may also want to return a value type by reference, but disallow the
caller from modifying that value. The `ref readonly` modifier on the
return type of a method signature specifies this. It notifies readers
that you are returning a reference to existing data, but not allowing
modification. Most likely, this is for performance considerations.

The compiler enforces that the caller cannot modify the reference. Attempts
to assign to the value directly generate a compile time error. Calling member
methods will create a defensive copy. 

Creating a copy of a ref readonly return is easy: Just assign it to a variable
not declared with the `ref readonly` modifierl The copmiler generates code
to copy the object as part of the assignment.

## `readonly struct` type

Applying `ref readonly` to high-traffic uses of a struct may be sufficient.
Other times, you may want to declare that an immutable struct should always
be passed by reference to any method, thereby removing the defensive copies
that take place when you access methodsof a struct used as an `in` parameter.

You can do that by creating a `readonly struct` type. You can add the `readonly`
modifier to a struct declaration. The language enforces that allmembers of
the struct are `readonly`: the `struct` must be immutable.

There are other optimizations for a `readonly struct`. You can
use the `in` modifier at every location where a `readonly struct` is an
argument. In addition, you can return a `readonly struct` as a `ref return` when
you are returning an object whose lifetime extends beyond the scope of the method
returning the object.

Finally, the compiler generates more efficient code when you call members of a
`readonly struct`: The `this` reference is always an `in` parameter, instead
of a copy of the receiver, passed by value to the member method. This optimization
saves more copying when you use a `readonly struct`.

## `ref struct` type

Another related language feature is the ability to declare a value type that
must be stack allocated. In other words, these types can never be created on the
heap as a member of another reference type. The primary motivation for this feature
was `Span<T>` and related structures, but you can use the feature for any type
you create that has similar requirements. In this topic, you'll see examples
using `Span<T>` for simplicity.

`Span<T>` may contains a managed pointer as one of its members, the other being
the length of the span. It's actually implemented a bit differently because C#
doesn't support pointers to managed memory outside of an unsafe context. Any
write that changes the pointer and the length will not be atomic. That means a
`Span<T>` would be subject to out of range errors or other type safey violations
if it were not constrained to a single stack frame. In addition, putting a
managed pointer on the GC heap typically crashes at JIT time.

The `ref struct` declaration declares that a struct of this type must be
on the stack. The language rules ensure the safe use of these types. Other
types declared as `ref struct` include `ReadOnlySpan<T>`, `Memory<T>`, and
`ReadOnlyMemory<T>`. 

The goal of keeping a `ref struct` type as a stack allocated variable
introduces several rules that the compiler enforces for all `ref struct`
types.

- You can't box a ref struct.
- You can't declare a `ref struct` as a member of a class or a normal struct.
- You cannot declare local variables that are `ref struct` types in async methods. Note that you can declare them in synchronous methods that return `Task`, `Task<T>` or Task-like types.
- You cannot delare `ref struct` local variables in iterators.
- You cannot capture `ref struct` variables in lamdba expressions (VERIFY)

## Conclusions

These enhancements to the C# language are designed for performance critical
algorithms where memory allocations can be critical to achieving the
necessary performance. You may find that you don't often use these features in
the code you write. However, these enhancements have been adopted in many locations
in the .NET framework. As more and more APIs make use of these features, you'll
see the performance of your own applications improve.
