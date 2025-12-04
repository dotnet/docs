---
title: Pattern matching
description: In this tutorial about pattern matching, you learn C#. You're going to write C# code and see the results of compiling and running your code.
ms.date: 12/04/2025
---
# Match data against patterns

This tutorial teaches you how to use pattern matching to inspect data in C#. You write small amounts of code, then you compile and run that code. The tutorial contains a series of lessons that explore different kinds of patterns supported by C#. These lessons teach you the fundamentals of the C# language.

The preceding tutorials demonstrated built-in types and types you define as tuples or records. Instances of these types can be checked against a *pattern*. Whether an instance matches a pattern determines the actions your program takes. In the examples below, you'll notice `?` after type names. This symbol allows the value of this type to be null (for example, `bool?` can be `true`, `false` or `null`). For more information, see [Nullable value types](../../language-reference/builtin-types/nullable-value-types.md).  Let's start to explore how you can use patterns.

<< TO DO: Make your app >>

## Match a value

All the examples in this tutorial use text input that represents a series of bank transactions as comma separated values (CSV) input. In each of the samples you can match the record against a pattern using either an `is` or `switch` expression. This first example splits each line on the `,` character and then *matches* the first string field against the value "DEPOSIT" or "WITHDRAWAL" using an `is` expression. When it matches, the transaction amount is added or deducted from the current account balance. To see it work, add the following code to your source file. Then, type `dotnet run` in the console window.

:::code language="csharp" source="./snippets/PatternMatching/patterns.cs" id="FirstExample":::

Examine the output. You can see that each line is processed by comparing the value of the text in the first field. The preceding sample could be similarly constructed using the `==` operator to test that two `string` values are equal. Comparing a variable to a constant is a basic building block for pattern matching. Let's explore more of the building blocks that are part of pattern matching.

## Enum matches

Another common use for pattern matching is to match on the values of an `enum` type. This next sample processes the input records to create a *tuple* where the first value is an `enum` value that notes a deposit or a withdrawal. The second value is the value of the transaction. Add the following code to the end of your source file. It defines the `TransactionType` enumeration:

:::code language="csharp" source="./snippets/PatternMatching/patterns.cs" id="TransactionTypeEnum":::

Next, add a function to parse a bank transaction into a tuple that holds the transaction type and the value of the transaction. Add the following code before your declaration of the `TransactionType` enum:

:::code language="csharp" source="./snippets/PatternMatching/patterns.cs" id="ParseTransaction":::

Next, add a new loop to process the transaction data using the `TransactionType` enumeration you declared:

:::code language="csharp" source="./snippets/PatternMatching/patterns.cs" id="EnumPatternMatch":::

The preceding example also uses an `if` statement to check the value of an `enum` expression. Another form of pattern matching uses a `switch` expression. Let's explore that syntax and how you can use it.

## Exhaustive matches with `switch`

A series of `if` statements can test a series of conditions. But, the compiler can't tell if a series of `if` statements are *exhaustive* or if later `if` conditions are *subsumed* by earlier conditions. *Exhaustive* means that all possible inputs are handled by one of the `if` or `else` clauses in the series of tests. If a series of `if` statements are exhaustive, every possible input satisfies at least one `if` or `else` clause. *Subsumption* means that a later `if` or `else` clause can't be reached because earlier `if` or `else` clauses match all possible inputs. For example, in the following example code, one clause never matches:

```csharp
int n = GetNumber();

if (n < 20)
    Console.WriteLine("n is less than 20");
else if (n < 10)
    Console.WriteLine("n is less than 10"); // unreachable
else
    Console.WriteLine("n is greater than 20");
```

The `else if` clause never matches because every number less than 10 is also less than 20. The `switch` expression ensures both of those characteristics are met, which results in fewer bugs in your apps. Let's try it and experiment. Copy the following code. Replace the two `if` statements in your `foreach` loop with the `switch` expression you copied. After you've modified the code, type `dotnet run` to run the new sample.

:::code language="csharp" source="./snippets/PatternMatching/patterns.cs" id="SwitchEnumValue":::

When you run the code, you see that it works the same. To demonstrate *subsumption*, reorder the switch arms as shown in the following snippet:

```csharp
currentBalance += transaction switch
{
    (TransactionType.Deposit, var amount) => amount,
    _ => 0.0,
    (TransactionType.Withdrawal, var amount) => -amount,
};
```

After you reorder the switch arms, type `dotnet run`. The compiler issues an error because the arm with `_` matches every value. As a result, that final arm with `TransactionType.Withdrawal` never runs. The compiler tells you that something's wrong in your code.

The compiler issues a warning if the expression tested in a `switch` expression could contain values that don't match any switch arm. If some values could fail to match any condition, the `switch` expression isn't *exhaustive*. The compiler also issues a warning if some values of the input don't match any of the switch arms. For example, if you remove the line with `_ => 0.0,`, any invalid values don't match. At run time, that would fail. Once you install the .NET SDK and build programs in your environment, you can test this behavior. The online experience doesn't display warnings in the output window.

## Type patterns

To finish this tutorial, let's explore one more building block to pattern matching: the *type pattern*. A *type pattern* tests an expression at run time to see if it's the specified type. You can use a type test with either an `is` expression or a `switch` expression. Let's modify the current sample in two ways. First, instead of a tuple, let's build `Deposit` and `Withdrawal` record types that represent the transactions. Add the following declarations just at the end of the your code file:

:::code language="csharp" source="./snippets/PatternMatching/patterns.cs" id="RecordDeclarations":::

Next, add this method just before the declaration of the `TransactionType` enumeration. It parses the text and return a series of records:

:::code language="csharp" source="./snippets/PatternMatching/patterns.cs" id="ParseToRecord":::

Finally, add the following code after the last `foreach` loop:

:::code language="csharp" source="./snippets/PatternMatching/patterns.cs" id="TypePattern":::

Then, type `dotnet run` to see the results. This final version tests the input against a *type*.

Pattern matching provides a vocabulary to compare an expression against characteristics. Patterns can include the expression's type, values of types, property values, and combinations of them. Comparing expressions against a pattern can be more clear than multiple `if` comparisons. You explored some of the patterns you can use to match expressions. There are many more ways to use pattern matching in your applications. First, visit the [.NET site](https://dotnet.microsoft.com/learn/dotnet/hello-world-tutorial/intro) to download the .NET SDK, create a project on your machine, and keep coding. As you explore, you can learn more about pattern matching in C# in the following articles:

- [Pattern matching in C#](../../fundamentals/functional/pattern-matching.md)
- [Explore pattern matching tutorial](../../tutorials/patterns-objects.md)
- [Pattern matching scenario](../../fundamentals/tutorials/pattern-matching.md)
