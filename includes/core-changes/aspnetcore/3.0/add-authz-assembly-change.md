### AddAuthorization overload moved to a different assembly

The core `AddAuthorization` methods that used to reside in `Microsoft.AspNetCore.Authorization` were renamed to `AddAuthorizationCore`. The old `AddAuthorization` methods still exist, but are in the `Microsoft.AspNetCore.Authorization.Policy` package instead. Apps using both methods should see no impact. Apps that weren't using the policy package must switch to using `AddAuthorizationCore`.

#### Version introduced

3.0

#### Old behavior

`AddAuthorization` methods existed in `Microsoft.AspNetCore.Authorization`.

#### New behavior

`AddAuthorization` methods exist in `Microsoft.AspNetCore.Authorization.Policy`. `AddAuthorizationCore` is the new name for the old methods.

#### Reason for change

`AddAuthorization` is a better method name for adding all common services needed for authorization.

#### Recommended action

Either add a reference to `Microsoft.AspNetCore.Authorization.Policy` or use `AddAuthorizationCore` instead.

#### Category

ASP.NET Core

#### Affected APIs

<xref:Microsoft.Extensions.DependencyInjection.AuthorizationServiceCollectionExtensions.AddAuthorization(Microsoft.Extensions.DependencyInjection.IServiceCollection,System.Action{Microsoft.AspNetCore.Authorization.AuthorizationOptions})?displayProperty=fullName>

<!--
#### Affected APIs

`M:Microsoft.Extensions.DependencyInjection.AuthorizationServiceCollectionExtensions.AddAuthorization(Microsoft.Extensions.DependencyInjection.IServiceCollection,System.Action{Microsoft.AspNetCore.Authorization.AuthorizationOptions})`

-->
