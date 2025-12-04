---
title: Work with Numbers - Introductory tutorial
description: This tutorial teaches you about the numeric types in C#. The tutorial contains a series of lessons that explore numbers and math operations in C#. 
ms.date: 12/02/2025
---
# How to use integer and floating point numbers in C\#

This tutorial teaches you about the numeric types in C#. You write small amounts of code, then you compile and run that code. The tutorial contains a series of lessons that explore numbers and math operations in C#. These lessons teach you the fundamentals of the C# language.

## Explore integer math

Create a directory named *numbers-quickstart*. Make it the current directory and run the following command:

```dotnetcli
dotnet new console -n NumbersInCSharp -o .
```

Open *numbers.cs* in your favorite editor, and replace the contents of the file with the following code:

:::code language="csharp" source="./snippets/NumbersInCsharp/numbers.cs" id="Addition":::
Addition

Run this code by typing `dotnet run` in your command window.

You've seen one of the fundamental math operations with integers. The `int` type represents an **integer**, a zero, positive, or negative whole number. You use the `+` symbol for addition. Other common mathematical operations for integers include:

- `-` for subtraction
- `*` for multiplication
- `/` for division

Start by exploring those different operations. Add these lines after the line that writes the value of `c`:

:::code language="csharp" source="./snippets/NumbersInCsharp/numbers.cs" id="OtherOperations":::

Run this code by typing `dotnet run` in your command window.

You can also experiment by writing multiple mathematics operations in the same line, if you'd like. Try `c = a + b - 12 * 17;` for example. Mixing variables and constant numbers is allowed.

> [!TIP]
> As you explore C# (or any programming language), you'll make mistakes when you write code. The **compiler** will find those errors and report them to you. When the output contains error messages, look closely at the example code and the code in your window to see what to fix. That exercise will help you learn the structure of C# code.

You've finished the first step. Before you start the next section, let's move the current code into a separate *method*. A method is a series of statements grouped together and given a name. You call a method by writing the method's name followed by `()`. Organizing your code into methods makes it easier to start working with a new example. When you finish, your code should look like this:

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

Comment out the call to `WorkingWithIntegers()`. It will make the output less cluttered as you work in this section:

```csharp
//WorkWithIntegers();
```

The `//` starts a **comment** in C#. Comments are any text you want to keep in your source code but not execute as code. The compiler doesn't generate any executable code from comments. Because `WorkWithIntegers()` is a method, you need to only comment out one line.

The C# language defines the precedence of different mathematics operations with rules consistent with the rules you learned in mathematics. Multiplication and division take precedence over addition and subtraction. Explore that by adding the following code after the call to `WorkWithIntegers()`, and executing `dotnet run`:

:::code language="csharp" source="./snippets/NumbersInCsharp/numbers.cs" id="Precedence":::

The output demonstrates that the multiplication is performed before the addition.

You can force a different order of operation by adding parentheses around the operation or operations you want performed first. Add the following lines and run again:

:::code language="csharp" source="./snippets/NumbersInCsharp/numbers.cs" id="Parentheses":::

Explore more by combining many different operations. Add something like the following lines. Try `dotnet run` again.

:::code language="csharp" source="./snippets/NumbersInCsharp/numbers.cs" id="CompoundExpression":::

You may have noticed an interesting behavior for integers. Integer division always produces an integer result, even when you'd expect the result to include a decimal or fractional portion.

If you haven't seen this behavior, try the following code:

:::code language="csharp" source="./snippets/NumbersInCsharp/numbers.cs" id="Truncation":::

Type `dotnet run` again to see the results.

Before moving on, let's take all the code you've written in this section and put it in a new method. Call that new method `OrderPrecedence`. Your code should look something like this:

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

That last sample showed you that integer division truncates the result. You can get the **remainder** by using the **remaimnder** operator, the `%` character. Try the following code after the method call to `OrderPrecedence()`:

:::code language="csharp" source="./snippets/NumbersInCsharp/numbers.cs" id="QuotientAndRemainder":::

The C# integer type differs from mathematical integers in one other way: the `int` type has minimum and maximum limits. Try the following code to see those limits:

:::code language="csharp" source="./snippets/NumbersInCsharp/numbers.cs" id="MinAndMax":::

If a calculation produces a value that exceeds those limits, you have an **underflow** or **overflow** condition. The answer appears to wrap from one limit to the other. To see an example, add these two lines to your code:

:::code language="csharp" source="./snippets/NumbersInCsharp/numbers.cs" id="Overflow":::

Notice that the answer is very close to the minimum (negative) integer. It's the same as `min + 2`. The addition operation **overflowed** the allowed values for integers. The answer is a large negative number because an overflow "wraps around" from the largest possible integer value to the smallest.

There are other numeric types with different limits and precision that you would use when the `int` type doesn't meet your needs. Let's explore those types of numbers next.

## Work with the double type

The `double` numeric type represents a double-precision floating point number. Those terms may be new to you. A **floating point** number is useful to represent non-integral numbers that may be very large or small in magnitude. **Double-precision** is a relative term that describes the number of binary digits used to store the value. **Double precision** numbers have twice the number of binary digits as **single-precision**. On modern computers, it's more common to use double precision than single precision numbers. **Single precision** numbers are declared using the `float` keyword. Let's explore. Add the following code and see the result:

:::code language="csharp" source="./snippets/NumbersInCsharp/numbers.cs" id="FloatingPoint":::

Notice that the answer includes the decimal portion of the quotient. Try a slightly more complicated expression with doubles. You can use the following values, or substitute other numbers:

:::code language="csharp" source="./snippets/NumbersInCsharp/numbers.cs" id="ChangeDoubleValues":::

The range of a double value is much greater than integer values. Try the following code below what you've written so far:

:::code language="csharp" source="./snippets/NumbersInCsharp/numbers.cs" id="MinMax":::

These values are printed in scientific notation. The number to the left of the `E` is the significand. The number to the right is the exponent, as a power of 10. Just like decimal numbers in math, doubles in C# can have rounding errors. Try this code:

:::code language="csharp" source="./snippets/NumbersInCsharp/numbers.cs" id="RoundingError":::

You know that `0.3` is `3/10` and not exactly the same as `1/3`. Similarly, `0.33` is `33/100`. That value is closer to `1/3`, but still not exact. No matter how many decimal places you add, a rounding error remains.

***Challenge***

Try other calculations with large numbers, small numbers, multiplication, and division using the `double` type. Try more complicated calculations. After you've spent some time with the challenge, take the code you've written and place it in a new method. Name that new method `WorkWithDoubles`.

## Work with decimal types

You've seen the basic numeric types in C#: integers and doubles. There's one other type to learn: the `decimal` type. The `decimal` type has a smaller range but greater precision than `double`. Let's take a look:

:::code language="csharp" source="./snippets/NumbersInCsharp/numbers.cs" id="Decimal":::

There's one other type to learn: the `decimal` type. The `decimal` type has a smaller range but greater precision than `double`. Let's take a look:

Notice that the range is smaller than the `double` type. You can see the greater precision with the decimal type by trying the following code:

:::code language="csharp" source="./snippets/NumbersInCsharp/numbers.cs" id="Precision":::

Notice that the math using the decimal type has more digits to the right of the decimal point.

The `M` suffix on the numbers is how you indicate that a constant should use the `decimal` type. Otherwise, the compiler assumes the `double` type.

> [!NOTE]
> The letter `M` was chosen as the most visually distinct letter between the `double` and `decimal` keywords.
Notice that the math using the decimal type has more digits to the right of the decimal point.

***Challenge***

Now that you've seen the different numeric types, write code that calculates the area of a circle whose radius is 2.50 centimeters. Remember that the area of a circle is the radius squared multiplied by PI. One hint: .NET contains a constant for PI, <xref:System.Math.PI?displayProperty=nameWithType> that you can use for that value. <xref:System.Math.PI?displayProperty=nameWithType>, like all constants declared in the `System.Math` namespace, is a `double` value. For that reason, you should use `double` instead of `decimal` values for this challenge.

You should get an answer between 19 and 20.

Once you try it, open the details pane to see how you did:

<!-- markdownlint-disable MD033 -->
<details>

:::code language="csharp" interactive="try-dotnet-method" source="./snippets/NumbersInCsharp/numbers.cs" id="Challenge":::
</details>
<!-- markdownlint-enable MD033 -->

Try some other formulas if you'd like.

You completed the "Numbers in C#" tutorial. You can select the **Tuples and types** link to start the next tutorial, or you can visit the [.NET site](https://dotnet.microsoft.com/learn/dotnet/hello-world-tutorial/intro) to download the .NET SDK, create a project on your machine, and keep coding. The "Next steps" section brings you back to these tutorials.

You can learn more about numbers in C# in the following articles:

- [Integral numeric types](../../language-reference/builtin-types/integral-numeric-types.md)
- [Floating-point numeric types](../../language-reference/builtin-types/floating-point-numeric-types.md)
- [Built-in numeric conversions](../../language-reference/builtin-types/numeric-conversions.md)
