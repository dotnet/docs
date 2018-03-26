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
The disadvantage is that they are copied by value. This tradeoff
makes it harder to optimize algorithms that operate on large amounts of
data. New language features in C# 7.2 provide mechanisms that enable pass-by-reference
semantics with value types. Use these features wisely to minimize both allocations
and copy operations. This article explores those new features.

Much of the sample code in this article demonstrates features added in C# 7.2. In order to
use those features, you must configure your project to use C# 7.2 or later. 
You can use Visual Studio to select it. For each project, select **Project** from
the menu, then **Properties**. Select the **Build** tab and click **Advanced**. From there,
configure the language version. Choose either "7.2", or "latest".  Or you can
edit the *csproj* file and add the following node:

```XML
  <PropertyGroup>
    <LangVersion>7.2</LangVersion>
  </PropertyGroup>
```

You can use either "7.2" or "latest" for the value.

## Passing arguments by readonly reference

C# 7.2 adds the `in` keyword to complement the existing `ref`
and `out` keywords to pass arguments
by reference. The `in` keyword specifies passing
the argument by reference, but the called method does not modify
the value. 

This addition provides a full vocabulary to express your design intent. 
Value types are copied when passed to a called method when you don't
specify any of the following modifiers in the method signature. Each of these modifiers specifies
that a value type is passed by reference, avoiding the copy. Each modifier
expresses a different intent:

- `out`: This method sets the value of the argument used as this parameter.
- `ref`: This method may set the value of the argument used as this parameter.
- `in`: This method does not modify the value of the argument used as this parameter.

Add the `in` modifier to pass an argument by reference and declare
your design intent to pass arguments by reference to
avoid unnecessary copying. You do not intend to modify the object used
as that argument. The following code shows an example of a method
that calculates the distance between two points in 3D space. 

[!code-csharp[InArgument](../../samples/csharp/reference-semantics/Program.cs#InArgument "Specifying an In argument")]

The arguments are two structures that each contain three doubles. A double is 8 bytes,
so each argument is 24 bytes. By specifying the `in` modifier, you pass a 4-byte
or 8-byte reference to those arguments, depending on the
architecture of the machine. The difference in size is small, but it can quickly add
up when your application calls this method in a tight loop using many different
values.
 
The `in` modifier complements `out` and `ref` in other ways as well. You
cannot create overloads of a method that differ only in the presence of
`in`, `out`, or `ref`. These new rules extend the same behavior that had always been
defined for `out` and `ref` parameters.

The `in` modifier may be applied to any member that takes parameters:
methods, delegates, lambdas, local functions, indexers, operators.

Unlike `ref` and `out` arguments, you may use literal values or constants
for the argument to an `in` parameter. Also, unlike a `ref` or `out` parameter,
you don't need to apply the `in` modifier at the call site. The following
code shows you two examples of calling the `CalculateDistance` method. The
first uses two local variables passed by reference. The second includes a
temporary variable created as part of the method call. 

[!code-csharp[UseInArgument](../../samples/csharp/reference-semantics/Program.cs#UseInArgument "Specifying an In argument")]

There are several ways in which the compiler ensures that the read-only
nature of an `in` argument is enforced.  First of all, the called method
can't directly assign to an `in` parameter. It can't directly assign
to any field of an `in` parameter when that value is a `struct` type. In addition, you cannot pass
an `in` parameter to any method using the `ref` or `out` modifier.
These rules apply to any field of an `in` parameter, provided the
field is a `struct` type and the parameter is also a `struct` type. In fact, these rules
apply for multiple layers of member access provided the types at all levels
of member access are `structs`. 
The compiler enforces that `struct` types passed as  `in` arguments and their
`struct` members are read-only variables when used as arguments to other methods.

The use of `in` parameters avoids the potential performance costs
of making copies. It does not change the semantics of any method call. Therefore,
you do not need to specify the `in` modifier at the call site. However,
omitting the `in` modifier at the call site informs the compiler that it is
allowed to make a copy of the argument for the following reasons:

- There is an implicit conversion but not an identity conversion from the argument type to the parameter type.
- The argument is an expression but does not have a known storage variable.
- An overload exists that differs by the presence or absence of `in`. In that case, the by value overload is a better match.

These rules are useful as you update existing code to use read-only
reference arguments. Inside the called method, you can call any instance
method that uses by value parameters. In
those instances, a copy of the `in` parameter is created. Because the compiler
can create a temporary variable for any `in` parameter, you can also specify default
values for any `in` parameter. The following code specifies the origin
(point 0,0) as the default value for the second point:

[!code-csharp[InArgumentDefault](../../samples/csharp/reference-semantics/Program.cs#InArgumentDefault "Specifying defaults for an in parameter")]

To force the compiler to pass read only arguments by reference, specify the `in` modifer
on the arguments at the call site, as shown in the following code:

[!code-csharp[UseInArgument](../../samples/csharp/reference-semantics/Program.cs#ExplicitInArgument "Specifying an In argument")]

This behavior makes it easier to adopt `in` parameters over time in large
codebases where performance gains are possible. You add the `in` modifier
to method signatures first. Then, you can add the `in` modifier at callsites
and create `readonly struct` types to enable the compiler to avoid creating
defensive copies of `in` parameters in more locations.

The `in` parameter designation can also be used with reference types or numeric values. However, the benefits in both cases are minimal, if any.

## `ref readonly` returns

You may also want to return a value type by reference, but disallow the
caller from modifying that value. Use the `ref readonly` modifier to
express that design intent. It notifies readers
that you are returning a reference to existing data, but not allowing
modification. 

The compiler enforces that the caller cannot modify the reference. Attempts
to assign the value directly generate a compile-time error. However, the compiler
cannot know if any member method modifies the state of the struct.
To ensure that the object is not modified, the compiler creates a copy and
calls member references using that copy. Any modifications are to that
defensive copy. 

It's likely that the library using `Point3D` would often use the origin
throughout the code. Every instance creates a new object on the stack. It may
be advantageous to create a constant and return it by reference. But, if you
return a reference to internal storage, you may want to enforce that
the caller cannot modify the referenced storage. The following code
defines a read-only property that returns a `readonly ref` to a `Point3D`
that specifies the origin.

[!code-csharp[OriginReference](../../samples/csharp/reference-semantics/Point3D.cs#OriginReference "Creating a readonly Origin reference")]

Creating a copy of a ref readonly return is easy: Just assign it to a variable
not declared with the `ref readonly` modifier. The compiler generates code
to copy the object as part of the assignment. 

When you assign a variable to a `ref readonly return`, you can specify either a `ref readonly`
variable, or a by-value copy of the read-only reference:

[!code-csharp[AssignRefReadonly](../../samples/csharp/reference-semantics/Program.cs#AssignRefReadonly "Assigning a ref readonly")]

The first assignment in the preceding code makes a copy of the `Origin` constant and assigns
that copy. The second assigns a reference. Notice that the `readonly` modifier
must be part of the declaration of the variable. The reference to which it refers
can't be modified. Attempts to do so result in a compile-time error.

## `readonly struct` type

Applying `ref readonly` to high-traffic uses of a struct may be sufficient.
Other times, you may want to create an immutable struct. Then you can
always pass by read-only reference. That practice 
removes the defensive copies
that take place when you access methods of a struct used as an `in` parameter.

You can do that by creating a `readonly struct` type. You can add the `readonly`
modifier to a struct declaration. The compiler enforces that all instance members of
the struct are `readonly`; the `struct` must be immutable.

There are other optimizations for a `readonly struct`. You can
use the `in` modifier at every location where a `readonly struct` is an
argument. In addition, you can return a `readonly struct` as a `ref return` when
you are returning an object whose lifetime extends beyond the scope of the method
returning the object.

Finally, the compiler generates more efficient code when you call members of a
`readonly struct`: The `this` reference, instead of a copy of the receiver,
is always an `in` parameter passed by reference to the member method. This optimization
saves more copying when you use a `readonly struct`. The `Point3D` is a great
candidate for this change. The following code shows an updated `ReadonlyPoint3D` structure:

[!code-csharp[ReadonlyOnlyPoint3D](../../samples/csharp/reference-semantics/Point3D.cs#ReadonlyOnlyPoint3D "Defining an immutable structure")]

## `ref struct` type

Another related language feature is the ability to declare a value type that
must be stack allocated. In other words, these types can never be created on the
heap as a member of another class. The primary motivation for this feature
was <xref:System.Span%601> and related structures. <xref:System.Span%601> may contain a managed pointer as one of its members, the other being
the length of the span. It's implemented a bit differently because C#
doesn't support pointers to managed memory outside of an unsafe context. Any
write that changes the pointer and the length is not atomic. That means a
<xref:System.Span%601> would be subject to out of range errors or other type safety violations
were it not constrained to a single stack frame. In addition, putting a
managed pointer on the GC heap typically crashes at JIT time.

You may have similar requirements working with memory created
using [`stackalloc`](language-reference/keywords/stackalloc.md) or
when using memory from interop APIs. You can define your own `ref struct` types
for those needs. In this article, you see examples
using `Span<T>` for simplicity.

The `ref struct` declaration declares a struct of this type must be
on the stack. The language rules ensure the safe use of these types. Other
types declared as `ref struct` include <xref:System.ReadOnlySpan%601>. 

The goal of keeping a `ref struct` type as a stack-allocated variable
introduces several rules that the compiler enforces for all `ref struct`
types.

- You can't box a `ref struct`. You cannot assign a `ref struct` type to a variable of type `object`, `dynamic`, or any interface type.
- You can't declare a `ref struct` as a member of a class or a normal struct.
- You cannot declare local variables that are `ref struct` types in async methods. You can declare them in synchronous methods that return `Task`, `Task<T>` or Task-like types.
- You cannot declare `ref struct` local variables in iterators.
- You cannot capture `ref struct` variables in lambda expressions or local functions.

These restrictions ensure you do not accidentally use a `ref struct`
in a manner that could promote it to the managed heap.

## `readonly ref struct` type

Declaring a struct as `readonly ref` combines the benefits and restrictions of `ref struct` and `readonly struct` delcarations. 

The following example demonstrates the declaration of `readonly ref struct`.

```csharp
readonly ref struct ReadOnlyRefPoint2D
{
    public int X { get; }
    public int Y { get; }
    
    public ReadOnlyRefPoint2D(int x, int y) => (X, Y) = (x, y);
}
```

## Conclusions

These enhancements to the C# language are designed for performance critical
algorithms where memory allocations can be critical to achieving the
necessary performance. You may find that you don't often use these features in
the code you write. However, these enhancements have been adopted in many locations
in the .NET Framework. As more and more APIs make use of these features, you'll
see the performance of your own applications improve.
