---
title: "MSTEST0088: MSTest host test-class injection is not supported by the selected build mode"
description: "Learn about code analysis rule MSTEST0088: MSTest host test-class injection is not supported by the selected build mode"
ms.date: 10/06/2026
f1_keywords:
- MSTEST0088
- TestClassConstructorShouldBeValidAnalyzer
helpviewer_keywords:
- TestClassConstructorShouldBeValidAnalyzer
- MSTEST0088
author: evangelink
ms.author: amauryleve
ai-usage: ai-generated
dev_langs:
- CSharp
- VB
---
# MSTEST0088: MSTest host test-class injection is not supported by the selected build mode

| Property | Value |
|---|---|
| **Rule ID** | MSTEST0088 |
| **Title** | MSTest host test-class injection is not supported by the selected build mode |
| **Category** | Usage |
| **Fix is breaking or non-breaking** | Non-breaking |
| **Enabled by default** | Yes |
| **Default severity** | Error |
| **Introduced in version** | 4.5.0 |
| **Is there a code fix** | No |

## Cause

You enable host-owned MSTest test-class injection through `AddMSTestTestClassInjection` from the experimental `MSTest.Extensions.Hosting` package, but the test project uses an unsupported build mode.

The rule applies to the following settings:

| Build mode | Setting |
|---|---|
| Native AOT | `PublishAot` is `true`. |
| AOT compilation | `RunAOTCompilation` is `true`. |
| MSTest source generation | `EnableMSTestSourceGeneration` is `true`. |
| Browser WebAssembly | `TargetPlatformIdentifier` is `browser`, or `RuntimeIdentifier` contains `browser-wasm`. |

## Rule description

Host-owned test-class injection uses reflection-based activation through `Microsoft.Extensions.DependencyInjection`. That activation path doesn't support Native AOT, AOT compilation, browser WebAssembly, or MSTest source generation.

The analyzer reports this error on calls to `AddMSTestTestClassInjection`. It also recognizes host-owned injection enabled through a referenced assembly that records the registration, even when the test project doesn't call the method directly.

This rule is separate from [MSTEST0063](mstest0063.md), which validates test-class constructors. A valid constructor doesn't make host-owned injection compatible with an unsupported build mode. The experimental API also produces the `MSTESTEXP` diagnostic; suppressing `MSTESTEXP` doesn't suppress MSTEST0088 or resolve the build-mode incompatibility.

The rule remains enabled as an error in every [`MSTestAnalysisMode`](overview.md#mstestanalysismode), including `None`.

## How to fix violations

Choose one of the following approaches:

- To keep host-owned injection, use a supported build mode. Disable the applicable AOT or source-generation setting, or target a runtime other than browser WebAssembly.
- To keep the selected build mode, remove the `AddMSTestTestClassInjection` registration, including registrations in referenced host-setup assemblies. Use test classes with a public parameterless constructor or a public constructor that accepts only an exact <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestContext> parameter.

No automatic code fix is available because the appropriate resolution depends on your test project's host setup and deployment requirements.

## When to suppress errors

Don't suppress this rule. Suppression doesn't make reflection-based host injection compatible with the selected build mode.

## Suppress a diagnostic

To disable the rule for a file, folder, or project, set its severity to `none` in the [configuration file](../../../fundamentals/code-analysis/configuration-files.md).

```ini
[*.{cs,vb}]
dotnet_diagnostic.MSTEST0088.severity = none
```

For more information, see [How to suppress code analysis warnings](../../../fundamentals/code-analysis/suppress-warnings.md).

## See also

- [Create test classes from host services](../unit-testing-mstest-writing-tests-lifecycle.md#create-test-classes-from-host-services)
- [Microsoft.Extensions host integration](../microsoft-testing-platform-extensions-integration.md#host-integration)
- [MSTEST0063: Test classes should have valid constructors](mstest0063.md)
- [MSTest experimental API diagnostics](overview.md#mstestexp)
