---
description: "where (generic type constraint) - C# Reference"
title: "where (generic type constraint) - C# Reference"

ms.date: 04/28/2021
f1_keywords:
  - "whereconstraint"
  - "whereconstraint_CSharpKeyword"
  - "classconstraint_CSharpKeyword"
  - "structconstraint_CSharpKeyword"
  - "enumconstraint_CSharpKeyword"
helpviewer_keywords:
  - "where (generic type constraint) [C#]"
---
# where (generic type constraint) (C# Reference)

The `where` clause in a generic definition specifies constraints on the types that are used as arguments for type parameters in a generic type, method, delegate, or local function. Constraints can specify interfaces, base classes, or require a generic type to be a reference, value, or unmanaged type. They declare capabilities that the type argument must have.

For example, you can declare a generic class, `AGenericClass`, such that the type parameter `T` implements the <xref:System.IComparable%601> interface:

:::code language="csharp" source="snippets/GenericWhereConstraints.cs" ID="Snippet1":::

> [!NOTE]
> For more information on the where clause in a query expression, see [where clause](where-clause.md).

The `where` clause can also include a base class constraint. The base class constraint states that a type to be used as a type argument for that generic type has the specified class as a base class, or is that base class. If the base class constraint is used, it must appear before any other constraints on that type parameter. Some types are disallowed as a base class constraint: <xref:System.Object>, <xref:System.Array>, and <xref:System.ValueType>. Before C# 7.3, <xref:System.Enum>, <xref:System.Delegate>, and <xref:System.MulticastDelegate> were also disallowed as base class constraints. The following example shows the types that can now be specified as a base class:

:::code language="csharp" source="snippets/GenericWhereConstraints.cs" ID="Snippet2":::

In a nullable context in C# 8.0 and later, the nullability of the base class type is enforced. If the base class is non-nullable (for example `Base`), the type argument must be non-nullable. If the base class is nullable (for example `Base?`), the type argument may be either a nullable or non-nullable reference type. The compiler issues a warning if the type argument is a nullable reference type when the base class is non-nullable.

The `where` clause can specify that the type is a `class` or a `struct`. The `struct` constraint removes the need to specify a base class constraint of `System.ValueType`. The `System.ValueType` type may not be used as a base class constraint. The following example shows both the `class` and `struct` constraints:

:::code language="csharp" source="snippets/GenericWhereConstraints.cs" ID="Snippet3":::

In a nullable context in C# 8.0 and later, the `class` constraint requires a type to be a non-nullable reference type. To allow nullable reference types, use the `class?` constraint, which allows both nullable and non-nullable reference types.

The `where` clause may include the `notnull` constraint. The `notnull` constraint limits the type parameter to non-nullable types. The type may be a [value type](../builtin-types/value-types.md) or a non-nullable reference type. The `notnull` constraint is available starting in C# 8.0 for code compiled in a [`nullable enable` context](../../nullable-references.md#nullable-contexts). Unlike other constraints, if a type argument violates the `notnull` constraint, the compiler generates a warning instead of an error. Warnings are only generated in a `nullable enable` context.

The addition of nullable reference types introduces a potential ambiguity in the meaning of `T?` in generic methods. If `T` is a `struct`, `T?` is the same as <xref:System.Nullable%601?displayProperty=nameWithType>. However, if `T` is a reference type, `T?` means that `null` is a valid value. The ambiguity arises because overriding methods can't include constraints.  The new `default` constraint resolves this ambiguity. You'll add it when a base class or interface declares two overloads of a method, one that specifies the `struct` constraint, and one that doesn't have either the `struct` or `class` constraint applied:

:::code language="csharp" source="snippets/GenericWhereConstraints.cs" ID="BaseClass":::

You use the `default` constraint to specify that your derived class overrides the method without the constraint in your derived class, or explicit interface implementation. It's only valid on methods that override base methods, or explicit interface implementations:

:::code language="csharp" source="snippets/GenericWhereConstraints.cs" ID="DerivedClass":::

> [!IMPORTANT]
> Generic declarations that include the `notnull` constraint can be used in a nullable oblivious context, but compiler does not enforce the constraint.

:::code language="csharp" source="snippets/GenericWhereConstraints.cs" ID="NotNull":::

The `where` clause may also include an `unmanaged` constraint. The `unmanaged` constraint limits the type parameter to types known as [unmanaged types](../builtin-types/unmanaged-types.md). The `unmanaged` constraint makes it easier to write low-level interop code in C#. This constraint enables reusable routines across all unmanaged types. The `unmanaged` constraint can't be combined with the `class` or `struct` constraint. The `unmanaged` constraint enforces that the type must be a `struct`:

:::code language="csharp" source="snippets/GenericWhereConstraints.cs" ID="Snippet4":::

The `where` clause may also include a constructor constraint, `new()`. That constraint makes it possible to create an instance of a type parameter using the `new` operator. The [new() Constraint](new-constraint.md) lets the compiler know that any type argument supplied must have an accessible parameterless constructor. For example:

:::code language="csharp" source="snippets/GenericWhereConstraints.cs" ID="Snippet5":::

The `new()` constraint appears last in the `where` clause. The `new()` constraint can't be combined with the `struct` or `unmanaged` constraints. All types satisfying those constraints must have an accessible parameterless constructor, making the `new()` constraint redundant.

With multiple type parameters, use one `where` clause for each type parameter, for example:

:::code language="csharp" source="snippets/GenericWhereConstraints.cs" ID="Snippet6":::

You can also attach constraints to type parameters of generic methods, as shown in the following example:

:::code language="csharp" source="snippets/GenericWhereConstraints.cs" ID="Snippet7":::

Notice that the syntax to describe type parameter constraints on delegates is the same as that of methods:

:::code language="csharp" source="snippets/GenericWhereConstraints.cs" ID="Snippet8":::

For information on generic delegates, see [Generic Delegates](../../programming-guide/generics/generic-delegates.md).

For details on the syntax and use of constraints, see [Constraints on Type Parameters](../../programming-guide/generics/constraints-on-type-parameters.md).

## C# language specification

 [!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]

## See also

- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [Introduction to Generics](../../fundamentals/types/generics.md)
- [new Constraint](./new-constraint.md)
- [Constraints on Type Parameters](../../programming-guide/generics/constraints-on-type-parameters.md)
