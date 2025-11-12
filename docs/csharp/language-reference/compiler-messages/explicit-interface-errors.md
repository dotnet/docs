---
title: Resolve errors and warnings that explicit interface implementation.
description: These compiler errors and warnings indicate errors in declaring methods that explicitly implement an interface member.
f1_keywords:
  - "CS0071"
  - "CS0106"
  - "CS0425"
  - "CS0460"
  - "CS0470"
  - "CS0473"
  - "CS0538"
  - "CS0539"
  - "CS0541"
  - "CS0551"
  - "CS0686"
  - "CS0736"
  - "CS9333"
  - "CS9334"
helpviewer_keywords:
  - "CS0071"
  - "CS0106"
  - "CS0425"
  - "CS0460"
  - "CS0470"
  - "CS0473"
  - "CS0538"
  - "CS0539"
  - "CS0541"
  - "CS0551"
  - "CS0686"
  - "CS0736"
  - "CS9333"
  - "CS9334"
ms.date: 11/12/2025
ai-usage: ai-assisted
---
# Resolve errors and warnings related to attribute declarations or attribute use in your code

This article covers the following compiler errors:

<!-- The text in this list generates issues for Acrolinx, because they don't use contractions.
That's by design. The text closely matches the text of the compiler error / warning for SEO purposes.
 -->
- [**CS0071**](#event-accessor-syntax): *An explicit interface implementation of an event must use event accessor syntax*
- [**CS0106**](#invalid-modifiers): *The modifier 'modifier' is not valid for this item*
- [**CS0425**](#constraint-mismatch): *The constraints for type parameter 'type parameter' of method 'method' must match the constraints for type parameter 'type parameter' of interface method 'method'. Consider using an explicit interface implementation instead.*
- [**CS0460**](#inherited-constraints): *Constraints for override and explicit interface implementation methods are inherited from the base method, so they cannot be specified directly*
- [**CS0470**](#accessor-implementation): *Method 'method' cannot implement interface accessor 'accessor' for type 'type'. Use an explicit interface implementation.*
- [**CS0473**](#ambiguous-match): *Explicit interface implementation 'method name' matches more than one interface member. Which interface member is actually chosen is implementation-dependent. Consider using a non-explicit implementation instead.*
- [**CS0538**](#not-an-interface): *'name' in explicit interface declaration is not an interface*
- [**CS0539**](#member-not-in-interface): *'member' in explicit interface declaration is not a member of interface*
- [**CS0541**](#wrong-location): *'declaration' : explicit interface declaration can only be declared in a class or struct*
- [**CS0551**](#missing-accessor): *Explicit interface implementation 'implementation' is missing accessor 'accessor'*
- [**CS0686**](#accessor-name-conflict): *Accessor 'accessor' cannot implement interface member 'member' for type 'type'. Use an explicit interface implementation.*
- [**CS0736**](#static-implementation): *'type name' does not implement interface member 'member name'. 'method name' cannot implement an interface member because it is static.*
- [**CS9333**](#incorrect-member-signature): *Parameter type must match implemented member declaration.*
- [**CS9334**](#incorrect-member-signature): *Return type must match implemented member declaration.*

## Event accessor syntax

- **CS0071**: *An explicit interface implementation of an event must use event accessor syntax*

When explicitly implementing an [event](../keywords/event.md) that was declared in an interface, you must manually provide the `add` and `remove` event accessors that are typically provided by the compiler. The accessor code can connect the interface event to another event in your class (shown later in this topic) or to its own delegate type. For more information, see [How to implement interface events](../../programming-guide/events/how-to-implement-interface-events.md).

The following sample generates CS0071:

```csharp
// CS0071.cs
public delegate void MyEvent(object sender);

interface ITest
{
    event MyEvent Clicked;
}

class Test : ITest
{
    event MyEvent ITest.Clicked;  // CS0071

    // Try the following code instead.
    /*
    private MyEvent clicked;

    event MyEvent ITest.Clicked
    {
        add
        {
            clicked += value;
        }
        remove
        {
            clicked -= value;
        }
    }
    */
    public static void Main() { }
}
```

## Invalid modifiers

- **CS0106**: *The modifier 'modifier' is not valid for this item*

When declaring explicit interface implementations, certain modifiers are not allowed:

- The `public` keyword is not allowed on an explicit interface declaration. In this case, remove the `public` keyword from the explicit interface declaration.
- The [abstract](../keywords/abstract.md) keyword is not allowed on an explicit interface declaration because an explicit interface implementation can never be overridden.

For more information, see [Interfaces](../../fundamentals/types/interfaces.md).

The following sample generates CS0106:

```csharp
// CS0106.cs
namespace MyNamespace
{
   interface I
   {
      void M1();
      void M2();
   }

   public class MyClass : I
   {
      public void I.M1() {}   // CS0106
      abstract void I.M2() {}   // CS0106

      public static void Main() {}
   }
}
```

## Constraint mismatch

- **CS0425**: *The constraints for type parameter 'type parameter' of method 'method' must match the constraints for type parameter 'type parameter' of interface method 'method'. Consider using an explicit interface implementation instead.*

This error occurs if a virtual generic method is overridden in a derived class and the constraints on the method in the derived class do not match the constraints on the method in the base class. To avoid this error, make sure the `where` clause is identical in both declarations, or implement the interface explicitly.

The following example generates CS0425:

```csharp
// CS0425.cs

class C1
{
}

class C2
{
}

interface IBase
{
    void F<ItemType>(ItemType item) where ItemType : C1;
}

class Derived : IBase
{
    public void F<ItemType>(ItemType item) where ItemType : C2  // CS0425
    {
    }
}

class CMain
{
    public static void Main()
    {
    }
}
```

The constraints do not have to be a literal match, as long as the set of constraints has the same meaning. For example, the following is okay:

```csharp
// CS0425b.cs

interface J<Z>
{
}

interface I<S>
{
    void F<T>(S s, T t) where T: J<S>, J<int>;
}

class C : I<int>
{
    public void F<X>(int s, X x) where X : J<int>
    {
    }

    public static void Main()
    {
    }
}
```

## Inherited constraints

- **CS0460**: *Constraints for override and explicit interface implementation methods are inherited from the base method, so they cannot be specified directly*

When a generic method that is part of a derived class overrides a method in the base class, you can't specify constraints on the overridden method. The override method in the derived class inherits its constraints from the method in the base class.

However, there are exceptions to this rule:

- Starting with C# 9, you can apply the `default` constraint to `override` and explicit interface implementation methods to resolve ambiguities with nullable reference types.
- Starting with C# 8, you can explicitly specify `where T : class` and `where T : struct` constraints on `override` and explicit interface implementation methods to allow annotations for type parameters constrained to reference types.

The following sample generates CS0460 when attempting to redeclare inherited constraints:

```csharp
// CS0460.cs
// compile with: /target:library
class BaseClass
{
   BaseClass() { }
}

interface I
{
   void F1<T>() where T : BaseClass;
   void F2<T>() where T : struct;
   void F3<T>();
   void F4<T>() where T : struct;
}

class ExpImpl : I
{
    // CS0460 - cannot redeclare inherited constraint.
    void I.F1<T>() where T : BaseClass { }
    
    // Allowed - explicit constraint for struct.
    void I.F2<T>() where T : struct { }
   
    // Valid since C# 8 - explicit class constraint for nullable annotations.
    void I.F4<T>() where T : struct { }
    
    // Valid since C# 9 - default constraint to resolve ambiguities.
    void I.F3<T>() where T : default { }
}
```

## Ambiguous match

- **CS0473**: *Explicit interface implementation 'method name' matches more than one interface member. Which interface member is actually chosen is implementation-dependent. Consider using a non-explicit implementation instead.*

In some cases a generic method might acquire the same signature as a non-generic method. The problem is that there is no way in the common language infrastructure (CLI) metadata system to unambiguously state which method binds to which slot. It is up to the CLI to make that determination.

To correct the error, eliminate the explicit implementation and implement both of the interface methods in the implicit implementation `public int TestMethod(int)`.

The following code generates CS0473:

```csharp
public interface ITest<T>
{
    int TestMethod(int i);
    int TestMethod(T i);
}

public class ImplementingClass : ITest<int>
{
    int ITest<int>.TestMethod(int i) // CS0473
    {
        return i + 1;
    }

    public int TestMethod(int i)
    {
        return i - 1;
    }
}

class T
{
    static int Main()
    {
        ImplementingClass a = new ImplementingClass();
        if (a.TestMethod(0) != -1)
            return -1;

        ITest<int> i_a = a;
        System.Console.WriteLine(i_a.TestMethod(0).ToString());
        if (i_a.TestMethod(0) != 1)
            return -1;

        return 0;
    }
}
```

## Accessor implementation

- **CS0470**: *Method 'method' cannot implement interface accessor 'accessor' for type 'type'. Use an explicit interface implementation.*

This error is generated when an accessor is trying to implement an interface. Explicit interface implementation must be used.

The following sample generates CS0470:

```csharp
// CS0470.cs
// compile with: /target:library

interface I
{
   int P { get; }
}

class MyClass : I
{
   public int get_P() { return 0; }   // CS0470
   public int P2 { get { return 0;} }   // OK
}
```

## Not an interface

- **CS0538**: *'name' in explicit interface declaration is not an interface*

An attempt was made to explicitly declare an [interface](../keywords/interface.md), but an interface was not specified.

The following sample generates CS0538:

```csharp
// CS0538.cs
interface MyIFace
{
   void F();
}

public class MyClass
{
   public void G()
   {
   }
}

class C: MyIFace
{
   void MyIFace.F()
   {
   }

   void MyClass.G()   // CS0538, MyClass not an interface
   {
   }
}
```

## Member not in interface

- **CS0539**: *'member' in explicit interface declaration is not a member of interface*

An attempt was made to explicitly declare an [interface](../keywords/interface.md) member that does not exist. You should either delete the declaration or change it so that it refers to a valid interface member.

The following sample generates CS0539:

```csharp
// CS0539.cs
namespace x
{
   interface I
   {
      void m();
   }

   public class clx : I
   {
      void I.x()   // CS0539
      {
      }

      public static int Main()
      {
         return 0;
      }
   }
}
```

## Wrong location

- **CS0541**: *'declaration' : explicit interface declaration can only be declared in a class or struct*

An explicit [interface](../keywords/interface.md) declaration was found outside a [class](../keywords/class.md) or [struct](../builtin-types/struct.md).

The following sample generates CS0541:

```csharp
// CS0541.cs
namespace x
{
   interface IFace
   {
      void F();
   }

   interface IFace2 : IFace
   {
      void IFace.F();   // CS0541
   }
}
```

## Missing accessor

- **CS0551**: *Explicit interface implementation 'implementation' is missing accessor 'accessor'*

A class that explicitly implements an interface's property must implement all the accessors that the interface defines.

For more information, see [Using Properties](../../programming-guide/classes-and-structs/using-properties.md).

The following sample generates CS0551:

```csharp
// CS0551.cs
// compile with: /target:library
interface ii
{
   int i
   {
      get;
      set;
   }
}

public class a : ii
{
   int ii.i { set {} }   // CS0551

   // OK
   int ii.i
   {
      set {}
      get { return 0; }
   }
}
```

## Accessor name conflict

- **CS0686**: *Accessor 'accessor' cannot implement interface member 'member' for type 'type'. Use an explicit interface implementation.*

This error can occur when implementing an interface that contains method names which conflict with the auto-generated methods associated with a property or event. The get/set methods for properties are generated as get_property and set_property, and the add/remove methods for events are generated as add_event and remove_event. If an interface contains either of these methods, a conflict occurs. To avoid this error, implement the methods using an explicit interface implementation. To do this, specify the function as:

```csharp
Interface.get_property() { /* */ }
Interface.set_property() { /* */ }
```

### Example 1

The following sample generates CS0686:

```csharp
// CS0686.cs
interface I
{
    int get_P();
}

class C : I
{
    public int P
    {
        get { return 1; }  // CS0686
    }
}
// But the following is valid:
class D : I
{
    int I.get_P() { return 1; }
    public static void Main() {}
}
```

### Example 2

This error can also occur when declaring events. The event construct automatically generates the `add_event` and `remove_event` methods, which could conflict with the methods of the same name in an interface, as in the following sample:

```csharp
// CS0686b.cs
using System;

interface I
{
    void add_OnMyEvent(EventHandler e);
}

class C : I
{
    public event EventHandler OnMyEvent
    {
        add { }  // CS0686
        remove { }
    }
}

// Correct (using explicit interface implementation):
class D : I
{
    void I.add_OnMyEvent(EventHandler e) {}
    public static void Main() {}
}
```

## Static implementation

- **CS0736**: *'type name' does not implement interface member 'member name'. 'method name' cannot implement an interface member because it is static.*

This error is generated when a static method is either implicitly or explicitly declared as an implementation of an interface member.

To correct this error:

- Remove the [static](../keywords/static.md) modifier from the method declaration.
- Change the name of the interface method.
- Redefine the containing type so that it does not inherit from the interface.

For more information, see [Interfaces](../../fundamentals/types/interfaces.md).

The following code generates CS0736 because `Program.testMethod` is declared as static:

```csharp
// cs0736.cs
namespace CS0736
{
    interface ITest
    {
        int testMethod(int x);
    }

    class Program : ITest // CS0736
    {
        public static int testMethod(int x) { return 0; }
        // Try the following line instead.
        // public int testMethod(int x) { return 0; }
        public static void Main() { }
    }
}
```

## Incorrect member signature

The following errors occur when the explicit member implementation doesn't match the declaration

- **CS9333**: *Parameter type must match implemented member declaration.*
- **CS9334**: *Return type must match implemented member declaration.*
