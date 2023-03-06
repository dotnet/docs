---
title: Executing Expression Trees
description: Learn about executing expression trees by converting them into executable Intermediate Language (IL) instructions.
ms.date: 03/06/2023
---

# Execute expression trees

An *expression tree* is a data structure that represents some code. It isn't compiled and executable code. If you want to execute
the .NET code represented by an expression tree, you must convert it into executable IL instructions. Executing an expression tree may return a value, or it may just perform an action such as calling a method.

Only expression trees that represent lambda expressions can be executed. Expression trees that represent lambda expressions are of type <xref:System.Linq.Expressions.LambdaExpression> or <xref:System.Linq.Expressions.Expression%601>. To execute these expression trees, call the <xref:System.Linq.Expressions.LambdaExpression.Compile%2A> method to create an executable delegate, and then invoke the delegate.

> [!NOTE]
> If the type of the delegate is not known, that is, the lambda expression is of type <xref:System.Linq.Expressions.LambdaExpression> and not <xref:System.Linq.Expressions.Expression%601>, you must call the <xref:System.Delegate.DynamicInvoke%2A> method on the delegate instead of invoking it directly.

If an expression tree doesn't represent a lambda expression, you can create a new lambda expression that has the original expression tree as its body, by calling the <xref:System.Linq.Expressions.Expression.Lambda%60%601%28System.Linq.Expressions.Expression%2CSystem.Collections.Generic.IEnumerable%7BSystem.Linq.Expressions.ParameterExpression%7D%29> method. Then, you can execute the lambda expression as described earlier in this section.

## Lambda expressions to functions

You can convert any LambdaExpression, or any type derived from LambdaExpression into executable IL. Other expression types can't be directly converted into code. This restriction has little effect in practice. Lambda expressions are the only types of expressions that you would want to execute by converting to executable intermediate language (IL). (Think about what it would mean to directly execute a <xref:System.Linq.Expressions.ConstantExpression?displayProperty=nameWithType>. Would it mean anything useful?) Any expression tree that is a <xref:System.Linq.Expressions.LambdaExpression?displayProperty=nameWithType>, or a type derived from `LambdaExpression` can be converted to IL. The expression type <xref:System.Linq.Expressions.Expression%601?displayProperty=nameWithType> is the only concrete example in the .NET Core libraries. It's used to represent an expression that maps to any delegate type. Because this type maps to a delegate type, .NET can examine the expression, and generate IL for an appropriate delegate that matches the signature of the lambda expression. The delegate type is based on the expression type. You must know the return type and the argument list if you want to use the delegate object in a strongly typed manner. The `LambdaExpression.Compile()` method returns the `Delegate` type. You have to cast it to the correct delegate type to have any compile-time tools check the argument list or return type.

In most cases, a simple mapping between an expression and its corresponding delegate exists. For example, an expression tree represented by `Expression<Func<int>>` would be converted to a delegate of the type `Func<int>`. For a lambda expression with any return type and argument list, there exists a delegate type that is the target type for the executable code represented by that lambda expression.

The <xref:System.Linq.Expressions.LambdaExpression?displayProperty=nameWithType> type contains <xref:System.Linq.Expressions.LambdaExpression.Compile%2A?displayProperty=nameWithType> and <xref:System.Linq.Expressions.LambdaExpression.CompileToMethod%2A?displayProperty=nameWithType> members that you would use to convert an expression tree to executable code. The `Compile` method creates a delegate. The `CompileToMethod` method updates a <xref:System.Reflection.Emit.MethodBuilder?displayProperty=nameWithType> object with the IL that represents the compiled output of the expression tree.

> [!IMPORTANT]
> `CompileToMethod` is only available in the full desktop framework, not in the .NET Core.

Optionally, you can also provide a <xref:System.Runtime.CompilerServices.DebugInfoGenerator?displayProperty=nameWithType> that receives the symbol debugging information for the generated delegate object. The `DebugInfoGenerator` provides full debugging information about the generated delegate.

You would convert an expression into a delegate using the following code:

:::code language="csharp" source="snippets/RunExpressionTrees.cs" id="ConvertToDelegate":::

The following code example demonstrates the concrete types used when you compile and execute an expression tree.

:::code language="csharp" source="snippets/RunExpressionTrees.cs" id="CreateExpressionTree":::

The following code example demonstrates how to execute an expression tree that represents raising a number to a power by creating a lambda expression and executing it. The result, which represents the number raised to the power, is displayed.

:::code language="csharp" source="snippets/RunExpressionTrees.cs" id="ConvertToFund":::

## Execution and lifetimes

You execute the code by invoking the delegate created when you called `LambdaExpression.Compile()`. The preceding code, `add.Compile()`, returns a delegate. You invoke that delegate by calling `func()`, which execute the code.

That delegate represents the code in the expression tree. You can retain the handle to that delegate and invoke it later. You don't need to compile the expression tree each time you want to execute the code it represents. (Remember that expression trees are immutable, and compiling the same expression tree later creates a delegate that executes the same code.)

> [!CAUTION]
> Don't create any more sophisticated caching mechanisms to increase performance by avoiding unnecessary compile calls. Comparing two arbitrary expression trees to determine if they represent the same algorithm is a time consuming operation. The compute time you save avoiding any extra calls to `LambdaExpression.Compile()` are likely more than consumed by the time executing code that determines of two different expression trees result in the same executable code.

## Caveats

Compiling a lambda expression to a delegate and invoking that delegate is one of the simplest operations you can perform with an expression tree. However, even with this simple operation, there are caveats you must be aware of.

Lambda Expressions create closures over any local variables that are referenced in the expression. You must guarantee that any variables that would be part of the delegate are usable at the location where you call `Compile`, and when you execute the resulting delegate. The compiler ensures that variables are in scope. However, if your expression accesses a variable that implements `IDisposable`, it's possible that your code might dispose of the object while it's still held by the expression tree.

For example, this code works fine, because `int` doesn't implement `IDisposable`:

:::code language="csharp" source="snippets/RunExpressionTrees.cs" id="CreateBoundFunc":::

The delegate has captured a reference to the local variable `constant`. That variable is accessed at any time later, when the function returned by `CreateBoundFunc` executes.

However, consider the following (rather contrived) class that implements <xref:System.IDisposable?displayProperty=nameWithType>:

:::code language="csharp" source="snippets/RunExpressionTrees.cs" id="ResourceClass":::

If you use it in an expression as shown in the following code, you get an <xref:System.ObjectDisposedException?displayProperty=nameWithType> when you execute the code referenced by the `Resource.Argument` property:

:::code language="csharp" source="snippets/RunExpressionTrees.cs" id="CreateBoundResource":::

The delegate returned from this method has closed over the `constant` object, which has been disposed of. (It's been disposed, because it was declared in a `using` statement.)

Now, when you execute the delegate returned from this method, you have an `ObjectDisposedException` thrown at the point of execution.

It does seem strange to have a runtime error representing a compile-time construct, but that's the world we enter when we work with expression trees.

There are numerous permutations of this problem, so it's hard to offer general guidance to avoid it. Be careful about accessing local variables when defining expressions, and be careful about accessing state in the current object (represented by `this`) when creating an expression tree returned via a public API.

The code in your expression may reference methods or properties in other assemblies. That assembly must be accessible when the expression is defined, when it's compiled, and when the resulting delegate is invoked. You're met with a `ReferencedAssemblyNotFoundException` in cases where it isn't present.

## Summary

Expression Trees that represent lambda expressions can be compiled to create a delegate that you can execute. Expression trees provide one mechanism to execute the code represented by an expression tree.

The Expression Tree does represent the code that would execute for any given construct you create. As long as the environment where you compile and execute the code matches the environment where you create the expression, everything works as expected. When that doesn't happen, the errors are predictable, and they're caught in your first tests of any code using the expression trees.
