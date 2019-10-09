### IHostingEnvironment and IApplicationLifetime types marked obsolete and replaced

New types have been introduced to replace existing `IHostingEnvironment` and `IApplicationLifetime` types.

#### Version introduced

3.0

#### Old behavior

There were two different `IHostingEnvironment` and `IApplicationLifetime` types from `Microsoft.Extensions.Hosting` and `Microsoft.AspNetCore.Hosting`.

#### New behavior

The old types have been obsoleted and replaced by new types.

#### Reason for change

When `Microsoft.Extensions.Hosting` was introduced in ASP.NET Core 2.1, some types like `IHostingEnvironment` and `IApplicationLifetime` were copied from `Microsoft.AspNetCore.Hosting`. Some ASP.NET Core 3.0 changes cause apps to include both the `Microsoft.Extensions.Hosting` and `Microsoft.AspNetCore.Hosting` namespaces. Any use of those duplicate types causes an "ambiguous reference" compiler error when both namespaces are referenced.

#### Recommended action

Replaced any usages of the old types with the newly introduced types as below:

**Obsolete types (warning):**

- `Microsoft.Extensions.Hosting.IHostingEnvironment`
- `Microsoft.AspNetCore.Hosting.IHostingEnvironment`
- `Microsoft.Extensions.Hosting.IApplicationLifetime`
- `Microsoft.AspNetCore.Hosting.IApplicationLifetime`
- `Microsoft.Extensions.Hosting.EnvironmentName`
- `Microsoft.AspNetCore.Hosting.EnvironmentName`

**New types:**

- `Microsoft.Extensions.Hosting.IHostEnvironment`
- `Microsoft.AspNetCore.Hosting.IWebHostEnvironment : IHostEnvironment`
- `Microsoft.Extensions.Hosting.IHostApplicationLifetime`
- `Microsoft.Extensions.Hosting.Environments`

Note the new `IHostEnvironment` `IsDevelopment`, `IsProduction`, etc. extension methods are in the `Microsoft.Extensions.Hosting` namespace. That namespace may need to be added to your project.

#### Category

ASP.NET Core

#### Affected APIs

- [Microsoft.Extensions.Hosting.IHostingEnvironment](/dotnet/api/microsoft.extensions.hosting.ihostingenvironment?view=aspnetcore-2.2)
- [Microsoft.AspNetCore.Hosting.IHostingEnvironment](/dotnet/api/microsoft.aspnetcore.hosting.ihostingenvironment?view=aspnetcore-2.2)
- [Microsoft.Extensions.Hosting.IApplicationLifetime](/dotnet/api/microsoft.extensions.hosting.iapplicationlifetime?view=aspnetcore-2.2)
- [Microsoft.AspNetCore.Hosting.IApplicationLifetime](/dotnet/api/microsoft.aspnetcore.hosting.iapplicationlifetime?view=aspnetcore-2.2)
- [Microsoft.Extensions.Hosting.EnvironmentName](/dotnet/api/microsoft.extensions.hosting.environmentname?view=aspnetcore-2.2)
- [Microsoft.AspNetCore.Hosting.EnvironmentName](/dotnet/api/microsoft.aspnetcore.hosting.environmentname?view=aspnetcore-2.2)
