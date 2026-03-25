---
title: Resolve errors related to numeric overflow and underflow
description: These compiler errors relate to mathematical operations that may overflow or underflow.
ai-usage: ai-assisted
f1_keywords:
  - "CS8973"
helpviewer_keywords:
  - "CS8973"
ms.date: 03/24/2026
---
# Resolve errors and warnings related to overflow or underflow

This article covers the following compiler errors and warnings:

<!-- The text in this list generates issues for Acrolinx, because they don't use contractions.
That's by design. The text closely matches the text of the compiler error or warning for SEO purposes.
 -->
- [**CS8973**](#overflow-errors): *The operation may overflow at runtime (use 'unchecked' syntax to override)*

## Overflow errors

- **CS8973**: *The operation may overflow at runtime (use 'unchecked' syntax to override)*

To correct these errors, follow these rules:

- Use the `unchecked` context to override overflow warnings (**CS8973**).
