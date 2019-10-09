### Removed Microsoft.AspNetCore.All shared framework

Earlier this year, we announced the `Microsoft.AspNetCore.App` metapackage (see https://github.com/aspnet/Announcements/issues/287). That announcement said:

> The existing `Microsoft.AspNetCore.All` meta-package will continue to be made available throughout the 2.x lifecycle, but **we recommend customers move to the new Microsoft.AspNetCore.App meta-package** and then add individual references to any of the removed packages if their app requires it.

For migration instructions, see [Migrating from Microsoft.AspNetCore.All to Microsoft.AspNetCore.App](/aspnet/core/fundamentals/metapackage?view=aspnetcore-2.1#migrating-from-microsoftaspnetcoreall-to-microsoftaspnetcoreapp).

As of ASP.NET Core 3.0, the `Microsoft.AspNetCore.All` metapackage and the matching `Microsoft.AspNetCore.All` shared framework is no longer produced.

This package will be available in ASP.NET Core 2.2 and will continue to receive servicing updates in ASP.NET Core 2.1.

#### Version introduced

3.0

#### Old behavior

Apps were able to use the `Microsoft.AspNetCore.All` metapackage to target the `Microsoft.AspNetCore.All` shared framework on .NET Core.

#### New behavior

There is no `Microsoft.AspNetCore.All` shared framework as part of .NET Core 3.0.

#### Reason for change

As [previously announced](https://github.com/aspnet/Announcements/issues/287), the `Microsoft.AspNetCore.All` metapackage included a large number of external dependencies.

#### Recommended action

Migrate your app to use the `Microsoft.AspNetCore.App` framework. Components that were previously available in `Microsoft.AspNetCore.All` are **still available on NuGet**. Those components are now deployed with your app instead of being included in the shared framework.

#### Category

ASP.NET Core

#### Affected APIs

Any API that was only present in the `Microsoft.AspNetCore.All` framework.
