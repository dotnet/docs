---
title: Interpreting Expressions
description: Learn how to write code to examine the structure of an expression tree.
keywords: .NET, .NET Core
author: BillWagner
ms.author: wiwagn
ms.date: 06/20/2016
ms.topic: article
ms.prod: .net
ms.technology: devlang-csharp
ms.devlang: csharp
ms.assetid: adf73dde-1e52-4df3-9929-2e0670e28e16
---

# Interpreting Expressions

[Previous -- Executing Expressions](expression-trees-execution.md)

Now, let's write some code to examine the structure of an 
*expression tree*. Every node in an expression tree will be
an object of a class that is derived from `Expression`.

That design makes visiting all the nodes in an expression tree
a relatively straight forward recursive operation. The general strategy
is to start at the root node and determine what kind of node it is.

If the node type has children, recursively visit the children. At each
child node, repeat the process used at the root node: determine the
type, and if the type has children, visit each of the children.

## Examining an Expression with No Children
Let's start by visiting each node in a very simple expression tree.
Here's the code that creates a constant expression and then
examines its properties:

```csharp
var constant = Expression.Constant(24, typeof(int));

Console.WriteLine($"This is a/an {constant.NodeType} expression type");
Console.WriteLine($"The type of the constant value is {constant.Type}");
Console.WriteLine($"The value of the constant value is {constant.Value}");
```

This will print the following:

```
This is an Constant expression type
The type of the constant value is System.Int32
The value of the constant value is 24
```

Now, let's write the code that would examine this expression and write
out some important properties about it. Here's that code:

## Examining a simple Addition Expression

Let's start with the addition sample from the
introduction to this section.

```csharp
Expression<Func<int>> sum = () => 1 + 2;
```

> I'm not using `var` to declare this expression tree, as it is not possible
> because the right-hand side of the assignment is implicitly typed. To understand
> this more deeply, read [here](implicitly-typed-lambda-expressions.md).

The root node is a `LambdaExpression`. In order to get the interesting
code on the right hand side of the `=>` operator, you need to find one
of the children of the `LambdaExpression`. We'll do that with all the
expressions in this section. The parent node does help us find the return
type of the `LambdaExpression`.

To examine each node in this expression, we'll need to recursively
visit a number of nodes. Here's a simple first implementation:

```csharp
Expression<Func<int, int, int>> addition = (a, b) => a + b;

Console.WriteLine($"This expression is a {addition.NodeType} expression type");
Console.WriteLine($"The name of the lambda is {((addition.Name == null) ? "<null>" : addition.Name)}");
Console.WriteLine($"The return type is {addition.ReturnType.ToString()}");
Console.WriteLine($"The expression has {addition.Parameters.Count} arguments. They are:");
foreach(var argumentExpression in addition.Parameters)
{
    Console.WriteLine($"\tParameter Type: {argumentExpression.Type.ToString()}, Name: {argumentExpression.Name}");
}

var additionBody = (BinaryExpression)addition.Body;
Console.WriteLine($"The body is a {additionBody.NodeType} expression");
Console.WriteLine($"The left side is a {additionBody.Left.NodeType} expression");
var left = (ParameterExpression)additionBody.Left;
Console.WriteLine($"\tParameter Type: {left.Type.ToString()}, Name: {left.Name}");
Console.WriteLine($"The right side is a {additionBody.Right.NodeType} expression");
var right= (ParameterExpression)additionBody.Right;
Console.WriteLine($"\tParameter Type: {right.Type.ToString()}, Name: {right.Name}");
```

This sample prints the following output:

```
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

You'll notice a lot of repetition in the code sample above.
Let's clean that up and build a more general purpose expression
node visitor. That's going to require us to write a recursive
algorithm. Any node could be of a type that might have children.
Any node that has children requires us to visit those children
and determine what that node is. Here's the cleaned up version
that utilizes recursion to visit the addition operations:

```csharp
// Base Visitor class:
public abstract class Visitor
{
    private readonly Expression node;

    protected Visitor(Expression node)
    {
        this.node = node;
    }

    public abstract void Visit(string prefix);

    public ExpressionType NodeType => this.node.NodeType;
    public static Visitor CreateFromExpression(Expression node)
    {
        switch(node.NodeType)
        {
            case ExpressionType.Constant:
                return new ConstantVisitor((ConstantExpression)node);
            case ExpressionType.Lambda:
                return new LambdaVisitor((LambdaExpression)node);
            case ExpressionType.Parameter:
                return new ParameterVisitor((ParameterExpression)node);
            case ExpressionType.Add:
                return new BinaryVisitor((BinaryExpression)node);
            default:
                Console.Error.WriteLine($"Node not processed yet: {node.NodeType}");
                return default(Visitor);
        }
    }
}

// Lambda Visitor
public class LambdaVisitor : Visitor
{
    private readonly LambdaExpression node;
    public LambdaVisitor(LambdaExpression node) : base(node)
    {
        this.node = node;
    }

    public override void Visit(string prefix)
    {
        Console.WriteLine($"{prefix}This expression is a {NodeType} expression type");
        Console.WriteLine($"{prefix}The name of the lambda is {((node.Name == null) ? "<null>" : node.Name)}");
        Console.WriteLine($"{prefix}The return type is {node.ReturnType.ToString()}");
        Console.WriteLine($"{prefix}The expression has {node.Parameters.Count} argument(s). They are:");
        // Visit each parameter:
        foreach (var argumentExpression in node.Parameters)
        {
            var argumentVisitor = Visitor.CreateFromExpression(argumentExpression);
            argumentVisitor.Visit(prefix + "\t");
        }
        Console.WriteLine($"{prefix}The expression body is:");
        // Visit the body:
        var bodyVisitor = Visitor.CreateFromExpression(node.Body);
        bodyVisitor.Visit(prefix + "\t");
    }
}

// Binary Expression Visitor:
public class BinaryVisitor : Visitor
{
    private readonly BinaryExpression node;
    public BinaryVisitor(BinaryExpression node) : base(node)
    {
        this.node = node;
    }

    public override void Visit(string prefix)
    {
        Console.WriteLine($"{prefix}This binary expression is a {NodeType} expression");
        var left = Visitor.CreateFromExpression(node.Left);
        Console.WriteLine($"{prefix}The Left argument is:");
        left.Visit(prefix + "\t");
        var right = Visitor.CreateFromExpression(node.Right);
        Console.WriteLine($"{prefix}The Right argument is:");
        right.Visit(prefix + "\t");
    }
}

// Parameter visitor:
public class ParameterVisitor : Visitor
{
    private readonly ParameterExpression node;
    public ParameterVisitor(ParameterExpression node) : base(node)
    {
        this.node = node;
    }

    public override void Visit(string prefix)
    {
        Console.WriteLine($"{prefix}This is an {NodeType} expression type");
        Console.WriteLine($"{prefix}Type: {node.Type.ToString()}, Name: {node.Name}, ByRef: {node.IsByRef}");
    }
}

// Constant visitor:
public class ConstantVisitor : Visitor
{
    private readonly ConstantExpression node;
    public ConstantVisitor(ConstantExpression node) : base(node)
    {
        this.node = node;
    }

    public override void Visit(string prefix)
    {
        Console.WriteLine($"{prefix}This is an {NodeType} expression type");
        Console.WriteLine($"{prefix}The type of the constant value is {node.Type}");
        Console.WriteLine($"{prefix}The value of the constant value is {node.Value}");
    }
}
```

This algorithm is the basis of an algorithm that can visit
any arbitrary `LambdaExpression`. There are a lot of holes,
namely that the code I created only looks for a very small
sample of the possible sets of expression tree nodes that
it may encounter. However, you can still learn quite a bit
from what it produces. (The default case in the `Visitor.CreateFromExpression`
method prints a message to the error console when a new node type
is encountered. That way, you know to add a new expression type.)

When you run this visitor on the addition expression shown above, you get the
following output:

```
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

Now that you've built a more general visitor implementation, you
can visit and process many more different types of expressions.

## Examining an Addition Expression with Many Levels

Let's try a more complicated example,
yet still limit the node types to addition only:

```csharp
Expression<Func<int>> sum = () => 1 + 2 + 3 + 4;
```

Before you run this on the visitor algorithm, try a thought
exercise to work out what the output might be. Remember that
the `+` operator is a *binary operator*: it must have two
children, representing the left and right operands. There
are several possible ways to construct a tree that 
could be correct:

```csharp
Expression<Func<int>> sum1 = () => 1 + (2 + (3 + 4));
Expression<Func<int>> sum2 = () => ((1 + 2) + 3) + 4;

Expression<Func<int>> sum3 = () => (1 + 2) + (3 + 4);
Expression<Func<int>> sum4 = () => 1 + ((2 + 3) + 4);
Expression<Func<int>> sum5 = () => (1 + (2 + 3)) + 4;
```

You can see the separation into two possible answers to highlight the
most promising. The first represents *right associative*
expressions. The second represent *left associative* expressions.
The advantage of both of those two formats is that the format scales
to any arbitrary number of addition expressions. 

If you do run this expression through the visitor, you will see this
this output, verifying that the simple addition expression is
*left associative*. 

In order to run this sample, and see the full expression tree, I had to
make one change to the source expression tree. When the expression tree
contains all constants, the resulting tree simply contains the constant
value of `10`. The compiler performs all the addition and reduces the
expression to its simplest form. Simply adding one variable in the expression
is sufficient to see the original tree:

```csharp
Expression<Func<int, int>> sum = (a) => 1 + a + 3 + 4;
```

Create a visitor for this sum and run the visitor you'll see this output:

```
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

You can also run any of the other samples through the visitor code
and see what tree it represents. Here's an example of the `sum3`
expression above (with an additional parameter to prevent the compiler from
computing the constant):

```csharp
Expression<Func<int, int, int>> sum3 = (a, b) => (1 + a) + (3 + b);
```

Here's the output from the visitor:

```
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

Notice that the parentheses are not part of the output. There are no
nodes in the expression tree that represent the parentheses in the
input expression. The structure of the expression tree contains all the
information necessary to communicate the precedence.

## Extending from this sample

The sample deals with only the most rudimentary expression trees. The code
you've seen in this section only handles constant integers and the binary
`+` operator. As a final sample, let's update the visitor to handle a more
complicated expression. Let's make it work for this:

```csharp
Expression<Func<int, int>> factorial = (n) =>
    n == 0 ? 
    1 : 
    Enumerable.Range(1, n).Aggregate((product, factor) => product * factor);
```

This code represents one possible implementation for the
mathematical *factorial* function. The way I've written this code highlights
two limitiations of building expression trees by assigning lambda expressions
to Expressions. First, statement lambdas are not allowed. That means I can't use
loops, blocks, if / else statements, and other control structures common in C#. I'm
limited to using expressions. Second, I can't recursively call the same expression.
I could if it were already a delegate, but I can't call it in its expression tree 
form. In the section on [building expression trees](expression-trees-building.md)
you'll learn techniques to overcome these limitations.


In this expression, you'll encounter nodes of all these types:
1. Equal (binary expression)
2. Multiply (binary expression)
3. Conditional (the ? : expression)
4. Method Call Expression (calling `Range()` and `Aggregate()`)

One way to modify the visitor algorithm is to keep executing it, and write
the node type every time you reach your `default` clause. After a few
iterations, you'll have seen each of the potential nodes. Then, you have
all you need. The result would be something like this:

```csharp
public static Visitor CreateFromExpression(Expression node)
{
    switch(node.NodeType)
    {
        case ExpressionType.Constant:
            return new ConstantVisitor((ConstantExpression)node);
        case ExpressionType.Lambda:
            return new LambdaVisitor((LambdaExpression)node);
        case ExpressionType.Parameter:
            return new ParameterVisitor((ParameterExpression)node);
        case ExpressionType.Add:
        case ExpressionType.Equal:
        case ExpressionType.Multiply:
            return new BinaryVisitor((BinaryExpression)node);
        case ExpressionType.Conditional:
            return new ConditionalVisitor((ConditionalExpression)node);
        case ExpressionType.Call:
            return new MethodCallVisitor((MethodCallExpression)node);
        default:
            Console.Error.WriteLine($"Node not processed yet: {node.NodeType}");
            return default(Visitor);
    }
}
```

The ConditionalVisitor and MethodCallVisitor process those two nodes:

```csharp
public class ConditionalVisitor : Visitor
{
    private readonly ConditionalExpression node;
    public ConditionalVisitor(ConditionalExpression node) : base(node)
    {
        this.node = node;
    }

    public override void Visit(string prefix)
    {
        Console.WriteLine($"{prefix}This expression is a {NodeType} expression");
        var testVisitor = Visitor.CreateFromExpression(node.Test);
        Console.WriteLine($"{prefix}The Test for this expression is:");
        testVisitor.Visit(prefix + "\t");
        var trueVisitor = Visitor.CreateFromExpression(node.IfTrue);
        Console.WriteLine($"{prefix}The True clause for this expression is:");
        trueVisitor.Visit(prefix + "\t");
        var falseVisitor = Visitor.CreateFromExpression(node.IfFalse);
        Console.WriteLine($"{prefix}The False clause for this expression is:");
        falseVisitor.Visit(prefix + "\t");
    }
}

public class MethodCallVisitor : Visitor
{
    private readonly MethodCallExpression node;
    public MethodCallVisitor(MethodCallExpression node) : base(node)
    {
        this.node = node;
    }

    public override void Visit(string prefix)
    {
        Console.WriteLine($"{prefix}This expression is a {NodeType} expression");
        if (node.Object == null)
            Console.WriteLine($"{prefix}This is a static method call");
        else
        {
            Console.WriteLine($"{prefix}The receiver (this) is:");
            var receiverVisitor = Visitor.CreateFromExpression(node.Object);
            receiverVisitor.Visit(prefix + "\t");
        }

        var methodInfo = node.Method;
        Console.WriteLine($"{prefix}The method name is {methodInfo.DeclaringType}.{methodInfo.Name}");
        // There is more here, like generic arguments, and so on.
        Console.WriteLine($"{prefix}The Arguments are:");
        foreach(var arg in node.Arguments)
        {
            var argVisitor = Visitor.CreateFromExpression(arg);
            argVisitor.Visit(prefix + "\t");
        }
    }
}
```

And the output for the expression tree would be:

```
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

## Extending the Sample Library

The samples in this section show the core techniques to visit and
examine nodes in an expression tree. I glossed over many actions
you might need in order to concentrate on the core tasks of
visiting and accessing nodes in an expression tree. 

First, the visitors only handle constants
that are integers. Constant values could be any other numeric type,
and the C# language supports conversions and promotions between those
types. A more robust version of this code would mirror all those
capabilities.

Even the last example recognizes a subset of the possible node types.
You can still feed it many expressions that will cause it to fail.
A full implementation is included in the .NET Standard 
under the name [ExpressionVisitor](/dotnet/core/api/System.Linq.Expressions.ExpressionVisitor)
and can handle all the possible node types.

Finally, the library I used in this article was built for demonstration
and learning. It's not optimized. I wrote it to make the structures
used very clear, and to highlight the techniques used to visit
the nodes and analyze what's there. A production implementation would
pay more attention to performance than I have.

Even with those limitations, you should be well on your way to writing
algorithms that read and understand expression trees.

[Next -- Building Expressions](expression-trees-building.md)
