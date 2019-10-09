### IAuthorizationPolicyProvider implementations require a new method

As part of [aspnet/AspNetCore#9759](https://github.com/aspnet/AspNetCore/pull/9759), a new `GetFallbackPolicyAsync` method was added to `IAuthorizationPolicyProvider`. This fallback policy is used by the authorization middleware when no policy is specified.

#### Version introduced

3.0

#### Old behavior

Implementations of `IAuthorizationPolicyProvider` didn't require a `GetFallbackPolicyAsync` method.

#### New behavior

Implementations of `IAuthorizationPolicyProvider` require a `GetFallbackPolicyAsync` method.

#### Reason for change

A new method was needed for the new `AuthorizationMiddleware` to use when no policy is specified.

#### Recommended action

Add `GetFallbackPolicyAsync` method to your implementations of `IAuthorizationPolicyProvider`.

#### Category

ASP.NET Core

#### Affected APIs

[IAuthorizationPolicyProvider](/dotnet/api/microsoft.aspnetcore.authorization.iauthorizationpolicyprovider?view=aspnetcore-2.2)
