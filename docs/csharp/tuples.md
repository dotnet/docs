---
title: Tuples | C# Guide
description: Learn about unnamed and named tuple types in C#
keywords: .NET, .NET Core, C#
author:  BillWagner
ms-author: wiwagn
ms.date: 11/23/2016
ms.topic: article
ms.prod: .net
ms.technology: devlang-csharp
ms.devlang: csharp
ms.assetid: ee8bf7c3-aa3e-4c9e-a5c6-e05cc6138baa
---

# C# Tuple types #

C# Tuples are types that you define using a lightweight syntax. The advantages
include a simpler syntax, rules for conversions based on number (referred to as "arity")
and types of fields, and
consistent rules for copies and assignments. As a tradeoff, Tuples do not
support some of the object oriented idioms associated with inheritance. You
can get an overview in the section on [Tuples in the What's new in C# 7](csharp-7.md#tuples) topic.

In this topic, you'll learn the language rules governing Tuples in C# 7,
different ways to use them, and initial guidance on working with Tuples.

> [!NOTE]
> The new tuples features require the `System.ValueTuple` type. For Visual Studio 2017,
> you must add the NuGet package "System.ValueTuple", available in the pre-release stream.

Let's start with the reasons for adding new Tuple support. Methods return
a single object. Tuples enable you to package multiple values in that single
object more easily. 

The .NET Framework already has generic `Tuple` classes. These classes,
however, had two major limitations. For one, the `Tuple` classes named
their fields `Item1`, `Item2`, and so on. Those names carry no semantic
information. Using these `Tuple` types does not enable communicating the
meaning of each of the fields. Another concern is that the `Tuple` classes are
reference types. Using one of the `Tuple` types means allocating objects. On hot
paths, this can have a measurable impact on your application's performance.

To avoid those deficiencies, you could create a `class` or a `struct`
to carry multiple fields. Unfortunately, that's more work for you,
and it obscures your design intent. Making a `struct` or `class` implies
that you are defining a type with both data and behavior. Many times, you
simply want to store multiple values in a single object.

The new language features for tuples, combined with a new set of
classes in the framework, address these deficiencies. These new tuples
use the new `ValueTuple` generic structs. As the name implies, this type is a `struct`
instead of a `class`. There are different versions of this struct to support
tuples with different numbers of fields. New language support provides semantic
names for the fields of the tuple type, along with features to make constructing
or accessing tuple fields easy.

The language features and the `ValueTuple` generic structs enforce the rule that
you cannot add any behavior (methods) to these tuple types.
All the `ValueTuple` types are *mutable structs*. Each member field is a
public field. That makes them very lightweight. However, that means tuples
should not be used where immutability is important.

Tuples are both simpler and more flexible data containers than `class` and
`struct` types. Let's explore those differences.

## Named and unnamed tuples

The `ValueTuple` struct has fields named `Item1`, `Item2`, `Item3` and so on,
similer to the properties defined in the existing `Tuple` types.
These names are the only names you can use for *unnamed tuples*. When you
do not provide any alternative field names to a tuple, you've created an
unnamed tuple:

[!code-csharp[UnnamedTuple](../../samples/snippets/csharp/tuples/tuples/program.cs#01_UnNamedTuple "Unnamed tuple")]

However, when you initialize a tuple, you can use new language features
that give better names to each field. Doing so creates a *named tuple*.
Named tuples still have fields named `Item1`, `Item2`, `Item3` and so on.
But they also have synonyms for any of those fields that you have named.
You create a named tuple by specifying the names for each field. One way
is to specify the names as part of the tuple initialization:

[!code-csharp[NamedTuple](../../samples/snippets/csharp/tuples/tuples/program.cs#02_NamedTuple "Named tuple")]

These synonyms are handled by the compiler and the language so that you
can use named tuples effectively. IDEs and editors can read these semantic names
using the Roslyn APIs. This enables you to reference the fields of a named
tuple by those semantic names anywhere in the same assembly. The compiler
replaces the names you've defined with `Item*` equivalents when generating
the compiled output. The compiled Microsoft Intermediate Language (MSIL)
does not include the names you've given these fields. 

The compiler must communicate those names you created for tuples that
are returned from public methods or properties. In those cases, the compiler
adds a `TupleElementNames` attribute on the method. This attribute contains
a `TransformNames` list property that contains the names given to each of
the fields in the Tuple. 

> [!NOTE]
> Development Tools, such as Visual Studio, also read that metadata,
> and provide IntelliSense and other features using the metadata
> field names.

It is important to understand these underlying fundamentals of
the new tuples and the `ValueTuple` type in order to understand
the rules for assigning named tuples to each other.

## Assignment and tuples

The language supports assignment between tuple types that have
the same number of fields and the same types for each of those
fields. Those types must be exact compile-time matches. Other
conversions are not considered for assignments. Let's look at the kinds
of assignments that are allowed between tuple types.

Consider these variables used in the following examples:

[!code-csharp[VariableCreation](../../samples/snippets/csharp/tuples/tuples/program.cs#03_VariableCreation "Variable creation")]

The first two variables, `unnamed` and `anonymous` do not have semantic
names provided for the fields. The field names are `Item1` and `Item2`.
The last two variables, `named` and `differentName` have semantic names
given for the fields. Note that these two tuples have different names
for the fields.

All four of these tuples have the same number of fields (referred to as 'arity')
and the types of those fields are identical. Therefore, all of these
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

One of the most common uses for Tuples is as a method return
value. Let's walk through one example. Consider this method
that computes the standard deviation for a sequence of numbers:

[!code-csharp[StandardDeviation](../../samples/snippets/csharp/tuples/tuples/statistics.cs#05_StandardDeviation "Compute Standard Deviation")]

> [!NOTE]
> These examples compute the uncorrected sample standard deviation.
> The corrected sample standard deviation formula would divide
> the sum of the squared differences from the mean by (N-1) instead
> of N, as the `Average` extension method does. Consult a statistics
> text for more details on the differences between these formulas
> for standard deviation.

This follows the textbook formula for the standard deviation. It produces
the correct answer, but it's a very inefficient implementation. This
method enumerates the sequence twice: Once to produce the average, and
once to produce the average of the square of the difference of the average.
(Remember that LINQ queries are evaluated lazily, so the computation of
the differences from the mean and the average of those differences makes
only one enumeration.)

There is an alternative formula that computes standard deviation using
only one enumeration of the sequence.  This computation produces two
values as it enumerates the sequence: the sum of all items in the sequence,
and the sum of the each value squared:

[!code-csharp[SumOfSquaresFormula](../../samples/snippets/csharp/tuples/tuples/statistics.cs#06_SumOfSquaresFormula "Compute Standard Deviation using the sum of squares")]

Ths version enumerates the sequence exactly once. But, it's not very
reusable code. As you keep working, you'll find that many different
statistical computations use the number of items in the sequence,
the sum of the sequence, and the sum 
of the squares of the sequence. Let's refactor this method and write
a utility method that produces all three of those values.

This is where tuples come in very useful. 

Let's update this method so the three values computed during the enumeration
are stored in a tuple. That creates this version:

[!code-csharp[TupleVersion](../../samples/snippets/csharp/tuples/tuples/statistics.cs#07_TupleVersion "Refactor to use tuples")]

Visual Studio's Refactoring suport makes it easy to extract the functionality
for the core statistics into a private method. That gives you a `private static`
method that returns the tuple type with the three values of `Sum`, `SumOfSquares`, and `Count`:

[!code-csharp[TupleMethodVersion](../../samples/snippets/csharp/tuples/tuples/statistics.cs#08_TupleMethodVersion "After extracting utility method")]
 
The language enables a couple more options that you can use, if you want
to make a few quick edits by hand. First, you can use the `var`
declaration to initialize the tuple result from the `ComputeSumAndSumOfSquares`
method call. You can also create three discrete variables inside the
`ComputeSumAndSumOfSquares` method. The final version is below:

[!code-csharp[CleanedTupleVersion](../../samples/snippets/csharp/tuples/tuples/statistics.cs#09_CleanedTupleVersion "After final cleanup")]

This final version can be used for any method that needs those three
values, or any subset of them.

The language supports other options in managing the names of the fields
in these tuple-returning methods.

You can remove the field names from the return value declaration and
return an unnamed tuple:

```csharp
private static (double, double, int) ComputeSumAndSumOfSquares(IEnumerable<double> sequence)
{
    double sum = 0;
    double sumOfSquares = 0;
    int count = 0;

    foreach (var item in sequence)
    {
        count++;
        sum += item;
        sumOfSquares += item * item;
    }

    return (sum, sumOfSquares, count);
}
```

You must address the fields of this tuple as `Item1`, `Item2`, and `Item3`.
It's recommended that you provide semantic names to the fields of tuples
returned from methods.

Another idiom where tuples can be very useful is when you are authoring
LINQ queries where the final result is a projection that contains some, but not
all, of the properties of the objects being selected.

You would traditionally project the results of the query into a sequence
of objects that were an anonymous type. That presented many limitations,
primarily because anonymous types could not conveniently be named in the
return type for a method. Alternatives using `object` or `dynamic` as the
type of the result came with significant performance costs.

Returning a sequence of a tuple type is easy, and the names and types
of the fields are available at compile time and through IDE tools.
For example, consider a ToDo application. You might define a
class similar to the following to represent a single entry in the ToDo list:

[!code-csharp[ToDoItem](../../samples/snippets/csharp/tuples/tuples/projectionsample.cs#14_ToDoItem "To Do Item")]

Your mobile applications may support a compact form of the current ToDo items
that only displays the title. That LINQ query would make a projection that
includes only the ID and the title. A method that returns a sequence of tuples
expresses that design very well:

[!code-csharp[QueryReturningTuple](../../samples/snippets/csharp/tuples/tuples/projectionsample.cs#15_QueryReturningTuple "Query returning a tuple")]

The named tuple can be part of the signature. It lets the compiler and IDE
tools provide static checking that you are using the result correctly. The
named tuple also carries the static type information so there is no need
to use expensive run time features like reflection or dynamic binding to
work with the results.

## Deconstruction

You can unpackage all the items in a tuple by *deconstructng* the tuple
returned by a method. There are two different approaches to deconstructing
tuples.  First, you can explicitly declare the type of each field inside
parentheses to create discrete variables for each of the fields in the tuple:

[!code-csharp[Deconstruct](../../samples/snippets/csharp/tuples/tuples/statistics.cs#10_Deconstruct "Deconstruct")]

You can also declare implicitly typed variables for each field in a tuple
by using the `var` keyword outside the parentheses:

[!code-csharp[DeconstructToVar](../../samples/snippets/csharp/tuples/tuples/statistics.cs#11_DeconstructToVar "Deconstruct to Var")]

It is also legal to use the `var` keyword with any, or all of the variable
declarations inside the parentheses. 

```csharp
(double sum, var sumOfSquares, var count) = ComputeSumAndSumOfSquares(sequence);
```
Note that you cannot use a specific
type outside the parentheses, even if every field in the tuple has the
same type.

### Deconstring user defined types

Any tuple type can be deconstructed as shown above. It's also easy
to enable deconstruction on any user defined type (classes, structs, or 
even interfaces).

The type author can define one or more `Deconstruct` methods that
assign values to any number of `out` variables representing the
data elements that make up the type. For example, the following
`Person` type defines a `Deconstruct` method that deconstructs
a person object into the fields representing the first name
and last name:

[!code-csharp[TypeWithDeconstructMethod](../../samples/snippets/csharp/tuples/tuples/person.cs#12_TypeWithDeconstructMethod "Type with a deconstruct method")]

The deconstruct method enables assignment from a `Person` to two strings, 
representing the `FirstName` and `LastName` properties:

[!code-csharp[Deconstruct Type](../../samples/snippets/csharp/tuples/tuples/program.cs#12A_DeconstructType "Deconstruct a class type")]

You can enable deconstruction even for types you did not author.
The `Deconstruct` method can be an extension method that unpackages
the accessible data members of an object. The example below shows
a `Student` type, derived from the `Person` type, and an extension
method that deconstructs a `Student` into three variables, representing
the `FirstName`, the `LastName` and the `GPA`:

[!code-csharp[ExtensionDeconstructMethod](../../samples/snippets/csharp/tuples/tuples/person.cs#13_ExtensionDeconstructMethod "Type with a deconstruct extension method")]

A `Student` object now has two accessible `Deconstruct` methods: the extension method
declared for `Student` types, and the member of the `Person` type. Both are in scope,
and that enables a `Student` to be deconstructed into either two variables or three.
If you assign a student to three variabless, the first name, last name, and GPA are
all returned. If you assign a student to two variables, only the first name and 
the last name are returned.

[!code-csharp[Deconstruct extension method](../../samples/snippets/csharp/tuples/tuples/program.cs#13A_DeconstructExtension "Deconstruct a class type using an extension method")]

You should be very careful defining multiple `Deconstruct` methods in a 
class or a class hierarchy. Multiple `Deconstruct` methods that have the
same number of `out` parameters can quickly cause ambiguities. Callers may
not be able to easily call the desired `Deconstruct` method.

In this example, there is minimal chance for an ambiguious call because the 
`Deconstruct` method for `Person` has two output parameters, and the `Deconstruct`
method for `Student` has three.

## Conclusion 

The new language and library support for named tuples makes it much easier
to work with designs that use data structures that store multiple fields
but do not define behavior, as classes and structs do. It's
easy and concise to use tuples for those types. You get all the benefits of
static type checking, without needing to author types using the more
verbose `class` or `struct` syntax. Even so, they are most useful for utility methods
that are `private`, or `internal`. Create user defined types, either
`class` or `struct` types when your public methods return a value
that has multiple fields.