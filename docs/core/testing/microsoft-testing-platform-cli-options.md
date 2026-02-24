---
title: Microsoft.Testing.Platform CLI options reference
description: Find platform and extension command-line options for Microsoft.Testing.Platform in one place.
author: Evangelink
ms.author: amauryleve
ms.date: 02/24/2026
ai-usage: ai-assisted
---

# Microsoft.Testing.Platform CLI options reference

This article gives a central entry point for Microsoft.Testing.Platform command-line options.

## Platform options

For core platform options, see [Microsoft.Testing.Platform overview](./microsoft-testing-platform-intro.md#options).

## Extension options by scenario

Use the following table to find extension options quickly.

| Scenario | Extension documentation |
|---|---|
| Collect code coverage | [Code Coverage extensions](./microsoft-testing-platform-extensions-code-coverage.md) |
| Collect crash or hang dumps | [Diagnostics extensions](./microsoft-testing-platform-extensions-diagnostics.md) |
| Generate test reports (for example TRX) | [Test Reports extensions](./microsoft-testing-platform-extensions-test-reports.md) |
| Use VSTest compatibility features (for example RunSettings bridge and test parameters) | [VSTest Bridge extension](./microsoft-testing-platform-extensions-vstest-bridge.md) |
| Apply hosting-level controls | [Hosting extensions](./microsoft-testing-platform-extensions-hosting.md) |
| Apply policy controls | [Policy extensions](./microsoft-testing-platform-extensions-policy.md) |
| Run tests that use Microsoft Fakes | [Microsoft Fakes extension](./microsoft-testing-platform-extensions-fakes.md) |

## Discover options in your test app

Run your test executable with `--help` to list the options available for your current extension set.

For advanced diagnostics of registered providers and options, run with `--info`.

## See also

- [Microsoft.Testing.Platform overview](./microsoft-testing-platform-intro.md)
- [Microsoft.Testing.Platform extensions](./microsoft-testing-platform-extensions.md)
- [Testing with `dotnet test`](./unit-testing-with-dotnet-test.md)
