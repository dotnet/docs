---
title: "Objects - create instances of types"
description: C# uses a class or struct definition to define types of objects. In an object-oriented language such as C#, a program consists of objects interacting dynamically.
ms.date: 05/14/2021
helpviewer_keywords: 
  - "objects [C#], about objects"
  - "variables [C#]"
---
# Objects - create instances of types

A class or struct definition is like a blueprint that specifies what the type can do. An object is basically a block of memory that has been allocated and configured according to the blueprint. A program may create many objects of the same class. Objects are also called instances, and they can be stored in either a named variable or in an array or collection. Client code is the code that uses these variables to call the methods and access the public properties of the object. In an object-oriented language such as C#, a typical program consists of multiple objects interacting dynamically.

> [!NOTE]
> Static types behave differently than what is described here. For more information, see [Static Classes and Static Class Members](../../programming-guide/classes-and-structs/static-classes-and-static-class-members.md).

## Struct Instances vs. Class Instances

Because classes are reference types, a variable of a class object holds a reference to the address of the object on the managed heap. If a second variable of the same type is assigned to the first variable, then both variables refer to the object at that address. This point is discussed in more detail later in this article.

Instances of classes are created by using the [`new` operator](../../language-reference/operators/new-operator.md). In the following example, `Person` is the type and `person1` and `person2` are instances, or objects, of that type.

:::code language="csharp" source="./snippets/objects/Program.cs" interactive="try-dotnet":::

Because structs are value types, a variable of a struct object holds a copy of the entire object. Instances of structs can also be created by using the `new` operator, but this isn't required, as shown in the following example:

:::code language="csharp" source="./snippets/objects/Application.cs" interactive="try-dotnet":::

The memory for both `p1` and `p2` is allocated on the thread stack. That memory is reclaimed along with the type or method in which it's declared. This is one reason why structs are copied on assignment. By contrast, the memory that is allocated for a class instance is automatically reclaimed (garbage collected) by the common language runtime when all references to the object have gone out of scope. It isn't possible to deterministically destroy a class object like you can in C++. For more information about garbage collection in .NET, see [Garbage Collection](../../../standard/garbage-collection/index.md).

> [!NOTE]
> The allocation and deallocation of memory on the managed heap is highly optimized in the common language runtime. In most cases there is no significant difference in the performance cost of allocating a class instance on the heap versus allocating a struct instance on the stack.

## Object Identity vs. Value Equality

When you compare two objects for equality, you must first distinguish whether you want to know whether the two variables represent the same object in memory, or whether the values of one or more of their fields are equivalent. If you're intending to compare values, you must consider whether the objects are instances of value types (structs) or reference types (classes, delegates, arrays).

- To determine whether two class instances refer to the same location in memory (which means that they have the same *identity*), use the static <xref:System.Object.Equals%2A?displayProperty=nameWithType> method. (<xref:System.Object?displayProperty=nameWithType> is the implicit base class for all value types and reference types, including user-defined structs and classes.)
- To determine whether the instance fields in two struct instances have the same values, use the <xref:System.ValueType.Equals%2A?displayProperty=nameWithType> method. Because all structs implicitly inherit from <xref:System.ValueType?displayProperty=nameWithType>, you call the method directly on your object as shown in the following example:

  :::code language="csharp" source="./snippets/objects/Equality.cs" ID="Snippet32":::

  The <xref:System.ValueType?displayProperty=nameWithType> implementation of `Equals` uses boxing and reflection in some cases. For information about how to provide an efficient equality algorithm that is specific to your type, see [How to define value equality for a type](../../programming-guide/statements-expressions-operators/how-to-define-value-equality-for-a-type.md). Records are reference types that use value semantics for equality.

- To determine whether the values of the fields in two class instances are equal, you might be able to use the <xref:System.Object.Equals%2A> method or the [== operator](../../language-reference/operators/equality-operators.md#equality-operator-). However, only use them if the class has overridden or overloaded them to provide a custom definition of what "equality" means for objects of that type. The class might also implement the <xref:System.IEquatable%601> interface or the <xref:System.Collections.Generic.IEqualityComparer%601> interface. Both interfaces provide methods that can be used to test value equality. When designing your own classes that override `Equals`, make sure to follow the guidelines stated in [How to define value equality for a type](../../programming-guide/statements-expressions-operators/how-to-define-value-equality-for-a-type.md) and <xref:System.Object.Equals%28System.Object%29?displayProperty=nameWithType>.

## Related Sections

For more information:

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
