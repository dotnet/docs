---
title: Executing Expression Trees
description: Learn about executing expression trees by converting them into executable Intermediate Language (IL) instructions.
keywords: .NET, .NET Core
author: BillWagner
ms.author: wiwagn
ms.date: 06/20/2016
ms.topic: article
ms.prod: .net
ms.technology: devlang-csharp
ms.devlang: csharp
ms.assetid: 109e0ac5-2a9c-48b4-ac68-9b6219cdbccf
---

# Executing Expression Trees

[Previous -- Framework Types Supporting Expression Trees](expression-classes.md)

An *expression tree* is a data structure that represents some code.
It is not compiled and executable code. If you want to execute
the .NET code that is represented by an expression tree, you must
convert it into executable IL instructions. 
## Lambda Expressions to Functions
You can convert any LambdaExpression, or any type derived from
LambdaExpression into executable IL. Other expression types
cannot be directly converted into code. This restriction has
little effect in practice. Lambda expressions are the only
types of expressions that you would want to execute by converting
to executable intermediate language (IL). (Think about what it would mean
to directly execute a `ConstantExpression`. Would it mean
anything useful?) Any expression tree that is a `LamdbaExpression`,
or a type derived from `LambdaExpression` can be converted to IL.
The expression type `Expression<TDelegate>`
is the only concrete example in the .NET Core libraries. It's used
to represent an expression that maps to any delegate type. Because
this type maps to a delegate type, .NET can examine
the expression, and generate IL for an appropriate delegate that
matches the signature of the lambda expression. 

In most cases, this creates a simple mapping between an expression,
and its corresponding delegate. For example, an expression tree that
is represented by `Expression<Func<int>>` would be converted to a delegate
of the type `Func<int>`. For a lambda expression with any return type
and argument list, there exists a delegate type that is the target type
for the executable code represented by that lamdba expression.

The `LamdbaExpression` type contains `Compile` and `CompileToMethod`
members that you would use to convert an expression tree to executable
code. The `Compile` method creates a delegate. The `CompileToMethod`
method updates a `MethodBuilder` object with the IL that represents
the compiled output of the expression tree. Note that `CompileToMethod`
is only available on the full desktop framework, not on the 
.NET Core framework.

Optionally, you can also provide a `DebugInfoGenerator` that will
receive the symbol debugging information for the generated delegate
object. This enables you to convert the expression tree into a
delegate object, and have full debugging information about the
generated delegate.

You would convert an expression into a delegate using the following
code:

```csharp
Expression<Func<int>> add = () => 1 + 2;
var func = add.Compile(); // Create Delegate
var answer = func(); // Invoke Delegate
Console.WriteLine(answer);
```

Notice that the delegate type is based on the expression type. You must
know the return type and the argument list if you want to use the
delegate object in a strongly typed manner. The `LambdaExpression.Compile()`
method returns the `Delegate` type. You will have to cast it to the correct
delegate type to have any compile-time tools check the argument list of
return type.

## Execution and Lifetimes

You execute the code by invoking the delegate created when
you called `LamdbaExpression.Compile()`. You can see this above where
`add.Compile()` returns a delegate. Invoking that delegate, by calling
`func()` executes the code.

That delegate represents the code in the expression tree. You can
retain the handle to that delegate and invoke it later. You don't need
to compile the expression tree each time you want to execute the code
it represents. (Remember that expression trees are immutable, and
compiling the same expression tree later will create a delegate that
executes the same code.)

I will caution you against trying to create any more sophisticated
caching mechanisms to increase performance by avoiding unnecessary
compile calls. Comparing two arbitrary expression trees to determine
if they represent the same algorithm will also be time consuming to
execute. You'll likely
find that the compute time you save avoiding any extra calls to
`LambdaExpression.Compile()` will be more than consumed by the time executing
code that determines of two different expression trees result in
the same executable code.

## Caveats

Compiling a lambda expression to a delegate and invoking that delegate
is one of the simplest operations you can perform with an expression
tree. However, even with this simple operation, there are caveats
you must be aware of. 

Lambda Expressions create closures over any local variables that are
referenced in the expression. You must guarantee that any variables
that would be part of the delegate are usable at the location where
you call `Compile`, and when you execute the resulting delegate.

In general, the compiler will ensure that this is true. However,
if your expression accesses a variable that implements `IDisposable`,
it's possible that your code might dispose of the object while it
is still held by the expression tree.

For example, this code works fine, because `int` does not implement
`IDisposable`:

```csharp
private static Func<int, int> CreateBoundFunc()
{
    var constant = 5; // constant is captured by the expression tree
    Expression<Func<int, int>> expression = (b) => constant + b;
    var rVal = expression.Compile();
    return rVal;
}
```

The delegate has captured a reference to the local variable `constant`.
That variable is accessed at any time later, when the function returned
by `CreateBoundFunc` executes.

However, consider this (rather contrived) class that implements
`IDisposable`:

```csharp
public class Resource : IDisposable
{
    private bool isDisposed = false;
    public int Argument
    {
        get
        {
            if (!isDisposed)
                return 5;
            else throw new ObjectDisposedException("Resource");
        }
    }

    public void Dispose()
    {
        isDisposed = true;
    }
}
```

If you use it in an expression as shown below, you'll get an
`ObjectDisposedException` when you execute the code referenced
by the `Resource.Argument` property:

```csharp
private static Func<int, int> CreateBoundResource()
{
    using (var constant = new Resource()) // constant is captured by the expression tree
    {
        Expression<Func<int, int>> expression = (b) => constant.Argument + b;
        var rVal = expression.Compile();
        return rVal;
    }
}
```

The delegate returned from this method has closed over the `constant` object,
which has been disposed of. (It's been disposed, because it was declared in a
`using` statement.) 

Now, when you execute the delegate returned from this method, you'll have a
`ObjecctDisposedException` thrown at the point of execution.

It does seem strange to have a runtime error representing a compile-time
construct, but that's the world we enter when we work with
expression trees.

There are a lot of permutations of this problem, so it's hard
to offer general guidance to avoid it. Be careful about accessing
local variables when defining expressions, and be careful about
accessing state in the current object (represented by `this`) when
creating an expression tree that can be returned by a public API.

The code in your expression may reference methods or properties in
other assemblies. That assembly must be accessible when the expression
is defined, and when it is compiled, and when the resulting delegate
is invoked. You'll be met with a `ReferencedAssemblyNotFoundException`
in cases where it is not present.

## Summary

Expression Trees that represent lambda expressions can be compiled
to create a delegate that you can execute. This provides one
mechanism to execute the code represented by an expression tree.

The Expression Tree does represent the code that would execute for
any given construct you create. As long as the environment where
you compile and execute the code matches the environment where you
create the expression, everything works as expected. When that
doesn't happen, the errors are very predictable, and they will
be caught in your first tests of any code using the expression
trees.

[Next -- Interpreting Expressions](expression-trees-interpreting.md)
