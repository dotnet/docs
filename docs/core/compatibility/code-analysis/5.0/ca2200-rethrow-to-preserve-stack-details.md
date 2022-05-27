---
title: "Breaking change: CA2200: Rethrow to preserve stack details"
description: Learn about the breaking change in .NET 5 caused by the enablement of code analysis rule CA2200.
ms.date: 09/03/2020
---
# Warning CA2200: Rethrow to preserve stack details

.NET code analyzer rule [CA2200](/visualstudio/code-quality/ca2200) is enabled, by default, starting in .NET 5. It produces a build warning for any `catch` blocks that rethrow an exception and the exception is explicitly specified in the `throw` statement.

## Change description

Starting in .NET 5, the .NET SDK includes [.NET source code analyzers](../../../../fundamentals/code-analysis/overview.md). Several of these rules are enabled, by default, including [CA2200](/visualstudio/code-quality/ca2200). If your project contains code that violates this rule and is configured to treat warnings as errors, this change could break your build.

Rule CA2200 flags code where exceptions are rethrown and the exception variable is specified in the `throw` statement. When an exception is thrown, part of the information it carries is the stack trace. The stack trace is a list of the method call hierarchy that starts with the method that throws the exception and ends with the method that catches the exception. If an exception is rethrown by specifying the exception in the `throw` statement, the stack trace restarts at the current method and the list of method calls between the original method that threw the exception and the current method is lost. To keep the original stack trace information with the exception, use the `throw` statement without specifying the exception.

The following code snippet does not produce a warning for rule CA2200. The commented line *would* trigger a violation, however.

```csharp
catch (ArithmeticException e)
{
    // throw e;
    throw;
}
```

## Version introduced

5.0

## Recommended action

- Rethrow exceptions without specifying the exception explicitly. For more information, see [CA2200](/visualstudio/code-quality/ca2200).

- To disable code analysis completely, set `EnableNETAnalyzers` to `false` in your project file. For more information, see [EnableNETAnalyzers](../../../project-sdk/msbuild-props.md#enablenetanalyzers).

## Affected APIs

Not detectable via API analysis.

<!--

### Affected APIs

Not detectable via API analysis.

### Category

Code analysis

-->
