### Authorization: IAuthorizationPolicyProvider implementations require new method

In ASP.NET Core 3.0, a new `GetFallbackPolicyAsync` method was added to `IAuthorizationPolicyProvider`. This fallback policy is used by the authorization middleware when no policy is specified.

For more information, see [aspnet/AspNetCore#9759](https://github.com/aspnet/AspNetCore/pull/9759).

#### Version introduced

3.0

#### Old behavior

Implementations of `IAuthorizationPolicyProvider` didn't require a `GetFallbackPolicyAsync` method.

#### New behavior

Implementations of `IAuthorizationPolicyProvider` require a `GetFallbackPolicyAsync` method.

#### Reason for change

A new method was needed for the new `AuthorizationMiddleware` to use when no policy is specified.

#### Recommended action

Add the `GetFallbackPolicyAsync` method to your implementations of `IAuthorizationPolicyProvider`.

#### Category

ASP.NET Core

#### Affected APIs

<xref:Microsoft.AspNetCore.Authorization.IAuthorizationPolicyProvider?displayProperty=fullName>

<!-- 

#### Affected APIs

`T:Microsoft.AspNetCore.Authorization.IAuthorizationPolicyProvider`

-->
