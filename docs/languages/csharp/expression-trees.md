# Expression Trees

If you have used LINQ, you have experience with a rich library
where `Func` and `Func<T>` are part of the API. (If you are not familiar
with LINQ, you probably want to read [that tutorial](linq.md) and
the tutorial on [lambda expressions](lambda-expressions.md) before this one.)
*Expression Trees* provide richer interaction with the arguments that
are functions.

Using a typical LINQ query, and function arguments are represented
by a delegate the compiler creates.

When you want to have a richer interaction, you need to use *Expression Trees*.
Expression Trees represent code as a structure that you can examine,
modify, or execute. These tools give you the power to manipulate code during
runtime. You can write code that examines running algorithms, or injects new
capabilities. In more advanced scenarios, you can modify running algorithms,
and even translate C# expressions into another form for execution in another
environment.

You've likely already written code that uses Expression Trees. Entity Framework's
LINQ APIs accept Expression Trees as the arguments for the LINQ Query Expression Pattern.
That enables Entity Framework to translate the query you wrote in C# into SQL
that executes in the database engine. Another example is [Moq](https://github.com/Moq/moq),
which is a popular mocking framework for .NET.

The remaining sections of this tutorial will explore what Expression Trees are,
examine the framework classes that support expression trees, and show you how to work
with expression trees. You'll learn how to read expression trees, how to create
expression trees, how to create modified expression trees, and how to execute the
code represented by expression trees. After reading, you will be ready to use these
structures to create rich adaptive algorithms.

# [Expression Trees Explained](expression-trees-explained.md)

Understand the structure and concepts behind *Expression Trees*.

# [Framework Types Supporting Expression Trees](expression-classes.md)

Learn about the structures and classes that define and manipulate expression trees.

# [Executing Expressions](expression-trees-execution.md)

Learn how to convert an expression tree represented as 
a Lambda Expression into a delegate and execute the resulting
delegate.

# [Interpreting Expressions](expression-trees-interpreting.md)

Learn how to traverse and examine *expression trees* to understand
what code the expression tree represents.

# [Building Expressions](expression-trees-building.md)

Learn how to construct the nodes for an expression tree and build
expression trees.

# [Translating Expressions](expression-trees-translating.md)

Learn how to build a modified copy of an expression tree, or translate
an expression tree into a different format.

# [Summing up](expression-trees-summary.md)

Review the information on expression trees.