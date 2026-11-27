---
title: "Auto-implemented property examples"
description: Explore initialization and subsequent changes to auto-implemented properties, and find related examples of controlled state.
ms.date: 11/25/2026
ms.topic: concept-article
ai-usage: ai-assisted
helpviewer_keywords:
  - "auto-implemented properties [C#]"
---
# Auto-implemented property examples

For declaration syntax, property initializers, and custom accessors, see [Declare and initialize properties](../../fundamentals/classes/properties.md).

The following example initializes auto-implemented properties through a constructor. The caller then changes `TotalPurchases` on the existing object:

:::code language="csharp" source="./snippets/properties/AutoImplemented.cs" id="snippet28":::

Public `set` accessors let callers change these values after creation. To control later changes, use get-only properties, `init` accessors, or restricted setters as appropriate. These options control assignment to the property; they don't make an object referenced by the property immutable.

For constructor and factory examples that restrict caller assignments, see [How to implement a lightweight class with automatically implemented properties](./how-to-implement-a-lightweight-class-with-auto-implemented-properties.md).

In an interface, an accessor declaration with a semicolon specifies a contract rather than an auto-implemented property with instance storage. Each implementing type provides the property implementation. See [Interface properties](interface-properties.md).

## See also

- [Declare and initialize properties](../../fundamentals/classes/properties.md)
- [Use auto-implemented properties (style rule IDE0032)](../../../fundamentals/code-analysis/style-rules/ide0032.md)
