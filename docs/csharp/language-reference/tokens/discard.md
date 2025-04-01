---
description: "A `_` is a discard, a placeholder for an unused variable in an expression"
title: "Discard - _"
ms.date: 12/17/2024
---
# Discard - A `_` acts as a placeholder for a variable

The `_` character serves as a *discard*, which is a placeholder for an unused variable.

There are two uses for the *discard* token:

1. To declare an unused variable. A discard can't be read or accessed.
   - Unused `out` arguments: `var r = M(out int _, out var _, out _);`
   - Unused lambda expression parameters: `Action<int> _ => WriteMessage();`
   - Unused deconstruction arguments: `(int _, var answer) = M();`
1. To match any expression in a [discard pattern](../operators/patterns.md#discard-pattern). You can add a `_` pattern to satisfy exhaustiveness requirements.

The `_` token is a valid identifier in C#. The `_` token is interpreted as a discard only when no valid identifier named `_` is found in scope.

A discard can't be read as a variable. The compiler reports an error if your code reads a discard. The compiler can avoid allocating the storage for a discard in some situations where that is safe.

## See also

- [Tuples](../builtin-types/value-tuples.md)
- [Deconstruction](../tokens/discard.md)
- [Discard pattern](../operators/patterns.md#discard-pattern)
