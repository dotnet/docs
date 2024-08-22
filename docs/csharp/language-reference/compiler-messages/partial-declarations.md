---
title: Compiler Errors on partial type and member declarations
description: Use this article to diagnose and correct compiler errors and warnings when you write `partial` types and `partial` members.
f1_keywords:
  - "CS0260"
  - "CS0261"
  - "CS0262"
  - "CS0263"
  - "CS0264"
  - "CS0265"
  - "CS0267"
  - "CS0282"
  - "CS0501"
  - "CS0750"
  - "CS0751"
  - "CS0754"
  - "CS0755"
  - "CS0756"
  - "CS0757"
  - "CS0759"
  - "CS0761"
  - "CS0762"
  - "CS0763"
  - "CS0764"
  - "CS1067"
  - "CS8142"
  - "CS8663"
  - "CS8796"
  - "CS8795"
  - "CS8797"
  - "CS8798"
  - "CS8799"
  - "CS8800"
  - "CS8817"
  - "CS8818"
  - "CS8863"
  - "CS8988"
  - "CS9248"
  - "CS9249"
  - "CS9250"
  - "CS9251"
  - "CS9152"
  - "CS9253"
  - "CS9254"
  - "CS9255"
  - "CS9256"
  - "CS9257"
helpviewer_keywords:
ms.date: 08/21/2024
---
# Errors and warnings related to `partial` type and `partial` member declarations

There are numerous *errors* related to `partial` type and `partial` member declarations:

<!-- The text in this list generates issues for Acrolinx, because they don't use contractions.
That's by design. The text closely matches the text of the compiler error / warning for SEO purposes.
 -->
- **CS8142**: *Both partial member declarations must use the same tuple element names.*
- **CS8663**: *Both partial member declarations must be readonly or neither may be readonly*
- **CS8796**: *Partial method '{0}' must have accessibility modifiers because it has a non-void return type.*
- **CS8797**: *Partial method '{0}' must have accessibility modifiers because it has 'out' parameters.*
- **CS8798**: *Partial method '{0}' must have accessibility modifiers because it has a 'virtual', 'override', 'sealed', 'new', or 'extern' modifier.*
- **CS8799**: *Both partial member declarations must have identical accessibility modifiers.*
- **CS8800**: *Both partial member declarations must have identical combinations of `virtual`, `override`, `sealed`, and `new` modifiers.*
- **CS8818**: *Partial member declarations must have matching ref return values.*
- **CS8863**: *Only a single partial type declaration may have a parameter list*
- **CS8988**: *The `scoped` modifier of parameter doesn't match partial definition.*
- [**CS9248**](#partial-properties): *Partial property must have an implementation part.*
- [**CS9249**](#partial-properties): *Partial property must have a definition part.*
- [**CS9250**](#partial-properties): *A partial property may not have multiple defining declarations, and cannot be an auto-property.*
- [**CS9251**](#partial-properties): *A partial property may not have multiple implementing declarations*
- [**CS9252**](#partial-properties): *Property accessor must be implemented because it is declared on the definition part*
- [**CS9253**](#partial-properties): *Property accessor does not implement any accessor declared on the definition part*
- [**CS9254**](#partial-properties): *Property accessor must match the definition part*
- [**CS9255**](#partial-properties): *Both partial property declarations must have the same type.*
- [**CS9256**](#partial-properties): *Partial property declarations have signature differences.*
- [**CS9257**](#partial-properties): *Both partial property declarations must be required or neither may be required*

## Partial properties

The following errors and warnings are issued when a partial property or indexer is declared incorrectly:

- **CS9248**: *Partial property must have an implementation part.*
- **CS9249**: *Partial property must have a definition part.*
- **CS9250**: *A partial property may not have multiple defining declarations, and cannot be an auto-property.*
- **CS9251**: *A partial property may not have multiple implementing declarations*
- **CS9252**: *Property accessor must be implemented because it is declared on the definition part*
- **CS9253**: *Property accessor does not implement any accessor declared on the definition part*
- **CS9254**: *Property accessor must match the definition part*
- **CS9255**: *Both partial property declarations must have the same type.*
- **CS9257**: *Both partial property declarations must be required or neither may be required*

The following warning indicates signature differences in the partial property declarations:

- **CS9256**: *Partial property declarations have signature differences.*

## Compiler Error CS0260

Missing partial modifier on declaration of type 'type'; another partial declaration of this type exists

This error indicates that you have declared multiple classes that have the same name. In addition, at least one but not all of the declarations contains the `partial` modifier. If you want to define a class in several parts, you must declare each part by using the keyword `partial`.

This error also occurs if you declare a class and accidentally give it the same name as a partial class that's declared elsewhere in the same namespace.

The following sample generates CS0260:

```csharp
// CS0260.cs
// You must mark both parts of the definition of class C
// by using the partial keyword.

// The following line causes CS0260. To resolve the error, add
// the 'partial' keyword to the declaration.
class C
{
}

partial class C
{
}
```

## Compiler Error CS0261

Partial declarations of 'type' must be all classes, all structs, or all interfaces

This error occurs if a partial type is declared as a different type of construct in various places. For more information, see [Partial types](../keywords/partial-type.md).

The following sample generates CS0261:

```csharp
// CS0261.cs
partial class A  // CS0261 – A declared as a class here, but as a struct below
{
}

partial struct A
{
}
```

## Compiler Error CS0262

Partial declarations of 'type' have conflicting accessibility modifiers

This error occurs if a partial type has inconsistent modifiers such as public, private, protected, internal, or abstract. These modifiers must be consistent in all partial declarations for that type. For more information, see [Partial types](../keywords/partial-type.md).

The following sample generates CS0262:

```csharp
// CS0262.cs
class A
{
    public partial class C  // CS0262
    {
    }
    private partial class C
    {
    }
}
```

## Compiler Error CS0263

Partial declarations of 'type' must not specify different base classes

When defining a type in partial declarations, specify the same base types in each of the partial declarations. For more information, see [Partial types](../keywords/partial-type.md).

The following sample generates CS0263:

```csharp
// CS0263.cs
// compile with: /target:library
class B1
{
}

class B2
{
}
partial class C : B1  // CS0263 – is the base class B1 or B2?
{
}

partial class C : B2
{
}
```

## Compiler Error CS0264

Partial declarations of 'type' must have the same type parameter names in the same order

This error occurs if you are defining a generic type in partial declarations and the type parameters are not consistent in name or order throughout all of the partial declarations. To get rid of this error, check the type parameters for each partial declaration and make sure the same name and order of parameters is used. For more information, see [Partial types](../keywords/partial-type.md) and [Generic Type Parameters](../../programming-guide/generics/generic-type-parameters.md).

The following example generates CS0264.

```csharp
// CS0264.cs

partial class MyClass<T>  // CS0264
{
}

partial class MyClass <MyType>
{
}
```

## Compiler Error CS0265

Partial declarations of 'type' have inconsistent constraints for type parameter 'type parameter'

This error happens when you define a generic class as a partial class, so that its partial definitions occur in more than one place, and the constraints on the generic type are inconsistent or different in two or more places. If you specify the constraints in more than one place, they must all be identical. The easiest solution is to specify the constraints in one place, and omit them everywhere else. For more information, see [Partial types](../keywords/partial-type.md) and [Constraints on Type Parameters](../../programming-guide/generics/constraints-on-type-parameters.md).

The following code generates error CS0265.

In this code, the partial class definitions are all in a single file, but they could also be spread across multiple files.

```csharp
// CS0265.cs
public class GenericsErrors
{
    interface IFace1 { }
    interface IFace2 { }
    partial class PartialBadBounds<T> where T : IFace1 { } // CS0265
    partial class PartialBadBounds<T> where T : IFace2 { }
}
```

## Compiler Error CS0267

The partial modifier can only appear immediately before 'class', 'record', 'struct', 'interface', or a method return type.

The placement of the **partial** modifier was incorrect in the declaration of the class, record, struct, interface, or method. To fix the error, reorder the modifiers. For more information, see [Partial types](../keywords/partial-type.md).

The following sample generates CS0267:

```csharp
public partial class MyClass
{
}

partial public class MyClass  // CS0267
// Try this line instead:
// public partial class MyClass
{
}
```

## Compiler Warning (level 3) CS0282

There is no defined ordering between fields in multiple declarations of partial class or struct 'type'. To specify an ordering, all instance fields must be in the same declaration.

To resolve this error, put all member variables in a single partial class definition.

A common way to get this error is by having a partial `struct` defined in more than one place, with some of the member variables in one definition, and some in another.

The following code generates CS0282.

This code contains one description of a `struct`. Compile these two modules together in a single step by means of the command:

`csc /target:library cs0282_1.cs cs0282_2.cs`

```csharp
partial struct A
{
    int i;
}
```

This code contains a conflicting description of the same `struct`.

```csharp
partial struct A
{
    int j;
}
```

> [!NOTE]
> If the struct layout does not matter, decorating the struct with `[StructLayout(LayoutKind.Auto)]` will express it,and suppress the warning

## Compiler Error CS0501

'member function' must declare a body because it is not marked abstract, extern, or partial

Nonabstract methods must have implementations.

In C#, methods/functions that are a part of a class must have a "body", or implementation. The compiler needs to know what should happen when these methods are called, so that it knows what to execute. A method with no body is not acceptable to the compiler because it wants to avoid confusion about the intent of the code.

There are exceptions to this rule:

- When the method is marked `abstract` as an [Abstract Method](../../language-reference/keywords/abstract.md)
- When the method is marked `extern` as an [External Method](../../language-reference/keywords/extern.md)
- When the method is marked `partial` as a [Partial Method](../../language-reference/keywords/partial-method.md)

The following sample generates CS0501:

```csharp
public class MyClass
{
   public void MethodWithNoBody();   // CS0501 declared but not defined
}
```

This could be fixed by declaring a body (by adding brackets):

```csharp  
public class MyClass
{  
   public void MethodWithNoBody() { }   // No error; compiler now interprets as an empty method
}  
```

> [!NOTE]
> When defining a method body with brackets, do not add a semicolon. Doing so will trigger [compiler error CS1597](../../misc//cs1597.md).

Or, using an appropriate keyword, such as defining an `abstract` method:

```csharp
abstract class MyClass // class is abstract; classes that inherit from it will have to define MyAbstractMethod
{  
   public abstract void MyAbstractMethod();   // Compiler now knows that this method must be defined by inheriting classes.
}  
```

## Compiler Error CS0750

A partial method cannot have access modifiers or the virtual, abstract, override, new, sealed, or extern modifiers.

Because of their special behavior, partial methods are subject to restrictions as to the modifiers they can accept.

Remove the unauthorized modifier from the method declaration.

The following example generates CS0750:

```csharp
// cs0750.cs
using System;

public class Base
{
    protected virtual void PartG()
    {
    }

    protected void PartH()
    {
    }
    protected virtual void PartI()
    {
    }
}

public partial class C:Base
{
    // All these partial method declarations
    // will generate CS0750.
    public partial void PartA();
    private partial void PartB();
    protected partial void PartC();
    internal partial void PartD();
    virtual partial void PartE();
    abstract partial void PartF();
    override partial void PartG();
    new partial void PartH();
    sealed override partial void PartI();
    extern partial void PartJ();

    public static int Main()
    {
        return 1;
    }
}
```

## Compiler Error CS0751

A partial member must be declared in a partial class or partial struct

It is not possible to declare a [partial](../../language-reference/keywords/partial-method.md) method unless it is encapsulated inside a partial class or partial struct.

Either remove the `partial` modifier from the method and provide an implementation, or else add the `partial` modifier to the enclosing class or struct.

The following example generates CS0751:

```csharp
// cs0751.cs
using System;

public class C
{
    partial void Part(); // CS0751
    public static int Main()
    {
        return 1;
    }
}
```

## Compiler Error CS0754

A partial method may not explicitly implement an interface method.

A partial method cannot be declared as an explicit implementation of a method defined in an interface.

Remove the explicit interface qualification from the method declaration.

The following code generates CS0754:

```csharp
// cs0754.cs
using System;

    public interface IF
    {
        void Part();
    }

    public partial class C : IF
    {
        partial void IF.Part(); //CS0754
        public static int Main()
        {
            return 1;
        }
    }
```

## Compiler Error CS0755

Both partial method declarations must be extension methods or neither may be an extension method.

A partial method consists of a defining declaration (signature) and an optional implementing declaration (body). If the defining declaration is an extension method, the implementing declaration, if one is defined, must also be an extension method. And if the defining method is not an extension method, the implementing must not be one either.

Either remove the `this` modifier from one of the parts, or add it to the other.

The following example generates CS0755:

```csharp
// cs0755.cs
    public static partial class Ext
    {
        static partial void Part(this C c); //Extension method

        // Typically the implementing declaration is in a separate file.
        static partial void Part(C c) //CS0755
        {
        }
    }

    public partial class C
    {
        public static int Main()
        {
            return 1;
        }
    }
```

## Compiler Error CS0756

A partial method may not have multiple defining declarations.

The defining declaration of a partial method is the part that specifies the method signature, but not the implementation (method body). A partial method must have exactly one defining declaration for each unique signature. Each overloaded version of a partial method must have its own defining declaration.

The following sample generates CS0756:

```csharp
// CS0756.cs (5,18)

public partial class PartialClass
{
    partial void PartialMethod();
    partial void PartialMethod();
}
```

Remove all except one defining declaration for the partial method:

```csharp
public partial class PartialClass
{
    partial void PartialMethod();
}
```

## Compiler Error CS0757

A partial method may not have multiple implementing declarations.

A partial method consists of exactly one defining declaration (signature) and one or zero implementing declarations (body). Multiple implementing declarations for the same identical defining declarations are not allowed. Partial methods may be overloaded, and each overloaded version may have one or zero implementing declarations.

Remove all except one of the implementing declarations for the partial method.

The following example generates CS0757:

```csharp
// cs0757.cs
using System;

    public partial class C
    {
        // Defining declaration.
        partial void Part();

        // Implementing declaration.
        partial void Part()
        {
            //...Do something.
        }

        // Second implementing declaration.
        partial void Part() // CS0757
        {
            //...Do something.
        }

        public static int Main()
        {
            return 1;
        }
    }
```

## Compiler Error CS0759

No defining declaration found for implementing declaration of partial method 'method'.

A partial method must have a defining declaration that defines the signature (name, return type and parameters) of the method. The implementation or method body is optional.

Provide a defining declaration for the partial method in the other part of a partial class or struct.

The following example generates CS0759:

```csharp
// cs0759.cs
using System;

public partial class C
{
    partial void Part() // CS0759
    {
    }

    public static int Main()
    {
        return 1;
    }
}
```  

To correct this error a defining declaration for `Part()` method should be provided:

```csharp
using System;

public partial class C
{
    partial void Part();    // Defining declaration
}

public partial class C
{
    partial void Part()     // Implementing declaration, no CS0759
    {
    }

    public static int Main()
    {
        return 1;
    }
}
```

## Compiler Error CS0761

Partial method declarations of 'method\<T>' have inconsistent type parameter constraints.

If a partial method has an implementation, the generic type constraint must be identical to the constraint defined on the method signature.

Make the generic type constraints identical on each part of the partial method.  
  
The following code generates CS0761:

```csharp
// cs0761.cs
using System;

public partial class C
{
    partial void Part<T>() where T : class;
    partial void Part<T>() where T : struct // CS0761
    {
    }

    public static int Main()
    {
        return 1;
    }
}
```

## Compiler Error CS0762

Cannot create delegate from method 'method' because it is a partial method without an implementing declaration

A partial method is not required to have an implementing declaration. However, a delegate does require that its encapsulated method have an implementation.

Provide an implementation for the method that is used to initialize the delegate.

```csharp
public delegate void TestDel();

public partial class C
{ 
    partial void Part();

    public static int Main()
    {
        C c = new C();
        TestDel td = new TestDel(c.Part); // CS0762
        return 1;
    }
}  
```

## Compiler Error CS0763

Both partial method declarations must be static or neither may be static.

A partial method declaration cannot have one part static and the other part not static.

Make both parts either static or non-static.

The following code generates CS0763:

```csharp
// cs0763.cs
using System;

public partial class C
{
    static partial void Part();
    partial void Part() // CS0763
    {
    }

    public static int Main()
    {
        return 1;
    }
}
```

## Compiler Error CS0764

Both partial method declarations must be unsafe or neither may be unsafe

A partial method consists of a defining declaration (signature) and an optional implementing declaration (body). If the defining declaration has the `unsafe` modifier, the implementing declaration must also have it. Conversely, if the implementing declaration has the `unsafe` modifier, the defining declaration must also.

Assuming that the defining declaration is correct, add or remove the `unsafe` modifier from the implementing declaration to match the defining declaration.

```csharp
// cs0764.cs
//  Compile with: /target:library /unsafe
public partial class C
{
    partial void Part();
    unsafe partial void Part() //CS0764
    {
    }

    public static int Main()
    {
        return 1;
    }
}
```

## Compiler Error CS1067

Partial declarations of 'type' must have the same type parameter names and variance modifiers in the same order.

Both defining and implementing declaration of a generic partial interface must have their signatures matching including the type parameters and variance modifers in the same order between defining and implementing declaration.

The following samples generate CS1067:

```csharp
// CS1067: type parameter 'T' has an extra 'out' modifier
public partial interface IExample1<out T>;
public partial interface IExample1<T>
{ }

// CS1067: type parameter 'T' differs in variance modifier
public partial interface IExample2<in T>;
public partial interface IExample2<out T>
{ }

// CS1067: type parameters 'T' and 'S' differs in their order
public partial interface IExample3<in S, out T>;
public partial interface IExample3<out T, in S>
{ }
```

To correct this error keep the same signatures for both defining and implementing declaration of a generic partial interface:

```csharp
public partial interface IExample1<T>;
public partial interface IExample1<T>
{ }

public partial interface IExample2<out T>;
public partial interface IExample2<out T>
{ }

public partial interface IExample3<out T, in S>;
public partial interface IExample3<out T, in S>
{ }
```

## Compiler Error CS8795

Partial member must have an implementation part because it has accessibility modifiers.

The following sample generates CS8795:

```csharp
// CS8795.cs (4,25)

public partial class PartialClass
{
    public partial void PartialMethod();
}
```

Add an implementation in another partial class:

```csharp
public partial class PartialClass
{
    public partial void PartialMethod();
}

public partial class PartialClass
{
    public partial void PartialMethod() {}
}
```

> [!NOTE]
> The following is not allowed as it is missing the defining declaration that specifies the signature of the partial method (without any implementation). Since the following partial method has an access modifier, it *must* also have a corresponding implementation part separate from the defining declaration (present in the following example).
>
> ```csharp
> public partial class PartialClass
> {
>     public partial void PartialMethod() {}
> }
> ```
>
> See [CS0759](../../misc/cs0759.md) for more details.

Alternatively, remove the access modifier (this will make it default to `private`):

```csharp
public partial class PartialClass
{
    partial void PartialMethod();
}
```

## Compiler Error CS8817

Both partial method declarations must have the same return type.

The following sample generates CS8817:

```csharp
// CS8817.cs (9,24)

public partial class PartialClass
{
    public partial long PartialMethod();
}

public partial class PartialClass
{
    public partial int PartialMethod()
    {
        return 1;
    }
}
```

To correct this error ensure that the return type matches:

```csharp
public partial class PartialClass
{
    public partial long PartialMethod();
}

public partial class PartialClass
{
    public partial long PartialMethod()
    {
        return 1;
    }
}
```
