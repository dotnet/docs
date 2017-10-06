---
title: Mapping Requests to Responses | Microsoft Docs 
description: .NET Microservices Architecture for Containerized .NET Applications | Mapping Requests to Responses
keywords: Docker, Microservices, ASP.NET, Container
author: CESARDELATORRE
ms.author: wiwagn
ms.date: 05/19/2017
---
# Mapping Requests to Responses

At its heart, ASP&period;NET Core apps map incoming requests to outgoing responses. At a low level, this is done with middleware, and simple ASP&period;NET Core apps and microservices may be comprised solely of custom middleware. When using ASP&period;NET Core MVC, you can work at a somewhat higher level, thinking in terms of *routes*, *controllers*, and *actions*. Each incoming request is compared with the application's routing table, and if a matching route is found, the associated action method (belonging to a controller) is called to handle the request. If no matching route is found, an error handler (in this case, returning a NotFound result) is called.

ASP&period;NET Core MVC apps can use conventional routes, attribute routes, or both. Conventional routes are defined in code, specifying routing *conventions* using syntax like in the example below:

```cs
app.UseMvc(routes =>;
{
    routes.MapRoute("default","{controller=Home}/{action=Index}/{id?}");
});
```

In this example, a route named "default" has been added to the routing table. It defines a route template with placeholders for *controller*, *action*, and *id*. The controller and action placeholders have default specified ("Home" and "Index", respectively), and the id placeholder is optional (by virtue of a "?" applied to it). The convention defined here states that the first part of a request should correspond to the name of the controller, the second part to the action, and then if necessary a third part will represent an id parameter. Conventional routes are typically defined in one place for the application, such as in the Configure method in the Startup class.

Attribute routes are applied to controllers and actions directly, rather than specified globally. This has the advantage of making them much more discoverable when you're looking at a particular method, but does mean that routing information is not kept in one place in the application. With attribute routes, you can easily specify multiple routes for a given action, as well as combine routes between controllers and actions. For example:
```cs
[Route("Home")]
public class HomeController : Controller
{
    [Route("")] // Combines to define the route template "Home"
    [Route("Index")] // Combines to define route template "Home/Index"
    [Route("/")] // Does not combine, defines the route template ""
    public IActionResult Index() {}
```

    Routes can be specified on [HttpGet] and similar attributes, avoiding the need to add separate [Route\] attributes. Attribute routes can also use tokens to reduce the need to repeat controller or action names, as shown below:

```cs
[Route("[controller\]")]
public class ProductsController : Controller
{
    [Route("")] // Matches 'Products'
    [Route("Index")] // Matches 'Products/Index'
    public IActionResult Index()
}
```

Once a given request has been matched to a route, but before the action method is called, ASP&period;NET Core MVC will perform [model binding](https://docs.microsoft.com/en-us/aspnet/core/mvc/models/model-binding) and [model validation](https://docs.microsoft.com/en-us/aspnet/core/mvc/models/validation) on the request. Model binding is responsible for converting incoming HTTP data into the .NET types specified as parameters of the action method to be called. For example, if the action method expects an int id parameter, model binding will attempt to provide this parameter from a value provided as part of the request. To do so, model binding looks for values in a posted form, values in the route itself, and query string values. Assuming an id value is found, it will be converted to an integer before being passed into the action method.

After binding the model but before calling the action method, model validation occurs. Model validation uses optional attributes on the model type, and can help ensure that the provided model object conforms to certain data requirements. Certain values may be specified as required, or limited to a certain length or numeric range, etc. If validation attributes are specified but the model does not conform to their requirements, the property ModelState.IsValid will be false, and the set of failing validation rules will be available to send to the client making the request.

If you are using model validation, you should be sure to always check that the model is valid before performing any state-altering commands, to ensure your app is not corrupted by invalid data. You can use a [filter](https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/filters) to avoid the need to add code for this in every action. ASP&period;NET Core MVC filters offer a way of intercepting groups of requests, so that common policies and cross-cutting concerns can be applied on a targeted basis. Filters can be applied to individual actions, whole controllers, or globally for an application.

For web APIs, ASP&period;NET Core MVC supports [*content negotiation*](https://docs.microsoft.com/en-us/aspnet/core/mvc/models/formatting), allowing requests to specify how responses should be formatted. Based on headers provided in the request, actions returning data will format the response in XML, JSON, or another supported format. This feature enables the same API to be used by multiple clients with different data format requirements.

> ### References – Mapping Requests to Responses
> - **Routing to Controller Actions**
> <https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/routing>
> - **Model Binding**
> https://docs.microsoft.com/en-us/aspnet/core/mvc/models/model-binding
> - **Model Validation**
> <https://docs.microsoft.com/en-us/aspnet/core/mvc/models/validation>
> - **Filters**
> https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/filters


>[!div class="step-by-step"]
[Previous] (summary.md)
[Next] (working-with-dependencies.md)
