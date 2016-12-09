---
title: Pattern Matching | C# Guide
description: Learn about pattern matching expressions in C#
keywords: .NET, .NET Core, C#
ms.date: 12/09/2016
ms.author: wiwagn
ms.topic: article
ms.prod: .net
ms.technology: devlang-csharp
ms.devlang: csharp
ms.assetid: 1e575c32-2e2b-4425-9dca-7d118f3ed15b
---

# Pattern Matching #

Pattern matching provides a control flow mechanism that is much more
generalized than is possible with traditional inheritance hierarchies
available in Object Oriented practices.

You are probably familiar with building class hierarchies and creating
virtual methods and overriden methods to customize object behavior based
on the runtime type of the object.

Those techniques aren't possible for data that isn't structured in a class
hierarchy. In those cases, you'd need to utilize traditional procedural
imperative constructs like `if` or `switch` statements to manage the control
flow.

The new *pattern matching* expressions enable cleaner syntax to examine data
and manipulate control flow based on any conditon of that data.

In this topic, you'll build a sample class that computes the area of
different geometric shapes. But, you'll do it without resorting to object
oriented techniques and building a class hierarchy for the different shapes.
You'll use *pattern matching* instead. To further emphasize that we're not
using inheritance, you'll make each shape a `struct` instead of a class. 

## Using `is` pattern expressions ##

Let's start simple with a square. 

[!code-csharp[SquareDefinition](../../samples/csharp/PatternMatching/PatternMatching/Shapes.cs#01_SquareDefinition "Square definition")]

The method to compute the area multiplies the length of a side by itself:

[!code-csharp[02_ComputeSquareArea](../../samples/csharp/PatternMatching/PatternMatching/GeometricUtilities.cs#02_ComputeSquareArea "Compute square area")]

Next, we'll add a circle:

[!code-csharp[CircleDefinition](../../samples/csharp/PatternMatching/PatternMatching/Shapes.cs#03_CircleDefinition "Circle definition")]

We'll also write a method to compute the area of a circle:

[!code-csharp[04_ComputeCircleArea](../../samples/csharp/PatternMatching/PatternMatching/GeometricUtilities.cs#04_ComputeCircleArea "Compute circle area")]

Ideally, you'd want one method that computes the area of any kind of
shape. You've only created a couple different kinds of shapes so far.
Let's use an `is` pattern matching expression to test the type of 
shape:

[!code-csharp[05_ComputeWithAsExpression](../../samples/csharp/PatternMatching/PatternMatching/GeometricUtilities.cs#05_ComputeWithAsExpression "Compute with as expression")]

The parameter type for this method is `object`: any type can be passed
to this method. The code in the method checks the type to see if the parameter
is either a square or a circle. Notice that the pattern match `is` expression
can assign a variable as well as test the type. The pattern match expression
`shape is Square s` is semantically the same as the more verbose syntax:

```csharp
Square s;
if (shape is Square)
{
    s = (shape as Square);
    // use 's'
} 
```

Language rules for pattern matching expressions help you avoid misuising
the results of a match expression. In the example above, the variables `s`
and `c` are only in scope and definitely assigned when the respective
pattern match expressions have true results. If you try and use either
variable in another location, your code generates compiler errors.

Let's examine both of those rules in detail, beginning with scope. The variable
`c` is in scope only in the `else` branch of the first `if` statement. The variable
`s` is in scope in the method `ComputeArea`. That's because the true and false
branches of an `if` statement each establish a scope. However, the `if` statement
itself does not. That means variables declared in the `if` statement are in the
same scope as the `if` statement (the method in this case.) 

The variables `c` and `s` are assigned when the respective `if` statements are true
because of the definitely assigned when true mechanism. (You could reverse the
logic by saying `if !(shape is Square s)` and the variable `s` would be definitely
assigned only in the false branch.) 

These rules mean that you are unlikely to accidentally access the result
of a pattern match expression when that pattern ws not met.

## Extending to more shape types

As time goes on, you need to support other shape types. As the number
of conditions you are testing grows, you'll find that using the `is` pattern
matching expressions becomes cumbersome. In addition to requiring `if`
statements on each type you want to check, the `is` expressions are limited
to testing a type.

As the number of conditions grows, you'll find that the `switch` pattern
matching expressions becomes a better choice. To get ready to add more
types of shapes to this library, let's change the existing method to use
the `switch` pattern match expression:

[!code-csharp[ComputeWithSwitchExpression](../../samples/csharp/PatternMatching/PatternMatching/GeometricUtilities.cs#06_ComputeWithSwitchExpression "Compute with switch expression")]

The pattern matching `switch` statement uses familiar syntax to developers
that have used the traditional `switch` statement. Each `case` is evaluated
and the code beneath the condition that matches the input variable is
executed. Code execution cannot "fall through" from one `case` expression
to the next. Each block following a `case` must end with a `break`, `return`
or `goto`.

There are important new rules governing the `switch` statement. The restrictions
on the type of the variable in the `switch` expression have been removed.
Any type, such as `object` in this example, may be used. The case expressions
are no longer limited to constant values. Removing that limitation means
that reordering switch sections may change a program's behavior.

When limited to constant values, no more than one switch
label could match the value of the switch expression. Combine that with the 
rule that every switch section must not fall through to the next section, and 
it followed that the
switch sections could be rearranged in any order without affecting behavior.
Now, with more generalized switch expressions, the order of each section
matters. The switch expressions are evaluated in textual order. Execution
transfers to the first switch label that matches the switch expression.  
Note that the `default` case will only be executed if no other
case labels match. The `default` case is evaluated last, regardless
of its textual order.

## `when` clauses in switch expressions

You can make special cases for those shapes that have 0 area by using
a `when` clause on the switch label. A square with side length of 0, or
a circle with a radius of 0 has a 0 area. You specify that condition
using a `when` clause on the switch label:  

[!code-csharp[ComputeDegenerateShapes](../../samples/csharp/PatternMatching/PatternMatching/GeometricUtilities.cs#07_ComputeDegenerateShapes "Compute shapes with 0 area")]

This change demonstrates a few important points on the new syntax. First,
multiple switch labels can be applied to one switch section. The statement
block is executed when any of those labels is true. In this instance,
if the switch expression is either a circle or a square with 0 area, the
method returns the constant 0.

This example introduces two different variables in the two switch labels
for the first switch block. Notice that the statements in this switch block
do not use either the variables `c` (for the circle), or `s` (for the square).
Neither of those variables is definitely assigned in this switch block.
Clearly one has been assigned, but static analysis cannot know which one. For that reason,
most times when you use multiple switch labels for the same block, you won't
introduce a new variable in the `case` statement, or you will only use the
variable only in the `when` clause.

Having adding those degenarate shapes, let's add a couple more shape types:
a rectangle and a triangle:

[!code-csharp[RectangleAndTriangle](../../samples/csharp/PatternMatching/PatternMatching/Shapes.cs#08_RectangleAndTriangle "Rectangle and Triangle definition")]

Next, you'll add switch labels and blocks for those shapes in the `ComputeArea` method:

[!code-csharp[AddRectangleAndTriangle](../../samples/csharp/PatternMatching/PatternMatching/GeometricUtilities.cs#09_AddRectangleAndTriangle "Add rectangle and triangle")]

 This set of changes adds switch labels for the degenerate case, and labels
 and blocks for each of the new shapes. 

Finally, you can add a `null` case to ensure the argument is not `null`:

[!code-csharp[NullCase](../../samples/csharp/PatternMatching/PatternMatching/GeometricUtilities.cs#10_NullCase "Add null case")]

The special case for the `null` pattern is interesting because the constant `null` does
not have a type, but can be converted to any reference type or nullable
type. 

## Conclusions

*Pattern Matching expressions* enable you to easily manage control flow
among different variables and types that are not related by an inheritance
hierarchy. You can also the control logic to use any condition you test on
the variable. It enables patterns and idioms that you'll need more often
as we build more distributed applications, where data and the methods that
manipulate that data are separate. You'll notice that the shape structs
used in this sample do not contain any methods, just read only properties.
Pattern Matching works with any data type. You write expressions that examine
the object, and make control flow decisions based on those conditions.
