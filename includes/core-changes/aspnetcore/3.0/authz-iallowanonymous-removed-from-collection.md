### Authorization: IAllowAnonymous removed from AuthorizationFilterContext.Filters

As of ASP.NET Core 3.0, MVC doesn't add [AllowAnonymousFilters](xref:Microsoft.AspNetCore.Mvc.Authorization.AllowAnonymousFilter) for [[AllowAnonymous]](xref:Microsoft.AspNetCore.Authorization.AllowAnonymousAttribute) attributes that were discovered on controllers and action methods. This change is addressed locally for derivatives of <xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute>, but it's a breaking change for <xref:Microsoft.AspNetCore.Mvc.Filters.IAsyncAuthorizationFilter> and <xref:Microsoft.AspNetCore.Mvc.Filters.IAuthorizationFilter> implementations. Such implementations wrapped in a [[TypeFilter]](xref:Microsoft.AspNetCore.Mvc.TypeFilterAttribute) attribute are a [popular](https://stackoverflow.com/a/41348219/608220) and supported way to achieve strongly-typed, attribute-based authorization when both configuration and dependency injection are required.

#### Version introduced

3.0

#### Old behavior

<xref:Microsoft.AspNetCore.Authorization.IAllowAnonymous> appeared in the [AuthorizationFilterContext.Filters](xref:Microsoft.AspNetCore.Mvc.Filters.FilterContext.Filters%2A) collection. Testing for the interface's presence was a valid approach to override or disable the filter on individual controller methods.

#### New behavior

`IAllowAnonymous` no longer appears in the `AuthorizationFilterContext.Filters` collection. `IAsyncAuthorizationFilter` implementations that are dependent on the old behavior typically cause intermittent HTTP 401 Unauthorized or HTTP 403 Forbidden responses.

#### Reason for change

A new endpoint routing strategy was introduced in ASP.NET Core 3.0.

#### Recommended action

Search the endpoint metadata for `IAllowAnonymous`. For example:

```csharp
var endpoint = context.HttpContext.GetEndpoint();
if (endpoint?.Metadata?.GetMetadata<IAllowAnonymous>() != null)
{
}
```

An example of this technique is seen in [this HasAllowAnonymous method](https://github.com/aspnet/AspNetCore/blob/bd65275148abc9b07a3b59797a88d485341152bf/src/Mvc/Mvc.Core/src/Authorization/AuthorizeFilter.cs#L236).

#### Category

ASP.NET Core

#### Affected APIs

None

<!--

#### Affected APIs

Not detectable via API analysis

-->
