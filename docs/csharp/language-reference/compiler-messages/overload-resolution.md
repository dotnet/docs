---
title: Fix errors that involve overload resolution
description: Compiler errors and warnings that indicate a problem in your code related to overload resolution. Learn causes and fixes for these errors.
  - "CS9261"
  - "CS9262"
helpviewer_keywords:
  - "CS9261"
  - "CS9262"
ms.date: 09/10/2024
---
# Resolve errors and warnings that impact overload resolution.

This article covers the following compiler warnings:

- [**CS9261**](#overload-resolution-priority) - *Cannot use '`OverloadResolutionPriorityAttribute`' on an overriding member.*
- [**CS9262**](#overload-resolution-priority) - *Cannot use '`OverloadResolutionPriorityAttribute`' on this member.*

## Overload resolution priority

- **CS9261** - *Cannot use '`OverloadResolutionPriorityAttribute`' on an overriding member.*
- **CS9262** - *Cannot use '`OverloadResolutionPriorityAttribute`' on this member.*

Your code violated the rules for using the <xref:System.Runtime.CompilerServices.OverloadResolutionPriorityAttribute> to favor one overload instead of another. You can't apply the `OverloadResolutionPriorityAttribute` to the following method types:

- Non-indexer properties
- Property, indexer, or event accessors
- Conversion operators
- Lambdas
- Local functions
- Finalizers
- Static constructors

In addition, you can't apply the `OverloadResolutionPriorityAttribute` to an `override` of a `virtual` or `abstract` member. The compiler uses the value from the base type declaration.
