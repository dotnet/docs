---
title: MSTest Performance rules (code analysis)
description: Learn about MSTest code analysis performance rules.
author: evangelink
ms.author: amauryleve
ms.date: 12/20/2023
---

# MSTest performance rules

Rules that support high-performance testing.

Identifier | Name | Description
-----------|------|------------
[MSTEST0001](mstest0001.md) | UseParallelizeAttributeAnalyzer | By default, MSTest runs tests sequentially which can lead to severe performance limitations. It is recommended to enable assembly attribute `[Parallelize]` or if the assembly is known to not be parallelizable, to use explicitly the assembly level attribute `[DoNotParallelize]`.
