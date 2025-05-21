---
title: Value tuples
description: Learn about value tuple structures in .NET.
ms.date: 01/03/2024
ms.topic: article
---
# Value tuples

A value tuple is a data structure that has a specific number and sequence of values. .NET provides the following built-in value tuple types:

- The <xref:System.ValueTuple%601> structure represents a value tuple that has one element.
- The <xref:System.ValueTuple%602> structure represents a value tuple that has two elements.-
- The <xref:System.ValueTuple%603> structure represents a value tuple that has three elements.
- The <xref:System.ValueTuple%604> structure represents a value tuple that has four elements.
- The <xref:System.ValueTuple%605> structure represents a value tuple that has five elements.
- The <xref:System.ValueTuple%606> structure represents a value tuple that has six elements.
- The <xref:System.ValueTuple%607> structure represents a value tuple that has seven elements.
- The <xref:System.ValueTuple%608> structure represents a value tuple that has eight or more elements.

The value tuple types differ from the tuple types (such as <xref:System.Tuple%602>) as follows:

- They are structures (value types) rather than classes (reference types).
- Members such as <xref:System.ValueTuple%602.Item1> and   <xref:System.ValueTuple%602.Item2> are fields rather than properties.
- Their fields are mutable rather than read-only.

The value tuple types provide the runtime implementation that supports [tuples in C#](../csharp/language-reference/builtin-types/value-tuples.md) and struct tuples in F#. In addition to creating a <xref:System.ValueTuple%602> instance by using language syntax, you can call the <xref:System.ValueTuple.Create%2A> factory method.

## See also

- [Tuple types (C# reference)](../csharp/language-reference/builtin-types/value-tuples.md)
