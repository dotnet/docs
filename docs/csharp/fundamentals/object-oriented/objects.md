---
title: "Objects - create instances of types"
description: C# uses a class or struct definition to define types of objects. In an object-oriented language such as C#, a program consists of objects interacting dynamically.
ms.date: 10/13/2025
helpviewer_keywords:
  - "objects [C#], about objects"
  - "variables [C#]"
---
# Objects - create instances of types

A class or struct definition is like a blueprint that specifies what the type can do. An object is a block of memory that the program allocates and configures according to the blueprint. A program might create many objects of the same class. You can also call objects instances. You can store them in a named variable or in an array or collection. Client code uses these variables to call the methods and access the public properties of the object. In an object-oriented language such as C#, a typical program consists of multiple objects interacting dynamically.

> [!NOTE]
> Static types behave differently than what is described in this article. For more information, see [Static Classes and Static Class Members](../../programming-guide/classes-and-structs/static-classes-and-static-class-members.md).

## Struct instances vs. class instances

Because classes are reference types, a variable of a class object holds a reference to the address of the object on the managed heap. If you assign a second variable of the same type to the first variable, both variables refer to the object at that address. This article discusses this point in more detail later.

You create instances of classes by using the [`new` operator](../../language-reference/operators/new-operator.md). In the following example, `Person` is the type and `person1` and `person2` are instances, or objects, of that type.

:::code language="csharp" source="./snippets/objects/Program.cs":::

Because structs are value types, a variable of a struct object holds a copy of the entire object. You can also create instances of structs by using the `new` operator, but you don't need to use it, as shown in the following example:

:::code language="csharp" source="./snippets/objects/Application.cs":::

The thread stack allocates memory for both `p1` and `p2`. The program reclaims that memory along with the type or method in which you declare it. This memory management is one reason why structs are copied on assignment. By contrast, the common language runtime automatically reclaims (garbage collects) the memory it allocates for a class instance when all references to the object go out of scope. You can't deterministically destroy a class object like you can in C++. For more information about garbage collection in .NET, see [Garbage Collection](../../../standard/garbage-collection/index.md).

> [!NOTE]
> The common language runtime highly optimizes the allocation and deallocation of memory on the managed heap. In most cases, there's no significant difference in the performance cost of allocating a class instance on the heap versus allocating a struct instance on the stack.

## Object identity vs. value equality

When you compare two objects for equality, first decide whether you want to know if the two variables represent the same object in memory or if the values of one or more of their fields are equivalent. If you want to compare values, consider whether the objects are instances of value types (structs) or reference types (classes, delegates, arrays).

- Use the static <xref:System.Object.ReferenceEquals*?displayProperty=nameWithType> method to determine whether two class instances refer to the same location in memory (which means that they have the same *identity*). (<xref:System.Object?displayProperty=nameWithType> is the implicit base class for all value types and reference types, including user-defined structs and classes.)
- By default, the <xref:System.ValueType.Equals*?displayProperty=nameWithType> method determines whether the instance fields in two struct instances have the same values. Because all structs implicitly inherit from <xref:System.ValueType?displayProperty=nameWithType>, you call the method directly on your object as shown in the following example:

  :::code language="csharp" source="./snippets/objects/Equality.cs" ID="Snippet32":::

  The default <xref:System.ValueType?displayProperty=nameWithType> implementation of `Equals` uses boxing and reflection in some cases. For information about how to provide an efficient equality algorithm that's specific to your type, see [Implement equality yourself when a type can't be a record](../../language-reference/operators/equality-operators.md#implement-equality-yourself-when-a-type-cant-be-a-record). Records are reference types that use value semantics for equality.

- To determine whether the values of the fields in two class instances are equal, you might be able to use the <xref:System.Object.Equals*> method or the [== operator](../../language-reference/operators/equality-operators.md#equality-operator-). However, only use them if the class has overridden or overloaded them to provide a custom definition of what "equality" means for objects of that type. The class might also implement the <xref:System.IEquatable`1> interface or the <xref:System.Collections.Generic.IEqualityComparer`1> interface. Both interfaces provide methods that can be used to test value equality. When designing your own classes that override `Equals`, make sure to follow the guidelines stated in [Implement equality yourself when a type can't be a record](../../language-reference/operators/equality-operators.md#implement-equality-yourself-when-a-type-cant-be-a-record) and <xref:System.Object.Equals%28System.Object%29?displayProperty=nameWithType>.

## Related sections

For more information, see:

- [Classes](../types/classes.md)
- [Constructors](../../programming-guide/classes-and-structs/constructors.md)
- [Finalizers](../../programming-guide/classes-and-structs/finalizers.md)
- [Events](../../programming-guide/events/index.md)
- [object](../../language-reference/builtin-types/reference-types.md)
- [Inheritance](./inheritance.md)
- [class](../../language-reference/keywords/class.md)
- [Structure types](../../language-reference/builtin-types/struct.md)
- [new Operator](../../language-reference/operators/new-operator.md)
- [Common Type System](../../../standard/base-types/common-type-system.md)
