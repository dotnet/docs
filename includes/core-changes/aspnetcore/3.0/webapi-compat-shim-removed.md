### Removed Microsoft.AspNetCore.Mvc.WebApiCompatShim

Starting with ASP.NET Core 3.0, the `Microsoft.AspNetCore.Mvc.WebApiCompatShim` package is no longer available.

#### Change description

The `Microsoft.AspNetCore.Mvc.WebApiCompatShim` (WebApiCompatShim) package provides partial compatibility in ASP.NET Core with ASP.NET 4.x Web API 2 to simplify migrating existing Web API implementations to ASP.NET Core. However, apps using the WebApiCompatShim don't benefit from the API-related features shipping in recent ASP.NET Core releases. Such features include improved Open API specification generation, standardized error handling, and client code generation. To better focus the API efforts in 3.0, WebApiCompatShim will be removed. Existing apps using the WebApiCompatShim should migrate to the newer `[ApiController]` model.

#### Version introduced

3.0

#### Reason for change

The Web API compatibility shim was a migration tool. It restricts user access to new functionality added in ASP.NET Core.

#### Recommended action

Remove usage of this shim and migrate directly to the similar functionality in ASP.NET Core itself.

#### Category

ASP.NET Core

#### Affected APIs

<xref:Microsoft.AspNetCore.Mvc.WebApiCompatShim?displayProperty=fullName>

<!--

#### Affected APIs

N:Microsoft.AspNetCore.Mvc.WebApiCompatShim

-->
