---
title: Errors and warnings associated with reference parameter modifiers
description: The compiler issues these errors and warnings when you have used the reference parameter modifiers incorrectly. They indicate you've got some mismatch between the modifier on the parameter, the argument, or the use of the parameter in the method.
f1_keywords:
  - "CS9190"
  - "CS9191"
  - "CS9192"
  - "CS9193"
  - "CS9195"
  - "CS9196"
  - "CS9197"
  - "CS9198"
  - "CS9199"
  - "CS9200"
helpviewer_keywords:
  - "CS9190"
  - "CS9191"
  - "CS9192"
  - "CS9193"
  - "CS9195"
  - "CS9196"
  - "CS9197"
  - "CS9198"
  - "CS9199"
  - "CS9200"
ms.date: 10/16/2023
---
# Errors and warnings associated with reference parameters, variables, and returns

The following errors may be generated when source generators or interceptors are loaded during a compilation:

- CS0192: ERR_RefReadonly
  - A readonly field cannot be used as a ref or out value (except in a constructor)
- CS0199: ERR_RefReadonlyStatic
  - A static readonly field cannot be used as a ref or out value (except in a static constructor)
- CS0206: ERR_RefProperty
  - A non ref-returning property or indexer may not be used as an out or ref value
- CS0631: ERR_IllegalRefParam
  - ref and out are not valid in this context
- CS1510: ERR_RefLvalueExpected
  - A ref or out value must be an assignable variable
- CS1605: ERR_RefReadonlyLocal
  - Cannot use '{0}' as a ref or out value because it is read-only
- CS1623: ERR_BadIteratorArgType
  - Iterators cannot have ref, in or out parameters
- CS1649: ERR_RefReadonly2
  - Members of readonly field '{0}' cannot be used as a ref or out value (except in a constructor)
- CS1651: ERR_RefReadonlyStatic2
  - Fields of static readonly field '{0}' cannot be used as a ref or out value (except in a static constructor)
- CS1655: ERR_RefReadonlyLocal2Cause
  - Cannot use fields of '{0}' as a ref or out value because it is a '{1}'
- CS1657: ERR_RefReadonlyLocalCause
  - Cannot use '{0}' as a ref or out value because it is a '{1}'
- CS1939: ERR_QueryOutRefRangeVariable
  - Cannot pass the range variable '{0}' as an out or ref parameter

- **CS9190**: `readonly` modifier must be specified after `ref`.
- **CS9199**: A ref readonly parameter cannot have the Out attribute.

The following warnings may be generated when source generators or interceptors are loaded during a compilation:

- **CS9191**: The `ref` modifier for argument corresponding to `in` parameter is equivalent to `in`. Consider using `in` instead.
- **CS9192**: Argument should be passed with `ref` or `in` keyword.
- **CS9193**: Argument should be a variable because it is passed to a `ref readonly` parameter
- **CS9195**: Argument should be passed with the `in` keyword
- **CS9196**: Reference kind modifier of parameter doesn't match the corresponding parameter in overridden or implemented member.
- **CS9197**: Reference kind modifier of parameter doesn't match the corresponding parameter in hidden member.
- **CS9198**: Reference kind modifier of parameter doesn't match the corresponding parameter in target.
- **CS9200**: A default value is specified for `ref readonly` parameter, but `ref readonly` should be used only for references. Consider declaring the parameter as `in`.

These errors and warnings follow these themes:

## Compiler Error CS0192

Fields of static readonly field 'name' cannot be passed ref or out (except in a static constructor)

A field (variable) marked with the [readonly](../language-reference/keywords/readonly.md) keyword cannot be passed either to a [ref](../language-reference/keywords/ref.md) or [out](../language-reference/keywords/out-parameter-modifier.md) parameter except inside a constructor. For more information, see [Fields](../programming-guide/classes-and-structs/fields.md).

CS0192 also results if the `readonly` field is [static](../language-reference/keywords/static.md) and the constructor is not marked `static`.

The following sample generates CS0192.

```csharp
// CS0192.cs
class MyClass
{
    public readonly int TestInt = 6;
    static void TestMethod(ref int testInt)
    {
        testInt = 0;
    }

    MyClass()
    {
        TestMethod(ref TestInt);   // OK
    }

    public void PassReadOnlyRef()
    {
        TestMethod(ref TestInt);   // CS0192
    }

    public static void Main()
    {
    }
}
```

## Compiler Error CS0199

Fields of static readonly field 'name' cannot be passed ref or out (except in a static constructor)

A [readonly](../language-reference/keywords/readonly.md) variable must have the same [static](../language-reference/keywords/static.md) usage as the constructor in which you want to pass it as a [ref](../language-reference/keywords/ref.md) or [out](../language-reference/keywords/out-parameter-modifier.md) parameter. For more information, see [Method Parameters](../language-reference/keywords/method-parameters.md).

The following sample generates CS0199:

```csharp
// CS0199.cs
class MyClass
{
    public static readonly int TestInt = 6;

    static void TestMethod(ref int testInt)
    {
        testInt = 0;
    }

    MyClass()
    {
        TestMethod(ref TestInt);   // CS0199, TestInt is static
    }

    public static void Main()
    {
    }
}
```

## Compiler Error CS0206

A property or indexer may not be passed as an out or ref parameter

A [property](../programming-guide/classes-and-structs/properties.md) is not available to be passed as a [ref](../language-reference/keywords/ref.md) or [out](../language-reference/keywords/out-parameter-modifier.md) parameter. For more information, see [Method Parameters](../language-reference/keywords/method-parameters.md).

The following sample generates CS0206:

```csharp
// CS0206.cs
public class MyClass
{
    public static int P
    {
        get
        {
            return 0;
        }
        set
        {
        }
    }

    public static void MyMethod(ref int i)
    // public static void MyMethod(int i)
    {
    }

    public static void Main()
    {
        MyMethod(ref P);   // CS0206
        // try the following line instead
        // MyMethod(P);   // CS0206
    }
}
```

## Compiler Error CS0631

ref and out are not valid in this context

The declaration for an [indexer](../programming-guide/indexers/index.md) cannot include the use of [ref](../language-reference/keywords/ref.md) or [out](../language-reference/keywords/out-parameter-modifier.md) parameters.

The following sample generates CS0631:

```csharp
// CS0631.cs
public class MyClass
{
    public int this[ref int i]   // CS0631
    // try the following line instead
    // public int this[int i]
    {
        get
        {
            return 0;
        }
    }
}

public class MyClass2
{
    public static void Main()
    {
    }
}
```

## Compiler Error CS1510

A ref or out argument must be an assignable variable

Only a variable can be passed as a [ref](../language-reference/keywords/ref.md) parameter in a method call. A `ref` value is like passing a pointer.

The following sample generates CS1510:

```csharp
// CS1510.cs
public class C
{
   public static int j = 0;

   public static void M(ref int j)
   {
      j++;
   }

   public static void Main ()
   {
      M (ref 2);   // CS1510, can't pass a number as a ref parameter
      // try the following to resolve the error
      // M (ref j);
   }
}
```

## Compiler Error CS1605

Cannot pass 'var' as a ref or out argument because it is read-only

A variable passed as a [ref](../language-reference/keywords/ref.md) or [out](../language-reference/keywords/out-parameter-modifier.md) parameter is expected to be modified in the called method. Therefore, it is not possible to pass a read-only parameter as `ref` or `out`.

The following sample generates CS1605:

```csharp
// CS1605.cs
class C
{
    public void Mutate(ref C c) {}

    public void CallMutate()
    {
        Mutate(ref this);   // CS1605
    }
}
```

## Compiler Error CS1623

Iterators cannot have in ref or out parameters

This error occurs if an iterator method takes an `in`, `ref`, or `out` parameter. To avoid this error, remove the `in`, `ref`, or `out` keyword from the method signature.

The following sample generates CS1623:

```csharp
// CS1623.cs
using System.Collections;

class C : IEnumerable
{
    public IEnumerator GetEnumerator()
    {
        yield return 0;
    }

    // To resolve the error, remove in  
    public IEnumerator GetEnumerator(in short i)  // CS1623  
    {
        yield return i;
    }
    // To resolve the error, remove ref  
    public IEnumerator GetEnumerator(ref int i)  // CS1623  
    {
        yield return i;
    }

    // To resolve the error, remove out  
    public IEnumerator GetEnumerator(out float f)  // CS1623  
    {
        f = 0.0F;
        yield return f;
    }
}
```

## Compiler Error CS1649

Members of readonly field 'identifier' cannot be passed ref or out (except in a constructor)

This error occurs if you pass a variable to a function that is a member of a `readonly` field as a `ref` or `out` argument. Since `ref` and `out` parameters may be modified by the function, this is not allowed. To resolve this error, remove the `readonly` keyword on the field, or do not pass the members of the `readonly` field to the function. For example, you might try creating a temporary variable which can be modified and passing the temporary as a `ref` argument, as shown in the following example.

The following sample generates CS1649:

```csharp
// CS1649.cs
public struct Inner
    {
        public int i;
    }

class Outer
{
    public readonly Inner inner = new Inner();
}
 
class D
{
    static void f(ref int iref)
    {
    }

    static void Main()
    {
        Outer outer = new Outer();
        f(ref outer.inner.i);  // CS1649
        // Try this code instead:
        // int tmp = outer.inner.i;
        // f(ref tmp);
    }
}
```

## Compiler Error CS1651

Fields of static readonly field 'identifier' cannot be passed ref or out (except in a static constructor)

This error occurs if you pass a variable to a function that is a member of a static readonly field as a ref argument. Since ref parameters may be modified by the function, this is not allowed. To resolve this error, remove the **readonly** keyword on the field, or do not pass the members of the readonly field to the function. For example, you might try creating a temporary variable which can be modified and passing the temporary as a ref argument, as shown in the following example.

The following sample generates CS1651:

```csharp
// CS1651.cs
public struct Inner
  {
    public int i;
  }

class Outer
{
  public static readonly Inner inner = new Inner();
}

class D
{
   static void f(ref int iref)
   {
   }

   static void Main()
   {
      f(ref Outer.inner.i);  // CS1651
      // Try this instead:
      // int tmp = Outer.inner.i;
      // f(ref tmp);
   }
}
```

## Compiler Error CS1655

Cannot pass fields of 'variable' as a ref or out argument because it is a 'readonly variable type'

This error occurs if you are attempting to pass a member of a [foreach](../language-reference/statements/iteration-statements.md#the-foreach-statement) variable, a [using](../language-reference/statements/using.md) variable, or a [fixed](../language-reference/statements/fixed.md) variable to a function as a ref or out argument. Because these variables are considered read-only in these contexts, this is not allowed.

The following sample generates CS1655:

```csharp
// CS1655.cs
struct S
{
   public int i;
}

class CMain
{
  static void f(ref int iref)
  {
  }

  public static void Main()
  {
     S[] sa = new S[10];
     foreach(S s in sa)
     {
        CMain.f(ref s.i);  // CS1655
     }
  }
}
```

## Compiler Error CS1657

Cannot pass 'parameter' as a ref or out argument because 'reason'

This error occurs when a variable is passed as a [ref](../language-reference/keywords/ref.md) or [out](../language-reference/keywords/out-parameter-modifier.md) argument in a context in which that variable is readonly. Readonly contexts include [foreach](../language-reference/statements/iteration-statements.md#the-foreach-statement) iteration variables, [using](../language-reference/statements/using.md) variables, and `fixed` variables. To resolve this error, do not call functions that take the `foreach`, `using` or `fixed` variable as a `ref` or `out` parameter in `using` blocks, `foreach` statements, and `fixed` statements.

The following sample generates CS1657:

```csharp
// CS1657.cs
using System;
class C : IDisposable
{
    public int i;
    public void Dispose() {}
}

class CMain
{
    static void f(ref C c)
    {
    }
    static void Main()
    {
        using (C c = new C())
        {
            f(ref c);  // CS1657
        }
    }
}
```

The following code illustrates the same problem in a `fixed` statement:

```csharp
// CS1657b.cs
// compile with: /unsafe
unsafe class C
{
    static void F(ref int* p)
    {
    }

    static void Main()
    {
        int[] a = new int[5];
        fixed(int* p = a) F(ref p); // CS1657
    }
}
```

## Compiler Error CS1939

Cannot pass the range variable 'name' as an out or ref parameter.

A range variable is a read-only variable that is introduced in a query expression and serves as an identifier for each successive element in a source sequence. Because it cannot be modified in any way, there is no point in passing it by `ref` or `out`. Therefore, both operations are not valid.

To correct this error, pass the range variable by value.

The following example generates CS1939:

```csharp
// cs1939.cs
using System.Linq;
class Test
{
    public static void F(ref int i)
    {
    }
    public static void Main()
    {
        var list = new int[] { 0, 1, 2, 3, 4, 5 };
        var q = from x in list
                let k = x
                select Test.F(ref x); // CS1939
    }
}
```
