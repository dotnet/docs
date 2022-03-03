---
title: "Breaking change: SignalR Hub methods try to resolve parameters from DI"
description: Learn about the breaking change in ASP.NET Core 7.0 where SignalR Hub methods try to resolve parameters from DI.
ms.date: 03/03/2022
---

# SignalR Hub methods try to resolve parameters from DI

Hub methods now support injecting services from your Dependency Injection container. In rare cases this can break applications that have a type in DI that is also accepted in Hub methods from SignalR client messages.

## Version introduced

ASP.NET Core 7.0 Preview 2

## Previous behavior

Before if you accepted a type in your Hub method that was also in your Dependency Injection container the type would always be resolved from a message sent by the client.

```csharp
Services.AddScoped<SomeCustomType>();

class MyHub : Hub
{
    // type always comes from the client, never comes from DI
    public Task Method(string text, SomeCustomType type) => Task.CompletedTask;
}
```

## New behavior

Now types in DI will be checked at app startup using `IServiceProviderIsService` to determine if an argument in a Hub method will come from DI or from the client.

In the below example `SomeCustomType` (assuming you're using the default DI container) will come from the DI container instead of from the client. And if the client tried to send `SomeCustomType` it will get an error.

```csharp
Services.AddScoped<SomeCustomType>();

class MyHub : Hub
{
    // comes from DI by default
    public Task Method(string text, SomeCustomType type) => Task.CompletedTask;
}
```

## Type of breaking change

This change affects [source compatibility](../../categories.md#source-compatibility).

## Reason for change

We believe the likelihood of breaking apps to be very low as it's not a common scenario to have a type in DI and as an argument in your Hub method at the same time.

## Recommended action

If you are broken by this change you can disable the feature by setting `DisableImplicitFromServicesParameters` to true.

```csharp
services.AddSignalR(options =>
{
    options.DisableImplicitFromServicesParameters = true;
});
```

If you are broken by the change but want to use the feature without breaking clients, you can disable the feature as shown above, and use an attribute that implements `IFromServiceMetadata` on new arguments/Hub methods.

```csharp
Services.AddScoped<SomeCustomType>();
Services.AddScoped<SomeCustomType2>();

class MyHub : Hub
{
    // old method with new feature (non-breaking), only SomeCustomType2 will be resolved from DI
    public Task MethodA(string arguments, SomeCustomType type, [FromService] SomeCustomType2 type2);

    // new method
    public Task MethodB(string arguments, [FromService] SomeCustomType type);
}
```

## Affected APIs

Hub methods
