---
title: Errors and warnings for iterator methods and `yield return`
description: Use article to diagnose and correct compiler errors and warnings when you write iterator methods that use `yield return` to enumerate a sequence of elements.
f1_keywords:
  - "CS9237"
  - "CS9238"
  - "CS9239"
helpviewer_keywords:
  - "CS9237"
  - "CS9238"
  - "CS9239"
ms.date: 07/02/2024
---
# Errors and warnings related to the `yield return` statement and iterator methods

There are numerous *errors* related to the `yield return` statement and iterator methods:

<!-- The text in this list generates issues for Acrolinx, because they don't use contractions.
That's by design. The text closely matches the text of the compiler error / warning for SEO purposes.
 -->
- [**CS9237**](#): *'yield return' should not be used in the body of a lock statement*
- [**CS9238**](#): *Cannot use 'yield return' in an 'unsafe' block*
- [**CS9239**](#): *The `&` operator cannot be used on parameters or local variables in iterator methods.*

In addition, the compiler might produce the following *warning* related to `lock` statements and thread synchronization:

- [**CS9216**](#lock-warning): *A value of type `System.Threading.Lock` converted to a different type will use likely unintended monitor-based locking in `lock` statement.*

## New errors

- **CS9237**: *''yield return' should not be used in the body of a lock statement*
- **CS9238**: *Cannot use 'yield return' in an 'unsafe' block*
- **CS9239**: *The `&` operator cannot be used on parameters or local variables in iterator methods.*

These errors indicate that your code violates safety rules because an iterator returns an element and resumes to generate the next element:

- You can't `yield return` from inside a `lock` statement block. Doing so can cause deadlocks.
- You can't `yield return` from an `unsafe` block. The context for an iterator creates a nested `safe` block within the enclosing `unsafe` block.
- You can't use the `&` operator to take the address of a variable in an iterator method.

You must update your code to remove the constructs that aren't allowed.
