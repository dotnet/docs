---
title: C# Versioning - C# Guide
description: Understand how versioning works in C# and .NET
keywords: .NET, .NET Core, C#
author: BillWagner
manager: wpickett
ms.date: 01/08/2017
ms.topic: article
ms.prod: visual-studio-dev-14
ms.technology: devlang-csharp
ms.devlang: csharp
ms.assetid: aa8732d7-5cd0-46e1-994a-78017f20d861
---

# Versioning in C# #

In this tutorial you'll learn what versioning means in .NET. You'll also learn the factors to consider when versioning your library as well as upgrading
to a new version of the a library.

## Authoring Libraries

As a developer who has created .NET libraries for public use, you've most likely been in situations where you have
to roll out new updates. How you go about this process matters a lot as you need to ensure that there's a seamless transition
of existing code to the new version of your library. Here are several things to consider when creating a new release:

### Semantic Versioning

[Semantic versioning](http://semver.org/) (SemVer for short) is a naming convention applied to versions of your library to signify specific milestone events.
Ideally, the version information you give your library should help developers determine the compatibility
with their projects that make use of older versions of that same library.

The most basic approach to SemVer is the 3 component format `MAJOR.MINOR.PATCH`, where:
 
* `MAJOR` is incremented when you make incompatible API changes
* `MINOR` is incremented when you add functionality in a backwards-compatible manner
* `PATCH` is incremented when you make backwards-compatible bug fixes

There are also ways to specify other scenarios like pre-release versions etc. when applying version information to your .NET library.

### Backwards Compatibility

As you release new versions of your library, backwards compatibility with previous versions will most likely be one of your major concerns.
A new version of your library is source compatible with a previous version if code that depends on the previous version can, when recompiled, work with the new version. 
A new version of your library is binary compatible if an application that depended on the old version can, without recompilation, work with the new version.

Here are some things to consider when trying to maintain backwards compatibility with older versions of your library:

* Virtual methods: When you make a virtual method non-virtual in your new version it means that projects that override that method
will have to be updated. This is a huge breaking change and is strongly discouraged.
* Method signatures: When updating a method behaviour requires you to change its signature as well, you should instead create an overload so that code calling into that method will still work.
You can always manipulate the old method signature to call into the new method signature so that implementation remains consistent.
* [Obsolete attribute](programming-guide/concepts/attributes/common-attributes.md#Obsolete): You can use this attribute in your code to specify classes or class members that are deprecated and likely to be removed in future versions.
This ensures developers utilizing your library are better prepared for breaking changes.
* Optional Method Arguments: When you make previously optional method arguments compulsory or change their default value then all code that does not supply those arguments will need to be updated.
> [!NOTE]
> Making compulsory arguments optional should have very little effect especially if it doesn't change the method's behaviour.

The easier you make it for your users to upgrade to the new version of your library, the more likely that they will upgrade sooner.

### Application Configuration File

As a .NET developer there's a very high chance you've encountered [the `app.config` file](https://msdn.microsoft.com/library/1fk1t1t0(v=vs.110).aspx) present in most project types.
This simple configuration file can go a long way into improving the rollout of new updates. You should generally design your libraries in such
a way that information that is likely to change regularly is stored in the `app.config` file, this way when such information is updated
the config file of older versions just needs to be replaced with the new one without the need for recompilation of the library.

## Consuming Libraries

As a developer that consumes .NET libraries built by other developers you're most likely aware that a new version of a library might not be fully compatible with your project
and you might often find yourself having to update your code to work with those changes.

Lucky for you C# and the .NET ecosystem comes with features and techniques that allow us to easily update our app to work with new versions of libraries that might introduce breaking changes.

### Assembly Binding Redirection

You can use the `app.config` file to update the version of a library your app uses. By adding what is called a [*binding redirect*](https://msdn.microsoft.com/library/7wd6ex19(v=vs.110).aspx) your
can use the new library version without having to recompile your app. The following example shows how you would update
your app's `app.config` file to use the `1.0.1` patch version of `ReferencedLibrary` instead of the `1.0.0` version it was originally compiled with.

```xml
<dependentAssembly>
    <assemblyIdentity name="ReferencedLibrary" publicKeyToken="32ab4ba45e0a69a1" culture="en-us" />
    <bindingRedirect oldVersion="1.0.0" newVersion="1.0.1" />
</dependentAssembly>
```

> [!NOTE]
> This approach will only work if the new version of `ReferencedLibrary` is binary compatible with your app.
> See the [Backwards Compatibility](#backwards-compatibility) section above for changes to look out for when determining compatibility.

### new

You use the `new` modifier to hide inherited members of a base class. This is one way derived classes can respond to updates in base classes.

Take the following example:

[!code-csharp[Sample usage of the 'new' modifier](../../samples/csharp/versioning/new/Program.cs#sample)]

**Output**

```
A base method
A derived method
```

From the example above you can see how `DerivedClass` hides the `MyMethod` method present in `BaseClass`.
This means that when a base class in the new version of a library adds a member that already exists in your derived class, you can
simply use the `new` modifier on your derived class member to hide the base class member.

When no `new` modifier is specified, a derived class will by default hide conflicting members in a base class,
although a compiler warning will be generated the code will still compile. This means that simply adding new members to an existing class
makes that new version of your library both source and binary compatible with code that depends on it.

### override

The `override` modifier means a derived implementation extends the implementation of a base class member rather than
hides it. The base class member needs to have the `virtual` modifier applied to it.

[!code-csharp[Sample usage of the 'override' modifier](../../samples/csharp/versioning/override/Program.cs#sample)]

**Output**

```
Base Method One: Method One
Derived Method One: Derived Method One
```

The `override` modifier is evaluated at compile time and the compiler will throw an error if it doesn't find a virtual member to override.

Your knowledge of the discussed techniques as well as your understanding of what situations to use them will go a long way to boost the ease
of transition between versions of a library.
