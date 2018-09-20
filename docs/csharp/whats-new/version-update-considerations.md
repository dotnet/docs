---
title: Version and update considerations for C# developers
description: Introducing new languages features in your library can impact the code that uses it.
ms.date: 09/19/2018
---

# Version and update considerations for C# developers

Compatibility is a very important goal as new features are added to the C# language. In almost all cases, you can use a new compiler version without breaking existing code.

More care may be required when you adopt new language features in a library, and consumers of that library have not yet upgraded. The are two variations of compatibility: source compatible and binary compatible.

## Source compatible changes

Changes to your library are **source compatible** when assemblies that use your library must be recompiled against the new version to work correctly. Source code changes to the dependent library aren't required, but a rebuild is.

## Binary compatible changes

Changes to your library are **binary compatible** when your updated library can be used without rebuilding applications that use it. Dependent assemblies are not required to be rebuilt, nor are any source code changes required. Binary compatible changes are also source compatible changes.

## Evaluate your library

These compatibility concepts affect the public and protected declarations for your library, not its internal implementation. For that reason, many language enhancements are always binary compatible changes. Adopting any new features internally are always **binary compatible**.  

**Binary compatible** changes provide new syntax that generates the same compiled code for public declarations as the older syntax. For example, change a method to an expression bodied member is a **binary compatible** change:

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