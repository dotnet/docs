---
title: C# Attributes - A tour of the C# language
description: Learn about declarative programming using attributes in C#
keywords: .NET, csharp
author: BillWagner
ms.author: wiwagn
ms.date: 08/10/2016
ms.topic: article
ms.prod: .net
ms.technology: devlang-csharp
ms.devlang: csharp
ms.assetid: 753bcfe2-7ddd-4487-9513-ba70937fc8e9
---

# Attributes

Types, members, and other entities in a C# program support modifiers that control certain aspects of their behavior. For example, the accessibility of a method is controlled using the `public`, `protected`, `internal`, and `private` modifiers. C# generalizes this capability such that user-defined types of declarative information can be attached to program entities and retrieved at run-time. Programs specify this additional declarative information by defining and using ***attributes***.

The following example declares a `HelpAttribute` attribute that can be placed on program entities to provide links to their associated documentation.

[!code-csharp[AttributeDefined](../../../samples/snippets/csharp/tour/attributes/Program.cs#L3-L20)]

All attribute classes derive from the <xref:System.Attribute> base class provided by the standard library. Attributes can be applied by giving their name, along with any arguments, inside square brackets just before the associated declaration. If an attribute’s name ends in `Attribute`, that part of the name can be omitted when the attribute is referenced. For example, the `HelpAttribute` attribute can be used as follows.

[!code-csharp[AttributeApplied](../../../samples/snippets/csharp/tour/attributes/Program.cs#L22-L28)]

This example attaches a `HelpAttribute` to the `Widget` class. It adds another `HelpAttribute` to the `Display` method in the class. The public constructors of an attribute class control the information that must be provided when the attribute is attached to a program entity. Additional information can be provided by referencing public read-write properties of the attribute class (such as the reference to the `Topic` property previously).

When a particular attribute is requested through reflection, the constructor for the attribute class is invoked with the information provided in the program source, and the resulting attribute instance is returned. If additional information was provided through properties, those properties are set to the given values before the attribute instance is returned.

>[!div class="step-by-step"]
[Previous](delegates.md)
