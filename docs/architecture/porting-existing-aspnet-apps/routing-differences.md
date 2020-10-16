---
title: Routing differences between ASP.NET MVC and ASP.NET Core
description: 
author: ardalis
ms.date: 11/13/2020
---

# Routing differences between ASP.NET MVC and ASP.NET Core

Routing is responsible for mapping incoming browser requests to particular controller actions (or Razor Pages handlers). This section provides an overview of how routing differs between ASP.NET MVC (and Web API) and ASP.NET Core (MVC, Razor Pages, and otherwise).

## Routing in ASP.NET MVC and Web API

ASP.NET MVC offers two approaches to routing. The first is the route table, which is a collection of routes that can be used to match incoming requests to controller actions. The second is attribute routing, which performs the same function but is achieved by decorating the actions themselves, rather than editing a global route table.

## Route table

The route table is configured when the app starts up. Typically a static method call is used to configure the global route collection, like so:

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

In the above code, the route table is managed by the `RouteCollection` type, which is used to add new routes with `MapRoute`. Routes are named and include a route string, which can include parameters for controllers, actions, areas, and other placeholders. If an app follows a standard convention, most of its actions can be handled by this single default route, with any exceptions to this convention configured using additional routes.

### Attribute routing in ASP.NET MVC

Routes that are defined with their actions may be easier to discover and reason about than those defined in an external location. Using attribute routing, an individual action method can have its route defined with a `[Route]` attribute:

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

Attribute routing can take advantage of route constraints, both built-in and custom, and supports named routes as well as areas using the [RouteArea] attribute. If your app uses areas, you'll need to be sure to configure support for them in your route registration code as well by adding one more line:

```csharp
routes.MapMvcAttributeRoutes();

AreaRegistration.RegisterAllAreas();
```

### Attribute routing in ASP.NET Web API 2

[Attribute routing in ASP.NET Web API 2](https://docs.microsoft.com/aspnet/web-api/overview/web-api-routing-and-actions/attribute-routing-in-web-api-2) is very similar to routing in ASP.NET MVC 5, with minor differences. Configuring Web API 2 is typically done in its own class which is called during app startup, and configuring attribute routing is done in this class:

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

As shown in the listing above, attribute routing may be combined with convention-based routing in Web API apps.

In addition to attribute routing, [ASP.NET Web API chooses which action to call](https://docs.microsoft.com/aspnet/web-api/overview/web-api-routing-and-actions/routing-and-action-selection) based on the HTTP method (for instance, GET or POST), the `{action}` placeholder in a route (if any), and parameters of the action. In many cases, the name of the action will help determine whether it is matched, since prefixing the action name with "Get" or "Post" is used to match the appropriate HTTP method to it. Alternatively, actions can be decorated with an appropriate HTTP method attribute, like `[HttpGet]`, allowing the use of action names that aren't prefixed with an HTTP method.

```csharp
public class ProductsController : ApiController
{
    public IEnumerable<Product> GetAll() {} // matched by name and (lack of) parameters
    [HttpGet]
    public IEnumerable<Product> FindProductsByName(string name) {} // matched by GET and string parameter
}
```

Given the above controller, a GET request made to `localhost:123/products/` would match the `GetAll` action, while a GET request made to `localhost:123/products?name=ardalis` would match the `FindProductsByName` action.

## Routing in ASP.NET Core 3.1

In ASP.NET Core, routing is handled by routing middleware, which matches the URLs of incoming requests to actions or other endpoints. Controller actions are either conventionally-routed or attribute-routed. Conventional routing is similar to the route table approach used in ASP.NET MVC and Web API. Whether you're using conventional, attribute, or both, you need to configure your app to use the routing middleware by adding this to your `Configure` method in `Startup`:

```csharp
app.UseRouting();
```

### Conventional routing

With conventional routing, you set up one or more conventions that will be used to match incoming URLs to *endpoints* in the ap. In ASP.NET Core, these endpoints may be controller actions, like in ASP.NET MVC or Web API, but they could also be Razor Pages or Health Checks or SignalR hubs. All of these routable features are configured in a similar fashion using endpoints:

```csharp
// in Startup.Configure()
app.UseEndpoints(endpoints =>
{
    endpoints.MapHealthChecks("/healthz").RequireAuthorization();
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
    endpoints.MapRazorPages();
});
```

The above code snippet is used (in addition to UseRouting) to configure a variety of endpoints, including Health Checks, Controllers, and Razor Pages. For Controllers, the above configuration specifies a default routing convention, which is the fairly standard `{controller}/{action}/{id?}` pattern that's been recommended since the first versions of ASP.NET MVC.

### Attribute routing

Attribute routing in ASP.NET Core is the preferred approach for configuring routing in controllers. If you are building APIs, the `[ApiController]` attribute should be applied to your controllers, and among other things this attribute requires the use of attribute routing for actions in such controller classes.

Attribute routing in ASP.NET Core works very similarly to in ASP.NET MVC and Web API. In addition to supporting the `[Route]` attribute, however, route information can also be specified as part of the HTTP method attribute:

```csharp
[HttpGet("api/products/{id}")]
public async ActionResult<Product> Details(int id)
{}
```

As with previous version, you can specify a default route with placeholders, and add this at the controller class level or even on a base class. You use the same `[Route]` attribute for all of these cases. For example, a base API controller class might look like this:

```csharp
[Route("api/{controller}/{action}/{id?:int}")]
public abstract class BaseApiController : ControllerBase, IApiController
{}
```

Using this attribute, classes inheriting from this type would route URLs to actions based on the controller name, action name, and an optional integer id parameter.

## References

- [ASP.NET MVC Routing Overview](https://docs.microsoft.com/aspnet/mvc/overview/older-versions-1/controllers-and-routing/asp-net-mvc-routing-overview-cs)
- [Attribute Routing in ASP.NET MVC 5](https://devblogs.microsoft.com/aspnet/attribute-routing-in-asp-net-mvc-5/)
- [Attribute routing in ASP.NET Web API 2](https://docs.microsoft.com/aspnet/web-api/overview/web-api-routing-and-actions/attribute-routing-in-web-api-2)
- [Routing and Action Selection in ASP.NET Web API](https://docs.microsoft.com/aspnet/web-api/overview/web-api-routing-and-actions/routing-and-action-selection)
- [Routing in ASP.NET Core](https://docs.microsoft.com/aspnet/core/fundamentals/routing)
- [Routing to controller actions in ASP.NET Core MVC](https://docs.microsoft.com/aspnet/core/mvc/controllers/routing)

>[!div class="step-by-step"]
>[Previous](configuration-differences.md)
>[Next](comparing-razor-pages-aspnet-mvc.md)
