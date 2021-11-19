---
title: Write safe and efficient C# code
description: Learn about C# language features that enable you to write safe code that performs as efficiently as unsafe code. 
ms.date: 05/25/2021
ms.technology: csharp-advanced-concepts
ms.custom: mvc
---
# Write safe and efficient C# code

C# provides features that enable you to write verifiable safe code with better performance. If you carefully apply these techniques, fewer scenarios require unsafe code. These features make it easier to use references to value types as method arguments and method returns. When done safely, these techniques minimize copying value types. By using value types, you can minimize the number of allocations and garbage collection passes.

Much of the sample code in this article uses features added in C# 7.2. To use those features, make sure your project isn't configured to use an earlier version. For more information, see [configure the language version](language-reference/configure-language-version.md).

One advantage to using value types is that they often avoid heap allocations. The disadvantage is that they're copied by value. This trade-off makes it harder to optimize algorithms that operate on large amounts of data. The language features highlighted in this article provide mechanisms that enable safe efficient code using references to value types. Use these features wisely to minimize both allocations and copy operations.

Some of the guidance in this article refers to coding practices that are always advisable, not only for the performance benefit. Use the `readonly` keyword when it accurately expresses design intent:

- [Declare immutable structs as `readonly`](#declare-immutable-structs-as-readonly).
- [Declare `readonly` members for mutable structs](#declare-readonly-members-for-mutable-structs).

The article also explains some low-level optimizations that are advisable when you've run a profiler and have identified bottlenecks:

- [Use the `in` parameter modifier](#use-the-in-parameter-modifier).
- [Use `ref readonly return` statements](#use-ref-readonly-return-statements).
- [Use `ref struct` types](#use-ref-struct-types).
- [Use `nint` and `nuint` types](#use-nint-and-nuint-types).

These techniques balance two competing goals:

- Minimize allocations on the heap.

  Variables that are [reference types](./fundamentals/types/index.md#reference-types) hold a reference to a location in memory and are allocated on the managed heap. Only the reference is copied when a reference type is passed as an argument to a method or returned from a method. Each new object requires a new allocation, and later must be reclaimed. Garbage collection takes time.

- Minimize the copying of values.

  Variables that are [value types](./fundamentals/types/index.md#value-types) directly contain their value, and the value is typically copied when passed to a method or returned from a method. This behavior includes copying the value of `this` when calling iterators and async instance methods of structs. The copy operation takes time, depending on the size of the type.

This article uses the following example concept of the 3D-point structure to explain its recommendations:

```csharp
public struct Point3D
{
    public double X;
    public double Y;
    public double Z;
}
```

Different examples use different implementations of this concept.

## Declare immutable structs as `readonly`

Declare a [`readonly struct`](language-reference/builtin-types/struct.md#readonly-struct) to indicate that a type is **immutable**. The `readonly` modifier informs the compiler that your intent is to create an immutable type. The compiler enforces that design decision with the following rules:

- All field members must be read-only.
- All properties must be read-only, including auto-implemented properties.

These two rules are sufficient to ensure that no member of a `readonly struct` modifies the state of that struct. The `struct` is immutable. The `Point3D` structure could be defined as an immutable struct as shown in the following example:

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

Follow this recommendation whenever your design intent is to create an immutable value type. Any performance improvements are an added benefit. The `readonly struct` keywords clearly express your design intent.

## Declare `readonly` members for mutable structs

In C# 8.0 and later, when a struct type is mutable, declare members that don't modify state as [`readonly` members](language-reference/builtin-types/struct.md#readonly-instance-members).

Consider a different application that needs a 3D point structure, but must support mutability. The following version of the 3D point structure adds the `readonly` modifier only to those members that don't modify the structure. Follow this example when your design must support modifications to the struct by some members, but you still want the benefits of enforcing `readonly` on some members:

```csharp
public struct Point3D
{
    public Point3D(double x, double y, double z)
    {
        _x = x;
        _y = y;
        _z = z;
    }

    private double _x;
    public double X
    {
        readonly get => _x;
        set => _x = value;
    }

    private double _y;
    public double Y
    {
        readonly get => _y;
        set => _y = value;
    }

    private double _z;
    public double Z
    {
        readonly get => _z;
        set => _z = value;
    }

    public readonly double Distance => Math.Sqrt(X * X + Y * Y + Z * Z);

    public readonly override string ToString() => $"{X}, {Y}, {Z}";
}
```

The preceding sample shows many of the locations where you can apply the `readonly` modifier: methods, properties, and property accessors. If you use auto-implemented properties, the compiler adds the `readonly` modifier to the `get` accessor for read-write properties. The compiler adds the `readonly` modifier to the auto-implemented property declarations for properties with only a `get` accessor.

Adding the `readonly` modifier to members that don't mutate state provides two related benefits. First, the compiler enforces your intent. That member can't mutate the struct's state. Second, the compiler won't create [defensive copies](#avoid-defensive-copies) of `in` parameters when accessing a `readonly` member. The compiler can make this optimization safely because it guarantees that the `struct` is not modified by a `readonly` member.

## Use `ref readonly return` statements

Use a [`ref readonly`](language-reference/keywords/ref.md#reference-return-values) return when both of the following conditions are true:

- The return value is a `struct` larger than <xref:System.IntPtr.Size%2A?displayProperty=nameWithType>.
- The storage lifetime is greater than the method returning the value.

You can return values by reference when the value being returned isn't local to the returning method. Returning by reference means that only the reference is copied, not the structure. In the following example, the `Origin` property can't use a `ref` return because the value being returned is a local variable:

```csharp
public Point3D Origin => new Point3D(0,0,0);
```

However, the following property definition can be returned by reference because the returned value is a static member:

```csharp
public struct Point3D
{
    private static Point3D origin = new Point3D(0,0,0);

    // Dangerous! returning a mutable reference to internal storage
    public ref Point3D Origin => ref origin;

    // other members removed for space
}
```

You don't want callers modifying the origin, so you should return the value by `ref readonly`:

```csharp
public struct Point3D
{
    private static Point3D origin = new Point3D(0,0,0);

    public static ref readonly Point3D Origin => ref origin;

    // other members removed for space
}
```

Returning `ref readonly` enables you to save copying larger structures and preserve the immutability of your internal data members.

At the call site, callers make the choice to use the `Origin` property as a `ref readonly` or as a value:

[!code-csharp[AssignRefReadonly](../../samples/snippets/csharp/safe-efficient-code/ref-readonly-struct/Program.cs#AssignRefReadonly "Assigning a ref readonly")]

The first assignment in the preceding code makes a copy of the `Origin` constant and assigns that copy. The second assigns a reference. Notice that the `readonly` modifier must be part of the declaration of the variable. The reference to which it refers can't be modified. Attempts to do so result in a compile-time error.

The `readonly` modifier is required on the declaration of `originReference`.

The compiler enforces that the caller can't modify the reference. Attempts to assign the value directly generate a compile-time error. In other cases, the compiler allocates a [defensive copy](#avoid-defensive-copies) unless it can safely use the readonly reference. Static analysis rules determine if the struct could be modified. The compiler doesn't create a defensive copy when the struct is a `readonly struct` or the member is a `readonly` member of the struct. Defensive copies aren't needed to pass the struct as an `in` argument.

## Use the `in` parameter modifier

The following sections explain what the `in` modifier does, how to use it, and when to use it for performance optimization:

- [The `out`, `ref`, and `in` keywords](#the-out-ref-and-in-keywords)
- [Use `in` parameters for large structs](#use-in-parameters-for-large-structs)
- [Optional use of `in` at call site](#optional-use-of-in-at-call-site)
- [Avoid defensive copies](#avoid-defensive-copies)

### The `out`, `ref`, and `in` keywords

The `in` keyword complements the `ref` and `out` keywords to pass arguments by reference. The `in` keyword specifies that the argument is passed by reference, but the called method doesn't modify the value. The `in` modifier can be applied to any member that takes parameters, such as methods, delegates, lambdas, local functions, indexers, and operators.

With the addition of the `in` keyword, C# provides a full vocabulary to express your design intent. Value types are copied when passed to a called method when you don't specify any of the following modifiers in the method signature. Each of these modifiers specifies that a variable is passed by reference, avoiding the copy. Each modifier expresses a different intent:

- `out`: This method sets the value of the argument used as this parameter.
- `ref`: This method may modify the value of the argument used as this parameter.
- `in`: This method doesn't modify the value of the argument used as this parameter.

Add the `in` modifier to pass an argument by reference and declare your design intent to pass arguments by reference to avoid unnecessary copying. You don't intend to modify the object used as that argument.

The `in` modifier complements `out` and `ref` in other ways as well. You can't create overloads of a method that differ only in the presence of
`in`, `out`, or `ref`. These new rules extend the same behavior that had always been defined for `out` and `ref` parameters. Like the `out` and `ref` modifiers, value types aren't boxed because the `in` modifier is applied. Another feature of `in` parameters is that you can use literal values or constants for the argument to an `in` parameter.

The `in` modifier can also be used with reference types or numeric values. However, the benefits in those cases are minimal, if any.

There are several ways in which the compiler enforces the read-only nature of an `in` argument.  First of all, the called method can't directly assign to an `in` parameter. It can't directly assign to any field of an `in` parameter when that value is a `struct` type. In addition, you can't pass an `in` parameter to any method using the `ref` or `out` modifier. These rules apply to any field of an `in` parameter, provided the
field is a `struct` type and the parameter is also a `struct` type. In fact, these rules apply for multiple layers of member access provided the types at all levels of member access are `structs`. The compiler enforces that `struct` types passed as `in` arguments and their `struct` members are read-only variables when used as arguments to other methods.

### Use `in` parameters for large structs

You can apply the `in` modifier to any `readonly struct` parameter, but this practice is likely to improve performance only for value types that are substantially larger than <xref:System.IntPtr.Size%2A?displayProperty=nameWithType>. For simple types (such as `sbyte`, `byte`, `short`, `ushort`, `int`, `uint`, `long`, `ulong`, `char`, `float`, `double`, `decimal` and `bool`, and `enum` types), any potential performance gains are minimal. Some simple types, such as `decimal` at 16 bytes in size, are larger than either 4-byte or 8-byte references but not by enough to make a measurable difference in performance in most scenarios. And performance may degrade by using pass-by-reference for types smaller than <xref:System.IntPtr.Size?displayProperty=nameWithType>.

The following code shows an example of a method that calculates the distance between two points in 3D space.

[!code-csharp[InArgument](../../samples/snippets/csharp/safe-efficient-code/ref-readonly-struct/Program.cs#InArgument "Specifying an in argument")]

The arguments are two structures that each contain three doubles. A double is 8 bytes, so each argument is 24 bytes. By specifying the `in` modifier, you pass a 4-byte or 8-byte reference to those arguments, depending on the architecture of the machine. The difference in size is small, but it can add up when your application calls this method in a tight loop using many different values.

However, the impact of any low-level optimizations like using the `in` modifier should be measured to validate a performance benefit. For example, you might think that using `in` on a [Guid](xref:System.Guid) parameter would be beneficial. The `Guid` type is 16 bytes in size, twice the size of an 8-byte reference. But such a small difference isn't likely to result in a measurable performance benefit unless it's in a method that's in a time critical hot path for your application.

### Optional use of `in` at call site

Unlike a `ref` or `out` parameter, you don't need to apply the `in` modifier at the call site. The following code shows two examples of calling the `CalculateDistance` method. The first uses two local variables passed by reference. The second includes a temporary variable created as part of the method call.

[!code-csharp[UseInArgument](../../samples/snippets/csharp/safe-efficient-code/ref-readonly-struct/Program.cs#UseInArgument "Specifying an In argument")]

Omitting the `in` modifier at the call site informs the compiler that it's allowed to make a copy of the argument for any of the following reasons:

- There exists an implicit conversion but not an identity conversion from the argument type to the parameter type.
- The argument is an expression but doesn't have a known storage variable.
- An overload exists that differs by the presence or absence of `in`. In that case, the by value overload is a better match.

These rules are useful as you update existing code to use read-only reference arguments. Inside the called method, you can call any instance
method that uses by-value parameters. In those instances, a copy of the `in` parameter is created.

Because the compiler may create a temporary variable for any `in` parameter, you can also specify default values for any `in` parameter. The following code specifies the origin (point 0,0,0) as the default value for the second point:

[!code-csharp[InArgumentDefault](../../samples/snippets/csharp/safe-efficient-code/ref-readonly-struct/Program.cs#InArgumentDefault "Specifying defaults for an in parameter")]

To force the compiler to pass read-only arguments by reference, specify the `in` modifier on the arguments at the call site, as shown in the following code:

[!code-csharp[UseInArgument](../../samples/snippets/csharp/safe-efficient-code/ref-readonly-struct/Program.cs#ExplicitInArgument "Specifying an In argument")]

This behavior makes it easier to adopt `in` parameters over time in large codebases where performance gains are possible. You add the `in` modifier to method signatures first. Then you can add the `in` modifier at call sites and create `readonly struct` types to enable the compiler to avoid creating defensive copies of `in` parameters in more locations.

### Avoid defensive copies

Pass a `struct` as the argument for an `in` parameter only if it's declared with the `readonly` modifier or the method accesses only `readonly` members of the struct. Otherwise, the compiler must create *defensive copies* in many situations to ensure that arguments are not mutated. Consider the following example that calculates the distance of a 3D point from the origin:

[!code-csharp[InArgument](../../samples/snippets/csharp/safe-efficient-code/ref-readonly-struct/Program.cs#InArgument "Specifying an in argument")]

The `Point3D` structure is *not* a read-only struct. There are six different property access calls in the body of this method. On first examination, you may think these accesses are safe. After all, a `get` accessor shouldn't modify the state of the object. But there's no language rule that enforces that. It's only a common convention. Any type could implement a `get` accessor that modified the internal state.

Without some language guarantee, the compiler must create a temporary copy of the argument before calling any member not marked with the `readonly` modifier. The temporary storage is created on the stack, the values of the argument are copied to the temporary storage, and the value is copied to the stack for each member access as the `this` argument. In many situations, these copies harm performance enough that pass-by-value is faster than pass-by-read-only-reference when the argument type isn't a `readonly struct` and the method calls members that aren't marked `readonly`. If you mark all methods that don't modify the struct state as `readonly`, the compiler can safely determine that the struct state isn't modified, and a defensive copy is not needed.

If the distance calculation uses the immutable struct, `ReadonlyPoint3D`, temporary objects aren't needed:

[!code-csharp[readonlyInArgument](../../samples/snippets/csharp/safe-efficient-code/ref-readonly-struct/Program.cs#ReadOnlyInArgument "Specifying a readonly in argument")]

The compiler generates more efficient code when you call members of a `readonly struct`. The `this` reference, instead of a copy of the receiver,
is always an `in` parameter passed by reference to the member method. This optimization saves copying when you use a `readonly struct` as an `in` argument.

Don't pass a nullable value type as an `in` argument. The <xref:System.Nullable%601> type isn't declared as a read-only struct. That means the compiler must generate defensive copies for any nullable value type argument passed to a method using the `in` modifier on the parameter declaration.

You can see an example program that demonstrates the performance differences using [BenchmarkDotNet](https://www.nuget.org/packages/BenchmarkDotNet/) in our [samples repository](https://github.com/dotnet/samples/tree/main/csharp/safe-efficient-code/benchmark) on GitHub. It compares passing a mutable struct by value and by reference with passing an immutable struct by value and by reference. The use of the immutable struct and pass by reference is fastest.

## Use `ref struct` types

Use a [`ref struct`](language-reference/builtin-types/struct.md#ref-struct) or a `readonly ref struct`, such as <xref:System.Span%601> or <xref:System.ReadOnlySpan%601>, to work with blocks of memory as a sequence of bytes. The memory used by the span is constrained to a single stack frame. This restriction enables the compiler to make several optimizations. The primary motivation for this feature was <xref:System.Span%601> and related structures. You'll achieve performance improvements from these enhancements by using new and updated .NET APIs that make use of the <xref:System.Span%601> type.

Declaring a struct as `readonly ref` combines the benefits and restrictions of `ref struct` and `readonly struct` declarations. The memory used by the readonly span is restricted to a single stack frame, and the memory used by the readonly span can't be modified.

You may have similar requirements working with memory created using [`stackalloc`](language-reference/operators/stackalloc.md) or when using memory from interop APIs. You can define your own `ref struct` types for those needs.

## Use `nint` and `nuint` types

[Native-sized integer types](language-reference/builtin-types/nint-nuint.md) are 32-bit integers in a 32-bit process or 64-bit integers in a 64-bit process. Use them for interop scenarios, low-level libraries, and to optimize performance in scenarios where integer math is used extensively.

## Conclusions

Using value types minimizes the number of allocation operations:

- Storage for value types is stack-allocated for local variables and method arguments.
- Storage for value types that are members of other objects is allocated as part of that object, not as a separate allocation.
- Storage for value type return values is stack allocated.

Contrast that with reference types in those same situations:

- Storage for reference types is heap allocated for local variables and method arguments. The reference is stored on the stack.
- Storage for reference types that are members of other objects are separately allocated on the heap. The containing object stores the reference.
- Storage for reference type return values is heap allocated. The reference to that storage is stored on the stack.

Minimizing allocations comes with tradeoffs. You copy more memory when the size of the `struct` is larger than the size of a reference. A reference is typically 64 bits or 32 bits, and depends on the target machine CPU.

These tradeoffs generally have minimal performance impact. However, for large structs or larger collections, the performance impact increases. The impact can be large in tight loops and hot paths for programs.

These enhancements to the C# language are designed for performance critical algorithms where minimizing memory allocations is a major factor in achieving the necessary performance. You may find that you don't often use these features in the code you write. However, these enhancements have been adopted throughout .NET. As more APIs make use of these features, you'll see the performance of your applications improve.

## See also

- [in parameter modifier (C# Reference)](language-reference/keywords/in-parameter-modifier.md)
- [ref keyword](language-reference/keywords/ref.md)
- [Ref returns and ref locals](programming-guide/classes-and-structs/ref-returns.md)
