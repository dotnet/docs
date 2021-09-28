---
title: What's New in C# 7.0 - C# Guide
description: Get an overview of the new features in version 7.0 of the C# language.
ms.date: 10/02/2020
ms.assetid: fd41596d-d0c2-4816-b94d-c4d00a5d0243
---

# What's new in C# 7.0 through C# 7.3

C# 7.0 through C# 7.3 brought a number of features and incremental improvements to your development experience with C#. This article provides an overview of the new language features and compiler options. The descriptions describe the behavior for C# 7.3, which is the most recent version supported for .NET Framework-based applications.

The [language version selection](../language-reference/configure-language-version.md) configuration element was added with C# 7.1, which enables you to specify the compiler language version in your project file.

C# 7.0-7.3 adds these features and themes to the C# language:

- [Tuples and discards](#tuples-and-discards)
  - You can create lightweight, unnamed types that contain multiple public fields. Compilers and IDE tools understand the semantics of these types.
  - Discards are temporary, write-only variables used in assignments when you don't care about the value assigned. They're most useful when deconstructing tuples and user-defined types, as well as when calling methods with `out` parameters.
- [Pattern Matching](#pattern-matching)
  - You can create branching logic based on arbitrary types and values of the members of those types.
- [`async` `Main` method](#async-main)
  - The entry point for an application can have the `async` modifier.
- [Local Functions](#local-functions)
  - You can nest functions inside other functions to limit their scope and visibility.
- [More expression-bodied members](#more-expression-bodied-members)
  - The list of members that can be authored using expressions has grown.
- [`throw` Expressions](#throw-expressions)
  - You can throw exceptions in code constructs that previously weren't allowed because `throw` was a statement.
- [`default` literal expressions](#default-literal-expressions)
  - You can use default literal expressions in default value expressions when the target type can be inferred.
- [Numeric literal syntax improvements](#numeric-literal-syntax-improvements)
  - New tokens improve readability for numeric constants.
- [`out` variables](#out-variables)
  - You can declare `out` values inline as arguments to the method where they're used.
- [Non-trailing named arguments](#non-trailing-named-arguments)
  - Named arguments can be followed by positional arguments.
- [`private protected` access modifier](#private-protected-access-modifier)
  - The `private protected` access modifier enables access for derived classes in the same assembly.
- [Improved overload resolution](#improved-overload-candidates)
  - New rules to resolve overload resolution ambiguity.
- [Techniques for writing safe efficient code](#enabling-more-efficient-safe-code)
  - A combination of syntax improvements that enable working with value types using reference semantics.

Finally, the compiler has new options:

- `-refout` and `-refonly` that control [reference assembly generation](#reference-assembly-generation).
- `-publicsign` to enable Open Source Software (OSS) signing of assemblies.
- `-pathmap` to provide a mapping for source directories.

The remainder of this article provides an overview of each feature. For each feature, you'll learn the reasoning behind it and the syntax. You can explore these features in your environment using the `dotnet try` global tool:

1. Install the [dotnet-try](https://github.com/dotnet/try/blob/main/DotNetTryLocal.md) global tool.
1. Clone the [dotnet/try-samples](https://github.com/dotnet/try-samples) repository.
1. Set the current directory to the *csharp7* subdirectory for the *try-samples* repository.
1. Run `dotnet try`.

## Tuples and discards

C# provides a rich syntax for classes and structs that is used to explain your design intent. But sometimes that rich syntax requires extra work with minimal benefit. You may often write methods that need a simple structure containing more than one data element. To support these scenarios *tuples* were added to C#. Tuples are lightweight data structures
that contain multiple fields to represent the data members. The fields aren't validated, and you can't define your own methods. C# tuple types support `==` and `!=`. For more information.

> [!NOTE]
> Tuples were available before C# 7.0, but they were inefficient and had no language support. This meant that tuple elements could only be referenced as `Item1`, `Item2` and so on. C# 7.0 introduces language support for tuples, which enables semantic names for the fields of a tuple using new, more efficient tuple types.

You can create a tuple by assigning a value to each member, and optionally providing semantic names to each of the members of the tuple:

[!code-csharp[NamedTuple](~/samples/snippets/csharp/new-in-7/program.cs#NamedTuple "Named tuple")]

The `namedLetters` tuple contains fields referred to as `Alpha` and `Beta`. Those names exist only at compile time and aren't preserved, for example when inspecting the tuple using reflection at run time.

In a tuple assignment, you can also specify the names of the fields on the right-hand side of the assignment:

[!code-csharp[ImplicitNamedTuple](~/samples/snippets/csharp/new-in-7/program.cs#ImplicitNamedTuple "Implicitly named tuple")]

There may be times when you want to unpackage the members of a tuple that were returned from a method.  You can do that by declaring separate variables for each of the values in the tuple. This unpackaging is called *deconstructing* the tuple:

[!code-csharp[CallingWithDeconstructor](~/samples/snippets/csharp/new-in-7/program.cs#CallingWithDeconstructor "Deconstructing a tuple")]

You can also provide a similar deconstruction for any type in .NET. You write a `Deconstruct` method as a member of the class. That `Deconstruct` method provides a set of `out` arguments for each of the properties you want to extract. Consider this `Point` class that provides a deconstructor method that extracts the `X` and `Y` coordinates:

[!code-csharp[PointWithDeconstruction](~/samples/snippets/csharp/new-in-7/point.cs#PointWithDeconstruction "Point with deconstruction method")]

You can extract the individual fields by assigning a `Point` to a tuple:

[!code-csharp[DeconstructPoint](~/samples/snippets/csharp/new-in-7/program.cs#DeconstructPoint "Deconstruct a point")]

Many times when you initialize a tuple, the variables used for the right side of the assignment are the same as the names you'd like for the tuple elements: The names of tuple elements can be inferred from the variables used to initialize the tuple:

```csharp
int count = 5;
string label = "Colors used in the map";
var pair = (count, label); // element names are "count" and "label"
```

You can learn more about this feature in the [Tuple types](../language-reference/builtin-types/value-tuples.md) article.

Often when deconstructing a tuple or calling a method with `out` parameters, you're forced to define a variable whose value you don't care about and don't intend to use. C# adds support for *discards* to handle this scenario. A discard is a write-only variable whose name is `_` (the underscore character); you can assign all of the values that you intend to discard to the single variable. A discard is like an unassigned variable; apart from the assignment statement, the discard can't be used in code.

Discards are supported in the following scenarios:

- When deconstructing tuples or user-defined types.
- When calling methods with [out](../language-reference/keywords/out-parameter-modifier.md) parameters.
- In a pattern matching operation with the [`is` operator](../language-reference/operators/is.md) and [`switch` statement](../language-reference/statements/selection-statements.md#the-switch-statement).
- As a standalone identifier when you want to explicitly identify the value of an assignment as a discard.

The following example defines a `QueryCityData` method that returns a 3-tuple that contains data for a city for two different years. The method call in the example is concerned only with the two population values returned by the method and so treats the remaining values in the tuple as discards when it deconstructs the tuple.

```csharp
using System;

public class Example
{
    public static void Main()
    {
        var (_, pop, _) = QueryCityData("New York City");

         // Do something with the data.
    }

    private static (string name, int pop, double size) QueryCityData(string name)
    {
        if (name == "New York City")
            return (name, 8175133, 468.48);

        return ("", 0, 0);
    }
}
```

For more information, see [Discards](../fundamentals/functional/discards.md).

## Pattern matching

*Pattern matching* is a set of features that enable new ways to express control flow in your code. You can test variables for their type, values or the values of their properties. These techniques create more readable code flow.

Pattern matching supports `is` expressions and `switch` expressions. Each enables inspecting an object and its properties to determine if that object satisfies the sought pattern. You use the `when` keyword to specify additional rules to the pattern.

The `is` pattern expression extends the familiar [`is` operator](../language-reference/operators/is.md) to query an object about its type and assign the result in one instruction. The following code checks if a variable is an `int`, and if so, adds it to the current sum:

```csharp
if (input is int count)
    sum += count;
```

The preceding small example demonstrates the enhancements to the `is` expression. You can test against value types as well as reference types, and you can assign the successful result to a new variable of the correct type.

The switch match expression has a familiar syntax, based on the `switch` statement already part of the C# language. The updated switch statement has several new constructs:

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

- `case 0:` is a [constant pattern](../language-reference/operators/patterns.md#constant-pattern).
- `case IEnumerable<int> childSequence:` is a [declaration pattern](../language-reference/operators/patterns.md#declaration-and-type-patterns).
- `case int n when n > 0:` is a declaration pattern with an additional `when` condition.
- `case null:` is the `null` constant pattern.
- `default:` is the familiar default case.

Beginning with C# 7.1, the pattern expression for `is` and the `switch` type pattern may have the type of a generic type parameter. This can be most useful when checking types that may be either `struct` or `class` types, and you want to avoid boxing.

You can learn more about pattern matching in [Pattern Matching in C#](../fundamentals/functional/pattern-matching.md).

## Async main

An *async main* method enables you to use `await` in your `Main` method. Previously you would need to write:

```csharp
static int Main()
{
    return DoAsyncWork().GetAwaiter().GetResult();
}
```

You can now write:

```csharp
static async Task<int> Main()
{
    // This could also be replaced with the body
    // DoAsyncWork, including its await expressions:
    return await DoAsyncWork();
}
```

If your program doesn't return an exit code, you can declare a `Main` method
that returns a <xref:System.Threading.Tasks.Task>:

```csharp
static async Task Main()
{
    await SomeAsyncMethod();
}
```

You can read more about the details in the [async main](../fundamentals/program-structure/main-command-line.md) article in the programming guide.

## Local functions

Many designs for classes include methods that are called from only one location. These additional private methods keep each method small and focused. *Local functions* enable you to declare methods inside the context of another method. Local functions make it easier for readers of the class to see that the local method is only called from the context in which it is declared.

There are two common use cases for local functions: public iterator methods and public async methods. Both types of methods generate code that reports errors later than programmers might expect. In iterator methods, any exceptions are observed only when calling code that enumerates the returned sequence. In async methods, any exceptions are only observed when the returned `Task` is awaited. The following example demonstrates separating parameter validation from the iterator implementation using a local function:

[!code-csharp[22_IteratorMethodLocal](~/samples/snippets/csharp/new-in-7/Iterator.cs#IteratorMethodLocal "Iterator method with local function")]

The same technique can be employed with `async` methods to ensure that exceptions arising from argument validation are thrown before the asynchronous work begins:

[!code-csharp[TaskExample](~/samples/snippets/csharp/new-in-7/AsyncWork.cs#TaskExample "Task returning method with local function")]

This syntax is now supported:

```csharp
[field: SomeThingAboutFieldAttribute]
public int SomeProperty { get; set; }
```

The attribute `SomeThingAboutFieldAttribute` is applied to the compiler generated backing field for `SomeProperty`. For more information, see [attributes](../programming-guide/concepts/attributes/index.md) in the C# programming guide.

> [!NOTE]
> Some of the designs that are supported by local functions can also be accomplished using *lambda expressions*. For more information, see [Local functions vs. lambda expressions](../programming-guide/classes-and-structs/local-functions.md#local-functions-vs-lambda-expressions).

## More expression-bodied members

C# 6 introduced expression-bodied members for member functions and read-only properties. C# 7.0 expands the allowed members that can be implemented as expressions. In C# 7.0, you can implement *constructors*, *finalizers*, and `get` and `set` accessors on *properties* and *indexers*. The following code shows examples of each:

[!code-csharp[ExpressionBodiedMembers](~/samples/snippets/csharp/new-in-7/expressionmembers.cs#ExpressionBodiedEverything "new expression-bodied members")]

> [!NOTE]
> This example does not need a finalizer, but it is shown to demonstrate the syntax. You should not implement a finalizer in your class unless it is necessary to  release unmanaged resources. You should also consider using the <xref:System.Runtime.InteropServices.SafeHandle> class instead of managing unmanaged resources directly.

These new locations for expression-bodied members represent an important milestone for the C# language: These features were implemented by community members working on the open-source
[Roslyn](https://github.com/dotnet/Roslyn) project.

Changing a method to an expression bodied member is a [binary compatible change](version-update-considerations.md#binary-compatible-changes).

## Throw expressions

In C#, `throw` has always been a statement. Because `throw` is a statement, not an expression, there were C# constructs where you couldn't use it. These included conditional expressions, null coalescing expressions, and some lambda expressions. The addition of expression-bodied members adds more locations where `throw` expressions would be useful. So that you can write any of these constructs, C# 7.0 introduces [*throw expressions*](../language-reference/keywords/throw.md#the-throw-expression).

This addition makes it easier to write more expression-based code. You don't need additional statements for error checking.

## Default literal expressions

Default literal expressions are an enhancement to default value expressions. These expressions initialize a variable to the default value. Where you previously
would write:

```csharp
Func<string, bool> whereClause = default(Func<string, bool>);
```

You can now omit the type on the right-hand side of the initialization:

```csharp
Func<string, bool> whereClause = default;
```

For more information, see the [default literal](../language-reference/operators/default.md#default-literal) section of the [default operator](../language-reference/operators/default.md) article.

## Numeric literal syntax improvements

Misreading numeric constants can make it harder to understand code when reading it for the first time. Bit masks or other symbolic values are prone to misunderstanding. C# 7.0 includes two new features to write numbers in the most readable fashion for the intended use: *binary literals*, and *digit separators*.

For those times when you're creating bit masks, or whenever a binary representation of a number makes the most readable code, write that number in binary:

[!code-csharp[ThousandSeparators](~/samples/snippets/csharp/new-in-7/Program.cs#ThousandSeparators "Thousands separators")]

The `0b` at the beginning of the constant indicates that the number is written as a binary number. Binary numbers can get long, so it's often easier to see the bit patterns by introducing the `_` as a digit separator, as shown in the binary constant in the preceding example. The digit separator can appear anywhere in the constant. For base 10 numbers, it is common to use it as a thousands separator. Hex and binary numeric literals may begin with an `_`:

[!code-csharp[LargeIntegers](~/samples/snippets/csharp/new-in-7/Program.cs#LargeIntegers "Large integer")]

The digit separator can be used with `decimal`, `float`, and `double` types as well:

[!code-csharp[OtherConstants](~/samples/snippets/csharp/new-in-7/Program.cs#OtherConstants "non-integral constants")]

Taken together, you can declare numeric constants with much more readability.

## `out` variables

The existing syntax that supports `out` parameters has been improved in C# 7. You can now declare `out` variables in the argument list of a method call, rather than writing a separate declaration statement:

[!code-csharp[OutVariableDeclarations](~/samples/snippets/csharp/new-in-7/program.cs#OutVariableDeclarations "Out variable declarations")]

You may want to specify the type of the `out` variable for clarity, as shown in the preceding example. However, the language does support using an implicitly typed local variable:

[!code-csharp[OutVarVariableDeclarations](~/samples/snippets/csharp/new-in-7/program.cs#OutVarVariableDeclarations "Implicitly typed Out variable")]

- The code is easier to read.
  - You declare the out variable where you use it, not on a preceding line of code.
- No need to assign an initial value.
  - By declaring the `out` variable where it's used in a method call, you can't accidentally use it before it is assigned.

The syntax added in C# 7.0 to allow `out` variable declarations has been extended to include field initializers, property initializers, constructor initializers, and query clauses. It enables code such as the following example:

```csharp
public class B
{
   public B(int i, out int j)
   {
      j = i;
   }
}

public class D : B
{
   public D(int i) : base(i, out var j)
   {
      Console.WriteLine($"The value of 'j' is {j}");
   }
}
```

## Non-trailing named arguments

Method calls may now use named arguments that precede positional arguments when those named arguments are in the correct positions. For more information, see [Named and optional arguments](../programming-guide/classes-and-structs/named-and-optional-arguments.md).

## *private protected* access modifier

A new compound access modifier: `private protected` indicates that a member may be accessed by containing class or derived classes that are declared in the same assembly. While `protected internal` allows access by derived classes or classes that are in the same assembly, `private protected` limits access to derived types declared in the same assembly.

For more information, see [access modifiers](../language-reference/keywords/access-modifiers.md) in the language reference.

## Improved overload candidates

In every release, the overload resolution rules get updated to address situations where ambiguous method invocations have an "obvious" choice. This release adds three new rules to help the compiler pick the obvious choice:

1. When a method group contains both instance and static members, the compiler discards the instance members if the method was invoked without an instance receiver or context. The compiler discards the static members if the method was invoked with an instance receiver. When there is no receiver, the compiler includes only static members in a static context, otherwise both static and instance members. When the receiver is ambiguously an instance or type, the compiler includes both. A static context, where an implicit `this` instance receiver cannot be used, includes the body of members where no `this` is defined, such as static members, as well as places where `this` cannot be used, such as field initializers and constructor-initializers.
1. When a method group contains some generic methods whose type arguments do not satisfy their constraints, these members are removed from the candidate set.
1. For a method group conversion, candidate methods whose return type doesn't match up with the delegate's return type are removed from the set.

You'll only notice this change because you'll find fewer compiler errors for ambiguous method overloads when you are sure which method is better.

## Enabling more efficient safe code

You should be able to write C# code safely that performs as well as unsafe code. Safe code avoids classes of errors, such as buffer overruns, stray pointers, and other memory access errors. These new features expand the capabilities of verifiable safe code. Strive to write more of your code using safe constructs. These features make that easier.

The following new features support the theme of better performance for safe code:

- You can access fixed fields without pinning.
- You can reassign `ref` local variables.
- You can use initializers on `stackalloc` arrays.
- You can use `fixed` statements with any type that supports a pattern.
- You can use additional generic constraints.
- The `in` modifier on parameters, to specify that an argument is passed by reference but not modified by the called method. Adding the `in` modifier to an argument is a [source compatible change](version-update-considerations.md#source-compatible-changes).
- The `ref readonly` modifier on method returns, to indicate that a method returns its value by reference but doesn't allow writes to that object. Adding the `ref readonly` modifier is a [source compatible change](version-update-considerations.md#source-compatible-changes), if the return is assigned to a value. Adding the `readonly` modifier to an existing `ref` return statement is an [incompatible change](version-update-considerations.md#incompatible-changes). It requires callers to update the declaration of `ref` local variables to include the `readonly` modifier.
- The `readonly struct` declaration, to indicate that a struct is immutable and should be passed as an `in` parameter to its member methods. Adding the `readonly` modifier to an existing struct declaration is a [binary compatible change](version-update-considerations.md#binary-compatible-changes).
- The `ref struct` declaration, to indicate that a struct type accesses managed memory directly and must always be stack allocated. Adding the `ref` modifier to an existing `struct` declaration is an [incompatible change](version-update-considerations.md#incompatible-changes). A `ref struct` cannot be a member of a class or used in other locations where it may be allocated on the heap.

You can read more about all these changes in [Write safe efficient code](../write-safe-efficient-code.md).

### Ref locals and returns

This feature enables algorithms that use and return references to variables defined elsewhere. One example is working with large matrices, and finding a single location with certain characteristics. The following method returns a **reference** to that storage in the matrix:

[!code-csharp[FindReturningRef](~/samples/snippets/csharp/new-in-7/MatrixSearch.cs#FindReturningRef "Find returning by reference")]

You can declare the return value as a `ref` and modify that value in the matrix, as shown in the following code:

[!code-csharp[AssignRefReturn](~/samples/snippets/csharp/new-in-7/Program.cs#AssignRefReturn "Assign ref return")]

The C# language has several rules that protect you from misusing the `ref` locals and returns:

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

The addition of ref locals and ref returns enables algorithms that are more efficient by avoiding copying values, or performing dereferencing operations multiple times.

Adding `ref` to the return value is a [source compatible change](version-update-considerations.md#source-compatible-changes). Existing code compiles, but the ref return value is copied when assigned. Callers must update the storage for the return value to a `ref` local variable to store the return as a reference.

Now, `ref` locals may be reassigned to refer to different instances after being initialized. The following code now compiles:

```csharp
ref VeryLargeStruct refLocal = ref veryLargeStruct; // initialization
refLocal = ref anotherVeryLargeStruct; // reassigned, refLocal refers to different storage.
```

For more information, see the article on [`ref` returns and `ref` locals](../programming-guide/classes-and-structs/ref-returns.md), and the article on [`foreach`](../language-reference/statements/iteration-statements.md#the-foreach-statement).

For more information, see the [ref keyword](../language-reference/keywords/ref.md) article.

### Conditional `ref` expressions

Finally, the conditional expression may produce a ref result instead of a value result. For example, you would write the following to retrieve a reference to the first element in one of two arrays:

```csharp
ref var r = ref (arr != null ? ref arr[0] : ref otherArr[0]);
```

The variable `r` is a reference to the first value in either `arr` or `otherArr`.

For more information, see [conditional operator (?:)](../language-reference/operators/conditional-operator.md) in the language reference.

### `in` parameter modifier

The `in` keyword complements the existing ref and out keywords to pass arguments by reference. The `in` keyword specifies passing the argument by reference, but the called method doesn't modify the value.

You may declare overloads that pass by value or by readonly reference, as shown in the following code:

```csharp
static void M(S arg);
static void M(in S arg);
```

The by value (first in the preceding example) overload is better than the by readonly reference version. To call the version with the readonly reference argument, you must include the `in` modifier when calling the method.

For more information, see the article on the [`in` parameter modifier](../language-reference/keywords/in-parameter-modifier.md).

### More types support the `fixed` statement

The `fixed` statement supported a limited set of types. Starting with C# 7.3, any type that contains a `GetPinnableReference()` method that returns a `ref T` or `ref readonly T` may be `fixed`. Adding this feature means that `fixed` can be used with <xref:System.Span%601?displayProperty=nameWithType> and related types.

For more information, see the [`fixed` statement](../language-reference/keywords/fixed-statement.md) article in the language reference.

### Indexing `fixed` fields does not require pinning

Consider this struct:

```csharp
unsafe struct S
{
    public fixed int myFixedField[10];
}
```

In earlier versions of C#, you needed to pin a variable to access one of the integers that are part of `myFixedField`. Now, the following code compiles without pinning the variable `p` inside a separate `fixed` statement:

```csharp
class C
{
    static S s = new S();

    unsafe public void M()
    {
        int p = s.myFixedField[5];
    }
}
```

The variable `p` accesses one element in `myFixedField`. You don't need to declare a separate `int*` variable. You still need an `unsafe` context. In earlier versions of C#, you need to declare a second fixed pointer:

```csharp
class C
{
    static S s = new S();

    unsafe public void M()
    {
        fixed (int* ptr = s.myFixedField)
        {
            int p = ptr[5];
        }
    }
}
```

For more information, see the article on the [`fixed` statement](../language-reference/keywords/fixed-statement.md).

### `stackalloc` arrays support initializers

You've been able to specify the values for elements in an array when you initialize it:

```csharp
var arr = new int[3] {1, 2, 3};
var arr2 = new int[] {1, 2, 3};
```

Now, that same syntax can be applied to arrays that are declared with `stackalloc`:

```csharp
int* pArr = stackalloc int[3] {1, 2, 3};
int* pArr2 = stackalloc int[] {1, 2, 3};
Span<int> arr = stackalloc [] {1, 2, 3};
```

For more information, see the [`stackalloc` operator](../language-reference/operators/stackalloc.md) article.

### Enhanced generic constraints

You can now specify the type <xref:System.Enum?displayProperty=nameWithType> or <xref:System.Delegate?displayProperty=nameWithType> as base class constraints for a type parameter.

You can also use the new `unmanaged` constraint, to specify that a type parameter must be a non-nullable [unmanaged type](../language-reference/builtin-types/unmanaged-types.md).

For more information, see the articles on [`where` generic constraints](../language-reference/keywords/where-generic-type-constraint.md) and [constraints on type parameters](../programming-guide/generics/constraints-on-type-parameters.md).

Adding these constraints to existing types is an [incompatible change](version-update-considerations.md#incompatible-changes). Closed generic types may no longer meet these new constraints.

### Generalized async return types

Returning a `Task` object from async methods can introduce performance bottlenecks in certain paths. `Task` is a reference type, so using it means allocating an object. In cases where a
method declared with the `async` modifier returns a cached result, or completes synchronously, the extra allocations can become a significant time cost in performance critical sections of code. It can become costly if those allocations occur in tight loops.

The new language feature means that async method return types aren't limited to `Task`, `Task<T>`, and `void`. The returned type must still satisfy the async pattern, meaning a `GetAwaiter` method must be accessible. As one concrete example, the `ValueTask` type has been added to .NET to make use of this new language feature:

[!code-csharp[UsingValueTask](~/samples/snippets/csharp/new-in-7/AsyncWork.cs#UsingValueTask "Using ValueTask")]

> [!NOTE]
> You need to add the NuGet package [`System.Threading.Tasks.Extensions`](https://www.nuget.org/packages/System.Threading.Tasks.Extensions/) > in order to use the <xref:System.Threading.Tasks.ValueTask%601> type.

This enhancement is most useful for library authors to avoid allocating a `Task` in performance critical code.

## New compiler options

New compiler options support new build and DevOps scenarios for C# programs.

### Reference assembly generation

There are two new compiler options that generate *reference-only assemblies*:
[**ProduceReferenceAssembly**](../language-reference/compiler-options/output.md#producereferenceassembly)
and [**ProduceOnlyReferenceAssembly**](../language-reference/compiler-options/code-generation.md#produceonlyreferenceassembly).
The linked articles explain these options and reference assemblies in more detail.

### Public or Open Source signing

The **PublicSign** compiler option instructs the compiler to sign the assembly using a public key. The assembly is marked as signed, but the signature is taken from the public key. This option enables you to build signed assemblies from open-source projects using a public key.

For more information, see the [**PublicSign** compiler option](../language-reference/compiler-options/security.md#publicsign) article.

### pathmap

The **PathMap** compiler option instructs the compiler to replace source paths from the build environment with mapped source paths. The **PathMap** option controls the source path written by the compiler to PDB files or for the <xref:System.Runtime.CompilerServices.CallerFilePathAttribute>.

For more information, see the [**PathMap** compiler option](../language-reference/compiler-options/advanced.md#pathmap) article.
