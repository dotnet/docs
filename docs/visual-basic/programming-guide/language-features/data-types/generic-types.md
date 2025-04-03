---
description: "Learn more about: Generic Types in Visual Basic (Visual Basic)"
title: "Generic Types"
ms.date: 01/31/2025
helpviewer_keywords: 
  - "generic interfaces"
  - "data type arguments [Visual Basic], defining"
  - "generic delegates"
  - "arguments [Visual Basic], data types"
  - "Of keyword [Visual Basic], using"
  - "delegates, generic"
  - "constraints, Visual Basic generic types"
  - "generic parameters"
  - "data type parameters"
  - "procedures [Visual Basic], generic"
  - "generic procedures"
  - "data types [Visual Basic], generic"
  - "data types [Visual Basic], as parameters"
  - "generics [Visual Basic], generic types"
  - "data types [Visual Basic], as arguments"
  - "generic classes [Visual Basic], Visual Basic"
  - "parameters [Visual Basic], type"
  - "type arguments"
  - "interfaces [Visual Basic], generic"
  - "generics [Visual Basic]"
  - "types [Visual Basic], generic"
  - "parameters [Visual Basic], generic"
  - "generic structures [Visual Basic]"
  - "generic classes [Visual Basic]"
  - "type parameters"
  - "data type arguments"
  - "structures [Visual Basic], generic"
  - "parameters [Visual Basic], data type"
  - "collections, generic"
  - "classes [Visual Basic], generic"
  - "data type parameters [Visual Basic], defining"
  - "type arguments [Visual Basic], defining"
  - "arguments [Visual Basic], type"
---
# Generic types in Visual Basic (Visual Basic)

A *generic type* is a single programming element that adapts to perform the same functionality for multiple data types. When you define a generic class or procedure, you don't have to define a separate version for each data type for which you might want to perform that functionality.

An analogy is a screwdriver set with removable heads. You inspect the screw and select the correct head for that screw (slotted, crossed, starred). Once you insert the correct head in the screwdriver handle, you perform the exact same function with the screwdriver, namely turning the screw.

:::image type="content" source="./media/generic-types/generic-screwdriver-set.gif" alt-text="Diagram of a screwdriver set with different heads.":::

When you define a generic type, you parameterize it with one or more data types. Type parameters allow code to tailor the data types to its requirements. Your code can declare several different programming elements from the generic element, each one acting on a different set of data types. But the declared elements all perform the identical logic, no matter what data types they're using.

For example, you might want to create and use a queue class that operates on a specific data type such as `String`. You can declare such a class from <xref:System.Collections.Generic.Queue%601?displayProperty=nameWithType>, as the following example shows.

:::code language="visual-basic" source="~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrDataTypes/VB/Class1.vb" id="Snippet1":::

You can now use `stringQ` to work exclusively with `String` values. Because `stringQ` is specific for `String` instead of being generalized for `Object` values, you don't have late binding or type conversion. Generic types save execution time and reduce run-time errors.

For more information on using a generic type, see [How to: Use a Generic Class](how-to-use-a-generic-class.md).

## Example of a generic class

The following example shows a skeleton definition of a generic class.

:::code language="visual-basic" source="~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrDataTypes/VB/Class1.vb" id="Snippet2":::

In the preceding skeleton, `t` is a *type parameter*, that is, a placeholder for a data type that you supply when you declare the class. Elsewhere in your code, you can declare various versions of `classHolder` by supplying various data types for `t`. The following example shows two such declarations.

:::code language="visual-basic" source="~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrDataTypes/VB/Class1.vb" id="Snippet3":::

The preceding statements declare *constructed classes*, in which a specific type replaces the type parameter. This replacement is propagated throughout the code within the constructed class. The following example shows what the `processNewItem` procedure looks like in `integerClass`.

:::code language="visual-basic" source="~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrDataTypes/VB/Class1.vb" id="Snippet4":::

For a more complete example, see [How to: Define a Class That Can Provide Identical Functionality on Different Data Types](how-to-define-a-class-that-can-provide-identical-functionality.md).

## Eligible programming elements

You can define and use generic classes, structures, interfaces, procedures, and delegates. .NET defines several generic classes, structures, and interfaces that represent commonly used generic elements. The <xref:System.Collections.Generic?displayProperty=nameWithType> namespace provides dictionaries, lists, queues, and stacks. Before defining your own generic element, see if it's already available in <xref:System.Collections.Generic?displayProperty=nameWithType>.

Procedures aren't types, but you can define and use generic procedures. See [Generic Procedures in Visual Basic](generic-procedures.md).

## Advantages of generic types

A generic type serves as a basis for declaring several different programming elements, each of which operates on a specific data type. The alternatives to a generic type are:

1. A single type operating on the `Object` data type.
2. A set of *type-specific* versions of the type. Each version is individually coded and operating on one specific data type such as `String`, `Integer`, or a user-defined type such as `customer`.

A generic type has the following advantages over these alternatives:

- **Type Safety.** Generic types enforce compile-time type checking. Types based on `Object` accept any data type, and you must write code to check whether an input data type is acceptable. With generic types, the compiler can catch type mismatches before run time.
- **Performance.** Generic types don't have to *box* and *unbox* data, because each one is specialized for one data type. Operations based on `Object` must box input data types to convert them to `Object` and unbox data destined for output. Boxing and unboxing reduce performance.
    Types based on `Object` are also late-bound, which means that accessing their members requires extra code at run time. Type conversions also reduce performance.  
- **Code Consolidation.** The code in a generic type has to be defined only once. A set of type-specific versions of a type must replicate the same code in each version, with the only difference being the specific data type for that version. With generic types, the type-specific versions are all generated from the original generic type.
- **Code Reuse.** Code that doesn't depend on a particular data type can be reused with various data types if it's generic. You can often reuse it even with a data type that you didn't originally predict.
- **IDE Support.** When you use a constructed type declared from a generic type, the integrated development environment (IDE) can give you more support while you're developing your code. For example, IntelliSense can show you the type-specific options for an argument to a constructor or method.
- **Generic Algorithms.** Abstract algorithms that are type-independent are good candidates for generic types. For example, a generic procedure that sorts items using the <xref:System.IComparable> interface can be used with any data type that implements <xref:System.IComparable>.

## Constraints

Although the code in a generic type definition should be as type-independent as possible, you might need to require a certain capability of any data type supplied to your generic type. For example, if you want to compare two items to sort or collate, their data type must implement the <xref:System.IComparable> interface. You can enforce this requirement by adding a *constraint* to the type parameter.

### Example of a constraint

The following example shows a skeleton definition of a class with a constraint that requires the type argument to implement <xref:System.IComparable>.

:::code language="visual-basic" source="~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrDataTypes/VB/Class1.vb" id="Snippet5":::

If subsequent code attempts to construct a class from `itemManager` supplying a type that doesn't implement <xref:System.IComparable>, the compiler signals an error.

### Types of constraints

Your constraint can specify the following requirements in any combination:

- The type argument must implement one or more interfaces
- The type argument must be of the type of, or inherit from, at most one class
- The type argument must expose a parameterless constructor accessible to the code that creates objects from it
- The type argument must be a *reference type*, or it must be a *value type*

C# code can declare that a type argument must be an [*unmanaged type*](../../../../csharp/programming-guide/generics/constraints-on-type-parameters.md#unmanaged-constraint). Visual Basic enforces this constraint for Visual Basic code that uses a generic type or method that was defined with this constraint (in C#). However, you can't declare an `unmanaged` constraint on a type parameter in Visual Basic.

If you need to impose more than one requirement, you use a comma-separated *constraint list* inside braces (`{ }`). To require an accessible constructor, you include the [New Operator](../../../language-reference/operators/new-operator.md) keyword in the list. To require a reference type, you include the `Class` keyword; to require a value type, you include the `Structure` keyword.  

For more information on constraints, see [Type List](../../../language-reference/statements/type-list.md).

### Example of multiple constraints

The following example shows a skeleton definition of a generic class with a constraint list on the type parameter. In the code that creates an instance of this class, the type argument must implement both the <xref:System.IComparable> and <xref:System.IDisposable> interfaces, be a reference type, and expose an accessible parameterless constructor.

:::code language="visual-basic" source="~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrDataTypes/VB/Class1.vb" id="Snippet6":::

## Important terms

Generic types introduce and use the following terms:

- *Generic Type*. A definition of a class, structure, interface, procedure, or delegate for which you supply at least one data type when you declare it.
- *Type Parameter*. In a generic type definition, a placeholder for a data type you supply when you declare the type.
- *Type Argument*. A specific data type that replaces a type parameter when you declare a constructed type from a generic type.
- *Constraint*. A condition on a type parameter that restricts the type argument you can supply for it. A constraint can require that the type argument implement a particular interface, inherit from a particular class, have an accessible parameterless constructor, or be a reference type or a value type. You can combine these constraints, but you can specify at most one base class.
- *Constructed Type*. A class, structure, interface, procedure, or delegate declared from a generic type by supplying type arguments for its type parameters.

## See also

- [Data Types](index.md)
- [Type Characters](type-characters.md)
- [Value Types and Reference Types](value-types-and-reference-types.md)
- [Type Conversions in Visual Basic](type-conversions.md)
- [Troubleshooting Data Types](troubleshooting-data-types.md)
- [Data Types](../../../language-reference/data-types/index.md)
- [Of](../../../language-reference/statements/of-clause.md)
- [As](../../../language-reference/statements/as-clause.md)
- [Object Data Type](../../../language-reference/data-types/object-data-type.md)
- [Covariance and Contravariance](../../concepts/covariance-contravariance/index.md)
- [Iterators](../../concepts/iterators.md)
