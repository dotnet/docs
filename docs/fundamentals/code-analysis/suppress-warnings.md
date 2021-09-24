---
title: Suppress code analysis warnings
description: Learn the different ways you can suppress .NET code analysis violations.
ms.date: 01/28/2021
ms-topic: how-to
dev_langs:
  - CSharp
  - VB
helpviewer_keywords:
  - code analysis, suppress warnings
  - suppress code analysis warnings
---
# How to suppress code analysis warnings

This article covers the various ways you can suppress warnings from code analysis when you build your .NET app.

> [!TIP]
> If you're using Visual Studio as your development environment, the *light bulb* menu provides options that generate the code to suppress warnings for you. For more information, see [Suppress violations](/visualstudio/code-quality/use-roslyn-analyzers?#suppress-violations).

## Disable the rule

By disabling the code analysis rule that's causing the warning, you disable the rule for your entire file or project (depending on the scope of the [configuration file](configuration-files.md) that you use). To disable the rule, set its severity to `none` in the configuration file.

```ini
[*.{cs,vb}]
dotnet_diagnostic.<rule-ID>.severity = none
```

For more information about rule severities, see [Configure rule severity](~/docs/fundamentals/code-analysis/configuration-options.md#severity-level).

## Use a preprocessor directive

Use a [#pragma warning (C#)](../../csharp/language-reference/preprocessor-directives.md#pragma-warning) or [Disable (Visual Basic)](../../visual-basic/language-reference/directives/disable-enable.md) directive to suppress the warning for only a specific line of code.

```csharp
    try { ... }
    catch (Exception e)
    {
#pragma warning disable CA2200 // Rethrow to preserve stack details
        throw e;
#pragma warning restore CA2200 // Rethrow to preserve stack details
    }
```

```vb
    Try
        ...
    Catch e As Exception
#Disable Warning CA2200 ' Rethrow to preserve stack details
        Throw e
#Enable Warning CA2200 ' Rethrow to preserve stack details
    End Try
```

## Use the SuppressMessageAttribute

You can use a <xref:System.Diagnostics.CodeAnalysis.SuppressMessageAttribute> to suppress a warning either in the source file or in a global suppressions file for the project (*GlobalSuppressions.cs* or *GlobalSuppressions.vb*). This attribute provides a way to suppress a warning in only certain parts of your project or file.

The two required, positional parameters for the <xref:System.Diagnostics.CodeAnalysis.SuppressMessageAttribute> attribute are the *category* of the rule and the *rule ID*. The following code snippet passes `"Usage"` and `"CA2200:Rethrow to preserve stack details"` for these parameters.

```csharp
[System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA2200:Rethrow to preserve stack details", Justification = "Not production code.")]
private static void IngorableCharacters()
{
    try
    {
        ...
    }
    catch (Exception e)
    {
        throw e;
    }
}
```

If you add the attribute to the global suppressions file, you [scope](xref:System.Diagnostics.CodeAnalysis.SuppressMessageAttribute.Scope) the suppression to the desired level, for example `"member"`. You specify the API where the warning should be suppressed using the <xref:System.Diagnostics.CodeAnalysis.SuppressMessageAttribute.Target> property.

```csharp
[assembly: SuppressMessage("Usage", "CA2200:Rethrow to preserve stack details", Justification = "Not production code.", Scope = "member", Target = "~M:MyApp.Program.IngorableCharacters")]
```

Use the *documentation ID* for the API you want to reference in the `Target` attribute. For information about documentation IDs, see [Documentation ID format](/dotnet/csharp/language-reference/language-specification/documentation-comments#id-string-format).

To suppress warnings for compiler-generated code that doesn't map to explicitly provided user source, you must put the suppression attribute in a global suppressions file. For example, the following code suppresses a violation against a compiler-emitted constructor:

```csharp
[module: SuppressMessage("Design", "CA1055:AbstractTypesDoNotHavePublicConstructors", Scope="member", Target="MyTools.Type..ctor()")]
```

## See also

- [Suppress violations (Visual Studio)](/visualstudio/code-quality/use-roslyn-analyzers?#suppress-violations)
