# Expression Trees Explained
Expression Trees are a data structure that defines code. They are based on the same structures
that a compiler uses to analyze code and generate the compiled output. As you read through this
tutorial, you will notice quite a bit of similarity between Expression Trees and the types used
in the Roslyn APIs to build analyzers and CodeFixes. The concepts are similar, and the end result
is a data structure that allows examination of the source ode in a meaningful way. However, Expression
Trees are based on a totally different set of classes and APIs than the Roslyn APIs.
    
Let's look at a simple example.
Here's a line of code:
```cs
var sum = 1 + 2;
```
If you were to analyze this as an expression tree, the tree contains several nodes.
The outermost node is a variable declaration statement with assignment (`var sum = 1 + 2;`)
That outermost node contains several child nodes: a variable declaration, an assignment expression, and an
expression representing the right hand side of the equals sign. That expression is further subdivided into
expressions that represent the addition operation, and left and right operands of the addition.

Let's drill down a bit more into the expressions that make up the right side of the equals sign.
The expression is `1 + 2`. That's a binary expression. More specifically, it's a binary addition
expression. A binary addition expression has two children, representing the left and right nodes
of the addition expression. Here, both nodes are constant expressions: The left operand is the
value `1`, and the right operand is the value `2`.

Visually, the entire statement is a tree: You could start at the root node, and travel to
each node in the tree to see the code that makes up the statement:

- Variable declaration statement with assignment (`var sum = 1 + 2;`)
    * Variable Declaration Expression (`var sum = 1 + 2`)
        - Implicit variable type declaration (`var sum`)
            * Implicit var keyword (`var`)
            * Variable name declaration (`sum`)
    * assignment expression (`=`)
    * Binary Addition Expression (`1 + 2`)
        - left operand (`1`)
        - addition operator (`+`)
        - right operand (`2`)

This may look complicated, but it is very powerful. Following the same process, you can decompose
much more complicated expressions. Consider this expression:
```cs
var finalAnswer = this.SecretSauceFuncion(
    currentState.createInterimResult(), currentState.createSecondValue(1, 2),
    decisionServer.considerFinalOptions("hello")) +
    MoreSecretSauce('A', DateTime.Now, true);
```

The expression above is also a variable declaration with an assignment.
In this instance, the right hand side of the assignment is a much more complicated tree.
I'm not going to decompose this expression, but consider what the different nodes might
be. There are method calls using the current object as a receiver, one that has an explicit `this`
receiver, one that does not. There are method calls using other receiver objects,
there are constant arguments of different types. And finally, there is a binary
addition operator. Depending on the return type of `SecretSauceFunction()` or
`MoreSecretSauce()`, that binary addition operator may be a method call to an
overridden addition operator, resolving to a static method call to the binary 
addition operator defined for a class.

Despite this perceived complexity, the expression above creates a tree strcuture
that can be navigated as easily as the first sample. You can keep traversing
child nodes to find leaf nodes in the expression. Parent nodes will have
references to their children, and each node has a property that describes
what kind of node it is.

The structure of an expression tree is very consistent. Once you've learned
the basics, you can understand even the most complex code when it is represented
as an expression tree. The elegance in
the data structure explains how the C# compiler can analyze the most complex
C# programs and create proper output from that complicated source code.

Once you become familiar with the structure of expression trees, you will
find that knowledge you've gained quickly enables you to work with many
more and more advanced scenarios. There is incredible power to expression
trees.

In addition to translating algorithms to execute in other environments,
expression trees can be used to make it easier to write algorithms that inspect
code before executing it. You can write a method whose arguments are expressions
and then examine those expressions before executing the code. The Expression Tree
is a full representation of the code: you can see values of any sub-expression.
You can see method and property names. You can see the value of any constant expressions.
You can also convert an expression tree into an executable delegate, and execute the
code.

The one thing you can't do is modify an expression tree.  Expression Trees are immutable
data structures. If you want to mutate (change) expression tree, you must create a new tree
is a copy of the original, but with your desired changes. 
