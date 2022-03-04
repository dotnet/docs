---
title: "Breaking change: API Controllers Actions try to infer parameters from DI"
description: Learn about the breaking change in ASP.NET Core 7.0 where API Controllers Actions try to infer parameters from DI.
ms.date: 03/04/2022
---

# API Controllers Actions try to infer parameters from DI

The mechanism to infer binding source of **API Controller action's parameters** now mark parameters to be bound from the Dependency Injection container when the type is registered in the container. In rare cases this can break applications that have a type in DI that is also accepted in API Controller actions methods.

## Version introduced

ASP.NET Core 7.0 Preview 2

## Previous behavior

Before if you want to bind a type registered in your Dependency Injection container, it **must** be explicitly decorated using an attribute that implements <xref:Microsoft.AspNetCore.Http.Metadata.IFromServiceMetadata> (eg.: <xref:Microsoft.AspNetCore.Mvc.FromServicesAttribute>).

```csharp
Services.AddScoped<SomeCustomType>();

[Route("[controller]")]
[ApiController]
public class MyController : ControllerBase
{
    public ActionResult Get([FromServices]SomeCustomType service) => Ok();
}
```

If the attribute is not specified, the parameter is resolved from the request Body sent by the client.

```csharp
Services.AddScoped<SomeCustomType>();

[Route("[controller]")]
[ApiController]
public class MyController : ControllerBase
{
    // Bind from the request body
    [HttpPost]
    public ActionResult Post(SomeCustomType service) => Ok();
}
```

## New behavior

Now types in DI will be checked at app startup using <xref:Microsoft.Extensions.DependencyInjection.IServiceProviderIsService> to determine if an argument in an API controller action will come from DI or from the other sources.

In the below example `SomeCustomType` (assuming you're using the default DI container) will come from the DI container.

``` csharp
Services.AddScoped<SomeCustomType>();

[Route("[controller]")]
[ApiController]
public class MyController : ControllerBase
{
    // Binding from the services
    [HttpPost]
    public ActionResult Post(SomeCustomType service) => Ok();
}
```

The new mechanism to infer binding source of **API Controller action's parameters** will follow the rule bellow:

1. A previously specified <xref:Microsoft.AspNetCore.Mvc.ModelBinding.BindingInfo.BindingSource%2A?displayProperty=nameWithType> is never overwritten.
1. A complex type parameter, registered in the DI container, is assigned <xref:Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource.Services?displayProperty=nameWithType>.
1. A complex type parameter, not registered in the DI container, is assigned <xref:Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource.Body?displayProperty=nameWithType>.
1. Parameter with a name that appears as a route value in ANY route template is assigned <xref:Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource.Path?displayProperty=nameWithType>.
1. All other parameters are <xref:Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource.Query?displayProperty=nameWithType>.

## Type of breaking change

This change affects [source compatibility](../../categories.md#source-compatibility).

## Reason for change

We believe the likelihood of breaking apps to be very low as it's not a common scenario to have a type in DI and as an argument in your API controller action at the same time. Also, this same behavior is currently supported by Minimal Actions.

## Recommended action

If you are broken by this change you can disable the feature by setting `DisableImplicitFromServicesParameters` to true.

```csharp
services.Configure<ApiBehaviorOptions>(options =>
{
     options.DisableImplicitFromServicesParameters = true;
});
```

Also, you could continue to have your action's parameters, with the new feature enabled or not, binding from your DI container using an attribute that implements <xref:Microsoft.AspNetCore.Http.Metadata.IFromServiceMetadata> (eg.: <xref:Microsoft.AspNetCore.Mvc.FromServicesAttribute>).

``` csharp
Services.AddScoped<SomeCustomType>();

[Route("[controller]")]
[ApiController]
public class MyController : ControllerBase
{
    // Binding from the DI container
    [HttpPost]
    public ActionResult Post([FromServices]SomeCustomType service) => Ok();
}
```

## Affected APIs

API Controller actions.
