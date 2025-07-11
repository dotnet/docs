---
description: "private protected - C# Reference"
title: "private protected keyword"
ms.date: 11/15/2017
f1_keywords:
  - "privateprotected_CSharpKeyword"
author: "sputier"
---
# private protected (C# Reference)

The `private protected` keyword combination is a member access modifier. A private protected member is accessible by types derived from the containing class, but only within its containing assembly. For a comparison of `private protected` with the other access modifiers, see [Accessibility Levels](accessibility-levels.md).

> [!NOTE]
> The `private protected` access modifier is valid in C# version 7.2 and later.

## Example

A private protected member of a base class is accessible from derived types in its containing assembly only if the static type of the variable is the derived class type. For example, consider the following code segment:

```csharp
// Assembly1.cs
// Compile with: /target:library
public class BaseClass
{
    private protected int myValue = 0;
}

public class DerivedClass1 : BaseClass
{
    void Access()
    {
        var baseObject = new BaseClass();

        // Error CS1540, because myValue can only be accessed by
        // classes derived from BaseClass.
        // baseObject.myValue = 5;

        // OK, accessed through the current derived class instance
        myValue = 5;
    }
}
```

```csharp
// Assembly2.cs
// Compile with: /reference:Assembly1.dll
class DerivedClass2 : BaseClass
{
    void Access()
    {
        // Error CS0122, because myValue can only be
        // accessed by types in Assembly1
        // myValue = 10;
    }
}
```

This example contains two files, `Assembly1.cs` and `Assembly2.cs`.
The first file contains a public base class, `BaseClass`, and a type derived from it, `DerivedClass1`. `BaseClass` owns a private protected member, `myValue`, which `DerivedClass1` can access as an inherited member within the same assembly.

In the second file, an attempt to access `myValue` as an inherited member of `DerivedClass2` will produce an error, because `private protected` members are only accessible by derived types **within the same assembly**. This is the key difference from `protected` (which allows access from derived classes in any assembly) and `protected internal` (which allows access from any class within the same assembly or derived classes in any assembly).

If `Assembly1.cs` contains an <xref:System.Runtime.CompilerServices.InternalsVisibleToAttribute> that names `Assembly2`, the derived class `DerivedClass2` will have access to `private protected` members declared in `BaseClass`. `InternalsVisibleTo` makes `private protected` members visible to derived classes in other assemblies.

## Comparison with other protected access modifiers

The following table summarizes the key differences between the three protected access modifiers:

| Access Modifier | Same Assembly, Derived Class | Same Assembly, Non-derived Class | Different Assembly, Derived Class |
|---|:-:|:-:|:-:|
| `protected` | ✔️ | ❌ | ✔️ |
| `protected internal` | ✔️ | ✔️ | ✔️ |
| `private protected` | ✔️ | ❌ | ❌ |

- Use `protected` when you want derived classes in any assembly to access the member
- Use `protected internal` when you want the most permissive access (any class in same assembly OR derived classes anywhere)
- Use `private protected` when you want the most restrictive protected access (only derived classes in the same assembly)

Struct members cannot be `private protected` because the struct cannot be inherited.

## C# language specification

[!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]

## See also

- [C# Keywords](index.md)
- [Access Modifiers](access-modifiers.md)
- [Accessibility Levels](accessibility-levels.md)
- [Modifiers](index.md)
- [public](public.md)
- [private](private.md)
- [internal](internal.md)
- [Security concerns for internal virtual keywords](/previous-versions/dotnet/netframework-4.0/heyd8kky(v=vs.100))
