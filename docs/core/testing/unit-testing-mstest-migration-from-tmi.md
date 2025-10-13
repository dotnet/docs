---
title: MSTest migration from Legacy Test runner
description: Learn about migrating from Legacy test runner to latest MSTest.
author: nohwnd
ms.author: jajares
ms.date: 08/21/2025
---

# MSTest legacy runner migration guide

This guide assists you in upgrading your MSTest tests that rely on legacy test runner in Visual Studio and VSTest to the latest MSTest.

### Who is impacted?

If you upgrade to VSTest 18.0.0 or later and encounter the following error, you need to migrate:

```plaintext
MSTest v1 run was offloaded to legacy TestPlatform runner, this is typically caused by:
- using .testsettings file
- setting ForcedLegacyMode in your runsettings file
- running Web and Load test (WLT)
- running Coded UI Tests (CUIT)
- running manual tests
- running generic tests

This runner was removed from the product and can no longer be used. 
```

Version 18 of VSTest removed the ability to run MSTest v1 tests via the legacy runner (running MSTest v1 tests via VSTest remains unaffected.). The legacy runner, also called TMI, TPv0, QTAgent, was removed from VSTest and Visual Studio.

### Resolve the error

The error can appear for multiple reasons:

- [Using a .testsettings file](#using-a-testsettings-file)
- [Setting ForcedLegacyMode](#setting-forcedlegacymode)
- [Web and Load tests (WLT)](web-and-load-tests-wlt)
- [Coded UI tests (CUIT)](#coded-ui-tests-cuit)
- [Manual tests](#manual-tests)
- [Generic tests](#generic-tests)

#### Using a .testsettings file

Providing a `.testsettings` file to the run triggers this error. Test settings files are no longer supported in VSTest. Replace them with `.runsettings` files.

To migrate from testsettings to runsettings, you can use the TestSettings migrator tool that shipped with Visual Studio 2022. For more information, see [Upgrade from .testsettings to .runsettings](/visualstudio/test/migrate-testsettings-to-runsettings).

When moving away from testsettings, consider upgrading from MSTest v1 to latest MSTest following [this migration guide](unit-testing-mstest-migration-from-v1-to-v3.md).

#### Setting ForcedLegacyMode

Inspect your runsettings file to see if `<ForcedLegacyMode>true</ForcedLegacyMode>` is set explicitly. This will force switching to the legacy MSTest runner. You need to remove this explicit setting.

#### Web and Load tests (WLT)

The Web and Load test workload and adapter was deprecated and removed. If you still need to run Web and Load tests, avoid upgrading from VSTest 17.x.

#### Coded UI tests (CUIT)

The Coded UI test workload and adapter was deprecated and removed. If you still need to run Coded UI tests, avoid upgrading from VSTest 17.x.

#### Manual tests

The manual-test test type was deprecated and removed. If you still need to run manual tests, avoid upgrading from VSTest 17.x.

#### Generic tests

The generic-test test type was deprecated and removed. If you still need to run generic tests, avoid upgrading from VSTest 17.x.
