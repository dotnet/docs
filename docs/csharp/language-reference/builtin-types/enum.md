---
title: "Enumeration types"
description: "Learn about C# enumeration types that represent a choice or a combination of choices"
ms.date: 12/13/2019
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

An *enumeration type* (or *enum type*) is a [value type](value-types.md) defined by a set of named constants of the underlying [integral numeric](integral-numeric-types.md) type. To define an enumeration type, use the `enum` keyword and specify the names of *enum members*:

```csharp
enum Season
{
    Spring,
    Summer,
    Autumn,
    Winter
}
```

By default, the associated constant values of enum members are of type `int`; they start with zero and increase by one following the definition text order. You can explicitly specify any other [integral numeric](integral-numeric-types.md) type as an underlying type of an enumeration type. You can also explicitly specify the associated constant values, as the following example shows:

```csharp
enum ErrorCode : ushort
{
    None = 0,
    Unknown = 1,
    ConnectionLost = 100,
    OutlierReading = 200
}
```

You cannot define a method inside the definition of an enumeration type. To add functionality to an enumeration type, create an [extension method](../../programming-guide/classes-and-structs/extension-methods.md).

The default value of an enumeration type `E` is the value produced by expression `(E)0`, even if zero doesn't have the corresponding enum member.

You use an enumeration type to represent a choice from a set of mutually exclusive values or a combination of choices. To represent a combination of choices, define an enumeration type as bit flags.

## Enumeration types as bit flags

If you want an enumeration type to represent a combination of choices, define enum members for those choices such that an individual choice is a bit field. That is, the associated values of those enum members should be the powers of two. Then, you can use the [bitwise logical operators `|` or `&`](../operators/bitwise-and-shift-operators.md#enumeration-logical-operators) to combine choices or intersect combinations of choices, respectively. To indicate that an enumeration type declares bit fields, apply the [Flags](xref:System.FlagsAttribute) attribute to it. As the following example shows, you can also include some typical combinations in the definition of an enumeration type.

[!code-csharp[enum flags](snippets/shared/EnumType.cs#Flags)]

For more information and examples, see the <xref:System.FlagsAttribute?displayProperty=nameWithType> API reference page and the [Non-exclusive members and the Flags attribute](/dotnet/api/system.enum#non-exclusive-members-and-the-flags-attribute) section of the <xref:System.Enum?displayProperty=nameWithType> API reference page.

## The System.Enum type and enum constraint

The <xref:System.Enum?displayProperty=nameWithType> type is the abstract base class of all enumeration types. It provides a number of methods to get information about an enumeration type and its values. For more information and examples, see the <xref:System.Enum?displayProperty=nameWithType> API reference page.

You can use `System.Enum` in a base class constraint (that is known as the [enum constraint](../../programming-guide/generics/constraints-on-type-parameters.md#enum-constraints)) to specify that a type parameter is an enumeration type. Any enumeration type also satisfies the `struct` constraint, which is used to specify that a type parameter is a non-nullable value type.

## Conversions

For any enumeration type, there exist explicit conversions between the enumeration type and its underlying integral type. If you [cast](../operators/type-testing-and-cast.md#cast-expression) an enum value to its underlying type, the result is the associated integral value of an enum member.

[!code-csharp[enum conversions](snippets/shared/EnumType.cs#Conversions)]

Use the <xref:System.Enum.IsDefined%2A?displayProperty=nameWithType> method to determine whether an enumeration type contains an enum member with the certain associated value.

For any enumeration type, there exist [boxing and unboxing](../../programming-guide/types/boxing-and-unboxing.md) conversions to and from the <xref:System.Enum?displayProperty=nameWithType> type, respectively.

## C# language specification

For more information, see the following sections of the [C# language specification](~/_csharpstandard/standard/README.md):

- [Enums](~/_csharpstandard/standard/enums.md)
- [Enum values and operations](~/_csharpstandard/standard/enums.md#196-enum-values-and-operations)
- [Enumeration logical operators](~/_csharpstandard/standard/expressions.md#12133-enumeration-logical-operators)
- [Enumeration comparison operators](~/_csharpstandard/standard/expressions.md#12126-enumeration-comparison-operators)
- [Explicit enumeration conversions](~/_csharpstandard/standard/conversions.md#1033-explicit-enumeration-conversions)
- [Implicit enumeration conversions](~/_csharpstandard/standard/conversions.md#1024-implicit-enumeration-conversions)

## See also

- [Enumeration format strings](../../../standard/base-types/enumeration-format-strings.md)
- [Design guidelines - Enum design](../../../standard/design-guidelines/enum.md)
- [Design guidelines - Enum naming conventions](../../../standard/design-guidelines/names-of-classes-structs-and-interfaces.md#naming-enumerations)
- [`switch` expression](../operators/switch-expression.md)
- [`switch` statement](../statements/selection-statements.md#the-switch-statement)
