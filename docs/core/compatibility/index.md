---
title: .NET Core application compatibility
description: Learn about the ways in which .NET Core attempts to maintain compatibility for developers across .NET versions.
author: rpetrusha
ms.author: ronpet
ms.date: 04/29/2019
---
# .NET Core application compatibility

Throughout its history, .NET has attempted to maintain a high level of compatibility from version to version and across flavors of .NET. This continues to be true of .NET Core. Although .NET Core can be considered as a new technology that is independent of the .NET Framework, two major factors limit the ability of .NET Core to diverge from .NET Framework:

- A large number of developers either originally developed or continue to develop .NET Framework applications. They expect consistent behavior across .NET implementations.

- .NET Standard library projects allow developers to create libraries that target common APIs shared by .NET Core and .NET Framework. Developers expect that a library used in a .NET Core application should behave identically to the same library used in a .NET Framework application.

Along with compatibility across .NET implementations, developers expect a high level of compatibility across .NET Core versions. In particular, code written for an earlier version of .NET Core should run seamlessly on a later version of .NET Core. In fact, many developers expect that the new APIs found in newly released versions of .NET Core should also be compatible with the pre-release versions in which those APIs were introduced.

This article outlines the categories of compatibility changes and the way in which the .NET team evaluates changes in each of these categories. An understanding of the how the .NET team approaches possible breaking changes is particularly helpful for developers who are opening pull requests in the GitHub [dotnet/corefx](https://github.com/dotnet/corefx) repository that modify the behavior of existing APIs.

## Modifications to the public contract

Changes in this category *modify* the public surface area of a type. Most of the changes in this category are disallowed since they violate *backwards compatibility* (the ability of an application that was developed with a previous version of an API to execute without recompilation on a later version). They include:

- **Renaming or removing a public type, member, or parameter.**

   This breaks all code that uses the renamed or removed type, member, or parameter. Note that this applies to changing the names of parameters as well. Because arguments can be specified for a particular parameter either positionally or [by name](../../csharp/programming-guide/classes-and-structs/named-and-optional-arguments#named-arguments), changing the name of a parameter can also break existing code.

- **Changing the value of a public constant or enumeration member.**

- **Sealing a type that was previously unsealed.**

- **Making a virtual member abstract.**

- **Adding an interface to the set of base types of an interface.**

   If an interface implements an interface that it previously did not implement, all types that implemented the original version of the interface are broken.

- **Removing a type or interface from the set of base types.**

- **Reducing the visibility of a type or member.**

- **Changing the return type of a member.**

Some kinds of changes are allowed, however:

- Adding a new interface implementation to a type.

- Expanding the visibility of a type or member. 