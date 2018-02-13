---
title: The relationship between language features and library types | Microsoft Docs 
description: Language features often rely on library types for implementation. Understand that relationship.
keywords: C# language design, standard library
author: billwagner
ms.author: wiwagn
ms.date: 07/20/2017
ms.topic: article
ms.prod: .net
ms.devlang: devlang-csharp
---

# Relationships between language features and library types

The C# language definition requires a standard library to have certain
types and certain accessible members on those types. The compiler generates
code that uses these required types and members for many different language
features. When necessary, there are NuGet packages that contain types
needed for newer versions of the language when writing code for environments
where those types or members have not been deployed yet.

This dependency on standard library functionality has been part of the
C# language since its first version. In that version, examples included:

* <xref:System.Exception> - used for all compiler generated exceptions.
* <xref:System.String> - the C# `string` type is a synonym for <xref:System.String>.
* <xref:System.Int32> - synonym of `int`.

That first
version was simple: the compiler and the standard library shipped together,
and there was only one version of each.

Subsequent versions of C# have occasionally added new types or members to
the dependencies. Examples include: <xref:System.Runtime.CompilerServices.INotifyCompletion>,
<xref:System.Runtime.CompilerServices.CallerFilePathAttribute> and
<xref:System.Runtime.CompilerServices.CallerMemberNameAttribute>. C# 7.0 continues this by adding a dependency on <xref:System.ValueTuple> to
implement the [tuples](../tuples.md) language feature.

The language design team works to minimize the surface area of the types
and members required in a compliant standard library. That goal is balanced
against a clean design where new library features are incorporated seamlessly
into the language. There will be new features in future versions of C# that
require new types and members in a standard library. It's important to understand
how to manage those dependencies in your work.

## Managing your dependencies

C# compiler tools are now decoupled from the release cycle of the .NET libraries
on supported platforms. In fact, different .NET libraries have different release
cycles: the .NET Framework on Windows is released as a Windows Update, .NET Core ships on
a separate schedule, and the Xamarin versions of library updates ship with the Xamarin tools
for each target platform.

The majority of time, you won't notice these changes. However, when you are working
with a newer version of the language that requires features not yet in the .NET libraries
on that platform, you'll reference the NuGet packages to provide those new types.
As the platforms your app supports are updated with new framework installations,
you can remove the extra reference.

This separation means you can use new language features even when you are targeting
machines that may not have the corresponding framework.
