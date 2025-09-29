---
title: Work with Numbers - Introductory interactive tutorial
description: In this tutorial about numeric types, you use your browser to learn C# interactively. You're going to write C# code and see the results of compiling and running your code directly in the browser.
ms.date: 03/06/2025
---
# How to use integer and floating point numbers in C\#

This tutorial teaches you about the numeric types in C#. You write small amounts of code, then you compile and run that code. The tutorial contains a series of lessons that explore numbers and math operations in C#. These lessons teach you the fundamentals of the C# language.

> [!TIP]
>
> When a code snippet block includes the "Run" button, that button opens the interactive window, or replaces the existing code in the interactive window. When the snippet doesn't include a "Run" button, you can copy the code and add it to the current interactive window.

## Explore integer math

Run the following code in the interactive window.

:::code language="csharp" interactive="try-dotnet-method" source="./snippets/NumbersInCsharp/Program.cs" id="Addition":::

The preceding code demonstrates  fundamental math operations with integers. The `int` type represents an **integer**, a positive or negative whole number. You use the `+` symbol for addition. Other common mathematical operations for integers include:

- `-` for subtraction
- `*` for multiplication
- `/` for division

Start by exploring those different operations. Modify the third line to try each of these operations. For example, to try subtraction, replace the `+` with a `-` as shown in the following line:

```csharp
int c = a - b;
```

Try it. Select the "Run" button. Then, try multiplication, `*` and, division, `/`. You can also experiment by writing multiple mathematics operations in the same line, if you'd like.

> [!TIP]
>
> As you explore C# (or any programming language), you make mistakes when you write code. The **compiler** finds those errors and report them to you. When the output contains error messages, look closely at the example code, and the code in the interactive window to see what to fix. That exercise helps you learn the structure of C# code.

## Explore order of operations

The C# language defines the precedence of different mathematics operations with rules consistent with the rules you learned in mathematics. Multiplication and division take precedence over addition and subtraction. Explore that by running the following code in the interactive window:

:::code language="csharp" interactive="try-dotnet-method" source="./snippets/NumbersInCsharp/Program.cs" id="Precedence":::

The output demonstrates that the multiplication is performed before the addition.

You can force a different order of operation by adding parentheses around the operation or operations you want performed first. Add the following lines to the interactive window:

:::code language="csharp" source="./snippets/NumbersInCsharp/Program.cs" id="Parentheses":::

Explore more by combining many different operations. Replace the fourth line in the preceding code with something like this:

:::code language="csharp" source="./snippets/NumbersInCsharp/Program.cs" id="CompoundExpression":::

You might notice an interesting behavior for integers. Integer division always produces an integer result, even when you'd expect the result to include a decimal or fractional portion.

Try the following code:

:::code language="csharp" interactive="try-dotnet-method" source="./snippets/NumbersInCsharp/Program.cs" id="Truncation":::

## Explore integer precision and limits

That last sample showed you that integer division truncates the result. You can get the **remainder** by using the **remainder** operator, the `%` character:

:::code language="csharp" interactive="try-dotnet-method" source="./snippets/NumbersInCsharp/Program.cs" id="QuotientAndRemainder":::

The C# integer type differs from mathematical integers in one other way: the `int` type has minimum and maximum limits. Try the following code to see those limits:

:::code language="csharp" source="./snippets/NumbersInCsharp/Program.cs" id="MinAndMax":::

If a calculation produces a value that exceeds those limits, you have an **underflow** or **overflow** condition. The answer appears to wrap from one limit to the other. To see an example, add these two lines in the interactive window:

:::code language="csharp" source="./snippets/NumbersInCsharp/Program.cs" id="Overflow":::

Notice that the answer is very close to the minimum (negative) integer. It's the same as `min + 2`. The addition operation **overflowed** the allowed values for integers. The answer is a large negative number because an overflow "wraps around" from the largest possible integer value to the smallest.

There are other numeric types with different limits and precision that you would use when the `int` type doesn't meet your needs. Let's explore those types of numbers next.

## Work with the double type

The `double` numeric type represents a double-precision floating point number. Those terms might be new to you. A **floating point** number is useful to represent nonintegral numbers that might be large or small in magnitude. **Double-precision** is a relative term that describes the number of binary digits used to store the value. **Double precision** numbers have twice the number of binary digits as **single-precision**. On modern computers, it's more common to use double precision than single precision numbers. **Single precision** numbers are declared using the `float` keyword. Let's explore. Run the following code and see the result:

:::code language="csharp" interactive="try-dotnet-method" source="./snippets/NumbersInCsharp/Program.cs" id="FloatingPoint":::

Notice that the answer includes the decimal portion of the quotient. Try a slightly more complicated expression with doubles. You can use the following values, or substitute other numbers:

:::code language="csharp" source="./snippets/NumbersInCsharp/Program.cs" id="ChangeDoubleValues":::

The range of a double value is greater than integer values. Try the following code in the interactive window:

:::code language="csharp" source="./snippets/NumbersInCsharp/Program.cs" id="MinMax":::

These values are printed in scientific notation. The number before the `E` is the significand. The number after the `E` is the exponent, as a power of 10.

Just like decimal numbers in math, doubles in C# can have rounding errors. Try this code:

:::code language="csharp" source="./snippets/NumbersInCsharp/Program.cs" id="RoundingError":::

You know that `0.3` is `3/10` and not exactly the same as `1/3`. Similarly, `0.33` is `33/100`. That value is closer to `1/3`, but still not exact. No matter how many decimal places you add, a rounding error remains.

***Challenge***

Try other calculations with large numbers, small numbers, multiplication, and division using the `double` type. Try more complicated calculations.

## Work with decimal types

There's one other type to learn: the `decimal` type. The `decimal` type has a smaller range but greater precision than `double`. Let's take a look:

:::code language="csharp" interactive="try-dotnet-method" source="./snippets/NumbersInCsharp/Program.cs" id="Decimal":::

Notice that the range is smaller than the `double` type. You can see the greater precision with the decimal type by trying the following code:

:::code language="csharp" source="./snippets/NumbersInCsharp/Program.cs" id="Precision":::

Notice that the math using the decimal type has more digits to the right of the decimal point.

The `M` suffix on the numbers is how you indicate that a constant should use the `decimal` type. Otherwise, the compiler assumes the `double` type.

> [!NOTE]
> The letter `M` was chosen as the most visually distinct letter between the `double` and `decimal` keywords.

***Challenge***

Write code that calculates the area of a circle whose radius is 2.50 centimeters. Remember that the area of a circle is the radius squared multiplied by PI. One hint: .NET contains a constant for PI, <xref:System.Math.PI?displayProperty=nameWithType> that you can use for that value. <xref:System.Math.PI?displayProperty=nameWithType>, like all constants declared in the `System.Math` namespace, is a `double` value. For that reason, you should use `double` instead of `decimal` values for this challenge.

You should get an answer between 19 and 20.

Once you try it, open the details pane to see how you did:

<!-- markdownlint-disable MD033 -->
<details>

:::code language="csharp" interactive="try-dotnet-method" source="./snippets/NumbersInCsharp/Program.cs" id="Challenge":::
</details>
<!-- markdownlint-enable MD033 -->

Try some other formulas if you'd like.

You completed the "Numbers in C#" interactive tutorial. You can select the **Tuples and types** link to start the next interactive tutorial, or you can visit the [.NET site](https://dotnet.microsoft.com/learn/dotnet/hello-world-tutorial/intro) to download the .NET SDK, create a project on your machine, and keep coding. The "Next steps" section brings you back to these tutorials.

You can learn more about numbers in C# in the following articles:

- [Integral numeric types](../../language-reference/builtin-types/integral-numeric-types.md)
- [Floating-point numeric types](../../language-reference/builtin-types/floating-point-numeric-types.md)
- [Built-in numeric conversions](../../language-reference/builtin-types/numeric-conversions.md)
