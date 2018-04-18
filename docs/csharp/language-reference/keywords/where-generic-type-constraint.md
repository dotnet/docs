---
title: "where (generic type constraint) (C# Reference)"
ms.date: 04/12/2018
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "whereconstraint"
  - "whereconstraint_CSharpKeyword"
helpviewer_keywords: 
  - "where (generic type constraint) [C#]"
author: "BillWagner"
ms.author: "wiwagn"
---
# where (generic type constraint) (C# Reference)

In a generic type definition, the `where` clause is used to specify constraints on the types that can be used as arguments for a type parameter defined in a generic declaration. For example, you can declare a generic class, `MyGenericClass`, such that the type parameter `T` implements the <xref:System.IComparable%601> interface:

[!code-csharp[using an interface constraint](../../../../samples/snippets/csharp/keywords/GenericWhereConstraints.cs#1)]

> [!NOTE]
> For more information on the where clause in a query expression, see [where clause](where-clause.md).

In addition to interface constraints, a `where` clause can include a base class constraint, which states that a type must have the specified class as a base class (or be that class itself) in order to be used as a type argument for that generic type. If such a constraint is used, it must appear before any other constraints on that type parameter. Some types are disallowed as a base class constraint. These restrictions were relaxed beginning with C# 7.3. The following examples shows the types that can now be specified as a base class:

[!code-csharp[using an interface constraint](../../../../samples/snippets/csharp/keywords/GenericWhereConstraints.cs#2)]

The `where` clause can specify that the type is a `class` or a `struct`. The `struct` constraint removes the need to specify a base class constraint of `System.ValueType`. The `System.ValueType` type may not be used as
a base class constraint. The following example shouws both the `class` and `struct` constraints:

[!code-csharp[using the class and struct constraints](../../../../samples/snippets/csharp/keywords/GenericWhereConstraints.cs#3)]

The `where` clause may also include an `unmanaged` constraint. The unmanaged
constraint limits the type parameter to types known as **unmanaged types**.
An **unmanaged type** is a type which is not a reference type and doesn't
contain reference type fields at any level of nesting. The `unmanaged`
constraint makes it easier to write low-level interop code in C#. This constraint
enables reusable routines across all unmanaged types. The `unmanaged` constraint
cannot be combined with the `class` or `struct` constraint. The `unmanaged` constraint
implies the `struct` constraint:

[!code-csharp[using the unmanaged constraint](../../../../samples/snippets/csharp/keywords/GenericWhereConstraints.cs#4)]

The `where` clause may also include a constructor constraint. It is possible to create an instance of a type parameter using the new operator; however, in order to do so the type parameter must be constrained by the constructor constraint, `new()`. The [new() Constraint](new-constraint.md) lets the compiler know that any type argument supplied must have an accessible parameterless--or default-- constructor. For example:

[!code-csharp[using the new constraint](../../../../samples/snippets/csharp/keywords/GenericWhereConstraints.cs#5)]

The `new()` constraint appears last in the `where` clause.  The `new()` constraint cannot be combined with the `struct` or `unmanaged` constraints. All types satisfying those constraints must have an accessible parameterless constructor, making the `new()` constraint redundant.

With multiple type parameters, use one `where` clause for each type parameter, for example:

[!code-csharp[using multiple where constraints](../../../../samples/snippets/csharp/keywords/GenericWhereConstraints.cs#6)]

You can also attach constraints to type parameters of generic methods, like this:

[!code-csharp[where constraints with generic methods](../../../../samples/snippets/csharp/keywords/GenericWhereConstraints.cs#7)]

Notice that the syntax to describe type parameter constraints on delegates is the same as that of methods:

[!code-csharp[where constraints with generic methods](../../../../samples/snippets/csharp/keywords/GenericWhereConstraints.cs#8)]

For information on generic delegates, see [Generic Delegates](../../../csharp/programming-guide/generics/generic-delegates.md).

For details on the syntax and use of constraints, see [Constraints on Type Parameters](../../../csharp/programming-guide/generics/constraints-on-type-parameters.md).

## C# Language Specification

 [!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]

## See Also

 [C# Reference](../../../csharp/language-reference/index.md)  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [Introduction to Generics](../../../csharp/programming-guide/generics/introduction-to-generics.md)  
 [new Constraint](../../../csharp/language-reference/keywords/new-constraint.md)  
 [Constraints on Type Parameters](../../../csharp/programming-guide/generics/constraints-on-type-parameters.md)  
