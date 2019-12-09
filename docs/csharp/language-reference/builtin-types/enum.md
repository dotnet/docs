---
title: "Enumeration types - C# reference"
description: "Learn about C# enumeration types that represent a set of named constants and how to define them with the `enum` keyword"
ms.date: 12/09/2019
f1_keywords:
  - "enum"
  - "enum_CSharpKeyword"
helpviewer_keywords:
  - "enum keyword [C#]"
  - "enum type [C#]"
  - "enumeration type [C#]"
  - "bit flags [C#]"
ms.assetid: bbeb9a0f-e9b3-41ab-b0a6-c41b1a08974c
---
# Enumeration types (C# reference)

An enumeration type (or enum type) is a value type that represents a set of named integral constants. To define an enumeration type, use the `enum` keyword and specify the names of *enum members*:

```csharp
enum Season
{
    Spring,
    Summer,
    Autumn,
    Winter
}
```

An enumeration type has an underlying type, which can be any [integral numeric type](integral-numeric-types.md) and is `int` by default. Each enum member has an associated constant value of the underlying type. By default, if an enum member is not the first declared member, its associated value is the associated value of the preceding enum member increased by one; otherwise, it's zero. You can explicitly specify an underlying type or associated constant values, as the following example shows:

```csharp
enum ErrorCode : ushort
{
    None = 0,
    Unknown = 1,
    ConnectionLost = 100,
    OutlierReading = 200
}
```

The default value of an enumeration type `E` is the value produced by expression `(E)0`.

> [!NOTE]
> If you don't specify associated values of enum members, the first declared enum member has the associated value 0 and is the default value of an enumeration type.
>
> If you explicitly specify associated values of enum members and want to ensure that the default value of an enumeration type is a declared value, declare an enum member with the associated value 0.

The <xref:System.Enum?displayProperty=nameWithType> type is the abstract base class of all enumeration types. It provides a number of methods to get information about an enumeration type and its values. For more information and examples, see the <xref:System.Enum?displayProperty=nameWithType> API reference page.

Beginning with C# 7.3, you can use `System.Enum` in a base class constraint (that is known as the [enum constraint](../../programming-guide/generics/constraints-on-type-parameters.md#enum-constraints)) to specify that a type parameter is an enumeration type.

You cannot define a method inside the definition of an enumeration type, but you can create an [extension method](../../programming-guide/classes-and-structs/extension-methods.md) to add functionality to an enumeration type.

Like with any [constant](../../programming-guide/classes-and-structs/constants.md), all references to individual values of an enumeration type are replaced with the corresponding integral values at compile time.

## Conversions

For an enumeration type `E` with an underlying type `U`, there exist explicit conversions from `E` to `U` and from `U` to `E`. If you [cast](../operators/type-testing-and-cast.md#cast-operator-) an enum value of type `E` to an underlying type `U`, the result is the associated integral value of an enum member. You can cast any value of an underlying type `U` to type `E`:

[!code-csharp[enum conversions](~/samples/csharp/language-reference/builtin-types/EnumType.cs#Conversions)]

Use the <xref:System.Enum.IsDefined%2A?displayProperty=nameWithType> method to determine whether an enumeration type contains an enum member with the certain associated value.

For any enumeration type, there exist [boxing and unboxing](../../programming-guide/types/boxing-and-unboxing.md) conversions to and from the <xref:System.Enum?displayProperty=nameWithType> type, respectively.

## Enumeration types as bit flags

You typically use an enumeration type to represent a set of mutually exclusive values. However, in some scenarios, a combination of enumeration values can also be a meaningful enumeration value. Then, you can define only those enum members that represent a bit field in an enumeration value and use the [bitwise logical operators](../operators/bitwise-and-shift-operators.md#enumeration-logical-operators) to combine enumeration values. The associated values of the enum members that represent a bit field should be the powers of two. To indicate that an enumeration type declares bit fields, apply the [Flags](xref:System.FlagsAttribute) attribute to it. The following example defines the `Days` enumeration type and shows the behavior of the bitwise operators with its instances.

[!code-csharp[enum flags](~/samples/csharp/language-reference/builtin-types/EnumType.cs#Flags)]

Instead of the `&` and `==` operators, you also can use the <xref:System.Enum.HasFlag%2A?displayProperty=nameWithType> method to determine whether one or more bit fields are set in an instance of an enumeration type.

For more information and examples, see the <xref:System.FlagsAttribute?displayProperty=nameWithType> API reference page and the [Non-exclusive members and the Flags attribute](/dotnet/api/system.enum#non-exclusive-members-and-the-flags-attribute) section of the <xref:System.Enum?displayProperty=nameWithType> API reference page.

## C# language specification

For more information, see the following sections of the [C# language specification](~/_csharplang/spec/introduction.md):

- [Enums](~/_csharplang/spec/enums.md)
- [Enum values and operations](~/_csharplang/spec/enums.md#enum-values-and-operations)
- [Enumeration logical operators](~/_csharplang/spec/expressions.md#enumeration-logical-operators)
- [Enumeration comparison operators](~/_csharplang/spec/expressions.md#enumeration-comparison-operators)
- [Explicit enumeration conversions](~/_csharplang/spec/conversions.md#explicit-enumeration-conversions)
- [Implicit enumeration conversions](~/_csharplang/spec/conversions.md#implicit-enumeration-conversions)

## See also

- [C# reference](../index.md)
- [Enumeration format strings](../../../standard/base-types/enumeration-format-strings.md)
- [Enum naming conventions](../../../standard/design-guidelines/names-of-classes-structs-and-interfaces.md#naming-enumerations)
- [switch statement](../keywords/switch.md)
