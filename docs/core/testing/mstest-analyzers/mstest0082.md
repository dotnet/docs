---
title: "MSTEST0082: A test class inherits a lifecycle or test method from a different MSTest version"
description: "Learn about code analysis rule MSTEST0082: A test class inherits a lifecycle or test method from a different MSTest version"
ms.date: 08/26/2026
f1_keywords:
- MSTEST0082
- InheritedMemberFromDifferentMSTestVersionAnalyzer
helpviewer_keywords:
- InheritedMemberFromDifferentMSTestVersionAnalyzer
- MSTEST0082
author: evangelink
ms.author: amauryleve
ai-usage: ai-assisted
dev_langs:
- CSharp
---
# MSTEST0082: A test class inherits a lifecycle or test method from a different MSTest version

| Property                            | Value                                              |
|-------------------------------------|----------------------------------------------------|
| **Rule ID**                         | MSTEST0082                                         |
| **Title**                           | A test class inherits a lifecycle or test method from a different MSTest version |
| **Category**                        | Usage                                              |
| **Fix is breaking or non-breaking** | Non-breaking                                       |
| **Enabled by default**              | Yes                                                |
| **Default severity**                | Warning                                            |
| **Introduced in version**           | 4.4.0 (preview)                                    |
| **Is there a code fix**             | No                                                 |

> [!IMPORTANT]
> This analyzer is planned for MSTest 4.4 and is available only in preview builds until MSTest 4.4.0 is released.

## Cause

A discoverable test class inherits a public test method or lifecycle method from an assembly that references a different major version of MSTest.

## Rule description

MSTest matches test and lifecycle attributes by exact runtime type identity. MSTest v3 defines these attributes in `Microsoft.VisualStudio.TestPlatform.TestFramework`, while MSTest v4 defines them in `MSTest.TestFramework`. If a base library and a derived test project use different major versions, the adapter silently ignores inherited attributes from the other framework assembly. As a result, inherited tests aren't discovered, and inherited initialization or cleanup methods don't run.

For example, a shared test library built with MSTest v3 might declare:

```csharp
public abstract class SharedTests
{
    [TestMethod] public void InheritedTest() { }
}
```

An MSTest v4 project that derives from the base class triggers the diagnostic:

```csharp
[TestClass]
public sealed class ProductTests : SharedTests { } // Violation
```

The analyzer checks inherited test methods, test initialization and cleanup methods, and class initialization and cleanup methods that are configured to run for derived classes.

## How to fix violations

Reference the same MSTest major version from the base library and the derived test project. Recompile the assembly that declares the base class and, for a custom attribute derived from an MSTest attribute, recompile the assembly that declares the custom attribute.

## When to suppress warnings

Don't suppress warnings from this rule. A violation means that MSTest silently skips inherited tests or lifecycle methods.

## Suppress a warning

If you just want to suppress a single violation, add preprocessor directives to your source file to disable and then re-enable the rule.

```csharp
#pragma warning disable MSTEST0082
// The code that's violating the rule is on this line.
#pragma warning restore MSTEST0082
```

To disable the rule for a file, folder, or project, set its severity to `none` in the [configuration file](../../../fundamentals/code-analysis/configuration-files.md).

```ini
[*.{cs,vb}]
dotnet_diagnostic.MSTEST0082.severity = none
```

For more information, see [How to suppress code analysis warnings](../../../fundamentals/code-analysis/suppress-warnings.md).

## See also

- [Migrate from MSTest v3 to v4](../unit-testing-mstest-migration-v3-v4.md)
- [Test lifecycle](../unit-testing-mstest-writing-tests-lifecycle.md)
