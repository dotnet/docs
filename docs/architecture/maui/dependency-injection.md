---
title: Dependency Injection
description: Patterns for building flexible, decoupled, and testable applications
author: michaelstonis
no-loc: [MAUI]
ms.date: 05/30/2024
ms.topic: article
---

# Dependency injection

[!INCLUDE [download-alert](includes/download-alert.md)]

Typically, a class constructor is invoked when instantiating an object, and any values that the object needs are passed as arguments to the constructor. This is an example of dependency injection known as *constructor injection*. The dependencies the object needs are injected into the constructor.

By specifying dependencies as interface types, dependency injection enables decoupling the concrete types from the code that depends on these types. It generally uses a container that holds a list of registrations and mappings between interfaces and abstract types, and the concrete types that implement or extend these types.

There are also other types of dependency injection, such as *property setter injection* and *method call injection*, but they are less commonly seen. Therefore, this chapter will focus solely on performing constructor injection with a dependency injection container.

## Introduction to dependency injection

Dependency injection is a specialized version of the Inversion of Control (IoC) pattern, where the concern being inverted is the process of obtaining the required dependency. With dependency injection, another class is responsible for injecting dependencies into an object at runtime. The following code example shows how the `ProfileViewModel` class is structured when using dependency injection:

```csharp
private readonly ISettingsService _settingsService;
private readonly IAppEnvironmentService _appEnvironmentService;

public ProfileViewModel(
    IAppEnvironmentService appEnvironmentService,
    IDialogService dialogService, 
    INavigationService navigationService, 
    ISettingsService settingsService)
    : base(dialogService, navigationService, settingsService)
{
    _appEnvironmentService = appEnvironmentService;
    _settingsService = settingsService;

    // Omitted for brevity
}
```

The `ProfileViewModel` constructor receives multiple interface object instances as arguments injected by another class. The only dependency in the `ProfileViewModel` class is on the interface types. Therefore, the `ProfileViewModel` class doesn't have any knowledge of the class that's responsible for instantiating the interface objects. The class that's responsible for instantiating the interface objects, and inserting it into the `ProfileViewModel` class, is known as the *dependency injection container*.

Dependency injection containers reduce the coupling between objects by providing a facility to instantiate class instances and manage their lifetime based on the configuration of the container. During object creation, the container injects any dependencies that the object requires into it. If those dependencies have not yet been created, the container creates and resolves their dependencies first.

There are several advantages to using a dependency injection container:

- A container removes the need for a class to locate its dependencies and manage its lifetimes.
- A container allows the mapping of implemented dependencies without affecting the class.
- A container facilitates testability by allowing dependencies to be mocked.
- A container increases maintainability by allowing new classes to be easily added to the app.

In the context of a .NET MAUI app that uses MVVM, a dependency injection container will typically be used for registering and resolving views, registering and resolving view models, and for registering services and injecting them into view models.

There are many dependency injection containers available in .NET; the eShop multi-platform app uses `Microsoft.Extensions.DependencyInjection` to manage the instantiation of views, view models, and service classes in the app. `Microsoft.Extensions.DependencyInjection` facilitates building loosely coupled apps, and provides all of the features commonly found in dependency injection containers, including methods to register type mappings and object instances, resolve objects, manage object lifetimes, and inject dependent objects into constructors of objects that it resolves. For more information about `Microsoft.Extensions.DependencyInjection`, see [Dependency injection in .NET](../../core/extensions/dependency-injection.md).

In .NET MAUI, the `MauiProgram` class will call into the `CreateMauiApp` method to create a `MauiAppBuilder` object. The `MauiAppBuilder` object has a `Services` property of type `IServiceCollection`, which provides a place to register our components, such as views, view models, and services for dependency injection. Any components registered with the `Services` property will be provided to the dependency injection container when the `MauiAppBuilder.Build` method is called.

At runtime, the container must know which implementation of the services are being requested in order to instantiate them for the requested objects. In the eShop multi-platform app, the `IAppEnvironmentService`, `IDialogService`, `INavigationService`, and `ISettingsService` interfaces need to be resolved before it can instantiate a `ProfileViewModel` object. This involves the container performing the following actions:

- Deciding how to instantiate an object that implements the interface. This is known as *registration*.
- Instantiating the object that implements the required interface and the `ProfileViewModel` object. This is known as *resolution*.

Eventually, the app will finish using the `ProfileViewModel` object, and it will become available for garbage collection. At this point, the garbage collector should dispose of any short-lived interface implementations if other classes do not share the same instance.

## Registration

Before dependencies can be injected into an object, the types of the dependencies must first be registered with the container. Registering a type involves passing the container an interface and a concrete type that implements the interface.

There are two ways of registering types and objects in the container through code:

- Register a type or mapping with the container. This is known as transient registration. When required, the container will build an instance of the specified type.
- Register an existing object in the container as a singleton. When required, the container will return a reference to the existing object.

> [!NOTE]
> Dependency injection containers are not always suitable. Dependency injection introduces additional complexity and requirements that might not be appropriate or useful to small apps. If a class does not have any dependencies, or is not a dependency for other types, it might not make sense to put it in the container. In addition, if a class has a single set of dependencies that are integral to the type and will never change, it might not make sense to put it in the container.

The registration of types requiring dependency injection should be performed in a single method in an app. This method should be invoked early in the app's lifecycle to ensure it is aware of the dependencies between its classes. The eShop multi-platform app performs this the `MauiProgram.CreateMauiApp` method. The following code example shows how the eShop multi-platform app declares the `CreateMauiApp` in the `MauiProgram` class:

```csharp
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
        => MauiApp.CreateBuilder()
            .UseMauiApp<App>()
            // Omitted for brevity            
            .RegisterAppServices()
            .RegisterViewModels()
            .RegisterViews()
            .Build();
}
```

The `MauiApp.CreateBuilder` method creates a `MauiAppBuilder` object that we can use to register our dependencies. Many dependencies in the eShop multi-platform app need to be registered, so the extension methods `RegisterAppServices`, `RegisterViewModels`, and `RegisterViews` were created to help provide an organized and maintainable registration workflow. The following code shows the `RegisterViewModels` method:

```csharp
public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder mauiAppBuilder)
{
    mauiAppBuilder.Services.AddSingleton<ViewModels.MainViewModel>();
    mauiAppBuilder.Services.AddSingleton<ViewModels.LoginViewModel>();
    mauiAppBuilder.Services.AddSingleton<ViewModels.BasketViewModel>();
    mauiAppBuilder.Services.AddSingleton<ViewModels.CatalogViewModel>();
    mauiAppBuilder.Services.AddSingleton<ViewModels.ProfileViewModel>();

    mauiAppBuilder.Services.AddTransient<ViewModels.CheckoutViewModel>();
    mauiAppBuilder.Services.AddTransient<ViewModels.OrderDetailViewModel>();
    mauiAppBuilder.Services.AddTransient<ViewModels.SettingsViewModel>();
    mauiAppBuilder.Services.AddTransient<ViewModels.CampaignViewModel>();
    mauiAppBuilder.Services.AddTransient<ViewModels.CampaignDetailsViewModel>();

    return mauiAppBuilder;
}
```

This method receives an instance of `MauiAppBuilder`, and we can use the `Services` property to register our view models. Depending on the needs of your application, you may need to add services with different lifetimes. The following table provides information on when you may want to choose these different registration lifetimes:

| Method | Description |
|---------|---------|
| `AddSingleton<T>` | Will create a single instance of the object which will be remain for the lifetime of the application. |
| `AddTransient<T>` | Will create a new instance of the object when requested during resolution. Transient objects do not have a pre-defined lifetime, but will typically follow the lifetime of their host.  |

> [!NOTE]
> The view models do not inherit from an interface, so they only need their concrete type provided to the `AddSingleton<T>` and `AddTransient<T>` methods.

The `CatalogViewModel` is used near the application's root and should always be available, so registering it with `AddSingleton<T>` is beneficial. Other view models, such as `CheckoutViewModel` and `OrderDetailViewModel` are situationally navigated to or are used later in the application. Suppose you know that you have a component that may not always be used. In that case, if it is memory or computationally intensive or requires just-in-time data, it may be a better candidate for `AddTransient<T>` registration.

Another common way to add services is using the `AddSingleton<TService, TImplementation>` and `AddTransient<TService, TImplementation>` methods. These methods take two input types: the interface definition and the concrete implementation. This type of registration is best for cases where you are implementing services based on interfaces. In the code example below, we register our `ISettingsService` interface using the `SettingsService` implementation:

```csharp
public static MauiAppBuilder RegisterAppServices(this MauiAppBuilder mauiAppBuilder)
{
    mauiAppBuilder.Services.AddSingleton<ISettingsService, SettingsService>();
    // Omitted for brevity...
}
```

Once all services have been registered, the `MauiAppBuilder.Build` method should be called to create our `MauiApp` and populate our dependency injection container with all the registered services.

> [!IMPORTANT]
> Once the `Build` method has been called, the dependency injection container is immutable and can no longer be updated or modified. Ensure that all services that you need within your application have been registered before you call `Build`.

## Resolution

After a type is registered, it can be resolved or injected as a dependency. When a type is being resolved, and the container needs to create a new instance, it injects any dependencies into the instance.

Generally, when a type is resolved, one of three things happens:

1. If the type hasn't been registered, the container throws an exception.
2. If the type has been registered as a singleton, the container returns the singleton instance. If this is the first time the type is called for, the container creates it if required and maintains a reference to it.
3. If the type has been registered as transient, the container returns a new instance and doesn't maintain a reference to it.

.NET MAUI offers a number of ways to resolve registered components based on your needs. The most direct way to gain access to the dependency injection container is from an `Element` using the `Handler.MauiContext.Services`. An example of this is shown below:

```csharp
var settingsService = this.Handler.MauiContext.Services.GetServices<ISettingsService>();
```

This can be helpful if you need to resolve a service from within an `Element` or from outside of the constructor of your `Element`.

> [!CAUTION]
> There is a possibility that the `Handler` property of your `Element` may be null, so be aware that you may need to handle those situations. For more information, please refer to [Handler lifecycle](/dotnet/maui/user-interface/handlers/customize#handler-lifecycle) on the Microsoft Documentation Center.

If using the `Shell` control for .NET MAUI, it will implicitly call into the dependency injection container to create our objects during navigation. When setting up our `Shell` control, the `Routing.RegisterRoute` method will tie a route path to a `View` as shown in the example below:

```csharp
Routing.RegisterRoute("Filter", typeof(FiltersView));
```

During `Shell` navigation, it will look for registrations of the `FiltersView`, and if any are found, it will create that view and inject any dependencies into the constructor. As shown in the code example below, the `CatalogViewModel` will be injected into the `FiltersView`:

```csharp
namespace eShop.Views;

public partial class FiltersView : ContentPage
{
    public FiltersView(CatalogViewModel viewModel)
    {
        BindingContext = viewModel;

        InitializeComponent();
    }
}
```

> [!TIP]
> The dependency injection container is great for creating view model instances. If a view model has dependencies, it will handle the creation and injection of any required services. Just make sure that you register your view models and any dependencies that they may have with the `CreateMauiApp` method in the `MauiProgram` class.  

## Summary

Dependency injection enables the decoupling of concrete types from the code that depends on these types. It typically uses a container that holds a list of registrations and mappings between interfaces and abstract types, and the concrete types that implement or extend these types.

`Microsoft.Extensions.DependencyInjection` facilitates building loosely coupled apps and provides all of the features commonly found in dependency injection containers, including methods to register type mappings and object instances, resolve objects, manage object lifetimes, and inject dependent objects into constructors of objects it resolves.
