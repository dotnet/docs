---
title: "new operator - C# reference"
ms.custom: seodec18
ms.date: 06/25/2019
helpviewer_keywords: 
  - "new operator keyword [C#]"
ms.assetid: a212b697-a79b-4105-9923-1f7b108036e8
---
# new operator (C# reference)

Introduction.

Both value-type objects such as structs and reference-type objects such as classes are destroyed automatically, but value-type objects are destroyed when their containing context is destroyed, whereas reference-type objects are destroyed by the garbage collector at an unspecified time after the last reference to them is removed. For types that contain resources such as file handles, or network connections, it is desirable to employ deterministic cleanup to ensure that the resources they contain are released as soon as possible. For more information, see [using Statement](using-statement.md).

You can also use the `new` keyword as a [member declaration modifier](../keywords/new-modifier.md) or a [generic type constraint](../keywords/new-constraint.md).

## Constructor invocation

Text.

Used to create objects and invoke constructors. For example:

```csharp
Class1 obj  = new Class1();
```

## Array instantiation

Text.

## Instantiation of anonymous types

Text.

It is also used to create instances of anonymous types:

```csharp
var query = from cust in customers
            select new { Name = cust.Name, Address = cust.PrimaryAddress };
```

## Operator overloadability

A user-defined type cannot overload the `new` operator.

## C# language specification

For more information, see [The new operator](~/_csharplang/spec/expressions.md#the-new-operator) section of the [C# language specification](~/_csharplang/spec/introduction.md).

## See also

- [C# reference](../index.md)
- [C# operators](index.md)
