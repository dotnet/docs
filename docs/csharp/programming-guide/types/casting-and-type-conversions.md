---
title: "Casting and type conversions"
description: Learn about casting and type conversions, such as implicit, explicit (casts), and user-defined conversions.
ms.date: 02/05/2025
helpviewer_keywords: 
  - "type conversion [C#]"
  - "data type conversion [C#]"
  - "numeric conversions [C#]"
  - "conversions [C#], type"
  - "casting [C#]"
  - "converting types [C#]"
ms.topic: concept-article
---

# Casting and type conversions (C# Programming Guide)

Because C# is statically typed at compile time, after a variable is declared, it can't be declared again or assigned a value of another type unless that type is implicitly convertible to the variable's type. For example, the `string` can't be implicitly converted to `int`. Therefore, after you declare `i` as an `int`, you can't assign the string "Hello" to it, as the following code shows:

```csharp
int i;

// error CS0029: can't implicitly convert type 'string' to 'int'
i = "Hello";
```

However, you might sometimes need to copy a value into a variable or method parameter of another type. For example, you might have an integer variable that you need to pass to a method whose parameter is typed as `double`. Or you might need to assign a class variable to a variable of an interface type. These kinds of operations are called *type conversions*. In C#, you can perform the following kinds of conversions:

- **Implicit conversions**: No special syntax is required because the conversion always succeeds and no data is lost. Examples include conversions from smaller to larger integral types, conversions from derived classes to base classes, and span conversions.

- **Explicit conversions (casts)**: Explicit conversions require a [cast expression](../../language-reference/operators/type-testing-and-cast.md#cast-expression). Casting is required when information might be lost in the conversion, or when the conversion might not succeed for other reasons. Typical examples include numeric conversion to a type that has less precision or a smaller range, and conversion of a base-class instance to a derived class.

- **User-defined conversions**: User-defined conversions use special methods that you can define to enable explicit and implicit conversions between custom types that don't have a base class–derived class relationship. For more information, see [User-defined conversion operators](../../language-reference/operators/user-defined-conversion-operators.md).

- **Conversions with helper classes**: To convert between noncompatible types, such as integers and <xref:System.DateTime?displayProperty=nameWithType> objects, or hexadecimal strings and byte arrays, you can use the <xref:System.BitConverter?displayProperty=nameWithType> class, the <xref:System.Convert?displayProperty=nameWithType> class, and the `Parse` methods of the built-in numeric types, such as <xref:System.Int32.Parse%2A?displayProperty=nameWithType>. For more information, see the following articles:

- [How to convert a byte array to an int](./how-to-convert-a-byte-array-to-an-int.md)
- [How to convert a string to a number](./how-to-convert-a-string-to-a-number.md)
- [How to convert between hexadecimal strings and numeric types](./how-to-convert-between-hexadecimal-strings-and-numeric-types.md)

## Implicit conversions

For built-in numeric types, an implicit conversion can be made when the value to be stored can fit into the variable without being truncated or rounded off. For integral types, this restriction means the range of the source type is a proper subset of the range for the target type. For example, a variable of type [long](../../language-reference/builtin-types/integral-numeric-types.md) (64-bit integer) can store any value that an [int](../../language-reference/builtin-types/integral-numeric-types.md) (32-bit integer) can store. In the following example, the compiler implicitly converts the value of `num` on the right to a type `long` before assigning it to `bigNum`.

:::code language="csharp" source="./snippets/CastingAndConversions/Program.cs" id="ImplicitConversion":::

For a complete list of all implicit numeric conversions, see the [Implicit numeric conversions](../../language-reference/builtin-types/numeric-conversions.md#implicit-numeric-conversions) section of the [Built-in numeric conversions](../../language-reference/builtin-types/numeric-conversions.md) article.

For reference types, an implicit conversion always exists from a class to any one of its direct or indirect base classes or interfaces. No special syntax is necessary because a derived class always contains all the members of a base class.

:::code language="csharp" source="./snippets/CastingAndConversions/Program.cs" id="ConversionToBase":::

## Explicit conversions

However, if a conversion can't be made without a risk of losing information, the compiler requires that you perform an explicit conversion, which is called a *cast*. A cast is a way of explicitly making the conversion. It indicates you're aware data loss might occur, or the cast might fail at run time. To perform a cast, specify the destination type in parentheses before the expression you want converted. The following program casts a [double](../../language-reference/builtin-types/floating-point-numeric-types.md) to an [int](../../language-reference/builtin-types/integral-numeric-types.md). The program doesn't compile without the cast.

:::code language="csharp" source="./snippets/CastingAndConversions/Program.cs" id="ExplicitConversion":::

For a complete list of supported explicit numeric conversions, see the [Explicit numeric conversions](../../language-reference/builtin-types/numeric-conversions.md#explicit-numeric-conversions) section of the [Built-in numeric conversions](../../language-reference/builtin-types/numeric-conversions.md) article.

For reference types, an explicit cast is required if you need to convert from a base type to a derived type:

A cast operation between reference types doesn't change the run-time type of the underlying object; it only changes the type of the value that is being used as a reference to that object. For more information, see [Polymorphism](../../fundamentals/object-oriented/polymorphism.md).

## Type conversion exceptions at run time

In some reference type conversions, the compiler can't determine whether a cast is valid. It's possible for a cast operation that compiles correctly to fail at run time. As shown in the following example, a type cast that fails at run time causes an <xref:System.InvalidCastException> to be thrown.

:::code language="csharp" source="./snippets/CastingAndConversions/Program.cs" id="UnsafeCast":::

Explicitly casting the argument `a` to a `Reptile` makes a dangerous assumption. It's safer to not make assumptions, but rather check the type. C# provides the [`is`](../../language-reference/operators/type-testing-and-cast.md#the-is-operator) operator to enable you to test for compatibility before actually performing a cast. For more information, see [How to safely cast using pattern matching and the as and is operators](../../fundamentals/tutorials/safely-cast-using-pattern-matching-is-and-as-operators.md).

## C# language specification

For more information, see the [Conversions](~/_csharpstandard/standard/conversions.md) section of the [C# language specification](~/_csharpstandard/standard/README.md).

## See also

- [Types](../../fundamentals/types/index.md)
- [Cast expression](../../language-reference/operators/type-testing-and-cast.md#cast-expression)
- [User-defined conversion operators](../../language-reference/operators/user-defined-conversion-operators.md)
- [Generalized Type Conversion](/previous-versions/visualstudio/visual-studio-2013/yy580hbd(v=vs.120))
- [How to convert a string to a number](./how-to-convert-a-string-to-a-number.md)
