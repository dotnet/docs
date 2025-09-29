---
title: "Breaking change: HTTP logging middleware requires AddHttpLogging"
description: Learn about the breaking change in ASP.NET Core 8.0 where HTTP logging middleware now requires AddHttpLogging to be called on app startup.
ms.date: 11/14/2023
---
# HTTP logging middleware requires AddHttpLogging

ASP.NET Core HTTP logging middleware has been updated with extra functionality. The middleware now requires services registered with <xref:Microsoft.Extensions.DependencyInjection.HttpLoggingServicesExtensions.AddHttpLogging%2A>.

## Version introduced

ASP.NET Core 8.0

## Previous behavior

Previously, HTTP logging could be used by calling only <xref:Microsoft.AspNetCore.Builder.HttpLoggingBuilderExtensions.UseHttpLogging%2A>:

```csharp
var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();
app.UseHttpLogging();
app.MapGet("/", () => "Hello World!");
app.Run();
```

## New behavior

If <xref:Microsoft.Extensions.DependencyInjection.HttpLoggingServicesExtensions.AddHttpLogging%2A> is not called on app startup, ASP.NET Core throws an informative error:

> System.InvalidOperationException: Unable to resolve service for type 'Microsoft.Extensions.ObjectPool.ObjectPool`1[Microsoft.AspNetCore.HttpLogging.HttpLoggingInterceptorContext]' while attempting to activate 'Microsoft.AspNetCore.HttpLogging.HttpLoggingMiddleware'.

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

Additional features were added to the HttpLogging middleware which are registered (and configurable) via the <xref:Microsoft.Extensions.DependencyInjection.HttpLoggingServicesExtensions.AddHttpLogging%2A> method.

## Recommended action

Ensure that <xref:Microsoft.Extensions.DependencyInjection.HttpLoggingServicesExtensions.AddHttpLogging%2A> is called at application startup.

For example:

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpLogging();

var app = builder.Build();
app.UseHttpLogging();
app.MapGet("/", () => "Hello World!");
app.Run();
```

## Affected APIs

- <xref:Microsoft.AspNetCore.Builder.HttpLoggingBuilderExtensions.UseHttpLogging%2A?displayProperty=fullName>
