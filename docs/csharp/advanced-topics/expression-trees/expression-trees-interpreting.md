---
title: Interpreting Expressions
description: Learn how to write code to examine the structure of an expression tree.
ms.date: 03/06/2023
---
# Interpret expressions

The following code example demonstrates how the expression tree that represents the lambda expression `num => num < 5` can be decomposed into its parts.

:::code language="csharp" source="snippets/InterpretExpressions.cs" id="ParseExpression":::

Now, let's write some code to examine the structure of an *expression tree*. Every node in an expression tree is an object of a class that is derived from `Expression`.

That design makes visiting all the nodes in an expression tree a relatively straight forward recursive operation. The general strategy is to start at the root node and determine what kind of node it is.

If the node type has children, recursively visit the children. At each child node, repeat the process used at the root node: determine the type, and if the type has children, visit each of the children.

## Examine an expression with no children

Let's start by visiting each node in a simple expression tree. Here's the code that creates a constant expression and then examines its properties:

:::code language="csharp" source="snippets/InterpretExpressions.cs" id="VisitConstant":::

The preceding code prints the following output:

```output
This is an Constant expression type
The type of the constant value is System.Int32
The value of the constant value is 24
```

Now, let's write the code that would examine this expression and write out some important properties about it.

## Addition expression

Let's start with the addition sample from the introduction to this section.

```csharp
Expression<Func<int>> sum = () => 1 + 2;
```

> [!NOTE]
> Don't use`var` to declare this expression tree, because the natural type of the delegate is `Func<int>`, not `Expression<Func<int>>`.

The root node is a `LambdaExpression`. In order to get the interesting code on the right-hand side of the `=>` operator, you need to find one of the children of the `LambdaExpression`. You do that with all the expressions in this section. The parent node does help us find the return type of the `LambdaExpression`.

To examine each node in this expression, you need to recursively visit many nodes. Here's a simple first implementation:

:::code language="csharp" source="snippets/InterpretExpressions.cs" id="VisitAddition":::

This sample prints the following output:

```output
This expression is a/an Lambda expression type
The name of the lambda is <null>
The return type is System.Int32
The expression has 2 arguments. They are:
        Parameter Type: System.Int32, Name: a
        Parameter Type: System.Int32, Name: b
The body is a/an Add expression
The left side is a Parameter expression
        Parameter Type: System.Int32, Name: a
The right side is a Parameter expression
        Parameter Type: System.Int32, Name: b
```

You notice much repetition in the preceding code sample. Let's clean that up and build a more general purpose expression node visitor. That's going to require us to write a recursive algorithm. Any node could be of a type that might have children. Any node that has children requires us to visit those children and determine what that node is. Here's the cleaned up version that utilizes recursion to visit the addition operations:

:::code language="csharp" source="snippets/Visitors.cs":::

This algorithm is the basis of an algorithm that visits any arbitrary `LambdaExpression`. The code you created only looks for a small sample of the possible sets of expression tree nodes that it may encounter. However, you can still learn quite a bit from what it produces. (The default case in the `Visitor.CreateFromExpression` method prints a message to the error console when a new node type is encountered. That way, you know to add a new expression type.)

When you run this visitor on the preceding addition expression, you get the following output:

```output
This expression is a/an Lambda expression type
The name of the lambda is <null>
The return type is System.Int32
The expression has 2 argument(s). They are:
        This is an Parameter expression type
        Type: System.Int32, Name: a, ByRef: False
        This is an Parameter expression type
        Type: System.Int32, Name: b, ByRef: False
The expression body is:
        This binary expression is a Add expression
        The Left argument is:
                This is an Parameter expression type
                Type: System.Int32, Name: a, ByRef: False
        The Right argument is:
                This is an Parameter expression type
                Type: System.Int32, Name: b, ByRef: False
```

Now that you've built a more general visitor implementation, you can visit and process many more different types of expressions.

## Addition Expression with more operands

Let's try a more complicated example,
yet still limit the node types to addition only:

:::code language="csharp" source="snippets/InterpretExpressions.cs" id="NoParens":::

Before you run these examples on the visitor algorithm, try a thought exercise to work out what the output might be. Remember that the `+` operator is a *binary operator*: it must have two children, representing the left and right operands. There are several possible ways to construct a tree that could be correct:

:::code language="csharp" source="snippets/InterpretExpressions.cs" id="ParensPermutations":::

You can see the separation into two possible answers to highlight the most promising. The first represents *right associative* expressions. The second represent *left associative* expressions. The advantage of both of those two formats is that the format scales to any arbitrary number of addition expressions.

If you do run this expression through the visitor, you see this output, verifying that the simple addition expression is *left associative*.

In order to run this sample, and see the full expression tree, you make one change to the source expression tree. When the expression tree contains all constants, the resulting tree simply contains the constant value of `10`. The compiler performs all the addition and reduces the expression to its simplest form. Simply adding one variable in the expression is sufficient to see the original tree:

:::code language="csharp" source="snippets/InterpretExpressions.cs" id="VariableAddition":::

Create a visitor for this sum and run the visitor you see this output:

```output
This expression is a/an Lambda expression type
The name of the lambda is <null>
The return type is System.Int32
The expression has 1 argument(s). They are:
        This is an Parameter expression type
        Type: System.Int32, Name: a, ByRef: False
The expression body is:
        This binary expression is a Add expression
        The Left argument is:
                This binary expression is a Add expression
                The Left argument is:
                        This binary expression is a Add expression
                        The Left argument is:
                                This is an Constant expression type
                                The type of the constant value is System.Int32
                                The value of the constant value is 1
                        The Right argument is:
                                This is an Parameter expression type
                                Type: System.Int32, Name: a, ByRef: False
                The Right argument is:
                        This is an Constant expression type
                        The type of the constant value is System.Int32
                        The value of the constant value is 3
        The Right argument is:
                This is an Constant expression type
                The type of the constant value is System.Int32
                The value of the constant value is 4
```

You can run any of the other samples through the visitor code and see what tree it represents. Here's an example of the preceding `sum3` expression (with an additional parameter to prevent the compiler from computing the constant):

:::code language="csharp" source="snippets/InterpretExpressions.cs" id="VariableParensAddition":::

Here's the output from the visitor:

```output
This expression is a/an Lambda expression type
The name of the lambda is <null>
The return type is System.Int32
The expression has 2 argument(s). They are:
        This is an Parameter expression type
        Type: System.Int32, Name: a, ByRef: False
        This is an Parameter expression type
        Type: System.Int32, Name: b, ByRef: False
The expression body is:
        This binary expression is a Add expression
        The Left argument is:
                This binary expression is a Add expression
                The Left argument is:
                        This is an Constant expression type
                        The type of the constant value is System.Int32
                        The value of the constant value is 1
                The Right argument is:
                        This is an Parameter expression type
                        Type: System.Int32, Name: a, ByRef: False
        The Right argument is:
                This binary expression is a Add expression
                The Left argument is:
                        This is an Constant expression type
                        The type of the constant value is System.Int32
                        The value of the constant value is 3
                The Right argument is:
                        This is an Parameter expression type
                        Type: System.Int32, Name: b, ByRef: False
```

Notice that the parentheses aren't part of the output. There are no nodes in the expression tree that represent the parentheses in the input expression. The structure of the expression tree contains all the information necessary to communicate the precedence.

## Extending this sample

The sample deals with only the most rudimentary expression trees. The code you've seen in this section only handles constant integers and the binary `+` operator. As a final  sample, let's update the visitor to handle a more complicated expression. Let's make it work for the following factorial expression:

:::code language="csharp" source="snippets/InterpretExpressions.cs" id="FactorialVisitor":::

This code represents one possible implementation for the mathematical *factorial* function. The way you've written this code highlights two limitations of building expression trees by assigning lambda expressions to Expressions. First, statement lambdas aren't allowed. That means you can't use loops, blocks, if / else statements, and other control structures common in C#. You're limited to using expressions. Second, you can't recursively call the same expression. You could if it were already a delegate, but you can't call it in its expression tree form. In the section on [building expression trees](expression-trees-building.md), you learn techniques to overcome these limitations.

In this expression, you encounter nodes of all these types:

1. Equal (binary expression)
1. Multiply (binary expression)
1. Conditional (the `? :` expression)
1. Method Call Expression (calling `Range()` and `Aggregate()`)

One way to modify the visitor algorithm is to keep executing it, and write the node type every time you reach your `default` clause. After a few iterations, you've see each of the potential nodes. Then, you have all you need. The result would be something like this:

:::code language="csharp" source="snippets/Visitors2.cs" id="UpdatedVisitor":::

The `ConditionalVisitor` and `MethodCallVisitor` process those two nodes:

:::code language="csharp" source="snippets/Visitors2.cs" id="NewNodes":::

And the output for the expression tree would be:

```output
This expression is a/an Lambda expression type
The name of the lambda is <null>
The return type is System.Int32
The expression has 1 argument(s). They are:
        This is an Parameter expression type
        Type: System.Int32, Name: n, ByRef: False
The expression body is:
        This expression is a Conditional expression
        The Test for this expression is:
                This binary expression is a Equal expression
                The Left argument is:
                        This is an Parameter expression type
                        Type: System.Int32, Name: n, ByRef: False
                The Right argument is:
                        This is an Constant expression type
                        The type of the constant value is System.Int32
                        The value of the constant value is 0
        The True clause for this expression is:
                This is an Constant expression type
                The type of the constant value is System.Int32
                The value of the constant value is 1
        The False clause for this expression is:
                This expression is a Call expression
                This is a static method call
                The method name is System.Linq.Enumerable.Aggregate
                The Arguments are:
                        This expression is a Call expression
                        This is a static method call
                        The method name is System.Linq.Enumerable.Range
                        The Arguments are:
                                This is an Constant expression type
                                The type of the constant value is System.Int32
                                The value of the constant value is 1
                                This is an Parameter expression type
                                Type: System.Int32, Name: n, ByRef: False
                        This expression is a Lambda expression type
                        The name of the lambda is <null>
                        The return type is System.Int32
                        The expression has 2 arguments. They are:
                                This is an Parameter expression type
                                Type: System.Int32, Name: product, ByRef: False
                                This is an Parameter expression type
                                Type: System.Int32, Name: factor, ByRef: False
                        The expression body is:
                                This binary expression is a Multiply expression
                                The Left argument is:
                                        This is an Parameter expression type
                                        Type: System.Int32, Name: product, ByRef: False
                                The Right argument is:
                                        This is an Parameter expression type
                                        Type: System.Int32, Name: factor, ByRef: False
```

## Extend the Sample Library

The samples in this section show the core techniques to visit and examine nodes in an expression tree. It simplified the types of nodes you'll encounter to concentrate on the core tasks of visiting and accessing nodes in an expression tree.

First, the visitors only handle constants that are integers. Constant values could be any other numeric type, and the C# language supports conversions and promotions between those types. A more robust version of this code would mirror all those capabilities.

Even the last example recognizes a subset of the possible node types. You can still feed it many expressions that cause it to fail. A full implementation is included in .NET Standard under the name <xref:System.Linq.Expressions.ExpressionVisitor> and can handle all the possible node types.

Finally, the library used in this article was built for demonstration and learning. It's not optimized. It makes the structures clear, and to highlight the techniques used to visit the nodes and analyze what's there.

Even with those limitations, you should be well on your way to writing algorithms that read and understand expression trees.
