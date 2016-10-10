---
title: Tuples | C# Guide
description: Learn about unnamed and named tuple types in C#
keywords: .NET, .NET Core, C#
author:  BillWagner
ms-author: wiwagn
manager: wpickett
ms.date: 11/01/2016
ms.topic: article
ms.prod: .net-core
ms.technology: .net-core-technologies
ms.devlang: csharp
ms.assetid: ee8bf7c3-aa3e-4c9e-a5c6-e05cc6138baa
---

# C# Tuple types

C# Tuples are types that you define using a lightweight syntax. The advantages
include a simpler syntax, rules for conversions based on arity and types, and
consistent rules for copies and assignments. As a tradeoff, Tuples do not
support some of the object oriented idioms associated with inheritance. You
can get an overview in the section on [Tuples in the What's new in C# 7](csharp-7.md#tuples) topic.

In this topic, you'll learn the language rules governing Tuples in C# 7,
different ways to use them, and initial guidance on working with Tuples.

Let's start with the reasons for adding new Tuple support. Methods return
a single object. Tuples enable you to package multiple values in that single
object more easily.

The .NET Framework already had a `Tuple` generic classes. These classes,
however, suffered from two limitations. For one, the `Tuple` classes named
their fields `Item1`, `Item2`, and so on. Those names carry no semantic
information. Using these `Tuple` types makes it harder to know the meaning
of each of the fields. Another concern is that the `Tuple` class is a
reference type. Using the `Tuple` type means allocating objects. On hot
paths, this can have a measurable impact on your application's performance.

To avoid those deficiencies, you could create a `class` or a `struct` as
an object to carry multiple fields. Unfortunately, that's more work for you,
and it obscures your design intent. Making a `struct` or `class` implies
that you are defining a type with both data and behavior.

The new language features for tuples, combined with a new set of generic
classes in the framework address thease deficiencies. These new tuples
use the new `ValueTuple` generic struct. As the name implies, this type is a `struct`
instead of a `class`. There are different versions of this struct to support
tuples with different numbers of fields. New language support provides semantic
names for the fields of the tuple type, along with features to make constructing
or accessing tuple fields easy.

The language features and the `ValueTuple` generic structs enforce the rule that
these tuple types do not have any behavior (methods) associated with them.
All the `ValueTuple` types are *mutable structs*. Each member field is a
public field. That makes them very lightweight. However, that means tuples
should not be used where immutability is important.

Tuples are both simpler and more flexible data containers than `class` and
`struct` types. Let's explore those differences.

## Named and unnamed tuples

The `ValueTuple` struct has fields named `Item1`, `Item2`, `Item3` and so on.
These names are the only names you can use for *unnamed tuples*. When you
do not provide any alternative field names to a tuple, you've created an
unnamed tuple:

[!code-csharp[UnnamedTuple](../../samples/snippets/csharp/tuples/tuples/program.cs#01_UnNamedTuple "Unnamed tuple")]

However, when you initialize a tuple, you can use new language features
that give better names to each field. Doing so creates a *named tuple*.
Named tuples still have fields named `Item1`, `Item2`, `Item3` and so on.
But they also have synonyms for any of those fields that you have named.
You creat a named tuple by specifying the names for each field. One way
is to specify the names as part of the tuple initialization:

[!code-csharp[NamedTuple](../../samples/snippets/csharp/tuples/tuples/program.cs#02_NamedTuple "Named tuple")]

These synonyms are handled by the compiler and the language so that you
can use named tuples effectively. Inside a single assembly, the compiler
replaces the names you've defined with `Item*` equivalents. Inside the
compiled Microsoft Intermediate Language (MSIL), the names you've given
do not exist.

The compiler must communicate those names you created for tuples that
are returned from public methods or properties. In those cases, the compiler
adds a `TupleElementNames` attribute on the method. This attribute contains
a `TransformNames` list property that contains the names give to each of
the fields in the Tuple.

> [!NOTE]
> Development Tools, such as Visual Studio, also read that metadata,
> and provide intellisense and other features using the metadata
> field names.

It is important to understand these underlying fundamentals of
the new tuples and the `ValueTuple` type in order to understand
the rules for assigning named tuples to each other.

## Assignment and tuples

The language supports assignment between tuple types that have
the same number of fields, and the same types for each of those
fields. Those types must be exact compile-time matches. Other
conversions are not considered for assignments. Let's look at the kinds
of assignments that are allowed by tuples that may appear to be different
types.

First, consider these variables.

[!code-csharp[VariableCreation](../../samples/snippets/csharp/tuples/tuples/program.cs#03_VariableCreation "Variable creation")]

The first two variables, `unnamed` and `anonymous` do not have semantic
names provided for the fields. The field names are `Item1` and `Item2`.
The last two variables, `named` and `differentName` have semantic names
given for the fields. Note that these two tuples have different names
for the fields.

All four of these tuples have the same number of fields (referred to as 'arity')
and the types of those fields are exactly the same. Therefore, all of these
assignments work:

[!code-csharp[VariableAssignment](../../samples/snippets/csharp/tuples/tuples/program.cs#04_VariableAssignment "Variable assignment")]

Notice that the names of the tuples are not assigned. The values of the
fields are assigned following the order of the fields in the tuple.

Tuples of different types or numbers of fields are not assignable:

```csharp
// Does not compile.
// CS0029: Cannot assign Tuple(int,int,int) to Tuple(int, string)
var differentShape = (1, 2, 3);
named = differentShape;
```

## Tuples as method return values


.. Declaring.

.. are they always named?

.. calling and naming



## deconstruction

.. deconstructing to var

.. create deconstruct method


## Guidance 

### Not Public

### LINQ Queries

### Multiple values






<!-- 

Ideas while writing the main C# 7 article:

. Go into detail on the 'shape' of a tuple and assignment between Tuples

. Go into detail on deconstruction methods

. Consider examples where a LINQ query returns a subset of the columns for a database record.


--> 


> **Note**
> 
> This topic hasn’t been written yet! 
>
> We welcome your input to help shape the scope and approach. You can track the status and provide input on this
> [issue](https://github.com/dotnet/docs/issues/1113) at GitHub.
> 
> If you would like to review early drafts and outlines of this topic, please leave a note with your contact information in the issue.
>
> Learn more about how you can contribute on [GitHub](https://github.com/dotnet/docs/blob/master/CONTRIBUTING.md).
>

