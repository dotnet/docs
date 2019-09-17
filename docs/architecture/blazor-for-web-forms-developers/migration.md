---
title: Migrating from ASP.NET Web Forms to Blazor
description: How to approach migrating an existing ASP.NET Web Forms app to Blazor
author: twsouthwick
ms.author: tasou
ms.date: 09/11/2019
---

# Migrating from ASP.NET Web Forms to Blazor

Migrating a code base from ASP.NET Web Forms to Blazor is one that requires
planning and can take time. In this chapter We will go over the process for each
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
to you. The eShop project does not use this, but if your projects use Windows
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

[ TBD: Include link to doc ]

## Migrate .aspx pages

[ TBD: include routing ]

## Blazor components available out of the box

[ TBD ]

## Migrate user controls

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

[ TBD ]
