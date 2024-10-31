---
title: System.Nullable<T> structure
description: Learn about the System.Nullable<T> structure.
ms.date: 10/31/2024
---
# System.Nullable\<T> structure

[!INCLUDE [context](includes/context.md)]

The <xref:System.Nullable> class represents a value type that can be assigned `null`.

A type is said to be nullable if it can be assigned a value or can be assigned `null`, which means the type has no value whatsoever. By default, all reference types, such as <xref:System.String>, are nullable, but all value types, such as <xref:System.Int32>, are not.

In C# and Visual Basic, you mark a value type as nullable by using the `?` notation after the value type. For example, `int?` in C# or `Integer?` in Visual Basic declares an integer value type that can be assigned `null`.

The <xref:System.Nullable%601> structure supports using only a value type as a nullable type because reference types are nullable by design.

The <xref:System.Nullable> class provides complementary support for the <xref:System.Nullable%601> structure. The <xref:System.Nullable> class supports obtaining the underlying type of a nullable type, and comparison and equality operations on pairs of nullable types whose underlying value type does not support generic comparison and equality operations.

## Fundamental properties

The two fundamental members of the <xref:System.Nullable%601> structure are the <xref:System.Nullable%601.HasValue%2A> and <xref:System.Nullable%601.Value%2A> properties. If the <xref:System.Nullable%601.HasValue> property for a <xref:System.Nullable%601> object is `true`, the value of the object can be accessed with the <xref:System.Nullable%601.Value> property. If the <xref:System.Nullable%601.HasValue> property is `false`, the value of the object is undefined and an attempt to access the <xref:System.Nullable%601.Value> property throws an <xref:System.InvalidOperationException>.

## Boxing and unboxing

When a nullable type is boxed, the common language runtime automatically boxes the underlying value of the <xref:System.Nullable%601> object, not the <xref:System.Nullable%601> object itself. That is, if the <xref:System.Nullable%601.HasValue> property is `true`, the contents of the <xref:System.Nullable%601.Value> property is boxed. When the underlying value of a nullable type is unboxed, the common language runtime creates a new <xref:System.Nullable%601> structure initialized to the underlying value.

If the `HasValue` property of a nullable type is `false`, the result of a boxing operation is `null`. Consequently, if a boxed nullable type is passed to a method that expects an object argument, that method must be prepared to handle the case where the argument is `null`. When `null` is unboxed into a nullable type, the common language runtime creates a new <xref:System.Nullable%601> structure and initializes its `HasValue` property to `false`.

## Windows runtime components

You can include a <xref:System.Nullable%601> type as a member of a structure exported in a WinMD library.
