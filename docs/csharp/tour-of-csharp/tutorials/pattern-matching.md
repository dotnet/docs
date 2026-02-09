---
title: Pattern matching
description: In this tutorial about pattern matching, you learn C#. You're going to write C# code and see the results of compiling and running your code.
ms.date: 02/09/2026
---
# Tutorial: Use C# to match data against patterns

This tutorial teaches you how to use pattern matching to inspect data in C#. You write small amounts of code, then you compile and run that code. The tutorial contains a series of lessons that explore different kinds of patterns supported by C#. These lessons teach you the fundamentals of the C# language.

> [!TIP]
> **New to programming?** Work through each section in order. **Coming from another language?** If you already know `switch` statements, focus on [exhaustive matches](#exhaustive-matches-with-switch) and [type patterns](#type-patterns) – these are distinctive C# features.

In this tutorial, you:

> [!div class="checklist"]
>
> * Launch a GitHub Codespace with a C# development environment.
> * Test data for discrete values.
> * Match enum data against value.
> * Create exhaustive matches using `switch` expressions.
> * Match types using type patterns.

## Prerequisites

You must have one of the following options:

- A GitHub account to use [GitHub Codespaces](https://github.com/codespaces). If you don't already have one, you can create a free account at [GitHub.com](https://github.com).
- A computer with the following tools installed:
  - The [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0).
  - [Visual Studio Code](https://code.visualstudio.com/download).
  - The [C# DevKit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit).

## Match a value

The preceding tutorials demonstrated built-in types and types you define as tuples or records. You can check instances of these types against a *pattern*. Whether an instance matches a pattern determines the actions your program takes. In the examples that follow, you see `?` after type names. This symbol allows the value of this type to be null (for example, `bool?` can be `true`, `false`, or `null`). For more information, see [Nullable value types](../../language-reference/builtin-types/nullable-value-types.md).  Let's start to explore how you can use patterns.

Open a browser window to [GitHub codespaces](https://github.com/codespaces). Create a new codespace from the *.NET Template*. If you completed other tutorials in this series, you can open that codespace.

1. When your codespace loads, create a new file in the *tutorials* folder named *patterns.cs*.
1. Open your new file.

1. All the examples in this tutorial use text input that represents a series of bank transactions as comma separated values (CSV) input. In each of the samples, you can match the record against a pattern by using either an `is` or `switch` expression. This first example splits each line on the `,` character and then *matches* the first string field against the value "DEPOSIT" or "WITHDRAWAL" by using an `is` expression. When it matches, the transaction amount is added or deducted from the current account balance. To see it work, add the following code to *patterns.cs*:

   :::code language="csharp" source="./snippets/PatternMatching/patterns.cs" id="FirstExample":::

1. Then, type the following text in the terminal window:

   ```dotnetcli
   cd tutorials
   dotnet patterns.cs
   ```

1. Examine the output.
   You can see that each line is processed by comparing the value of the text in the first field.

You could similarly construct the preceding sample by using the `==` operator to test that two `string` values are equal. Comparing a variable to a constant is a basic building block for pattern matching. Let's explore more of the building blocks that are part of pattern matching.

> [!TIP]
> **Learn more:** Read about [pattern matching](../../fundamentals/functional/pattern-matching.md) in the C# Fundamentals section for a comprehensive overview of all pattern types.

## Enum matches

Another common use for pattern matching is matching on the values of an `enum` type. The following sample processes the input records to create a *tuple* where the first value is an `enum` value that notes a deposit or a withdrawal. The second value is the value of the transaction.

1. Add the following code to the end of your source file. It defines the `TransactionType` enumeration:

   :::code language="csharp" source="./snippets/PatternMatching/patterns.cs" id="TransactionTypeEnum":::

1. Add a function to parse a bank transaction into a tuple that holds the transaction type and the value of the transaction. Add the following code before your declaration of the `TransactionType` enum:

   :::code language="csharp" source="./snippets/PatternMatching/patterns.cs" id="ParseTransaction":::

1. Add a new loop to process the transaction data by using the `TransactionType` enumeration you declared:

   :::code language="csharp" source="./snippets/PatternMatching/patterns.cs" id="EnumPatternMatch":::

The preceding example also uses an `if` statement to check the value of an `enum` expression. Another form of pattern matching uses a `switch` expression. Let's explore that syntax and how you can use it.

## Exhaustive matches with `switch`

A series of `if` statements can test a series of conditions. But, the compiler can't tell if a series of `if` statements are *exhaustive* or if later `if` conditions are *subsumed* by earlier conditions. *Exhaustive* means that one of the `if` or `else` clauses in the series of tests handles all possible inputs. If a series of `if` statements are exhaustive, every possible input satisfies at least one `if` or `else` clause. *Subsumption* means that a later `if` or `else` clause can't be reached because earlier `if` or `else` clauses match all possible inputs. For example, in the following example code, one clause never matches:

```csharp
int n = GetNumber();

if (n < 20)
    Console.WriteLine("n is less than 20");
else if (n < 10)
    Console.WriteLine("n is less than 10"); // unreachable
else
    Console.WriteLine("n is greater than 20");
```

The `else if` clause never matches because every number less than 10 is also less than 20. The `switch` expression ensures both of those characteristics are met, which results in fewer bugs in your apps. Let's try it and experiment.

1. Copy the following code. Replace the two `if` statements in your `foreach` loop with the `switch` expression you copied.

   :::code language="csharp" source="./snippets/PatternMatching/patterns.cs" id="SwitchEnumValue":::

1. Type `dotnet patterns.cs` in the terminal window to run the new sample.

   When you run the code, you see that it works the same.

1. To demonstrate *subsumption*, reorder the switch arms as shown in the following snippet:

   ```csharp
   currentBalance += transaction switch
   {
       (TransactionType.Deposit, var amount) => amount,
       _ => 0.0,
       (TransactionType.Withdrawal, var amount) => -amount,
   };
   ```

   After you reorder the switch arms, type `dotnet patterns.cs` in the terminal window. The compiler reports an error because the arm with `_` matches every value. As a result, that final arm with `TransactionType.Withdrawal` never runs. The compiler tells you that something's wrong in your code.

   The compiler reports a warning if the expression tested in a `switch` expression could contain values that don't match any switch arm. If some values can't match any condition, the `switch` expression isn't *exhaustive*. The compiler also reports a warning if some values of the input don't match any of the switch arms.

1. Remove the line with `_ => 0.0,`, so that any invalid values don't match.
1. Type `dotnet patterns.cs` to see the results.

   The compiler reports a warning. The test data is valid, so the program works. However, any invalid data would cause a failure at runtime.

## Type patterns

To finish this tutorial, explore one more building block for pattern matching: the *type pattern*. A *type pattern* tests an expression at run time to see if it's the specified type. You can use a type test with either an `is` expression or a `switch` expression. Modify the current sample in two ways. First, instead of a tuple, build `Deposit` and `Withdrawal` record types that represent the transactions.

1. Add the following declarations at the end of your code file:

   :::code language="csharp" source="./snippets/PatternMatching/patterns.cs" id="RecordDeclarations":::

1. Add this method just before the declaration of the `TransactionType` enumeration. It parses the text and returns a series of records:

   :::code language="csharp" source="./snippets/PatternMatching/patterns.cs" id="ParseToRecord":::

1. Add the following code after the last `foreach` loop:

   :::code language="csharp" source="./snippets/PatternMatching/patterns.cs" id="TypePattern":::

1. Type `dotnet patterns.cs` in the terminal window to see the results. This final version tests the input against a *type*.

Pattern matching provides a vocabulary to compare an expression against characteristics. Patterns can include the expression's type, values of types, property values, and combinations of them. Comparing expressions against a pattern can be clearer than multiple `if` comparisons. You explored some of the patterns you can use to match expressions. There are many more ways to use pattern matching in your applications. As you explore, you can learn more about pattern matching in C# in the following articles:

- [Pattern matching in C#](../../fundamentals/functional/pattern-matching.md)
- [Explore pattern matching tutorial](../../tutorials/patterns-objects.md)
- [Pattern matching scenario](../../fundamentals/tutorials/pattern-matching.md)
- [The C# type system](../../fundamentals/types/index.md) — Understand the types you matched against in this tutorial.

## Cleanup resources

GitHub automatically deletes your Codespace after 30 days of inactivity. You completed all the tutorials in this series. To delete your Codespace now, open a browser window and go to [your Codespaces](https://github.com/codespaces). You should see a list of your codespaces in the window. Select the three dots (`...`) in the entry for the learn tutorial codespace and select **delete**.

## Next steps

You completed all the introductory tutorials! Here's where to go next:

- [File-based programs](../../fundamentals/tutorials/file-based-programs.md) — Learn about the `dotnet run` command you used throughout these tutorials.
- [C# Fundamentals](../../fundamentals/program-structure/index.md) — Dive deeper into program structure, types, and object-oriented programming.
- [What you can build with C#](../what-you-can-build.md) — See the kinds of apps you can create with what you learned.
- Download and install the [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0).
- Download and install [Visual Studio Code](https://code.visualstudio.com/download).
- Download and install the [C# DevKit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit).
