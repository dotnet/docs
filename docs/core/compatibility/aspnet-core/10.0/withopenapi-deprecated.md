---
title: "Breaking change: Deprecation of WithOpenApi extension method"
description: "Learn about the breaking change in ASP.NET Core 10 where WithOpenApi extension methods have been deprecated and produce a compiler warning."
ms.date: 12/17/2024
ai-usage: ai-assisted
ms.custom: https://github.com/aspnet/Announcements/issues/519
---

# Deprecation of WithOpenApi extension method

The `WithOpenApi` extension methods in `Microsoft.AspNetCore.OpenApi.OpenApiEndpointConventionBuilderExtensions` have been deprecated in .NET 10. Invoking these methods now produces the compile-time diagnostic **ASPDEPR002** and a standard `[Obsolete]` warning.

## Version introduced

.NET 10 Preview 7

## Previous behavior

Previously, you could use the `WithOpenApi` extension method without any warnings:

```csharp
app.MapGet("/weather", () => ...)
   .WithOpenApi();   // no warnings
```

## New behavior

Starting in .NET 10 Preview 7, using the `WithOpenApi` extension method produces a compiler warning:

```csharp
app.MapGet("/weather", () => ...)
   .WithOpenApi();   // warning ASPDEPR002: WithOpenApi is deprecated and will be removed in a future release. For more information, visit https://aka.ms/aspnet/deprecate/002.
```

The call still compiles and executes, but the build now emits the new deprecation warning.

## Type of breaking change

This is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

`WithOpenApi` duplicated functionality now provided by the built-in OpenAPI document generation pipeline. Deprecating it simplifies the API surface and prepares for its eventual removal.

## Recommended action

Remove `.WithOpenApi()` calls from your code.

- If using `Microsoft.AspNetCore.OpenApi` for document generation, use the `AddOpenApiOperationTransformer` extension method.

**Before**

```csharp
using Microsoft.AspNetCore.OpenApi;

var builder = WebApplication.CreateBuilder();
var app = builder.Build();

app.MapGet("/weather", () => ...)
   .WithOpenApi(operation =>
   {
       // Per-endpoint tweaks
       operation.Summary     = "Gets the current weather report.";
       operation.Description = "Returns a short description and emoji.";
       return operation;
   });

app.Run();
```

**After**

```csharp
using Microsoft.AspNetCore.OpenApi;

var builder = WebApplication.CreateBuilder();
var app = builder.Build();

app.MapGet("/weather", () => ...)
   .AddOpenApiOperationTransformer((operation, context, ct) =>
   {
       // Per-endpoint tweaks
       operation.Summary     = "Gets the current weather report.";
       operation.Description = "Returns a short description and emoji.";
       return Task.CompletedTask;
   });

app.Run();
```

- If using `Swashbuckle` for document generation, use the `IOperationFilter` API.
- If using `NSwag` for document generation, use the `IOperationProcessor` API.

## Affected APIs

- <xref:Microsoft.AspNetCore.OpenApi.OpenApiEndpointConventionBuilderExtensions.WithOpenApi%2A?displayProperty=fullName>
