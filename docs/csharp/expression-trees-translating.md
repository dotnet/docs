---
title: Translating Expression Trees
description: Learn how to visit each node in an expression tree while building a modified copy of that expression tree.
keywords: .NET, .NET Core
author: BillWagner
ms.author: wiwagn
ms.date: 06/20/2016
ms.topic: article
ms.prod: .net
ms.technology: devlang-csharp
ms.devlang: csharp
ms.assetid: b453c591-acc6-4e08-8175-97e5bc65958e
---

# Translating Expression Trees

[Previous -- Building Expressions](expression-trees-building.md)

In this final section, you'll learn how to visit each node
in an expression tree while building a modified copy of that
expression tree. These are the techniques that you will use in two
important scenarios. The first is to understand the algorithms
expressed by an expression tree so that it can be translated
into another environment. The second is when you want to change
the algorithm that has been created. This might be to add logging,
intercept method calls and track them, or other purposes.

## Translating is Visiting

The code you build to translate an expression tree is an extension
of what you've already seen to visit all the nodes in a tree. When
you translate an expression tree, you visit all the nodes, and while
visiting them, build the new tree. The new tree may contain references
to the original nodes, or new nodes that you have placed in the tree.

Let's see this in action by visiting an expression tree, and
creating a new tree with some replacement nodes. In this example,
let's replace any constant with a constant that is ten times larger.
Otherwise, we'll leave the expression tree intact. Rather than
reading the value of the constant, and replacing it with a new
constant, we'll make this replacement by replacing the constant
node with a new node that performs the multiplication.

Here, once you find a constant node, you create a new multiplication
node whose children are the original constant, and the constant
`10`:

```csharp
private static Expression ReplaceNodes(Expression original)
{
    if (original.NodeType == ExpressionType.Constant)
    {
        return Expression.Multiply(original, Expression.Constant(10));
    }
    else if (original.NodeType == ExpressionType.Add)
    {
        var binaryExpression = (BinaryExpression)original;
        return Expression.Add(
            ReplaceNodes(binaryExpression.Left),
            ReplaceNodes(binaryExpression.Right));
    }
    return original;
}
```

By replacing the original node with the substitute, a new tree
is formed that contains our modifications. We can verify that by
compiling and executing the replaced tree.

```csharp
var one = Expression.Constant(1, typeof(int));
var two = Expression.Constant(2, typeof(int));
var addition = Expression.Add(one, two);
var sum = ReplaceNodes(addition);
var executableFunc = Expression.Lambda(sum);

var func = (Func<int>)executableFunc.Compile();
var answer = func();
Console.WriteLine(answer);
```

Building a new tree is a combination of visiting the nodes in
the existing tree, and creating new nodes and inserting them
into the tree.

This example shows the importance of expression trees being
immutable. Notice that the new tree created above contains a
mixture of newly created nodes, and nodes from the existing
tree. That's safe, because the nodes in the existing tree cannot be
modified. This can result in significant memory efficiencies.
The same nodes can be used throughout a tree, or in multiple
expression trees. Since nodes can't be modified, the
same node can be reused whenever its needed.

## Traversing and Executing an Addition

Let's verify this by building a second visitor that walks the tree
of addition nodes and computes the result. You can do this by
making a couple modifications to the vistor that you've seen so
far. In this new version, the visitor will return the partial sum
of the addition operation up to this point. For a constant expression,
that is simply the value of the constant expression. For an addition
expression, the result is the sum of the left and right operands, once
those trees have been traversed.

```csharp
var one = Expression.Constant(1, typeof(int));
var two = Expression.Constant(2, typeof(int));
var three= Expression.Constant(3, typeof(int));
var four = Expression.Constant(4, typeof(int));
var addition = Expression.Add(one, two);
var add2 = Expression.Add(three, four);
var sum = Expression.Add(addition, add2);

// Declare the delegate, so we can call it 
// from itself recursively:
Func<Expression, int> aggregate = null;
// Aggregate, return constants, or the sum of the left and right operand.
// Major simplification: Assume every binary expression is an addition.
aggregate = (exp) =>
    exp.NodeType == ExpressionType.Constant ?
    (int)((ConstantExpression)exp).Value :
    aggregate(((BinaryExpression)exp).Left) + aggregate(((BinaryExpression)exp).Right);

var theSum = aggregate(sum);
Console.WriteLine(theSum);
```

There's quite a bit of code here, but the concepts are very approachable.
This code visits children in a depth first search. When it encounters a
constant node, the visitor returns the value of the constant. After the
visitor has visited both children, those children will have computed the sum
computed for that sub-tree. The addition node can now compute its sum.
Once all the nodes in the expression tree have been visited, the sum
will have been computed. You can trace the execution by running the sample
in the debugger and tracing the execution.

Let's make it easier to trace how the nodes are analyzed and how the sum
is computed by travsersing the tree. Here's an updated version of the
Aggregate method that includes quite a bit of tracing information:

```csharp
private static int Aggregate(Expression exp)
{
    if (exp.NodeType == ExpressionType.Constant)
    {
        var constantExp = (ConstantExpression)exp;
        Console.Error.WriteLine($"Found Constant: {constantExp.Value}");
        return (int)constantExp.Value;
    }
    else if (exp.NodeType == ExpressionType.Add)
    {
        var addExp = (BinaryExpression)exp;
        Console.Error.WriteLine("Found Addition Expression");
        Console.Error.WriteLine("Computing Left node");
        var leftOperand = Aggregate(addExp.Left);
        Console.Error.WriteLine($"Left is: {leftOperand}");
        Console.Error.WriteLine("Computing Right node");
        var rightOperand = Aggregate(addExp.Right);
        Console.Error.WriteLine($"Right is: {rightOperand}");
        var sum = leftOperand + rightOperand;
        Console.Error.WriteLine($"Computed sum: {sum}");
        return sum;
    }
    else throw new NotSupportedException("Haven't written this yet");
}
```

Running it on the same expression yields the following output:

```
10
Found Addition Expression
Computing Left node
Found Addition Expression
Computing Left node
Found Constant: 1
Left is: 1
Computing Right node
Found Constant: 2
Right is: 2
Computed sum: 3
Left is: 3
Computing Right node
Found Addition Expression
Computing Left node
Found Constant: 3
Left is: 3
Computing Right node
Found Constant: 4
Right is: 4
Computed sum: 7
Right is: 7
Computed sum: 10
10
```

Trace the output and follow along in the code above. You should be able
to work out how the code visits each node and computes the sum as it goes
through the tree and finds the sum.

Now, let's look at a different run, with the expression given by `sum1`:

```csharp
Expression<Func<int> sum1 = () => 1 + (2 + (3 + 4));
```

Here's the output from examining this expression:

```
Found Addition Expression
Computing Left node
Found Constant: 1
Left is: 1
Computing Right node
Found Addition Expression
Computing Left node
Found Constant: 2
Left is: 2
Computing Right node
Found Addition Expression
Computing Left node
Found Constant: 3
Left is: 3
Computing Right node
Found Constant: 4
Right is: 4
Computed sum: 7
Right is: 7
Computed sum: 9
Right is: 9
Computed sum: 10
10
```

While the final answer is the same, the tree traversal is completely
different. The nodes are traveled in a different order, because the
tree was constructed with different operations occurring first.

## Learning More

This sample shows a small subset of the code you would build to traverse
and interpret the algorithms represented by an expression tree. For a complete
discussion of all the work necessary to build a general purpose library that
translates expression trees into another language, please read
[this series](http://blogs.msdn.com/b/mattwar/archive/2008/11/18/linq-links.aspx)
by Matt Warren. It goes into great detail on how to translate any of the code
you might find in an expression tree.

I hope you've now seen the true power of expression trees.
You can examine a set of code, make any changes you'd like to
that code, and execute the changed version. Because the
expression trees are immutable, you can create new trees by
using the components of existing trees. This minimizes the
amount of memory needed to create modified expression trees.

[Next -- Summing up](expression-trees-summary.md)
