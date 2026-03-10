---
description: "protected internal - C# Reference"
title: "protected internal keyword"
ms.date: 01/22/2026
f1_keywords:
  - "protectedinternal_CSharpKeyword"
author: "sputier"
---
# protected internal (C# reference)

The `protected internal` keyword combination is a member access modifier. You can access a protected internal member from the current assembly or from types that are derived from the containing class. For a comparison of `protected internal` with the other access modifiers, see [Accessibility Levels](accessibility-levels.md).

[!INCLUDE[csharp-version-note](../includes/initial-version.md)]

Any type within the containing assembly can access a protected internal member of a base class. A derived class located in another assembly can access the member only if the access occurs through a variable of the derived class type. For example, consider the following code segment:

```csharp
// Assembly1.cs
// Compile with: /target:library
public class BaseClass
{
   protected internal int myValue = 0;
}

class TestAccess
{
    void Access()
    {
        var baseObject = new BaseClass();
        baseObject.myValue = 5;
    }
}
```

```csharp
// Assembly2.cs
// Compile with: /reference:Assembly1.dll
class DerivedClass : BaseClass
{
    static void Main()
    {
        var baseObject = new BaseClass();
        var derivedObject = new DerivedClass();

        // Error CS1540, because myValue can only be accessed by
        // classes derived from BaseClass.
        // baseObject.myValue = 10;

        // OK, because this class derives from BaseClass.
        derivedObject.myValue = 10;
    }
}
```

This example contains two files, `Assembly1.cs` and `Assembly2.cs`.
The first file contains a public base class, `BaseClass`, and another class, `TestAccess`. `BaseClass` owns a protected internal member, `myValue`, which the `TestAccess` type accesses because they're in the same assembly.
In the second file, an attempt to access `myValue` through an instance of `BaseClass` produces an error, while an access to this member through an instance of a derived class, `DerivedClass` succeeds. This access rule shows that `protected internal` allows access from **any class within the same assembly** or **derived classes in any assembly**, making it the most permissive of the protected access modifiers.

Struct members can't be `protected internal` because the struct can't be inherited.

## Overriding protected internal members

When you override a virtual member, the accessibility modifier of the overridden method depends on the assembly where you define the derived class.

When you define the derived class in the same assembly as the base class, all overridden members have `protected internal` access. If you define the derived class in a different assembly from the base class, overridden members have `protected` access.

```csharp
// Assembly1.cs
// Compile with: /target:library
public class BaseClass
{
    protected internal virtual int GetExampleValue()
    {
        return 5;
    }
}

public class DerivedClassSameAssembly : BaseClass
{
    // Override to return a different example value, accessibility modifiers remain the same.
    protected internal override int GetExampleValue()
    {
        return 9;
    }
}
```

```csharp
// Assembly2.cs
// Compile with: /reference:Assembly1.dll
class DerivedClassDifferentAssembly : BaseClass
{
    // Override to return a different example value, since this override
    // method is defined in another assembly, the accessibility modifiers
    // are only protected, instead of protected internal.
    protected override int GetExampleValue()
    {
        return 2;
    }
}
```

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
