---
title: Best practices for writing unit tests
description: Learn best practices for writing unit tests that drive code quality and resilience for .NET Core and .NET Standard projects.
author: jpreese
ms.author: wiwagn
ms.date: 03/14/2025
ms.custom: devdivchpfy22
---

# Unit testing best practices for .NET Core and .NET Standard

There are numerous benefits of writing unit tests. They help with regression, provide documentation, and facilitate good design. But when unit tests are hard to read and brittle, they can wreak havoc on your code base. This article describes some best practices for designing unit tests to support your .NET Core and .NET Standard projects. You learn techniques to keep your tests resilient and easy to understand.

By [John Reese](https://reese.dev) with special thanks to [Roy Osherove](https://osherove.com/)

## Benefits of unit testing

The following sections describe several reasons to write unit tests for your .NET Core and .NET Standard projects.

### Less time performing functional tests

Functional tests are expensive. They typically involve opening the application and performing a series of steps that you (or someone else) must follow in order to validate the expected behavior. These steps might not always be known to the tester. They have to reach out to someone more knowledgeable in the area to carry out the test. Testing itself can take seconds for trivial changes, or minutes for larger changes. Lastly, this process must be repeated for every change that you make in the system. Unit tests, on the other hand, take milliseconds, can be run at the press of a button, and don't necessarily require any knowledge of the system at large. The test runner determines whether the test passes or fails, not the individual.

### Protection against regression

Regression defects are errors that are introduced when a change is made to the application. It's common for testers to not only test their new feature but also test features that existed beforehand to verify that existing features still function as expected. With unit testing, you can rerun your entire suite of tests after every build or even after you change a line of code. This approach helps to increase confidence that your new code doesn't break existing functionality.

### Executable documentation

It might not always be obvious what a particular method does or how it behaves given a certain input. You might ask yourself: _How does this method behave if I pass it a blank string or null?_ When you have a suite of well-named unit tests, each test should clearly explain the expected output for a given input. In addition, the test should be able to verify that it actually works.

### Less coupled code

When code is tightly coupled, it can be difficult to unit test. Without creating unit tests for the code that you're writing, coupling might be less apparent. Writing tests for your code naturally decouples your code because it's more difficult to test otherwise.

## Characteristics of good unit tests

There are several important characteristics that define a good unit test:

- **Fast**: It's not uncommon for mature projects to have thousands of unit tests. Unit tests should take little time to run. Milliseconds.
- **Isolated**: Unit tests are standalone, can run in isolation, and have no dependencies on any outside factors, such as a file system or database.
- **Repeatable**: Running a unit test should be consistent with its results. The test always returns the same result if you don't change anything in between runs.
- **Self-Checking**: The test should automatically detect if it passed or failed without any human interaction.
- **Timely**: A unit test shouldn't take a disproportionately long time to write compared to the code being tested. If you discover that testing the code takes a large amount of time compared to writing the code, consider a more testable design.

## Code coverage and code quality

A high code coverage percentage is often associated with a higher quality of code. However, the measurement itself *can't* determine the quality of code. Setting an overly ambitious code coverage percentage goal can be counterproductive. Consider a complex project with thousands of conditional branches, and suppose you set a goal of 95% code coverage. Currently, the project maintains 90% code coverage. The amount of time it takes to account for all of the edge cases in the remaining 5% can be a massive undertaking, and the value proposition quickly diminishes.

A high code coverage percentage isn't an indicator of success, and it doesn't imply high code quality. It just represents the amount of code covered by unit tests. For more information, see [unit testing code coverage](unit-testing-code-coverage.md).

## Unit testing terminology

Several terms are used frequently in the context of unit testing: *fake*, *mock*, and *stub*. Unfortunately, these terms can be misapplied, so it's important to understand the correct usage.

- **Fake**: A fake is a generic term that can be used to describe either a stub or a mock object. Whether the object is a stub or a mock depends on the context in which the object is used. In other words, a fake can be a stub or a mock.

- **Mock**: A mock object is a fake object in the system that decides whether or not a unit test passes or fails. A mock begins as a fake and remains a fake until it enters an `Assert` operation.

- **Stub**: A stub is a controllable replacement for an existing dependency (or collaborator) in the system. By using a stub, you can test your code without dealing with the dependency directly. By default, a stub begins as a fake.

Consider the following code:

```csharp
var mockOrder = new MockOrder();
var purchase = new Purchase(mockOrder);

purchase.ValidateOrders();

Assert.True(purchase.CanBeShipped);
```

This code shows a stub referred to as a mock. But in this scenario, the stub is truly a stub. The purpose of the code is to pass the order as a means to instantiate the `Purchase` (the system under test) task. The class name `MockOrder` is misleading because the order is a stub and not a mock.

The following code shows a more accurate design:

```csharp
var stubOrder = new FakeOrder();
var purchase = new Purchase(stubOrder);

purchase.ValidateOrders();

Assert.True(purchase.CanBeShipped);
```

When the class is renamed to `FakeOrder`, the class is more generic. The class can be used as a mock or a stub, according to the requirements of the test case. In the first example, the `FakeOrder` class is used as a stub, and it isn't used during the `Assert` operation. The code passes the `FakeOrder` class to the `Purchase` class just to satisfy the requirements of the constructor.

To use the class as a mock, you can update the code:

```csharp
var mockOrder = new FakeOrder();
var purchase = new Purchase(mockOrder);

purchase.ValidateOrders();

Assert.True(mockOrder.Validated);
```

In this design, the code checks a property on the fake (asserting against it), and therefore, the `mockOrder` class is a mock.

> [!IMPORTANT]
> It's important to implement the terminology correctly. If you call your stubs "mocks," other developers are going to make false assumptions about your intent.

The main thing to remember about mocks versus stubs is that mocks are just like stubs, except for the `Assert` process. You run `Assert` operations against a mock object, but not against a stub.

## Best practices

There are several important best practices to follow when writing unit tests. The following sections provide examples that show how to apply the best practices to your code.

### Avoid infrastructure dependencies

Try not to introduce dependencies on infrastructure when writing unit tests. The dependencies make the tests slow and brittle and should be reserved for integration tests. You can avoid these dependencies in your application by following the [Explicit Dependencies Principle](https://deviq.com/explicit-dependencies-principle) and by using [.NET dependency injection](../extensions/dependency-injection.md). You can also keep your unit tests in a separate project from your integration tests. This approach ensures your unit test project doesn't have references to or dependencies on infrastructure packages.

### Follow test naming standards

The name of your test should consist of three parts:

- Name of the method being tested
- Scenario under which the method is being tested
- Expected behavior when the scenario is invoked

Naming standards are important because they help to express the test purpose and application. Tests are more than just making sure your code works. They also provide documentation. Just by looking at the suite of unit tests, you should be able to infer the behavior of your code ant not have to look at the code itself. Moreover, when tests fail, you can see exactly which scenarios don't meet your expectations.

:::row:::
:::column span="":::
**Original code**

[!code-csharp[BeforeNaming](../../../samples/snippets/core/testing/unit-testing-best-practices/csharp/before/StringCalculatorTests.cs#BeforeNaming)]

:::column-end:::
:::column span="":::
**Apply best practice**

[!code-csharp[AfterNamingAndMinimallyPassing](../../../samples/snippets/core/testing/unit-testing-best-practices/csharp/after/StringCalculatorTests.cs#AfterNamingAndMinimallyPassing)]

:::column-end:::
:::row-end:::

### Arrange your tests

The "Arrange, Act, Assert" pattern is a common approach for writing unit tests. As the name implies, the pattern consists of three main tasks:

- **Arrange** your objects, create, and configure them as necessary
- **Act** on an object
- **Assert** that something is as expected

When you follow the pattern, you can clearly separate what is being tested from the Arrange and Assert tasks. The pattern also helps to reduce the opportunity for assertions to intermix with code in the Act task.

Readability is one of the most important aspects when writing a unit test. Separating each pattern action within the test clearly highlights the dependencies required to call your code, how your code is called, and what you're trying to assert. While it might be possible to combine some steps and reduce the size of your test, the overall goal is to make the test as readable as possible.

:::row:::
:::column span="":::
**Original code**

[!code-csharp[BeforeArranging](../../../samples/snippets/core/testing/unit-testing-best-practices/csharp/before/StringCalculatorTests.cs#BeforeArranging)] 

:::column-end:::
:::column span="":::
**Apply best practice**

[!code-csharp[AfterArranging](../../../samples/snippets/core/testing/unit-testing-best-practices/csharp/after/StringCalculatorTests.cs#AfterArranging)]

:::column-end:::
:::row-end:::

### Write minimally passing tests

The input for a unit test should be the simplest information needed to verify the behavior you're currently testing. The minimalist approach helps tests become more resilient to future changes in the codebase and focus on verifying the behavior over the implementation.

Tests that include more information than required to pass the current test have a higher chance of introducing errors into the test and can make the intent of the test less clear. When writing tests, you want to focus on the behavior. Setting extra properties on models or using nonzero values when not required, only detracts from what you're trying to confirm.

:::row:::
:::column span="":::
**Original code**

[!code-csharp[BeforeMinimallyPassing](../../../samples/snippets/core/testing/unit-testing-best-practices/csharp/before/StringCalculatorTests.cs#BeforeMinimallyPassing)] 

:::column-end:::
:::column span="":::
**Apply best practice**

[!code-csharp[AfterNamingAndMinimallyPassing](../../../samples/snippets/core/testing/unit-testing-best-practices/csharp/after/StringCalculatorTests.cs#AfterNamingAndMinimallyPassing)]

:::column-end:::
:::row-end:::

### Avoid magic strings

*Magic strings* are string values hard-coded directly in your unit tests without any code extra comment or context. These values make your code less readable and harder to maintain. Magic strings can cause confusion to the reader of your tests. If a string looks out of the ordinary, they might wonder why a certain value was chosen for a parameter or return value. This type of string value might lead them to take a closer look at the implementation details, rather than focus on the test.

> [!TIP]
> Make your goal to express as much intent as possible in your unit test code. Rather than using magic strings, assign any hard-coded values to constants.

:::row:::
:::column span="":::
**Original code**

[!code-csharp[BeforeMagicString](../../../samples/snippets/core/testing/unit-testing-best-practices/csharp/before/StringCalculatorTests.cs#BeforeMagicString)] 

:::column-end:::
:::column span="":::
**Apply best practice**

[!code-csharp[AfterMagicString](../../../samples/snippets/core/testing/unit-testing-best-practices/csharp/after/StringCalculatorTests.cs#AfterMagicString)]

:::column-end:::
:::row-end:::

### Avoid coding logic in unit tests

When you write your unit tests, avoid manual string concatenation, logical conditions, such as `if`, `while`, `for`, and `switch`, and other conditions. If you include logic in your test suite, the chance of introducing bugs increases dramatically. The last place you want to find a bug is within your test suite. You should have a high level of confidence that your tests work, otherwise, you can't trust them. Tests that you don't trust, don't provide any value. When a test fails, you want to have a sense that something is wrong with your code and that it can't be ignored.

> [!TIP]
> If adding logic in your test seems unavoidable, consider splitting the test into two or more different tests to limit the logic requirements.

:::row:::
:::column span="":::
**Original code**

[!code-csharp[LogicInTests](../../../samples/snippets/core/testing/unit-testing-best-practices/csharp/before/StringCalculatorTests.cs#LogicInTests)] 

:::column-end:::
:::column span="":::
**Apply best practice**

[!code-csharp[AfterTestLogic](../../../samples/snippets/core/testing/unit-testing-best-practices/csharp/after/StringCalculatorTests.cs#AfterTestLogic)]

:::column-end:::
:::row-end:::

### Use helper methods instead of Setup and Teardown

If you require a similar object or state for your tests, use a helper method rather than `Setup` and `Teardown` attributes, if they exist. Helper methods are preferred over these attributes for several reasons:

- Less confusion when reading the tests because all code is visible from within each test
- Less chance of setting up too much or too little for the given test
- Less chance of sharing state between tests, which creates unwanted dependencies between them

In unit testing frameworks, the `Setup` attribute is called before each and every unit test within your test suite. Some programmers see this behavior as useful, but it often results in bloated and hard to read tests. Each test generally has different requirements for setup and execution. Unfortunately, the `Setup` attribute forces you to use the exact same requirements for each test.

> [!NOTE]
> The `SetUp` and `TearDown` attributes are removed in [xUnit](https://xunit.net/) version 2.x and later.

:::row:::
:::column span="2":::
**Original code**
:::column-end:::
:::column span="2":::
**Apply best practice**
:::column-end:::
:::row-end:::

:::row:::
:::column span="2":::
[!code-csharp[BeforeSetup](../../../samples/snippets/core/testing/unit-testing-best-practices/csharp/before/StringCalculatorTests.cs#BeforeSetup)]
:::column-end:::
:::column span="2":::
[!code-csharp[AfterHelperMethod](../../../samples/snippets/core/testing/unit-testing-best-practices/csharp/after/StringCalculatorTests.cs#AfterHelperMethod)]
:::column-end:::
:::row-end:::

:::row:::
:::column span="2":::
```csharp
// More tests...
```
:::column-end:::
:::column span="2":::
```csharp
// More tests...
```
:::column-end:::
:::row-end:::

:::row:::
:::column span="2":::
[!code-csharp[BeforeHelperMethod](../../../samples/snippets/core/testing/unit-testing-best-practices/csharp/before/StringCalculatorTests.cs#BeforeHelperMethod)]
:::column-end:::
:::column span="2":::
[!code-csharp[AfterSetup](../../../samples/snippets/core/testing/unit-testing-best-practices/csharp/after/StringCalculatorTests.cs#AfterSetup)]
:::column-end:::
:::row-end:::

### Avoid multiple Act tasks

When you write your tests, try to include only one Act task per test. Some common approaches for implementing a single Act task include creating a separate test for each Act or using parameterized tests. There are several benefits to using a single Act task for each test:

- You can easily discern which Act task is failing if the test fails.
- You can ensure the test is focused on just a single case.
- You gain a clear picture as to why your tests are failing.

Multiple Act tasks need to be individually asserted, and you can't guarantee that all Assert tasks execute. In most unit testing frameworks, after an Assert task fails in a unit test, all subsequent tests are automatically considered as failing. The process can be confusing because some working functionality might be interpreted as failing.

:::row:::
:::column span="":::
**Original code**

[!code-csharp[BeforeMultipleAsserts](../../../samples/snippets/core/testing/unit-testing-best-practices/csharp/before/StringCalculatorTests.cs#BeforeMultipleAsserts)] 

:::column-end:::
:::column span="":::
**Apply best practice**

[!code-csharp[AfterMultipleAsserts](../../../samples/snippets/core/testing/unit-testing-best-practices/csharp/after/StringCalculatorTests.cs#AfterMultipleAsserts)]

:::column-end:::
:::row-end:::

### Validate private methods with public methods

In most cases, you don't need to test a private method in your code. Private methods are an implementation detail and never exist in isolation. At some point in the development process, you introduce a public-facing method to call the private method as part of its implementation. When you write your unit tests, what you care about is the end result of the public method that calls into the private one.

Consider the following code scenario:

```csharp
public string ParseLogLine(string input)
{
    var sanitizedInput = TrimInput(input);
    return sanitizedInput;
}

private string TrimInput(string input)
{
    return input.Trim();
}
```

In terms of testing, your first reaction might be to write a test for the `TrimInput` method to ensure it works as expected. However, it's possible the `ParseLogLine` method manipulates the `sanitizedInput` object in a way you don't expect. The unknown behavior might render your test against the `TrimInput` method useless.

A better test in this scenario is to verify the public-facing `ParseLogLine` method:

```csharp
public void ParseLogLine_StartsAndEndsWithSpace_ReturnsTrimmedResult()
{
    var parser = new Parser();

    var result = parser.ParseLogLine(" a ");

    Assert.Equals("a", result);
}
```

When you encounter a private method, locate the public method that calls the private method, and write your tests against the public method. Just because a private method returns an expected result, doesn't mean the system that eventually calls the private method uses the result correctly.

### Handle stub static references with seams

One principle of a unit test is that it must have full control of the system under test. However, this principle can be problematic when production code includes calls to static references (for example, `DateTime.Now`).

Examine the following code scenario:

```csharp
public int GetDiscountedPrice(int price)
{
    if (DateTime.Now.DayOfWeek == DayOfWeek.Tuesday)
    {
        return price / 2;
    }
    else
    {
        return price;
    }
}
```

Can you write a unit test for this code? You might try running an Assert task on the `price`:

```csharp
public void GetDiscountedPrice_NotTuesday_ReturnsFullPrice()
{
    var priceCalculator = new PriceCalculator();

    var actual = priceCalculator.GetDiscountedPrice(2);

    Assert.Equals(2, actual)
}

public void GetDiscountedPrice_OnTuesday_ReturnsHalfPrice()
{
    var priceCalculator = new PriceCalculator();

    var actual = priceCalculator.GetDiscountedPrice(2);

    Assert.Equals(1, actual);
}
```

Unfortunately, you quickly realize there are some problems with your test:

- If the test suite runs on Tuesday, the second test passes, but the first test fails.
- If the test suite runs on any other day, the first test passes, but the second test fails.

To solve these problems, you need to introduce a *seam* into your production code. One approach is to wrap the code that you need to control in an interface and have the production code depend on that interface:

```csharp
public interface IDateTimeProvider
{
    DayOfWeek DayOfWeek();
}

public int GetDiscountedPrice(int price, IDateTimeProvider dateTimeProvider)
{
    if (dateTimeProvider.DayOfWeek() == DayOfWeek.Tuesday)
    {
        return price / 2;
    }
    else
    {
        return price;
    }
}
```

You also need to write a new version of your test suite:

```csharp
public void GetDiscountedPrice_NotTuesday_ReturnsFullPrice()
{
    var priceCalculator = new PriceCalculator();
    var dateTimeProviderStub = new Mock<IDateTimeProvider>();
    dateTimeProviderStub.Setup(dtp => dtp.DayOfWeek()).Returns(DayOfWeek.Monday);

    var actual = priceCalculator.GetDiscountedPrice(2, dateTimeProviderStub);

    Assert.Equals(2, actual);
}

public void GetDiscountedPrice_OnTuesday_ReturnsHalfPrice()
{
    var priceCalculator = new PriceCalculator();
    var dateTimeProviderStub = new Mock<IDateTimeProvider>();
    dateTimeProviderStub.Setup(dtp => dtp.DayOfWeek()).Returns(DayOfWeek.Tuesday);

    var actual = priceCalculator.GetDiscountedPrice(2, dateTimeProviderStub);

    Assert.Equals(1, actual);
}
```

Now the test suite has full control over the `DateTime.Now` value, and can stub any value when calling into the method.

## Related links

- [Unit testing code coverage](unit-testing-code-coverage.md)
