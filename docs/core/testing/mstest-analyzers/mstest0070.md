---
title: "MSTEST0070: [MemberCondition] arguments should be valid"
description: "Learn about code analysis rule MSTEST0070: [MemberCondition] arguments should be valid"
ms.date: 06/19/2026
f1_keywords:
- MSTEST0070
- MemberConditionShouldBeValidAnalyzer
helpviewer_keywords:
- MemberConditionShouldBeValidAnalyzer
- MSTEST0070
author: evangelink
ms.author: amauryleve
ai-usage: ai-assisted
dev_langs:
- CSharp
---
# MSTEST0070: \[MemberCondition] arguments should be valid

| Property                            | Value                                              |
|-------------------------------------|----------------------------------------------------|
| **Rule ID**                         | MSTEST0070                                          |
| **Title**                           | \[MemberCondition] arguments should be valid        |
| **Category**                        | Usage                                              |
| **Fix is breaking or non-breaking** | Non-breaking                                       |
| **Enabled by default**              | Yes                                                |
| **Default severity**                | Warning                                            |
| **Introduced in version**           | 4.3.0                                              |
| **Is there a code fix**             | No                                                 |

## Cause

A `[MemberCondition]` attribute references a member that the test framework can't evaluate. The referenced member must exist on the referenced type, be `public static`, return `bool`, and (for methods) be parameterless.

## Rule description

The `[MemberCondition]` attribute conditionally runs or skips a test class or test method based on the value of one or more static `bool` members. You reference each member by its declaring type and name, for example `[MemberCondition(typeof(MyConditions), nameof(MyConditions.IsEnabled))]`.

Because the member is referenced by name, the test framework resolves it through reflection at run time. If the member doesn't exist, isn't `public`, isn't `static`, doesn't return `bool`, requires parameters, or is a write-only property, evaluating the condition throws an <xref:System.InvalidOperationException> and the test fails. This analyzer surfaces those problems at build time so that typos and refactors don't silently break test gating.

The rule reports a violation when a referenced member:

- Can't be found on the referenced type.
- Isn't `public`.
- Isn't `static`.
- Isn't a property, field, or parameterless method.
- Doesn't return `bool`.
- Is a method that declares parameters.
- Is a property without a getter.

```csharp
public class TestConditions
{
    public static bool IsEnabled => true;
    private static bool IsHidden => true;          // not public
    public bool IsInstance => true;                // not static
    public static int Count => 0;                  // wrong return type
    public static bool IsReady(string mode) => true; // has parameters
}

[TestClass]
public class MyTestClass
{
    [TestMethod]
    [MemberCondition(typeof(TestConditions), "IsEnable")] // Violation - member not found (typo)
    public void Test1()
    {
    }

    [TestMethod]
    [MemberCondition(typeof(TestConditions), nameof(TestConditions.IsInstance))] // Violation - not static
    public void Test2()
    {
    }

    [TestMethod]
    [MemberCondition(typeof(TestConditions), nameof(TestConditions.Count))] // Violation - doesn't return bool
    public void Test3()
    {
    }
}
```

## How to fix violations

Reference a member that is `public static`, returns `bool`, and (for methods) is parameterless. Fix the member name if it's a typo, or adjust the member declaration so it meets the requirements.

```csharp
public class TestConditions
{
    public static bool IsEnabled => true;
}

[TestClass]
public class MyTestClass
{
    [TestMethod]
    [MemberCondition(typeof(TestConditions), nameof(TestConditions.IsEnabled))]
    public void Test1()
    {
    }
}
```

Use `nameof` instead of a string literal so the compiler and this rule keep the reference in sync when you rename the member.

You can also reference a field or a parameterless method, combine several members (they're AND-combined), and use <xref:Microsoft.VisualStudio.TestTools.UnitTesting.ConditionMode> to invert the condition:

```csharp
[TestMethod]
[MemberCondition(
    typeof(TestConditions),
    nameof(TestConditions.IsEnabled),
    nameof(TestConditions.IsSupported))] // runs only when both are true
public void Test2()
{
}

[TestMethod]
[MemberCondition(ConditionMode.Exclude, typeof(TestConditions), nameof(TestConditions.IsLegacy))] // skipped when true
public void Test3()
{
}
```

## When to suppress warnings

Don't suppress warnings from this rule. A `[MemberCondition]` attribute that references an invalid member throws at run time and causes the test to fail rather than evaluate the condition.

## Suppress a warning

If you just want to suppress a single violation, add preprocessor directives to your source file to disable and then re-enable the rule.

```csharp
#pragma warning disable MSTEST0070
// The code that's violating the rule is on this line.
#pragma warning restore MSTEST0070
```

To disable the rule for a file, folder, or project, set its severity to `none` in the [configuration file](../../../fundamentals/code-analysis/configuration-files.md).

```ini
[*.{cs,vb}]
dotnet_diagnostic.MSTEST0070.severity = none
```

For more information, see [How to suppress code analysis warnings](../../../fundamentals/code-analysis/suppress-warnings.md).
