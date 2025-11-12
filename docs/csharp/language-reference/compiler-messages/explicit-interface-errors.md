---
title: Resolve errors and warnings that explicit interface implementation.
description: These compiler errors and warnings indicate errors in declaring methods that explicitly implement an interface member.
f1_keywords:
  - "CS0071"
  - "CS0106"
  - "CS0277"
  - "CS0425"
  - "CS0460"
  - "CS0470"
  - "CS0473"
  - "CS0531"
  - "CS0535"
  - "CS0538"
  - "CS0539"
  - "CS0540"
  - "CS0541"
  - "CS0550"
  - "CS0551"
  - "CS0630"
  - "CS0686"
  - "CS0736"
  - "CS0737"
  - "CS0738"
  - "CS8705"
  - "CS8854"
  - "CS9333"
  - "CS9334"
helpviewer_keywords:
  - "CS0071"
  - "CS0106"
  - "CS0277"
  - "CS0425"
  - "CS0460"
  - "CS0470"
  - "CS0473"
  - "CS0531"
  - "CS0535"
  - "CS0538"
  - "CS0539"
  - "CS0540"
  - "CS0541"
  - "CS0550"
  - "CS0551"
  - "CS0630"
  - "CS0686"
  - "CS0736"
  - "CS0737"
  - "CS0738"
  - "CS8705"
  - "CS8854"
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
- [**CS0071**](#interface-declaration-and-syntax): *An explicit interface implementation of an event must use event accessor syntax*
- [**CS0106**](#interface-declaration-and-syntax): *The modifier 'modifier' is not valid for this item*
- [**CS0277**](#accessor-implementation-and-conflicts): *'class' does not implement interface member 'accessor'. 'class accessor' is not public*
- [**CS0425**](#generic-type-constraints): *The constraints for type parameter 'type parameter' of method 'method' must match the constraints for type parameter 'type parameter' of interface method 'method'. Consider using an explicit interface implementation instead.*
- [**CS0460**](#generic-type-constraints): *Constraints for override and explicit interface implementation methods are inherited from the base method, so they cannot be specified directly*
- [**CS0470**](#accessor-implementation-and-conflicts): *Method 'method' cannot implement interface accessor 'accessor' for type 'type'. Use an explicit interface implementation.*
- [**CS0473**](#ambiguous-and-conflicting-implementations): *Explicit interface implementation 'method name' matches more than one interface member. Which interface member is actually chosen is implementation-dependent. Consider using a non-explicit implementation instead.*
- [**CS0531**](#interface-declaration-and-syntax): *'member' : interface members cannot have a definition*
- [**CS0535**](#missing-or-incomplete-implementations): *'class' does not implement interface member 'member'*
- [**CS0538**](#interface-declaration-and-syntax): *'name' in explicit interface declaration is not an interface*
- [**CS0539**](#member-matching-and-resolution): *'member' in explicit interface declaration is not a member of interface*
- [**CS0540**](#member-matching-and-resolution): *'interface member' : containing type does not implement interface 'interface'*
- [**CS0541**](#interface-declaration-and-syntax): *'declaration' : explicit interface declaration can only be declared in a class or struct*
- [**CS0550**](#missing-or-incomplete-implementations): *'accessor' adds an accessor not found in interface member 'property'*
- [**CS0551**](#missing-or-incomplete-implementations): *Explicit interface implementation 'implementation' is missing accessor 'accessor'*
- [**CS0630**](#special-implementation-restrictions): *'method' cannot implement interface member 'member' in type 'type' because it has an __arglist parameter*
- [**CS0686**](#accessor-implementation-and-conflicts): *Accessor 'accessor' cannot implement interface member 'member' for type 'type'. Use an explicit interface implementation.*
- [**CS0736**](#method-visibility-and-modifiers): *'type name' does not implement interface member 'member name'. 'method name' cannot implement an interface member because it is static.*
- [**CS0737**](#method-visibility-and-modifiers): *'type name' does not implement interface member 'member name'. 'method name' cannot implement an interface member because it is not public.*
- [**CS0738**](#return-types-and-signatures): *'type name' does not implement interface member 'member name'. 'method name' cannot implement 'interface member' because it does not have the matching return type of 'type name'.*
- [**CS8705**](#ambiguous-and-conflicting-implementations): *Interface member 'member' does not have a most specific implementation. Neither 'implementation1', nor 'implementation2' are most specific.*
- [**CS8854**](#return-types-and-signatures): *'type' does not implement interface member 'member'. 'implementation' cannot implement 'member' because it does not have the matching 'init' setter of 'property'.*
- [**CS9333**](#return-types-and-signatures): *Parameter type must match implemented member declaration.*
- [**CS9334**](#return-types-and-signatures): *Return type must match implemented member declaration.*

## Interface declaration and syntax

The following errors relate to proper syntax and structure when declaring explicit interface implementations:

- **CS0071**: *An explicit interface implementation of an event must use event accessor syntax*
- **CS0106**: *The modifier 'modifier' is not valid for this item*
- **CS0531**: *'member' : interface members cannot have a definition*
- **CS0538**: *'name' in explicit interface declaration is not an interface*
- **CS0541**: *'declaration' : explicit interface declaration can only be declared in a class or struct*

When explicitly implementing an [interface](../../fundamentals/types/interfaces.md) member, you must follow specific syntax rules. Understanding these rules helps avoid common declaration errors.

For events (**CS0071**), you must manually provide `add` and `remove` event accessors when explicitly implementing an interface event. The compiler doesn't automatically generate these accessors for explicit implementations. For more information, see [How to implement interface events](../../programming-guide/events/how-to-implement-interface-events.md).

Certain modifiers are not valid for explicit interface implementations (**CS0106**). The `public` keyword is redundant and not allowed because explicit interface implementations are implicitly public when accessed through the interface type. The `abstract` keyword is also not allowed because explicit interface implementations cannot be overridden.

Prior to C# 8.0, interface members could not contain method bodies (**CS0531**). Starting with C# 8.0, interfaces can include [default implementations](../../whats-new/csharp-8.md#default-interface-methods) for members, allowing you to provide concrete implementations in the interface itself.

The type specified in an explicit interface declaration must be an actual interface (**CS0538**). Attempting to use a class or other non-interface type in an explicit interface implementation syntax results in this error.

Explicit interface declarations can only appear in classes or structs (**CS0541**). They cannot be declared at the namespace level or in other contexts. The implementing type must be a class or struct that declares the interface in its base list.

## Missing or incomplete implementations

The following errors occur when a class fails to fully implement an interface or implements members that don't match the interface contract:

- **CS0535**: *'class' does not implement interface member 'member'*
- **CS0550**: *'accessor' adds an accessor not found in interface member 'property'*
- **CS0551**: *Explicit interface implementation 'implementation' is missing accessor 'accessor'*

When a class or struct implements an [interface](../../fundamentals/types/interfaces.md), it must provide implementations for all members declared in that interface. If any interface member is missing an implementation, the type must be declared as `abstract`. A class must implement all members of interfaces from which it derives unless it's marked abstract.

For property implementations, the accessors must match exactly what the interface defines. Adding an accessor that doesn't exist in the interface declaration causes an error. For example, if an interface property only declares a `get` accessor, the implementing property cannot add a `set` accessor. The implementation can only include accessors that are explicitly declared in the interface.

Conversely, omitting an accessor that the interface requires also causes an error. If an interface property declares both `get` and `set` accessors, the explicit interface implementation must provide both. Each accessor declared in the interface must have a corresponding accessor in the implementation with matching signatures.

The following example shows both missing implementation (**CS0535**) and correct implementation:

```csharp
// CS0535.cs
public interface A
{
   void F();
}

public class B : A {}   // CS0535 A::F is not implemented

// OK
public class C : A {
   public void F() {}
   public static void Main() {}
}
```

The following example demonstrates adding an extra accessor (**CS0550**):

```csharp
// CS0550.cs
namespace x
{
   interface ii
   {
      int i
      {
         get;
         // add the following accessor to resolve this CS0550
         // set;
      }
   }

   public class a : ii
   {
      int ii.i
      {
         get
         {
            return 0;
         }
         set {}   // CS0550  no set in interface
      }

      public static void Main() {}
   }
}
```

The following example demonstrates missing an accessor (**CS0551**):

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

For more information, see [Using Properties](../../programming-guide/classes-and-structs/using-properties.md) and [Interfaces](../../fundamentals/types/interfaces.md).

## Accessor implementation and conflicts

The following errors occur when implementing interface properties or events with accessor methods that have visibility issues or naming conflicts:

- **CS0277**: *'class' does not implement interface member 'accessor'. 'class accessor' is not public*
- **CS0470**: *Method 'method' cannot implement interface accessor 'accessor' for type 'type'. Use an explicit interface implementation.*
- **CS0686**: *Accessor 'accessor' cannot implement interface member 'member' for type 'type'. Use an explicit interface implementation.*

When implementing interface properties, accessors must have public accessibility. Property accessor implementations in a class that don't have public accessibility cause **CS0277**. All interface members are `public`, so any implementing accessor must also be public.

The **CS0470** error occurs when you try to use a method with an accessor-like name (such as `get_PropertyName`) to implement an interface property. You must use proper property syntax with explicit interface implementation instead.

The **CS0686** error can occur when implementing an interface that contains method names which conflict with the auto-generated methods associated with a property or event. The get/set methods for properties are generated as `get_Property` and `set_Property`, and the add/remove methods for events are generated as `add_Event` and `remove_Event`. If an interface contains either of these methods, a conflict occurs. To avoid this error, implement the methods using an explicit interface implementation.

The following example demonstrates **CS0277** with a non-public accessor:

```csharp
// CS0277.cs
public interface MyInterface
{
    int Property
    {
        get;
        set;
    }
}

public class MyClass : MyInterface   // CS0277
{
    public int Property
    {
        get { return 0; }
        // Try the following accessor instead:
        //set { }
        protected set { }
    }
}
```

The following example demonstrates **CS0470** with improper accessor implementation:

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

The following example demonstrates **CS0686** with property name conflicts:

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

This error can also occur when declaring events. The event construct automatically generates the `add_event` and `remove_event` methods, which could conflict with the methods of the same name in an interface:

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

For more information, see [Properties](../../programming-guide/classes-and-structs/properties.md) and [Events](../../programming-guide/events/index.md).

## Member matching and resolution

The following errors occur when attempting to implement interface members that don't exist in the interface or when the containing type doesn't declare the interface:

- **CS0539**: *'member' in explicit interface declaration is not a member of interface*
- **CS0540**: *'interface member' : containing type does not implement interface 'interface'*

When you explicitly implement an interface member, the member you're implementing must actually exist in the interface. Attempting to implement a member that isn't declared in the interface causes **CS0539**. Verify that the member name and signature match exactly what's declared in the interface, or remove the incorrect implementation.

The **CS0540** error occurs when you try to explicitly implement an interface member in a type that doesn't declare that interface in its base list. To resolve this error, either add the interface to the class's base list, or remove the explicit interface implementation.

The following example demonstrates **CS0539** where a method name doesn't match:

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
      void I.x()   // CS0539 - 'x' is not in interface I
      {
      }

      public static int Main()
      {
         return 0;
      }
   }
}
```

The following examples demonstrate **CS0540** where the type doesn't implement the interface:

```csharp
// CS0540.cs
interface I
{
   void m();
}

public class Clx
{
   void I.m() {}   // CS0540 - Clx doesn't implement I
}

// OK
public class Cly : I
{
   void I.m() {}
   public static void Main() {}
}
```

```csharp
// CS0540_b.cs
using System;
class C {
   void IDisposable.Dispose() {}   // CS0540 - C doesn't implement IDisposable
}

class D : IDisposable {
   void IDisposable.Dispose() {}
   public void Dispose() {}

   static void Main() {
      using (D d = new D()) {}
   }
}
```

For more information, see [Interfaces](../../fundamentals/types/interfaces.md) and [Explicit Interface Implementation](../../programming-guide/interfaces/explicit-interface-implementation.md).

## Generic type constraints

The following errors occur when implementing generic interface methods with type parameter constraints:

- **CS0425**: *The constraints for type parameter 'type parameter' of method 'method' must match the constraints for type parameter 'type parameter' of interface method 'method'. Consider using an explicit interface implementation instead.*
- **CS0460**: *Constraints for override and explicit interface implementation methods are inherited from the base method, so they cannot be specified directly*

When implementing generic interface methods or overriding virtual generic methods, the type parameter constraints must match those defined in the interface or base method. The **CS0425** error occurs when a method implementation has different constraints than the interface method. To avoid this error, ensure the `where` clause is identical in both declarations, or use explicit interface implementation.

The constraints don't have to be a literal match, as long as the set of constraints has the same meaning. For example, equivalent constraints like `where T : J<S>, J<int>` and `where X : J<int>` (when S is int) are acceptable.

When a generic method that is part of a derived class overrides a method in the base class, you can't specify constraints on the overridden method (**CS0460**). The override method in the derived class inherits its constraints from the method in the base class.

However, there are exceptions to this rule:

- Starting with C# 9, you can apply the `default` constraint to `override` and explicit interface implementation methods to resolve ambiguities with nullable reference types.
- Starting with C# 8, you can explicitly specify `where T : class` and `where T : struct` constraints on `override` and explicit interface implementation methods to allow annotations for type parameters constrained to reference types.

The following example demonstrates **CS0425** with mismatched constraints:

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

The following example shows equivalent constraints that are acceptable:

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

The following example demonstrates **CS0460** when attempting to redeclare inherited constraints:

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

For more information, see [Constraints on type parameters](../../programming-guide/generics/constraints-on-type-parameters.md) and [Interfaces](../../fundamentals/types/interfaces.md).

## Method visibility and modifiers

The following errors occur when implementing interface methods with incorrect accessibility or modifiers:

- **CS0736**: *'type name' does not implement interface member 'member name'. 'method name' cannot implement an interface member because it is static.*
- **CS0737**: *'type name' does not implement interface member 'member name'. 'method name' cannot implement an interface member because it is not public.*

Methods that implement interface members must have public accessibility and cannot be static. The **CS0736** error is generated when a static method is either implicitly or explicitly declared as an implementation of an interface member. Interface members are instance members by design, so static methods cannot fulfill the interface contract.

The **CS0737** error occurs when a method that implements an interface member doesn't have public accessibility. All interface members are `public`, so the implementing method must also be public.

To correct **CS0736**, remove the `static` modifier from the method declaration, change the name of the interface method, or redefine the containing type so that it doesn't inherit from the interface.

To correct **CS0737**, add the `public` access modifier to the method.

The following example demonstrates **CS0736** with a static method:

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

The following example demonstrates **CS0737** with a non-public method:

```csharp
// cs0737.cs
interface ITest
{
    // Default access of private with no modifier.
    int Return42();
    // Try the following line instead.
    // public int Return42();
}

struct Struct1 : ITest // CS0737
{
    int Return42() { return (42); }
}

public class Test
{
    public static int Main(string[] args)
    {
        Struct1 s1 = new Struct1();

        return (1);
    }

}
```

For more information, see [Interfaces](../../fundamentals/types/interfaces.md) and [Access Modifiers](../../programming-guide/classes-and-structs/access-modifiers.md).

## Ambiguous and conflicting implementations

The following errors occur when the compiler cannot determine which interface implementation to use:

- **CS0473**: *Explicit interface implementation 'method name' matches more than one interface member. Which interface member is actually chosen is implementation-dependent. Consider using a non-explicit implementation instead.*
- **CS8705**: *Interface member 'member' does not have a most specific implementation. Neither 'implementation1', nor 'implementation2' are most specific.*

The **CS0473** error occurs when a generic method might acquire the same signature as a non-generic method. In some cases, there's no way in the common language infrastructure (CLI) metadata system to unambiguously state which method binds to which slot. It's up to the CLI to make that determination.

To correct this error, eliminate the explicit implementation and implement both of the interface methods in the implicit implementation.

The **CS8705** error occurs when multiple interface implementations provide a default implementation for the same member, and the compiler cannot determine which one should be used. This typically happens with diamond inheritance patterns in interfaces with default implementations.

To resolve **CS8705**, provide an explicit implementation in the implementing class or struct to resolve the ambiguity, or restructure the interface hierarchy to avoid the conflict.

The following example demonstrates **CS0473**:

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

For more information, see [Interfaces](../../fundamentals/types/interfaces.md) and [Default Interface Methods](../../whats-new/csharp-8.md#default-interface-methods).

## Return types and signatures

The following errors occur when the implementing method's signature doesn't match the interface member declaration:

- **CS0738**: *'type name' does not implement interface member 'member name'. 'method name' cannot implement 'interface member' because it does not have the matching return type of 'type name'.*
- **CS8854**: *'type' does not implement interface member 'member'. 'implementation' cannot implement 'member' because it does not have the matching 'init' setter of 'property'.*
- **CS9333**: *Parameter type must match implemented member declaration.*
- **CS9334**: *Return type must match implemented member declaration.*

When implementing interface members, the signature must match exactly. The return type of an implementing method must match the return type of the interface member (**CS0738**). Similarly, parameter types (**CS9333**) and return types (**CS9334**) must match the interface declaration exactly.

The **CS8854** error occurs when an interface property defines an `init` accessor, but the implementing property doesn't provide a matching `init` accessor. The `init` keyword allows property initialization during object construction but prevents modification afterward. To resolve this error, add an `init` accessor to the implementing property to match the interface declaration.

To correct **CS0738**, change the return type of the method to match that of the interface member. To correct **CS9333** and **CS9334**, ensure the parameter types and return types match the interface member declaration exactly.

The following example demonstrates **CS0738** with mismatched return types:

```csharp
using System;

interface ITest
{
    int TestMethod();
}
public class Test: ITest
{
    public void TestMethod() { } // CS0738
    // Try the following line instead.
    // public int TestMethod();
}
```

The following example demonstrates **CS8854** with missing `init` accessor:

```csharp
interface IExample
{
    int Value { get; init; }
}

class Example : IExample
{
    public int Value { get; init; } // Must have init accessor
}
```

For more information, see [Interfaces](../../fundamentals/types/interfaces.md), [Properties](../../programming-guide/classes-and-structs/properties.md), and [Init-only setters](../../whats-new/csharp-9.md#init-only-setters).

## Special implementation restrictions

The following error occurs when using special parameter types that aren't compatible with interface implementation:

- **CS0630**: *'method' cannot implement interface member 'member' in type 'type' because it has an __arglist parameter*

Methods that use `__arglist` (variadic parameters) cannot implement interface members. The `__arglist` keyword allows a method to accept a variable number of arguments in an unmanaged way, but this feature is not compatible with interface implementation. This is a limitation of how interface contracts work—they require predictable, type-safe signatures.

To resolve this error, remove the `__arglist` parameter from the implementing method or use a different approach such as using `params` arrays for variable-length argument lists, which are compatible with interface implementation.

For more information, see [Interfaces](../../fundamentals/types/interfaces.md) and [params keyword](../keywords/method-parameters.md#params-modifier).










































