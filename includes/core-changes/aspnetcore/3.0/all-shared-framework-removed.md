### Removed Microsoft.AspNetCore.All shared framework

Starting in ASP.NET Core 3.0, the `Microsoft.AspNetCore.All` metapackage and the matching `Microsoft.AspNetCore.All` shared framework are no longer produced. This package is available in ASP.NET Core 2.2 and will continue to receive servicing updates in ASP.NET Core 2.1.

#### Version introduced

3.0

#### Old behavior

Apps could use the `Microsoft.AspNetCore.All` metapackage to target the `Microsoft.AspNetCore.All` shared framework on .NET Core.

#### New behavior

.NET Core 3.0 doesn't include a `Microsoft.AspNetCore.All` shared framework.

#### Reason for change

The `Microsoft.AspNetCore.All` metapackage included a large number of external dependencies.

#### Recommended action

Migrate your project to use the `Microsoft.AspNetCore.App` framework. Components that were previously available in `Microsoft.AspNetCore.All` are still available on NuGet. Those components are now deployed with your app instead of being included in the shared framework.

#### Category

ASP.NET Core

#### Affected APIs

Any API that was only present in the `Microsoft.AspNetCore.All` framework.
