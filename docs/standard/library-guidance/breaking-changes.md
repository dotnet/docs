---
title: Breaking changes and .NET libraries
description: Best practice recommendations for navigating breaking changes when creating .NET libraries.
author: jamesnk
ms.author: mairaw
ms.date: 10/02/2018
---
# Breaking changes

It's important for a .NET library to find a balance between stability for existing users and innovation for the future. Library authors lean towards refactoring and rethinking code until it's perfect, but breaking your existing users has a negative impact, especially for low-level libraries.

## Project types and breaking changes

How a library is used by the .NET community changes the effect of breaking changes on end-user developers.

* **Low and middle-level libraries** like a serializer, HTML parser, database object-relational mapper, or web framework are the most affected by breaking changes.

  Building block packages are used by end-user developers to build applications, and by other libraries as NuGet dependencies. For example, you're building an application and are using an open-source client to call a web service. A breaking update to a dependency the client uses isn't something you can fix. It's the open-source client that needs to be changed and you have no control over it. You have to find compatible versions of the libraries or submit a fix to the client library and wait for a new version. The worst-case situation is if you want to use two libraries that depend on mutually incompatible versions of a third library.

* **High-level libraries** like a suite of UI controls are less sensitive to breaking changes.

  High-level libraries are directly referenced in an end-user application. If breaking changes occur, the developer can choose to update to the latest version, or can modify their application to work with the breaking change.

**✔️ DO** think about how your library will be used. What effect will breaking changes have on applications and libraries that use it?

**✔️ DO** minimize breaking changes when developing a low-level .NET library.

**✔️ CONSIDER** publishing a major rewrite of a library as a new NuGet package.

## Types of breaking changes

Breaking changes fall into different categories and aren't equally impactful.

### Source breaking change

A source breaking change doesn't affect program execution but will cause compilation errors the next time the application is recompiled. For example, a new overload can create an ambiguity in method calls that were unambiguous previously, or a renamed parameter will break callers that use named parameters.

```csharp
public class Task
{
    // Adding a type called Task could conflict with System.Threading.Tasks.Task at compilation
}
```

Because a source breaking change is only harmful when developers recompile their applications, it's the least disruptive breaking change. Developers can fix their own broken source code easily.

### Behavior breaking change

Behavior changes are the most common type of breaking change: almost any change in behavior could break someone. Changes to your library, such as method signatures, exceptions thrown or input or output data formats, could all negatively impact your library consumers. Even a bug fix can qualify as a breaking change if users relied on the previously broken behavior.

Adding features and improving bad behaviors is a good thing, but without care it can make it very hard for existing users to upgrade. One approach to helping developers deal with behavior breaking changes is to hide them behind settings. Settings let developers update to the latest version of your library while at the same time choosing to opt in or opt out of breaking changes. This strategy lets developers stay up to date while letting their consuming code adapt over time.

For example, ASP.NET Core MVC has the concept of a [compatibility version](/aspnet/core/mvc/compatibility-version) that modifies the features enabled and disabled on `MvcOptions`.

**✔️ CONSIDER** leaving new features off by default, if they affect existing users, and let developers opt in to the feature with a setting.

### Binary breaking change

A binary breaking change happens when you change the public API of your library, so assemblies compiled against older versions of your library are no longer able to call the API. For example, changing a method's signature by adding a new parameter will cause assemblies compiled against the older version of the library to throw a <xref:System.MissingMethodException>.

A binary breaking change can also break an **entire assembly**. Renaming an assembly with `AssemblyName` will change the assembly's identity, as will adding, removing, or changing the assembly's strong naming key. A change of an assembly's identity will break all compiled code that uses it.

**❌ DO NOT** change an assembly name.

**❌ DO NOT** add, remove, or change the strong naming key.

**✔️ CONSIDER** using abstract base classes instead of interfaces.

> Adding anything to an interface will cause existing types that implement it to fail. An abstract base class allows you to add a default virtual implementation.

**✔️ CONSIDER** placing the <xref:System.ObsoleteAttribute> on types and members that you intend to remove. The attribute should have instructions for updating code to no longer use the obsolete API.

> Code that calls types and methods with the <xref:System.ObsoleteAttribute> will generate a build warning with the message supplied to the attribute. The warnings give people who use the obsolete API surface time to migrate so that when the obsolete API is removed, most are no longer using it.

```csharp
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

**✔️ CONSIDER** keeping types and methods with the <xref:System.ObsoleteAttribute> indefinitely in low and middle-level libraries.

> Removing APIs is a binary breaking change. Considering keeping obsolete types and methods if maintaining them is low cost and doesn't add lot of technical debt to your library. Not removing types and methods can help avoid the worst-case scenarios mentioned above.

## See also

- [Version and update considerations for C# developers](../../csharp/whats-new/version-update-considerations.md)
- [A definitive guide to API-breaking changes in .NET](https://stackoverflow.com/questions/1456785/a-definitive-guide-to-api-breaking-changes-in-net)
- [CoreFX Breaking Change Rules](https://github.com/dotnet/corefx/blob/master/Documentation/coding-guidelines/breaking-change-rules.md)

>[!div class="step-by-step"]
>[Previous](versioning.md)
