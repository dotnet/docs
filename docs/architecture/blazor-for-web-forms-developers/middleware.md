---
title: Modules, handlers, and middleware
description: Handling requests with HTTP modules, handlers, and middleware
author: danroth27
ms.author: daroth
ms.date: 09/11/2019
---
# Modules, handlers, and middleware

[!INCLUDE [book-preview](../../../includes/book-preview.md)]

An ASP.NET Core application is built upon a series of middleware that are handlers arranged into a pipeline to handle requests and response. In a WebForms application, HTTP handlers and modules could be used to solve similar problems. However, in ASP.NET Core, modules, handlers, *Global.asax.cs*, and the application life cycle have been replaced with middleware. In this chapter, we will explore what middleware is in terms of a Blazor application.

## Overview

The ASP.NET Core request pipeline consists of a sequence of request delegates, called one after the other. The following diagram demonstrates the concept. The thread of execution follows the black arrows.

![pipeline](media/middleware/request-delegate-pipeline.png)

No where in this diagram is there a concept of life cycle events, a concept that was foundational to how ASP.NET WebForms requests were handled. This system allows for easier reasoning about what process is occuring and allows middleware to be inserted at any point. Middleware execution is based on the order in which they're inserted into the request pipeline. They are also added in code instead of configuration files, usually in *Startup.cs*.

## Katana

For those readers who have familiarity with Katana, this may look familiar. Katana was a framework that ASP.NET Core derives from that inroduced similar middleware and pipeline patterns for ASP.NET. Middleware designed for Katana can fairly easily be adapted to work with the ASP.NET Core pipeline.

## Common Middleware

ASP.NET was shipped with many modules available for a developer. In a similar fashion, ASP.NET Core has many middleware components available as well. IIS modules may be used in some cases with ASP.NET Core, or native ASP.NET Core middleware may be available.

Some of the replacement middleware is shown below:

| Module | ASP.NET Module | ASP.NET Core Option |
| --- | :--: | --- |
| **HTTP Errors** | `CustomErrorModule`                                                            | [Status Code Pages Middleware](xref:fundamentals/error-handling#usestatuscodepages) |
| **Default Document** | `DefaultDocumentModule`                                                   | [Default Files Middleware](xref:fundamentals/static-files#serve-a-default-document) |
| **Directory Browsing** | `DirectoryListingModule`                                                | [Directory Browsing Middleware](xref:fundamentals/static-files#enable-directory-browsing) |
| **Dynamic Compression** | `DynamicCompressionModule`                                            | [Response Compression Middleware](xref:performance/response-compression) |
| **Failed Requests Tracing** | `FailedRequestsTracingModule`                                     | [ASP.NET Core Logging](xref:fundamentals/logging/index#tracesource-provider) |
| **File Caching** | `FileCacheModule`                                                             | [Response Caching Middleware](xref:performance/caching/middleware) |
| **HTTP Caching** | `HttpCacheModule`                                                             | [Response Caching Middleware](xref:performance/caching/middleware) |
| **HTTP Logging** | `HttpLoggingModule`                                                          | [ASP.NET Core Logging](xref:fundamentals/logging/index) |
| **HTTP Redirection** | `HttpRedirectionModule`                                                  | [URL Rewriting Middleware](xref:fundamentals/url-rewriting) |
| **ISAPI Filters** | `IsapiFilterModule`                                                         | [Middleware](xref:fundamentals/middleware/index) |
| **ISAPI** | `IsapiModule`                                                                       | [Middleware](xref:fundamentals/middleware/index) |
| **Request Filtering** | `RequestFilteringModule`                                                | [URL Rewriting Middleware `IRule`](xref:fundamentals/url-rewriting#irule-based-rule) |
| **URL Rewriting**&#8224; | `RewriteModule`                                                      | [URL Rewriting Middleware](xref:fundamentals/url-rewriting) |
| **Static Compression** | `StaticCompressionModule`                                               | [Response Compression Middleware](xref:performance/response-compression) |
| **Static Content** | `StaticFileModule`                                                          | [Static File Middleware](xref:fundamentals/static-files) |
| **URL Authorization** | `UrlAuthorizationModule`                                                | [ASP.NET Core Identity](xref:security/authentication/identity) |

This list is not exhaustive but should give an idea of what mapping exists between the two frameworks. For a more detailed list, please see [here](https://docs.microsoft.com/aspnet/core/host-and-deploy/iis/modules).

## Custom middleware

Built in middleware may not handle all of the scenarios you need for an application. In these cases, it makes sense to insert your own middleware. There are multiple ways of defining middleware, with the simplest being a simple delegate. For example, the following middleware takes a culture request from a query string:

```csharp
public class Startup
{
    public void Configure(IApplicationBuilder app)
    {
        app.Use(async (context, next) =>
        {
            var cultureQuery = context.Request.Query["culture"];
            if (!string.IsNullOrWhiteSpace(cultureQuery))
            {
                var culture = new CultureInfo(cultureQuery);

                CultureInfo.CurrentCulture = culture;
                CultureInfo.CurrentUICulture = culture;
            }

            // Call the next delegate/middleware in the pipeline
            await next();
        });

        app.Run(async (context) =>
        {
            await context.Response.WriteAsync(
                $"Hello {CultureInfo.CurrentCulture.DisplayName}");
        });

    }
}
```

Middleware can also be defined as class, either by implementing the `IMiddleware` interface or by following middleware convention. For more details on this and other middleware topics, please see [here](https://docs.microsoft.com/aspnet/core/fundamentals/middleware/write).

>[!div class="step-by-step"]
>[Previous](data.md)
>[Next](config.md)
