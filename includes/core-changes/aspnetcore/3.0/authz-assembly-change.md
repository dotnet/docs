### Authorization: AddAuthorization overload moved to different assembly

The core `AddAuthorization` methods that used to reside in `Microsoft.AspNetCore.Authorization` were renamed to `AddAuthorizationCore`. The old `AddAuthorization` methods still exist, but are in the `Microsoft.AspNetCore.Authorization.Policy` assembly instead. Apps using both methods should see no impact. Note that `Microsoft.AspNetCore.Authorization.Policy` now ships in the shared framework rather than a standalone package as discussed in [Shared framework: Assemblies removed from Microsoft.AspNetCore.App](#shared-framework-assemblies-removed-from-microsoftaspnetcoreapp).

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
