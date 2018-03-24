---
title: Pattern Matching - C# Guide
description: Learn about pattern matching expressions in C#
keywords: .NET, .NET Core, C#
ms.date: 01/24/2017
ms.author: wiwagn
ms.topic: article
ms.prod: .net
ms.technology: devlang-csharp
ms.devlang: csharp
ms.assetid: 1e575c32-2e2b-4425-9dca-7d118f3ed15b
---

# Pattern Matching #

Patterns test that a value has a certain *shape*, and can *extract*
information from the value when it has the matching shape. Pattern
matching provides more concise syntax for algorithms you already use
today. You already create pattern matching algorithms using existing
syntax. You write `if` or `switch` statements that test values. Then,
when those statements match, you extract and use information from that
value. The new syntax elements are extensions to statements you are already
familiar with: `is` and `switch`. These new extensions combine testing
a value and extracting that information.

In this topic, we'll look at the new syntax to show you how it enables
readable, concise code. Pattern matching enables idioms where data and
the code are separated, unlike object oriented designs where data 
and the methods that manipulate them are tightly coupled.

To illustrate these new idioms, let's work with structures that represent
geometric shapes using pattern matching statements. You are probably
familiar with building class hierarchies and creating
[virtual methods and overridden methods](methods.md#inherited) to
customize object behavior based on the runtime type of the object.

Those techniques aren't possible for data that isn't structured in a class
hierarchy. When data and methods are separate, you need other tools. The new
*pattern matching* constructs enable cleaner syntax to examine data
and manipulate control flow based on any condition of that data. You already
write `if` statements and `switch` that test a variable's value. You write `is`
statements that test a variable's type. *Pattern matching* adds new capabilities
to those statements.

In this topic, you'll build a method  that computes the area of
different geometric shapes. But, you'll do it without resorting to object
oriented techniques and building a class hierarchy for the different shapes.
You'll use *pattern matching* instead. To further emphasize that we're not
using inheritance, you'll make each shape a `struct` instead of a class. 
Note that different `struct` types cannot specify a common user defined
base type, so inheritance is not a possible design.
As you go through this sample, contrast this code with how it would
be structured as an object hierarchy. When the data you must
query and manipulate is not a class hierarchy, pattern matching enables
very elegant designs.

Rather than starting with an abstract shape definition and adding different
specific shape classes, let's start instead with simple data only definitions
for each of the geometric shapes:

[!code-csharp[ShapeDefinitions](../../samples/csharp/PatternMatching/Shapes.cs#01_ShapeDefinitions "Shape definitions")]

From these structures, let's write a method that computes the area
of some shape.

## The `is` type pattern expression

Before C# 7, you'd need to test each type in a series of `if` and `is`
statements:

[!code-csharp[ClassicIsExpression](../../samples/csharp/PatternMatching/GeometricUtilities.cs#02_ClassicIsExpression "Classic type pattern using is")]

That code above is a classic expression of the *type pattern*: You're testing a variable
to determine its type and taking a different action based on that type.

This code becomes simpler using extensions to the `is` expression to assign
a variable if the test succeeds:

[!code-csharp[IsPatternExpression](../../samples/csharp/PatternMatching/GeometricUtilities.cs#03_IsPatternExpression "is pattern expression")]

In this updated version, the `is` expression both tests the variable and assigns
it to a new variable of the proper type. Also, notice that this version includes
the `Rectangle` type, which is a `struct`. The new `is` expression works with
value types as well as reference types.

Language rules for pattern matching expressions help you avoid misusing
the results of a match expression. In the example above, the variables `s`,
 `c`, and `r` are only in scope and definitely assigned when the respective
pattern match expressions have `true` results. If you try to use either
variable in another location, your code generates compiler errors.

Let's examine both of those rules in detail, beginning with scope. The variable
`c` is in scope only in the `else` branch of the first `if` statement. The variable
`s` is in scope in the method `ComputeArea`. That's because each 
branch of an `if` statement establishes a separate scope for variables. However, the `if` statement
itself does not. That means variables declared in the `if` statement are in the
same scope as the `if` statement (the method in this case.) This behavior is not
specific to pattern matching, but is the defined behavior for variable scopes 
and `if` and `else` statements.

The variables `c` and `s` are assigned when the respective `if` statements are true
because of the definitely assigned when true mechanism.

> [!TIP]
> The samples in this topic use the recommended construct where
> a pattern match `is` expression definitely assigns the match
> variable in the `true` branch of the `if` statement.
> You could reverse the logic by saying `if (!(shape is Square s))`
> and the variable `s` would be definitely assigned only in the
> `false` branch. While this is valid C#, it is not recommended
> because it is more confusing to follow the logic.

These rules mean that you are unlikely to accidentally access the result
of a pattern match expression when that pattern was not met.

## Using pattern matching `switch` statements

As time goes on, you may need to support other shape types. As the number
of conditions you are testing grows, you'll find that using the `is` pattern
matching expressions can become cumbersome. In addition to requiring `if`
statements on each type you want to check, the `is` expressions are limited
to testing if the input matches a single type. In this case, you'll find that the `switch` pattern
matching expressions becomes a better choice. 

The traditional `switch`
statement was a pattern expression: it supported the constant pattern.
You could compare a variable to any constant used in a `case` statement:

[!code-csharp[ClassicSwitch](../../samples/csharp/PatternMatching/GeometricUtilities.cs#04_ClassicSwitch "Classic switch statement")]

The only pattern supported by the `switch` statement was the constant
pattern. It was further limited to numeric types and the `string` type.
Those restrictions have been removed, and you can now write a `switch`
statement using the type pattern:

[!code-csharp[Switch Type Pattern](../../samples/csharp/PatternMatching/GeometricUtilities.cs#05_SwitchTypePattern "Compute with `switch` expression")]

The pattern matching `switch` statement uses familiar syntax to developers
who have used the traditional C-style `switch` statement. Each `case` is evaluated
and the code beneath the condition that matches the input variable is
executed. Code execution cannot "fall through" from one case expression
to the next; the syntax of the `case` statement requires that each `case`
end with a `break`, `return`, or `goto`.

> [!NOTE]
> The `goto` statements to jump to another label are valid only
> for the constant pattern, the classic switch statement.

There are important new rules governing the `switch` statement. The restrictions
on the type of the variable in the `switch` expression have been removed.
Any type, such as `object` in this example, may be used. The case expressions
are no longer limited to constant values. Removing that limitation means
that reordering `switch` sections may change a program's behavior.

When limited to constant values, no more than one `case`
label could match the value of the `switch` expression. Combine that with the 
rule that every `switch` section must not fall through to the next section, and 
it followed that the
`switch` sections could be rearranged in any order without affecting behavior.
Now, with more generalized `switch` expressions, the order of each section
matters. The `switch` expressions are evaluated in textual order. Execution
transfers to the first `switch` label that matches the `switch` expression.  
Note that the `default` case will only be executed if no other
case labels match. The `default` case is evaluated last, regardless
of its textual order. If there is no `default` case, and none of the
other `case` statements match, execution continues at the statement
following the `switch` statement. None of the `case` labels code is
executed.

## `when` clauses in `case` expressions

You can make special cases for those shapes that have 0 area by using
a `when` clause on the `case` label. A square with a side length of 0, or
a circle with a radius of 0 has a 0 area. You specify that condition
using a `when` clause on the `case` label:  

[!code-csharp[ComputeDegenerateShapes](../../samples/csharp/PatternMatching/GeometricUtilities.cs#07_ComputeDegenerateShapes "Compute shapes with 0 area")]

This change demonstrates a few important points about the new syntax. First,
multiple `case` labels can be applied to one `switch` section. The statement
block is executed when any of those labels is `true`. In this instance,
if the `switch` expression is either a circle or a square with 0 area, the
method returns the constant 0.

This example introduces two different variables in the two `case` labels
for the first `switch` block. Notice that the statements in this `switch` block
do not use either the variables `c` (for the circle) or `s` (for the square).
Neither of those variables is definitely assigned in this `switch` block.
If either of these cases match, clearly one of the variables has been assigned.
However, it is impossible to tell *which* has been assigned at compile-time,
because either case could match at runtime. For that reason,
most times when you use multiple `case` labels for the same block, you won't
introduce a new variable in the `case` statement, or you will only use the
variable in the `when` clause.

Having added those shapes with 0 area, let's add a couple more shape types:
a rectangle and a triangle:

[!code-csharp[AddRectangleAndTriangle](../../samples/csharp/PatternMatching/GeometricUtilities.cs#09_AddRectangleAndTriangle "Add rectangle and triangle")]

 This set of changes adds `case` labels for the degenerate case, and labels
 and blocks for each of the new shapes. 

Finally, you can add a `null` case to ensure the argument is not `null`:

[!code-csharp[NullCase](../../samples/csharp/PatternMatching/GeometricUtilities.cs#10_NullCase "Add null case")]

The special behavior for the `null` pattern is interesting because the constant
`null` in the pattern does not have a type but can be converted to any reference
type or nullable type. Rather than convert a `null` to any type, the language
defines that a `null` value will not match any type pattern, regardless of the
compile-time type of the variable. This behavior makes the new `switch` based
type pattern consistent with the `is` statement: `is` statements always return `false` when
the value being checked is `null`. It's also simpler: once you have
checked the type, you don't need an additional null check. You can see that from
the fact that there are no null checks in any of the case blocks of the samples above:
they are not necessary, since matching the type pattern guarantees a non-null value.

## `var` declarations in `case` expressions

The introduction of `var` as one of the match expressions introduces new
rules to the pattern match.

The first rule is that the `var` declaration
follows the normal type inference rules: The type is inferred to be the
static type of the switch expression. From that rule, the type always
matches.

The second rule is that a `var` declaration does not have the null check
that other type pattern expressions include. That means the variable
may be null, and a null check is necessary in that case.

Those two rules mean that in many instances, a `var` declaration
in a `case` expression matches the same conditions as a `default` expression.
Because any non-default case is preferred to the `default` case, the `default`
case will never execute.

> [!NOTE]
> The compiler does not emit a warning in those cases where a `default` case
> has been written but will never execute. This is consistent with current
> `switch` statement behavior where all possible cases have been listed.

The third rule introduces uses where a `var` case may be useful. Imagine
that you are doing a pattern match where the input is a string and you are
searching for known command values. You might write something like:

[!code-csharp[VarCaseExpression](../../samples/csharp/PatternMatching/Program.cs#VarCaseExpression "use a var case expression to filter white space")]

The `var` case matches `null`, the empty string, or any string that contains
only white space. Notice that the preceding code uses the `?.` operator to
ensure that it does not accidentally throw a <xref:System.NullReferenceException>. The `default` case handles any other string values that are not understood by this command parser.

This is one example where you may want to consider
a `var` case expression that is distinct from a `default` expression.

## Conclusions

*Pattern Matching constructs* enable you to easily manage control flow
among different variables and types that are not related by an inheritance
hierarchy. You can also control logic to use any condition you test on
the variable. It enables patterns and idioms that you'll need more often
as you build more distributed applications, where data and the methods that
manipulate that data are separate. You'll notice that the shape structs
used in this sample do not contain any methods, just read-only properties.
Pattern Matching works with any data type. You write expressions that examine
the object, and make control flow decisions based on those conditions.

Compare the code from this sample with the design that would follow from
creating a class hierarchy for an abstract `Shape` and specific derived
shapes each with their own implementation of a virtual method to calculate
the area. You'll often find that pattern matching expressions can be a very
useful tool when you are working with data and want to separate the data
storage concerns from the behavior concerns.

