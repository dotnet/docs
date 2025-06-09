---
title: "How to create a new method for an enumeration"
description: Learn how to use extension methods to add functionality to an enum in C#. This example shows an extension method called Passing for an enum called Grades.
ms.date: 04/17/2025
helpviewer_keywords: 
  - "enumerations [C#]"
  - "extension methods [C#], for enums"
  - "enum extensibility [C#]"
ms.topic: how-to
---
# How to create a new method for an enumeration (C# Programming Guide)

You can use extension methods to add functionality specific to a particular enum type. In the following example, the `Grades` enumeration represents the possible letter grades that a student might receive in a class. An extension method named `Passing` is added to the `Grades` type so that each instance of that type now "knows" whether it represents a passing grade or not.

:::code language="csharp" source="./snippets/ExtensionMembers/CustomExtensionMethods.cs" id="ExtendEnumType":::

You can call the extension method as though it was declared on the `enum` type:

:::code language="csharp" source="./snippets/ExtensionMembers/CustomExtensionMethods.cs" id="ExampleExtendEnum":::

Beginning with C# 14, you can declare *extension members* in an extension block. The new syntax enables you to add *extension properties*. You can also add extension members that appear to be new static methods or properties. You're no longer limited to extensions that appear to be instance methods. The following example shows an extension block that adds an instance extension property for `Passing`, and a static extension property for `MinimumPassingGrade`:

:::code language="csharp" source="./snippets/ExtensionMembers/CustomExtensionMembers.cs" id="EnumExtensionMembers":::

You call these new extension properties as though they're declared on the extended type:

:::code language="csharp" source="./snippets/ExtensionMembers/CustomExtensionMembers.cs" id="EnumExtensionMembers":::

You can learn more about the new extension members in the article on [extension members](./extension-methods.md) and in the language reference article on the ['extension` keyword](../../language-reference/keywords/extension.md).

## See also

- [Extension Methods](./extension-methods.md)
