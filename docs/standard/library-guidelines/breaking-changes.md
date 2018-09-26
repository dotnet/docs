---
title: Breaking Changes
description: Best practice recommendations for navigating breaking changes when creating .NET libraries.
author: jamesnk
ms.author: jamesnk
ms.date: 09/20/2018
---
# Breaking Changes

It's important for an open-source project to find a balance between stability for existing users and innovation for the future. As developers, we lend towards refactoring and rethinking code until it's perfect, but breaking your existing users has a negative impact, especially for low-level libraries.

## Project types and breaking changes

How a project is used by the .NET community changes the effect of breaking changes on end-user developers.

* **Low and middle-level libraries** like a serializer, HTML parser, DB ORM, or web framework are the most effected by breaking changes.

  Building block packages are used by end-user developers to build applications, and by other projects as NuGet dependencies. For example, you're building an application and are using an open-source client to call a web service. A breaking update to dependency the client uses isn't something you can fix. It's the open-source client that needs to be changed and you have no control over it. You have to find compatible versions of the libraries, or submit a fix to the client library and wait for a new version. The worst-case situation is if you want to use two libraries that depend on mutually incompatible versions of a third library.

* **High-level libraries** like a suite of UI controls are less sensitive to breaking changes.

  High-level libraries are directly referenced in an end-user application. If breaking changes occur the developer can choose to update to the latest version, or can modify their application to work with the breaking change.

**✔️ DO** think about how your library will be used. What effect will breaking changes have on applications and libraries that use it?

**✔️ DO** minimize breaking changes when developing a low-level .NET library.

**✔️ CONSIDER** publishing a major rewrite of a library as a new NuGet package.

## Types of Breaking Changes

Breaking changes fall into different categories and aren't equally impactful.

### Source Breaking Change

A source breaking change doesn't affect program execution but will cause compilation errors the next time the application is recompiled. Examples of source breaking changes include adding an overload that can result in ambiguity in method calls that were unambiguous previously, or changing a parameter name that can break callers using named parameters.

```cs
public class Task
{
    // Adding a type called Task could conflict with System.Threading.Task at compilation
}
```

Because a source breaking change is only harmful when the developer recompiles their application, it's the least disruptive. Developers can fix their own broken source code easily.

### Behavior Breaking Change

Behavior changes are the most common breaking change: almost any change in behavior could break someone. Even a bug fix can qualify if users relied on the previously broken behavior.

**✔️ CONSIDER** leaving new features off by default if they affect existing users, and let developers opt in to the feature with a setting.

### Binary Breaking Change

A binary breaking change happens when you change the public API of a library so assemblies compiled against older versions are no longer able to call it. For example, changing a method's signature by adding a new parameter will cause already compiled assemblies that called it to throw a `MissingMethodException`.

A binary breaking change can also break an **entire assembly**. Renaming an assembly in `AssemblyNameAttribute` will change the assembly's identity, as will adding, removing, or changing an assembly's strong naming key. A change of an assembly's identity will break all compiled code that uses it.

**❌ DO NOT** change an assembly name.

**❌ DO NOT** add, remove, or change the strong naming key.

**✔️ CONSIDER** using abstract base classes instead of interfaces.

> Adding anything to an interface will cause existing types that implement it to fail. An abstract base class allows you to add a default virtual implementation.

**✔️ CONSIDER** placing the `ObsoleteAttribute` on types and members that you intend to remove. The attribute should have instructions for updating code to no longer use the obsolete API.

> Code that calls types and methods with the `ObsoleteAttribute` will generate a build warning with the message supplied to the attribute. The warnings give people who use the obsolete API surface time to migrate so that when the obsolete API is removed, most are no longer be using it.

```cs
public class Document
{
    [Obsolete("LoadDocument(string) is obsolete. Use LoadDocument(Uri) instead.")]
    public static Document LoadDocument(string uri)
    {
        return LoadDocument(new Uri(uri));
    }

    public static Document LoadDocument(Uri uri)
    {
        // Load the document
    }
}
```

**More Information**

* [A definitive guide to API-breaking changes in .NET](https://stackoverflow.com/questions/1456785/a-definitive-guide-to-api-breaking-changes-in-net)
* [CoreFX Breaking Change Rules](https://github.com/dotnet/corefx/blob/master/Documentation/coding-guidelines/breaking-change-rules.md)