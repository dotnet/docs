### AddAuthorization overload lives in a different assembly

The core `AddAuthorization` methods that used to live in `Microsoft.AspNetCore.Authorization` were renamed to `AddAuthorizationCore`. The old `AddAuthorization` methods still exist, but are in the `Microsoft.AspNetCore.Authorization.Policy` package instead. Apps using both methods should see no impact. Apps that weren't using the policy package must switch to using `AddAuthorizationCore`.

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

[AddAuthorization(Action<AuthorizationOptions>)](/dotnet/api/microsoft.extensions.dependencyinjection.authorizationservicecollectionextensions.addauthorization?view=aspnetcore-2.2#Microsoft_Extensions_DependencyInjection_AuthorizationServiceCollectionExtensions_AddAuthorization_Microsoft_Extensions_DependencyInjection_IServiceCollection_System_Action_Microsoft_AspNetCore_Authorization_AuthorizationOptions__)
