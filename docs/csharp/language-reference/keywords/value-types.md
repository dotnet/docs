---
title: "Value types - C# Reference"
ms.custom: seodec18
ms.date: 11/26/2018
f1_keywords: 
  - "cs.valuetypes"
helpviewer_keywords: 
  - "value types [C#]"
  - "types [C#], value types"
  - "C# language, value types"
ms.assetid: 471eb994-2958-49d5-a6be-19b4313f80a3
---
# Value types (C# Reference)

There are two kinds of value types:

- [Structs](struct.md)

- [Enumerations](enum.md)

## Main features of value types

A variable of a value type contains a value of the type. For example, a variable of the `int` type might contain the value `42`. This differs from a variable of a reference type, which contains a reference to an instance of the type, also known as an object. When you assign a new value to a variable of a value type, that value is copied. When you assign a new value to a variable of a reference type, the reference is copied, not the object itself.

All value types are derived implicitly from the <xref:System.ValueType?displayProperty=nameWithType>.

Unlike with reference types, you cannot derive a new type from a value type. However, like reference types, structs can implement interfaces.

Value type variables cannot be `null` by default. However, variables of the corresponding [nullable value types](../../programming-guide/nullable-types/index.md) can be `null`.

Each value type has an implicit parameterless constructor that initializes the default value of that type. For information about default values of value types, see [Default values table](default-values-table.md).

## Simple types

The *simple types* are a set of predefined struct types provided by C# and comprise the following types:

- [Integral types](../builtin-types/integral-numeric-types.md): integer numeric types and the [char](char.md) type
- [Floating-point types](../builtin-types/floating-point-numeric-types.md)
- [bool](bool.md)

The simple types are identified through keywords, but these keywords are simply aliases for predefined struct types in the <xref:System> namespace. For example, [int](../builtin-types/integral-numeric-types.md) is an alias of <xref:System.Int32?displayProperty=nameWithType>. For a complete list of aliases, see [Built-in types table](built-in-types-table.md).

The simple types differ from other struct types in that they permit certain additional operations:

- Simple types can be initialized by using literals. For example, `'A'` is a literal of the type `char` and `2001` is a literal of the type `int`.

- You can declare constants of the simple types with the [const](const.md) keyword. It's not possible to have constants of other struct types.

- Constant expressions, whose operands are all simple type constants, are evaluated at compile time.

For more information, see the [Simple types](~/_csharplang/spec/types.md#simple-types) section of the [C# language specification](../language-specification/index.md).

## Initializing value types

Local variables in C# must be initialized before they are used. For example, you might declare a local variable without initialization as in the following example:

```csharp
int myInt;
```

You cannot use it before you initialize it. You can initialize it using the following statement:

```csharp
myInt = new int();  // Invoke parameterless constructor for int type.
```

This statement is equivalent to the following statement:

```csharp
myInt = 0;         // Assign an initial value, 0 in this example.
```

You can, of course, have the declaration and the initialization in the same statement as in the following examples:

```csharp
int myInt = new int();
```

–or–

```csharp
int myInt = 0;
```

Using the [new](../operators/new-operator.md) operator calls the parameterless constructor of the specific type and assigns the default value to the variable. In the preceding example, the parameterless constructor assigned the value `0` to `myInt`. For more information about values assigned by calling parameterless constructors, see [Default values table](default-values-table.md).

With user-defined types, use [new](../operators/new-operator.md) to invoke the parameterless constructor. For example, the following statement invokes the parameterless constructor of the `Point` struct:

```csharp
var p = new Point(); // Invoke parameterless constructor for the struct.
```

After this call, the struct is considered to be definitely assigned; that is, all its members are initialized to their default values.

For more information about the `new` operator, see [new](../operators/new-operator.md).

For information about formatting the output of numeric types, see [Formatting numeric results table](formatting-numeric-results-table.md).

## See also

- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [C# Keywords](index.md)
- [Types](types.md)
- [Reference types](reference-types.md)
- [Nullable value types](../../programming-guide/nullable-types/index.md)
