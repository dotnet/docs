---
title: Migrate from ASP.NET Web Forms to Blazor
description: Learn how to approach migrating an existing ASP.NET Web Forms app to Blazor.
author: twsouthwick
ms.author: tasou
no-loc: [Blazor, WebAssembly]
ms.date: 12/2/2021
---
# Migrate from ASP.NET Web Forms to Blazor

Migrating a code base from ASP.NET Web Forms to Blazor is a time-consuming task that requires planning. This chapter outlines the process. Something that can ease the transition is to ensure the app adheres to an *N-tier* architecture, wherein the app model (in this case, Web Forms) is separate from the business logic. This logical separation of layers makes it clear what needs to move to .NET Core and Blazor.

For this example, the eShop app available on [GitHub](https://github.com/dotnet-architecture/eShopOnBlazor) is used. eShop is a catalog service that provides CRUD capabilities via form entry and validation.

Why should a working app be migrated to Blazor? Many times, there's no need. ASP.NET Web Forms will continue to be supported for many years. However, many of the features that Blazor provides are only supported on a migrated app. Such features include:

- Performance improvements in the framework such as `Span<T>`
- Ability to run as WebAssembly
- Cross-platform support for Linux and macOS
- App-local deployment or shared framework deployment without impacting other apps

If these or other new features are compelling enough, there may be value in migrating the app. The migration can take different shapes; it can be the entire app, or only certain endpoints that require the changes. The decision to migrate is ultimately based on the business problems to be solved by the developer.

## Server-side versus client-side hosting

As described in the [hosting models](hosting-models.md) chapter, a Blazor app can be hosted in two different ways: server-side and client-side. The server-side model uses ASP.NET Core SignalR connections to manage the DOM updates while running any actual code on the server. The client-side model runs as WebAssembly within a browser and requires no server connections. There are a number of differences that may affect which is best for a specific app:

- Running as WebAssembly doesn't support all features (such as threading) at the current time
- Chatty communication between the client and server may cause latency issues in server-side mode
- Access to databases and internal or protected services require a separate service with client-side hosting

At the time of writing, the server-side model more closely resembles Web Forms. Most of this chapter focuses on the server-side hosting model, as it's production-ready.

## Create a new project

This initial migration step is to create a new project. This project type is based on the SDK style projects of .NET and simplifies much of the boilerplate that was used in previous project formats. For more detail, please see the chapter on [Project Structure](project-structure.md).

Once the project has been created, install the libraries that were used in the previous project. In older Web Forms projects, you may have used the *packages.config* file to list the required NuGet packages. In the new SDK-style project, *packages.config* has been replaced with `<PackageReference>` elements in the project file. A benefit to this approach is that all dependencies are installed transitively. You only list the top-level dependencies you care about.

Many of the dependencies you're using are available for .NET, including Entity Framework 6 and log4net. If there's no .NET or .NET Standard version available, the .NET Framework version can often be used. Your mileage may vary. Any API used that isn't available in .NET causes a runtime error. Visual Studio notifies you of such packages. A yellow icon appears on the project's **References** node in **Solution Explorer**.

In the Blazor-based eShop project, you can see the packages that are installed. Previously, the *packages.config* file listed every package used in the project, resulting in a file almost 50 lines long. A snippet of *packages.config* is:

```xml
<?xml version="1.0" encoding="utf-8"?>
<packages>
  ...
  <package id="Microsoft.ApplicationInsights.Agent.Intercept" version="2.4.0" targetFramework="net472" />
  <package id="Microsoft.ApplicationInsights.DependencyCollector" version="2.9.1" targetFramework="net472" />
  <package id="Microsoft.ApplicationInsights.PerfCounterCollector" version="2.9.1" targetFramework="net472" />
  <package id="Microsoft.ApplicationInsights.Web" version="2.9.1" targetFramework="net472" />
  <package id="Microsoft.ApplicationInsights.WindowsServer" version="2.9.1" targetFramework="net472" />
  <package id="Microsoft.ApplicationInsights.WindowsServer.TelemetryChannel" version="2.9.1" targetFramework="net472" />
  <package id="Microsoft.AspNet.FriendlyUrls" version="1.0.2" targetFramework="net472" />
  <package id="Microsoft.AspNet.FriendlyUrls.Core" version="1.0.2" targetFramework="net472" />
  <package id="Microsoft.AspNet.ScriptManager.MSAjax" version="5.0.0" targetFramework="net472" />
  <package id="Microsoft.AspNet.ScriptManager.WebForms" version="5.0.0" targetFramework="net472" />
  ...
  <package id="System.Memory" version="4.5.1" targetFramework="net472" />
  <package id="System.Numerics.Vectors" version="4.4.0" targetFramework="net472" />
  <package id="System.Runtime.CompilerServices.Unsafe" version="4.5.0" targetFramework="net472" />
  <package id="System.Threading.Channels" version="4.5.0" targetFramework="net472" />
  <package id="System.Threading.Tasks.Extensions" version="4.5.1" targetFramework="net472" />
  <package id="WebGrease" version="1.6.0" targetFramework="net472" />
</packages>
```

The `<packages>` element includes all necessary dependencies. It's difficult to identify which of these packages are included because you require them. Some `<package>` elements are listed simply to satisfy the needs of dependencies you require.

The Blazor project lists the dependencies you require within an `<ItemGroup>` element in the project file:

```xml
<ItemGroup>
    <PackageReference Include="Autofac" Version="4.9.3" />
    <PackageReference Include="EntityFramework" Version="6.4.4" />
    <PackageReference Include="log4net" Version="2.0.12" />
    <PackageReference Include="Microsoft.Extensions.Logging.Log4Net.AspNetCore" Version="2.2.12" />
</ItemGroup>
```

One NuGet package that simplifies the life of Web Forms developers is the [Windows Compatibility Pack](../../core/porting/windows-compat-pack.md). Although .NET is cross-platform, some features are only available on Windows. Windows-specific features are made available by installing the compatibility pack. Examples of such features include the Registry, WMI, and Directory Services. The package adds around 20,000 APIs and activates many services with which you may already be familiar. The eShop project doesn't require the compatibility pack; but if your projects use Windows-specific features, the package eases the migration efforts.

## Enable startup process

The startup process for Blazor has changed from Web Forms and follows a similar setup for other ASP.NET Core services. When hosted server-side, Blazor components are run as part of a normal ASP.NET Core app. When hosted in the browser with WebAssembly, Blazor components use a similar hosting model. The difference is the components are run as a separate service from any of the backend processes. Either way, the startup is similar.

The *Global.asax.cs* file is the default startup page for Web Forms projects. In the eShop project, this file configures the Inversion of Control (IoC) container and handles the various lifecycle events of the app or request. Some of these events are handled with middleware (such as `Application_BeginRequest`). Other events require the overriding of specific services via dependency injection (DI).

By way of example, the *Global.asax.cs* file for eShop, contains the following code:

```csharp
public class Global : HttpApplication, IContainerProviderAccessor
{
    private static readonly ILog _log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    static IContainerProvider _containerProvider;
    IContainer container;

    public IContainerProvider ContainerProvider
    {
        get { return _containerProvider; }
    }

    protected void Application_Start(object sender, EventArgs e)
    {
        // Code that runs on app startup
        RouteConfig.RegisterRoutes(RouteTable.Routes);
        BundleConfig.RegisterBundles(BundleTable.Bundles);
        ConfigureContainer();
        ConfigDataBase();
    }

    /// <summary>
    /// Track the machine name and the start time for the session inside the current session
    /// </summary>
    protected void Session_Start(Object sender, EventArgs e)
    {
        HttpContext.Current.Session["MachineName"] = Environment.MachineName;
        HttpContext.Current.Session["SessionStartTime"] = DateTime.Now;
    }

    /// <summary>
    /// https://autofaccn.readthedocs.io/en/latest/integration/webforms.html
    /// </summary>
    private void ConfigureContainer()
    {
        var builder = new ContainerBuilder();
        var mockData = bool.Parse(ConfigurationManager.AppSettings["UseMockData"]);
        builder.RegisterModule(new ApplicationModule(mockData));
        container = builder.Build();
        _containerProvider = new ContainerProvider(container);
    }

    private void ConfigDataBase()
    {
        var mockData = bool.Parse(ConfigurationManager.AppSettings["UseMockData"]);

        if (!mockData)
        {
            Database.SetInitializer<CatalogDBContext>(container.Resolve<CatalogDBInitializer>());
        }
    }

    protected void Application_BeginRequest(object sender, EventArgs e)
    {
        //set the property to our new object
        LogicalThreadContext.Properties["activityid"] = new ActivityIdHelper();

        LogicalThreadContext.Properties["requestinfo"] = new WebRequestInfo();

        _log.Debug("Application_BeginRequest");
    }
}
```

The preceding file becomes the *Program.cs* file in server-side Blazor:

```csharp
using eShopOnBlazor.Models;
using eShopOnBlazor.Models.Infrastructure;
using eShopOnBlazor.Services;
using log4net;
using System.Data.Entity;
using eShopOnBlazor;

var builder = WebApplication.CreateBuilder(args);

// add services

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

if (builder.Configuration.GetValue<bool>("UseMockData"))
{
    builder.Services.AddSingleton<ICatalogService, CatalogServiceMock>();
}
else
{
    builder.Services.AddScoped<ICatalogService, CatalogService>();
    builder.Services.AddScoped<IDatabaseInitializer<CatalogDBContext>, CatalogDBInitializer>();
    builder.Services.AddSingleton<CatalogItemHiLoGenerator>();
    builder.Services.AddScoped(_ => new CatalogDBContext(builder.Configuration.GetConnectionString("CatalogDBContext")));
}

var app = builder.Build();

new LoggerFactory().AddLog4Net("log4Net.xml");

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
}

// Middleware for Application_BeginRequest
app.Use((ctx, next) =>
{
    LogicalThreadContext.Properties["activityid"] = new ActivityIdHelper(ctx);
    LogicalThreadContext.Properties["requestinfo"] = new WebRequestInfo(ctx);
    return next();
});

app.UseStaticFiles();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapBlazorHub();
    endpoints.MapFallbackToPage("/_Host");
});

ConfigDataBase(app);

void ConfigDataBase(IApplicationBuilder app)
{
    using (var scope = app.ApplicationServices.CreateScope())
    {
        var initializer = scope.ServiceProvider.GetService<IDatabaseInitializer<CatalogDBContext>>();

        if (initializer != null)
        {
            Database.SetInitializer(initializer);
        }
    }
}

app.Run();

```

One significant change you may notice from Web Forms is the prominence of dependency injection (DI). DI has been a guiding principle in the ASP.NET Core design. It supports customization of almost all aspects of the ASP.NET Core framework. There's even a built-in service provider that can be used for many scenarios. If more customization is required, it can be supported by many community projects. For example, you can carry forward your third-party DI library investment.

In the original eShop app, there's some configuration for session management. Since server-side Blazor uses ASP.NET Core SignalR for communication, the session state isn't supported as the connections may occur independent of an HTTP context. An app that uses the session state requires rearchitecting before running as a Blazor app.

For more information about app startup, see [App startup](app-startup.md).

## Migrate HTTP modules and handlers to middleware

HTTP modules and handlers are common patterns in Web Forms to control the HTTP request pipeline. Classes that implement `IHttpModule` or `IHttpHandler` could be registered and process incoming requests. Web Forms configure modules and handlers in the *web.config* file. Web Forms is also heavily based on app lifecycle event handling. ASP.NET Core uses middleware instead. Middleware is registered in the `Configure` method of the `Startup` class. Middleware execution order is determined by the registration order.

In the [Enable startup process](#enable-startup-process) section, a lifecycle event was raised by Web Forms as the `Application_BeginRequest` method. This event isn't available in ASP.NET Core. One way to achieve this behavior is to implement middleware as seen in the *Startup.cs* file example. This middleware does the same logic and then transfers control to the next handler in the middleware pipeline.

For more information on migrating modules and handlers, see [Migrate HTTP handlers and modules to ASP.NET Core middleware](/aspnet/core/migration/http-modules).

## Migrate static files

To serve static files (for example, HTML, CSS, images, and JavaScript), the files must be exposed by middleware. Calling the `UseStaticFiles` method enables the serving of static files from the web root path. The default web root directory is *wwwroot*, but it can be customized. As included in the *Program.cs* file:

```csharp
...

app.UseStaticFiles();

...

```

The eShop project enables basic static file access. There are many customizations available for static file access. For information on enabling default files or a file browser, see [Static files in ASP.NET Core](/aspnet/core/fundamentals/static-files).

## Migrate runtime bundling and minification setup

Bundling and minification are performance optimization techniques for reducing the number and size of server requests to retrieve certain file types. JavaScript and CSS often undergo some form of bundling or minification before being sent to the client. In ASP.NET Web Forms, these optimizations are handled at run time. The optimization conventions are defined an *App_Start/BundleConfig.cs* file. In ASP.NET Core, a more declarative approach is adopted. A file lists the files to be minified, along with specific minification settings.

For more information on bundling and minification, see [Bundle and minify static assets in ASP.NET Core](/aspnet/core/client-side/bundling-and-minification).

## Migrate ASPX pages

A page in a Web Forms app is a file with the *.aspx* extension. A Web Forms page can often be mapped to a component in Blazor. A Blazor component is authored in a file with the *.razor* extension. For the eShop project, five pages are converted to a Razor page.

For example, the details view comprises three files in the Web Forms project: *Details.aspx*, *Details.aspx.cs*, and *Details.aspx.designer.cs*. When converting to Blazor, the code-behind and markup are combined into *Details.razor*. Razor compilation (equivalent to what's in *.designer.cs* files) is stored in the *obj* directory and isn't, by default, viewable in **Solution Explorer**. The Web Forms page consists of the following markup:

```aspx-csharp
<%@ Page Title="Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="eShopLegacyWebForms.Catalog.Details" %>

<asp:Content ID="Details" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="esh-body-title">Details</h2>

    <div class="container">
        <div class="row">
            <asp:Image runat="server" CssClass="col-md-6 esh-picture" ImageUrl='<%#"/Pics/" + product.PictureFileName%>' />
            <dl class="col-md-6 dl-horizontal">
                <dt>Name
                </dt>

                <dd>
                    <asp:Label runat="server" Text='<%#product.Name%>' />
                </dd>

                <dt>Description
                </dt>

                <dd>
                    <asp:Label runat="server" Text='<%#product.Description%>' />
                </dd>

                <dt>Brand
                </dt>

                <dd>
                    <asp:Label runat="server" Text='<%#product.CatalogBrand.Brand%>' />
                </dd>

                <dt>Type
                </dt>

                <dd>
                    <asp:Label runat="server" Text='<%#product.CatalogType.Type%>' />
                </dd>
                <dt>Price
                </dt>

                <dd>
                    <asp:Label CssClass="esh-price" runat="server" Text='<%#product.Price%>' />
                </dd>

                <dt>Picture name
                </dt>

                <dd>
                    <asp:Label runat="server" Text='<%#product.PictureFileName%>' />
                </dd>

                <dt>Stock
                </dt>

                <dd>
                    <asp:Label runat="server" Text='<%#product.AvailableStock%>' />
                </dd>

                <dt>Restock
                </dt>

                <dd>
                    <asp:Label runat="server" Text='<%#product.RestockThreshold%>' />
                </dd>

                <dt>Max stock
                </dt>

                <dd>
                    <asp:Label runat="server" Text='<%#product.MaxStockThreshold%>' />
                </dd>

            </dl>
        </div>

        <div class="form-actions no-color esh-link-list">
            <a runat="server" href='<%# GetRouteUrl("EditProductRoute", new {id =product.Id}) %>' class="esh-link-item">Edit
            </a>
            |
            <a runat="server" href="~" class="esh-link-item">Back to list
            </a>
        </div>

    </div>
</asp:Content>
```

The preceding markup's code-behind includes the following code:

```csharp
using eShopLegacyWebForms.Models;
using eShopLegacyWebForms.Services;
using log4net;
using System;
using System.Web.UI;

namespace eShopLegacyWebForms.Catalog
{
    public partial class Details : System.Web.UI.Page
    {
        private static readonly ILog _log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        protected CatalogItem product;

        public ICatalogService CatalogService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            var productId = Convert.ToInt32(Page.RouteData.Values["id"]);
            _log.Info($"Now loading... /Catalog/Details.aspx?id={productId}");
            product = CatalogService.FindCatalogItem(productId);

            this.DataBind();
        }
    }
}
```

When converted to Blazor, the Web Forms page translates to the following code:

```razor
@page "/Catalog/Details/{id:int}"
@inject ICatalogService CatalogService
@inject ILogger<Details> Logger

<h2 class="esh-body-title">Details</h2>

<div class="container">
    <div class="row">
        <img class="col-md-6 esh-picture" src="@($"/Pics/{_item.PictureFileName}")">

        <dl class="col-md-6 dl-horizontal">
            <dt>
                Name
            </dt>

            <dd>
                @_item.Name
            </dd>

            <dt>
                Description
            </dt>

            <dd>
                @_item.Description
            </dd>

            <dt>
                Brand
            </dt>

            <dd>
                @_item.CatalogBrand.Brand
            </dd>

            <dt>
                Type
            </dt>

            <dd>
                @_item.CatalogType.Type
            </dd>
            <dt>
                Price
            </dt>

            <dd>
                @_item.Price
            </dd>

            <dt>
                Picture name
            </dt>

            <dd>
                @_item.PictureFileName
            </dd>

            <dt>
                Stock
            </dt>

            <dd>
                @_item.AvailableStock
            </dd>

            <dt>
                Restock
            </dt>

            <dd>
                @_item.RestockThreshold
            </dd>

            <dt>
                Max stock
            </dt>

            <dd>
                @_item.MaxStockThreshold
            </dd>

        </dl>
    </div>

    <div class="form-actions no-color esh-link-list">
        <a href="@($"/Catalog/Edit/{_item.Id}")" class="esh-link-item">
            Edit
        </a>
        |
        <a href="/" class="esh-link-item">
            Back to list
        </a>
    </div>

</div>

@code {
    private CatalogItem _item;

    [Parameter]
    public int Id { get; set; }

    protected override void OnInitialized()
    {
        Logger.LogInformation("Now loading... /Catalog/Details/{Id}", Id);

        _item = CatalogService.FindCatalogItem(Id);
    }
}
```

Notice that the code and markup are in the same file. Any required services are made accessible with the `@inject` attribute. Per the `@page` directive, this page can be accessed at the `Catalog/Details/{id}` route. The value of the route's `{id}` placeholder has been constrained to an integer. As described in the [routing](pages-routing-layouts.md) section, unlike Web Forms, a Razor component explicitly states its route and any parameters that are included. Many Web Forms controls may not have exact counterparts in Blazor. There's often an equivalent HTML snippet that will serve the same purpose. For example, the `<asp:Label />` control can be replaced with an HTML `<label>` element.

### Model validation in Blazor

If your Web Forms code includes validation, you can transfer much of what you have with little-to-no changes. A benefit to running in Blazor is that the same validation logic can be run without needing custom JavaScript. Data annotations enable easy model validation.

For example, the *Create.aspx* page has a data entry form with validation. An example snippet would look like this:

```aspx
<div class="form-group">
    <label class="control-label col-md-2">Name</label>
    <div class="col-md-3">
        <asp:TextBox ID="Name" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator runat="server" ControlToValidate="Name" Display="Dynamic"
            CssClass="field-validation-valid text-danger" ErrorMessage="The Name field is required." />
    </div>
</div>
```

In Blazor, the equivalent markup is provided in a *Create.razor* file:

```razor
<EditForm Model="_item" OnValidSubmit="@...">
    <DataAnnotationsValidator />

    <div class="form-group">
        <label class="control-label col-md-2">Name</label>
        <div class="col-md-3">
            <InputText class="form-control" @bind-Value="_item.Name" />
            <ValidationMessage For="(() => _item.Name)" />
        </div>
    </div>

    ...
</EditForm>
```

The `EditForm` context includes validation support and can be wrapped around an input. Data annotations are a common way to add validation. Such validation support can be added via the `DataAnnotationsValidator` component. For more information on this mechanism, see [ASP.NET Core Blazor forms and validation](/aspnet/core/blazor/forms-validation).

## Migrate configuration

In a Web Forms project, configuration data is most commonly stored in the *web.config* file. The configuration data is accessed with `ConfigurationManager`. Services were often required to parse objects. With .NET Framework 4.7.2, composability was added to the configuration via `ConfigurationBuilders`. These builders allowed developers to add various sources for the configuration that was then composed at run time to retrieve the necessary values.

ASP.NET Core introduced a flexible configuration system that allows you to define the configuration source or sources used by your app and deployment. The `ConfigurationBuilder` infrastructure that you may be using in your Web Forms app was modeled after the concepts used in the ASP.NET Core configuration system.

The following snippet demonstrates how the Web Forms eShop project uses *web.config* to store configuration values:

```xml
<configuration>
  <configSections>
    <section name="entityFramework" type="System.Data.Entity.Internal.ConfigFile.EntityFrameworkSection, EntityFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" requirePermission="false" />
  </configSections>
  <connectionStrings>
    <add name="CatalogDBContext" connectionString="Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=Microsoft.eShopOnContainers.Services.CatalogDb; Integrated Security=True; MultipleActiveResultSets=True;" providerName="System.Data.SqlClient" />
  </connectionStrings>
  <appSettings>
    <add key="UseMockData" value="true" />
    <add key="UseCustomizationData" value="false" />
  </appSettings>
</configuration>
```

It's common for secrets, such as database connection strings, to be stored within the *web.config*. The secrets are inevitably persisted in unsecure locations, such as source control. With Blazor on ASP.NET Core, the preceding XML-based configuration is replaced with the following JSON:

```json
{
  "ConnectionStrings": {
    "CatalogDBContext": "Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=Microsoft.eShopOnContainers.Services.CatalogDb; Integrated Security=True; MultipleActiveResultSets=True;"
  },
  "UseMockData": true,
  "UseCustomizationData": false
}
```

JSON is the default configuration format; however, ASP.NET Core supports many other formats, including XML. There are also several community-supported formats.

You can access configuration values from the builder in *Program.cs*:

```csharp
if (builder.Configuration.GetValue<bool>("UseMockData"))
{
    builder.Services.AddSingleton<ICatalogService, CatalogServiceMock>();
}
else
{
    builder.Services.AddScoped<ICatalogService, CatalogService>();
    builder.Services.AddScoped<IDatabaseInitializer<CatalogDBContext>, CatalogDBInitializer>();
    builder.Services.AddSingleton<CatalogItemHiLoGenerator>();
    builder.Services.AddScoped(_ => new CatalogDBContext(builder.Configuration.GetConnectionString("CatalogDBContext")));
}
```

By default, environment variables, JSON files (*appsettings.json* and *appsettings.{Environment}.json*), and command-line options are registered as valid configuration sources in the configuration object. The configuration sources can be accessed via `Configuration[key]`. A more advanced technique is to bind the configuration data to objects using the options pattern. For more information on configuration and the options pattern, see [Configuration in ASP.NET Core](/aspnet/core/fundamentals/configuration/) and [Options pattern in ASP.NET Core](/aspnet/core/fundamentals/configuration/options), respectively.

## Migrate data access

Data access is an important aspect of any app. The eShop project stores catalog information in a database and retrieves the data with Entity Framework (EF) 6. Since EF 6 is supported in .NET 5, the project can continue to use it.

The following EF-related changes were necessary to eShop:

- In .NET Framework, the `DbContext` object accepts a string of the form *name=ConnectionString* and uses the connection string from
  `ConfigurationManager.AppSettings[ConnectionString]` to connect. In .NET Core, this isn't supported. The connection string must be supplied.
- The database was accessed in a synchronous way. Though this works, scalability may suffer. This logic should be moved to an asynchronous pattern.

Although there isn't the same native support for dataset binding, Blazor provides flexibility and power with its C# support in a Razor page. For example, you can perform calculations and display the result. For more information on data patterns in Blazor, see the [Data access](data.md) chapter.

## Architectural changes

Finally, there are some important architectural differences to consider when migrating to Blazor. Many of these changes are applicable to anything based on .NET Core or ASP.NET Core.

Because Blazor is built on .NET Core, there are considerations in ensuring support on .NET Core. Some of the major changes include the removal of the following features:

- Multiple AppDomains
- Remoting
- Code Access Security (CAS)
- Security Transparency

For more information on techniques to identify necessary changes to support running on .NET Core, see [Port your code from .NET Framework to .NET Core](../../core/porting/index.md).

ASP.NET Core is a reimagined version of ASP.NET and has some changes that may not initially seem obvious. The main changes are:

- No synchronization context, which means there's no `HttpContext.Current`, `Thread.CurrentPrincipal`, or other static accessors
- No shadow copying
- No request queue

Many operations in ASP.NET Core are asynchronous, which allows easier off-loading of I/O-bound tasks. It's important to never block by using `Task.Wait()` or `Task.GetResult()`, which can quickly exhaust thread pool resources.

## Migration conclusion

At this point, you've seen many examples of what it takes to move a Web Forms project to Blazor. For a full example, see the [eShopOnBlazor](https://github.com/dotnet-architecture/eShopOnBlazor) project.

>[!div class="step-by-step"]
>[Previous](security-authentication-authorization.md)
