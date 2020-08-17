---
title: Version and update considerations for C# developers
description: Introducing new languages features in your library can impact the code that uses it.
ms.topic: reference
ms.date: 09/19/2018
---

# Version and update considerations for C# developers

Compatibility is a very important goal as new features are added to the C# language. In almost all cases, existing code can be recompiled with a new compiler version without any issue.

More care may be required when you adopt new language features in a library. You may be creating a new library with features found in the latest version and need to ensure apps built using previous versions of the compiler can use it. Or you may be upgrading an existing library and many of your users may not have upgraded versions yet. As you make decisions on adopting new features, you'll need to consider two variations of compatibility: source compatible and binary compatible.

## Binary compatible changes

Changes to your library are **binary compatible** when your updated library can be used without rebuilding applications and libraries that use it. Dependent assemblies are not required to be rebuilt, nor are any source code changes required. Binary compatible changes are also source compatible changes.

## Source compatible changes

Changes to your library are **source compatible** when applications and libraries that use your library do not require source code changes, but the source must be recompiled against the new version to work correctly.

## Incompatible changes

If a change is neither **source compatible** nor **binary compatible**, source code changes along with recompilation are required in dependent libraries and applications.

## Evaluate your library

These compatibility concepts affect the public and protected declarations for your library, not its internal implementation. Adopting any new features internally are always **binary compatible**.  

**Binary compatible** changes provide new syntax that generates the same compiled code for public declarations as the older syntax. For example, changing a method to an expression-bodied member is a **binary compatible** change:

Original code:

```csharp
public double CalculateSquare(double value)
{
    return value * value;
}
```

New code:

```csharp
public double CalculateSquare(double value) => value * value;
```

**Source compatible** changes introduce syntax that changes the compiled code for a public member, but in a way that is compatible with existing call sites. For example, changing a method signature from a by value parameter to an `in` by reference parameter is source compatible, but not binary compatible:

Original code:

```csharp
public double CalculateSquare(double value) => value * value;
```

New code:

```csharp
public double CalculateSquare(in double value) => value * value;
```

The [What's new](index.md) articles note if introducing a feature that affects public declarations is source compatible or binary compatible.
