---
title: Errors and warnings related to `params` arrays
description: This article helps you diagnose and correct compiler errors and warnings when you use the `params` modifier on method parameters.
f1_keywords:
  - "CS0225"
  - "CS0231"
  - "CS0466"
  - "CS0674"
  - "CS0758"
  - "CS1104"
  - "CS1611"
  - "CS1670"
  - "CS1751"
  - "CS9218"
  - "CS9219"
  - "CS9220"
  - "CS9221"
  - "CS9222"
  - "CS9223"
  - "CS9224"
  - "CS9225"
  - "CS9227"
  - "CS9228"
helpviewer_keywords:
  - "CS0225"
  - "CS0231"
  - "CS0466"
  - "CS0674"
  - "CS0758"
  - "CS1104"
  - "CS1611"
  - "CS1670"
  - "CS1751"
  - "CS9218"
  - "CS9219"
  - "CS9220"
  - "CS9221"
  - "CS9222"
  - "CS9223"
  - "CS9224"
  - "CS9225"
  - "CS9227"
  - "CS9228"
ms.date: 05/20/2024
---
# Errors and warnings related to the `params` modifier on method parameters

There are a few *errors* related to the `lock` statement and thread synchronization:

<!-- The text in this list generates issues for Acrolinx, because they don't use contractions.
That's by design. The text closely matches the text of the compiler error / warning for SEO purposes.
 -->
- **CS0225**: *The params parameter must be a single-dimensional array or have a valid collection type*
- **CS0231**: *A params parameter must be the last parameter in a formal parameter list.*
- **CS0466**: *'method1' should not have a params parameter since 'method2' does not*
- **CS0674**: *Do not use `System.ParamArrayAttribute` or `System.ParamArrayAttribute`/`System.Runtime.CompilerServices.ParamCollectionAttribute`. Use the `params` keyword instead.*
- **CS0758**: *Both partial method declarations must use a `params` parameter or neither may use a `params` parameter*
- **CS1104**: *A parameter array cannot be used with `this` modifier on an extension method.*
- **CS1611**: *The params parameter cannot be declared as in `ref` or `out`*
- **CS1670**: *`params` is not valid in this context*
- **CS1751**: *Cannot specify a default value for a parameter array.*
- **CS9218**: *The type arguments for method cannot be inferred from the usage because an argument with dynamic type is used and the method has a non-array params collection parameter. Try specifying the type arguments explicitly.*
- **CS9219**: *Ambiguity between expanded and normal forms of non-array params collection parameter of, the only corresponding argument has the type 'dynamic'. Consider casting the dynamic argument.*
- **CS9223**: *Creation of params collection results in an infinite chain of invocation of constructor.*
- **CS9224**: *Method cannot be less visible than the member with params collection.*
- **CS9225**: *Constructor leaves required member uninitialized.*
- **CS9227**: *Type does not contain a definition for a suitable instance `Add` method.*
- **CS9228**: *Non-array params collection type must have an applicable constructor that can be called with no arguments.*

In addition, the compiler might produce the following *warning* related to the `params` modifier on method parameters:

- **CS9220**: *One or more overloads of method having non-array params collection parameter might be applicable only in expanded form which is not supported during dynamic dispatch.*
- **CS9221**: *One or more indexer overloads having non-array params collection parameter might be applicable only in expanded form which is not supported during dynamic dispatch.*
- **CS9222**: *One or more constructor overloads having non-array params collection parameter might be applicable only in expanded form which is not supported during dynamic dispatch.*

## Compiler Error CS0225

The params parameter must be a single-dimensional array
The params parameter must have a valid collection type

When using the [params](../keywords/method-parameters.md#params-modifier) keyword, you must specify a single-dimensional array or collection of the data type. For more information, see [Methods](../../programming-guide/classes-and-structs/methods.md).

The following sample generates CS0225:

```csharp
// CS0225.cs
public class MyClass
{
    public static void TestParams(params int a)   // CS0225
    // try the following line instead
    // public static void TestParams(params int[] a)
    {
    }

    public static void Main()
    {
        TestParams(1);
    }
}
```

## Compiler Error CS0231

A params parameter must be the last parameter in a formal parameter list.

The [params](../keywords/method-parameters.md#params-modifier) parameter supports a variable number of arguments and must be after all other parameters. For more information, see [Methods](../../programming-guide/classes-and-structs/methods.md).

The following sample generates CS0231:

```csharp
// CS0231.cs
class Test
{
   public void TestMethod(params int[] p, int i) {} // CS0231
   // To resolve the error, use the following line instead:
   // public void TestMethod(int i, params int[] p) {}

   static void Main()
   {
   }
}
```

## Compiler Error CS0466

'method1' should not have a params parameter since 'method2' does not

You cannot use `params` parameter on a class member if the implemented interface doesn't use it.

The following sample generates CS0466.

```csharp
// CS0466.cs
interface I
{
   void F1(params int[] a);
   void F2(int[] a);
}

class C : I
{
   void I.F1(params int[] a) {}
   void I.F2(params int[] a) {}   // CS0466
   void I.F2(int[] a) {}   // OK

   public static void Main()
   {
      I i = (I) new C();

      i.F1(new int[] {1, 2} );
      i.F2(new int[] {1, 2} );
   }
}
```

## Compiler Error CS0674

Do not use 'System.ParamArrayAttribute'. Use the 'params' keyword instead.
Do not use 'System.ParamArrayAttribute'/'System.Runtime.CompilerServices.ParamCollectionAttribute'. Use the 'params' keyword instead.

The C# compiler does not allow for the use of <xref:System.ParamArrayAttribute?displayProperty=nameWithType>; use [params](../keywords/method-parameters.md#params-modifier) instead.

The following sample generates CS0674:

```csharp
// CS0674.cs
using System;
public class MyClass
{
 
   public static void UseParams([ParamArray] int[] list)   // CS0674
   // try the following line instead
   // public static void UseParams(params int[] list)
   {
      for ( int i = 0 ; i < list.Length ; i++ )
         Console.WriteLine(list[i]);
      Console.WriteLine();
   }

   public static void Main()
   {
      UseParams(1, 2, 3);
   }
}
```

## Compiler Error CS0758

Both partial method declarations must use a params parameter or neither may use a params parameter

If one part of a partial method specifies a `params` parameter, the other part must specify one also.

Either add the `params` modifier in one part of the method, or remove it in the other.

The following code generates CS0758:

```csharp
using System;

public partial class C
{
    partial void Part(int i, params char[] array);
    partial void Part(int i, char[] array) // CS0758
    {
    }

    public static int Main()
    {
        return 1;
    }
}
```  

## Compiler Error CS1104

A parameter array cannot be used with 'this' modifier on an extension method.

The first parameter of an extension method cannot be a params array.

Remember that the first parameter of an extension method definition specifies which type the method will "extend". It is not an input parameter. Therefore, it makes no sense to have a params array in this location. If you do have to pass in a params array, make it the second parameter.

The following example generates CS1104:

```csharp
// cs1104.cs
// Compile with: /target:library
public static class Extensions
{
    public static void Test<T>(this params T[] tArr) {} // CS1104
}
```

## Compiler Error CS1611

The params parameter cannot be declared as in ref or out

The keywords [in](../keywords/method-parameters.md#in-parameter-modifier), [ref](../keywords/ref.md) or [out](../keywords/method-parameters.md#out-parameter-modifier) cannot be used with the [params](../keywords/method-parameters.md#params-modifier) keyword.

The following sample generates CS1611:

```csharp
// CS1611.cs
public class MyClass
{
   public static void Test(params ref int[] a)   // CS1611, remove ref
   {
   }

   public static void Main()
   {
      Test(1);
   }
}
```

## Compiler Error CS1670

params is not valid in this context

A number of C# features are incompatible with variable argument lists, and do not allow the `params` keyword, including the following:

- Parameter lists of anonymous methods
- Overloaded operators

The following sample generates CS1670:

```csharp
// CS1670.cs
public class C
{
    public bool operator +(params int[] paramsList)  // CS1670
    {
        return false;
    }

    static void Main()
    {
    }
}
```

## Compiler Error CS1751

Cannot specify a default value for a parameter array.

The following sample generates CS1751:

```csharp
// CS1751.cs
void Method(params object[] values = null)
{
}
```

To fix the error:

```csharp
// Explicitly passing null
object[] values = null;
Method(values);

void Method(params object[] values)
{
    if (values == null)
    {

    }
}
```

## See also

- [Extension Methods](../../programming-guide/classes-and-structs/extension-methods.md)
- [Partial Classes and Methods](../../programming-guide/classes-and-structs/partial-classes-and-methods.md)
- [params](../keywords/method-parameters.md#params-modifier)
