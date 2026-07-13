---
title: "Resolve errors and warnings related to async enumerables, enumerables, and `foreach` statements"
description: "This article helps you diagnose and correct compiler errors and warnings related to async enumerables, enumerables, and foreach statements"
f1_keywords:
  - "CS0202"
  - "CS0230"
  - "CS0278"
  - "CS0279"
  - "CS0280"
  - "CS0446"
  - "CS1579"
  - "CS1640"
  - "CS8412"
  - "CS8413"
  - "CS8414"
  - "CS8415"
  - "CS8419"
  - "CS8420"
  - "CS8424"
  - "CS8425"
  - "CS8426"
helpviewer_keywords:
  - "CS0202"
  - "CS0230"
  - "CS0278"
  - "CS0279"
  - "CS0280"
  - "CS0446"
  - "CS1579"
  - "CS1640"
  - "CS8412"
  - "CS8413"
  - "CS8414"
  - "CS8415"
  - "CS8419"
  - "CS8420"
  - "CS8424"
  - "CS8425"
  - "CS8426"
ms.date: 07/13/2026
ai-usage: ai-assisted
---

# Resolve errors and warnings for `foreach` statements and async enumerables

This article covers the following compiler errors and warnings:

<!-- The text in this list generates issues for Acrolinx, because they don't use contractions.
That's by design. The text closely matches the text of the compiler error / warning for SEO purposes.
 -->

- [**CS0202**](#anchor-tbd): *foreach requires that the return type 'type' of 'type.GetEnumerator()' must have a suitable public 'MoveNext' method and public 'Current' property*
- [**CS0230**](#anchor-tbd): *Type and identifier are both required in a foreach statement*
- [**CS0278**](#anchor-tbd): *'type' does not implement the 'pattern name' pattern. 'method name' is ambiguous with 'method name'.*
- [**CS0279**](#anchor-tbd): *'type' does not implement the 'pattern name' pattern. 'method name' is not a public instance or extension method.*
- [**CS0280**](#anchor-tbd): *'type' does not implement the 'pattern name' pattern. 'method name' has the wrong signature.*
- [**CS0446**](#anchor-tbd): *Foreach cannot operate on a 'method group'. Did you intend to invoke the 'method group'?*
- [**CS1579**](#anchor-tbd): *foreach statement cannot operate on variables of type 'type' because 'type' does not contain a public instance or extension definition for 'member'*
- [**CS1640**](#anchor-tbd): *foreach statement cannot operate on variables of type 'type' because it implements multiple instantiations of 'interface'; try casting to a specific interface instantiation*
- [**CS8412**](#anchor-tbd): *Asynchronous foreach requires that the return type 'type' of 'method' must have a suitable public 'MoveNextAsync' method and public 'Current' property*
- [**CS8413**](#anchor-tbd): *Asynchronous foreach statement cannot operate on variables of type 'type' because it implements multiple instantiations of 'interface'; try casting to a specific interface instantiation*
- [**CS8414**](#anchor-tbd): *foreach statement cannot operate on variables of type 'type' because 'type' does not contain a public instance or extension definition for 'member'. Did you mean 'await foreach' rather than 'foreach'?*
- [**CS8415**](#anchor-tbd): *Asynchronous foreach statement cannot operate on variables of type 'type' because 'type' does not contain a public instance or extension definition for 'member'. Did you mean 'foreach' rather than 'await foreach'?*
- [**CS8419**](#anchor-tbd): *The body of an async-iterator method must contain a 'yield' statement.*
- [**CS8420**](#anchor-tbd): *The body of an async-iterator method must contain a 'yield' statement. Consider removing 'async' from the method declaration or adding a 'yield' statement.*
- [**CS8424**](#anchor-tbd): *The EnumeratorCancellationAttribute applied to parameter 'name' will have no effect. The attribute is only effective on a parameter of type CancellationToken in an async-iterator method returning IAsyncEnumerable*
- [**CS8425**](#anchor-tbd): *Async-iterator 'method' has one or more parameters of type 'CancellationToken' but none of them is decorated with the 'EnumeratorCancellation' attribute, so the cancellation token parameter from the generated 'IAsyncEnumerable<>.GetAsyncEnumerator' will be unconsumed*
- [**CS8426**](#anchor-tbd): *The attribute [EnumeratorCancellation] cannot be used on multiple parameters*

## CS0202

foreach requires that the return type 'type' of 'type.GetEnumerator()' must have a suitable public MoveNext method and public Current property

A <xref:System.Collections.IEnumerable.GetEnumerator*> function, used to enable the use of foreach statements, cannot return a pointer or array; it must return an instance of a class that is able to act as an enumerator. The proper requirements to serve as an enumerator include a public Current property and a public MoveNext method.

> [!NOTE]
> In C# 2.0, the compiler will automatically generate Current and MoveNext for you. For more information, see the code example in [Generic Interfaces](../../programming-guide/generics/generic-interfaces.md).

The following sample generates CS0202:

```csharp
// CS0202.cs

public class C1
{
   public int Current
   {
      get
      {
         return 0;
      }
   }

   public bool MoveNext ()
   {
      return false;
   }

   public static implicit operator C1 (int c1)
   {
      return 0;
   }
}

public class C2
{
   public int Current
   {
      get
      {
         return 0;
      }
   }

   public bool MoveNext ()
   {
      return false;
   }

   public C1[] GetEnumerator ()
   // try the following line instead
   // public C1 GetEnumerator ()
   {
      return null;
   }
}

public class MainClass
{
   public static void Main ()
   {
      C2 c2 = new C2();

      foreach (C1 x in c2)   // CS0202
      {
         System.Console.WriteLine(x.Current);
      }
   }
}
```

## CS0230

Type and identifier are both required in a foreach statement

A [foreach](../statements/iteration-statements.md#the-foreach-statement) statement was poorly formed.

The following sample generates CS0230:

```csharp
// CS0230.cs
class MyClass
{
   public static void Main()
   {
      int[] myarray = new int[3] {1,2,3};

      foreach (int in myarray)   // CS0230
      {
         Console.WriteLine(x);
      }
   }
}
```

To resolve this error, specify both a type and an identifier in the `foreach` statement:

```csharp
class MyClass
{
   public static void Main()
   {
      int[] myarray = new int[3] {1,2,3};

      foreach (int x in myarray)  // Both type (int) and identifier (x) are specified
      {
         Console.WriteLine(x);
      }
   }
}
```

## CS0278

'type' does not implement the 'pattern name' pattern. 'method name' is ambiguous with 'method name'.

There are several statements in C# that rely on defined patterns, such as `foreach` and `using`. For example, the [`foreach` statement](../statements/iteration-statements.md#the-foreach-statement) relies on the collection class implementing the "enumerable" pattern.

CS0278 can occur if the compiler is unable to make the match due to ambiguities. For example, the "enumerable" pattern requires that there be a method called `MoveNext`, and your code might contain two methods called `MoveNext`. The compiler will attempt to find an interface to use, but it is recommended that you determine and resolve the cause of the ambiguity.

The following sample generates CS0278.

```csharp
// CS0278.cs
using System.Collections.Generic;
public class myTest
{
   public static void TestForeach<W>(W w)
      where W: IEnumerable<int>, IEnumerable<string>
   {
      foreach (int i in w) {}   // CS0278
   }
}
```

## CS0279

'type name' does not implement the 'pattern name' pattern. 'method name' is either static or not public.

There are several statements in C# that rely on defined patterns, such as `foreach` and `using`. For example, `foreach` relies on the collection class implementing the enumerable pattern. This error occurs when the compiler is unable to make the match due to a method being declared `static` or not `public`. Methods in patterns are required to be instances of classes, and to be public.

The following example generates CS0279:

```csharp
// CS0279.cs

using System;
using System.Collections;

public class myTest : IEnumerable
{
    IEnumerator IEnumerable.GetEnumerator()
    {
        yield return 0;
    }

    internal IEnumerator GetEnumerator()
    {
        yield return 0;
    }

    public static void Main()
    {
        foreach (int i in new myTest()) {}  // CS0279
    }
}
```

## CS0280

'type' does not implement the 'pattern name' pattern. 'method name' has the wrong signature.

Two statements in C#, `foreach` and `using`, rely on predefined patterns, "collection" and "resource" respectively. This warning occurs when the compiler cannot match one of these statements to its pattern due to a method's incorrect signature. For example, the "collection" pattern requires that there be a method called <xref:System.Collections.IEnumerator.MoveNext*> which takes no parameters and returns a `boolean`. Your code might contain a <xref:System.Collections.IEnumerator.MoveNext*> method that has a parameter or perhaps returns an object.

The "resource" pattern and `using` provide another example. The "resource" pattern requires the <xref:System.IDisposable.Dispose*> method; if you define a property with the same name, you will get this warning.

To resolve this warning, ensure that the method signatures in your type match the signatures of the corresponding methods in the pattern, and ensure that you have no properties with the same name as a method required by the pattern.

### Example

The following sample generates CS0280.

```csharp
// CS0280.cs
using System;
using System.Collections;

public class ValidBase: IEnumerable
{
   IEnumerator IEnumerable.GetEnumerator()
   {
      yield return 0;
   }

   internal IEnumerator GetEnumerator()
   {
      yield return 0;
   }
}

class Derived : ValidBase
{
   // field, not method
   new public int GetEnumerator;
}

public class Test
{
   public static void Main()
   {
      foreach (int i in new Derived()) {}   // CS0280
   }
}
```

## CS0446

Foreach cannot operate on a 'Method or Delegate'. Did you intend to invoke the 'Method or Delegate'?

This error is caused by specifying a method without parentheses or an anonymous method without parentheses in the part of the `foreach` statement where you would normally put a collection class. Note that it is valid, though unusual, to put a method call in that location, if the method returns a collection class.

### Example

The following code will generate CS0446.

```csharp
// CS0446.cs
using System;
class Tester
{
    static void Main()
    {
        int[] intArray = new int[5];
        foreach (int i in M) { } // CS0446
    }
    static void M() { }
}
```

## CS1579

foreach statement cannot operate on variables of type 'type1' because 'type2' does not contain a public definition for 'identifier'

To iterate through a collection using the [foreach](../statements/iteration-statements.md#the-foreach-statement) statement, the collection must meet the following requirements:

- Its type must include a public parameterless `GetEnumerator` method whose return type is either class, struct, or interface type.
- The return type of the `GetEnumerator` method must contain a public property named `Current` and a public parameterless method named `MoveNext` whose return type is <xref:System.Boolean>.

### Example

The following sample generates CS1579 because the `MyCollection` class doesn't contain the public `GetEnumerator` method:

```csharp
// CS1579.cs
using System;
public class MyCollection
{
   int[] items;
   public MyCollection()
   {
      items = new int[5] {12, 44, 33, 2, 50};
   }

   // Delete the following line to resolve.
   MyEnumerator GetEnumerator()

   // Uncomment the following line to resolve:
   // public MyEnumerator GetEnumerator()
   {
      return new MyEnumerator(this);
   }

   // Declare the enumerator class:
   public class MyEnumerator
   {
      int nIndex;
      MyCollection collection;
      public MyEnumerator(MyCollection coll)
      {
         collection = coll;
         nIndex = -1;
      }

      public bool MoveNext()
      {
         nIndex++;
         return (nIndex < collection.items.Length);
      }

      public int Current => collection.items[nIndex];
   }

   public static void Main()
   {
      MyCollection col = new MyCollection();
      Console.WriteLine("Values in the collection are:");
      foreach (int i in col)   // CS1579
      {
         Console.WriteLine(i);
      }
   }
}
```

## CS1640

foreach statement cannot operate on variables of type 'type' because it implements multiple instantiations of 'interface', try casting to a specific interface instantiation

The type inherits from two or more instances of IEnumerator\<T>, which means there is not a unique enumeration of the type that `foreach` could use. Specify the type of IEnumerator\<T> or use another looping construct.

### Example

The following sample generates CS1640:

```csharp
// CS1640.cs

using System;
using System.Collections;
using System.Collections.Generic;

public class C : IEnumerable, IEnumerable<int>, IEnumerable<string>
{
    IEnumerator<int> IEnumerable<int>.GetEnumerator()
    {
        yield break;
    }

    IEnumerator<string> IEnumerable<string>.GetEnumerator()
    {
        yield break;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return (IEnumerator)((IEnumerable<string>)this).GetEnumerator();
    }
}

public class Test
{
    public static int Main()
    {
        foreach (int i in new C()){}    // CS1640

        // Try specifying the type of IEnumerable<T>
        // foreach (int i in (IEnumerable<int>)new C()){}
        return 1;
    }
}
```
