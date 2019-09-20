---
title: Project structure for Blazor apps
description: Learn how the project structures of ASP.NET Web Forms and Blazor projects compare.
author: danroth27
ms.author: daroth
ms.date: 09/11/2019
---
# Project structure for Blazor apps

[!INCLUDE [book-preview](../../../includes/book-preview.md)]

Despite their significant project structure differences, ASP.NET Web Forms and Blazor share many similar concepts. Here, we'll look at the structure of a Blazor project and compare it to an ASP.NET Web Forms project.

To create your first Blazor app, follow the instructions in the [Blazor getting started steps](/aspnet/core/blazor/get-started). You can follow the instructions to create either a Blazor Server app or a Blazor WebAssembly app hosted in ASP.NET Core. Except for the hosting model-specific logic, most of the code in both projects is the same.

## Project file

Blazor Server apps are .NET Core projects. The project file for the Blazor Server app is about as simple as it can get:

```xml
<Project Sdk="Microsoft.NET.Sdk.Web">

  <PropertyGroup>
    <TargetFramework>netcoreapp3.0</TargetFramework>
  </PropertyGroup>

</Project>
```

The project file for a Blazor WebAssembly app looks slightly more involved (exact version numbers may vary):

```xml
<Project Sdk="Microsoft.NET.Sdk.Web">

  <PropertyGroup>
    <TargetFramework>netstandard2.0</TargetFramework>
    <RazorLangVersion>3.0</RazorLangVersion>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Microsoft.AspNetCore.Blazor" Version="3.1.0" />
    <PackageReference Include="Microsoft.AspNetCore.Blazor.Build" Version="3.1.0" PrivateAssets="all" />
    <PackageReference Include="Microsoft.AspNetCore.Blazor.HttpClient" Version="3.1.0" />
    <PackageReference Include="Microsoft.AspNetCore.Blazor.DevServer" Version="3.1.0" PrivateAssets="all" />
  </ItemGroup>

  <ItemGroup>
    <ProjectReference Include="..\Shared\BlazorWebAssemblyApp1.Shared.csproj" />
  </ItemGroup>

</Project>
```

Blazor WebAssembly projects target .NET Standard instead of .NET Core because they run in the browser on a WebAssembly-based .NET runtime. You can't install .NET into a web browser like you can on a server or developer machine. Consequently, the project references the Blazor framework using individual package references.

By comparison, a default ASP.NET Web Forms project includes almost 300 lines of XML in its *.csproj* file, most of which is explicitly listing the various code and content files in the project. Many of the simplifications in the .NET Core- and .NET Standard-based projects come from the default targets and properties imported by referencing the `Microsoft.NET.Sdk.Web` SDK, often referred to as simply the Web SDK. The Web SDK includes wildcards and other conveniences that simplify inclusion of code and content files in the project. You don't need to list the files explicitly. When targeting .NET Core, the Web SDK also adds framework references to both the .NET Core and ASP.NET Core shared frameworks. The frameworks are visible from the **Dependencies** > **Frameworks** node in the **Solution Explorer** window. The shared frameworks are collections of assemblies that were installed on the machine when installing .NET Core.

Although they're supported, individual assembly references are less common in .NET Core projects. Most project dependencies are handled as NuGet package references. You only need to reference top-level package dependencies in .NET Core projects. Transitive dependencies are included automatically. Instead of using the *packages.config* file commonly found in ASP.NET Web Forms projects to reference packages, package references are added to the project file using the `<PackageReference>` element.

```xml
<ItemGroup>
  <PackageReference Include="Newtonsoft.Json" Version="12.0.2" />
</ItemGroup>
```

## Entry point

The Blazor Server app's entry point is defined in the *Program.cs* file, as you would see in a Console app. When the app executes, it creates and runs a web host instance using defaults specific to web apps. The web host manages the Blazor Server app's lifecycle and sets up host-level services. Examples of such services are configuration, logging, dependency injection, and the HTTP server. This code is mostly boilerplate and is often left unchanged.

```csharp
public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
}
```

Blazor WebAssembly apps also define an entry point in *Program.cs*. The code looks slightly different. The code is similar in that it's setting up the app host to provide the same host-level services to the app. The WebAssembly app host doesn't, however, set up an HTTP server because it executes directly in the browser.

Blazor apps have a `Startup` class instead of a *Global.asax* file to define the startup logic for the app. The `Startup` class is used to configure the app and any app-specific services. In the Blazor Server app, the `Startup` class is used to set up the endpoint for the real-time connection used by Blazor between the client browsers and the server. In the Blazor WebAssembly app, the `Startup` class defines the root components for the app and where they should be rendered. We'll take a deeper look at the `Startup` class in the [App startup](./app-startup.md) section.

## Static files

Unlike ASP.NET Web Forms projects, not all files in a Blazor project can be requested as static files. Only the files in the *wwwroot* folder are web-addressable. This folder is referred to the app's "web root". Anything outside of the app's web root *isn't* web-addressable. This setup provides an additional level of security that prevents accidental exposing of project files over the web.

## Configuration

Configuration in ASP.NET Web Forms apps is typically handled using one or more *web.config* files. Blazor apps don't typically have *web.config* files. If they do, the file is only used to configure IIS-specific settings when hosted on IIS. Instead, Blazor Server apps use the ASP.NET Core configuration abstractions (Blazor WebAssembly apps don't currently support the same configuration abstractions, but that may be a feature added in the future). For example, the default Blazor Server app stores some settings in *appsettings.json*.

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "AllowedHosts": "*"
}
```

We'll learn more about configuration in ASP.NET Core projects in the [Configuration](./config.md) section.

## Razor components

Most files in Blazor projects are *.razor* files. Razor is a templating language based on HTML and C# that is used to dynamically generate web UI. The *.razor* files define components that make up the UI of the app. For the most part, the components are identical for both the Blazor Server and Blazor WebAssembly apps. Components in Blazor are analogous to user controls in ASP.NET Web Forms.

Each Razor component file is compiled into a .NET class when the project is built. The generated class captures the component's state, rendering logic, lifecycle methods, event handlers, and other logic. We'll look at authoring components in the [Building reusable UI components with Blazor](./components.md) section.

The *_Imports.razor* files aren't Razor component files. Instead, they define a set of Razor directives to import into other *.razor* files within the same folder and in its subfolders. For example, a *_Imports.razor* file is a conventional way to add `using` statements for commonly used namespaces:

```razor
@using System.Net.Http
@using Microsoft.AspNetCore.Authorization
@using Microsoft.AspNetCore.Components.Authorization
@using Microsoft.AspNetCore.Components.Forms
@using Microsoft.AspNetCore.Components.Routing
@using Microsoft.AspNetCore.Components.Web
@using Microsoft.JSInterop
@using BlazorApp1
@using BlazorApp1.Shared
```

## Pages

Where are the pages in the Blazor apps? Blazor doesn't define a separate file extension for addressable pages, like the *.aspx* files in ASP.NET Web Forms apps. Instead, pages are defined by assigning routes to components. A route is typically assigned using the `@page` Razor directive. For example, the `Counter` component authored in the *Pages/Counter.razor* file defines the following route:

```razor
@page "/counter"
```

Routing in Blazor is handled client-side, not on the server. As the user navigates in the browser, Blazor intercepts the navigation and then renders the component with the matching route. 

The component routes aren't currently inferred by the component's file location like they are with *.aspx* pages. This feature may be added in the future. Each route must be specified explicitly on the component. Storing routable components in a *Pages* folder has no special meaning and is purely a convention.

We'll look in greater detail at routing in Blazor in the [Pages, routing, and layouts](./pages-routing-layouts.md) section.

## Layout

In ASP.NET Web Forms apps, common page layout is handled using master pages (*Site.Master*). In Blazor apps, page layout is handled using layout components (*Shared/MainLayout.razor*). Layout components will be discussed in more detail in [Page, routing, and layouts](./pages-routing-layouts.md) section.

## Bootstrap Blazor

To bootstrap Blazor, the app must:

* Specify where on the page the root component (*App.Razor*) should be rendered.
* Add the corresponding Blazor framework script.

In the Blazor Server app, the root component's host page is defined in the *_Host.cshtml* file. This file defines a Razor Page, not a component. Razor Pages use Razor syntax to define a server-addressable page, very much like an *.aspx* page. The `Html.RenderComponentAsync<TComponent>(RenderMode)` method is used to define where a root-level component should be rendered. The `RenderMode` option indicates the manner in which the component should be rendered. The following table outlines the supported `RenderMode` options.

|Option                        |Description       |
|------------------------------|------------------|
|`RenderMode.Server`           |Rendered interactively once a connection with the browser is established|
|`RenderMode.ServerPrerendered`|First prerendered and then rendered interactively|
|`RenderMode.Static`           |Rendered as static content|

The script reference to *_framework/blazor.server.js* establishes the real-time connection with the server and then deals with all user interactions and UI updates.

```razor
@page "/"
@namespace BlazorApp1.Pages
@addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>BlazorApp1</title>
    <base href="~/" />
    <link rel="stylesheet" href="css/bootstrap/bootstrap.min.css" />
    <link href="css/site.css" rel="stylesheet" />
</head>
<body>
    <app>
        @(await Html.RenderComponentAsync<App>(RenderMode.ServerPrerendered))
    </app>

    <script src="_framework/blazor.server.js"></script>
</body>
</html>
```

In the Blazor WebAssembly app, the host page is a simple static HTML file under *wwwroot/index.html*. The `<app>` element is used to indicate where the root component should be rendered.

```html
<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width" />
    <title>BlazorApp2</title>
    <base href="/" />
    <link href="css/bootstrap/bootstrap.min.css" rel="stylesheet" />
    <link href="css/site.css" rel="stylesheet" />
</head>
<body>
    <app>Loading...</app>

    <script src="_framework/blazor.webassembly.js"></script>
</body>
</html>
```

The specific component to render is configured in the app's `Startup.Configure` method with a corresponding CSS selector indicating where the component should be rendered.

```csharp
public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
    }

    public void Configure(IComponentsApplicationBuilder app)
    {
        app.AddComponent<App>("app");
    }
}
```

## Build output

When a Blazor project is built, all Razor component and code files are compiled into a single assembly. Unlike ASP.NET Web Forms projects, Blazor doesn't support runtime compilation of the UI logic.

## Run the app

To run the Blazor Server app, press `F5` in Visual Studio. Blazor apps don't support runtime compilation. To see the results of code and component markup changes, rebuild and restart the app with the debugger attached. If you run without the debugger attached (`Ctrl+F5`), Visual Studio watches for file changes and restarts the app as changes are made. You manually refresh the browser as changes are made.

To run the Blazor WebAssembly app, choose one of the following approaches:

* Run the client project directly using the development server.
* Run the server project when hosting the app with ASP.NET Core.

Blazor WebAssembly apps don't support debugging using Visual Studio. To run the app, use `Ctrl+F5` instead of `F5`. You can instead debug Blazor WebAssembly apps directly in the browser. See [Debug ASP.NET Core Blazor](/aspnet/core/blazor/debug) for details.

>[!div class="step-by-step"]
>[Previous](hosting-models.md)
>[Next](app-startup.md)
