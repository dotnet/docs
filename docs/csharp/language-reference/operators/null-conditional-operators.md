---
title: "Null-conditional operators - C# Reference"
ms.custom: seodec18
ms.date: 04/03/2015
helpviewer_keywords:
  - "null-conditional operators [C#]"
  - "?. operator [C#]"
  - "?[] operator [C#]"
ms.assetid: 9c7b2c8f-a785-44ca-836c-407bfb6d27f5
---
# ?. and ?[] null-conditional operators (C# Reference)

Tests the value of the left-hand operand for null before performing a member access (`?.`) or index (`?[]`) operation; returns `null` if the left-hand operand evaluates to `null`.

These operators help you write less code to handle null checks, especially for descending into data structures.

```csharp
int? length = customers?.Length; // null if customers is null
Customer first = customers?[0];  // null if customers is null
int? count = customers?[0]?.Orders?.Count();  // null if customers, the first customer, or Orders is null
```

The null-conditional operators are short-circuiting.  If one operation in a chain of conditional member access and index operations returns null, the rest of the chain’s execution stops.  In the following example, `E` doesn't execute if `A`, `B`, or `C` evaluates to null.

```csharp
A?.B?.C?.Do(E);
A?.B?.C?[E];
```

Another use for the null-conditional member access is invoking delegates in a thread-safe way with much less code.  The old way requires code like the following:

```csharp
var handler = this.PropertyChanged;
if (handler != null)
    handler(…);
```

The new way is much simpler:

```csharp
PropertyChanged?.Invoke(…)
```

The new way is thread-safe because the compiler generates code to evaluate `PropertyChanged` one time only, keeping the result in a temporary variable. You need to explicitly call the `Invoke` method because there is no null-conditional delegate invocation syntax `PropertyChanged?(e)`.

## Language specifications

For more information, see [Null-conditional operator](~/_csharplang/spec/expressions.md#null-conditional-operator) in the [C# Language Specification](../language-specification/index.md). The language specification is the definitive source for C# syntax and usage.

## See also

- [?? (null-coalescing operator)](null-coalescing-operator.md)
- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)