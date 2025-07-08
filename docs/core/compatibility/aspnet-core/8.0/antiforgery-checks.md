---
title: "Breaking change: IFormFile parameters require anti-forgery checks"
description: Learn about the breaking change in ASP.NET Core 8.0 where minimal APIs that consume IFormFile or IFormFileCollection parameters require anti-forgery checks.
ms.date: 12/05/2023
---
# Minimal APIs: IFormFile parameters require anti-forgery checks

Minimal API endpoints that consume an <xref:Microsoft.AspNetCore.Http.IFormFile> or <xref:Microsoft.AspNetCore.Http.IFormFileCollection> are now opted into requiring anti-forgery token validation using the new anti-forgery middleware.

## Version introduced

ASP.NET Core 8.0 RC 1

## Previous behavior

Minimal API endpoints that bound a parameter from the form via <xref:Microsoft.AspNetCore.Http.IFormFile> or <xref:Microsoft.AspNetCore.Http.IFormFileCollection> did not require anti-forgery validation.

## New behavior

Minimal API endpoints that bind a parameter from the form via <xref:Microsoft.AspNetCore.Http.IFormFile> or <xref:Microsoft.AspNetCore.Http.IFormFileCollection> require anti-forgery validation. An exception is thrown at startup if the anti-forgery middleware isn't registered for an API that defines these input types.

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

Anti-forgery token validation is a recommended security precaution for APIs that consume data from a form.

## Recommended action

You can opt out of anti-forgery validation for specific endpoints by using the <xref:Microsoft.AspNetCore.Builder.RoutingEndpointConventionBuilderExtensions.DisableAntiforgery%60%601(%60%600)> method.

```csharp
var app = WebApplication.Create();

app.MapPost("/", (IFormFile formFile) => ...)
  .DisableAntiforgery();

app.Run();
```

## Affected APIs

N/A
