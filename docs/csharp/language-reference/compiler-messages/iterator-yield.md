---
title: Errors and warnings for iterator methods and `yield return`
description: Use article to diagnose and correct compiler errors and warnings when you write iterator methods that use `yield return` to enumerate a sequence of elements.
f1_keywords:
  - "CS1622"
  - "CS1624"
  - "CS1625"
  - "CS1626"
  - "CS1627"
  - "CS1629"
  - "CS1631"
  - "CS1637"
  - "CS4013"
  - "CS8154"
  - "CS8176"
  - "CS9237"
  - "CS9238"
  - "CS9239"
helpviewer_keywords:
  - "CS1622"
  - "CS1624"
  - "CS1625"
  - "CS1626"
  - "CS1627"
  - "CS1629"
  - "CS1631"
  - "CS1637"
  - "CS4013"
  - "CS8154"
  - "CS8176"
  - "CS9237"
  - "CS9238"
  - "CS9239"
ms.date: 07/02/2024
---
# Errors and warnings related to the `yield return` statement and iterator methods

There are numerous *errors* related to the `yield return` statement and iterator methods:

<!-- The text in this list generates issues for Acrolinx, because they don't use contractions.
That's by design. The text closely matches the text of the compiler error / warning for SEO purposes.
 -->
- [**CS1622**](#compiler-error-cs1622): *Cannot return a value from an iterator. Use the yield return statement to return a value, or yield break to end the iteration.*
- [**CS1624**](#compiler-error-cs1624): *The body of 'accessor' cannot be an iterator block because 'type' is not an iterator interface type*
- [**CS1625**](#compiler-error-cs1625): *Cannot yield in the body of a finally clause*
- [**CS1626**](#compiler-error-cs1626): *Cannot yield a value in the body of a try block with a catch clause*
- [**CS1627**](#compiler-error-cs1627): *Expression expected after yield return*
- [**CS1629**](#compiler-error-cs1629): *Unsafe code may not appear in iterators*
- [**CS1631**](#compiler-error-cs1631): *Cannot yield a value in the body of a catch clause*
- [**CS1637**](#compiler-error-cs1637): *Iterators cannot have unsafe parameters or yield types*
- [**CS4013**](#compiler-error-cs4013): *Instance of type cannot be used inside a nested function, query expression, iterator block or async method*
- [**CS8154**](#compiler-error-cs8154): *The body cannot be an iterator block because it returns by reference*
- [**CS8176**](#compiler-error-cs8176): *Iterators cannot have by-reference locals*
- [**CS9237**](#new-errors): *'yield return' should not be used in the body of a lock statement*
- [**CS9238**](#new-errors): *Cannot use 'yield return' in an 'unsafe' block*
- [**CS9239**](#new-errors): *The `&` operator cannot be used on parameters or local variables in iterator methods.*

## Compiler Error CS1622

Cannot return a value from an iterator. Use the yield return statement to return a value, or yield break to end the iteration.

An iterator is a special function that returns a value via the yield statement rather than the return statement. For more information, see **iterators**.

The following sample generates CS1622:

```csharp
// CS1622.cs
// compile with: /target:library
using System.Collections;

class C : IEnumerable
{
   public IEnumerator GetEnumerator()
   {
      return (IEnumerator) this;  // CS1622
      yield return this;   // OK
   }
}
```

## Compiler Error CS1624

The body of 'accessor' cannot be an iterator block because 'type' is not an iterator interface type

This error occurs if an iterator accessor is used but the return type is not one of the iterator interface types: <xref:System.Collections.IEnumerable>, <xref:System.Collections.Generic.IEnumerable%601>, <xref:System.Collections.IEnumerator>, <xref:System.Collections.Generic.IEnumerator%601>. To avoid this error, use one of the iterator interface types as a return type.

The following sample generates CS1624:

```csharp
// CS1624.cs
using System;
using System.Collections;

class C
{
    public int Iterator
    // Try this instead:
    // public IEnumerable Iterator
    {
        get  // CS1624
        {
            yield return 1;
        }
    }
}
```

## Compiler Error CS1625

Cannot yield in the body of a finally clause

A yield statement is not allowed in the body of a finally clause. To avoid this error, move the yield statement out of the finally clause.

The following sample generates CS1625:

```csharp
// CS1625.cs
using System.Collections;

class C : IEnumerable
{
   public IEnumerator GetEnumerator()
   {
      try
      {
      }
      finally
      {
        yield return this;  // CS1625
      }
   }
}

public class CMain
{
   public static void Main() { }
}
```

## Compiler Error CS1626

Cannot yield a value in the body of a try block with a catch clause

A yield statement is not allowed in a try block if there is a catch clause associated with the try block. To avoid this error, either move the yield statement out of the try/catch/finally block, or remove the catch block.

The following sample generates CS1626:

```csharp
// CS1626.cs
using System.Collections;

class C : IEnumerable
{
   public IEnumerator GetEnumerator()
   {
      try
      {
         yield return this;  // CS1626
      }
      catch
      {

      }
      finally
      {

      }
   }  
}

public class CMain
{
   public static void Main() { }
}
```

## Compiler Error CS1627

Expression expected after yield return

This error occurs if `yield` is used without an expression. To avoid this error, insert the appropriate expression in the statement.

The following sample generates CS1627:

```csharp
// CS1627.cs
using System.Collections;

class C : IEnumerable
{
   public IEnumerator GetEnumerator()
   {
      yield return;   // CS1627
      // To resolve, add the following line:
      // yield return 0;
   }
}

public class CMain
{
   public static void Main() { }
}
```

## Compiler Error CS1629

Unsafe code may not appear in iterators

The C# language specification doesn't allow unsafe code in iterators. This restriction is relaxed in C# 13. You can use `unsafe` blocks, but the `yield return` statement can't be used in an `unsafe` block.

The following sample generates CS1629:

```csharp
// CS1629.cs
// compile with: /unsafe
using System.Collections.Generic;
class C
{
   IEnumerator<int> IteratorMethod()
   {
      int i;
      unsafe  // CS1629
      {
         int *p = &i;
         yield return *p;
      }
   }
}
```

## Compiler Error CS1631

Cannot yield a value in the body of a catch clause

The yield statement is not allowed from within the body of a catch clause. To avoid this error, move the yield statement outside the body of the catch clause.

The following sample generates CS1631:

```csharp
// CS1631.cs
using System;
using System.Collections;

public class C : IEnumerable
{
   public IEnumerator GetEnumerator()
   {
      try
      {
      }
      catch(Exception e)
      {
        yield return this;  // CS1631
      }
   }

   public static void Main()
   {
   }
}
```

## Compiler Error CS1637

Iterators cannot have unsafe parameters or yield types

Check the argument list of the iterator and the type of any yield statements to verify that you are not using any unsafe types.

The following sample generates CS1637:

```csharp
// CS1637.cs
// compile with: /unsafe
using System.Collections;

public unsafe class C
{
    public IEnumerator Iterator1(int* p)  // CS1637
    {
        yield return null;
    }
}
```

## Compiler Error CS4013

Instance of type cannot be used inside a nested function, query expression, iterator block or async method

Beginning with C# 13, `ref struct` types can be used in iterator methods, if they aren't accessed across `yield return` statement.

The following sample generates CS4013:

```csharp
public class C
{
    public static IEnumerable<string> Lines(char[] text)
    {
        ReadOnlySpan<char> chars = text;
        var index = chars.IndexOf('\n');
        while (index > 0)
        {
            yield return chars[..index].ToString();
            chars = chars[(index + 1)..];
            index = chars.IndexOf('\n');
        }

        yield return chars.ToString();
    }
}
```

This enumerator method extracts lines of text from a character array.  It naively tries to use `ReadOnlySpan<T>` to improve performance. The preceding example exhibits the same error in C# 13, because the `ReadOnlySpan` instance `chars` is in scope at the `yield return` statement.

To correct this error:

`Lines(char[] text)` is an enumerator function.  An enumerator function compiles the method's body into a state machine that manages the sequence of states the iterator function goes through while processing.   That state machine is implemented as a generated class, and the state is implemented as variables within that class.  That captured local state is forced from a stack context to a heap context.  Since `ref struct`s like `ReadOnlySpan<T>` can't be stored in the heap, the CS4013 error is raised.  To continue to use a `ReadOnlySpan<T>`, to correct this error, the method must be reimplemented as a noniterator function, for example:

```csharp
    public static IEnumerable<string> Lines2(char[] text)
    {
        ReadOnlySpan<char> chars = text;

        var lines = new List<string>();
        var index = chars.IndexOf('\n');
        while (index > 0)
        {
            lines.Add(chars[..index].ToString());
            chars = chars[(index+1)..];
            index = chars.IndexOf('\n');
        }

        lines.Add(chars.ToString());
        return lines;
    }
```

To continue to use an iterator function, to correct this error, the method must be reimplemented to avoid using `ReadOnlySpan<T>`, for example:

```csharp
    public static IEnumerable<string> Lines2(char[] chars)
    {
        var startIndex = 0;
        var index = Array.IndexOf(chars,'\n');
        while (index > 0)
        {
            yield return new string(chars, startIndex, index);
            startIndex = index+1;
            index = Array.IndexOf(chars, '\n', startIndex);
        }
        yield return new string(chars, startIndex, chars.Length - startIndex);
    }
```

In C# 13, a `ReadOnlySpan` can be used, but can only be used in code segments without a `yield return`:

```csharp
static IEnumerable<string> Lines2(char[] text)
{
    ReadOnlySpan<char> chars = text;

    var lines = new List<string>();
    var index = chars.IndexOf('\n');
    while (index > 0)
    {
        lines.Add(chars[..index].ToString());
        chars = chars[(index + 1)..];
        index = chars.IndexOf('\n');
    }

    lines.Add(chars.ToString());
    foreach(var line in lines)
    {
        yield return line;
    }
}
```

## Compiler Error CS8154

The body cannot be an iterator block because it returns by reference

The following sample generates CS8154:

```csharp
// CS8154.cs (12,17)

class TestClass
{
    int x = 0;
    ref int TestFunction()
    {
        if (true)
        {
            yield return x;
        }

        ref int localFunction()
        {
            if (true)
            {
                yield return x;
            }
        }

        yield return localFunction();
    }
}
```

Iterator methods cannot return by reference, refactoring to return by value corrects this error:

```csharp
class TestClass
{
    int x = 0;
    IEnumerable<int> TestFunction()
    {
        if (true)
        {
            yield return x;
        }

        IEnumerable<int> localFunction()
        {
            if (true)
            {
                yield return x;
            }
        }

        foreach (var item in localFunction())
            yield return item;
    }
}
```

## Compiler Error CS8176

Iterators cannot have by-reference locals

Iterator blocks use deferred execution, where the evaluation of an expression is delayed until its realized value is required. To manage that deferred execution state, iterator blocks use a state machine, capturing variable state in closures implemented in compiler-generated classes and properties. A local variable reference (on the stack) can't be captured within the instance of a class in the heap, so the compiler issues an error.

Beginning with C# 13, this restriction was removed.

The following sample generates CS8176:

```csharp
// CS8176.cs (7,26)

using System.Collections.Generic;
class C
{
    IEnumerable<int> M()
    {
        ref readonly int x = ref (new int[1])[0];
        int i = x;
        yield return i;
    }
}
```

Removing use of by-reference corrects this error:

```csharp
class C
{
    IEnumerable<int> M()
    {
        int x = (new int[1])[0];
        int i = x;
        yield return i;
    }
}
```

## New errors

- **CS9237**: *''yield return' should not be used in the body of a lock statement*
- **CS9238**: *Cannot use 'yield return' in an 'unsafe' block*
- **CS9239**: *The `&` operator cannot be used on parameters or local variables in iterator methods.*

These errors indicate that your code violates safety rules because an iterator returns an element and resumes to generate the next element:

- You can't `yield return` from inside a `lock` statement block. Doing so can cause deadlocks.
- You can't `yield return` from an `unsafe` block. The context for an iterator creates a nested `safe` block within the enclosing `unsafe` block.
- You can't use the `&` operator to take the address of a variable in an iterator method.

You must update your code to remove the constructs that aren't allowed.
