---
title: Work with Numbers - Introductory tutorial
description: This tutorial teaches you about the numeric types in C#. The tutorial contains a series of lessons that explore numbers and math operations in C#.
ms.date: 02/06/2026
---
# Tutorial: How to use integer and floating point numbers in C\#

This tutorial teaches you about the numeric types in C#. You write small amounts of code, then you compile and run that code. The tutorial contains a series of lessons that explore numbers and math operations in C#. These lessons teach you the fundamentals of the C# language.

> [!TIP]
> **New to programming?** Work through each section in order. **Coming from another language?** You might already know integer vs. floating-point distinctions - skim the basics and focus on the [precision and limits](#explore-integer-precision-and-limits) and [decimal type](#work-with-decimal-types) sections.

In this tutorial, you:

> [!div class="checklist"]
>
> * Launch a GitHub Codespace with a C# development environment.
> * Explore integer math.
> * Learn order of operations.
> * Learn integer limits and precision.
> * Learn floating point types.
> * Learn the decimal type.

## Prerequisites

You must have one of the following options:

- A GitHub account to use [GitHub Codespaces](https://github.com/codespaces). If you don't already have one, you can create a free account at [GitHub.com](https://github.com).
- A computer with the following tools installed:
  - The [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0).
  - [Visual Studio Code](https://code.visualstudio.com/download).
  - The [C# DevKit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit).

## Explore integer math

To start a GitHub Codespace with the tutorial environment, open a browser window to the [tutorial codespace](https://github.com/dotnet/tutorial-codespace) repository. Select the green *Code* button, and the *Codespaces* tab. Then select the `+` sign to create a new Codespace using this environment. If you completed the [hello world](./hello-world.md) tutorial, you can open that codespace instead of creating a new one.

1. When your codespace loads, create a new file in the *tutorials* folder named *numbers.cs*.
1. Open your new file.
1. Type or copy the following code into *numbers.cs*:

   :::code language="csharp" source="./snippets/NumbersInCsharp/numbers.cs" id="Addition":::

1. Run this code by typing the following commands in the integrated terminal:

   ```dotnetcli
   cd ./tutorials
   dotnet numbers.cs
   ```

   You saw one of the fundamental math operations with integers. The `int` type represents an **integer**, a zero, positive, or negative whole number. You use the `+` symbol for addition. Other common mathematical operations for integers include:

   - `-` for subtraction
   - `*` for multiplication
   - `/` for division

1. Start by exploring those different operations. Add these lines after the line that writes the value of `c`:

   :::code language="csharp" source="./snippets/NumbersInCsharp/numbers.cs" id="OtherOperations":::

1. Run this code by typing `dotnet numbers.cs` in the terminal window.

You can also experiment by writing multiple mathematics operations in the same line, if you'd like. Try `c = a + b - 12 * 17;` for example. Mixing variables and constant numbers is allowed.

> [!TIP]
> As you explore C# (or any programming language), you might make mistakes when you write code. The **compiler** finds those errors and reports them to you. When the output contains error messages, look closely at the example code and the code in your window to see what to fix. You can also ask Copilot to find differences or spot mistakes. That exercise helps you learn the structure of C# code.

You finished the first step. Before you start the next section, move the current code into a separate *method*. A method is a series of statements grouped together and given a name. You call a method by writing the method's name followed by `()`. Organizing your code into methods makes it easier to start working with a new example.

> [!TIP]
> **Learn more:** Read about [methods and program structure](../../fundamentals/program-structure/index.md) in C# Fundamentals.

When you finish, your code should look like this:

```csharp
WorkWithIntegers();

void WorkWithIntegers()
{
    int a = 18;
    int b = 6;
    int c = a + b;
    Console.WriteLine(c);


    // subtraction
    c = a - b;
    Console.WriteLine(c);

    // multiplication
    c = a * b;
    Console.WriteLine(c);

    // division
    c = a / b;
    Console.WriteLine(c);
}
```

## Explore order of operations

1. Comment out the call to `WorkingWithIntegers()`. This change makes the output less cluttered as you work in this section:

   ```csharp
   //WorkWithIntegers();
   ```

   The `//` starts a **comment** in C#. Comments are any text you want to keep in your source code but not execute as code. The compiler doesn't generate any executable code from comments. Because `WorkWithIntegers()` is a method, you need to comment out only one line.

1. The C# language defines the precedence of different mathematics operations with rules consistent with the rules you learned in mathematics. Multiplication and division take precedence over addition and subtraction. Explore that precedence by adding the following code after the call to `WorkWithIntegers()`, and typing `dotnet numbers.cs` in the terminal window:

   :::code language="csharp" source="./snippets/NumbersInCsharp/numbers.cs" id="Precedence":::

   The output demonstrates that the multiplication is performed before the addition.

1. You can force a different order of operation by adding parentheses around the operation or operations you want performed first. Add the following lines and run the app again:

   :::code language="csharp" source="./snippets/NumbersInCsharp/numbers.cs" id="Parentheses":::

1. Explore more by combining many different operations. Add something like the following lines. Try `dotnet numbers` again in the terminal window.

   :::code language="csharp" source="./snippets/NumbersInCsharp/numbers.cs" id="CompoundExpression":::

   You might notice an interesting behavior for integers. Integer division always produces an integer result, even when you'd expect the result to include a decimal or fractional portion.

1. If you didn't see this behavior, try the following code:

   :::code language="csharp" source="./snippets/NumbersInCsharp/numbers.cs" id="Truncation":::

1. Type `dotnet numbers.cs` again in the terminal window to see the results.

Before moving on, take all the code you wrote in this section and put it in a new method. Call that new method `OrderPrecedence`. Your code should look something like this:

```csharp
// WorkWithIntegers();
OrderPrecedence();

void WorkWithIntegers()
{
    int a = 18;
    int b = 6;
    int c = a + b;
    Console.WriteLine(c);


    // subtraction
    c = a - b;
    Console.WriteLine(c);

    // multiplication
    c = a * b;
    Console.WriteLine(c);

    // division
    c = a / b;
    Console.WriteLine(c);
}

void OrderPrecedence()
{
    int a = 5;
    int b = 4;
    int c = 2;
    int d = a + b * c;
    Console.WriteLine(d);

    d = (a + b) * c;
    Console.WriteLine(d);

    d = (a + b) - 6 * c + (12 * 4) / 3 + 12;
    Console.WriteLine(d);

    int e = 7;
    int f = 4;
    int g = 3;
    int h = (e + f) / g;
    Console.WriteLine(h);
}
```

## Explore integer precision and limits

The previous sample showed that integer division truncates the result. You can get the **remainder** by using the **remainder** operator, the `%` character.

1. Try the following code after the method call to `OrderPrecedence()`:

   :::code language="csharp" source="./snippets/NumbersInCsharp/numbers.cs" id="QuotientAndRemainder":::

1. The C# integer type differs from mathematical integers in one other way: the `int` type has minimum and maximum limits. Try the following code to see those limits:

   :::code language="csharp" source="./snippets/NumbersInCsharp/numbers.cs" id="MinAndMax":::

1. If a calculation produces a value that exceeds those limits, you get an **underflow** or **overflow** condition. The answer appears to wrap from one limit to the other. To see an example, add these two lines to your code:

   :::code language="csharp" source="./snippets/NumbersInCsharp/numbers.cs" id="Overflow":::

Notice that the answer is very close to the minimum (negative) integer. It's the same as `min + 2`. The addition operation **overflowed** the allowed values for integers. The answer is a large negative number because an overflow "wraps around" from the largest possible integer value to the smallest.

If the `int` type doesn't meet your needs, use other numeric types with different limits and precision. Let's explore those types of numbers next.

## Work with the double type

The `double` numeric type represents a double-precision floating point number. Those terms might be new to you. A **floating point** number is useful for representing non-integral numbers that can be very large or small in magnitude. **Double-precision** is a relative term that describes the number of binary digits used to store the value. **Double precision** numbers have twice the number of binary digits as **single-precision**. On modern computers, you more commonly use double precision than single precision numbers. **Single precision** numbers are declared by using the `float` keyword. Let's explore.

1. Add the following code and see the result:

   :::code language="csharp" source="./snippets/NumbersInCsharp/numbers.cs" id="FloatingPoint":::

   Notice that the answer includes the decimal portion of the quotient.

1. Try a slightly more complicated expression with doubles. You can use the following values, or substitute other numbers:

   :::code language="csharp" source="./snippets/NumbersInCsharp/numbers.cs" id="ChangeDoubleValues":::

1. The range of a double value is much greater than integer values. Try the following code that you add to what you wrote so far:

   :::code language="csharp" source="./snippets/NumbersInCsharp/numbers.cs" id="MinMax":::

   These values are printed in scientific notation. The number to the left of the `E` is the significand. The number to the right is the exponent, as a power of 10.

1. Just like decimal numbers in math, doubles in C# can have rounding errors. Try this code:

   :::code language="csharp" source="./snippets/NumbersInCsharp/numbers.cs" id="RoundingError":::

   You know that `0.3` is `3/10` and not exactly the same as `1/3`. Similarly, `0.33` is `33/100`. That value is closer to `1/3`, but still not exact. No matter how many decimal places you add, a rounding error remains.

***Challenge***

Try other calculations with large numbers, small numbers, multiplication, and division by using the `double` type. Try more complicated calculations. After you spend some time with the challenge, take the code you wrote and place it in a new method. Name that new method `WorkWithDoubles`.

## Work with decimal types

You saw the basic numeric types in C#: integers and doubles. There's one other type to learn: the `decimal` type. The `decimal` type has a smaller range but greater precision than `double`.

1. Let's take a look:

   :::code language="csharp" source="./snippets/NumbersInCsharp/numbers.cs" id="Decimal":::

   Notice that the range is smaller than the `double` type.

1. You can see the greater precision with the decimal type by trying the following code:

   :::code language="csharp" source="./snippets/NumbersInCsharp/numbers.cs" id="Precision":::

   Notice that the math with the decimal type has more digits to the right of the decimal point.

   The `M` suffix on the numbers indicates that a constant should use the `decimal` type. Otherwise, the compiler assumes the `double` type.

> [!NOTE]
> The letter `M` is the most visually distinct letter between the `double` and `decimal` keywords.

***Challenge***

Now that you know the different numeric types, write code that calculates the area of a circle whose radius is 2.50 centimeters. Remember that the area of a circle is the radius squared multiplied by PI. One hint: the runtime contains a constant for PI, <xref:System.Math.PI?displayProperty=nameWithType> that you can use for that value. <xref:System.Math.PI?displayProperty=nameWithType>, like all constants declared in the `System.Math` namespace, is a `double` value. For that reason, you should use `double` instead of `decimal` values for this challenge.

You should get an answer between 19 and 20.

<!-- markdownlint-disable MD033 -->
<details>

:::code language="csharp" source="./snippets/NumbersInCsharp/numbers.cs" id="Challenge":::
</details>
<!-- markdownlint-enable MD033 -->

Try some other formulas if you'd like.

## Cleanup resources

GitHub automatically deletes your Codespace after 30 days of inactivity. If you plan to explore more tutorials in this series, you can leave your Codespace provisioned. If you're ready to visit the [.NET site](https://dotnet.microsoft.com/download/dotnet) to download the .NET SDK, you can delete your Codespace. To delete your Codespace, open a browser window and go to [your Codespaces](https://github.com/codespaces). You should see a list of your codespaces in the window. Select the three dots (`...`) in the entry for the learn tutorial codespace and select **delete**.

## Next steps

Continue with the next tutorial in this series:

> [!div class="nextstepaction"]
> [Tuples and types](tuples-and-types.md)

Or explore related topics in C# Fundamentals:

- [The C# type system](../../fundamentals/types/index.md) — Dive deeper into the types you used in this tutorial.
- [Methods and program structure](../../fundamentals/program-structure/index.md) — Learn more about the methods you created to organize your code.
- [What you can build with C#](../what-you-can-build.md) — See the kinds of apps you can create with what you're learning.
- [Numeric types in C# Fundamentals](../../fundamentals/types/index.md) — Understand how C# represents numbers in the type system.
- [Integral numeric types](../../language-reference/builtin-types/integral-numeric-types.md)
- [Floating-point numeric types](../../language-reference/builtin-types/floating-point-numeric-types.md)
- [Built-in numeric conversions](../../language-reference/builtin-types/numeric-conversions.md)
