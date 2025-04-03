---
title: Errors and warnings for iterator methods and `yield return`
description: Use this article to diagnose and correct compiler errors and warnings when you write iterator methods that use `yield return` to enumerate a sequence of elements.
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
  - "CS9238"
  - "CS9239"
ms.date: 07/02/2024
---
# Errors and warnings related to the `yield return` statement and iterator methods

There are numerous *errors* related to the `yield return` statement and iterator methods:

<!-- The text in this list generates issues for Acrolinx, because they don't use contractions.
That's by design. The text closely matches the text of the compiler error / warning for SEO purposes.
 -->
- [**CS1622**](#structure-of-an-iterator-method): *Cannot return a value from an iterator. Use the yield return statement to return a value, or yield break to end the iteration.*
- [**CS1624**](#structure-of-an-iterator-method): *The body of 'accessor' cannot be an iterator block because 'type' is not an iterator interface type*
- [**CS1625**](#restrictions-on-iterator-methods): *Cannot yield in the body of a finally clause*
- [**CS1626**](#restrictions-on-iterator-methods): *Cannot yield a value in the body of a try block with a catch clause*
- [**CS1627**](#structure-of-an-iterator-method): *Expression expected after yield return*
- [**CS1629**](#restrictions-on-iterator-methods): *Unsafe code may not appear in iterators*
- [**CS1631**](#restrictions-on-iterator-methods): *Cannot yield a value in the body of a catch clause*
- [**CS1637**](#structure-of-an-iterator-method): *Iterators cannot have unsafe parameters or yield types*
- [**CS4013**](#ref-safety-in-iterator-methods): *Instance of type cannot be used inside a nested function, query expression, iterator block or async method*
- [**CS8154**](#structure-of-an-iterator-method): *The body cannot be an iterator block because it returns by reference*
- [**CS8176**](#ref-safety-in-iterator-methods): *Iterators cannot have by-reference locals*
- [**CS9238**](#restrictions-on-iterator-methods): *Cannot use 'yield return' in an 'unsafe' block*
- [**CS9239**](#restrictions-on-iterator-methods): *The `&` operator cannot be used on parameters or local variables in iterator methods.*

## Structure of an iterator method

An iterator method must conform to several rules in C#. The compiler issues the following errors when your iterator method violates one or more of those rules:

- **CS1622**: *Cannot return a value from an iterator. Use the yield return statement to return a value, or yield break to end the iteration.*
- **CS1624**: *The body of 'accessor' cannot be an iterator block because 'type' is not an iterator interface type*
- **CS1627**: *Expression expected after yield return*
- **CS1637**: *Iterators cannot have unsafe parameters or yield types*
- **CS8154**: *The body cannot be an iterator block because it returns by reference*

Your iterator method must follow the following rules:

- An iterator method (using `yield return` and optionally `yield break`) can't also use a `return` statement to return a sequence.
- An iterator method must declare an *iterator interface type* as the return type. The *iterator interface types* are: <xref:System.Collections.IEnumerable>, <xref:System.Collections.Generic.IEnumerable%601>, <xref:System.Collections.IEnumerator>, <xref:System.Collections.Generic.IEnumerator%601>.
- A `yield return` statement must include an expression to return as part of a sequence. `yield return;` isn't valid.
- An iterator method can't use unsafe types as parameters, such as pointers.
- An iterator method can't `yield return` unsafe type, such as pointers.
- An iterator method can't `yield return` by `ref`. You must return by value.

## Restrictions on iterator methods

The body of an iterator method must conform to restrictions on the `yield return` statement and its context. The compiler issues the following errors when your iterator violates one of these restrictions:

- **CS1625**: *Cannot yield in the body of a finally clause*
- **CS1626**: *Cannot yield a value in the body of a try block with a catch clause*
- **CS1631**: *Cannot yield a value in the body of a catch clause*
- **CS1629**: *Unsafe code may not appear in iterators*
- **CS9238**: *Cannot use 'yield return' in an 'unsafe' block*
- **CS9239**: *The `&` operator cannot be used on parameters or local variables in iterator methods.*

These errors indicate that your code violates safety rules because an iterator returns an element and resumes to generate the next element:

- You can't `yield return` from a `catch` or `finally` clause.
- You can't `yield return` from a `try` block with a catch clause.
- You can't `yield return` from an `unsafe` block. The context for an iterator creates a nested `safe` block within the enclosing `unsafe` block.
- You can't use the `&` operator to take the address of a variable in an iterator method.

Before C# 13, iterators can't contain `unsafe` code (CS1629). Beginning with C# 13, this restriction is relaxed. All `yield return` statements must be in a safe context, but an iterator method can contain `unsafe` code.

## ref safety in iterator methods

Iterator methods have special ref safety restrictions. These rules are relaxed in C# 13:

- **CS4013**: *Instance of type cannot be used inside a nested function, query expression, iterator block or async method*
- **CS8176**: *Iterators cannot have by-reference locals*

Before C# 13, iterators couldn't declare `ref` local variables. They could not declare any variables of a `ref struct` type.

Beginning with C# 13, `ref struct` types can be used in iterator methods, if they aren't accessed across `yield return` statement. Beginning with C# 13, iterator methods can declare `ref` local variables.
