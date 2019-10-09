### Deprecated ASP.NET Core MVC precompilation tool

In ASP.NET Core 1.1, the `Microsoft.AspNetCore.Mvc.Razor.ViewCompilation` (MVC precompilation tool) package was introduced to add support for publish-time compilation of Razor files (*.cshtml* files). In ASP.NET Core 2.1, the [Razor SDK](/aspnet/core/razor-pages/sdk?view=aspnetcore-2.1) was introduced to expand upon features of the precompilation tool. The Razor SDK added support for build- and publish-time compilation of Razor files. The SDK verifies the correctness of *.cshtml* files at build time while improving on app startup time. The Razor SDK is on by default, and no gesture is required to start using it.

In ASP.NET Core 3.0, the ASP.NET Core 1.1-era MVC precompilation tool was removed. Earlier package versions will continue receiving important bug and security fixes in the patch release. 

For users of ASP.NET Core 2.1 or later, migrate to the Razor SDK. If bugs or missing features prevent migration to the Razor SDK, open an issue at https://github.com/aspnet/Razor/issues.

#### Version introduced

3.0

#### Old behavior

The `Microsoft.AspNetCore.Mvc.Razor.ViewCompilation` package was used to pre-compile MVC Razor views.

#### New behavior

The Razor SDK natively supports this functionality. The `Microsoft.AspNetCore.Mvc.Razor.ViewCompilation` package is no longer updated.

#### Reason for change

The Razor SDK provides more functionality and verifies the correctness of *.cshtml* files at build time. The SDK also improves app startup time.

#### Recommended action

Update to use the native support for precompilation in the [Razor SDK](/aspnet/core/razor-pages/sdk?view=aspnetcore-3.0).

#### Category

ASP.NET Core

#### Affected APIs

Not detectable via API analysis
