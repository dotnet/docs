---
title: Best practices for writing unit tests
description: Learn best practices for writing unit tests that drive code quality and resilience for .NET Core and .NET Standard projects.
author: jpreese
ms.author: wiwagn
ms.date: 07/22/2022
ms.custom: devdivchpfy22
---

# Unit testing best practices with .NET Core and .NET Standard

There are numerous benefits of writing unit tests; they help with regression, provide documentation, and facilitate good design. However, hard to read and brittle unit tests can wreak havoc on your code base. This article describes some best practices regarding unit test design for your .NET Core and .NET Standard projects.

In this guide, you learn some best practices when writing unit tests to keep your tests resilient and easy to understand.

By [John Reese](https://reese.dev) with special thanks to [Roy Osherove](https://osherove.com/)

## Why unit test?

### Less time performing functional tests

Functional tests are expensive. They typically involve opening up the application and performing a series of steps that you (or someone else) must follow in order to validate the expected behavior. These steps might not always be known to the tester. They'll have to reach out to someone more knowledgeable in the area in order to carry out the test. Testing itself could take seconds for trivial changes, or minutes for larger changes. Lastly, this process must be repeated for every change that you make in the system.

Unit tests, on the other hand, take milliseconds, can be run at the press of a button, and don't necessarily require any knowledge of the system at large. Whether or not the test passes or fails is up to the test runner, not the individual.

### Protection against regression

Regression defects are defects that are introduced when a change is made to the application. It's common for testers to not only test their new feature but also test features that existed beforehand in order to verify that previously implemented features still function as expected.

With unit testing, it's possible to rerun your entire suite of tests after every build or even after you change a line of code. Giving you confidence that your new code doesn't break existing functionality.

### Executable documentation

It might not always be obvious what a particular method does or how it behaves given a certain input. You might ask yourself: How does this method behave if I pass it a blank string? Null?

When you have a suite of well-named unit tests, each test should be able to clearly explain the expected output for a given input. In addition, it should be able to verify that it actually works.

### Less coupled code

When code is tightly coupled, it can be difficult to unit test. Without creating unit tests for the code that you're writing, coupling might be less apparent.

Writing tests for your code will naturally decouple your code, because it would be more difficult to test otherwise.

## Characteristics of a good unit test

- **Fast**: It isn't uncommon for mature projects to have thousands of unit tests. Unit tests should take little time to run. Milliseconds.
- **Isolated**: Unit tests are standalone, can be run in isolation, and have no dependencies on any outside factors such as a file system or database.
- **Repeatable**: Running a unit test should be consistent with its results, that is, it always returns the same result if you don't change anything in between runs.
- **Self-Checking**: The test should be able to automatically detect if it passed or failed without any human interaction.
- **Timely**: A unit test shouldn't take a disproportionately long time to write compared to the code being tested. If you find testing the code taking a large amount of time compared to writing the code, consider a design that is more testable.

## Code coverage

A high code coverage percentage is often associated with a higher quality of code. However, the measurement itself *can't* determine the quality of code. Setting an overly ambitious code coverage percentage goal can be counterproductive. Imagine a complex project with thousands of conditional branches, and imagine that you set a goal of 95% code coverage. Currently the project maintains 90% code coverage. The amount of time it takes to account for all of the edge cases in the remaining 5% could be a massive undertaking, and the value proposition quickly diminishes.

A high code coverage percentage isn't an indicator of success, nor does it imply high code quality. It just represents the amount of code that is covered by unit tests. For more information, see [unit testing code coverage](unit-testing-code-coverage.md).

## Let's speak the same language

The term *mock* is unfortunately often misused when talking about testing. The following points define the most common types of *fakes* when writing unit tests:

*Fake* - A fake is a generic term that can be used to describe either a stub or a mock object. Whether it's a stub or a mock depends on the context in which it's used. So in other words, a fake can be a stub or a mock.

*Mock* - A mock object is a fake object in the system that decides whether or not a unit test has passed or failed. A mock starts out as a Fake until it's asserted against.

*Stub* - A stub is a controllable replacement for an existing dependency (or collaborator) in the system. By using a stub, you can test your code without dealing with the dependency directly. By default, a stub starts out as a fake.

Consider the following code snippet:

```csharp
var mockOrder = new MockOrder();
var purchase = new Purchase(mockOrder);

purchase.ValidateOrders();

Assert.True(purchase.CanBeShipped);
```

The preceding example would be of a stub being referred to as a mock. In this case, it's a stub. You're just passing in the Order as a means to be able to instantiate `Purchase` (the system under test). The name `MockOrder` is also misleading because again, the order isn't a mock.

A better approach would be:

```csharp
var stubOrder = new FakeOrder();
var purchase = new Purchase(stubOrder);

purchase.ValidateOrders();

Assert.True(purchase.CanBeShipped);
```

By renaming the class to `FakeOrder`, you've made the class a lot more generic. The class can be used as a mock or a stub, whichever is better for the test case. In the preceding example, `FakeOrder` is used as a stub. You're not using `FakeOrder` in any shape or form during the assert. `FakeOrder` was passed into the `Purchase` class to satisfy the requirements of the constructor.

To use it as a Mock, you could do something like the following code:

```csharp
var mockOrder = new FakeOrder();
var purchase = new Purchase(mockOrder);

purchase.ValidateOrders();

Assert.True(mockOrder.Validated);
```

In this case, you're checking a property on the Fake (asserting against it), so in the preceding code snippet, the `mockOrder` is a Mock.

> [!IMPORTANT]
> It's important to get this terminology correct. If you call your stubs "mocks," other developers are going to make false assumptions about your intent.

The main thing to remember about mocks versus stubs is that mocks are just like stubs, but you assert against the mock object, whereas you don't assert against a stub.

## Best practices

Try not to introduce dependencies on infrastructure when writing unit tests. The dependencies make the tests slow and brittle and should be reserved for integration tests. You can avoid these dependencies in your application by following the [Explicit Dependencies Principle](https://deviq.com/explicit-dependencies-principle) and using [Dependency Injection](../extensions/dependency-injection.md). You can also keep your unit tests in a separate project from your integration tests. This approach ensures your unit test project doesn't have references to or dependencies on infrastructure packages.

### Naming your tests

The name of your test should consist of three parts:

- The name of the method being tested.
- The scenario under which it's being tested.
- The expected behavior when the scenario is invoked.

#### Why?

Naming standards are important because they explicitly express the intent of the test. Tests are more than just making sure your code works, they also provide documentation. Just by looking at the suite of unit tests, you should be able to infer the behavior of your code without even looking at the code itself. Additionally, when tests fail, you can see exactly which scenarios don't meet your expectations.

#### Bad:

[!code-csharp[BeforeNaming](../../../samples/snippets/core/testing/unit-testing-best-practices/csharp/before/StringCalculatorTests.cs#BeforeNaming)]

#### Better:

[!code-csharp[AfterNamingAndMinimallyPassing](../../../samples/snippets/core/testing/unit-testing-best-practices/csharp/after/StringCalculatorTests.cs#AfterNamingAndMinimallyPassing)]

### Arranging your tests

**Arrange, Act, Assert** is a common pattern when unit testing. As the name implies, it consists of three main actions:

- *Arrange* your objects, create and set them up as necessary.
- *Act* on an object.
- *Assert* that something is as expected.

#### Why?

- Clearly separates what is being tested from the *arrange* and *assert* steps.
- Less chance to intermix assertions with "Act" code.

Readability is one of the most important aspects when writing a test. Separating each of these actions within the test clearly highlight the dependencies required to call your code, how your code is being called, and what you're trying to assert. While it might be possible to combine some steps and reduce the size of your test, the primary goal is to make the test as readable as possible.

#### Bad:

[!code-csharp[BeforeArranging](../../../samples/snippets/core/testing/unit-testing-best-practices/csharp/before/StringCalculatorTests.cs#BeforeArranging)]

#### Better:

[!code-csharp[AfterArranging](../../../samples/snippets/core/testing/unit-testing-best-practices/csharp/after/StringCalculatorTests.cs#AfterArranging)]

### Write minimally passing tests

The input to be used in a unit test should be the simplest possible in order to verify the behavior that you're currently testing.

#### Why?

- Tests become more resilient to future changes in the codebase.
- Closer to testing behavior over implementation.

Tests that include more information than required to pass the test have a higher chance of introducing errors into the test and can make the intent of the test less clear. When writing tests, you want to focus on the behavior. Setting extra properties on models or using non-zero values when not required, only detracts from what you are trying to prove.

#### Bad:

[!code-csharp[BeforeMinimallyPassing](../../../samples/snippets/core/testing/unit-testing-best-practices/csharp/before/StringCalculatorTests.cs#BeforeMinimallyPassing)]

#### Better:

[!code-csharp[AfterNamingAndMinimallyPassing](../../../samples/snippets/core/testing/unit-testing-best-practices/csharp/after/StringCalculatorTests.cs#AfterNamingAndMinimallyPassing)]

### Avoid magic strings

Naming variables in unit tests is important, if not more important, than naming variables in production code. Unit tests shouldn't contain magic strings.

#### Why?

- Prevents the need for the reader of the test to inspect the production code in order to figure out what makes the value special.
- Explicitly shows what you're trying to *prove* rather than trying to *accomplish*.

Magic strings can cause confusion to the reader of your tests. If a string looks out of the ordinary, they might wonder why a certain value was chosen for a parameter or return value. This type of string value might lead them to take a closer look at the implementation details, rather than focus on the test.

> [!TIP]
> When writing tests, you should aim to express as much intent as possible. In the case of magic strings, a good approach is to assign these values to constants.

#### Bad:

[!code-csharp[BeforeMagicString](../../../samples/snippets/core/testing/unit-testing-best-practices/csharp/before/StringCalculatorTests.cs#BeforeMagicString)]

#### Better:

[!code-csharp[AfterMagicString](../../../samples/snippets/core/testing/unit-testing-best-practices/csharp/after/StringCalculatorTests.cs#AfterMagicString)]

### Avoid logic in tests

When writing your unit tests, avoid manual string concatenation, logical conditions, such as `if`, `while`, `for`, and `switch`, and other conditions.

#### Why?

- Less chance to introduce a bug inside of your tests.
- Focus on the end result, rather than implementation details.

When you introduce logic into your test suite, the chance of introducing a bug into it increases dramatically. The last place that you want to find a bug is within your test suite. You should have a high level of confidence that your tests work, otherwise, you won't trust them. Tests that you don't trust, don't provide any value. When a test fails, you want to have a sense that something is wrong with your code and that it can't be ignored.

> [!TIP]
> If logic in your test seems unavoidable, consider splitting the test up into two or more different tests.

#### Bad:

[!code-csharp[LogicInTests](../../../samples/snippets/core/testing/unit-testing-best-practices/csharp/before/StringCalculatorTests.cs#LogicInTests)]

#### Better:

[!code-csharp[AfterTestLogic](../../../samples/snippets/core/testing/unit-testing-best-practices/csharp/after/StringCalculatorTests.cs#AfterTestLogic)]

### Prefer helper methods to setup and teardown

If you require a similar object or state for your tests, prefer a helper method than using `Setup` and `Teardown` attributes if they exist.

#### Why?

- Less confusion when reading the tests since all of the code is visible from within each test.
- Less chance of setting up too much or too little for the given test.
- Less chance of sharing state between tests, which creates unwanted dependencies between them.

In unit testing frameworks, `Setup` is called before each and every unit test within your test suite. While some might see this as a useful tool, it generally ends up leading to bloated and hard to read tests. Each test will generally have different requirements in order to get the test up and running. Unfortunately, `Setup` forces you to use the exact same requirements for each test.

> [!NOTE]
> xUnit has removed both SetUp and TearDown as of version 2.x

#### Bad:

[!code-csharp[BeforeSetup](../../../samples/snippets/core/testing/unit-testing-best-practices/csharp/before/StringCalculatorTests.cs#BeforeSetup)]

```csharp
// more tests...
```

[!code-csharp[BeforeHelperMethod](../../../samples/snippets/core/testing/unit-testing-best-practices/csharp/before/StringCalculatorTests.cs#BeforeHelperMethod)]

#### Better:

[!code-csharp[AfterHelperMethod](../../../samples/snippets/core/testing/unit-testing-best-practices/csharp/after/StringCalculatorTests.cs#AfterHelperMethod)]

```csharp
// more tests...
```

[!code-csharp[AfterSetup](../../../samples/snippets/core/testing/unit-testing-best-practices/csharp/after/StringCalculatorTests.cs#AfterSetup)]

### Avoid multiple acts

When writing your tests, try to only include one act per test. Common approaches to using only one act include:

- Create a separate test for each act.
- Use parameterized tests.

#### Why?

- When the test fails, it is clear which act is failing.
- Ensures that the test is focused on just a single case.
- Gives you the entire picture as to why your tests are failing.

Multiple acts need to be individually Asserted and it isn't guaranteed that all of the Asserts will be executed. In most unit testing frameworks, once an Assert fails in a unit test, the proceeding tests are automatically considered to be failing. This kind of process can be confusing as functionality that is actually working, will be shown as failing.

#### Bad:

[!code-csharp[BeforeMultipleAsserts](../../../samples/snippets/core/testing/unit-testing-best-practices/csharp/before/StringCalculatorTests.cs#BeforeMultipleAsserts)]

#### Better:

[!code-csharp[AfterMultipleAsserts](../../../samples/snippets/core/testing/unit-testing-best-practices/csharp/after/StringCalculatorTests.cs#AfterMultipleAsserts)]

### Validate private methods by unit testing public methods

In most cases, there shouldn't be a need to test a private method. Private methods are an implementation detail and never exist in isolation. At some point, there's going to be a public facing method that calls the private method as part of its implementation. What you should care about is the end result of the public method that calls into the private one.

Consider the following case:

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

Your first reaction might be to start writing a test for `TrimInput` because you want to ensure that the method is working as expected. However, it's entirely possible that `ParseLogLine` manipulates `sanitizedInput` in such a way that you don't expect, rendering a test against `TrimInput` useless.

The real test should be done against the public facing method `ParseLogLine` because that is what you should ultimately care about.

```csharp
public void ParseLogLine_StartsAndEndsWithSpace_ReturnsTrimmedResult()
{
    var parser = new Parser();

    var result = parser.ParseLogLine(" a ");

    Assert.Equals("a", result);
}
```

With this viewpoint, if you see a private method, find the public method and write your tests against that method. Just because a private method returns the expected result, doesn't mean the system that eventually calls the private method uses the result correctly.

### Stub static references

One of the principles of a unit test is that it must have full control of the system under test. This principle can be problematic when production code includes calls to static references (for example, `DateTime.Now`). Consider the following code:

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

How can this code possibly be unit tested? You might try an approach such as:

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

Unfortunately, you'll quickly realize that there are a couple of problems with your tests.

- If the test suite is run on a Tuesday, the second test will pass, but the first test will fail.
- If the test suite is run on any other day, the first test will pass, but the second test will fail.

To solve these problems, you'll need to introduce a *seam* into your production code. One approach is to wrap the code that you need to control in an interface and have the production code depend on that interface.

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

Your test suite now becomes as follows:

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

Now the test suite has full control over `DateTime.Now` and can stub any value when calling into the method.
