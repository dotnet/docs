---
title: "Constraints on type parameters - C# Programming Guide"
ms.custom: seodec18
ms.date: 04/12/2018
helpviewer_keywords: 
  - "generics [C#], type constraints"
  - "type constraints [C#]"
  - "type parameters [C#], constraints"
  - "unbound type parameter [C#]"
---
# Constraints on type parameters (C# Programming Guide)

Constraints inform the compiler about the capabilities a type argument must have. Without any constraints, the type argument could be any type. The compiler can only assume the members of <xref:System.Object?displayProperty=nameWithType>, which is the ultimate base class for any .NET type. For more information, see [Why use constraints](#why-use-constraints). If client code tries to instantiate your class by using a type that is not allowed by a constraint, the result is a compile-time error. Constraints are specified by using the `where` contextual keyword. The following table lists the seven types of constraints:

|Constraint|Description|
|----------------|-----------------|
|`where T : struct`|The type argument must be a value type. Any value type except <xref:System.Nullable%601> can be specified. For more information about nullable types, see [Nullable types](../nullable-types/index.md).|
|`where T : class`|The type argument must be a reference type. This constraint applies also to any class, interface, delegate, or array type.|
|`where T : unmanaged`|The type argument must be an [unmanaged type](../../language-reference/builtin-types/unmanaged-types.md).|
|`where T : new()`|The type argument must have a public parameterless constructor. When used together with other constraints, the `new()` constraint must be specified last.|
|`where T :` *\<base class name>*|The type argument must be or derive from the specified base class.|
|`where T :` *\<interface name>*|The type argument must be or implement the specified interface. Multiple interface constraints can be specified. The constraining interface can also be generic.|
|`where T : U`|The type argument supplied for T must be or derive from the argument supplied for U.|

Some of the constraints are mutually exclusive. All value types must have an accessible parameterless constructor. The `struct` constraint implies the `new()` constraint and the `new()` constraint cannot be combined with the `struct` constraint. The `unmanaged` constraint implies the `struct` constraint. The `unmanaged` constraint cannot be combined with either the `struct` or `new()` constraints.

## Why use constraints

By constraining the type parameter, you increase the number of allowable operations and method calls to those supported by the constraining type and all types in its inheritance hierarchy. When you design generic classes or methods, if you will be performing any operation on the generic members beyond simple assignment or calling any methods not supported by <xref:System.Object?displayProperty=nameWithType>, you will have to apply constraints to the type parameter. For example, the base class constraint tells the compiler that only objects of this type or derived from this type will be used as type arguments. Once the compiler has this guarantee, it can allow methods of that type to be called in the generic class. The following code example demonstrates the functionality you can add to the `GenericList<T>` class (in [Introduction to Generics](introduction-to-generics.md)) by applying a base class constraint.

[!code-csharp[using the class and struct constraints](../../../../samples/snippets/csharp/keywords/GenericWhereConstraints.cs#9)]

The constraint enables the generic class to use the `Employee.Name` property. The constraint specifies that all items of type `T` are guaranteed to be either an `Employee` object or an object that inherits from `Employee`.

Multiple constraints can be applied to the same type parameter, and the constraints themselves can be generic types, as follows:

[!code-csharp[using the class and struct constraints](../../../../samples/snippets/csharp/keywords/GenericWhereConstraints.cs#10)]

When applying the `where T : class` constraint, avoid the `==` and `!=` operators on the type parameter because these operators will test for reference identity only, not for value equality. This behavior occurs even if these operators are overloaded in a type that is used as an argument. The following code illustrates this point; the output is false even though the <xref:System.String> class overloads the `==` operator.

[!code-csharp[using the class and struct constraints](../../../../samples/snippets/csharp/keywords/GenericWhereConstraints.cs#11)]

The compiler only knows that T is a reference type at compile time and must use the default operators that are valid for all reference types. If you must test for value equality, the recommended way is to also apply the `where T : IEquatable<T>` or `where T : IComparable<T>` constraint and implement the interface in any class that will be used to construct the generic class.

## Constraining multiple parameters

You can apply constraints to multiple parameters, and multiple constraints to a single parameter, as shown in the following example:

[!code-csharp[using the class and struct constraints](../../../../samples/snippets/csharp/keywords/GenericWhereConstraints.cs#12)]

## Unbounded type parameters

 Type parameters that have no constraints, such as T in public class `SampleClass<T>{}`, are called unbounded type parameters. Unbounded type parameters have the following rules:

- The `!=` and `==` operators cannot be used because there is no guarantee that the concrete type argument will support these operators.
- They can be converted to and from `System.Object` or explicitly converted to any interface type.
- You can compare them to [null](../../language-reference/keywords/null.md). If an unbounded parameter is compared to `null`, the comparison will always return false if the type argument is a value type.

## Type parameters as constraints

The use of a generic type parameter as a constraint is useful when a member function with its own type parameter has to constrain that parameter to the type parameter of the containing type, as shown in the following example:

[!code-csharp[using the class and struct constraints](../../../../samples/snippets/csharp/keywords/GenericWhereConstraints.cs#13)]

In the previous example, `T` is a type constraint in the context of the `Add` method, and an unbounded type parameter in the context of the `List` class.

Type parameters can also be used as constraints in generic class definitions. The type parameter must be declared within the angle brackets together with any other type parameters:

[!code-csharp[using the class and struct constraints](../../../../samples/snippets/csharp/keywords/GenericWhereConstraints.cs#14)]

The usefulness of type parameters as constraints with generic classes is limited because the compiler can assume nothing about the type parameter except that it derives from `System.Object`. Use type parameters as constraints on generic classes in scenarios in which you want to enforce an inheritance relationship between two type parameters.

## Unmanaged constraint

Beginning with C# 7.3, you can use the `unmanaged` constraint to specify that the type parameter must be an [unmanaged type](../../language-reference/builtin-types/unmanaged-types.md). The `unmanaged` constraint enables you to write reusable routines to work with types that can be manipulated as blocks of memory, as shown in the following example:

[!code-csharp[using the unmanaged constraint](../../../../samples/snippets/csharp/keywords/GenericWhereConstraints.cs#15)]

The preceding method must be compiled in an `unsafe` context because it uses the `sizeof` operator on a type not known to be a built-in type. Without the `unmanaged` constraint, the `sizeof` operator is unavailable.

## Delegate constraints

Also beginning with C# 7.3, you can use <xref:System.Delegate?displayProperty=nameWithType> or <xref:System.MulticastDelegate?displayProperty=nameWithType> as a base class constraint. The CLR always allowed this constraint, but the C# language disallowed it. The `System.Delegate` constraint enables you to write code that works with delegates in a type-safe manner. The following code defines an extension method that combines two delegates provided they are the same type:

[!code-csharp[using the delegate constraint](../../../../samples/snippets/csharp/keywords/GenericWhereConstraints.cs#16)]

You can use the above method to combine delegates that are the same type:

[!code-csharp[using the unmanaged constraint](../../../../samples/snippets/csharp/keywords/GenericWhereConstraints.cs#17)]

If you uncomment the last line, it won't compile. Both `first` and `test` are delegate types, but they are different delegate types.

## Enum constraints

Beginning in C# 7.3, you can also specify the <xref:System.Enum?displayProperty=nameWithType> type as a base class constraint. The CLR always allowed this constraint, but the C# language disallowed it. Generics using `System.Enum` provide type-safe programming to cache results from using the static methods in `System.Enum`. The following sample finds all the valid values for an enum type, and then builds a dictionary that maps those values to its string representation.

[!code-csharp[using the unmanaged constraint](../../../../samples/snippets/csharp/keywords/GenericWhereConstraints.cs#18)]

The methods used make use of reflection, which has performance implications. You can call this method to build a collection that is cached and reused rather than repeating the calls that require reflection.

You could use it as shown in the following sample to create an enum and build a dictionary of its values and names:

[!code-csharp[using the unmanaged constraint](../../../../samples/snippets/csharp/keywords/GenericWhereConstraints.cs#19)]

[!code-csharp[using the unmanaged constraint](../../../../samples/snippets/csharp/keywords/GenericWhereConstraints.cs#20)]

## See also

- <xref:System.Collections.Generic>
- [C# Programming Guide](../../../csharp/programming-guide/index.md)
- [Introduction to Generics](../../../csharp/programming-guide/generics/index.md)
- [Generic Classes](../../../csharp/programming-guide/generics/generic-classes.md)
- [new Constraint](../../../csharp/language-reference/keywords/new-constraint.md)
