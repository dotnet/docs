---
title: Strongly Typed Delegates
description: Learn how to use generic delegate types to declare custom types when creating a feature requiring delegates.
keywords: .NET, .NET Core
author: BillWagner
ms.author: wiwagn
ms.date: 06/20/2016
ms.topic: article
ms.prod: .net
ms.technology: devlang-csharp
ms.devlang: csharp
ms.assetid: 564a683d-352b-4e57-8bac-b466529daf6b
---

# Strongly Typed Delegates

[Previous](delegate-class.md)

In the previous article, you saw that you create specific delegate
types using the `delegate` keyword. 

The abstract Delegate class provide the infrastructure for loose coupling
and invocation. Concrete Delegate types become much more useful by embracing
and enforcing type safety for the methods that are added to the invocation
list for a delegate object. When you use the `delegate` keyword and define
a concrete delegate type, the compiler generates those methods.

In practice, this would lead to creating new delegate types
whenever you need a different method signature. This work could get tedious
after a time. Every new feature requires new delegate types.

Thankfully, this isn't necessary. The .NET Core framework contains several
types that you can reuse whenever you need delegate types. These are
[generic](programming-guide/generics/index.md) definitions so you can declare customizations
when you need new method declarations. 

The first of these types is the <xref:System.Action> type, and several variations:

```csharp
public delegate void Action();
public delegate void Action<in T>(T arg);
public delegate void Action<in T1, in T2>(T1 arg1, T2 arg2);
// Other variations removed for brevity.
```

The `in` modifier on the generic type argument is covered in the article
on covariance.

There are variations of the `Action` delegate that contain up to
16 arguments such as <xref:System.Action%6016>.
It's important that these definitions use different generic arguments for each of the
delegate arguments: That gives you maximum flexibility. The method arguments need not be, but may be, the same type.

Use one of the `Action` types for any delegate type that has a void return type.

The framework also includes several generic delegate types that you can use for
delegate types that return values:

```csharp
public delegate TResult Func<out TResult>();
public delegate TResult Func<in T1, out TResult>(T1 arg);
public delegate TResult Func<in T1, in T2, out TResult>(T1 arg1, T2 arg2);
// Other variations removed for brevity
```

The `out` modifier on the result generic type argument is covered in the
article on covariance.

There are variations of the `Func` delegate with up to
16 input arguments such as <xref:System.Func%6017>.
The type of the result is always the last type parameter in all the `Func`
declarations, by convention.

Use one of the `Func` types for any delegate type that returns a value.

There's also a specialized
<xref:System.Predicate%601> 
type for a delegate that returns a test on a single value:

```csharp
public delegate bool Predicate<in T>(T obj);
```

You may notice that for any `Predicate` type, a structurally equivalent `Func`
type exists For example:

```csharp
Func<string, bool> TestForString;
Predicate<string> AnotherTestForString;
```

You might think these two types are equivalent. They are not.
These two variables cannot be used interchangeably. A variable of one type cannot
be assigned the other type. The C# type system uses the names of the defined types,
not the structure.

All these delegate type definitions in the .NET Core Library should mean that
you do not need to define a new delegate type for any new feature you create
that requires delegates. These generic definitions should provide all the
delegate types you need under most situations. You can simply instantiate
one of these types with the required type parameters. In the case of algorithms
that can be made generic, these delegates can be used as generic types. 

This should save time, and minimize the number of new types that you need
to create in order to work with delegates.

In the next article, you'll see several common patterns for working
with delegates in practice.

[Next](delegates-patterns.md)
