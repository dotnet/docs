---
title: App startup
description: Learn how to define the startup logic for your app.
author: csharpfritz
ms.author: jefritz
ms.date: 02/25/2020
---
# App startup

[!INCLUDE [book-preview](../../../includes/book-preview.md)]

Applications that are written for ASP.NET typically have a `global.asax.cs` file that defines the `Application_Start` event that controls which services are configured and made available for both HTML rendering and .NET processing. This chapter looks at how things are slightly different with ASP.NET Core and Blazor Server.

## Application_Start and Web Forms

The default web forms `Application_Start` method has grown in purpose over years to handle many configuration tasks.  A fresh web forms project with the default template in Visual Studio 2019 now contains the following configuration logic:

- `RouteConfig` - Application URL routing
- `BundleConfig` - CSS and JavaScript bundling and minification

Each of these individual files reside in the `App_Start` folder and run only once at the start of our application.  `RouteConfig` in the default project template adds the `FriendlyUrlSettings` for web forms to allow application URLs to omit the `.ASPX` file extension.  The default template also contains a directive that provides permanent HTTP redirect status codes (HTTP 301) for the `.ASPX` pages to the friendly URL with the file name that omits the extension.

With ASP.NET Core and Blazor, these methods are either simplified and consolidated into the `Startup` class or they are eliminated in favor of common web technologies.

## Blazor Server Startup Structure

Blazor Server applications reside on top of an ASP.NET Core 3.0 or later application.  ASP.NET Core web applications are configured through a pair of methods in the `Startup.cs` class on the root folder of the application.  The Startup class's default content is listed below

```csharp
public class Startup
{
  public Startup(IConfiguration configuration)
  {
    Configuration = configuration;
  }

  public IConfiguration Configuration { get; }

  // This method gets called by the runtime. Use this method to add services to the container.
  // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
  public void ConfigureServices(IServiceCollection services)
  {
    services.AddRazorPages();
    services.AddServerSideBlazor();
    services.AddSingleton<WeatherForecastService>();
  }

  // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
  public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
  {
    if (env.IsDevelopment())
    {
      app.UseDeveloperExceptionPage();
    }
    else
    {
      app.UseExceptionHandler("/Error");
      // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
      app.UseHsts();
    }

    app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.UseRouting();

    app.UseEndpoints(endpoints =>
    {
      endpoints.MapBlazorHub();
      endpoints.MapFallbackToPage("/_Host");
   });
  }
 }
```

Like the rest of ASP.NET Core, the Startup class is created with dependency injection principles.  The `IConfiguration` is provided to the constructor and stashed in a public property for later access during configuration.

The `ConfigureServices` method introduced in ASP.NET Core allows for the various ASP.NET Core framework services to be configured for the framework's built-in dependency injection container.  The various `services.Add*` methods add services that enable features such as authentication, razor pages, MVC controller routing, SignalR, and Blazor Server interactions among many others.  This method was not needed in web forms, as the parsing and handling of the ASPX, ASCX, ASHX, and ASMX files was defined by referencing ASP.NET in the web.config configuration file.  More information about dependency injection in ASP.NET Core is available in the [online documentation](https://docs.microsoft.com/aspnet/core/fundamentals/dependency-injection).

The `Configure` method introduces the concept of the HTTP pipeline to ASP.NET Core.  In this method, we declare from top to bottom the [Middleware](middleware.md) that will handle every request sent to our application. Most of these features in the default configuration were scattered across the web forms configuration files and are now in one place for ease of reference.

No longer is the configuration of the custom error page placed in a `web.config` file, but now is configured to always be shown if the application environment is not labeled `Development`.  Additionally, ASP.NET Core applications are now configured to serve secure pages with TLS by default with the `UseHttpsRedirection` method call.

Next, an unexpected configuration method is listed to `UseStaticFiles`.  In ASP.NET Core, support for requests for static files (like JavaScript, CSS, and image files) must be explicitly enabled, and only files in the app's *wwwroot* folder are publicly addressable by default.

The next line is the first that replicates one of the configuration options from web forms: `UseRouting`.  This method adds the ASP.NET Core router to the pipeline and it can be either configured here or in the individual files that it can consider routing to.  More information about routing configuration can be found in the [Routing section](pages-routing-layouts.md).

The final statement in this method defines the endpoints that ASP.NET Core is listening on.  These are the web accessible locations that you can access on the web server and receive some content handled by .NET and returned to you.  The first entry, `MapBlazorHub` configures a SignalR hub for use in providing the real-time and persistent connection to the server where the state and rendering of Blazor components is handled.  The `MapFallbackToPage` method call indicates the web-accessible location of the page that starts the Blazor application and also configures the application to handle deep-linking requests from the client-side.  You will see this feature at work if you open a browser and navigate directly to Blazor handled route in your application, such as `/counter` in the default project template. The request gets handled by the *_Host.cshtml* fallback page, which then runs the Blazor router and renders the counter page.

## Upgrading the BundleConfig Process

Technologies for bundling assets like CSS stylesheets and JavaScript files have evolved significantly, with other technologies providing quickly evolving tools and techniques for managing these resources.  To this end, we recommend using a Node command-line tool such as Grunt / Gulp / WebPack to package your static assets.

The Grunt, Gulp, and WebPack command-line tools and their associated configurations can be added to your application and ASP.NET Core will quietly ignore those files during the application build process.  You can add a call to run their tasks by adding a `Target` inside your project file with syntax similar to the following that would trigger a gulp script and the `min` target inside that script

```xml
<Target Name="MyPreCompileTarget" BeforeTargets="Build">
  <Exec Command="gulp min" />
</Target>
```

More details about both strategies to manage your CSS and JavaScript files are available in the [Bundle and minify static assets in ASP.NET Core](https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification) documentation.

>[!div class="step-by-step"]
>[Previous](project-structure.md)
>[Next](components.md)
