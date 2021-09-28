---
description: "Learn more about: Static Class Design"
title: "Static Class Design"
ms.date: "10/22/2008"
helpviewer_keywords:
  - "type design guidelines, static classes"
  - "class library design guidelines [.NET Framework], classes"
  - "classes [.NET Framework], static"
  - "static classes [.NET Framework]"
  - "classes [.NET Framework], design guidelines"
  - "type design guidelines, classes"
ms.assetid: d67c14d8-c4dd-443f-affb-4ccae677c9b6
---
# Static Class Design

A static class is defined as a class that contains only static members (of course besides the instance members inherited from <xref:System.Object?displayProperty=nameWithType> and possibly a private constructor). Some languages provide built-in support for static classes. In C# 2.0 and later, when a class is declared to be static, it is sealed, abstract, and no instance members can be overridden or declared.

 Static classes are a compromise between pure object-oriented design and simplicity. They are commonly used to provide shortcuts to other operations (such as <xref:System.IO.File?displayProperty=nameWithType>), holders of extension methods, or functionality for which a full object-oriented wrapper is unwarranted (such as <xref:System.Environment?displayProperty=nameWithType>).

 ✔️ DO use static classes sparingly.

 Static classes should be used only as supporting classes for the object-oriented core of the framework.

 ❌ DO NOT treat static classes as a miscellaneous bucket.

 ❌ DO NOT declare or override instance members in static classes.

 ✔️ DO declare static classes as sealed, abstract, and add a private instance constructor if your programming language does not have built-in support for static classes.

 *Portions © 2005, 2009 Microsoft Corporation. All rights reserved.*

 *Reprinted by permission of Pearson Education, Inc. from [Framework Design Guidelines: Conventions, Idioms, and Patterns for Reusable .NET Libraries, 2nd Edition](https://www.informit.com/store/framework-design-guidelines-conventions-idioms-and-9780321545619) by Krzysztof Cwalina and Brad Abrams, published Oct 22, 2008 by Addison-Wesley Professional as part of the Microsoft Windows Development Series.*

## See also

- [Type Design Guidelines](type.md)
- [Framework Design Guidelines](index.md)
