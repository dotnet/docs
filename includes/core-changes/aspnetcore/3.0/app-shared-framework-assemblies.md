### Assemblies removed from Microsoft.AspNetCore.App

Starting in ASP.NET Core 3.0, the ASP.NET Core shared framework (`Microsoft.AspNetCore.App`) will only contain first-party assemblies that are fully developed, supported, and serviceable by Microsoft. Think of this as constituting the ASP.NET Core "platform." It will be fully [source buildable by anybody via GitHub](https://github.com/dotnet/source-build) and will continue to bring all the existing benefits of .NET Core shared frameworks to your apps. Some benefits include smaller deployment size, centralized patching, and faster startup time. 

As part of this change, some notable breaking changes will be made in `Microsoft.AspNetCore.App`.

#### Version introduced

3.0

#### Old behavior

Projects referenced `Microsoft.AspNetCore.App` via a `<PackageReference>` element in the project file.

Additionally, `Microsoft.AspNetCore.App` contained the following subcomponents:

- Json.NET (`Newtonsoft.Json`)
- Entity Framework Core (assemblies prefixed with `Microsoft.EntityFrameworkCore.`) 
- Roslyn (`Microsoft.CodeAnalysis`)

#### New behavior

References to `Microsoft.AspNetCore.App` will no longer be a `<PackageReference>` element in the project file. The .NET Core SDK will support a new element called
`<FrameworkReference>`, which will replace the use of `<PackageReference>`. Changes to support this new item type are already under way.

For more information, see [aspnet/AspNetCore#3612](https://github.com/aspnet/AspNetCore/issues/3612).

Entity Framework Core will ship as "pure" NuGet packages in 3.0. This change makes its shipping model the same as all other data access libraries on .NET. It provides Entity Framework Core the simplest path to continue innovating while providing support for all the various .NET platforms customers enjoy it on today. Note, Entity Framework Core moving out of the shared framework has no impact on its status as a Microsoft-developed, supported, and serviceable library. It will continue to be covered by the [.NET Core support policy](https://www.microsoft.com/net/platform/support-policy).

Json.NET and Entity Framework Core will continue to work with ASP.NET Core. They won't, however, be included in the shared framework.

See [The future of JSON in .NET Core 3.0](https://github.com/dotnet/announcements/issues/90) for details on our plans to remove the dependency from ASP.NET Core to Json.NET and replace it with high-performance JSON APIs.

We have separately posted [a complete list of exact binaries][items-removed-from-fx] that are being removed. This list may fluctuate as we continue to work on ASP.NET Core 3.0.

#### Reason for change

This change simplifies the consumption of `Microsoft.AspNetCore.App` and reduces the duplication between NuGet packages and shared frameworks.

For more information on the motivation for this change, see [this blog post][aspnet-blog].

#### Recommended action

As result of these changes, it won't be necessary for projects to consume assemblies in `Microsoft.AspNetCore.App` as NuGet packages. To simplify the way in which consumers target and use the ASP.NET Core shared framework, we will stop producing many of the NuGet packages that we have been shipping since ASP.NET Core 1.0. The API those packages provide are still available to apps by using a `<FrameworkReference>` to `Microsoft.AspNetCore.App`. This includes commonly referenced APIs, such as Kestrel, MVC, Razor, and others.

This won't apply to all binaries that are pulled in via `Microsoft.AspNetCore.App` in 2.x. Notable exceptions include:

- `Microsoft.Extensions` libraries that continue to target .NET Standard will be available as NuGet packages (see https://github.com/aspnet/Extensions)
- APIs produced by the ASP.NET Core team that aren't part of `Microsoft.AspNetCore.App`. For example, the following components will ship as NuGet packages instead of being included in the shared framework:
    - Entity Framework Core
    - APIs that provide third-party integration
    - Experimental features
    - APIs with dependencies that couldn't [fulfill the requirements to be in the shared framework][shared-fx-guidance]
- Extensions to MVC that maintain support for Json.NET. We intend to provide an API as a NuGet package to support using Json.NET and MVC.
- The SignalR .NET client will continue to support .NET Standard and ship as a NuGet package. It's intended for use on many .NET runtimes, such as Xamarin and UWP.

For more information, see the [complete list of packages that will only be obsolete in favor of <FrameworkReference>][packages-removed-from-fx].

You can use [aspnet/AspNetCore#3757][discussion] for discussion.

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
