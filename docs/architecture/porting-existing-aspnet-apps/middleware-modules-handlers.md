---
title: Compare middleware to modules and handlers
description: This section explores the differences in structure for ASP.NET apps that use handlers and modules with ASP.NET Core apps that define middleware for their request handling pipelines.
author: ardalis
ms.date: 11/13/2020
---

# Compare middleware to modules and handlers

If your existing ASP.NET MVC or Web API app uses OWIN/Katana, you're most likely already familiar with the concept of middleware and porting it to ASP.NET Core should be fairly straightforward. However, most ASP.NET apps rely on HTTP modules and HTTP handlers instead of middleware. Migrating these to ASP.NET Core requires extra effort.

## ASP.NET modules and handlers

[HTTP modules and HTTP handlers](/troubleshoot/aspnet/http-modules-handlers) are an integral part of the ASP.NET architecture. While a request is being processed, each request is processed by multiple HTTP modules (for example, the authentication module and the session module) and is then processed by a single HTTP handler. After the handler has processed the request, the request flows back through the HTTP modules.

If your app is using custom HTTP modules or HTTP handlers, you'll need a plan to migrate them to ASP.NET Core. The most likely replacement in ASP.NET Core is middleware.

## ASP.NET Core middleware

ASP.NET Core defines a request pipeline in each app's `Configure` method. This request pipeline defines how an incoming request is handled by the app, with each method in the pipeline calling the next method until eventually a method terminates, and the chain of *middleware* terminates and returns back up the stack. Middleware can target all requests, or can be configured to only map to certain requests based on the requested path or other factors. It can be configured wholly in the `Configure` method of an app, or implemented in a separate class.

Behavior in an ASP.NET MVC app that uses HTTP modules is probably best suited to [custom middleware](/aspnet/core/fundamentals/middleware/?preserve-view=true&view=aspnetcore-3.1). Custom HTTP handlers can be replaced with custom routes or endpoints that respond to the same path.

## References

- [ASP.NET HTTP modules and HTTP handlers](/troubleshoot/aspnet/http-modules-handlers)
- [ASP.NET Core middleware](/aspnet/core/fundamentals/middleware/?preserve-view=true&view=aspnetcore-3.1)

>[!div class="step-by-step"]
>[Previous](dependency-injection-differences.md)
>[Next](configuration-differences.md)
