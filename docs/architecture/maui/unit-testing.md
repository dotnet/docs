---
title: Unit tests for .NET MAUI
description: Learn how to unit test .NET MAUI application logic, choose a test framework and platform, and identify scenarios that need device or UI tests.
author: michaelstonis
no-loc: [MAUI]
ms.date: 11/05/2026
ai-usage: ai-assisted
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

## Choose a test framework and platform

A test framework defines the attributes, assertions, and test lifecycle you use to write tests. A test platform discovers and runs those tests and integrates with your IDE, command line, and continuous integration (CI) pipeline. [VSTest and Microsoft.Testing.Platform (MTP)](../../core/testing/test-platforms-overview.md) are test platforms, not replacements for frameworks such as MSTest.

The following frameworks support tests for platform-independent .NET MAUI application logic:

| Framework | Framework documentation | MTP configuration |
|-----------|-------------------------|-------------------|
| MSTest | [MSTest overview](../../core/testing/unit-testing-mstest-intro.md) and [Get started with MSTest](../../core/testing/unit-testing-mstest-getting-started.md). | [Run tests with MSTest](../../core/testing/unit-testing-mstest-running-tests.md) and [MSTest SDK](../../core/testing/unit-testing-mstest-sdk.md). |
| NUnit | [Get started with C# and NUnit](../../core/testing/unit-testing-csharp-with-nunit.md). | [NUnit runner](../../core/testing/unit-testing-nunit-runner-intro.md). |
| xUnit.net | [Get started with C# and xUnit.net](../../core/testing/unit-testing-csharp-with-xunit.md). | [xUnit.net v3](https://xunit.net/docs/getting-started/v3/microsoft-testing-platform) has built-in MTP support. [xUnit.net v2](https://xunit.net/docs/getting-started/v2/microsoft-testing-platform) requires a third-party integration that isn't supported by xUnit.net or Microsoft. |
| TUnit | [TUnit documentation](https://tunit.dev/). | TUnit is built on MTP and doesn't support VSTest. |

[MTP](../../core/testing/microsoft-testing-platform-intro.md) runs tests as executable applications. For CLI, IDE, and CI setup, see [Run and debug MTP tests](../../core/testing/microsoft-testing-platform-run-and-debug.md). With the .NET 10 SDK or later, you can select the MTP mode of `dotnet test` in `global.json`. This mode requires MTP 1.7 or later, and all selected test projects must support MTP. Don't mix VSTest-based and MTP-based projects in the same test run. The platforms also use different command-line options. For details, see [Testing with `dotnet test`](../../core/testing/unit-testing-with-dotnet-test.md).

## Understand .NET MAUI test boundaries

To run unit tests on your development machine, isolate business logic, validation, and view models from platform-specific dependencies. One approach is to put that code in a .NET class library that both the app and test project reference. Alternatively, configure your .NET MAUI app or class library to expose a matching non-platform-specific target, such as `net10.0`. For an app project, that target must produce a library rather than an executable. Keep native startup code and platform-specific implementations out of that target. For project configuration, see [.NET MAUI unit testing](/dotnet/maui/deployment/unit-testing).

A non-platform-specific test project doesn't create a native .NET MAUI application context. Replace dependencies on navigation, UI dispatch, and device services with test doubles when you test application logic. These tests don't verify native rendering, device permissions, or the real implementations of the services you replace.

To test code that requires platform APIs or native control handlers, use a compatible platform test host or device runner. MTP can be hosted in a platform application, but selecting MTP for a desktop test project doesn't turn it into a device test app. For device runners and platform test options, including their version requirements, see [.NET MAUI unit testing](/dotnet/maui/deployment/unit-testing). To automate interactions with the deployed app, see [UI testing with Appium](/dotnet/maui/deployment/ui-testing). Run those tests on the platforms you support.

## Dependency injection and unit testing

To isolate the code under test, use constructor injection to supply test doubles for its dependencies. Test doubles, such as fakes and mocks, implement the same interfaces as the real services but provide controlled behavior for a test. For architectural guidance, see [Dependency injection](dependency-injection.md).

For example, the eShop app's [OrderDetailViewModel](https://github.com/dotnet/eShop/blob/main/src/ClientApp/ViewModels/OrderDetailViewModel.cs) receives `IAppEnvironmentService`, `INavigationService`, and `ISettingsService` dependencies through its constructor. Supply test implementations for the dependencies the test exercises rather than call real web services or device APIs.

The [eShop catalog view model tests](https://github.com/dotnet/eShop/blob/main/tests/ClientApp.UnitTests/ViewModels/CatalogViewModelTests.cs) show a complete setup: they construct an `AppEnvironmentService` with mock services, select those services, and pass it to the view model together with a mock navigation service. Use the maintained sample tests for complete constructor and initialization code. Replacing service dependencies isolates application logic; it doesn't remove native requirements from other code the test calls.

## Testing MVVM applications

When models and view models don't require a native application context, test them with the same frameworks and techniques you use for other .NET classes. Some patterns that are typical to model and view model classes benefit from specific unit testing techniques.

> [!TIP]
> Test one behavior with each unit test. To keep tests repeatable, isolated, and easy to diagnose, limit each test to a single concern. For more guidance, see [Unit testing best practices with .NET](../../core/testing/unit-testing-best-practices.md).

Don't be tempted to make a unit test exercise more than one aspect of the unit's behavior. Doing so leads to tests that are difficult to read and update. It can also lead to confusion when interpreting a failure.

The eShop multi-platform app uses MSTest. In MSTest, apply `TestClass` to the test class and `TestMethod` to each test method. For attributes, signatures, and lifecycle guidance, see [Write tests with MSTest](../../core/testing/unit-testing-mstest-writing-tests.md).

To run the same test with different inputs, combine `TestMethod` with `DataRow` for inline data or `DynamicData` for data supplied by a member. These attributes supply test cases; they aren't separate test frameworks or alternatives to `TestMethod`. The legacy `DataSource` attribute is available only for .NET Framework, not modern .NET or .NET MAUI projects. For supported options, see [Data-driven testing in MSTest](../../core/testing/unit-testing-mstest-writing-tests-data-driven.md).

## Testing asynchronous functionality

View models often invoke asynchronous service operations. To test the result rather than an intermediate state, await the operation before you assert. Write asynchronous MSTest methods that return `Task`, or `ValueTask` with MSTest 3.3 or later. Don't use `async void` test methods. For supported signatures, see [Write tests with MSTest](../../core/testing/unit-testing-mstest-writing-tests.md#testmethodattribute).

For example, `ProductsPropertyIsNotNullAfterViewModelInitializationTest` in the [eShop catalog view model tests](https://github.com/dotnet/eShop/blob/main/tests/ClientApp.UnitTests/ViewModels/CatalogViewModelTests.cs) creates a view model with mock services, awaits `InitializeAsync`, and asserts that `Products` isn't null. The test checks initialization with controlled data, not the behavior of the real catalog web service. For the app's initialization and navigation flow, see [Navigation](navigation.md).

For asynchronous commands, await the command's asynchronous execution API before you check the result. Calling `ICommand.Execute` alone doesn't guarantee that asynchronous work has completed. For the MVVM Toolkit command APIs, see [AsyncRelayCommand](/dotnet/communitytoolkit/mvvm/asyncrelaycommand).

## Testing INotifyPropertyChanged implementations

The `INotifyPropertyChanged` interface lets views react to changes in models and view models. To test a notification, attach an event handler to `PropertyChanged`, change the property, and assert that the handler receives the expected `PropertyName`. Don't treat an unrelated property notification as success.

The `SettingForenamePropertyShouldRaisePropertyChanged` test in the [eShop validation view model tests](https://github.com/dotnet/eShop/blob/main/tests/ClientApp.UnitTests/ViewModels/MockViewModelTests.cs) demonstrates this pattern. It subscribes to the `Forename` object's `PropertyChanged` event, sets `Forename.Value`, and checks for a notification for `Value`.

This test verifies the notification contract. It doesn't verify that a XAML binding or native control updates correctly; cover those behaviors with UI tests.

## Testing message-based communication

For message-based communication, use the MVVM Toolkit's `IMessenger`, such as `WeakReferenceMessenger`. For the messaging contract and API examples, see [Communicate between loosely coupled components](communicating-between-components.md) and [MVVM Toolkit Messenger](/dotnet/communitytoolkit/mvvm/messenger).

To test a publisher, register a recipient for the expected message type, execute the operation, and assert that the recipient receives the expected payload. To test a recipient, send a known message and assert the resulting view model state. Await asynchronous commands before you assert.

To isolate message tests, create a messenger instance per test and inject the same instance into the code under test. If the code uses `WeakReferenceMessenger.Default`, unregister test recipients during cleanup and prevent concurrent tests from interfering with shared messenger state. Weak references don't guarantee that a recipient is collected before the next test. For cleanup and isolation options, see [MSTest test lifecycle](../../core/testing/unit-testing-mstest-writing-tests-lifecycle.md) and [Control test execution](../../core/testing/unit-testing-mstest-writing-tests-controlling-execution.md).

> [!NOTE]
> `MessagingCenter` is deprecated in .NET 10. For new code, use the MVVM Toolkit Messenger instead.

## Testing exception handling

To verify that invalid actions or inputs throw an exception, use the framework's exception assertions. In MSTest 3.8 or later, `Assert.Throws<T>` accepts the specified exception type or a derived type, while `Assert.ThrowsExactly<T>` requires the exact type. For asynchronous code, await `Assert.ThrowsAsync<T>` or `Assert.ThrowsExactlyAsync<T>` rather than pass asynchronous work to a synchronous assertion. For examples and version-specific APIs, see [MSTest assertions](../../core/testing/unit-testing-mstest-writing-tests-assertions.md).

An exception assertion passes when it observes the expected exception; the exception isn't an unhandled test failure. If the operation under test constructs native views or uses platform handlers, it still needs the appropriate application context. An exception assertion doesn't provide that context.

> [!TIP]
> Avoid writing unit tests that examine exception message strings. Exception message strings might change over time, and so unit tests that rely on their presence are regarded as brittle.

## Testing validation

Test both the validation rules and the state exposed by `ValidatableObject<T>`. For each rule, cover valid, invalid, and boundary inputs. For the validation model used by the app, see [Validation](validation.md).

The [eShop validation view model tests](https://github.com/dotnet/eShop/blob/main/tests/ClientApp.UnitTests/ViewModels/MockViewModelTests.cs) supply a mock navigation service to `MockViewModel` and exercise its `Validate` method. `CheckValidationPassesWhenBothPropertiesHaveDataTest` checks that validation succeeds when both names have data. `CheckValidationFailsWhenOnlyForenameHasDataTest` checks that a missing surname causes validation to fail.

Check the `Value`, `IsValid`, and `Errors` properties as well as the overall result. For example, when only the forename has data, the forename should remain valid with no errors, while the surname should be invalid with errors. These assertions verify the validation model, not whether the UI displays the errors correctly.

## Summary

A unit test takes a small unit of the app, typically a method, isolates it from the remainder of the code, and verifies that it behaves as expected. Its goal is to check that each unit of functionality performs as expected, so errors don't propagate throughout the app.

To isolate application logic, replace service dependencies with test doubles. Choose a test framework and a compatible test platform, and use their supported attributes and assertions.

Test platform-independent models and view models with ordinary .NET unit tests. Use device, platform, integration, and UI tests for behavior that depends on a real service or native application context.
