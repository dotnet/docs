### ASP.NET Core 3.0 only runs on .NET Core

.NET Framework will get less of the new platform and language features that come to .NET Core. The reasoning is the in-place update nature of .NET Framework and the decision to limit changes there that might break existing apps. To ensure ASP.NET Core can use the improvements coming to .NET Core, ASP.NET Core will only run on .NET Core starting from 3.0. You can think of ASP.NET Core 3.0 as being part of .NET Core.

Customers using ASP.NET Core with .NET Framework can continue in a fully supported fashion using the [2.1 LTS release][2.1-lts]. Support and servicing for 2.1 continues until at least August 21, 2021. This date is three years after declaration of the LTS release per the [.NET Support Policy](https://www.microsoft.com/net/platform/support-policy). Support for ASP.NET Core 2.1 packages **on .NET Framework** will extend indefinitely, similar to the [servicing policy for other package-based ASP.NET frameworks](https://dotnet.microsoft.com/platform/support/policy/aspnet).

For more information about porting from .NET Framework to .NET Core, see [Porting to .NET Core.](/dotnet/core/porting/).

`Microsoft.Extensions` packages (such as logging, dependency injection, and configuration) and Entity Framework Core aren't affected. They'll continue to support .NET Standard.

For more information on the motivation for this change, see [the original blog post][aspnet-blog].

[2.1-lts]: https://www.microsoft.com/net/download/dotnet-core/2.1
[dotnet-blog]: https://blogs.msdn.microsoft.com/dotnet/2018/10/04/update-on-net-core-3-0-and-net-framework-4-8/
[aspnet-blog]: https://blogs.msdn.microsoft.com/webdev/2018/10/29/a-first-look-at-changes-coming-in-asp-net-core-3-0
[discussion]: https://github.com/aspnet/AspNetCore/issues/3753

#### Version introduced

3.0

#### Old behavior

ASP.NET Core apps could run on either .NET Core or .NET Framework.

#### New behavior

ASP.NET Core apps can only be run on .NET Core.

#### Reason for change

.NET Framework will receive less of the new platform and language features that come to .NET Core. The reasoning is the in-place update nature of .NET Framework and the decision to limit breaking changes to existing apps. To ensure ASP.NET Core can adopt the improvements coming to .NET Core, ASP.NET Core will only run on .NET Core.

#### Recommended action

- Keep your app on ASP.NET Core 2.1
- Migrate your app and dependencies to .NET Core

#### Category

ASP.NET Core

#### Affected APIs

Not detectable via API analysis
