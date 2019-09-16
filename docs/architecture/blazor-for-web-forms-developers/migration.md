---
title: Migrating from ASP.NET Web Forms to Blazor
description: How to approach migrating an existing ASP.NET Web Forms app to Blazor
author: twsouthwick
ms.author: tasou
ms.date: 09/11/2019
---

# Migrating from ASP.NET Web Forms to Blazor

Migrating a code base from ASP.NET Web Forms to Blazor is one that requires
planning and can take time. The process can be broken into two main parts:

1. Update the business logic projects to run on .NET Core/.NET Standard
1. Convert the app model from WebForms to Blazor

In this chapter we will go over the process for each of these. One thing that
can really help ease the transition is to ensure the application is adhering to
an *n-tier* approach, where the app model (in this case Web Forms) is separate
from the business logic. Without this separation it can be very tedious to tease
apart what needs to be moved to .NET Core and Blazor vs what can be left behind.

## Move supporting libraries to .NET Standard

The patterns to move supporting libraries to .NET Standard is the same
regardless of which app model one is moving to. These steps are:

1. Analyze assemblies with .NET Portability Analyzer and develop a plan to move
   to .NET Standard
1. Convert project files to new SDK style
1. Update all dependencies to latest versions
1. Update project to run on .NET 4.7.2 or higher
1. Enable Windows Compatibility Pack
1. Move to .NET Standard

### Analyze assemblies with .NET Portability Analyzer

The first step in making a move to .NET Standard is to understand the holistic
view of the application and its dependencies. The [.NET Portability
Analyzer](https://github.com/Microsoft/dotnet-apiport) can help in this task. It
will take as input all the assemblies that you are interested in porting and
give a report as to how many APIs are in used that will not be available in .NET
Standard.

When looking at the report and devising a plan for migration, it is important to
start at the leaf nodes of the application's dependency graph. The .NET
Portability Analyzer has a report it can build that will provide a graph output
of the dependencies so you can identify the leaf nodes. A useful way of running
the command is to request both the graph output (DGML) and the Excel output:

```
apiport.exe -f [path/to/folder] -r dgml -r excel
```

The `.dgml` output can be opened in Visual Studio to view a graph
representation, while the `.xslx` file can be opened in Excel. The output in
Excel is useful as the full power of filtering and analysis that Excel provides
will be available.

When using this tool, it is also important to only submit user code; third-party
dependencies will be addressed at a later stage.

### Convert project files to new SDK style

The next step in converting a code base to support .NET Core is to ready the
project files themselves. A new, leaner style of `.csproj` and `.vbproj` is
supported for .NET Core that removes much of the extraneous information that was
required but proved difficult to maintain. Some of the benefits of this approach
are:

1. Source code is implicitly included in the project (with easy opt-out if needed)
1. NuGet packages are referenced in the project file and their dependencies are
   automatically brought in without needing to explicitly list them
1. Globbing is better supported for including/excluded files
1. AssemblyInfo properties can be controlled by the project file, which is
   helpful for build-time setting of versions, copyright, and other assembly
   level attributes.

A basic `csproj` file will now look like the following code:

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net46</TargetFramework>
  </PropertyGroup>
  <ItemGroup>
    <PackageReference Include="Newtonsoft.Json" Version="11.0.1" />
  </ItemGroup>
</Project>
```

For more information on the SDK style of project, see the [documentation](https://docs.microsoft.com/dotnet/core/tools/csproj).

### Update all dependencies to latest versions

One of the most difficult parts of moving to .NET Core is ensuring that
third-party dependencies will continue to work once ported. Since often the
source code for these libraries is not available, you are not able to rebuild to
target .NET Standard. Many dependencies, however, have been ported to support
.NET Standard. By updating to the latest versions, you are most likely to have a
supported package.

In cases where .NET Standard is not supported, there is also the option of being
able to run libraries compiled for .NET Framework on .NET Core. Starting with
.NET Standard 2.0, a .NET Framework compatibility mode was introduced that
allows libraries compiled against the .NET Framework to run on .NET Core. These
libraries will not magically find APIs that don't exist, so there is the chance
that they will fail at runtime; thus, targeted testing of the scenarios these
libraries are used for is recommended. A warning will appear at build time that
there were restored for .NET Framework. Although this scenario may cause some
errors, it may also help unblock some porting scenarios.

For more information on supporting third-party dependencies, see the
[documentation](https://docs.microsoft.com/dotnet/core/porting/third-party-deps).

### Update project to run on .NET 4.7.2 or higher

.NET Framework 4.x is produced as a machine-wide framework that is updated
in-place. This has created the need for a high bar of compatibility for
subsequent versions. The main way this has been accomplished is with the
introduction of quirks. These quirks are defined by a combination of what
framework the application was compiled against as well as the version of the
runtime that is being used.

For example, in .NET Framework 4.5, the algorithm used by `List.Sort` was
changed from a quick sort to an introspective sort. Both of these sorting
algorithms are considered unstable (where items that are equal may not be in the
same order each time), but users may have taken a dependency on the ordering of
the order of these unstable elements. In order to preserve this old behavior, a
quirk was added that would continue to use the quick sort in later versions if
the application targeted .NET Framework 4.0 but ran on .NET 4.5 or later.
However, if the application were to be retargeted to .NET Framework 4.5 or
later, then it would automatically opt into the introspective sort.

The majority of these kinds of breaking changes are manifest when an application
takes a dependency on an implementation detail (such as the undefined behavior
of an unstable sort). To review what possible changes may impact your
application, see the
[documentation](https://docs.microsoft.com/dotnet/framework/migration-guide/application-compatibility)
for this topic.

### Enable Windows Compatibility Pack

At this point, we are ready at a tooling level to make the switch to .NET
Standard. However, there may still be APIs in the application that are not
supported. Some of these types may be available via the [Windows Compatibility
Pack](https://docs.microsoft.com/dotnet/core/porting/windows-compat-pack). This
package adds support for around 20,000 APIs, including registry, WMI, Directory
Services, among many more areas.

Some of the high-level areas that are not supported in .NET Core:

- AppDomains
- Remoting
- Code Access Security
- Security Transparency
- System.EnterpriseServices

For more information on areas that are not supported, see the [documentation](https://docs.microsoft.com/dotnet/core/porting/net-framework-tech-unavailable).

### Move to .NET Standard

Having moved to SDK-style project files, moved to .NET 4.7.2 or later, and
mitigated unsupported APIs, the project is now ready to be switched to .NET
Standard. This change is as simple as changing:

```
<TargetFramework>net472</TargetFramework>
```

to 

```
<TargetFramework>netstandard2.0</TargetFramework>
```

If a .NET Framework version of the library is still needed for some reason (such
as another dependency requiring it), the library can be multi-targeted so that
both will be available when needed:

```
<TargetFrameworks>net472;netstandard2.0</TargetFrameworks>
```

Notice that here `TargetFrameworks` is used rather than `TargetFramework`. This
is what is meant as multi-targeting and can be helpful while porting a large
solution over to .NET Standard when some upstream components still need a .NET
Framework build of the library.

Once the target framework has been updated, the project has been updated to .NET
Standard. This process will need to be continued for each project up the
dependency tree as discovered by the .NET Portability Analyzer. Once all
dependencies have been updated, then the application will be ready to be moved
to Blazor.

## Convert WebForms to Blazor

Migrating an application from WebForms to Blazor presents a number of changes in
the way the framework handles things. Other chapters will go in depth in some of
these, but some are presented here as they are good to know but may not warrant
their own chapter.

### Task based with no custom synchronization context

One of the biggest differences for developers coming from WebForms is the way
requests are handled from a threading perspective. In WebForms, as well as all
ASP.NET frameworks before .NET Core, there is a custom `SynchronizationContext`
that is used to maintain state for a request. In ASP.NET Core, however, this has
been removed and everything is async. State is managed by per request with the
built in dependency injection support. This means properties such as
`HttpContext.Current` no longer exist and must be accessed via the provider
`IHttpContextAccessor.HttpContext`.

Tasks are used throughout the stack and should be used all the way down.
Although making a method return a `Task` is a viral and can affect all calling
methods, any place where `Task.Wait()` or similar is called can adversely affect
performance. This is a blocking call and will cause threads to be unuseable by
the rest of the pipeline. Since the ThreadPool is used for this, it can cause
performance degradation as threads become locked up and are unavailable for
queued work.

### Built in general abstractions 

ASP.NET Core provides many general abstractions that allow for a clean
separation of service from implementation. Services like logging, configuration,
and dependency injection can be abstracted away via some common interfaces that
have default implementations or can wrap well-known 3rd party libraries. For
example, although the logging infrastructure by default outputs with a simple
logging provider, it can easily be replaced with anything else, including
log4net, NLog, and Serilog (among many others).

### Centralized start up method

In WebForms, there there a number of ways to configure the application from `web.config`, `Global.asax`, and Owin. In ASP.NET Core, this is simplified to a single startup class that handles two steps:

- Configure services required in the application
  
  Dependency injection is built into ASP.NET Core from the bottom up so
  everything can be considered a service that can be scoped how needed. This can
  be per-instance, per-request, or an application singleton. This startup method
  allows you to add services for your own application, as well as override
  system ones with your own implementation.

- Configure pipeline of middleware

  Middleware can be thought of as handlers that take a request in and has the
  ability to process it before or after sending it on to the next piece of
  middleware. There are many built in middleware that can be added into the
  pipeline, as well as easy ways to add your own implementations to do things
  like inspect or add headers, exception handling, logging, and many more. This
  will be discussed more in depth in the chapter on
  [Middleware](./middleware.md).

## Example of code changes

We'll demonstrate some of these code changes by looking at the [eShopOnBlazor](https://github.com/dotnet-architecture/eShopOnBlazor) project. This project is a simple eShop that allows a user to perform simple CRUD operations on a catalog. We will look specifically at the Create page and the changes required to make that work.

### Start up changes

In Blazor, the startup process is the same as other ASP.NET Core frameworks.
This is greatly simplified from traditional ASP.NET where everything that is
included is in the start up class itself. Comparing `Global.asax.cs` vs
`Startup.cs`, the separation of the start up into services and pipeline make it
clear what is being registered. In WebForms, dependency injection was not
something that was built into the project, but something you could add on. For
projects that wanted to use it, it was difficult to get things hooked up right,
as can be seen in `Global.asax.cs` as the container has to be wired up
manually.This is done for you in ASP.NET Core. Anything that is required for
startup that had been in `Global.asax` can be added into this file to configure
the ASP.NET pipeline.

### Code behind vs razor page

In WebForms, a page was defined by three files: Create.aspx,
Create.aspx.designer.cs and Create.aspx.cs. In Blazor, it is all done in the
same file, with any code generation from the HTML elements occurring behind the
scenes (equivalent to the `*designer.cs` files).

The first thing that you will see is that the syntax is slightly different from
WebForms to Razor. WebForms components are brought in by a tag similar to
`<asp:SomeComponent>` while in Blazor this will look like `<SomeComponent>`. The
Razor compiler will understand that this is a Razor component and will handle it
appropriately. The syntax to start injecting code is different, too; instead of
`<%= %>` or `<%# =>`, code can be injected into a razor file by adding `@`
before.

For example, in order to add a field to the Create component, we change the
following WebForms:

```
<div class="form-group">
    <label class="control-label col-md-2">Name</label>
    <div class="col-md-3">
        <asp:TextBox ID="Name" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator runat="server" ControlToValidate="Name" Display="Dynamic"
            CssClass="field-validation-valid text-danger" ErrorMessage="The Name field is required." />
    </div>
</div>
```

to

```
<div class="form-group">
    <label class="control-label col-md-2">Name</label>
    <div class="col-md-3">
        <InputText class="form-control" @bind-Value="_item.Name" />
        <ValidationMessage For="(() => _item.Name)" />
    </div>
</div>
```

Notice how `<InputText>` and `<ValidationMessage>` look just like HTML
components, but are evaluated on the server side. Some code expressions are
mixed in as well, often brought in by `@`, such as `@bind-Value="_item.Name"`.

A new feature of Razor compared to WebForms is the ability to inject components
directly into a page. Since dependency injection is built in from the ground up,
there is first class support for it everywhere.  In `Create.razor` the following
is at the top of the page:

```
@inject ICatalogService CatalogService
@inject IUriHelper UriHelper;
@inject ILogger<Create> _logger;
```

This will bring in those services so that the component has access to them.
