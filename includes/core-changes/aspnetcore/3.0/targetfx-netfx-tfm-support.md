### Target framework: .NET Framework support dropped

Starting with ASP.NET Core 3.0, .NET Framework is an unsupported target framework.

#### Change description

.NET Framework 4.8 is the last major version of .NET Framework. New ASP.NET Core apps should be built on .NET Core. Starting with the .NET Core 3.0 release, you can think of ASP.NET Core 3.0 as being part of .NET Core.

Customers using ASP.NET Core with .NET Framework can continue in a fully supported fashion using the [2.1 LTS release](https://www.microsoft.com/net/download/dotnet-core/2.1). Support and servicing for 2.1 continues until at least August 21, 2021. This date is three years after declaration of the LTS release per the [.NET Support Policy](https://www.microsoft.com/net/platform/support-policy). Support for ASP.NET Core 2.1 packages **on .NET Framework** will extend indefinitely, similar to the [servicing policy for other package-based ASP.NET frameworks](https://dotnet.microsoft.com/platform/support/policy/aspnet).

For more information about porting from .NET Framework to .NET Core, see [Porting to .NET Core](~/docs/core/porting/index.md).

`Microsoft.Extensions` packages (such as logging, dependency injection, and configuration) and Entity Framework Core aren't affected. They'll continue to support .NET Standard.

For more information on the motivation for this change, see [the original blog post](https://blogs.msdn.microsoft.com/webdev/2018/10/29/a-first-look-at-changes-coming-in-asp-net-core-3-0).

#### Version introduced

3.0

#### Old behavior

ASP.NET Core apps could run on either .NET Core or .NET Framework.

#### New behavior

ASP.NET Core apps can only be run on .NET Core.

#### Recommended action

Take one of the following actions:

- Keep your app on ASP.NET Core 2.1.
- Migrate your app and dependencies to .NET Core.

#### Category

ASP.NET Core

#### Affected APIs

None

<!-- 

#### Affected APIs

Not detectable via API analysis

-->
