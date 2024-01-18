---
description: "protected internal - C# Reference"
title: "protected internal - C# Reference"
ms.date: 11/15/2017
f1_keywords:
  - "protectedinternal_CSharpKeyword"
author: "sputier"
---
# protected internal (C# Reference)

The `protected internal` keyword combination is a member access modifier. A protected internal member is accessible from the current assembly or from types that are derived from the containing class. For a comparison of `protected internal` with the other access modifiers, see [Accessibility Levels](accessibility-levels.md).

## Example

A protected internal member of a base class is accessible from any type within its containing assembly. It is also accessible in a derived class located in another assembly only if the access occurs through a variable of the derived class type. For example, consider the following code segment:

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
The first file contains a public base class, `BaseClass`, and another class, `TestAccess`. `BaseClass` owns a protected internal member, `myValue`, which is accessed by the `TestAccess` type.
In the second file, an attempt to access `myValue` through an instance of `BaseClass` will produce an error, while an access to this member through an instance of a derived class, `DerivedClass` will succeed.

Struct members cannot be `protected internal` because the struct cannot be inherited.

## Overriding protected internal members

When overriding a virtual member, the accessibility modifier of the overriden method will depend on if it defined in the same assembly as the class it is deriving from.
If the derived class is defined in the same assembly that the base class is defined in, all overriden members will have the accessibility modifier `protected internal`. If the derived class is defined in a different assembly from where the base class is defined, overriden members will only have the `protected` accessibility modifier.

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

- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [C# Keywords](index.md)
- [Access Modifiers](access-modifiers.md)
- [Accessibility Levels](accessibility-levels.md)
- [Modifiers](index.md)
- [public](public.md)
- [private](private.md)
- [internal](internal.md)
- [Security concerns for internal virtual keywords](/previous-versions/dotnet/netframework-4.0/heyd8kky(v=vs.100))
