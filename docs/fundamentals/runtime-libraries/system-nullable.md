---
title: System.Nullable class
description: Learn about the System.Nullable class.
ms.date: 12/31/2023
ms.topic: article
---
# System.Nullable class

[!INCLUDE [context](includes/context.md)]

The <xref:System.Nullable> class supports value types that can be assigned `null`.

A type is said to be nullable if it can be assigned a value or can be assigned `null`, which means the type has no value whatsoever. By default, all reference types, such as <xref:System.String>, are nullable, but all value types, such as <xref:System.Int32>, are not.

In C# and Visual Basic, you mark a value type as nullable by using the `?` notation after the value type. For example, `int?` in C# or `Integer?` in Visual Basic declares an integer value type that can be assigned `null`.

The <xref:System.Nullable> class provides complementary support for the <xref:System.Nullable%601> structure. The <xref:System.Nullable> class supports obtaining the underlying type of a nullable type, and comparison and equality operations on pairs of nullable types whose underlying value type does not support generic comparison and equality operations.

## Boxing and unboxing

When a nullable type is boxed, the common language runtime automatically boxes the underlying value of the <xref:System.Nullable%601> object, not the <xref:System.Nullable%601> object itself. That is, if the <xref:System.Nullable%601.HasValue> property is `true`, the contents of the <xref:System.Nullable%601.Value> property is boxed.

If the `HasValue` property of a nullable type is `false`, the result of the boxing operation is `null`. When the underlying value of a nullable type is unboxed, the common language runtime creates a new <xref:System.Nullable%601> structure initialized to the underlying value.
