---
title: "MSTEST0072: '[AssemblyFixtureProvider]' isn't supported with ahead-of-time compilation"
description: "Learn about code analysis rule MSTEST0072: '[AssemblyFixtureProvider]' isn't supported with ahead-of-time compilation"
ms.date: 08/06/2026
f1_keywords:
- MSTEST0072
- AssemblyFixtureProviderNotSupportedWithNativeAotAnalyzer
helpviewer_keywords:
- AssemblyFixtureProviderNotSupportedWithNativeAotAnalyzer
- MSTEST0072
author: evangelink
ms.author: amauryleve
ai-usage: ai-assisted
dev_langs:
- CSharp
---
# MSTEST0072: '\[AssemblyFixtureProvider]' isn't supported with ahead-of-time compilation

| Property                            | Value                                              |
|-------------------------------------|----------------------------------------------------|
| **Rule ID**                         | MSTEST0072                                          |
| **Title**                           | '\[AssemblyFixtureProvider]' isn't supported with ahead-of-time compilation |
| **Category**                        | Usage                                              |
| **Fix is breaking or non-breaking** | Non-breaking                                       |
| **Enabled by default**              | Yes                                                |
| **Default severity**                | Warning                                            |
| **Introduced in version**           | 4.4.0 (preview)                                    |
| **Is there a code fix**             | No                                                 |

> [!IMPORTANT]
> This analyzer is planned for MSTest 4.4 and is available only in preview builds until MSTest 4.4.0 is released.

## Cause

A project applies `[AssemblyFixtureProvider]`, either directly or through a referenced library, while publishing with Native AOT (`PublishAot`) or Blazor WebAssembly AOT (`RunAOTCompilation`).

## Rule description

`[AssemblyFixtureProvider]` discovery walks the runtime assembly reference graph, which requires the runtime to generate dynamic code. Ahead-of-time compilation flavors such as Native AOT and Blazor WebAssembly AOT can't generate dynamic code, so the runtime silently skips discovery, and the fixture's `[AssemblyInitialize]`/`[AssemblyCleanup]` methods never run.

```csharp
// Violation: ignored at run time under Native AOT / Blazor WebAssembly AOT.
[assembly: AssemblyFixtureProvider(typeof(SharedFixtures))]
```

The analyzer reports this diagnostic whether the attribute is applied in the current compilation or on a referenced assembly, because either way the consuming Native AOT test project silently loses its assembly fixtures.

## How to fix violations

Declare the `[AssemblyInitialize]` and `[AssemblyCleanup]` methods directly in the test assembly instead of relying on a shared `[AssemblyFixtureProvider]` library.

```csharp
public static class Fixtures
{
    [AssemblyInitialize]
    public static void Init(TestContext context) { }
}
```

## When to suppress warnings

Don't suppress warnings from this rule for a project that actually publishes with Native AOT or Blazor WebAssembly AOT, because the fixture methods won't run and any state they set up won't exist for your tests. Suppressing is reasonable only if the AOT-published configuration doesn't run the affected tests.

## Suppress a warning

If you just want to suppress a single violation, add preprocessor directives to your source file to disable and then re-enable the rule.

```csharp
#pragma warning disable MSTEST0072
// The code that's violating the rule is on this line.
#pragma warning restore MSTEST0072
```

To disable the rule for a file, folder, or project, set its severity to `none` in the [configuration file](../../../fundamentals/code-analysis/configuration-files.md).

```ini
[*.{cs,vb}]
dotnet_diagnostic.MSTEST0072.severity = none
```

For more information, see [How to suppress code analysis warnings](../../../fundamentals/code-analysis/suppress-warnings.md).

## See also

- [Shared assembly fixtures with AssemblyFixtureProvider](../unit-testing-mstest-writing-tests-lifecycle.md#shared-assembly-fixtures-with-assemblyfixtureprovider)
