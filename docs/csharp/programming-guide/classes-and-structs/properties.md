---
title: "Properties and backing fields"
description: Explore how C# properties hide stored values, computed values, validation, and cached results behind a public member.
ms.date: 11/25/2026
ms.topic: concept-article
ai-usage: ai-assisted
helpviewer_keywords:
  - "properties [C#], backing fields"
---
# Properties and backing fields

For property declarations, accessor accessibility, and initialization with `init` and `required`, see [Declare and initialize properties](../../fundamentals/classes/properties.md). The examples here explore how a property hides its implementation from callers.

Properties expose a public way to read and assign values while the type controls storage and validation. Callers use the same member access whether an accessor returns a stored value, computes a result, or reuses a cached result. See [Using properties](using-properties.md) for validation and computed-value examples.

## Properties with backing fields

You can combine a computed property with a private field to cache a result. In the following example, `FullName` formats the string on the first read and stores the result for later reads:

:::code language="csharp" source="./snippets/properties/Person.cs" id="CachedBackingStore":::

This implementation works because callers can't reassign `FirstName` and `LastName` after initialization. If those properties instead have `set` accessors, each change must invalidate the cached `fullName` value. The next example updates both setters so that the next read recalculates the result:

:::code language="csharp" source="./snippets/properties/Person.cs" id="UseBackingFields":::

This version evaluates `FullName` only when needed. It reuses the previously calculated value while that value remains valid. Callers don't need to know about the private fields or the cache; the public property access stays the same.

## Partial properties

Beginning with C# 13, you can create [`partial` properties](../../language-reference/keywords/partial-member.md) in `partial` classes. The implementing declaration for a `partial` property can't be an automatically implemented property. An automatically implemented property uses the same syntax as a declaring partial property declaration.

## See also

- [Declare and initialize properties](../../fundamentals/classes/properties.md)
- [Using properties](using-properties.md)
- [Indexers](../indexers/index.md)
- [Properties in the C# specification](~/_csharpstandard/standard/classes.md#157-properties)
