---
title: "How to create a new method for an enumeration"
description: Learn how to use extension methods to add functionality to an enum in C#. This example shows an extension method called Passing for an enum called Grades.
ms.date: 04/15/2025
helpviewer_keywords: 
  - "enumerations [C#]"
  - "extension methods [C#], for enums"
  - "enum extensibility [C#]"
ms.topic: how-to
---
# How to create a new method for an enumeration (C# Programming Guide)

You can use extension methods to add functionality specific to a particular enum type. In the following example, the `Grades` enumeration represents the possible letter grades that a student might receive in a class. An extension method named `Passing` is added to the `Grades` type so that each instance of that type now "knows" whether it represents a passing grade or not.

<<TODO: New extension members style too>>

:::code language="csharp" source="./snippets/ExtensionMembers/CustomExtensionMethods.cs" id="EnumMethods":::

The `Extensions` class also contains a static variable that is updated dynamically and that the return value of the extension method reflects the current value of that variable. The preceding code demonstrates that, behind the scenes, extension methods are invoked directly on the static class in which they're defined.

## See also

- [Extension Methods](./extension-methods.md)
