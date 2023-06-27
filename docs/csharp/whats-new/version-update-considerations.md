---
title: Version and update considerations for C# developers
description: Introducing new languages features in your library can impact the code that uses it.
ms.topic: language-reference
ms.date: 06/26/2023
---

# Version and update considerations for C# developers

Compatibility is an important goal as new features are added to the C# language. In almost all cases, existing code can be recompiled with a new compiler version without any issue. The .NET runtime team also has a goal to ensure compatibility for updated libraries. In almost all cases, when your app is launched from an updated runtime with updated libraries, the behavior is exactly the same as with previous versions.

The language version used to compile your app typically matches the runtime TFM referenced in your project. For more information on changing the default language version, see the article on [configure your language version](../language-reference/configure-language-version.md). This default behavior ensures maximum compatibility.

When *breaking changes* are introduced, they're classified as:

- *Binary breaking change*: A binary breaking change means that your application or library has different behavior when launched using a new runtime. You must recompile your app to incorporate these changes. The existing binary may not function correctly.
- *Source breaking change*: A source breaking change means that the meaning of your source code has changed. You need to make source code edits before compiling your application with the latest language version.

When a binary breaking change affects your app, you don't need to edit any source code. Recompiling is all that is necessary. When a source breaking change affects by a source breaking change, the existing binary still runs correctly in environments with the updated runtime and libraries. If a change is both source breaking and binary breaking, you must recompile your application, and you need to make source updates to recompile with the latest version.

Because of the goal to avoid breaking changes by the C# language team and runtime team, updating your application is typically a matter of updating the TFM and rebuilding the app. However, for libraries that are distributed publicly, you should carefully evaluate your policy for supported TFMs and supported language versions. You may be creating a new library with features found in the latest version and need to ensure apps built using previous versions of the compiler can use it. Or you may be upgrading an existing library and many of your users may not have upgraded versions yet.

## Introducing breaking changes in your libraries

When you adopt new language features in your library's public API, you should evaluate if adopting the feature introduces either a binary or source breaking change for the users of your library. Any changes to your internal implementation that don't appear in the `public` or `protected` interfaces are always compatible.

A *binary breaking change* requires your users to recompile their code in order to use the new version.  For example, consider this public method:

```csharp
public double CalculateSquare(double value) => value * value;
```

If you add the `in` modifier to the method, that's a binary breaking change:

```csharp
public double CalculateSquare(in double value) => value * value;
```

Users must recompile any application that uses your library for the new library to work correctly.

A *source breaking change* requires your users to change their code before they recompile. For example, consider this type:

```csharp
public class Person
{
    public string FirstName { get; }
    public string LastName { get; }

    public Person(string firstName, string lastName) => (FirstName, LastName) = (firstName, lastName);

    // other details omitted
}
```

In a newer version, you'd like to take advantage of the synthesized members generated for `record` types. You make the following change:

```csharp
public record class Person(string FirstName, string LastName);
```

The previous change requires changes for any type derived from `Person`. All those declarations must add the `record` modifier to their declarations.

## Impact of breaking changes

When you add a *binary breaking change* to your library, you force all projects that use your library to recompile. However, none of the source code in those projects needs to change. As a result, the impact of the breaking change is reasonably small for each project.

When you make a *source breaking change* to your library, you require all projects to make source changes in order to use your new library. If the necessary change requires new language features, you force those projects to upgrade to the same language version and TFM you're now using. You've required more work for your users, and possibly forced them to upgrade as well.

The impact of any breaking change you make depends on the number of projects that have a dependency on your library. If your library is used internally by a few applications, you can react to any breaking changes in all impacted projects. However, if your library is publicly downloaded, you should evaluate the potential impact and consider alternatives. You may add new APIs that parallel existing APIs. You may consider parallel builds for different TFMs. You can also consider multi-targeting.
