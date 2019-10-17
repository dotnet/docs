---
title: Breaking change categories - .NET Core
description: Learn about the ways in which breaking changes are categorized in .NET Core.
author: rpetrusha
ms.author: ronpet
ms.date: 06/10/2019
---
# Breaking change categories

*Compatibility* refers to the ability to compile or execute code on a version of a .NET implementation other than the one with which the code was originally developed. A particular change can affect compatibility in six different ways. The [individual kinds of changes that are considered when evaluating compatibility](index.md) fall into the first five categories. 

## Behavioral change

A behavioral change represents a change to the behavior of a member. The change may be externally visible (for example, a method may throw a different exception), or it may represent a changed implementation (for example, a change in the way a return value is calculated, the addition or removal of internal method calls, or even a significant performance improvement).

When behavioral changes are externally visible and modify a type's public contract, they are easy to evaluate since they affect binary compatibility. Implementation changes are much more difficult to evaluate; depending on the nature of the change and the frequency and patterns of use of the API, the impact of a change can range from severe to innocuous.  

## Binary compatibility

Binary compatibility refers to the ability of a consumer of an API to use the API on a newer version without recompilation. Such changes as adding methods or adding a new interface implementation to a type do not affect binary compatibility. However, removing or altering an assembly's public signatures so that consumers can no longer access the same interface exposed by the assembly does affect binary compatibility. A change of this kind is termed a *binary incompatible change*.

## Source compatibility

 Source compatibility refers to the ability of existing consumers of an API to recompile against a newer version without any source changes. A *source incompatible change* occurs when a consumer needs to modify source code for it to build successfully against a newer version of an API.

## Design-time compatibility

Design-time compatibility refers to preserving the design-time experience across versions of Visual Studio and other design-time environments. While this can involve the behavior or the UI of designers, the most important aspect of design-time compatibility concerns project compatibility. A project or solution must be able to be opened and used on a newer version of the design-time environment.

## Backwards compatibility

Backwards compatibility refers to the ability of an existing consumer of an API to run against a new version while behaving in the same way. Both behavioral changes and changes in binary compatibility affect backwards compatibility. If a consumer is not able to run or behaves differently when running against the newer version of the API, the API is *backwards incompatible*.

Changes that affect backwards compatibility are strongly discouraged since developers by default expect backwards compatibility in newer versions of an API.

## Forward compatibility

Forward compatibility refers to the ability of an existing consumer of an API to run against an older version while exhibiting the same behavior. If a consumer is not able to run or behaves differently when run against an older version of the API, the API is *forward incompatible*. 

Maintaining forward compatibility virtually precludes any changes or additions from version to version, since those changes prevent a consumer that targets a later version from running under an earlier version. Developers expect that a consumer that relies on a newer API may not function correctly against the older API. 

Maintaining forward compatibility is not a goal of .NET Core.

## See also

- [Evaluate breaking changes in .NET Core](index.md)
