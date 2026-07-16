---
title: "Resolve errors related to index and range expressions"
description: "This article helps you diagnose and correct compiler errors related to index and range expressions"
f1_keywords:
  - "CS8428"
  - "CS8429"
helpviewer_keywords:
  - "CS8428"
  - "CS8429"
ms.date: 07/16/2026
ai-usage: ai-assisted
---
# Resolve errors related to index and range expressions

This article covers the following compiler errors:

<!-- The text in this list generates issues for Acrolinx, because they don't use contractions.
That's by design. The text closely matches the text of the compiler error / warning for SEO purposes.
 -->
- [**CS8428**](#implicit-index-and-range-indexers): *Invocation of implicit Index Indexer cannot name the argument.*
- [**CS8429**](#implicit-index-and-range-indexers): *Invocation of implicit Range Indexer cannot name the argument.*

## Implicit index and range indexers

- **CS8428**: *Invocation of implicit Index Indexer cannot name the argument.*
- **CS8429**: *Invocation of implicit Range Indexer cannot name the argument.*

The compiler can synthesize an indexer for the [index from end (`^`) and range (`..`) operators](../operators/member-access-operators.md#index-from-end-operator-) when a type has the required `Length` or `Count` member, an `int` indexer, or a compatible `Slice` method. Calls to those implicit `Index` or `Range` indexers must use positional arguments. Remove the argument name from the invocation and pass the `Index` or `Range` value positionally (**CS8428**, **CS8429**).
