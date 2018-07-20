# Unit Testing Best Practices

By [John Reese](http://reesespieces.io) with special thanks to [Roy Osherove](http://osherove.com/)

## Why unit test?

### Less time performing functional tests
Functional tests are expensive. They typically involve opening up the application and performing a series of steps that you (or someone else), must follow in order to validate the expected behavior. These steps may not always be known to the tester, which means they will have to reach out to someone more knowledgeable in the area in order to carry out the test. Testing itself could take seconds for trivial changes, or minutes for larger changes. Lastly, this process must be repeated for every change that you make in the system.

Unit tests on the other hand take milliseconds, can be run at the press of a button and do not necessarily require any knowledge of the system at large. Whether or not the test passes or fails is up to the test runner, not the individual.

### Protection against regression
Regression defects are defects that are introduced when a change is made to the application. It is common for testers to not only test their new feature but also features that existed beforehand in order to verify that previously implemented features still function as expected.

With unit testing, it's possible to rerun your entire suite of tests after every build or even after you change a line of code. Giving you confidence that your new code does not break existing functionality.

### Executable documentation
It may not always be obvious what a particular method does or how it behaves given a certain input. You may ask yourself: How does this method behave if I pass it a blank string? Null?

When you have a suite of well-named unit tests, each test should be able to clearly explain the expected output for a given input. In addition, it should be able to verify that it actually works.

### Less coupled code
When code is tightly coupled, it can be difficult to unit test. Without creating unit tests for the code that you're writing, coupling may be less apparent.

Writing tests for your code will naturally decouple your code, because it would be near impossible to test otherwise.

## What makes a good unit test?
- **Fast**. It is not uncommon for mature projects to have thousands of unit tests. Unit tests should take very little time to run. Milliseconds.
- **Isolated**. Unit tests are standalone, can be run in isolation, and have no dependencies on any outside factors such as a file system or database.
- **Repeatable**. Running a unit test should be consistent with its results, that is, it always returns the same result if you do not change anything in between runs.
- **Self-Checking**. The test should be able to automatically detect if it passed or failed without any human interaction.
- **Timely**. A unit test should not take a disproportionally long time to write compared to the code being tested. If you find testing the code taking a large amount of time compared to writing the code, consider a design that is more testable.

## Lets speak the same language
The term *mock* is unfortunately very misused when talking about testing. The following defines the most common types of *fakes* when writing unit tests:

*Fake* - A fake is a generic term which can be used to describe either a stub or a mock object. Whether it is a stub or a mock depends on the context in which it's used. So in other words, a fake can be a stub or a mock.

*Mock* - A mock object is a fake object in the system that decides whether or not a unit test has passed or failed. A mock starts out as a Fake until it is asserted against.

*Stub* - A stub is a controllable replacement for an existing dependency (or collaborator) in the system. By using a stub, you can test your code without dealing with the dependency directly. By default, a fake starts out as a stub.

Consider the following code snippet:

```csharp
var mockOrder = new MockOrder();
var purchase = new Purchase(mockOrder);

purchase.ValidateOrders();

Assert.True(purchase.CanBeShipped);
```

This would be an example of Mock being used improperly. In this case, it is a stub. We're just passing in the Order as a means to be able to instantiate `Purchase` (the system under test). The name `MockOrder` is also very misleading because again, the order is not a mock.

A better approach would be

```csharp
var stubOrder = new FakeOrder();
var purchase = new Purchase(stubOrder);

purchase.ValidateOrders();

Assert.True(purchase.CanBeShipped);
```

By renaming the class to `FakeOrder`, we've made the class a lot more generic, the class can be used as a mock or a stub. Whichever is better for the test case. In the above example, `FakeOrder` is used as a stub. We're not using the `FakeOrder` in any shape or form during the assert. We just passed it into the `Purchase` class to satisfy the requirements of the constructor.

To use it as a Mock, we could do something like this

```csharp
var mockOrder = new FakeOrder();
var purchase = new Purchase(mockOrder);

purchase.ValidateOrders();

Assert.True(mockOrder.Validated);
```

In this case, we are checking a property on the Fake (asserting against it), so in the above code snippet, the `mockOrder` is a Mock.

**It's important to get this terminology correct. If you call your stubs "mocks", other developers are going to make false assumptions about your intent.**

The main thing to remember about mocks versus stubs is that mocks are just like stubs, but you assert against the mock object, whereas you do not assert against a stub.

## Best practices

### Arranging your tests
Arrange, Act, Assert is a common pattern when unit testing. As the name implies, it consists of three main actions:
- *Arrange* your objects, creating and setting them up as necessary.
- *Act* on an object.
- *Assert* that something is as expected.

#### Why?
- Clearly separates what is being tested from the *arrange* and *assert* steps.
- Less chance to intermix assertions with "Act" code.

#### Bad:
```csharp
public void IsValidWord_InputIsNull_ReturnsFalse()
{
    // Arrange
    var glossary = new Glossary();

    // Assert
    Assert.False(glossary.IsValidWord(null));
}
```

#### Better:
```csharp
public void IsValidWord_InputIsNull_ReturnsFalse()
{
    var glossary = new Glossary();
    
    var result = glossary.IsValidWord(null);

    Assert.False(result);
}
```

### Naming your tests
The name of your test should consist of three parts:
- The name of the method being tested.
- The scenario under which it's being tested.
- The expected behavior when the scenario is invoked.

#### Why?
- Naming standards are important because they explicitly express intent of the test.

#### Bad:
```csharp
public void Test_Invalid()
{
    var glossary = new Glossary();

    var result = glossary.IsValidWord(null);

    Assert.False(result);
}
```

#### Better:
```csharp
public void IsValidWord_InputIsNull_ReturnsFalse()
{
    var glossary = new Glossary();

    var result = glossary.IsValidWord(null);

    Assert.False(result);
}
```

### Avoid magic strings
Naming variables in unit tests is as important, if not more important, than naming variables in production code. Unit tests should not contain magic strings.

#### Why?
- Prevents the need for the reader of the test to inspect the production code in order to figure out what makes the value special.
- Explicitly shows what you're trying to *prove* rather than trying to *accomplish*.

#### Bad:
```csharp
public void TryParseWord_InputIsNumber_ReturnsInvalidInputErrorCode()
{
    var glossary = new Glossary();

    glossary.TryParseWord("1", out var result)

    Assert.Equal(-1, result);
}
```

#### Better:
```csharp
public void TryParseWord_InputIsNumber_ReturnsInvalidInputErrorCode()
{
    var glossary = new Glossary();
    const int INVALID_INPUT = -1;

    glossary.TryParseWord("1", out var result)

    Assert.Equal(INVALID_INPUT, result);
}
```

### Avoid logic in tests
When writing your unit tests avoid manual string concatenation and logical conditions such as `if`, `while`, `for`, `switch`, etc.

#### Why?
- Less chance to introduce a bug inside of your tests.
- Focus on the end result, rather than implementation details.

#### Bad:
```csharp
public void ExclaimAllWords_TwoWords_ReturnsArrayOfExclaimedWords()
{
    var glossary = new Glossary();
    var wordList = new string[] 
    {
        "cat",
        "dog"
    };

    var result = glossary.ExclaimAllWords(wordList);

    for(int x = 0; x < result.length; x++)
    {
        Assert.Equal(wordList[x] + '!', result[x]);
    }
}
```

#### Better:
```csharp
public void ExclaimAllWords_TwoWords_ReturnsArrayOfExclaimedWords()
{
    var glossary = new Glossary();
    var input = new string[] 
    {
        "a",
        "b"
    };
    var expected = new string[] 
    {
        "a!",
        "b!"
    };

    var result = glossary.ExclaimAllWords(input);

    Assert.Equal(expected, result);
}
```

### Prefer helper methods to setup and teardown
If you require a similar object or state for your tests, prefer a helper method than leveraging Setup and Teardown attributes if they exist.

#### Why?
- Less confusion when reading the tests since all of the code is visible from within each test.
- Less chance of setting up too much or too little for the given test.
- Less chance of sharing state between tests which creates unwanted dependencies between them.

#### Bad:
```csharp
Glossary glossary;

[SetUp]
public void Initialize()
{
    glossary = new Glossary();
}

// more tests..

public void ParseWord_NullValue_ThrowsArgumentException()
{
    Assert.Throws<ArgumentException>(() => glossary.ParseWord(null));
}

public void ParseWord_EmptyString_ReturnsEmptyString()
{
    Assert.Empty(glossary.ParseWord(""));
}
```

#### Better:
```csharp
public void ParseWord_NullValue_ThrowsArgumentException()
{
    var glossary = CreateDefaultGlossary();

    var result = () => glossary.ParseWord(null);

    Assert.Throws<ArgumentException>(result);
}

public void ParseWord_EmptyString_ReturnsEmptyString()
{
    var glossary = CreateDefaultGlossary();

    var result = glossary.ParseWord("");

    Assert.Empty(result);
}

// more tests..

private Glossary CreateDefaultGlossary()
{
    return new Glossary();
}
```

### Avoid multiple asserts
When writing your tests, try to only include one Assert per test. Common approaches to using only one assert include:
- Create a separate test for each assert.
- Use parameterized tests.

#### Why?
- If one Assert fails, the subsequent Asserts will not be evaluated.
- Ensures you are not asserting multiple cases in your tests.
- Gives you the entire picture as to why your tests are failing. 

#### Bad:
```csharp
public void IsValidWord_InputIsNullOrEmpty_ReturnsFalse()
{
    var glossary = new Glossary();

    Assert.False(glossary.IsValidWord(null)); // potential NullException
    Assert.False(glossary.IsValidWord("")); // this never gets executed if the above test fails
}
```

#### Better:
```csharp
[InlineData(null)]
[InlineData("")]
public void IsValidWord_InputIsNullOrEmpty_ReturnsFalse(string input)
{
    var glossary = new Glossary();
    
    var result = glossary.IsValidWord(input);

    Assert.False(result);
}
```

### Write minimally passing tests
The input to be used in a unit test should be the simplest possible in order to pass the behavior that you are currently testing.

#### Why?
- Tests become more resilient to future changes in the codebase.
- Closer to testing behavior over implementation.

#### Bad:
```csharp
public void ConcatenateWords_ByDefault_ReturnsStringWithCommaBetween()
{
    var glossary = new Glossary();
    var firstWord = "aardvark";
    var secondWord = "baboon";

    var result = glossary.ConcatenateWords(firstWord, secondWord)

    Assert.Equals("aardvark,baboon", result)
}
```

#### Better:
```csharp
public void ConcatenateWords_ByDefault_ReturnsStringWithCommaBetween()
{
    var glossary = new Glossary();

    var result = glossary.ConcatenateWords("a", "b")

    Assert.Equals("a,b", result)
}
```

## How do I...?

### Test private methods
In most cases, there should not be a need to test a private method. Private methods are an implementation detail. You can think of it this way: private methods never exist in isolation. At some point, there is going to be a public facing method that calls the private method as part of its implementation. What you should care about is the end result of the public method that calls into the private one. 

Consider the following case

```csharp
public string ParseLogLine(string input)
{
    var sanitizedInput = trimInput(input);
    return sanitizedInput;
}

private string trimInput(string input)
{
    return input.Trim();
}
```

Your first reaction may be to start writing a test for `trimInput` because you want to make sure that the method is working as expected. However, it is entirely possible that `ParseLogLine` manipulates `sanitizedInput` in such a way that we do not expect, rendering a test against `trimInput` useless. 

The real test should be done against the public facing method `ParseLogLine` because that is what we ultimately care about. 

```csharp
public void ParseLogLine_ByDefault_ReturnsTrimmedResult()
{
    var parser = new Parser();

    var result = parser.ParseLogLine(" a ");

    Assert.Equals("a", result);
}
```

With this viewpoint, if you see a private method, find the public method and write your tests against that method. Just because a private method returns the expected result, does not mean the system that eventually calls the private method uses the result correctly.

### Stub static references
One of the principles of a unit test is that it must have full control of the system under test. This can be problematic when production code includes calls to static references (e.g. `DateTime.Now`). Consider the following code

```csharp
public bool CanPerformOperation()
{
    if(DateTime.Now == DayOfWeek.Sunday) 
    {
        return true;
    }
    else 
    {
        return false;
    }
}
```

How can this code possibly be unit tested? You may try an approach such as

```csharp
public void CanPerformOperation_OnSunday_ReturnsTrue()
{
    var operationService = new OperationService();

    var result = operationService.CanPerformOperation();

    Assert.True(result);
}

public void CanPerformOperation_OnMonday_ReturnsFalse()
{
    var operationService = new OperationService();

    var result = operationService.CanPerformOperation();

    Assert.False(result);   
}
```

Unfortunately, you will quickly realize that there are a few problems with your tests. 

- If the test suite is ran on a Sunday, the first test will pass, and the second test will fail.
- If the test suite is ran on any other day, the first test will fail, and the second test will pass.
- How is it even possible to test a specific day of the week..?

To solve this problem, you'll need to introduce a *seam* into your production code. One approach to solve this is to wrap the code that you need to control in an interface and have the production code depend on that interface.

```csharp
public interface IDateTimeProvider
{
    DayOfWeek DayOfWeek();
}

public bool CanPerformOperation(IDateTimeProvider dateTimeProvider)
{
    if(dateTimeProvider.DayOfWeek() == DayOfWeek.Sunday)
    {
        return true;
    }
    else
    {
        return false;
    }
}
```

Your test suite now becomes

```csharp
public void CanPerformOperation_OnSunday_ReturnsTrue()
{
    var operationService = new OperationService();
    var dateTimeProviderStub = new Mock<IDateTimeProvider>();
    dateTimeProviderStub.Setup(dtp => dtp.DayOfWeek()).Returns(DayOfWeek.Sunday);

    var result = operationService.CanPerformOperation(dateTimeProviderStub);

    Assert.True(result);
}

public void CanPerformOperation_OnMonday_ReturnsFalse()
{
    var operationService = new OperationService();
    var dateTimeProviderStub = new Mock<IDateTimeProvider>();
    dateTimeProviderStub.Setup(dtp => dtp.DayOfWeek()).Returns(DayOfWeek.Monday);

    var result = operationService.CanPerformOperation(dateTimeProviderStub);

    Assert.False(result);
}
```

Now the test suite has full control over `DateTime.Now` and can stub any value when calling into the method.
