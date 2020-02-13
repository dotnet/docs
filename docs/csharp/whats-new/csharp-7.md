---
title: What's New in C# 7.0 - C# Guide
description: Get an overview of the new features in version 7.0 of the C# language.
ms.date: 02/20/2019
ms.assetid: fd41596d-d0c2-4816-b94d-c4d00a5d0243
---

# What's new in C# 7.0

C# 7.0 adds a number of new features to the C# language:

- [`out` variables](#out-variables)
  - You can declare `out` values inline as arguments to the method where they're used.
- [Tuples](#tuples)
  - You can create lightweight, unnamed types that contain multiple public fields. Compilers and IDE tools understand the semantics of these types.
- [Discards](#discards)
  - Discards are temporary, write-only variables used in assignments when you don't care about the value assigned. They're most useful when deconstructing tuples and user-defined types, as well as when calling methods with `out` parameters.
- [Pattern Matching](#pattern-matching)
  - You can create branching logic based on arbitrary types and values of the members of those types.
- [`ref` locals and returns](#ref-locals-and-returns)
  - Method local variables and return values can be references to other storage.
- [Local Functions](#local-functions)
  - You can nest functions inside other functions to limit their scope and visibility.
- [More expression-bodied members](#more-expression-bodied-members)
  - The list of members that can be authored using expressions has grown.
- [`throw` Expressions](#throw-expressions)
  - You can throw exceptions in code constructs that previously weren't allowed because `throw` was a statement.
- [Generalized async return types](#generalized-async-return-types)
  - Methods declared with the `async` modifier can return other types in addition to `Task` and `Task<T>`.
- [Numeric literal syntax improvements](#numeric-literal-syntax-improvements)
  - New tokens improve readability for numeric constants.

The remainder of this article provides an overview of each feature. For each feature,
you'll learn the reasoning behind it. You'll learn the syntax. You can explore these features in your environment using the `dotnet try` global tool:

1. Install the [dotnet-try](https://github.com/dotnet/try/blob/master/README.md#setup) global tool.
1. Clone the [dotnet/try-samples](https://github.com/dotnet/try-samples) repository.
1. Set the current directory to the *csharp7* subdirectory for the *try-samples* repository.
1. Run `dotnet try`.

## `out` variables

The existing syntax that supports `out` parameters has been improved
in this version. You can now declare `out` variables in the argument list of a method call,
rather than writing a separate declaration statement:

[!code-csharp[OutVariableDeclarations](~/samples/snippets/csharp/new-in-7/program.cs#OutVariableDeclarations "Out variable declarations")]

You may want to specify the type of the `out` variable for clarity,
as shown above. However, the language does support using an implicitly
typed local variable:

[!code-csharp[OutVarVariableDeclarations](~/samples/snippets/csharp/new-in-7/program.cs#OutVarVariableDeclarations "Implicitly typed Out variable")]

- The code is easier to read.
  - You declare the out variable where you use it, not on another line above.
- No need to assign an initial value.
  - By declaring the `out` variable where it's used in a method call, you can't accidentally use it before it is assigned.

## Tuples

C# provides a rich syntax for classes and structs that is used to explain
your design intent. But sometimes that rich syntax requires extra
work with minimal benefit. You may often write methods that need a simple
structure containing more than one data element. To support these scenarios
*tuples* were added to C#. Tuples are lightweight data structures
that contain multiple fields to represent the data members.
The fields aren't validated, and you can't define your own methods

> [!NOTE]
> Tuples were available before C# 7.0,
> but they were inefficient and had no language support.
> This meant that tuple elements could only be referenced as
> `Item1`, `Item2` and so on. C# 7.0 introduces language support for tuples,
> which enables semantic names for the fields of a tuple using new,
> more efficient tuple types.

You can create a tuple by assigning a value to each member, and optionally providing semantic
names to each of the members of the tuple:

[!code-csharp[NamedTuple](~/samples/snippets/csharp/new-in-7/program.cs#NamedTuple "Named tuple")]

The `namedLetters` tuple contains fields referred to as `Alpha` and
`Beta`. Those names exist only at compile time and aren't preserved,
for example when inspecting the tuple using reflection at runtime.

In a tuple assignment, you can also specify the names of the fields
on the right-hand side of the assignment:

[!code-csharp[ImplicitNamedTuple](~/samples/snippets/csharp/new-in-7/program.cs#ImplicitNamedTuple "Implicitly named tuple")]

There may be times when you want to unpackage the members of a tuple that
were returned from a method.  You can do that by declaring separate variables
for each of the values in the tuple. This unpackaging is called *deconstructing* the tuple:

[!code-csharp[CallingWithDeconstructor](~/samples/snippets/csharp/new-in-7/program.cs#CallingWithDeconstructor "Deconstructing a tuple")]

You can also provide a similar deconstruction for any type in .NET. You write a `Deconstruct` method as a member of the class. That
`Deconstruct` method provides a set of `out` arguments for each of the
properties you want to extract. Consider
this `Point` class that provides a deconstructor method that extracts
the `X` and `Y` coordinates:

[!code-csharp[PointWithDeconstruction](~/samples/snippets/csharp/new-in-7/point.cs#PointWithDeconstruction "Point with deconstruction method")]

You can extract the individual fields by assigning a `Point` to a tuple:

[!code-csharp[DeconstructPoint](~/samples/snippets/csharp/new-in-7/program.cs#DeconstructPoint "Deconstruct a point")]

You can learn more in depth about tuples in the
[tuples article](../tuples.md).

## Discards

Often when deconstructing a tuple or calling a method with `out` parameters, you're forced to define a variable whose value you don't care about and don't intend to use. C# adds support for *discards* to handle this scenario. A discard is a write-only variable whose name is `_` (the underscore character); you can assign all of the values that you intend to discard to the single variable. A discard is like an unassigned variable; apart from the assignment statement, the discard can't be used in code.

Discards are supported in the following scenarios:

- When deconstructing tuples or user-defined types.
- When calling methods with [out](../language-reference/keywords/out-parameter-modifier.md) parameters.
- In a pattern matching operation with the [is](../language-reference/keywords/is.md) and [switch](../language-reference/keywords/switch.md) statements.
- As a standalone identifier when you want to explicitly identify the value of an assignment as a discard.

The following example defines a `QueryCityDataForYears` method that returns a 6-tuple that contains data for a city for two different years. The method call in the example is concerned only with the two population values returned by the method and so treats the remaining values in the tuple as discards when it deconstructs the tuple.

[!code-csharp[Tuple-discard](~/samples/snippets/csharp/programming-guide/deconstructing-tuples/discard-tuple1.cs)]

For more information, see [Discards](../discards.md).

## Pattern matching

*Pattern matching* is a feature that allows you to implement method dispatch on
properties other than the type of an object. You're probably already familiar
with method dispatch based on the type of an object. In object-oriented programming,
virtual and override methods provide language syntax to implement method dispatching
based on an object's type. Base and Derived classes provide different implementations.
Pattern matching expressions extend this concept so that you can easily
implement similar dispatch patterns for types and data elements that aren't
related through an inheritance hierarchy.

Pattern matching supports `is` expressions and `switch` expressions. Each
enables inspecting an object and its properties to determine if that object
satisfies the sought pattern. You use the `when` keyword to specify additional
rules to the pattern.

The `is` pattern expression extends the familiar [`is` operator](../language-reference/keywords/is.md#pattern-matching-with-is) to query an object about its type and assign the result in one instruction. The following code checks if a variable is an `int`, and if so, adds it to the current sum:

```csharp
if (input is int count)
    sum += count;
```

The preceding small example demonstrates the enhancements to the `is` expression. You can test against value types as well as reference types, and you can assign the successful result to a new variable of the correct type.

The switch match expression has a familiar syntax, based on the `switch`
statement already part of the C# language. The updated switch statement has several new constructs:

- The governing type of a `switch` expression is no longer restricted to integral types, `Enum` types, `string`, or a nullable type corresponding to one of those types. Any type may be used.
- You can test the type of the `switch` expression in each `case` label. As with the `is` expression, you may assign a new variable to that type.
- You may add a `when` clause to further test conditions on that variable.
- The order of `case` labels is now important. The first branch to match is executed; others are skipped.

The following code demonstrates these new features:

```csharp
public static int SumPositiveNumbers(IEnumerable<object> sequence)
{
    int sum = 0;
    foreach (var i in sequence)
    {
        switch (i)
        {
            case 0:
                break;
            case IEnumerable<int> childSequence:
            {
                foreach(var item in childSequence)
                    sum += (item > 0) ? item : 0;
                break;
            }
            case int n when n > 0:
                sum += n;
                break;
            case null:
                throw new NullReferenceException("Null found in sequence");
            default:
                throw new InvalidOperationException("Unrecognized type");
        }
    }
    return sum;
}
```

- `case 0:` is the familiar constant pattern.
- `case IEnumerable<int> childSequence:` is a type pattern.
- `case int n when n > 0:` is a type pattern with an additional `when` condition.
- `case null:` is the null pattern.
- `default:` is the familiar default case.

You can learn more about pattern matching in
[Pattern Matching in C#](../pattern-matching.md).

## Ref locals and returns

This feature enables algorithms that use and return references
to variables defined elsewhere. One example is working with
large matrices, and finding a single location with certain
characteristics. The following method returns a **reference** to that storage in the matrix:

[!code-csharp[FindReturningRef](~/samples/snippets/csharp/new-in-7/MatrixSearch.cs#FindReturningRef "Find returning by reference")]

You can declare the return value as a `ref` and modify that value in the matrix, as shown in the following code:

[!code-csharp[AssignRefReturn](~/samples/snippets/csharp/new-in-7/Program.cs#AssignRefReturn "Assign ref return")]

The C# language has several rules that protect you from misusing
the `ref` locals and returns:

- You must add the `ref` keyword to the method signature and to all `return` statements in a method.
  - That makes it clear the method returns by reference throughout the method.
- A `ref return` may be assigned to a value variable, or a `ref` variable.
  - The caller controls whether the return value is copied or not. Omitting the `ref` modifier when assigning the return value indicates that the caller wants a copy of the value, not a reference to the storage.
- You can't assign a standard method return value to a `ref` local variable.
  - That disallows statements like `ref int i = sequence.Count();`
- You can't return a `ref` to a variable whose lifetime doesn't extend beyond the execution of the method.
  - That means you can't return a reference to a local variable or a variable with a similar scope.
- `ref` locals and returns can't be used with async methods.
  - The compiler can't know if the referenced variable has been set to its final value when the async method returns.

The addition of ref locals and ref returns enables algorithms that are more
efficient by avoiding copying values, or performing dereferencing operations
multiple times.

Adding `ref` to the return value is a [source compatible change](version-update-considerations.md#source-compatible-changes). Existing code compiles, but the ref return value is copied when assigned. Callers must update the storage for the return value to a `ref` local variable to store the return as a reference.

For more information, see the [ref keyword](../language-reference/keywords/ref.md) article.

## Local functions

Many designs for classes include methods that are called from only
one location. These additional private methods keep each method small
and focused. *Local functions* enable you to declare methods
inside the context of another method. Local functions make it easier for readers
of the class to see that the local method is only called from the context
in which it is declared.

There are two common use cases for local functions: public iterator
methods and public async methods. Both types of methods generate
code that reports errors later than programmers might expect. In
iterator methods, any exceptions are observed only
when calling code that enumerates the returned sequence. In
async methods, any exceptions are only observed when the returned
`Task` is awaited. The following example demonstrates separating parameter validation from the iterator implementation using a local function:

[!code-csharp[22_IteratorMethodLocal](~/samples/snippets/csharp/new-in-7/Iterator.cs#IteratorMethodLocal "Iterator method with local function")]

The same technique can be employed with `async` methods to ensure that
exceptions arising from argument validation are thrown before the asynchronous
work begins:

[!code-csharp[TaskExample](~/samples/snippets/csharp/new-in-7/AsyncWork.cs#TaskExample "Task returning method with local function")]

> [!NOTE]
> Some of the designs that are supported by local functions
> could also be accomplished using *lambda expressions*. For more information, see [Local functions vs. lambda expressions](../local-functions-vs-lambdas.md).

## More expression-bodied members

C# 6 introduced [expression-bodied members](csharp-6.md#expression-bodied-function-members)
for member functions, and read-only properties. C# 7.0 expands the allowed
members that can be implemented as expressions. In C# 7.0, you can implement
*constructors*, *finalizers*, and `get` and `set` accessors on *properties*
and *indexers*. The following code shows examples of each:

[!code-csharp[ExpressionBodiedMembers](~/samples/snippets/csharp/new-in-7/expressionmembers.cs#ExpressionBodiedEverything "new expression-bodied members")]

> [!NOTE]
> This example does not need a finalizer, but it is shown
> to demonstrate the syntax. You should not implement a
> finalizer in your class unless it is necessary to  release
> unmanaged resources. You should also consider using the
> <xref:System.Runtime.InteropServices.SafeHandle> class instead
> of managing unmanaged resources directly.

These new locations for expression-bodied members represent
an important milestone for the C# language: These features
were implemented by community members working on the open-source
[Roslyn](https://github.com/dotnet/Roslyn) project.

Changing a method to an expression bodied member is a [binary compatible change](version-update-considerations.md#binary-compatible-changes).

## Throw expressions

In C#, `throw` has always been a statement. Because `throw` is a statement,
not an expression, there were C# constructs where you couldn't use it. These
included conditional expressions, null coalescing expressions, and some lambda
expressions. The addition of expression-bodied members adds more locations
where `throw` expressions would be useful. So that you can write any of these
constructs, C# 7.0 introduces [*throw expressions*](../language-reference/keywords/throw.md#the-throw-expression).

This addition makes it easier to write more expression-based code. You don't need additional statements for error checking.

## Generalized async return types

Returning a `Task` object from async methods can introduce
performance bottlenecks in certain paths. `Task` is a reference
type, so using it means allocating an object. In cases where a
method declared with the `async` modifier returns a cached result, or
completes synchronously, the extra allocations can become a significant
time cost in performance critical sections of code. It can become
costly if those allocations occur in tight loops.

The new language feature means that async method return types aren't limited to `Task`, `Task<T>`, and `void`. The returned type
must still satisfy the async pattern, meaning a `GetAwaiter` method
must be accessible. As one concrete example, the `ValueTask` type
has been added to the .NET framework to make use of this new language
feature:

[!code-csharp[UsingValueTask](~/samples/snippets/csharp/new-in-7/AsyncWork.cs#UsingValueTask "Using ValueTask")]

> [!NOTE]
> You need to add the NuGet package [`System.Threading.Tasks.Extensions`](https://www.nuget.org/packages/System.Threading.Tasks.Extensions/)
> in order to use the <xref:System.Threading.Tasks.ValueTask%601> type.

This enhancement is most useful for library authors to avoid allocating a `Task` in performance critical code.

## Numeric literal syntax improvements

Misreading numeric constants can make it harder to understand
code when reading it for the first time. Bit masks or other symbolic
values are prone to misunderstanding. C# 7.0 includes two new features to write numbers in the most readable fashion
for the intended use: *binary literals*, and *digit separators*.

For those times when you're creating bit masks, or whenever a
binary representation of a number makes the most readable code,
write that number in binary:

[!code-csharp[ThousandSeparators](~/samples/snippets/csharp/new-in-7/Program.cs#ThousandSeparators "Thousands separators")]

The `0b` at the beginning of the constant indicates that the
number is written as a binary number. Binary numbers can get long, so it's often easier to see
the bit patterns by introducing the `_` as a digit separator, as shown above in the binary constant. The digit separator can appear anywhere in the constant. For base 10
numbers, it is common to use it as a thousands separator:

[!code-csharp[LargeIntegers](~/samples/snippets/csharp/new-in-7/Program.cs#LargeIntegers "Large integer")]

The digit separator can be used with `decimal`, `float`, and `double`
types as well:

[!code-csharp[OtherConstants](~/samples/snippets/csharp/new-in-7/Program.cs#OtherConstants "non-integral constants")]

Taken together, you can declare numeric constants with much more
readability.
