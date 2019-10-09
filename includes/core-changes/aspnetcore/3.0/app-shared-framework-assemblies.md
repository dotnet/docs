### Assemblies removed from Microsoft.AspNetCore.App

Starting in ASP.NET Core 3.0, the ASP.NET Core shared framework (`Microsoft.AspNetCore.App`) only contains first-party assemblies that are fully developed, supported, and serviceable by Microsoft. Think of the change as the redefining of boundaries for the ASP.NET Core "platform." The shared framework will be [source-buildable by anybody via GitHub](https://github.com/dotnet/source-build) and will continue to offer the existing benefits of .NET Core shared frameworks to your apps. Some benefits include smaller deployment size, centralized patching, and faster startup time.

As part of the change, some notable breaking changes are introduced in `Microsoft.AspNetCore.App`.

#### Version introduced

3.0

#### Old behavior

Projects referenced `Microsoft.AspNetCore.App` via a `<PackageReference>` element in the project file.

Additionally, `Microsoft.AspNetCore.App` contained the following subcomponents:

- Json.NET (`Newtonsoft.Json`)
- Entity Framework Core (assemblies prefixed with `Microsoft.EntityFrameworkCore.`)
- Roslyn (`Microsoft.CodeAnalysis`)

#### New behavior

A reference to `Microsoft.AspNetCore.App` no longer requires a `<PackageReference>` element in the project file. The .NET Core SDK supports a new element called
`<FrameworkReference>`, which will replace the use of `<PackageReference>`.

For more information, see [aspnet/AspNetCore#3612](https://github.com/aspnet/AspNetCore/issues/3612).

Entity Framework Core ships as NuGet packages. This change aligns the shipping model with all other data access libraries on .NET. It provides Entity Framework Core the simplest path to continue innovating while supporting the various .NET platforms. The move of Entity Framework Core out of the shared framework has no impact on its status as a Microsoft-developed, supported, and serviceable library. The [.NET Core support policy](https://www.microsoft.com/net/platform/support-policy) continues to cover it.

Json.NET and Entity Framework Core continue to work with ASP.NET Core. They won't, however, be included in the shared framework.

For more information, see [The future of JSON in .NET Core 3.0](https://github.com/dotnet/announcements/issues/90). Also see [the complete list of binaries][items-removed-from-fx] removed from the shared framework.

#### Reason for change

This change simplifies the consumption of `Microsoft.AspNetCore.App` and reduces the duplication between NuGet packages and shared frameworks.

For more information on the motivation for this change, see [this blog post][aspnet-blog].

#### Recommended action

It won't be necessary for projects to consume assemblies in `Microsoft.AspNetCore.App` as NuGet packages. To simplify the targeting and usage of the ASP.NET Core shared framework, many NuGet packages shipped since ASP.NET Core 1.0 are no longer produced. The APIs those packages provide are still available to apps by using a `<FrameworkReference>` to `Microsoft.AspNetCore.App`. Common API examples include Kestrel, MVC, and Razor.

This change doesn't apply to all binaries referenced via `Microsoft.AspNetCore.App` in ASP.NET Core 2.x. Notable exceptions include:

- `Microsoft.Extensions` libraries that continue to target .NET Standard will be available as NuGet packages (see https://github.com/aspnet/Extensions)
- APIs produced by the ASP.NET Core team that aren't part of `Microsoft.AspNetCore.App`. For example, the following components are available as NuGet packages:
    - Entity Framework Core
    - APIs that provide third-party integration
    - Experimental features
    - APIs with dependencies that couldn't [fulfill the requirements to be in the shared framework][shared-fx-guidance]
- Extensions to MVC that maintain support for Json.NET. We intend to provide an API as a NuGet package to support using Json.NET and MVC.
- The SignalR .NET client will continue to support .NET Standard and ship as a NuGet package. It's intended for use on many .NET runtimes, such as Xamarin and UWP.

For more information, see [Stop producing packages for shared framework assemblies in 3.0][packages-removed-from-fx]. You can use [aspnet/AspNetCore#3757][discussion] for discussion.

[2.1-lts]: https://www.microsoft.com/net/download/dotnet-core/2.1
[aspnet-blog]: https://blogs.msdn.microsoft.com/webdev/2018/10/29/a-first-look-at-changes-coming-in-asp-net-core-3-0
[discussion]: https://github.com/aspnet/AspNetCore/issues/3757
[items-removed-from-fx]: https://github.com/aspnet/AspNetCore/issues/3755
[packages-removed-from-fx]: https://github.com/aspnet/AspNetCore/issues/3756
[shared-fx-guidance]: https://github.com/aspnet/AspNetCore/blob/4e44e5bcbedd961cc0d4f6b846699c7c494f5597/docs/SharedFramework.md

#### Category

ASP.NET Core

#### Affected APIs

- Json.NET (Newtonsoft.Json)
- Entity Framework Core (assemblies prefixed with `Microsoft.EntityFrameworkCore.`) 
- Roslyn (`Microsoft.CodeAnalysis`)
