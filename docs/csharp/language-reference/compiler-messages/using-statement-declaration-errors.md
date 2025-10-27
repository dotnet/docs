---
title: Resolve errors related to `using` statements and `using` declarations.
description: These errors indicate an incorrect use of the `using` statement or `using` declarations. Learn about the errors and how to fix them.
f1_keywords:
  - "CS9229"
helpviewer_keywords:
  - "CS9229"
ms.date: 10/27/2025
ai-usage: ai-assisted
---
# Resolve warnings related to the `using` statements and `using` declarations

This article covers the following compiler errors:

<!-- The text in this list generates issues for Acrolinx, because they don't use contractions.
That's be design. The text closely matches the text of the compiler error / warning for SEO purposes.
 -->
- [**CS9229**](#incorrect-using-declaration): *Modifiers cannot be placed on using declarations.*

## Incorrect `using` declaration

- **CS9229**: *Modifiers cannot be placed on using declarations.*

A variable declaration wrapped in a `using` declaration can't include any of the following modifiers:

- `const`
- `static`
- `volatile`
- `readonly`
- Acccessibility modifiers: `public`, `protected`, `internal`, `private`, `protected internal` or `private protected`
