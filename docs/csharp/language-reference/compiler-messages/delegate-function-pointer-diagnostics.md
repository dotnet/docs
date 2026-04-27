---
title: "Resolve errors and warnings related to delegate and function pointer declarations and uses"
description: "This article helps you diagnose and correct compiler errors and warnings related to delegate and function pointer declarations and uses"
f1_keywords:
  - "CS0059"
  - "CS0123"
  - "CS0148"
  - "CS0410"
  - "CS0644"
  - "CS1599"
  - "CS1958"
  - "CS8755"
  - "CS8756"
  - "CS8757"
  - "CS8758"
  - "CS8759"
  - "CS8786"
  - "CS8787"
  - "CS8788"
  - "CS8789"
  - "CS8806"
  - "CS8807"
  - "CS8808"
  - "CS8809"
  - "CS8811"
  - "CS8909"
  - "CS8911"
helpviewer_keywords:
  - "CS0059"
  - "CS0123"
  - "CS0148"
  - "CS0410"
  - "CS0644"
  - "CS1599"
  - "CS1958"
  - "CS8755"
  - "CS8756"
  - "CS8757"
  - "CS8758"
  - "CS8759"
  - "CS8786"
  - "CS8787"
  - "CS8788"
  - "CS8789"
  - "CS8806"
  - "CS8807"
  - "CS8808"
  - "CS8809"
  - "CS8811"
  - "CS8909"
  - "CS8911"
ms.date: 04/27/2026
ai-usage: ai-assisted
---

# Resolve errors and warnings for delegate and function pointer declarations

This article covers the following compiler errors and warnings:

<!-- The text in this list generates issues for Acrolinx, because they don't use contractions.
That's by design. The text closely matches the text of the compiler error / warning for SEO purposes.
 -->

- [**CS0059**](#anchor-tbd): *Inconsistent accessibility: parameter type 'type' is less accessible than delegate 'delegate'.*
- [**CS0123**](#anchor-tbd): *No overload for 'method' matches delegate 'delegate'.*
- [**CS0148**](#anchor-tbd): *The delegate 'delegate' does not have a valid constructor.*
- [**CS0410**](#anchor-tbd): *No overload for 'method' has the correct parameter and return types.*
- [**CS0644**](#anchor-tbd): *'class' cannot derive from special class 'class'.*
- [**CS1599**](#anchor-tbd): *The return type of a method, delegate, or function pointer cannot be 'type'.*
- [**CS1958**](#anchor-tbd): *Object and collection initializer expressions may not be applied to a delegate creation expression.*
- [**CS8755**](#anchor-tbd): *'modifier' cannot be used as a modifier on a function pointer parameter.*
- [**CS8756**](#anchor-tbd): *Function pointer 'type' does not take 'count' arguments.*
- [**CS8757**](#anchor-tbd): *No overload for 'method' matches function pointer 'type'.*
- [**CS8758**](#anchor-tbd): *Ref mismatch between 'method' and function pointer 'type'.*
- [**CS8759**](#anchor-tbd): *Cannot create a function pointer for 'method' because it is not a static method.*
- [**CS8786**](#anchor-tbd): *Calling convention of 'convention' is not compatible with 'convention'.*
- [**CS8787**](#anchor-tbd): *Cannot convert method group to function pointer. (Are you missing a '&'?)*
- [**CS8788**](#anchor-tbd): *Cannot use an extension method with a receiver as the target of a '&' operator.*
- [**CS8789**](#anchor-tbd): *The type of a local declared in a fixed statement cannot be a function pointer type.*
- [**CS8806**](#anchor-tbd): *The calling convention of 'convention' is not supported by the language.*
- [**CS8807**](#anchor-tbd): *'specifier' is not a valid calling convention specifier for a function pointer.*
- [**CS8808**](#anchor-tbd): *'modifier' is not a valid function pointer return type modifier. Valid modifiers are 'ref' and 'ref readonly'.*
- [**CS8809**](#anchor-tbd): *A return type can only have one 'modifier' modifier.*
- [**CS8811**](#anchor-tbd): *Cannot convert &method group 'method' to delegate type 'type'.*
- [**CS8909**](#anchor-tbd): *Comparison of function pointers might yield an unexpected result, since pointers to the same function may be distinct.*
- [**CS8911**](#anchor-tbd): *Using a function pointer type in this context is not supported.*

## CS0059

Inconsistent accessibility: parameter type 'type' is less accessible than delegate 'delegate'

The return type and each of the types referenced in the formal parameter list of a method must be at least as accessible as the method itself. For more information, see [Access Modifiers](../../programming-guide/classes-and-structs/access-modifiers.md).

The following sample generates CS0059:

```csharp
// CS0059.cs
class MyClass //defaults to private accessibility
// try the following line instead
// public class MyClass
{
}

public delegate void MyClassDel( MyClass myClass);   // CS0059

public class Program
{
    public static void Main()
    {
    }
}
```

## CS0123

No overload for 'method' matches delegate 'delegate'

An attempt to create a delegate failed because the correct signature was not used. Instances of a delegate must be declared with the same signature as the delegate declaration.

You can resolve this error by adjusting either the method or delegate signature. For more information, see [Delegates](../../programming-guide/delegates/index.md).

The following sample generates CS0123.

```csharp
// CS0123.cs
delegate void D();
delegate void D2(int i);

public class C
{
   public static void f(int i) {}

   public static void Main()
   {
      D d = new D(f);   // CS0123
      D2 d2 = new D2(f);   // OK
   }
}
```

## CS0148

The delegate 'delegate' does not have a valid constructor

You imported and used a managed program (one that uses the .NET runtime) that was created with another compiler. That compiler allowed an ill-formed [delegate](../../language-reference/builtin-types/reference-types.md) constructor. For more information, see [Delegates](../../programming-guide/delegates/index.md).

[!INCLUDE[csharp-build-only-diagnostic-note](~/includes/csharp-build-only-diagnostic-note.md)]

## CS0410

No overload for 'method' has the correct parameter and return types

This error occurs if you try to instantiate a delegate with a function that has the wrong parameter types. The parameter types of the delegate must match the function that you are assigning to the delegate.

The following example generates CS0410:

```csharp
// CS0410.cs
// compile with: /langversion:ISO-1

class Test
{
    delegate void D(double d );
    static void F(int i) { }

    static void Main()
    {
        D d = new D(F);  // CS0410
    }
}
```

> [!NOTE]
> This compiler error is no longer used in Roslyn. The previous example generates CS0123 when compiled with Roslyn.

## CS0644

'class' cannot derive from special class 'class'

Classes can't explicitly inherit from any of the following base classes:

- **System.Enum**
- **System.ValueType**
- **System.Delegate**
- **System.Array**

These are used as implicit base classes by the compiler. For example, **System.ValueType** is the implicit base class of structs.

The following sample generates CS0644:

```csharp
// CS0644.cs
class MyClass : System.ValueType   // CS0644
{
}
```

## CS1599

The return type of a method, delegate, or function pointer cannot be 'type'

Some types in the .NET class library, for example, <xref:System.TypedReference>, <xref:System.RuntimeArgumentHandle> and <xref:System.ArgIterator> can't be used as return types because they can potentially be used to perform unsafe operations.

The following sample generates CS1599:

```csharp
// CS1599.cs
using System;

class MyClass
{
   public static void Main()
   {
   }

   public TypedReference Test1()   // CS1599
   {
      return null;
   }

   public ArgIterator Test2()   // CS1599
   {
      return null;
   }
}
```

## CS1958

Object and collection initializer expressions may not be applied to a delegate creation expression

A delegate has no members like a class or struct has, and so there's nothing for an object initializer to initialize. If you encounter this error, it's probably because there are braces after the delegate creation expression. Remove the braces and this error disappears.

The following code produces CS1958:

```csharp
// cs1958.cs
public class MemberInitializerTest
{
    delegate void D<T>();
    public static void GenericMethod<T>() { }
    public static void Run()
    {
        D<int> genD = new D<int>(GenericMethod<int>) { }; // CS1958
       // Try the following line instead
      // D<int> genD = new D<int>(GenericMethod<int>);
    }
}
```
