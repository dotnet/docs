---
title: Numbers in C# tutorial - C# local quickstarts
description: Learn C# by exploring numeric types, their properties and methods.
author: billwagner
ms.author: wiwagn
ms.date: 10/31/2017
ms.topic: get-started-article
ms.prod: .net
ms.technology: devlang-csharp
ms.devlang: csharp
ms.custom: mvc
---

# Numbers in C# quickstart

This quickstart teaches you about the number types in C# interactively. You'll write small amounts of code, then you'll compile and run that code. The quickstart contains a series of lessons that explore numbers and math operations in C#. These lessons teach you the fundamentals of the C# language.

This quickstart expects you to have a machine you can use for development. The .NET topic [Get Started in 10 minutes](https://www.microsoft.com/net/core) has instructions for setting up your local development environment on Mac, PC or Linux. A quick overview of the commands you'll use is in the [introduction to the local quickstarts](local-environment.md) with links to more details.

## Explore integer math

Create a directory named **numbers-quickstart**. Make that the current directory and run `dotnet new console -n NumbersInCSharp -o .`.

Open **Program.cs** in your favorite editor, and replace the line `Console.Writeline("Hello World!");` with the following:

```csharp
int a = 18;
int b = 6;
int c = a + b;
Console.WriteLine(c);
```

Run this code by typing `dotnet run` in your command window. 

You've just seen one of the fundamental math operations with integers. The `int` type represents an **integer**, a positive or negative whole number. You use the `+` symbol for addition. Other common mathematical operations for integers include:

- `-` for subtraction
- `*` for multiplication
- `/` for division

Start by exploring those different operations. Add these lines after the line that writes the value of `c`:

```csharp
c = a - b;
Console.WriteLine(c);
c = a * b;
Console.WriteLine(c);
c = a / b;
Console.WriteLine(c);
```

Run this code by typing `dotnet run` in your command window. 
    
You can also experiment by performing multiple mathematics operations in the same line, if you'd like. Try `c = a + b - 12 * 17;` for example. Mixing variables and constant numbers is allowed.

> [!TIP]
> As you explore C# (or any programming language), you'll
> make mistakes when you write code. The **compiler** will
> find those errors and report them to you. When the output
> contains error messages, look closely at the example code
> and the code in your window to see what to fix.
> That exercise will help you learn the structure of C# code.     

You've finished the first step. Before you start the next section, let's move the current code into a separate method. That makes it easier to start working with a new example. Rename your `Main` method to `WorkingWithIntegers` and write a new `Main` method that calls `WorkingWithIntegers`. When you have finished, your code should look like this:

```csharp
using System;

namespace NumbersInCSharp
{
    class Program
    {
        static void WorkingWithIntegers()
        {
            int a = 18;
            int b = 6;
            int c = a + b;
            Console.WriteLine(c);
            c = a - b;
            Console.WriteLine(c);
            c = a * b;
            Console.WriteLine(c);
            c = a / b;
            Console.WriteLine(c);
        }

        static void Main(string[] args)
        {
            WorkingWithIntegers();
        }
    }
}
```

## Explore order of operations

Comment out the call to `WorkingWithIntegers()`. It will make the output less cluttered as you work in this section:

```csharp
//WorkingWithIntegers();
```

The `//` starts a **comment** in C#. Comments are any text you want to keep in your source code but not execute as code. The compiler does not generate any executable code from comments.

The C# language defines the precedence of different mathematics operations
with rules consistent with the rules you learned in mathematics.
Multiplication and division take precedence over addition and subtraction.
Explore that by adding the following code to your `Main` method, and execuing
`dotnet run`:

```csharp
int a = 5;
int b = 4;
int c = 2;
int d = a + b * c;
Console.WriteLine(d);
 ```

The output demonstrates that the multiplication is performed before the addition.

You can force a different order of operation by adding parentheses around
the operation or operations you want performed first. Add the following
lines and run again:

```csharp
d = (a  + b) * c;
Console.WriteLine(d);
```

Explore more by combining many different operations. Add something like
the following lines at the bottom of your `Main` method. Try `dotnet run` again.

```csharp
d = (a + b) - 6 * c + (12 * 4) / 3 + 12;
Console.WriteLine(d);
```

You may have noticed an interesting behavior for integers. Integer
division always produces an integer result, even when you'd expect the result to include a decimal or fractional portion.

If you haven't seen this behavior, try the following code at the end
of your `Main` method:

```csharp
int e = 7;
int f = 4;
int g = 3;
int h = (e  + f) / g;
Console.WriteLine(h);
```

Type `dotnet run` again to see the results.

Before moving on, let's take all the code you've written in this
section and put it in a new method. Call that new method `OrderPrecedence`.
You should end up with something like this:

```csharp
using System;

namespace NumbersInCSharp
{
    class Program
    {
        static void WorkingWithIntegers()
        {
            int a = 18;
            int b = 6;
            int c = a + b;
            Console.WriteLine(c);
            c = a - b;
            Console.WriteLine(c);
            c = a * b;
            Console.WriteLine(c);
            c = a / b;
            Console.WriteLine(c);
        }

        static void OrderPrecedence()
        {   
            int a = 5;
            int b = 4;
            int c = 2;
            int d = a + b * c;
            Console.WriteLine(d);

            d = (a  + b) * c;
            Console.WriteLine(d);

            d = (a + b) - 6 * c + (12 * 4) / 3 + 12;
            Console.WriteLine(d);

            int e = 7;
            int f = 4;
            int g = 3;
            int h = (e  + f) / g;
            Console.WriteLine(h);
        }

        static void Main(string[] args)
        {
            WorkingWithIntegers();

            OrderPrecedence();

        }
    }
}
```

## Explore integer precision and limits
That last sample showed you that integer division truncates the result.
You can get the **remainder** by using the **modulo** operator, the `%` character. Try the following code in your `Main` method:

```csharp
int a = 7;
int b = 4;
int c = 3;
int d = (a  + b) / c;
int e = (a + b) % c;
Console.WriteLine($"quotient: {d}");
Console.WriteLine($"remainder: {e}");
```

The C# integer type differs from mathematical integers in one other
way: the `int` type has minimum and maximum limits. Add this code to
your `Main` method to see those limits:
    
```csharp
int max = int.MaxValue;
int min = int.MinValue;
Console.WriteLine($"The range of integers is {min} to {max}");
```

If a calculation produces a value that exceeds those limits, you
have an **underflow** or **overflow** condition. The answer appears
to wrap from one limit to the other. Add these two lines to your `Main`
method to see an example:

```csharp
int what = max + 3;
Console.WriteLine($"An example of overflow: {what}");
```
    
Notice that the answer is very close to the minimum (negative) integer. It's
the same as `min + 2`. 
The addition operation **overflowed** the allowed values for integers.
The answer is a very large negative number because an overflow "wraps around"
from the largest possible integer value to the smallest.

There are other numeric types with different limits and precision that you
would use when the `int` type doesn't meet your needs. Let's explore those next.

Once again, let's move the code you wrote in this section into a separate method. Name it `TestLimits`. 

## Work with the double type

The `double` numeric type represents a double-precision floating point
number. Those terms may be new to you. A **floating point** number is
useful to represent non-integral numbers that may be very large or small
in magnitude. **Double-precision** means that these numbers are stored
using greater precision than **single-precision**. On modern computers,
it is more common to use double precision than single precision numbers.
Let's explore. Add the following code and see the result:

```csharp
double a = 5;
double b = 4;
double c = 2;
double d = (a  + b) / c;
Console.WriteLine(d);
```

Notice that the answer includes the decimal portion of the quotient. Try a slightly
more complicated expression with doubles:

```csharp
double e = 19;
double f = 23;
double g = 8;
double h = (e  + f) / g;
Console.WriteLine(h);
```

The range of a double value is much greater than integer values. Try the following
code below what you've written so far:

```csharp
double max = double.MaxValue;
double min = double.MinValue;
Console.WriteLine($"The range of double is {min} to {max}");
```

These values are printed out in scientific notation. The number to
the left of the `E` is the significand. The number to the right is the exponent,
as a power of 10. 

Just like decimal numbers in math, doubles in C# can have rounding errors. Try this code:

```csharp
double third = 1.0 / 3.0;
Console.WriteLine(third);
```

You know that `0.3` repeating is not exactly the same as `1/3`.

***Challenge***

Try other calculations with large numbers, small numbers, multiplication
and division using the `double` type.  Try more complicated calculations.

After you've spent some time with the challenge, take the code you've written
and place it in a new method. Name that new method `WorkWithDoubles`.

## Work with fixed point types

You've seen the basic numeric types in C#: integers and doubles.  There is one
other type to learn: the `decimal` type. The `decimal` type has a smaller
range but greater precision than `double`. The term **fixed point** means
that the decimal point (or binary point) doesn't move. Let's take a look:

```csharp
decimal min = decimal.MinValue;
decimal max = decimal.MaxValue;
Console.WriteLine($"The range of the decimal type is {min} to {max}");
```

Notice that the range is smaller than the `double` type. You can see the greater
precision with the decimal type by trying the following code:

```csharp
double a = 1.0;
double b = 3.0;
Console.WriteLine(a / b);

decimal c = 1.0M;
decimal d = 3.0M;
Console.WriteLine(c / d);
```

The `M` suffix on the numbers is how you indicate that a constant should use the
`decimal` type.

Notice that the math using the decimal type has more digits to the right
of the decimal point. 

***Challenge***

Now that you've seen the different numeric types, write code that calculates
the area of a circle whose radius is 2.50 centimeters. Remember that the area of a circle
is the radius squared multiplied by PI. One hint: .NET contains a constant
for PI, <xref:System.Math.PI?displayProperty=nameWithType> that you can use for that value. 

You should get an answer between 19 and 20.
You can check your answer by [looking at the finished sample code on GitHub](https://github.com/dotnet/samples/tree/master/csharp/numbers-quickstart/Program.cs#L104-L106)

Try some other formulas if you'd like. 

You've completed the "Numbers in C#" quickstart. You can continue with
the [Branches and loops](branches-and-loops-local.md) quickstart in
your own development environment.

You can learn more about numbers in C# in the following topics:

[Integral Types Table](../language-reference/keywords/integral-types-table.md)   
[Floating-Point Types Table](../language-reference/keywords/floating-point-types-table.md)   
[Built-In Types Table](../language-reference/keywords/built-in-types-table.md)   
[Implicit Numeric Conversions Table](../language-reference/keywords/implicit-numeric-conversions-table.md)   
[Explicit Numeric Conversions Table](../language-reference/keywords/explicit-numeric-conversions-table.md)

