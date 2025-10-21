---
title: Resolve errors and warnings related to using unsafe code
description: These compiler errors and warnings indicate errors when you work with `unsafe` code. Unsafe code requires special keywords before it's enabled. Unsafe code allows constructs that can introduce memory based errors. These warnings and errors explain common misues.
f1_keywords:
 - "CS0193"
 - "CS0196"
 - "CS0208"
 - "CS0209"
 - "CS0210"
 - "CS0211"
 - "CS0212"
 - "CS0213"
 - "CS0214"
 - "CS0227"
 - "CS0233"
 - "CS0242"
 - "CS0244"
 - "CS0254"
 - "CS0459"
 - "CS0821"
 - "CS1641"
 - "CS1642"
 - "CS1656"
 - "CS1663"
 - "CS1665"
 - "CS1666"
 - "CS1708"
 - "CS1716"
 - "CS1919"
 - "CS8812"
 - "CS9123" # The '&' operator should not be used on parameters or local variables in async methods. (new unsafe file)
helpviewer_keywords:
 - "CS0193"
 - "CS0196"
 - "CS0208"
 - "CS0209"
 - "CS0210"
 - "CS0211"
 - "CS0212"
 - "CS0213"
 - "CS0214"
 - "CS0227"
 - "CS0233"
 - "CS0242"
 - "CS0244"
 - "CS0254"
 - "CS0459"
 - "CS0821"
 - "CS1641"
 - "CS1642"
 - "CS1656"
 - "CS1663"
 - "CS1665"
 - "CS1666"
 - "CS1708"
 - "CS1716"
 - "CS1919"
 - "CS8812"
 - "CS9123" # The '&' operator should not be used on parameters or local variables in async methods. (new unsafe file)
ms.date: 10/21/2025
---
# Resolve errors and warnings in unsafe code constructs

This article covers the following compiler errors:

<!-- The text in this list generates issues for Acrolinx, because they don't use contractions.
That's by design. The text closely matches the text of the compiler error / warning for SEO purposes.
 -->
 - [**CS0193**](#cs0193): *The \* or -> operator must be applied to a data pointer*
 - [**CS0196**](#cs0196): *A pointer must be indexed by only one value*
 - [**CS0208**](#cs0208): *Cannot take the address of, get the size of, or declare a pointer to a managed type ('type')*
 - [**CS0209**](#cs0209): *The type of local declared in a fixed statement must be a pointer type*
 - [**CS0210**](#cs0210): *You must provide an initializer in a fixed or `using` statement declaration*
 - [**CS0211**](#cs0211): *Cannot take the address of the given expression*
 - [**CS0212**](#cs0212): *You can only take the address of an unfixed expression inside of a fixed statement initializer*
 - [**CS0213**](#cs0213): *You cannot use the fixed statement to take the address of an already fixed expression*
 - [**CS0214**](#cs0214): *Pointers and fixed size buffers may only be used in an unsafe context*
 - [**CS0227**](#cs0227): *Unsafe code may only appear if compiling with /unsafe*
 - [**CS0233**](#cs0233): *'identifier' does not have a predefined size, therefore sizeof can only be used in an unsafe context*
 - [**CS0242**](#cs0242): *The operation in question is undefined on void pointers*
 - [**CS0244**](#cs0244): *Neither 'is' nor 'as' is valid on pointer types*
 - [**CS0254**](#cs0254): *The right hand side of a fixed statement assignment may not be a cast expression*
 - [**CS0459**](#cs0459): *Cannot take the address of a read-only local variable*
 - [**CS0821**](#cs0821): *Implicitly typed locals cannot be fixed*
 - [**CS1641**](#cs1641): *A fixed size buffer field must have the array size specifier after the field name*
 - [**CS1642**](#cs1642): *Fixed size buffer fields may only be members of structs.*
 - [**CS1656**](#cs1656): *Cannot assign to 'variable' because it is a 'read-only variable type'*
 - [**CS1663**](#cs1663): *Fixed size buffer type must be one of the following: bool, byte, short, int, long, char, sbyte, ushort, uint, ulong, float or double*
 - [**CS1665**](#cs1665): *Fixed size buffers must have a length greater than zero*
 - [**CS1666**](#cs1666): *You cannot use fixed size buffers contained in unfixed expressions. Try using the fixed statement.*
 - [**CS1708**](#cs1708): *Fixed size buffers can only be accessed through locals or fields*
 - [**CS1716**](#cs1716): *Do not use 'System.Runtime.CompilerServices.FixedBuffer' attribute. Use the 'fixed' field modifier instead.*
 - [**CS1919**](#cs1919): *Unsafe type 'type name' cannot be used in object creation.*
 - [**CS8812**](#cs8812): *Cannot convert `&Method` group to non-function pointer type.*
 - **CS9123**: *The '`&`' operator should not be used on parameters or local variables in async methods.

In addition, the following warnings are covered in this article:

## CS0193

The \* or -> operator must be applied to a data pointer

The \* or -> operator was used with a nonpointer type or with a function pointer. Function pointers cannot be dereferenced in C#. For more information, see [Pointer types](../unsafe-code.md#pointer-types) and [Function pointers](../unsafe-code.md#function-pointers).

The following sample generates CS0193:

```csharp
// CS0193.cs
using System;

public struct Age
{
   public int AgeYears;
   public int AgeMonths;
   public int AgeDays;
}

public class MyClass
{
   public static void SetAge(ref Age anAge, int years, int months, int days)
   {
      anAge->Months = 3;   // CS0193, anAge is not a pointer
      // try the following line instead
      // anAge.AgeMonths = 3;
   }

   public static void Main()
   {
      Age MyAge = new Age();
      Console.WriteLine(MyAge.AgeMonths);
      SetAge(ref MyAge, 22, 4, 15);
      Console.WriteLine(MyAge.AgeMonths);
   }
}
```

The following example shows that function pointers cannot be dereferenced in C#, unlike in C/C++:

```csharp
unsafe class FunctionPointerExample
{
    public static void Log() { /* ... */ }

    public static unsafe void Example()
    {
        delegate*<void> fp = &Log;   // pointer to managed function Log()
        fp();                        // OK; call Log() via function pointer
        (*fp)();                     // Error; CS0193, function pointers cannot be dereferenced
    }
}
```

## CS0196

A pointer must be indexed by only one value

A pointer cannot have multiple indices. For more information, see [Pointer types](../unsafe-code.md#pointer-types)

The following sample generates CS0196:

```csharp
// CS0196.cs
public class MyClass
{
   public static void Main ()
   {
      int *i = null;
      int j = 0;
      j = i[1,2];   // CS0196
      // try the following line instead
      // j = i[1];
   }
}
```

## CS0208

Cannot take the address of, get the size of, or declare a pointer to a managed type ('type')

Even when used with the [unsafe](../keywords/unsafe.md) keyword, taking the address of a managed object, getting the size of a managed object, or declaring a pointer to a managed type is not allowed. A managed type is:

- any reference type

- any struct that contains a reference type as a field or property

For more information, see [Unmanaged types](../builtin-types/unmanaged-types.md).

The following sample generates CS0208:

```csharp
// CS0208.cs
// compile with: /unsafe

class myClass
{
    public int a = 98;
}

struct myProblemStruct
{
    string s;
    float f;
}

struct myGoodStruct
{
    int i;
    float f;
}

public class MyClass
{
    unsafe public static void Main()
    {
        // myClass is a class, a managed type.
        myClass s = new myClass();
        myClass* s2 = &s;    // CS0208

        // The struct contains a string, a managed type.
        int i = sizeof(myProblemStruct); //CS0208

        // The struct contains only value types.
        i = sizeof(myGoodStruct); //OK

    }
}
```

## CS0209

The type of local declared in a fixed statement must be a pointer type

The variable that you declare in a [fixed statement](../statements/fixed.md) must be a pointer. For more information, see [Unsafe Code and Pointers](../unsafe-code.md).

The following sample generates CS0209:

```csharp
// CS0209.cs
// compile with: /unsafe

class Point
{
   public int x, y;
}

public class MyClass
{
   unsafe public static void Main()
   {
      Point pt = new Point();

      fixed (int i)    // CS0209
      {
      }
      // try the following lines instead
      /*
      fixed (int* p = &pt.x)
      {
      }
      fixed (int* q = &pt.y)
      {
      }
      */
   }
}
```

## CS0210

You must provide an initializer in a fixed or `using` statement declaration

You must declare and initialize the variable in a [fixed statement](../statements/fixed.md). For more information, see [Unsafe Code and Pointers](../unsafe-code.md).

The following sample generates CS0210:

```csharp
// CS0210a.cs
// compile with: /unsafe

class Point
{
   public int x, y;
}

public class MyClass
{
   unsafe public static void Main()
   {
      Point pt = new Point();

      fixed (int i)    // CS0210
      {
      }
      // try the following lines instead
      /*
      fixed (int* p = &pt.x)
      {
      }
      fixed (int* q = &pt.y)
      {
      }
      */
   }
}
```

The following sample also generates CS0210 because the [`using` statement](../statements/using.md) has no initializer.

```csharp
// CS0210b.cs

using System.IO;
class Test
{
   static void Main()
   {
      using (StreamWriter w) // CS0210
      // Try this line instead:
      // using (StreamWriter w = new StreamWriter("TestFile.txt"))
      {
         w.WriteLine("Hello there");
      }
   }
}
```

## CS0211

Cannot take the address of the given expression

You can take the address of fields, local variables, and indirection of pointers, but you cannot take, for example, the address of the sum of two local variables. For more information, see [Unsafe Code and Pointers](../unsafe-code.md).

The following sample generates CS0211:

```csharp
// CS0211.cs
// compile with: /unsafe

public class MyClass
{
   unsafe public void M()
   {
      int a = 0, b = 0;
      int *i = &(a + b);   // CS0211, the addition of two local variables
      // try the following line instead
      // int *i = &a;
   }

   public static void Main()
   {
   }
}
```

## CS0212

You can only take the address of an unfixed expression inside of a fixed statement initializer

For more information, see [Unsafe Code and Pointers](../unsafe-code.md).

The following sample shows how to take the address of an unfixed expression. The following sample generates CS0212.

```csharp
// CS0212a.cs
// compile with: /unsafe /target:library

public class A {
   public int iField = 5;

   unsafe public void M() {
      A a = new A();
      int* ptr = &a.iField;   // CS0212
   }

   // OK
   unsafe public void M2() {  
      A a = new A();
      fixed (int* ptr = &a.iField) {}
   }
}
```

The following sample also generates CS0212 and shows how to resolve the error:

```csharp
// CS0212b.cs
// compile with: /unsafe /target:library
using System;

public class MyClass
{
   unsafe public void M()
   {
      // Null-terminated ASCII characters in an sbyte array
      sbyte[] sbArr1 = new sbyte[] { 0x41, 0x42, 0x43, 0x00 };
      sbyte* pAsciiUpper = &sbArr1[0];   // CS0212
      // To resolve this error, delete the previous line and
      // uncomment the following code:
      // fixed (sbyte* pAsciiUpper = sbArr1)
      // {
      //    String szAsciiUpper = new String(pAsciiUpper);
      // }
   }
}
```

## CS0213

You cannot use the fixed statement to take the address of an already fixed expression

A local variable in an [unsafe](../keywords/unsafe.md) method or a parameter is already fixed (on the stack), so you cannot take the address of either of these two variables in a [fixed](../statements/fixed.md) expression. For more information, see [Unsafe Code and Pointers](../unsafe-code.md).

The following sample generates CS0213.

```csharp
// CS0213.cs
// compile with: /unsafe
public class MyClass
{
   unsafe public static void Main()
   {
      int i = 45;
      fixed (int *j = &i) { }  // CS0213
      // try the following line instead
      // int* j = &i;

      int[] a = new int[] {1,2,3};
      fixed (int *b = a)
      {
         fixed (int *c = b) { }  // CS0213
         // try the following line instead
         // int *c = b;
      }
   }
}
```

## CS0214

Pointers and fixed size buffers may only be used in an unsafe context

Pointers can only be used with the [unsafe](../keywords/unsafe.md) keyword. For more information, see [Unsafe Code and Pointers](../unsafe-code.md).

The following sample generates CS0214:

```csharp
// CS0214.cs
// compile with: /target:library /unsafe
public struct S
{
   public int a;
}

public class MyClass
{
   public static void Test()
   {
      S s = new S();
      S * s2 = &s;    // CS0214
      s2->a = 3;      // CS0214
      s.a = 0;
   }

   // OK
   unsafe public static void Test2()
   {
      S s = new S();  
      S * s2 = &s;
      s2->a = 3;
      s.a = 0;
   }
}
```

## CS0227

Unsafe code may only appear if compiling with /unsafe

If source code contains the [unsafe](../keywords/unsafe.md) keyword, then the [**AllowUnsafeBlocks**](../compiler-options/language.md#allowunsafeblocks) compiler option must also be used. For more information, see [Unsafe Code and Pointers](../unsafe-code.md).

To set the unsafe option in Visual Studio 2012, click on **Project** in the main menu, select the **Build** pane, and check the box that says "allow unsafe code."

The following sample, when compiled without **/unsafe**, generates CS0227:

```csharp
// CS0227.cs
public class MyClass
{
   unsafe public static void Main()   // CS0227
   {
   }
}
```

## CS0233

'identifier' does not have a predefined size, therefore sizeof can only be used in an unsafe context

Without [unsafe](../keywords/unsafe.md) context, the [sizeof](../operators/sizeof.md) operator can only be used for types whose size is a compile-time constant. If you are getting this error, use an unsafe context.

The following example generates CS0233:

```csharp
// CS0233.cs
using System;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential)]
public struct S
{
    public int a;
}

public class MyClass
{
    public static void Main()
    {
        S myS = new S();
        Console.WriteLine(sizeof(S));   // CS0233
        // Try the following instead:
        // unsafe
        // {
        //     Console.WriteLine(sizeof(S));
        // }
   }
}
```

## CS0242

The operation in question is undefined on void pointers

Incrementing a void pointer is not allowed. For more information, see [Unsafe Code and Pointers](../unsafe-code.md).

### Example

The following sample generates CS0242:

```csharp
// CS0242.cs
// compile with: /unsafe
class TestClass
{
   public unsafe void Test()
   {
      void * p = null;
      p++;   // CS0242, incrementing a void pointer not allowed
   }

   public static void Main()
   {
   }
}
```

## CS0244

Neither 'is' nor 'as' is valid on pointer types

The [is](../operators/type-testing-and-cast.md#the-is-operator) and [as](../operators/type-testing-and-cast.md#the-as-operator) operators are not valid for use on pointer types. For more information, see [Unsafe Code and Pointers](../unsafe-code.md).

### Example

The following sample generates CS0244:

```csharp
// CS0244.cs
// compile with: /unsafe

class UnsafeTest
{
   unsafe static void SquarePtrParam (int* p)
   {
      bool b = p is object;   // CS0244 p is pointer
   }

   unsafe public static void Main()
   {
      int i = 5;
      SquarePtrParam (&i);
   }
}
```

## CS0254

The right hand side of a fixed statement assignment may not be a cast expression

The right side of a [fixed](../statements/fixed.md) expression may not use a cast. For more information, see [Unsafe Code and Pointers](../unsafe-code.md).

### Example

The following sample generates CS0254:

```csharp
// CS0254.cs
// compile with: /unsafe
class Point
{
   public uint x, y;
}

class FixedTest
{
   unsafe static void SquarePtrParam (int* p)
   {
      *p *= *p;
   }

   unsafe public static void Main()
   {
      Point pt = new Point();
      pt.x = 5;
      pt.y = 6;

      fixed (int* p = (int*)&pt.x)   // CS0254
      // try the following line instead
      // fixed (uint* p = &pt.x)
      {
         SquarePtrParam ((int*)p);
      }
   }
}
```

## CS0459

Cannot take the address of a read-only local variable

There are three common scenarios in the C# language that generate read-only local variables: `foreach`, `using`, and `fixed`. In each of these cases, you are not allowed to write to the read-only local variable, or to take its address. This error is generated when the compiler realizes you are trying to take the address of a read-only local variable.

### Example

The following example generates CS0459 when an attempt is made to take the address of a read-only local variable in a `foreach` loop and in a `fixed` statement block:

```csharp
// CS0459.cs
// compile with: /unsafe

class Program
{
    public unsafe void M1()
    {
        int[] ints = new int[] { 1, 2, 3 };
        foreach (int i in ints)
        {
            int *j = &i;  // CS0459
        }

        fixed (int *i = &_i)
        {
            int **j = &i;  // CS0459
        }
    }

    private int _i = 0;
}
```

> [!NOTE]
> Roslyn compiler was updated and this compiler error was removed starting with Visual Studio 2017 version 15.5, so the previous code would compile successfully with this version and later.

## CS0821

Implicitly typed locals cannot be fixed

Implicitly typed local variables and anonymous types are not supported in the `fixed` context.

### To correct this error

1. Either remove the `fixed` modifier from the variable or else give the variable an explicit type.

### Example

The following code generates CS0821:

```csharp
class A
{
    static int x;

    public static int Main()
    {
        unsafe
        {
            fixed (var p = &x) { }  
        }
        return -1;
    }
}
```

### See also

- [Implicitly Typed Local Variables](../../programming-guide/classes-and-structs/implicitly-typed-local-variables.md)

## CS1641

A fixed size buffer field must have the array size specifier after the field name

Unlike regular arrays, fixed size buffers require a constant size to be specified at the declaration point. To resolve this error, add a positive integer literal or a constant positive integer and put the square brackets after the identifier.

### Example

The following sample generates CS1641:

```csharp
// CS1641.cs
// compile with: /unsafe /target:library
unsafe struct S {
   fixed int [] a;  // CS1641

   // OK
   fixed int b [10];
   const int c = 10;
   fixed int d [c];
}
```

## CS1642

Fixed size buffer fields may only be members of structs.

This error occurs if you use a fixed size buffer field in a `class`, instead of a `struct`. To resolve this error, change the `class` to a `struct` or declare the field as an ordinary array.

### Example

The following sample generates CS1642.

```csharp
// CS1642.cs
// compile with: /unsafe /target:library
unsafe class C
{
   fixed int a[10];   // CS1642
}

unsafe struct D
{
    fixed int a[10];
}

unsafe class E
{
   public int[] a = null;
}
```

## CS1656

Cannot assign to 'variable' because it is a 'read-only variable type'

This error occurs when an assignment to variable occurs in a read-only context. Read-only contexts include [foreach](../statements/iteration-statements.md#the-foreach-statement) iteration variables, [using](../statements/using.md) variables, and [fixed](../statements/fixed.md) variables. To resolve this error, avoid assignments to a statement variable in `using` blocks, `foreach` statements, and `fixed` statements.

### Example 1

The following example generates error CS1656 because it tries to replace complete elements of a collection inside a `foreach` loop. One way to work around the error is to change the `foreach` loop to a [for](../statements/iteration-statements.md#the-for-statement) loop. Another way, not shown here, is to modify the members of the existing element; this is possible with classes, but not with structs.

```csharp
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CS1656_2
{

    class Book
    {
        public string Title;
        public string Author;
        public double Price;
        public Book(string t, string a, double p)
        {
            Title=t;
            Author=a;
            Price=p;

        }
    }

    class Program
    {
        private List<Book> list;
        static void Main(string[] args)
        {
            Program prog = new Program();
            prog.list = new List<Book>();
            prog.list.Add(new Book ("The C# Programming Language",
                                    "Hejlsberg, Wiltamuth, Golde",
                                     29.95));
            prog.list.Add(new Book ("The C++ Programming Language",
                                    "Stroustrup",
                                     29.95));
            prog.list.Add(new Book ("The C Programming Language",
                                    "Kernighan, Ritchie",
                                    29.95));
            foreach(Book b in prog.list)
            {
                // Cannot modify an entire element in a foreach loop
                // even with reference types.
                // Use a for or while loop instead
                if (b.Title == "The C Programming Language")
                    // Cannot assign to 'b' because it is a 'foreach
                    // iteration variable'
                    b = new Book("Programming Windows, 5th Ed.", "Petzold", 29.95); //CS1656
            }

            //With a for loop you can modify elements
            //for(int x = 0; x < prog.list.Count; x++)
            //{  
            //    if(prog.list[x].Title== "The C Programming Language")
            //        prog.list[x] = new Book("Programming Windows, 5th Ed.", "Petzold", 29.95);
            //}
            //foreach(Book b in prog.list)
            //    Console.WriteLine(b.Title);

        }
    }
}
```

### Example 2

The following sample demonstrates how CS1656 can be generated in other contexts besides a `foreach` loop:

```csharp
// CS1656.cs
// compile with: /unsafe
using System;

class C : IDisposable
{
    public void Dispose() { }
}

class CMain
{
    unsafe public static void Main()
    {
        using (C c = new C())
        {
            // Cannot assign to 'c' because it is a 'using variable'
            c = new C(); // CS1656
        }

        int[] ary = new int[] { 1, 2, 3, 4 };
        fixed (int* p = ary)
        {
            // Cannot assign to 'p' because it is a 'fixed variable'
            p = null; // CS1656
        }
    }
}
```

## CS1663

Fixed size buffer type must be one of the following: bool, byte, short, int, long, char, sbyte, ushort, uint, ulong, float or double

This error occurs when you try to declare a [fixed-size buffer](../unsafe-code.md#fixed-size-buffers) with a type other than the supported primitive types. Fixed-size buffers can only use specific value types that are safe for pointer arithmetic and have predictable memory layouts.

### Example

The following sample generates CS1663:

```csharp
// CS1663.cs
// compile with: /unsafe /target:library
public struct MyStruct
{
    unsafe public fixed string a[10];  // CS1663 - string is not allowed
}
```

To fix the error, use one of the allowed primitive types, such as `char` for text data or `int` for numeric data.

## CS1665

Fixed size buffers must have a length greater than zero

This error occurs if a [fixed-size buffer](../unsafe-code.md#fixed-size-buffers) is declared with a zero or negative size. The length of a fixed-size buffer must be a positive integer.

### Example

The following sample generates CS1665:

```csharp
// CS1665.cs
// compile with: /unsafe /target:library
struct S
{
   public unsafe fixed int A[0];   // CS1665
}
```

## CS1666

You cannot use fixed size buffers contained in unfixed expressions. Try using the fixed statement.

This error occurs if you use the [fixed-size buffer](../unsafe-code.md#fixed-size-buffers) in an expression involving an instance that is not itself fixed. The runtime is free to move the unfixed instance around to optimize memory access, which could lead to errors when using the fixed-size buffer. To avoid this error, use the [`fixed` statement](../statements/fixed.md).

### Example

The following sample generates CS1666.

```csharp
// CS1666.cs
// compile with: /unsafe /target:library
unsafe struct S
{
   public fixed int buffer[1];
}

unsafe class Test
{
   S field = new S();

   private bool example1()
   {
      return (field.buffer[0] == 0);   // CS1666 error
   }

   private bool example2()
   {
      // OK
      fixed (S* p = &field)
      {
         return (p->buffer[0] == 0);
      }
   }

   private bool example3()
   {
      S local = new S();
      return (local.buffer[0] == 0);
   }
}
```

## CS1708

Fixed size buffers can only be accessed through locals or fields

A new feature in C# 2.0 is the ability to define an in-line array inside of a `struct`. Such arrays can only be accessed via local variables or fields, and may not be referenced as intermediate values on the left-hand side of an expression. Also, the arrays cannot be accessed by fields that are `static` or `readonly`.

To resolve this error, define an array variable, and assign the in-line array to the variable. Or, remove the `static` or `readonly` modifier from the field representing the in-line array.

### Example

The following sample generates CS1708.

```csharp
// CS1708.cs
// compile with: /unsafe
using System;

unsafe public struct S
{
    public fixed char name[10];
}

public unsafe class C
{
    public S UnsafeMethod()
    {
        S myS = new S();
        return myS;
    }
  
    static void Main()
    {
        C myC = new C();
        myC.UnsafeMethod().name[3] = 'a';  // CS1708
        // Uncomment the following 2 lines to resolve:
        // S myS = myC.UnsafeMethod();
        // myS.name[3] = 'a';

        // The field cannot be static.
        C._s1.name[3] = 'a';  // CS1708

        // The field cannot be readonly.
        myC._s2.name[3] = 'a';  // CS1708
    }

    static readonly S _s1;
    public readonly S _s2;
}
```

## CS1716

Do not use 'System.Runtime.CompilerServices.FixedBuffer' attribute. Use the 'fixed' field modifier instead.

This error arises in an unsafe code section that contains a fixed-size array declaration similar to a field declaration. Do not use this attribute. Instead, use the keyword `fixed`.

### Example

The following example generates CS1716.

```csharp
// CS1716.cs
// compile with: /unsafe
using System;
using System.Runtime.CompilerServices;

public struct UnsafeStruct
{
    [FixedBuffer(typeof(int), 4)]  // CS1716
    unsafe public int aField;
    // Use this single line instead of the above two lines.
    // unsafe public fixed int aField[4];
}

public class TestUnsafe
{
    static int Main()
    {
        UnsafeStruct us = new UnsafeStruct();  
        unsafe
        {
            if (us.aField[0] == 0)
                return us.aField[1];
            else
                return us.aField[2];
        }
    }
}
```

## CS1919

Unsafe type 'type name' cannot be used in object creation.

The `new` operator creates objects only on the managed heap. However, you can create objects in unmanaged memory indirectly by using the interoperability capabilities of the language to call native methods that return pointers.

### To correct this error

1. Use a safe type in the new object creation expression. For example, use `char` or `int` instead of `char*` or `int*`.

2. If you must create objects in unmanaged memory, use a Win32 or COM method or else write your own function in C or C++ and call it from C#.

### Example

The following example generates CS1919 because a pointer type is unsafe:

```csharp
// cs1919.cs
// Compile with: /unsafe
unsafe public class C
{
    public static int Main()
    {
        var col1 = new int* { }; // CS1919
        var col2 = new char* { }; // CS1919
        return 1;
    }
}
```

## See also

- [Interoperability](../../advanced-topics/interop/index.md)

## CS8812

Cannot convert `&Method` group to non-function pointer type.

The address of an expression (for example, `&Method`) has no type and thus cannot be assigned to a non-function pointer variable.

The `&` operator is the [address-of](../operators/pointer-related-operators.md#address-of-operator-) operator, used to return the address of its operand.

### Example

The following sample generates CS8812:

```csharp
// CS8812.cs (6,22)

unsafe class C
{
    static void Method()
    {
        void* ptr1 = &Method;
    }
}
```

### To correct this error

Explicitly convert the expression to the required type (for example, a `void` `delegate`):

```csharp
unsafe class C
{
    static void Method()
    {
        void* ptr1 = (delegate*<void>)&Method;
    }
}
```

### See also

- [Shouldn't method addresses be implicitly convertible to void* and thus allowing direct casts to function pointers with mismatched signatures?](https://github.com/dotnet/csharplang/discussions/5720)
- [Casting function pointer directly to void and then a function pointer type causes crash.](https://github.com/dotnet/roslyn/issues/44489)
- [Address-of operator &amp;](../operators/pointer-related-operators.md#address-of-operator-)
