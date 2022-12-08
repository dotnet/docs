---
title: ".NET 7 breaking change: Compiling C++/CLI projects in Visual Studio"
description: Learn about the breaking change in core .NET libraries where Visual Studio version 17.2 is required to compile .NET 7 C++/CLI projects.
ms.date: 03/21/2022
---
# C++/CLI projects in Visual Studio

.NET 7 includes *generic math* APIs that use `static abstract` interface members on primitive types, such as <xref:System.Int32>.  Earlier versions of the C++/CLI compiler were incompatible with such members. Because those members are used on many primitive types, compilation errors will occur when targeting `net7.0`, even if you don't use the generic math features directly.

Beyond C++/CLI, it's also possible that the introduction of `static abstract` interface members on primitive <xref:System> types will surface issues in other tools that aren't forward-compatible with the usage of this new language construct. If you're a tool author, you'll need to update any tools impacted by this change to accommodate the usage of `static abstract` interface members. If you need help, [file an issue in the dotnet/runtime repo](https://github.com/dotnet/runtime/issues/new) to request guidance.

## Previous behavior

Previously, compiling .NET projects using C++/CLI did not result in errors related to members on primitive <xref:System> types.

## New behavior

Compiling a `net7.0` project using C++/CLI in a release of Visual Studio version 17.2 prior to will result in many errors similar to this example:

```txt
error C2253: 'System.Int32.Parse': pure specifier or abstract override specifier only allowed on virtual function
```

Other than upgrading, there's no way to work around this compiler error. It's generated because of `static abstract` interface members on primitive <xref:System> types. When you upgrade to Visual Studio 2022 version 17.2, the compilation errors will no longer occur.

Implicitly implemented `static abstract` interface members can be invoked, but even with Visual Studio 2022 version 17.2, C++/CLI doesn't support invoking explicitly implemented `static abstract` interface members.

## Version introduced

.NET 7

## Type of breaking change

This change can affect [source compatibility](../../categories.md#source-compatibility).

## Reason for change

.NET 7 includes the new API definitions for the *generic math* feature set. These APIs were introduced in .NET 6 as a preview feature and required you to install the `System.Runtime.Experimental` package to gain access. Starting in .NET 7, these generic math APIs are included "in box".

## Recommended action

To continue using C++/CLI with .NET 7, upgrade to Visual Studio 2022 version 17.2 or a later version.

## Affected APIs

N/A

## See also

- [Visual Studio 2022 version 17.2 - release notes](/visualstudio/releases/2022/release-notes-v17.2)
