---
title: Compare middleware to modules and handlers
description: This section explores the differences in structure for ASP.NET apps that use handlers and modules with ASP.NET Core apps that define middleware for their request handling pipelines.
author: ardalis
ms.date: 12/10/2021
---

# Compare middleware to modules and handlers

If your existing ASP.NET MVC or Web API app uses OWIN/Katana, you're most likely already familiar with the concept of middleware and porting it to ASP.NET Core should be fairly straightforward. However, most ASP.NET apps rely on HTTP modules and HTTP handlers instead of middleware. Migrating these to ASP.NET Core requires extra effort.

## ASP.NET modules and handlers

[HTTP modules and HTTP handlers](/troubleshoot/aspnet/http-modules-handlers) are an integral part of the ASP.NET architecture. While a request is being processed, each request is processed by multiple HTTP modules (for example, the authentication module and the session module) and is then processed by a single HTTP handler. After the handler has processed the request, the request flows back through the HTTP modules.

If your app is using custom HTTP modules or HTTP handlers, you'll need a plan to migrate them to ASP.NET Core. The most likely replacement in ASP.NET Core is middleware.

## ASP.NET Core middleware

ASP.NET Core defines a request pipeline in each app's `Configure` method. This request pipeline defines how an incoming request is handled by the app, with each method in the pipeline calling the next method until eventually a method terminates, and the chain of *middleware* terminates and returns back up the stack. Middleware can target all requests, or can be configured to only map to certain requests based on the requested path or other factors. It can be configured wholly in the `Configure` method of an app, or implemented in a separate class.

Behavior in an ASP.NET MVC app that uses HTTP modules is probably best suited to [custom middleware](/aspnet/core/fundamentals/middleware/?preserve-view=true&view=aspnetcore-3.1). Custom HTTP handlers can be replaced with custom routes or endpoints that respond to the same path.

## Accessing HttpContext

Many .NET apps reference the current request's context through `HttpContext.Current`. This static access can be a common source of problems with testing and other code usage outside of individual requests. When building ASP.NET Core apps, access to the current HttpContext should be provided as a method parameter on middleware, as this sample demonstrates:

```csharp
public class Middleware
{
    private readonly RequestDelegate _next;

    public Middleware(RequestDelegate next)
    {
        _next = next;
    }

    public Task Invoke(HttpContext httpContext)
    {
        return _next(httpContext);
    }
}
```

Similarly, ASP.NET Core filters pass a context argument to their methods, from which the current HttpContext can be accessed:

```csharp
public class MyActionFilterAttribute : ActionFilterAttribute
{
    public override void OnResultExecuting(ResultExecutingContext context)
    {
        var headers = context.HttpContext.Request.Headers;
        // do something based on a header

        base.OnResultExecuting(context);
    }
}
```

If you have components or services that require access to HttpContext, rather than using a static call like `HttpContext.Current` you should instead use constructor dependency injection and the <xref:Microsoft.AspNetCore.Http.IHttpContextAccessor> interface:

```csharp
public class MyService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public MyService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public void DoSomething()
    {
        var currentContext = _httpContextAccessor.HttpContext;
    }
}
```

This approach eliminates the static coupling of the method to the current context while providing access in a testable fashion.

## References

- [ASP.NET HTTP modules and HTTP handlers](/troubleshoot/aspnet/http-modules-handlers)
- [ASP.NET Core middleware](/aspnet/core/fundamentals/middleware/?preserve-view=true&view=aspnetcore-3.1)

>[!div class="step-by-step"]
>[Previous](dependency-injection-differences.md)
>[Next](configuration-differences.md)
