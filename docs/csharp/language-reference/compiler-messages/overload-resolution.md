---
title: Fix errors that involve overload resolution
description: Compiler errors and warnings that indicate a problem in your code related to overload resolution. Learn causes and fixes for these errors.
f1_keywords:
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
  - "CS9261"
  - "CS9262"
helpviewer_keywords:
  - "CS0663"
  - "CS1019"
  - "CS1020"
  - "CS1501"
  - "CS1534"
  - "CS1535"
  - "CS1928"
  - "CS1929"
  - "CS3006"
  - "CS9261"
  - "CS9262"
ms.date: 09/10/2024
---
# Resolve errors and warnings that impact overload resolution.

This article covers the following compiler warnings:

- [**CS9261**](#overload-resolution-priority) - *Cannot use '`OverloadResolutionPriorityAttribute`' on an overriding member.*
- [**CS9262**](#overload-resolution-priority) - *Cannot use '`OverloadResolutionPriorityAttribute`' on this member.*

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

## Compiler Error CS0663

Cannot define overloaded methods that differ only on ref and out.

Methods that differ only on their use of [in](../keywords/method-parameters.md#in-parameter-modifier), [ref](../keywords/ref.md) and [out](../keywords/method-parameters.md#out-parameter-modifier) on a parameter are not allowed.

The following sample generates CS0663:

```csharp
// CS0663.cs
class TestClass
{
   public static void Main()
   {
   }

   public void Test(ref int i)
   {
   }

   public void Test(out int i)   // CS0663
   {
   }
}
```

## Compiler Error CS1019

Overloadable unary operator expected

Something that looks like an overloaded unary operator has been declared, but the operator is missing or is in the wrong location in the signature.

A *unary operator* is an operator that operates on a single operand. For example, `++` is a unary operator. You can overload some unary operators by using the `operator` keyword and specifying a single parameter of the type that the operator operates on. For example, if you want to overload the operator `++` for a user-defined class `Temperature` so that you can write `Temperature++`, you can define it in this way:

```csharp
public static  Temperature operator ++ (Temperature temp)
{
    temp.Degrees++;
    return temp;
}
```

When you receive this error, you have declared something that looks like an overloaded unary operator, except that the operator itself is missing or is in the wrong location in the signature. If you remove the `++` from the signature in the previous example, you will generate CS1019.

The following code generates CS1019:

```csharp
// CS1019.cs  
public class ii
{
   int i
   {
      get
      {
         return 0;
      }
   }
}

public class a
{
    public int i;
// Generates CS1019: "ii" is not a unary operator.
   public static a operator ii(a aa)

   // Use the following line instead:
   //public static a operator ++(a aa)
   {
      aa.i++;
      return aa;
   }

   public static void Main()
   {
   }
}
```

## Compiler Error CS1020

Overloadable binary operator expected

An attempt was made to define an operator overload, but the operator was not an overloadable binary operator, which takes two parameters. For the list of overloadable operators, see the [Overloadable operators](../language-reference/operators/operator-overloading.md#overloadable-operators) section of the [Operator overloading](../language-reference/operators/operator-overloading.md) article.

The following sample generates CS1020:

```csharp
// CS1020.cs
public class iii
{
   public static int operator ++(iii aa, int bb)   // CS1020, change ++ to +
   {
      return 0;
   }

   public static void Main()
   {
   }
}
```

## Compiler Error CS1501

No overload for method 'method' takes 'number' arguments

A call was made to a class method, but no definition of the method takes the specified number of arguments.

The following sample generates CS1501.

```csharp
using System;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            ExampleClass ec = new ExampleClass();
            ec.ExampleMethod();
            ec.ExampleMethod(10);
            // The following line causes compiler error CS1501 because
            // ExampleClass does not contain an ExampleMethod that takes
            // two arguments.
            ec.ExampleMethod(10, 20);
        }
    }

    // ExampleClass contains two overloads for ExampleMethod. One of them
    // has no parameters and one has a single parameter.
    class ExampleClass
    {
        public void ExampleMethod()
        {
            Console.WriteLine("Zero parameters");
        }

        public void ExampleMethod(int i)
        {
            Console.WriteLine("One integer parameter.");
        }

        //// To fix the error, you must add a method that takes two arguments.
        //public void ExampleMethod (int i, int j)
        //{
        //    Console.WriteLine("Two integer parameters.");
        //}
    }
}
```

## Compiler Error CS1534

Overloaded binary operator 'operator' takes two parameters

The definition of a binary [operator](../operators/operator-overloading.md) must take two parameters.

The following sample generates CS1534:

```csharp
// CS1534.cs
class MyClass
{
   public static MyClass operator - (MyClass MC1, MyClass MC2, MyClass MC3)   // CS1534
   // try the following line instead
   // public static MyClass operator - (MyClass MC1, MyClass MC2)
   {
      return new MyClass();
   }

   public static int Main()
   {
      return 1;
   }
}
```

## Compiler Error CS1535

Overloaded unary operator 'operator' takes one parameter

The definition of a unary [operator](../operators/operator-overloading.md) must take one parameter.

The following sample generates CS1535:

```csharp
// CS1535.cs
class MyClass
{
    // uncomment the method parameter to resolve CS1535
    public static MyClass operator ++ (/*MyClass MC1*/)   // CS1535
    {
       return new MyClass();
    }

    public static int Main()
    {
        return 1;
    }
}
```

## Compiler Error CS1928

Not used in Roslyn

'Type' does not contain a definition for 'method' and the best extension method overload 'method' has some invalid arguments.

This error is produced when the compiler cannot find a class member with the name of the method you have called. It can find an extension method with that name, but not with a signature that matches the types you passed in with your method call.

To correct this error, pass in types that match an existing extension method or class method.  

The following code generates CS1928:

```csharp
// cs1928.cs
class Test
{
    static void Main()
    {
        Test t = new Test();
        t.M("hi"); // CS1928
    }
}
static class Ext
{
    public static void M(this Test t, int i)
    {
    }
}
```

This error is often accompanied by CS1503: Argument 'n': cannot convert from 'typeA' to 'typeB'.

## Compiler Error CS1929

'typeB' does not contain a definition for 'method' and the best extension method overload 'typeC.method' requires a receiver of type 'typeA'

This error is generated when you try to invoke an extension method from a class that it does not extend. In the example shown here, the extension method is defined for the derived class `D`, but not for the base class `B`.

To correct this error, create a new extension method for the type where you have to invoke it, or move the call into an object of the type that the existing method extends.

The following code generates CS1929:

```csharp
static class Extension
{
    public static void ExtensionMethod(this D d)
    {
    }
}

class D : B
{
}

class B
{
    static void Main()
    {
        B b = new B();
        b.ExtensionMethod(); // CS1929
    }
}
```

The following code solves the CS1929 as described in 1. - by creating a new extension method for proper type 'B':

```csharp
static class Extension
{
    public static void ExtensionMethod(this D d)
    {
    }

    public static void NewExtensionMethod(this B b)
    {
    }
}

class D : B
{
}

class B
{
    static void Main()
    {
        B b = new B();
        b.NewExtensionMethod();
    }
}
```

The following code solves the CS1929 as described in 2. - moving the call into an object of the proper type 'D':

```csharp
static class Extension
{
    public static void ExtensionMethod(this D d)
    {
    }
}

class D : B
{
}

class B
{
    static void Main()
    {
        D d = new D();
        d.ExtensionMethod();
    }
}
```

## Compiler Warning (level 1) CS3006

Overloaded method 'method' differing only in ref or out, or in array rank, is not CLS-compliant

A method cannot be overloaded based on the [ref](../keywords/ref.md) or [out](../keywords/method-parameters.md#out-parameter-modifier) parameter and still comply with the Common Language Specification (CLS). For more information on CLS Compliance, see [Language independence and language-independent components](../../../standard/language-independence.md).

The following example generates CS3006. To resolve this warning, comment out the assembly-level attribute or remove one of the method definitions.

```csharp
// CS3006.cs

using System;

[assembly: CLSCompliant(true)]
public class MyClass
{
    public void f(int i)
    {
    }

    public void f(ref int i)   // CS3006
    {
    }

    public static void Main()
    {
    }
}
```
