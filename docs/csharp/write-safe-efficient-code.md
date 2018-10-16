---
title: Write safe and efficient code
description: Recent enhancements to the C# language enable you to write verifiable safe code that the performance previously associated with unsafe code. 
ms.date: 11/16/2017
ms.custom: mvc
---

# Write safe and efficient code

New features in C# enable you to write verifiable safe code with better performance metrics. If you carefully apply these new techniques, far fewer scenarios require using unsafe code. The new features make it easier to use references to value types as method arguments and method returns. When done safely, these techniques minimize copying value types. By using value types, you can minimize the number of allocations and garbage collection passes.

Much of the sample code in this article uses features added in C# 7.2. In order to
use those features, you must configure your project to use C# 7.2 or later. For more information on setting the language version see [configure the language version](language-reference/configure-language-version.md).

This article focuses on techniques for efficient resource management. One advantage to using value types is that they often avoid heap allocations. The disadvantage is that they are copied by value. This tradeoff makes it harder to optimize algorithms that operate on large amounts of data. New language features in C# 7.2 provide mechanisms that enable safe efficient code using references to value types. Use these features wisely to minimize both allocations and copy operations. This article explores those new features.

This article focuses on the following resource management techniques:

- Declare a [`readonly struct`](language-reference/keywords/readonly.md#readonly-struct-example) to express that a type is **immutable** and enables the compiler to save copies when using [`in`](language-reference/keywords/in-parameter-modifier.md) parameters.
- Use a [`ref readonly`](language-reference/keywords/ref.md#reference-return-values) return when the return value is a `struct` larger than <xref:System.IntPtr.Size?displayProperty=nameWithType> and the storage lifetime is greater than the method returning the value.
- When the size of a `readonly struct` is bigger than <xref:System.IntPtr.Size?displayProperty=nameWithType> you should pass it as an `in` parameter for performance reasons.
- You should never pass a `struct` as an `in` parameter unless it's declared with the `readonly` modifier because it may negatively affect performance and could lead to an obscure behavior.
- Use a [`ref struct`](language-reference/keywords/ref.md#ref-struct-types), or a `readonly ref struct` such as <xref:System.Span%601> or <xref:System.ReadonlySpan%601> to work with memory as a sequence of bytes.

These techniques force you to balance two competing goals with regard to **references** and **values**. Variables that are [reference types](programming-guide/types/index.md#reference-types) hold a reference to the location in memory. Variables that are [value types](programming-guide/types/index.md#value-types) directly contain their value. These difference highlight the key differences that are important for managing memory resources. **Value types** are typically copied when passed to a method or returned from a method. This includes copying the value of `this` when calling members of a value type. The cost of the copy is related to the size of the type. **Reference types** are allocated on the managed heap. Each new object requires a new allocation, and subsequently must be reclaimed. Both these operations take time. The reference is copied when a reference type is passes as an argument to a method, or returned from a method.

This article uses the following example concept of the 3D point structure to explain these recommendations:

```csharp
public struct Point3D
{
    public double X;
    public double Y;
    public double Z;
}
```

## Declare readonly structs for immutable value types

Declaring a `struct` using the `readonly` modifier informs the compiler that your intent is to create an immutable type. The compiler enforces that design decision with the following rules:

- All field members must be `readonly`
- All properties must be read-only, including auto-implemented properties.

Note that these two rules are sufficient to ensure that no member of a `readonly struct` modifies the state of that struct. The `struct` is immutable. The `Point3D` structure could be defined as an immutable struct as shown in the following example:

```csharp
readonly public struct ReadonlyPoint3D
{
    public ReadonlyPoint3D(double x, double y, double z)
    {
        this.X = x;
        this.Y = y;
        this.Z = z;
    }

    public double X { get; }
    public double Y { get; }
    public double Z { get; }
}
```

## Use `ref readonly return` statements for large structures when possible

You can return values by reference when the value being returned isn't local to the returning method. Returning by reference means that only the reference is copied, not the structure. For example, the following property definition for `Origin` cannot use a `ref` return because the valuer being returned is a local variable:

```csharp
public Point3D Origin {get;} => new Point3D(0,0,0);
```

However, the following property definition can be returned by reference because the returned value is a static member:

```csharp
public struct Point3D
{
    private static Point3D origin = new Point3D(0,0,0);

    // Dangerous! returning a mutable reference to internal storage
    public ref Point3D Origin { get; } => ref origin;

    // other members removed for space
}
```

Because you don't want callers modifying the origin, you should return the value by `readonly ref`:

```csharp
public struct Point3D
{
    private static Point3D origin = new Point3D(0,0,0);

    public ref readonly Point3D Origin { get; } => ref origin;

    // other members removed for space
}
```

Callers make the choice to use the `Origin` property as a `readonly ref` or as a value:

```csharp
// center is a copy, and a value:
var center = Point3D.Origin;

// centerRef is a reference to the static storage:
ref readonly var centerRef = ref Point3D.Origin;
```

Note that the `readonly` modifier is required on the declaration of `centerRef`.

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



## Apply the `in` modifier to `readonly struct` parameters larger than `System.IntPtr.Size`

The `in` keyword complements the existing `ref`
and `out` keywords to pass arguments
by reference. The `in` keyword specifies passing
the argument by reference, but the called method does not modify
the value.

This addition provides a full vocabulary to express your design intent.
Value types are copied when passed to a called method when you don't
specify any of the following modifiers in the method signature. Each of these modifiers specifies
that a variable is passed by reference, avoiding the copy. Each modifier
expresses a different intent:

- `out`: This method sets the value of the argument used as this parameter.
- `ref`: This method may set the value of the argument used as this parameter.
- `in`: This method does not modify the value of the argument used as this parameter.

Add the `in` modifier to pass an argument by reference and declare
your design intent to pass arguments by reference to
avoid unnecessary copying. You do not intend to modify the object used
as that argument. The following code shows an example of a method
that calculates the distance between two points in 3D space.

[!code-csharp[InArgument](../../samples/csharp/reference-semantics/Program.cs#InArgument "Specifying an in argument")]

The arguments are two structures that each contain three doubles. A double is 8 bytes,
so each argument is 24 bytes. By specifying the `in` modifier, you pass a 4-byte
or 8-byte reference to those arguments, depending on the
architecture of the machine. The difference in size is small, but it can add
up when your application calls this method in a tight loop using many different
values.

The `in` modifier complements `out` and `ref` in other ways as well. You
cannot create overloads of a method that differ only in the presence of
`in`, `out`, or `ref`. These new rules extend the same behavior that had always been
defined for `out` and `ref` parameters.

The `in` modifier may be applied to any member that takes parameters:
methods, delegates, lambdas, local functions, indexers, operators.

Another feature of `in` parameters is that you may use literal values or constants
for the argument to an `in` parameter. Also, unlike a `ref` or `out` parameter,
you don't need to apply the `in` modifier at the call site. The following
code shows you two examples of calling the `CalculateDistance` method. The
first uses two local variables passed by reference. The second includes a
temporary variable created as part of the method call.

[!code-csharp[UseInArgument](../../samples/csharp/reference-semantics/Program.cs#UseInArgument "Specifying an In argument")]

You can use the `in` modifier at every location where a `readonly struct` is an
argument. In addition, you can return a `readonly struct` as a `ref return` when
you are returning an object whose lifetime extends beyond the scope of the method
returning the object. These practices improve performance only when the size of the immutable struct is larger than a reference to that struct. Otherwise, it's just as fast, or even faster, to pass the struct by value.

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

To force the compiler to pass read only arguments by reference, specify the `in` modifier
on the arguments at the call site, as shown in the following code:

[!code-csharp[UseInArgument](../../samples/csharp/reference-semantics/Program.cs#ExplicitInArgument "Specifying an In argument")]

This behavior makes it easier to adopt `in` parameters over time in large
codebases where performance gains are possible. You add the `in` modifier
to method signatures first. Then, you can add the `in` modifier at callsites
and create `readonly struct` types to enable the compiler to avoid creating
defensive copies of `in` parameters in more locations.

The `in` parameter designation can also be used with reference types or numeric values. However, the benefits in both cases are minimal, if any.

## Never use mutable structs as in `in` argument

The techniques described above explain how to avoid copies by returning references and passing values by reference. These work only when the argument types are declared as `readonly struct` types. Otherwise, the compiler must create **defensive copies** in many situations to enforce the readonly-ness of any arguments. Consider the following example that calculates the distance of a 3D point from the origin:

[!code-csharp[InArgument](../../samples/csharp/reference-semantics/Program.cs#InArgument "Specifying an in argument")]

The `Point3D` structure is *not* a readonly struct. There are six different property access calls in the body of this method. On first examination, you may have thought these accesses were safe. After all, a `get` accessor should not modify the state of the object. But there's no language rule that enforces that. It's only a common convention. Without that guarantee, the compiler must create a temporary copy of the argument before accessing any member. The temporary storage is created on the stack, the values of the arguments are copied to the temporary storage, and the values are copied to the stack for each member access as the `this` argument. In many situations, this harms performance enough that pass-by-value is faster than pass-by-readonly-reference when the argument type is not a `readonly struct`.

Instead, of the distance calculation uses the immutable struct, `ReadonlyPoint3D`, temporary objects are not needed:

[!code-csharp[readonlyInArgument](../../samples/csharp/reference-semantics/Program.cs#ReadOnlyInArgument "Specifying a readonly in argument")]

The compiler generates more efficient code when you call members of a
`readonly struct`: The `this` reference, instead of a copy of the receiver,
is always an `in` parameter passed by reference to the member method. This optimization
saves more copying when you use a `readonly struct` as an `in` argument.

## Use `ref struct` types to work with blocks or memory on a single stack frame

<<< THIS MOVED TO The ref keywords reference >>>
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

Declaring a struct as `readonly ref` combines the benefits and restrictions of `ref struct` and `readonly struct` declarations. 

The following example demonstrates the declaration of `readonly ref struct`.

```csharp
readonly ref struct ReadOnlyRefPoint2D
{
    public int X { get; }
    public int Y { get; }
    
    public ReadOnlyRefPoint2D(int x, int y) => (X, Y) = (x, y);
}
```


[!code-csharp[ReadonlyOnlyPoint3D](../../samples/csharp/reference-semantics/Point3D.cs#ReadonlyOnlyPoint3D "Defining an immutable structure")]

## Conclusions

Using value types minimizes the number of allocation operations:

- Storage for value types are stack allocated for local variables and method arguments.
- Storage for value types that are members of other objects are allocated as part of that object, not as a separate allocation.
- Storage for value type return values are stack allocated.

Contrast that with reference types in those same situations:

- Storage for reference types are heap allocated for local variables and method arguments. The reference is stored on the stack.
- Storage for reference types that are members of other objects are separately allocated on the heap. The containing object stores the reference.
- Storage for value type return values are heap allocated. The reference to that storage is stored on the stack.

Minimizing allocations comes with tradeoffs. You copy more memory when the size of the `struct` is larger than the size of a reference. A reference is typically 64 or 32 bits, and depends on the target machine CPU.

These tradeoffs generally have minimal performance impact. However, for large structs or larger collections the performance impact increases. The impact can be large in tight loops and hot paths for programs. The remainder of this article provides general guidance for clearly expressing designs with generally good performance. Optimizations require careful measurement and experimentation.

These enhancements to the C# language are designed for performance critical
algorithms where memory allocations can be critical to achieving the
necessary performance. You may find that you don't often use these features in
the code you write. However, these enhancements have been adopted in many locations
in the .NET Framework. As more and more APIs make use of these features, you'll
see the performance of your own applications improve.
