---
title: Code-style language and unnecessary code rules
description: Learn about the different code-style rules for using C# and Visual Basic language constructs and for finding unnecessary code.
ms.date: 07/22/2023
ms.topic: reference
helpviewer_keywords:
- language code style rules [EditorConfig]
- language rules
- EditorConfig language conventions
---
# Language and unnecessary rules

Code-style language rules affect how various constructs of .NET programming languages, for example, modifiers, and parentheses, are used.

This category also includes rules that identify parts of the code base that are unnecessary and can be refactored or removed. The presence of unnecessary code indicates one of more of the following problems:

- Readability: Code that unnecessarily degrades readability.
- Maintainability: Code that's no longer used after refactoring and is maintained unnecessarily.
- Performance: Unnecessary computation that has no side effects and leads to unnecessary performance overhead.
- Functionality: Functional issue in code that makes required code redundant. For example, [IDE0060](ide0060.md) flags unused parameters where the method accidentally ignores an input parameter.

The language rules fall into the following categories:

- [.NET style rules](#net-style-rules): Rules that apply to both C# and Visual Basic. The option names for these rules start with the prefix `dotnet_style_`.
- [C# style rules](#c-style-rules): Rules that are specific to C# code. The option names for these rules start with the prefix `csharp_style_`.
- [Visual Basic style rules](#visual-basic-style-rules): Rules that are specific to Visual Basic code. The option names for these rules start with the prefix `visual_basic_style_`.

## Option format

Many of the language rules have one or more associated options to customize the preferred style. For example, [Use simple 'using' statement (IDE0063)](ide0063.md) has the associated option `csharp_prefer_simple_using_statement` that lets you define whether you prefer a `using` declaration or a `using` statement. The rule enforces whichever options you choose at a specified level, for example, warning or error.

Options for language rules can be specified in a [configuration file](../configuration-files.md) with the following format:

`option_name = value` (Visual Studio 2019 and later)

or

`option_name = value:severity`

- **Value**

  For each language rule, you specify a value that defines if or when to prefer the style. Many rules accept a value of `true` (prefer this style) or `false` (do not prefer this style). Other rules accept values such as `when_on_single_line` or `never`.

- **Severity** (optional in Visual Studio 2019 and later versions)

  The second part of the rule specifies the [severity level](../configuration-options.md#severity-level) for the rule. When specified in this way, *the severity setting is only respected inside development IDEs, such as Visual Studio*. It is *not* respected during build.

  To enforce code style rules at build time, set the severity by using the rule ID-based severity configuration syntax for analyzers instead. The syntax takes the form `dotnet_diagnostic.<rule ID>.severity = <severity>`, for example, `dotnet_diagnostic.IDE0040.severity = none`. For more information, see [severity level](../configuration-options.md#severity-level).

> [!TIP]
>
> Starting in Visual Studio 2019, you can configure code style rules from the [Quick Actions](/visualstudio/ide/quick-actions) light bulb menu after a style violation occurs. For more information, see [Automatically configure code styles in Visual Studio](/visualstudio/ide/editorconfig-language-conventions#automatically-configure-code-styles-in-visual-studio).

## Rule index

Language and unnecessary code rules are further categorized into subcategories, such as expression-level preferences, code-block preferences, and modifier preferences.

- [`using` directive preferences](#using-directive-preferences)
- [Code-block preferences](#code-block-preferences)
- [Expression-bodied members](#expression-bodied-members)
- [Expression-level preferences](#expression-level-preferences)
- [Field preferences](#field-preferences)
- [Language keyword vs. framework types preferences](#language-keyword-vs-framework-types-preferences)
- [Modifier preferences](#modifier-preferences)
- [New-line preferences](#new-line-preferences)
- [Null-checking preferences](#null-checking-preferences)
- [Parameter preferences](#parameter-preferences)
- [Parentheses preferences](#parentheses-preferences)
- [Pattern-matching preferences](#pattern-matching-preferences)
- [Suppression preferences](#suppression-preferences)
- [`This.` and `me.` preferences](#this-and-me-preferences)
- [`var` preferences](#var-preferences)

### `using` directive preferences

C# and Visual Basic:

- [Require file header (IDE0073)](ide0073.md)

C# only:

- [Remove unnecessary using directives (IDE0005)](ide0005.md)
- ['using' directive placement (IDE0065)](ide0065.md)

### Code-block preferences

C# only:

- [Add braces (IDE0011)](ide0011.md)
- [Use simple 'using' statement (IDE0063)](ide0063.md)
- [Namespace declaration preferences (IDE0160)](ide0160-ide0161.md)
- [Namespace declaration preferences (IDE0161)](ide0160-ide0161.md)
- [Remove unnecessary lambda expression (IDE0200)](ide0200.md)
- [Convert to top-level statements (IDE0210)](ide0210.md)
- [Convert to 'Program.Main' style program (IDE0211)](ide0211.md)

### Expression-bodied members

C# only:

- [Use expression body for constructors (IDE0021)](ide0021.md)
- [Use expression body for methods (IDE0022)](ide0022.md)
- [Use expression body for operators (IDE0023](ide0023-ide0024.md)
- [Use expression body for operators (IDE0024)](ide0023-ide0024.md)
- [Use expression body for properties (IDE0025)](ide0025.md)
- [Use expression body for indexers (IDE0026)](ide0026.md)
- [Use expression body for accessors (IDE0027)](ide0027.md)
- [Use expression body for lambdas (IDE0053)](ide0053.md)
- [Use expression body for local functions (IDE0061)](ide0061.md)

### Expression-level preferences

C# and Visual Basic:

- [Simplify name (IDE0001)](ide0001.md)
- [Simplify member access (IDE0002)](ide0002.md)
- [Remove unnecessary cast (IDE0004)](ide0004.md)
- [Add missing cases to switch statement (IDE0010)](ide0010.md)
- [Use object initializers (IDE0017)](ide0017.md)
- [Use collection initializers (IDE0028)](ide0028.md)
- [Use coalesce expression (IDE0029)](ide0029-ide0030.md)
- [Use coalesce expression (IDE0030)](ide0029-ide0030.md)
- [Use null propagation (IDE0031)](ide0031.md)
- [Use auto-implemented property (IDE0032)](ide0032.md)
- [Use explicitly provided tuple name (IDE0033)](ide0033.md)
- [Remove unreachable code (IDE0035)](ide0035.md)
- [Use inferred member names (IDE0037)](ide0037.md)
- [Use 'is null' check (IDE0041)](ide0041.md)
- [Use conditional expression for assignment (IDE0045)](ide0045.md)
- [Use conditional expression for return (IDE0046)](ide0046.md)
- [Convert anonymous type to tuple (IDE0050)](ide0050.md)
- [Remove unused private member (IDE0051)](ide0051.md)
- [Remove unread private member (IDE0052)](ide0052.md)
- [Use compound assignment (IDE0054)](ide0054-ide0074.md)
- [Use compound assignment (IDE0074)](ide0054-ide0074.md)
- [Remove unnecessary expression value (IDE0058)](ide0058.md)
- [Remove unnecessary value assignment (IDE0059)](ide0059.md)
- [Use 'System.HashCode.Combine' (IDE0070)](ide0070.md)
- [Simplify interpolation (IDE0071)](ide0071.md)
- [Simplify conditional expression (IDE0075)](ide0075.md)
- [Convert `typeof` to `nameof` (IDE0082)](ide0082.md)
- [Remove unnecessary equality operator (IDE0100)](ide0100.md)
- [Simplify LINQ expression (IDE0120)](ide0120.md)
- [Namespace does not match folder structure (IDE0130)](ide0130.md)

C# only:

- [Use throw expression (IDE0016)](ide0016.md)
- [Inline variable declaration (IDE0018)](ide0018.md)
- [Simplify 'default' expression (IDE0034)](ide0034.md)
- [Use local function instead of lambda (IDE0039)](ide0039.md)
- [Deconstruct variable declaration (IDE0042)](ide0042.md)
- [Use index operator (IDE0056)](ide0056.md)
- [Use range operator (IDE0057)](ide0057.md)
- [Add missing cases to switch expression (IDE0072)](ide0072.md)
- [Remove unnecessary suppression operator (IDE0080)](ide0080.md)
- [Simplify `new` expression (IDE0090)](ide0090.md)
- [Remove unnecessary discard (IDE0110)](ide0110.md)
- [Prefer 'null' check over type check (IDE0150)](ide0150.md)
- [Use tuple to swap values (IDE0180)](ide0180.md)
- [Add explicit cast in foreach loop (IDE0220)](ide0220.md)
- [Use UTF-8 string literal (IDE0230)](ide0230.md)

Visual Basic only:

- [Remove `ByVal` (IDE0081)](ide0081.md)
- [Use pattern matching (`IsNot` operator) (IDE0084)](ide0084.md)
- [Simplify object creation (IDE0140)](ide0140.md)

### Field preferences

C# and Visual Basic:

- [Add readonly modifier (IDE0044)](ide0044.md)

### Language keyword vs. framework types preferences

C# and Visual Basic:

- [Use language keywords instead of framework type names for type references (IDE0049)](ide0049.md)

### Modifier preferences

C# and Visual Basic:

- [Order modifiers (IDE0036)](ide0036.md)
- [Add accessibility modifiers (IDE0040)](ide0040.md)

C# only:

- [Make local function static (IDE0062)](ide0062.md)
- [Make struct fields writable (IDE0064)](ide0064.md)

### New-line preferences

- Allow multiple blank lines (IDE2000)
- Allow embedded statements on same line (IDE2001)
- Allow blank lines between consecutive braces (IDE2002)
- Allow statement immediately after block (IDE2003)
- Allow blank line after colon in constructor initializer (IDE2004)
- Allow blank line after token in conditional expression (IDE2005)
- Allow blank line after token in arrow expression (IDE2006)

### Null-checking preferences

C# only:

- [Use conditional delegate call (IDE1005)](ide1005.md)

### Parameter preferences

C# and Visual Basic:

- [Remove unused parameter (IDE0060)](ide0060.md)

### Parentheses preferences

C# and Visual Basic:

- [Parentheses preferences (IDE0047)](ide0047-ide0048.md)
- [Parentheses preferences (IDE0048)](ide0047-ide0048.md)

### Pattern-matching preferences

C# only:

- [Use pattern matching to avoid 'as' followed by 'null' check (IDE0019)](ide0019.md)
- [Use pattern matching to avoid 'is' check followed by a cast (IDE0020)](ide0020-ide0038.md)
- [Use pattern matching to avoid 'is' check followed by a cast (IDE0038)](ide0020-ide0038.md)
- [Use switch expression (IDE0066)](ide0066.md)
- [Use pattern matching (IDE0078)](ide0078.md)
- [Use pattern matching (`not` operator) (IDE0083)](ide0083.md)
- [Simplify property pattern (IDE0170)](ide0170.md)

### Suppression preferences

C# and Visual Basic:

- [Remove unnecessary suppression (IDE0079)](ide0079.md)

### `This.` and `me.` preferences

C# and Visual Basic:

- [this and Me preferences (IDE0003)](ide0003-ide0009.md)
- [this and Me preferences (IDE0009)](ide0003-ide0009.md)

### `var` preferences

C# only:

- ['var' preferences (IDE0007)](ide0007-ide0008.md)
- ['var' preferences (IDE0008)](ide0007-ide0008.md)

## See also

- [.NET code style rules reference](index.md)
