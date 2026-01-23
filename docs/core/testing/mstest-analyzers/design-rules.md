---
title: MSTest Design rules (code analysis)
description: Learn about MSTest code analysis design rules.
author: evangelink
ms.author: amauryleve
ms.date: 01/03/2024
---

# MSTest design rules

Design rules help you create and maintain test suites that adhere to proper design and good practices. These rules focus on test structure, best practices, and common patterns that lead to maintainable test code.

## Rules in this category

| Rule ID | Title | Severity | Fix Available |
|---------|-------|----------|---------------|
| [MSTEST0004](mstest0004.md) | Public types should be test classes. | Info | Yes |
| [MSTEST0006](mstest0006.md) | Avoid ExpectedException attribute. | Info | Yes |
| [MSTEST0015](mstest0015.md) | Test method should not be ignored. | None (opt-in) | No |
| [MSTEST0016](mstest0016.md) | Test class should have test method. | Info | No |
| [MSTEST0019](mstest0019.md) | Prefer TestInitialize over constructors. | None (opt-in) | Yes |
| [MSTEST0020](mstest0020.md) | Prefer constructors over TestInitialize. | None (opt-in) | Yes |
| [MSTEST0021](mstest0021.md) | Prefer Dispose over TestCleanup. | None (opt-in) | Yes |
| [MSTEST0022](mstest0022.md) | Prefer TestCleanup over Dispose. | None (opt-in) | Yes |
| [MSTEST0025](mstest0025.md) | Prefer Assert.Fail over always-false conditions. | Info | Yes |
| [MSTEST0029](mstest0029.md) | Public method should be test method. | Info | Yes |
| [MSTEST0036](mstest0036.md) | Do not use shadowing. | Warning | No |
| [MSTEST0044](mstest0044.md) | Prefer TestMethod over DataTestMethod. | Info | Yes |
| [MSTEST0045](mstest0045.md) | Use cooperative cancellation for timeout. | Info | Yes |

## Common scenarios

### Test class structure

When creating test classes, these rules help ensure proper design:

- **[MSTEST0004](mstest0004.md)**: Keep helper classes internal, only test classes should be public.
- **[MSTEST0016](mstest0016.md)**: Ensure test classes contain at least one test method.
- **[MSTEST0029](mstest0029.md)**: Public methods in test classes should be test methods.

### Initialization patterns

MSTest supports both constructors and TestInitialize methods. These mutually exclusive rules let you enforce a consistent pattern:

- **[MSTEST0019](mstest0019.md)**: Enforce TestInitialize for initialization (useful for async scenarios).
- **[MSTEST0020](mstest0020.md)**: Enforce constructors for initialization (better for readonly fields).

### Cleanup patterns

Similarly, choose between Dispose and TestCleanup:

- **[MSTEST0021](mstest0021.md)**: Enforce Dispose pattern for cleanup.
- **[MSTEST0022](mstest0022.md)**: Enforce TestCleanup for cleanup.

### Better assertions

- **[MSTEST0006](mstest0006.md)**: Use Assert.ThrowsExactly instead of [ExpectedException] for better precision.
- **[MSTEST0025](mstest0025.md)**: Use Assert.Fail instead of Assert.IsTrue(false).

### Test quality

- **[MSTEST0015](mstest0015.md)**: Flag ignored tests (opt-in rule).
- **[MSTEST0036](mstest0036.md)**: Avoid shadowing base class members.
- **[MSTEST0044](mstest0044.md)**: Use TestMethod unless data-driven testing is needed.
- **[MSTEST0045](mstest0045.md)**: Enable cancellation tokens for timeout handling.

## Related documentation

- [Write tests with MSTest](../unit-testing-mstest-writing-tests.md)
- [Lifecycle](../unit-testing-mstest-writing-tests-lifecycle.md)
- [Attributes](../unit-testing-mstest-writing-tests-attributes.md)
- [Assertions](../unit-testing-mstest-writing-tests-assertions.md)
