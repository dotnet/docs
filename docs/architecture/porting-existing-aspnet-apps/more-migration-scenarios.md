---
title: More migration scenarios
description: This section describes additional migration scenarios and techniques for upgrading .NET Framework apps to .NET Core / .NET 5.
author: ardalis
ms.date: 02/11/2021
---

# More migration scenarios

[!INCLUDE [book-preview](../../../includes/book-preview.md)]

This section describes several different ASP.NET app scenarios and situation, and offers specific techniques for solving each of them. You can use this section to identify scenarios applicable to your app and evaluate which techniques will work for your app and its hosting environment.

## Migrate ASP.NET MVC 5 and WebApi 2 to ASP.NET Core MVC

A common scenario in ASP.NET MVC 5 and Web API 2 apps was for both products to be installed in the same application. This is a supported and relatively common approach used by many teams, but because the two products use different abstractions, there is some redundant effort needed. For example, setting up routes for ASP.NET MVC is done using methods on `RouteCollection`, such as `MapMvcAttributeRoutes()` and `MapRoute()`. But ASP.NET Web API 2 routing is managed with `HttpConfiguration` and methods like `MapHttpAttributeRoutes()` and `MapHttpRoute()`.

The `eShopLegacyMVC` app includes both ASP.NET MVC and Web API, and includes methods in its `App_Start` folder for setting up routes for both. It also supports dependency injection using Autofac, which also requires two sets of similar work to configure:

```csharp
protected IContainer RegisterContainer()
{
    var builder = new ContainerBuilder();

    var thisAssembly = Assembly.GetExecutingAssembly();
    builder.RegisterControllers(thisAssembly);      // MVC controllers
    builder.RegisterApiControllers(thisAssembly);   // Web API controllers

    var mockData = bool.Parse(ConfigurationManager.AppSettings["UseMockData"]);
    builder.RegisterModule(new ApplicationModule(mockData));

    var container = builder.Build();

    // set mvc resolver
    DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

    // set webapi resolver
    var resolver = new AutofacWebApiDependencyResolver(container);
    GlobalConfiguration.Configuration.DependencyResolver = resolver;

    return container;
}
```

When upgrading these apps to use ASP.NET Core, this duplicate effort and the confusion that sometimes accompanies it is eliminated. ASP.NET Core MVC is a unified framework with one set of rules for routing, filters, and more. Dependency injection is built into ASP.NET Core itself. All of this can can be configured in `Startup.cs`, as is shown in the `eShopPorted` app in the sample.

## Migrate HttpResponseMessage to ASP.NET Core

Some ASP.NET Web API apps may have action methods that return `HttpResponseMessage`. This type does not exist in ASP.NET Core. Below is an example of its usage in a Delete action method, using the `ResponseMessage` helper method on the base `ApiController`:

```csharp
[HttpDelete]
// DELETE api/<controller>/5
public IHttpActionResult Delete(int id)
{
    var brandToDelete = service.GetCatalogBrands().FirstOrDefault(x => x.Id == id);
    if (brandToDelete == null)
    {
        return ResponseMessage(new HttpResponseMessage(HttpStatusCode.NotFound));
    }

    // demo only - don't actually delete
    return ResponseMessage(new HttpResponseMessage(HttpStatusCode.OK));
}
```

In ASP.NET Core MVC, there are helper methods available for all of the common HTTP response status codes, so the above method would be ported to the following code:

```csharp
[HttpDelete("{id}")]
public IActionResult Delete(int id)
{
    var brandToDelete = _service.GetCatalogBrands().FirstOrDefault(x => x.Id == id);
    if (brandToDelete == null)
    {
        return NotFound();
    }

    // demo only - don't actually delete
    return Ok();
}
```

If you do find that you need to return a custom status code for which no helper exists, you can always use `return StatusCode(int statusCode)` to return any numeric code you like.

## Migrate content negotiation from ASP.NET Web API to ASP.NET Core

ASP.NET Web API 2 supports [content negotiation](https://docs.microsoft.com/aspnet/web-api/overview/formats-and-model-binding/content-negotiation) natively. The sample app includes a `BrandsController` demonstrates this support, listing its results in either XML or JSON based on whether request's `Accept` header includes `application/xml` or `application/json`.

ASP.NET MVC 5 apps do not have content negotiation support built in.

Content negotiation is preferable to returning a specific encoding type, as it is more flexible and makes the API available to a larger number of clients. If you currently have action methods that return a specific format, you should consider modifying them to return a result type that supports content negotiation when you port the code to ASP.NET Core.

The following code returns data in JSON format regardless of client `Accept` header content:

```csharp
[HttpGet]
public ActionResult Index()
{
    return Json(new { Message = "Hello World!" });
}
```

[ASP.NET Core MVC supports content negotiation natively](https://docs.microsoft.com/aspnet/core/web-api/advanced/formatting), provided an appropriate [return type](https://docs.microsoft.com/aspnet/core/web-api/action-return-types) is used. Content negotiation is implemented by [ObjectResult] which is returned by the status code-specific action results returned by the controller helper methods. The previous action method, implemented in ASP.NET Core MVC and using content negotiation, would be:

```csharp
public IActionResult Index()
{
    return Ok(new { Message = "Hello World!"} );
}
```

This will default to returning the data in JSON format. XML and other formats will be used [if the app has been configured with the appropriate formatter](https://docs.microsoft.com/aspnet/core/web-api/advanced/formatting).

## References

- [ASP.NET Web API Content Negotiation](https://docs.microsoft.com/aspnet/web-api/overview/formats-and-model-binding/content-negotiation)
- [Format response data in ASP.NET Core Web API](https://docs.microsoft.com/aspnet/core/web-api/advanced/formatting)

>[!div class="step-by-step"]
>[Previous](strategies-migrating-in-production.md)
>[Next](deployment-scenarios.md)
