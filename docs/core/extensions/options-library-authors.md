---
title: Options pattern guidance for .NET library authors
author: IEvangelist
description: Learn how to expose the options pattern as a library author in .NET.
ms.author: dapine
ms.date: 11/12/2021
---

# Options pattern guidance for .NET library authors

With the help of dependency injection, registering your services and their corresponding configurations can make use of the *options pattern*. The options pattern enables consumers of your library (and your services) to require instances of [options interfaces](options.md#options-interfaces) where `TOptions` is your options class. Consuming configuration options through strongly-typed objects helps to ensure consistent value representation, and removes the burden of manually parsing string values. There are many [configuration providers](configuration-providers.md) for consumers of your library to use. With these providers, consumers can configure your library in many ways.

As a .NET library author, you'll learn general guidance on how to correctly expose the options pattern to consumers of your library. There are various ways to achieve the same thing, and several considerations to make.

## Naming conventions

By convention, extension methods responsible for registering services are named `Add{Service}`, where `{Service}` is a meaningful and descriptive name. Depending on the package, the registration of services may be accompanied by `Use{Service}` extension methods. The `Use{Service}` extension methods are commonplace in [ASP.NET Core](/aspnet).

✔️ CONSIDER names that disambiguate your service from other offerings.

❌ DO NOT use names that are already part of the .NET ecosystem from official Microsoft packages.

✔️ CONSIDER naming static classes that expose extension methods as `{Type}Extensions`, where `{Type}` is the type that you're extending.

### Namespace guidance

Microsoft packages make use of the `Microsoft.Extensions.DependencyInjection` namespace to unify the registration of various service offerings.

✔️ CONSIDER a namespace that clearly identifies your package offering.

❌ DO NOT use the `Microsoft.Extensions.DependencyInjection` namespace for non-official Microsoft packages.

## Parameterless

If your service can work with minimal or no explicit configuration, consider a parameterless extension method.

:::code language="csharp" source="snippets/configuration/options-noparams/ServiceCollectionExtensions.cs" highlight="10-14":::

In the preceding code, the `AddMyLibraryService`:

- Extends an instance of <xref:Microsoft.Extensions.DependencyInjection.IServiceCollection>
- Calls <xref:Microsoft.Extensions.DependencyInjection.OptionsServiceCollectionExtensions.AddOptions%60%601(Microsoft.Extensions.DependencyInjection.IServiceCollection)?displayProperty=nameWithType> with the type parameter of `LibraryOptions`
- Chains a call to <xref:Microsoft.Extensions.Options.OptionsBuilder%601.Configure%2A>, which specifies the default option values

## `IConfiguration` parameter

When you author a library that exposes many options to consumers, you may want to consider requiring an `IConfiguration` parameter extension method. The expected `IConfiguration` instance should be scoped to a named section of the configuration by using the <xref:Microsoft.Extensions.Configuration.IConfiguration.GetSection%2A?displayProperty=nameWithType> function.

:::code language="csharp" source="snippets/configuration/options-configparam/ServiceCollectionExtensions.cs" highlight="10,12-14":::

> [!TIP]
> The <xref:Microsoft.Extensions.DependencyInjection.OptionsConfigurationServiceCollectionExtensions.Configure%60%601(Microsoft.Extensions.DependencyInjection.IServiceCollection,Microsoft.Extensions.Configuration.IConfiguration)> method is part of the [`Microsoft.Extensions.Options.ConfigurationExtensions`](https://www.nuget.org/packages/Microsoft.Extensions.Options.ConfigurationExtensions) NuGet package.

In the preceding code, the `AddMyLibraryService`:

- Extends an instance of <xref:Microsoft.Extensions.DependencyInjection.IServiceCollection>
- Defines an <xref:Microsoft.Extensions.Configuration.IConfiguration> parameter `namedConfigurationSection`
- Calls <xref:Microsoft.Extensions.DependencyInjection.OptionsConfigurationServiceCollectionExtensions.Configure%60%601(Microsoft.Extensions.DependencyInjection.IServiceCollection,Microsoft.Extensions.Configuration.IConfiguration)> passing the generic type parameter of `LibraryOptions` and the `namedConfigurationSection` instance to configure

Consumers in this pattern provide the scoped `IConfiguration` instance of the named section:

:::code language="csharp" source="snippets/configuration/options-configparam/Program.cs" highlight="21-22":::

The call to `.AddMyLibraryService` is made in the <xref:Microsoft.Extensions.Hosting.IHostBuilder.ConfigureServices%2A> method. The same is true when using a `Startup` class, the addition of services being registered occurs in `ConfigureServices`.

As the library author, specifying default values is up to you.

> [!NOTE]
> It is possible to bind configuration to an options instance. However, there is a risk of name collisions - which will cause errors. Additionally, when manually binding in this way, you limit the consumption of your options pattern to read-once. Changes to settings will not be re-bound, as such consumers will not be able to use the [IOptionsMonitor](options.md#ioptionsmonitor) interface.
>
> ```csharp
> services.AddOptions<LibraryOptions>()
>     .Configure<IConfiguration>(
>         (options, configuration) =>
>             configuration.GetSection("LibraryOptions").Bind(options));
> ```

## `Action<TOptions>` parameter

Consumers of your library may be interested in providing a lambda expression that yields an instance of your options class. In this scenario, you define an `Action<LibraryOptions>` parameter in your extension method.

:::code language="csharp" source="snippets/configuration/options-action/ServiceCollectionExtensions.cs" highlight="9,11":::

In the preceding code, the `AddMyLibraryService`:

- Extends an instance of <xref:Microsoft.Extensions.DependencyInjection.IServiceCollection>
- Defines an <xref:System.Action%601> parameter `configureOptions` where `T` is `LibraryOptions`
- Calls <xref:Microsoft.Extensions.DependencyInjection.OptionsServiceCollectionExtensions.Configure%2A> given the `configureOptions` action

Consumers in this pattern provide a lambda expression (or a delegate that satisfies the `Action<LibraryOptions>` parameter):

:::code language="csharp" source="snippets/configuration/options-action/Program.cs" highlight="21-25":::

## Options instance parameter

Consumers of your library might prefer to provide an inlined options instance. In this scenario, you expose an extension method that takes an instance of your options object, `LibraryOptions`.

:::code language="csharp" source="snippets/configuration/options-object/ServiceCollectionExtensions.cs" highlight="9,11-17":::

In the preceding code, the `AddMyLibraryService`:

- Extends an instance of <xref:Microsoft.Extensions.DependencyInjection.IServiceCollection>
- Calls <xref:Microsoft.Extensions.DependencyInjection.OptionsServiceCollectionExtensions.AddOptions%60%601(Microsoft.Extensions.DependencyInjection.IServiceCollection)?displayProperty=nameWithType> with the type parameter of `LibraryOptions`
- Chains a call to <xref:Microsoft.Extensions.DependencyInjection.OptionsServiceCollectionExtensions.Configure%2A>, which specifies default option values that can be overridden from the given `userOptions` instance

Consumers in this pattern provide an instance of the `LibraryOptions` class, defining desired property values inline:

:::code language="csharp" source="snippets/configuration/options-object/Program.cs" highlight="21-25":::

## Post configuration

After all configuration option values are bound or specified, post configuration functionality is available. Exposing the same [`Action<TOptions>` parameter](#actiontoptions-parameter) detailed earlier, you could choose to call <xref:Microsoft.Extensions.DependencyInjection.OptionsServiceCollectionExtensions.PostConfigure%2A>. Post configure runs after all `.Configure` calls.

:::code language="csharp" source="snippets/configuration/options-postconfig/ServiceCollectionExtensions.cs" highlight="9,11":::

In the preceding code, the `AddMyLibraryService`:

- Extends an instance of <xref:Microsoft.Extensions.DependencyInjection.IServiceCollection>
- Defines an <xref:System.Action%601> parameter `configureOptions` where `T` is `LibraryOptions`
- Calls <xref:Microsoft.Extensions.DependencyInjection.OptionsServiceCollectionExtensions.PostConfigure%2A> given the `configureOptions` action

Consumers in this pattern provide a lambda expression (or a delegate that satisfies the `Action<LibraryOptions>` parameter), just as they would with the [`Action<TOptions>` parameter](#actiontoptions-parameter) in a non-post configuration scenario:

:::code language="csharp" source="snippets/configuration/options-postconfig/Program.cs" highlight="21-25":::

## See also

- [Options pattern in .NET](options.md)
- [Dependency injection in .NET](dependency-injection.md)
- [Dependency injection guidelines](dependency-injection-guidelines.md)
