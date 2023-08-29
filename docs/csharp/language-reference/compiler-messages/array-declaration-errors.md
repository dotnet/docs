---
title: Resolve errors and warnings related to array declarations and initializations
description: These compiler errors and warnings indicate errors in the syntax for declaring and initializing array variables. There are multiple valid expressions to declare an array. Combining them incorrectly leads to errors.
f1_keywords:
 - "CS0022"
 - "CS0178"
 - "CS0248"
 - "CS0251"
 - "CS0270"
 - "CS0611"
 - "CS0623"
 - "CS0650"
 - "CS0719"
 - "CS0820"
 - "CS0826"
 - "CS0846"
 - "CS1552"
 - "CS1586"
 - "CS1925"
 - "CS3007"
 - "CS3016"
helpviewer_keywords:
 - "CS0022"
 - "CS0178"
 - "CS0248"
 - "CS0251"
 - "CS0270"
 - "CS0611"
 - "CS0623"
 - "CS0650"
 - "CS0719"
 - "CS0820"
 - "CS0826"
 - "CS0846"
 - "CS1552"
 - "CS1586"
 - "CS1925"
 - "CS3007"
 - "CS3016"
ms.date: 08/29/2023
---
# Resolve errors and warnings in array declarations and initialization expressions

This article covers the following compiler errors:

<!-- The text in this list generates issues for Acrolinx, because they don't use contractions.
That's by design. The text closely matches the text of the compiler error / warning for SEO purposes.
 -->
- [**CS0022**](#compiler-error-cs0022) - *Wrong number of indices inside [], expected 'number'*
- [**CS0178**](#compiler-error-cs0178) - *Invalid rank specifier: expected '`,`' or '`]`'*
- [**CS0248**](#compiler-error-cs0248) - *Cannot create an array with a negative size*
- [**CS0270**](#compiler-error-cs0270) - *Array size cannot be specified in a variable declaration (try initializing with a '`new`' expression)*
- [**CS0611**](#compiler-error-cs0611) - *Array elements cannot be of type*
- [**CS0623**](#compiler-error-cs0623) - *Array initializers can only be used in a variable or field initializer. Try using a new expression instead.*
- [**CS0650**](#compiler-error-cs0650) - *Bad array declarator: To declare a managed array the rank specifier precedes the variable's identifier. To declare a fixed size buffer field, use the fixed keyword before the field type.*
- [**CS0719**](#compiler-error-cs0719) - *Array elements cannot be of static type*
- [**CS0820**](#compiler-error-cs0820) - *Cannot assign array initializer to an implicitly typed local*
- [**CS0826**](#compiler-error-cs0826) - *No best type found for implicitly typed array.*
- [**CS0846**](#compiler-error-cs0846) - *A nested array initializer is expected*
- [**CS1552**](#compiler-error-cs1552) - *Array type specifier, `[]`, must appear before parameter name*
- [**CS1586**](#compiler-error-cs1586) - *Array creation must have array size or array initializer*
- [**CS1925**](#compiler-error-cs1925) - *Cannot initialize object of type 'type' with a collection initializer.*

In addition, the following warnings are covered in this article:

- [**CS0251**](#compiler-warning-level-2-cs0251) - *Indexing an array with a negative index (array indices always start at zero)*
- [**CS3007**](#compiler-warning-level-1-cs3007) - *Overloaded method 'method' differing only by unnamed array types is not CLS-compliant*
- [**CS3016**](#compiler-warning-level-1-cs3016) - *Arrays as attribute arguments is not CLS-compliant*

## Compiler Error CS0022

Wrong number of indices inside [], expected 'number'

An array-access operation specified the incorrect number of dimensions within the square brackets. For more information, see [Arrays](../../programming-guide/arrays/index.md). The following sample generates CS0022:

```csharp
// CS0022.cs
public class MyClass
{
    public static void Main()
    {
        int[] a = new int[10];
        a[0] = 0;     // single-dimension array
        a[0,1] = 9;   // CS0022, the array does not have two dimensions
    }
}
```

## Compiler Error CS0178

Invalid rank specifier: expected ',' or ']'

An array initialization was ill-formed. For example, when specifying the array dimensions, you can specify the following:

- A number in brackets
- Empty brackets
- A comma enclosed in brackets

For more information, see [Arrays](../../programming-guide/arrays/index.md) and the C# specification ([C# Language Specification](~/_csharpstandard/standard/arrays.md#177-array-initializers)) section on array initializers.

The following sample generates CS0178.

```csharp
// CS0178.cs
class MyClass
{
   public static void Main()
   {
      int a = new int[5][,][][5;   // CS0178
      int[,] b = new int[3,2];   // OK

      int[][] c = new int[10][];
      c[0] = new int[5][5];   // CS0178
      c[0] = new int[2];   // OK
      c[1] = new int[2]{1,2};   // OK
   }
}
```

## Compiler Error CS0248

Cannot create an array with a negative size

An array size was specified with a negative number. For more information, see [Arrays](../../programming-guide/arrays/index.md).

The following sample generates CS0248:

```csharp
// CS0248.cs
class MyClass
{
    public static void Main()
    {
        int[] myArray = new int[-3] {1,2,3};   // CS0248, pass a nonnegative number
    }
}
```

## Compiler Error CS0270

Array size cannot be specified in a variable declaration (try initializing with a 'new' expression

This error occurs when a size is specified as part of an array declaration. To resolve, use the [new operator](../operators/new-operator.md) expression.

The following example generates CS0270:

```csharp
// CS0270.cs
// compile with: /t:module

public class Test
{
   int[10] a;   // CS0270
   // To resolve, use the following line instead:
   // int[] a = new int[10];
}
```

## Compiler Error CS0611

Array elements cannot be of type 'type'

There are some types that cannot be used as the type of an array. These types include <xref:System.TypedReference?displayProperty=fullName> and <xref:System.ArgIterator?displayProperty=fullName>.

The following sample generates CS0611 as a result of using <xref:System.TypedReference> as an array element:

```csharp
// CS0611.cs
public class a
{
   public static void Main()
   {
      System.TypedReference[] ao = new System.TypedReference [10];   // CS0611
      // try the following line instead
      // int[] ao = new int[10];
   }
}
```

## Compiler Error CS0623

Array initializers can only be used in a variable or field initializer. Try using a new expression instead.

An attempt was made to initialize an array by using an array initializer in a context where it is not allowed.

The following example produces CS0623 because the compiler interprets the {4} as embedded array initializer inside the outer array initializer:

```csharp
//cs0632.cs
using System;

class X
{
    public int[] x = { 2, 3, {4}}; //CS0623
}
```

## Compiler Error CS0650

Bad array declarator: To declare a managed array the rank specifier precedes the variable's identifier. To declare a fixed size buffer field, use the fixed keyword before the field type.

An array was declared incorrectly. In C#, unlike in C and C++, the square brackets follow the type, not the variable name. Also, realize that the syntax for a fixed size buffer differs from that of an array. The following example code generates CS0650.

```csharp
// CS0650.cs
public class MyClass
{
   public static void Main()
   {
// Generates CS0650. Incorrect array declaration syntax:
      int myarray[2];

      // Correct declaration.
      int[] myarray2;

      // Declaration and initialization in one statement
      int[] myArray3= new int[2] {1,2}

      // Access an array element.
      myarray3[0] = 0;
    }
}
```

The following example shows how to use the `fixed` keyword when you create a fixed size buffer:

```csharp
// This code must appear in an unsafe block
public struct MyArray
{
    public fixed char pathName[128];
}
```

## Compiler Error CS0719

'type': array elements cannot be of static type

An array of static type does not make sense since array elements are instances, but it is not possible to create instances of static types.

The following sample generates CS0719:

```csharp
// CS0719.cs
public static class SC
{
   public static void F()
   {
   }
}public class CMain
{
   public static void Main()
   {
      SC[] sca = new SC[10];  // CS0719
   }
}
```

## Compiler Error CS0820

Cannot assign array initializer to an implicitly typed local

An implicitly typed array is an array whose element type is inferred by the compiler. It must be initialized by using the `new`[] modifier as shown in the example code.

To correct this error

- Use the `new`[] modifier with the array initializer.
- Do not use an implicitly typed local variable.

The following code generates CS0820 and shows how to correctly initialize an implicitly typed array:

```csharp
//cs0820.cs
class G
{
    public static int Main()
    {

        var a = { 1,2,3}; //CS0820
        // Try using one of the following lines instead.
        // var b = new[] { 1, 2, 3 };
       //int[] b = {1, 2, 3};
        return -1;
    }
}
```

## Compiler Error CS0826

No best type found for implicitly typed array.

Array elements must all be the same type or implicitly convertible to the same type according to the type inference rules used by the compiler. The best type must be one of the types present in the array expression. Elements will not be converted to a new type such as `object`. For an implicitly typed array, the compiler must infer the array type based on the type of elements assigned to it.

To correct this error

- Give the array an explicit type.
- Give all array elements the same type.
- Provide explicit casts on those elements that might be causing the problem.

The following code generates CS0826 because the array elements are not all the same type, and the compiler's type inference logic does not find a single best type:

```csharp
// cs0826.cs
public class C
{
    public static int Main()
    {
        var x = new[] { 1, "str" }; // CS0826

        char c = 'c';
        short s1 = 0;
        short s2 = -0;
        short s3 = 1;
        short s4 = -1;

        var array1 = new[] { s1, s2, s3, s4, c, '1' }; // CS0826
        return 1;
    }
}
```

## Compiler Error CS0846

A nested array initializer is expected

This error occurs when something other than an array initializer is used when creating an array.

The following sample generates CS0846:

```csharp
// CS0846.cs (0,0)

namespace Test
{
    public class Program
    {
        public void Goo()
        {
            var a3 = new[,,] { { { 3, 4 } }, 3, 4 };
        }
    }
}
```

To correct this error

This example contains a 3-dimensional array.  The initializer does not represent a three-dimensional array, resulting in CS0846.  The last two statements in the top-level array initializer `, 3, 4` are not an array initializer.  Assuming the intent is to create a 3-dimensional array with 2, 1, and 2 elements per dimension, to correct this error, properly bracket the last two statements:

```csharp
        var a3 = new[, ,] { { { 3, 4 } }, { { 3, 4 } } };
```

## Compiler Error CS1552

Array type specifier, [], must appear before parameter name

The position of the array type specifier is after the variable name in the array declaration.

The following sample generates CS1552:

```csharp
// CS1552.cs
public class C
{
    public static void Main(string args[])   // CS1552
    // try the following line instead
    // public static void Main(string [] args)
    {
    }
}
```

## Compiler Error CS1586

Array creation must have array size or array initializer

An array was declared incorrectly. The following sample generates CS1586:

```csharp
// CS1586.cs
using System;
class MyClass
{
   public static void Main()
   {
      int[] a = new int[];   // CS1586
      // try the following line instead
      int[] b = new int[5];
   }
}
```

## Compiler Error CS1925

Cannot initialize object of type 'type' with a collection initializer.

Collection initializers are only allowed for collection classes that meet certain criteria. For more information, see [Object and Collection Initializers](../../programming-guide/classes-and-structs/object-and-collection-initializers.md). This error is also produced when you try to use the short form of an array initializer nested inside a collection initializer.

To correct this error initialize the object by calling its constructors and methods.

The following code generates CS1925:

```csharp
// cs1925.cs
public class Student
{
    public int[] Scores;
}

class Test
{
    static void Main(string[] args)
    {
        Student student = new Student { Scores = { 1, 2, 3 } }; // CS1925
    }
}
```

## Compiler Warning (level 1) CS3007

Overloaded method 'method' differing only by unnamed array types is not CLS-compliant

This error occurs if you have an overloaded method that takes a jagged array and the only difference between the method signatures is the element type of the array. To avoid this error, consider using a rectangular array rather than a jagged array; use an additional parameter to disambiguate the function call; rename one or more of the overloaded methods; or, if CLS Compliance is not needed, remove the <xref:System.CLSCompliantAttribute> attribute. For more information on CLS Compliance, see [Language independence and language-independent components](../../../standard/language-independence.md).

The following example generates CS3007:

```csharp
// CS3007.cs
[assembly: System.CLSCompliant(true)]
public struct S
{
    public void F(int[][] array) { }
    public void F(byte[][] array) { }  // CS3007
    // Try this instead:
    // public void F1(int[][] array) {}
    // public void F2(byte[][] array) {}
    // or
    // public void F(int[,] array) {}
    // public void F(byte[,] array) {}
}
```

## Compiler Warning (level 1) CS3016

Arrays as attribute arguments is not CLS-compliant

It is not compliant with the Common Language Specification (CLS) to pass an array to an attribute. For more information on CLS compliance, see [Language independence and language-independent components](../../../standard/language-independence.md).

The following example generates CS3016:

```csharp
// CS3016.cs

using System;

[assembly : CLSCompliant(true)]
[C(new int[] {1, 2})]   // CS3016
// try the following line instead
// [C()]
class C : Attribute
{
    public C()
    {
    }

    public C(int[] a)
    {
    }

    public static void Main ()
    {
    }
}
```

## Compiler Warning (level 2) CS0251

Indexing an array with a negative index (array indices always start at zero)

Do not use a negative number to index into an array.

The following sample generates CS0251:

```csharp
// CS0251.cs
// compile with: /W:2
class MyClass
{
   public static void Main()
   {
      int[] myarray = new int[] {1,2,3};
      try
      {
         myarray[-1]++;   // CS0251
         // try the following line instead
         // myarray[1]++;
      }
      catch (System.IndexOutOfRangeException e)
      {
         System.Console.WriteLine("{0}", e);
      }
   }
}
```
