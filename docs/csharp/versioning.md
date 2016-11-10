---
title: C# Versioning | C# Guide
description: Understand how versioning works in C# and .NET
keywords: .NET, .NET Core, C#
author: tsolarin
manager: wpickett
ms.date: 2016/11/11
ms.topic: article
ms.prod: visual-studio-dev-14
ms.technology: devlang-csharp
ms.devlang: csharp
ms.assetid: aa8732d7-5cd0-46e1-994a-78017f20d861
---

# Versioning in C#

As a developer who has created .NET libraries for public use, you've most likely been in situations where you have
to roll out new updates. How you go about this process matters a lot as you need to ensure that there's a seamless transition
of existing code to the new version of your library. Here are several things to consider when creating a new release:

## Semantic Versioning

Semantic versioning (SemVer for short) is a naming convention applied to versions of your library to signify specific milestone events.
Ideally, the version information you give your library should help developers determine the compatibility
with their projects that make use of older versions of that same library.

The most basic approach to SemVer is the 3 component format `MAJOR.MINOR.PATCH`, where:

* `MAJOR` is incremented when you make incompatible API changes
* `MINOR` is incremented when you add functionality in a backwards-compatible manner
* `PATCH` is incremented when you make backwards-compatible bug fixes

There are also ways to specify other scenarios like pre-release versions etc. Go [here]([http://semver.org/]) to get more information on SemVer
and how best to utilize it when applying version information to your .NET library.

## Application Configuration File

As a .NET developer there's a very high chance you've encountered the `app.config` file present in most project types.
This simple configuration file can go a long way into improving the rollout of new updates. You should generally design your libraries in such
a way that information that is likely to change regularly is stored in the `app.config` file, this way when such information is updated
the config file of older versions just needs to be replaced with the new one without the need for recompilation of the library.
Go [here](https://msdn.microsoft.com/en-us/library/1fk1t1t0(v=vs.110).aspx) to get more information on the structure of the configuration file
and what kind of information is usually stored in it.

## Compatibility

As you release new versions of your library, backwards compatibility with previous versions will most likely be one of your major concerns.
A new version of your library is source compatible with a previous version if code that depends on the previous version can, when recompiled, work with the new version. 
In contrast, a new version of your library is binary compatible if an application that depended on the old version can, without recompilation, work with the new version.

Lucky for you C# comes with features that ensure that as a class evolves over time, through the addition of new members, other classes that derive from it still keep working as intended.
This is achieved through the use of the `new`, `override` and `virtual` modifiers.

### new

You use the new modifier to hide inherited members of a base class. This ensures resiliency of derived classes allowing you to update base classes the way you want in your library.

Take the following example:

```
[!code-csharp[Sample usage of the 'new' modifier](/samples/csharp/versioning/new/Program.cs#sample)]
```

#### Output

```
A base method
A derived method
```

From the example above you can see how `DerivedClass` hides the `MyMethod` method present in `BaseClass`.
As a library developer this means that you can add new base class members and developers consuming that library can simply use the `new`
modifier on any of the members in their derived classes that conflict with your base class.

When no `new` modifier is specified, a derived class will by default hide conflicting members in a base class,
although a compiler warning will be generated the code will still compile. This means that simply adding new members to an existing class
makes that new version of your library both source and binary compatible with code that depends on it.

### override

The `override` modifier works very similar to the `new` modifier except that it extends the implementation of a base class member rather than
hides it, also the base class member needs to have the `virtual` modifier applied to it.

```
[!code-csharp[Sample usage of the 'override' modifier](/samples/csharp/versioning/override/Program.cs#sample)]
```

#### Output

```
Base Method One: Method One
Derived Method One: Derived Method One
```

The `override` modifier is evaluated at compile time as opposed to at runtime for the `new` modifier. If an update to your library involves removing a
previously virtual method then code that overrides this method will need to be updated and re-compiled.
