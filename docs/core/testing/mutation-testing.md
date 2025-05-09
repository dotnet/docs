---
title: Mutation testing
author: sigmade
description: Learn about the Stryker.net tool for mutation testing, to evaluate the quality of your unit tests.
ms.date: 03/11/2025
---

# Mutation testing

Mutation testing is a way to evaluate the quality of our unit tests. For mutation testing, the **Stryker.NET** tool automatically performs mutations in your code, runs tests, and generates a detailed report with the results.

## Example test scenario

Consider a sample _PriceCalculator.cs_ class with a `Calculate` method that calculates the price, taking into account the discount.

```csharp
public class PriceCalculator
{
    public decimal CalculatePrice(decimal price, decimal discountPercent)
    {
        if (price <= 0)
        {
            throw new ArgumentException("Price must be greater than zero.");
        }

        if (discountPercent < 0 || discountPercent > 100)
        {
            throw new ArgumentException("Discount percent must be between 0 and 100.");
        }

        var discount = price * (discountPercent / 100);
        var discountedPrice = price - discount;

        return Math.Round(discountedPrice, 2);
    }
}
```

The preceding method is covered by the following unit tests:

```csharp
[Fact]
public void ApplyDiscountCorrectly()
{
    decimal price = 100;
    decimal discountPercent = 10;

    var calculator = new PriceCalculator();

    var result = calculator.CalculatePrice(price, discountPercent);

    Assert.Equal(90.00m, result);
}

[Fact]
public void InvalidDiscountPercent_ShouldThrowException()
{
    var calculator = new PriceCalculator();

    Assert.Throws<ArgumentException>(() => calculator.CalculatePrice(100, -1));
    Assert.Throws<ArgumentException>(() => calculator.CalculatePrice(100, 101));
}

[Fact]
public void InvalidPrice_ShouldThrowException()
{
    var calculator = new PriceCalculator();

    Assert.Throws<ArgumentException>(() => calculator.CalculatePrice(-10, 10));
}
```

The preceding code highlights two projects, one for the service that acts as a `PriceCalculator` and the other is the test project.

## Install the global tool

First, install **Stryker.NET**.
To do this, you need to execute the command:

```dotnetcli
dotnet tool install -g dotnet-stryker
```

To run `stryker`, invoke it from the command line in the directory where the unit test project is located:

```dotnetcli
dotnet stryker
```

After the tests have run, a report is displayed in the console.

:::image type="content" source="media/stryker-console-report.png" lightbox="media/stryker-console-report.png" alt-text="Stryker console report":::

**Stryker.NET** saves a detailed HTML report in the StrykerOutput directory.

:::image type="content" source="media/stryker-first-report.png" lightbox="media/stryker-first-report.png" alt-text="Stryker first report":::

Now, consider what mutants are and what 'survived' and 'killed' mean. A mutant is a small change in your code that Stryker makes on purpose. The idea is simple: if your tests are good, they should catch the change and fail. If they still pass, your tests might not be strong enough.

In our example, a mutant will be the replacement of the expression `price <= 0`, for example, with `price < 0`, after which unit tests are run.

Stryker supports several types of mutations:

| Type | Description |
|--|--|
| Equivalent | The equivalent operator is used to replace an operator with its equivalent. For example, `x < y` becomes `x <= y`. |
| Arithmetic | The arithmetic operator is used to replace an arithmetic operator with its equivalent. For example, `x + y` becomes `x - y`. |
| String | The string operator is used to replace a string with its equivalent. For example, `"text"` becomes `""`. |
| Logical | The logical operator is used to replace a logical operator with its equivalent. For example, `x && y` becomes `x \|\| y`. |

For additional mutation types, see the [Stryker.NET: Mutations](https://stryker-mutator.io/docs/stryker-net/mutations) documentation.

## Interpreting Mutation Testing Results

After running Stryker.NET, you’ll receive a report that categorizes mutants as **killed**, **survived**, or **timeout**. Here's how to interpret and act on these results:

-  **Killed Mutants**: These are changes that your tests successfully caught. A high number of killed mutants indicates that your test suite effectively detects logic errors.

-  **Survived Mutants**: These changes were not caught by your tests. Review them to identify gaps in test coverage or assertions that are too weak. Focus on adding targeted unit tests that would fail if the mutant were real.

-  **Timeout Mutants**: These mutations caused your code to hang or exceed the allowed time. This can happen with infinite loops or unoptimized paths. Investigate the code logic or increase the timeout threshold if needed.

>  **Note**: Don't chase a 100% mutation score. Focus instead on high risk or business critical areas where undetected bugs would be most costly.

## Incremental improvement

If, after changing your code, the unit tests pass successfully, then they aren't sufficiently robust, and the mutant survived.
After mutation testing, five mutants survive.

Let's add test data for boundary values and run mutation testing again.

```csharp
[Fact]
public void InvalidPrice_ShouldThrowException()
{
    var calculator = new PriceCalculator();

    // changed price from -10 to 0
    Assert.Throws<ArgumentException>(() => calculator.CalculatePrice(0, 10));
}

[Fact] // Added test for 0 and 100 discount
public void NoExceptionForZeroAnd100Discount()
{
    var calculator = new PriceCalculator();

    var exceptionWhen0 = Record.Exception(() => calculator.CalculatePrice(100, 0));
    var exceptionWhen100 = Record.Exception(() => calculator.CalculatePrice(100, 100));

    Assert.Null(exceptionWhen0);
    Assert.Null(exceptionWhen100);
}
```

:::image type="content" source="media/stryker-second-report.png" lightbox="media/stryker-second-report.png" alt-text="Stryker second report":::

As you can see, after correcting the equivalent mutants, we only have string mutations left, which we can easily 'kill' by checking the text of the exception message.

```csharp
[Fact]
public void InvalidDiscountPercent_ShouldThrowExceptionWithCorrectMessage()
{
    var calculator = new PriceCalculator();

    var ex1 = Assert.Throws<ArgumentException>(() => calculator.CalculatePrice(100, -1));
    Assert.Equal("Discount percent must be between 0 and 100.", ex1.Message);

    var ex2 = Assert.Throws<ArgumentException>(() => calculator.CalculatePrice(100, 101));
    Assert.Equal("Discount percent must be between 0 and 100.", ex2.Message);
}

[Fact]
public void InvalidPrice_ShouldThrowExceptionWithCorrectMessage()
{
    var calculator = new PriceCalculator();

    var ex = Assert.Throws<ArgumentException>(() => calculator.CalculatePrice(0, 10));
    Assert.Equal("Price must be greater than zero.", ex.Message);
}
```

:::image type="content" source="media/stryker-final-report.png" lightbox="media/stryker-final-report.png" alt-text="Stryker final report":::

Mutation testing helps to find opportunities to improve tests that make them more reliable. It forces you to check not only the 'happy path', but also complex boundary cases, reducing the likelihood of bugs in production.
