---
title: Migrating from ASP.NET Web Forms to Blazor
description: How to approach migrating an existing ASP.NET Web Forms app to Blazor
author: twsouthwick
ms.author: tasou
ms.date: 09/17/2019
---

# Migrating from ASP.NET Web Forms to Blazor

Migrating a code base from ASP.NET Web Forms to Blazor is one that requires
planning and can take time. In this chapter, we will go over the process for each
of these. One thing that can really help ease the transition is to ensure the
application is adhering to an *n-tier* approach where the app model (in this
case Web Forms) is separate from the business logic. Without this separation it
can be very tedious to tease apart what needs to be moved to .NET Core and
Blazor vs what can be left behind. For this example, we will look at the eShop
available on [Github](https://github.com/dotnet-architecture/eShopOnBlazor).
This application is a simple catalog service that provides CRUD capabilities and
form entry and validation.

As a developer with a working application, there may be questions as to why
there's a need to migrate to Blazor at all. This is a valid question. Many
times, there is no need; ASP.NET Web Forms will continue to be supported for
many years. However, many of the features that Blazor provides will only be
supported on a migrated app. This includes:

- Performance improvements in the framework such as `Span<>`
- Ability to run as web assembly
- Cross-platform support for Linux and Mac
- App-local deployment or shared framework deployment without impacting other
  applications

If these (or other new features) are compelling enough, there may be value in
migrating the application. This migration can take different shapes; it can be
the entire application, or only certain endpoints that require the changes. The
choice to migrate is ultimately up to the developer and the business needs they
are attempting to solve.

## Choosing server side vs client side

As described in the [hosting models chapter](./hosting-models.md), there are two
ways to host a Blazor application. The first is server-side, while the other is
client-side. The server-side uses SignalR connections to manage the DOM updates
while running any actual code on the server. The client-side hosting runs as
WebAssembly within a browser and requires no server connections.  There are a
number of differences that may affect which is best for a specific application:

- Running as WebAssembly is still in development and may not support all
  features (such as threading) at the current time
- Chatty communication between the client and server may cause latency issues in
  server-side mode
- Access to databases and internal or protected services require a separate
  service with client side hosting

At the time of writing, the server side model is a much closer model to what you
may be familiar with as a Web Forms developer. Most of the discussion in this
chapter will focus on server side hosting as that is both more production ready
at this time and maps easier to Web Forms.

## Create a new project

This initial step to begin is to create a new project. This project type is
based on the SDK style projects of .NET Core and simplifies much of the boiler
plate that was used in previous project formats. For more detail, please see the
chapter on [Project Structure](./project-structure.md).

Once the project has been created, you'll want to pull in the libraries that
were used in the previous project. In previous Web Form projects, you may be
used to `packages.config` to bring in all the NuGet packages required; in new
SDK-style projects, this has been simplified to `<PackageReference>` nodes
within the project file. There are many benefits to this, including all
dependencies are brought in transitively so you only list the dependencies you
care about.

Many of the dependencies you may be used to using are available for .NET Core,
including Entity Framework 6, log4net, and others. Often, even if there is no
.NET Core or .NET Standard version available, the .NET Framework version can be
installed and used. Your mileage may vary on this as any API used that is not
available in .NET Core will cause a runtime error. Visual Studio will notify you
of such packages with a yellow icon on the reference node.

In the eShop on Blazor project, you can see these packages that are brought in.
Previously, the `packages.config` listed every package used in the project,
resulting in a file almost 50 lines long. A snippet of this is:

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

This includes everything and as a developer it was hard to identify which of
these are included because you require them, versus required by a different
dependency. This is simplified in the blazor version as follows:

```xml
  <ItemGroup>
    <PackageReference Include="Autofac" Version="4.9.3" />
    <PackageReference Include="EntityFramework" Version="6.3.0-preview9-19423-04" />
    <PackageReference Include="log4net" Version="2.0.8" />
  </ItemGroup>
```

One package that will simplify the life of Web Forms developers is to install
the Windows Compatibility Pack. Although .NET Core is cross platform, there are
features that are only available on Windows that developers will want to use.
Systems such as registry, WMI, and directory services that are only available in
Windows can be made available by installing this compatibility pack. This
package adds around 20,000 APIs and lights up many services that may be familiar
to you. The eShop project does not require this, but if your projects use Windows
specific features, this package will greatly help in migration.

## Enable startup process

The startup process for Blazor has changed from Web Forms and follows a similar
set up for other ASP.NET Core services. When hosted server side, the Blazor
components are run as part of a normal ASP.NET Core application. When hosted in
the browser with WebAssembly, the Blazor component uses a similar hosting model
but is run as a separate service from any of the backend processes. Either way,
the start up is similar.

The `Global.asax.cs` file is the normal start up page for Web Forms. In the
eShop project, this is where the IoC container is set up and populated, as well
as hooking into various lifetime cycles of the application or request. Some of
these events are handled with middleware (such as `Application_BeginRequest`)
while others require overriding specific services via dependency injection.

By way of example, the `Global.asax.cs` for the eShop, looks like the following:

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
        // Code that runs on application startup
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
    /// http://docs.autofac.org/en/latest/integration/webforms.html
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

This is transformed to the following for server-sided Blazor:

```csharp
   public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            Env = env;
        }

        public IConfiguration Configuration { get; }

        public IWebHostEnvironment Env { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();

            if (Configuration.GetValue<bool>("UseMockData"))
            {
                services.AddSingleton<ICatalogService, CatalogServiceMock>();
            }
            else
            {
                services.AddScoped<ICatalogService, CatalogService>();
                services.AddScoped<IDatabaseInitializer<CatalogDBContext>, CatalogDBInitializer>();
                services.AddSingleton<CatalogItemHiLoGenerator>();
                services.AddScoped(_ => new CatalogDBContext(Configuration.GetConnectionString("CatalogDBContext")));
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddLog4Net("log4Net.xml");

            if (Env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            // Middlware for Application_BeginRequest
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
        }

        private void ConfigDataBase(IApplicationBuilder app)
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
    }
}
```

One of the big changes you may notice coming from Web Forms is how pervasive the
concept of dependency injection is. This has been a guiding principle in the
design of ASP.NET Core and allows for customization of almost all aspects of the
ASP.NET Core framework. There is even a built-in service provider that can be
used out of the box that works for many scenarios. If more customization is
required, or a framework is already being used, then it can easily be supported
by many of the community extensions. 

In the original eShop application, you may see that there is some configuration
for session management. Since server-side Blazor uses SignalR for communication,
session is not supported as the connections may occur independent of an HTTP
context. In cases where an application makes use of session, they must be
rearchitected in order to run as a Blazor application.

For more details about application startup, refer to the following chapter: [App Startup](./app-startup.md).

## Migrate HTTP modules and handlers to middleware

HTTP modules and handlers are common patterns in Web Forms to control the
request pipeline. Classes that implement `IHttpModule` or `IHttpHandler` could
be registered and process incoming requests. Instead of configuring handlers and
modules in `web.config` and being processed based on application life cycle
events, middleware is registered in the startup and is executed in the order in
which they are registered.

In the section above, there was a life cycle event that is raised by Web Forms
as the `Application_BeginRequest` method. This is not available in ASP.NET Core,
so one way to achieve this is by implementing middleware as seen in the
Startup.cs example above. This middleware does the same logic and then just
passes control onto the next handler in the middleware pipeline.

For more details on how to migrate a modules and handlers, please see the
following
[documentation](https://docs.microsoft.com/aspnet/core/migration/http-modules).

## Migrate static files

In order to serve any static files (be they HTML, CSS, images, JavaScript or
other), they must be exposed by middleware. By using the `UseStaticFiles`
method, the web root will be exposed for static access. This web root, by
default is *wwwroot*, but can be customized. As can be seen in the startup for
eShop, this is very simple:

```csharp
public void Configure(IApplicationBuilder app)
{
    ...

    app.UseStaticFiles();

    ...
}
```

There are many customizations available for this if needed. The eShop project
doesn't need more than simple static file access, but if you require features
such as default files or a file browser, see
[this](https://docs.microsoft.com/aspnet/core/fundamentals/static-files) for
details on how to enable it.

## Migrate runtime bundling and minification setup

Bundling and minification are common steps to reduce the number and size of
requests that must be made to retrieve certain kinds of files. JavaScript and
CSS often undergo some form of bundling or minification before being sent to the
client. In ASP.NET Web Forms, this was performed at runtime by convention in a
`BundleConfig` file. In ASP.NET Core, this has been changed to be more
declarative by defining a file that has the files that need to be minified, as
well as any options associated with that.

For more details on this, please see the [documentation](https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification).

## Migrate .aspx pages

A page in a Web Forms application is a file that ends with `.aspx`. Often, these
can be mapped to a component in Blazor, which is written in a file with the
`.razor` extension. For the eShop project, there are five main pages that are
each converted to a razor page.

For example, the details view is contained in `Details.aspx`, `Details.aspx.cs`,
`Details.aspx.designer.cs` in the Web Forms project. When converting to Blazor,
the code behind and markup are combined into `Details.razor` and any razor
compilation (equivalent to what is in `*.designer.cs` files) is kept in the
`obj` directory and not directly viewable in the solution explorer. The web
forms looks like the following:

```
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

with code behind including the following:

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

When converted to Blazor, this becomes the following:

```html
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

Notice how the code and markup are in the same file and that any injected
services can be added with the `@inject` attribute. This page is defined to be
at the *Catalog/Details/{id}* route, where the *id* must be an integer. As
described in the [routing](./pages-routings.md) section, unlike Web Forms, a
razor component explicitly states its route and any parameters that is included.
Many of the controls that are defined in Web Forms may not have an exact
counterpart in Blazor, but often there is an equivalent HTML snippet that will
perform the same thing, such as `asp:Label` being plain text.

### Model validation in Blazor

If your code includes validation, then you can transfer much of what you have in
WebForms and have it work with little to no change. A benefit to running in
Blazor is that the same validation logic can be run without needing custom
JavaScript. By using DataAnnotations, models can get easy validation.

For example, the `Create.aspx` page has a data entry form with validation. An
example snippet would look like this:

```html
<div class="form-group">
    <label class="control-label col-md-2">Name</label>
    <div class="col-md-3">
        <asp:TextBox ID="Name" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator runat="server" ControlToValidate="Name" Display="Dynamic"
            CssClass="field-validation-valid text-danger" ErrorMessage="The Name field is required." />
    </div>
</div>
```

In Blazor, the equivalent in `Create.razor` looks like the following:

```html
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

The `EditForm` context can be wrapped around input and has support for
validation. Since DataAnnotations are a common way to add validation, that can
be added via the `DataAnnotationsValidator`. This mechanism is very powerful and
more details can be found in the [forms
validation](https://docs.microsoft.com/aspnet/core/blazor/forms-validation)
documentation.

## Migrate built-in Web Forms controls

[ TBD ]

## Migrate data access

[ TBD ]

## Migrate config

In a Web Forms application, the most common way to get configuration into a
project was via `web.config`. This was then surfaced through
`ConfigurationManager` and services were generally required to parse any object
their when they need it. With .NET Framework 4.7.2, composability was added to
configuration via `ConfigurationBuilders`. These builders allowed developers to
add various sources for configuration that was then composed at run time to
bring in all the necessary values. ASP.NET Core introduced a new configuration
system that allows you as a developer to define whatever source makes most sense
to your application and deployment. The `ConfigurationBuilder` infrastructure
that you may be using in your Web Forms application was modeled after the
concepts used in the ASP.NET Core configuration system.

The eShop project used `web.config` to store config values as seen below:

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
```

This system is useable, but it was common for secrets, such as a connection
string, to be stored within the `web.config` and then persisted where it
shouldn't be. With Blazor on ASP.NET Core, the configuration can be defined as:

```json
{
  "ConnectionStrings": {
    "CatalogDBContext": "Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=Microsoft.eShopOnContainers.Services.CatalogDb; Integrated Security=True; MultipleActiveResultSets=True;"
  },
  "UseMockData": true,
  "UseCustomizationData": false
}
```

By default, json is used, but xml or any other format could be used. Many are
available out of the box and more through the community. In the startup class,
you may see that the constructor takes an `IConfiguration`:

```csharp
public class Startup
{
    public Startup(IConfiguration configuration, IWebHostEnvironment env)
    {
        Configuration = configuration;
        Env = env;
    }

    ...
}
```

By default, environment variables, json and command line options are used to
construct the configuration object. These can then be access via
`Configuration[key]` or can be bound to objects using the options framework. For
more details on customizing this as well as in-depth exploration, see the following
[documentation](https://docs.microsoft.com/aspnet/core/fundamentals/configuration/).

## Architectural changes

Finally, there are some architectural differences that are important to consider
when migrating to Blazor. Many of these changes are applicable to anything based
on .NET Core or ASP.NET Core.

Since Blazor is built on .NET Core, there are considerations in ensuring support on .NET Core. Some of the major changes here include removal of the following features:

- Multiple AppDomains
- Remoting
- Code Access Security (CAS)
- Security Transparency

There are many techniques to identify what changes may be needed to support running on .NET Core which are documented [https://docs.microsoft.com/dotnet/core/porting](here).

ASP.NET Core is a very different framework than ASP.NET and has some changes that may not initially seem obvious. The main changes are:

- No synchronization context. This means there is no `HttpContext.Current`, `Thread.CurrentPrinciple` or other static accessors
- No shadow copying
- No request queue

Many operations in ASP.NET Core are asynchronous which allows easier off-loading of I/O bound tasks. It is important to never block by using `Task.Wait()` or `Task.GetResult()` which can quickly exhaust threadpool resources.

## Migration Conclusion

At this point, we have walked through many examples of what it takes to move a Web Forms project to Blazor. For a full example, please see the [eShopOnBlazor](https://github.com/dotnet-architecture/eShopOnBlazor) project.
