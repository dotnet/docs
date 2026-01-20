---
title: MSTest Performance rules (code analysis)
description: Learn about MSTest code analysis performance rules.
author: evangelink
ms.author: amauryleve
ms.date: 12/20/2023
---

# MSTest performance rules

Performance rules support high-performance testing by identifying opportunities to optimize test execution speed.

## Rules in this category

| Rule ID | Title | Severity | Fix Available |
|---------|-------|----------|---------------|
| [MSTEST0001](mstest0001.md) | Use Parallelize attribute | Info | Yes |

## Common scenarios

### Test parallelization

By default, MSTest runs tests sequentially, which can significantly impact execution time for large test suites.

- **[MSTEST0001](mstest0001.md)**: Reminds you to explicitly enable parallelization with `[assembly: Parallelize]` or acknowledge sequential execution with `[assembly: DoNotParallelize]`

**Why this matters**: Parallelization can dramatically reduce test execution time by running tests concurrently across multiple threads or processes. However, not all test suites are safe to parallelize (for example, tests that modify shared state). This rule ensures you make a conscious decision about parallelization.

**When to enable parallelization**:

- Tests are independent and don't share state.
- Tests don't rely on execution order.
- Tests don't modify global resources (databases, files, and environment variables).

**When to use DoNotParallelize**:

- Tests have dependencies on shared resources.
- Tests modify global state.
- Tests require specific execution order.
- You're debugging test failures.

## Related documentation

- [Configure MSTest](../unit-testing-mstest-configure.md)
- [Running tests](../unit-testing-mstest-running-tests.md)
