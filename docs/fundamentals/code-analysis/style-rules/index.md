---
title: Code style rules overview
description: Learn about the different .NET code style rules and categories.
ms.date: 09/25/2020
ms.topic: reference
author: gewarren
ms.author: gewarren
---
# Code style rules

.NET code style analysis provides rules that aim to maintain consistent *code style* in your codebase. These rules have an "IDE" prefix in the rule ID. Most of the rules have associated options to customize the preferred style. The rules are organized into the following subcategories:

- [Language rules](language-rules.md)

   Rules that pertain to the C# or Visual Basic language. For example, you can specify rules that regard the use of `var` when defining variables, or whether expression-bodied members are preferred.

- [Formatting rules](formatting-rules.md)

   Rules that pertain to the layout and structure of your code in order to make it easier to read. For example, you can specify rules that regard Allman braces, or whether spaces in control blocks are preferred.

- [Naming rules](naming-rules.md)

   Rules that pertain to the naming of code elements. For example, you can specify that `async` method names must have an "Async" suffix.

## Legend

The following table shows the type of information that is provided for each rule in the reference documentation.

|Item|Description|
|----------|-----------------|
| **Option name** |The code style option name for the rule, if any. Options for customizing style are specified in an EditorConfig file.|
| **Rule ID** |The unique identifier for the rule. The rule ID is used for configuring rule severity and suppressing warnings in the code file.|
| **Applicable languages** |Applicable .NET languages (C# or Visual Basic), along with the minimum language version, if applicable.|
| **Option values** |The code style option values for the rule option, if any.|
| **Default option value** |Default code style option value for the rule option, if any.
| **Introduced version** |Version of the .NET SDK or Visual Studio when the rule was first introduced.|
| **Code examples** |Examples for different code styles corresponding to the rule.|

## See also

- [Enforce code style on build](../overview.md#code-style-analysis)
- [Quick Actions in Visual Studio](/visualstudio/ide/quick-actions)
- [Create portable custom editor options in Visual Studio](/visualstudio/ide/create-portable-custom-editor-options)
