---
title: MSTest migration from Legacy Test runner
description: Learn about migrating from Legacy test runner to latest MSTest.
author: nohwnd
ms.author: jajares
ms.date: 08/21/2025
---

# MSTest legacy runner migration guide

This guide assists users in upgrading their MSTest tests that rely on legacy test runner in Visual Studio and VSTest, to move to latest MSTest.

### Who is impacted?

Users who upgrade to VSTest 18.0.0 or newer and encounter error:

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

Version 18 of VSTest removed the ability to run MSTest v1 tests via the legacy runner (running MSTest v1 tests via VSTest remains unaffected.). The legacy runner, also called TMI, TPv0, QTAgent, was removed from VSTest and VisualStudio.

### Solving the error

The error can show up for multiple reasons, typically the reasons that are listed.

#### Using .testsettings file

Providing `.testsettings` file to the run will trigger this error. Test settings files are no longer supported in VSTest and you should replace them with `.runsettings` file.

To migrate from testsettings to run settings you can use the TestSettings migrator tool that is shipped with VisualStudio 2022. See <https://learn.microsoft.com/visualstudio/test/migrate-testsettings-to-runsettings?view=vs-2022>

When moving away from testsettings, please also consider upgrading from MSTest v1 to latest MSTest following [this migration guide](unit-testing-mstest-migration-from-v1-to-v3.md).

#### Setting ForcedLegacyMode in runsettings

Inspect your runsettings file to see if `<ForcedLegacyMode>true</ForcedLegacyMode>` is set explicitly. This will force switching to the legacy MSTest runner. You need to remove this explicit setting.

#### Running Web and Load test (WLT)

Web and Load test workload and adapter was deprecated and removed. If you still have the need to run Web and Load tests, avoid upgrading from VSTest 17.x.

#### Running Coded UI Tests (CUIT)

Coded UI test workload and adapter was deprecated and removed. If you still have the need to run Coded UI tests, avoid upgrading from VSTest 17.x.

#### Running manual tests

Manual test test type was deprecated and removed. If you still have the need to manual tests, avoid upgrading from VSTest 17.x.

#### Generic tests tests

Generic test test type was deprecated and removed. If you still have the need to manual tests, avoid upgrading from VSTest 17.x.
