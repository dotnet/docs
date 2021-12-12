---
title: More migration scenarios
description: This section describes additional migration scenarios and techniques for upgrading .NET Framework apps to .NET Core / .NET 6.
author: ardalis
ms.date: 12/10/2021
---

# More migration scenarios

This section describes several different ASP.NET app scenarios, and offers specific techniques for solving each of them. You can use this section to identify scenarios applicable to your app, and evaluate which techniques will work for your app and its hosting environment.

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

When upgrading these apps to use ASP.NET Core, this duplicate effort and the confusion that sometimes accompanies it is eliminated. ASP.NET Core MVC is a unified framework with one set of rules for routing, filters, and more. Dependency injection is built into .NET Core itself. All of this can can be configured in `Startup.cs`, as is shown in the `eShopPorted` app in the sample.

## Migrate HttpResponseMessage to ASP.NET Core

Some ASP.NET Web API apps may have action methods that return `HttpResponseMessage`. This type does not exist in ASP.NET Core. Below is an example of its usage in a `Delete` action method, using the `ResponseMessage` helper method on the base `ApiController`:

```csharp
// DELETE api/<controller>/5
[HttpDelete]
public IHttpActionResult Delete(int id)
{
    var brandToDelete = _service.GetCatalogBrands().FirstOrDefault(x => x.Id == id);
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

ASP.NET Web API 2 supports [content negotiation](/aspnet/web-api/overview/formats-and-model-binding/content-negotiation) natively. The sample app includes a `BrandsController` that demonstrates this support by listing its results in either XML or JSON. This is based on the request's `Accept` header, and changes when it includes `application/xml` or `application/json`.

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

[ASP.NET Core MVC supports content negotiation natively](/aspnet/core/web-api/advanced/formatting), provided an appropriate [return type](/aspnet/core/web-api/action-return-types) is used. Content negotiation is implemented by [ObjectResult] which is returned by the status code-specific action results returned by the controller helper methods. The previous action method, implemented in ASP.NET Core MVC and using content negotiation, would be:

```csharp
public IActionResult Index()
{
    return Ok(new { Message = "Hello World!"} );
}
```

This will default to returning the data in JSON format. XML and other formats will be used [if the app has been configured with the appropriate formatter](/aspnet/core/web-api/advanced/formatting).

## Custom model binding

Most ASP.NET MVC and Web API apps make use of model binding. The default model binding syntax migrates fairly seamlessly between these apps and ASP.NET Core MVC. However, in some cases customers have written [custom model binders](/aspnet/web-api/overview/formats-and-model-binding/parameter-binding-in-aspnet-web-api#model-binders) to support specific model types or usage scenarios. Custom model binders in ASP.NET MVC and Web API projects use separate `IModelBinder` interfaces defined in `System.Web.Mvc` and `System.Web.Http` namespaces, respectively. In both cases, the custom binder exposes a `Bind` method that accepts a controller or action context and a model binding context as arguments.

Once the custom binder is created, it must be registered with the app. This step requires creating another type, a `ModelBinderProvider`, which acts as a factory and creates the model binder during a request. Binders can be added during `ApplicationStart` in MVC apps as shown:

```csharp
ModelBinderProviders.BinderProviders.Insert(0, new MyCustomBinderProvider()); // MVC
```

In Web API apps, custom binders can be referenced using attributes. The `ModelBinder` attribute can be added to action method parameters or to the parameter's type definition, as shown:

```csharp
// attribute on action method parameter
public HttpResponseMessage([ModelBinder(typeof(MyCustomBinder))] CustomDTO custom)
{
}

// attribute on type
[ModelBinder(typeof(MyCustomBinder))]
public class CustomDTO
{
}
```

To register a model binder globally in ASP.NET Web API, its provider must be added during app startup:

```csharp
public static class WebApiConfig
{
    public static void Register(HttpConfiguration config)
    {
        var provider = new CustomModelBinderProvider(
            typeof(CustomDTO), new CustomModelBinder());
        config.Services.Insert(typeof(ModelBinderProvider), 0, provider);

        // ...
    }
}
```

When migrating [custom model providers to ASP.NET Core](/aspnet/core/mvc/advanced/custom-model-binding#custom-model-binder-sample), the Web API pattern is closer to the ASP.NET Core approach than the ASP.NET MVC 5. The main differences between ASP.NET Core's `IModelBinder` interface and Web API's is that the ASP.NET Core method is async (`BindModelAsync`) and it only requires a single `BindingModelContext` parameter instead of two parameters like Web API's version required. In ASP.NET Core, you can use a `[ModelBinder]` attribute on individual action method parameters or their associated types. You can also create a `ModelBinderProvider` that will be used globally within the app where appropriate. To configure such a provider, you would add code to `Startup` in `ConfigureServices`:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddControllers(options =>
    {
        options.ModelBinderProviders.Insert(0, new CustomModelBinderProvider());
    });
}
```

## Media formatters

ASP.NET Web API supports multiple media formats and can be extended by using custom media formatters. The docs describe an [example CSV Media Formatter](/aspnet/web-api/overview/formats-and-model-binding/media-formatters#example-creating-a-csv-media-formatter) that can be used to send data in a comma-separated value format. If your Web API app uses custom media formatters, you'll need to convert them to [ASP.NET Core custom formatters](/aspnet/core/web-api/advanced/custom-formatters).

To create a custom formatter in Web API 2, you inherited from an appropriate base class and then added the formatter to the Web API pipeline using the `HttpConfiguration` object:

```csharp
public static void ConfigureApis(HttpConfiguration config)
{
    config.Formatters.Add(new ProductCsvFormatter());
}
```

In ASP.NET Core, the process is similar. ASP.NET Core supports both input formatters (used by model binding) and output formatters (used to format responses). Adding a custom formatter to output responses in a specific way involves inheriting from an appropriate base class and adding the formatter to MVC in `Startup`:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddControllers(options =>
    {
        options.InputFormatters.Insert(0, new CustomInputFormatter());
        options.OutputFormatters.Insert(0, new CustomOutputFormatter());
    });
}
```

You'll find a complete list of base classes in the <xref:Microsoft.AspNetCore.Mvc.Formatters?displayProperty=fullName> namespace.

The steps to migrate from a Web API formatter to an ASP.NET Core MVC formatter are:

1. Identify an appropriate base class for the new formatter.
1. Create a new instance of the base class and implement its required methods.
1. Copy over the functionality from the Web API formatter to the new implementation.
1. Configure MVC in the ASP.NET Core App's `ConfigureServices` method to use the new formatter.

## Custom filters

Filters are used in ASP.NET Core apps to execute code before and/or after certain stages in the request processing pipeline. ASP.NET MVC and Web API also use filters in much the same way, but the details vary. For instance, [ASP.NET MVC supports four kinds of filters](/aspnet/mvc/overview/older-versions-1/controllers-and-routing/understanding-action-filters-cs#the-different-types-of-filters). ASP.NET Web API 2 supports similar filters, and both MVC and Web API included attributes to [override filters](/dotnet/api/system.web.mvc.filters.ioverridefilter).

The most common filter used in ASP.NET MVC and Web API apps is the action filter, which is defined by an [IActionFilter interface](/dotnet/api/system.web.mvc.iactionfilter). This interface provides methods for before (`OnActionExecuting`) and after (`OnActionExecuted`) which can be used to execute code before and/or after an action executes, as noted for each method.

ASP.NET Core continues to support filters, and its unification of MVC and Web API means there is only one approach to their implementation. The [docs include detailed coverage of the five (5) kinds of filters built into ASP.NET Core MVC](/aspnet/core/mvc/controllers/filters#filter-types). All of the filter variants supported in ASP.NET MVC and ASP.NET Web API have associated versions in ASP.NET Core, so migration is generally just a matter of identifying the appropriate interface and/or base class and migrating the code over.

In addition to the synchronous interfaces, ASP.NET Core also provides async interfaces like `IAsyncActionFilter` which provide a single async method that can be used to incorporate code to run both before and after the action, as shown:

```csharp
public class SampleAsyncActionFilter : IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(
        ActionExecutingContext context,
        ActionExecutionDelegate next)
    {
        // Do something before the action executes.

        // next() calls the action method.
        var resultContext = await next();
        // resultContext.Result is set.
        // Do something after the action executes.
    }
}
```

When migrating async code (or code that should be async), teams should consider leveraging the built in async types that are provided for this purpose.

Most ASP.NET MVC and Web API apps do not use a large number of custom filters. Since the approach to filters in ASP.NET Core MVC is closely aligned with filters in ASP.NET MVC and Web API, the migration of custom filters is generally fairly straightforward. Be sure to read the detailed documentation on filters in ASP.NET Core's docs, and once you're sure you have a good understanding of them, port the logic from the old system to the new system's filters.

## Route constraints

ASP.NET Core uses route constraints to help ensure requests are routed properly to route a request. [ASP.NET Core supports a large number of different route constraints for this purpose](/aspnet/core/fundamentals/routing#route-constraint-reference). Route constraints can be applied in the route table, but most apps built with ASP.NET MVC 5 and/or [ASP.NET Web API 2](/aspnet/web-api/overview/web-api-routing-and-actions/attribute-routing-in-web-api-2#route-constraints) use inline route constraints applied to attribute routes. Inline route constraints use a format like this one:

```csharp
[Route("/customer/{id:int}")]
```

The `:int` after the `id` route parameter constrains the value to match the the `int` type. One benefit of using route constraints is that they allow for two otherwise-identical routes to exist where the parameters differ only by their type. This allows for the equivalent of [method overloading](../../standard/design-guidelines/member-overloading.md) of routes based solely on parameter type.

The set of route constraints, their syntax, and usage is very similar between all three approaches. Custom route constraints are fairly rare in customer applications. If your app uses a custom route constraint and needs to port to ASP.NET Core, the docs include examples showing [how to create custom route constraints in ASP.NET Core](/aspnet/core/fundamentals/routing#custom-route-constraints). Essentially all that's required is to implement `IRouteConstraint` and its `Match` method, and then add the custom constraint when configuring routing for the app:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddControllers();

    services.AddRouting(options =>
    {
        options.ConstraintMap.Add("customName", typeof(MyCustomConstraint));
    });
}
```

This is very similar to how custom constraints are used in ASP.NET Web API, which uses `IHttpRouteConstraint` and configures it using a resolver and a call to `HttpConfiguration.MapHttpAttributeRoutes`:

```csharp
public static class WebApiConfig
{
    public static void Register(HttpConfiguration config)
    {
        var constraintResolver = new DefaultInlineConstraintResolver();
        constraintResolver.ConstraintMap.Add("nonzero", typeof(CustomConstraint));

        config.MapHttpAttributeRoutes(constraintResolver);
    }
}
```

ASP.NET MVC 5 follows a very similar approach, using `IRouteConstraint` for its interface name and configuring the constraint as part of route configuration:

```csharp
public class RouteConfig
{
    public static void RegisterRoutes(RouteCollection routes)
    {
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

        var constraintsResolver = new DefaultInlineConstraintResolver();
        constraintsResolver.ConstraintMap.Add("values", typeof(ValuesConstraint));
        routes.MapMvcAttributeRoutes(constraintsResolver);
    }
}
```

Migrating route constraint usage as well as custom route constraints to ASP.NET Core is typically very straightforward.

## Custom route handlers

Another fairly advanced feature of ASP.NET MVC 5 is route handlers. Custom route handlers implement `IRouteHandler`, which includes a single method that returns an `IHttpHandler` for a give request. The `IHttpHandler`, in turn, exposes an `IsReusable` property and a single `ProcessRequest` method. In ASP.NET MVC 5, you can configure a particular route in the route table to use your custom handler:

```csharp
public static void RegisterRoutes(RouteCollection routes)
{
    routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

    routes.Add(new Route("custom", new CustomRouteHandler()));
}
```

To migrate custom route handlers from ASP.NET MVC 5 to ASP.NET Core, you can either use a filter (such as an action filter) or a custom [`IRouter`](/dotnet/api/microsoft.aspnetcore.routing.irouter). The filter approach is relatively straightforward, and can be added as a global filter when MVC is added to the app's services during startup:

```csharp
builder.Services.AddMvc(options =>
{
    options.Filters.Add(typeof(CustomActionFilter));
});
```

The `IRouter` option requires implementing the interface's `RouteAsync` and `GetVirtualPath` methods. The custom router is added to the request pipeline during app startup.

```csharp
// ...
app.UseMvc(routes =>
{
    routes.Routes.Add(new CustomRouter(routes.DefaultHandler));
});
```

In ASP.NET Web API, these handlers are referred to as [custom message handlers](/aspnet/web-api/overview/advanced/http-message-handlers#custom-message-handlers), rather than *route handlers*. Message handlers must derive from `DelegatingHandler` and override its `SendAsync` method. Message handlers can be chained together to form a pipeline in a fashion that is very similar to ASP.NET Core middleware and its request pipeline.

ASP.NET Core has no `DelegatingHandler` type or separate message handler pipeline. Instead, such handlers should be migrated using global filters, custom `IRouter` instances (see above), or custom middleware. ASP.NET Core MVC filters and `IRouter` types have the advantage of having built-in access to MVC constructs like controllers and actions, while middleware is a lower level approach that has no ties to MVC. This makes it more flexible but also requires more effort if you need to access MVC components.

## CORS support

CORS, or Cross-Origin Resource Sharing, is a W3C standard that allows servers to accept requests that don't originate from responses they've served. ASP.NET MVC 5 and ASP.NET Web API 2 support CORS in different ways. The simplest way to enable CORS support in ASP.NET MVC 5 is with an action filter like this one:

```csharp
public class AllowCrossSiteAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext filterContext)
    {
        filterContext.RequestContext.HttpContext.Response.AddHeader(
            "Access-Control-Allow-Origin", "example.com");
        base.OnActionExecuting(filterContext);
    }
}
```

ASP.NET Web API can also use such a filter, but it has [built-in support for enabling CORS](/aspnet/web-api/overview/security/enabling-cross-origin-requests-in-web-api#enable-cors) as well:

```csharp
public static class WebApiConfig
{
    public static void Register(HttpConfiguration config)
    {
        config.EnableCors();
        // ...
    }
}
```

Once this is added, you can configure allowed origins, headers, and methods using the `EnableCors` attribute, like so:

```csharp
[EnableCors(origins: "https://dot.net", headers: "*", methods: "*")]
public class TestController : ApiController
{
    // Controller methods not shown...
}
```

Before migrating your CORS implementation from ASP.NET MVC 5 or ASP.NET Web API 2, be sure to review [how CORS works](/aspnet/web-api/overview/security/enabling-cross-origin-requests-in-web-api#how-cors-works) and create some automated tests that demonstrate CORS is working as expected in your current system.

In ASP.NET Core, there are three built-in ways to enable CORS:

- [Configured via policy](/aspnet/core/security/cors?#cors-with-named-policy-and-middleware) in `ConfigureServices`
- Enabled with [endpoint routing](/aspnet/core/security/cors?#enable-cors-with-endpoint-routing)
- Enabled with the [`EnableCors` attribute](/aspnet/core/security/cors#enable-cors-with-attributes)

Each of these approaches is covered in detail in the docs, which are linked from the above options. Which one you choose will largely depend on how your existing app supports CORS. If the app uses attributes, you can probably migrate to use the `EnableCors` attribute most easily. If your app uses filters, you could continue using that approach (though it's not the typical approach used in ASP.NET Core), or migrate to use attributes or policies. Endpoint routing is a relatively new feature introduced with ASP.NET Core 3 and as such it doesn't have a close analog in ASP.NET MVC 5 or ASP.NET Web API 2 apps.

## Custom areas

Many ASP.NET MVC apps use Areas to organize the project. Areas typically reside in the root of the project in an *Areas* folder, and must be registered when the application starts, typically in `Application_Start()`:

```csharp
AreaRegistration.RegisterAllAreas();
```

An alternative to registering all areas in startup is to use the `RouteArea` attribute on individual controllers:

```csharp
[RouteArea("Admin")]
public class SomeController : Controller
```

When using Areas, additional arguments are passed into HTML helper methods to generate links to actions in different areas:

```cshtml
@Html.ActionLink("News", "Index", "News", new { area = "News" }, null)
```

ASP.NET Web API apps don't typically use areas explicitly, since their controllers can be placed in any folder in the project. Teams can use any folder structure they like to organize their API controllers.

[Areas](/aspnet/core/mvc/controllers/areas) are supported in ASP.NET Core MVC. The approach used is nearly identical to the use of areas in ASP.NET MVC 5. Developers migrating code using areas should keep in mind the following differences:

- `AreaRegistration.RegisterAllAreas` is not used in ASP.NET Core MVC
- Areas are applied using the `[Area("name")]` attribute (not `RouteArea` as in ASP.NET MVC 5)
- Areas can be added to the route table templates, if desired (or they can use attribute routing)

To add area support to the route table in ASP.NET Core MVC, you would add the following during app startup:

```csharp
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "MyArea",
        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});
```

Areas can also be used with attribute routing, using the `{area}` keyword in the route definition (it's one of several [reserved routing names](/aspnet/core/mvc/controllers/routing#reserved-routing-names) that can be used with route templates).

Tag helpers support areas with the `asp-area` attribute, which can be used to generate links in Razor views and pages:

```razor
<ul>
    <li>
        <a asp-area="Products" asp-controller="Home" asp-action="About">
            Products/Home/About
        </a>
    </li>
    <li>
        <a asp-area="Services" asp-controller="Home" asp-action="About">
            Services About
        </a>
    </li>
    <li>
        <a asp-area="" asp-controller="Home" asp-action="About">
            /Home/About
        </a>
    </li>
</ul>
```

If you're migrating to Razor Pages you will need to use an *Areas* folder in your *Pages* folder. For more information, see [Areas with Razor Pages](/aspnet/core/mvc/controllers/areas#areas-with-razor-pages).

In addition to the above guidance, teams should review [how routing in ASP.NET Core works with areas](/aspnet/core/mvc/controllers/routing#areas) as part of their migration planning process.

## Integration tests for ASP.NET MVC and ASP.NET Web API

Integration tests are automated tests that verify several different parts of an app work together correctly. Writing integration tests for ASP.NET MVC and ASP.NET Web API usually involved deploying the app to a real web server, such as a local instance of IIS or IIS Express, and then making requests to this hosted application using an HTTP client. Some of these tests may interact with the client-side user interface using browser automation tools like [Selenium](https://www.selenium.dev/), though often these are referred to as *UI tests* rather than integration tests.

If your migrated app shares the same behavior as its original version, whatever existing technology the team is using to perform integration tests (and UI tests) should continue to work just as it did before. These tests are usually indifferent to the underlying technology used to host the app they're testing, and interact with it only through HTTP requests. Where things may get more challenging is with how the tests interact with the app to get it into a known good state prior to each test. This may require some migration effort, since configuration and startup are significantly different in ASP.NET Core compared to ASP.NET MVC or ASP.NET Web API.

Teams should strongly consider migrating their integration tests to use [ASP.NET Core's built-in integration testing](/aspnet/core/test/integration-tests) support. In ASP.NET Core, apps can be tested by deploying them to a `TestHost`, which is configured using a `WebApplicationFactory`. There's a little bit of setup required to host the app for testing, but once this is in place, creating individual integration tests is very straightforward.

One of the best features of ASP.NET Core's integration testing support is that the app is hosted in memory. There's no need to configure a real webserver to host the app. There's no need to use a browser automation tool (if you're only testing ASP.NET Core and not client-side behavior). Many of the problems that can be encountered when trying to use a real web server for automated integration tests, such as firewall issues or process start/stop issues, are eliminated with this approach. Since the requests are all made in memory with no network requirement, the tests also tend to run much faster than tests that must set up a separate webserver and communicate with it over the network (even if it's running on the same machine).

Below you can see an example ASP.NET Core integration test (sometimes referred to as *functional tests* to distinguish them from lower-level integration tests) from the [eShopOnWeb reference application](https://github.com/dotnet-architecture/eShopOnWeb):

```csharp
public class GetByIdEndpoint : IClassFixture<ApiTestFixture>
{
    JsonSerializerOptions _jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

    public GetByIdEndpoint(ApiTestFixture factory)
    {
        Client = factory.CreateClient();
    }

    public HttpClient Client { get; }

    [Fact]
    public async Task ReturnsItemGivenValidId()
    {
        var response = await Client.GetAsync("api/catalog-items/5");
        response.EnsureSuccessStatusCode();
        var stringResponse = await response.Content.ReadAsStringAsync();
        var model = stringResponse.FromJson<GetByIdCatalogItemResponse>();

        Assert.Equal(5, model.CatalogItem.Id);
        Assert.Equal("Roslyn Red Sheet", model.CatalogItem.Name);
    }
}
```

If the app being migrated has no integration tests, the migration process can be a great opportunity to add some. These tests can verify that the migrated app behaves as the team expects. When such tests are in place early in a migration, they can ensure that later migration efforts do not break previously migrated portions of the app. Given how easy it is to set up and run integration tests in ASP.NET Core, the return on the investment spent setting up such tests is usually pretty high.

## WCF client configuration

If your app currently relies on WCF services as a client, this scenario is supported. However, you will need to [migrate your configuration](/aspnet/core/migration/configuration) from *web.config* to use the new *appsettings.json* file. Another option is to add any necessary configuration to your clients programmatically when you create them. For example:

```csharp
var wcfClient = new OrderServiceClient(
    new BasicHttpBinding(BasicHttpSecurityMode.None),
    new EndpointAddress("http://localhost:5050/OrderService.svc"));
```

If your organization has extensive services built using WCF that your app relies on, consider migrating them to use gRPC instead. For more details on gRPC, why you may wish to migrate, and a detailed migration guide, consult the [gRPC for WCF Developers](../grpc-for-wcf-developers/index.md) eBook.

## References

- [ASP.NET Web API Content Negotiation](/aspnet/web-api/overview/formats-and-model-binding/content-negotiation)
- [Format response data in ASP.NET Core Web API](/aspnet/core/web-api/advanced/formatting)
- [Custom Model Binders in ASP.NET Web API](/aspnet/web-api/overview/formats-and-model-binding/parameter-binding-in-aspnet-web-api#model-binders)
- [Custom Model Binders in ASP.NET Core](/aspnet/core/mvc/advanced/custom-model-binding#custom-model-binder-sample)
- [Media Formatters in ASP.NET Web API 2](/aspnet/web-api/overview/formats-and-model-binding/media-formatters)\
- [Custom formatters in ASP.NET Core Web API](/aspnet/core/web-api/advanced/custom-formatters)
- [Filters in ASP.NET Core](/aspnet/core/mvc/controllers/filters)
- [Route constraints in ASP.NET Web API 2](/aspnet/web-api/overview/web-api-routing-and-actions/attribute-routing-in-web-api-2#route-constraints)
- [Route constraints in ASP.NET MVC 5](https://devblogs.microsoft.com/aspnet/attribute-routing-in-asp-net-mvc-5/#route-constraints)
- [ASP.NET Core Route Constraint Reference](/aspnet/core/fundamentals/routing#route-constraint-reference)
- [Custom message handlers in ASP.NET Web API 2](/aspnet/web-api/overview/advanced/http-message-handlers#custom-message-handlers)
- [Simple CORS control in MVC 5 and Web API 2](https://stackoverflow.com/questions/6290053/setting-access-control-allow-origin-in-asp-net-mvc-simplest-possible-method)
- [Enabling Cross-Origin Requests in Web API](/aspnet/web-api/overview/security/enabling-cross-origin-requests-in-web-api#enable-cors)
- [Enable Cross-Origin Requests (CORS) in ASP.NET Core](/aspnet/core/security/cors)
- [Areas in ASP.NET Core](/aspnet/core/mvc/controllers/areas)
- [Integration tests in ASP.NET Core](/aspnet/core/test/integration-tests)

>[!div class="step-by-step"]
>[Previous](example-migration-eshop.md)
>[Next](deployment-scenarios.md)
