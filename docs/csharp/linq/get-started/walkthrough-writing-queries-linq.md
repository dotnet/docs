---
title: "Tutorial: Writing LINQ Queries"
description: This walkthrough shows how C# language features are used in LINQ query expressions.
ms.date: 04/22/2024
ms.topic: tutorial
helpviewer_keywords: 
  - "LINQ [C#], walkthroughs"
  - "LINQ [C#], writing queries"
  - "queries [LINQ in C#], writing"
  - "writing LINQ queries"
---
# Tutorial: Write queries in C# using language integrated query (LINQ)

In this tutorial, you create a data source and write several LINQ queries. You can experiment with the query expressions and see the differences in the results. This walkthrough demonstrates the C# language features that are used to write LINQ query expressions. You can follow along and build the app and experiment with the queries yourself. This article assumes you've installed the latest .NET SDK. If not, go to the [.NET Downloads page](https://dot.net) and install the latest version on your machine.

First, create the application. From the console, type the following command:

```dotnetcli
dotnet new console -o WalkthroughWritingLinqQueries
```

Or, if you prefer Visual Studio, create a new console application named *WalkthroughWritingLinqQueries*.

## Create an in-memory data source

The first step is to create a data source for your queries. The data source for the queries is a simple list of `Student` records. Each `Student` record has a first name, family name, and an array of integers that represents their test scores in the class. Add a new file named *students.cs*, and copy the following code into that file:

:::code language="csharp" source="./snippets/WalkthroughWritingLinqQueries/StudentDataSource.cs":::

Note the following characteristics:

- The `Student` record consists of automatically implemented properties.
- Each student in the list is initialized with the primary constructor.
- The sequence of scores for each student is initialized with a primary constructor.

Next, create a sequence of `Student` records that serves as the source of this query. Open *Program.cs*, and remove the following boilerplate code:

```csharp
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
```

Replace it with the following code that creates a sequence of `Student` records:

:::code language="csharp" source="./snippets/WalkthroughWritingLinqQueries/Program.cs" id="CreateSequence":::

- The sequence of students is initialized with a collection expression.
- The `Student` record type holds the static list of all students.
- Some of the constructor calls use [named arguments](../../programming-guide/classes-and-structs/named-and-optional-arguments.md) to clarify which argument matches which constructor parameter.

Try adding a few more students with different test scores to the list of students to get more familiar with the code so far.

## Create the query

Next, you create your first query. Your query, when you execute it, produces a list of all students whose score on the first test was greater than 90. Because the whole `Student` object is selected, the type of the query is `IEnumerable<Student>`. Although the code could also use implicit typing by using the [var](../../language-reference/statements/declarations.md#implicitly-typed-local-variables) keyword, explicit typing is used to clearly illustrate results. (For more information about `var`, see [Implicitly Typed Local Variables](../../programming-guide/classes-and-structs/implicitly-typed-local-variables.md).) Add the following code to *Program.cs*, after the code that creates the sequence of students:

:::code language="csharp" source="./snippets/WalkthroughWritingLinqQueries/Program.cs" id="DefineFirstQuery":::

The query's range variable, `student`, serves as a reference to each `Student` in the source, providing member access for each object.

## Run the query

Now write the `foreach` loop that causes the query to execute. Each element in the returned sequence is accessed through the iteration variable in the `foreach` loop. The type of this variable is `Student`, and the type of the query variable is compatible, `IEnumerable<Student>`. After you added the following code, build and run the application to see the results in the **Console** window.

:::code language="csharp" source="./snippets/WalkthroughWritingLinqQueries/Program.cs" id="RunFirstQuery":::

To further refine the query, you can combine multiple Boolean conditions in the `where` clause. The following code adds a condition so that the query returns those students whose first score was over 90 and whose last score was less than 80. The `where` clause should resemble the following code.
  
```csharp
where student.Scores[0] > 90 && student.Scores[3] < 80  
```

Try the preceding `where` clause, or experiment yourself with other filter conditions. For more information, see [where clause](../../language-reference/keywords/where-clause.md).

## Order the query results

It's easier to scan the results if they are in some kind of order. You can order the returned sequence by any accessible field in the source elements. For example, the following `orderby` clause orders the results in alphabetical order from A to Z according to the family name of each student. Add the following `orderby` clause to your query, right after the `where` statement and before the `select` statement:

:::code language="csharp" source="./snippets/WalkthroughWritingLinqQueries/Program.cs" id="OrderByLast":::

Now change the `orderby` clause so that it orders the results in reverse order according to the score on the first test, from the highest score to the lowest score.

:::code language="csharp" source="./snippets/WalkthroughWritingLinqQueries/Program.cs" id="OrderByScore":::

Change the `WriteLine` format string so that you can see the scores:

:::code language="csharp" source="./snippets/WalkthroughWritingLinqQueries/Program.cs" id="WriteFirstScore":::

For more information, see [orderby clause](../../language-reference/keywords/orderby-clause.md).

## Group the results

Grouping is a powerful capability in query expressions. A query with a group clause produces a sequence of groups, and each group itself contains a `Key` and a sequence that consists of all the members of that group. The following new query groups the students by using the first letter of their family name as the key.

:::code language="csharp" source="./snippets/WalkthroughWritingLinqQueries/Program.cs" id="CreateGroupQuery":::

The type of the query changed. It now produces a sequence of groups that have a `char` type as a key, and a sequence of `Student` objects. The code in the `foreach` execution loop also must change:

:::code language="csharp" source="./snippets/WalkthroughWritingLinqQueries/Program.cs" id="RunGroupQuery":::

Run the application and view the results in the **Console** window. For more information, see [group clause](../../language-reference/keywords/group-clause.md).

Explicitly coding `IEnumerables` of `IGroupings` can quickly become tedious. Write the same query and `foreach` loop much more conveniently by using `var`. The `var` keyword doesn't change the types of your objects; it just instructs the compiler to infer the types. Change the type of `studentQuery` and the iteration variable `group` to `var` and rerun the query. In the inner `foreach` loop, the iteration variable is still typed as `Student`, and the query works as before. Change the `student` iteration variable to `var` and run the query again. You see that you get exactly the same results.

:::code language="csharp" source="./snippets/WalkthroughWritingLinqQueries/Program.cs" id="VarGroupQuery":::

For more information about `var`, see [Implicitly Typed Local Variables](../../programming-guide/classes-and-structs/implicitly-typed-local-variables.md).
  
## Order the groups by their key value

The groups in the previous query aren't in alphabetical order. You can provide an `orderby` clause after the `group` clause. But to use an `orderby` clause, you first need an identifier that serves as a reference to the groups created by the `group` clause. You provide the identifier by using the `into` keyword, as follows:

:::code language="csharp" source="./snippets/WalkthroughWritingLinqQueries/Program.cs" id="OrderedGroupQuery":::

Run this query, and the groups are now sorted in alphabetical order.

You can use the `let` keyword to introduce an identifier for any expression result in the query expression. This identifier can be a convenience, as in the following example. It can also enhance performance by storing the results of an expression so that it doesn't have to be calculated multiple times.

:::code language="csharp" source="./snippets/WalkthroughWritingLinqQueries/Program.cs" id="QueryWithLet":::

For more information, see the article on the [`let` clause](../../language-reference/keywords/let-clause.md).

## Use method syntax in a query expression

As described in [Query Syntax and Method Syntax in LINQ](./write-linq-queries.md), some query operations can only be expressed by using method syntax. The following code calculates the total score for each `Student` in the source sequence, and then calls the `Average()` method on the results of that query to calculate the average score of the class.

:::code language="csharp" source="./snippets/WalkthroughWritingLinqQueries/Program.cs" id="ComputeAverage":::

## To transform or project in the select clause

It's common for a query to produce a sequence whose elements differ from the elements in the source sequences. Delete or comment out your previous query and execution loop, and replace it with the following code. The query returns a sequence of strings (not `Students`), and this fact is reflected in the `foreach` loop.

:::code language="csharp" source="./snippets/WalkthroughWritingLinqQueries/Program.cs" id="SelectProjection":::

Code earlier in this walkthrough indicated that the average class score is approximately 334. To produce a sequence of `Students` whose total score is greater than the class average, together with their `Student ID`, you can use an anonymous type in the `select` statement:

:::code language="csharp" source="./snippets/WalkthroughWritingLinqQueries/Program.cs" id="BetterThanMost":::
