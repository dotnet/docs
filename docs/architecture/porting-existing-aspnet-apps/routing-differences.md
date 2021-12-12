---
title: Routing differences between ASP.NET MVC and ASP.NET Core
description: How is routing defined and how does it work at run time in ASP.NET MVC? How does routing differ in ASP.NET Core apps?
author: ardalis
ms.date: 12/10/2021
---

# Routing differences between ASP.NET MVC and ASP.NET Core

Routing is responsible for mapping incoming browser requests to particular controller actions (or Razor Pages handlers). This section covers how routing differs between ASP.NET MVC (and Web API) and ASP.NET Core (MVC, Razor Pages, and otherwise).

## Routing in ASP.NET MVC and Web API

ASP.NET MVC offers two approaches to routing:

1. The route table, which is a collection of routes that can be used to match incoming requests to controller actions.
1. Attribute routing, which performs the same function but is achieved by decorating the actions themselves, rather than editing a global route table.

## Route table

The route table is configured when the app starts up. Typically, a static method call is used to configure the global route collection, like so:

```csharp
public class MvcApplication : System.Web.HttpApplication
{
    public static void RegisterRoutes(RouteCollection routes)
    {
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
        routes.MapRoute(
            name: "Default",
            url: "{controller}/{action}/{id}",
            defaults: new { controller = "Home", action = "Index", id = "" },
            constraints: new { id = "\\d+" }
        );
    }

    protected void Application_Start()
    {
        RegisterRoutes(RouteTable.Routes);
    }
}
```

In the preceding code, the route table is managed by the `RouteCollection` type, which is used to add new routes with `MapRoute`. Routes are named and include a route string, which can include parameters for controllers, actions, areas, and other placeholders. If an app follows a standard convention, most of its actions can be handled by this single default route, with any exceptions to this convention configured using additional routes.

### Attribute routing in ASP.NET MVC

Routes that are defined with their actions may be easier to discover and reason about than routes defined in an external location. Using attribute routing, an individual action method can have its route defined with a `[Route]` attribute:

```csharp
public class ProductsController
{
    [Route("products")]
    public ActionResult Index()
    {
        return View();
    }

    [Route("products/{id}")]
    public ActionResult Details(int id)
    {
        return View();
    }
}
```

[Attribute routing in ASP.NET MVC 5](https://devblogs.microsoft.com/aspnet/attribute-routing-in-asp-net-mvc-5/) also supports defaults and prefixes, which can be added at the controller level (and which are applied to all actions within that controller). Refer to the documentation for details.

Setting up attribute routing requires adding one line to the default route table configuration:

```csharp
routes.MapMvcAttributeRoutes();
```

Attribute routing can take advantage of route constraints, both built-in and custom, and supports named routes and areas using the `[RouteArea]` attribute. If your app uses areas, you'll need to configure support for them in your route registration code by adding one more line:

```csharp
routes.MapMvcAttributeRoutes();

AreaRegistration.RegisterAllAreas();
```

### Attribute routing in ASP.NET Web API 2

[Attribute routing in ASP.NET Web API 2](/aspnet/web-api/overview/web-api-routing-and-actions/attribute-routing-in-web-api-2) is similar to routing in ASP.NET MVC 5, with minor differences. Configuring Web API 2 is typically done in its own class, which is called during app startup. Attribute routing configuration is handled in this class:

```csharp
public static class WebApiConfig
{
    public static void Register(HttpConfiguration config)
    {
        // Attribute routing.
        config.MapHttpAttributeRoutes();

        // Convention-based routing.
        config.Routes.MapHttpRoute(
            name: "DefaultApi",
            routeTemplate: "api/{controller}/{id}",
            defaults: new { id = RouteParameter.Optional }
        );
    }
}
```

As shown in the preceding code, attribute routing may be combined with convention-based routing in Web API apps.

In addition to attribute routing, [ASP.NET Web API chooses which action to call](/aspnet/web-api/overview/web-api-routing-and-actions/routing-and-action-selection) based on the HTTP method (for example, GET or POST), the `{action}` placeholder in a route (if any), and parameters of the action. In many cases, the name of the action will help determine whether it's matched, since prefixing the action name with "Get" or "Post" is used to match the appropriate HTTP method to it. Alternatively, actions can be decorated with an appropriate HTTP method attribute, like `[HttpGet]`, allowing the use of action names that aren't prefixed with an HTTP method.

```csharp
public class ProductsController : ApiController
{
    // matched by name and (lack of) parameters
    public IEnumerable<Product> GetAll() { }

    // matched by GET and string parameter
    [HttpGet]
    public IEnumerable<Product> FindProductsByName(string name) { }
}
```

Given the above controller, an HTTP GET request to `localhost:123/products/` matches the `GetAll` action. An HTTP GET request to `localhost:123/products?name=ardalis` matches the `FindProductsByName` action.

## Routing in ASP.NET Core 3.1

In ASP.NET Core, routing is handled by routing middleware, which matches the URLs of incoming requests to actions or other endpoints. Controller actions are either conventionally routed or attribute-routed. Conventional routing is similar to the route table approach used in ASP.NET MVC and Web API. Whether you're using conventional, attribute, or both, you need to configure your app to use the routing middleware. To use the middleware, add the following code to your `Startup.Configure` method:

```csharp
app.UseRouting();
```

### Conventional routing

With conventional routing, you set up one or more conventions that will be used to match incoming URLs to *endpoints* in the app. In ASP.NET Core, these endpoints may be controller actions, like in ASP.NET MVC or Web API. The endpoints could also be Razor Pages, Health Checks, or SignalR hubs. All of these routable features are configured in a similar fashion using endpoints:

```csharp
app.UseEndpoints(endpoints =>
{
    endpoints.MapHealthChecks("/healthz").RequireAuthorization();
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
    endpoints.MapRazorPages();
});
```

The preceding code is used (in addition to `UseRouting`) to configure various endpoints, including Health Checks, controllers, and Razor Pages. For controllers, the above configuration specifies a default routing convention, which is the fairly standard `{controller}/{action}/{id?}` pattern that's been recommended since the first versions of ASP.NET MVC.

### Attribute routing

Attribute routing in ASP.NET Core is the preferred approach for configuring routing in controllers. If you're building APIs, the `[ApiController]` attribute should be applied to your controllers. Among other things, this attribute requires the use of attribute routing for actions in such controller classes.

Attribute routing in ASP.NET Core behaves similarly in ASP.NET MVC and Web API. In addition to supporting the `[Route]` attribute, however, route information can also be specified as part of the HTTP method attribute:

```csharp
[HttpGet("api/products/{id}")]
public async ActionResult<Product> Details(int id)
{
    // ...
}
```

As with previous versions, you can specify a default route with placeholders, and add this at the controller class level or even on a base class. You use the same `[Route]` attribute for all of these cases. For example, a base API controller class might look like this:

```csharp
[Route("api/{controller}/{action}/{id?:int}")]
public abstract class BaseApiController : ControllerBase, IApiController
{
    // ...
}
```

Using this attribute, classes inheriting from this type would route URLs to actions based on the controller name, action name, and an optional integer `id` parameter.

## References

- [ASP.NET MVC Routing Overview](/aspnet/mvc/overview/older-versions-1/controllers-and-routing/asp-net-mvc-routing-overview-cs)
- [Attribute Routing in ASP.NET MVC 5](https://devblogs.microsoft.com/aspnet/attribute-routing-in-asp-net-mvc-5/)
- [Attribute routing in ASP.NET Web API 2](/aspnet/web-api/overview/web-api-routing-and-actions/attribute-routing-in-web-api-2)
- [Routing and Action Selection in ASP.NET Web API](/aspnet/web-api/overview/web-api-routing-and-actions/routing-and-action-selection)
- [Routing in ASP.NET Core](/aspnet/core/fundamentals/routing)
- [Routing to controller actions in ASP.NET Core MVC](/aspnet/core/mvc/controllers/routing)

>[!div class="step-by-step"]
>[Previous](configuration-differences.md)
>[Next](logging-differences.md)
