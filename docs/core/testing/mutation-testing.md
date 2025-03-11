---
title: Mutation Testing
author: sigmade
description: Mutation testing is a way to evaluate the quality of our unit tests
ms.date: 01/30/2025
---

# Mutation Testing

Mutation testing is a way to evaluate the quality of our unit tests.
For mutation testing, there is a tool **Stryker.NET**, will automatically perform mutations in the code, run the tests, and generate a detailed report with the results.

Let's see how it works with an example.

We have a `PriceCalculator.cs` class with a `Calculate` method that calculates the price taking into account the discount.

```csharp
public class PriceCalculator
{
    public static decimal CalculatePrice(decimal price, decimal discountPercent)
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

This method is covered by unit tests

```csharp
[Fact]
public void ApplyDiscountCorrectly()
{
    decimal price = 100;
    decimal discountPercent = 10;

    var result = PriceCalculator.CalculatePrice(price, discountPercent);

    Assert.Equal(90.00m, result);
}

[Fact]
public void InvalidDiscountPercent_ShouldThrowException()
{
    Assert.Throws<ArgumentException>(() => PriceCalculator.CalculatePrice(100, -1));
    Assert.Throws<ArgumentException>(() => PriceCalculator.CalculatePrice(100, 101));
}

[Fact]
public void InvalidPrice_ShouldThrowException()
{
    Assert.Throws<ArgumentException>(() => PriceCalculator.CalculatePrice(-10, 10));
}
```

First, install **Stryker.NET**.
To do this, you need to execute the command:

```dotnetcli
    dotnet tool install -g dotnet-stryker
```

Let's run Stryker using the command from the directory where the unit tests are located:

```dotnetcli
    dotnet stryker
```

After the testing is completed, a report will be displayed in the console - how many mutants were killed and how many survived.

:::image type="content" source="media/stryker-console-report.png" lightbox="media/stryker-console-report.png" alt-text="Stryker console report":::

**Stryker.NET** saves a detailed HTML report in the StrykerOutput directory.

:::image type="content" source="media/stryker-first-report.png" lightbox="media/stryker-first-report.png" alt-text="Stryker first report":::

Now, consider what mutants are and what 'survived' and 'killed' mean. A mutant is a small change in your code that Stryker makes on purpose. The idea is simple: if your tests are good, they should catch the change and fail. If they still pass, your tests might not be strong enough. 

In our example, a mutant will be the replacement of the expression `price <= 0`, for example, with `price < 0`, after which unit tests are run.

Stryker supports several types of mutations:
-equivalent (for example, replaces < with <=)
-arithmetic (+ to -)
-string ("text" to "")
-logical (&& to ||)

and so on, you can find the full list in the **Stryker.NET** documentation.

If, after changing our code, the unit tests pass successfully, then they are not sufficiently robust, and the mutant survived.
After mutation testing, 5 mutants survive 

Let's add test data for boundary values and run mutation testing again.

```csharp
[Fact]
public void InvalidPrice_ShouldThrowException()
{
    Assert.Throws<ArgumentException>(()
        => PriceCalculator.CalculatePrice(0, 10));
    // changed price from -10 to 0
}

[Fact] // Added test for 0 and 100 discount
public void NoExceptionForZeroAnd100Discount()
{
    var exceptionWhen0 = Record.Exception(() => PriceCalculator.CalculatePrice(100, 0));
    var exceptionWhen100 = Record.Exception(() => PriceCalculator.CalculatePrice(100, 100));

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
    var exception1 = Assert.Throws<ArgumentException>(()
        => PriceCalculator.CalculatePrice(100, -1));
    Assert.Equal("Discount percent must be between 0 and 100.", exception1.Message);

    var exception2 = Assert.Throws<ArgumentException>(()
        => PriceCalculator.CalculatePrice(100, 101));
    Assert.Equal("Discount percent must be between 0 and 100.", exception2.Message);
}

[Fact]
public void InvalidPrice_ShouldThrowExceptionWithCorrectMessage()
{
    var exception = Assert.Throws<ArgumentException>(()
        => PriceCalculator.CalculatePrice(0, 10));
    Assert.Equal("Price must be greater than zero.", exception.Message);
}
```

:::image type="content" source="media/stryker-final-report.png" lightbox="media/stryker-final-report.png" alt-text="Stryker final report":::

Mutation testing helps to find weak points in tests and makes them more reliable. It forces you to check not only the 'happy path', but also complex boundary cases, reducing the likelihood of bugs in production.