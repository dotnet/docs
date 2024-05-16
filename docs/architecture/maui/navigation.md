---
title: Navigation
description: Managing Navigation in a .NET MAUI Application
author: michaelstonis
no-loc: [MAUI]
ms.date: 07/01/2022
---

# Navigation

[!INCLUDE [download-alert](includes/download-alert.md)]

.NET MAUI includes support for page navigation, which typically results from the user's interaction with the UI or from the app itself as a result of internal logic-driven state changes. However, navigation can be complex to implement in apps that use the Model-View-ViewModel (MVVM) pattern, as the following challenges must be met:

- Identifying the view to be navigated to using an approach that does not introduce tight coupling and dependencies between views.
- Coordinating the process by which the view to be navigated to is instantiated and initialized. When using MVVM, the view and view-model need to be instantiated and associated with each other via the view's binding context. When an app is using a dependency injection container, the instantiation of views and view-models might require a specific construction mechanism.
- Whether to perform view-first navigation, or view-model-first navigation. With view-first navigation, the page to navigate to refers to the name of the view type. During navigation, the specified view is instantiated, along with its corresponding view-model and other dependent services. An alternative approach is to use view-model-first navigation, where the page to navigate to refers to the name of the view-model type.
- Determining how to cleanly separate the navigational behavior of the app across the views and view-models. The MVVM pattern separates the app's UI and its presentation and business logic, but it doesn't provide a direct mechanism for tying them together. However, the navigation behavior of an app will often span the UI and presentation parts of the app. The user will often initiate navigation from a view, and the view will be replaced as a result of the navigation. However, navigation might often also need to be initiated or coordinated from within the view-model.
- Determining how to pass parameters during navigation for initialization purposes. For example, if the user navigates to a view to update order details, the order data will have to be passed to the view so that it can display the correct data.
- Coordinating navigation to ensure that specific business rules are obeyed. For example, users might be prompted before navigating away from a view so that they can correct any invalid data or be prompted to submit or discard any data changes that were made within the view.

This chapter addresses these challenges by presenting a navigation service class named `MauiNavigationService` that's used to perform view-model-first page navigation.

> [!NOTE]
> The `MauiNavigationService` used by the app is simplistic and does not cover all possible navigation types. The types of navigation needed by your application may require additional functionality.

## Navigating between pages

Navigation logic can reside in a view's code-behind or a data-bound view-model. While placing navigation logic in a view might be the most straightforward approach, it is not easily testable through unit tests. Putting navigation logic in view-model classes means that the logic can be verified through unit tests. In addition, the view-model can then implement logic to control navigation to ensure that certain business rules are enforced. For example, an app might not allow the user to navigate away from a page without first ensuring that the entered data is valid.

A navigation service is typically invoked from view-models, in order to promote testability. However, navigating to views from view-models would require the view-models to reference views, and particularly views that the active view-model isn't associated with, which is not recommended. Therefore, the `MauiNavigationService` presented here specifies the view-model type as the target to navigate to.

The eShopOnContainers multi-platform app uses the `MauiNavigationService` class to provide view-model-first navigation. This class implements the `INavigationService` interface, which is shown in the following code example:

```csharp
public interface INavigationService
{
    Task InitializeAsync();

    Task NavigateToAsync(string route, IDictionary<string, object> routeParameters = null);

    Task PopAsync();
}
```

This interface specifies that an implementing class must provide the following methods:

| Method | Purpose |
| ----------- | ----------- |
| `InitializeAsync` | Performs navigation to one of two pages when the app is launched. |
| `NavigateToAsync(string route, IDictionary<string, object> routeParameters = null)` | Performs hierarchical navigation to a specified page using a registered navigation route. Can optionally pass named route parameters to use for processing on the destination page |
| `PopAsync` | Removes the current page from the navigation stack. |

> [!NOTE]
> An `INavigationService` interface would usually also specify a `GoBackAsync` method, which is used to programmatically return to the previous page in the navigation stack. However, this method is missing from the eShopOnContainers multi-platform app because it's not required.

## Creating the MauiNavigationService instance

The `MauiNavigationService` class, which implements the `INavigationService` interface, is registered as a singleton with the dependency injection container in the `MauiProgram.CreateMauiApp()` method, as demonstrated in the following code example:

```csharp
mauiAppBuilder.Services.AddSingleton<INavigationService, MauiNavigationService>();;
```

The `INavigationService` interface can then be resolved by adding it to the constructor of our views and view-models, as demonstrated in the following code example:

```csharp
public AppShell(INavigationService navigationService)
```

This returns a reference to the `MauiNavigationService` object that's stored in the dependency injection container.

The `ViewModelBase` class stores the `MauiNavigationService` instance in a `NavigationService` property, of type `INavigationService`. Therefore, all view-model classes, which derive from the `ViewModelBase` class, can use the `NavigationService` property to access the methods specified by the `INavigationService` interface.

## Handling navigation requests

.NET MAUI provides multiple ways to navigate within an application. The traditional way to navigate is with the `NavigationPage` class, which implements a hierarchical navigation experience in which the user can navigate through pages, forward and backward, as desired. The eShopOnContainers app uses the `Shell` component as the root container for the application and as a navigation host. For more information about Shell navigation, see [Shell Navigation](/dotnet/maui/fundamentals/shell/navigation) on the Microsoft Developer Center.

Navigation is performed inside view-model classes by invoking one of the `NavigateToAsync` methods, specifying the route path for the page being navigated to, as demonstrated in the following code example:

```csharp
await NavigationService.NavigateToAsync("//Main");
```

The following code example shows the `NavigateToAsync` method provided by the `MauiNavigationService` class:

```csharp
public Task NavigateToAsync(string route, IDictionary<string, object> routeParameters = null)
{
    return
        routeParameters != null
            ? Shell.Current.GoToAsync(route, routeParameters)
            : Shell.Current.GoToAsync(route);
}
```

The .NET MAUI `Shell` control is already familiar with route-based navigation, so the `NavigateToAsync` method works to mask this functionality. The `NavigateToAsync` method allows navigation data to be specified as an argument that's passed to the view-model being navigated to, where it's typically used to perform initialization. For more information, see [Passing parameters during navigation](#passing-parameters-during-navigation).

> [!IMPORTANT]
> There are multiple ways to perform navigation in .NET MAUI. The `MauiNavigationService` is specifically build to work with `Shell`. If you are using a `NavigationPage` or `TabbedPage` or a different navigation mechanism, this routing service would have to be updated to work using those components.

In order to register routes for the `MauiNavigationService` we need to supply route information from XAML or in the code-behind. The following example shows registration of routes via XAML.

```xaml
<?xml version="1.0" encoding="UTF-8" ?>
<Shell
    xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
    xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
    xmlns:views="clr-namespace:eShopOnContainers.Views"
    x:Class="eShopOnContainers.AppShell">

    <!-- Omitted for brevity -->

    <FlyoutItem >
        <ShellContent x:Name="login" ContentTemplate="{DataTemplate views:LoginView}" Route="Login" />
    </FlyoutItem>

    <TabBar x:Name="main" Route="Main">
        <ShellContent Title="CATALOG" Route="Catalog" Icon="{StaticResource CatalogIconImageSource}" ContentTemplate="{DataTemplate views:CatalogView}" />
        <ShellContent Title="PROFILE" Route="Profile" Icon="{StaticResource ProfileIconImageSource}" ContentTemplate="{DataTemplate views:ProfileView}" />
    </TabBar>
</Shell>
```

In this example, the `ShellContent` and `TabBar` user interface objects are setting their `Route` property. This is the preferred method of registering routes for user interface objects that are controlled by a `Shell`.

If we have objects that will be added to the navigation stack at a later time, then we will need to add those via code-behind. The following example show registration of routes in code-behind.

```csharp
Routing.RegisterRoute("Filter", typeof(FiltersView));
Routing.RegisterRoute("Basket", typeof(BasketView));
```

In code-behind, we will call the `Routing.RegisterRoute` method which takes a route name as the first parameter and a view type as the second parameter. When a view-model uses the `NavigationService` property to navigate, the application's `Shell` object will look for registered routes and push them onto the navigation stack.

After the view is created and navigated to, the `ApplyQueryAttributes` and `InitializeAsync` methods of the view's associated view-model are executed. For more information, see [Passing parameters during navigation](#passing-parameters-during-navigation).

## Navigating when the app is launched

When the app is launched, a `Shell` object is set as the root view of the application. Once set, the `Shell` will be used to control route registration and will be present at the root of our application going forward. Once the `Shell` has been created, we can wait for it to be attached to the application using the `OnParentSet` method to initialize our navigation route. The following code example shows this method:

```csharp
protected override async void OnParentSet()
{
    base.OnParentSet();

    if (Parent is not null)
    {
        await _navigationService.InitializeAsync();
    }
}
```

The method uses an instance of `INavigationService` which is provided the constructor from dependency injection and invokes its `InitializeAsync` method.

The following code example shows the implementation of the `MauiNavigationService.InitializeAsync` method:

```csharp
public Task InitializeAsync()
{
    return NavigateToAsync(string.IsNullOrEmpty(_settingsService.AuthAccessToken)
        ? "//Login"
        : "//Main/Catalog");
}
```

The `//Main/Catalog` route is navigated to if the app has a cached access token, which is used for authentication. Otherwise, the `//Login` route is navigated to.

## Passing parameters during navigation

The `NavigateToAsync` method, specified by the `INavigationService` interface, enables navigation data to be specified as an `IDictionary<string, object>` of data that's passed to the view-model being navigated to, where it's typically used to perform initialization.

For example, the `ProfileViewModel` class contains an `OrderDetailCommand` that's executed when the user selects an order on the `ProfileView` page. In turn, this executes the `OrderDetailAsync` method, which is shown in the following code example:

```csharp
private async Task OrderDetailAsync(Order order)
{
    if (order is null)
    {
        return;
    }

    await NavigationService.NavigateToAsync(
        "OrderDetail",
        new Dictionary<string, object>{ { "OrderNumber", order.OrderNumber } });
}
```

This method invokes navigation to the `OrderDetail` route, passing order number information the order that the user selected. When the dependency injection framework creates the `OrderDetailView` for the `OrderDetail` route along with the `OrderDetailViewModel` class which is assigned to the view's `BindingContext`. The `OrderDetailViewModel` has an attribute added to it that allows it to receive data from the navigation service as shown in the code example below.

```csharp
[QueryProperty(nameof(OrderNumber), "OrderNumber")]
public class OrderDetailViewModel : ViewModelBase
{
    public int OrderNumber { get; set; }
}
```

The `QueryProperty` attribute allows us to provide a parameter for a property to map values to and a key to find values from the query parameters dictionary. In this example, the key "OrderNumber" and order number value were provided during the `NavigateToAsync` call. The view-model found the "OrderNumber" key and mapped the value to the `OrderNumber` property. The `OrderNumber` property can then be used at a later time to retrieve the full order details from the `OrderService` instance.

## Invoking navigation using behaviors

Navigation is usually triggered from a view by a user interaction. For example, the `LoginView` performs navigation following successful authentication. The following code example shows how the navigation is invoked by a behavior:

```xml
<WebView>
    <WebView.Behaviors>
        <behaviors:EventToCommandBehavior
            EventName="Navigating"
            EventArgsConverter="{StaticResource WebNavigatingEventArgsConverter}"
            Command="{Binding NavigateCommand}" />
    </WebView.Behaviors>
</WebView>
```

At runtime, the `EventToCommandBehavior` will respond to interaction with the `WebView`. When the `WebView` navigates to a web page, the `Navigating` event will fire, which will execute the `NavigateCommand` in the `LoginViewMode`l. By default, the event arguments for the event are passed to the command. This data is converted as it's passed between source and target by the converter specified in the `EventArgsConverter` property, which returns the `Url` from the `WebNavigatingEventArgs`. Therefore, when the `NavigationCommand` is executed, the `Url` of the web page is passed as a parameter to the registered Action.

In turn, the `NavigationCommand` executes the `NavigateAsync` method, which is shown in the following code example:

```csharp
private async Task NavigateAsync(string url)
{
    // Omitted for brevity.
    if (!string.IsNullOrWhiteSpace(accessToken))
    {
        _settingsService.AuthAccessToken = accessToken;
        _settingsService.AuthIdToken = authResponse.IdentityToken;
        await NavigationService.NavigateToAsync("//Main/Catalog");
    }
}
```

This method invokes `NavigationService` route the application to the `//Main/Catalog` route.

## Confirming or cancelling navigation

An app might need to interact with the user during a navigation operation, so that the user can confirm or cancel navigation. This might be necessary, for example, when the user attempts to navigate before having fully completed a data entry page. In this situation, an app should provide a notification that allows the user to navigate away from the page, or to cancel the navigation operation before it occurs. This can be achieved in a view-model class by using the response from a notification to control whether or not navigation is invoked.

## Summary

.NET MAUI includes support for page navigation, which typically results from the user's interaction with the UI, or from the app itself, as a result of internal logic-driven state changes. However, navigation can be complex to implement in apps that use the MVVM pattern.

This chapter presented a NavigationService class, which is used to perform view-model-first navigation from view-models. Placing navigation logic in view-model classes means that the logic can be exercised through automated tests. In addition, the view-model can then implement logic to control navigation to ensure that certain business rules are enforced.
