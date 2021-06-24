---
description: "Restrictions on using accessibility levels - C# Reference"
title: "Restrictions on using accessibility levels - C# Reference"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "access modifiers [C#], accessibility level restrictions"
ms.assetid: 987e2f22-46bf-4fea-80ee-270b9cd01045
---
# Restrictions on using accessibility levels (C# Reference)

When you specify a type in a declaration, check whether the accessibility level of the type is dependent on the accessibility level of a member or of another type. For example, the direct base class must be at least as accessible as the derived class. The following declarations cause a compiler error because the base class `BaseClass` is less accessible than `MyClass`:

```csharp
class BaseClass {...}
public class MyClass: BaseClass {...} // Error
```

The following table summarizes the restrictions on declared accessibility levels.

|Context|Remarks|
|-------------|-------------|
|[Classes](../../fundamentals/types/classes.md)|The direct base class of a class type must be at least as accessible as the class type itself.|
|[Interfaces](../../fundamentals/types/interfaces.md)|The explicit base interfaces of an interface type must be at least as accessible as the interface type itself.|
|[Delegates](../../programming-guide/delegates/index.md)|The return type and parameter types of a delegate type must be at least as accessible as the delegate type itself.|
|[Constants](../../programming-guide/classes-and-structs/constants.md)|The type of a constant must be at least as accessible as the constant itself.|
|[Fields](../../programming-guide/classes-and-structs/fields.md)|The type of a field must be at least as accessible as the field itself.|
|[Methods](../../programming-guide/classes-and-structs/methods.md)|The return type and parameter types of a method must be at least as accessible as the method itself.|
|[Properties](../../programming-guide/classes-and-structs/properties.md)|The type of a property must be at least as accessible as the property itself.|
|[Events](../../programming-guide/events/index.md)|The type of an event must be at least as accessible as the event itself.|
|[Indexers](../../programming-guide/indexers/index.md)|The type and parameter types of an indexer must be at least as accessible as the indexer itself.|
|[Operators](../operators/index.md)|The return type and parameter types of an operator must be at least as accessible as the operator itself.|
|[Constructors](../../programming-guide/classes-and-structs/constructors.md)|The parameter types of a constructor must be at least as accessible as the constructor itself.|

## Example

The following example contains erroneous declarations of different types. The comment following each declaration indicates the expected compiler error.

```csharp
// Restrictions on Using Accessibility Levels
// CS0052 expected as well as CS0053, CS0056, and CS0057
// To make the program work, change access level of both class B
// and MyPrivateMethod() to public.

using System;

// A delegate:
delegate int MyDelegate();

class B
{
    // A private method:
    static int MyPrivateMethod()
    {
        return 0;
    }
}

public class A
{
    // Error: The type B is less accessible than the field A.myField.
    public B myField = new B();

    // Error: The type B is less accessible
    // than the constant A.myConst.
    public readonly B myConst = new B();

    public B MyMethod()
    {
        // Error: The type B is less accessible
        // than the method A.MyMethod.
        return new B();
    }

    // Error: The type B is less accessible than the property A.MyProp
    public B MyProp
    {
        set
        {
        }
    }

    MyDelegate d = new MyDelegate(B.MyPrivateMethod);
    // Even when B is declared public, you still get the error:
    // "The parameter B.MyPrivateMethod is not accessible due to
    // protection level."

    public static B operator +(A m1, B m2)
    {
        // Error: The type B is less accessible
        // than the operator A.operator +(A,B)
        return new B();
    }

    static void Main()
    {
        Console.Write("Compiled successfully");
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
- [Accessibility Domain](accessibility-domain.md)
- [Accessibility Levels](accessibility-levels.md)
- [Access Modifiers](../../programming-guide/classes-and-structs/access-modifiers.md)
- [public](public.md)
- [private](private.md)
- [protected](protected.md)
- [internal](internal.md)
