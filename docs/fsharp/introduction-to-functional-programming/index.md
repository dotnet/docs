---
title: Introduction to Functional Programming in F#
description: Learn the fundamentals of functional programming in F#.
ms.date: 10/29/2018
---

# Introduction to Functional Programming in F# #

Functional programming is a style of programming that emphasizes the use of functions and immutable data. Typed functional programming is when functional programming is combined with static types, such as with F#. In general, the following concepts are emphasized in functional programming:

* Functions as the primary constructs you use
* Expressions instead of statements
* Immutable values over variables
* Declarative programming over imperative programming

Throughout this series, you'll explore concepts and patterns in functional programming using F#. Along the way, you'll learn some F# too.

## Terminology

Functional programming, like other programming paradigms, comes with a vocabulary that you will eventually need to learn. Here are some common terms you'll see all of the time:

* **Function** - A function is a construct that will produce an output when given an input. More formally, it _maps_ an item from one set to another set. This formalism is lifted into the concrete in many ways, especially when using functions that operate on collections of data. It is the most basic (and important) concept in functional programming. 
* **Expression** - An expression is a construct in code that produces a value. In F#, this value must be bound or explicitly ignored. An expression can be trivially replaced by a function call.
* **Purity** - Purity is a property of a function such that its return value is always the same for the same arguments, and that its evaluation has no side effects. A pure function depends entirely on its arguments.
* **Referential Transparency** - Referential Transparency is a property of expressions such that they can be replaced with their output without affecting a program's behavior.
* **Immutability** - Immutability means that a value cannot be changed in-place. This is in contrast with variables, which can change in place.

## Examples

The following examples demonstrate these core concepts.

### Functions

The most common and fundamental construct in functional programming is the function. Here's a simple function that adds 1 to an integer:

```fsharp
let addOne x = x + 1
```

Its type signature is as follows:

```fsharp
val addOne: x:int -> int
```

The signature can be read as, "`addOne` accepts an `int` named `x` and will produce an `int`". More formally, `addOne` is _mapping_ a value from the set of integers to the set of integers. The `->` token signifies this mapping. In F#, you can usually look at the function signature to get a sense for what it does.

So, why is the signature important? In typed functional programming, the implementation of a function is often less important than the actual type signature! The fact that `addOne` adds the value 1 to an integer is interesting at runtime, but when you are constructing a program, the fact that it accepts and returns an `int` is what informs how you will actually use this function. Furthermore, once you use this function correctly (with respect to its type signature), diagnosing any problems can be done only within the body of the `addOne` function. This is the impetus behind typed functional programming.

### Expressions

Expressions are constructs that evaluate to a value. In contrast to statements, which perform an action, expressions can be thought of performing an action that gives back a value. Expressions are almost always used in favor of statements in functional programming.

Consider the previous function, `addOne`. The body of `addOne` is an expression:

```fsharp
// 'x + 1' is an expression!
let addOne x = x + 1
```

It is the result of this expression that defines the result type of the `addOne` function. For example, the expression that makes up this function could be changed to be a different type, such as a `string`:

```fsharp
let addOne x = x.ToString() + "1"
```

The signature of the function is now:

```fsharp
val addOne: x:'a -> string
```

Since any type in F# can have `ToString()` called on it, the type of `x` has been made generic (called [Automatic Generalization](../language-reference/generics/automatic-generalization.md)), and the resultant type is a `string`.

Expressions are not just the bodies of functions. You can have expressions that produce a value you use elsewhere. A common one is `if`:

```fsharp
// Checks if 'x' is odd by using the mod operator
let isOdd x = x % 2 <> 0

let addOneIfOdd input =
    let result =
        if isOdd input then
            input + 1
        else
            input

    result
```

The `if` expression produces a value called `result`. Note that you could omit `result` entirely, making the `if` expression the body of the `addOneIfOdd` function. The key thing to remember about expressions is that they produce a value.

There is a special type, `unit`, that is used when there is nothing to return. For example, consider this simple function:

```fsharp
let printString (str: string) =
    printfn "String is: %s" s
```

The signature looks like this:

```fsharp
val printString: str:string -> unit
```

The `unit` type indicates that there is no actual value being returned. This is useful when you have a routine that must "do work" despite having no value to return as a result of that work.

This is in sharp contrast to imperative programming, where the equivalent `if` construct is a statement, and producing values is often done with mutating variables. For example, in C#, the code might be written like this:

```csharp
bool IsOdd(int x) => x % 2 != 0;

int AddOneIfOdd(int input)
{
    var result = input;

    if (IsOdd(input))
    {
        result = input + 1;
    }

    return result;
}
```

It's worth noting that C# and other C-style languages do support the [ternary expression](../../csharp/language-reference/operators/conditional-operator.md), which allows for expression-based conditional programming.

In functional programming, it is rare to mutate values with statements. Although some functional languages support statements and mutation, it is not common to use these concepts in functional programming.

### Pure functions

As previously mentioned, pure functions are functions that:

* Always evaluate to the same value for the same input.
* Have no side effects.

It is helpful to think of mathematical functions in this context. In mathematics, functions depend only on their arguments and do not have any side effects. In the mathematical function `f(x) = x + 1`, the value of `f(x)` depends only on the value of `x`. Pure functions in functional programming are the same way.

When writing a pure function, the function must depend only on its arguments and not perform any action that results in a side effect.

Here is an example of a non-pure function because it depends on global, mutable state:

```fsharp
let mutable value = 1

let addOneToValue x = x + value
```

The `addOneToValue` function is clearly impure, because `value` could be changed at any time to have a different value than 1. This pattern of depending on a global value is to be avoided in functional programming.

Here is another example of a non-pure function, because it performs a side effect:

```fsharp
let addOneToValue x = 
    printfn "x is %d" x
    x + 1
```

Although this function does not depend on a global value, it writes the value of `x` to the output of the program. Although there is nothing inherently wrong with doing this, it does mean that the function is not pure.

Removing the `printfn` statement finally makes the function pure:

```fsharp
let addOneToValue x = x + 1
```

Although this function is not inherently _better_ than the previous version with the `printfn` statement, it does guarantee that all this function does is return a value. Calling this function once or 1 billion times will still result in the same thing: just producing a value. This predictability is valuable in functional programming, as it means that any pure function is referentially transparent.

### Referential Transparency

Referential transparency is a property of expressions and functions. For an expression to be referentially transparent, it must be able to be replaced with its resulting value without changing the program's behavior. All pure functions are referentially transparent.

As with pure functions, it can be helpful to think of referential transparency from a mathematical perspective. In the mathematical expression `y = f(x)`, `f(x)` can be replaced by the result of the function and it will still be equal to `y`. This is equally true for referential transparency in functional programming.

Consider calling the previously defined `addOneIfOdd` function twice:

```fsharp
// Checks if 'x' is odd by using the mod operator
let isOdd x = x % 2 <> 0

let addOneIfOdd input =
    let result =
        if isOdd input then
            input + 1
        else
            input

    result

let res1 = addOneIfOdd 1 // Produces 2
let res2 = addOneIfOdd 2 // Produces 2
```

We can replace each function call with the function body, substituting the argument `input` with each value:

```fsharp
// Checks if 'x' is odd by using the mod operator
let isOdd x = x % 2 <> 0

let addOneIfOdd input =
    let result =
        if isOdd input then
            input + 1
        else
            input

    result

let res1 =
    let result =
        if isOdd 1 then
            1 + 1
        else
            1

    result
let res2 =
    let result =
        if isOdd 2 then
            2 + 1
        else
            2

    result
```

Both `res1` and `res2` have the same value as if the function was called, indicating that `addOneIfOdd` is referentially transparent!

Additionally, a function doesn't have to be pure to also be referentially transparent. Consider a previous definition of  `addOneTovalue`:

```fsharp
let addOneToValue x = 
    printfn "x is %d" x
    x + 1
```

Any call to this function can also be replaced by its body and the same things will happen each time:

* The value, prior to being added to, is printed to the output
* The value has 1 added to it

When programming in F#, it is often referential transparency that is the goal, rather than purity. However, it is still good practice to write pure functions when you can.

### Immutability

Finally, one of the most fundamental concepts of typed functional programming is immutability. In F#, all values are immutable by default. That means they cannot be mutated in-place unless you explicitly mark them as mutable.

In practice, working with immutable values means that you change your approach to programming from, "I need to change something", to "I need to produce a new value".

For example, adding 1 to a value means producing a new value, not mutating the existing one:

```fsharp
let value = 1
let secondValue = value + 1
```

In F#, the following code does **not** mutate the `value` function; instead, it performs an equality check:

```fsharp
let value = 1
value = value + 1 // Produces a 'bool' value!
```

Some functional programming languages do not support mutation at all. In F#, it is supported, but it is not the default behavior for values.

This concept extends even further to data structures. In functional programming, immutable data structures such as sets (and many more) have a different implementation than you might initially expect. Conceptually, something like adding an item to a set does not change the set, it produces a _new_ set with the added value. Under the covers, this is often accomplished by a different data structure that allows for efficiently tracking a value so that the appropriate representation of the data can be given as a result.

This style of working with values and data structures is critical, as it forces you to treat any operation that modifies something as if it creates a new version of that thing. This allows for things like equality and comparability to be consistent in your programs.

## Next steps

The next section will thoroughly cover functions, exploring different ways you can use them in functional programming.

[First-class functions](first-class-functions.md) explores functions deeply, showing how you can use them in various contexts.

## Further reading

The [Thinking Functionally](https://fsharpforfunandprofit.com/posts/thinking-functionally-intro/) series is another great resource to learn about functional programming with F#. It covers fundamentals of functional programming in a pragmatic and easy-to-read way, using F# features to illustrate the concepts.
