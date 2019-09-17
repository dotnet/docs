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

## Choosing server side vs client side

[ TBD ]

## Create a new project

This initial step to begin is to create a new project. This project type is
based on the SDK style projects of .NET Core and simplifies much of the boiler
plate that was used in previous project formats. For more detail, please see the
chapter on [Project Structure](./project-structure).

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

[ TBD ]

## Migrate HTTP modules and handlers to middleware

[ TBD: Link to current doc ]

## Migrate static files

[ TBD: Include link to doc ]

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

[ TBD: Include link]

## Integrate dependency injection

[ TBD ]

## Architectural changes

[ TBD ]
