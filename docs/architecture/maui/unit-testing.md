---
title: Unit Testing
description:  Learn how to provide application testing and improve code quality in .NET MAUI.
author: michaelstonis
no-loc: [MAUI]
ms.date: 05/30/2024
ms.topic: article
---

# Unit testing

[!INCLUDE [download-alert](includes/download-alert.md)]

Multi-platform apps experience problems similar to both desktop and web-based applications. Mobile users will differ by their devices, network connectivity, availability of services, and various other factors. Therefore, multi-platform apps should be tested as they would be used in the real world to improve their quality, reliability, and performance. Many types of testing should be performed on an app, including unit testing, integration testing, and user interface testing. Unit testing is the most common form and essential to building high-quality applications.

A unit test takes a small unit of the app, typically a method, isolates it from the remainder of the code, and verifies that it behaves as expected. Its goal is to check that each unit of functionality performs as expected, so errors don't propagate throughout the app. Detecting a bug where it occurs is more efficient than observing the effect of a bug indirectly at a secondary point of failure.

Unit testing has the most significant effect on code quality when it's an integral part of the software development workflow. Unit tests can act as design documentation and functional specifications for an application. As soon as a method has been written, unit tests should be written that verify the method's behavior in response to standard, boundary, and incorrect input data cases and check any explicit or implicit assumptions made by the code. Alternatively, with test-driven development, unit tests are written before the code. For more information on test-driven development and how to implement it, see [Walkthrough: Test-driven development using Test Explorer.](/visualstudio/test/quick-start-test-driven-development-with-test-explorer).

> [!NOTE]
> Unit tests are very effective against regression. That is, functionality that used to work, but has been disturbed by a faulty update.

Unit tests typically use the arrange-act-assert pattern:

| Step | Description |
|---------|---------|
| Arrange | Initializes objects and sets the value of the data that is passed to the method under test. |
| Act | Invokes the method under test with the required arguments. |
| Assert | Verifies that the action of the method under test behaves as expected. |

This pattern ensures that unit tests are readable, self-describing, and consistent.

## Dependency injection and unit testing

One of the motivations for adopting a loosely-coupled architecture is that it facilitates unit testing. One of the types registered with the dependency injection service is the `IAppEnvironmentService` interface. The following code example shows an outline of this class:

```csharp
public class OrderDetailViewModel : ViewModelBase
{
    private IAppEnvironmentService _appEnvironmentService;

    public OrderDetailViewModel(
        IAppEnvironmentService appEnvironmentService,
        IDialogService dialogService, INavigationService navigationService, ISettingsService settingsService)
        : base(dialogService, navigationService, settingsService)
    {
        _appEnvironmentService = appEnvironmentService;
    }
}
```

The `OrderDetailViewModel` class has a dependency on the `IAppEnvironmentService` type, which the dependency injection container resolves when it instantiates an `OrderDetailViewModel` object. However, rather than create an `IAppEnvironmentService` object which utilizes real servers, devices and configurations to unit test the `OrderDetailViewModel` class, instead, replace the `IAppEnvironmentService` object with a mock object for the purpose of the tests. A mock object is one that has the same signature of an object or an interface, but is created in a specific manner to help with unit testing. It is often used with dependency injection to provide specific implementations of interfaces for testing different data and workflow scenarios.

This approach allows the `IAppEnvironmentService` object to be passed into the `OrderDetailViewModel` class at runtime, and in the interests of testability, it allows a mock class to be passed into the `OrderDetailViewModel` class at test time. The main advantage of this approach is that it enables unit tests to be executed without requiring unwieldy resources such as runtime platform features, web services, or databases.

## Testing MVVM applications

Testing models and view models from MVVM applications is identical to testing any other class, and uses the same tools and techniques; this includes features such as unit testing and mocking. However, some patterns that are typical to model and view model classes can benefit from specific unit testing techniques.

> [!TIP]
> Test one thing with each unit test. As the complexity of a test expands, it makes verification of that test more difficult. By limiting a unit test to a single concern, we can ensure that our tests are more repeatable, isolated, and have a smaller execution time. See
[Unit testing best practices with .NET](../../core/testing/unit-testing-best-practices.md) for more best practices.

Don't be tempted to make a unit test exercise more than one aspect of the unit's behavior. Doing so leads to tests that are difficult to read and update. It can also lead to confusion when interpreting a failure.

The eShop multi-platform app uses [MSTest](../../core/testing/unit-testing-csharp-with-mstest.md) to perform unit testing, which supports two different types of unit tests:

| Testing Type    | Attribute    | Description                                                  |
|-----------------|--------------|--------------------------------------------------------------|
| TestMethod      | `TestMethod` | Defines the actual test method to run.                       |
| DataSource      | `DataSource` | Tests that are only true for a particular set of data.       |

The unit tests included with the eShop multi-platform app are TestMethod, so each unit test method is decorated with the `TestMethod` attribute. In addition to MSTest there are several other testing frameworks available including [NUnit](../../core/testing/unit-testing-csharp-with-nunit.md) and [xUnit](../../core/testing/unit-testing-csharp-with-xunit.md).

## Testing asynchronous functionality

When implementing the MVVM pattern, view models usually invoke operations on services, often asynchronously. Tests for code that invokes these operations typically use mocks as replacements for the actual services. The following code example demonstrates testing asynchronous functionality by passing a mock service into a view model:

```csharp
[TestMethod]
public async Task OrderPropertyIsNotNullAfterViewModelInitializationTest()
{
    // Arrange
    var orderService = new OrderMockService();
    var orderViewModel = new OrderDetailViewModel(orderService);

    // Act
    var order = await orderService.GetOrderAsync(1, GlobalSetting.Instance.AuthToken);
    await orderViewModel.InitializeAsync(order);

    // Assert
    Assert.IsNotNull(orderViewModel.Order);
}
```

This unit test checks that the `Order` property of the `OrderDetailViewModel` instance will have a value after the `InitializeAsync` method has been invoked. The `InitializeAsync` method is invoked when the view model's corresponding view is navigated to. For more information about navigation, see [Navigation](navigation.md).

When the `OrderDetailViewModel` instance is created, it expects an `IOrderService` instance to be specified as an argument. However, the `OrderService` retrieves data from a web service. Therefore, an `OrderMockService` instance, a mock version of the `OrderService` class, is specified as the argument to the `OrderDetailViewModel` constructor. Then, mock data is retrieved rather than communicating with a web service when the view model's `InitializeAsync` method is invoked, which uses `IOrderService` operations.

## Testing INotifyPropertyChanged implementations

Implementing the `INotifyPropertyChanged` interface allows views to react to changes that originate from view models and models. These changes are not limited to data shown in controls -- they are also used to control the view, such as view model states that cause animations to be started or controls to be disabled.

Properties that can be updated directly by the unit test can be tested by attaching an event handler to the `PropertyChanged` event and checking whether the event is raised after setting a new value for the property. The following code example shows such a test:

```csharp
[TestMethod]
public async Task SettingOrderPropertyShouldRaisePropertyChanged()
{
    var invoked = false;
    var orderService = new OrderMockService();
    var orderViewModel = new OrderDetailViewModel(orderService);

    orderViewModel.PropertyChanged += (sender, e) =>
    {
        if (e.PropertyName.Equals("Order"))
            invoked = true;
    };
    var order = await orderService.GetOrderAsync(1, GlobalSetting.Instance.AuthToken);
    await orderViewModel.InitializeAsync(order);

    Assert.IsTrue(invoked);
}
```

This unit test invokes the `InitializeAsync` method of the `OrderViewModel` class, which causes its `Order` property to be updated. The unit test will pass, provided that the `PropertyChanged` event is raised for the `Order` property.

## Testing message-based communication

View models that use the `MessagingCenter` class to communicate between loosely coupled classes can be unit tested by subscribing to the message being sent by the code under test, as demonstrated in the following code example:

```csharp
[TestMethod]
public void AddCatalogItemCommandSendsAddProductMessageTest()
{
    var messageReceived = false;
    var catalogService = new CatalogMockService();
    var catalogViewModel = new CatalogViewModel(catalogService);

    MessagingCenter.Subscribe<CatalogViewModel, CatalogItem>(
        this, MessageKeys.AddProduct, (sender, arg) =>
    {
        messageReceived = true;
    });
    catalogViewModel.AddCatalogItemCommand.Execute(null);

    Assert.IsTrue(messageReceived);
}
```

This unit test checks that the `CatalogViewModel` publishes the `AddProduct` message in response to its `AddCatalogItemCommand` being executed. Because the `MessagingCenter` class supports multicast message subscriptions, the unit test can subscribe to the `AddProduct` message and execute a callback delegate in response to receiving it. This callback delegate, specified as a lambda expression, sets a boolean field that's used by the `Assert` statement to verify the behavior of the test.

## Testing exception handling

Unit tests can also be written that check that specific exceptions are thrown for invalid actions or inputs, as demonstrated in the following code example:

```csharp
[TestMethod]
public void InvalidEventNameShouldThrowArgumentExceptionText()
{
    var behavior = new MockEventToCommandBehavior
    {
        EventName = "OnItemTapped"
    };
    var listView = new ListView();

    Assert.Throws<ArgumentException>(() => listView.Behaviors.Add(behavior));
}
```

This unit test will throw an exception because the `ListView` control does not have an event named `OnItemTapped`. The `Assert.Throws<T>` method is a generic method where `T` is the type of the expected exception. The argument passed to the `Assert.Throws<T>` method is a lambda expression that will throw the exception. Therefore, the unit test will pass provided that the lambda expression throws an `ArgumentException`.

> [!TIP]
> Avoid writing unit tests that examine exception message strings. Exception message strings might change over time, and so unit tests that rely on their presence are regarded as brittle.

## Testing validation

There are two aspects to testing the validation implementation: testing that any validation rules are correctly implemented and testing that the `ValidatableObject<T>` class performs as expected.

Validation logic is usually simple to test, because it is typically a self-contained process where the output depends on the input. There should be tests on the results of invoking the `Validate` method on each property that has at least one associated validation rule, as demonstrated in the following code example:

```csharp
[TestMethod]
public void CheckValidationPassesWhenBothPropertiesHaveDataTest()
{
    var mockViewModel = new MockViewModel();
    mockViewModel.Forename.Value = "John";
    mockViewModel.Surname.Value = "Smith";

    var isValid = mockViewModel.Validate();

    Assert.IsTrue(isValid);
}
```

This unit test checks that validation succeeds when the two `ValidatableObject<T>` properties in the `MockViewModel` instance both have data.

As well as checking that validation succeeds, validation unit tests should also check the values of the `Value`, `IsValid`, and `Errors` property of each `ValidatableObject<T>` instance, to verify that the class performs as expected. The following code example demonstrates a unit test that does this:

```csharp
[TestMethod]
public void CheckValidationFailsWhenOnlyForenameHasDataTest()
{
    var mockViewModel = new MockViewModel();
    mockViewModel.Forename.Value = "John";

    bool isValid = mockViewModel.Validate();

    Assert.IsFalse(isValid);
    Assert.IsNotNull(mockViewModel.Forename.Value);
    Assert.IsNull(mockViewModel.Surname.Value);
    Assert.IsTrue(mockViewModel.Forename.IsValid);
    Assert.IsFalse(mockViewModel.Surname.IsValid);
    Assert.AreEqual(mockViewModel.Forename.Errors.Count(), 0);
    Assert.AreNotEqual(mockViewModel.Surname.Errors.Count(), 0);
}
```

This unit test checks that validation fails when the `Surname` property of the `MockViewModel` doesn't have any data, and the `Value`, `IsValid`, and `Errors` property of each `ValidatableObject<T>` instance are correctly set.

## Summary

A unit test takes a small unit of the app, typically a method, isolates it from the remainder of the code, and verifies that it behaves as expected. Its goal is to check that each unit of functionality performs as expected, so errors don't propagate throughout the app.

The behavior of an object under test can be isolated by replacing dependent objects with mock objects that simulate the behavior of the dependent objects. This enables unit tests to be executed without requiring unwieldy resources such as runtime platform features, web services, or databases

Testing models and view models from MVVM applications is identical to testing any other classes, and the same tools and techniques can be used.
