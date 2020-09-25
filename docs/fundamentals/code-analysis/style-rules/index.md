---
title: Code style rules overview
ms.date: 09/25/2020
ms.topic: reference
author: gewarren
ms.author: gewarren
---
# Code style rules

.NET code style analysis provides rules that aim to maintain consistent *code style* in your codebase. These rules have an "IDE" prefix in the rule ID. Majority of the rules have an associated code style option to customize the preferred style. The rules are organized into following sub-categories:

- [Language rules](language-rules.md)

   Rules pertaining to the C# or Visual Basic language. For example, you can specify rules around using `var` or explicit types when defining variables, or preferring expression-bodied members.

- [Formatting rules](formatting-rules.md)

   Rules regarding the layout and structure of your code in order to make it easier to read. For example, you can specify rules around Allman braces, or preferring spaces in control blocks.

- [Naming rules](naming-rules.md)

   Rules regarding the naming of code elements. For example, you can specify that `async` methods must end in "Async".

## Legend

The following table shows the type of information that is provided for each rule in the reference documentation.

|Item|Description|
|----------|-----------------|
| **Option name** |The code style option name for the rule, if any. Option is specified in EditorConfig file for customizing the style.|
| **Rule ID** |The unique identifier for the rule. RuleId and Category are used for rule severity configuration and in-source suppression.|
| **Category** |The sub-category of the style rule, i.e., language, formatting or naming.|
| **Applicable languages** |Applicable .NET languages, i.e. C# or Visual Basic, along with the minimum language version, if applicable.|
| **Option values** |The code style option values for the rule option, if any. Option is specified in EditorConfig file for customizing the style.|
| **Default option value** |Default code style option value for the rule option, if any.
| **Introduced version** |Version of the .NET SDK and/or Visual Studio when the rule was first introduced.|
|Code examples|Examples for different code styles corresponding to the rule.|
