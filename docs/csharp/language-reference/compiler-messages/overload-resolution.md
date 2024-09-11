---
title: Fix errors that involve overload resolution
description: Compiler errors and warnings that indicate a problem in your code related to overload resolution. Learn causes and fixes for these errors.
f1_keywords:
  - "CS0034"
  - "CS0035"
  - "CS0111"
  - "CS0121"
  - "CS0457"
  - "CS1007"
  - "CS0663"
  - "CS1019"
  - "CS1020"
  - "CS1062"
  - "CS1064"
  - "CS1501"
  - "CS1534"
  - "CS1535"
  - "CS1928"
  - "CS1929"
  - "CS3006"
  - "CS8315"
  - "CS9261"
  - "CS9262"
helpviewer_keywords:
  - "CS0034"
  - "CS0035"
  - "CS0111"
  - "CS0121"
  - "CS0457"
  - "CS1007"
  - "CS0663"
  - "CS1019"
  - "CS1020"
  - "CS1501"
  - "CS1534"
  - "CS1535"
  - "CS1928"
  - "CS1929"
  - "CS3006"
  - "CS8315"
  - "CS9261"
  - "CS9262"
ms.date: 09/10/2024
---
# Resolve errors and warnings that impact overload resolution.

This article covers the following compiler errors:

- [**CS0663**](#incorrect-overload-definition) - *Cannot define overloaded methods that differ only on `ref` and `out`.*
- [**CS1019**](#incorrect-overload-definition) - *Overloadable unary operator expected*
- [**CS1020**](#incorrect-overload-definition) - *Overloadable binary operator expected*
- [**CS1501**](#no-overload-found) - *No overload for method 'method' takes 'number' arguments*
- [**CS1534**](#incorrect-overload-definition) - *Overloaded binary operator 'operator' takes two parameters*
- [**CS1535**](#incorrect-overload-definition) - *Overloaded unary operator 'operator' takes one parameter*
- [**CS1928**](#no-overload-found) - *'Type' does not contain a definition for 'method' and the best extension method overload 'method' has some invalid arguments.*
- [**CS1929**](#no-overload-found) - *'TypeA' does not contain a definition for 'method' and the best extension method overload 'TypeB.method' requires a receiver of type 'TypeC'*
- [**CS8315**](#) - *Operator '{0}' is ambiguous on operands '{1}' and '{2}'*
- [**CS9261**](#overload-resolution-priority) - *Cannot use '`OverloadResolutionPriorityAttribute`' on an overriding member.*
- [**CS9262**](#overload-resolution-priority) - *Cannot use '`OverloadResolutionPriorityAttribute`' on this member.*

In addition, the following compiler warning:

- [**CS3006**](#incorrect-overload-definition) - *Overloaded method 'method' differing only in `ref` or `out`, or in array rank, is not CLS-compliant*

## Incorrect overload definition

- **CS0663** - *Cannot define overloaded methods that differ only on `ref` and `out`.*
- **CS1019** - *Overloadable unary operator expected*
- **CS1020** - *Overloadable binary operator expected*
- **CS1534** - *Overloaded binary operator 'operator' takes two parameters*
- **CS1535** - *Overloaded unary operator 'operator' takes one parameter*

In addition, the following compiler warning:

- **CS3006** - *Overloaded method 'method' differing only in `ref` or `out`, or in array rank, is not CLS-compliant*

When you create overloaded operators in your class, the signature must match the number of parameters required for that operator. You have the wrong number of parameters in the operator definition.

In addition, overload operators must use the defined operator name. The only exception is when you create a [conversion operator](../operators/user-defined-conversion-operators.md), where the operator name matches the return type of the conversion.

## No overload found

- [**CS1501**](#no-overload-found) - *No overload for method 'method' takes 'number' arguments*
- [**CS1928**](#no-overload-found) - *'Type' does not contain a definition for 'method' and the best extension method overload 'method' has some invalid arguments.*
- [**CS1929**](#no-overload-found) - *'TypeA' does not contain a definition for 'method' and the best extension method overload 'TypeB.method' requires a receiver of type 'TypeC'*

Your code calls a method where the name exists, but some arguments are incorrect, or you've used the wrong number of arguments.

> [!NOTE]
> Error `CS1928` isn't used by the latest compilers. Newer compilers use `CS1929` exclusively.

## Overload resolution priority

- **CS9261** - *Cannot use '`OverloadResolutionPriorityAttribute`' on an overriding member.*
- **CS9262** - *Cannot use '`OverloadResolutionPriorityAttribute`' on this member.*

Your code violated the rules for using the <xref:System.Runtime.CompilerServices.OverloadResolutionPriorityAttribute> to favor one overload instead of another. You can't apply the `OverloadResolutionPriorityAttribute` to the following method types:

- Non-indexer properties
- Property, indexer, or event accessors
- Conversion operators
- Lambdas
- Local functions
- Finalizers
- Static constructors

In addition, you can't apply the `OverloadResolutionPriorityAttribute` to an `override` of a `virtual` or `abstract` member. The compiler uses the value from the base type declaration.

## Compiler Error CS0111

Type 'class' already defines a member called 'member' with the same parameter types

CS0111 occurs if a class contains two member declarations with the same name and parameter types. For more information, see [Methods](../programming-guide/classes-and-structs/methods.md).

The following sample generates CS0111.

```csharp
// CS0111.cs
class A
{
   void Test() { }
   public static void Test(){}   // CS0111

   public static void Main() {}
}
```

## Compiler Error CS1007

Property accessor already defined

When you declare a [property](../programming-guide/classes-and-structs/using-properties.md), you must also declare its accessor methods. However, a property cannot have more than one `get` accessor method or more than one `set` accessor method.

The following sample generates CS1007:

```csharp
// CS1007.cs
public class clx
{
    public int MyProperty
    {
        get
        {
            return 0;
        }
        get   // CS1007, this is the second get method
        {
            return 0;
        }
    }

    public static void Main() {}
}
```

## Compiler Error CS0034

Operator 'operator' is ambiguous on operands of type 'type1' and 'type2'

An operator was used on two objects and the compiler found more than one conversion. Because conversions have to be unique, you either have to make a cast or to make one of the conversions explicit. For more information, see [User-defined conversion operators](../operators/user-defined-conversion-operators.md).

The following sample generates CS0034:

```csharp
// CS0034.cs
public class A
{
    // Allows for the conversion of A object to int.
    public static implicit operator int (A s)
    {
        return 0;
    }

    public static implicit operator string (A i)
    {
        return null;
    }
}

public class B
{
    public static implicit operator int (B s)  
    // One way to resolve this CS0034 is to make one conversion explicit.
    // public static explicit operator int (B s)
    {
        return 0;
    }

    public static implicit operator string (B i)
    {
        return null;
    }

    public static implicit operator B (string i)
    {
        return null;
    }

    public static implicit operator B (int i)
    {
        return null;
    }
}

public class C
{
    public static void Main()
    {
        A a = new A();
        B b = new B();
        b = b + a;   // CS0034
        // Another way to resolve this CS0034 is to make a cast.
        // b = b + (int)a;
    }
}
```

 In C# 1.1, a compiler bug made it possible to define a class that has implicit user-defined conversions to both `int` and `bool`, and to use a bitwise `AND` operator (`&`) on objects of that type. In C# 2.0, this bug was fixed to bring the compiler into compliance with the C# specification, and therefore the following code will now cause CS0034:

```csharp
namespace CS0034
{
    class TestClass2
    {
        public void Test()
        {
            TestClass o1 = new TestClass();
            TestClass o2 = new TestClass();
            TestClass o3 = o1 & o2; //CS0034
        }
    }

    class TestClass
    {
        public static implicit operator int(TestClass o)
        {
            return 1;
        }

        public static implicit operator TestClass(int v)
        {
            return new TestClass();
        }

        public static implicit operator bool(TestClass o)
        {
            return true;
        }
    }

}
```

## CS8315

This involves ops like:

```csharp
(default, default) == (default, default);
```

## Compiler Error CS0035

Operator 'operator' is ambiguous on an operand of type 'type'
  
The compiler has more than one available conversion and does not know which to choose before applying the operator.

The following sample generates CS0035:

```csharp
// CS0035.cs
class MyClass
{
   private int i;

   public MyClass(int i)
   {
      this.i = i;
   }

   public static implicit operator double(MyClass x)
   {
      return (double) x.i;
   }

   public static implicit operator decimal(MyClass x)
   {
      return (decimal) x.i;
   }
}

class MyClass2
{
   static void Main()
   {
      MyClass x = new MyClass(7);
      object o = - x;   // CS0035
      // try a cast:
      // object o = - (double)x;
   }
}
```

# Compiler error CS0121

The call is ambiguous between the following methods or properties: 'method1' and 'method2'

Due to implicit conversion, the compiler was not able to call one form of an overloaded method. You can resolve this error in one of the following ways:

- Specify the method parameters in such a way that implicit conversion does not take place.
- Remove all overloads for the method.
- Cast to proper type before calling the method.
- Use named arguments.

The following examples generate compiler error CS0121:

```csharp
public class Program
{
    static void f(int i, double d)
    {
    }

    static void f(double d, int i)
    {
    }

    public static void Main()
    {
        f(1, 1);   // CS0121

        // Try the following code instead:
        // f(1, 1.0);
        // or
        // f(1.0, 1);
        // or
        // f(1, (double)1);   // Cast and specify which method to call.
        // or
        // f(i: 1, 1);
        // or
        // f(d: 1, 1);

        // f(i: 1, d: 1); // This still gives CS0121
    }
}
```

Example 2:

```csharp
class Program2
{
    static int ol_invoked = 0;

    delegate int D1(int x);
    delegate T D1<T>(T x);
    delegate T D1<T, U>(U u);

    static void F(D1 d1) { ol_invoked = 1; }
    static void F<T>(D1<T> d1t) { ol_invoked = 2; }
    static void F<T, U>(D1<T, U> d1t) { ol_invoked = 3; }

    static int Test001()
    {
        F(delegate(int x) { return 1; }); // CS0121
        if (ol_invoked == 1)
            return 0;
        else
            return 1;
    }

    static int Main()
    {
        return Test001();
    }
}
```

## Compiler Error CS0457

Ambiguous user defined conversions 'Conversion method name 1' and 'Conversion method name 2' when converting from 'type name 1' to 'type name 2'

Two conversion methods are applicable, and the compiler is unable to decide which one to use.

One scenario that can cause this error is as follows:

- You want to convert class A to class B where A and B are unrelated.
- A is derived from A0, and there is a method that converts from A0 to B.
- B has a subclass B1 and there is a method that converts from A to B1.

The compiler will weight the two conversion methods equally, because the first conversion provides the best destination type, and the second conversion provides the best source type. Since the compiler will be unable to choose, this error will be generated. To resolve, write a new explicit method converting A to B.

Another scenario that causes this error is if there are two methods that convert A to B. To fix, specify which conversion to use through an explicit cast.

The following sample generates CS0457.

```csharp
// CS0457.cs
using System;
public class A { }

public class G0 {  }
public class G1<R> : G0 {  }

public class H0 {
   public static implicit operator G0(H0 h) {
      return new G0();
   }
}
public class H1<R> : H0 {
   public static implicit operator G1<R>(H1<R> h) {
      return new G1<R>();
   }
}

public class Test
{
   public static void F0(G0 g) {  }
   public static void Main()
   {
      H1<A> h1a = new H1<A>();
      F0(h1a);   // CS0457
   }
}
```
