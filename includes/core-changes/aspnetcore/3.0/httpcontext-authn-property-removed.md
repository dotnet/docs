### Removed deprecated HttpContext.Authentication property

As part of [aspnet/AspNetCore#6504](https://github.com/aspnet/AspNetCore/pull/6504), the deprecated `Authentication` property on `HttpContext` has been removed. The `Authentication` property has been deprecated since 2.0. A [migration guide](/aspnet/core/migration/1x-to-2x/identity-2x?view=aspnetcore-2.2#use-httpcontext-authentication-extensions) was published to migrate code using this deprecated property to the new replacement APIs. The remaining unused classes / APIs related to the old ASP.NET Core 1.x authentication stack were removed in commit [aspnet/AspNetCore@d7a7c65](https://github.com/aspnet/AspNetCore/commit/d7a7c65).

To discuss this change, see https://github.com/aspnet/AspNetCore/issues/6533.

#### Version introduced

3.0

#### Old behavior

These APIs were available since 1.0 and were deprecated in 2.0.

#### New behavior

These APIs have been removed in 3.0.

#### Reason for change

The old 1.0 APIs have been replaced by extension methods in the `Microsoft.AspNetCore.Authentication` namespace. The new API is documented [here](/dotnet/api/microsoft.aspnetcore.authentication.authenticationhttpcontextextensions?view=aspnetcore-2.2).

#### Recommended action

The migration guide is available [here](/aspnet/core/migration/1x-to-2x/identity-2x?view=aspnetcore-2.2#use-httpcontext-authentication-extensions).

#### Category

ASP.NET Core

#### Affected APIs

[HttpContext.Authentication](/dotnet/api/microsoft.aspnetcore.http.httpcontext.authentication?view=aspnetcore-1.0)

**Classes**

- Microsoft.AspNetCore.Http.Authentication.AuthenticationManager
- Microsoft.AspNetCore.Http.Authentication.AuthenticateInfo
- Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties
- Microsoft.AspNetCore.Http.Features.Authentication.AuthenticateContext
- Microsoft.AspNetCore.Http.Features.Authentication.ChallengeContext
- Microsoft.AspNetCore.Http.Features.Authentication.ChallengeBehavior
- Microsoft.AspNetCore.Http.Features.Authentication.DescribeSchemesContext
- Microsoft.AspNetCore.Http.Features.Authentication.IAuthenticationHandler
- Microsoft.AspNetCore.Http.Features.Authentication.SignInContext
- Microsoft.AspNetCore.Http.Features.Authentication.SignOutContext

**Properties**

Microsoft.AspNetCore.Http.Features.Authentication.IHttpAuthenticationFeature.Handler
