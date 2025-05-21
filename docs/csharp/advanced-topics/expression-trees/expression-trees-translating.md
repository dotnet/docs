---
title: Translate Expression Trees
description: Learn how to visit each node in an expression tree while building a modified copy of that expression tree.
ms.date: 03/07/2023
ms.topic: how-to
---
# Translate expression trees

In this article, you learn how to visit each node in an expression tree while building a modified copy of that expression tree. You translate expression trees to understand the algorithms so that it can be translated into another environment. You change the algorithm that has been created. You might add logging, intercept method calls and track them, or other purposes.

The code you build to translate an expression tree is an extension of what you've already seen to visit all the nodes in a tree. When you translate an expression tree, you visit all the nodes, and while visiting them, build the new tree. The new tree may contain references to the original nodes, or new nodes that you've placed in the tree.

Let's visit an expression tree, and creating a new tree with some replacement nodes. In this example, let's replace any constant with a constant that is 10 times larger. Otherwise, you leave the expression tree intact. Rather than reading the value of the constant and replacing it with a new constant, you make this replacement by replacing the constant node with a new node that performs the multiplication.

Here, once you find a constant node, you create a new multiplication node whose children are the original constant and the constant `10`:

:::code language="csharp" source="snippets/TranslateExpressions.cs" id="ReplaceNode":::

Create a new tree by replacing the original node with the substitute. You verify the changes by compiling and executing the replaced tree.

:::code language="csharp" source="snippets/TranslateExpressions.cs" id="TranslateNode":::

Building a new tree is a combination of visiting the nodes in the existing tree, and creating new nodes and inserting them into the tree. The previous example shows the importance of expression trees being immutable. Notice that the new tree created in the preceding code contains a mixture of newly created nodes, and nodes from the existing tree. Nodes can be used in both trees because the nodes in the existing tree can't be modified. Reusing nodes results in significant memory efficiencies. The same nodes can be used throughout a tree, or in multiple expression trees. Since nodes can't be modified, the same node can be reused whenever it's needed.

## Traverse and execute an addition

Let's verify the new tree by building a second visitor that walks the tree of addition nodes and computes the result. Make a couple modifications to the visitor that you've seen so far. In this new version, the visitor returns the partial sum of the addition operation up to this point. For a constant expression it's simply the value of the constant expression. For an addition expression, the result is the sum of the left and right operands, once those trees have been traversed.

:::code language="csharp" source="snippets/TranslateExpressions.cs" id="TraverseAndCreateNode":::

There's quite a bit of code here, but the concepts are approachable. This code visits children in a depth first search. When it encounters a constant node, the visitor returns the value of the constant. After the visitor has visited both children, those children have computed the sum computed for that subtree. The addition node can now compute its sum. Once all the nodes in the expression tree have been visited, the sum has been computed. You can trace the execution by running the sample in the debugger and tracing the execution.

Let's make it easier to trace how the nodes are analyzed and how the sum is computed by traversing the tree. Here's an updated version of the Aggregate method that includes quite a bit of tracing information:

:::code language="csharp" source="snippets/TranslateExpressions.cs" id="Aggregate":::

Running it on the `sum` expression yields the following output:

```output
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

Trace the output and follow along in the preceding code. You should be able to work out how the code visits each node and computes the sum as it goes through the tree and finds the sum.

Now, let's look at a different run, with the expression given by `sum1`:

:::code language="csharp" source="snippets/TranslateExpressions.cs" id="sum1Expression":::

Here's the output from examining this expression:

```output
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

While the final answer is the same, the tree traversal is different. The nodes are traveled in a different order, because the tree was constructed with different operations occurring first.

### Create a modified copy

Create a new **Console Application** project. Add a `using` directive to the file for the `System.Linq.Expressions` namespace. Add the `AndAlsoModifier` class to your project.

:::code language="csharp" source="snippets/TranslateExpressions.cs" id="AndAlsoModifier":::

This class inherits the <xref:System.Linq.Expressions.ExpressionVisitor> class and is specialized to modify expressions that represent conditional `AND` operations. It changes these operations from a conditional `AND` to a conditional `OR`. The class overrides the <xref:System.Linq.Expressions.ExpressionVisitor.VisitBinary%2A> method of the base type, because conditional `AND` expressions are represented as binary expressions. In the `VisitBinary` method, if the expression that is passed to it represents a conditional `AND` operation, the code constructs a new expression that contains the conditional `OR` operator instead of the conditional `AND` operator. If the expression that is passed to `VisitBinary` doesn't represent a conditional `AND` operation, the method defers to the base class implementation. The base class methods construct nodes that are like the expression trees that are passed in, but the nodes have their sub trees replaced with the expression trees produced recursively by the visitor.

Add a `using` directive to the file for the `System.Linq.Expressions` namespace. Add code to the `Main` method in the Program.cs file to create an expression tree and pass it to the method that modifies it.

:::code language="csharp" source="snippets/TranslateExpressions.cs" id="ModifyExpression":::

The code creates an expression that contains a conditional `AND` operation. It then creates an instance of the `AndAlsoModifier` class and passes the expression to the `Modify` method of this class. Both the original and the modified expression trees are outputted to show the change. Compile and run the application.

## Learn more

This sample shows a small subset of the code you would build to traverse and interpret the algorithms represented by an expression tree. For information on building a general purpose library that translates expression trees into another language, read [this series](/archive/blogs/mattwar/linq-building-an-iqueryable-provider-series) by Matt Warren. It goes into great detail on how to translate any of the code you might find in an expression tree.

You've now seen the true power of expression trees. You examine a set of code, make any changes you'd like to that code, and execute the changed version. Because the expression trees are immutable, you create new trees by using the components of existing trees. Reusing nodes minimizes the amount of memory needed to create modified expression trees.
