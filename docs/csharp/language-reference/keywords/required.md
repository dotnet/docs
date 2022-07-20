---
description: "required modifier - C# Reference"
title: "required modifier - C# Reference"
ms.date: 07/20/2022
helpviewer_keywords: 
  - "required  keyword [C#]"
---
# required modifier (C# Reference)

The `required` modifier indicates that the *field* or *property* its applied to must be initialized by all constructors or using an [object initiializer](../../programming-guide/classes-and-structs/object-and-collection-initializers.md). Any expression that initializes a new instance of the type must initialize all *required members*. Constructors indicate that they initialize all required members by adding the [`SetsRequiredMembers`](../attributes/general.md#setsrequiredmembers-attribute) attribute to the constructor declaration. Code that uses a constructor without this attribute must use *object initializers* to initialize all `required` members.

***Outline***:

- Motivation
- Rules on types (not interfaces)
- Only fields and properties
- Semantics:
  - ctor chaining requires attribute if destination is attributed
  - record copy ctor attributed, if any members are required
  - Not allowed (or needed) on record positional parameters
  - Not to be confused with "not null".
